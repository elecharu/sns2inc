/// <reference path="../../Script/reference.js" />
var tabstate = 0;

/* 페이지 접근 시 수행 */
ItsPage.Load = function () {

    ItsGrid.Create('grid1', {}, [
        column.create('등록여부', 'BOM_YN', { width: 50, columnType: enumColumnTypes.check }),
        column.create('품목유형', 'ITEMTP', { width: 60, columnType: enumColumnTypes.combo, gpcd: 'ITEMTP', align: 'center' }),
        column.create('품목코드', 'ITEMCD', { width: 150, align: 'center', align: 'center' }),
        column.create('품명', 'ITEMNM', { width: 200, align: 'center' }),        
        column.split()
    ]);

    ItsGrid.Create('grid2', {}, [
        column.create('품목코드', 'CITEMCD', { width: 150, align: 'center' }),
        column.create('품명', 'ITEMNM', { width: 200, align: 'center' }),
        column.create('공정', 'PRCCD', { width: 80, columnType: enumColumnTypes.combo, gpcd: 'PRCCD', align: 'center' }),
        column.create('기준수량', 'MUSAGE', { width: 80, align: 'right'}),
        column.create('소요수량', 'CUSAGE', { width: 80, align: 'right' }),
        column.create('LOSS수량', 'LUSAGE', { width: 80, align: 'right' }),
        column.create('단위', 'ITEMUNIT', { width: 80, columnType: enumColumnTypes.combo, gpcd: 'ITEMUNIT', align: 'center'}),
        column.create('사용여부', 'USEYN', { width: 80, columnType: enumColumnTypes.check}),
        column.split()
    ]);

};


/*********************************************************************************************************************************************/
/* 조회 */
ItsButton.EventSearch = function () {
    ItsGrid.Clear('grid1');
    ItsGrid.Clear('grid2');

    var maria = new ItsMaria('MST0001_R10', 'LIST_MSTITEM');

    maria.AddPanel('sdiv1');

    maria.CallProc();

    if (maria.isError) {
        maria.ShowErrMsg();
        return;
    }

    ItsGrid.SetStore('grid1', maria.store.YnToBool('BOM_YN'));

};

ItsGrid.Event('grid1').onSelect = function (rowIndex) {
    var maria = new ItsMaria('MST0001_R10', 'LIST_MSTBOM');

    maria.AddParam('SALODRDKEY', ItsGrid.GetValue('grid1', rowIndex, 'SALODRDKEY'));
    maria.AddParam('MITEMCD', ItsGrid.GetValue('grid1', rowIndex, 'ITEMCD'));

    maria.CallProc();

    if (maria.isError) {
        maria.ShowErrMsg();
        return;
    }

    ItsGrid.SetStore('grid2', maria.store.YnToBool('USEYN'));

};

/////* 추가 */
//ItsButton.EventAdd = function () {
//    if (ItsGrid.Length('grid1') == 0) {
//        ItsMsg.Alert("품목을 조회하세요.");
//        return;
//    }

//    ItsPage.InitData('pdiv1');

//    ItsFind.SetValue('find_MITEMCD', ItsGrid.GetValue('grid1', ItsGrid.GetCurrentIndex('grid1'), 'ITEMCD'));

//    ItsFind.Focus('pdiv1_find_CITEMCD');

//    ItsPop.Open('pop1');
//}

//ItsPop.Event('pop1').onCancelBtnClick = function () {
//    ItsPop.Close('pop1');
//}

///* 추가 저장*/
//ItsPop.Event('pop1').onAddBtnClick = function () {
//    var maria = new ItsMaria('MST0001_R10', 'ADD_MSTBOM');

//    maria.AddPanel('pdiv1');

//    maria.CallProc();

//    if (maria.isError) {
//        maria.ShowErrMsg();
//        return;
//    }

//    ItsPop.Close('pop1');

//    ItsGrid.Event('grid1').onSelect(ItsGrid.GetCurrentIndex('grid1'));
    
//    ItsMsg.Toast(ItsMsg.CommonMsg.AddComplete);

//    ItsButton.EventSearch();
//}

//// 추가 팝업창에 자품목 입력시 단위가 자동으로 들어가도록
//ItsFind.Event('pdiv1_find_CITEMCD').onChanged = function (Value) {
    
//    var UNIT = ItsFind.GetRef05Value('pdiv1_find_CITEMCD', Value);
//    console.log(UNIT);
//    ItsCombo.SetValue('pdiv1_combo_ITEMUNIT', UNIT);

//}

/////*********************************************************************************************************************************************/
///* 수정 저장 */
//ItsButton.EventSave = function () {
//    ItsMsg.Confirm("해당항목을 수정하시겠습니까?", function () {
//        var maria = new ItsMaria('MST0001_R10', 'UP_MSTBOM');
//        maria.AddParam('MITEMCD', ItsGrid.GetValue('grid1', ItsGrid.GetCurrentIndex('grid1'), 'ITEMCD'));
//        maria.AddRecord('grid2', ItsGrid.GetCurrentIndex('grid2'));
//        maria.CallProc();
//        if (maria.isError) {
//            maria.ShowErrMsg();
//        }

//        ItsGrid.Event('grid1').onSelect(ItsGrid.GetCurrentIndex('grid1'));
//        ItsButton.EventSearch();
//    })

//}

///*********************************************************************************************************************************************/
///* 삭제 */
//ItsButton.EventDelete = function () {
//    ItsMsg.Confirm("선택항목을 삭제하시겠습니까?",
//        function () {
//            var maria = new ItsMaria('MST0001_R10', 'DEL_MSTBOM');
//            maria.AddParam('MITEMCD', ItsGrid.GetValue('grid1', ItsGrid.GetCurrentIndex('grid1'), 'ITEMCD'));
//            maria.AddRecord('grid2', ItsGrid.GetCurrentIndex('grid2'));
//            maria.CallProc();
//            if (maria.isError) {
//                maria.ShowErrMsg();
//            }

//            ItsGrid.Event('grid1').onSelect(ItsGrid.GetCurrentIndex('grid1'));
//        }
//    );
//}

