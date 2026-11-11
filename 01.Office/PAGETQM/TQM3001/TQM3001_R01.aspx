<%-- TQM3001_R01: 품질관리 ▶ 협력사 클레임등록 --%>

<%-- PAGE --%>
<%@ Page Title="" Language="C#" MasterPageFile="~/Common/Master/MasterBase.master" AutoEventWireup="true" CodeFile="TQM3001_R01.aspx.cs" Inherits="TQM3001_R01" %>

<%-- HEAD --%>
<asp:Content ContentPlaceHolderID="CPH_HEAD" runat="Server">
    <script type="text/javascript" src="TQM3001_R01.js?ver=<%= BasePage.srcVersion %>"></script>
</asp:Content>

<%-- SEARCH --%>
<asp:Content ContentPlaceHolderID="CPH_SEARCH" runat="Server">
    <Its:div runat="server" Type="SearchPanel" ID="sdiv1">
        <Its:month runat="server" Label="발생월" ID="mon_SMONTH" Field="SMONTH" />
        <Its:button runat="server" Label="클레임통보서 출력" ID="btn_PRINT_CLAIM" MarginLeft="20" BackColor="CustomButton2" />
    </Its:div>
</asp:Content>

<%-- BODY --%>
<asp:Content ContentPlaceHolderID="CPH_BODY" runat="Server">
    <%-- 왼쪽: 발생월 협력사(귀책처) 목록 --%>
    <Its:div runat="server" Type="SplitLeft" LeftWidthPc="28">
        <Its:grid runat="server" ID="grid1" />
    </Its:div>

    <Its:split runat="server" Type="Vertical" />

    <%-- 오른쪽: 클레임 머리글 / 품목별 발생 손실 비용 --%>
    <Its:div runat="server" Type="SplitRight">
        <Its:div runat="server" Type="SplitTop" TopHeightPc="20" ID="hdiv1">
            <Its:label runat="server" Text="■ CLAIM 통보서" Bold="true" Margin="3px 0px 0px 10px" />
            <Its:newline runat="server" />
            <%-- 문서번호 = 클레임키 (처음 저장할 때 SSI-yy-mm-NNN 으로 매김, 고칠 수 없음) --%>
            <Its:text runat="server" Label="문서번호" ID="txt_CLAIMKEY" InputWidth="130" ReadOnly="true" />
            <Its:date runat="server" Label="작성일" ID="date_DOCDATE" Field="DOCDATE" />
            <Its:date runat="server" Label="이의제기 기한" ID="date_OBJDATE" Field="OBJDATE" LabelWidth="90" />
            <Its:find runat="server" Label="담당" ID="find_EMPCD" Field="EMPCD" GPCD="EMPCD" InputWidth="80" NameWidth="100" />
            <Its:newline runat="server" />
            <Its:text runat="server" Label="수신" ID="txt_RECVNM" Field="RECVNM" InputWidth="200" />
            <Its:text runat="server" Label="참조" ID="txt_REFNM" Field="REFNM" InputWidth="250" />
            <Its:newline runat="server" />
            <Its:text runat="server" Label="제목" ID="txt_TITLE" Field="TITLE" InputWidth="520" />
            <Its:newline runat="server" />
            <Its:text runat="server" Label="비고" ID="txt_REMARK" Field="REMARK" InputWidth="520" />
        </Its:div>

        <Its:split runat="server" Type="Horizon" Resizeable="false" />

        <Its:div runat="server" Type="SplitDown">
            <Its:div runat="server" Type="SplitTop">
                <Its:label runat="server" Text="■ 발생 손실 비용 (노란 줄: 등록 뒤 새로 생긴 불량 품목)" Bold="true" Margin="3px 0px 0px 10px" />
                <Its:button runat="server" Label="행삭제" ID="btn_DEL_ITEM" BackColor="CustomButton3" MarginTop="4" MarginLeft="20" />
            </Its:div>
            <Its:split runat="server" Type="Horizon" Resizeable="false" />
            <Its:div runat="server" Type="SplitDown">
                <Its:grid runat="server" ID="grid2" />
            </Its:div>
        </Its:div>
    </Its:div>
</asp:Content>
