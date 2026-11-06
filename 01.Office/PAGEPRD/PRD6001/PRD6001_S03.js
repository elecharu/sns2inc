/// <reference path="../../Script/reference.js" />
var tabState = 0;

/* 페이지 접근 시 수행 */
ItsPage.Load = function () {
    ItsGrid.Create('grid1', { isCheckBoxGrid: true }, [
        column.create('설비수리번호', 'EQMREPNO', { width: 150, align: 'center', hidden: true }),
        column.create('작업장', 'LINENM', { width: 80, align: 'center' }),
        column.create('설비구분', 'EQMTPNM', { width: 80, align: 'center' }),
        column.create('설비대분류', 'EQMGROUP1NM', { width: 80, align: 'center' }),
        column.create('설비중분류', 'EQMGROUP2', { width: 100, align: 'center', columnType: enumColumnTypes.combo, gpcd: 'FM114' }),
        column.create('상세설비', 'FANO', { width: 100, align: 'center', hidden: true }),
        column.create('상세설비명', 'EQMNM', { width: 100, align: 'center' }),
        column.create('수리시작시간', 'NONSTIME', { width: 150, align: 'center' }),
        column.create('수리완료시간', 'NONETIME', { width: 150, align: 'center' }),
        column.create('수리유형', 'REPTP', { width: 120, align: 'center', columnType: enumColumnTypes.combo, gpcd: 'ISSUE' }),
        column.create('정지시간', 'REPSTOPTIME', { width: 100, align: 'center' }),
        column.create('고장원인', 'REPREMARK', { width: 400, align: 'center', readOnly: true }),
        column.create('처리내용', 'HANDLEREMARK', { width: 500, align: 'center', readOnly: true }),
        column.split()
    ]);

    ItsGrid.Create('grid2', { isCheckBoxGrid: true}, [
        column.create('입력일자', 'DATETIME', { width: 100, align: 'center', hidden: true }),
        column.create('부서명', 'DEPTCD', { width: 100, columnType: enumColumnTypes.combo, gpcd: 'DEPTCD', align: 'center', hidden: true }),
        column.create('작업자', 'EMPCD', { width: 100, columnType: enumColumnTypes.combo, gpcd: 'EMPCD', align: 'center' }),
        column.create('근무직구분', 'WORKDUTY', { width: 100, columnType: enumColumnTypes.combo, gpcd: 'HR160', align: 'center', hidden: true }),
        column.create('순번', 'SEQ', { width: 50, align: 'center', hidden: true }),
        column.create('구분', 'GUBUN', { width: 50, align: 'center', hidden: true }),
        column.create('설비', 'TITLE', { width: 150, columnType: enumColumnTypes.combo, gpcd: 'FANO', readOnly: false }),
        column.create('작업시간(분)', 'WORKTIME', { width: 100, columnType: enumColumnTypes.number, readOnly: false}),
        column.create('개선사항', 'REMARK', { width: 500, readOnly: false }),
        column.create('업무정보', 'DAILYINFOTP', { width: 100, align: 'center', readOnly: false, columnType: enumColumnTypes.combo, gpcd: 'DAILYINFOTP'}),
        column.split()
    ]);

    ItsGrid.Create('grid3', { isCheckBoxGrid: true}, [
        column.create('입력일자', 'DATETIME', { width: 100, align: 'center' }),
        column.create('순번', 'SEQ', { width: 50, align: 'center', hidden: true }),
        column.create('구분', 'GUBUN', { width: 50, align: 'center', hidden: true }),
        column.create('항목', 'TITLE', { width: 200, readOnly: false }),
        column.create('요청사항', 'REMARK', { width: 500, readOnly: false }),
        column.create('진행상태', 'DAILYSTATUSTP', { width: 100, align: 'center', readOnly: false, columnType: enumColumnTypes.combo, gpcd: 'DAILYSTATUSTP' }),
        column.split()
    ]);
};


