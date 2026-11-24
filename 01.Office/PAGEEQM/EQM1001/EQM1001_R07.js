/// <reference path="../../Script/reference.js" />

// 설비 목록·예방보전 이력·점검항목 그리드
ItsPage.Load = function () {
    ItsGrid.Create('grid1', { isCheckBoxGrid: false, isSubTotalGrid: false }, [
        column.create('작업장', 'LINECD', { width: 110, align: 'center', columnType: enumColumnTypes.combo, gpcd: 'LINECD', readOnly: true }),
        column.create('공정', 'EQMTP', { width: 90, align: 'center', columnType: enumColumnTypes.combo, gpcd: 'FM100', readOnly: true }),
        column.create('라인', 'EQMGROUP1', { width: 90, align: 'center', columnType: enumColumnTypes.combo, gpcd: 'FM113', readOnly: true }),
        column.create('설비번호', 'EQMCD', { width: 110, align: 'center', readOnly: true }),
        column.create('설비명', 'EQMNM', { width: 170, readOnly: true }),
        column.create('정기점검 계획', 'PLANYN', { width: 90, columnType: enumColumnTypes.check, readOnly: true }),
        //column.create('공장', 'FACTORYCD', { width: 100, align: 'center', columnType: enumColumnTypes.combo, gpcd: 'FACTORYCD', readOnly: true }),
    ]);

    ItsGrid.Create('grid2', { isCheckBoxGrid: false, isSubTotalGrid: false }, [
        column.create('점검일자', 'BASEDATE', { width: 100, align: 'center', readOnly: true }),
        column.create('점검자', 'EMPNM', { width: 90, align: 'center', readOnly: true }),
        column.create('문제점', 'PROBLEM', { width: 200, readOnly: true, multiLine: true }),
        column.create('조치사항', 'SOLUTION', { width: 200, readOnly: true, multiLine: true }),
        column.create('승인자', 'APRVEMPNM', { width: 80, align: 'center', readOnly: true }),
        column.create('승인일시', 'APRVTIME', { width: 130, align: 'center', readOnly: true }),
        column.create('등록일시', 'RTIME', { width: 130, align: 'center', readOnly: true }),
        column.create('실적키', 'CHKRSTKEY', { hidden: true }),
        column.create('점검자코드', 'EMPCD', { hidden: true }),
    ]);

    ItsGrid.Create('grid3', { isCheckBoxGrid: false, isSubTotalGrid: false }, [
        column.create('구분', 'PLANTPNM', { width: 70, align: 'center', readOnly: true }),
        column.create('적용 REV', 'REVNM', { width: 80, align: 'center', readOnly: true }),
        column.create('점검코드', 'CHKKNDCD', { width: 80, align: 'center', readOnly: true }),
        column.create('점검명', 'CHKKNDNM', { width: 220, readOnly: true }),
        column.create('점검항목', 'CHKLOC', { width: 100, columnType: enumColumnTypes.combo, gpcd: 'CHKLOC', readOnly: true }),
        column.create('점검방법', 'CHKMTH', { width: 80, columnType: enumColumnTypes.combo, gpcd: 'CHKMTH', readOnly: true }),
        column.create('점검값구분', 'CHKVALTP', { width: 80, columnType: enumColumnTypes.combo, gpcd: 'CHKVALTP', readOnly: true }),
        column.create('점검값', 'CHKVALUE', { width: 80, align: 'center', readOnly: true }),
        column.create('특이사항', 'REMARK', { width: 230, readOnly: true }),
    ]);

    ItsGrid.Create('grid4', { isCheckBoxGrid: false, isSubTotalGrid: false }, [
        column.create('구분', 'PLANTPNM', { width: 70, align: 'center', readOnly: true }),
        column.create('적용 REV', 'REVNM', { width: 80, align: 'center', readOnly: true }),
        column.create('계획구분키', 'PLANTP', { hidden: true }),
        column.create('점검코드', 'CHKKNDCD', { width: 80, align: 'center', readOnly: true }),
        column.create('점검명', 'CHKKNDNM', { width: 220, readOnly: true }),
        column.create('점검항목', 'CHKLOC', { width: 100, columnType: enumColumnTypes.combo, gpcd: 'CHKLOC', readOnly: true }),
        column.create('점검방법', 'CHKMTH', { width: 80, columnType: enumColumnTypes.combo, gpcd: 'CHKMTH', readOnly: true }),
        column.create('점검값구분', 'CHKVALTP', { width: 80, columnType: enumColumnTypes.combo, gpcd: 'CHKVALTP', readOnly: true }),
        column.create('점검값', 'CHKVALUE', { width: 80, align: 'center', readOnly: false }),
        column.create('특이사항', 'REMARK', { width: 246, readOnly: false }),
    ]);

    ItsGrid.Get('grid2').autoRowHeights = true;
    ItsDateRange.SetInitValueFrom('date_SEARCH', ItsHelper.GetYearMonthDay());
    ItsDateRange.SetInitValueTo('date_SEARCH', ItsHelper.GetYearMonthDay());
};

