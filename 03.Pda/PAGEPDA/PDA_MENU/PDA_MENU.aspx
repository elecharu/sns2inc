<%-- PAGE --%>
<%@ Page Title="" Language="C#" MasterPageFile="~/Common/Master/MasterBase.master" AutoEventWireup="true" CodeFile="PDA_MENU.aspx.cs" Inherits="PDA_MENU" %>

<%-- HEAD --%>
<asp:Content ContentPlaceHolderID="CPH_HEAD" runat="Server">
    <link rel="stylesheet" type="text/css" href="PDA_MENU.css?ver=<%= BasePage.srcVersion %>"/>
    <script type="text/javascript" src="PDA_MENU.js?ver=<%= BasePage.srcVersion %>"></script>
</asp:Content>
<%-- BODY --%>
<asp:Content ContentPlaceHolderID="CPH_BODY" runat="Server">
    <div ID="top_wrap">     
        <div class="menu " ID="MENU_PDA1100_R01" data-menupath="../PDA1100/PDA1100_R01.aspx">
            <img class="icon" src="../../images/ic_14.png" />
            <span class="menu_title">재고조회</span>
        </div>

        <div class="menu " ID="MENU_PDA1200_R02" data-menupath="../PDA1200/PDA1200_R01.aspx">
            <img class="icon" src="../../images/ic_04.png" />
            <span class="menu_title">제품출고</span>
        </div>

        <div class="menu " ID="MENU_PDA1700_R01" data-menupath="../PDA1700/PDA1700_R01.aspx">
            <img class="icon" src="../../images/ic_07.png" />
            <span class="menu_title">재고이동</span>
        </div>      
        
    </div>
</asp:Content>