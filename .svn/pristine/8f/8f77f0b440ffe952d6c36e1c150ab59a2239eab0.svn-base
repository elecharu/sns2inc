<%-- PAGE --%>
<%@ Page Title="" Language="C#" MasterPageFile="~/Common/Master/MasterBase.master" AutoEventWireup="true" CodeFile="PDA1200_R01.aspx.cs" Inherits="PDA1200_R01" %>

<%-- HEAD --%>
<asp:Content ContentPlaceHolderID="CPH_HEAD" runat="Server">
    <script type="text/javascript" src="PDA1200_R01.js?ver=<%= BasePage.srcVersion %>"></script>
    <style type="text/css">
        
        #txt_pop_LOTKEY_CNT { text-align: right }
        #txt_pop_LOTQTY_SUM { text-align: right }
        #txt_pop_SCAN_OUTQTY { text-align: right }        
        
    </style>
</asp:Content>
<%-- BODY --%>
<asp:Content ContentPlaceHolderID="CPH_BODY" runat="Server">
    <Its:div runat="server" Type="BasicBlock" ID="Div1">
        <Its:div runat="server" Type="SearchPanel" ID="sp_DIV">
            <Its:date runat="server" Label="출고일자" Field="SDATE" ID="date_OUTDATE_SDATE" Required="true" InputWidth="80" LabelWidth="58"/>
            <Its:date runat="server" Label="" Field="EDATE" ID="date_OUTDATE_EDATE" Required="true" InputWidth="80" LabelWidth="0" />                        
            <Its:newline runat="server" Height="5" />
            <Its:find runat="server" Label="거래처" Field="CUSTCD" GPCD ="CUSTCD"  ID="find_CUSTCD" InputWidth="80" LabelWidth="58"/>        
            <Its:newline runat="server" Height="5" />                         
            <Its:button runat="server" Label="조회" Width ="310" Height="30" ID="btn_LIST_SALOUT_GROUP"  />
        </Its:div>        
        <Its:div runat="server" Type="SplitSingle" ID="Div3">
            <Its:newline runat="server" Height="5" />
            <Its:grid runat="server" ID="grid_SALOUT_GROUP" Height ="350"/>
            <Its:newline runat="server" Height="5" />
            
            <Its:button runat="server" Label="선택" Width="330" Height="40" ID="btn_SALOUT_GROUP_SELECT" />
        </Its:div>
    </Its:div>
</asp:Content>

<asp:Content ContentPlaceHolderID="CPH_POP" runat="Server">
    
    <Its:pop runat="server" ID="pop_SALOUT" Title="품목선택" Width="370"> 
        <Its:grid runat="server" ID="grid_SALOUT" Height ="350" />
        <Its:newline runat="server" Height="5" />
        <Its:text runat="server" Field="LOTKEY" Label="LOT스캔" LabelWidth="70" InputWidth="200" ID="txt_lotkey" ReadOnly="false" Hidden="true"/>
        <%--<Its:Text runat="server" Field="LOTQTY" Label="스캔수량" LabelWidth="70"  InputWidth="100" ID="txt_lotqty" ReadOnly="true" Hidden="false"/>--%>
        <Its:newline runat="server" Height="5" />
        <Its:button runat="server" Label="출하스캔" Width="350" Height="40" ID="btn_SALOUT_SELECT" />
        <Its:newline runat="server" Height="5" />        
        <%--<Its:button runat="server" Label="출하완료" Width="150" Height="40" ID="Button2" BackColor="CustomButton"/>
        <Its:button runat="server" Label="완료 취소" Width="150" Height="40" ID="Button3" BackColor="CustomButton3"/>--%>
        <Its:newline runat="server" Height="5" />
    </Its:pop>
    
    <Its:pop runat="server" ID="pop_SCAN" Title="LOT 스캔" Width="310" >        
        <div id="div_panel">
            <Its:text runat="server" Field="SALOUTDATE" Label="출고일자" LabelWidth="70"  InputWidth="200" ID="txt_pop_SCAN_SALOUTDATE" ReadOnly="true" />
            <Its:newline runat="server"/>
            <Its:combo runat="server" Field="WARECD" Label="출고창고" GPCD="WARECD" LabelWidth="70"  InputWidth="180" ID="cmb_pop_SCAN_WARECD" ReadOnly="true"  />
            <Its:newline runat="server"/>
            <Its:text runat="server" Field="CUSTNM" Label="거래처" LabelWidth="70"  InputWidth="200" ID="txt_pop_SCAN_CUSTNM" ReadOnly="true" />
            <Its:newline runat="server"/>            
            <Its:text runat="server" Field="CARMODEL" Label="차종" LabelWidth="70" InputWidth="200" ID="txt_pop_SCAN_CARMODEL" ReadOnly="true"/>
            <Its:newline runat="server"/>
            <Its:text runat="server" Field="ITEMCD" Label="품목코드" LabelWidth="70" InputWidth="200" ID="txt_pop_SCAN_ITEMCD" ReadOnly="true"/>
            <Its:newline runat="server"/>     
            <Its:text runat="server" Field="ITEMNM" Label="품명" LabelWidth="70" InputWidth="200" ID="txt_pop_SCAN_ITEMNM" ReadOnly="true"/>

            <Its:newline runat="server"/>                     
            <Its:Text runat="server" Field="OUTQTY" Label="지시수량" LabelWidth="70" InputWidth="59" ID="txt_pop_SCAN_OUTQTY" ReadOnly="true" />            
            <Its:Text runat="server" Field="LOTQTY_SUM" Label="스캔수량" LabelWidth="60"  InputWidth="58" ID="txt_pop_LOTQTY_SUM" ReadOnly="true"  Required="true"/>
            <Its:text runat="server" Field="LOTKEY" Label="LOT스캔" LabelWidth="70" InputWidth="200" ID="txt_pop_SCAN_LOTKEY" ReadOnly="false"/>
            <Its:newline runat="server"/>                
        </div>

            <Its:grid runat="server" ID="grid_SALOUTLOT" Height ="200" />
            <Its:newline runat="server" Height="5" />
            <Its:button runat="server" Label="출고검사 등록" Width="145" Height="40" ID="btn_POP_OUTTEST" BackColor="CustomButton2"/>
            <Its:button runat="server" Label="출고 확정" Width="145" Height="40" ID="btn_FINISH_SALOUT" BackColor="CustomButton"/>
            <Its:newline runat="server" Height="5" />
        
    </Its:pop>     
    
    
    <Its:pop runat="server" ID="pop_OUTTEST" Title="출고검사 등록" Width="310" >        
        <Its:grid runat="server" ID="grid_OUTTEST" Height ="200" />
        <Its:newline runat="server" Height="5" />        
        <Its:button runat="server" Label="출고검사 등록" Width="300" Height="40" ID="btn_SAVE_OUTTEST" BackColor="CustomButton2"/>        
    </Its:pop>         
</asp:Content>