// 작업장 변경 시 공정·라인 콤보를 그 작업장 기준으로 변경
ItsCombo.Event('cmb_LINECD').onChanged = function (value, oldValue) {
    ItsCombo.SetRef01('cmb_EQMTP', ItsCombo.GetValue('cmb_LINECD'));
    ItsCombo.SetValue('cmb_EQMTP', '', false);

    ItsCombo.SetRef01('cmb_EQMGROUP1', ItsCombo.GetValue('cmb_LINECD'), false);
    ItsCombo.SetRef02('cmb_EQMGROUP1', '');
    ItsCombo.SetValue('cmb_EQMGROUP1', '', false);
};

// 공정 변경 시 라인 콤보를 그 공정 기준으로 변경
ItsCombo.Event('cmb_EQMTP').onChanged = function (value, oldValue) {
    ItsCombo.SetRef02('cmb_EQMGROUP1', ItsCombo.GetValue('cmb_EQMTP'));
    ItsCombo.SetValue('cmb_EQMGROUP1', '', false);
};

// 설비 목록 조회
ItsButton.EventSearch = function () {
    var maria = new ItsMaria('EQM1001_R07', 'LIST_EQMCD');
    maria.AddPanel('sdiv1');
    maria.CallProc();
    if (maria.isError) {
        maria.ShowErrMsg();
        return;
    }


    ItsMsg.Toast(ItsMsg.CommonMsg.SearchComplete(maria.store.Length()));
    CLEAR_PM();
};

// 설비 선택 시 예방보전 이력 조회
ItsGrid.Event('grid1').onSelect = function (rowIndex) {
    SEARCH_PM(rowIndex);
};

// 설비 행의 예방보전 이력 조회 (첫 행의 점검항목 표시)
function SEARCH_PM(rowIndex) {
    var eqmCd = rowIndex >= 0 && rowIndex < ItsGrid.Length('grid1') ? ItsGrid.GetValue('grid1', rowIndex, 'EQMCD') : '';
    if (!eqmCd) {
        CLEAR_PM();
        return;
    }

    ItsLabel.SetText('lbl_PM', '■ 예방보전 이력 : ' + eqmCd + ' ' + ItsGrid.GetValue('grid1', rowIndex, 'EQMNM'));

    var maria = new ItsMaria('EQM1001_R07', 'LIST_CHKRST');
    maria.AddPanel('sdiv1');
    maria.AddParam('EQMCD', eqmCd);
    maria.CallProc();
    if (maria.isError) {
        maria.ShowErrMsg();
        return;
    }
    ItsGrid.SetStore('grid2', maria.store);

    var rstIdx = ItsGrid.Length('grid2') > 0 ? 0 : -1;
    if (rstIdx >= 0) {
        ItsGrid.SelectRow('grid2', rstIdx);
    }
    SEARCH_ITEM(rstIdx);
}

// 이력 선택 시 점검항목 결과 조회
ItsGrid.Event('grid2').onSelect = function (rowIndex) {
    SEARCH_ITEM(rowIndex);
};

// 이력 행의 점검항목 결과 조회 (NG 행 강조)
function SEARCH_ITEM(rowIndex) {
    ItsGrid.Clear('grid3');
    var rstKey = rowIndex >= 0 && rowIndex < ItsGrid.Length('grid2') ? ItsGrid.GetValue('grid2', rowIndex, 'CHKRSTKEY') : '';
    if (!rstKey) {
        return;
    }

    var maria = new ItsMaria('EQM1001_R07', 'LIST_CHKRSTKND');
    maria.AddParam('CHKRSTKEY', rstKey);
    maria.CallProc();
    if (maria.isError) {
        maria.ShowErrMsg();
        return;
    }
    SET_NG_COLOR(maria.store.data);
    ItsGrid.SetStore('grid3', maria.store);
}

// NG 점검값 행 배경색
function SET_NG_COLOR(arrRow) {
    for (var i = 0; i < arrRow.length; i++) {
        arrRow[i].BACKGROUND = arrRow[i].CHKVALUE == 'NG' ? 'MISTYROSE' : '';
    }
}

