/// <reference path="../../Script/reference.js" />

/* 페이지 로드 시 수행 */
var LANGLIST = [];
var langinit = true;
ItsPage.Load = function () {

    if (langinit) {
        var maria = new ItsMaria('COMLANG', 'LANG_LIST');
        maria.CallProc();
        if (maria.isError) {
            maria.ShowErrMsg();
            return;
        }
        var colList = [];
        colList.push(column.create('유형', 'LANGTP', { width: 80, align: 'center', columnType:enumColumnTypes.combo, gpcd:'LANGTP' }));
        colList.push(column.create('다국어Key', 'LANGKEY', { width: 120 }));
        colList.push(column.create('키워드', 'LANGNM', { width: 150 }));
        for (var i = 0; i < maria.store.data.length; i++) {
            colList.push(column.create(maria.store.data[i]['TPNM'], maria.store.data[i]['TPCD'], { width: 150, readOnly: false }));
            LANGLIST.push(maria.store.data[i]['TPCD']);
        }
        colList.push(column.split());

        ItsGrid.Create('grid1', { isCheckBoxGrid: true }, colList);
        langinit = false;
    }
};

/* 조회 */
ItsButton.EventSearch = function () {

    var maria = new ItsMaria('COMLANG', 'LIST');
    maria.AddPanel('sdiv1');
    maria.CallProc();
    if (maria.isError) {
        maria.ShowErrMsg();
        return;
    }
    ItsGrid.SetStore('grid1', maria.store);
    ItsMsg.Toast(ItsMsg.CommonMsg.SearchComplete(maria.store.Length()));
};

ItsButton.EventAdd = function () {
    ItsMsg.Alert('새로운 키 추가는 문의 바랍니다.');
};

/* 저장 */
ItsButton.EventSave = function () {

    for (var i = 0; i < ItsGrid.Length('grid1') ; i++) {
        if (ItsGrid.IsChecked('grid1', i)) {
            LANGLIST.forEach(function (lang) {
                var maria = new ItsMaria('COMLANG', 'SAVE');
                maria.AddParam('LANGKEY', ItsGrid.GetValue('grid1', i, 'LANGKEY'));
                maria.AddParam('LANGUAGE', lang);
                maria.AddParam('MSG', ItsGrid.GetValue('grid1', i, lang));
                maria.CallProc();
                if (maria.isError) {
                    maria.ShowErrMsg();
                    return;
                }
            });


        }
    }
    ItsButton.EventSearch();
};
