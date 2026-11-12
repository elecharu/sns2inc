<%-- 'CodeFile', 'Inherits' --%>
<%@ Page Title="" Language="C#" MasterPageFile="~/Common/Master/MasterBase.master" AutoEventWireup="true" 
    CodeFile="LOT1003_R01.aspx.cs" Inherits="LOT1003_R01" %>

<%-- HEAD 'src' --%>
<asp:Content ContentPlaceHolderID="CPH_HEAD" Runat="Server">
    <script type="text/javascript" src="LOT1003_R01.js?ver=<%= BasePage.srcVersion %>"></script>
</asp:Content>

<%-- SEARCH --%>
<asp:Content ContentPlaceHolderID="CPH_SEARCH" Runat="Server">
    <Its:div runat="server" Type="SearchPanel" ID="sdiv1">
        <Its:dateRange runat="server" Label="실사기간" FieldFrom="SDATE" FieldTo="EDATE" ID="dr_DATE" />
        <Its:combo runat="server" Label="창고코드" Field="WARECD" Width="120" GPCD="WARECD"  ID="cmb_WARECD" Required="true"/>
        <Its:combo runat="server" Label="품목유형" GPCD="*DM100" Field="ITEMCG" ID="cmb_ITEMCG" />
        <Its:find runat="server" Label="승인자" ID="find_EMPCD" Field="EMPCD" GPCD="EMPCD" FindType="mini" ReadOnly="true" Required="true"  />
        <Its:button runat="server" Label="승인" ID="btn_CONFIRM_COMCHK" Width="80" Margin_Left="50px" BackColor="Danger" ForeColor="White"/>
        <Its:button runat="server" Label="취소" ID="btn_CANCEL_COMCHK" Width="80" />
    </Its:div>
</asp:Content>

<%-- BODY --%>
<asp:Content ContentPlaceHolderID="CPH_BODY" Runat="Server">
    <Its:div runat="server" Type="SplitTop" TopHeightPc="50">
        <Its:div runat="server" Type="SplitLeft" LeftWidthPc="40">
            <Its:grid runat="server" ID="grid1" />
        </Its:div>
        <Its:split runat="server" Type="Vertical" />
        <Its:div runat="server" Type="SplitRight" >
            <Its:grid runat="server" ID="grid2" />
        </Its:div>
    </Its:div>
    <Its:split runat="server" Type="Horizon"/>
    <Its:div runat="server" Type="SplitDown">
        <Its:grid runat="server" ID="grid3"  />
    </Its:div>
</asp:Content>

<%--POP--%>
<asp:Content ContentPlaceHolderID="CPH_POP" runat="server">

    <Its:pop runat="server" ID="pop1" Type="add" Title="실사지시생성" Width="780" Height="650">
        <Its:div runat="server" Type="SplitSingle" ID="pdiv1">
            <Its:div runat="server" Type="BasicFloat" ID="float1">
                <Its:date runat="server" Label="실사일자" Field="CHKDATE" ID="pdiv1_date_CHKDATE" Required="true"/>
                <Its:combo runat="server" Label="창고코드" Field="WARECD" GPCD="*WARECD" ID="pdiv1_cmb_WARECD" Required="true"/>
                <Its:text runat="server" Label="실사명" Field="CHKNM" Required="true" InputWidth="150"/>
                <Its:newline runat="server" Height="5"/>
                <Its:combo runat="server" Label="품목유형" GPCD="*DM100" Field="ITEMCG" ID="pdiv1_cmb_ITEMCG"/>
                <Its:button runat="server" Label="품목조회" ID="btn_SEARCH_ITEMLIST" BackColor="CustomButton2"/>
                <Its:newline runat="server" />
            </Its:div>

            <Its:newline runat="server" />

            <Its:div runat="server" Type="BasicFloat" ID="float2">
                <Its:grid runat="server" ID="grid_ITEMLIST_ADD" Height="540"/>
            </Its:div>
        </Its:div>
    </Its:pop>

</asp:Content>