// 설비 미선택 상태로 이력·항목 영역 초기화
function CLEAR_PM() {
    ItsGrid.Clear('grid2');
    ItsGrid.Clear('grid3');
    ItsLabel.SetText('lbl_PM', '■ 예방보전 이력 (좌측에서 설비를 선택하세요)');
}

// 좌측 그리드에서 선택한 설비번호
function GET_EQMCD() {
    var idx = ItsGrid.GetCurrentIndex('grid1');
    if (ItsGrid.Length('grid1') == 0 || idx < 0) {
        return '';
    }
    return ItsGrid.GetValue('grid1', idx, 'EQMCD');
}

// 점검 등록 팝업 (설비의 최신 정기점검 계획 항목, 오늘·로그인 사원 기본값)
ItsButton.Event('btn_PM_ADD').onClick = function () {
    var maria = new ItsMaria('EQM1001_R07', 'LIST_PLAN_ITEM');
    maria.AddParam('EQMCD', GET_EQMCD());
    maria.AddParam('BASEDATE', ItsHelper.GetYearMonthDay());
    maria.CallProc();
    if (maria.isError) {
        maria.ShowErrMsg();
        return;
    }

    ItsPage.InitData('pdiv1');
    ItsText.SetValue('pop1_txt_EQMCD', GET_EQMCD());
    ItsText.SetValue('pop1_txt_EQMNM', ItsGrid.GetValue('grid1', ItsGrid.GetCurrentIndex('grid1'), 'EQMNM'));
    ItsText.SetValue('pop1_txt_GRPREVCD', maria.store.data[0]['GRPREVCD']);
    ItsText.SetValue('pop1_txt_REVCD', maria.store.data[0]['EQMREVCD']);
    ItsDate.SetValue('pop1_date_BASEDATE', ItsHelper.GetYearMonthDay());
    ItsFind.SetValue('pop1_find_EMPCD', ItsPage.EMPCD);
    ItsGrid.SetStore('grid4', maria.store);
    ItsPop.Open('pop1');
};

// 선택한 이력 수정 팝업
ItsButton.Event('btn_PM_EDIT').onClick = function () {
    OPEN_PM_EDIT(ItsGrid.GetCurrentIndex('grid2'));
};

// 이력 더블클릭 시 수정 팝업
ItsGrid.Event('grid2').onDoubleClick = function (rowIndex, field) {
    OPEN_PM_EDIT(rowIndex);
};

// 수정 팝업에 이력·점검항목 표시 (승인된 이력은 안내만)
function OPEN_PM_EDIT(rowIndex) {
    if (!GET_EQMCD()) {
        ItsMsg.Alert('좌측에서 사용 중인 설비를 선택해주세요.');
        return;
    }
    if (ItsGrid.Length('grid2') == 0 || rowIndex < 0) {
        ItsMsg.Alert('수정할 예방보전 이력을 선택해주세요.');
        return;
    }
    if (ItsGrid.GetValue('grid2', rowIndex, 'APRVTIME')) {
        ItsMsg.Alert('승인된 예방보전 이력은 수정할 수 없습니다.\n설비점검 이력에서 승인취소 후 처리해주세요.');
        return;
    }

    var rstKey = ItsGrid.GetValue('grid2', rowIndex, 'CHKRSTKEY');
    var maria = new ItsMaria('EQM1001_R07', 'LIST_CHKRSTKND');
    maria.AddParam('CHKRSTKEY', rstKey);
    maria.CallProc();
    if (maria.isError) {
        maria.ShowErrMsg();
        return;
    }

    ItsPage.InitData('pdiv1');
    ItsText.SetValue('pop1_txt_EQMCD', GET_EQMCD());
    ItsText.SetValue('pop1_txt_EQMNM', ItsGrid.GetValue('grid1', ItsGrid.GetCurrentIndex('grid1'), 'EQMNM'));
    ItsText.SetValue('pop1_txt_CHKRSTKEY', rstKey);
    ItsDate.SetValue('pop1_date_BASEDATE', ItsGrid.GetValue('grid2', rowIndex, 'BASEDATE'));
    ItsFind.SetValue('pop1_find_EMPCD', ItsGrid.GetValue('grid2', rowIndex, 'EMPCD'));
    ItsTextArea.SetValue('pop1_txtarea_PROBLEM', ItsGrid.GetValue('grid2', rowIndex, 'PROBLEM'));
    ItsTextArea.SetValue('pop1_txtarea_SOLUTION', ItsGrid.GetValue('grid2', rowIndex, 'SOLUTION'));
    ItsGrid.SetStore('grid4', maria.store);
    ItsPop.Open('pop1');
}

