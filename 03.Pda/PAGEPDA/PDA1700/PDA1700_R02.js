/**
 * 
 * 재고이동등록
 * 
 * */



/// <reference path="../../Script/reference.js" />

/* 페이지 접근 시 수행 */
ItsPage.Load = function () {
    $('.title-text').html('로트정보조회');

    ItsText.Focus('txt_LOTKEY');

};

// 이전화면 이동
ItsButton.Event('MOVE_BACK').onClick = function () {
    
    location.href = '../PDA_MENU/PDA_MENU.aspx';
};



// 스캔
ItsText.Event('txt_LOTKEY').onKeyEnter = function (value, oldValue) {
    scanSearch();

}
function scanSearch() {
  

    var maria = new ItsMaria('PDA1700_R02', 'COMLOT_LIST');

    maria.AddParam('LOTKEY', ItsText.GetValue('txt_LOTKEY'));
    maria.CallProc();
    
    if (maria.isError) {
        //maria.ShowErrMsg();
        ItsMsg.Toast(maria.errMessage);               
        inputInit();
        return;
    }

    ItsText.SetValue('txt_CUSTCD', maria.store.data[0].CUSTCD);
    ItsText.SetValue('txt_ITEMCD', maria.store.data[0].ITEMCD);
    ItsText.SetValue('txt_SPECNM', maria.store.data[0].SPECNM);
    ItsText.SetValue('txt_SPECNUM', maria.store.data[0].SPECVALUE);
    ItsText.SetValue('txt_SCAN_LOTQTY', maria.store.data[0].LOTQTY);
    ItsText.SetValue('txt_PRCCD', maria.store.data[0].PRCCD);
    ItsText.SetValue('txt_SCAN_ITEMUNIT', maria.store.data[0].ITEMUNIT);
    ItsText.SetValue('txt_EXPDATE', maria.store.data[0].EXPDATE);
    ItsText.SetValue('txt_EXPKIND', maria.store.data[0].DELIVERYTP);

    ItsText.SetValue('txt_LOTKEY', '');    
    ItsText.Focus('txt_LOTKEY');
    
}

