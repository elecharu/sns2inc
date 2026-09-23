

/// <reference path="../../Script/reference.js" />

/* 페이지 로드 시 수행 */
ItsPage.Load = function () {

    // 가입고 이력(헤더)
    ItsGrid.Create('grid1', { isCheckBoxGrid: true, isSubTotalGrid: true }, [
        column.create('입고일자', 'PRDDATE', { width: 80, align: 'center', readOnly: true }),
        column.create('거래처명', 'CUSTCD', { width: 100, columnType: enumColumnTypes.combo, gpcd: 'CUSTCD', align: 'center', readOnly: true }),
        column.create('품목형태', 'ITEMTP', { width: 70, columnType: enumColumnTypes.combo, gpcd: 'ITEMTP', readOnly: true, align: 'center' }),        
        column.create('품목코드', 'ITEMCD', { width: 200, readOnly: true, align: 'center' }),        
        column.create('품명', 'ITEMNM', { width: 200, align: 'center', readOnly: true }),
        column.create('재질', 'MATERIAL', { width: 100, columnType: enumColumnTypes.combo, gpcd: 'MATERIAL', align: 'center', readOnly: true }),
        column.create('두께', 'THICK', { width: 100, columnType: enumColumnTypes.number, aligh: 'center', readOnly: true }),
        column.create('길이', 'LENGTH', { width: 100, columnType: enumColumnTypes.number, aligh: 'center', readOnly: true }),
        column.create('폭', 'WIDTH', { width: 100, columnType: enumColumnTypes.number, aligh: 'center', readOnly: true }),

        column.create('가입고번호', 'MTRINKEY', { width: 100, align: 'center', hidden: true}),        
        column.create('입고량', 'INQTY', { width: 90, columnType: enumColumnTypes.number, decimalPrecision: 0, groupType: enumGrouping.sum, readOnly: true }),   
        column.create('종합판정', 'FINALJUDGE', { width: 100, align: 'center', columnType: enumColumnTypes.combo, gpcd: 'JUDGE' }),
        column.split()
    ]);



    ItsGrid.Create('grid2', { isCheckBoxGrid: false }, [
        column.create("검사항목코드", "STDCD", { width: 100, hidden: true }),
        column.create("검사항목", "STDNM", { width: 200 }),
        column.create("검사방법", "STDCHKTP", { width: 100, columnType: enumColumnTypes.combo, gpcd: 'STDCHKTP', align: 'center', readOnly: true }),
        column.create("측정부위", "STDPOINT", { width: 100, columnType: enumColumnTypes.combo, gpcd: 'STDPOINT', align: 'center' }),
        column.create("판정범위", "STDJUDGE_MEASURE", { width: 100, columnType: enumColumnTypes.combo, gpcd: 'STDPOINT', align: 'center' }),
        column.create('판정기준', 'STDJUDGE', { width: 200, multiLine: true }),
        column.create('시료수', 'SAMPLESIZE', { width: 60, columnType: enumColumnTypes.number, decimalPrecision: 2 }),

        column.band('검사결과', {}, [
            column.create('MIN', 'MINVAL', { width: 80, columnType: enumColumnTypes.number, decimalPrecision: 3 }),
            column.create('MAX', 'MAXVAL', { width: 80, columnType: enumColumnTypes.number, decimalPrecision: 3 }),
            column.create('AVG', 'AVG', { width: 80, columnType: enumColumnTypes.number, decimalPrecision: 3 }),
            column.create('판정', 'JUDGE', { width: 80, align: 'center', columnType: enumColumnTypes.combo, gpcd: 'JUDGE' }),
        ]),

        column.create('기준값', 'STDVAL', { width: 60, readOnly: true, hidden: true }),
        column.create("단위", "STDUNIT", { width: 60, columnType: enumColumnTypes.combo, gpcd: 'STDUNIT', align: 'center', readOnly: true, hidden: true }),
        column.create('범위', 'STDRANGE', { width: 60, columnType: enumColumnTypes.combo, gpcd: 'STDRANGE', align: 'center', readOnly: true, hidden: true }),
        column.create('오차(-)', 'STDMINUS', { width: 60, columnType: enumColumnTypes.number, decimalPrecision: 3, readOnly: true, hidden: true }),
        column.create('오차(+)', 'STDPLUS', { width: 60, columnType: enumColumnTypes.number, decimalPrecision: 3, readOnly: true, hidden: true }),

        column.split()
    ]);

    ItsGrid.Create('grid_TQMRST_VALUE', { isCheckBoxGrid: true }, [
        column.create('검사값키', 'VALUEKEY', { width: 100, hidden: true }),
        column.create('검사값', 'VALUE', { width: 100, readOnly: false })
    ]);

}

