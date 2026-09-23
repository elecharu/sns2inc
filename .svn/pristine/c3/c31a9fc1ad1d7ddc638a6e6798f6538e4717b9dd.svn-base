
/// <reference path="../../Script/reference.js" />

    /* 페이지 로드 시 수행 */
ItsPage.Load = function () {

    ItsGrid.Create('grid_PRDINS_CUT', { isSubTotalGrid: false, isCheckBoxGrid: false }, [
        column.create('작업지시번호', 'PRDINSKEY', { width: 120, align: 'center', hidden: true }),
        
        column.create('지시일자', 'INSDATE', { width: 100, align: 'center' }),
        column.create('수주명', 'SALODRNM', { width: 110 }),
        column.create('지시상태', 'WORKSTT', { width: 100, columnType: enumColumnTypes.combo, gpcd: 'WORKSTT', align: 'center' }),
        column.create('설비코드', 'EQMCD', { width: 100, align: 'center' }),
        column.create('설비명', 'EQMNM', { width: 100, align: 'center' }),
        column.create('거래처명', 'CUSTNM', { width: 100, align: 'center' }),
        //column.create('원자재코드', 'MTRITEMCD', { width: 100, align: 'center' }),
        column.create('원자재명', 'MTRITEMNM', { width: 100, align: 'center' }),
        column.create('특이사항', 'REMARK', { width: 100, align: 'center' }),
        column.create('자재투입 등록', 'POP_ADD_PRDINSSCAN', { width: 150, columnType: enumColumnTypes.button, iconCls: 'fa-pencil' }),
        column.create('생산실적 등록', 'POP_ADD_PRDRST', { width: 150, columnType: enumColumnTypes.button, iconCls: 'fa-pencil' }),
        column.create('생산실적 삭제', 'POP_DEL_PRDRST', { width: 150, columnType: enumColumnTypes.button, iconCls: 'fa-trash' }),
        column.create('작업지시서 보기', 'OPEN_PRDINS_FILE', { width: 150, columnType: enumColumnTypes.button, iconCls: 'fa-search' }),        
        column.create('잔재 생성', 'POP_COMLOT_MTRLEFT', { width: 150, columnType: enumColumnTypes.button, iconCls: 'fa-search' }),
        column.create('작업 중지', 'STOP_PRDINS', { width: 100, columnType: enumColumnTypes.button, iconCls: 'fa-stop' }),
        column.create('작업 종료', 'FINISH_PRDINS', { width: 100, columnType: enumColumnTypes.button, iconCls: 'fa-power-off' }),
        
        column.split()
    ]);

    ItsGrid.Create('grid_PRDITEM', { isSubTotalGrid: true, isCheckBoxGrid: true }, [
        //column.create('수주제품', 'SALITEMCD', { width: 100, align: 'center' }),
        //column.create('수주수량', 'ODRQTY', { width: 100, align: 'center', columnType: enumColumnTypes.number, groupType: enumGrouping.sum }),
        column.create('생산수량 입력', 'GOODQTY_INPUT', { width: 100, align: 'center', columnType: enumColumnTypes.number, readOnly: false }),
        column.create('생산품코드', 'SUBITEMCD', { width: 100, align: 'center' }),
        column.create('지시수량', 'INSQTY', { width: 100, align: 'center', columnType: enumColumnTypes.number, groupType: enumGrouping.sum }),
        column.band('누적', {}, [
            column.create('생산수량', 'PRODQTY', { width: 100, align: 'center', columnType: enumColumnTypes.number, groupType: enumGrouping.sum }),
            column.create('양품수량', 'GOODQTY', { width: 100, align: 'center', columnType: enumColumnTypes.number, groupType: enumGrouping.sum }),
            column.create('추가생산', 'GOODQTY_EXTRA', { width: 100, align: 'center', columnType: enumColumnTypes.number, groupType: enumGrouping.sum }),
            column.create('불량수량', 'BADQTY', { width: 100, align: 'center', columnType: enumColumnTypes.number, groupType: enumGrouping.sum }),
        ]),
        column.create('비고', 'REMARK', { width: 100 }),

        column.split()
    ]);

    ItsGrid.Create('grid_COMLOT_MTR', { isSubTotalGrid: false, isCheckBoxGrid: false, allowMerging: 'Cells' }, [
        column.create('창고', 'WARENM', { width: 100, align: 'center', allowMerging: true }),
        column.create('품목유형', 'ITEMTP', { width: 100, columnType: enumColumnTypes.combo, gpcd: 'ITEMTP', align: 'center', allowMerging: true }),
        column.create('품목코드', 'ITEMCD', { width: 100, align: 'center', allowMerging: true }),
        column.create('품명', 'ITEMNM', { width: 100, align: 'center', allowMerging: true }),
        column.create('재질', 'MATERIAL', { width: 100, columnType: enumColumnTypes.combo, gpcd: 'MATERIAL', align: 'center', allowMerging: true }),
        column.create('두께', 'THICK', { width: 100, align: 'center', allowMerging: true }),
        column.create('길이', 'LENGTH', { width: 120, align: 'center', allowMerging: true }),
        column.create('폭', 'WIDTH', { width: 100, align: 'center', allowMerging: true }),
        column.create('로트번호', 'LOTKEY', { width: 100, align: 'center' }),
        column.create('재고수량', 'LOTQTY', { width: 100, align: 'center' }),
        column.create('투입수량', 'SCANQTY', { width: 100, align: 'center' }),
        column.create('단위', 'ITEMUNIT', { width: 100, columnType: enumColumnTypes.combo, gpcd: 'ITEMUNIT', align: 'center' }),
        column.create('자재투입 등록', 'POP_SCANQTY', { width: 150, columnType: enumColumnTypes.button, iconCls: 'fa-plus' }),

        column.split()
    ]);

    ItsGrid.Create('grid_PRDINSSCAN', { isSubTotalGrid: false, isCheckBoxGrid: false, allowMerging: 'Cells' }, [
        column.create('투입시간', 'SCANTIME', { width: 100, align: 'center' }),
        column.create('창고', 'WARENM', { width: 100, align: 'center', allowMerging: true }),
        column.create('로트번호', 'LOTKEY', { width: 100, align: 'center' }),
        column.create('투입수량', 'SCANQTY', { width: 100, align: 'center' }),
        column.create('단위', 'ITEMUNIT', { width: 100, columnType: enumColumnTypes.combo, gpcd: 'ITEMUNIT', align: 'center' }),
        column.create('자재투입 취소', 'DEL_PRDINSSCAN', { width: 150, columnType: enumColumnTypes.button, iconCls: 'fa-trash' }),        
        column.create('품목유형', 'ITEMTP', { width: 100, columnType: enumColumnTypes.combo, gpcd: 'ITEMTP', align: 'center', allowMerging: true }),
        column.create('품목코드', 'ITEMCD', { width: 100, align: 'center', allowMerging: true }),
        column.create('품명', 'ITEMNM', { width: 100, align: 'center', allowMerging: true }),
        column.create('재질', 'MATERIAL', { width: 100, columnType: enumColumnTypes.combo, gpcd: 'MATERIAL', align: 'center', allowMerging: true }),
        column.create('두께', 'THICK', { width: 100, align: 'center', allowMerging: true }),
        column.create('길이', 'LENGTH', { width: 120, align: 'center', allowMerging: true }),
        column.create('폭', 'WIDTH', { width: 100, align: 'center', allowMerging: true }),

        column.split()
    ]);

    ItsGrid.Create('grid_COMLOT_MTRLEFT', { isSubTotalGrid: false, isCheckBoxGrid: false, allowMerging: 'Cells' }, [
        column.create('창고', 'WARENM', { width: 100, align: 'center', allowMerging: true }),
        column.create('품목유형', 'ITEMTP', { width: 100, columnType: enumColumnTypes.combo, gpcd: 'ITEMTP', align: 'center', allowMerging: true }),
        column.create('품목코드', 'ITEMCD', { width: 100, align: 'center', allowMerging: true }),
        column.create('품명', 'ITEMNM', { width: 100, align: 'center', allowMerging: true }),
        column.create('재질', 'MATERIAL', { width: 100, columnType: enumColumnTypes.combo, gpcd: 'MATERIAL', align: 'center', allowMerging: true }),
        column.create('두께', 'THICK', { width: 100, align: 'center', allowMerging: true }),
        column.create('길이', 'LENGTH', { width: 120, align: 'center', allowMerging: true }),
        column.create('폭', 'WIDTH', { width: 100, align: 'center', allowMerging: true }),
        column.create('로트번호', 'LOTKEY', { width: 100, align: 'center' }),
        column.create('재고수량', 'LOTQTY', { width: 100, align: 'center' }),
        column.create('단위', 'ITEMUNIT', { width: 100, columnType: enumColumnTypes.combo, gpcd: 'ITEMUNIT', align: 'center' }),
        column.create('잔재사이즈 변경유무', 'SIZECHANGE_YN', { width: 150, columnType: enumColumnTypes.check, hidden: true }),
        column.create('잔재사이즈 변경', 'POP_SIZE_CHANGE', { width: 150, columnType: enumColumnTypes.button, iconCls: 'fa-pencil', hidden: true }),
        column.create('잔재 삭제', 'DEL_MTRLEFT', { width: 150, columnType: enumColumnTypes.button, iconCls: 'fa-trash' }),

        column.split()
    ]);

    ItsGrid.Create('grid_PRDRST', { isSubTotalGrid: false, isCheckBoxGrid: false, }, [
        column.create('등록시간', 'RSTTIME', { width: 100, align: 'center' }),
        column.create('실적유형', 'RSTTP', { width: 100, align: 'center' }),            
        column.create('불량유형', 'BADCD', { width: 100, align: 'center', columnType: enumColumnTypes.combo, gpcd: 'BADCD' }),
        column.create('불량수량', 'BADQTY', { width: 100, align: 'center' }),
        column.create('생산품코드', 'SUBITEMCD', { width: 100, align: 'center' }),
        column.create('실적삭제', 'DEL_PRDRST', { width: 100, columnType: enumColumnTypes.button, iconCls: 'fa-trash' }),    

        column.split()
    ]);

    // 중지버튼 아이콘 변경
    ItsGrid.Get('grid_PRDINS_CUT').formatItem.addHandler(function (s, e) {
        try {
            if (s.columns[e.col].binding == 'STOP_PRDINS' && !$(e.cell).hasClass('wj-header') && !$(e.cell).hasClass('wj-group') && e.panel != s.columnHeader) {
                if (s.getCellData(e.row, ItsGrid.$colIndex('grid_PRDINS_CUT', 'WORKSTT')) == '02') {
                    e.cell.innerHTML = '<div class="fa fa-stop ItsGridButton" onclick="ItsGrid.Event(\'grid_PRDINS_CUT\').onButtonClick(ItsGrid.$GetRowIndex(\'grid_PRDINS_CUT\'),\'STOP_PRDINS\')"></div>';
                }
                else if (s.getCellData(e.row, ItsGrid.$colIndex('grid_PRDINS_CUT', 'WORKSTT')) == '03') {
                    e.cell.innerHTML = '<div class="fa fa-play ItsGridButton" onclick="ItsGrid.Event(\'grid_PRDINS_CUT\').onButtonClick(ItsGrid.$GetRowIndex(\'grid_PRDINS_CUT\'),\'STOP_PRDINS\')"></div>';
                }
                else {
                    e.cell.innerHTML = '';
                }
            }
        } catch (e) { }
    });
};
/*************************************************************************************************************************************************************************/
ItsPage.onMenuClick = function () {
    ItsButton.Event('btn_LIST_PRDINS_CUT').onClick();
};
/*************************************************************************************************************************************************************************/   
// 가공 작업지시 조회 
ItsButton.Event('btn_LIST_PRDINS_CUT').onClick = function () {    
    var maria = new ItsMaria('TAL1001_R01', 'LIST_PRDINS_CUT');

    maria.AddParam('SDATE', ItsDateRange.GetValueFrom('dateR_INSDATE'));
    maria.AddParam('EDATE', ItsDateRange.GetValueTo('dateR_INSDATE'));
    maria.AddParam('EQMCD', ItsCombo.GetValue('cmb_EQMCD'));
    maria.AddParam('WORKSTT', ItsCombo.GetValue('cmb_WORKSTT'));
    maria.AddParam('WORKSTT_99_YN', ItsCheck.GetValue('chk_WORKSTT_99_YN'));

    maria.CallProc();

    if (maria.isError) {
        maria.ShowErrMsg();
        return;
    }

    ItsGrid.SetStore('grid_PRDINS_CUT', maria.store);

    ItsGrid.Get('grid_PRDINS_CUT').autoSizeColumns();
};
/*************************************************************************************************************************************************************************/
ItsGrid.Event('grid_PRDINS_CUT').onButtonClick = function (rowindex, field) {
    if (field == 'POP_ADD_PRDINSSCAN') {
        // 자재투입등록
        LIST_COMLOT_MTR();
        ItsPop.Open('pop_ADD_PRDINSSCAN');
        ItsGrid.Get('grid_COMLOT_MTR').autoSizeColumns();
    }
    else if (field == 'POP_ADD_PRDRST') {
        // 생산실적등록 팝업오픈
        LIST_PRDITEM();

        var WORKSTT = ItsGrid.GetValue('grid_PRDINS_CUT', rowindex, 'WORKSTT')

        if (WORKSTT == '99')
            ItsButton.Show('btn_ADD_PRDRST_CUT_EXTRA');
        else
            ItsButton.Hide('btn_ADD_PRDRST_CUT_EXTRA');

        ItsPop.Open('pop_ADD_PRDRST');

        ItsGrid.Get('grid_PRDITEM').autoSizeColumns();
    }
    else if (field == 'OPEN_PRDINS_FILE') {
        // 작업지시서 파일오픈
        var url = ItsGrid.GetValue('grid_PRDINS_CUT', rowindex, 'FILEURL');

        if (url == undefined || url == '') {
            ItsMsg.Alert('등록된 작업지시서 파일이 없습니다.');
        }
        else {
            const newWindow = window.open(url);

            newWindow.onload = () => {
                if (newWindow.document.documentElement.requestFullscreen) {
                    newWindow.document.documentElement.requestFullscreen();
                }
            };
        }
    }
    else if (field == 'POP_COMLOT_MTRLEFT') {
        // 잔재관리 팝업오픈
        LIST_COMLOT_MTRLEFT();
        ItsCombo.SetValueByIndex('cmb_WARECD', 0);
        ItsPop.Open('pop_COMLOT_MTRLEFT');
        ItsGrid.Get('grid_COMLOT_MTRLEFT').autoSizeColumns();
    }
    else if (field == 'POP_DEL_PRDRST') {
        // 생산실적삭제 팝업오픈
        LIST_PRDRST();
        ItsPop.Open('pop_DEL_PRDRST');
        ItsGrid.Get('grid_PRDRST').autoSizeColumns();
    }
    else if (field == 'STOP_PRDINS') {
        // 작업중지 혹은 재시작
        var WORKSTT = ItsGrid.GetValue('grid_PRDINS_CUT', ItsGrid.GetCurrentIndex('grid_PRDINS_CUT'), 'WORKSTT');

        if (WORKSTT == '02') {
            // 작업중시
            var maria = new ItsMaria('TAL1001_R01', 'STOP_PRDINS');

            var PRDINSKEY = ItsGrid.GetValue('grid_PRDINS_CUT', ItsGrid.GetCurrentIndex('grid_PRDINS_CUT'), 'PRDINSKEY');

            maria.AddParam('PRDINSKEY', PRDINSKEY);

            maria.CallProc();

            if (maria.isError) {
                maria.ShowErrMsg();
                return;
            }
        }
        else if (WORKSTT == '03') {
            // 작업 재시작
            var maria = new ItsMaria('TAL1001_R01', 'RESTART_PRDINS');

            var PRDINSKEY = ItsGrid.GetValue('grid_PRDINS_CUT', ItsGrid.GetCurrentIndex('grid_PRDINS_CUT'), 'PRDINSKEY');

            maria.AddParam('PRDINSKEY', PRDINSKEY);

            maria.CallProc();

            if (maria.isError) {
                maria.ShowErrMsg();
                return;
            }
        }

        ItsButton.Event('btn_LIST_PRDINS_CUT').onClick();
    }
    else if (field == 'FINISH_PRDINS') {
        // 작업종료
        ItsMsg.Confirm("작업을 종료하시겠습니까?", function () {
            var maria = new ItsMaria('TAL1001_R01', 'FINISH_PRDINS');

            var PRDINSKEY = ItsGrid.GetValue('grid_PRDINS_CUT', ItsGrid.GetCurrentIndex('grid_PRDINS_CUT'), 'PRDINSKEY');

            maria.AddParam('PRDINSKEY', PRDINSKEY);

            maria.CallProc();

            if (maria.isError) {
                maria.ShowErrMsg();
                return;
            }

            ItsButton.Event('btn_LIST_PRDINS_CUT').onClick();
        });
    }
};
/*************************************************************************************************************************************************************************/
ItsGrid.Event('grid_COMLOT_MTRLEFT').onButtonClick = function (rowindex, field) {
    if (field == 'POP_SIZE_CHANGE') {
        // 잔재사이즈 변경 팝업오픈
        ItsNum.SetValue('num_LENGTH', ItsGrid.GetValue('grid_COMLOT_MTRLEFT', rowindex, 'LENGTH'));
        ItsNum.SetValue('num_WIDTH', ItsGrid.GetValue('grid_COMLOT_MTRLEFT', rowindex, 'WIDTH'));
        ItsPop.Open('pop_SIZECHANGE');
    }
    else if (field == 'DEL_MTRLEFT') {
        // 잔재 삭제
        ItsMsg.Confirm("잔재를 삭제하시겠습니까?", function () {
            var maria = new ItsMaria('TAL1001_R01', 'DEL_MTRLEFT');

            var PRDINSKEY = ItsGrid.GetValue('grid_PRDINS_CUT', ItsGrid.GetCurrentIndex('grid_PRDINS_CUT'), 'PRDINSKEY');
            var WARECD = ItsGrid.GetValue('grid_COMLOT_MTRLEFT', rowindex, 'WARECD');
            var LOTKEY = ItsGrid.GetValue('grid_COMLOT_MTRLEFT', rowindex, 'LOTKEY');

            maria.AddParam('PRDINSKEY', PRDINSKEY);
            maria.AddParam('WARECD', WARECD);
            maria.AddParam('LOTKEY', LOTKEY);

            maria.CallProc();

            if (maria.isError) {
                maria.ShowErrMsg();
                return;
            }

            LIST_COMLOT_MTRLEFT();
        });
    }
};

