/*
 *  제품출고
 * 
 * *

/// <reference path="../../Script/reference.js" />

/* 페이지 접근 시 수행 */
ItsPage.Load = function () {
    $('.title-text').html('제품출고'); 

    // 출하지시집계(출고일자, 거래처)
    ItsGrid.Create('grid_SALOUT_GROUP', { isCheckBoxGrid: false, isSubTotalGrid: true }, [
        column.create('출고일자', 'SALOUTDATE', { width: 80 }),
        column.create('출고창고', 'WARENM', { width: 80 }),
        column.create('거래처', 'CUSTNM', { width: 80 }),
        column.create('거래처', 'CUSTCD', { width: 80, hidden: true }),
        column.create('수량', 'SUMOUTQTY', { width: 50, columnType: enumColumnTypes.number, decimalPrecision: 0, groupType: enumGrouping.sum }),
    ]);

    // 출하지시(품목)
    ItsGrid.Create('grid_SALOUT', { isSubTotalGrid: true}, [        
        column.create('출하키(hidden)', 'SALOUTKEY', { width: 120, hidden: true }),
        column.create('품목코드', 'ITEMCD', { width: 50, hidden: true }),
        column.create('품목정보', 'ITEMINFO', { width: 140 }),
        column.create('지시수량', 'OUTQTY', { width: 60, columnType: enumColumnTypes.number, decimalPrecision: 0, groupType: enumGrouping.sum }),
        column.create('스캔수량', 'SCANQTY', { width: 60, columnType: enumColumnTypes.number, decimalPrecision: 0, groupType: enumGrouping.sum }),
    ]);

    // 스캔목록
    ItsGrid.Create('grid_SALOUTLOT', { isCheckBoxGrid: false, isSubTotalGrid: true }, [
        column.create('로트키', 'LOTKEY', { width: 110 }),
        column.create('스캔수량', 'LOTQTY', { width: 100, columnType: enumColumnTypes.number, decimalPrecision: 0, groupType: enumGrouping.sum }),
        column.create('삭제', 'DELETE', { width: 60, columnType: enumColumnTypes.button, iconCls: 'fa-times' }),
    ]);    

    // 출고검사항목
    ItsGrid.Create('grid_OUTTEST', { isCheckBoxGrid: false }, [
        column.create('검사이력키', 'TQMRSTKEY', { width: 50, hidden: true }),
        column.create('리비전코드', 'REVCD', { width: 50, hidden: true }),
        column.create('검사항목코드', 'STDCD', { width: 50, hidden: true }),
        column.create('검사항목명', 'STDNM', { width: 130 }),
        column.create('합', 'STDJUDGE_Y', { width: 60, columnType: enumColumnTypes.check, readOnly: false }),
        column.create('불', 'STDJUDGE_N', { width: 60, columnType: enumColumnTypes.check, readOnly: false }),
    ]);    
    
    ItsDate.SetInitValue('date_OUTDATE', ItsHelper.GetYearMonthDay());    
    ItsDate.SetValue('date_OUTDATE_SDATE', ItsHelper.AddDay(-7, ItsHelper.GetYearMonthDay()));
    ItsDate.SetValue('date_OUTDATE_EDATE', ItsHelper.GetYearMonthDay());


    // 그리드 Row 높이 수정
    ItsGrid.Get('grid_SALOUT').formatItem.addHandler(function (s, e) {
        for (var i = 0; i < ItsGrid.Length('grid_SALOUT'); i++) {
            ItsGrid.Get('grid_SALOUT').rows[i].height = 66;
        }
    });
};

/*************************************************************************************************************************************************************************************/
// 출하지시 집계 조회 (출고일자, 거래처)
ItsButton.Event('btn_LIST_SALOUT_GROUP').onClick = function () {
    LIST_SALOUT_GROUP();
}

LIST_SALOUT_GROUP = function () {
    var maria = new ItsMaria('PDA1200_R01', 'LIST_SALOUT_GROUP');

    maria.AddParam('CUSTCD', ItsCombo.GetValue('cmb_CUSTCD'));

    maria.AddParam('SDATE', ItsDate.GetValue('date_OUTDATE_SDATE'));
    maria.AddParam('EDATE', ItsDate.GetValue('date_OUTDATE_EDATE'));

    maria.CallProc();

    if (maria.isError) {
        maria.ShowErrMsg();
        return;
    }

    ItsGrid.SetStore('grid_SALOUT_GROUP', maria.store);
    ItsGrid.Get('grid_SALOUT_GROUP').autoSizeColumns();
}

