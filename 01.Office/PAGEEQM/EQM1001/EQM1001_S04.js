/// <reference path="../../Script/reference.js" />

/* 페이지 접근 시 수행 */
ItsPage.Load = function () {
    // 설비종합효율
    ItsGrid.Create('grid1', { isCheckBoxGrid: true, isSubTotalGrid: true }, [
        column.create('점검일자', 'BASEDATE', { width: 80, columnType: enumColumnTypes.date, align: 'center' }),
        column.create('점검유형', 'CHKTP', { width: 110, columnType: enumColumnTypes.combo, gpcd: "CHKTP", align: 'center' }),
        column.create('점검자', 'EMPCD', { width: 100, columnType: enumColumnTypes.combo, gpcd: "EMPCD", align: 'center' }),
        column.create('공장', 'FACTORYCD', { width: 100, align: 'center', columnType: enumColumnTypes.combo, gpcd: 'FACTORYCD', readOnly: true }),
        column.create('작업장', 'LINECD', { width: 80, align: 'center', columnType: enumColumnTypes.combo, gpcd: 'LINECD', readOnly: true }),
        column.create('설비구분', 'EQMTP', { width: 80, align: 'center', columnType: enumColumnTypes.combo, gpcd: 'FM100', readOnly: true }),
        column.create('설비대분류', 'EQMGROUP1', { width: 80, align: 'center', columnType: enumColumnTypes.combo, gpcd: 'FM113', readOnly: true }),
        column.create('설비코드', 'EQMCD', { width: 100, align: 'center' }),
        column.create('설비명', 'EQMNM', { width: 250, align: 'center' }),
        column.create('문제점', 'PROBLEM', { width: 300, multiLine: true, readOnly: true }),
        column.create('조치사항', 'SOLUTION', { width: 300, multiLine: true, readOnly: true }),
        column.create('점검키', 'CHKRSTKEY', { width: 120, readOnly: true, hidden: false, align: 'center' }),
        column.create('등록시간', 'RTIME', { width: 140, readOnly: true, align: 'center' }),
        // 2026-11-16 TQM1002_R01 방식 승인자·승인일시
        column.create('승인자', 'APRVEMPNM', { width: 80, align: 'center', readOnly: true }),
        column.create('승인일시', 'APRVTIME', { width: 120, align: 'center', readOnly: true }),
        column.split()
    ]);

    // 노동생산성
    ItsGrid.Create('grid2', { isSubTotalGrid: true }, [
        column.create('점검코드', 'CHKKNDCD', { width: 80, align: 'center' }),
        column.create('점검명', 'CHKKNDNM', { width: 300, readOnly: true }),
        column.create('점검항목', 'CHKLOC', { width: 130, columnType: enumColumnTypes.combo, gpcd: "CHKLOC", align: 'center' }),
        column.create('점검방법', 'CHKMTH', { width: 100, columnType: enumColumnTypes.combo, gpcd: 'CHKMTH', align: 'center' }),
        column.create('점검값구분', 'CHKVALTP', { width: 90, columnType: enumColumnTypes.combo, gpcd: 'CHKVALTP', align: 'center' }),
        column.create('점검값', 'CHKVALUE', { width: 90, align: 'center' }),
        // 2026-11-06 점검항목별 특이사항 표시
        column.create('특이사항', 'REMARK', { width: 300, readOnly: true }),

        column.split()
    ]);

    // 2026-11-16 승인자 기본값: 로그인 사원 (TQM1002_R01과 동일)
    ItsFind.SetValue('find_APRVEMP', ItsPage.EMPCD);
};

// 2026-11-16 체크한 점검이력의 점검키 목록
function GetCheckedChkRstKeys() {
    var keys = [];
    for (var i = 0; i < ItsGrid.Length('grid1'); i++) {
        if (ItsGrid.IsChecked('grid1', i)) {
            keys.push(ItsGrid.GetValue('grid1', i, 'CHKRSTKEY'));
        }
    }
    return keys;
}

