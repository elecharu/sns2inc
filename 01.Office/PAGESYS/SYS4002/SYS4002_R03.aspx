<%-- -------------------------------------------------------------------------------------------------------------------------------------------------- --%>
<%-- SYS4002_R03 (영진산업): 시스템관리 ▶ 시스템관리 ▷ 시스템I/F결과조회 --%>

<%-- -------------------------------------------------------------------------------------------------------------------------------------------------- --%>
<%-- PAGE --%>

<%@ Page Title="" Language="C#" MasterPageFile="~/Common/Master/MasterBase.master" AutoEventWireup="true" CodeFile="SYS4002_R03.aspx.cs" Inherits="SYS4002_R03" %>

<%-- -------------------------------------------------------------------------------------------------------------------------------------------------- --%>
<%-- HEAD --%>

<asp:Content ContentPlaceHolderID="CPH_HEAD" runat="Server">
    <script type="text/javascript" src="SYS4002_R03.js?ver=<%= BasePage.srcVersion %>"></script>
</asp:Content>

<%-- -------------------------------------------------------------------------------------------------------------------------------------------------- --%>
<%-- SEARCH PANEL --%>

<asp:Content ContentPlaceHolderID="CPH_SEARCH" runat="Server">
    <Its:div runat="server" Type="SearchPanel" ID="sdiv1">
        <Its:combo runat="server" Label="프레임 타입" ID="cmb_FRAMETP_sdiv1" Field="FRAMETP" GPCD="*FRAMETP" />
        <Its:text runat="server" Label="키워드" ID="txt_KEYWORD_sdiv1" Field="KEYWORD" MaxLength="1000" />
    </Its:div>
</asp:Content>

<%-- -------------------------------------------------------------------------------------------------------------------------------------------------- --%>
<%-- BODY --%>

<asp:Content ContentPlaceHolderID="CPH_BODY" runat="Server">
    <Its:div runat="server" Type="SplitLeft" LeftWidthPc="30">
        <Its:grid runat="server" ID="grid_PLC" />        
    </Its:div>
    <Its:split runat="server" Type="Vertical" />
    <Its:div runat="server" Type="SplitRight">
        <Its:grid runat="server" ID="grid_PLCCUR" />
    </Its:div>
</asp:Content>

<%-- -------------------------------------------------------------------------------------------------------------------------------------------------- --%>
<%-- POP --%>

<asp:Content ContentPlaceHolderID="CPH_POP" runat="server">
    <Its:pop runat="server" ID="pop1" Type="add" Width="700" Title="I/F 설비정보 추가">
        <Its:div runat="server" Type="SplitSingle">
            <Its:text runat="server" Label="I/F번지" ID="txt_PLCADDR_pdiv1" Field="PLCADDR" MaxLength="10" />
            <Its:find runat="server" Label="설비코드" ID="find_EQMCD_pdiv1" Field="EQMCD" GPCD="EQMCD" />
            <Its:newline runat="server" />
            <Its:text runat="server" Label="작업표준항목" ID="txt_STDKNDCD_pdiv1" Field="STDKNDCD" MaxLength="10" />
            <Its:num runat="server" Label="변환계수" ID="num_CONVFACT_pdiv1" Field="CONVFACT" DecimalPoint="0" TriggerButton="false" />
            <Its:num runat="server" Label="정렬 순번" ID="num_SORTNO_pdiv1" Field="SORTNO" DecimalPoint="0" TriggerButton="false" />
            <Its:newline runat="server" />
            <Its:num runat="server" Label="현재 값" ID="num_PLCVALUE_pdiv1" Field="PLCVALUE" DecimalPoint="2" TriggerButton="false" />
            <Its:num runat="server" Label="쓰기 값" ID="num_WRITEVALUE_pdiv1" Field="WRITEVALUE" DecimalPoint="2" TriggerButton="false" />
            <Its:newline runat="server" Height="10" />
            <Its:check runat="server" Label="사용 여부" ID="chk_USEYN_pdiv1" Field="USEYN" MarginLeft="75" />
            <Its:check runat="server" Label="읽기 여부" ID="chk_READYN_pdiv1" Field="READYN" />
            <Its:check runat="server" Label="쓰기 여부" ID="chk_WRITEYN_pdiv1" Field="WRITEYN" />
            <Its:check runat="server" Label="카운터 번지" ID="chk_CNTYN_pdiv1" Field="CNTYN" />
            <Its:check runat="server" Label="비가동" ID="chk_NONYN_pdiv1" Field="NONYN" />
            <Its:check runat="server" Label="리셋 번지" ID="chk_RESETYN_pdiv1" Field="RESETYN" />
            <Its:check runat="server" Label="히스토리" ID="chk_HISYN_pdiv1" Field="HISYN" />
            <Its:newline runat="server" Height="10" />
            <Its:text runat="server" Label="비고" ID="txt_REMARK_pdiv1" Field="REMARK" MaxLength="1000" InputWidth="534" />
        </Its:div>
    </Its:pop>
</asp:Content>

<%-- -------------------------------------------------------------------------------------------------------------------------------------------------- --%>