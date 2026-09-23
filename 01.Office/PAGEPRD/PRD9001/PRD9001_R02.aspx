<%@ Page Title="" Language="C#" MasterPageFile="~/Common/Master/MasterBase.master" AutoEventWireup="true" CodeFile="PRD9001_R02.aspx.cs" Inherits="PRD9001_R02" %>

<%-- -------------------------------------------------------------------------------------------------------------------------------------------------- --%>
<%-- HEAD --%>


<asp:Content ContentPlaceHolderID="CPH_HEAD" runat="Server">
    <link rel="stylesheet" href="../../Script/FullCalendar-packages/core/main.css">
    <link rel="stylesheet" href="../../Script/FullCalendar-packages/core/main.min.css">
    <link rel="stylesheet" href="../../Script/FullCalendar-packages/daygrid/main.css">
    <link rel="stylesheet" href="../../Script/FullCalendar-packages/daygrid/main.min.css">
    <link rel="stylesheet" href="../../Script/FullCalendar-packages/list/main.css">
    <link rel="stylesheet" href="../../Script/FullCalendar-packages/list/main.min.css">
    <script src="../../Script/FullCalendar-packages/core/main.js"></script>
    <script src="../../Script/FullCalendar-packages/core/main.min.js"></script>
    <script src="../../Script/FullCalendar-packages/daygrid/main.js"></script>
    <script src="../../Script/FullCalendar-packages/daygrid/main.min.js"></script>
    <script src="../../Script/FullCalendar-packages/list/main.js"></script>
    <script src="../../Script/FullCalendar-packages/list/main.min.js"></script>
    <script src="../../Script/FullCalendar-packages/interaction/main.js"></script>
    <script src="../../Script/FullCalendar-packages/interaction/main.min.js"></script>
    <script type="text/javascript" src="PRD9001_R02.js?ver=<%= BasePage.srcVersion %>"></script>
    <link rel="stylesheet" href="PRD9001_R02.css?ver=<%= BasePage.srcVersion %>">
</asp:Content>

<%-- -------------------------------------------------------------------------------------------------------------------------------------------------- --%>
<%-- BODY --%>

<asp:Content ContentPlaceHolderID="CPH_BODY" runat="Server">
    <Its:div runat="server" Type="SplitSingle" ID="ddiv_calendar">
        <div id="calendar" style="max-width:70%; text-align: center; font-size: 14px; font-family:'Malgun Gothic'; margin: 0px auto"> <%-- 1200px --%>
        </div>
    </Its:div>
</asp:Content>

<%-- -------------------------------------------------------------------------------------------------------------------------------------------------- --%>
<%-- POP --%>
<asp:Content ContentPlaceHolderID="CPH_POP" Runat="Server">
    <Its:pop runat="server" ID="pop1" Type="add" Title="작업시간 일괄 생성">
        <Its:div runat="server" ID="pdiv1" Type="SplitSingle">
            <Its:month runat="server" Label="년월" Field="WORKDATE" />
        </Its:div>
    </Its:pop>
    <Its:pop runat="server" ID="pop2" Type="add" Title="작업시간 관리">
        <Its:div runat="server" Type="SplitSingle" ID="pdiv2">
            <Its:date runat="server" Label="일자" ID="date_WORKDATE_pdiv2" Field="WORKDATE" ReadOnly="true" />
            <Its:newline runat="server" />
            <Its:num runat="server" Label="주간" Field="DAYTIME" />
            <Its:newline runat="server" />
            <Its:num runat="server" Label="야간" Field="NIGHTTIME" />
            <Its:newline runat="server" />
            <Its:num runat="server" Label="주간연장" Field="OVERTIME_DY" />
            <Its:newline runat="server" />
            <Its:num runat="server" Label="야간연장" Field="OVERTIME_NT" />
            <Its:newline runat="server" />
            <Its:text runat="server" Label="비고" Field="REMARK" />
        </Its:div>
    </Its:pop>
</asp:Content>