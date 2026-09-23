/// <reference path="../../Script/reference.js" />

/* 페이지 접근 시 수행 */
ItsPage.Load = function () {
    ItsGrid.Create('grid1', { isCheckBoxGrid: false, isSubTotalGrid: true }, [
        column.create('점검시간', 'CHKTIME', { width: 150, align: 'center' }),
        column.create('점검자', 'EMPCD', { width: 110, align: 'center', columnType: enumColumnTypes.combo, gpcd: 'EMPCD' }),
        column.create('점검키', 'CHKRSTKEY', { width: 150, align: 'center', hidden: true }),
    ]);

    ItsGrid.Create('grid2', { isCheckBoxGrid: false, isSubTotalGrid: true }, [
        column.create('점검키', 'CHKRSTKEY', { width: 150, align: 'center', hidden: true }),
        column.create('점검명', 'CHKKNDNM', { width: 150, align: 'center' }),
        column.create('점검항목', 'CHKLOC', { width: 110, align: 'center', columnType: enumColumnTypes.combo, gpcd: 'CHKLOC' }),
        column.create('점검방법', 'CHKMTH', { width: 110, align: 'center', columnType: enumColumnTypes.combo, gpcd: 'CHKMTH' }),
        column.create('점검값', 'CHKVALUE', { width: 110, align: 'center' }),
        column.create('점검주기', 'CHKCYCLE', { width: 110, align: 'center', columnType: enumColumnTypes.combo, gpcd: 'CHKCYCLE' }),
        column.create('비고', 'REMARK', { width: 110, align: 'center' }),
    ]);

    ItsGrid.Create('grid3', { isCheckBoxGrid: false, isSubTotalGrid: false }, [
        column.create('순번', 'SORTNO', { width: 60, align: 'center'}),
        column.create('점검키', 'CHKRSTKEY', { width: 250, align: 'center', hidden: true }),
        column.create('점검명', 'CHKKNDNM', { width: 150, align: 'center' }),
        column.create('점검항목', 'CHKLOC', { width: 150, align: 'center', columnType: enumColumnTypes.combo, gpcd: 'CHKLOC' }),
        column.create('점검방법', 'CHKMTH', { width: 150, align: 'center', columnType: enumColumnTypes.combo, gpcd: 'CHKMTH' }),
        column.create('점검값구분', 'CHKVALTP', { width: 150, align: 'center', columnType: enumColumnTypes.combo, gpcd: 'CHKVALTP' }),
        column.create('점검주기', 'CHKCYCLE', { width: 110, align: 'center', columnType: enumColumnTypes.combo, gpcd: 'CHKCYCLE' }),
        column.create('점검값', 'CHKVALUE', { width: 110, align: 'center' }),

        column.create('비고', 'REMARK', { width: 250, align: 'center' }),
    ]);

    ItsGrid.Create('grid4', { isCheckBoxGrid: false, isSubTotalGrid: false }, [
        column.create('순번', 'SORTNO', { width: 60, align: 'center' }),
        column.create('점검키', 'CHKRSTKEY', { width: 250, align: 'center', hidden: true }),
        column.create('점검명', 'CHKKNDNM', { width: 150, align: 'center' }),
        column.create('점검항목', 'CHKLOC', { width: 150, align: 'center', columnType: enumColumnTypes.combo, gpcd: 'CHKLOC' }),
        column.create('점검방법', 'CHKMTH', { width: 150, align: 'center', columnType: enumColumnTypes.combo, gpcd: 'CHKMTH' }),
        column.create('점검값구분', 'CHKVALTP', { width: 150, align: 'center', columnType: enumColumnTypes.combo, gpcd: 'CHKVALTP' }),
        column.create('점검주기', 'CHKCYCLE', { width: 110, align: 'center', columnType: enumColumnTypes.combo, gpcd: 'CHKCYCLE' }),
        column.create('점검값', 'CHKVALUE', { width: 110, align: 'center' }),

        column.create('비고', 'REMARK', { width: 250, align: 'center' }),
    ]);



    // 페이지가 열릴때 자동적으로 설비 목록 띄우기
    LIST_EQMCD_BUTTON();
    
    $('input#date_RANGEDATE_F').prop('disabled', true);
    $('input#date_RANGEDATE_T').prop('disabled', true);
    ItsFind.Disable('find_EMPCD');
    ItsButton.Disable('btn_SEARCH');
    ItsButton.Disable('btn_REG');
    ItsButton.Disable('btn_EDIT');
    ItsButton.Disable('btn_DELETE');
    ItsButton.Disable('btn_REMARK');
   

};
// 상단에 설비목록
LIST_EQMCD_BUTTON = function () {

    var maria = new ItsMaria('TAL0001_R05', 'LIST_EQMCD');


    maria.CallProc();

    if (maria.isError) {
        maria.ShowErrMsg();
        return;
    }

    $('#EQM_LIST').empty();

    for (var i = 0; i < maria.store.Length(); i++) {

        var EQMCD = maria.store.data[i].EQMCD;
        var EQMNM = maria.store.data[i].EQMNM;

        var html = '';

        html += '<button ';
        html += 'class="eqm-btn" ';
        html += 'data-EQMCD="' + EQMCD + '">';

        html += EQMCD;
        html += '<br>';
        html += EQMNM;

        html += '</button>';

        $('#EQM_LIST').append(html);
    }
};

