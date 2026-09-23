<%-- 'CodeFile', 'Inherits' --%>
<%@ Page Title="" Language="C#" MasterPageFile="~/Common/Master/MasterBase.master" AutoEventWireup="true" 
    CodeFile="PRD0001_S01.aspx.cs" Inherits="PRD0001_S01" %>

<%-- HEAD --%>
<asp:Content ContentPlaceHolderID="CPH_HEAD" runat="Server">
    <script type="text/javascript" src="PRD0001_S01.js?ver=<%= BasePage.srcVersion %>"></script>
</asp:Content>


<%-- SEARCH --%>
<asp:Content ContentPlaceHolderID="CPH_SEARCH" Runat="Server">
    <Its:div runat="server" Type="SearchPanel" ID="sdiv1">
        <Its:dateRange runat="server" Label="지시일자" ID="dataR_INSDATE" FieldFrom="SDATE" FieldTo="EDATE" />
        <Its:find runat="server" Label= "설비코드" ID="find_EQMCD" Field="EQMCD"  GPCD ="EQMCD"/>        
    </Its:div>
</asp:Content>


<%-- BODY --%>
<asp:Content ContentPlaceHolderID="CPH_BODY" runat="server">
    <Its:div runat="server" Type="SplitTop" TopHeightPc="50" >
        <Its:grid runat="server" ID="grid_PRDINS" />
    </Its:div>

    <Its:split runat="server" Type="Horizon" />

    <Its:div runat="server" ID="ddiv1" Type="SplitDown">
        <Its:tab runat="server" ID="tab1">
            <Its:div runat="server" Type="SplitSingle" TabTitle="생산품목">
                <Its:grid runat="server" ID="grid_PRDINS_SALODRD_EXTRAITEM" />
            </Its:div>
            <Its:div runat="server" Type="SplitSingle" TabTitle="생산실적">
                <Its:grid runat="server" ID="grid_PRDRST" />
            </Its:div>
            <Its:div runat="server" Type="SplitSingle"  TabTitle="사용자재">
                <Its:grid runat="server" ID="grid_PRDINSSCAN" />
            </Its:div>            
            <Its:div runat="server" Type="SplitSingle"  TabTitle="잔재">
                <Its:grid runat="server" ID="grid_MTRLEFT" />
            </Its:div>     
        </Its:tab>
    </Its:div>

    <Its:pop runat="server" ID="pop_FILE_1" Type="common" Title="작업지시서 파일관리" Width="330" Height="120">
        <Its:div runat="server" Type="SplitSingle" ID="pfdiv1">
            <Its:fileManager runat="server" ID="fm1" Field="FILEKEY" MarginLeft="20" MarginTop="20" />
            <Its:button runat="server" Label="다운로드" ID="btn_DOWN_FILE_1" MarginLeft="20" MarginTop="5"/>
            <Its:text runat="server" Label="URL" Field="FILEURL" ID="txt_URL_FILE_1" Hidden="true" />
        </Its:div>
    </Its:pop>
</asp:Content>
