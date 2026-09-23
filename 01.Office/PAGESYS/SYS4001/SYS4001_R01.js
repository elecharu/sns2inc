/// <reference path="../../Script/reference.js" />

/* 페이지 로드 시 수행 */
ItsPage.Load = function () {
    ItsPop.LoadFindPopCOM();

    ItsGrid.Create('grid1', { isCheckBoxGrid: true }, [
        column.create('사업장', 'BDVCD', { width: 100, columnType: enumColumnTypes.combo, gpcd: 'BDVCD' }),
        column.create('적용일자', 'BASDT', { width: 110, align: 'center' }),
        column.create('품목코드', 'ITEMCD', { width: 120 }),
        column.create('품명', 'ITEMNM', { width: 200 }),    //MSTITEM
        column.create('규격', 'ITEMSPEC', { width: 120 }),  //MSTITEM
        column.create('차종', 'BRANDNM', { width: 120 }),
        column.create('수량', 'STOCKQTY', { width: 70, readOnly: false, columnType: enumColumnTypes.number }),
        column.create('단위', 'ITEMUNIT', { width: 60, columnType: enumColumnTypes.combo, gpcd: 'ITEMUNIT', align: 'center' }),
        column.create('단가', 'UNITCOST', { width: 80, readOnly: false, columnType: enumColumnTypes.number }),
        column.create('금액', 'STOCKAMT', { width: 90, columnType: enumColumnTypes.number }),
        column.create('등록일', 'RTIME', { width: 110, align: 'center' }),
        column.create('수정일', 'MTIME', { width: 110, align: 'center' }),
        column.split()
    ]);
};

/* 조회 */
ItsButton.EventSearch = function () {

    var maria = new ItsMaria('SYS4001_R01', 'LIST_STOCK');
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
    ItsPage.InitData('pdiv1');
    ItsDate.SetValue('date_BASDT', ItsHelper.GetYearMonthDay());
    ItsPop.Open('pop1');
};

ItsPop.Event('pop1').onAddBtnClick = function () {
    var maria = new ItsMaria('SYS4001_R01', 'ADD_STOCK');
    maria.AddPanel('pdiv1');
    maria.CallProc();
    if (maria.isError) {
        maria.ShowErrMsg();
        return;
    }

    ItsPop.Close('pop1');
    ItsMsg.Toast(ItsMsg.CommonMsg.AddComplete);
    ItsButton.EventSearch();
};

ItsPop.Event('pop1').onCancelBtnClick = function () {
    ItsPop.Close('pop1');
    ItsPage.InitData('pdiv1');
};

/* 저장 */
ItsButton.EventSave = function () {
    var $cnt = 0;
    var $isError = false;
    for (var i = 0; i < ItsGrid.Length('grid1') ; i++) {
        if (ItsGrid.IsChecked('grid1', i)) {
            var maria = new ItsMaria('SYS4001_R01', 'UP_STOCK');
            maria.AddRecord('grid1', i);
            maria.CallProc();
            if (maria.isError) {
                $isError = true;
                maria.ShowErrMsg();
            } else {
                $cnt++;
            }
        }
    }
    if ($isError) {
        return;
    }
    ItsMsg.Toast(ItsMsg.CommonMsg.SaveComplete($cnt));
    ItsButton.EventSearch();
};

/* 삭제 */
ItsButton.EventDelete = function () {
    ItsMsg.Confirm('삭제 하시겠습니까?',
        function () {
            var $cnt = 0;
            var $isError = false;
            for (var i = 0; i < ItsGrid.Length('grid1') ; i++) {
                if (ItsGrid.IsChecked('grid1', i)) {
                    var maria = new ItsMaria('SYS4001_R01', 'DEL_STOCK');
                    maria.AddRecord('grid1', i);
                    maria.CallProc();
                    if (maria.isError) {
                        $isError = true;
                        maria.ShowErrMsg();
                    } else {
                        $cnt++;
                    }
                }
            }
            ItsMsg.Toast(ItsMsg.CommonMsg.DeleteComplete($cnt));
            if (!$isError) {
                ItsButton.EventSearch();
            }
        }
    )
};

/* 기초 재고 조회 그리드 필드 값 변경 */
ItsGrid.Event('grid1').onChanged = function (rowIndex, field, newValue, oldValue) {
    if (field == 'STOCKQTY') {
        /* 재고량 변경 시 */
        ItsGrid.SetValue('grid1', rowIndex, 'STOCKAMT', newValue * ItsGrid.GetValue('grid1', rowIndex, 'UNITCOST'));
    } else if (field == 'UNITCOST') {
        /* 재고 금액 변경 시 */
        ItsGrid.SetValue('grid1', rowIndex, 'STOCKAMT', ItsGrid.GetValue('grid1', rowIndex, 'STOCKQTY') * newValue);
    } 
};

ItsNum.Event('num_STOCKQTY').onChanged = function (value, oldvalue) {
    ItsNum.SetValue('num_STOCKAMT', value * ItsNum.GetValue('num_UNITCOST'));
}

ItsNum.Event('num_UNITCOST').onChanged = function (value, oldvalue) {
    ItsNum.SetValue('num_STOCKAMT', value * ItsNum.GetValue('num_STOCKQTY'));
}