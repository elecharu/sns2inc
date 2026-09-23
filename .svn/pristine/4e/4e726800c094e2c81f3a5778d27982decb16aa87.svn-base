
/// <reference path="../../Script/reference.js" />

/* 페이지 로드 시 수행 */
ItsPage.Load = function () {
    ItsGrid.Create('grid1', { /*allowMerging: 'Cells'*/ }, [
        column.create('발주상태', 'MTRODRSTT', { width: 100, columnType: enumColumnTypes.combo, gpcd: 'MTRODRSTT', align: 'center' }),
        column.create('발주일자', 'ODRDATE', { width: 100, align: 'center' }),
        column.create('거래처', 'CUSTCD', { width: 100, columnType: enumColumnTypes.combo, gpcd: 'CUSTCD', align: 'center' }),

        column.create('픔목유형', 'ITEMTP', { width: 80, columnType: enumColumnTypes.combo, gpcd: 'ITEMTP', align: 'center' }),
        column.create('품목코드', 'ITEMCD', { width: 100, align: 'center' }),
        column.create('재질', 'MATERIAL', { width: 50, align: 'center', columnType: enumColumnTypes.combo, gpcd: 'MATERIAL', }),
        column.create('품명', 'ITEMNM', { width: 110, align: 'center' }),

        column.create('두께', 'THICK', { width: 50, columnType: enumColumnTypes.number, aligh: 'center' }),
        column.create('길이', 'LENGTH', { width: 50, columnType: enumColumnTypes.number, aligh: 'center' }),
        column.create('폭', 'WIDTH', { width: 50, columnType: enumColumnTypes.number, aligh: 'center' }),
        column.create('발주상세키', 'MTRODRDKEY', { width: 100, align: 'center', hidden: true }),
        column.create('발주수량', 'ODRQTY', { width: 100, columnType: enumColumnTypes.number }),
        column.create('미입고 수량', 'MISSQTY', { width: 100, columnType: enumColumnTypes.number }),
        column.create('단위', 'ITEMUNIT', { width: 80, columnType: enumColumnTypes.combo, gpcd: 'ITEMUNIT', align: 'center' }),
        column.create('한로트관리', 'ONELOT_YN', { width: 150, columnType: enumColumnTypes.check }),


        column.split()
    ]);

    ItsGrid.Create('grid2', {}, [

        column.band('입고확정 정보', {}, [
            column.create('입고키', 'INKEY', { width: 100, hidden: true }),
            column.create('입고확정일자', 'INDATE', { width: 80, align: "center" }),
            column.create('로트번호', 'LOTKEY', { width: 110, align: "center" }),
            column.create('입고량', 'INQTY', { width: 80, columnType: enumColumnTypes.number, groupType: enumGrouping.sum }),
        ]),
        column.band('수입검사 정보', {}, [
            column.create('수입검사여부', 'INTEST_YN', { width: 150, columnType: enumColumnTypes.check }),
            column.create('수입검사번호', 'TQMRSTKEY', { width: 150, hidden: true }),
            column.create('수입검사일자', 'TQMDATE', { width: 150, align: "center" }),
        ]),
        column.split()
    ]);


    ItsDateRange.SetInitValueFrom('txt_INDATE', ItsHelper.GetYearMonth() + '-01');
};
ItsCombo.Event('cmb_ITEMTP').onChanged = function () {
    ItsCombo.SetRef01('find_ITEMCD', ItsCombo.GetValue('cmb_ITEMTP'));
};

// 조회버튼
ItsButton.Event('button_SEARCHCOMIN').onClick = function () {
    var maria = new ItsMaria('TAL0001_S02', 'LIST_MTRIN');
    maria.AddPanel('sdiv1');
    maria.CallProc();
    if (maria.isError) {
        maria.ShowErrMsg();
        return;
    }

    ItsGrid.SetStore('grid1', maria.store.YnToBool('ONELOT_YN'));
    ItsMsg.Toast(ItsMsg.CommonMsg.SearchComplete(maria.store.Length()));
    ItsGrid.Get('grid1').autoSizeColumns();

};

ItsGrid.Event('grid1').onSelect = function (rowIndex) {
    var maria = new ItsMaria('TAL0001_S02', 'LIST_COMLOT');
    maria.AddParam('MTRODRDKEY', ItsGrid.GetValue('grid1', rowIndex, 'MTRODRDKEY'));
    maria.CallProc();
    if (maria.isError) {
        maria.ShowErrMsg();
        return;
    }
    ItsGrid.SetStore('grid2', maria.store.YnToBool('INTEST_YN'));
    ItsMsg.Toast(ItsMsg.CommonMsg.SearchComplete(maria.store.Length()));
     ItsGrid.Get('grid2').autoSizeColumns();

}