// 상단에 설비 목록중 하나를 선택할때
$(document).on('click', '.eqm-btn', function () {

    $('.eqm-btn').removeClass('active');
    $(this).addClass('active');

    var EQMCD = $(this).data('eqmcd');

    $('input#date_RANGEDATE_F').prop('disabled', false);
    $('input#date_RANGEDATE_T').prop('disabled', false);

    ItsFind.Enable('find_EMPCD');

    ItsButton.Enable('btn_SEARCH');
    ItsButton.Enable('btn_REG');
    ItsButton.Enable('btn_EDIT');
    ItsButton.Enable('btn_DELETE');
    ItsButton.Enable('btn_REMARK');

    SEARCH_LIST();
});


// 조회 버튼 클릭
SEARCH_LIST = function () {
    ItsGrid.Clear('grid1');
    ItsGrid.Clear('grid2');
    var EQMCD = $('.eqm-btn.active').data('eqmcd');

    var maria = new ItsMaria('TAL0001_R05', 'LIST_CHKRSTEQM');
    maria.AddParam('EQMCD', EQMCD);
    maria.AddPanel('div1');
    
    maria.CallProc();
    if (maria.isError) {
        maria.ShowErrMsg();
        return;
    }
    ItsGrid.SetStore('grid1', maria.store);
    ItsMsg.Toast(ItsMsg.CommonMsg.SearchComplete(maria.store.Length()));
    ItsGrid.Get('grid1').autoSizeColumns();
}

// 좌측 그리드 선택시 
ItsGrid.Event('grid1').onSelect = function (rowIndex) {
    ItsGrid.Clear('grid2');
    var maria = new ItsMaria('TAL0001_R05', 'LIST_CHKRSTEQMKND');
    maria.AddParam('CHKRSTKEY', ItsGrid.GetValue('grid1', rowIndex, 'CHKRSTKEY'));

    maria.CallProc();
    if (maria.isError) {
        maria.ShowErrMsg();
        return;
    }
    ItsGrid.SetStore('grid2', maria.store);
    ItsMsg.Toast(ItsMsg.CommonMsg.SearchComplete(maria.store.Length()));
    ItsGrid.Get('grid2').autoSizeColumns();

}

// 조회버튼 클릭
ItsButton.Event('btn_SEARCH').onClick = function () {
    SEARCH_LIST();
}

// 점검버튼 클릭
ItsButton.Event('btn_REG').onClick = function () {
    ItsGrid.Clear('grid3');
    var EQMCD = $('.eqm-btn.active').data('eqmcd');

    var maria = new ItsMaria('TAL0001_R05', 'LIST_CHKPLANEQM');
  
    maria.AddParam('EQMCD', EQMCD);


    maria.CallProc();
    if (maria.isError) {
        maria.ShowErrMsg();
        
        return;
    }
    
    
    ItsGrid.SetStore('grid3', maria.store);
    ItsPop.Open('pop1');
    ItsMsg.Toast(ItsMsg.CommonMsg.SearchComplete(maria.store.Length()));
    //ItsGrid.Get('grid3').autoSizeColumns();
}


ItsGrid.Event('grid3').onDoubleClick = function (rowIndex, field) {
    var CHKVALTP = ItsGrid.GetValue('grid3', rowIndex, 'CHKVALTP');

    if (CHKVALTP == '01') {
        ItsPop.Open('pop_NUM');
    } else {
        ItsPop.Open('pop_OK');
    }
}