// 2026-11-16 승인: 체크한 점검이력을 승인자로 승인 (TQM1002_R01 방식, 이미 승인된 이력은 승인자·승인일시를 새 값으로)
ItsButton.Event('btn_APPROVE').onClick = function () {
    var APRVEMP = ItsFind.GetValue('find_APRVEMP');
    if (APRVEMP == '') {
        ItsMsg.Alert('승인자를 선택하세요.');
        return;
    }
    var keys = GetCheckedChkRstKeys();
    if (keys.length == 0) {
        ItsMsg.Alert('승인할 점검이력을 체크하세요.');
        return;
    }

    ItsMsg.Confirm(keys.length + '건을 승인하시겠습니까?', function () {
        var maria = new ItsMaria('EQM1001_S04', 'APPROVE');
        maria.AddParam('APRVEMP', APRVEMP);
        for (var i = 0; i < keys.length; i++) {
            maria.AddList('CHKRSTKEY_LIST', keys[i]);
        }
        maria.CallProc();
        if (maria.isError) {
            maria.ShowErrMsg();
            return;
        }
        ItsMsg.Toast(keys.length + '건 승인 되었습니다.');
        ItsButton.EventSearch();
    });
};

// 2026-11-16 승인취소: 체크한 점검이력의 승인자·승인일시를 비움 (승인 안 된 이력이 있으면 프로시저가 막음)
ItsButton.Event('btn_APPROVE_CANCEL').onClick = function () {
    var keys = GetCheckedChkRstKeys();
    if (keys.length == 0) {
        ItsMsg.Alert('승인취소할 점검이력을 체크하세요.');
        return;
    }

    ItsMsg.Confirm(keys.length + '건을 승인취소하시겠습니까?', function () {
        var maria = new ItsMaria('EQM1001_S04', 'APPROVE_CANCEL');
        for (var i = 0; i < keys.length; i++) {
            maria.AddList('CHKRSTKEY_LIST', keys[i]);
        }
        maria.CallProc();
        if (maria.isError) {
            maria.ShowErrMsg();
            return;
        }
        ItsMsg.Toast(keys.length + '건 승인취소 되었습니다.');
        ItsButton.EventSearch();
    });
};

/* 조회 */
ItsButton.EventSearch = function () {
    ItsGrid.Clear('grid2');

    var maria = new ItsMaria('EQM1001_S04', 'LIST_CHKRSTEQM');

    maria.AddPanel('sdiv1');

    maria.CallProc();

    if (maria.isError) {
        maria.ShowErrMsg();
        return;
    }

    ItsGrid.SetStore('grid1', maria.store);

    ItsMsg.Toast(ItsMsg.CommonMsg.SearchComplete(maria.store.Length()));
};


ItsGrid.Event('grid1').onSelect = function () {

    var maria = new ItsMaria('EQM1001_S04', 'LIST_CHKRSTEQMKND');
    maria.AddParam('CHKRSTKEY', ItsGrid.GetValue('grid1', ItsGrid.GetCurrentIndex('grid1'), 'CHKRSTKEY'));
    maria.CallProc();

    if (maria.isError) {
        maria.ShowErrMsg();
        return;
    }

    ItsGrid.SetStore('grid2', maria.store);
}

// 체크한 점검이력(grid1) 점검 시트 출력, 여러 건은 한 PDF에 점검이력마다 새 페이지
ItsButton.Event('btn_PRINT').onClick = function () {
    var keys = GetCheckedChkRstKeys();
    if (keys.length == 0) {
        ItsMsg.Alert('출력할 점검이력을 체크하십시오.');
        return;
    }

    var rpt = new ItsXtraRpt('EQM1001_S04A');
    rpt.AddParam('CHKRSTKEY_LIST', keys.join(','));
    rpt.CallPop();

    if (rpt.isError) {
        ItsMsg.Alert(rpt.errMessage);
    }
};