<%@ Page Language="C#" AutoEventWireup="true" CodeFile="index.aspx.cs" Inherits="index" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml" style="overflow-y:scroll;">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <meta http-equiv="Cache-Control" content="no-cache">
    <meta name="viewport" content="width=device-width, user-scalable=no">
    <title>S&S 2공장 MES</title>
    <link rel="stylesheet" type="text/css" href="../css/new_main.css?ver=<%= BasePage.srcVersion %>" />
    <link rel="stylesheet" type="text/css" href="../css/font-awesome.min.css" />
    <link rel="stylesheet" type="text/css" href="./css/login.css?ver=<%= BasePage.srcVersion %>" />
    <script type="text/javascript" src="../../UserControl/ItsPage.js?ver=<%= BasePage.srcVersion %>"></script>
    <script type="text/javascript" src="../../UserControl/ItsMaria.js?ver=<%= BasePage.srcVersion %>"></script>
    <script type="text/javascript" src="./js/portal.js?ver=<%= BasePage.srcVersion %>"></script>
    <!-- new_add -->
    <script type="text/javascript" src="../js/jquery-2.2.4.min.js"></script>
    <script type="text/javascript" src="../js/jquery-ui.min.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $('#login_id').val(GET_COOKIE('SAVE_ID'));

            //$('input:radio[name=chk_system]').removeAttr("checked");
            //var chk_system = 'ERP';
            //chk_system = GET_COOKIE('SELECT_SYSTEM');
            //if (chk_system == '' || chk_system == undefined) {
            //    chk_system = 'ERP';
            //}
            //$('input:radio[name=chk_system]:input[value=' + chk_system + ']').prop('checked', true);

            if (GET_COOKIE('SAVE_ID') != '') $('#id_save_new2').prop('checked', true);
                       
            $('#btn_view').hide();

            $('#login_pw').on('keydown', function (key) {
                if (key.keyCode == 13) {                    
                    login();
                }
            })
        });

        $(document).on('change', 'input[name="chk_system"]:radio', function () {
            //라디오 버튼 값을 가져온다.
            if (this.value == 'TAL') {
                $('#login_id').show();
                $('#login_pw').show();

                $('#btn_login').show();
                $('#btn_view').hide();


                $('#login_id').val('');
                $('#login_pw').val('');
            }
            else if (this.value == 'MES') {
                $('#login_id').show();
                $('#login_pw').show();

                $('#btn_login').show();
                $('#btn_view').hide();

                $('#login_id').val('');
                $('#login_pw').val('');
            }
            else if (this.value == 'MONITOR') {
                $('#login_id').hide();
                $('#login_pw').hide();
                $('#btn_login').hide();
                $('#btn_view').show();
                $('#login_id').val('admin');
                $('#login_pw').val('1234');
            }
        });  

        function monitor() {
            var popUrl = "/PAGECOM/MONITOR/Monitoring.aspx";
            window.open(popUrl, 'Monitoring', 'height=' + screen.height + ',width=' + screen.width + 'fullscreen=yes');
        }
    </script>
</head>
<body>
	<div class="wrap">
		<div class="login_box">
            <div class="login_logo">
                <div class="menu_logo"><img src="../../images/menu/logo.png" /></div>
                <div class="logo_text1"></div>
                <div class="logo_text2"></div>
            </div>
			<h1 class="title1">Welcome!</h1>
            <h1 class="title2"></h1>
            <h1 class="title2"> S&S 2공장 MES SYSTEM</h1>

			<div class="chk_system">
                <label><input type="radio" name="chk_system" value="MES" checked="checked"/><span>MES</span></label>
                <label><input type="radio" name="chk_system" value="TAL"/><span>태블릿</span></label>
                <%--<label><input type="radio" name="chk_system" value="MONITOR"/><span>모니터링</span></label>--%>
            </div>

			<input type="text" name="" id="login_id"  placeholder="아이디를 입력하세요." />
			<input type="password" name="" id="login_pw" placeholder="비밀번호를 입력하세요." />
			
            <div class="check_Box4">
                <input type="checkbox" id="id_save_new2" name="id_save_new2"/>
                <label for="id_save_new2">아이디 저장</label>
            </div>

            <button onclick="login(this)" id="btn_login">로그인</button>
            <button onclick="monitor(this)" id="btn_view">VIEW</button>
     
            <div class="errmsg">
                <span id="login_errMsg"></span>
            </div>
		</div>
	</div>
</body>
</html>
