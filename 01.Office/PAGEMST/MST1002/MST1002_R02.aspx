<%-- 기준관리 ▶ 기준관리 ▷ 작업장정보 --%>

<%-- PAGE --%>
<%@ Page Title="" Language="C#" MasterPageFile="~/Common/Master/MasterBase.master" AutoEventWireup="true" CodeFile="MST1002_R02.aspx.cs" Inherits="MST1002_R02" %>

<%-- HEAD --%>
<asp:Content ContentPlaceHolderID="CPH_HEAD" runat="Server">
    <script type="text/javascript" src="MST1002_R02.js?ver=<%= BasePage.srcVersion %>"></script>
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
    <Its:div runat="server" Type="SplitTop" TopHeightPc="50">
        <Its:grid runat="server" ID="grid1" />
    </Its:div>
    <Its:split runat="server" Type="Horizon" />
    <Its:div runat="server" Type="SplitDown" TopHeightPc="50">
        <Its:tab runat="server" ID="tab1">
            <Its:div runat="server" Type="SplitSingle" TabTitle="작업장별공정정보" ID="div3">
                <Its:grid runat="server" ID="grid2" />
            </Its:div>
        </Its:tab>
    </Its:div>
</asp:Content>