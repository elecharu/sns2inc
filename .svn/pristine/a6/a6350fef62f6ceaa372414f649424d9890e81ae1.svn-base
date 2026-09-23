<%--품목정보--%>
<%-- 'CodeFile', 'Inherits' --%>
<%@ Page Title="" Language="C#" MasterPageFile="~/Common/Master/MasterBase.master" AutoEventWireup="true" 
    CodeFile="MST0001_R09.aspx.cs" Inherits="MST0001_R09" %>

<%-- HEAD --%>
<asp:Content ContentPlaceHolderID="CPH_HEAD" Runat="Server">
    <script type="text/javascript" src="MST0001_R09.js?ver=<%= BasePage.srcVersion %>"></script>
</asp:Content>



<%-- SEARCH --%>
<asp:Content ContentPlaceHolderID="CPH_SEARCH" Runat="Server">
    <Its:div runat="server" Type="SearchPanel" ID="sdiv1">    
        <Its:combo runat="server" Label="품목유형" Field="ITEMTP" GPCD="*ITEMTP"/>        
        <Its:find runat="server" Label="거래처" Field="CUSTCD" GPCD="CUSTCD" ID="find_CUSTCD"/>  
        <Its:find runat="server" Label="품목코드" Field="ITEMCD" GPCD="ITEMCD" ID="find_ITEMCD"/>               
    </Its:div>
</asp:Content>

<%-- BODY --%>
<asp:Content ContentPlaceHolderID="CPH_BODY" Runat="Server">   
    <Its:div runat="server" Type="SplitSingle">
        <Its:grid runat="server" ID="grid1" />
    </Its:div>
</asp:Content>


<%-- POP --%>
<asp:Content ContentPlaceHolderID="CPH_POP" runat="server">
    <Its:pop runat="server" ID="pop1" Type="add" Title="품목 추가" Width="730">
        <Its:div runat="server"  ID="pdiv1">
            <Its:text runat="server" Label="품목코드" Field="ITEMCD" ID="txt_ITEMCD" Required="true"/>
            <Its:combo runat="server" Label="재질" Field="MATERIAL" GPCD="MATERIAL"/>
            <Its:combo runat="server" Label="공정" Field="PRCCD" GPCD="PRCCD" />
            <Its:newline runat="server" />

            <Its:text runat="server" Label="품명" Field="ITEMNM" ID="txt_ITEMNM" Required="true"/>
            <Its:num runat="server" Label="두께" Field="THICK" DecimalPoint="1"/>         
            <Its:find runat="server" Label="거래처" GPCD="CUSTCD" Field="CUSTCD" />
            <Its:newline runat="server" />

            <Its:combo runat="server" Label="품목유형" Field="ITEMTP" GPCD="ITEMTP" Required="true"/>
            <Its:num runat="server" Label="길이" Field="LENGTH" DecimalPoint="1"/>            
            <Its:newline runat="server" />

            <Its:combo runat="server" Label="단위" Field="ITEMUNIT" GPCD="ITEMUNIT" USEYN="Y" Required="true"/>
            <Its:num runat="server" Label="폭" Field="WIDTH" DecimalPoint="1"/>            
            <Its:newline runat="server" />

            <Its:text runat="server" Label="비고" Field="REMARK"  InputWidth="597" />
            <Its:newline runat="server" />
            
            <Its:check runat="server" Label="사용여부" Field="USEYN" MarginLeft="80"/>
            <Its:check runat="server" Label="한로트관리" Field="ONELOT_YN" Value="false"/>
            <Its:check runat="server" Label="수입검사" Field="INTEST_YN" Value="false" MarginLeft="130"/>
            <Its:check runat="server" Label="공정검사" Field="PRCTEST_YN" Value="false"/>
            <Its:check runat="server" Label="출고검사" Field="OUTTEST_YN" Value="false"/>           
        </Its:div>
    </Its:pop>

    <Its:pop runat="server" ID="pop2" Type="add" Title="잔재품목 추가" Width="400">
        <Its:div runat="server"  ID="pdiv2">
            <Its:text runat="server" Label="품목코드" Field="ITEMCD_MTRLEFT" ID="txt_ITEMCD_MTRLEFT" InputWidth="150" ReadOnly="true"/>
            <Its:newline runat="server" />
            <Its:text runat="server" Label="품명" Field="ITEMNM_MTRLEFT" ID="txt_ITEMNM_MTRLEFT" InputWidth="150"/>
            <Its:newline runat="server" />
            <Its:num runat="server" Label="길이" Field="LENGTH_MTRLEFT" ID="num_LENGTH_MTRLEFT" DecimalPoint="1"/>        
            <Its:newline runat="server" />
            <Its:num runat="server" Label="폭" Field="WIDTH_MTRLEFT" ID="num_WIDTH_MTRLEFT" DecimalPoint="1"/>        
        </Its:div>
    </Its:pop>
</asp:Content>
