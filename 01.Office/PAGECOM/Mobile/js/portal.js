document.addEventListener('DOMContentLoaded', function () {
    $(".login_box").find('input').eq(0).val(GET_COOKIE('SAVEUSERID'));

    if (GET_COOKIE('SAVEYN') == 'Y') {
        $("input:checkbox[id='save_account']").prop("checked", true);
    }

    //if (location.href.indexOf('GWS') > -1 || location.href.indexOf('GWM') > -1) apprcnt();
});

function mobilelogin(sender) {
    var id = $(sender).parents().find('input').eq(0).val();
    var pw = $(sender).parents().find('input').eq(1).val();
    var maria = new ItsMaria('WEBSYSLOGIN', 'MAIN_LOGIN');
    maria.AddParam('USERID', id);
    maria.AddParam('USERPASS', pw);
    maria.AddParam('ISMOBILE', 'Y');
    maria.AddParam("---", "---");
    maria.CallProcCenter();
    if (maria.isError) {
        alert(maria.errMessage);
        return;
    }

    SET_COOKIE('MPUSERID', id);

    if ($("#save_account").is(':checked') == true) {
        SET_COOKIE('SAVEUSERID', id);
        SET_COOKIE('SAVEYN', 'Y');
    }

    var maria2 = new ItsMaria('GWS0000_R01', 'LOGIN_INFO');
    maria2.AddParam('USERID', id);
    maria2.CallProc();
    if (maria2.isError) {
        maria2.ShowErrMsg();
        return;
    } else {
        var data = maria2.store.data[0];
        SET_COOKIE('MPUSERNM', data.EMPNM);
        SET_COOKIE('MPUSERDEPT', data.DEPTNM);
        SET_COOKIE('MPUSERJOBGRADE', data.JOBGRADE);
        SET_COOKIE('MPUSERIMG', data.IMGURL);
        SET_COOKIE('MPUSERAUT', data.AUTCD);
        SET_COOKIE('MPUSERMAIL', data.MAIL);
    }

    goMoblieGW();
};

function goMoblieGW() {
    location.href = "/PAGEGWM/GWM0000/GWM0000_R01.aspx";
}

function mobilecheck() {
    if (navigator.platform) {
        if ("win16|win32|win64|mac|macintel".indexOf(navigator.platform.toLowerCase()) > -1 && location.href.indexOf('GWS') > -1) {
            var href = location.href.replace(location.href.replace(/GWS/g, 'GWM'));
        } else if("win16|win32|win64|mac|macintel".indexOf(navigator.platform.toLowerCase()) == -1 && location.href.indexOf('GWM') > -1) {
            var href = location.href.replace(location.href.replace(/GWM/g, 'GWS'));
        }
        location.href = href;
    }
}

function logout() {
    var l = confirm('로그아웃 하시겠습니까?');
    if (l) {
        var maria = new ItsMaria('WEBSYSLOGIN', 'LOGOUT');
        maria.AddParam("---", "---");
        maria.AddSessionLoginKey();
        maria.CallProcCenter();
        if (maria.isError) {
            maria.ShowErrMsg();
            return;
        }
        SET_COOKIE('MPUSERNM', '', -1);
        SET_COOKIE('MPUSERDEPT', '', -1);
        SET_COOKIE('MPUSERJOBGRADE', '', -1);
        SET_COOKIE('MPUSERIMG', '', -1);
        SET_COOKIE('MPUSERAUT', '', -1);
        SET_COOKIE('MPUSERMAIL', '', -1);
        location.reload();
    }
}