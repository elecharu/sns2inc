/// <reference path="../../Script/reference.js" />

/* 페이지 접근 시 수행 */
ItsPage.Load = function () {

    // 설비그룹 점검계획 탭: 설비그룹 목록
    ItsGrid.Create('grid_GRP1', { isCheckBoxGrid: false, isSubTotalGrid: false }, [
        column.create('설비그룹코드', 'EQMGUBUN', { width: 120, align: 'center' }),
        column.create('설비그룹', 'EQMGRPNM', { width: 120, align: 'center' }),
        column.create('REV', 'REVNM', { width: 100, align: 'center' }),
        column.create('승인상태', 'APRVSTTNM', { width: 70, align: 'center' }),
        column.split()
    ]);

    // 설비그룹 점검계획 탭: 개정 이력(REV)
    ItsGrid.Create('grid_GRP_REV', { isCheckBoxGrid: false, isSubTotalGrid: false }, [
        column.create('REV', 'REVNM', { width: 100, align: 'center' }),
        column.create('상태', 'APRVSTTNM', { width: 60, align: 'center' }),
        column.create('개정내용', 'REMARK', { width: 260, readOnly: false }),
        column.create('작성자', 'REQEMP', { width: 80, align: 'center' }),
        column.create('수정일시', 'REQTIME', { width: 130, align: 'center' }),
        column.create('승인자', 'APRVEMP', { width: 80, align: 'center' }),
        column.create('처리일시', 'APRVTIME', { width: 130, align: 'center' }),
        column.create('REV번호', 'REVNUM', { hidden: true }),
        column.create('상태코드', 'APRVSTT', { hidden: true }),
        column.split()
    ]);

    // 설비그룹 점검계획 탭: 일상점검 항목
    // 2026-11-03 [설비그룹 점검계획 탭] 점검주기 표시
    ItsGrid.Create('grid_GRP2', { isCheckBoxGrid: true, isSubTotalGrid: false }, [
        column.create('점검코드', 'CHKKNDCD', { width: 80, align: 'center' }),
        column.create('점검명', 'CHKKNDNM', { width: 300 }),
        column.create('점검항목', 'CHKLOCNM', { width: 130, align: 'center' }),
        column.create('점검방법', 'CHKMTHNM', { width: 100, align: 'center' }),
        column.create('점검값구분', 'CHKVALTPNM', { width: 90, align: 'center' }),
        column.create('점검주기', 'CHKCYCLE', { width: 80, align: 'center', columnType: enumColumnTypes.combo, gpcd: 'CHKCYCLE', readOnly: true }),
        column.create('정렬순서', 'SORTNO', { width: 80, columnType: enumColumnTypes.number, decimalPrecision: 0, readOnly: false }),
        column.split()
    ]);

    // 설비그룹 복사 팝업: 복사 원본 설비그룹
    ItsGrid.Create('grid_GRP_COPY1', { isCheckBoxGrid: false, isSubTotalGrid: false }, [
        column.create('설비그룹코드', 'PLANCD', { width: 120, align: 'center' }),
        column.create('설비그룹', 'PLANNM', { width: 120, align: 'center' }),
        column.create('일상점검 건수', 'ITEMCNT', { width: 80, columnType: enumColumnTypes.number, decimalPrecision: 0 }),
        column.split()
    ]);

    // 설비그룹 복사 팝업: 복사 원본 일상점검 항목
    // 2026-11-03 [설비그룹 복사 팝업] 점검주기 표시
    ItsGrid.Create('grid_GRP_COPY2', { isCheckBoxGrid: false, isSubTotalGrid: false }, [
        column.create('점검코드', 'CHKKNDCD', { width: 80, align: 'center' }),
        column.create('점검명', 'CHKKNDNM', { width: 300 }),
        column.create('점검항목', 'CHKLOCNM', { width: 130, align: 'center' }),
        column.create('점검방법', 'CHKMTHNM', { width: 100, align: 'center' }),
        column.create('점검값구분', 'CHKVALTPNM', { width: 90, align: 'center' }),
        column.create('점검주기', 'CHKCYCLE', { width: 80, align: 'center', columnType: enumColumnTypes.combo, gpcd: 'CHKCYCLE', readOnly: true }),
        column.create('정렬순서', 'SORTNO', { width: 80, columnType: enumColumnTypes.number, decimalPrecision: 0 }),
        column.split()
    ]);

    // 설비별 점검계획 탭: 설비 목록
    ItsGrid.Create('grid1', { isCheckBoxGrid: false, isSubTotalGrid: false }, [
        column.create('작업장', 'LINENM', { width: 80, align: 'center' }),
        column.create('공정', 'EQMTPNM', { width: 60, align: 'center' }),
        column.create('라인', 'EQMGROUP1NM', { width: 60, align: 'center' }),
        column.create('설비그룹', 'EQMGUBUNNM', { width: 100, align: 'center' }),
        column.create('설비코드', 'FANO', { width: 80, align: 'center' }),
        column.create('설비명', 'EQMNM', { width: 200 }),
        column.create('REV', 'REVNM', { width: 100, align: 'center' }),
        column.create('승인상태', 'APRVSTTNM', { width: 65, align: 'center' }),
        column.split()
    ]);

    // 설비별 점검계획 탭: 개정 이력(REV)
    ItsGrid.Create('grid_EQM_REV', { isCheckBoxGrid: false, isSubTotalGrid: false }, [
        column.create('REV', 'REVNM', { width: 100, align: 'center' }),
        column.create('상태', 'APRVSTTNM', { width: 60, align: 'center' }),
        column.create('개정내용', 'REMARK', { width: 260, readOnly: false }),
        column.create('작성자', 'REQEMP', { width: 80, align: 'center' }),
        column.create('수정일시', 'REQTIME', { width: 130, align: 'center' }),
        column.create('승인자', 'APRVEMP', { width: 80, align: 'center' }),
        column.create('처리일시', 'APRVTIME', { width: 130, align: 'center' }),
        column.create('REV번호', 'REVNUM', { hidden: true }),
        column.create('상태코드', 'APRVSTT', { hidden: true }),
        column.split()
    ]);

    // 설비별 점검계획 탭: 일상점검 항목
    // 2026-11-03 [설비별 점검계획 탭] 점검주기 표시
    ItsGrid.Create('grid3', { isCheckBoxGrid: true, isSubTotalGrid: false }, [
        column.create('점검코드', 'CHKKNDCD', { width: 80, align: 'center' }),
        column.create('점검명', 'CHKKNDNM', { width: 300 }),
        column.create('점검항목', 'CHKLOCNM', { width: 130, align: 'center' }),
        column.create('점검방법', 'CHKMTHNM', { width: 100, align: 'center' }),
        column.create('점검값구분', 'CHKVALTPNM', { width: 90, align: 'center' }),
        column.create('점검주기', 'CHKCYCLE', { width: 80, align: 'center', columnType: enumColumnTypes.combo, gpcd: 'CHKCYCLE', readOnly: true }),
        column.create('정렬순서', 'SORTNO', { width: 80, columnType: enumColumnTypes.number, decimalPrecision: 0, readOnly: false }),
        column.split()
    ]);

    // 설비 복사 팝업: 복사 원본 설비
    ItsGrid.Create('grid7', { isCheckBoxGrid: false, isSubTotalGrid: false }, [
        column.create('설비코드', 'PLANCD', { width: 100, align: 'center' }),
        column.create('설비명', 'PLANNM', { width: 150 }),
        column.create('일상점검 건수', 'ITEMCNT', { width: 80, columnType: enumColumnTypes.number, decimalPrecision: 0 }),
        column.split()
    ]);

    // 설비 복사 팝업: 복사 원본 일상점검 항목
    // 2026-11-03 [설비 복사 팝업] 점검주기 표시
    ItsGrid.Create('grid8', { isCheckBoxGrid: false, isSubTotalGrid: false }, [
        column.create('점검코드', 'CHKKNDCD', { width: 70, align: 'center' }),
        column.create('점검명', 'CHKKNDNM', { width: 300 }),
        column.create('점검항목', 'CHKLOCNM', { width: 130, align: 'center' }),
        column.create('점검방법', 'CHKMTHNM', { width: 100, align: 'center' }),
        column.create('점검값구분', 'CHKVALTPNM', { width: 90, align: 'center' }),
        column.create('점검주기', 'CHKCYCLE', { width: 80, align: 'center', columnType: enumColumnTypes.combo, gpcd: 'CHKCYCLE', readOnly: true }),
        column.split()
    ]);

    // 일상점검 항목 추가 팝업 (두 탭 공용)
    // 2026-11-03 [일상점검 항목 추가 팝업] 점검주기 표시
    ItsGrid.Create('grid10', { isCheckBoxGrid: true, isSubTotalGrid: false }, [
        column.create('점검코드', 'CHKKNDCD', { width: 70, align: 'center' }),
        column.create('점검명', 'CHKKNDNM', { width: 300 }),
        column.create('점검항목', 'CHKLOCNM', { width: 130, align: 'center' }),
        column.create('점검방법', 'CHKMTHNM', { width: 100, align: 'center' }),
        column.create('점검값구분', 'CHKVALTPNM', { width: 90, align: 'center' }),
        column.create('점검주기', 'CHKCYCLE', { width: 80, align: 'center', columnType: enumColumnTypes.combo, gpcd: 'CHKCYCLE', readOnly: true }),
        column.split()
    ]);
};
/**********************************************************************************************************************************************************************/
// 조회
ItsButton.EventSearch = function () {
    if (ItsTab.GetIndex('tab1') == 0) {
        // 설비그룹 목록 조회 (선택 행의 REV·점검항목은 onSelect 에서 조회)
        ItsGrid.Clear('grid_GRP_REV');
        ItsGrid.Clear('grid_GRP2');

        var maria = new ItsMaria('PRD6001_R02', 'LIST_MSTEQM_GRP');
        maria.AddPanel('div_GRP');
        maria.CallProc();
        if (maria.isError) {
            maria.ShowErrMsg();
            return;
        }

        ItsGrid.SetStore('grid_GRP1', maria.store);
        ItsMsg.Toast(ItsMsg.CommonMsg.SearchComplete(maria.store.Length()));
    }
    else if (ItsTab.GetIndex('tab1') == 1) {
        // 설비 목록 조회 (선택 행의 REV·점검항목은 onSelect 에서 조회)
        ItsGrid.Clear('grid_EQM_REV');
        ItsGrid.Clear('grid3');

        var maria = new ItsMaria('PRD6001_R02', 'LIST_MSTEQM');
        maria.AddPanel('div_EQM');
        maria.CallProc();
        if (maria.isError) {
            maria.ShowErrMsg();
            return;
        }

        ItsGrid.SetStore('grid1', maria.store);
        ItsMsg.Toast(ItsMsg.CommonMsg.SearchComplete(maria.store.Length()));
    }
};
/**********************************************************************************************************************************************************************/
// 설비그룹 점검계획 탭

