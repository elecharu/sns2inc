<%-- 기준관리 ▶ 기준관리 ▷ 창고정보 --%>

<%-- PAGE --%>
<%@ Page Title="" Language="C#" MasterPageFile="~/Common/Master/MasterBase.master" AutoEventWireup="true" CodeFile="MST1002_R01.aspx.cs" Inherits="MST1002_R01" %>

<%-- HEAD --%>
<asp:Content ContentPlaceHolderID="CPH_HEAD" runat="Server">
    <script type="text/javascript" src="MST1002_R01.js?ver=<%= BasePage.srcVersion %>"></script>
</asp:Content>

<%-- SEARCH --%>
<asp:Content ContentPlaceHolderID="CPH_SEARCH" Runat="Server">
    <Its:div runat="server" Type="SearchPanel" ID="sdiv1">
        <Its:combo runat="server" Label="공장" Field="FACTORYCD"  GPCD="*FACTORYCD" InputWidth="100" Value="07"/>
        <Its:check runat="server" Label="사용여부" Field="USEYN" Value="Y" MarginLeft="20"/>
    </Its:div>
</asp:Content>

<%-- BODY --%>
<asp:Content ContentPlaceHolderID="CPH_BODY" Runat="Server">
    <Its:div runat="server" Type="SplitSingle" TopHeightPc="50">
        <Its:grid runat="server" ID="grid1" />
    </Its:div>
</asp:Content>

<%--POP--%>
<asp:Content ContentPlaceHolderID="CPH_POP" runat="server" >
    <Its:pop runat="server" Type="add" ID="pop1" Title="MES 전용 유상사급 창고추가" >
        <Its:div runat="server" Type="BasicFloat" ID="pdiv1" >
            <Its:find runat="server" Label="거래처" Field="CUSTCD" GPCD="CUSTCD" />
        </Its:div>
    </Its:pop>
</asp:Content>