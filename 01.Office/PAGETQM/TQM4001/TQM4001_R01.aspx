<%-- PAGE --%>
<%@ Page Title="" Language="C#" MasterPageFile="~/Common/Master/MasterBase.master" AutoEventWireup="true" CodeFile="TQM4001_R01.aspx.cs" Inherits="TQM4001_R01" %>

<%-- HEAD --%>
<asp:Content ContentPlaceHolderID="CPH_HEAD" runat="Server">
    <script type="text/javascript" src="TQM4001_R01.js?ver=<%= BasePage.srcVersion %>"></script>
</asp:Content>

<%-- SEARCH --%>
<asp:Content ContentPlaceHolderID="CPH_SEARCH" runat="Server">
    <Its:div runat="server" Type="SearchPanel" ID="sdiv1">
        <Its:combo runat="server" Label="품목유형" GPCD="*DM100" Field="ITEMCG" />
        <Its:combo runat="server" Label="공장" ID="cmb_FACTORYCD" Field="FACTORYCD" GPCD="FACTORYCD" InputWidth="120" Hidden="true"/>   <%-- 숨김: 언제나 2공장(07, JS Load) --%>
        <Its:find runat="server" Label="품목" ID="sdiv1_find_ITEMID" GPCD="ITEMID" Field="ITEMID" InputWidth="130" />
    </Its:div>
</asp:Content>

<%-- BODY --%>
<asp:Content ContentPlaceHolderID="CPH_BODY" runat="Server">
    <Its:div runat="server" Type="SplitLeft" LeftWidthPc="12">
        <Its:grid runat="server" ID="grid1" />
    </Its:div>
    <Its:split runat="server" Type="Vertical" Resizeable="false"/>
    <Its:div runat="server" Type="SplitRight">
        <Its:div runat="server" Type="SplitTop" TopHeightPc="50">
            <Its:div runat="server" Type="SplitTop" TopHeightPc="8">
                <Its:button runat="server" Label="SPC관리항목 등록" ID="btn_ADD_SPC" BackColor="CustomButton2" MarginTop="4" MarginLeft="10"/>
                <Its:button runat="server" Label="SPC관리항목 삭제" ID="btn_DEL_SPC" BackColor="CustomButton3" MarginTop="4"/>
            </Its:div>

            <Its:split runat="server" Type="Horizon" Resizeable="false" />

            <Its:div runat="server" Type="SplitDown">
                <Its:grid runat="server" ID="grid2" />
            </Its:div>
        </Its:div>
        <Its:split runat="server" Type="Horizon" />
        <Its:div runat="server" Type="SplitDown">
            <Its:div runat="server" Type="SplitTop" TopHeightPc="8">
                <Its:button runat="server" Label="CPK,PPK 저장" ID="btn_SAVE_CPKPPK" BackColor="CustomButton2" MarginTop="4" MarginLeft="10"/>
                <Its:button runat="server" Label="CPK,PPK 삭제" ID="btn_DELETE_CPKPPK" BackColor="CustomButton3" MarginTop="4" />
            </Its:div>

            <Its:split runat="server" Type="Horizon" Resizeable="false" />

            <Its:div runat="server" Type="SplitDown">
                <Its:grid runat="server" ID="grid3" />
            </Its:div>
        </Its:div>
    </Its:div>
</asp:Content>
