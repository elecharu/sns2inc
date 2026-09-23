<%-- 'CodeFile', 'Inherits' --%>
<%@ Page Title="" Language="C#" MasterPageFile="~/Common/Master/MasterBase.master" AutoEventWireup="true" 
    CodeFile="SYS1003_R01.aspx.cs" Inherits="SYS1003_R01" %>

<%-- HEAD 'src' --%>
<asp:Content ContentPlaceHolderID="CPH_HEAD" Runat="Server">
    <script type="text/javascript" src="SYS1003_R01.js?ver=<%= BasePage.srcVersion %>"></script>
</asp:Content>

<%-- SEARCH --%>
<asp:Content ContentPlaceHolderID="CPH_SEARCH" Runat="Server">
</asp:Content>

<%-- BODY --%>
<asp:Content ContentPlaceHolderID="CPH_BODY" Runat="Server">
    <Its:div runat="server" Type="SplitLeft">
        <Its:div runat="server" Type="SplitTop" ID="sdiv1">
            <Its:combo runat="server" Label="패키지 유형" Field="PKGTP"  GPCD="*PKGTP" ID="cmb_PKGTP"/>  
            <Its:button runat="server" Label="추가" ID="ADD_CATEGORY" />
            <Its:button runat="server" Label="삭제" ID="DEL_CATEGORY" />
        </Its:div>
        <Its:split runat="server" Type="Horizon"/>
        <Its:div runat="server" Type="SplitDown">
            <Its:grid runat="server" ID="grid1" />
        </Its:div>
    </Its:div>
    <Its:split runat="server" Type="Vertical"/>
    <Its:div runat="server" Type="SplitRight">
        <Its:div runat="server" Type="SplitTop" ID="ddiv1" >
            <Its:text runat="server" Label="메뉴 이름" Field="MENUNM" InputWidth="250"/>
            <Its:text runat="server" Label="프로그램 코드" Field="PRGCD"  LabelWidth="110" ID="txt_PRGCD"/>
            <Its:num runat="server" Label="정렬 순서" Field="SORTNO" ID="asd"/>
            <Its:text runat="server" Label="비고" Field="REMARK" InputWidth="460" />
            <Its:onoff runat="server" Label="신규/기존 여부" Field="NEWYN" Hidden="true" OnText="신규" OffText="기존" ID="onoff_NEWYN"/>
        </Its:div>
        <Its:split runat="server" Type="Horizon"/>
        <Its:div runat="server" Type="SplitDown">
            <Its:grid runat="server" ID="grid2" />
        </Its:div>
    </Its:div>
</asp:Content>

<%-- POP --%>
<asp:Content ContentPlaceHolderID="CPH_POP" runat="Server">
    <Its:pop runat="server" ID="pop1" Title="등록" Width="500">
        <Its:div runat="server" Type="BasicBlock" BackColor="AddPanel">
            <Its:combo runat="server" Label="패키지 유형" Field="PKGTP"  GPCD="PKGTP"/>  
            <Its:newline runat="server" />
            <Its:text runat="server" Label="카테고리 코드" Field="CATECD" />
            <Its:newline runat="server" />
            <Its:text runat="server" Label="카테고리 이름" Field="CATENM" />
            <Its:newline runat="server" />
            <Its:div runat="server" Type="BasicFloat" Float="right" BackColor="AddPanel">
                <Its:button runat="server" Label="등록" ID="SAVE_CATEGORY" />
            </Its:div>
        </Its:div>
    </Its:pop>
</asp:Content>