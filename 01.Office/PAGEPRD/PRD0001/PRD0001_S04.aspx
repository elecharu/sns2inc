<%-- PAGE --%>
<%@ Page Title="" Language="C#" MasterPageFile="~/Common/Master/MasterBase.master" AutoEventWireup="true" CodeFile="PRD0001_S04.aspx.cs" Inherits="PRD0001_S04" %>

<%-- HEAD --%>
<asp:Content ContentPlaceHolderID="CPH_HEAD" runat="Server">
    <script type="text/javascript" src="PRD0001_S04.js?ver=<%= BasePage.srcVersion %>"></script>
</asp:Content>


<%-- SEARCH --%>
<asp:Content ContentPlaceHolderID="CPH_SEARCH" Runat="Server">
    <Its:div runat="server" Type="SearchPanel" ID="sdiv1">
        <Its:dateRange runat="server" Label="납기일자"  ID="dr_DATE" FieldFrom="SDATE" FieldTo="EDATE" InputWidth="80"/>
        <Its:find runat="server" Label="거래처"  Field="CUSTCD" GPCD="CUSTCD" />
        <Its:combo runat="server" Label="품목유형" GPCD="*ITEMTP" ID="cmb_ITEMTP" Field="ITEMTP" />                                  
        <Its:find runat="server" Label="품목코드"  Field="ITEMCD" ID="find_ITEMCD"  GPCD="ITEMCD" />        

    </Its:div>
</asp:Content>

<%-- BODY --%>
<asp:Content ContentPlaceHolderID="CPH_BODY" Runat="Server">
    <Its:div runat="server" Type="SplitTop" TopHeightPc="50">
        <Its:grid runat="server" ID="grid_SALODRD_ROUT" />
    </Its:div>

    <Its:split runat="server" Type="Horizon" />

    <Its:div runat="server" Type="SplitDown">
        <Its:div runat="server" Type="SplitLeft" LeftWidthPc="27">
            <Its:grid runat="server" ID="grid_TQMRST_HEADER" />
        </Its:div>

        <Its:split runat="server" Type="Vertical" />

        <Its:div runat="server" Type="SplitRight">
            <Its:grid runat="server" ID="grid_TQMRST_DETAIL" />
        </Its:div>

    </Its:div>
</asp:Content>

<%-- POP --%>
<asp:Content ContentPlaceHolderID="CPH_POP" runat="server">
    
      <Its:pop runat="server" ID="POP_TQMRST_VALUE" Type="common" Title="검사값 조회" Width="200" Height="500">
  
        <Its:div runat="server" Type="BasicBlock">
            <Its:grid runat="server" ID="grid_TQMRST_VALUE" />
        </Its:div>
    </Its:pop>
   
</asp:Content>