// 잔재사이즈 변경
ItsButton.Event('btn_SIZECHANGE').onClick = function () {
    var maria = new ItsMaria('TAL1001_R01', 'SIZECHANGE');

    var WARECD = ItsGrid.GetValue('grid_COMLOT_MTRLEFT', ItsGrid.GetCurrentIndex('grid_COMLOT_MTRLEFT'), 'WARECD');
    var LOTKEY = ItsGrid.GetValue('grid_COMLOT_MTRLEFT', ItsGrid.GetCurrentIndex('grid_COMLOT_MTRLEFT'), 'LOTKEY');
    var LENGTH = ItsNum.GetValue('num_LENGTH');
    var WIDTH = ItsNum.GetValue('num_WIDTH');

    maria.AddParam('WARECD', WARECD);
    maria.AddParam('LOTKEY', LOTKEY);
    maria.AddParam('LENGTH', LENGTH);
    maria.AddParam('WIDTH', WIDTH);

    maria.CallProc();

    if (maria.isError) {
        maria.ShowErrMsg();
        return;
    }

    ItsPop.Close('pop_SIZECHANGE');
    LIST_COMLOT_MTRLEFT();
}
/*************************************************************************************************************************************************************************/
// 자재투입등록 팝업에서의 기능들

ItsGrid.Event('grid_COMLOT_MTR').onButtonClick = function (rowindex, field) {
    if (field == 'POP_SCANQTY') {
        // 투입수량입력 팝업오픈
        ItsNum.SetValue('num_SCANQTY', ItsGrid.GetValue('grid_COMLOT_MTR', rowindex, 'LOTQTY'));
        ItsPop.Open('pop_SCANQTY');
    }
}

