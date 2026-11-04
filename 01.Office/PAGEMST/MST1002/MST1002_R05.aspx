<%-- 기준관리 ▶ 기준관리 ▷ 생산설비정보 --%>

<%-- PAGE --%>
<%@ Page Title="" Language="C#" MasterPageFile="~/Common/Master/MasterBase.master" AutoEventWireup="true" CodeFile="MST1002_R05.aspx.cs" Inherits="MST1002_R05" %>

<%-- HEAD --%>
<asp:Content ContentPlaceHolderID="CPH_HEAD" runat="Server">
    <script type="text/javascript" src="MST1002_R05.js?ver=<%= BasePage.srcVersion %>"></script>
</asp:Content>

<%-- SEARCH --%>
<asp:Content ContentPlaceHolderID="CPH_SEARCH" Runat="Server">
    <Its:div runat="server" Type="SearchPanel" ID="sdiv1">
        <Its:combo runat="server" Label="공장" Field="FACTORYCD"  GPCD="*FACTORYCD" InputWidth="100" Value="07"/>
        <Its:combo runat="server" Label="작업장" Field="LINECD" GPCD="*LINECD" REF01="07"/>
        <Its:combo runat="server" Label="공정" Field="PRCCD" GPCD="*PRCCD" REF01="07"/>
        <Its:check runat="server" Label="사용여부" Field="USEYN" Value="Y" MarginLeft="20"/>
    </Its:div>
</asp:Content>

<%-- BODY --%>
<asp:Content ContentPlaceHolderID="CPH_BODY" Runat="Server">
    <Its:div runat="server" Type="SplitLeft" LeftWidthPc="70">
        <Its:grid runat="server" ID="grid1" />
    </Its:div>
    <Its:split runat="server" Type="Vertical" />
    <Its:div runat="server" Type="SplitRight">
        <Its:tab runat="server" ID="tab1">
            <Its:div runat="server" Type="SplitSingle" TabTitle="라인별 설비매칭" ID="div3">
                <Its:grid runat="server" ID="grid2" />
            </Its:div>
        </Its:tab>
    </Its:div>

    <Its:pop runat="server" ID="pop_PRCDETAIL" Title="세부공정 관리" Width="650" Height="500">
        <Its:div runat="server" Type="SplitTop" TopHeightPc="7">
            <Its:combo runat="server" Label="라인" ID="cmb_POP_EQMCD" GPCD="EQMCD_LINE" InputWidth="200" LabelWidth="40" ReadOnly="true" MarginTop="5" />
            <Its:button runat="server" Label="닫기" ID="btn_POP_CLOSE" Float="right" MarginRight="10" MarginTop="5" />
            <Its:button runat="server" Label="저장" ID="btn_POP_SAVE" Float="right" MarginRight="10" MarginTop="5" BackColor="CustomButton" />
        </Its:div>
        <Its:split runat="server" Type="Horizon" Resizeable="false" />
        <Its:div runat="server" Type="SplitDown">
            <Its:grid runat="server" ID="grid_POP_PRCDETAIL" />
        </Its:div>
    </Its:pop>
</asp:Content>