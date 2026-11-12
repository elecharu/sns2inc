<%-- TQM2001_R01: 품질관리 ▶ 부적합관리 ▷ 부적합 판정등록 --%>

<%-- PAGE --%>
<%@ Page Title="" Language="C#" MasterPageFile="~/Common/Master/MasterBase.master" AutoEventWireup="true" CodeFile="TQM2001_R01.aspx.cs" Inherits="TQM2001_R01" %>

<%-- HEAD --%>
<asp:Content ContentPlaceHolderID="CPH_HEAD" runat="Server">
    <script type="text/javascript" src="TQM2001_R01.js?ver=<%= BasePage.srcVersion %>"></script>
</asp:Content>

<%-- SEARCH --%>
<asp:Content ContentPlaceHolderID="CPH_SEARCH" Runat="Server">
    <Its:div runat="server" Type="SearchPanel" ID="sdiv1">
        <Its:combo runat="server" Label="불량창고" ID="cmb_WARECD" Field="WARECD" GPCD="*WARECD_BAD" REF01="07" REF03="Y" />
        <Its:combo runat="server" Label="품목유형" ID="cmb_ITEMCG" Field="ITEMCG" GPCD="*DM100" />
        <Its:find runat="server" Label="품목" ID="find_ITEMID" Field="ITEMID" GPCD="ITEMID" NameWidth="150" />
        <Its:combo runat="server" Label="판정상태" ID="cmb_JUDGESTT" Field="JUDGESTT" GPCD="*JUDGESTT" />
        <Its:button runat="server" Label="일괄판정" ID="btn_JUDGE_MULTI" MarginLeft="20" BackColor="CustomButton2" />
    </Its:div>
</asp:Content>

<%-- BODY --%>
<asp:Content ContentPlaceHolderID="CPH_BODY" Runat="Server">
    <Its:div runat="server" Type="SplitLeft" LeftWidthPc="55">
        <Its:grid runat="server" ID="grid1" />
    </Its:div>

    <Its:split runat="server" Type="Vertical" />

    <Its:div runat="server" Type="SplitRight">
        <Its:div runat="server" Type="SplitTop">
            <Its:button runat="server" Label="공정이동표 출력" ID="btn_PRINT_MOVE" BackColor="CustomButton2" />
        </Its:div>
        <Its:split runat="server" Type="Horizon" Resizeable="false" />
        <Its:div runat="server" Type="SplitDown">
            <Its:grid runat="server" ID="grid2" />
        </Its:div>
    </Its:div>
</asp:Content>

<%-- POP --%>
<asp:Content ContentPlaceHolderID="CPH_POP" runat="server">
    <Its:pop runat="server" Type="add" ID="pop1" Title="일괄판정" Width="420" Height="245" AddBtnName="판정등록">
        <Its:div runat="server" Type="SplitSingle" ID="pdiv1">
            <Its:date runat="server" Label="판정일자" ID="pop1_date_JUDGEDATE" Field="JUDGEDATE" />
            <Its:newline runat="server" />
            <Its:find runat="server" Label="판정자" ID="pop1_find_EMPCD" Field="EMPCD" GPCD="EMPCD" InputWidth="80" NameWidth="160" />
            <Its:newline runat="server" />
            <Its:combo runat="server" Label="판정유형" ID="pop1_cmb_JUDGETP" Field="JUDGETP" GPCD="@JUDGETP" />
            <Its:newline runat="server" />
            <Its:combo runat="server" Label="불량구분" ID="pop1_cmb_JUDGEBADTP" Field="JUDGEBADTP" GPCD="@JUDGEBADTP" />
            <Its:newline runat="server" />
            <%-- 발생내용: 대분류(QM210)가 폐기인 불량코드만 --%>
            <Its:find runat="server" Label="발생내용" ID="pop1_find_BADCD" Field="BADCD" GPCD="BADCD" REF02="QM210I210N" InputWidth="80" NameWidth="160" />
            <Its:newline runat="server" />
            <Its:text runat="server" Label="비고" ID="pop1_txt_REMARK" Field="REMARK" InputWidth="240" />
        </Its:div>
    </Its:pop>
</asp:Content>
