<%--검사항목정보--%>
<%-- 'CodeFile', 'Inherits' --%>
<%@ Page Title="" Language="C#" MasterPageFile="~/Common/Master/MasterBase.master" AutoEventWireup="true" 
    CodeFile="MST0001_R11.aspx.cs" Inherits="MST0001_R11" %>

<%-- HEAD 'src' --%>
<asp:Content ContentPlaceHolderID="CPH_HEAD" Runat="Server">
    <script type="text/javascript" src="MST0001_R11.js?ver=<%= BasePage.srcVersion %>"></script>
</asp:Content>

<%-- SEARCH --%>
<asp:Content ContentPlaceHolderID="CPH_SEARCH" Runat="Server">    
    <Its:div runat="server" Type="SearchPanel" ID="sdiv1">         
        <Its:combo runat="server" Label="검사유형" GPCD="*STDTP" Field="STDTP" ID="cmb_STDTP" ReadOnly="true"/>
    </Its:div>

</asp:Content>

<%-- BODY --%>
<asp:Content ContentPlaceHolderID="CPH_BODY" Runat="Server">
    <Its:div runat="server" Type="SplitSingle" >
       <Its:grid runat="server" ID="grid1" />
    </Its:div>

</asp:Content>

<%-- POP --%>
<asp:Content ContentPlaceHolderID="CPH_POP" runat="server">
    <Its:pop runat="server" ID="pop_ADD_MSTSTD" Type="add" Title="검사항목 추가" Width="700" Height="180">
        <Its:div runat="server" Type="SplitSingle" ID="pdiv1">
            <Its:combo runat="server" Label="검사유형" GPCD="STDTP" Field="STDTP" Required="true" ID="cmb_STDTP_ADD" ReadOnly="true"/>          
            <Its:newline runat="server" />

            <Its:text runat="server" Label="검사항목명"  Field="STDNM" Required="true" InputWidth="314"/>
            <Its:newline runat="server" />
            <Its:combo runat="server" Label="검사방법" GPCD="STDCHKTP" Field="STDCHKTP" Required="true"/>     

            <Its:newline runat="server" />
            <Its:combo runat="server" Label="유형" GPCD="STDVALTP" Field="STDVALTP" />
            <Its:combo runat="server" Label="범위" GPCD="STDRANGE" Field="STDRANGE" />
            <Its:combo runat="server" Label="단위" GPCD="STDUNIT" Field="STDUNIT" />
            <Its:newline runat="server" />

            <Its:text runat="server" Label="비고"  Field="REMARK" InputWidth="520"/>            
        </Its:div>
    </Its:pop>
</asp:Content>