ItsGrid.Event('grid_PRDINSSCAN').onButtonClick = function (rowindex, field) {
    if (field == 'DEL_PRDINSSCAN') {
        // 자재투입 취소
        ItsMsg.Confirm("자재투입을 취소하시겠습니까?", function () {
            var maria = new ItsMaria('TAL1001_R01', 'DEL_PRDINSSCAN');

            var PRDINSKEY = ItsGrid.GetValue('grid_PRDINS_CUT', ItsGrid.GetCurrentIndex('grid_PRDINS_CUT'), 'PRDINSKEY');
            var WARECD = ItsGrid.GetValue('grid_PRDINSSCAN', rowindex, 'WARECD');
            var LOTKEY = ItsGrid.GetValue('grid_PRDINSSCAN', rowindex, 'LOTKEY');

            maria.AddParam('PRDINSKEY', PRDINSKEY);
            maria.AddParam('WARECD', WARECD);
            maria.AddParam('LOTKEY', LOTKEY);

            maria.CallProc();

            if (maria.isError) {
                maria.ShowErrMsg();
                return;
            }

            LIST_PRDINSSCAN();
        });
    }
}

// 투입가능자재재고 조회
LIST_COMLOT_MTR = function () {
    var maria = new ItsMaria('TAL1001_R01', 'LIST_COMLOT_MTR');

    var PRDINSKEY = ItsGrid.GetValue('grid_PRDINS_CUT', ItsGrid.GetCurrentIndex('grid_PRDINS_CUT'), 'PRDINSKEY');

    maria.AddParam('PRDINSKEY', PRDINSKEY);

    maria.CallProc();

    if (maria.isError) {
        maria.ShowErrMsg();
        return;
    }

    ItsGrid.SetStore('grid_COMLOT_MTR', maria.store);

    ItsGrid.Get('grid_COMLOT_MTR').autoSizeColumns();
}

