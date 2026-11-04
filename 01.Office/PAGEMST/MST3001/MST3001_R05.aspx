<%-- PAGE --%>
<%@ Page Title="" Language="C#" MasterPageFile="~/Common/Master/MasterBase.master" AutoEventWireup="true" CodeFile="MST3001_R05.aspx.cs" Inherits="MST3001_R05" %>

<%-- HEAD --%>
<asp:Content ContentPlaceHolderID="CPH_HEAD" runat="Server">
    <script type="text/javascript" src="MST3001_R05.js?ver=<%= BasePage.srcVersion %>"></script>
</asp:Content>

<%-- SEARCH --%>
<asp:Content ContentPlaceHolderID="CPH_SEARCH" Runat="Server">
    <Its:div runat="server" Type="SearchPanel" ID="sdiv1">
        <Its:combo runat="server" Label="법인" ID="cmb_COMPANYCD" Field="COMPANYCD" GPCD="*COMPANYCD" InputWidth="120" ReadOnly="true"/>
        <Its:combo runat="server" Label="공장" ID="cmb_FACTORYCD" Field="FACTORYCD" GPCD="*FACTORYCD" InputWidth="120" ReadOnly="true"/>
        <Its:combo runat="server" Label="품목유형" ID="sdiv1_combo_ITEMCG" Field="ITEMCG" GPCD="DM100" Value="DM100990" ReadOnly="true"/>
        <Its:find runat="server" Label="품목" ID="sdiv1_find_ITEMID" Field="ITEMID" GPCD="ITEMID" REF02="DM100990" REF03="07"/>
        <Its:check runat="server" Label="종료 여부" ID="sdiv1_check_ENDYN" Field="ENDYN" Value="N"/>
        <Its:label runat="server" Text="안전재고 미만 (현재고가 안전재고보다 적음)" BackColorHex="Pink" MarginLeft="20"/>
    </Its:div>
</asp:Content>

<%-- BODY --%>
<asp:Content ContentPlaceHolderID="CPH_BODY" Runat="Server">
    <Its:div runat="server" Type="SplitLeft" LeftWidthPc="45">
        <Its:grid runat="server" ID="grid1" />
    </Its:div>
    <Its:split runat="server" Type="Vertical" />
    <Its:div runat="server" Type="SplitRight">
        <Its:grid runat="server" ID="grid2" />
    </Its:div>

    <Its:pop runat="server" ID="pop_BULK" Title="사용위치 일괄 추가" Width="1100" Height="600">
        <Its:div runat="server" Type="SplitTop" TopHeightPc="9">
            <Its:combo runat="server" Label="작업장" ID="pop_combo_LINECD" GPCD="LINECD" REF01="07" InputWidth="140" MarginTop="5" />
            <Its:combo runat="server" Label="공정" ID="pop_combo_PRCCD" GPCD="*PRCCD_LINE" InputWidth="140" MarginTop="5" />
            <Its:button runat="server" Label="추가" ID="btn_POP_ADD" MarginLeft="20" MarginTop="5" BackColor="CustomButton" />
            <Its:button runat="server" Label="닫기" ID="btn_POP_CLOSE" MarginLeft="10" MarginTop="5" />
        </Its:div>
        <Its:split runat="server" Type="Horizon" Resizeable="false" />
        <Its:div runat="server" Type="SplitDown">
            <Its:div runat="server" Type="SplitLeft" LeftWidthPc="75">
                <Its:grid runat="server" ID="grid_POP_EQM" />
            </Its:div>
            <Its:split runat="server" Type="Vertical" Resizeable="false" />
            <Its:div runat="server" Type="SplitRight">
                <Its:grid runat="server" ID="grid_POP_TURRET" />
            </Its:div>
        </Its:div>
    </Its:pop>
</asp:Content>