ItsButton.EventSearch = function () {
    ItsGrid.Clear('grid1');
    ItsGrid.Clear('grid2');
    ItsGrid.Clear('grid_TQMRST_VALUE');

    ItsText.SetValue('txt_REVNUM', '');
    ItsText.SetValue('txt_REVCD', '');
    ItsFind.SetValue('find_EMPCD', '');
    ItsCombo.SetValue('comb_FINALJUDGE', '');

    var maria = new ItsMaria('MTR0001_R03 ', 'LIST_MTRINLOT');

    maria.AddPanel('sdiv1');

    maria.CallProc();

    if (maria.isError) {
        maria.ShowErrMsg();
        return;
    }

    ItsGrid.SetStore('grid1', maria.store);
    ItsMsg.Toast(maria.store.Length() + '건이 조회되었습니다.');
};

ItsGrid.Event('grid1').onSelect = function (rowIndex, field) {    
    ItsGrid.Clear('grid2');
    ItsGrid.Clear('grid_TQMRST_VALUE');

    var maria = new ItsMaria('MTR0001_R03', 'LIST_TQMRSTKND');

    var MTRINKEY = ItsGrid.GetValue('grid1', rowIndex, 'MTRINKEY');

    maria.AddParam('MTRINKEY', MTRINKEY);

    maria.CallProc();

    if (maria.isError) {
        maria.ShowErrMsg();
        return;
    }

    ItsGrid.SetStore('grid2', maria.store);

    ItsFind.SetValue('find_EMPCD', ItsGrid.GetValue('grid1', rowIndex, 'EMPCD'));
    ItsCombo.SetValue('comb_FINALJUDGE', ItsGrid.GetValue('grid1', rowIndex, 'FINALJUDGE'));

    var TQMDATE = ItsGrid.GetValue('grid1', rowIndex, 'TQMDATE');

    if (TQMDATE != undefined && TQMDATE != '')
        ItsDate.SetValue('date_TQMDATE', ItsGrid.GetValue('grid1', rowIndex, 'TQMDATE'));

    ItsText.SetValue('txt_REVNUM', maria.store.data[0]["REVNUM"]);
};


/*************************************************************************************************************************************************************************/
ItsGrid.Event('grid2').onSelect = function (rowindex, field) {
    LIST_TQMRST_VALUE();
};


LIST_TQMRST_VALUE = function () {
    ItsGrid.Clear('grid_TQMRST_VALUE');
    ItsCheck.SetValue('check_OK', 'N');
    ItsCheck.SetValue('check_NG', 'N');

    var maria = new ItsMaria('MTR0001_R03', 'LIST_TQMRST_VALUE');

    var TQMRSTKEY = ItsGrid.GetValue('grid1', ItsGrid.GetCurrentIndex('grid1'), 'TQMRSTKEY');
    var STDCD = ItsGrid.GetValue('grid2', ItsGrid.GetCurrentIndex('grid2'), 'STDCD');

    maria.AddParam('TQMRSTKEY', TQMRSTKEY);
    maria.AddParam('STDCD', STDCD);

    maria.CallProc();

    if (maria.isError) {
        maria.ShowErrMsg();
        return;
    }

    var SAMPLESIZE = ItsGrid.GetValue('grid2', ItsGrid.GetCurrentIndex('grid2'), 'SAMPLESIZE');

    if (maria.store.Length() > 0) {
        ItsGrid.SetStore('grid_TQMRST_VALUE', maria.store);

        if (maria.store.Length() < SAMPLESIZE) {
            for (var i = maria.store.Length(); i < SAMPLESIZE; i++) {
                ItsGrid.AddRow('grid_TQMRST_VALUE', i);
            }
        }
    }
    else {
        for (var i = 0; i < SAMPLESIZE; i++) {
            ItsGrid.AddRow('grid_TQMRST_VALUE', i);
        }
    }

    var JUDGE = ItsGrid.GetValue('grid2', ItsGrid.GetCurrentIndex('grid2'), 'JUDGE');

    if (JUDGE == 'Y')
        ItsCheck.SetValue('check_OK', 'Y');
    else if (JUDGE == 'N')
        ItsCheck.SetValue('check_NG', 'Y');
    else {
        ItsCheck.SetValue('check_OK', 'N');
        ItsCheck.SetValue('check_OK', 'N');
    }
}