// 자재투입이력 조회
LIST_PRDINSSCAN = function () {
    var maria = new ItsMaria('TAL1001_R01', 'LIST_PRDINSSCAN');

    var PRDINSKEY = ItsGrid.GetValue('grid_PRDINS_CUT', ItsGrid.GetCurrentIndex('grid_PRDINS_CUT'), 'PRDINSKEY');

    maria.AddParam('PRDINSKEY', PRDINSKEY);

    maria.CallProc();

    if (maria.isError) {
        maria.ShowErrMsg();
        return;
    }

    ItsGrid.SetStore('grid_PRDINSSCAN', maria.store);

    ItsGrid.Get('grid_PRDINSSCAN').autoSizeColumns();
}

// 자재투입등록
ItsButton.Event('btn_ADD_PRDINSSCAN').onClick = function () {    
    var maria = new ItsMaria('TAL1001_R01', 'ADD_PRDINSSCAN');

    var PRDINSKEY = ItsGrid.GetValue('grid_PRDINS_CUT', ItsGrid.GetCurrentIndex('grid_PRDINS_CUT'), 'PRDINSKEY');
    var WARECD = ItsGrid.GetValue('grid_COMLOT_MTR', ItsGrid.GetCurrentIndex('grid_COMLOT_MTR'), 'WARECD');
    var LOTKEY = ItsGrid.GetValue('grid_COMLOT_MTR', ItsGrid.GetCurrentIndex('grid_COMLOT_MTR'), 'LOTKEY');
    var SCANQTY = ItsNum.GetValue('num_SCANQTY');

    maria.AddParam('PRDINSKEY', PRDINSKEY);
    maria.AddParam('WARECD', WARECD);
    maria.AddParam('LOTKEY', LOTKEY);
    maria.AddParam('SCANQTY', SCANQTY);

    maria.CallProc();

    if (maria.isError) {
        maria.ShowErrMsg();
        return;
    }

    LIST_COMLOT_MTR();

    ItsPop.Close('pop_SCANQTY');
}

