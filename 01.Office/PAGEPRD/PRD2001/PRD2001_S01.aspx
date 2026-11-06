<%-- 생산관리 ▶ 생산실적조회 --%>

<%-- PAGE --%>
<%@ Page Title="" Language="C#" MasterPageFile="~/Common/Master/MasterBase.master" AutoEventWireup="true" CodeFile="PRD2001_S01.aspx.cs" Inherits="PRD2001_S01" %>

<%-- HEAD --%>
<asp:Content ContentPlaceHolderID="CPH_HEAD" runat="Server">
    <script type="text/javascript" src="PRD2001_S01.js?ver=<%= BasePage.srcVersion %>"></script>
</asp:Content>

<%-- SEARCH --%>
<asp:Content ContentPlaceHolderID="CPH_SEARCH" runat="Server">
    <Its:div runat="server" Type="SearchPanel" ID="sdiv1">
        <Its:dateRange runat="server" Label="생산일자" ID="dateR_WORKDATE" FieldFrom="SDATE" FieldTo="EDATE" />
        <Its:combo runat="server" Label="작업장" ID="cmb_LINECD" Field="LINECD" GPCD="*LINECD" REF01="07" />
        <Its:combo runat="server" Label="공정" ID="cmb_PRCCD" Field="PRCCD" GPCD="*PRCCD_LINE" />
        <Its:combo runat="server" Label="라인" ID="cmb_EQMCD" Field="EQMCD" GPCD="*EQMCD_LINE" />
        <Its:find runat="server" Label="품목" ID="find_ITEMID" Field="ITEMID" GPCD="ITEMID" NameWidth="150" />
        <Its:button runat="server" Label="생산일보 출력" ID="btn_PRINT_DAILY" MarginLeft="20" BackColor="CustomButton2" />
    </Its:div>
</asp:Content>

<%-- BODY --%>
<asp:Content ContentPlaceHolderID="CPH_BODY" runat="Server">
    <%-- 작업 목록 --%>
    <Its:div runat="server" Type="SplitTop" TopHeightPc="40">
        <Its:grid runat="server" ID="grid_PRDWORK" />
    </Its:div>

    <Its:split runat="server" Type="Horizon" />

    <Its:div runat="server" Type="SplitDown">
        <%-- 왼쪽: 생산실적 / 비가동이력 --%>
        <Its:div runat="server" Type="SplitLeft" LeftWidthPc="50">
            <Its:div runat="server" Type="SplitTop" TopHeightPc="50">
                <Its:div runat="server" Type="SplitTop">
                    <Its:label runat="server" Text="■ 생산실적" Bold="true" MarginLeft="10" />
                </Its:div>

                <Its:split runat="server" Type="Horizon" Resizeable="false" />

                <Its:div runat="server" Type="SplitDown">
                    <Its:grid runat="server" ID="grid_PRDRST" />
                </Its:div>
            </Its:div>

            <Its:split runat="server" Type="Horizon" />

            <Its:div runat="server" Type="SplitDown">
                <Its:div runat="server" Type="SplitTop">
                    <Its:label runat="server" Text="■ 비가동이력" Bold="true" MarginLeft="10" />
                </Its:div>

                <Its:split runat="server" Type="Horizon" Resizeable="false" />

                <Its:div runat="server" Type="SplitDown">
                    <Its:grid runat="server" ID="grid_PRDRSTNON" />
                </Its:div>
            </Its:div>
        </Its:div>

        <Its:split runat="server" Type="Vertical" />

        <%-- 오른쪽: 불량상세 --%>
        <Its:div runat="server" Type="SplitRight">
            <Its:div runat="server" Type="SplitTop">
                <Its:label runat="server" Text="■ 불량상세" Bold="true" MarginLeft="10" />
            </Its:div>

            <Its:split runat="server" Type="Horizon" Resizeable="false" />

            <Its:div runat="server" Type="SplitDown">
                <Its:grid runat="server" ID="grid_PRDRSTBAD" />
            </Its:div>
        </Its:div>
    </Its:div>
</asp:Content>
