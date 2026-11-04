/* EQM1001_R06: 생산기술팀 ▶ 설비고장/수리 ▷ 년 설비고장율 현황 */

/// <reference path="../../Script/reference.js" />

var chart1, chart2;

/* 페이지 접근 시 수행 */
ItsPage.Load = function () {
    ItsCombo.SetValue('cmb_SYEAR', ItsHelper.GetYearMonthDay().substr(0, 4));

    // 본문 높이는 Load 뒤 MasterBase 의 resize 에서 정해지므로, 그 뒤에 차트 높이를 칸에 맞춘다
    $(window).resize(function () {
        setTimeout(function () {
            if (chart1 == undefined) {
                return;
            }
            chart1.resize({ height: $('#chart1').height() });
            chart2.resize({ height: $('#chart2').height() });
        }, 10);
    });

    // TOP ISSUE 표 클릭 → 바로 아래 상세(원인 및 예방) 펼치기/접기
    $('#div_TOPLIST').on('click', '.topissue-table', function () {
        $(this).next('.topissue-detail').slideToggle(150);
    });

    ItsButton.EventSearch();
};

/* 조회 (설비 고장율 / 고장건수 차트) */
ItsButton.EventSearch = function () {
    // 화면 디자인 확인용으로 예시 데이터를 쓴다. 실제 조회로 바꿀 때 아래 주석을 풀고 SAMPLE_DATA 를 maria.store.data 로 바꾼다
    // var maria = new ItsMaria('EQM1001_R06', 'LIST_CHART');
    // maria.AddPanel('sdiv1');
    // maria.CallProc();
    // if (maria.isError) {
    //     maria.ShowErrMsg();
    //     return;
    // }

    var categories = [], nonHr = ['NONHR'], nonRate = ['NONRATE'], goalRate = ['GOALRATE'];
    var failCnt = ['FAILCNT'], avgRepMin = ['AVGREPMIN'];
    SAMPLE_DATA().forEach(function (d) {
        categories.push(d['GUBUN']);
        nonHr.push(d['NONHR']);
        nonRate.push(d['NONRATE']);
        goalRate.push(0.75);   // 목표 점유율 0.75% 고정
        failCnt.push(d['FAILCNT']);
        avgRepMin.push(d['AVGREPMIN']);
    });

    chart1 = bb.generate({
        bindto: '#chart1',
        size: { height: $('#chart1').height() },   // 칸 높이에 맞춰 그림 (기본은 320px 고정)
        title: { text: '설비 고장율' },
        data: {
            columns: [nonHr, nonRate, goalRate],
            names: { NONHR: '설비 비가동시간', NONRATE: '비가동시간 점유율(고장시간/가동시간)', GOALRATE: '목표' },
            type: 'bar',
            types: { NONRATE: 'line', GOALRATE: 'line' },
            axes: { NONRATE: 'y2', GOALRATE: 'y2' },
            colors: { NONHR: '#b7bdf0', NONRATE: 'red', GOALRATE: 'blue' },
            labels: true,
            onclick: TOPISSUE_OPEN
        },
        axis: {
            x: { type: 'category', categories: categories },
            y: { min: 0, padding: { bottom: 0 } },
            y2: { show: true, min: 0, padding: { bottom: 0 } }
        },
        legend: { contents: { bindto: '#chart1_legend', template: CHART_LEGEND } },
        grid: { y: { show: true } }
    });

    chart2 = bb.generate({
        bindto: '#chart2',
        size: { height: $('#chart2').height() },
        title: { text: '고장건수' },
        data: {
            columns: [failCnt, avgRepMin],
            names: { FAILCNT: '설비 고장건수', AVGREPMIN: '평균수리시간(분)' },
            type: 'bar',
            types: { AVGREPMIN: 'line' },
            axes: { AVGREPMIN: 'y2' },
            colors: { FAILCNT: '#f6c79a', AVGREPMIN: 'red' },
            labels: true,
            onclick: TOPISSUE_OPEN
        },
        axis: {
            x: { type: 'category', categories: categories },
            y: { min: 0, padding: { bottom: 0 } },
            y2: { show: true, min: 0, padding: { bottom: 0 } }
        },
        legend: { contents: { bindto: '#chart2_legend', template: CHART_LEGEND } },
        grid: { y: { show: true } }
    });
};

