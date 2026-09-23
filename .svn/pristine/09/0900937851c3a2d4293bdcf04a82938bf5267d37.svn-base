/**
 * 
 * 재고이동등록
 * 
 * */



/// <reference path="../../Script/reference.js" />

/* 페이지 접근 시 수행 */
ItsPage.Load = function () {
    $('.title-text').html('재고이동등록');

    ItsText.Disable('txt_SCAN_LOTKEY');
    ItsText.Disable('txt_SCAN_LOTQTY');
    ItsCombo.Disable('cmb_WARECD_TO');   
};

// 이전화면 이동
ItsButton.Event('MOVE_BACK').onClick = function () {    
    location.href = '../PDA_MENU/PDA_MENU.aspx';
};

function inputInit() {
    ItsText.SetValue('txt_SCAN_LOTKEY', '');
    ItsText.SetValue('txt_SCAN_LOTQTY', '');
    ItsText.SetValue('txt_SCAN_ITEMCD', '');
    ItsText.SetValue('txt_SCAN_ITEMNM', '');
    ItsText.SetValue('txt_SCAN_CARMODEL', '');
    ItsText.SetValue('txt_SCAN_ITEMUNIT', '');
    ItsText.Focus('txt_SCAN_LOTKEY');
}

// 스캔
ItsText.Event('txt_SCAN_LOTKEY').onKeyEnter = function (value, oldValue) {
    if (!ItsCombo.GetValue('cmb_WARECD_FROM')) {
        ItsMsg.Toast('현창고를 선택 후 스캔해주세요.');
        inputInit();
        return;
    }

    var maria = new ItsMaria('PDA1700_R01', 'SCAN_LOTKEY');

    maria.AddPanel('Div1');

    maria.CallProc();

    if (maria.isError) {
        ItsMsg.Toast(maria.errMessage);
        inputInit();
        return;
    }

    ItsText.SetValue('txt_SCAN_LOTQTY', maria.store.data[0]['LOTQTY']);
    ItsText.SetValue('txt_SCAN_CARMODEL', maria.store.data[0]['CARMODEL']);
    ItsText.SetValue('txt_SCAN_ITEMCD', maria.store.data[0]['ITEMCD']);
    ItsText.SetValue('txt_SCAN_ITEMNM', maria.store.data[0]['ITEMNM']);
    ItsText.SetValue('txt_SCAN_ITEMUNIT', maria.store.data[0]['ITEMUNIT']);
}


// 현창고 선택 시
ItsCombo.Event('cmb_WARECD_FROM').onChanged = function (newValue, oldValue) {
    ItsText.Enable('txt_SCAN_LOTKEY');
    //ItsText.Enable('txt_SCAN_LOTQTY');
    ItsCombo.Enable('cmb_WARECD_TO');
    ItsText.Focus('txt_SCAN_LOTKEY');
    
    if (ItsCombo.GetValue('cmb_WARECD_TO') === ItsCombo.GetValue('cmb_WARECD_FROM')) {
        ItsCombo.SetValue('cmb_WARECD_TO', '');
    }
}

ItsCombo.Event('cmb_WARECD_TO').onChanged = function () {
    ItsText.Focus('txt_SCAN_LOTKEY');
}


// 재고이동
ItsButton.Event('btn_MOVE_COMLOT').onClick = function () {
    var maria = new ItsMaria('PDA1700_R01', 'MOVE_COMLOT');

    maria.AddPanel('Div1'); 

    maria.CallProc();

    if (maria.isError) {
        maria.ShowErrMsg();        
        return;
    }

    inputInit();

    ItsMsg.Toast('재고이동 완료.');    
}

