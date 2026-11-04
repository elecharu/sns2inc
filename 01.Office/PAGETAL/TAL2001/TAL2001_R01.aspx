<%-- TAL2001_R01: 자주검사 등록 (태블릿) --%>
<%@ Page Title="" Language="C#" MasterPageFile="~/Common/Kiosk/Kiosk.master" AutoEventWireup="true"
    CodeFile="TAL2001_R01.aspx.cs" Inherits="TAL2001_R01" %>


<%-- HEAD --%>
<asp:Content ContentPlaceHolderID="CPH_HEAD" Runat="Server" >
    <script type="text/javascript" src="TAL2001_R01.js?ver=<%= BasePage.srcVersion %>"></script>
    <link rel="stylesheet" href="TAL2001_R01.css?ver=<%= BasePage.srcVersion %>" />

</asp:Content>

<%-- SEARCH PANEL --%>
<asp:Content ContentPlaceHolderID="CPH_SEARCH" runat="Server">

</asp:Content>

<%-- BODY --%>
<asp:Content ContentPlaceHolderID="CPH_BODY" runat="Server">
    <Its:div runat="server" Type="SplitTop" ID="div1">
        <Its:combo runat="server" Label="작업장" ID="cmb_LINECD" Field="LINECD" REF01="07" GPCD="@LINECD" MarginLeft="10" MarginTop="10" InputWidth="200" />
        <Its:combo runat="server" Label="공정" ID="cmb_PRCCD" Field="PRCCD" GPCD="@PRCCD_LINE" MarginLeft="20" MarginTop="10" InputWidth="200" />
        <Its:combo runat="server" Label="라인" ID="cmb_EQMCD" Field="EQMCD" GPCD="@EQMCD_LINE" MarginLeft="20" MarginTop="10" InputWidth="200" />
        <Its:newline runat="server" Resizeable="false" />
        <Its:text runat="server" Label="품목코드" ID="txt_ITEMCD" Field="ITEMCD" ReadOnly="true" MarginLeft="10" MarginTop="10" MarginBottom="10" InputWidth="259" />
        <Its:text runat="server" Label="품목명" ID="txt_ITEMNM" Field="ITEMNM" ReadOnly="true" MarginLeft="20" MarginTop="10" MarginBottom="10" InputWidth="259" />
        <Its:text runat="server" Label="규격" ID="txt_ITEMSPEC" Field="ITEMSPEC" ReadOnly="true" MarginLeft="20" MarginTop="10" MarginBottom="10" InputWidth="259" />
        <Its:text runat="server" Label="품목ID" ID="txt_ITEMID" Field="ITEMID" ReadOnly="true" Hidden="true" />
    </Its:div>
    <Its:split runat="server" Type="Horizon" Resizeable="false" />
    <Its:div runat="server" Type="SplitDown">
        <Its:div runat="server" Type="SplitTop" ID="div2">
            <Its:date runat="server" Label="검사일자" ID="date_TQMDATE" Field="TQMDATE" MarginTop="10" MarginBottom="10" />
            <Its:text runat="server" Label="검사시간" ID="txt_TQMTIME" Field="TQMTIME" Type="hhmm" InputWidth="20" HiddenLabel="true" MarginTop="10" MarginBottom="10" />
            <Its:find runat="server" Label="검사자" ID="find_EMPCD" Field="EMPCD" GPCD="EMPCD" REF01="44F20" MarginTop="10" MarginBottom="10" InputWidth="100" NameWidth="100" />
        </Its:div>
        <Its:split runat="server" Type="Horizon" Resizeable="false" />
        <Its:div runat="server" Type="SplitDown">
            <Its:div runat="server" Type="SplitLeft" LeftWidthPc="80">
                <Its:grid runat="server" ID="grid1" />
            </Its:div>
            <Its:split runat="server" Type="Vertical" />
            <Its:div runat="server" Type="SplitRight">
                <Its:div runat="server" Type="SplitTop" TopHeightPc="73">
                    <Its:grid runat="server" ID="grid2" />
                </Its:div>
                <Its:split runat="server" Type="Horizon" Resizeable="false" />
                <Its:div runat="server" Type="SplitDown" ID="div3">
                    <Its:check runat="server" Label="합격" Field="OK" ID="check_OK" Value="false" MarginLeft="40" MarginTop="10" />
                    <Its:check runat="server" Label="불합격" Field="NG" ID="check_NG" Value="false" MarginLeft="20" MarginTop="10" />
                    <Its:button runat="server" Label="저    장" ID="btn_SAVE" MarginLeft="60" MarginTop="20" Width="150" Height="45" />
                </Its:div>
            </Its:div>
        </Its:div>
    </Its:div>

</asp:Content>



<%-- POP --%>
<asp:Content ContentPlaceHolderID="CPH_POP" runat="server">

</asp:Content>
