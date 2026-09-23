
<%-- 'CodeFile', 'Inherits' --%>
<%@ Page Title="" Language="C#" MasterPageFile="~/Common/Kiosk/Kiosk.master" AutoEventWireup="true" 
    CodeFile="TAL1002_R01.aspx.cs" Inherits="TAL1002_R01" %>

<%-- HEAD --%>
<asp:Content ContentPlaceHolderID="CPH_HEAD" Runat="Server">
    <script type="text/javascript" src="TAL1002_R01.js?ver=<%= BasePage.srcVersion %>"></script>
<%--      <style type="text/css">
        #grid1 { height:675px !important; }
        #grid2 { height:675px !important; }
    </style>--%>
</asp:Content>


<%-- SEARCH --%>
<asp:Content ContentPlaceHolderID="CPH_SEARCH" Runat="Server">
    <Its:div runat="server" Type="SearchPanel" ID="sdiv1">
        <Its:dateRange runat="server" Label="납기일자" ID="dateR_EXPDATE"  /> 
        <%--<its:combo runat="server" Label="공정" Field="PRCCD" GPCD="*PRCCD_AFTERCUT" ID="cmb_PRCCD" InputWidth="100"/>--%>
        <Its:button runat="server" Label="수주 조회" ID="btn_LIST_SALODRD_ROUT"  Width="200" MarginLeft="40"/>

    </Its:div>
</asp:Content>

<%-- BODY --%>
<asp:Content ContentPlaceHolderID="CPH_BODY" Runat="Server">
    <Its:div runat="server" Type="SplitSingle">
        <Its:grid runat="server" ID="grid_SALODRD_ROUT" />
    </Its:div>
</asp:Content>


<%-- POP --%>
<asp:Content ContentPlaceHolderID="CPH_POP" runat="server">
    <Its:pop runat="server" ID="pop_TQMRST_HEADER" Title="초중종검사 관리"  Width="1200" Height="500">
        <Its:div runat="server" Type="SplitTop">
            <Its:date runat="server" Label="검사일자" Field="TQMDATE" ID="date_TQMDATE"/>
            <Its:find runat="server" Label="검사자" GPCD="EMPCD" Field="EMPCD" ID="find_EMPCD"/>
            <Its:combo runat="server" Label="초중종유형" GPCD="PRCTESTTP" Field="PRCTESTTP" ID="cmb_PRCTESTTP"  LabelWidth="100"/>
            <Its:button runat="server" Label="검사실시" ID="btn_ADD_TQMRST_HEADER" MarginLeft="40"/>
        </Its:div>        

        <Its:split runat="server" Type="Horizon" Resizeable="false" />

        <Its:div runat="server" Type="SplitDown">
            <Its:grid runat="server" ID="grid_TQMRST_HEADER" />
        </Its:div>        
    </Its:pop>

    <Its:pop runat="server" ID="pop_TQMRST_DETAIL" Title="검사결과 등록"  Width="1200" Height="500">
        <Its:div runat="server" Type="SplitLeft" LeftWidthPc="80">
            <Its:grid runat="server" ID="grid_TQMRST_DETAIL" />
        </Its:div>        

        <Its:split runat="server" Type="Vertical" Resizeable="false" />

        <Its:div runat="server" Type="SplitRight">
            <Its:div runat="server" Type="SplitTop" TopHeightPc="75">
                <Its:grid runat="server" ID="grid_TQMRST_VALUE" />
            </Its:div>
            <Its:split runat="server" Type="Horizon" Resizeable="false" />
            <Its:div runat="server" Type="SplitDown">
                <Its:check runat="server" Label="합격" Field="OK" MarginLeft="20" MarginTop="10" ID="check_OK" Value="false"/>  
                <Its:check runat="server" Label="불합격" Field="NG" MarginLeft="10" MarginTop="10" ID="check_NG" Value="false"/>        
                <Its:button runat="server" Label="저장" MarginLeft="40" MarginTop="20" ID="btn_SAVE_TQMRSTKND"/>
            </Its:div>
        </Its:div>        
    </Its:pop>
</asp:Content>