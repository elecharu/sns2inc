<%@ Page Title="" Language="C#" MasterPageFile="~/Common/Master/MasterBase.master" AutoEventWireup="true" 
    CodeFile="SYS0000_R01.aspx.cs" Inherits="SYS0000_R01" %>
<asp:Content ContentPlaceHolderID="CPH_HEAD" Runat="Server">
    <link rel="stylesheet" type="text/css" href="SYS0000_R01.css?ver=<%= BasePage.srcVersion %>" />
    <script type="text/javascript" src="SYS0000_R01.js?ver=<%= BasePage.srcVersion %>"></script>
    <style>
        div.ItsDate_box > input:read-only,
        div.ItsText_table > input:read-only,
        div.ItsTextArea_table > textarea:read-only {background: unset; color: unset;}

    </style>
    <%--<script src="jquery.xdomainajax.js"></script>--%>
</asp:Content>
<asp:Content ContentPlaceHolderID="CPH_SEARCH" Runat="Server">
</asp:Content>

<asp:Content ContentPlaceHolderID="CPH_BODY" Runat="Server">
    <Its:div runat="server" Type="SplitLeft"  ID="div1">
        <Its:grid runat="server" ID="grid1" />
    </Its:div>
    <Its:split runat="server" Type="Vertical" />
    <Its:div runat="server" Type="SplitRight" ID="div2">
        <Its:date runat="server" Label="공지일자" Field="NOTICEFRDT" ID="date_NOTICEFRDT" ReadOnly="true" />
        <Its:date runat="server" Label="만료일자" Field="NOTICETODT" ID="date_NOTICETODT" ReadOnly="true" />
        <Its:newline runat="server" />
        <Its:text runat="server" Label="공지제목" Field="SUBJECT" InputWidth="786" ReadOnly="true" />
        <Its:newline runat="server" />
        <Its:textarea runat="server" Label="공지내용" Field="CONTENT" InputHeight="750" InputWidth="800" ReadOnly="true" />
    </Its:div>
<%--    <h1>ERP MAIN</h1>
    <br />
    <br />
    <div style="background-color:black; padding:10px;">
        <h4 style="color:white;">흰색글씨는 정상화면</h4>
        <br />
        <h4 style="color:HotPink;">붉은 글씨는 권한을 획득하였으나 개발 대기 중인 화면</h4>
        <br />
        <h4 style="color:DimGray;">어두운 글씨는 권한을 획득하지 못한 화면(내외부 권한, 화면 권한, 부서 권한 등)</h4>
        <br />
        <br />
        <h4 style="color:white;">관리자권한 아이디 : admin (관리자), 10098 (이왕재대리)</h4>
        <h4 style="color:white;">일부권한 아이디 : 91003 (이성호과장)</h4>
        <br />
        <br />
        <h4 style="color:white;">화면별 버튼 권한을 설정 할 수 있습니다. 필요없는 버튼 권한 체크 없애주세요(조회 추가 저장 삭제 출력)</h4>
        <h4 style="color:white;">시스템관리 > 사용권한관리 > 직무별 권한등록</h4>
        <h5 style="color:black; background-color:yellow; display:inline-block; margin-left:20px;" onclick="ItsPage.Jump('SYS3002_R02');">이동하기</h5>
        
        <br />
        <br />
        <h4 style="color:white;">캐시로 인해 변경된 소스가 반영되지 않으면 다음을 실행해서 값을 0.01씩 더하세요.</h4>
        <h5 style="color:white;">SELECT REF01 FROM COMTYPE WHERE GPCD = 'GLOBAL' AND TPCD = 'SRCVERSION';</h5>
    </div>--%>
</asp:Content>