// 설비그룹 선택 시 개정 이력(REV) 조회
ItsGrid.Event('grid_GRP1').onSelect = function (rowIndex) {
    ItsGrid.Clear('grid_GRP2');

    var maria = new ItsMaria('PRD6001_R02', 'LIST_PLAN_REV');
    maria.AddParam('PLANTP', 'G');
    maria.AddParam('PLANCD', ItsGrid.GetValue('grid_GRP1', rowIndex, 'EQMGUBUN'));
    maria.CallProc();
    if (maria.isError) {
        maria.ShowErrMsg();
        return;
    }

    ItsGrid.SetStore('grid_GRP_REV', maria.store);
};

// REV 선택 시 그 REV 의 일상점검 항목 조회
ItsGrid.Event('grid_GRP_REV').onSelect = function (rowIndex) {
    var maria = new ItsMaria('PRD6001_R02', 'LIST_PLAN_REV_ITEM');
    maria.AddParam('PLANTP', 'G');
    maria.AddParam('PLANCD', ItsGrid.GetValue('grid_GRP1', ItsGrid.GetCurrentIndex('grid_GRP1'), 'EQMGUBUN'));
    maria.AddParam('REVNUM', ItsGrid.GetValue('grid_GRP_REV', rowIndex, 'REVNUM'));
    maria.CallProc();
    if (maria.isError) {
        maria.ShowErrMsg();
        return;
    }

    ItsGrid.SetStore('grid_GRP2', maria.store);
};

