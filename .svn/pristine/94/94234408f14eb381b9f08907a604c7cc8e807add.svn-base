

/// <reference path="../../Script/reference.js" />

var tabstate = 0;
/* 페이지 접근 시 수행 */
ItsPage.Load = function () {
    ItsGrid.Create('grid1', {}, [
        column.create('등록여부', 'ROUT_YN', { width: 80, columnType: enumColumnTypes.check }),
        column.create('품목유형', 'ITEMTP', { width: 100, columnType: enumColumnTypes.combo, gpcd: 'ITEMTP', align:'center' }),
        column.create('품목코드', 'ITEMCD', { width: 150 }),        
        column.create('품명', 'ITEMNM', { width: 200 }),

        column.split()
    ]);

    ItsGrid.Create('grid2', { isCheckBoxGrid: false }, [
        column.create('공정코드', 'PRCCD', { width: 120 }),
        column.create('공정명', 'PRCNM', { width: 120 }),
        column.create('공정순번', 'PRCSEQ', { width: 70, columnType: enumColumnTypes.number }),
        column.split()
    ]);

    ItsGrid.Create('grid3', { isCheckBoxGrid: true }, [
        column.create('공정코드', 'PRCCD', { width: 90 }),
        column.create('공정명', 'PRCNM', { width: 100 }),
        column.create('공정순번', 'PRCSEQ', { width: 90, columnType: enumColumnTypes.number, readOnly: false }),
        column.split()
    ]);

};

/*********************************************************************************************************************************************/
/* 조회 */
ItsButton.EventSearch = function () {
    var maria = new ItsMaria('MST1001_R06', 'LIST_MSTITEM');

    maria.AddPanel('sdiv1');

    maria.CallProc();

    if (maria.isError) {
        maria.ShowErrMsg();
        return;
    }

    ItsGrid.SetStore('grid1', maria.store.YnToBool('ROUT_YN'));
};


// 라우팅 정보 조회
ItsGrid.Event('grid1').onSelect = function (rowIndex) {
    var maria = new ItsMaria('MST1001_R06', 'LIST_MSTROUT');

    maria.AddParam('SALODRDKEY', ItsGrid.GetValue('grid1', rowIndex, 'SALODRDKEY'));
    maria.AddParam('ITEMCD', ItsGrid.GetValue('grid1', rowIndex, 'ITEMCD'));

    maria.CallProc();
    if (maria.isError) {
        maria.ShowErrMsg();
        return;
    }

    ItsGrid.SetStore('grid2', maria.store.YnToBool('USEYN').YnToBool('OSCYN'));

}
/*********************************************************************************************************************************************/
///* 추가 > 팝업 띄워 선택하기 */
//ItsButton.EventAdd = function () {
//    if (ItsGrid.Length('grid1') == 0) {
//        ItsMsg.Alert("품목을 조회하세요.");
//        return;
//    }

//    ItsPage.InitData('pdiv1');
//    ItsPop.Open('pop1');

//    var maria = new ItsMaria();

//    maria.AddQuery("SELECT A.PRCCD, A.PRCNM, IFNULL(B.PRCSEQ, 0) AS PRCSEQ FROM MSTPRC AS A LEFT JOIN MSTROUT AS B ON A.PRCCD = B.PRCCD AND B.ITEMCD = '" + ItsGrid.GetValue('grid1', ItsGrid.GetCurrentIndex('grid1'), 'ITEMCD') + "' WHERE A.USEYN = 'Y';");

//    maria.CallProc();

//    if (maria.isError) {
//        maria.ShowErrMsg();
//        return;
//    }

//    ItsGrid.SetStore('grid3', maria.store);

//    // 자동체크
//    for (var i = 0; i < ItsGrid.Length('grid3'); i++) {
//        if (ItsGrid.GetValue('grid3', i, 'PRCSEQ') != 0) {
//            ItsGrid.CheckRow('grid3', i);
//        }
//    }
//}

//// 추가 저장
//ItsPop.Event('pop1').onAddBtnClick = function () {
//    var maria = new ItsMaria('PRD1003_R01', 'ADD_MSTROUT');

//    maria.AddParam('BDVCD', ItsCombo.GetValue('combo_BDVCD'));
//    maria.AddParam('ITEMCD', ItsGrid.GetValue('grid1', ItsGrid.GetCurrentIndex('grid1'), 'ITEMCD'));

//    for (var i = 0; i < ItsGrid.Length('grid3'); i++) {
//        if (ItsGrid.IsChecked('grid3', i)) {
//            maria.AddList('PRCLIST', ItsGrid.GetValue('grid3', i, 'PRCCD'));
//            maria.AddList('PRNMLIST', ItsGrid.GetValue('grid3', i, 'PRCNM'));
//            maria.AddList('SEQLIST', ItsGrid.GetValue('grid3', i, 'PRCSEQ'));
//        }
//    }

//    maria.CallProc();

//    if (maria.isError) {
//        maria.ShowErrMsg();
//        return;
//    }

//    ItsPop.Close('pop1');
//    ItsMsg.Toast(ItsMsg.CommonMsg.AddComplete);
//    ItsGrid.Event('grid1').onSelect(ItsGrid.GetCurrentIndex('grid1'));
//}

