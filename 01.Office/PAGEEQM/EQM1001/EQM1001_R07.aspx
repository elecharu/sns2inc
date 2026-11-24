<%-- EQM1001_R07: 설비 예방보전 점검등록 --%>

<%-- PAGE --%>
<%@ Page Title="" Language="C#" MasterPageFile="~/Common/Master/MasterBase.master" AutoEventWireup="true" CodeFile="EQM1001_R07.aspx.cs" Inherits="EQM1001_R07" %>

<%-- HEAD --%>
<asp:Content ContentPlaceHolderID="CPH_HEAD" runat="Server">
    <script type="text/javascript" src="EQM1001_R07.js?ver=<%= BasePage.srcVersion %>"></script>
</asp:Content>

<%-- SEARCH PANEL --%>
<asp:Content ContentPlaceHolderID="CPH_SEARCH" runat="Server">
    <Its:div runat="server" Type="SearchPanel" ID="sdiv1">
        <Its:dateRange runat="server" Label="점검일자" ID="date_SEARCH" FieldFrom="SDATE" FieldTo="EDATE" />
        <Its:combo runat="server" Label="작업장" ID="cmb_LINECD" Field="LINECD" REF01="07" GPCD="*LINECD" InputWidth="160" />
        <Its:combo runat="server" Label="공정" ID="cmb_EQMTP" Field="EQMTP" GPCD="*EQMTP" InputWidth="120" />
        <Its:combo runat="server" Label="라인" ID="cmb_EQMGROUP1" Field="EQMGROUP1" GPCD="*EQMGROUP1" InputWidth="120" />
        <Its:find runat="server" Label="설비" ID="find_EQMCD" Field="EQMCD" GPCD="EQMCD" InputWidth="80" NameWidth="120" />
    </Its:div>
</asp:Content>

<%-- BODY --%>
<asp:Content ContentPlaceHolderID="CPH_BODY" runat="Server">
    <Its:div runat="server" Type="SplitLeft" LeftWidthPc="42">
        <Its:grid runat="server" ID="grid1" />
    </Its:div>
    <Its:split runat="server" Type="Vertical" />
    <Its:div runat="server" Type="SplitRight">
        <Its:div runat="server" Type="SplitTop" TopHeightPc="50">
            <Its:div runat="server" Type="SplitTop">
                <Its:label runat="server" Text="■ 예방보전 이력 (좌측에서 설비를 선택하세요)" Bold="true" MarginLeft="10" ID="lbl_PM" />
                <Its:button runat="server" Label="삭제" ID="btn_PM_DEL" Float="right" MarginRight="10" BackColor="CustomButton3" />
                <Its:button runat="server" Label="수정" ID="btn_PM_EDIT" Float="right" MarginRight="6" BackColor="CustomButton2" />
                <Its:button runat="server" Label="점검 등록" ID="btn_PM_ADD" Float="right" MarginRight="6" BackColor="CustomButton" />
            </Its:div>

            <Its:split runat="server" Type="Horizon" Resizeable="false" />

            <Its:div runat="server" Type="SplitDown">
                <Its:grid runat="server" ID="grid2" />
            </Its:div>
        </Its:div>

        <Its:split runat="server" Type="Horizon" />

        <Its:div runat="server" Type="SplitDown">
            <Its:div runat="server" Type="SplitTop">
                <Its:label runat="server" Text="■ 점검항목 결과" Bold="true" MarginLeft="10" ID="lbl_ITEM" />
            </Its:div>

            <Its:split runat="server" Type="Horizon" Resizeable="false" />

            <Its:div runat="server" Type="SplitDown">
                <Its:grid runat="server" ID="grid3" />
            </Its:div>
        </Its:div>
    </Its:div>
</asp:Content>

<%-- POP --%>
<asp:Content ContentPlaceHolderID="CPH_POP" runat="server">
    <Its:pop runat="server" Type="add" ID="pop1" Title="예방보전 점검" Width="1100" Height="540">
        <Its:div runat="server" Type="SplitTop" ID="pdiv1">
            <Its:text runat="server" Label="설비번호" ID="pop1_txt_EQMCD" Field="EQMCD" InputWidth="110" ReadOnly="true" />
            <Its:text runat="server" Label="설비명" ID="pop1_txt_EQMNM" Field="EQMNM" InputWidth="200" ReadOnly="true" />
            <Its:text runat="server" Label="실적키" ID="pop1_txt_CHKRSTKEY" Field="CHKRSTKEY" Hidden="true" />
            <Its:text runat="server" Label="그룹REV" ID="pop1_txt_GRPREVCD" Field="GRPREVCD" Hidden="true" />
            <Its:text runat="server" Label="설비REV" ID="pop1_txt_REVCD" Field="REVCD" Hidden="true" />
            <Its:date runat="server" Label="점검일자" ID="pop1_date_BASEDATE" Field="BASEDATE" />
            <Its:find runat="server" Label="점검자" ID="pop1_find_EMPCD" Field="EMPCD" GPCD="EMPCD" InputWidth="100" NameWidth="120" />
            <Its:newline runat="server" />
            <Its:textarea runat="server" Label="문제점" ID="pop1_txtarea_PROBLEM" Field="PROBLEM" InputWidth="973" />
            <Its:newline runat="server" />
            <Its:textarea runat="server" Label="조치사항" ID="pop1_txtarea_SOLUTION" Field="SOLUTION" InputWidth="973" />
        </Its:div>

        <Its:split runat="server" Type="Horizon" />

        <Its:div runat="server" Type="SplitDown" ID="pdiv2">
            <Its:label runat="server" Text="■ 점검항목 (설비 정기점검 계획 항목, OK/NG 항목은 OK·NG, 숫자 항목은 숫자 입력)" Bold="true" MarginLeft="10" />
            <Its:button runat="server" Label="전체 항목 OK" ID="pdiv2_btn_ALL_OK" Float="right" MarginRight="10" BackColor="CustomButton2" />
            <Its:newline runat="server" />
            <Its:grid runat="server" ID="grid4" />
        </Its:div>
    </Its:pop>
</asp:Content>
