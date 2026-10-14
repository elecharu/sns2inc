<%-- PAGE --%>
<%@ Page Title="" Language="C#" MasterPageFile="~/Common/Master/MasterBase.master" AutoEventWireup="true" CodeFile="MST3001_R03.aspx.cs" Inherits="MST3001_R03" %>

<%-- HEAD --%>
<asp:Content ContentPlaceHolderID="CPH_HEAD" runat="Server">
    <script type="text/javascript" src="MST3001_R03.js?ver=<%= BasePage.srcVersion %>"></script>
</asp:Content>

<%-- SEARCH --%>
<asp:Content ContentPlaceHolderID="CPH_SEARCH" Runat="Server">
    <Its:div runat="server" Type="SearchPanel" ID="sdiv1">
        <Its:combo runat="server" Label="법인" ID="cmb_COMPANYCD" Field="COMPANYCD" GPCD="COMPANYCD" InputWidth="120"/>
        <Its:combo runat="server" Label="품목유형" ID="sdiv1_combo_ITEMCG" Field="ITEMCG" GPCD="DM100" Value="DM100700" ReadOnly="true"/>
        <Its:find runat="server" Label="품목" ID="sdiv1_find_ITEMID" Field="ITEMID" GPCD="ITEMID" REF02="DM100700"/>
        <Its:check runat="server" Label="종료 여부" ID="sdiv1_check_ENDYN" Field="ENDYN" Value="N"/>
        <Its:button runat="server" Label="로케이션 기준정보 관리" ID="btn_LOCA_MNG" Float="right" MarginRight="10" MarginTop="5" BackColor="CustomButton2" />
    </Its:div>
</asp:Content>

<%-- BODY --%>
<asp:Content ContentPlaceHolderID="CPH_BODY" Runat="Server">
    <Its:div runat="server" Type="SplitSingle">
        <Its:grid runat="server" ID="grid1" />
    </Its:div>

    <Its:pop runat="server" ID="pop_LOCA" Title="로케이션 기준정보 관리" Width="800" Height="480">
        <Its:div runat="server" Type="SplitTop" TopHeightPc="9">
            <Its:button runat="server" Label="조회" ID="btn_POP_SEARCH" MarginLeft="10" MarginTop="5" BackColor="CommonButton" ForeColor="White" />
            <Its:button runat="server" Label="저장" ID="btn_POP_SAVE" MarginLeft="10" MarginTop="5" BackColor="CustomButton" />
            <Its:button runat="server" Label="행추가" ID="btn_POP_ADD" MarginLeft="10" MarginTop="5" BackColor="CustomButton2" />
            <Its:button runat="server" Label="삭제" ID="btn_POP_DEL" MarginLeft="10" MarginTop="5" BackColor="CustomButton3" />
        </Its:div>
        <Its:split runat="server" Type="Horizon" Resizeable="false" />
        <Its:div runat="server" Type="SplitDown">
            <Its:grid runat="server" ID="grid_LOCA" />
        </Its:div>
    </Its:pop>
</asp:Content>