// 일상점검 항목 추가 팝업
ItsButton.Event('bdiv_GRP_btn_ADD').onClick = function () {
    var EQMGUBUN = ItsGrid.GetValue('grid_GRP1', ItsGrid.GetCurrentIndex('grid_GRP1'), 'EQMGUBUN');
    if (!EQMGUBUN) {
        ItsMsg.Toast('설비그룹을 선택하세요.');
        return;
    }

    if (ItsGrid.GetCurrentIndex('grid_GRP_REV') > 0) {
        ItsMsg.Toast('최신 REV 에서만 수정할 수 있습니다.');
        return;
    }

    var maria = new ItsMaria('PRD6001_R02', 'LIST_CHKKND_ADD');
    maria.AddParam('PLANTP', 'G');
    maria.AddParam('PLANCD', EQMGUBUN);
    maria.CallProc();
    if (maria.isError) {
        maria.ShowErrMsg();
        return;
    }

    ItsPop.Open('pop_EQM02_ADD');
    ItsGrid.SetStore('grid10', maria.store);
};

// 일상점검 항목 저장 (정렬순서)
ItsButton.Event('bdiv_GRP_btn_SAVE').onClick = function () {
    var EQMGUBUN = ItsGrid.GetValue('grid_GRP1', ItsGrid.GetCurrentIndex('grid_GRP1'), 'EQMGUBUN');

    if (ItsGrid.GetCurrentIndex('grid_GRP_REV') > 0) {
        ItsMsg.Toast('최신 REV 에서만 수정할 수 있습니다.');
        return;
    }

    var hasChecked = false;
    for (var i = 0; i < ItsGrid.Length('grid_GRP2'); i++) {
        if (ItsGrid.IsChecked('grid_GRP2', i)) {
            hasChecked = true;
            break;
        }
    }

    if (!hasChecked) {
        ItsMsg.Toast('선택된 항목이 없습니다.');
        return;
    }

    ItsMsg.Confirm('선택한 점검항목을 저장하시겠습니까?', function () {
        var maria = new ItsMaria('PRD6001_R02', 'SAVE_PLAN_ITEM');
        maria.AddParam('PLANTP', 'G');
        maria.AddParam('PLANCD', EQMGUBUN);
        maria.AddParam('REVNUM', ItsGrid.GetValue('grid_GRP_REV', 0, 'REVNUM'));

        for (var i = 0; i < ItsGrid.Length('grid_GRP2'); i++) {
            if (ItsGrid.IsChecked('grid_GRP2', i)) {
                maria.AddList('CHKKNDCD_LIST', ItsGrid.GetValue('grid_GRP2', i, 'CHKKNDCD'));
                maria.AddList('SORTNO_LIST', ItsGrid.GetValue('grid_GRP2', i, 'SORTNO'));
                maria.AddList('REMARK_LIST', ItsGrid.GetValue('grid_GRP2', i, 'REMARK'));
            }
        }

        maria.CallProc();
        if (maria.isError) {
            maria.ShowErrMsg();
            return;
        }

        ItsMsg.Toast(ItsMsg.CommonMsg.SaveComplete());
        ItsGrid.Setkey('grid_GRP1', 'EQMGUBUN', EQMGUBUN);
        ItsButton.EventSearch();
    }, function () {
        ItsMsg.Toast('저장이 취소되었습니다.');
    });
};

