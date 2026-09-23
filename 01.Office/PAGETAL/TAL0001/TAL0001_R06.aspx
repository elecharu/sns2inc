<%-- 'CodeFile', 'Inherits' --%>
<%@ Page Title="" Language="C#" MasterPageFile="~/Common/Kiosk/Kiosk.master" AutoEventWireup="true" 
    CodeFile="TAL0001_R06.aspx.cs" Inherits="TAL0001_R06" %>


<%-- HEAD --%>
<asp:Content ContentPlaceHolderID="CPH_HEAD" Runat="Server" >
    <script type="text/javascript" src="TAL0001_R06.js?ver=<%= BasePage.srcVersion %>"></script>
    <link rel="stylesheet" href="TAL0001_R06.css?ver=<%= BasePage.srcVersion %>" />
   
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
        <Its:div runat="server" Type="SplitTop">
            <Its:button runat="server" Label="비가동조회" ID="btn_SEARH" BackColor="CommonButton" MarginTop="10" MarginLeft="50" MarginBottom="10" Width="150" Height="50"/>
            <Its:button runat="server" Label="시작/종료" ID="btn_REG"  BackColor="CustomButton" MarginTop="10" MarginLeft="50" MarginBottom="10" Width="150" Height="50"/>
            <Its:button runat="server" Label="추     가" ID="btn_ADD"  MarginTop="10"  MarginLeft="50" MarginBottom="10" Width="150" Height="50"/>
            <Its:button runat="server" Label="수     정" ID="btn_EDIT" BackColor="GrayDark1" MarginTop="10" MarginLeft="50" MarginBottom="10" Width="150" Height="50"/>
            <Its:button runat="server" Label="삭     제" ID="btn_DELETE" BackColor="CustomButton3" MarginTop="10" MarginLeft="50" MarginBottom="10" Width="150" Height="50"/>              
            <Its:button runat="server" Label="점검사항/조치사항" ID="btn_REMARK" BackColor="PurpleDark1" MarginTop="10" MarginLeft="50" MarginBottom="10" Width="20"  Height="50"/>
        </Its:div>
      <Its:split runat="server" Type="Horizon" Resizeable="false" />
      <Its:div runat="server" Type="SplitDown">
         <Its:grid runat="server" ID="grid1" />
      </Its:div>
    </Its:div>

</asp:Content>


