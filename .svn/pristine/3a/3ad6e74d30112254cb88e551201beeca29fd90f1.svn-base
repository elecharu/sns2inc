<%-- PAGE --%>
<%@ Page Title="" Language="C#" MasterPageFile="~/Common/Master/MasterBase.master" AutoEventWireup="true" CodeFile="EQM1001_S03.aspx.cs" Inherits="EQM1001_S03" %>

<%-- HEAD --%>
<asp:Content ContentPlaceHolderID="CPH_HEAD" runat="Server">
    <script type="text/javascript" src="EQM1001_S03.js?ver=<%= BasePage.srcVersion %>"></script>
</asp:Content>



<%-- SEARCH --%>
<asp:Content ContentPlaceHolderID="CPH_SEARCH" Runat="Server">
    <Its:div runat="server" Type="SearchPanel" ID="sdiv1"> 
        <Its:dateRange runat="server" Label="비가동일자" ID="dr_DATE" FieldFrom="SDATE" FieldTo="EDATE"/>                 
        <Its:find runat="server" Label="설비코드" ID="find_EQMCD" Field="EQMCD" GPCD="EQMCD" />        
        <Its:find runat="server" Label="비가동유형" GPCD="NONTP" Field="NONCD"  />  
    </Its:div>
</asp:Content>

<%-- BODY --%>
<asp:Content ContentPlaceHolderID="CPH_BODY" Runat="Server">
    <Its:div runat="server" Type="SplitSingle">
       <Its:grid runat="server" ID="grid1" />
    </Its:div>
</asp:Content>