// 일상점검 항목 삭제
ItsButton.Event('bdiv_GRP_btn_DEL').onClick = function () {
    var EQMGUBUN = ItsGrid.GetValue('grid_GRP1', ItsGrid.GetCurrentIndex('grid_GRP1'), 'EQMGUBUN');

    if (ItsGrid.GetCurrentIndex('grid_GRP_REV') > 0) {
        ItsMsg.Toast('최신 REV 에서만 수정할 수 있습니다.');
        return;
    }

    var hasChecked = false;
    for (var i = 0; i < ItsGrid.Length('grid_GRP2'); i++) {
        if (ItsGrid.IsChecked('grid_GRP2', i)) {
            hasChecked = true;
            break;
        }
    }

    if (!hasChecked) {
        ItsMsg.Toast('선택된 항목이 없습니다.');
        return;
    }

    ItsMsg.Confirm('선택한 점검항목을 삭제하시겠습니까?', function () {
        var maria = new ItsMaria('PRD6001_R02', 'DELETE_PLAN_ITEM');
        maria.AddParam('PLANTP', 'G');
        maria.AddParam('PLANCD', EQMGUBUN);
        maria.AddParam('REVNUM', ItsGrid.GetValue('grid_GRP_REV', 0, 'REVNUM'));

        for (var i = 0; i < ItsGrid.Length('grid_GRP2'); i++) {
            if (ItsGrid.IsChecked('grid_GRP2', i)) {
                maria.AddList('CHKKNDCD_LIST', ItsGrid.GetValue('grid_GRP2', i, 'CHKKNDCD'));
            }
        }

        maria.CallProc();
        if (maria.isError) {
            maria.ShowErrMsg();
            return;
        }

        ItsMsg.Toast(ItsMsg.CommonMsg.DeleteComplete());
        ItsGrid.Setkey('grid_GRP1', 'EQMGUBUN', EQMGUBUN);
        ItsButton.EventSearch();
    }, function () {
        ItsMsg.Toast('삭제가 취소되었습니다.');
    });
};

// 일상점검 항목 복사 팝업
ItsButton.Event('bdiv_GRP_btn_COPY').onClick = function () {
    var EQMGUBUN = ItsGrid.GetValue('grid_GRP1', ItsGrid.GetCurrentIndex('grid_GRP1'), 'EQMGUBUN');
    if (!EQMGUBUN) {
        ItsMsg.Toast('설비그룹을 선택하세요.');
        return;
    }

    if (ItsGrid.GetCurrentIndex('grid_GRP_REV') > 0) {
        ItsMsg.Toast('최신 REV 에서만 수정할 수 있습니다.');
        return;
    }

    ItsGrid.Clear('grid_GRP_COPY2');

    var maria = new ItsMaria('PRD6001_R02', 'LIST_COPY_PLAN');
    maria.AddParam('PLANTP', 'G');
    maria.AddParam('PLANCD', EQMGUBUN);
    maria.CallProc();
    if (maria.isError) {
        maria.ShowErrMsg();
        return;
    }

    ItsPop.Open('pop_GRP_EQM02_COPY');
    ItsGrid.SetStore('grid_GRP_COPY1', maria.store);
};

// 복사 원본 설비그룹 선택 시 일상점검 항목 조회
ItsGrid.Event('grid_GRP_COPY1').onSelect = function (rowIndex) {
    var maria = new ItsMaria('PRD6001_R02', 'LIST_PLAN_REV_ITEM');
    maria.AddParam('PLANTP', 'G');
    maria.AddParam('PLANCD', ItsGrid.GetValue('grid_GRP_COPY1', rowIndex, 'PLANCD'));
    maria.AddParam('REVNUM', '');
    maria.CallProc();
    if (maria.isError) {
        maria.ShowErrMsg();
        return;
    }

    ItsGrid.SetStore('grid_GRP_COPY2', maria.store);
};

// 일상점검 항목 복사 (선택한 설비그룹의 항목으로 전체 교체)
ItsButton.Event('btn_COPY_GRP_EQM02').onClick = function () {
    var EQMGUBUN = ItsGrid.GetValue('grid_GRP1', ItsGrid.GetCurrentIndex('grid_GRP1'), 'EQMGUBUN');

    ItsMsg.Confirm('선택한 설비그룹의 점검항목으로 복사하시겠습니까?', function () {
        var maria = new ItsMaria('PRD6001_R02', 'COPY_PLAN_ITEM');
        maria.AddParam('PLANTP', 'G');
        maria.AddParam('PLANCD', EQMGUBUN);
        maria.AddParam('PLANCD_COPY', ItsGrid.GetValue('grid_GRP_COPY1', ItsGrid.GetCurrentIndex('grid_GRP_COPY1'), 'PLANCD'));
        maria.AddParam('REVNUM', ItsGrid.Length('grid_GRP_REV') > 0 ? ItsGrid.GetValue('grid_GRP_REV', 0, 'REVNUM') : '');
        maria.CallProc();
        if (maria.isError) {
            maria.ShowErrMsg();
            return;
        }

        ItsPop.Close('pop_GRP_EQM02_COPY');
        ItsMsg.Toast(ItsMsg.CommonMsg.CopyComplete());
        ItsGrid.Setkey('grid_GRP1', 'EQMGUBUN', EQMGUBUN);
        ItsButton.EventSearch();
    }, function () {
        ItsMsg.Toast('복사가 취소되었습니다.');
    });
};

// 복사 팝업 닫기
ItsButton.Event('btn_CANCEL_GRP_COPY_EQM02').onClick = function () {
    ItsPop.Close('pop_GRP_EQM02_COPY');
};

