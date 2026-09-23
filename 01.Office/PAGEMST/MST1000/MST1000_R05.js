/// <reference path="../../Script/reference.js" />

/* 페이지 로드 시 수행 */
ItsPage.Load = function () {

    /* 그리드 생성 */
    ItsGrid.Create('grid1', { isCheckBoxGrid: false }, [
        column.create("거래처코드", "CUSTCD", { width: 100}),
        column.create("거래처명", "CUSTNM", { width: 100}),
        //column.create("거래처영문명", "CUSTNMEN", { width: 100, align: 'center' }),
        column.create("법인", "COMCD", { width: 100, align: 'center', columnType: enumColumnTypes.combo, gpcd: 'COMPANYCD' }),
        //column.create("대분류", "GPCD1", { width: 100, align: 'center' }),
        //column.create("중분류", "GPCD2", { width: 100, align: 'center' }),
        //column.create("소분류", "GPCD3", { width: 100, align: 'center' }),
        column.create("거래처구분", "CUSTTP", { width: 100, align: 'center', columnType: enumColumnTypes.combo, gpcd: 'BC500' }),
        column.create("거래처형태", "CUST_KD", { width: 100, align: 'center', columnType: enumColumnTypes.combo, gpcd: 'BC510' }),
        column.create("거래처명_인쇄용", "CUSTNM_PRT", { width: 100 }),
        //column.create("기업구분", "COM_KD", { width: 100, align: 'center' }),
        //column.create("경영구분", "MNG_KD", { width: 100, align: 'center' }),
        //column.create("기업규모", "SIZE_BC", { width: 100, align: 'center' }),
        //column.create("중요도구분", "LV_BC", { width: 100, align: 'center' }),
        //column.create("신용등급구분", "CREDIT_BC", { width: 100, align: 'center' }),
        //column.create("거래시작일", "TRADESDT", { width: 100, align: 'center' }),
        //column.create("거래종료일", "TRADEEDT", { width: 100, align: 'center' }),
        column.create("매출여부", "SALYN", { width: 100, align: 'center', columnType: enumColumnTypes.check }),
        column.create("매입여부", "PURYN", { width: 100, align: 'center', columnType: enumColumnTypes.check }),
        column.create("매출지역구분", "DE_BC", { width: 100, align: 'center', columnType: enumColumnTypes.combo, gpcd: 'SD300' }),
        column.create("매입지역구분", "DI_BC", { width: 100, align: 'center', columnType: enumColumnTypes.combo, gpcd: 'MM060' }),
        column.create("매출부가세구분", "TAX_BC", { width: 100, align: 'center', columnType: enumColumnTypes.combo, gpcd: 'FA630' }),
        //column.create("전자계산서발행구분", "ISS_BC", { width: 100, align: 'center' }),
        column.create("매출정산거래처코드", "CUSTSALCD", { width: 100, align: 'center', columnType: enumColumnTypes.combo, gpcd: 'CUSTCD' }),
        column.create("매입정산거래처코드", "CUSTPURCD", { width: 100, align: 'center', columnType: enumColumnTypes.combo, gpcd: 'CUSTCD' }),
        //column.create("매입결재조건", "PSET_BC", { width: 100, align: 'center' }),
        //column.create("정기지급일", "DAY_BC", { width: 100, align: 'center' }),
        //column.create("결재지급구분", "PAY_BC", { width: 100, align: 'center' }),
        column.create("국가코드", "NATCD", { width: 100, align: 'center' }),
        column.create("결재통화코드", "CURY_BC", { width: 100, align: 'center', columnType: enumColumnTypes.combo, gpcd: 'BC400'}),
        //column.create("통화코드", "CURY_BC2", { width: 100, align: 'center' }),
        column.create("우편번호", "ZIP_CD", { width: 100}),
        column.create("주소1", "CUSTADDR1", { width: 100}),
        column.create("주소2", "CUSTADDR2", { width: 100}),
        column.create("주소_인쇄용", "ADDR_PRT", { width: 100}),
        column.create("대표자전화", "REPRETEL", { width: 100, align: 'center'}),
        column.create("팩스번호", "CUSTFAX", { width: 100}),
        //column.create("홈페이지 URL", "HOMEURL", { width: 100, align: 'center' }),
        column.create("전자계산서담당", "ESERO", { width: 100, align: 'center' }),
        column.create("E-MAIL", "EMAIL", { width: 100}),
        //column.create("계산서담당전화", "ETEL", { width: 100, align: 'center' }),
        //column.create("거래처본사/본점", "CUSTMAIN", { width: 100, align: 'center' }),
        column.create("사업자등록번호", "REGBUSSNUM", { width: 100, align: 'center' }),
        column.create("업태_인쇄용", "BIZTYPE_PRT", { width: 100}),
        column.create("업종_인쇄용", "BIZKIND_PRT", { width: 100}),
        column.create("대표자", "PRESIDENT", { width: 100, align: 'center' }),
        //column.create("대표자주민번호", "REPREREGNO", { width: 100, align: 'center' }),
        column.create("매출액", "SALES_AMT", { width: 100, align: 'center' }),
        column.create("종업원수", "EMP_CNT", { width: 100, align: 'center' }),
        //column.create("거래품목", "TRADEITEM", { width: 100, align: 'center' }),
        //column.create("세무서코드", "TAXNO", { width: 100, align: 'center' }),
        column.create("계좌개설", "ACCTYN", { width: 100, align: 'center', columnType: enumColumnTypes.check }),
        column.create("은행코드", "BANKCD", { width: 100, align: 'center' }),
        column.create("예금주", "ACCTNM", { width: 100, align: 'center' }),
        column.create("주거래계좌번호", "ACCTNO", { width: 100, align: 'center' }),
        //column.create("법인등록번호", "INCREGNO", { width: 100, align: 'center' }),
        column.create("거래여부", "USEYN", { width: 100, align: 'center', columnType: enumColumnTypes.check }),
        column.create("거래명세서유형", "RPT_BC", { width: 100, align: 'center' }),
        //column.create("검사구분", "INSP_BC", { width: 100, align: 'center' }),
        //column.create("환율적용기준", "EXCH_BC", { width: 100, align: 'center' }),
        //column.create("담당자사번", "CHARGENO", { width: 100, align: 'center' }),
    ]);
};

/* 조회 */
ItsButton.EventSearch = function () {
    var maria = new ItsMaria('MST1000_R05', 'SEL_CUST');
    maria.AddPanel('sdiv1');
    maria.CallProc();
    if (maria.isError) {
        maria.ShowErrMsg();
        return;
    }

    ItsGrid.SetStore('grid1', maria.store.YnToBool('SALYN').YnToBool('PURYN').YnToBool('ACCTYN').YnToBool('USEYN'));
    ItsMsg.Toast(maria.store.Length() + '건이 조회되었습니다.');

    ItsGrid.Get('grid1').autoSizeColumns();
};







