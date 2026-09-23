/// <reference path="../../Script/reference.js" />

/* 페이지 접근 시 수행 */
ItsPage.Load = function () {
    $('.title-text').html('반품입고');
    
    ItsGrid.Create('grid3', { isCheckBoxGrid: false }, [
        column.create('전표키', 'SALODRDKEY', { width: 80, hidden: true }),
        column.create('요청일자', 'SALOUTDT', { width: 90 }),
        column.create('반입처', 'CUSTCD', { width: 80, hidden: true }),
        column.create('반입처', 'CUSTNM', { width: 130 }),
        column.create('수량', 'OUTQTY', { width: 60, columnType: enumColumnTypes.number, decimalPrecision: 0 }),
        column.create('비고', 'REMARK', { width: 130 })
    ]);

    ItsGrid.Create('grid1', { isCheckBoxGrid: false }, [
        column.create('출하지시키', 'SALOUTKEY', { width: 80, hidden: true }),
        column.create('품목코드', 'ITEMCD', { width: 80, hidden: true }),
        column.create('품번', 'ITEMNUM', { width: 170 }),
        column.create('품명', 'ITEMNM', { width: 300, hidden: true }),
        column.create('요청', 'OUTQTY', { width: 50, columnType: enumColumnTypes.number }),
        column.create('스캔', 'SCANQTY', { width: 50, columnType: enumColumnTypes.number }),
    ]);

    ItsGrid.Create('grid2', {}, [
        column.create('로트번호', 'LOTKEY', { width: 80, hidden: true }),
        column.create('UDI', 'UDI', { width: 150 }),
        column.create('반입수량', 'LOTQTY', { width: 80, columnType: enumColumnTypes.number, decimalPrecision: 0 }),
        column.create('삭제', 'CANCLE', { width: 60, columnType: enumColumnTypes.button, iconCls: 'fa-times' }),
    ]);

    // 그리드 Row 높이 수정
    ItsGrid.Get('grid2').formatItem.addHandler(function (s, e) {
        for (var i = 0; i < ItsGrid.Length('grid2'); i++) {
            ItsGrid.Get('grid2').rows[i].height = 66;
        }
    });

    // 그리드_자동줄넘김
    ItsGrid.Get('grid2').getColumn('UDI').multiLine = true;
    ItsGrid.Get('grid2').getColumn('UDI').wordWrap = true;
};
//***********************************************************************************************
// 이전화면 이동
ItsButton.Event('MOVE_BACK').onClick = function () {
    location.href = '../PDA_MENU/PDA_MENU.aspx';
};
//***********************************************************************************************
// 반입전표 조회
ItsButton.Event('btn_LIST_SALODRD').onClick = function () {
    var maria = new ItsMaria('PDA1500_R01', 'LIST_SALODRD');

    maria.AddParam('SALODRTP', ItsCombo.GetValue('cmb_SALODRTP'));
    maria.AddParam('CUSTWARE', ItsCombo.GetValue('cmb_CUSTWARE'));

    maria.CallProc();

    if (maria.isError) {
        maria.ShowErrMsg();
        return;
    }

    ItsGrid.SetStore('grid3', maria.store);

    ItsGrid.Get('grid3').autoSizeColumns();
}

ItsText.Event('CUSTCD').onKeyEnter = function (value, oldValue) {
    ItsButton.Event('btn_LIST_SALOUT').onClick();
};
//***********************************************************************************************
// 반입전표 선택시
ItsButton.Event('btn_SELECT_SALODRD').onClick = function () {
    if (ItsGrid.GetCurrentIndex('grid3') < 0)
        return;
    ItsPop.Open('pop2');
}

// 출하지시 조회 
var LIST_SALOUT_ITEM = function () {
    var maria = new ItsMaria('PDA1500_R01', 'LIST_SALOUT_ITEM');

    maria.AddParam('SALODRDKEY', ItsGrid.GetValue('grid3', ItsGrid.GetCurrentIndex('grid3'), "SALODRDKEY"));

    maria.CallProc();

    if (maria.isError) {
        maria.ShowErrMsg();
        return;
    }

    ItsGrid.SetStore('grid1', maria.store);
}

ItsPop.Event('pop2').onPopOpened = function () {
    LIST_SALOUT_ITEM();
}

ItsPop.Event('pop2').onPopClosed = function () {
    ItsButton.Event('btn_LIST_SALOUT').onClick();
}
//***********************************************************************************************
//품목선택시
ItsButton.Event('btn_SELECT_ITEMCD').onClick = function () {
    if (ItsGrid.GetCurrentIndex('grid1') < 0)
        return;
    ItsPop.Open('pop1');
}

ItsPop.Event('pop1').onPopOpened = function () {
    LIST_SALOUTLOT();
}

var LIST_SALOUTLOT = function () {
    var maria = new ItsMaria('PDA1500_R01', 'LIST_SALOUTLOT');

    maria.AddParam('SALOUTKEY', ItsGrid.GetValue('grid1', ItsGrid.GetCurrentIndex('grid1'), "SALOUTKEY"));
    maria.AddParam('ITEMCD', ItsGrid.GetValue('grid1', ItsGrid.GetCurrentIndex('grid1'), "ITEMCD"));

    maria.CallProc();

    if (maria.isError) {
        maria.ShowErrMsg();
        return;
    }
    ItsGrid.SetStore('grid2', maria.store);

    var qty = 0;
    if (maria.storeExtend1.Length() > 0)
        qty = maria.storeExtend1.data[0]['LOTQTY'];

    ItsText.SetValue('CUSTNM', ItsGrid.GetValue('grid3', ItsGrid.GetCurrentIndex('grid3'), "CUSTNM"));
    ItsText.SetValue('ITEMNUM', ItsGrid.GetValue('grid1', ItsGrid.GetCurrentIndex('grid1'), "ITEMNUM"));
    ItsText.SetValue('ITEMNM', ItsGrid.GetValue('grid1', ItsGrid.GetCurrentIndex('grid1'), "ITEMNM"));
    ItsText.SetValue('OUTQTY', ItsGrid.GetValue('grid1', ItsGrid.GetCurrentIndex('grid1'), "OUTQTY"));
    ItsText.SetValue('LOTQTY', qty);
    ItsText.SetValue('txt_SCAN', '');
    ItsNum.SetValue('num_OUTQTY', '');

    ItsText.Focus('txt_SCAN');
}

