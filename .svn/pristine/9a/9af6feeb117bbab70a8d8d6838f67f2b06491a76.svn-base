<%-- 'CodeFile', 'Inherits' --%>
<%@ Page Title="" Language="C#" MasterPageFile="~/Common/Kiosk/Kiosk.master" AutoEventWireup="true" 
    CodeFile="TAL0001_R05.aspx.cs" Inherits="TAL0001_R05" %>


<%-- HEAD --%>
<asp:Content ContentPlaceHolderID="CPH_HEAD" Runat="Server" >
    <script type="text/javascript" src="TAL0001_R05.js?ver=<%= BasePage.srcVersion %>"></script>
    <link rel="stylesheet" href="TAL0001_R05.css?ver=<%= BasePage.srcVersion %>" />
   
</asp:Content>

<%-- SEARCH PANEL --%>
<asp:Content ContentPlaceHolderID="CPH_SEARCH" runat="Server">

</asp:Content>

<%-- BODY --%>
<asp:Content ContentPlaceHolderID="CPH_BODY" runat="Server">
    <Its:div runat="server" Type="SplitTop">

    <div id="EQM_LIST" 
         style="width:100%;
         height:130px;
         overflow:auto;
         padding:0px;">
    </div>

    </Its:div>
    <Its:split runat="server" Type="Horizon" />
    <Its:div runat="server" Type="SplitDown">
        <Its:div runat="server" Type="SplitTop" ID="div1">
            <Its:dateRange runat="server" Label="조회일자" FieldFrom="SDATE" FieldTo="EDATE" ID="date_RANGEDATE" MarginTop="15"/>
            <Its:find runat="server" Label="작업자" Field="EMPCD" ID="find_EMPCD" GPCD="EMPCD" InputWidth="100"  NameWidth="100" MarginTop="15"/>
             <Its:newline runat="server" Resizeable="false" />
             <Its:button runat="server" Label="조    회" ID="btn_SEARCH" BackColor="CommonButton" MarginTop="10" MarginLeft="20" MarginBottom="10" Width="150" Height="50"   />
             <Its:button runat="server" Label="점    검" ID="btn_REG"  BackColor="CustomButton" MarginTop="10" MarginLeft="20" MarginBottom="10" Width="150" Height="50"/>
             <Its:button runat="server" Label="수    정" ID="btn_EDIT" BackColor="GrayDark1" MarginTop="10"  MarginLeft="20" MarginBottom="10" Width="150" Height="50"/>
             <Its:button runat="server" Label="삭    제" ID="btn_DELETE" BackColor="CustomButton3" MarginTop="10" MarginLeft="20" MarginBottom="10" Width="150" Height="50"/>
             <Its:button runat="server" Label="문제점/조치사항" ID="btn_REMARK" MarginTop="10" MarginLeft="20" MarginBottom="10" Width="200"  Height="50"/>
        </Its:div>
      <Its:split runat="server" Type="Horizon" Resizeable="false" />
        <Its:div runat="server" Type="SplitDown">
            <Its:div runat="server" Type="SplitLeft"  LeftWidthPc="18"  >
                <Its:grid runat="server" ID="grid1"   />
           </Its:div>     
           <Its:split runat="server" Type="Vertical" />
           
           <Its:div runat="server" Type="SplitRight" >
                <Its:grid runat="server" ID="grid2" />
           </Its:div>   
        
        </Its:div>
    </Its:div>
    
</asp:Content>



