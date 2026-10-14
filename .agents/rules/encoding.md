---
trigger: always_on
---

# File Encoding & Line Endings Rule

모든 소스 코드 및 문서 파일을 생성하거나 수정할 때 파일 손상, 한글 깨짐, 불필요한 줄바꿈 중복 및 인코딩 파서 에러를 방지하기 위해 다음 원칙을 반드시 준수합니다.

---

### 1. 단일 UTF-8 with BOM 인코딩 강제 (중복 BOM 절대 금지)
- **적용 대상**: 모든 소스 코드 및 텍스트 파일 (`.cs`, `.xaml`, `.aspx`, `.js`, `.sql`, `.css`, `.html`, `.md` 등)
- **인코딩 표준**: 반드시 **단일 UTF-8 with BOM** (파일 시작 3바이트: `\xef\xbb\xbf`) 방식으로 저장합니다.
- **[중요] 중복 BOM (`\xef\xbb\xbf\xef\xbb\xbf`) 발생 절대 금지**:
  - 이미 BOM이 존재하는 파일에 무조건 BOM 바이트를 덧붙여 6바이트 이상의 중복 BOM(`0xEF 0xBB 0xBF 0xEF 0xBB 0xBF`)이 생성되는 행위를 철저히 방지합니다.
  - 파일의 시작은 정확히 3바이트(`0xEF 0xBB 0xBF`)의 단일 BOM이어야 하며, 4~6번째 바이트에 BOM이 반복되어서는 안 됩니다.

---

### 2. 중복 BOM으로 인한 치명적 장애 방지 (ASP.NET 파서 오류 실사례)
- **ASP.NET `.aspx` 구문 분석 오류 (줄 1 파서 크래시)**:
  - **오류 메시지**: `Content 컨트롤이 포함된 콘텐츠 페이지에는 Content 컨트롤만 사용할 수 있습니다. 줄 1:`
  - **발생 원인**:
    - 마스터 페이지(`MasterPageFile`)를 상속하는 `.aspx` 콘텐츠 페이지는 `<%@ Page ... %>` 및 `<asp:Content ...>` 태그 바깥에 어떠한 일반 텍스트나 공백 문자도 허용하지 않습니다.
    - 파일에 중복 BOM이 기록되면 첫 번째 BOM만 파일 인코딩 헤더로 인식되고, **두 번째 BOM은 본문에 포함된 보이지 않는 특수문자(`\uFEFF`, Zero Width No-Break Space) 즉 텍스트로 인식**되어 줄 1 파서 오류를 유발하고 페이지 접속이 전면 단절됩니다.
- **JS / CS / SQL 파싱 결함 방지**:
  - 스크립트(`.js`), C#(`.cs`), 데이터베이스 프로시저(`.sql`)에서도 중복 BOM이 들어가면 첫 줄에 알 수 없는 식별자 오류나 구문 분석 오류가 발생할 수 있으므로 항상 단일 BOM을 엄수합니다.

---

### 3. 표준 Windows CRLF 개행 통일
- **줄바꿈 표준**: 모든 줄바꿈 문자는 Windows 표준인 **CRLF (`\r\n`)**로 정상화합니다.
- **주의사항**:
  - `\r\r\n`과 같이 잘못된 중복 캐리지 리턴이 발생하면 에디터 상에서 줄마다 빈 줄이 한 줄씩 추가되어 파일 라인이 2배로 불어나므로 이를 철저히 방지합니다.
  - Unix 방식의 단독 `LF (\n)`나 레거시 `CR (\r)`이 섞이지 않도록 저장 전 항상 통일합니다.

---

### 4. 파일 저장 후 3단계 바이너리 무결성 검증 의무화
- 소스 코드 및 문서 파일 수정 후에는 바이너리 레벨에서 아래 3가지를 스스로 즉시 검증합니다:
  1. **단일 BOM 존재 확인**: 첫 3바이트가 `\xef\xbb\xbf`인지 확인.
  2. **중복 BOM 부존재 확인**: 4~6번째 바이트가 `\xef\xbb\xbf`가 아닌지 확인 (`buf.slice(0, 6)` 비교).
  3. **표준 CRLF 확인**: 파일 내용 중에 `\r\r\n` (중복 개행)이나 단독 `LF`가 없는지 확인.

- **표준 안전 저장/검증 스크립트 패턴 (Node.js)**:
  ```javascript
  // 파일 저장 시 중복 BOM을 원천 방지하는 안전 정규화 패턴
  let content = fs.readFileSync(filePath, 'utf8');
  // 1. 개행 통일 (LF / 중복 CR 제거 후 CRLF로 정규화)
  content = content.replace(/\r\r\n/g, '\n').replace(/\r\n/g, '\n').replace(/\n/g, '\r\n');
  // 2. 문자열 앞단의 기존 BOM 문자(\uFEFF) 전면 제거
  while (content.charCodeAt(0) === 0xFEFF) {
    content = content.slice(1);
  }
  // 3. 정확히 단 1개의 BOM 바이트만 결합하여 저장
  const buf = Buffer.from(content, 'utf8');
  const bomBuf = Buffer.concat([Buffer.from([0xEF, 0xBB, 0xBF]), buf]);
  fs.writeFileSync(filePath, bomBuf);
  ```
