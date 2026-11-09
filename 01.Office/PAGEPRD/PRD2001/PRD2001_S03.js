/// <reference path="../../Script/reference.js" />

/* 페이지 로드 */
ItsPage.Load = function () {
    // 월 생산실적 (작업장 + 공정 + 품목 1줄, 누적 줄은 프로시저가 만들고 BACKGROUND 로 색 표시)
    // 가동율(시간·성능·종합)은 계산식 미정이라 빈칸
    ItsGrid.Create('grid_MONTH', { isCheckBoxGrid: false, isSubTotalGrid: false }, [
        column.create('LINE', 'LINENM', { width: 80, align: 'center', allowMerging: true }),
        column.create('품목ID', 'ITEMID', { width: 70, align: 'center' }),
        column.create('품목코드', 'ITEMCD', { width: 120 }),
        column.create('품명', 'ITEMNM', { width: 250 }),
        column.create('제품', 'PRODNM', { width: 200 }),
        column.create('공정', 'PRCNM', { width: 110, align: 'center' }),
        column.band('누적 생산계획 실적 (연)', {}, [
            column.create('계획', 'Y_PLAN', { width: 85, columnType: enumColumnTypes.number, decimalPrecision: 0 }),
            column.create('실적', 'Y_RST', { width: 85, columnType: enumColumnTypes.number, decimalPrecision: 0 }),
            column.create('진척(%)', 'Y_RATE', { width: 65, columnType: enumColumnTypes.number, decimalPrecision: 1 }),
            column.create('시간가동률', 'Y_TIMEOEE', { width: 70, columnType: enumColumnTypes.number, decimalPrecision: 1 }),
            column.create('성능가동률', 'Y_PERFOEE', { width: 70, columnType: enumColumnTypes.number, decimalPrecision: 1 }),
            column.create('종합가동률', 'Y_OEE', { width: 70, columnType: enumColumnTypes.number, decimalPrecision: 1 }),
            column.create('불량(PPM)', 'Y_BADPPM', { width: 75, columnType: enumColumnTypes.number, decimalPrecision: 0 })
        ]),
        column.band('월간 생산계획 대비 실적', {}, [
            column.create('계획(주간)', 'M_PLAN_DAY', { width: 75, columnType: enumColumnTypes.number, decimalPrecision: 0 }),
            column.create('계획(야간)', 'M_PLAN_NIGHT', { width: 75, columnType: enumColumnTypes.number, decimalPrecision: 0 }),
            column.create('실적(주간)', 'M_RST_DAY', { width: 75, columnType: enumColumnTypes.number, decimalPrecision: 0 }),
            column.create('실적(야간)', 'M_RST_NIGHT', { width: 75, columnType: enumColumnTypes.number, decimalPrecision: 0 }),
            column.create('진척(%)', 'M_RATE', { width: 65, columnType: enumColumnTypes.number, decimalPrecision: 1 }),
            column.create('시간가동률', 'M_TIMEOEE', { width: 70, columnType: enumColumnTypes.number, decimalPrecision: 1 }),
            column.create('성능가동률', 'M_PERFOEE', { width: 70, columnType: enumColumnTypes.number, decimalPrecision: 1 }),
            column.create('종합가동률', 'M_OEE', { width: 70, columnType: enumColumnTypes.number, decimalPrecision: 1 }),
            column.create('월 불량률(PPM)', 'M_BADPPM', { width: 90, columnType: enumColumnTypes.number, decimalPrecision: 0 })
        ]),
        column.split()
    ]);
    // 밴드(제목줄 병합)와 LINE 셀 병합을 같이 쓰려고 wijmo 병합을 직접 All 로 둔다 (PRD2001_S02 와 같은 이유).
    // allowMerging: 'Cells' 는 제목줄 병합이 꺼져 밴드가 칸마다 찍히고, ItsGrid 의 'All' 은 데이터 칸 전용 병합으로 덮어쓴다
    ItsGrid.Get('grid_MONTH').allowMerging = wijmo.grid.AllowMerging.All;

    // 비가동 ISSUE: 작업장·공정별 그 달 비가동 항목별 분 + 작업지시 ISSUE
    ItsGrid.Create('grid_NON', { isCheckBoxGrid: false, isSubTotalGrid: true }, [
        column.create('대상라인', 'LINENM', { width: 70, align: 'center' }),
        column.create('공정', 'PRCNM', { width: 80, align: 'center' }),
        column.create('비가동(분)', 'NONMIN', { width: 75, columnType: enumColumnTypes.number, decimalPrecision: 0, groupType: enumGrouping.sum }),
        column.create('비가동 내역', 'NONTEXT', { width: 250 }),
        column.create('주요 ISSUE', 'ISSUE', { width: 250 }),
        column.split()
    ]);

    // 불량률 ISSUE: 작업장·공정별 그 달 불량 불량명별 EA
    ItsGrid.Create('grid_BAD', { isCheckBoxGrid: false, isSubTotalGrid: true }, [
        column.create('대상라인', 'LINENM', { width: 70, align: 'center' }),
        column.create('공정', 'PRCNM', { width: 80, align: 'center' }),
        column.create('불량(EA)', 'BADQTY', { width: 70, columnType: enumColumnTypes.number, decimalPrecision: 0, groupType: enumGrouping.sum }),
        column.create('불량 내역', 'BADTEXT', { width: 350 }),
        column.split()
    ]);
};

/* 조회 */
ItsButton.EventSearch = function () {
    var maria = new ItsMaria('PRD2001_S03', 'LIST');
    maria.AddPanel('sdiv1');
    maria.CallProc();
    if (maria.isError) {
        maria.ShowErrMsg();
        return;
    }

    var period = maria.store.data[0];
    ItsLabel.SetText('lbl_YEAR', '연 누적: ' + period.YEARTEXT);
    ItsLabel.SetText('lbl_MONTH', '월간: ' + period.MONTHTEXT);

    ItsGrid.SetStore('grid_MONTH', maria.storeExtend1);
    ItsGrid.SetStore('grid_NON', maria.storeExtend2);
    ItsGrid.SetStore('grid_BAD', maria.storeExtend3);
    ItsMsg.Toast(ItsMsg.CommonMsg.SearchComplete(maria.storeExtend1.Length()));
};
