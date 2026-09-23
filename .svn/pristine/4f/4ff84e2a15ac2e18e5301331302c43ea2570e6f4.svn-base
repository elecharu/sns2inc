/// <reference path="../../Script/reference.js" />

/* 페이지 로드 시 수행 */
ItsPage.Load = function () {
    ItsPop.LoadFindPopCOM();

    /* TAB1 - 기초 채권 등록 */
    ItsGrid.Create('grid1', { isCheckBoxGrid: true }, [
        column.create('사업장', 'BDVCD', { width: 100, columnType: enumColumnTypes.combo, gpcd: 'BDVCD' }),
        column.create('적용일자', 'BASDT', { width: 110, align: 'center' }),
        column.create('거래처', 'CUSTCD', { width: 100 }),
        column.create('상호', 'CUSTNM', { width: 180 }),
        column.create('외상매출금', 'CRDTSALAMT', { width: 120, readOnly: false, columnType: enumColumnTypes.number }),
        column.create('미수금', 'ACTRCVAMT', { width: 120, readOnly: false, columnType: enumColumnTypes.number }),
        column.create('등록자', 'REMP', { width: 110 }),
        column.create('등록일자', 'RTIME', { width: 110, align: 'center' }),
        column.create('수정자', 'MEMP', { width: 110 }),
        column.create('수정일자', 'MTIME', { width: 110 }),
        column.split()
    ]);

    /* TAB2 - 기초 채무 등록 */
    ItsGrid.Create('grid2', { isCheckBoxGrid: true }, [
        column.create('사업장', 'BDVCD', { width: 100, columnType: enumColumnTypes.combo, gpcd: 'BDVCD' }),
        column.create('적용일자', 'BASDT', { width: 110 }),
        column.create('거래처', 'CUSTCD', { width: 100 }),
        column.create('상호', 'CUSTNM', { width: 180 }),
        column.create('외상매입금', 'CRDTPURAMT', { width: 120, readOnly: false, columnType: enumColumnTypes.number}),
        column.create('미지급금', 'ACTPAYAMT', { width: 120, readOnly: false, columnType: enumColumnTypes.number }),
        column.create('등록자', 'REMP', { width: 110 }),
        column.create('등록일자', 'RTIME', { width: 110 }),
        column.create('수정자', 'MEMP', { width: 110 }),
        column.create('수정일자', 'MTIME', { width: 110 }),
        column.split()
    ]);

};

var tabState = 0;   // 탭 현재 위치

/* 탭 변경 */
ItsTab.Event('tab1').onTabChanged = function (newPanel) {
    if (newPanel == 0) {
        tabState = 0;
    } else if (newPanel == 1) {
        tabState = 1;
    }
};

/* 조회 */
ItsButton.EventSearch = function () {
    var maria = new ItsMaria('SYS4001_R02', 'LIST_BAS');
    maria.CallProc();
    if (maria.isError) {
        maria.ShowErrMsg();
        return;
    }

    ItsGrid.SetStore('grid1', maria.store);
    ItsGrid.SetStore('grid2', maria.store);

    ItsMsg.Toast(ItsMsg.CommonMsg.SearchComplete(maria.store.Length()));
};

/* 추가 */
ItsButton.EventAdd = function () {
    if (tabState == 0) {    /* 기초 채권 */
        ItsPage.InitData('pdiv1');
        ItsDate.SetValue('pop1_date_BASDT', ItsHelper.GetYearMonthDay());
        ItsPop.Open('pop1');
    } else if (tabState == 1) {     /* 기초 채무 */
        ItsPage.InitData('pdiv2');
        ItsDate.SetValue('pop2_date_BASDT', ItsHelper.GetYearMonthDay());
        ItsPop.Open('pop2');
    }
};