//ItsPop.Event('pop1').onCancelBtnClick = function () {
//    ItsPop.Close('pop1');
//}
///*********************************************************************************************************************************************/
///* 저장 */
//ItsButton.EventSave = function () {
//    var cnt = 0;
//    for (var i = 0; i < ItsGrid.Length('grid2'); i++) {
//        if (ItsGrid.IsChecked('grid2', i)) {
//            var maria = new ItsMaria('PRD1003_R01', 'UP_MSTROUT');
//            maria.AddRecord('grid2', i);
//            maria.AddParam('BDVCD', ItsCombo.GetValue('combo_BDVCD'));
//            maria.AddParam('ITEMCD', ItsGrid.GetValue('grid1', ItsGrid.GetCurrentIndex('grid1'), 'ITEMCD'));
//            maria.CallProc();
//            if (maria.isError) {
//                maria.ShowErrMsg();
//            }
//            else {
//                ItsGrid.UnCheckRow('grid2', i);
//                cnt++;
//            }
//        }
//    }
//    ItsMsg.Toast(ItsMsg.CommonMsg.SaveComplete(cnt));
//    ItsGrid.Event('grid1').onSelect(ItsGrid.GetCurrentIndex('grid1'));
//}
///*********************************************************************************************************************************************/
///* 삭제 */
//ItsButton.EventDelete = function () {
//    ItsMsg.Confirm("선택항목을 삭제하시겠습니까?",
//        function () {
//            var cnt = 0;
//            for (var i = 0; i < ItsGrid.Length('grid2') ; i++) {
//                if (ItsGrid.IsChecked('grid2', i)) {
//                    var maria = new ItsMaria('PRD1003_R01', 'DEL_MSTROUT');
//                    maria.AddRecord('grid2', i);
//                    maria.AddParam('BDVCD', ItsCombo.GetValue('combo_BDVCD'));
//                    maria.AddParam('ITEMCD', ItsGrid.GetValue('grid1', ItsGrid.GetCurrentIndex('grid1'), 'ITEMCD'));
//                    maria.CallProc();
//                    if (maria.isError) {
//                        maria.ShowErrMsg();
//                    }
//                    else {
//                        ItsGrid.UnCheckRow('grid2', i);
//                        cnt++;
//                    }
//                }
//            }
//            ItsMsg.Toast(ItsMsg.CommonMsg.DeleteComplete(cnt));
//            ItsGrid.Event('grid1').onSelect(ItsGrid.GetCurrentIndex('grid1'));
//        }
//    );
//}

///*********************************************************************************************************************************************/

//// 공정 선택에 따라 순번 입력 자동화
//ItsGrid.Event('grid3').onChanged = function (rowIndex, field, value) {
//    if (field == 'isRowCheck') {
//        if (value == true) {
//            var cnt = 0;
//            for (var i = 0; i < ItsGrid.Length('grid3') ; i++) {
//                if (ItsGrid.IsChecked('grid3', i)) {
//                    if (ItsGrid.GetValue('grid3', i, 'PRCSEQ') % 2 == 0)
//                        cnt++;
//                }
//            }

//            ItsGrid.SetValue('grid3', rowIndex, 'PRCSEQ', (cnt * 10).toString());
//        } else {
//            var oldV = ItsGrid.GetValue('grid3', rowIndex, 'PRCSEQ');
//            ItsGrid.SetValue('grid3', rowIndex, 'PRCSEQ', 0);

//            for (var i = 0; i < ItsGrid.Length('grid3') ; i++) {
//                if (ItsGrid.IsChecked('grid3', i)) {
//                    if (ItsGrid.GetValue('grid3', i, 'PRCSEQ') > oldV) {
//                        ItsGrid.SetValue('grid3', i, 'PRCSEQ', (ItsGrid.GetValue('grid3', i, 'PRCSEQ') - 10).toString());
//                    }
//                }
//            }
//        }
//    }
//}

///*********************************************************************************************************************************************/
//// 복사기능
//ItsButton.Event('btn_COPY').onClick = function () {
//    if (ItsFind.GetValue('find_COPYITEM') == "" || !ItsFind.IsFindName('find_COPYITEM') || ItsGrid.Length('grid1') == 0 || ItsGrid.Length('grid2') == 0) {
//        ItsMsg.Alert("기준이 되는 품목코드, 라우팅정보를 조회하고 대상품목을 선택해주세요.");
//        return;
//    }

//    ItsMsg.Confirm("현재 조회된 품목의 라우팅정보를 대상품목의 라우팅값으로 복사합니다.", function () {
//        var maria = new ItsMaria('PRD1003_R01', 'COPY_ROUT');
//        maria.AddParam('ITEMCD', ItsGrid.GetValue('grid1', ItsGrid.GetCurrentIndex('grid1'), 'ITEMCD'));
//        maria.AddParam('COPYITEM', ItsFind.GetValue('find_COPYITEM'));
//        maria.CallProc();
//        if (maria.isError) {
//            maria.ShowErrMsg();
//            return;
//        }

//        ItsMsg.Alert("복사완료");
//        return;
//    });
//}
/*********************************************************************************************************************************************/