// 출하지시집계 선택시 출하지시(품목) 조회
ItsButton.Event('btn_SALOUT_GROUP_SELECT').onClick = function () {

    if (ItsGrid.GetCurrentIndex('grid_SALOUT_GROUP') < 0) // 선택된 출하지시집계가 없는 경우
        return;

    ItsPop.Open('pop_SALOUT'); // 품목 리스트 팝업 호출    
}

/*************************************************************************************************************************************************************************************/
// 출하지시(품목) 팝업 오픈시
ItsPop.Event('pop_SALOUT').onPopOpened = function () {
    LIST_SALOUT();
}

// 출하지시리스트(품목) 팝업닫을때, 출하지시 집계 새로고침
ItsPop.Event('pop_SALOUT').onPopClosed = function () {
    LIST_SALOUT_GROUP();
}


// 출하지시(품목) 조회
LIST_SALOUT = function () {

    var maria = new ItsMaria('PDA1200_R01', 'LIST_SALOUT');

    maria.AddParam('SALOUTDATE', ItsGrid.GetValue('grid_SALOUT_GROUP', ItsGrid.GetCurrentIndex('grid_SALOUT_GROUP'), "SALOUTDATE"));
    maria.AddParam('WARECD', ItsGrid.GetValue('grid_SALOUT_GROUP', ItsGrid.GetCurrentIndex('grid_SALOUT_GROUP'), "WARECD"));
    maria.AddParam('CUSTCD', ItsGrid.GetValue('grid_SALOUT_GROUP', ItsGrid.GetCurrentIndex('grid_SALOUT_GROUP'), "CUSTCD"));

    maria.CallProc();

    if (maria.isError) {        
        maria.ShowErrMsg();
        return;
    }

    ItsGrid.SetStore('grid_SALOUT', maria.store);

    ItsGrid.Get('grid_SALOUT').autoSizeColumns();

}

// 출하품목 선택시
ItsButton.Event('btn_SALOUT_SELECT').onClick = function () {

    if (ItsGrid.GetCurrentIndex('grid_SALOUT') < 0)     // 선택된 출하지시가 없는 경우
        return; 

    ItsPop.Open('pop_SCAN'); // 스캔 리스트 팝업 호출
}



/*************************************************************************************************************************************************************************************/

// 출하스캔 리스트 팝업 오픈 시
ItsPop.Event('pop_SCAN').onPopOpened = function () {    
    ItsText.Focus('txt_pop_SCAN_LOTKEY');
    LIST_SALOUTLOT();    
}

// 스캔 팝업 닫을때, 출하지시리스트(품목) 새로고침
ItsPop.Event('pop_SCAN').onPopClosed = function () {
    LIST_SALOUT();
}

