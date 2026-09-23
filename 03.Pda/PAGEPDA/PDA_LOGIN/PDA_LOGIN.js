/// <reference path="../../Script/reference.js" />

/* 페이지 접근 시 수행 */
//ItsPage.Load = function () {
//    ItsCombo.SetValue('cmb_BDVCD', GET_COOKIE('BDVCD'));
//};
ItsButton.Event('login_btn').onClick = function () {
    var maria = new ItsMaria('WEBSYSLOGIN', 'MAIN_LOGIN');

    maria.AddParam('USERID', $('#user_id').val());
    maria.AddParam('USERPASS', $('#user_pw').val());
    maria.AddParam('---', '---');

    maria.CallProc();

    if (maria.isError) {
        alert(maria.errMessage);
        return;
    }

    SET_COOKIE('BDVCD', ItsCombo.GetValue('cmb_BDVCD'));
    SET_COOKIE('USERID', ItsText.GetValue('user_id'));

    location.href = '../../PAGEPDA/PDA_MENU/PDA_MENU.aspx';
}