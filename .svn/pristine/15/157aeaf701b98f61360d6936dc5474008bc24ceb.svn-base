//발주조회
/// <reference path="../../Script/reference.js" />

/* 페이지 로드 시 수행 */
ItsPage.Load = function () {
    /* 발주 목록 */
    ItsGrid.Create('grid1', {}, [
        column.create('발주일자', 'MTRODRDATE', { width: 90, align: 'center' }),
        column.create('발주번호', 'MTRODRKEY', { width: 100, align: 'center' }),
        column.create('발주순번', 'MTRODRSEQ', { width: 50, align: 'center', hidden: true }),
        column.create('발주상태', 'MTRODRSTT', { width: 80, align: 'center', columnType: enumColumnTypes.combo, gpcd: 'MM110' }),
        column.create('거래처코드', 'CUSTCD', { width: 100, align: 'center', hidden: true }),
        column.create('거래처명', 'CUSTNM', { width: 150, align: 'center' }),
        column.create('납기일자', 'EXPDATE', { width: 100, align: 'center' }),
        column.create('구매담당자', 'ODREMPID', { width: 80, align: 'center' }),
    ]);

    ItsGrid.Create('grid2', {}, [
        column.create('발주순번', 'MTRODRSEQ', { width: 50, align: 'center', hidden: true }),
        column.create('발주상태', 'MTRODRSTT', { width: 100, align: 'center', columnType: enumColumnTypes.combo, gpcd: 'MM110' }),
        column.create('품목유형', 'ITEMCG', { width: 100, align: 'center', columnType: enumColumnTypes.combo, gpcd: 'DM100' }),
        column.create('품목코드', 'ITEMCD', { width: 200, align: 'center' }),
        column.create('품명', 'ITEMNM', { width: 250, align: 'center' }),
        column.create('규격', 'ITEMSPEC', { width: 200, align: 'center' }),
        column.create('납기일자', 'EXPDATE', { width: 100, align: 'center' }),
        column.create('구매담당자', 'ODRDELEMPID', { width: 100, align: 'center', hidden: true }),
        column.create('발주수량', 'ODRQTY', { width: 80, columnType: enumColumnTypes.number }),
        column.create('구매단가', 'MTRODRPRICE', { width: 80, columnType: enumColumnTypes.number }),
        column.create('구매금액', 'MTRODRAMT', { width: 80, columnType: enumColumnTypes.number }),
        column.create('발주단가', 'MTRODRFPRICE', { width: 80, columnType: enumColumnTypes.number }),
        column.create('발주금액', 'MTRODRFAMT', { width: 80, columnType: enumColumnTypes.number })
    ]);

    ItsDateRange.SetInitValueFrom('date_DATE', ItsHelper.AddDay(-7, ItsHelper.GetYearMonthDay()));

    // 2025-06-27 법인 콤보박스 값을 60으로 고정
    ItsCombo.SetValue('sdiv1_combo_COMPANYCD', '60');
};

//-------------------------------------------------------------------------------------------------------------
/* 조회 */
ItsButton.EventSearch = function () {

    ItsGrid.Clear('grid2');
    var maria = new ItsMaria('MTR0001_R01', 'LIST_MTRODR');
    maria.AddPanel('sdiv1');

    maria.CallProc();
    if (maria.isError) {
        maria.ShowErrMsg();
        return;
    }

    ItsGrid.SetStore('grid1', maria.store);

    ItsMsg.Toast(ItsMsg.CommonMsg.SearchComplete(maria.store.Length()));

};

ItsGrid.Event('grid1').onSelect = function (rowIndex) {
    var maria = new ItsMaria('MTR0001_R01', 'LIST_MTRODRD');
    maria.AddPanel('sdiv1');
    maria.AddRecord('grid1', rowIndex);
    maria.CallProc();
    if (maria.isError) {
        maria.ShowErrMsg();
        return;
    }
    ItsGrid.SetStore('grid2', maria.store);
    ItsGrid.Get('grid2').autoSizeColumns();
}

ItsCombo.Event('sdiv1_combo_COMPANYCD').onChanged = function (value) {
    ItsCombo.SetRef01('sdiv1_combo_FACTORYCD', value);
    ItsCombo.SetValueByIndex('sdiv1_combo_FACTORYCD', 2);
}