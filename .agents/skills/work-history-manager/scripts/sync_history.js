const fs = require('fs');
const path = require('path');

const WORKSPACE_ROOT = path.resolve(__dirname, '../../../../');
const HISTORY_FILE = path.join(WORKSPACE_ROOT, 'WORK_HISTORY.md');

// 요일 구하기
function getDayOfWeek(dateStr) {
  const days = ['일', '월', '화', '수', '목', '금', '토'];
  const d = new Date(dateStr);
  return isNaN(d.getDay()) ? '' : days[d.getDay()];
}

// 오늘 날짜 문자열 (YYYY-MM-DD)
function getTodayString() {
  const now = new Date();
  const year = now.getFullYear();
  const month = String(now.getMonth() + 1).padStart(2, '0');
  const day = String(now.getDate()).padStart(2, '0');
  return `${year}-${month}-${day}`;
}

// 파일 안전하게 읽기 (UTF-8)
function readHistoryFile() {
  if (!fs.existsSync(HISTORY_FILE)) {
    throw new Error(`WORK_HISTORY.md 파일을 찾을 수 없습니다: ${HISTORY_FILE}`);
  }
  let content = fs.readFileSync(HISTORY_FILE, 'utf8');
  // BOM 제거 (문자열 처리용)
  if (content.charCodeAt(0) === 0xFEFF) {
    content = content.slice(1);
  }
  return content;
}

// 파일 안전하게 쓰기 (UTF-8 with BOM + CRLF)
function writeHistoryFile(content) {
  // 개행 CRLF 통일
  let normalized = content.replace(/\r\n/g, '\n').replace(/\r/g, '\n').replace(/\n/g, '\r\n');
  const bom = Buffer.from([0xEF, 0xBB, 0xBF]);
  const buf = Buffer.concat([bom, Buffer.from(normalized, 'utf8')]);
  fs.writeFileSync(HISTORY_FILE, buf);
}

// 1. 최신 작업 내역 및 WIP 읽기
function readLatest() {
  const content = readHistoryFile();
  const lines = content.split(/\r?\n/);

  let latestDate = '';
  let latestDateIndex = -1;
  let wipIndex = -1;

  for (let i = 0; i < lines.length; i++) {
    const line = lines[i];
    if (line.startsWith('## 🕒 ') && !latestDate) {
      latestDate = line.replace('## 🕒 ', '').replace(' 작업 내역', '').trim();
      latestDateIndex = i;
    }
    if (line.includes('## 🚀 현재 작업 상태 및 다음 작업 대기열')) {
      wipIndex = i;
    }
  }

  // 최신 날짜의 작업 섹션 추출
  let taskSection = [];
  if (latestDateIndex !== -1) {
    for (let i = latestDateIndex + 1; i < lines.length; i++) {
      if (lines[i].startsWith('## 🕒 ') || lines[i].startsWith('## 🚀 ')) {
        break;
      }
      taskSection.push(lines[i]);
    }
  }

  // WIP 테이블 추출
  let wipRows = [];
  if (wipIndex !== -1) {
    for (let i = wipIndex + 1; i < lines.length; i++) {
      const line = lines[i].trim();
      if (line.startsWith('|') && !line.includes('상태') && !line.includes(':---:')) {
        const parts = line.split('|').map(s => s.trim()).filter(s => s.length > 0);
        if (parts.length >= 3) {
          wipRows.push({
            status: parts[0].replace(/\*\*/g, ''),
            target: parts[1],
            desc: parts[2],
            note: parts[3] || ''
          });
        }
      }
    }
  }

  const result = {
    latestDate,
    taskSummary: taskSection.join('\n').trim(),
    wip: wipRows
  };

  console.log(JSON.stringify(result, null, 2));
  return result;
}

