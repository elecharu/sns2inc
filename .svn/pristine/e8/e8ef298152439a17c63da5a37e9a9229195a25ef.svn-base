<%-- -------------------------------------------------------------------------------------------------------------------------------------------------- --%>
<%-- PRD7001_R01 (영진산업): 생산관리 ▶ 단말기 정보 ▷ 단말기 정보 --%>

<%-- -------------------------------------------------------------------------------------------------------------------------------------------------- --%>
<%-- PAGE --%>

<%@ Page Title="" Language="C#" MasterPageFile="~/Common/Master/MasterBase.master" AutoEventWireup="true" CodeFile="PRD7001_R01.aspx.cs" Inherits="PRD7001_R01" %>

<%-- -------------------------------------------------------------------------------------------------------------------------------------------------- --%>
<%-- HEAD --%>

<asp:Content ContentPlaceHolderID="CPH_HEAD" runat="Server">
    <script type="text/javascript" src="PRD7001_R01.js?ver=<%= BasePage.srcVersion %>"></script>
</asp:Content>

<%-- -------------------------------------------------------------------------------------------------------------------------------------------------- --%>
<%-- SEARCH --%>

<asp:Content ContentPlaceHolderID="CPH_SEARCH" runat="Server">
    <Its:div runat="server" Type="SearchPanel" ID="sdiv1">
        <Its:text runat="server" Label="키워드" ID="txt_KEYWORD_sdiv1" Field="KEYWORD" InputWidth="410" MaxLength="100" />
    </Its:div>
</asp:Content>

<%-- -------------------------------------------------------------------------------------------------------------------------------------------------- --%>
<%-- BODY --%>

<asp:Content ContentPlaceHolderID="CPH_BODY" runat="Server">
    <Its:div runat="server" Type="SplitSingle">
        <Its:grid runat="server" ID="grid_TML" />
    </Its:div>
</asp:Content>

<%-- -------------------------------------------------------------------------------------------------------------------------------------------------- --%>
<%-- POP --%>

<asp:Content ContentPlaceHolderID="CPH_POP" runat="server">
    <Its:pop runat="server" ID="pop1" Type="add" Title="단말기 추가" Width="650">
        <Its:div runat="server" ID="pdiv1" Type="SplitSingle">
            <Its:text runat="server" Label="단말기 코드" ID="txt_TMLCD_pdiv1" Field="TMLCD" InputWidth="51" MaxLength="20" />
            <Its:text runat="server" Label="단말기 이름" ID="txt_TMLNM_pdiv1" Field="TMLNM" InputWidth="153" MaxLength="100" />
            <Its:combo runat="server" Label="공장" Field="FACTORYCD" GPCD="FACTORYCD" ID="cmb_FACTORYCD_pdiv1"/>
            <Its:newline runat="server" Height="10" />
            <Its:combo runat="server" Label="창고" Field="WARECD" GPCD="WARECD" ID="cmb_WARECD_pdiv1"/>
            <Its:combo runat="server" Label="작업장" Field="LINECD" GPCD="LINECD" ID="cmb_LINECD_pdiv1" />
            <Its:num runat="server" Label="순번" ID="num_SORTNO_pdiv1" Field="SORTNO" TriggerButton="false" DecimalPoint="0" InputWidth="35" />
            <Its:newline runat="server" Height="10" />
            <Its:text runat="server" Label="IP 주소" ID="txt_IPADDR_pdiv1" Field="IPADDR" InputWidth="92" MaxLength="100" />
            <Its:text runat="server" Label="MAC 주소" ID="txt_MACADDR_pdiv1" Field="MACADDR" InputWidth="112" MaxLength="100" />
            <Its:check runat="server" Label="외주처여부" ID="chk_OSCYN_pdiv1" Field="OSCYN" MarginLeft="30" Value="N"/>
            <Its:check runat="server" Label="설비 연동" ID="chk_EQMYN_pdiv1" Field="EQMYN" Value="N"/>
            <Its:newline runat="server" Height="10" />
            <Its:text runat="server" Label="비고" ID="txt_REMARK_pdiv1" Field="REMARK" InputWidth="468" />
        </Its:div>
    </Its:pop>
</asp:Content>

<%-- -------------------------------------------------------------------------------------------------------------------------------------------------- --%>