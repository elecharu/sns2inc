<%-- PAGE --%>
<%@ Page Title="" Language="C#" MasterPageFile="~/Common/Master/MasterBase.master" AutoEventWireup="true" CodeFile="EQM1001_S04.aspx.cs" Inherits="EQM1001_S04" %>

<%-- HEAD --%>
<asp:Content ContentPlaceHolderID="CPH_HEAD" runat="Server">
    <script type="text/javascript" src="EQM1001_S04.js?ver=<%= BasePage.srcVersion %>"></script>
</asp:Content>


<%-- SEARCH PANEL --%>
<asp:Content ContentPlaceHolderID="CPH_SEARCH" runat="Server">
    <Its:div runat="server" Type="SearchPanel" ID="sdiv1">
        <Its:dateRange runat="server" Label="점검일자" FieldFrom="SDATE" FieldTo="EDATE" ID="date_SDATE" />
        <Its:combo runat="server" Label="점검유형" ID="cmb_CHKTP" GPCD="*CHKTP"  Field="CHKTP" />
        <Its:combo runat="server" Label="작업장" ID="cmb_LINECD" Field="LINECD" GPCD="*LINECD" REF01="07" />
        <Its:combo runat="server" Label="공정" ID="cmb_EQMTP" Field="EQMTP" GPCD="*EQMTP" InputWidth="70" />
        <Its:combo runat="server" Label="라인" ID="cmb_EQMGROUP1" Field="EQMGROUP1" GPCD="*EQMGROUP1" InputWidth="70" />
        <Its:find runat="server" Label="설비코드" ID="find_EQMCD" GPCD="EQMCD" Field="EQMCD" />
    </Its:div>
</asp:Content>

<%-- BODY --%>
<asp:Content ContentPlaceHolderID="CPH_BODY" runat="Server">

   <Its:div runat="server" Type="SplitTop" TopHeightPc="40">
        <Its:div runat="server" Type="SplitTop">
            <Its:label runat="server" Text="■ 설비점검 이력" Bold="true" MarginLeft="10"/>
            <%-- 2026-11-16 TQM1002_R01 방식 승인자·승인·승인취소, 점검시트 출력은 검색 영역에서 이동 --%>
            <Its:find runat="server" Label="승인자" ID="find_APRVEMP" Field="APRVEMP" GPCD="EMPCD" InputWidth="80" NameWidth="100" />
            <Its:button runat="server" Label="승인" ID="btn_APPROVE" Width="80" BackColor="CustomButton" MarginLeft="20" />
            <Its:button runat="server" Label="승인취소" ID="btn_APPROVE_CANCEL" Width="80" BackColor="CustomButton3" MarginLeft="10" />
            <%-- 2026-11-06 선택한 점검이력 점검 시트 출력 --%>
            <Its:button runat="server" Label="점검시트 출력" ID="btn_PRINT" Width="100" BackColor="CustomButton2" MarginLeft="20" />
        </Its:div>

        <Its:split runat="server" Type="Horizon" Resizeable="false" />

        <Its:div runat="server" Type="SplitDown">
            <Its:grid runat="server" ID="grid1" />
        </Its:div>
    </Its:div>

    <Its:split runat="server" Type="Horizon" />

    <Its:div runat="server" Type="SplitDown">
        <Its:div runat="server" Type="SplitTop">
            <Its:label runat="server" Text="■ 설비점검항목" Bold="true" MarginLeft="10"/>
        </Its:div>

        <Its:split runat="server" Type="Horizon" Resizeable="false" />

        <Its:div runat="server" Type="SplitDown">
            <Its:grid runat="server" ID="grid2" />
        </Its:div> 
    </Its:div>   


</asp:Content>