// 2. 신규 작업 항목 추가
function addTask(title, targetFiles, background, details, verifyResult, wipStatus, wipDesc) {
  let content = readHistoryFile();
  const today = getTodayString();
  const dayOfWeek = getDayOfWeek(today);
  const dateHeader = `## 🕒 ${today} (${dayOfWeek}) 작업 내역`;

  // 최종 갱신일 갱신
  content = content.replace(/> \*\*최종 갱신일\*\*: .*/, `> **최종 갱신일**: ${today}`);

  // 날짜 섹션 확인
  let lines = content.split(/\r?\n/);
  let dateIndex = lines.findIndex(l => l.trim().startsWith(`## 🕒 ${today}`));

  let taskNum = 1;
  if (dateIndex !== -1) {
    // 해당 날짜 내 기존 작업 번호 파악
    for (let i = dateIndex + 1; i < lines.length; i++) {
      if (lines[i].startsWith('## 🕒 ') || lines[i].startsWith('## 🚀 ')) break;
      const match = lines[i].match(/^### (\d+)\./);
      if (match) {
        taskNum = parseInt(match[1], 10) + 1;
      }
    }
  }

  // 작업 마크다운 텍스트 블록 생성
  let taskMd = [];
  taskMd.push(`### ${taskNum}. ${title}`);
  if (targetFiles) {
    taskMd.push(`- **수정/대상 파일**: ${targetFiles}`);
  }
  if (background) {
    taskMd.push(`- **배경 및 원인**: ${background}`);
  }
  if (details) {
    taskMd.push(`- **작업 상세 내용**:`);
    if (Array.isArray(details)) {
      details.forEach(d => taskMd.push(`  - ${d}`));
    } else {
      taskMd.push(`  - ${details}`);
    }
  }
  if (verifyResult) {
    taskMd.push(`- **검증 결과**: ${verifyResult}`);
  }
  taskMd.push('');

  const taskBlock = taskMd.join('\n');

  if (dateIndex !== -1) {
    // 해당 날짜 섹션 아래 첫 작업 뒤 또는 날짜 헤더 바로 뒤에 추가
    lines.splice(dateIndex + 1, 0, '\n' + taskBlock);
    content = lines.join('\n');
  } else {
    // 신규 날짜 섹션을 가이드라인 구분선(`---\n\n## 🕒`) 바로 위에 삽입
    const firstDateIndex = lines.findIndex(l => l.startsWith('## 🕒 '));
    const newSection = `${dateHeader}\n\n${taskBlock}---\n\n`;
    if (firstDateIndex !== -1) {
      lines.splice(firstDateIndex, 0, newSection);
      content = lines.join('\n');
    } else {
      content += `\n\n---\n\n${newSection}`;
    }
  }

  // WIP 테이블 갱신 (지정된 경우)
  if (wipStatus && wipDesc) {
    const wipMarker = '## 🚀 현재 작업 상태 및 다음 작업 대기열 (Work In Progress)';
    const wipIdx = content.indexOf(wipMarker);
    if (wipIdx !== -1) {
      const newRow = `| **${wipStatus}** | ${targetFiles || title} | ${wipDesc} | ${verifyResult || '완료'} |\n`;
      const tableHeaderMatch = content.match(/\| :---: \| :--- \| :--- \| :--- \|\n/);
      if (tableHeaderMatch) {
        const insertPos = tableHeaderMatch.index + tableHeaderMatch[0].length;
        content = content.slice(0, insertPos) + newRow + content.slice(insertPos);
      }
    }
  }

  writeHistoryFile(content);
  console.log(`성공적으로 작업 내역이 WORK_HISTORY.md에 기록되었습니다: [${title}]`);
}

// 3. 무결성 검증
function validate() {
  const buf = fs.readFileSync(HISTORY_FILE);
  const isBom = buf[0] === 0xEF && buf[1] === 0xBB && buf[2] === 0xBF;
  const str = buf.toString('utf8');
  const hasDoubleCr = str.includes('\r\r\n');
  const hasCrlf = str.includes('\r\n');

  console.log(`WORK_HISTORY.md 검증 결과:`);
  console.log(`- UTF-8 with BOM: ${isBom ? '정상 (BOM 있음)' : '비정상 (BOM 누락)'}`);
  console.log(`- CRLF 개행: ${hasCrlf ? '정상 (CRLF 적용)' : '비정상 (LF 적용)'}`);
  console.log(`- 중복 캐리지리턴(\\r\\r\\n): ${hasDoubleCr ? '오류 발견' : '정상 (0건)'}`);

  if (!isBom || !hasCrlf || hasDoubleCr) {
    console.log('자동 복원 중...');
    writeHistoryFile(readHistoryFile());
    console.log('복원 완료!');
  }
}

// CLI 실행 핸들러
const args = process.argv.slice(2);
const command = args[0];

if (command === '--read-latest') {
  readLatest();
} else if (command === '--validate') {
  validate();
} else if (command === '--add-task') {
  const title = args[1] || '작업 완료';
  const targetFiles = args[2] || '';
  const background = args[3] || '';
  const details = args[4] || '';
  const verifyResult = args[5] || '검증 완료';
  const wipStatus = args[6] || '완료';
  const wipDesc = args[7] || title;
  addTask(title, targetFiles, background, details, verifyResult, wipStatus, wipDesc);
} else {
  console.log(`사용법:
  node sync_history.js --read-latest
  node sync_history.js --validate
  node sync_history.js --add-task [제목] [대상파일] [배경] [상세내용] [검증결과] [WIP상태] [WIP설명]`);
}