ItsTab.Event('tab_ADD_PRDINSSCAN').onTabChanged = function (newPanel) {
    if (newPanel == 0) {
        LIST_COMLOT_MTR();
    }
    else if (newPanel == 1) {
        LIST_PRDINSSCAN();
    }
}

ItsPop.Event('pop_SCANQTY').onPopClosed = function () {
    ItsButton.Event('btn_LIST_PRDINS_CUT').onClick();
}
/*************************************************************************************************************************************************************************/
// 생산실적등록 팝업에서의 기능들

// 작업지시의 생산품목 조회
LIST_PRDITEM = function () {
    var maria = new ItsMaria('TAL1001_R01', 'LIST_PRDINS_SALODRD_EXTRAITEM');

    var PRDINSKEY = ItsGrid.GetValue('grid_PRDINS_CUT', ItsGrid.GetCurrentIndex('grid_PRDINS_CUT'), 'PRDINSKEY');

    maria.AddParam('PRDINSKEY', PRDINSKEY);

    maria.CallProc();

    if (maria.isError) {
        maria.ShowErrMsg();
        return;
    }

    ItsGrid.SetStore('grid_PRDITEM', maria.store);

    ItsGrid.Get('grid_PRDITEM').autoSizeColumns();
}

// 작업지시서 파일오픈
ItsButton.Event('btn_OPEN_PRDINS_FILE').onClick = function () {
    var url = ItsGrid.GetValue('grid_PRDINS_CUT', ItsGrid.GetCurrentIndex('grid_PRDINS_CUT'), 'FILEURL');

    if (url == undefined || url == '') {
        ItsMsg.Alert('등록된 작업지시서 파일이 없습니다.');
    }
    else {
        window.open(url);
    }
}