// 출하스캔 리스트 조회
LIST_SALOUTLOT = function () {
    ItsText.SetValue('txt_pop_SCAN_LOTKEY', '');
    ItsText.SetValue('txt_pop_SCAN_LOTQTY', '');    

    var maria = new ItsMaria('PDA1200_R01', 'LIST_SALOUTLOT');

    maria.AddParam('SALOUTKEY', ItsGrid.GetValue('grid_SALOUT', ItsGrid.GetCurrentIndex('grid_SALOUT'), "SALOUTKEY"));

    maria.CallProc();

    if (maria.isError) {
        maria.ShowErrMsg();
        ItsText.Focus('txt_pop_SCAN_LOTKEY');
        return;
    }

    var SALOUTDATE = ItsGrid.GetValue('grid_SALOUT_GROUP', ItsGrid.GetCurrentIndex('grid_SALOUT_GROUP'), 'SALOUTDATE');
    var CUSTNM = ItsGrid.GetValue('grid_SALOUT_GROUP', ItsGrid.GetCurrentIndex('grid_SALOUT_GROUP'), 'CUSTNM');
    var ITEMCD = ItsGrid.GetValue('grid_SALOUT', ItsGrid.GetCurrentIndex('grid_SALOUT'), 'ITEMCD');
    var ITEMNM = ItsGrid.GetValue('grid_SALOUT', ItsGrid.GetCurrentIndex('grid_SALOUT'), 'ITEMNM');
    var OUTQTY = ItsGrid.GetValue('grid_SALOUT', ItsGrid.GetCurrentIndex('grid_SALOUT'), 'OUTQTY');
    var CARMODEL = ItsGrid.GetValue('grid_SALOUT', ItsGrid.GetCurrentIndex('grid_SALOUT'), 'CARMODEL');

    ItsText.SetValue('txt_pop_SCAN_SALOUTDATE', SALOUTDATE);
    
    ItsText.SetValue('txt_pop_SCAN_CUSTNM', CUSTNM);
    ItsText.SetValue('txt_pop_SCAN_ITEMCD', ITEMCD);
    ItsText.SetValue('txt_pop_SCAN_ITEMNM', ITEMNM);
    ItsText.SetValue('txt_pop_SCAN_OUTQTY', maria.storeExtend1.data[0]['OUTQTY']);
    ItsText.SetValue('txt_pop_SCAN_CARMODEL', CARMODEL);

    ItsGrid.SetStore('grid_SALOUTLOT', maria.store);
    ItsGrid.Get('grid_SALOUTLOT').autoSizeColumns();

    ItsText.SetValue('txt_pop_LOTQTY_SUM', maria.storeExtend1.data[0]['LOTQTY_SUM']); // 스캔총수량   
    ItsCombo.SetValue('cmb_pop_SCAN_WARECD', maria.storeExtend2.data[0]['WARECD']);    
}

// 로트번호 스캔
ItsText.Event('txt_pop_SCAN_LOTKEY').onKeyEnter = function (value, oldValue) {
    var maria = new ItsMaria('PDA1200_R01', 'ADD_SALOUTLOT');
        
    maria.AddParam('SALOUTKEY', ItsGrid.GetValue('grid_SALOUT', ItsGrid.GetCurrentIndex('grid_SALOUT'), 'SALOUTKEY'));
    maria.AddParam('WARECD', ItsCombo.GetValue('cmb_pop_SCAN_WARECD'));
    maria.AddParam('LOTKEY', ItsText.GetValue('txt_pop_SCAN_LOTKEY'));

    maria.CallProc();

    if (maria.isError) {
        maria.ShowErrMsg();

        ItsText.SetValue('txt_pop_SCAN_LOTKEY', '');
        ItsText.SetValue('txt_pop_SCAN_LOTQTY', '');
        ItsText.Focus('txt_pop_SCAN_LOTKEY');
        LIST_SALOUTLOT();
        return;
    }

    LIST_SALOUTLOT(); // 출하스캔리스트 새로고침     
    ItsText.Focus('txt_pop_SCAN_LOTKEY');
}


// 스캔로트 삭제
ItsGrid.Event('grid_SALOUTLOT').onButtonClick = function (rowIndex, field) {
    if (field === 'DELETE') {
        ItsMsg.Confirm('삭제 하시겠습니까?', function () {
            var maria = new ItsMaria('PDA1200_R01', 'DEL_SALOUTLOT');

            var LOTKEY = ItsGrid.GetValue('grid_SALOUTLOT', ItsGrid.GetCurrentIndex('grid_SALOUTLOT'), 'LOTKEY');

            maria.AddParam('LOTKEY', LOTKEY);
            maria.AddParam('SALOUTKEY', ItsGrid.GetValue('grid_SALOUT', ItsGrid.GetCurrentIndex('grid_SALOUT'), 'SALOUTKEY'));

            maria.CallProc();

            if (maria.isError) {
                maria.ShowErrMsg();

                ItsText.SetValue('txt_pop_SCAN_LOTKEY', '');
                ItsText.Focus('txt_pop_SCAN_LOTQTY');

                return;
            }

            LIST_SALOUTLOT(); // 출하스캔리스트 새로고침  
        });
    }
}

// 출고검사 팝업 오픈
ItsButton.Event('btn_POP_OUTTEST').onClick = function () {
    // 출고검사대상여부 체크
    var maria = new ItsMaria('PDA1200_R01', 'CHECK_OUTTEST_YN');

    maria.AddParam('ITEMCD', ItsGrid.GetValue('grid_SALOUT', ItsGrid.GetCurrentIndex('grid_SALOUT'), 'ITEMCD'));

    maria.CallProc();

    if (maria.isError) {
        maria.ShowErrMsg();
        return;
    }

    if (maria.store.data[0]['OUTTEST_YN'] == 'Y') {
        ItsPop.Open('pop_OUTTEST');
    }
    else {
        ItsMsg.Toast('출고검사대상이 아닙니다.');
    }
}

