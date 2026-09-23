<%@ Page Language="C#" AutoEventWireup="true" CodeFile="main.aspx.cs" Inherits="Main"  Debug="true" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <meta name="viewport" content="width=device-width, user-scalable=no"/>
    <title>:: JINYANG SPECIALTY STEEL ::</title>
    <link rel="stylesheet" type="text/css" href="../../Script/toastr/toastr.min.css?ver=<%= BasePage.srcVersion %>" />
    <link rel="stylesheet" type="text/css" href="../css/new_main.css?ver=<%= BasePage.srcVersion %>" />
    <link rel="stylesheet" type="text/css" href="../css/font-awesome.min.css" />
    <script type="text/javascript" src="../../UserControl/ItsPage.js?ver=<%= BasePage.srcVersion %>"></script>
    <script type="text/javascript" src="../../UserControl/ItsMaria.js?ver=<%= BasePage.srcVersion %>"></script>
    <!-- new_add -->
    <script type="text/javascript" src="../js/jquery-2.2.4.min.js"></script>
    <script type="text/javascript" src="../js/jquery-ui.min.js"></script>
    <script type="text/javascript" src="../js/common.js?ver=<%= BasePage.srcVersion %>"></script>
    <script type="text/javascript" src="../../UserControl/ItsMsg.js?ver=<%= BasePage.srcVersion %>"></script>
    <script type="text/javascript" src="../../Script/toastr/toastr.min.js?ver=<%= BasePage.srcVersion %>"></script>
    <script type="text/javascript" src="../../PAGECOM/PORTAL/js/portal.js"></script>
    <script>
        var $srcVersion = <%= "\"" + BasePage.srcVersion.ToString() + "\"" %>;
        var $userFontSize = <%= "\"" + BasePage.userFontSize.ToString() + "\"" %>;
    </script>
