<%-- TQM1002_R01: 품질관리 ▶ 출하검사 등록 --%>

<%-- PAGE --%>
<%@ Page Title="" Language="C#" MasterPageFile="~/Common/Master/MasterBase.master" AutoEventWireup="true" CodeFile="TQM1002_R01.aspx.cs" Inherits="TQM1002_R01" %>

<%-- HEAD --%>
<asp:Content ContentPlaceHolderID="CPH_HEAD" runat="Server">
    <script type="text/javascript" src="TQM1002_R01.js?ver=<%= BasePage.srcVersion %>"></script>
</asp:Content>

<%-- SEARCH --%>
<asp:Content ContentPlaceHolderID="CPH_SEARCH" runat="Server">
    <Its:div runat="server" Type="SearchPanel" ID="sdiv1">
        <Its:dateRange runat="server" Label="출하계획일자" ID="dr_DATE" FieldFrom="SDATE" FieldTo="EDATE" />
        <Its:combo runat="server" Label="구분" ID="cmb_OUTPLANTP" Field="OUTPLANTP" GPCD="SELECT '전체' AS Label, '' AS Value UNION ALL SELECT '수출', 'EXP' UNION ALL SELECT '내수', 'DOM'" />
        <%-- 거래처: 법인 60 거래처 (출하계획의 거래처 또는 고객) / 품목코드: 법인 60 품목 (값은 품목ID) --%>
        <Its:find runat="server" Label="거래처" ID="find_CUSTCD" Field="CUSTCD" REF01="60" GPCD="CUSTCD_COMPANY" />
        <Its:find runat="server" Label="품목코드" ID="find_ITEMID" Field="ITEMID" REF01="60" GPCD="ITEMID" />
    </Its:div>
</asp:Content>

<%-- BODY --%>
<asp:Content ContentPlaceHolderID="CPH_BODY" runat="Server">
    <%-- 위: 주간출하계획 (체크한 계획을 승인) --%>
    <Its:div runat="server" Type="SplitTop" TopHeightPc="35">
        <Its:div runat="server" Type="SplitTop" ID="div1">
            <Its:label runat="server" Text="■ 주간출하계획" Bold="true" Margin="3px 0px 0px 10px" />
            <%-- 승인자: 품질팀(44C10) --%>
            <Its:find runat="server" Label="승인자" ID="find_APRVEMP" Field="APRVEMP" REF01="44C10" GPCD="EMPCD" InputWidth="80" NameWidth="100" />
            <Its:button runat="server" Label="승인" ID="btn_APPROVE" Width="80" BackColor="CustomButton" MarginLeft="20" />
            <Its:button runat="server" Label="승인취소" ID="btn_APPROVE_CANCEL" Width="80" BackColor="CustomButton3" MarginLeft="10" />
            <%-- 체크한 출하계획의 검사성적서 (검사 1건에 1장, 리포트 TQM1002.exe R01) --%>
            <Its:button runat="server" Label="성적서 출력" ID="btn_PRINT_RST" Width="100" BackColor="CustomButton2" MarginLeft="20" />
        </Its:div>
        <Its:split runat="server" Type="Horizon" Resizeable="false" />
        <Its:div runat="server" Type="SplitDown">
            <Its:grid runat="server" ID="grid1" />
        </Its:div>
    </Its:div>

    <Its:split runat="server" Type="Horizon" />

    <%-- 아래: 선택한 출하계획 품목의 출하검사 --%>
    <Its:div runat="server" Type="SplitDown">
        <Its:div runat="server" Type="SplitTop" ID="div2">
            <Its:label runat="server" Text="■ 출하검사" Bold="true" Margin="3px 0px 0px 10px" />
            <Its:text runat="server" Label="품번" ID="txt_ITEMCD" InputWidth="150" ReadOnly="true" />
            <Its:text runat="server" Label="품명" ID="txt_ITEMNM" InputWidth="200" ReadOnly="true" />
            <Its:date runat="server" Label="검사일자" ID="date_TQMDATE" Field="TQMDATE" />
            <%-- 검사자: 품질팀(44C10) --%>
            <Its:find runat="server" Label="검사자" ID="find_EMPCD" Field="EMPCD" REF01="44C10" GPCD="EMPCD" InputWidth="80" NameWidth="100" />
            <%-- 저장: 판정이 있는 검사항목 전체 --%>
            <Its:button runat="server" Label="저장" ID="btn_SAVE" Width="80" BackColor="CustomButton2" MarginLeft="20" />
        </Its:div>

        <Its:split runat="server" Type="Horizon" Resizeable="false" />

        <%-- 검사항목 + 측정치(X1~X5) + 판정 --%>
        <Its:div runat="server" Type="SplitDown">
            <Its:grid runat="server" ID="grid2" />
        </Its:div>
    </Its:div>
</asp:Content>
