<%-- 'CodeFile', 'Inherits' --%>
<%@ Page Title="" Language="C#" MasterPageFile="~/Common/Master/MasterBase.master" AutoEventWireup="true" 
    CodeFile="SAL0001_R01.aspx.cs" Inherits="SAL0001_R01" %>

<%-- HEAD 'src' --%>
<asp:Content ContentPlaceHolderID="CPH_HEAD" Runat="Server">
    <script type="text/javascript" src="SAL0001_R01.js?ver=<%= BasePage.srcVersion %>"></script>
</asp:Content>

<%-- SEARCH --%>
<asp:Content ContentPlaceHolderID="CPH_SEARCH" Runat="Server">
    <Its:div runat="server" Type="SearchPanel" ID="sdiv1"> 
        <Its:dateRange runat="server" Label="수주일자" FieldFrom="SDATE" FieldTo="EDATE"/> 
        <Its:find runat="server" Label="거래처" Field="CUSTCD" GPCD="CUSTCD" />
        <Its:combo runat="server" Label="품목유형" ID="Combo_ITEMTP" Field="ITEMTP" GPCD="*ITEMTP"/>
        <Its:find runat="server" Label="품목코드" GPCD="ITEMCD" Field="ITEMCD"  />     
        
    </Its:div>
</asp:Content>

<%-- BODY --%>
<asp:Content ContentPlaceHolderID="CPH_BODY" Runat="Server">
    <Its:div runat="server" Type="SplitTop" TopHeightPc="40">
        <Its:div runat="server" Type="SplitTop" >
            <Its:label runat="server" Text="■ 수주품목" Bold="true" Margin="0px 0px 0px 10px"/> 

            <Its:button runat="server" Label="출하지시 행추가" BackColor="CustomButton2" ID="btn_ADD_ROW_SALOUT" MarginLeft="30"/>
        </Its:div>

        <Its:split runat="server" Type="Horizon" Resizeable="false" />

        <Its:div runat="server" Type="SplitDown" >
            <Its:grid runat="server" ID="grid1" />
        </Its:div>       
    </Its:div>

    <Its:split runat="server" Type="Horizon" />

    <Its:div runat="server" Type="SplitDown">
        <Its:div runat="server" Type="SplitTop" >
            <Its:label runat="server" Text="■ 출하지시" Bold="true" Margin="0px 0px 0px 10px"/> 

            <Its:dateRange runat="server" Label="출하지시일자" ID="dateR_SALOUTDATE" MarginLeft="30"/>
            <Its:button runat="server" Label="출하지시 저장" BackColor="CustomButton" ID="btn_SAVE_SALOUT" MarginLeft="30"/>
            <Its:button runat="server" Label="출하지시 삭제" BackColor="CustomButton3" ID="btn_DELETE_SALOUT" MarginLeft="30"/>           
        </Its:div>

        <Its:split runat="server" Type="Horizon" Resizeable="false" />

        <Its:div runat="server" Type="SplitDown" >
            <Its:grid runat="server" ID="grid2" />
        </Its:div>        
    </Its:div>
</asp:Content>
