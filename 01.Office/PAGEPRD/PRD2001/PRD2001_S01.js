/// <reference path="../../Script/reference.js" />

/* 페이지 로드 */
ItsPage.Load = function () {
    // 작업 목록 (사내공정 작업지시의 작업 1건 = 1줄)
    ItsGrid.Create('grid_PRDWORK', { isCheckBoxGrid: false, isSubTotalGrid: true }, [
        column.create('생산일자', 'WORKDATE', { width: 90, align: 'center' }),
        column.create('주야구분', 'DNTPNM', { width: 70, align: 'center' }),
        column.create('작업시작', 'WORKSTIME', { width: 130, align: 'center' }),
        column.create('작업종료', 'WORKETIME', { width: 130, align: 'center' }),
        column.create('작업자', 'EMPNM', { width: 150, align: 'center' }),
        //column.create('작업장', 'LINENM', { width: 100, align: 'center' }),
        //column.create('공정', 'PRCNM', { width: 100, align: 'center' }),
        column.create('라인', 'EQMNM', { width: 120, align: 'center' }),
        column.create('품목코드', 'ITEMCD', { width: 120 }),
        column.create('품명', 'ITEMNM', { width: 200 }),
        column.create('규격', 'ITEMSPEC', { width: 120 }),        
        column.create('계획수량', 'INSQTY', { width: 80, columnType: enumColumnTypes.number, decimalPrecision: 0, groupType: enumGrouping.sum }),
        column.create('생산수량', 'PRODQTY', { width: 80, columnType: enumColumnTypes.number, decimalPrecision: 0, groupType: enumGrouping.sum }),
        column.create('양품수량', 'GOODQTY', { width: 80, columnType: enumColumnTypes.number, decimalPrecision: 0, groupType: enumGrouping.sum }),
        column.create('불량수량', 'BADQTY', { width: 80, columnType: enumColumnTypes.number, decimalPrecision: 0, groupType: enumGrouping.sum }),
        column.create('비가동(분)', 'NONMIN', { width: 80, columnType: enumColumnTypes.number, decimalPrecision: 0, groupType: enumGrouping.sum }),        
        column.create('ISSUE사항', 'ISSUE', { width: 150 }),
        //column.create('작업지시번호', 'PRDINSKEY', { width: 130, align: 'center' }),
        //column.create('작업키', 'PRDWORKKEY', { width: 130, align: 'center' }),
        column.split()
    ]);

    // 생산실적 (투입로트 1개 = 1줄, 가공완료 로트·수량은 같은 실적끼리 셀 병합)
    // 같은 실적의 값이 줄마다 반복되므로 소계 합계는 쓰지 않음
    ItsGrid.Create('grid_PRDRST', { isCheckBoxGrid: false, isSubTotalGrid: false, allowMerging: 'Cells' }, [
        column.create('투입LotNo', 'USELOTKEY', { width: 140, align: 'center' }),
        column.create('가공완료 LotNo', 'LOTKEY', { width: 140, align: 'center', allowMerging: true }),
        column.create('양품수량', 'GOODQTY', { width: 80, columnType: enumColumnTypes.number, decimalPrecision: 0, allowMerging: true }),
        column.create('불량수량', 'BADQTY', { width: 80, columnType: enumColumnTypes.number, decimalPrecision: 0, allowMerging: true }),
        column.create('합계', 'PRODQTY', { width: 80, columnType: enumColumnTypes.number, decimalPrecision: 0, allowMerging: true }),
        column.split()
    ]);

    // 비가동이력
    ItsGrid.Create('grid_PRDRSTNON', { isCheckBoxGrid: false, isSubTotalGrid: true }, [
        column.create('비가동유형', 'NONTPNM', { width: 100, align: 'center' }),
        column.create('비가동', 'NONNM', { width: 130 }),
        column.create('시작시간', 'NONSTIME', { width: 130, align: 'center' }),
        column.create('종료시간', 'NONETIME', { width: 130, align: 'center' }),
        column.create('시간(분)', 'NONMIN', { width: 70, columnType: enumColumnTypes.number, decimalPrecision: 0, groupType: enumGrouping.sum }),
        column.create('자동', 'AUTOYN', { width: 50, align: 'center' }),
        column.create('문제점', 'PROBLEM', { width: 180 }),
        column.create('조치사항', 'SOLUTION', { width: 180 }),
        column.create('비고', 'REMARK', { width: 150 }),
        column.split()
    ]);

    // 불량상세
    ItsGrid.Create('grid_PRDRSTBAD', { isCheckBoxGrid: false, isSubTotalGrid: true }, [
        column.create('대분류', 'BADTP1NM', { width: 100, align: 'center' }),
        column.create('중분류', 'BADTP2NM', { width: 100, align: 'center' }),
        column.create('불량', 'BADNM', { width: 150 }),
        column.create('불량상세', 'BADDETAIL', { width: 150 }),
        column.create('불량수량', 'BADQTY', { width: 80, columnType: enumColumnTypes.number, decimalPrecision: 0, groupType: enumGrouping.sum }),
        column.create('비고', 'REMARK', { width: 150 }),
        column.split()
    ]);

    ItsDateRange.SetInitValueFrom('dateR_WORKDATE', ItsHelper.GetYearMonth() + '-01');
};

