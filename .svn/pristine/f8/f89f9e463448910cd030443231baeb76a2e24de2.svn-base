<%-- PAGE --%>
<%@ Page Title="" Language="C#" MasterPageFile="~/Common/Master/MasterBase.master" AutoEventWireup="true" CodeFile="SAL0001_S05.aspx.cs" Inherits="SAL0001_S05" %>

<%-- HEAD --%>
<asp:Content ContentPlaceHolderID="CPH_HEAD" runat="Server">
    <script type="text/javascript" src="SAL0001_S05.js?ver=<%= BasePage.srcVersion %>"></script>
</asp:Content>


<%-- SEARCH --%>
<asp:Content ContentPlaceHolderID="CPH_SEARCH" Runat="Server">
    <Its:div runat="server" Type="SearchPanel" ID="sdiv1">
        <Its:dateRange runat="server" Label="납기일자"  ID="dr_DATE" FieldFrom="SDATE" FieldTo="EDATE" InputWidth="80"/>
        <Its:find runat="server" Label="거래처"  Field="CUSTCD" GPCD="CUSTCD" />
        <Its:combo runat="server" Label="품목유형" GPCD="*ITEMTP" ID="cmb_ITEMTP" Field="ITEMTP" />                                  
        <Its:find runat="server" Label="품목코드"  Field="ITEMCD" ID="find_ITEMCD"  GPCD="ITEMCD" />        
        <Its:text runat="server" Label="검사번호"  Field="TQMRSTKEY" ID ="txt_TQMRSTKEY" />
    </Its:div>
</asp:Content>

<%-- BODY --%>
<asp:Content ContentPlaceHolderID="CPH_BODY" Runat="Server">
    <Its:div runat="server" Type="SplitTop" TopHeightPc="50">
        <Its:grid runat="server" ID="grid1" />
    </Its:div>

    <Its:split runat="server" Type="Horizon" />

    <Its:div runat="server" Type="SplitDown"> 
        <Its:div runat="server" Type="SplitTop" ID="ddiv1" TopHeightPc="8">                   
            <Its:date runat="server" Label="검사일자" Field="TQMDATE" ID="date_TQMDATE" ReadOnly="true"  LabelWidth="85" MarginTop="5"/>      
            <Its:find runat="server" Label="검사자" Field="EMPCD" GPCD="EMPCD" ID="find_EMPCD" ReadOnly="true" MarginTop="5"/>
            <Its:text runat="server" Label="리비전"  Field="REVNUM"  ID="txt_REVNUM" ReadOnly="true" InputWidth="50" LabelWidth="54" MarginTop="5"/>
              <Its:text runat="server" Label="리비전코드"  Field="REVCD"  ID="txt_REVCD" ReadOnly="true" Hidden="true" InputWidth="50" LabelWidth="54" MarginTop="5"/>
            <Its:text runat="server" Label="비고"  Field="REMARK"  ID="txt_REMARK" ReadOnly="true" InputWidth="300" LabelWidth="54" MarginTop="5" Hidden="true"/>
            <Its:combo runat="server" ID="comb_FINALJUDGE" Field="FINALJUDGE" GPCD="JUDGE" Label="종합판정" MarginLeft="10" ReadOnly="true" MarginTop="5"/>              
        </Its:div>   
        <Its:split runat="server" Type="Horizon" Resizeable="false"/> 
        <Its:div runat="server" Type="SplitDown">
            <Its:div runat="server" Type="SplitLeft" LeftWidthPc="70">
                <Its:grid runat="server" ID="grid2" />
            </Its:div>
            <Its:split runat="server" Type="Vertical" Resizeable="false" />
            <Its:div runat="server" Type="SplitRight">
                <Its:grid runat="server" ID="grid_TQMRST_VALUE" />
            </Its:div>       
        </Its:div>   
    </Its:div>
</asp:Content>

<%-- POP --%>
<asp:Content ContentPlaceHolderID="CPH_POP" runat="server">    
      <Its:pop runat="server" ID="pop1" Type="common" Title="검사값 조회" Width="200" Height="700">  
        <Its:div runat="server" Type="BasicBlock">
            <Its:grid runat="server" ID="grid3" />
        </Its:div>
    </Its:pop>
   
</asp:Content>