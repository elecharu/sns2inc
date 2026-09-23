<%-- PAGE --%>
<%@ Page Title="" Language="C#" MasterPageFile="~/Common/Master/MasterBase.master" AutoEventWireup="true" CodeFile="PDA_LOGIN.aspx.cs" Inherits="PDA_LOGIN" %>

<%-- HEAD --%>
<asp:Content ContentPlaceHolderID="CPH_HEAD" runat="Server">        
    <style>
        .main-title {
            display: none;
        }
        .login-logo {
            width:100%;
        }
        .hidden {
            display: none;
            border-width: 0px;
        }
        .login-wrapper {
            top:80px;
            position: relative;
        }
        .login-wrapper img {
            width:300px;
        }

    </style>
    <script type="text/javascript" src="PDA_LOGIN.js?ver=<%= BasePage.srcVersion %>"></script>
</asp:Content>
<%-- BODY --%>
<asp:Content ContentPlaceHolderID="CPH_BODY" runat="Server">
    <Its:div runat="server" Type="BasicBlock">
        <div class="login-wrapper">
            <img src="../../images/logo.png" class="login-logo"/><br>
            <Its:combo runat="server" GPCD="BDVCD" Field="BDVCD" ID="cmb_BDVCD" Label="사 업 장" Value="1000"/>
            <Its:newline runat="server" Height="10" />
            <Its:text runat="server" Field="USERID" ID="user_id" Label="아 이 디" />
            <Its:newline runat="server" Height="10" />
            <Its:text runat="server" Field="USERPASS" ID="user_pw" Label="비밀번호" Type="password"/>
            <Its:newline runat="server" Height="10" />
            <Its:button runat="server" Label="로 그 인" ID="login_btn" BackColor="Primary" BorderColor="PrimaryBorder" Width="200" Height="35" Margin_Left="98px"/>
        </div>
    </Its:div>
</asp:Content>