/// <reference path="../../Script/reference.js" />

var tabstate = 0;

/* 페이지 로드 시 수행 */
ItsPage.Load = function () {
    
    /* 그리드 생성 */
    ItsGrid.Create('grid1', { isCheckBoxGrid: false, allowMerging: 'Cells' }, [
        column.create("공장", "FACTORYCD", { width: 120, align: 'center', columnType: enumColumnTypes.combo, gpcd: 'FACTORYCD', allowMerging: true }),
        column.create("직업장", "LINECD", { width: 121, align: 'center', columnType: enumColumnTypes.combo, gpcd: 'LINECD', allowMerging: true }),
        column.create("설비구분", "EQMTP", { width: 103, align: 'center', columnType: enumColumnTypes.combo, gpcd: 'FM100', allowMerging: true }),
        column.create("설비대분류", "EQMGROUP1", { width: 104, align: 'center', columnType: enumColumnTypes.combo, gpcd: 'FM113', allowMerging: true }),
        column.create("설비중분류", "EQMGROUP2", { width: 105, align: 'center', columnType: enumColumnTypes.combo, gpcd: 'FM114', allowMerging: true }),
        column.create("설비소분류", "EQMGROUP3", { width: 106, align: 'center', columnType: enumColumnTypes.combo, gpcd: 'FM115', allowMerging: true }),
        column.create("설비코드", "FANO", { width: 100, align: 'center' }),
        column.create("설비명", "EQMNM", { width: 101 }),
        column.create("설비상세명", "EQMNM_DETAIL", { width: 102 }),        
        column.create("설비등급구분", "EQMGRADE", { width: 107, align: 'center', columnType: enumColumnTypes.combo, gpcd: 'FM110' }),
        column.create("설비상태구분", "EQMSTT", { width: 108, align: 'center', columnType: enumColumnTypes.combo, gpcd: 'FM111' }),
        column.create("설치일자", "SETDATE", { width: 109, align: 'center' }),
        column.create("폐기일자", "SCRAPDATE", { width: 110, align: 'center' }),
        column.create("제작일자", "MKDATE", { width: 111, align: 'center' }),
        column.create("제작업체", "MKCUST", { width: 112 }),
        column.create("제작일련번호", "SERNO", { width: 113 }),
        column.create("구매국가코드", "NATCD", { width: 114, align: 'center' }),
        column.create("구매통화구분", "CURY_BC", { width: 115, align: 'center', columnType: enumColumnTypes.combo, gpcd: 'BC400' }),
        column.create("구매금액", "BUYFAMT", { width: 116 }),
        column.create("구매가격_원화", "BUYAMT", { width: 117 }),
        column.create("고정자산번호", "ASTNO", { width: 118, align: 'center' }),
        column.create("설비투자번호", "INVNO", { width: 119, align: 'center' }),
        column.create("생산정보연계", "PRODYN", { width: 122, align: 'center', columnType: enumColumnTypes.check }),
        column.create("담당부서", "DEPTP", { width: 123, align: 'center' }),
        column.create("담당사원", "EMPCD", { width: 124, align: 'center' }),
        column.create("소유구분 ", "OWN_DIV", { width: 125, align: 'center', columnType: enumColumnTypes.combo, gpcd: 'MD111' }),
        column.create("소유업체코드", "OWNCUST", { width: 126, align: 'center', columnType: enumColumnTypes.combo, gpcd: 'CUSTCD' }),
        column.create("용도", "USAGE", { width: 127, align: 'center' }),
        column.create("전력용량(KW)", "EPOWER", { width: 128, align: 'center' }),
        column.create("전력비배부대상", "DIVYN", { width: 129, align: 'center', columnType: enumColumnTypes.check }),
        column.create("설비평가대상", "EVALYN", { width: 130, align: 'center', columnType: enumColumnTypes.check }),
        column.create("사용여부", "USEYN", { width: 50, align: 'center', columnType: enumColumnTypes.check }),
        column.create("비고", "REMARK", { width: 131 }),
        column.create("점검시작일", "CHKSDT", { width: 132, align: 'center' }),
        column.create("점검종료일", "CHKEDT", { width: 133, align: 'center' })
    ]);
};

/* 조회 */
ItsButton.EventSearch = function () {

    var maria = new ItsMaria('MST1002_R06', 'SEL_EQM');
    maria.AddPanel('sdiv1');
    maria.CallProc();
    if (maria.isError) {
        maria.ShowErrMsg();
        return;
    }

    ItsGrid.SetStore('grid1', maria.store.YnToBool('USEYN')); 

    ItsMsg.Toast(maria.store.Length() + '건이 조회되었습니다.'); 

    ItsGrid.Get('grid1').autoSizeColumns();
};










