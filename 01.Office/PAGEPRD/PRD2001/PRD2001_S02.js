/// <reference path="../../Script/reference.js" />

/* 페이지 로드 */
ItsPage.Load = function () {
    // 주간 생산실적 (라인 × 품목, 공정·작업장 합계와 누적은 프로시저가 만들고 BACKGROUND 로 색 표시)
    // 가동율(시간·성능·종합)은 계산식 미정이라 빈칸
    ItsGrid.Create('grid_WEEK', { isCheckBoxGrid: false, isSubTotalGrid: false }, [
        column.create('구분', 'LINENM', { width: 80, align: 'center', allowMerging: true }),
        //column.create('품목유형', 'ITEMCGNM', { width: 80, align: 'center' }),
        column.create('품목ID', 'ITEMID', { width: 70, align: 'center' }),
        column.create('품목코드', 'ITEMCD', { width: 120, }),
        column.create('품명', 'ITEMNM', { width: 250 }),
        column.create('제품품명', 'PRODNM', { width: 205}),
        column.create('공정', 'PRCNM', { width: 110, align: 'center', allowMerging: true }),
        column.create('라인', 'EQMNM', { width: 90, align: 'center', allowMerging: true }),
        column.band('주간 생산계획 대비 실적', {}, [
            column.create('계획(주간)', 'W_PLAN_DAY', { width: 75, columnType: enumColumnTypes.number, decimalPrecision: 0 }),
            column.create('계획(야간)', 'W_PLAN_NIGHT', { width: 75, columnType: enumColumnTypes.number, decimalPrecision: 0 }),
            column.create('실적(주간)', 'W_RST_DAY', { width: 75, columnType: enumColumnTypes.number, decimalPrecision: 0 }),
            column.create('실적(야간)', 'W_RST_NIGHT', { width: 75, columnType: enumColumnTypes.number, decimalPrecision: 0 }),
            column.create('진척(%)', 'W_RATE', { width: 65, columnType: enumColumnTypes.number, decimalPrecision: 1 }),
            column.create('시간가동율', 'W_TIMEOEE', { width: 70, columnType: enumColumnTypes.number, decimalPrecision: 1 }),
            column.create('성능가동율', 'W_PERFOEE', { width: 70, columnType: enumColumnTypes.number, decimalPrecision: 1 }),
            column.create('종합가동율', 'W_OEE', { width: 70, columnType: enumColumnTypes.number, decimalPrecision: 1 }),
            column.create('불량률(PPM)', 'W_BADPPM', { width: 80, columnType: enumColumnTypes.number, decimalPrecision: 0 })
        ]),
        column.band('누적 생산계획 대비 실적 (월)', {}, [
            column.create('계획', 'M_PLAN', { width: 80, columnType: enumColumnTypes.number, decimalPrecision: 0 }),
            column.create('실적', 'M_RST', { width: 80, columnType: enumColumnTypes.number, decimalPrecision: 0 }),
            column.create('진척(%)', 'M_RATE', { width: 65, columnType: enumColumnTypes.number, decimalPrecision: 1 }),
            column.create('시간가동율', 'M_TIMEOEE', { width: 70, columnType: enumColumnTypes.number, decimalPrecision: 1 }),
            column.create('성능가동율', 'M_PERFOEE', { width: 70, columnType: enumColumnTypes.number, decimalPrecision: 1 }),
            column.create('종합가동율', 'M_OEE', { width: 70, columnType: enumColumnTypes.number, decimalPrecision: 1 })
        ]),
        column.create('월 불량률(PPM)', 'M_BADPPM', { width: 90, columnType: enumColumnTypes.number, decimalPrecision: 0 }),
        column.split()
    ]);
    // 밴드(제목줄 병합)와 구분·품명 셀 병합을 같이 쓰려고 wijmo 병합을 직접 All 로 둔다.
    // allowMerging: 'Cells' 는 제목줄 병합이 꺼져 밴드가 칸마다 찍히고,
    // ItsGrid 의 allowMerging: 'All' 은 데이터 칸 전용 병합으로 덮어써서 역시 제목줄이 안 합쳐진다 (ItsGrid.js getMergedRange)
    ItsGrid.Get('grid_WEEK').allowMerging = wijmo.grid.AllowMerging.All;

    // 가동률 ISSUE: 라인별 주간 비가동 항목별 분 + 작업지시 ISSUE
    ItsGrid.Create('grid_NON', { isCheckBoxGrid: false, isSubTotalGrid: true }, [
        column.create('대상라인', 'LINENM', { width: 70, align: 'center' }),
        column.create('공정', 'PRCNM', { width: 70, align: 'center' }),
        column.create('라인', 'EQMNM', { width: 80, align: 'center' }),
        column.create('비가동(분)', 'NONMIN', { width: 75, columnType: enumColumnTypes.number, decimalPrecision: 0, groupType: enumGrouping.sum }),
        column.create('비가동 내역', 'NONTEXT', { width: 250 }),
        column.create('주요 ISSUE', 'ISSUE', { width: 250 }),
        column.split()
    ]);

    // 불량률 ISSUE: 라인별 주간 불량 불량명별 EA
    ItsGrid.Create('grid_BAD', { isCheckBoxGrid: false, isSubTotalGrid: true }, [
        column.create('대상라인', 'LINENM', { width: 70, align: 'center' }),
        column.create('공정', 'PRCNM', { width: 70, align: 'center' }),
        column.create('라인', 'EQMNM', { width: 80, align: 'center' }),
        column.create('불량(EA)', 'BADQTY', { width: 70, columnType: enumColumnTypes.number, decimalPrecision: 0, groupType: enumGrouping.sum }),
        column.create('불량 내역', 'BADTEXT', { width: 350 }),
        column.split()
    ]);

};

/* 조회 */
ItsButton.EventSearch = function () {
    var maria = new ItsMaria('PRD2001_S02', 'LIST');
    maria.AddPanel('sdiv1');
    maria.CallProc();
    if (maria.isError) {
        maria.ShowErrMsg();
        return;
    }

    var period = maria.store.data[0];
    ItsLabel.SetText('lbl_WEEK', '주간: ' + period.WEEKTEXT);
    ItsLabel.SetText('lbl_MONTH', '월 누적: ' + period.MONTHTEXT);

    ItsGrid.SetStore('grid_WEEK', maria.storeExtend1);
    ItsGrid.SetStore('grid_NON', maria.storeExtend2);
    ItsGrid.SetStore('grid_BAD', maria.storeExtend3);
    ItsMsg.Toast(ItsMsg.CommonMsg.SearchComplete(maria.storeExtend1.Length()));
};