// 숫자 팝업창 동작
ItsButton.Event('btn_DOT_TAL0001_R05').onClick = function () {
    var GOODQTY = ItsText.GetValue('txt_GOODQTY_TAL0001_R05');
    if (GOODQTY == '') {
        ItsNum.SetValue('txt_GOODQTY_TAL0001_R05', GOODQTY + '0.');
    }
    else {
    ItsNum.SetValue('txt_GOODQTY_TAL0001_R05', GOODQTY + '.');
    }
};

ItsButton.Event('btn_1_TAL0001_R05').onClick = function () {
    var GOODQTY = ItsText.GetValue('txt_GOODQTY_TAL0001_R05');
    ItsNum.SetValue('txt_GOODQTY_TAL0001_R05', GOODQTY + '1');
};
ItsButton.Event('btn_2_TAL0001_R05').onClick = function () {
    var GOODQTY = ItsText.GetValue('txt_GOODQTY_TAL0001_R05');
    ItsNum.SetValue('txt_GOODQTY_TAL0001_R05', GOODQTY + '2');
};
ItsButton.Event('btn_3_TAL0001_R05').onClick = function () {
    var GOODQTY = ItsText.GetValue('txt_GOODQTY_TAL0001_R05');
    ItsNum.SetValue('txt_GOODQTY_TAL0001_R05', GOODQTY + '3');
};
ItsButton.Event('btn_4_TAL0001_R05').onClick = function () {
    var GOODQTY = ItsText.GetValue('txt_GOODQTY_TAL0001_R05');
    ItsNum.SetValue('txt_GOODQTY_TAL0001_R05', GOODQTY + '4');
};
ItsButton.Event('btn_5_TAL0001_R05').onClick = function () {
    var GOODQTY = ItsText.GetValue('txt_GOODQTY_TAL0001_R05');
    ItsNum.SetValue('txt_GOODQTY_TAL0001_R05', GOODQTY + '5');
};
ItsButton.Event('btn_6_TAL0001_R05').onClick = function () {
    var GOODQTY = ItsText.GetValue('txt_GOODQTY_TAL0001_R05');
    ItsNum.SetValue('txt_GOODQTY_TAL0001_R05', GOODQTY + '6');
};
ItsButton.Event('btn_7_TAL0001_R05').onClick = function () {
    var GOODQTY = ItsText.GetValue('txt_GOODQTY_TAL0001_R05');
    ItsNum.SetValue('txt_GOODQTY_TAL0001_R05', GOODQTY + '7');
};
ItsButton.Event('btn_8_TAL0001_R05').onClick = function () {
    var GOODQTY = ItsText.GetValue('txt_GOODQTY_TAL0001_R05');
    ItsNum.SetValue('txt_GOODQTY_TAL0001_R05', GOODQTY + '8');
};
ItsButton.Event('btn_9_TAL0001_R05').onClick = function () {
    var GOODQTY = ItsText.GetValue('txt_GOODQTY_TAL0001_R05');
    ItsNum.SetValue('txt_GOODQTY_TAL0001_R05', GOODQTY + '9');
};
ItsButton.Event('btn_0_TAL0001_R05').onClick = function () {
    var GOODQTY = ItsText.GetValue('txt_GOODQTY_TAL0001_R05');
    if (GOODQTY != '')
        ItsNum.SetValue('txt_GOODQTY_TAL0001_R05', GOODQTY + '0');
};
ItsButton.Event('btn_00_TAL0001_R05').onClick = function () {
    var GOODQTY = ItsText.GetValue('txt_GOODQTY_TAL0001_R05');
    if (GOODQTY != '')
        ItsNum.SetValue('txt_GOODQTY_TAL0001_R05', GOODQTY + '00');
};
ItsButton.Event('btn_DEL_TAL0001_R05').onClick = function () {
    var GOODQTY = ItsText.GetValue('txt_GOODQTY_TAL0001_R05');
    var LENGTH = GOODQTY.length;
    if (LENGTH != 0) {
        GOODQTY = GOODQTY.substring(0, LENGTH - 1);
        ItsNum.SetValue('txt_GOODQTY_TAL0001_R05', GOODQTY);
    }
};
ItsButton.Event('btn_CLEAR_TAL0001_R05').onClick = function () {
    ItsText.SetValue('txt_GOODQTY_TAL0001_R05', '');
};