// 출하검사 팝업 오픈시
ItsPop.Event('pop_OUTTEST').onPopOpened = function () {
    LIST_OUTTEST();
}

// 출하검사팝업 닫을때
ItsPop.Event('pop_OUTTEST').onPopClosed = function () {    
    LIST_SALOUTLOT(); 
}

// 출고검사 조회
LIST_OUTTEST = function () {
    var maria = new ItsMaria('PDA1200_R01', 'LIST_OUTTEST');

    maria.AddParam('ITEMCD', ItsGrid.GetValue('grid_SALOUT', ItsGrid.GetCurrentIndex('grid_SALOUT'), 'ITEMCD'));
    maria.AddParam('SALOUTKEY', ItsGrid.GetValue('grid_SALOUT', ItsGrid.GetCurrentIndex('grid_SALOUT'), 'SALOUTKEY'));

    maria.CallProc();

    if (maria.isError) {
        maria.ShowErrMsg();
        return;
    }

    ItsGrid.SetStore('grid_OUTTEST', maria.store.YnToBool('STDJUDGE_Y').YnToBool('STDJUDGE_N'));
}

ItsGrid.Event('grid_OUTTEST').onChanged = function (rowIndex, field, newValue, oldValue, type) {
    if (field == 'STDJUDGE_Y') {
        if (newValue)
            ItsGrid.SetValue('grid_OUTTEST', rowIndex, 'STDJUDGE_N', false);
        else
            ItsGrid.SetValue('grid_OUTTEST', rowIndex, 'STDJUDGE_N', true);
    }   

    if (field == 'STDJUDGE_N') {
        if (newValue)
            ItsGrid.SetValue('grid_OUTTEST', rowIndex, 'STDJUDGE_Y', false);
        else
            ItsGrid.SetValue('grid_OUTTEST', rowIndex, 'STDJUDGE_Y', true);
    }   
}

// 출고검사 등록
ItsButton.Event('btn_SAVE_OUTTEST').onClick = function () {
    if (ItsGrid.Length('grid_OUTTEST') > 0) {
        var maria = new ItsMaria('PDA1200_R01', 'SAVE_OUTTEST');

        maria.AddParam('SALOUTKEY', ItsGrid.GetValue('grid_SALOUT', ItsGrid.GetCurrentIndex('grid_SALOUT'), 'SALOUTKEY'));
        maria.AddParam('REVCD', ItsGrid.GetValue('grid_OUTTEST', 0, 'REVCD'));
        maria.AddParam('TQMRSTKEY', ItsGrid.GetValue('grid_OUTTEST', 0, 'TQMRSTKEY'));

        for (var i = 0; i < ItsGrid.Length('grid_OUTTEST'); i++) {
            maria.AddList('STDCD_LIST', ItsGrid.GetValue('grid_OUTTEST', i, 'STDCD'));

            if (ItsGrid.GetValue('grid_OUTTEST', i, 'STDJUDGE_Y'))
                maria.AddList('JUDGE_LIST', 'Y');
            else
                maria.AddList('JUDGE_LIST', 'N');
        }

        maria.CallProc();

        if (maria.isError) {
            maria.ShowErrMsg();
            return;
        }
        else {
            ItsMsg.Toast('출고검사가 등록되었습니다.');
        }        

        ItsPop.Close('pop_OUTTEST');
    }
}

// 출고확정 버튼
ItsButton.Event('btn_FINISH_SALOUT').onClick = function () {
    ItsMsg.Confirm('출고확정 하시겠습니까?', function () {
        var maria = new ItsMaria('PDA1200_R01', 'FINISH_SALOUT');

        maria.AddParam('SALOUTKEY', ItsGrid.GetValue('grid_SALOUT', ItsGrid.GetCurrentIndex('grid_SALOUT'), 'SALOUTKEY'));

        maria.CallProc();

        if (maria.isError) {
            maria.ShowErrMsg();
            return;
        }
        else {
            ItsMsg.Toast('출고확정 되었습니다.');
        }

        ItsPop.Close('pop_SCAN');        
    });
}
/*************************************************************************************************************************************************************************************/