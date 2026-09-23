<%-- 'CodeFile', 'Inherits' --%>
<%@ Page Title="" Language="C#" MasterPageFile="~/Common/Kiosk/Kiosk.master" AutoEventWireup="true" 
    CodeFile="TAL0001_R07.aspx.cs" Inherits="TAL0001_R07" %>

<%-- HEAD --%>
<asp:Content ContentPlaceHolderID="CPH_HEAD" Runat="Server">
    <script type="text/javascript" src="TAL0001_R07.js?ver=<%= BasePage.srcVersion %>"></script>
    <link rel="stylesheet" href="TAL0001_R07.css?ver=<%= BasePage.srcVersion %>" />
    <style type="text/css">
        #grid1 { height:315px !important; }
        #grid2 { height:315px !important; }
    </style>
</asp:Content>

<%-- SEARCH --%>
<asp:Content ContentPlaceHolderID="CPH_SEARCH" Runat="Server" >
</asp:Content>

<%-- BODY --%>
<asp:Content ContentPlaceHolderID="CPH_BODY" Runat="Server">

    <Its:div runat="server" Type="SplitSingle" >
        <Its:tab runat="server" ID="tab1">
            <Its:div runat="server" Type="SplitSingle" TabTitle="사용등록">
                <Its:div runat="server" Type="SplitTop" >
                    <Its:div runat="server" Type="SplitTop" >
                        <Its:find runat="server" Label="품목" ID="find1" Field="ITEMCD" GPCD="ITEMCD" REF05="MTR" REF02="ONE"  InputWidth="150" NameWidth="200"  />        
                        <Its:button runat="server" Label="부자재조회" Height="40" MarginLeft="50" ID="btn_SEARCH_SUBMAT" ForeColor="White"/>   
                    </Its:div>
                <Its:split runat="server" Type="Horizon"  Resizeable="false"/>
                
                <Its:div runat="server" Type="SplitDown" >
                      <Its:grid runat="server" ID="grid1"   />
                </Its:div>        
                </Its:div>        
                 <Its:split runat="server" Type="Horizon"  Resizeable="false"/>
    
            <Its:div runat="server" Type="SplitDown" >
                <Its:div runat="server" Type="SplitTop"  >
                   <Its:button runat="server" Label="사용등록" Height="40" MarginLeft="50" ID="btn_USE_SUBMAT" ForeColor="White" BackColor="CommonButton" Visible="true"/>
                </Its:div>
        
                <Its:split runat="server" Type="Horizon"  Resizeable="false"/>
        
                <Its:div runat="server" Type="SplitDown" >
                
                    <Its:div runat="server" Type="SplitLeft"  LeftWidthPc="25">

                       <Its:grid runat="server" ID="grid2"   />   
                   </Its:div>  
                     <Its:split runat="server" Type="Vertical"  Resizeable="false"/>
            
                   <Its:div runat="server" Type="SplitRight" >

                       <Its:grid runat="server" ID="grid3"   />   
                   </Its:div>  
             </Its:div>   
   
            </Its:div>
                  </Its:div>
            <Its:div runat="server" Type="SplitSingle" TabTitle="사용내역">
                    <Its:div runat="server" Type="SplitTop" ID="sdiv2" >
                        <Its:dateRange runat="server" Label="조회기간"  FieldFrom="SDATE" FieldTo="EDATE" />
                        <Its:find runat="server" Label="부자재" ID="sdiv2_find_ITEMCD" Field="ITEMCD" GPCD="ITEMCD" REF05="MTR" REF02="ONE"  InputWidth="150" NameWidth="200"  />        
                        <Its:button runat="server" Label="사용조회" Height="40" MarginLeft="50" ID="sdiv2_btn_SEARCH" ForeColor="White"/>   
                    </Its:div>
                       <Its:split runat="server" Type="Horizon"  Resizeable="false"/>
                
                      <Its:div runat="server" Type="SplitDown" >

                        <Its:grid runat="server" ID="grid4" />
                      </Its:div>
             </Its:div>
        </Its:tab>
    </Its:div>

 
</asp:Content>


<asp:Content ContentPlaceHolderID="CPH_POP" runat="server">
    <Its:pop runat="server" ID="pop1" Type="add" Title="부자재 사용등록" Width="1000" >
        <Its:div runat="server"  ID="pdiv1">
        <Its:date runat="server" Label="출고일자" Field="REGDATE"  Required="true" />
        <Its:combo runat="server" Label="출고유형" Field="OUTTP" GPCD="OUTTP" REF06="Y" Required="true"/>
        <Its:find runat="server" Label="작업자" Field="EMPCD" GPCD="EMPCD" ID="find_EMPCD" Required="true"/>
        <Its:newline runat="server" />      
        <Its:find runat="server" Label="부자재" Field="ITEMCD" GPCD="ITEMCD" ID="pop_find_ITEMCD"  ReadOnly="true"/>
        <Its:text runat="server" Label="로트키" Field="LOTKEY"  ID="pop_txt_LOTKEY"  ReadOnly="true" InputWidth="180"  MarginLeft="12"/>
        <Its:num runat="server" Label="출고수량" Field="OUTQTY"  ID="pop_num_OUTQTY"  MarginLeft="75"  InputWidth="128" DecimalPoint="0" />
     
        <Its:newline runat="server" /> 
        <Its:textarea runat="server" Label="비고" Field="REMARK" ID="pop_textarea_REMARK"  MarginLeft="50" InputWidth="810" InputHeight="100" />
        </Its:div>
    </Its:pop>
</asp:Content>