ItsButton.Event('btn_ADDRST_TAL0001_R05').onClick = function () {

    var GOODQTY = ItsNum.GetValue('txt_GOODQTY_TAL0001_R05');

 
    var rowIndex = ItsGrid.GetCurrentIndex('grid3');

    ItsGrid.SetValue('grid3', rowIndex, 'CHKVALUE', GOODQTY);

    ItsPop.Close('pop_NUM');
    ItsText.SetValue('txt_GOODQTY_TAL0001_R05', '');

};

ItsButton.Event('btn_ADDRST2_TAL0001_R05').onClick = function () {

    var GOODQTY = ItsNum.GetValue('txt_GOODQTY_TAL0001_R05');


    var rowIndex = ItsGrid.GetCurrentIndex('grid3');

    ItsGrid.SetValue('grid3', rowIndex, 'CHKVALUE', GOODQTY);

    ItsPop.Close('pop_NUM');
    ItsText.SetValue('txt_GOODQTY_TAL0001_R05', '');

};

ItsButton.Event('btn_OK_TAL0001_R05').onClick = function () {
   
    var rowIndex = ItsGrid.GetCurrentIndex('grid3');

    ItsGrid.SetValue('grid3', rowIndex, 'CHKVALUE', 'OK');

    ItsPop.Close('pop_OK');

};
ItsButton.Event('btn_NG_TAL0001_R05').onClick = function () {

    var rowIndex = ItsGrid.GetCurrentIndex('grid3');

    ItsGrid.SetValue('grid3', rowIndex, 'CHKVALUE', 'NG');

    ItsPop.Close('pop_OK');

};


ItsPop.Event('pop1').onCancelBtnClick = function () {
    ItsPage.InitData('pdiv1');
    ItsPop.Close('pop1');
}

ItsPop.Event('pop1').onAddBtnClick = function () {
    var EQMCD = $('.eqm-btn.active').data('eqmcd');
    
    var maria = new ItsMaria('TAL0001_R05', 'SAVE_CHKPLANEQM');

    maria.AddPanel('pdiv1');
    maria.AddParam('EQMCD', EQMCD);
    for (var i = 0; i < ItsGrid.Length('grid3'); i++) {
        maria.AddList('SORTNO_LIST', ItsGrid.GetValue('grid3', i, 'SORTNO'));
        maria.AddList('CHKKNDCD_LIST', ItsGrid.GetValue('grid3', i, 'CHKKNDCD'));
        maria.AddList('CHKKNDNM_LIST', ItsGrid.GetValue('grid3', i, 'CHKKNDNM'));
        maria.AddList('CHKLOC_LIST', ItsGrid.GetValue('grid3', i, 'CHKLOC'));
        maria.AddList('CHKMTH_LIST', ItsGrid.GetValue('grid3', i, 'CHKMTH'));
        maria.AddList('CHKVALTP_LIST', ItsGrid.GetValue('grid3', i, 'CHKVALTP'));
        maria.AddList('CHKCYCLE_LIST', ItsGrid.GetValue('grid3', i, 'CHKCYCLE'));
        maria.AddList('CHKVALUE_LIST', ItsGrid.GetValue('grid3', i, 'CHKVALUE'));
        maria.AddList('REMARK_LIST', ItsGrid.GetValue('grid3', i, 'REMARK'));
    }

    maria.CallProc();

    if (maria.isError) {
        maria.ShowErrMsg();
        return;
    }

    ItsPop.Close('pop1');
    SEARCH_LIST();
}