/* 월 막대 클릭 → 그 달 설비 고장 TOP ISSUE (비가동시간 상위 5개 설비) */
function TOPISSUE_OPEN(d) {
    if (d.index < 6 || d.value == null) {   // 0~5 = 연도 평균, 값 없는 달은 제외
        return;
    }
    var month = d.index - 5;

    var html = '';
    SAMPLE_TOP5().forEach(function (r, i) {   // 예시라 달과 관계없이 같은 5건
        html += '<table class="topissue-table">'
            + '<colgroup><col style="width:8%"><col style="width:8%"><col style="width:9%"><col style="width:8%"><col style="width:6%"><col style="width:7%">'
            + '<col style="width:7%"><col style="width:20%"><col style="width:20%"><col style="width:7%"></colgroup>'
            + '<tr><th rowspan="2">라인명</th><th rowspan="2">설비명</th><th rowspan="2">규격</th><th rowspan="2">비가동<br>시간(분)</th>'
            + '<th rowspan="2">고장<br>횟수</th><th rowspan="2">고장<br>유형</th><th rowspan="2">고장<br>부위</th>'
            + '<th colspan="2">고장 및 조치</th><th rowspan="2">진행<br>상태</th></tr>'
            + '<tr><th>고장내용</th><th>조치내역</th></tr>'
            + '<tr><td>' + r.LINENM + '</td><td>' + r.EQMNM + '</td><td>' + r.EQMSPEC + '</td>'
            + '<td>' + r.NONMIN + '(분)<br>(약 ' + Math.round(r.NONMIN / 60) + 'HR)</td>'
            + '<td>' + r.FAILCNT + '회</td><td>' + r.ISSUENM + '</td><td>' + r.FAILPART + '</td>'
            + '<td class="text">- ' + r.MALFUNCTION + '</td><td class="text">- ' + r.HANDLE + '</td><td>' + r.STATNM + '</td></tr>'
            + '</table>'
            + TOPISSUE_DETAIL(r, i + 1);
    });

    $('#lbl_TOPISSUE').text('■ 설비 고장 TOP ISSUE_' + month + '월');
    $('#div_TOPLIST').html(html);
    $('#div_TOPISSUE').scrollTop(0).show();
}

/* TOP ISSUE 상세 (이슈 정보 / 원인 및 예방 / 사진), 처음엔 접혀 있음 */
function TOPISSUE_DETAIL(r, no) {
    var cause = '', prevent = '', photo = '';
    r.CAUSE.forEach(function (t) { cause += '<div class="sub">' + t + '</div>'; });
    r.PREVENT.forEach(function (t) { prevent += '<div class="sub">' + t + '</div>'; });
    r.PHOTOS.forEach(function (src) { photo += '<img src="' + src + '" />'; });
    if (photo == '') {
        photo = '<span class="empty">사진 없음</span>';
    }

    return '<div class="topissue-detail"><div class="topissue-detail-inner">'
        + '<div class="topissue-detail-col" style="width: 22%;">'
        + '<span class="topissue-detail-head">TOP ISSUE-' + no + '</span>'
        + '<div class="topissue-detail-box">'
        + '<div class="item">라인명 : ' + r.LINENM.replace('<br>', ' ') + '</div>'
        + '<div class="item">설비명 : ' + r.EQMNM + '</div>'
        + '<div class="item">발생일 : ' + r.ISSUEDATE.substr(2).replace(/-/g, '.') + '</div>'
        + '<div class="item">문제내용 : <span class="problem">' + r.PROBLEM + '</span></div>'
        + '</div></div>'
        + '<div class="topissue-detail-col" style="flex: 1;">'
        + '<span class="topissue-detail-head" style="align-self: center;">원인 및 예방</span>'
        + '<div class="topissue-detail-box">[원인]' + cause + '[예방]' + prevent + '</div>'
        + '</div>'
        + '<div class="topissue-detail-col" style="width: 26%;">'
        + '<span class="topissue-detail-head">사진</span>'
        + '<div class="topissue-detail-box topissue-photo">' + photo + '</div>'
        + '</div>'
        + '</div></div>';
}

/* TOP ISSUE → 그래프로 돌아가기 */
ItsButton.Event('btn_BACK').onClick = function () {
    $('#div_TOPISSUE').hide();
};