ItsPop.Event('pop1').onPopClosed = function () {   
    LIST_SALOUT_ITEM();
}

//***********************************************************************************************
//반입등록
ItsButton.Event('btn_SALOUTLOT').onClick = function () {
    var maria = new ItsMaria('PDA1500_R01', 'ADD_SALOUTLOT');

    maria.AddParam('SALOUTKEY', ItsGrid.GetValue('grid1', ItsGrid.GetCurrentIndex('grid1'), "SALOUTKEY"));
    maria.AddParam('UDI', ItsText.GetValue('txt_SCAN'));
    maria.AddParam('CUSTWARE', ItsCombo.GetValue('cmb_CUSTWARE'));

    var LOTQTY = 0;
    if (ItsNum.GetValue('num_LOTQTY') != '' || ItsNum.GetValue('num_LOTQTY') > 0) {
        LOTQTY = ItsNum.GetValue('num_LOTQTY');
    }    

    maria.AddParam('LOTQTY', LOTQTY);

    maria.CallProc();

    if (maria.isError) {
        maria.ShowErrMsg();
        return;
    }

    LIST_SALOUTLOT();

}
// 반입 삭제
ItsGrid.Event('grid2').onButtonClick = function (r, c) {
    if (c == 'CANCLE') {
        ItsMsg.Confirm('삭제하시겠습니까?', function () {
            var maria = new ItsMaria('PDA1500_R01', 'LOT_DEL');

            maria.AddParam('SALOUTKEY', ItsGrid.GetValue('grid1', ItsGrid.GetCurrentIndex('grid1'), "SALOUTKEY"));
            maria.AddParam('LOTKEY', ItsGrid.GetValue('grid2', r, 'LOTKEY'));

            maria.CallProc();

            if (maria.isError) {
                maria.ShowErrMsg();
                return;
            }

            LIST_SALOUTLOT();
        });
    }
};
//***********************************************************************************************
//반입완료
ItsButton.Event('btn_FINISH_SALOUT').onClick = function () {

    ItsMsg.Confirm('반입완료 하시겠습니까?', function () {
        var maria = new ItsMaria('PDA1500_R01', 'FINISH_SALOUT');

        maria.AddParam('SALOUTKEY', ItsGrid.GetValue('grid1', ItsGrid.GetCurrentIndex('grid1'), "SALOUTKEY"));    
        maria.AddParam('CUSTWARE', ItsCombo.GetValue('cmb_CUSTWARE'));
        
        maria.CallProc();
        if (maria.isError) {
            maria.ShowErrMsg();
            return;
        }

        ItsMsg.Toast('반입완료.');

        LIST_SALOUT_ITEM();
    });

}
//반입완료 취소
ItsButton.Event('btn_CANCEL_SALOUT').onClick = function () {

    ItsMsg.Confirm('취소하시겠습니까?', function () {
        var maria = new ItsMaria('PDA1500_R01', 'CANCEL_SALOUT');

        maria.AddParam('SALOUTKEY', ItsGrid.GetValue('grid1', ItsGrid.GetCurrentIndex('grid1'), "SALOUTKEY"));

        maria.CallProc();

        if (maria.isError) {
            maria.ShowErrMsg();
            return;
        }


        ItsMsg.Toast('반입완료 취소.');

        ItsPop.Close('pop1');


        LIST_SALOUT_ITEM();
    });

}
//***********************************************************************************************
//전표완료
ItsButton.Event('btn_FINISH_SALODRD').onClick = function () {

    ItsMsg.Confirm('전표완료 하시겠습니까?', function () {
        var maria = new ItsMaria('PDA1500_R01', 'FINISH_SALODRD');

        maria.AddParam('SALODRDKEY', ItsGrid.GetValue('grid3', ItsGrid.GetCurrentIndex('grid3'), "SALODRDKEY"));
        maria.AddParam('CUSTWARE', ItsCombo.GetValue('cmb_CUSTWARE'));

        maria.CallProc();

        if (maria.isError) {
            maria.ShowErrMsg();
            return;
        }

        // IF 전송 호출
        // 출하 수불 IF
        var mariaIF = new ItsMaria();
        mariaIF.AddQuery("CALL IFR_SALOUTLOT(); ");
        mariaIF.CallProcIF();
        if (mariaIF.isError) {
            mariaIF.ShowErrMsg();
            return;
        }

        // 전표상태수정 IF
        mariaIF = new ItsMaria();
        mariaIF.AddQuery("CALL IFR_SALOUTSTATE('" + maria.store.data[0]["SALODRDKEY"] + "', '" + maria.store.data[0]["SALODRTP"] + "', '" + maria.store.data[0]["MTIME"] + "', '" + maria.store.data[0]["MEMP"] + "', '" + maria.store.data[0]["MODSTT"] + "'); ");
        mariaIF.CallProcIF();
        if (mariaIF.isError) {
            mariaIF.ShowErrMsg();
            return;
        }

        ItsButton.Event('btn_LIST_SALODRD').onClick();

        ItsMsg.Toast('전표완료.');
    });

}