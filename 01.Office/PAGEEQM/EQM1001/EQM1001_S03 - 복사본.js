/// <reference path="../../Script/reference.js" />
/* 페이지 로드 시 수행 */
ItsPage.Load = function () {

    /* 그리드 생성 */
    ItsGrid.Create('grid1', { isCheckBoxGrid: false, isSubTotalGrid: true }, [
        column.band('비가동 이력', {}, [
            column.create("비가동키", "PRDNONKEY", { width: 100, hidden: true }),
            column.create('비가동일자', 'NONDATE', { width: 90, align: 'center' }),
            column.create('설비코드', 'EQMCD', { width: 100, align: 'center' }),
            column.create('설비명', 'EQMNM', { width: 100, align: 'center' }),
            column.create("비가동유형", "NONCD", { width: 150, columnType: enumColumnTypes.combo, gpcd: 'NONCD', align: 'center' }),
            column.create("시작시간", "NONSTIME", { width: 130, align: 'center' }),
            column.create("종료시간", "NONETIME", { width: 130, align: 'center' }),
            column.create('비가동시간(분)', 'NONTIME', { width: 100, columnType: enumColumnTypes.number, decimalPrecision: 0, groupType: enumGrouping.sum }),
            column.create('문제점', 'PROBLEM', { width: 150 }),
            column.create('조치사항', 'SOLUTION', { width: 150 }),
            column.create('등록자', 'EMPNM', { width: 100, align: 'center' }),
        ]),

        column.band('작업 정보', {}, [
            column.create("지시일자", "INSDATE", { width: 100, columnType: enumColumnTypes.date, align: 'center' }),
            column.create("지시번호", "PRDINSKEY", { width: 100, align: 'center' }),
            column.create("지시유형", "INSTP", { width: 70, align: 'center', columnType: enumColumnTypes.combo, gpcd: 'INSTP' }),
            column.create("지시상태", "WORKSTT", { width: 70, align: 'center', columnType: enumColumnTypes.combo, gpcd: 'WORKSTT' }),
            column.create('거래처코드', 'CUSTCD', { width: 100 }),
            column.create('거래처', 'CUSTNM', { width: 150, backColor: enumColor.greenLight2, align: 'center' }),
            column.create('품목유형', 'ITEMTP', { width: 100, columnType: enumColumnTypes.combo, gpcd: 'ITEMTP', align: 'center' }),
            column.create('차종', 'CARMODEL', { width: 100, columnType: enumColumnTypes.combo, gpcd: 'CARMODEL', align: 'center' }),
            column.create('품목코드', 'ITEMCD', { width: 100 }),
            column.create('품명', 'ITEMNM', { width: 150 }),
            column.create("지시수량", "INSQTY", { width: 100, columnType: enumColumnTypes.number, decimalPrecision: 0, groupType: enumGrouping.sum }),
        ]),

        column.split()
    ]);
};

/* 조회 */
ItsButton.EventSearch = function () {
    var maria = new ItsMaria('EQM1001_S03', 'LIST_RSTNON');

    maria.AddPanel('sdiv1');

    maria.CallProc();

    if (maria.isError) {
        maria.ShowErrMsg();
        return;
    }

    ItsGrid.SetStore('grid1', maria.store);

    ItsGrid.Get('grid1').autoSizeColumns();

    ItsMsg.Toast(maria.store.Length() + '건이 조회되었습니다.');
};