/* 조회 */
ItsButton.EventSearch = function () {
    var maria = new ItsMaria('PRD6001_S03', 'SEL_EQMREP');
    maria.AddPanel('sdiv1');

    maria.CallProc();
    if (maria.isError) {
        maria.ShowErrMsg();
        return;
    }

    ItsGrid.SetStore('grid1', maria.store);
    ItsMsg.Toast(ItsMsg.CommonMsg.SearchComplete(maria.store.data.length));

    var maria = new ItsMaria('PRD6001_S03', 'SEL_EQMREPDAILY');
    maria.AddPanel('sdiv1');

    maria.CallProc();
    if (maria.isError) {
        maria.ShowErrMsg();
        return;
    }

    ItsGrid.SetStore('grid2', maria.store);
    ItsGrid.Get('grid2').autoSizeColumns();

    var maria = new ItsMaria('PRD6001_S03', 'SEL_EQMREPDAILY');
    maria.AddPanel('sdiv1');

    maria.CallProc();
    if (maria.isError) {
        maria.ShowErrMsg();
        return;
    }

    ItsGrid.SetStore('grid3', maria.storeExtend1);
    ItsGrid.Get('grid3').autoSizeColumns();
}

/* 저장 */
ItsButton.EventSave = function () {
    var cnt = 0;
    var maria = new ItsMaria('PRD6001_S03', 'UP_EQMREP');

    for (var i = 0; i < ItsGrid.Length('grid1'); i++) {
        if (ItsGrid.IsChecked('grid1', i)) {
            maria.AddList('EQMREPNOLIST', ItsGrid.GetValue('grid1', i, 'EQMREPNO'));
            maria.AddList('REPREMARKLIST', ItsGrid.GetValue('grid1', i, 'REPREMARK'));
            maria.AddList('HANDLEREMARKLIST', ItsGrid.GetValue('grid1', i, 'HANDLEREMARK'));
            cnt++;
        }
    }

    for (var i = 0; i < ItsGrid.Length('grid2'); i++) {
        if (ItsGrid.IsChecked('grid2', i)) {
            maria.AddList('DATETIMELIST', ItsGrid.GetValue('grid2', i, 'DATETIME'));
            maria.AddList('GUBUNLIST', ItsGrid.GetValue('grid2', i, 'GUBUN'));
            maria.AddList('SEQLIST', ItsGrid.GetValue('grid2', i, 'SEQ'));
            maria.AddList('TITLELIST', ItsGrid.GetValue('grid2', i, 'TITLE'));
            maria.AddList('WORKTIMELIST', ItsGrid.GetValue('grid2', i, 'WORKTIME'));
            maria.AddList('REMARKLIST', ItsGrid.GetValue('grid2', i, 'REMARK'));
            maria.AddList('DAILYINFOTPLIST', ItsGrid.GetValue('grid2', i, 'DAILYINFOTP'));
            cnt++;
        }
    }

    for (var i = 0; i < ItsGrid.Length('grid3'); i++) {
        if (ItsGrid.IsChecked('grid3', i)) {
            maria.AddList('DATETIMELIST', ItsGrid.GetValue('grid3', i, 'DATETIME'));
            maria.AddList('GUBUNLIST', ItsGrid.GetValue('grid3', i, 'GUBUN'));
            maria.AddList('SEQLIST', ItsGrid.GetValue('grid3', i, 'SEQ'));
            maria.AddList('TITLELIST', ItsGrid.GetValue('grid3', i, 'TITLE'));
            maria.AddList('REMARKLIST', ItsGrid.GetValue('grid3', i, 'REMARK'));
            maria.AddList('DAILYSTATUSTPLIST', ItsGrid.GetValue('grid3', i, 'DAILYSTATUSTP'));
            cnt++;
        }
    }

    if (cnt != 0) {
        maria.CallProc();
        if (maria.isError) {
            maria.ShowErrMsg();
            return;
        }
    }

    ItsMsg.Toast(ItsMsg.CommonMsg.SaveComplete(cnt));
    ItsButton.EventSearch();
}

