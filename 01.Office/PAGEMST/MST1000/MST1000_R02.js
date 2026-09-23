/// <reference path="../../Script/reference.js" />

/* 페이지 로드 시 수행 */
ItsPage.Load = function () {

    /* 그리드 생성 */
    ItsGrid.Create('grid1', { isCheckBoxGrid: false }, [
        column.create("사업장코드", "BDVCD", { width: 100, align: 'center' }),
        column.create("사업장명", "BDVNM", { width: 100}),
        column.create("사업장명_약칭", "BDVBNM", { width: 100}),
        column.create("대표자", "PRESIDENT", { width: 100, align: 'center' }),
        column.create("사업장 영문명", "BDVNMENG", { width: 100}),
        column.create("사업자등록번호", "BDVREGNO", { width: 100, align: 'center' }),
        column.create("사업장명_인쇄용", "BDVBNM_PRT", { width: 100}),
        column.create("업종", "INDKIND", { width: 100}),
        column.create("업태", "INDTYPE", { width: 100}),
        column.create("업종_인쇄용", "INDKIND_PRT", { width: 100}),
        column.create("업테_인쇄용", "INDTYPE_PRT", { width: 100}),
        column.create("사업소면적_과제", "TAX_AREA", { width: 100, align: 'center' }),
        column.create("사업소면적_비과세", "NOTAX_AREA", { width: 100, align: 'center' }),
        column.create("소재국가", "NATCD", { width: 100, align: 'center' }),
        column.create("사업군(채권단위)", "BIZ_BC", { width: 100, align: 'center' }),
        column.create("기준통화", "CURY_BC", { width: 100, align: 'center' }),
        column.create("개업일자", "FRDT", { width: 100, align: 'center' }),
        column.create("폐업일자", "TODT", { width: 100, align: 'center' }),
        column.create("영업개시일", "OPENDT", { width: 100, align: 'center' }),
        column.create("우편번호", "ZIPCD", { width: 100, align: 'center' }),
        column.create("주소", "ADDR", { width: 100}),
        column.create("주소_인쇄용", "ADDR_PRT", { width: 100}),
        column.create("대표자전화", "REPRETEL", { width: 100, align: 'center' }),
        column.create("팩스번호", "FAXNO", { width: 100, align: 'center' }),
        column.create("Email", "EMAIL", { width: 100, align: 'center' }),
        column.create("홈페이지 URL", "HOMEURL", { width: 100}),
        column.create("대표자전화", "REPRETEL2", { width: 100}),
        column.create("HOMETAX_ID", "HOMETAX_ID", { width: 100}),
        column.create("팩스번호(해외)", "FAX2", { width: 100}),
        column.create("관활세무서코드", "TAX_OFCCD", { width: 100, align: 'center' }),
        column.create("지방세납부관공서", "LOCAL_OFCCD", { width: 100, align: 'center' }),
        column.create("세무서납세코드", "TAX_PAYCD", { width: 100, align: 'center' }),
        column.create("부가세마감일", "VAT_CLOSEDT", { width: 100, align: 'center' }),
        column.create("본사여부", "HEADYN", { width: 100, columnType: enumColumnTypes.check}),
        column.create("은행코드", "BANKCD", { width: 100, align: 'center' }),
        column.create("예금주", "ACCTNM", { width: 100, align: 'center' }),
        column.create("계좌번호", "ACCTNO", { width: 100, align: 'center' }),
        column.create("외국인단일세율적용여부", "FRNYN", { width: 100, columnType: enumColumnTypes.check}),
        column.create("출근감안시간-분", "CON_IN_TM", { width: 100, align: 'center' }),
        column.create("퇴근감안시간-분", "CON_OUT_TM", { width: 100, align: 'center' }),
        column.create("단위시간-분", "UNIT_TM", { width: 100, align: 'center' }),
        column.create("부가세환급은행코드", "TAX_BANK", { width: 100, align: 'center' }),
        column.create("부가세환급계좌", "TAX_ACCT", { width: 100, align: 'center' }),
        column.create("부가세환급지점", "TAX_BANK_LOC", { width: 100, align: 'center' }),
        column.create("원천징수사업장", "TAX_BS", { width: 100, align: 'center', columnType: enumColumnTypes.combo, gpcd: 'COMPANYCD' }),
        column.create("귀속사업장", "APP_BS", { width: 100, align: 'center', columnType: enumColumnTypes.combo, gpcd: 'COMPANYCD' }),
        column.create("법인코드", "COMCD", { width: 100, align: 'center', columnType: enumColumnTypes.combo, gpcd: 'COMPANYCD' }),
        column.create("법인직인", "IMG", { width: 100, align: 'center' }),
        column.create("출력순번", "DISPSEQ", { width: 100, align: 'center' }),
        column.create("운영여부", "USEYN", { width: 100, columnType: enumColumnTypes.check})
    ]);

    ItsButton.EventSearch();
};

/* 조회 */
ItsButton.EventSearch = function () {
    var maria = new ItsMaria('MST1000_R02', 'SEL_BDV');
    maria.AddPanel('sdiv1');
    maria.CallProc();
    if (maria.isError) {
        maria.ShowErrMsg();
        return;
    }

    ItsGrid.SetStore('grid1', maria.store.YnToBool('HEADYN').YnToBool('FRNYN').YnToBool('USEYN'));
    ItsMsg.Toast(maria.store.Length() + '건이 조회되었습니다.');

    ItsGrid.Get('grid1').autoSizeColumns();
};