// 생산실적 등록
ItsButton.Event('btn_ADD_PRDRST_CUT').onClick = function () {
    ItsMsg.Confirm("생산실적을 등록하시겠습니까?", function () {
        var maria = new ItsMaria('TAL1001_R01', 'ADD_PRDRST_CUT');

        var PRDINSKEY = ItsGrid.GetValue('grid_PRDINS_CUT', ItsGrid.GetCurrentIndex('grid_PRDINS_CUT'), 'PRDINSKEY');

        maria.AddParam('PRDINSKEY', PRDINSKEY);

        for (var i = 0; i < ItsGrid.Length('grid_PRDITEM'); i++) {
            if (ItsGrid.IsChecked('grid_PRDITEM', i)) {
                var GOODQTY_INPUT = ItsGrid.GetValue('grid_PRDITEM', i, 'GOODQTY_INPUT');

                if (GOODQTY_INPUT == undefined || GOODQTY_INPUT == '') {
                    ItsMsg.Alert('생산수량을 입력하세요.');
                    return;
                }

                maria.AddList('SALODRDKEY_LIST', ItsGrid.GetValue('grid_PRDITEM', i, 'SALODRDKEY'));
                maria.AddList('SUBITEMCD_LIST', ItsGrid.GetValue('grid_PRDITEM', i, 'SUBITEMCD'));
                maria.AddList('GOODQTY_INPUT_LIST', GOODQTY_INPUT);     
            }       
        }

        maria.CallProc();

        if (maria.isError) {
            maria.ShowErrMsg();
            return;
        }

        LIST_PRDITEM();
        LIST_PRDINSSCAN();
    });
}

