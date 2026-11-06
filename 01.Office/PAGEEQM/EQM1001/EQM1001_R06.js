/* EQM1001_R06: 생산기술팀 ▶ 설비고장/수리 ▷ 년 설비고장율 현황 */

/// <reference path="../../Script/reference.js" />

var chart1, chart2;
var topMonth, topIssueData, topIssueImg;   // 보고 있는 TOP ISSUE 달 / 조회 결과 (수정 팝업에서 씀)

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

    // 상세의 [수정] → 원인 및 예방 / 사진 팝업
    $('#div_TOPLIST').on('click', '.topissue-edit', function () {
        var r = topIssueData[$(this).data('index')];
        ItsText.SetValue('pop1_txt_EQMCD', r.EQMCD);
        ItsText.SetValue('pop1_txt_YM', r.YM);
        ItsText.SetValue('pop1_txt_EQMNM', r.LINENM + ' / ' + r.EQMNM);
        ItsTextArea.SetValue('pop1_txtarea_CAUSE', r.CAUSE);
        ItsTextArea.SetValue('pop1_txtarea_PREVENT', r.PREVENT);
        ItsFileManager.Clear('pop1_file_IMG');
        POP_IMGLIST();
        $('#pop1').height(620);   // Type="add" 팝업은 열 때마다 45px 씩 커지는 라이브러리 버그가 있어 되돌림
        ItsPop.Open('pop1');
    });

    // 팝업 사진의 [✕] → 사진 삭제 (DB 등록 삭제 후 파일 삭제)
    $('#pop1_IMGLIST').on('click', '.del', function () {
        var fileKey = $(this).data('filekey');
        ItsMsg.Confirm('사진을 삭제하시겠습니까?', function () {
            var maria = new ItsMaria('EQM1001_R06', 'DEL_ISSUEIMG');
            maria.AddParam('EQMCD', ItsText.GetValue('pop1_txt_EQMCD'));
            maria.AddParam('YM', ItsText.GetValue('pop1_txt_YM'));
            maria.AddParam('FILEKEY', fileKey);
            maria.CallProc();
            if (maria.isError) {
                maria.ShowErrMsg();
                return;
            }
            ItsFileManager.Delete('pop1_file_IMG', fileKey);
            ItsMsg.Toast(ItsMsg.CommonMsg.DeleteComplete());
            POP_IMGLIST();
        });
    });

    ItsButton.EventSearch();
};

