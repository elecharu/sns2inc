<%-- -------------------------------------------------------------------------------------------------------------------------------------------------- --%>
<%-- SYS4002_R02 (영진산업): 시스템관리 ▶ 시스템관리 ▷ 시스템 PLC 정보등록 --%>

<%-- -------------------------------------------------------------------------------------------------------------------------------------------------- --%>
<%-- PAGE --%>

<%@ Page Title="" Language="C#" MasterPageFile="~/Common/Master/MasterBase.master" AutoEventWireup="true" CodeFile="SYS4002_R02.aspx.cs" Inherits="SYS4002_R02" %>

<%-- -------------------------------------------------------------------------------------------------------------------------------------------------- --%>
<%-- HEAD --%>

<asp:Content ContentPlaceHolderID="CPH_HEAD" runat="Server">
    <script type="text/javascript" src="SYS4002_R02.js?ver=<%= BasePage.srcVersion %>"></script>
</asp:Content>

<%-- -------------------------------------------------------------------------------------------------------------------------------------------------- --%>
<%-- SEARCH PANEL --%>

<asp:Content ContentPlaceHolderID="CPH_SEARCH" runat="Server">
    <Its:div runat="server" Type="SearchPanel" ID="sdiv1">
        <Its:combo runat="server" Label="프레임 타입" ID="cmb_FRAMTP_sdiv1" Field="FRAMETP" GPCD="*FRAMETP" />
        <Its:text runat="server" Label="키워드" ID="txt_KEYWORD_sdiv1" Field="KEYWORD" MaxLength="1000" />
    </Its:div>
</asp:Content>

<%-- -------------------------------------------------------------------------------------------------------------------------------------------------- --%>
<%-- BODY --%>

<asp:Content ContentPlaceHolderID="CPH_BODY" runat="Server">
    <Its:div runat="server" Type="SplitTop" TopHeightPc="50">
        <Its:grid runat="server" ID="grid_PLC" />
    </Its:div>
    <Its:split runat="server" Type="Horizon" />
    <Its:div runat="server" Type="SplitDown">
        <Its:div runat="server" Type="SplitTop" ID="ddiv1">
            <Its:text runat="server" Label="시작 번지" ID="txt_SADDR_ddiv1" Field="SADDR" MaxLength="10" />
            <Its:text runat="server" Label="할당 번지" ID="txt_EADDR_ddiv1" Field="EADDR" MaxLength="10" />
            <Its:text runat="server" Label="비고" ID="txt_REMARK_ddiv1" Field="REMARK" MaxLength="100" />
            <Its:button runat="server" Label="추가" ID="ADD_PLCADDR_ddiv1" FaIcon="fas fa-plus" Width="75" Margin="0px 0px 0px 30px" />
            <Its:button runat="server" Label="수정" ID="UP_PLCADDR_ddiv1" FaIcon="fas fa-save" Width="75" Margin="0px 0px 0px 10px" />
            <Its:button runat="server" Label="삭제" ID="DEL_PLCADDR_ddiv1" FaIcon="fas fa-minus" Width="75" Margin="0px 0px 0px 10px" />
        </Its:div>
        <Its:split runat="server" Type="Horizon" />
        <Its:div runat="server" Type="SplitDown">
            <Its:grid runat="server" ID="grid_PLCADDR" />
        </Its:div>
    </Its:div>
</asp:Content>

<%-- -------------------------------------------------------------------------------------------------------------------------------------------------- --%>
<%-- POP --%>

<asp:Content ContentPlaceHolderID="CPH_POP" runat="server">
    <Its:pop runat="server" Type="add" ID="pop1" Width="500" Title="시스템 I/F 추가">
        <Its:div runat="server" Type="SplitSingle" ID="pdiv1">
            <Its:text runat="server" Label="I/F 코드" ID="txt_PLCCD_pdiv1" Field="PLCCD" MaxLength="20" />
            <Its:text runat="server" Label="I/F 이름" ID="txt_PLCNM_pdiv1" Field="PLCNM" MaxLength="100" />
            <Its:newline runat="server" />
            <Its:text runat="server" Label="IP 주소" ID="txt_PLCIP_pdiv1" Field="PLCIP" MaxLength="20" />
            <Its:num runat="server" Label="포트번호" ID="num_PLCPORT_pdiv1" Field="PLCPORT" DecimalPoint="0" TriggerButton="false" />
            <Its:newline runat="server" />
            <Its:combo runat="server" Label="프레임 타입" ID="cmb_FRAMETP_pdiv1" Field="FRAMETP" GPCD="FRAMETP" />
            <Its:num runat="server" Label="수집 주기 (초)" ID="num_READCYCLE_pdiv1" Field="READCYCLE" DecimalPoint="0" TriggerButton="false" Value="2" />
            <Its:newline runat="server" />
            <Its:num runat="server" Label="히스토리 주기 (초)" ID="num_HISCYCLE_pdiv1" Field="HISCYCLE" DecimalPoint="0" TriggerButton="false" Value="5" />
            <Its:text runat="server" Label="비고" ID="txt_REMARK_pdiv1" Field="REMARK" MaxLength="1000" />
        </Its:div>
    </Its:pop>
</asp:Content>

<%-- -------------------------------------------------------------------------------------------------------------------------------------------------- --%>