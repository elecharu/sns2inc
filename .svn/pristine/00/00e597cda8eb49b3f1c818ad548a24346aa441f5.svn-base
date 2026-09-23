<%-- 'CodeFile', 'Inherits' --%>
<%@ Page Title="" Language="C#" MasterPageFile="~/Common/Master/MasterBase.master" AutoEventWireup="true" 
    CodeFile="PRD0003_S05.aspx.cs" Inherits="PRD0003_S05" %>

<%-- HEAD 'src' --%>
<asp:Content ContentPlaceHolderID="CPH_HEAD" Runat="Server">
    <script type="text/javascript" src="PRD0003_S05.js?ver=<%= BasePage.srcVersion %>"></script>
    <link rel="stylesheet" href="PRD0003_S05.css?ver=<%= BasePage.srcVersion %>" />
</asp:Content>

<%-- SEARCH PANEL --%>
<asp:Content ContentPlaceHolderID="CPH_SEARCH" runat="Server">
    <Its:div runat="server" Type="SearchPanel" ID="sdiv1">
        <Its:text runat="server" Label="LOTKEY 입력" ID="txt_LOTKEY_INPUT" Field="LOTKEY_INPUT" Required="true" InputWidth="350"/>
    </Its:div>
</asp:Content>

<%-- BODY --%>
<asp:Content ContentPlaceHolderID="CPH_BODY" runat="Server">
    <Its:div runat="server" Type="SplitLeft" LeftWidthPc="25">
        <Its:text runat="server" Label="품목코드" ID="txt_ITEMCD" ReadOnly="true" InputWidth="200"/>
        <Its:newline runat="server" Height="10"/>
        <Its:textarea runat="server" Label="품명" ID="txta_ITEMNM" ReadOnly="true" InputWidth="200" InputHeight="55"/>        
        <Its:newline runat="server" Height="10"/>
        <Its:text runat="server" Label="제조일자" ID="txt_PRDDATE" ReadOnly="true" InputWidth="200"/>
        <Its:newline runat="server" Height="10"/>
        <Its:text runat="server" Label="생산량" ID="txt_PRODQTY" ReadOnly="true" InputWidth="200"/>
        <Its:newline runat="server" Height="10"/>
        <Its:text runat="server" Label="출고량" ID="txt_OUTQTY" ReadOnly="true" InputWidth="200"/>
        <Its:newline runat="server" Height="10"/>
        <Its:text runat="server" Label="재고수량" ID="txt_LOTQTY" ReadOnly="true" InputWidth="200"/>
        <Its:newline runat="server" Height="10"/>
        <Its:text runat="server" Label="WORKORDER" ID="txt_WORKORDER" ReadOnly="true" InputWidth="200"/>
        <Its:newline runat="server" Height="10"/>
        <Its:text runat="server" Label="고객사명" ID="txt_CUSTNM" ReadOnly="true" InputWidth="200"/>
        <Its:newline runat="server" Height="10"/>
        <Its:text runat="server" Label="고객라인" ID="txt_CUSTLINE" ReadOnly="true" InputWidth="200"/>
    </Its:div>

    <Its:split runat="server" Resizeable="false" />

    <Its:div runat="server" Type="SplitRight">
        <Its:div runat="server" Type="SplitTop" TopHeightPc="50">
            <Its:tab runat="server" ID="tab_PRODUCE" >
                <Its:div runat="server" Type="SplitSingle" TabTitle="작업지시">
                    <Its:grid runat="server" ID="grid_PRDINS" />  
                </Its:div>

                <Its:div runat="server" Type="SplitSingle" TabTitle="사용자재">
                    <Its:grid runat="server" ID="grid_USELOT" />                              
                </Its:div>

            </Its:tab>
        </Its:div>

        <Its:split runat="server" Type="Horizon" Resizeable="false"/>

        <Its:div runat="server" Type="SplitDown">
            <Its:tab runat="server" ID="tab_SAL">
                <Its:div runat="server" Type="SplitSingle" TabTitle="출하지시">
                    <Its:grid runat="server" ID="grid_SALOUT" />  
                </Its:div>
                
                <Its:div runat="server" Type="SplitSingle" TabTitle="반품">
                    <Its:grid runat="server" ID="grid_RETURN" />  
                </Its:div>
            </Its:tab>
        </Its:div>
    </Its:div>
</asp:Content>