///////////////////////////////////////////////////////////////////////////////////////////////////////////////// 수정 
// 점검버튼 클릭
ItsButton.Event('btn_EDIT').onClick = function () {
    ItsGrid.Clear('grid4');

    var CHKRSTKEY = ItsGrid.GetValue('grid1', ItsGrid.GetCurrentIndex('grid1'), 'CHKRSTKEY');
    if (CHKRSTKEY == '' || CHKRSTKEY == undefined || CHKRSTKEY == null) {
        return;
    }

    var maria = new ItsMaria('TAL0001_R05', 'LIST_UPDATE_CHKPLANEQM');
    maria.AddParam('CHKRSTKEY', CHKRSTKEY);


    maria.CallProc();
    if (maria.isError) {
        maria.ShowErrMsg();
        return;
    }


    ItsGrid.SetStore('grid4', maria.store);
    ItsFind.SetValue('pop2_find_EQMCD', maria.store.data[0]["EQMCD"]);
    ItsDate.SetValue('pop2_date_BASEDATE', maria.store.data[0]["BASEDATE"]);
    ItsFind.SetValue('pop2_find_EMPCD', maria.store.data[0]["EMPCD"]);
    ItsDate.SetValue('pop2_date_REGDATE', maria.store.data[0]["DATE"]);
    ItsText.SetValue('pop2_txt_BASETIME', maria.store.data[0]["TIME"]);



    ItsPop.Open('pop2');
    ItsMsg.Toast(ItsMsg.CommonMsg.SearchComplete(maria.store.Length()));
    //ItsGrid.Get('grid4').autoSizeColumns();
}


ItsGrid.Event('grid4').onDoubleClick = function (rowIndex, field) {
    var CHKVALTP = ItsGrid.GetValue('grid4', rowIndex, 'CHKVALTP');

    if (CHKVALTP == '01') {
        ItsPop.Open('pop_EDIT_NUM');
    } else {
        ItsPop.Open('pop_EDIT_OK');
    }
}


// 숫자 팝업창 동작
ItsButton.Event('btn_DOT_EDIT_TAL0001_R05').onClick = function () {
    var EDITQTY = ItsText.GetValue('txt_EDITQTY_TAL0001_R05');
    if (EDITQTY == '') {
        ItsNum.SetValue('txt_EDITQTY_TAL0001_R05', EDITQTY + '0.');
    }
    else {
        ItsNum.SetValue('txt_EDITQTY_TAL0001_R05', EDITQTY + '.');
    }
};

ItsButton.Event('btn_1_EDIT_TAL0001_R05').onClick = function () {
    var EDITQTY = ItsText.GetValue('txt_EDITQTY_TAL0001_R05');
    ItsNum.SetValue('txt_EDITQTY_TAL0001_R05', EDITQTY + '1');
};
ItsButton.Event('btn_2_EDIT_TAL0001_R05').onClick = function () {
    var EDITQTY = ItsText.GetValue('txt_EDITQTY_TAL0001_R05');
    ItsNum.SetValue('txt_EDITQTY_TAL0001_R05', EDITQTY + '2');
};
ItsButton.Event('btn_3_EDIT_TAL0001_R05').onClick = function () {
    var EDITQTY = ItsText.GetValue('txt_EDITQTY_TAL0001_R05');
    ItsNum.SetValue('txt_EDITQTY_TAL0001_R05', EDITQTY + '3');
};
ItsButton.Event('btn_4_EDIT_TAL0001_R05').onClick = function () {
    var EDITQTY = ItsText.GetValue('txt_EDITQTY_TAL0001_R05');
    ItsNum.SetValue('txt_EDITQTY_TAL0001_R05', EDITQTY + '4');
};
ItsButton.Event('btn_5_EDIT_TAL0001_R05').onClick = function () {
    var EDITQTY = ItsText.GetValue('txt_EDITQTY_TAL0001_R05');
    ItsNum.SetValue('txt_EDITQTY_TAL0001_R05', EDITQTY + '5');
};
ItsButton.Event('btn_6_EDIT_TAL0001_R05').onClick = function () {
    var EDITQTY = ItsText.GetValue('txt_EDITQTY_TAL0001_R05');
    ItsNum.SetValue('txt_EDITQTY_TAL0001_R05', EDITQTY + '6');
};
ItsButton.Event('btn_7_EDIT_TAL0001_R05').onClick = function () {
    var EDITQTY = ItsText.GetValue('txt_EDITQTY_TAL0001_R05');
    ItsNum.SetValue('txt_EDITQTY_TAL0001_R05', EDITQTY + '7');
};
ItsButton.Event('btn_8_EDIT_TAL0001_R05').onClick = function () {
    var EDITQTY = ItsText.GetValue('txt_EDITQTY_TAL0001_R05');
    ItsNum.SetValue('txt_EDITQTY_TAL0001_R05', EDITQTY + '8');
};
ItsButton.Event('btn_9_EDIT_TAL0001_R05').onClick = function () {
    var EDITQTY = ItsText.GetValue('txt_EDITQTY_TAL0001_R05');
    ItsNum.SetValue('txt_EDITQTY_TAL0001_R05', EDITQTY + '9');
};
ItsButton.Event('btn_0_EDIT_TAL0001_R05').onClick = function () {
    var EDITQTY = ItsText.GetValue('txt_EDITQTY_TAL0001_R05');
    if (EDITQTY != '')
        ItsNum.SetValue('txt_EDITQTY_TAL0001_R05', EDITQTY + '0');
};
ItsButton.Event('btn_00_EDIT_TAL0001_R05').onClick = function () {
    var EDITQTY = ItsText.GetValue('txt_EDITQTY_TAL0001_R05');
    if (EDITQTY != '')
        ItsNum.SetValue('txt_EDITQTY_TAL0001_R05', EDITQTY + '00');
};
ItsButton.Event('btn_DEL_EDIT_TAL0001_R05').onClick = function () {
    var EDITQTY = ItsText.GetValue('txt_EDITQTY_TAL0001_R05');
    var LENGTH = EDITQTY.length;
    if (LENGTH != 0) {
        EDITQTY = EDITQTY.substring(0, LENGTH - 1);
        ItsNum.SetValue('txt_EDITQTY_TAL0001_R05', EDITQTY);
    }
};
ItsButton.Event('btn_CLEAR_EDIT_TAL0001_R05').onClick = function () {
    ItsText.SetValue('txt_EDITQTY_TAL0001_R05', '');
};

