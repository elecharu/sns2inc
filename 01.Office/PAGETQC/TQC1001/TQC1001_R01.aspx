<%-- PAGE --%>
<%@ Page Title="" Language="C#" MasterPageFile="~/Common/Master/MasterBase.master" AutoEventWireup="true" CodeFile="TQC1001_R01.aspx.cs" Inherits="TQC1001_R01" %>

<%-- HEAD --%>
<asp:Content ContentPlaceHolderID="CPH_HEAD" runat="Server">
    <script type="text/javascript" src="TQC1001_R01.js?ver=<%= BasePage.srcVersion %>"></script>
</asp:Content>

<%-- SEARCH --%>
<asp:Content ContentPlaceHolderID="CPH_SEARCH" Runat="Server">    
    <Its:div runat="server" Type="SearchPanel" ID="sdiv1">         
        <Its:combo runat="server" Label="검사구분" GPCD="*STDTP" Field="STDTP" ID="cmb_STDTP"/>
        <Its:text runat="server" Label="키워드" Field="KEYWORD" ID ="txt_KEYWORD" />
        <Its:button runat="server" Label="복사" ID="btn_COPY" BackColor="CustomButton2"  MarginLeft="40" />
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
    <Its:pop runat="server" ID="pop_ADD_MSTSTD" Type="add" Title="검사항목 추가" Width="580" Height="310">
        <Its:div runat="server" Type="SplitSingle" ID="pdiv1">
            
            <Its:div runat="server" Type="BasicFloat">     <%-- 이미지 패널 --%>
                <Its:div runat="server" Type="BorderFloat">
                    <Its:combo runat="server" Label="검사구분" GPCD="STDTP" Field="STDTP" REF01="Y" InputWidth="144" Required="true" ID="cmb_STDTP_ADD"/>          
                    <Its:combo runat="server" Label="검사방법" GPCD="STDCHKTP" Field="STDCHKTP" InputWidth="144"  Required="true" ID ="cmb_STDCHKTP_ADD"/>   
                    <Its:newline runat="server" />
                
                    <Its:text runat="server" Label="검사항목명"  Field="STDNM" Required="true" InputWidth="463"  MarginTop="17"/>
                    <Its:newline runat="server" />
                
                    <Its:combo runat="server" Label="측정부위" GPCD="STDPOINT" Field="STDPOINT"  InputWidth="144" MarginTop="17" />  
                    <Its:combo runat="server" Label="측정기기" GPCD="STDMACHINE" Field="STDMACHINE" InputWidth="144" MarginTop="17"/>
                    <Its:newline runat="server" />
            
                    <Its:combo runat="server" Label="범위" GPCD="STDRANGE" Field="STDRANGE"  InputWidth="87" MarginTop="17" ID="cmb_STDRANGE_ADD"/>
                    <Its:combo runat="server" Label="단위" GPCD="STDUNIT" Field="STDUNIT"  InputWidth="88"  labelWidth="35" MarginTop="17"/>
                    <Its:combo runat="server" Label="주기" GPCD="STDCYCLE" Field="STDCYCLE"  ID="cmb_STDCYCLE" InputWidth="88" labelWidth="35" MarginTop="17"/>
                    <Its:newline runat="server" />
                </Its:div>
                <Its:div runat="server" Type="BorderFloat">
                    <Its:textarea runat="server" Label="판정기준"  Field="STDJUDGE" InputWidth="463" />
                    <Its:text runat="server" Label="비고"  Field="REMARK" InputWidth="463"/>   
                     <Its:newline runat="server" />
                </Its:div>
            </Its:div>
        </Its:div>
    </Its:pop>
</asp:Content>