/* 작업장 변경: 공정·라인 목록을 작업장 기준으로 */
ItsCombo.Event('cmb_LINECD').onChanged = function (value) {
    ItsCombo.SetRef01('cmb_PRCCD', value);
    ItsCombo.SetValueByIndex('cmb_PRCCD', 0);
    ItsCombo.SetRef01('cmb_EQMCD', value);
    ItsCombo.SetRef02('cmb_EQMCD', '');
    ItsCombo.SetValueByIndex('cmb_EQMCD', 0);
};

/* 공정 변경: 라인 목록을 작업장·공정 기준으로 */
ItsCombo.Event('cmb_PRCCD').onChanged = function (value) {
    ItsCombo.SetRef02('cmb_EQMCD', value);
    ItsCombo.SetValueByIndex('cmb_EQMCD', 0);
};

/* 조회 */
ItsButton.EventSearch = function () {
    ItsGrid.Clear('grid_PRDRST');
    ItsGrid.Clear('grid_PRDRSTNON');
    ItsGrid.Clear('grid_PRDRSTBAD');

    var maria = new ItsMaria('PRD2001_S01', 'LIST_PRDWORK');
    maria.AddPanel('sdiv1');
    maria.CallProc();
    if (maria.isError) {
        maria.ShowErrMsg();
        return;
    }

    ItsGrid.SetStore('grid_PRDWORK', maria.store);
    ItsMsg.Toast(ItsMsg.CommonMsg.SearchComplete(maria.store.Length()));
};

/* 작업 선택: 그 작업의 생산실적·비가동·불량 조회 */
ItsGrid.Event('grid_PRDWORK').onSelect = function (rowIndex) {
    var maria = new ItsMaria('PRD2001_S01', 'LIST_DETAIL');
    maria.AddParam('PRDWORKKEY', ItsGrid.GetValue('grid_PRDWORK', rowIndex, 'PRDWORKKEY'));
    maria.CallProc();
    if (maria.isError) {
        maria.ShowErrMsg();
        return;
    }

    ItsGrid.SetStore('grid_PRDRST', maria.store);
    ItsGrid.SetStore('grid_PRDRSTNON', maria.storeExtend1);
    ItsGrid.SetStore('grid_PRDRSTBAD', maria.storeExtend2);
};

/* [생산일보 출력] → 선택 작업의 생산일·라인·품목 기준 생산일보 (04.Report\PAGEPRD\PRD2001 S01) */
ItsButton.Event('btn_PRINT_DAILY').onClick = function () {
    var rowIndex = ItsGrid.GetCurrentIndex('grid_PRDWORK');
    var prdWorkKey = rowIndex < 0 ? '' : ItsGrid.GetValue('grid_PRDWORK', rowIndex, 'PRDWORKKEY');
    if (!prdWorkKey) {
        ItsMsg.Alert('출력할 작업을 선택하십시오.');
        return;
    }

    var rpt = new ItsXtraRpt('PRD2001_S01');
    rpt.AddParam('PRDWORKKEY', prdWorkKey);
    rpt.CallPop();
    if (rpt.isError) {
        ItsMsg.Alert(rpt.errMessage);
    }
};