// 불량등록
ItsButton.Event('btn_ADD_PRDRSTBAD').onClick = function () {
    ItsMsg.Confirm("불량을 등록하시겠습니까?", function () {
        var maria = new ItsMaria('TAL1001_R01', 'ADD_PRDRSTBAD');

        var PRDINSKEY = ItsGrid.GetValue('grid_PRDINS_CUT', ItsGrid.GetCurrentIndex('grid_PRDINS_CUT'), 'PRDINSKEY');
        var SALODRDKEY = ItsGrid.GetValue('grid_PRDITEM', ItsGrid.GetCurrentIndex('grid_PRDITEM'), 'SALODRDKEY');
        var SUBITEMCD = ItsGrid.GetValue('grid_PRDITEM', ItsGrid.GetCurrentIndex('grid_PRDITEM'), 'SUBITEMCD');
        var BADCD = ItsCombo.GetValue('cmb_BADCD');
        var BADQTY = ItsNum.GetValue('num_BADQTY');

        maria.AddParam('PRDINSKEY', PRDINSKEY);
        maria.AddParam('SALODRDKEY', SALODRDKEY);
        maria.AddParam('SUBITEMCD', SUBITEMCD);
        maria.AddParam('BADCD', BADCD);
        maria.AddParam('BADQTY', BADQTY);

        maria.CallProc();

        if (maria.isError) {
            maria.ShowErrMsg();
            return;
        }

        LIST_PRDITEM();
    });
}

// 추가생산 등록
ItsButton.Event('btn_ADD_PRDRST_CUT_EXTRA').onClick = function () {
    ItsMsg.Confirm("추가 생산실적을 등록하시겠습니까?", function () {
        var maria = new ItsMaria('TAL1001_R01', 'ADD_PRDRST_CUT_EXTRA');

        var PRDINSKEY = ItsGrid.GetValue('grid_PRDINS_CUT', ItsGrid.GetCurrentIndex('grid_PRDINS_CUT'), 'PRDINSKEY');

        maria.AddParam('PRDINSKEY', PRDINSKEY);

        for (var i = 0; i < ItsGrid.Length('grid_PRDITEM'); i++) {
            if (ItsGrid.IsChecked('grid_PRDITEM', i)) {
                var GOODQTY_INPUT = ItsGrid.GetValue('grid_PRDITEM', i, 'GOODQTY_INPUT');

                if (GOODQTY_INPUT == undefined || GOODQTY_INPUT == '') {
                    ItsMsg.Alert('생산수량을 입력하세요.');
                    return;
                }

                maria.AddList('SALODRDKEY_LIST', ItsGrid.GetValue('grid_PRDITEM', i, 'SALODRDKEY'));
                maria.AddList('SUBITEMCD_LIST', ItsGrid.GetValue('grid_PRDITEM', i, 'SUBITEMCD'));
                maria.AddList('GOODQTY_INPUT_LIST', GOODQTY_INPUT);
            }
        }

        maria.CallProc();

        if (maria.isError) {
            maria.ShowErrMsg();
            return;
        }

        LIST_PRDITEM();
        LIST_PRDINSSCAN();
    });
}

ItsPop.Event('pop_ADD_PRDRST').onPopClosed = function () {
    ItsButton.Event('btn_LIST_PRDINS_CUT').onClick();
}

ItsCombo.Event('cmb_BADTP').onChanged = function (value, oldValue) {
    ItsCombo.SetRef01('cmb_BADCD', value);
    ItsCombo.SetValue('cmb_BADCD', '');
}
/*************************************************************************************************************************************************************************/
// 생성된 잔재재고 조회
LIST_COMLOT_MTRLEFT = function () {
    var maria = new ItsMaria('TAL1001_R01', 'LIST_COMLOT_MTRLEFT');

    var PRDINSKEY = ItsGrid.GetValue('grid_PRDINS_CUT', ItsGrid.GetCurrentIndex('grid_PRDINS_CUT'), 'PRDINSKEY');

    maria.AddParam('PRDINSKEY', PRDINSKEY);

    maria.CallProc();

    if (maria.isError) {
        maria.ShowErrMsg();
        return;
    }

    ItsGrid.SetStore('grid_COMLOT_MTRLEFT', maria.store.YnToBool('SIZECHANGE_YN'));

    ItsGrid.Get('grid_COMLOT_MTRLEFT').autoSizeColumns();
}