// 개정내용 저장 (승인요청)
ItsButton.Event('btn_GRP_REV_SAVE').onClick = function () {
    var EQMGUBUN = ItsGrid.GetValue('grid_GRP1', ItsGrid.GetCurrentIndex('grid_GRP1'), 'EQMGUBUN');

    if (ItsGrid.Length('grid_GRP_REV') == 0) {
        ItsMsg.Toast('저장할 REV 가 없습니다. 점검항목을 먼저 등록하세요.');
        return;
    }

    ItsGrid.FinishEditing('grid_GRP_REV');

    ItsMsg.Confirm('개정내용을 저장하시겠습니까?', function () {
        var maria = new ItsMaria('PRD6001_R02', 'SAVE_PLAN_REV');
        maria.AddParam('PLANTP', 'G');
        maria.AddParam('PLANCD', EQMGUBUN);
        maria.AddParam('REVNUM', ItsGrid.GetValue('grid_GRP_REV', 0, 'REVNUM'));
        maria.AddParam('REMARK', ItsGrid.GetValue('grid_GRP_REV', 0, 'REMARK'));
        maria.CallProc();
        if (maria.isError) {
            maria.ShowErrMsg();
            return;
        }

        ItsMsg.Toast(ItsMsg.CommonMsg.SaveComplete());
        ItsGrid.Setkey('grid_GRP1', 'EQMGUBUN', EQMGUBUN);
        ItsButton.EventSearch();
    });
};

// 최신 REV 승인
ItsButton.Event('btn_GRP_APPROVE').onClick = function () {
    var EQMGUBUN = ItsGrid.GetValue('grid_GRP1', ItsGrid.GetCurrentIndex('grid_GRP1'), 'EQMGUBUN');

    if (ItsGrid.Length('grid_GRP_REV') == 0) {
        ItsMsg.Toast('승인할 REV 가 없습니다.');
        return;
    }

    ItsMsg.Confirm('[' + EQMGUBUN + '] ' + ItsGrid.GetValue('grid_GRP_REV', 0, 'REVNM') + '을 승인하시겠습니까?', function () {
        var maria = new ItsMaria('PRD6001_R02', 'SAVE_PLAN_STATUS');
        maria.AddParam('PLANTP', 'G');
        maria.AddParam('PLANCD', EQMGUBUN);
        maria.AddParam('REVNUM', ItsGrid.GetValue('grid_GRP_REV', 0, 'REVNUM'));
        maria.AddParam('REMARK', ItsGrid.GetValue('grid_GRP_REV', 0, 'REMARK'));
        maria.CallProc();
        if (maria.isError) {
            maria.ShowErrMsg();
            return;
        }

        ItsMsg.Toast('승인 처리가 완료되었습니다.');
        ItsGrid.Setkey('grid_GRP1', 'EQMGUBUN', EQMGUBUN);
        ItsButton.EventSearch();
    });
};

// 계획서 출력
ItsButton.Event('btn_GRP_PLAN_RPT').onClick = function () {
    var EQMGUBUN = ItsGrid.GetValue('grid_GRP1', ItsGrid.GetCurrentIndex('grid_GRP1'), 'EQMGUBUN');
    if (!EQMGUBUN) {
        ItsMsg.Toast('설비그룹을 선택하세요.');
        return;
    }

    var rpt = new ItsXtraRpt('EQM1001_R03');
    rpt.AddParam('PLANTP', 'G');
    rpt.AddParam('PLANCD', EQMGUBUN);
    rpt.CallPop();
    if (rpt.isError) {
        ItsMsg.Alert(rpt.errMessage);
    }
};
/**********************************************************************************************************************************************************************/
// 설비별 점검계획 탭

// 작업장 변경 시 공정·라인 콤보와 설비 찾기를 그 작업장 기준으로 바꿈
ItsCombo.Event('cmb_LINECD').onChanged = function (value, oldValue) {
    ItsCombo.SetRef01('cmb_EQMTP', ItsCombo.GetValue('cmb_LINECD'));
    ItsCombo.SetValue('cmb_EQMTP', '', false);

    ItsCombo.SetRef01('cmb_EQMGROUP1', ItsCombo.GetValue('cmb_LINECD'), false);
    ItsCombo.SetRef02('cmb_EQMGROUP1', '');
    ItsCombo.SetValue('cmb_EQMGROUP1', '', false);

    // 설비 찾기 (DC_FIND EQMCD: REF05 작업장, REF01 공정, REF02 라인)
    ItsFind.SetRef05('find_EQMCD', ItsCombo.GetValue('cmb_LINECD'));
    ItsFind.SetRef01('find_EQMCD', '');
    ItsFind.SetRef02('find_EQMCD', '');
    ItsFind.SetValue('find_EQMCD', '');
};

// 공정 변경 시 라인 콤보와 설비 찾기를 그 공정 기준으로 바꿈
ItsCombo.Event('cmb_EQMTP').onChanged = function (value, oldValue) {
    ItsCombo.SetRef02('cmb_EQMGROUP1', ItsCombo.GetValue('cmb_EQMTP'));
    ItsCombo.SetValue('cmb_EQMGROUP1', '', false);

    ItsFind.SetRef01('find_EQMCD', ItsCombo.GetValue('cmb_EQMTP'));
    ItsFind.SetRef02('find_EQMCD', '');
    ItsFind.SetValue('find_EQMCD', '');
};

