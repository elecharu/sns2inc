/* TQM2001_S01: 품질관리 ▶ 부적합관리 ▷ 부적합 판정조회 */
/* 판정일자 기준으로 부적합 판정이력과 후처리 여부를 조회한다.
   후처리 후 재고가 불량창고에서 다른 창고로 옮겨지면 판정등록(TQM2001_R01)에서는 안 보이므로 여기서 본다. */

/// <reference path="../../Script/reference.js" />

/* 페이지 로드 시 수행 */
ItsPage.Load = function () {

    ItsGrid.Create('grid1', { isCheckBoxGrid: false }, [
        column.create('판정일자', 'JUDGEDATE', { width: 90, align: 'center' }),
        column.create('판정유형', 'JUDGETP', { width: 75, align: 'center', columnType: enumColumnTypes.combo, gpcd: 'JUDGETP' }),
        column.create('불량구분', 'JUDGEBADTP', { width: 75, align: 'center', columnType: enumColumnTypes.combo, gpcd: 'JUDGEBADTP' }),
        column.create('불량명', 'BADNM', { width: 120 }),
        column.create('로트번호', 'LOTKEY', { width: 130, align: 'center' }),
        column.create('품목유형', 'ITEMCG', { width: 80, align: 'center', columnType: enumColumnTypes.combo, gpcd: 'DM100' }),
        column.create('품목코드', 'ITEMCD', { width: 90, align: 'center' }),
        column.create('품명', 'ITEMNM', { width: 150 }),
        column.create('규격', 'ITEMSPEC', { width: 90 }),
        column.create('판정창고', 'WARENM', { width: 100, align: 'center' }),
        column.create('판정수량', 'JUDGEQTY', { width: 70, columnType: enumColumnTypes.number, decimalPrecision: 0 }),
        column.create('판정자', 'EMPNM', { width: 70, align: 'center' }),
        column.create('비고', 'REMARK', { width: 150 }),
        column.create('후처리', 'PROCYN', { width: 55, columnType: enumColumnTypes.check }),
        column.create('후처리일시', 'PROCTIME', { width: 120, align: 'center' }),
        column.create('후처리화면', 'PROCPRGNM', { width: 130 }),
        column.create('판정키', 'JUDGEKEY', { width: 80, hidden: true }),
        column.split()
    ]);

    ItsDateRange.SetInitValueFrom('dr_JUDGEDATE', ItsHelper.GetYearMonth() + '-01');
};

/* 조회 */
ItsButton.EventSearch = function () {
    var maria = new ItsMaria('TQM2001_S01', 'LIST');
    maria.AddPanel('sdiv1');
    maria.CallProc();
    if (maria.isError) {
        maria.ShowErrMsg();
        return;
    }
    ItsGrid.SetStore('grid1', maria.store.YnToBool('PROCYN'));
    ItsGrid.Get('grid1').autoSizeColumns();
    ItsMsg.Toast(ItsMsg.CommonMsg.SearchComplete(maria.store.Length()));
};
