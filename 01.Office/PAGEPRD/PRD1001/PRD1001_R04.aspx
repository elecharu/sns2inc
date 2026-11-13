<%-- PRD1001_R04: 생산관리 ▶ 주간출하계획등록 --%>

<%-- PAGE --%>
<%@ Page Title="" Language="C#" MasterPageFile="~/Common/Master/MasterBase.master" AutoEventWireup="true" CodeFile="PRD1001_R04.aspx.cs" Inherits="PRD1001_R04" %>

<%-- HEAD --%>
<asp:Content ContentPlaceHolderID="CPH_HEAD" runat="Server">
    <script type="text/javascript" src="PRD1001_R04.js?ver=<%= BasePage.srcVersion %>"></script>
    <script src="https://unpkg.com/xlsx@0.11.18/dist/xlsx.full.min.js"></script>    <%-- XLSX, XLS 엑셀 파일 읽기 --%>
</asp:Content>

<%-- SEARCH --%>
<asp:Content ContentPlaceHolderID="CPH_SEARCH" runat="Server">
    <Its:div runat="server" Type="SearchPanel" ID="sdiv1">
        <Its:dateRange runat="server" Label="출하일자" ID="dr_DATE" FieldFrom="SDATE" FieldTo="EDATE" />
        <Its:combo runat="server" Label="구분" ID="cmb_OUTPLANTP" Field="OUTPLANTP" GPCD="SELECT '전체' AS Label, '' AS Value UNION ALL SELECT '수출', 'EXP' UNION ALL SELECT '내수', 'DOM'" />
        <Its:find runat="server" Label="거래처" ID="find_CUSTCD" Field="CUSTCD" GPCD="CUSTCD" />
    </Its:div>
</asp:Content>

<%-- BODY --%>
<asp:Content ContentPlaceHolderID="CPH_BODY" runat="Server">
    <Its:div runat="server" Type="SplitSingle">
        <Its:grid runat="server" ID="grid1" />
    </Its:div>
</asp:Content>

<%-- POP --%>
<asp:Content ContentPlaceHolderID="CPH_POP" runat="server">
    <%-- 엑셀 올리기 → 화면에 표시 → 고쳐서 저장 --%>
    <Its:pop runat="server" ID="pop1" Type="common" Title="출하계획 엑셀 올리기" Width="1500" Height="720">
        <Its:div runat="server" Type="SplitTop" ID="pdiv1">
            <Its:button runat="server" Label="수출 엑셀 올리기" ID="btn_UPLOAD_EXP" Width="140" BackColor="CustomButton2" MarginLeft="10" MarginTop="8" MarginBottom="10" />
            <input type="file" id="file_EXP" accept=".xlsx,.xls" style="display:none;" />
            <Its:button runat="server" Label="내수 엑셀 올리기" ID="btn_UPLOAD_DOM" Width="140" BackColor="CustomButton2" MarginLeft="10" MarginTop="8" />
            <input type="file" id="file_DOM" accept=".xlsx,.xls" style="display:none;" />
            <Its:text runat="server" Label="구분" ID="txt_OUTPLANTPNM" InputWidth="60" ReadOnly="true" MarginTop="8" />
            <Its:text runat="server" Label="파일" ID="txt_FILENAME" InputWidth="300" ReadOnly="true" MarginTop="8" />
            <Its:button runat="server" Label="저장" ID="btn_SAVE_PLAN" Width="100" BackColor="CustomButton2" MarginLeft="20" MarginTop="8" />
        </Its:div>
        <Its:split runat="server" Type="Horizon" Resizeable="false" />
        <Its:div runat="server" Type="SplitDown">
            <Its:grid runat="server" ID="grid2" />
        </Its:div>
    </Its:pop>
</asp:Content>