ItsButton.Event('btn_ADDRST_EDIT_TAL0001_R05').onClick = function () {

    var EDITQTY = ItsNum.GetValue('txt_EDITQTY_TAL0001_R05');


    var rowIndex = ItsGrid.GetCurrentIndex('grid4');

    ItsGrid.SetValue('grid4', rowIndex, 'CHKVALUE', EDITQTY);

    ItsPop.Close('pop_EDIT_NUM');
    ItsText.SetValue('txt_EDITQTY_TAL0001_R05', '');

};

ItsButton.Event('btn_ADDRST2_EDIT_TAL0001_R05').onClick = function () {

    var EDITQTY = ItsNum.GetValue('txt_EDITQTY_TAL0001_R05');


    var rowIndex = ItsGrid.GetCurrentIndex('grid4');

    ItsGrid.SetValue('grid4', rowIndex, 'CHKVALUE', EDITQTY);

    ItsPop.Close('pop_EDIT_NUM');
    ItsText.SetValue('txt_EDITQTY_TAL0001_R05', '');

};

ItsButton.Event('btn_OK_EDIT_TAL0001_R05').onClick = function () {

    var rowIndex = ItsGrid.GetCurrentIndex('grid4');

    ItsGrid.SetValue('grid4', rowIndex, 'CHKVALUE', 'OK');

    ItsPop.Close('pop_EDIT_OK');

};
ItsButton.Event('btn_NG_EDIT_TAL0001_R05').onClick = function () {

    var rowIndex = ItsGrid.GetCurrentIndex('grid4');

    ItsGrid.SetValue('grid4', rowIndex, 'CHKVALUE', 'NG');

    ItsPop.Close('pop_EDIT_OK');

};


ItsPop.Event('pop2').onCancelBtnClick = function () {
    ItsPage.InitData('pdiv2');
    ItsPop.Close('pop2');
}

ItsPop.Event('pop2').onAddBtnClick = function () {
    var EQMCD = ItsFind.GetValue('pop2_find_EQMCD');
    var CHKRSTKEY = ItsGrid.GetValue('grid1', ItsGrid.GetCurrentIndex('grid1'), 'CHKRSTKEY');

    var maria = new ItsMaria('TAL0001_R05', 'UPDATE_CHKPLANEQM');

    maria.AddPanel('pdiv2');
    maria.AddParam('EQMCD', EQMCD);
    maria.AddParam('CHKRSTKEY', CHKRSTKEY);

    for (var i = 0; i < ItsGrid.Length('grid4'); i++) {
        maria.AddList('SORTNO_LIST', ItsGrid.GetValue('grid4', i, 'SORTNO'));
        maria.AddList('CHKKNDCD_LIST', ItsGrid.GetValue('grid4', i, 'CHKKNDCD'));
        maria.AddList('CHKKNDNM_LIST', ItsGrid.GetValue('grid4', i, 'CHKKNDNM'));
        maria.AddList('CHKLOC_LIST', ItsGrid.GetValue('grid4', i, 'CHKLOC'));
        maria.AddList('CHKMTH_LIST', ItsGrid.GetValue('grid4', i, 'CHKMTH'));
        maria.AddList('CHKVALTP_LIST', ItsGrid.GetValue('grid4', i, 'CHKVALTP'));
        maria.AddList('CHKCYCLE_LIST', ItsGrid.GetValue('grid4', i, 'CHKCYCLE'));
        maria.AddList('CHKVALUE_LIST', ItsGrid.GetValue('grid4', i, 'CHKVALUE'));
        maria.AddList('REMARK_LIST', ItsGrid.GetValue('grid4', i, 'REMARK'));
    }

    maria.CallProc();

    if (maria.isError) {
        maria.ShowErrMsg();
        return;
    }

    ItsPop.Close('pop2');
    SEARCH_LIST();
}