// 검사결과 저장
ItsButton.Event('btn_SAVE_TQMRSTKND').onClick = function () {
    var maria = new ItsMaria('MTR0001_R03', 'SAVE_TQMRSTKND');

    var MTRINKEY = ItsGrid.GetValue('grid1', ItsGrid.GetCurrentIndex('grid1'), 'MTRINKEY');
    var TQMRSTKEY = ItsGrid.GetValue('grid1', ItsGrid.GetCurrentIndex('grid1'), 'TQMRSTKEY');
    var STDCD = ItsGrid.GetValue('grid2', ItsGrid.GetCurrentIndex('grid2'), 'STDCD');
    var SAMPLESIZE = ItsGrid.GetValue('grid2', ItsGrid.GetCurrentIndex('grid2'), 'SAMPLESIZE');
    var JUDGE = '';
    var TQMDATE = ItsDate.GetValue('date_TQMDATE');
    var EMPCD = ItsFind.GetValue('find_EMPCD');

    if (ItsCheck.GetValue('check_OK') == 'Y')
        JUDGE = 'Y';
    else if (ItsCheck.GetValue('check_NG') == 'Y')
        JUDGE = 'N';

    maria.AddParam('MTRINKEY', MTRINKEY);
    maria.AddParam('TQMRSTKEY', TQMRSTKEY);
    maria.AddParam('STDCD', STDCD);
    maria.AddParam('SAMPLESIZE', SAMPLESIZE);
    maria.AddParam('JUDGE', JUDGE);
    maria.AddParam('TQMDATE', TQMDATE);
    maria.AddParam('EMPCD', EMPCD);

    for (var i = 0; i < ItsGrid.Length('grid_TQMRST_VALUE'); i++) {
        if (ItsGrid.IsChecked('grid_TQMRST_VALUE', i)) {
            maria.AddList('VALUEKEY_LIST', ItsGrid.GetValue('grid_TQMRST_VALUE', i, 'VALUEKEY'));
            maria.AddList('VALUE_LIST', ItsGrid.GetValue('grid_TQMRST_VALUE', i, 'VALUE'));
        }
    }

    maria.CallProc();

    if (maria.isError) {
        maria.ShowErrMsg();
        return;
    }

    var FINALJUDGE = maria.store.data[0]["FINALJUDGE"];
    TQMRSTKEY = maria.store.data[0]["TQMRSTKEY"];

    ItsGrid.SetValue('grid1', ItsGrid.GetCurrentIndex('grid1'), 'TQMDATE', TQMDATE);
    ItsGrid.SetValue('grid1', ItsGrid.GetCurrentIndex('grid1'), 'FINALJUDGE', FINALJUDGE);
    ItsGrid.SetValue('grid1', ItsGrid.GetCurrentIndex('grid1'), 'EMPCD', EMPCD);
    ItsGrid.SetValue('grid1', ItsGrid.GetCurrentIndex('grid1'), 'TQMRSTKEY', TQMRSTKEY);

    var index_grid2 = ItsGrid.GetCurrentIndex('grid2');

    if (index_grid2 + 1 == ItsGrid.Length('grid2'))
        index_grid2 = 0;
    else
        index_grid2 = index_grid2 + 1;

    ItsGrid.Event('grid1').onSelect(ItsGrid.GetCurrentIndex('grid1'));

    ItsGrid.SelectRow('grid2', index_grid2);   // 다음 검사항목 클릭
}

ItsCheck.Event('check_OK').onChanged = function () {
    if (ItsCheck.GetValue('check_OK') == 'Y')
        ItsCheck.SetValue('check_NG', 'N')
};

ItsCheck.Event('check_NG').onChanged = function () {
    if (ItsCheck.GetValue('check_NG') == 'Y')
        ItsCheck.SetValue('check_OK', 'N')
};
/*************************************************************************************************************************************************************************/
// 수입검사 삭제
ItsButton.Event('btn_DELETE_TQMRST').onClick = function () {
    ItsMsg.Confirm("검사결과를 삭제하시겠습니까?\n삭제 후에는 복구할 수 없습니다.", function () {
        var maria = new ItsMaria('MTR0001_R03', 'DELETE_TQMRST');

        for (var i = 0; i < ItsGrid.Length('grid1'); i++) {
            if (ItsGrid.IsChecked('grid1', i)) {
                maria.AddList('TQMRSTKEY_LIST', ItsGrid.GetValue('grid1', i, 'TQMRSTKEY'));
            }
        }

        maria.CallProc();

        if (maria.isError) {
            maria.ShowErrMsg();
            return;
        }

        ItsButton.EventSearch();
    });
}
/*************************************************************************************************************************************************************************/