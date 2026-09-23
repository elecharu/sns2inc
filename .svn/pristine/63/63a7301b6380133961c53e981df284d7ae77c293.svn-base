/// <reference path="../../Script/reference.js" />

/* 페이지 접근 시 수행 */
ItsPage.Load = function () {
    ItsGrid.Create('grid1', {isCheckBoxGrid: true}, [
        column.create('측정일자', 'HISTIME_VIEW', { width: 100, align:'center' }),
        column.create('상한온도', 'TEMP_MAX', { width: 90, columnType: enumColumnTypes.number, decimalPrecision: 2 }),
        column.create('하한온도', 'TEMP_MIN', { width: 90, columnType: enumColumnTypes.number, decimalPrecision: 2 }),
        column.create('현재온도', 'TEMP_CUR', { width: 90, columnType: enumColumnTypes.number, decimalPrecision: 2 }),
        column.create('관리온도', 'TEMP_CUR_F', { width: 90, columnType: enumColumnTypes.number, decimalPrecision: 2, readOnly: false }),
        column.create('상한습도', 'HUMI_MAX', { width: 90, columnType: enumColumnTypes.number, decimalPrecision: 2 }),
        column.create('현재습도', 'HUMI_CUR', { width: 90, columnType: enumColumnTypes.number, decimalPrecision: 2 }),
        column.create('관리습도', 'HUMI_CUR_F', { width: 90, columnType: enumColumnTypes.number, decimalPrecision: 2, readOnly: false }),
        column.create('온도이상', 'TEMP_ALRAM', { width: 100, align: 'center' }),
        column.create('관리온도이상', 'TEMP_ALRAM_F', { width: 100, align: 'center' }),
        column.create('습도이상', 'HUMI_ALRAM', { width: 100, align: 'center' }),
        column.create('관리습도이상', 'HUMI_ALRAM_F', { width: 100, align: 'center' }),
        column.create('PLCCD', 'PLCCD', { hidden: true }),
        column.create('EQMCD', 'EQMCD', { hidden:true }),
        column.create('HISTIME', 'HISTIME', { hidden:true }),
        column.split()
    ]);
};

/* 조회 */
ItsButton.EventSearch = function () {
    var maria = new ItsMaria('SYS4002_R01', 'TEMP_HUMI');
    maria.AddPanel('sdiv1');
    maria.CallProc();
    if (maria.isError) {
        maria.ShowErrMsg();
        return;
    }
    ItsGrid.SetStore('grid1', maria.store);
};

ItsButton.EventSave = function () {
    var cnt = 0;
    for (var i = 0; i < ItsGrid.Length('grid1') ; i++) {
        if (ItsGrid.IsChecked('grid1', i)) {
            var maria = new ItsMaria('SYS4002_R01', 'UP_TEMP');
            maria.AddRecord('grid1', i);
            maria.CallProc();
            if (maria.isError) {
                maria.ShowErrMsg();
            }
            else {
                ItsGrid.UnCheckRow('grid1', i);
                cnt++;
            }
        }
    }
    ItsMsg.Toast(ItsMsg.CommonMsg.SaveComplete(cnt));
};