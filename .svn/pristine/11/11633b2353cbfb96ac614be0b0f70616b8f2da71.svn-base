
function login() {
    var maria = new ItsMaria('WEBSYSLOGIN', 'MAIN_LOGIN');
    maria.AddParam('USERID', $('#login_id').val());
    maria.AddParam('USERPASS', $('#login_pw').val());
    maria.AddParam('NEWPASS', $('#login_pw_new').val());
    maria.AddParam('NEWPASS2', $('#login_pw_new2').val());
    maria.AddParam("---", "---");
    maria.CallProcCenter();
    if (maria.isError) {
        $('#login_errMsg').html('<img src="../images/login_error.png" /><span>' + maria.errMessage + '</span>');
        if (maria.errMessage.indexOf('변경할 패스워드 입력 후 로그인 하세요') > -1 || maria.errMessage.indexOf('패스워드를 변경 한지 3개월 이상 되었습니다. 패스워드 변경 후 로그인 하세요') > -1) {
            $('.log_mod_pass').show();
            $('#id_save_new2').parent().hide();
        } else if (maria.errMessage.indexOf('변경된 패스워드로 로그인 하세요.') > -1) {
            $('.login_pw_new').val('');
            $('.login_pw_new2').val('');
            $('.log_mod_pass').hide();
        }
        return;
    } else {
        SET_COOKIE('MPUSERNM', maria.storeExtend1.data[0].EMPNM);
        SET_COOKIE('MPUSERDEPT', maria.storeExtend1.data[0].DEPTNM);
        SET_COOKIE('MPUSERJOBGRADE', maria.storeExtend1.data[0].JOBGRADE);
        SET_COOKIE('MPUSERIMG', maria.storeExtend1.data[0].IMGURL);
        SET_COOKIE('MPUSERAUT', maria.storeExtend1.data[0].AUTCD);
        SET_COOKIE('MPUSERMAIL', maria.storeExtend1.data[0].MAIL);
        SET_COOKIE('WORKCOMP', maria.storeExtend1.data[0].WORKCOMP);

        SET_COOKIE('SELECT_SYSTEM', $("input[name='chk_system']:checked").val());

        var url = '../MAIN/main.aspx';

        if ($("input[name='chk_system']:checked").val() == 'TAL') {
            url = '../MAIN/main_Kiosk.aspx';
        }
        //else if ($("input[name='chk_system']:checked").val() == 'GW') {
        //    url = '../../PAGEGWS/GWS0000/GWS0000_R01.aspx';
        //}

        if ($('#id_save_new2').prop('checked')) {
            SET_COOKIE('SAVE_ID', $('#login_id').val());
        } else {
            SET_COOKIE('SAVE_ID', '');
        }

        location.href = url;
    }
}


//function logout() {
//    var l = confirm('로그아웃 하시겠습니까?');
//    if (l) {
//        var maria = new ItsMaria('WEBSYSLOGIN', 'LOGOUT');
//        maria.AddParam("---", "---");
//        maria.AddSessionLoginKey();
//        maria.CallProcCenter();
//        if (maria.isError) {
//            maria.ShowErrMsg();
//            return;
//        }
//        SET_COOKIE('MPUSERNM', '', -1);
//        SET_COOKIE('MPUSERDEPT', '', -1);
//        SET_COOKIE('MPUSERJOBGRADE', '', -1);
//        SET_COOKIE('MPUSERIMG', '', -1);
//        SET_COOKIE('MPUSERAUT', '', -1);
//        SET_COOKIE('MPUSERMAIL', '', -1);
//        location.href = "../../PAGECOM/PORTAL/index.aspx";
//    }
//};

