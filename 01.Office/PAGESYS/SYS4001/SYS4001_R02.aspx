<%-- 'CodeFile', 'Inherits' --%>
<%@ Page Title="" Language="C#" MasterPageFile="~/Common/Master/MasterBase.master" AutoEventWireup="true" 
    CodeFile="SYS4001_R02.aspx.cs" Inherits="SYS4001_R02" %>

<%-- HEAD 'src' --%>
<asp:Content ContentPlaceHolderID="CPH_HEAD" Runat="Server">
    <script type="text/javascript" src="SYS4001_R02.js?ver=<%= BasePage.srcVersion %>"></script>
</asp:Content>

<%-- SEARCH --%>
<asp:Content ContentPlaceHolderID="CPH_SEARCH" Runat="Server">

</asp:Content>

<%-- BODY --%>
<asp:Content ContentPlaceHolderID="CPH_BODY" Runat="Server">
    <Its:tab runat="server" ID="tab1">
        <Its:div runat="server" Type="SplitSingle" TabTitle="기초 채권 등록">
            <Its:div runat="server" Type="SplitSingle">
                <Its:grid runat="server" ID="grid1" />
            </Its:div>
        </Its:div>
        <Its:div runat="server" Type="SplitSingle" TabTitle="기초 채무 등록">
            <Its:div runat="server" Type="SplitSingle">
                <Its:grid runat="server" ID="grid2"/>
            </Its:div>
        </Its:div>
    </Its:tab>
</asp:Content>

<%-- POP --%>
<asp:Content ContentPlaceHolderID="CPH_POP" runat="server">
    <Its:pop runat="server" ID="pop1" Type="add" Title="기초 채권 추가" Width="500">
        <Its:div runat="server" Type="BasicBlock" ID="pdiv1">
            <Its:combo runat="server" Label="사업장" Field="BDVCD" GPCD="BDVCD" />
            <Its:date runat="server" Label="적용일자" Field="BASDT" ID="pop1_date_BASDT" />
            <Its:newline runat="server" />
            <Its:find runat="server" Label="거래처" Field="CUSTCD" GPCD="CUSTCD" />
            <Its:newline runat="server" />
            <Its:num runat="server" Label="외상매출금" Field="CRDTSALAMT" Value="0" TriggerButton="false" />
            <Its:num runat="server" Label="미수금" Field="ACTRCVAMT" Value="0" TriggerButton="false" />
        </Its:div>
    </Its:pop>

    <Its:pop runat="server" ID="pop2" Type="add" Title="기초 채무 추가" Width="500">
        <Its:div runat="server" Type="BasicBlock" ID="pdiv2">
            <Its:combo runat="server" Label="사업장" Field="BDVCD" GPCD="BDVCD" />
            <Its:date runat="server" Label="적용일자" Field="BASDT" ID="pop2_date_BASDT" />
            <Its:newline runat="server" />
            <Its:find runat="server" Label="거래처" Field="CUSTCD" GPCD="CUSTCD" />
            <Its:newline runat="server" />
            <Its:num runat="server" Label="외상매입금" Field="CRDTPURAMT" Value="0" TriggerButton="false" />
            <Its:num runat="server" Label="미지급금" Field="ACTPAYAMT" Value="0" TriggerButton="false" />
        </Its:div>
    </Its:pop>
</asp:Content>