// 잔재생성
ItsButton.Event('btn_MAKE_MTRLEFT').onClick = function () {
    ItsMsg.Confirm("잔재를 생성하시겠습니까?", function () {
        var maria = new ItsMaria('TAL1001_R01', 'MAKE_MTRLEFT');

        var PRDINSKEY = ItsGrid.GetValue('grid_PRDINS_CUT', ItsGrid.GetCurrentIndex('grid_PRDINS_CUT'), 'PRDINSKEY');
        var LENGTH = ItsNum.GetValue('num_LENGTH2');
        var WIDTH = ItsNum.GetValue('num_WIDTH2');
        var LOTQTY = ItsNum.GetValue('num_LOTQTY');
        var WARECD = ItsCombo.GetValue('cmb_WARECD');

        maria.AddParam('PRDINSKEY', PRDINSKEY);
        maria.AddParam('LENGTH', LENGTH);
        maria.AddParam('WIDTH', WIDTH);
        maria.AddParam('LOTQTY', LOTQTY);
        maria.AddParam('WARECD', WARECD);

        maria.CallProc();

        if (maria.isError) {
            maria.ShowErrMsg();
            return;
        }

        LIST_COMLOT_MTRLEFT();
    });
}
/*************************************************************************************************************************************************************************/
// 생산실적 조회
LIST_PRDRST = function () {
    var maria = new ItsMaria('TAL1001_R01', 'LIST_PRDRST');

    var PRDINSKEY = ItsGrid.GetValue('grid_PRDINS_CUT', ItsGrid.GetCurrentIndex('grid_PRDINS_CUT'), 'PRDINSKEY');

    maria.AddParam('PRDINSKEY', PRDINSKEY);

    maria.CallProc();

    if (maria.isError) {
        maria.ShowErrMsg();
        return;
    }

    ItsGrid.SetStore('grid_PRDRST', maria.store);

    ItsGrid.Get('grid_PRDRST').autoSizeColumns();
}

ItsGrid.Event('grid_PRDRST').onButtonClick = function (rowindex, field) {
    if (field == 'DEL_PRDRST') {
        var RSTTP = ItsGrid.GetValue('grid_PRDRST', rowindex, 'RSTTP');

        if (RSTTP == '양품실적등록') {
            // 양품생산실적 삭제
            ItsMsg.Confirm("양품실적을 삭제하시겠습니까?", function () {
                var maria = new ItsMaria('TAL1001_R01', 'DEL_PRDRST');

                var PRDINSKEY = ItsGrid.GetValue('grid_PRDINS_CUT', ItsGrid.GetCurrentIndex('grid_PRDINS_CUT'), 'PRDINSKEY');
                var PRDWORKKEY = ItsGrid.GetValue('grid_PRDRST', rowindex, 'PRDWORKKEY');

                maria.AddParam('PRDINSKEY', PRDINSKEY);
                maria.AddParam('PRDWORKKEY', PRDWORKKEY);

                maria.CallProc();

                if (maria.isError) {
                    maria.ShowErrMsg();
                    return;
                }

                LIST_PRDRST();
            });
        }
        else if (RSTTP == '추가생산등록') {
            // 추가생산 삭제
            ItsMsg.Confirm("추가생살실적을 삭제하시겠습니까?", function () {
                var maria = new ItsMaria('TAL1001_R01', 'DEL_PRDRST_EXTRA');

                var PRDINSKEY = ItsGrid.GetValue('grid_PRDINS_CUT', ItsGrid.GetCurrentIndex('grid_PRDINS_CUT'), 'PRDINSKEY');
                var PRDWORKKEY = ItsGrid.GetValue('grid_PRDRST', rowindex, 'PRDWORKKEY');

                maria.AddParam('PRDINSKEY', PRDINSKEY);
                maria.AddParam('PRDWORKKEY', PRDWORKKEY);

                maria.CallProc();

                if (maria.isError) {
                    maria.ShowErrMsg();
                    return;
                }

                LIST_PRDRST();
            });
        }
        else if (RSTTP == '불량실적등록') {
            ItsMsg.Confirm("불량실적을 삭제하시겠습니까?", function () {
                var maria = new ItsMaria('TAL1001_R01', 'DEL_PRDRSTBAD');

                var PRDINSKEY = ItsGrid.GetValue('grid_PRDINS_CUT', ItsGrid.GetCurrentIndex('grid_PRDINS_CUT'), 'PRDINSKEY');
                var PRDWORKKEY = ItsGrid.GetValue('grid_PRDRST', rowindex, 'PRDWORKKEY');
                var PRDRSTKEY = ItsGrid.GetValue('grid_PRDRST', rowindex, 'PRDRSTKEY');

                maria.AddParam('PRDINSKEY', PRDINSKEY);
                maria.AddParam('PRDWORKKEY', PRDWORKKEY);
                maria.AddParam('PRDRSTKEY', PRDRSTKEY);

                maria.CallProc();

                if (maria.isError) {
                    maria.ShowErrMsg();
                    return;
                }

                LIST_PRDRST();
            });
        }
    }
};

ItsPop.Event('pop_DEL_PRDRST').onPopClosed = function () {
    ItsButton.Event('btn_LIST_PRDINS_CUT').onClick();
}
/*************************************************************************************************************************************************************************/