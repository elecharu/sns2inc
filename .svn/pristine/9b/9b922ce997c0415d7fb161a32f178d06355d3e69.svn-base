<%--재고조정--%>

<%-- 'CodeFile', 'Inherits' --%>
<%@ Page Title="" Language="C#" MasterPageFile="~/Common/Master/MasterBase.master" AutoEventWireup="true" 
    CodeFile="MTR0001_R02.aspx.cs" Inherits="MTR0001_R02" %>

<%-- HEAD 'src' --%>
<asp:Content ContentPlaceHolderID="CPH_HEAD" Runat="Server">
    <script type="text/javascript" src="MTR0001_R02.js?ver=<%= BasePage.srcVersion %>"></script>
</asp:Content>


<%-- SEARCH PANEL --%>
<asp:Content ContentPlaceHolderID="CPH_SEARCH" runat="Server">
    <Its:div runat="server" Type="SearchPanel" ID="sdiv1">
        <Its:find runat="server" Label="창고코드" ID="find_WARECD" Field="WARECD" GPCD="WARECD" />
        <Its:combo runat="server" Label="품목유형" ID="cmb_ITEMTP" Field="ITEMTP" GPCD="*ITEMTP" />
        <Its:find runat="server" Label="품목코드" ID="find_ITEMCD" Field="ITEMCD" GPCD="ITEMCD" />        
    </Its:div>
</asp:Content>


<asp:Content ContentPlaceHolderID="CPH_BODY" runat="Server">
    <Its:tab runat="server" ID="tab1">  
        <Its:div runat="server" Type="SplitSingle" TabTitle="기타입고">
            <Its:div runat="server" Type="SplitTop" TopHeightPc="50">
                <Its:div runat="server" Type="SplitLeft" LeftWidthPc="65" >
                    <Its:grid runat="server" ID="grid1"/>
                </Its:div>
                <Its:split runat="server" Type="Vertical" />
                <Its:div runat="server" Type="SplitRight" >
                    <Its:grid runat="server" ID="grid1_LOTLIST"/>
                </Its:div>
            </Its:div>
            <Its:split runat="server" Type="Horizon"/>
            <Its:div runat="server" Type="SplitDown">
                <Its:div runat="server" Type="SplitTop" BackColor="AddPanel" ID="Div1">                     
                    <Its:date runat="server" Label="입고일자" ID="date_INDATE" Required="true"/>
                    <Its:combo runat="server" Label="입고구분" ID="cmb_INTP" Field="INTP" GPCD="INTP" USEYN="Y" REF05="Y" Required="true" />
                    <Its:find runat="server" Label="입고처" Field="CUSTCD" GPCD="CUSTCD" ID="find_CUSTCD_IN" Hidden="true"/>
                    <Its:find runat="server" Label="사원" Field="EMPCD" GPCD="EMPCD" ID="find_EMPCD" Required="true"/>
                    <Its:text runat="server" Label="사유" ID="txt_REMARK" InputWidth="300" Required="true"/>
                    <Its:button runat="server" Label="기타입고 등록" ID="btn_IN_COMLOT" Width="100" Margin_Left="120px" BackColor="CustomButton2" />    
                    <Its:button runat="server" Label="행추가" ID="btn_ADD_LINE" Width="100"  BackColor="CustomButton" />   
                </Its:div>   
                <Its:split runat="server" Type="Horizon" />
                    <Its:div runat="server" Type="SplitDown">
                         <Its:grid runat="server" ID="grid2"   />
                    </Its:div>        
            </Its:div>
        </Its:div>

        <Its:div runat="server" Type="SplitSingle" TabTitle="기타출고">
                 <Its:div runat="server" Type="SplitTop" TopHeightPc="50">
                <Its:grid runat="server" ID="grid3"/>
            </Its:div>
            <Its:split runat="server" Type="Horizon"/>
            <Its:div runat="server" Type="SplitDown">
                <Its:div runat="server" Type="SplitTop" BackColor="AddPanel"  TopHeightPc="7" ID="pdiv2">
                    <Its:date runat="server" Label="출고일자" ID="date_OUTDATE" Field="OUTDATE" Required="true"/>
                    <Its:combo runat ="server" Label="출고구분" ID="cmb_OUTTP" Field ="OUTTP" REF05="Y"  Required="true" GPCD="OUTTP" />
                    <Its:find runat="server" Label="사원" Field="EMPCD" GPCD="EMPCD" ID="find_OUT_EMPCD" Required="true"/>
                    <Its:text runat="server" Label="사유" ID="txt_OUT_REMARK" InputWidth="300" Required="true"/>
                    <Its:button runat="server" Label="기타출고 등록" ID="btn_OUT_COMLOT" Width="100" Margin_Left="120px" BackColor="CustomButton2" />    
                </Its:div>   
                <Its:split runat="server" Type="Horizon" Resizeable="false" />
                <Its:div runat="server" Type="SplitDown">
                    <Its:grid runat="server" ID="grid4"  />
                </Its:div>        
            </Its:div>
        </Its:div>


    </Its:tab>
</asp:Content>