<%-- POP --%>
<asp:Content ContentPlaceHolderID="CPH_POP" runat="server">
    <%--시작/종료 팝업--%>
     <Its:pop runat="server" ID="pop_STARTEND" Type="common"  Width="1360" Height="400" > 
            <Its:date runat="server" Label="시작시간" ID="pop1_date_STARTDATE" Field="STARTDATE"  InputWidth="120" MarginTop="10" />
            <Its:text runat="server" Label="시작시간" ID="pop1_txt_STARTTIME"  Field="STARTTIME" InputWidth="20" Type="hhmmss" HiddenLabel="true" MarginTop="10"  />
            <Its:button runat="server" Label="시작" ID="pop1_btn_START" BackColor="CustomButton"  MarginLeft="30" MarginTop="10"  />

            <Its:date runat="server" Label="종료시간" ID="pop1_date_ENDDATE" Field="ENDDATE"  InputWidth="120" MarginLeft="100"   MarginTop="10" />
            <Its:text runat="server" Label="종료시간" ID="pop1_txt_ENDTIME"  Field="ENDTIME" InputWidth="20" Type="hhmmss" HiddenLabel="true"   MarginTop="10" />
            <Its:button runat="server" Label="종료" ID="pop1_btn_END" BackColor="CustomButton3"  MarginLeft="30"  MarginTop="10" />
        <Its:newline runat="server" />
        <hr style="margin:10px 0; border:1px solid #dcdcdc;" />
            <div id="NONTP_LIST"  
                 style="width:100%;
                 height:110px;
                 overflow:auto;
                 padding:0px;">
            </div>
        <hr style="margin:10px 0; border:1px solid #dcdcdc;" />
            <div id="MSTNON_LIST" 
                 style="width:100%;
                 height:110px;
                 overflow:auto;
                 padding:0px;">
            </div>
        <hr style="margin:10px 0; border:1px solid #dcdcdc;" />
     </Its:pop>

    <%--추가 팝업--%>
      <Its:pop runat="server" ID="pop_ADD" Type="common"  Width="1360" Height="400" > 
        <Its:date runat="server" Label="시작시간" ID="pop2_date_STARTDATE" Field="STARTDATE"  InputWidth="120" MarginTop="10" />
        <Its:text runat="server" Label="시작시간" ID="pop2_txt_STARTTIME"  Field="STARTTIME" InputWidth="20" Type="hhmmss" HiddenLabel="true" MarginTop="10"  />
    
        <Its:date runat="server" Label="종료시간" ID="pop2_date_ENDDATE" Field="ENDDATE"  InputWidth="120" MarginLeft="100"   MarginTop="10" />
        <Its:text runat="server" Label="종료시간" ID="pop2_txt_ENDTIME"  Field="ENDTIME" InputWidth="20" Type="hhmmss" HiddenLabel="true"   MarginTop="10" />
        <Its:button runat="server" Label="추가" ID="pop2_btn_ADD" BackColor="CommonButton"  MarginLeft="220" MarginTop="10" />
       <Its:newline runat="server" />
        <hr style="margin:10px 0; border:1px solid #dcdcdc;" />
            <div id="NONTP2_LIST"  
                    style="width:100%;
                    height:110px;
                    overflow:auto;
                    padding:0px;">
            </div>
        <hr style="margin:10px 0; border:1px solid #dcdcdc;" />
            <div id="MSTNON2_LIST" 
                    style="width:100%;
                    height:110px;
                    overflow:auto;
                    padding:0px;">
            </div>
        <hr style="margin:10px 0; border:1px solid #dcdcdc;" />
       </Its:pop>


    <%--수정 팝업--%>
    <Its:pop runat="server" ID="pop_EDIT" Type="common"  Width="1360" Height="400" > 
        <Its:date runat="server" Label="시작시간" ID="pop3_date_STARTDATE" Field="STARTDATE"  InputWidth="120" MarginTop="10" />
        <Its:text runat="server" Label="시작시간" ID="pop3_txt_STARTTIME"  Field="STARTTIME" InputWidth="20" Type="hhmmss" HiddenLabel="true" MarginTop="10"  />
    
        <Its:date runat="server" Label="종료시간" ID="pop3_date_ENDDATE" Field="ENDDATE"  InputWidth="120" MarginLeft="100"   MarginTop="10" />
        <Its:text runat="server" Label="종료시간" ID="pop3_txt_ENDTIME"  Field="ENDTIME" InputWidth="20" Type="hhmmss" HiddenLabel="true"   MarginTop="10" />
        <Its:button runat="server" Label="수정" ID="pop3_btn_EDIT" BackColor="CommonButton"  MarginLeft="220" MarginTop="10" />
   <Its:newline runat="server" />
    <hr style="margin:10px 0; border:1px solid #dcdcdc;" />
        <div id="NONTP3_LIST"  
                style="width:100%;
                height:110px;
                overflow:auto;
                padding:0px;">
        </div>
    <hr style="margin:10px 0; border:1px solid #dcdcdc;" />
        <div id="MSTNON3_LIST" 
                style="width:100%;
                height:110px;
                overflow:auto;
                padding:0px;">
        </div>
    <hr style="margin:10px 0; border:1px solid #dcdcdc;" />
   </Its:pop>

    <Its:pop runat="server" ID="pop_PROB_SOL"  Type="add" Title="점검사항/조치사항" Width="1250" >
       <Its:textarea runat="server" Label="점검사항" ID="txtArea_PROBLEM" Field="PROBLEM" InputWidth="500" InputHeight="180"  />

        <Its:textarea runat="server" Label="조치사항" ID="txtArea_SOLUTION" Fiel="SOLUTION" InputWidth="500" InputHeight="180" />
    </Its:pop>
</asp:Content>