// 라인 변경 시 설비 찾기를 그 라인 기준으로 바꿈
ItsCombo.Event('cmb_EQMGROUP1').onChanged = function (value, oldValue) {
    ItsFind.SetRef02('find_EQMCD', ItsCombo.GetValue('cmb_EQMGROUP1'));
    ItsFind.SetValue('find_EQMCD', '');
};

// 설비 선택 시 개정 이력(REV) 조회
ItsGrid.Event('grid1').onSelect = function (rowIndex) {
    ItsGrid.Clear('grid3');

    var maria = new ItsMaria('PRD6001_R02', 'LIST_PLAN_REV');
    maria.AddParam('PLANTP', 'E');
    maria.AddParam('PLANCD', ItsGrid.GetValue('grid1', rowIndex, 'FANO'));
    maria.CallProc();
    if (maria.isError) {
        maria.ShowErrMsg();
        return;
    }

    ItsGrid.SetStore('grid_EQM_REV', maria.store);
};

// REV 선택 시 그 REV 의 일상점검 항목 조회
ItsGrid.Event('grid_EQM_REV').onSelect = function (rowIndex) {
    var maria = new ItsMaria('PRD6001_R02', 'LIST_PLAN_REV_ITEM');
    maria.AddParam('PLANTP', 'E');
    maria.AddParam('PLANCD', ItsGrid.GetValue('grid1', ItsGrid.GetCurrentIndex('grid1'), 'FANO'));
    maria.AddParam('REVNUM', ItsGrid.GetValue('grid_EQM_REV', rowIndex, 'REVNUM'));
    maria.CallProc();
    if (maria.isError) {
        maria.ShowErrMsg();
        return;
    }

    ItsGrid.SetStore('grid3', maria.store);
};

// 일상점검 항목 추가 팝업
ItsButton.Event('bdiv3_btn_ADD').onClick = function () {
    var FANO = ItsGrid.GetValue('grid1', ItsGrid.GetCurrentIndex('grid1'), 'FANO');
    if (!FANO) {
        ItsMsg.Toast('설비를 선택하세요.');
        return;
    }

    if (ItsGrid.GetCurrentIndex('grid_EQM_REV') > 0) {
        ItsMsg.Toast('최신 REV 에서만 수정할 수 있습니다.');
        return;
    }

    var maria = new ItsMaria('PRD6001_R02', 'LIST_CHKKND_ADD');
    maria.AddParam('PLANTP', 'E');
    maria.AddParam('PLANCD', FANO);
    maria.CallProc();
    if (maria.isError) {
        maria.ShowErrMsg();
        return;
    }

    ItsPop.Open('pop_EQM02_ADD');
    ItsGrid.SetStore('grid10', maria.store);
};

// 일상점검 항목 저장 (정렬순서)
ItsButton.Event('bdiv3_btn_SAVE').onClick = function () {
    var FANO = ItsGrid.GetValue('grid1', ItsGrid.GetCurrentIndex('grid1'), 'FANO');

    if (ItsGrid.GetCurrentIndex('grid_EQM_REV') > 0) {
        ItsMsg.Toast('최신 REV 에서만 수정할 수 있습니다.');
        return;
    }

    var hasChecked = false;
    for (var i = 0; i < ItsGrid.Length('grid3'); i++) {
        if (ItsGrid.IsChecked('grid3', i)) {
            hasChecked = true;
            break;
        }
    }

    if (!hasChecked) {
        ItsMsg.Toast('선택된 항목이 없습니다.');
        return;
    }

    ItsMsg.Confirm('선택한 점검항목을 저장하시겠습니까?', function () {
        var maria = new ItsMaria('PRD6001_R02', 'SAVE_PLAN_ITEM');
        maria.AddParam('PLANTP', 'E');
        maria.AddParam('PLANCD', FANO);
        maria.AddParam('REVNUM', ItsGrid.GetValue('grid_EQM_REV', 0, 'REVNUM'));

        for (var i = 0; i < ItsGrid.Length('grid3'); i++) {
            if (ItsGrid.IsChecked('grid3', i)) {
                maria.AddList('CHKKNDCD_LIST', ItsGrid.GetValue('grid3', i, 'CHKKNDCD'));
                maria.AddList('SORTNO_LIST', ItsGrid.GetValue('grid3', i, 'SORTNO'));
                maria.AddList('REMARK_LIST', ItsGrid.GetValue('grid3', i, 'REMARK'));
            }
        }

        maria.CallProc();
        if (maria.isError) {
            maria.ShowErrMsg();
            return;
        }

        ItsMsg.Toast(ItsMsg.CommonMsg.SaveComplete());
        ItsGrid.Setkey('grid1', 'FANO', FANO);
        ItsButton.EventSearch();
    }, function () {
        ItsMsg.Toast('저장이 취소되었습니다.');
    });
};

