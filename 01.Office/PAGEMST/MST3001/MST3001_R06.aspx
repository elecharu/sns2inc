<%-- PAGE --%>
<%@ Page Title="" Language="C#" MasterPageFile="~/Common/Master/MasterBase.master" AutoEventWireup="true" CodeFile="MST3001_R06.aspx.cs" Inherits="MST3001_R06" %>

<%-- HEAD --%>
<asp:Content ContentPlaceHolderID="CPH_HEAD" runat="Server">
    <script type="text/javascript" src="MST3001_R06.js?ver=<%= BasePage.srcVersion %>"></script>
</asp:Content>

<%-- SEARCH --%>
<asp:Content ContentPlaceHolderID="CPH_SEARCH" Runat="Server">
    <Its:div runat="server" Type="SearchPanel" ID="sdiv1">
        <Its:dateRange runat="server" Label="불출일자" ID="sdiv1_date_RELEASEDATE" FieldFrom="SDATE" FieldTo="EDATE" />
        <Its:combo runat="server" Label="라인" ID="sdiv1_combo_EQMCD" Field="EQMCD" GPCD="*OSCCONSUM_EQMCD" REF01="07" InputWidth="160" />
        <Its:button runat="server" Label="수령확정" ID="btn_CONFIRM" MarginLeft="20" BackColor="CustomButton2" />
        <Its:button runat="server" Label="확정취소" ID="btn_CANCEL" MarginLeft="10" BackColor="CustomButton3" />
        <Its:label runat="server" Text="수령" BackColorHex="Green" ForeColorHex="White" Width="70" Align="center" MarginLeft="20"/>
        <Its:label runat="server" Text="수령확정" BackColorHex="SkyBlue" Width="70" Align="center" MarginLeft="5"/>
    </Its:div>
</asp:Content>

<%-- BODY --%>
<asp:Content ContentPlaceHolderID="CPH_BODY" Runat="Server">
    <Its:div runat="server" Type="SplitLeft" LeftWidthPc="55">
        <Its:grid runat="server" ID="grid1" />
    </Its:div>
    <Its:split runat="server" Type="Vertical" />
    <Its:div runat="server" Type="SplitRight">
        <Its:grid runat="server" ID="grid2" />
    </Its:div>
</asp:Content>

<%-- POP --%>
<asp:Content ContentPlaceHolderID="CPH_POP" runat="server">
    <Its:pop runat="server" Type="add" ID="pop1" Title="수령확정" Width="420" Height="170" AddBtnName="수령확정">
        <Its:div runat="server" Type="SplitSingle" ID="pdiv1">
            <Its:date runat="server" Label="확정일자" ID="pop1_date_CONFIRMDATE" Field="CONFIRMDATE" />
            <Its:newline runat="server" />
            <Its:find runat="server" Label="확정자" ID="pop1_find_EMPCD_CONFIRM" Field="EMPCD_CONFIRM" GPCD="EMPCD" InputWidth="80" NameWidth="160" />
        </Its:div>
    </Its:pop>
</asp:Content>