/* 삭제 */
ItsButton.EventDelete = function () {

    ItsMsg.Confirm("선택한 항목을 삭제하시겠습니까?", function () {
        var cnt = 0;
        var maria = new ItsMaria('PRD6001_S03', 'DEL_EQMREP');

        for (var i = 0; i < ItsGrid.Length('grid2'); i++) {
            if (ItsGrid.IsChecked('grid2', i)) {            
                maria.AddList('DATETIMELIST', ItsGrid.GetValue('grid2', i, 'DATETIME'));
                maria.AddList('GUBUNLIST', ItsGrid.GetValue('grid2', i, 'GUBUN'));
                maria.AddList('SEQLIST', ItsGrid.GetValue('grid2', i, 'SEQ'));
                cnt++;
            }
        }

        for (var i = 0; i < ItsGrid.Length('grid3'); i++) {
            if (ItsGrid.IsChecked('grid3', i)) {
                maria.AddList('DATETIMELIST', ItsGrid.GetValue('grid3', i, 'DATETIME'));
                maria.AddList('GUBUNLIST', ItsGrid.GetValue('grid3', i, 'GUBUN'));
                maria.AddList('SEQLIST', ItsGrid.GetValue('grid3', i, 'SEQ'));
                cnt++;
            }
        }

        if (cnt != 0) {
            maria.CallProc();
            if (maria.isError) {
                maria.ShowErrMsg();
                return;
            }
        }
        else {
            ItsMsg.Alert("삭제 항목을 선택하세요.");
            return;
        }

        ItsMsg.Toast(ItsMsg.CommonMsg.DeleteComplete(cnt));
        ItsButton.EventSearch();
    });
}

ItsButton.Event('div2_2_1_Button').onClick = function () {
    ItsPage.InitData('pdiv1');
    ItsCombo.SetValueByIndex('pdiv1_combo_DAILYINFOTP', 0);
    ItsDate.SetValue('pdiv1_date_date', ItsDate.GetValue('sdiv1_date_SEARCH'));
    ItsFind.SetValue('pdiv1_find_EMPCD', ItsPage.EMPCD)
    ItsPop.Open('pop1');
}

ItsPop.Event('pop1').onAddBtnClick = function () {

    var maria = new ItsMaria('PRD6001_S03', 'INS_EQMREPDAILY');
    maria.AddParam('DATE', ItsDate.GetValue('pdiv1_date_date'));
    maria.AddParam('GUBUN', '1');
    maria.AddParam('TITLE', ItsFind.GetValue('pdiv1_text_TITLE'));
    maria.AddParam('WORKTIME', ItsNum.GetValue('pdiv1_text_WORKTIME'));
    maria.AddParam('EMPCD', ItsFind.GetValue('pdiv1_find_EMPCD'));
    maria.AddParam('REMARK', ItsTextArea.GetValue('pdiv1_textarea_REMARK'));
    maria.AddParam('DAILYINFOTP', ItsCombo.GetValue('pdiv1_combo_DAILYINFOTP'));

    maria.CallProc();
    if (maria.isError) {
        maria.ShowErrMsg();
        return;
    }

    ItsPop.Close('pop1');

    ItsButton.EventSearch();
}

ItsPop.Event('pop1').onCancelBtnClick = function () {
    ItsPop.Close('pop1');
}

ItsButton.Event('div2_3_1_Button').onClick = function () {
    ItsPage.InitData('pdiv2');
    ItsCombo.SetValueByIndex('pdiv1_combo_DAILYSTATUSTP', 0);
    ItsDate.SetValue('pdiv2_date_date', ItsDate.GetValue('sdiv1_date_SEARCH'));
    ItsPop.Open('pop2');
}

ItsPop.Event('pop2').onAddBtnClick = function () {

    var maria = new ItsMaria('PRD6001_S03', 'INS_EQMREPDAILY');
    maria.AddParam('DATE', ItsDate.GetValue('pdiv2_date_date'));
    maria.AddParam('GUBUN', '2');
    maria.AddParam('TITLE', ItsTextArea.GetValue('pdiv2_text_TITLE'));
    maria.AddParam('REMARK', ItsTextArea.GetValue('pdiv2_textarea_REMARK'));
    maria.AddParam('DAILYSTATUSTP', ItsCombo.GetValue('pdiv1_combo_DAILYSTATUSTP'));

    maria.CallProc();
    if (maria.isError) {
        maria.ShowErrMsg();
        return;
    }

    ItsPop.Close('pop2');

    ItsButton.EventSearch();
}

ItsPop.Event('pop2').onCancelBtnClick = function () {
    ItsPop.Close('pop2');
}

// 프린트
ItsButton.EventPrint = function () {
    
    var rpt = new ItsXtraRpt('PRD6001_R01');
    
    rpt.AddParam('DATE', ItsDate.GetValue('sdiv1_date_SEARCH'));
    rpt.AddParam('REPTP', ItsCombo.GetValue('sdiv1_combo_REPTP'));

    if (rpt.isError) {
        ItsMsg.Alert(rpt.errMessage);
        return;
    }

    rpt.Call();
}