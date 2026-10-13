<%-- 'CodeFile', 'Inherits' --%>
<%@ Page Title="" Language="C#" MasterPageFile="~/Common/Master/MasterBase.master" AutoEventWireup="true" 
    CodeFile="MTR0001_R04.aspx.cs" Inherits="MTR0001_R04" %>

<%-- HEAD 'src' --%>
<asp:Content ContentPlaceHolderID="CPH_HEAD" Runat="Server">
    <script type="text/javascript" src="MTR0001_R04.js?ver=<%= BasePage.srcVersion %>"></script>
</asp:Content>

<%-- SEARCH --%>
<asp:Content ContentPlaceHolderID="CPH_SEARCH" Runat="Server">
    <Its:div runat="server" Type="SearchPanel" ID="sdiv1"> 
        <Its:dateRange runat="server" Label="발주일자" ID="dr_DATE" FieldFrom="SDATE" FieldTo="EDATE" />
        <Its:find runat="server" Field="CUSTCD" Label="거래처" GPCD="CUSTCD" />   
        <Its:combo runat="server" Label="품목구분" GPCD="*DM100" Field="ITEMCG" ID="cmb_ITEMCG" />    
        <Its:find runat="server" Field="ITEMCD" Label="품목코드" GPCD="ITEMCD"/>   
    </Its:div>
</asp:Content>

<%-- BODY --%>
<asp:Content ContentPlaceHolderID="CPH_BODY" Runat="Server">
    <Its:tab runat="server" ID="tab1">
        <Its:div runat="server" Type="SplitSingle" TabTitle="조회">
            <Its:div runat="server" Type="SplitSingle">
                <Its:grid runat="server" ID="grid1" />
            </Its:div>
        </Its:div>
        
        <Its:div runat="server" Type="SplitSingle" TabTitle="ERP데이터수신">
            <Its:div runat="server" Type="SplitTop" TopHeightPc="50">
                <Its:div runat="server" Type="SplitTop">
                    <Its:label runat="server" Text="■ ERP 데이터" Bold="true" MarginLeft="10"/>
                    <Its:button runat="server" Label="ERP데이터수신" BackColor="CustomButton2" ID="btn_RCV_ERPDATA" MarginLeft="20"/> 
                    <Its:find runat="server" Label="수신자" GPCD="EMPCD" ID="find_EMPCD" LabelWidth="50"/>
                </Its:div>
                <Its:split runat="server" Type="Horizon" Resizeable="false" />
                <Its:div runat="server" Type="SplitDown">
                    <Its:grid runat="server" ID="grid_ERP" />
                </Its:div>        
            </Its:div>

            <Its:split runat="server" Type="Horizon" Resizeable="false" />

            <Its:div runat="server" Type="SplitDown">
                <Its:div runat="server" Type="SplitTop">
                    <Its:label runat="server" Text="■ MES 데이터" Bold="true" MarginLeft="10"/>
                    <Its:button runat="server" Label="MES데이터삭제" BackColor="CustomButton3" ID="btn_DELETE_MESDATA" MarginLeft="20"/> 
                    <Its:find runat="server" Label="수신자" GPCD="EMPCD" ID="find_EMPCD2" LabelWidth="50"/>
                </Its:div>
                <Its:split runat="server" Type="Horizon" Resizeable="false" />
                <Its:div runat="server" Type="SplitDown">
                    <Its:grid runat="server" ID="grid_MES" />
                </Its:div>        
            </Its:div>
        </Its:div>   
    </Its:tab>
</asp:Content>