<%-- POP --%>
<asp:Content ContentPlaceHolderID="CPH_POP" runat="server">
    <Its:pop runat="server" ID="pop1" Title="일상점검 등록" Type="add" Width="1200" Height="500">        
        <Its:div runat="server" Type="SplitTop" ID="pdiv1">
            <Its:find runat="server" Label="설비코드" ID="pop1_find_EQMCD" Field="EQMCD" GPCD="EQMCD" InputWidth="80" ReadOnly="true"  Hidden="true"/>
            <Its:date runat="server" Label="점검일자" ID="pop1_date_BASEDATE" Field="BASEDATE"  InputWidth="120" />
            <Its:date runat="server" Label="등록일자" ID="pop1_txt_REGDATE" Field="DATE"  InputWidth="120" />
            <Its:text runat="server" Label="등록시간" ID="pop1_txt_BASETIME"  Field="BASETIME" InputWidth="5" Type="hhmm" HiddenLabel="true"   />
   
            <Its:find runat="server" Label="점검자" ID="pop1_find_EMPCD" Field="EMPCD" GPCD="EMPCD"   InputWidth="110" />
   
        </Its:div>

        <Its:split runat="server" Type="Horizon" Resizeable="false"/>

        <Its:div runat="server" Type="SplitDown"  >

            <Its:grid runat="server" ID="grid3"/>
        </Its:div> 
    </Its:pop>

    <Its:pop runat="server" ID="pop2" Title="일상점검 수정" Type="add" Width="1200" Height="500">        
        <Its:div runat="server" Type="SplitTop" ID="pdiv2">
            <Its:find runat="server" Label="설비코드" ID="pop2_find_EQMCD" Field="EQMCD" GPCD="EQMCD" InputWidth="80" ReadOnly="true" Hidden="true"/>
            <Its:date runat="server" Label="점검일자" ID="pop2_date_BASEDATE" Field="BASEDATE"  InputWidth="120" />
            <Its:date runat="server" Label="등록일자" ID="pop2_date_REGDATE" Field="DATE"  InputWidth="120" />
            <Its:text runat="server" Label="등록시간" ID="pop2_txt_BASETIME"  Field="BASETIME" InputWidth="5" Type="hhmm" HiddenLabel="true"   />  

            <Its:find runat="server" Label="점검자" ID="pop2_find_EMPCD" Field="EMPCD" GPCD="EMPCD"   InputWidth="110" />
 
            
        </Its:div>

       <Its:split runat="server" Type="Horizon" Resizeable="false"/>

        <Its:div runat="server" Type="SplitDown"  >

            <Its:grid runat="server" ID="grid4"/>
        </Its:div>    
    </Its:pop>

    <%--------------------------------점검값 팝업--------------------------------------------------------------------------------------------------------------------------%>
    <Its:pop runat="server" ID="pop_NUM" Title="점검값등록" Width="390"   >
        <Its:div runat="server" Type="SplitTop" ID="pdiv_GOODQTY" BackColor="White">       
            <Its:num runat="server" Label="점검값" ReadOnly="true" ID="txt_GOODQTY_TAL0001_R05" MarginTop="70" LabelWidth="110" InputWidth="220" />
        </Its:div>

        <Its:split runat="server" Type="Horizon" Resizeable="false"/>

        <Its:div runat="server" Type="SplitDown">
            
            <Its:button runat="server" Label="7" Width="90" Height="80" ID="btn_7_TAL0001_R05" BackColor="Black"/>
            <Its:button runat="server" Label="8" Width="90" Height="80" ID="btn_8_TAL0001_R05" BackColor="Black"  />
            <Its:button runat="server" Label="9" Width="90" Height="80" ID="btn_9_TAL0001_R05" BackColor="Black"/>
            <Its:button runat="server" Label="◀" Width="90" Height="80" ID="btn_DEL_TAL0001_R05" BackColor="Black"/>
            <Its:newline runat="server" />

            <Its:button runat="server" Label="4" Width="90" Height="80" ID="btn_4_TAL0001_R05" BackColor="Black"/>
            <Its:button runat="server" Label="5" Width="90" Height="80" ID="btn_5_TAL0001_R05" BackColor="Black"/>
            <Its:button runat="server" Label="6" Width="90" Height="80" ID="btn_6_TAL0001_R05" BackColor="Black"/>
            <Its:button runat="server" Label="C" Width="90" Height="80" ID="btn_CLEAR_TAL0001_R05" ForeColor="White"/>
            <Its:newline runat="server" />

            <Its:button runat="server" Label="1" Width="90" Height="80" ID="btn_1_TAL0001_R05" BackColor="Black"/>
            <Its:button runat="server" Label="2" Width="90" Height="80" ID="btn_2_TAL0001_R05" BackColor="Black"/>
            <Its:button runat="server" Label="3" Width="90" Height="80" ID="btn_3_TAL0001_R05" BackColor="Black"/>
            <Its:button runat="server" Label="등" Width="90" Height="80" ID="btn_ADDRST_TAL0001_R05" ForeColor="White"/>
            <Its:newline runat="server" />

            <Its:button runat="server" Label="0" Width="90" Height="80" ID="btn_0_TAL0001_R05" BackColor="Black"/>            
            <Its:button runat="server" Label="00" Width="90" Height="80" ID="btn_00_TAL0001_R05" BackColor="Black"/>
            <Its:button runat="server" Label="." Width="90" Height="80" ID="btn_DOT_TAL0001_R05" BackColor="Black"/>    
            <Its:button runat="server" Label="록" Width="90" Height="80" ID="btn_ADDRST2_TAL0001_R05" ForeColor="White"/>        
        </Its:div>
    </Its:pop>


    <Its:pop runat="server" ID="pop_OK" Title="OK/NG 등록" Width="180">
       <Its:button runat="server" Label="OK" Width="141" Height="95" ID="btn_OK_TAL0001_R05" BackColor="CustomButton"/>
       <Its:button runat="server" Label="NG" Width="141" Height="95" ID="btn_NG_TAL0001_R05" BackColor="CustomButton3"  />     
    </Its:pop>




     <%--------------------------------수정값 팝업--------------------------------------------------------------------------------------------------------------------------%>
    <Its:pop runat="server" ID="pop_EDIT_NUM" Title="수정값등록" Width="390"   >
        <Its:div runat="server" Type="SplitTop" ID="pdiv_EDITQTY" BackColor="White">       
              <Its:num runat="server" Label="점검값" ReadOnly="true" ID="txt_EDITQTY_TAL0001_R05" MarginTop="70" LabelWidth="110" InputWidth="220" />
        </Its:div>

        <Its:split runat="server" Type="Horizon" Resizeable="false"/>

        <Its:div runat="server" Type="SplitDown">
            
            <Its:button runat="server" Label="7" Width="90" Height="80" ID="btn_7_EDIT_TAL0001_R05" BackColor="Black"/>
            <Its:button runat="server" Label="8" Width="90" Height="80" ID="btn_8_EDIT_TAL0001_R05" BackColor="Black"  />
            <Its:button runat="server" Label="9" Width="90" Height="80" ID="btn_9_EDIT_TAL0001_R05" BackColor="Black"/>
            <Its:button runat="server" Label="◀" Width="90" Height="80" ID="btn_DEL_EDIT_TAL0001_R05" BackColor="Black"/>
            <Its:newline runat="server" />

            <Its:button runat="server" Label="4" Width="90" Height="80" ID="btn_4_EDIT_TAL0001_R05" BackColor="Black"/>
            <Its:button runat="server" Label="5" Width="90" Height="80" ID="btn_5_EDIT_TAL0001_R05" BackColor="Black"/>
            <Its:button runat="server" Label="6" Width="90" Height="80" ID="btn_6_EDIT_TAL0001_R05" BackColor="Black"/>
            <Its:button runat="server" Label="C" Width="90" Height="80" ID="btn_CLEAR_EDIT_TAL0001_R05" ForeColor="White"/>
            <Its:newline runat="server" />

            <Its:button runat="server" Label="1" Width="90" Height="80" ID="btn_1_EDIT_TAL0001_R05" BackColor="Black"/>
            <Its:button runat="server" Label="2" Width="90" Height="80" ID="btn_2_EDIT_TAL0001_R05" BackColor="Black"/>
            <Its:button runat="server" Label="3" Width="90" Height="80" ID="btn_3_EDIT_TAL0001_R05" BackColor="Black"/>
            <Its:button runat="server" Label="수" Width="90" Height="80" ID="btn_ADDRST_EDIT_TAL0001_R05" ForeColor="White"/>
            <Its:newline runat="server" />

            <Its:button runat="server" Label="0" Width="90" Height="80" ID="btn_0_EDIT_TAL0001_R05" BackColor="Black"/>            
            <Its:button runat="server" Label="00" Width="90" Height="80" ID="btn_00_EDIT_TAL0001_R05" BackColor="Black"/>
            <Its:button runat="server" Label="." Width="90" Height="80" ID="btn_DOT_EDIT_TAL0001_R05" BackColor="Black"/>    
            <Its:button runat="server" Label="정" Width="90" Height="80" ID="btn_ADDRST2_EDIT_TAL0001_R05" ForeColor="White"/>        
        </Its:div>
    </Its:pop>


    <Its:pop runat="server" ID="pop_EDIT_OK" Title="OK/NG 수정" Width="180">
       <Its:button runat="server" Label="OK" Width="141" Height="95" ID="btn_OK_EDIT_TAL0001_R05" BackColor="CustomButton"/>
       <Its:button runat="server" Label="NG" Width="141" Height="95" ID="btn_NG_EDIT_TAL0001_R05" BackColor="CustomButton3"  />     
    </Its:pop>


    <Its:pop runat="server" ID="pop_PROB_SOL"  Type="add" Title="문제점/조치사항" Width="1250" >
       <Its:textarea runat="server" Label="문제점" ID="txtArea_PROBLEM" Field="PROBLEM" InputWidth="500" InputHeight="180"  />

        <Its:textarea runat="server" Label="조치사항" ID="txtArea_SOLUTION" Fiel="SOLUTION" InputWidth="500" InputHeight="180" />
    </Its:pop>
</asp:Content>