ItsPop.Event('pop1').onAddBtnClick = function () {
    var maria = new ItsMaria('SYS4001_R02', 'ADD_BAS_U1');
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


ItsPop.Event('pop2').onAddBtnClick = function () {
    var maria = new ItsMaria('SYS4001_R02', 'ADD_BAS_U2');
    maria.AddPanel('pdiv2');
    maria.CallProc();
    if (maria.isError) {
        maria.ShowErrMsg();
        return;
    }

    ItsPop.Close('pop2');
    ItsMsg.Toast(ItsMsg.CommonMsg.AddComplete);
    ItsButton.EventSearch();
};

ItsPop.Event('pop1').onCancelBtnClick = function () {
    ItsPop.Close('pop1');
    ItsPage.InitData('pdiv1');
};

/* 저장 */
ItsButton.EventSave = function () {

    if (tabState == 0) {    /* 기초 채권 */

        var $cnt = 0;
        var $isError = false;
        for (var i = 0; i < ItsGrid.Length('grid1') ; i++) {
            if (ItsGrid.IsChecked('grid1', i)) {

                var maria = new ItsMaria('SYS4001_R02', 'UP_BAS_U1');
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

    } else if (tabState == 1) {     /* 기초 채무 */

        var $cnt = 0;
        var $isError = false;
        for (var i = 0; i < ItsGrid.Length('grid2') ; i++) {
            if (ItsGrid.IsChecked('grid2', i)) {
                var maria = new ItsMaria('SYS4001_R02', 'UP_BAS_U2');
                maria.AddRecord('grid2', i);
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
    }
};

/* 삭제 */
ItsButton.EventDelete = function () {

    if (tabState == 0) {        /* 기초 채권 */

        ItsMsg.Confirm('삭제 하시겠습니까?',
            function () {
                var $cnt = 0;
                var $isError = false;
                for (var i = 0; i < ItsGrid.Length('grid1') ; i++) {
                    if (ItsGrid.IsChecked('grid1', i)) {
                        var maria = new ItsMaria('SYS4001_R02', 'DEL_BAS_D1');
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
                if (!$isError) {
                    ItsMsg.Toast(ItsMsg.CommonMsg.DeleteComplete($cnt));
                }
                ItsButton.EventSearch();
            }
        )
    } else if (tabState == 1) {     /* 기초 채무 */

        ItsMsg.Confirm('삭제 하시겠습니까?',
            function () {
                var $cnt = 0;
                var $isError = false;
                for (var i = 0; i < ItsGrid.Length('grid2') ; i++) {
                    if (ItsGrid.IsChecked('grid2', i)) {
                        var maria = new ItsMaria('SYS4001_R02', 'DEL_BAS_D2');
                        maria.AddRecord('grid2', i);
                        maria.CallProc();
                        if (maria.isError) {
                            $isError = true;
                            maria.ShowErrMsg();
                        } else {
                            $cnt++;
                        }
                    }
                }
                if (!$isError) {
                    ItsMsg.Toast(ItsMsg.CommonMsg.DeleteComplete($cnt));
                }
                ItsButton.EventSearch();
            }
        )
    }
};

//ItsGrid.Event('grid1').onDoubleClick = function (rowIndex, field) {
//    ItsGrid.Event('grid1').onKeydownEnter(rowIndex, field);
//}

//ItsGrid.Event('grid1').onKeydownEnter = function (rowIndex, field) {
//    if (field == 'CUSTCD' || field == 'CUSTNM') {
//        ItsPop.OpenFindCOM({ gpcd: 'ITEMCD' }, function (res) {
//            ItsGrid.SetValue('grid1', rowIndex, 'CUSTCD', res['CODE']);
//            ItsGrid.SetValue('grid1', rowIndex, 'CUSTNM', res['NAME']);
//            ItsGrid.CheckRow('grid1', rowIndex);
//            ItsGrid.SelectCell('grid1', rowIndex, 'CRDTSALAMT');
//            //        ItsGrid.Event('grid1').onChanged(rowIndex, 'ITEMCD', res['CODE'], '');
//        })
//    } else {
//        return;
//    }
//}

//ItsGrid.Event('grid2').onDoubleClick = function (rowIndex, field) {
//    ItsGrid.Event('grid2').onKeydownEnter(rowIndex, field);
//}

//ItsGrid.Event('grid2').onKeydownEnter = function (rowIndex, field) {
//    if (field == 'CUSTCD' || field == 'CUSTNM') {
//        ItsPop.OpenFindCOM({ gpcd: 'ITEMCD' }, function (res) {
//            ItsGrid.SetValue('grid2', rowIndex, 'CUSTCD', res['CODE']);
//            ItsGrid.SetValue('grid2', rowIndex, 'CUSTNM', res['NAME']);
//            ItsGrid.CheckRow('grid2', rowIndex);
//            ItsGrid.SelectCell('grid2', rowIndex, 'CRDTPURAMT');
//            //        ItsGrid.Event('grid2').onChanged(rowIndex, 'ITEMCD', res['CODE'], '');
//        })
//    } else {
//        return;
//    }
//}