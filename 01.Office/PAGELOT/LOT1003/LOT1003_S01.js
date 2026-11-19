/// <reference path="../../Script/reference.js" />

/* 페이지 로드 시 수행 */
ItsPage.Load = function () {

    ItsGrid.Create('grid1', {}, [
        column.band('실사/조정 이력정보', {}, [
            column.create('발생일자', 'INOUTDATE', { width: 100, align: 'center' }),
            column.create("행위구분", "ACTION", { width: 100, align: 'center' }),
            column.create("입출고구분", "INOUTTP", { width: 100, align: 'center' }),
            column.create('창고코드', 'WARECD', { width: 100, hidden: true }),
            column.create('창고명', 'WARENM', { width: 100, align: 'center' }),
            column.create('로트번호', 'LOTKEY', { width: 110, align: 'center' }),
            column.create('입출고수량', 'INOUTQTY', { width: 100, columnType: enumColumnTypes.number, decimalPrecision: 0 }),
            column.create("관리자", "EMPNM", { width: 100, align: 'center' }),
        ]),

        column.band('품목정보', {}, [
            column.create("품목유형", "ITEMCG", { width: 90, columnType: enumColumnTypes.combo, gpcd: 'DM100', align: 'center' }),
            column.create('품목코드', 'ITEMCD', { width: 120 }),
            column.create('품명', 'ITEMNM', { width: 250 }),
        ]),
        column.split()
    ]);
    ItsDateRange.SetInitValueFrom('dr_DATE', ItsHelper.GetYearMonth() + '-01');
    ItsCombo.SetValue('cmb_FACTORYCD', '07');   // 공장 기본값 (onChanged 로 품목 find 법인·공장도 들어감)
};

/* 공장이 정해지면 품목 find 에 법인(REF01)·공장(REF03) 넣기. 법인코드는 공장 콤보 목록 줄의 REF01(DC_COMBO FACTORYCD) */
ItsCombo.Event('cmb_FACTORYCD').onChanged = function (value) {
    var companycd = $('#cmb_FACTORYCD').siblings('ul').children('li').filter('[data-value="' + value + '"]').attr('data-ref01');
    if (companycd == undefined || companycd == 'undefined') companycd = '';
    ItsFind.SetRef01('find_ITEMID', companycd);
    ItsFind.SetRef03('find_ITEMID', value);
};

/* 조회 */
ItsButton.EventSearch = function () {
    var maria = new ItsMaria('LOT1003_S01', 'LIST_COMLOT_INOUT');

    maria.AddPanel('sdiv1');

    maria.CallProc();

    if (maria.isError) {
        maria.ShowErrMsg();
        return;
    }

    ItsGrid.SetStore('grid1', maria.store);

    ItsGrid.Get('grid1').autoSizeColumns();
};
