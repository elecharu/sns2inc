<%-- 'CodeFile', 'Inherits' --%>
<%@ Page Title="" Language="C#" MasterPageFile="~/Common/Master/MasterBase.master" AutoEventWireup="true" 
    CodeFile="LOT1002_S01.aspx.cs" Inherits="LOT1002_S01" %>

<%-- HEAD 'src' --%>
<asp:Content ContentPlaceHolderID="CPH_HEAD" Runat="Server">
    <script type="text/javascript" src="LOT1002_S01.js?ver=<%= BasePage.srcVersion %>"></script>
</asp:Content>

<%-- SEARCH PANEL --%>
<asp:Content ContentPlaceHolderID="CPH_SEARCH" runat="Server">
    <Its:div runat="server" Type="SearchPanel" ID="sdiv1">
        <Its:dateRange runat="server" Label="조회기간" FieldFrom="SDATE" FieldTo="EDATE" ID="dr_DATE" />
        <Its:combo runat="server" Label="품목유형" ID="cmb_ITEMCG" Field="ITEMCG" GPCD="*DM100" />
        <Its:find runat="server" Label="품목코드" ID="find_ITEMID" Field="ITEMID" GPCD="ITEMID" />
        <Its:button runat="server" Label="기타입출고 이력삭제" BackColor="CustomButton3" ID="btn_DELETE_INOUT_ETC" />
    </Its:div>
</asp:Content>

<%-- BODY --%>
<asp:Content ContentPlaceHolderID="CPH_BODY" runat="Server">
    <Its:tab runat="server" ID="tab1" >
        <Its:div runat="server" Type="SplitSingle" TabTitle="입고">
            <Its:grid runat="server" ID="grid1"/>
        </Its:div>
        <Its:div runat="server" Type="SplitSingle" TabTitle="출고">
            <Its:grid runat="server" ID="grid2"/>
        </Its:div>
    </Its:tab>

</asp:Content>