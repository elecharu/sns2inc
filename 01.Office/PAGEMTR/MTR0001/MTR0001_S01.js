//입고조회
/// <reference path="../../Script/reference.js" />



/* 페이지 로드 시 수행 */
ItsPage.Load = function () {
    /* 가입고일자별 */
    ItsGrid.Create('grid1', { /*allowMerging: 'Cells'*/ }, [
        column.create('발주키', 'MTRODRKEY', { width: 100, align: 'center', hidden: true }),
        column.create('발주상태', 'MTRODRSTT', { width: 80, columnType: enumColumnTypes.combo, gpcd: 'MM110', align: 'center' }),
        column.create('발주일자', 'MTRODRDATE', { width: 90, align: 'center' }),
        column.create('거래처', 'CUSTCD', { width: 150, columnType: enumColumnTypes.combo, gpcd: 'CUSTCD', align: 'center' }),
        column.create('픔목유형', 'ITEMCG', { width: 80, columnType: enumColumnTypes.combo, gpcd: 'DM100', align: 'center' }),
        column.create('품목코드', 'ITEMCD', { width: 150, align: 'center', hidden: true }),        
        column.create('품명', 'ITEMNM', { width: 250, align: 'center' }),
        //column.create('재질', 'ITMAT', { width: 50, align: 'center' }),
        //column.create('두께', 'DUKE', { width: 50, columnType: enumColumnTypes.number, aligh: 'center' }),
        //column.create('길이', 'ITLENGTH', { width: 50, columnType: enumColumnTypes.number, aligh: 'center' }),
        //column.create('폭', 'POK', { width: 50, columnType: enumColumnTypes.number, aligh: 'center' }),
        column.create('발주상세키', 'MTRODRSEQ', { width: 100, align: 'center', hidden: true }),
        column.create('발주수량', 'ODRQTY', { width: 90, columnType: enumColumnTypes.number }),
        //column.create('구매단가', 'MTRODRPRICE', { width: 90, columnType: enumColumnTypes.number }),
        //column.create('구매금액', 'MTRODRAMT', { width: 90, columnType: enumColumnTypes.number }),
        column.create('발주단가', 'MTRODRFPRICE', { width: 90, columnType: enumColumnTypes.number }),
        column.create('발주금액', 'MTRODRFAMT', { width: 90, columnType: enumColumnTypes.number }),
        column.create('미입고 수량', 'MISSQTY', { width: 90, columnType: enumColumnTypes.number  }),
        column.create('단위', 'ITEMUNIT', { width: 60, columnType: enumColumnTypes.combo, gpcd: 'DM150', align: 'center' }),
  
    ]);

    ItsGrid.Create('grid2', { }, [

        column.create('입고키', 'INKEY', { width: 100, hidden: true }),
        column.create('입고확정일자', 'INDATE', { width: 80, align: "center" }),
        column.create('로트번호', 'LOTKEY', { width: 110, align: "center" }),
        column.create('입고량', 'INQTY', { width: 80, columnType: enumColumnTypes.number, groupType: enumGrouping.sum }),

    ]);
     
    ItsDateRange.SetInitValueFrom('date_DATE', ItsHelper.AddDay(-7, ItsHelper.GetYearMonthDay()));

    // 공장 기본값 (법인은 공장의 법인코드를 씀)
    ItsCombo.SetValue('sdiv1_combo_FACTORYCD', '07');
};

// 조회버튼
ItsButton.EventSearch = function () {
    var maria = new ItsMaria('MTR0001_S01', 'LIST_MTRIN');
    maria.AddPanel('sdiv1');
    maria.AddParam('COMPANYCD', ItsFind.GetRef01('find_ITEMID'));   // 법인 = 선택한 공장의 법인코드
    maria.CallProc();
    if (maria.isError) {
        maria.ShowErrMsg();
        return;
    }

    ItsGrid.SetStore('grid1', maria.store);
    ItsMsg.Toast(ItsMsg.CommonMsg.SearchComplete(maria.store.Length()));
    //ItsGrid.Get('grid1').autoSizeColumns();

};

ItsGrid.Event('grid1').onSelect = function (rowIndex) {
    var maria = new ItsMaria('MTR0001_S01', 'LIST_COMLOT');
    maria.AddRecord('grid1', rowIndex);
    maria.CallProc();
    if (maria.isError) {
        maria.ShowErrMsg();
        return;
    }
    ItsGrid.SetStore('grid2', maria.store);
    ItsMsg.Toast(ItsMsg.CommonMsg.SearchComplete(maria.store.Length()));
    //ItsGrid.Get('grid2').autoSizeColumns();
}

/* 공장이 정해지면 품목 find 에 법인(REF01)·공장(REF03) 넣기. 법인코드는 공장 콤보 목록 줄의 REF01(DC_COMBO FACTORYCD) */
ItsCombo.Event('sdiv1_combo_FACTORYCD').onChanged = function (value) {
    var companycd = $('#sdiv1_combo_FACTORYCD').siblings('ul').children('li').filter('[data-value="' + value + '"]').attr('data-ref01');
    if (companycd == undefined || companycd == 'undefined') companycd = '';
    ItsFind.SetRef01('find_ITEMID', companycd);
    ItsFind.SetRef03('find_ITEMID', value);
}