// 일상점검 항목 삭제
ItsButton.Event('bdiv3_btn_DEL').onClick = function () {
    var FANO = ItsGrid.GetValue('grid1', ItsGrid.GetCurrentIndex('grid1'), 'FANO');

    if (ItsGrid.GetCurrentIndex('grid_EQM_REV') > 0) {
        ItsMsg.Toast('최신 REV 에서만 수정할 수 있습니다.');
        return;
    }

    var hasChecked = false;
    for (var i = 0; i < ItsGrid.Length('grid3'); i++) {
        if (ItsGrid.IsChecked('grid3', i)) {
            hasChecked = true;
            break;
        }
    }

    if (!hasChecked) {
        ItsMsg.Toast('선택된 항목이 없습니다.');
        return;
    }

    ItsMsg.Confirm('선택한 점검항목을 삭제하시겠습니까?', function () {
        var maria = new ItsMaria('PRD6001_R02', 'DELETE_PLAN_ITEM');
        maria.AddParam('PLANTP', 'E');
        maria.AddParam('PLANCD', FANO);
        maria.AddParam('REVNUM', ItsGrid.GetValue('grid_EQM_REV', 0, 'REVNUM'));

        for (var i = 0; i < ItsGrid.Length('grid3'); i++) {
            if (ItsGrid.IsChecked('grid3', i)) {
                maria.AddList('CHKKNDCD_LIST', ItsGrid.GetValue('grid3', i, 'CHKKNDCD'));
            }
        }

        maria.CallProc();
        if (maria.isError) {
            maria.ShowErrMsg();
            return;
        }

        ItsMsg.Toast(ItsMsg.CommonMsg.DeleteComplete());
        ItsGrid.Setkey('grid1', 'FANO', FANO);
        ItsButton.EventSearch();
    }, function () {
        ItsMsg.Toast('삭제가 취소되었습니다.');
    });
};

// 일상점검 항목 복사 팝업
ItsButton.Event('bdiv3_btn_COPY').onClick = function () {
    var FANO = ItsGrid.GetValue('grid1', ItsGrid.GetCurrentIndex('grid1'), 'FANO');
    if (!FANO) {
        ItsMsg.Toast('설비를 선택하세요.');
        return;
    }

    if (ItsGrid.GetCurrentIndex('grid_EQM_REV') > 0) {
        ItsMsg.Toast('최신 REV 에서만 수정할 수 있습니다.');
        return;
    }

    ItsGrid.Clear('grid8');

    var maria = new ItsMaria('PRD6001_R02', 'LIST_COPY_PLAN');
    maria.AddParam('PLANTP', 'E');
    maria.AddParam('PLANCD', FANO);
    maria.CallProc();
    if (maria.isError) {
        maria.ShowErrMsg();
        return;
    }

    ItsPop.Open('pop_EQM02_COPY');
    ItsGrid.SetStore('grid7', maria.store);
};

// 복사 원본 설비 선택 시 일상점검 항목 조회
ItsGrid.Event('grid7').onSelect = function (rowIndex) {
    var maria = new ItsMaria('PRD6001_R02', 'LIST_PLAN_REV_ITEM');
    maria.AddParam('PLANTP', 'E');
    maria.AddParam('PLANCD', ItsGrid.GetValue('grid7', rowIndex, 'PLANCD'));
    maria.AddParam('REVNUM', '');
    maria.CallProc();
    if (maria.isError) {
        maria.ShowErrMsg();
        return;
    }

    ItsGrid.SetStore('grid8', maria.store);
};

// 일상점검 항목 복사 (선택한 설비의 항목으로 전체 교체)
ItsButton.Event('btn_COPY_EQM02').onClick = function () {
    var FANO = ItsGrid.GetValue('grid1', ItsGrid.GetCurrentIndex('grid1'), 'FANO');

    ItsMsg.Confirm('선택한 설비의 점검항목으로 복사하시겠습니까?', function () {
        var maria = new ItsMaria('PRD6001_R02', 'COPY_PLAN_ITEM');
        maria.AddParam('PLANTP', 'E');
        maria.AddParam('PLANCD', FANO);
        maria.AddParam('PLANCD_COPY', ItsGrid.GetValue('grid7', ItsGrid.GetCurrentIndex('grid7'), 'PLANCD'));
        maria.AddParam('REVNUM', ItsGrid.Length('grid_EQM_REV') > 0 ? ItsGrid.GetValue('grid_EQM_REV', 0, 'REVNUM') : '');
        maria.CallProc();
        if (maria.isError) {
            maria.ShowErrMsg();
            return;
        }

        ItsPop.Close('pop_EQM02_COPY');
        ItsMsg.Toast(ItsMsg.CommonMsg.CopyComplete());
        ItsGrid.Setkey('grid1', 'FANO', FANO);
        ItsButton.EventSearch();
    }, function () {
        ItsMsg.Toast('복사가 취소되었습니다.');
    });
};

// 복사 팝업 닫기
ItsButton.Event('btn_CANCEL_COPY_EQM02').onClick = function () {
    ItsPop.Close('pop_EQM02_COPY');
};

// 개정내용 저장 (승인요청)
ItsButton.Event('btn_EQM_REV_SAVE').onClick = function () {
    var FANO = ItsGrid.GetValue('grid1', ItsGrid.GetCurrentIndex('grid1'), 'FANO');

    if (ItsGrid.Length('grid_EQM_REV') == 0) {
        ItsMsg.Toast('저장할 REV 가 없습니다. 점검항목을 먼저 등록하세요.');
        return;
    }

    ItsGrid.FinishEditing('grid_EQM_REV');

    ItsMsg.Confirm('개정내용을 저장하시겠습니까?', function () {
        var maria = new ItsMaria('PRD6001_R02', 'SAVE_PLAN_REV');
        maria.AddParam('PLANTP', 'E');
        maria.AddParam('PLANCD', FANO);
        maria.AddParam('REVNUM', ItsGrid.GetValue('grid_EQM_REV', 0, 'REVNUM'));
        maria.AddParam('REMARK', ItsGrid.GetValue('grid_EQM_REV', 0, 'REMARK'));
        maria.CallProc();
        if (maria.isError) {
            maria.ShowErrMsg();
            return;
        }

        ItsMsg.Toast(ItsMsg.CommonMsg.SaveComplete());
        ItsGrid.Setkey('grid1', 'FANO', FANO);
        ItsButton.EventSearch();
    });
};