/* 조회 (설비 고장율 / 고장건수 차트) */
ItsButton.EventSearch = function () {
    var maria = new ItsMaria('EQM1001_R06', 'LIST_CHART');
    maria.AddPanel('sdiv1');
    maria.CallProc();
    if (maria.isError) {
        maria.ShowErrMsg();
        return;
    }

    var categories = [], nonHr = ['NONHR'], nonRate = ['NONRATE'], goalRate = ['GOALRATE'];
    var failCnt = ['FAILCNT'], avgRepMin = ['AVGREPMIN'];
    maria.store.data.forEach(function (d) {
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
    topMonth = d.index - 5;
    TOPISSUE_SEARCH();
    $('#div_TOPISSUE').scrollTop(0).show();
}

/* TOP ISSUE 조회 (topMonth 달), 표 + 접힌 상세 */
function TOPISSUE_SEARCH() {
    var maria = new ItsMaria('EQM1001_R06', 'LIST_TOPISSUE');
    maria.AddPanel('sdiv1');
    maria.AddParam('SMONTH', String(topMonth));
    maria.CallProc();
    if (maria.isError) {
        maria.ShowErrMsg();
        return;
    }
    topIssueData = maria.store.data;
    topIssueImg = maria.storeExtend1.data;

    var html = '';
    if (topIssueData.length == 0) {
        html = '<div style="margin-top: 40px; text-align: center; font-size: 15px; color: #999;">' + topMonth + '월 설비 수리 이력이 없습니다.</div>';
    }
    topIssueData.forEach(function (r, i) {
        html += '<table class="topissue-table">'
            + '<colgroup><col style="width:8%"><col style="width:8%"><col style="width:9%"><col style="width:8%"><col style="width:6%"><col style="width:7%">'
            + '<col style="width:7%"><col style="width:20%"><col style="width:20%"><col style="width:7%"></colgroup>'
            + '<tr><th rowspan="2">라인명</th><th rowspan="2">설비명</th><th rowspan="2">규격</th><th rowspan="2">비가동<br>시간(분)</th>'
            + '<th rowspan="2">고장<br>횟수</th><th rowspan="2">고장<br>유형</th><th rowspan="2">고장<br>부위</th>'
            + '<th colspan="2">고장 및 조치</th><th rowspan="2">진행<br>상태</th></tr>'
            + '<tr><th>고장내용</th><th>조치내역</th></tr>'
            + '<tr><td>' + r.LINENM + '</td><td>' + r.EQMNM + '</td><td>' + r.EQMSPEC + '</td>'
            + '<td>' + r.NONMIN + '(분)<br>(약 ' + Math.round(r.NONMIN / 60) + 'HR)</td>'
            + '<td>' + r.FAILCNT + '회</td><td>-</td><td>-</td>'   // 고장유형/고장부위 : EQMREP 에 컬럼 없음
            + '<td class="text">- ' + r.MALFUNCTION + '</td><td class="text">- ' + r.HANDLE + '</td><td>' + r.STATNM + '</td></tr>'
            + '</table>'
            + TOPISSUE_DETAIL(r, i);
    });

    $('#lbl_TOPISSUE').text('■ 설비 고장 TOP ISSUE_' + topMonth + '월');
    $('#div_TOPLIST').html(html);
}

/* TOP ISSUE 상세 (이슈 정보 / 원인 및 예방 / 사진), 처음엔 접혀 있음
   원인/예방 = 이 화면에서 등록한 값(EQMREP_ISSUE), 없으면 '-' */
function TOPISSUE_DETAIL(r, i) {
    var cause = '', prevent = '', photo = '';
    (r.CAUSE == '' ? '-' : r.CAUSE).split('\n').forEach(function (t) { cause += '<div class="sub">' + t + '</div>'; });
    (r.PREVENT == '' ? '-' : r.PREVENT).split('\n').forEach(function (t) { prevent += '<div class="sub">' + t + '</div>'; });
    topIssueImg.forEach(function (img) {
        if (img.EQMCD == r.EQMCD) {
            photo += '<img src="' + img.FILEURL + '" />';
        }
    });
    if (photo == '') {
        photo = '<span class="empty">사진 없음</span>';
    }
    var no = i + 1;

    return '<div class="topissue-detail" data-eqmcd="' + r.EQMCD + '"><div class="topissue-detail-inner">'
        + '<div class="topissue-detail-col" style="width: 22%;">'
        + '<span class="topissue-detail-head">TOP ISSUE-' + no + '</span>'
        + '<div class="topissue-detail-box">'
        + '<div class="item">라인명 : ' + r.LINENM + '</div>'
        + '<div class="item">설비명 : ' + r.EQMNM + '</div>'
        + '<div class="item">발생일 : ' + r.REPSTIME.substr(2, 8).replace(/-/g, '.') + '</div>'
        + '<div class="item">문제내용 : <span class="problem">' + r.MALFUNCTION + '</span></div>'
        + '</div></div>'
        + '<div class="topissue-detail-col" style="flex: 1;">'
        + '<div class="topissue-detail-headrow"><span class="topissue-detail-head">원인 및 예방</span>'
        + '<span class="topissue-edit" data-index="' + i + '">수정</span></div>'
        + '<div class="topissue-detail-box">[원인]' + cause + '[예방]' + prevent + '</div>'
        + '</div>'
        + '<div class="topissue-detail-col" style="width: 26%;">'
        + '<span class="topissue-detail-head">사진</span>'
        + '<div class="topissue-detail-box topissue-photo">' + photo + '</div>'
        + '</div>'
        + '</div></div>';
}

/* 툴바 [인쇄] → 보고 있는 화면대로 출력 (그래프 = 고장율 현황 1장, TOP ISSUE = 그 달 표 + 세부내용) */
ItsButton.EventPrint = function () {
    var rpt;
    if ($('#div_TOPISSUE').is(':visible')) {
        if (topIssueData == undefined || topIssueData.length == 0) {
            ItsMsg.Alert(topMonth + '월 설비 수리 이력이 없습니다.');
            return;
        }
        rpt = new ItsXtraRpt('EQM1001_R0602');
        rpt.AddParam('SYEAR', ItsCombo.GetValue('cmb_SYEAR'));
        rpt.AddParam('SMONTH', String(topMonth));
    }
    else {
        rpt = new ItsXtraRpt('EQM1001_R0601');
        rpt.AddParam('SYEAR', ItsCombo.GetValue('cmb_SYEAR'));
    }
    rpt.CallPop();
    if (rpt.isError) {
        ItsMsg.Alert(rpt.errMessage);
    }
};

/* TOP ISSUE → 그래프로 돌아가기 */
ItsButton.Event('btn_BACK').onClick = function () {
    $('#div_TOPISSUE').hide();
};

/* 팝업 사진 목록 (설비 + 년월) */
function POP_IMGLIST() {
    var maria = new ItsMaria('EQM1001_R06', 'LIST_ISSUEIMG');
    maria.AddParam('EQMCD', ItsText.GetValue('pop1_txt_EQMCD'));
    maria.AddParam('YM', ItsText.GetValue('pop1_txt_YM'));
    maria.CallProc();
    if (maria.isError) {
        maria.ShowErrMsg();
        return;
    }
    var html = '';
    maria.store.data.forEach(function (img) {
        html += '<div class="item"><img src="' + img.FILEURL + '" /><span class="del" data-filekey="' + img.FILEKEY + '">✕</span></div>';
    });
    if (html == '') {
        html = '<span class="empty">사진 없음</span>';
    }
    $('#pop1_IMGLIST').html(html);
}

/* 팝업 [저장] → 원인 및 예방 저장 */
ItsPop.Event('pop1').onAddBtnClick = function () {
    var maria = new ItsMaria('EQM1001_R06', 'SAVE_ISSUE');
    maria.AddParam('EQMCD', ItsText.GetValue('pop1_txt_EQMCD'));
    maria.AddParam('YM', ItsText.GetValue('pop1_txt_YM'));
    maria.AddParam('CAUSE', ItsTextArea.GetValue('pop1_txtarea_CAUSE'));
    maria.AddParam('PREVENT', ItsTextArea.GetValue('pop1_txtarea_PREVENT'));
    maria.CallProc();
    if (maria.isError) {
        maria.ShowErrMsg();
        return;
    }
    ItsMsg.Toast(ItsMsg.CommonMsg.SaveComplete());
    ItsPop.Close('pop1');
};

ItsPop.Event('pop1').onCancelBtnClick = function () {
    ItsPop.Close('pop1');
};

/* 팝업 닫힘 → TOP ISSUE 다시 조회하고 그 설비 상세를 펼쳐 둠 (사진은 저장 없이 바로 반영되므로 취소해도 다시 조회) */
ItsPop.Event('pop1').onPopClosed = function () {
    TOPISSUE_SEARCH();
    $('#div_TOPLIST .topissue-detail[data-eqmcd="' + ItsText.GetValue('pop1_txt_EQMCD') + '"]').show();
};

/* 팝업 [원인·예방 삭제] → 등록한 원인/예방 삭제 */
ItsButton.Event('pop1_btn_DEL').onClick = function () {
    ItsMsg.Confirm('등록한 원인 및 예방을 삭제하시겠습니까?\n(사진은 삭제되지 않습니다)', function () {
        var maria = new ItsMaria('EQM1001_R06', 'DEL_ISSUE');
        maria.AddParam('EQMCD', ItsText.GetValue('pop1_txt_EQMCD'));
        maria.AddParam('YM', ItsText.GetValue('pop1_txt_YM'));
        maria.CallProc();
        if (maria.isError) {
            maria.ShowErrMsg();
            return;
        }
        ItsMsg.Toast(ItsMsg.CommonMsg.DeleteComplete());
        ItsPop.Close('pop1');
    });
};

/* 팝업 사진 선택 → 바로 업로드 → 파일키 등록 */
ItsFileManager.Event('pop1_file_IMG').onFileChange = function (id) {
    ItsFileManager.Upload(id);
};
ItsFileManager.Event('pop1_file_IMG').onUpload = function (id, fileKey) {
    var maria = new ItsMaria('EQM1001_R06', 'ADD_ISSUEIMG');
    maria.AddParam('EQMCD', ItsText.GetValue('pop1_txt_EQMCD'));
    maria.AddParam('YM', ItsText.GetValue('pop1_txt_YM'));
    maria.AddParam('FILEKEY', fileKey);
    maria.CallProc();
    if (maria.isError) {
        maria.ShowErrMsg();
        return;
    }
    ItsFileManager.Clear(id);
    POP_IMGLIST();
};

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
