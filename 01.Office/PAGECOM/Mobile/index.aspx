<%@ Page Language="C#" AutoEventWireup="true" CodeFile="index.aspx.cs" Inherits="index" %>
<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <meta http-equiv="X-UA-Compatible" content="ie=edge">
    <title>YoungJin GroupWare</title>
    <link rel="stylesheet" href="./css/login.css">
    <script type="text/javascript" src="../js/jquery-2.2.4.min.js"></script>
    <script type="text/javascript" src="/UserControl/ItsMaria.js"></script>
    <script type="text/javascript" src="/UserControl/ItsMsg.js"></script>
    <script type="text/javascript" src="./js/common.js?ver=<%= BasePage.srcVersion %>"></script>
    <script type="text/javascript" src="./js/portal.js?ver=<%= BasePage.srcVersion %>"></script>
    <script>
        //if (sessionCheck()) {
        //    goMoblieGW();
        //}
        if (navigator.platform) {
            if ("win16|win32|win64|mac|macintel".indexOf(navigator.platform.toLowerCase()) > -1) {
                console.log("PC접속");
                //location.href = "/PAGECOM/PORTAL/index.aspx";
            }
        }
    </script>
</head>
<body style="background:#f9f9f9;">
	<div class="wrap">
		<div class="login_box">
			<img src="../PORTAL/img/mini_logo.png"><p class="login_title">YOUNG JIN MOBILE <b>GROUPWARE</b></p>
            <div class="input_group">
                <span class="input_title">아이디</span>
			    <input type="text">
            </div>
            <div class="input_group">
                <span class="input_title">비밀번호</span>
			    <input type="password" style="margin-top:12px;">
            </div>
			<p class="check_Box4 textAlignLeft">
                <input type="checkbox" id="save_account">
                <label for="save_account">
                    <span>아이디 저장</span>
                </label>
			</p>
            <div class="button_wrap">
                <div class="button btn3" onclick="mobilelogin(this)">
                    <div class="btn_img">
                        <img src="../PORTAL/img/login_img03.png" />
                    </div>
                    <div class="btn_title">
                        <span class="btn_eng">그룹웨어</span>
                        <span class="btn_ko">업무지원시스템</span>
                    </div>
                </div>
            </div>
		</div>
	</div>
</body>
</html>