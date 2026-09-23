<%-- 'CodeFile', 'Inherits' --%>
<%@ Page Title="" Language="C#" MasterPageFile="~/Common/Master/MasterBase.master" AutoEventWireup="true" 
    CodeFile="LOT1002_R02.aspx.cs" Inherits="LOT1002_R02" %>

<%-- HEAD 'src' --%>
<asp:Content ContentPlaceHolderID="CPH_HEAD" Runat="Server">
    <script type="text/javascript" src="LOT1002_R02.js?ver=<%= BasePage.srcVersion %>"></script>
</asp:Content>

<%-- SEARCH PANEL --%>
<asp:Content ContentPlaceHolderID="CPH_SEARCH" runat="Server">
    <Its:div runat="server" Type="SearchPanel" ID="sdiv1">
        <Its:combo runat="server" Label="품목유형" ID="cmb_ITEMCG" Field="ITEMCG" GPCD="*DM100" />
        <Its:find runat="server" Label="품목" ID="find_ITEMID" Field="ITEMID" GPCD="ITEMID" />  
    </Its:div>
</asp:Content>

<%-- BODY --%>
<asp:Content ContentPlaceHolderID="CPH_BODY" runat="Server">
    <Its:div runat="server" Type="SplitTop" TopHeightPc="50">
        <Its:grid runat="server" ID="grid1"/>
    </Its:div>
    <Its:split runat="server" Type="Horizon"/>
    <Its:div runat="server" Type="SplitDown">
        <Its:div runat="server" Type="SplitTop" BackColor="AddPanel">
            <Its:date runat="server" Label="출고일자" ID="date_OUTDATE" Required="true"/>
            <Its:combo runat="server" Label="출고구분" ID="cmb_OUTTP" Field="OUTTP" GPCD="OUTTP" USEYN="Y" Required="true" />
            <Its:find runat="server" Label="반출처" Field="CUSTCD" GPCD="CUSTCDRETURN" ID="find_CUSTCD_RETURN" Required="true" Hidden="true" />
            <Its:find runat="server" Label="사원" Field="EMPCD" GPCD="EMPCD" ID="find_EMPCD" Required="true"/>
            <Its:text runat="server" Label="사유" ID="txt_REMARK" InputWidth="300" Required="true"/>
            <Its:button runat="server" Label="기타출고 등록" ID="btn_OUT_ETC" Width="100" Margin_Left="120px" BackColor="CustomButton2" />    
        </Its:div>   
        <Its:split runat="server" Type="Horizon" Resizeable="false" />
        <Its:div runat="server" Type="SplitDown">
            <Its:grid runat="server" ID="grid2"  />
        </Its:div>        
    </Its:div>
</asp:Content>

<%-- POP --%>
<asp:Content ContentPlaceHolderID="CPH_POP" runat="server">

</asp:Content>