// 선택한 이력 삭제
ItsButton.Event('btn_PM_DEL').onClick = function () {
    var idx = ItsGrid.GetCurrentIndex('grid2');
    if (!GET_EQMCD()) {
        ItsMsg.Alert('좌측에서 사용 중인 설비를 선택해주세요.');
        return;
    }
    if (ItsGrid.Length('grid2') == 0 || idx < 0) {
        ItsMsg.Alert('삭제할 예방보전 이력을 선택해주세요.');
        return;
    }

    ItsMsg.Confirm('[' + GET_EQMCD() + '] ' + ItsGrid.GetValue('grid2', idx, 'BASEDATE') + ' 예방보전 이력을 삭제하시겠습니까?', function () {
        var maria = new ItsMaria('EQM1001_R07', 'DELETE_CHKRST');
        maria.AddParam('EQMCD', GET_EQMCD());
        maria.AddParam('CHKRSTKEY', ItsGrid.GetValue('grid2', idx, 'CHKRSTKEY'));
        maria.CallProc();
        if (maria.isError) {
            maria.ShowErrMsg();
            return;
        }
        ItsMsg.Toast(ItsMsg.CommonMsg.DeleteComplete());
        SEARCH_PM(ItsGrid.GetCurrentIndex('grid1'));
    });
};

// 점검값 입력 보정 (OK/NG 항목은 OK·NG, 숫자 항목은 숫자, 문자 항목은 그대로)
function CHECK_CHKVALUE(gridId, rowIndex) {
    var valTp = ItsGrid.GetValue(gridId, rowIndex, 'CHKVALTP');
    var val = (ItsGrid.GetValue(gridId, rowIndex, 'CHKVALUE') || '').toString().trim();

    if (valTp === '03') {
        val = val.toUpperCase();
        ItsGrid.SetValue(gridId, rowIndex, 'CHKVALUE', (val === 'OK' || val === 'NG') ? val : '');
    } else if (valTp === '01') {
        ItsGrid.SetValue(gridId, rowIndex, 'CHKVALUE', /^-?\d+(\.\d+)?$/.test(val) ? val : '');
    } else {
        ItsGrid.SetValue(gridId, rowIndex, 'CHKVALUE', val);
    }
}

// 점검값 입력 시 형식 보정
ItsGrid.Event('grid4').onChanged = function (rowIndex, field) {
    if (field === 'CHKVALUE') CHECK_CHKVALUE('grid4', rowIndex);
};

// OK/NG 항목 중 비어 있는 점검값을 OK로 채움
ItsButton.Event('pdiv2_btn_ALL_OK').onClick = function () {
    ItsGrid.Get('grid4').finishEditing();
    for (var i = 0; i < ItsGrid.Length('grid4'); i++) {
        if (ItsGrid.GetValue('grid4', i, 'CHKVALTP') === '03' && !ItsGrid.GetValue('grid4', i, 'CHKVALUE')) {
            ItsGrid.SetValue('grid4', i, 'CHKVALUE', 'OK');
        }
    }
};

// 예방보전 저장 (실적키 없으면 등록, 있으면 수정)
ItsPop.Event('pop1').onAddBtnClick = function () {
    ItsGrid.Get('grid4').finishEditing();
    var rstKey = ItsText.GetValue('pop1_txt_CHKRSTKEY');

    var maria = new ItsMaria('EQM1001_R07', rstKey ? 'SAVE_CHKRST' : 'ADD_CHKRST');
    maria.AddPanel('pdiv1');
    for (var i = 0; i < ItsGrid.Length('grid4'); i++) {
        maria.AddList('PLANTP_LIST', ItsGrid.GetValue('grid4', i, 'PLANTP'));
        maria.AddList('CHKKNDCD_LIST', ItsGrid.GetValue('grid4', i, 'CHKKNDCD'));
        maria.AddList('CHKVALUE_LIST', ItsGrid.GetValue('grid4', i, 'CHKVALUE'));
        maria.AddList('REMARK_LIST', ItsGrid.GetValue('grid4', i, 'REMARK'));
    }
    maria.CallProc();
    if (maria.isError) {
        maria.ShowErrMsg();
        return;
    }

    ItsPop.Close('pop1');
    SEARCH_PM(ItsGrid.GetCurrentIndex('grid1'));
    ItsMsg.Toast(rstKey ? ItsMsg.CommonMsg.SaveComplete() : ItsMsg.CommonMsg.AddComplete);
};

// 팝업 닫기
ItsPop.Event('pop1').onCancelBtnClick = function () {
    ItsPop.Close('pop1');
};
