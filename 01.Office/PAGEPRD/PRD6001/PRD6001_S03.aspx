<%-- PAGE --%>
<%@ Page Title="" Language="C#" MasterPageFile="~/Common/Master/MasterBase.master" AutoEventWireup="true" CodeFile="PRD6001_S03.aspx.cs" Inherits="PRD6001_S03" %>

<%-- HEAD --%>
<asp:Content ContentPlaceHolderID="CPH_HEAD" runat="Server">
    <script type="text/javascript" src="PRD6001_S03.js?ver=<%= BasePage.srcVersion %>"></script>
</asp:Content>

<%-- SEARCH --%>
<asp:Content ContentPlaceHolderID="CPH_SEARCH" runat="Server">
    <Its:div runat="server" Type="SearchPanel" ID="sdiv1">    
        <Its:date runat="server" Label="수리일자" ID="sdiv1_date_SEARCH" Field="DATE"/>
        <Its:combo runat="server" Label="수리유형" ID="sdiv1_combo_REPTP" Field="REPTP" GPCD="*ISSUE"/>
        <Its:newline runat="server" />
        <Its:label runat="server" Text="수리일자는 해당일자 06시:00 ~ 다음날 05:59 (수리 완료시간) 기준으로 조회 됩니다." MarginLeft="45" ForeColor="Blue"/>
    </Its:div>
</asp:Content>

<%-- BODY --%>
<asp:Content ContentPlaceHolderID="CPH_BODY" runat="Server">
    <Its:div runat="server" Type="SplitTop" TopHeightPc="50" ID="div1">
        <Its:grid runat="server" ID="grid1"/>
    </Its:div>
    <Its:split runat="server" Type="Horizon"/>
    <Its:div runat="server" Type="SplitDown" ID="div2">
        <Its:div runat="server" Type="SplitLeft" ID="div2_2" LeftWidthPc="50">
            <Its:div runat="server" Type="SplitTop" ID="div2_2_1">
                <Its:button runat="server" Label="개선업무정보 추가" ID="div2_2_1_Button"/>
            </Its:div>
            <Its:split runat="server" Type="Horizon" Resizeable="false"/>
            <Its:div runat="server" Type="SplitDown" ID="div2_2_2">
                <Its:grid runat="server" ID="grid2"/>
            </Its:div>         
        </Its:div>
        <Its:split runat="server" Type="Vertical"/>
        <Its:div runat="server" Type="SplitRight" ID="div2_3">
            <Its:div runat="server" Type="SplitTop" ID="div2_3_1">
                <Its:button runat="server" Label="요청사항정보 추가" ID="div2_3_1_Button"/>
            </Its:div>
            <Its:split runat="server" Type="Horizon" Resizeable="false"/>
            <Its:div runat="server" Type="SplitDown" ID="div4">
                <Its:grid runat="server" ID="grid3"/>
            </Its:div>    
        </Its:div>
    </Its:div>
</asp:Content>

<asp:Content ContentPlaceHolderID="CPH_POP" runat="server">
    <Its:pop runat="server" ID="pop1" Type="add" Title="개선사항 및 요구사항 추가" Width="800">
        <Its:div runat="server" Type="BasicBlock" ID="pdiv1">
            <Its:date runat="server" Label="입력일자" Field="DATE" ID="pdiv1_date_date"/>
            <Its:combo runat="server" Label="진행상태" ID="pdiv1_combo_DAILYINFOTP" Field="DAILYINFOTP" GPCD="DAILYINFOTP" />
            <Its:num runat="server" Label="작업시간(분)" Field="WORKTIME" ID="pdiv1_text_WORKTIME" DecimalPoint="0" />
            <Its:find runat="server" Label="작업자" Field="EMPCD" ID="pdiv1_find_EMPCD" GPCD="EMPCD" InputWidth="100"/>
            <Its:newline runat="server" />
            <%--<Its:textarea runat="server" Label="설비" Field="TITLE" ID="pdiv1_text_TITLE" InputHeight="50" InputWidth="600"/>--%>
            <Its:find runat="server" Label="설비" ID="pdiv1_text_TITLE" Field="TITLE" GPCD="FANO" InputWidth="100" NameWidth="250"/>
            <Its:textarea runat="server" Label="개선사항" Field="REMARK" ID="pdiv1_textarea_REMARK" InputHeight="100" InputWidth="600"/>
        </Its:div>
    </Its:pop>

    <Its:pop runat="server" ID="pop2" Type="add" Title="개선사항 및 요구사항 추가" Width="800">
        <Its:div runat="server" Type="BasicBlock" ID="pdiv2">
            <Its:date runat="server" Label="입력일자" Field="DATE" ID="pdiv2_date_date"/>
            <Its:combo runat="server" Label="업무정보" ID="pdiv1_combo_DAILYSTATUSTP" Field="DAILYSTATUSTP" GPCD="DAILYSTATUSTP" REF01="N"/>
            <Its:newline runat="server" />
            <Its:textarea runat="server" Label="항목" Field="TITLE" ID="pdiv2_text_TITLE" InputHeight="50" InputWidth="600"/>
            <Its:textarea runat="server" Label="요구사항" Field="REMARK" ID="pdiv2_textarea_REMARK" InputHeight="100" InputWidth="600"/>
        </Its:div>
    </Its:pop>
</asp:Content>