</head>
<body style="height:auto; padding: 0px;">
    <div class="mask"></div>
    <div class="preloader">
        <div class="spinner">
            <span class="spinner-rotate"></span>
        </div>
    </div>
    <div class="layout">
        <div class="m_top">
            <div class="m_left">
                <h1><img src="../images/logo.png" alt="Optisco ERP"/></h1>
                <div class="m_click">
                    <span></span>
                    <span></span>
                    <span></span>
                </div>
            </div>
        </div>
        <div class="all_left">
            <h1><a target="_blank" href="../PORTAL/index.aspx" ><img src="../images/logo_01.png" style="margin: 0px auto;" alt="ERP" class="logo_p"/></a></h1>
            <h1><a target="_blank" href="../PORTAL/index.aspx" ><img src="../images/logo_m.png" alt="ERP" class="logo_m"/></a></h1>
            <%-- 의미없음: 서치에서 완성기능 안되게 하기 위해 --%>
            <div style="position: absolute;left:-999px;"> 
                <input type="text" id="tricId" name="tricId" placeholder="입력하세요.">
                <input type="password" id="tricPwd" name="tricPwd" placeholder="입력하세요.">
            </div>
            <div class="all_left_search">
                <input type="text" id="left_search_menu_before" autocomplete="new-password"  name="" title="" value="" required="required" placeholder="Search..."/>
                <i class="fa fa-search" aria-hidden="true"></i>
                <i class="fa fa-angle-double-up" aria-hidden="true"></i>
            </div>
            <%= emergency_market_info %>
            <div class="all_left_list">
                <ul class="left_list_root_ul">
                    <%= MenuHtml %>
                </ul>
            </div>
            <ul class='custom-menu'>
              <li data-action = "co">다른 창 닫기</li>
              <li data-action = "ca">전체 닫기</li>
              <li data-action = "mya">즐겨찾기추가</li>
              <li data-action = "myd">즐겨찾기제거</li>
            </ul>
        </div>
        <div class="all_right">
            <div class="menu_turn" style="padding: 15px 5px 15px 0px;">
                <span>
                    <i class="fa fa-angle-left" aria-hidden="true"></i>
                </span>
            </div>
            <div class="all_left_search_form">
                <div class="s_wrapper">
                    <input type="text" id="left_search_menu" style="width:145px" autocomplete="off"  name="" title="" value="" required placeholder="Search..." onkeydown="if( event.keyCode==13 ){search_menu_btn_click();}" />
                    <i class="fa fa-search" aria-hidden="true" onclick="search_menu_btn_click()"></i>
                </div>
                <div class="close_btn">
                    <img style="height:25px"; src="../images/close_search.png" />
                </div>
                <ul>
                </ul>
            </div>
            <div class="m_menu">
                <nav>
                    <div id="m_wrap">
                        <div class="layout">
                            <%--<div class="topmenu_slider left"><i class="fa fa-chevron-left"></i></div>--%>
                            <div class="openmenudiv left">
                                <ul class="clearfix">
                                    <li onclick="top_menu_click('../../PAGESYS/SYS0000/SYS0000_R01.aspx', this)" class="home" style="display: list-item; border-bottom: 0px;">
                                        <a href="#" data-menupath="../../PAGESYS/SYS0001/SYS0001_R01.aspx"><i class="fa fa-home" aria-hidden="true"></i></a>
                                    </li>
                                    <li class="topmenu_slider left"><i class="fa fa-chevron-left"></i></li>
                                    <li class="topmenu_slider blank"></li>
                                    <%= myMenuTab %>
                                
                                </ul>
                            </div>
                            <div class="openmenudiv">
                                <ul class="admin_menu_ul" style="float:right;">
                                    <li class="right_li" style="display:none;">
                                       <%-- <select id="BDVCD_main">
                                            <%= bdvList.Rows[0]["BDVTAG"].ToString() %>
                                        </select>
			   --%>
                                    </li>
                                    <li class="right_li">
                                        <a><i class="fa fa-user-o" aria-hidden="true"><span style="margin-left:5px"><%= loginUser %>님</span></i></a>
                                        <a href="#" onclick="showInfo()" style="margin-left:10px; font-size:15px;">
                                            <i class="fa fa-info-circle" aria-hidden="true"></i>
                                        </a>
                                    </li>
                                    <li class="logout_btn right_li" >
                                        <a href="#" onclick="logout()">
                                            <i class="fa fa-sign-out" aria-hidden="true"><span style="margin-left:5px">로그아웃</span></i>
                                        </a>
                                    </li>
                                </ul>
                            </div>
                            <div class="topmenu_slider right"><i class="fa fa-chevron-right" style="margin: 21px 5px 5px 5px;"></i></div>
                        </div>
                    </div>
                </nav>
            </div>
            <div id="modalLayer">
                <div class="modalContent">
                    <div class="modal_top">
                        <h2>Login<i>!</i></h2>
                    </div>
                    <button onclick="cancel_login()">
                        <span></span>
                        <span></span>
                    </button>
                    <div class="modal_bottom">
                        <div class="m_bottom_depth">
                            <h3>아 이 디</h3>
                            <input type="text" id="login_id_pop" name="login_id" title="" value="<%=GetSession("SESSION_USERID") %>" placeholder="아이디를 입력하세요." />
                        </div>
                        <div class="m_bottom_depth">
                            <h3>비밀번호</h3>
                            <input type="password" id="login_pw_pop" name="login_pw" title="" value="" placeholder="비밀번호를 입력하세요." />
                        </div>
                        <div style="padding-top: 10px; position: absolute; color:indianred; font-weight: bold; max-height: 20px">
                                <span id="login_errMsg_pop"></span>
                            </div>
                        <a href="#" onclick="login_pop_btn()">로그인</a>
                    </div>
                </div>
            </div>
            <div id="infoLayer">
                <div class="modalContent">
                    <div class="modal_top" style="height:50px;">
                        <a href="http://itsco.co.kr"><img src="../images/logo_02.jpg" alt="ITSCO" style="height:50px; margin-top:10px; margin-left:10px;" /></a>
                        <button onclick="cancel_info()">
                            <span></span>
                            <span></span>
                        </button>
                    </div>
                    <div class="modal_bottom">
                        <div class="m_bottom_depth">
                            <h2>Current Version　 <%= BasePage.srcVersion.ToString() %></h2><br/><br/>
                            <h2 id="lastVersion">Latest Version　　</h2><br/><br/><br/>
                            <h3>CopyrightⓒITSCO, All rights reserved. Since 2021.</h3>
                        </div>
                    </div>
                </div>
            </div>
            <div id="m_content" class="m_content">
                <iframe src="../../PAGESYS/SYS0000/SYS0000_R01.aspx" frameborder=0 framespacing=0; style="width:100%;"></iframe>
            </div>
        </div>
    </div>
</body>
</html>
