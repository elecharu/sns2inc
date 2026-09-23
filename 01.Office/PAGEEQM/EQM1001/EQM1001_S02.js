/// <reference path="../../Script/reference.js" />

/* 페이지 접근 시 수행 */
ItsPage.Load = function () {
    // 설비종합효율
    ItsGrid.Create('grid_EQM', { isSubTotalGrid: true }, [
        column.create('설비코드', 'EQMCD', { width: 150, align: 'center' }),
        column.create('설비명', 'EQMNM', { width: 200 }),
        column.create('양품수량', 'GOOD_V1', { width: 100, columnType: enumColumnTypes.number, groupType: enumGrouping.sum }),
        column.create('불량수량', 'GOOD_V2', { width: 100, columnType: enumColumnTypes.number, groupType: enumGrouping.sum }),
        column.create('생산량', 'GOOD_V3', { width: 100, columnType: enumColumnTypes.number, groupType: enumGrouping.sum }),
        column.create('양품율(%)', 'GOOD_V4', { width: 100, columnType: enumColumnTypes.number, decimalPrecision: 2, backColor: enumColor.yellowLight2 }), //(양품수량)/생산수량

        column.split()
    ]);

};

/* 조회 */
ItsButton.EventSearch = function () {
    var maria = new ItsMaria('EQM1001_S02', 'SEARCH_EQM_EFFC');

    maria.AddPanel('sdiv1');

    maria.CallProc();

    if (maria.isError) {
        maria.ShowErrMsg();
        return;
    }

    ItsGrid.SetStore('grid_EQM', maria.store);

    ItsMsg.Toast(ItsMsg.CommonMsg.SearchComplete(maria.store.Length()));
};