/* 예시 TOP5 (비가동시간 순) */
function SAMPLE_TOP5() {
    return [
        { LINENM: 'M7 열전<br>Line', EQMNM: 'CNC', EQMSPEC: 'MW200_2SPINDLE', NONMIN: 310, FAILCNT: 1, ISSUENM: '기계', FAILPART: '준공구', MALFUNCTION: 'L측 척 클램프 동작 이상', HANDLE: '척 그리스 점검 및 드로바 점검', STATNM: '완료',
          ISSUEDATE: '2026-04-08', PROBLEM: '척 드로바 볼트파손', PHOTOS: [],
          CAUSE: ['척 내부 그리스 부족 및 윤활 불량으로 드로바 작동 시 마찰 증가', '반복적인 체결·해체 동작에 따른 피로 누적', '척 내부 이물 유입 및 편마모 발생 가능', '체결력 이상 상태에서 지속 운전하여 볼트에 과부하 발생'],
          PREVENT: ['척 내부 그리스 정기 주입 및 윤활 관리 주기 표준화', '척 분해 점검을 통한 마모·균열 여부 정기 확인', '드로바 체결력 및 스트로크 이상 유무 일상점검 실시', '이물 유입 방지를 위한 청결 관리 강화', '주요 소모부품(볼트·씰 등) 예방교체 기준 수립'] },
        { LINENM: 'M2 열전<br>Line', EQMNM: '탭핑센터', EQMSPEC: '탭핑센터', NONMIN: 84, FAILCNT: 1, ISSUENM: '기계', FAILPART: '벨트류', MALFUNCTION: '소재이송 컨베이어 작동이상', HANDLE: '컨베이어 체인 파손으로 모터 과부하 체인 교체', STATNM: '완료',
          ISSUEDATE: '2026-04-12', PROBLEM: '컨베이어 체인 파손', PHOTOS: [],
          CAUSE: ['체인 장력 저하로 스프라켓 이탈 및 충격 하중 반복', '체인 윤활 부족으로 마모 진행'],
          PREVENT: ['체인 장력·마모 주간 점검 실시', '체인 윤활 주기 표준화', '모터 과부하 알람 설정값 점검'] },
        { LINENM: 'M4 열전<br>Line', EQMNM: 'CNC', EQMSPEC: 'MW200_2SPINDLE', NONMIN: 82, FAILCNT: 1, ISSUENM: '기계', FAILPART: '모터', MALFUNCTION: 'R측로더 회전모터 작동이상', HANDLE: '회전모터 작동시 전원차단 모터 교체', STATNM: '완료',
          ISSUEDATE: '2026-04-17', PROBLEM: '로더 회전모터 소손', PHOTOS: [],
          CAUSE: ['로더 회전부 부하 증가로 모터 과열', '모터 냉각팬 오염으로 방열 불량'],
          PREVENT: ['모터 전류·온도 정기 측정', '냉각팬 및 모터 주변 청소 주기 수립', '회전부 베어링 윤활 점검'] },
        { LINENM: 'M1 열후<br>Line', EQMNM: '세척기', EQMSPEC: 'WS-300', NONMIN: 65, FAILCNT: 2, ISSUENM: '전기', FAILPART: '센서', MALFUNCTION: '건조부 온도센서 오작동', HANDLE: '온도센서 교체 및 설정값 재조정', STATNM: '완료',
          ISSUEDATE: '2026-04-21', PROBLEM: '건조부 온도센서 불량', PHOTOS: [],
          CAUSE: ['고온·수분 환경에서 센서 단자 부식', '센서 케이블 피복 손상으로 접촉 불량'],
          PREVENT: ['센서 단자 방수 처리 및 정기 교체', '케이블 고정 상태 일상점검'] },
        { LINENM: 'M6 조립<br>Line', EQMNM: '자동 검사기', EQMSPEC: 'VS-120', NONMIN: 48, FAILCNT: 1, ISSUENM: '전기', FAILPART: '카메라', MALFUNCTION: '비전 카메라 인식 불량', HANDLE: '카메라 렌즈 청소 및 조명 각도 조정', STATNM: '수리중',
          ISSUEDATE: '2026-04-25', PROBLEM: '비전 카메라 인식 불량', PHOTOS: [],
          CAUSE: ['렌즈 표면 오염(분진·오일 미스트)', '조명 각도 틀어짐으로 반사광 발생'],
          PREVENT: ['렌즈 청소 일상점검 항목 추가', '조명 고정부 체결 상태 점검', '카메라 커버 설치 검토'] }
    ];
}

/* 예시 데이터 (프로시저 LIST_CHART 결과와 같은 모양: 전년도까지 5년 평균, 당해 평균, 1~12월) */
function SAMPLE_DATA() {
    var syear = Number(ItsCombo.GetValue('cmb_SYEAR'));
    var values = [   // 비가동시간(hr), 점유율(%), 고장건수, 평균수리시간(분)
        [68.2, 1.12, 21, 195], [61.5, 1.01, 19, 194], [55.8, 0.93, 17, 197], [52.4, 0.86, 16, 196], [49.7, 0.82, 15, 199],
        [44.6, 0.74, 14, 191],
        [52.1, 0.86, 16, 195], [47.3, 0.81, 15, 189], [39.8, 0.66, 12, 199], [45.2, 0.75, 14, 194], [41.6, 0.69, 13, 192], [38.9, 0.64, 12, 195],
        [50.4, 0.83, 15, 202], [36.2, 0.62, 11, 197], [42.7, 0.70, 13, 197], [47.9, 0.79, 14, 205], [48.2, 0.80, 15, 193], [null, null, null, null]
    ];
    var rows = [];
    values.forEach(function (v, i) {
        var gubun = i < 6 ? "'" + String(syear - 5 + i).substr(2, 2) + '년 평균' : (i - 5) + '월';
        rows.push({ GUBUN: gubun, NONHR: v[0], NONRATE: v[1], FAILCNT: v[2], AVGREPMIN: v[3] });
    });
    return rows;
}

/* 차트 범례 (막대 = 사각형, 선 = 점선 + 동그라미, 목표는 속이 빈 동그라미) */
function CHART_LEGEND(id, color) {
    var name = this.config.data_names[id];
    var icon = '<svg width="34" height="10"><rect x="0" y="0" width="34" height="10" fill="' + color + '" stroke="#888" /></svg>';
    if (this.config.data_types[id] == 'line') {
        icon = '<svg width="34" height="10"><line x1="0" y1="5" x2="34" y2="5" stroke="' + color + '" stroke-dasharray="4 3" />'
             + '<circle cx="17" cy="5" r="3" fill="' + (id == 'GOALRATE' ? '#fff' : color) + '" stroke="' + color + '" /></svg>';
    }
    return '<span>' + icon + name + '</span>';
}