///////////////////////////////////////////////////////////////////////////////////////////////////////////////// 삭제
// 삭제버튼 클릭
ItsButton.Event('btn_DELETE').onClick = function () {
    var EQMCD = $('.eqm-btn.active').data('eqmcd');
    var CHKRSTKEY = ItsGrid.GetValue('grid1', ItsGrid.GetCurrentIndex('grid1'), 'CHKRSTKEY');
    if (CHKRSTKEY == '' || CHKRSTKEY == undefined || CHKRSTKEY == null) {
        return;
    }

    var maria = new ItsMaria('TAL0001_R05', 'DELETE_CHKRSTEQM');
    maria.AddParam('CHKRSTKEY', CHKRSTKEY);
    maria.AddParam('EQMCD', EQMCD);

    maria.CallProc();
    if (maria.isError) {
        maria.ShowErrMsg();
        return;
    }
    SEARCH_LIST();


}


///////////////////////////////////////////////////////////////////////////////////////////////////////////////// 문제점/조치사항
// 문제점/조치사항 클릭
ItsButton.Event('btn_REMARK').onClick = function () {
    var EQMCD = $('.eqm-btn.active').data('eqmcd');
    var CHKRSTKEY = ItsGrid.GetValue('grid1', ItsGrid.GetCurrentIndex('grid1'), 'CHKRSTKEY');
    if (CHKRSTKEY == '' || CHKRSTKEY == undefined || CHKRSTKEY == null) {
        return;
    }

    var maria = new ItsMaria('TAL0001_R05', 'LIST_ERR');
    maria.AddParam('CHKRSTKEY', CHKRSTKEY);
    maria.AddParam('EQMCD', EQMCD);

    maria.CallProc();
    if (maria.isError) {
        maria.ShowErrMsg();
        return;
    }

    
    ItsTextArea.SetValue('txtArea_PROBLEM', maria.store.data[0]["PROBLEM"]);
    ItsTextArea.SetValue('txtArea_SOLUTION', maria.store.data[0]["SOLUTION"]);
    ItsPop.Open('pop_PROB_SOL');

}

ItsPop.Event('pop_PROB_SOL').onCancelBtnClick = function () {
    ItsTextArea.SetValue('txtArea_PROBLEM', '');
    ItsTextArea.SetValue('txtArea_SOLUTION', '');
    ItsPop.Close('pop_PROB_SOL');
}

ItsPop.Event('pop_PROB_SOL').onAddBtnClick = function () {
    var EQMCD = $('.eqm-btn.active').data('eqmcd');
    var CHKRSTKEY = ItsGrid.GetValue('grid1', ItsGrid.GetCurrentIndex('grid1'), 'CHKRSTKEY');
    if (CHKRSTKEY == '' || CHKRSTKEY == undefined || CHKRSTKEY == null) {
        return;
    }

    var maria = new ItsMaria('TAL0001_R05', 'ADD_ERR');
    maria.AddParam('CHKRSTKEY', CHKRSTKEY);
    maria.AddParam('EQMCD', EQMCD);

    maria.AddParam('PROBLEM', ItsTextArea.GetValue('txtArea_PROBLEM'));
    maria.AddParam('SOLUTION', ItsTextArea.GetValue('txtArea_SOLUTION'));


    maria.CallProc();
    if (maria.isError) {
        maria.ShowErrMsg();
        return;
    }
    ItsPop.Close('pop_PROB_SOL');
    SEARCH_LIST();
}