// 최신 REV 승인
ItsButton.Event('btn_EQM_APPROVE').onClick = function () {
    var FANO = ItsGrid.GetValue('grid1', ItsGrid.GetCurrentIndex('grid1'), 'FANO');

    if (ItsGrid.Length('grid_EQM_REV') == 0) {
        ItsMsg.Toast('승인할 REV 가 없습니다.');
        return;
    }

    ItsMsg.Confirm('[' + FANO + '] ' + ItsGrid.GetValue('grid_EQM_REV', 0, 'REVNM') + '을 승인하시겠습니까?', function () {
        var maria = new ItsMaria('PRD6001_R02', 'SAVE_PLAN_STATUS');
        maria.AddParam('PLANTP', 'E');
        maria.AddParam('PLANCD', FANO);
        maria.AddParam('REVNUM', ItsGrid.GetValue('grid_EQM_REV', 0, 'REVNUM'));
        maria.AddParam('REMARK', ItsGrid.GetValue('grid_EQM_REV', 0, 'REMARK'));
        maria.CallProc();
        if (maria.isError) {
            maria.ShowErrMsg();
            return;
        }

        ItsMsg.Toast('승인 처리가 완료되었습니다.');
        ItsGrid.Setkey('grid1', 'FANO', FANO);
        ItsButton.EventSearch();
    });
};

// 계획서 출력
ItsButton.Event('btn_EQM_PLAN_RPT').onClick = function () {
    var FANO = ItsGrid.GetValue('grid1', ItsGrid.GetCurrentIndex('grid1'), 'FANO');
    if (!FANO) {
        ItsMsg.Toast('설비를 선택하세요.');
        return;
    }

    var rpt = new ItsXtraRpt('EQM1001_R03');
    rpt.AddParam('PLANTP', 'E');
    rpt.AddParam('PLANCD', FANO);
    rpt.CallPop();
    if (rpt.isError) {
        ItsMsg.Alert(rpt.errMessage);
    }
};
/**********************************************************************************************************************************************************************/
// 일상점검 항목 추가 팝업 (두 탭 공용)

// 체크한 항목 추가
ItsButton.Event('btn_ADD_EQM02').onClick = function () {
    var hasChecked = false;
    for (var i = 0; i < ItsGrid.Length('grid10'); i++) {
        if (ItsGrid.IsChecked('grid10', i)) {
            hasChecked = true;
            break;
        }
    }

    if (!hasChecked) {
        ItsMsg.Toast('선택된 항목이 없습니다.');
        return;
    }

    var maria = new ItsMaria('PRD6001_R02', 'ADD_PLAN_ITEM');

    if (ItsTab.GetIndex('tab1') == 0) {
        var PLANCD = ItsGrid.GetValue('grid_GRP1', ItsGrid.GetCurrentIndex('grid_GRP1'), 'EQMGUBUN');
        maria.AddParam('PLANTP', 'G');
        maria.AddParam('PLANCD', PLANCD);
        maria.AddParam('REVNUM', ItsGrid.Length('grid_GRP_REV') > 0 ? ItsGrid.GetValue('grid_GRP_REV', 0, 'REVNUM') : '');
    }
    else if (ItsTab.GetIndex('tab1') == 1) {
        var PLANCD = ItsGrid.GetValue('grid1', ItsGrid.GetCurrentIndex('grid1'), 'FANO');
        maria.AddParam('PLANTP', 'E');
        maria.AddParam('PLANCD', PLANCD);
        maria.AddParam('REVNUM', ItsGrid.Length('grid_EQM_REV') > 0 ? ItsGrid.GetValue('grid_EQM_REV', 0, 'REVNUM') : '');
    }

    for (var i = 0; i < ItsGrid.Length('grid10'); i++) {
        if (ItsGrid.IsChecked('grid10', i)) {
            maria.AddList('CHKKNDCD_LIST', ItsGrid.GetValue('grid10', i, 'CHKKNDCD'));
            maria.AddList('REMARK_LIST', ItsGrid.GetValue('grid10', i, 'REMARK'));
        }
    }

    maria.CallProc();
    if (maria.isError) {
        maria.ShowErrMsg();
        return;
    }

    ItsPop.Close('pop_EQM02_ADD');
    ItsMsg.Toast(ItsMsg.CommonMsg.AddComplete);

    if (ItsTab.GetIndex('tab1') == 0) {
        ItsGrid.Setkey('grid_GRP1', 'EQMGUBUN', PLANCD);
    }
    else if (ItsTab.GetIndex('tab1') == 1) {
        ItsGrid.Setkey('grid1', 'FANO', PLANCD);
    }
    ItsButton.EventSearch();
};

// 팝업 닫기
ItsButton.Event('btn_CANCEL_ADD_EQM02').onClick = function () {
    ItsPop.Close('pop_EQM02_ADD');
};
/**********************************************************************************************************************************************************************/
