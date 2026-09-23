<%@ Page Language="C#" AutoEventWireup="true" CodeFile="main_Kiosk.aspx.cs" Inherits="Main"  Debug="true" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <meta name="viewport" content="width=device-width, user-scalable=no"/>
    <title>:: S&S 2공장 MES ::</title>
    <link rel="stylesheet" type="text/css" href="../../Script/wijmo5.20203.748/wijmo.min.css" />
    <link rel="stylesheet" type="text/css" href="../../Script/toastr/toastr.min.css?ver=<%= BasePage.srcVersion %>" />
    <link rel="stylesheet" type="text/css" href="../css/font-awesome.min.css" />
    <link rel="stylesheet" type="text/css" href="../css/main_Kiosk.css?ver=<%= BasePage.srcVersion %>" />
    <link rel="stylesheet" type="text/css" href="../../UserControl/ItsMsg.css?ver=<%= BasePage.srcVersion %>" />
    <script type="text/javascript" src="../../UserControl/ItsPage.js?ver=<%= BasePage.srcVersion %>"></script>
    <script type="text/javascript" src="../../UserControl/ItsMaria.js?ver=<%= BasePage.srcVersion %>"></script>
    <!-- new_add -->
    <script type="text/javascript" src="../js/jquery-2.2.4.min.js"></script>
    <script type="text/javascript" src="../js/jquery-ui.min.js"></script>
    <script type="text/javascript" src="../../Script/wijmo5.20203.748/wijmo.min.js"></script>
    <script type="text/javascript" src="../../Script/wijmo5.20203.748/wijmo.nav.min.js"></script>
    <script type="text/javascript" src="../../Script/wijmo5.20203.748/wijmo.input.min.js"></script>
    <script type="text/javascript" src="../js/main_Kiosk.js?ver=<%= BasePage.srcVersion %>"></script>
    <script type="text/javascript" src="../../UserControl/ItsMsg.js?ver=<%= BasePage.srcVersion %>"></script>
    <script type="text/javascript" src="../../Script/toastr/toastr.min.js?ver=<%= BasePage.srcVersion %>"></script>
    <script type="text/javascript" src="../../PAGECOM/PORTAL/js/portal.js"></script>
    <script>
        var $srcVersion = <%= "\"" + BasePage.srcVersion.ToString() + "\"" %>;
        var $userFontSize = <%= "\"" + BasePage.userFontSize.ToString() + "\"" %>;
        
        var MenuListJson = JSON.parse('<%= MenuJson %>');
        var UseMenuJson = JSON.parse('<%= UseMenuJson %>');
        MenuListJson.concat(UseMenuJson);
    </script>
</head>
<body style="height:auto; padding: 0px;">
    <div class="mask"></div>
    <div class="preloader">
        <div class="spinner">
            <span class="spinner-rotate"></span>
        </div>
    </div>

    <div class="main_right">
        <div class="main_right_adminmenu">
            <div class="fullScreen" onclick="fullScreen()">
                <span>전체화면</span>
            </div>
            <div class="windowScreen" onclick="windowScreen()">
                <span>창모드</span>
            </div>
            <div class="loginifo" >
                <span><%= loginUser %>님</span>
            </div>
            <div class="logout_btn" onclick="logout()" >
                <span>로그아웃</span>
            </div>
        </div>
        <div>
            <%--<div id="ope nedTabHome_back"></div>--%>
<%--            <a id="openedTabLeft" href="#" data-prgcd=""data-prgnm="" data-menupath="">
                <i class="fa fa-chevron-left fa-white" aria-hidden="true"></i>
            </a>--%>
            <div id="main_right_tabmenu" class="main_right_tabmenu">
<%--                <div class="opened_menu home">
                    <a  id="openedTabHome" href="#" data-prgcd="SYS0000_R01"data-prgnm="home" data-menupath="../../PAGESYS/SYS0000/SYS0000_R01.aspx">                        
                        <i class="fa fa-home" aria-hidden="true"></i>
                    </a> 
                    <div></div>
                </div>--%>
                <%= myMenuTab %>
            </div>
<%--            <a id="openedTabRight" href="#" data-prgcd=""data-prgnm="" data-menupath="">
                <i class="fa fa-chevron-right fa-white" aria-hidden="true"></i>
            </a>--%>
        </div>
        <div id="m_content" class="m_content">
            <iframe src="../../PAGESYS/SYS0000/SYS0000_R01.aspx" style="width:100%;"></iframe>
        </div>
    </div>
    <div id="modalLayer">
        <div class="modalContent">
            <button id="cancel_login" onclick="cancel_login()">
                <span></span>
                <span></span>
            </button>
            <img id="login_pop_img" src="/images/Login/timeout_icon.png"/>
            <div id="login_pop_txt">로그인 세션이 만료되어<br/>사용자의 새로운 로그인이 필요합니다</div>
            <div class="modal_bottom">
                <div class="m_bottom_depth">
                    <img id="login_id_pop_img" src="/images/Login/id_icon.png"/>
                    <input type="text" id="login_id_pop" name="login_id" title="" value="<%=GetSession("SESSION_USERID") %>" placeholder="아이디 입력" />
                </div>
                <div class="m_bottom_depth">
                    <img id="login_pw_pop_img" src="/images/Login/pass_icon.png"/>
                    <input type="password" id="login_pw_pop" name="login_pw" title="" value="" placeholder="비밀번호 입력" />
                </div>    
                <a href="#" onclick="login_pop_btn()"><span id="login_pop_btn_txt">로그인</span></a>
                <span id="login_errMsg_pop"></span>
            </div>
        </div>
    </div>
    <div id="infoLayer" style="display:none">
        <div class="infoLayer">
            <div class="infoLayer_cancel" onclick="cancel_info()"></div>
            <div class="infoLayer_top">
                <div class="hello">반갑습니다! <%= loginUser %> 님</div>
                <div class="user">
                    <div></div>
                    <div></div>
                </div>
                <div class="mail"><%= emailAddr %></div>
                <div class="passwordform">
                    <div class="curpass">현재 비밀번호</div>
                    <input type="password" id="curpass" placeholder="현재 비밀번호"/>
                    <div class="newpass">새 비밀번호</div>
                    <input type="password" id="newpass" placeholder="새 비밀번호"/>
                    <div class="curpass2">새 비밀번호 확인</div>
                    <input type="password" id="newpass2" placeholder="새 비밀번호 확인"/>
                    <div class="passerr">비밀번호 확인이 필요합니다.</div>
                    <div class="passwordBtn" onclick="passChange()">패스워드 변경</div>
                    <div class="mymenuBtn" onclick="add_iframe('SYS0000_R02', '../../PAGESYS/SYS0000/SYS0000_R02.aspx', '개인환경설정')"><div>개인환경설정</div></div>
                </div>
            </div>
            <div class="infoLayer_bottom">
                <div class="infoLayer_bottom_info">
                    <div class="optisco"></div>
                    <div class="curVersion">
                        <div>Current Version</div>
                        <div><%= BasePage.srcVersion.ToString() %></div>
                    </div>
                    <div class="lastVersion">
                        <div>Latest Version</div>
                        <div id="lastVersion"></div>
                    </div>
                    <div class="copyright">CopyrightⓒITSCO, All rights reserved. Since 2021.</div>
                    <div class="itsco">아이티스코 T. 053-792-1647</div>
                </div>
                <a href="http://itsco.co.kr" target="_blank">
                    <div class="infoLayer_bottom_depth">    
                    </div>
                </a>
            </div>
        </div>
    </div>
</body>
</html>
