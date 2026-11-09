<%-- TAL0001_R08: 설비 정기점검 등록 (태블릿) --%>
<%@ Page Title="" Language="C#" MasterPageFile="~/Common/Kiosk/Kiosk.master" AutoEventWireup="true"
    CodeFile="TAL0001_R08.aspx.cs" Inherits="TAL0001_R08" %>


<%-- HEAD --%>
<asp:Content ContentPlaceHolderID="CPH_HEAD" Runat="Server" >
    <script type="text/javascript" src="TAL0001_R08.js?ver=<%= BasePage.srcVersion %>"></script>
    <link rel="stylesheet" href="TAL0001_R08.css?ver=<%= BasePage.srcVersion %>" />

</asp:Content>

<%-- SEARCH PANEL --%>
<asp:Content ContentPlaceHolderID="CPH_SEARCH" runat="Server">

</asp:Content>

<%-- BODY --%>
<asp:Content ContentPlaceHolderID="CPH_BODY" runat="Server">
    <Its:div runat="server" Type="SplitTop" ID="div_TOP">
        <Its:combo runat="server" Label="조회년도" ID="cmb_SYEAR" GPCD="YEAR" REF01="-4" REF02="0" MarginLeft="10" MarginTop="10" InputWidth="120" />
        <Its:find runat="server" Label="설비" ID="find_EQMCD" GPCD="EQMCD" MarginLeft="20" MarginTop="10" InputWidth="120" NameWidth="180" />
        <div id="MONTH_LIST"></div>
        <div id="EQM_LIST"></div>
    </Its:div>
    <Its:split runat="server" Type="Horizon" />
    <Its:div runat="server" Type="SplitDown">
        <Its:div runat="server" Type="SplitTop" ID="div1">
            <Its:button runat="server" Label="조    회" ID="btn_SEARCH" BackColor="CommonButton" MarginTop="10" MarginLeft="20" MarginBottom="10" Width="150" Height="50" />
            <Its:button runat="server" Label="점    검" ID="btn_REG" BackColor="CustomButton" MarginTop="10" MarginLeft="20" MarginBottom="10" Width="150" Height="50" />
            <Its:button runat="server" Label="수    정" ID="btn_EDIT" BackColor="GrayDark1" MarginTop="10" MarginLeft="20" MarginBottom="10" Width="150" Height="50" />
            <Its:button runat="server" Label="삭    제" ID="btn_DELETE" BackColor="CustomButton3" MarginTop="10" MarginLeft="20" MarginBottom="10" Width="150" Height="50" />
            <Its:button runat="server" Label="문제점/조치사항" ID="btn_REMARK" MarginTop="10" MarginLeft="20" MarginBottom="10" Width="200" Height="50" />
        </Its:div>
        <Its:split runat="server" Type="Horizon" Resizeable="false" />
        <Its:div runat="server" Type="SplitDown">
            <Its:div runat="server" Type="SplitLeft" LeftWidthPc="30">
                <Its:grid runat="server" ID="grid1" />
            </Its:div>
            <Its:split runat="server" Type="Vertical" />
            <Its:div runat="server" Type="SplitRight">
                <Its:grid runat="server" ID="grid2" />
            </Its:div>
        </Its:div>
    </Its:div>

</asp:Content>



<%-- POP --%>
<asp:Content ContentPlaceHolderID="CPH_POP" runat="server">
    <Its:pop runat="server" ID="pop1" Title="정기점검 등록" Type="add" Width="1200" Height="500">
        <Its:div runat="server" Type="SplitTop" ID="pdiv1">
            <Its:find runat="server" Label="설비" ID="pop1_find_EQMCD" Field="EQMCD" GPCD="EQMCD" InputWidth="120" NameWidth="180" ReadOnly="true" MarginTop="10" MarginBottom="10" />
            <Its:date runat="server" Label="점검일자" ID="pop1_date_BASEDATE" Field="BASEDATE" InputWidth="130" MarginTop="10" MarginBottom="10" />
            <Its:find runat="server" Label="점검자" ID="pop1_find_EMPCD" Field="EMPCD" GPCD="EMPCD" InputWidth="110" NameWidth="140" MarginTop="10" MarginBottom="10" />
            <Its:text runat="server" Label="년월" ID="pop1_txt_YYYYMM" Field="YYYYMM" Hidden="true" />
            <Its:text runat="server" Label="설비 REV" ID="pop1_txt_REVCD" Field="REVCD" Hidden="true" />
            <Its:text runat="server" Label="그룹 REV" ID="pop1_txt_GRPREVCD" Field="GRPREVCD" Hidden="true" />
            <Its:text runat="server" Label="문제점" ID="pop1_txt_PROBLEM" Field="PROBLEM" Hidden="true" />
            <Its:text runat="server" Label="조치사항" ID="pop1_txt_SOLUTION" Field="SOLUTION" Hidden="true" />
        </Its:div>

        <Its:split runat="server" Type="Horizon" Resizeable="false" />

        <Its:div runat="server" Type="SplitDown">
            <Its:grid runat="server" ID="grid3" />
        </Its:div>
    </Its:pop>

    <Its:pop runat="server" ID="pop2" Title="정기점검 수정" Type="add" Width="1200" Height="500">
        <Its:div runat="server" Type="SplitTop" ID="pdiv2">
            <Its:find runat="server" Label="설비" ID="pop2_find_EQMCD" Field="EQMCD" GPCD="EQMCD" InputWidth="120" NameWidth="180" ReadOnly="true" MarginTop="10" MarginBottom="10" />
            <Its:date runat="server" Label="점검일자" ID="pop2_date_BASEDATE" Field="BASEDATE" InputWidth="130" MarginTop="10" MarginBottom="10" />
            <Its:find runat="server" Label="점검자" ID="pop2_find_EMPCD" Field="EMPCD" GPCD="EMPCD" InputWidth="110" NameWidth="140" MarginTop="10" MarginBottom="10" />
            <Its:text runat="server" Label="년월" ID="pop2_txt_YYYYMM" Field="YYYYMM" Hidden="true" />
            <Its:text runat="server" Label="점검키" ID="pop2_txt_CHKRSTKEY" Field="CHKRSTKEY" Hidden="true" />
            <Its:text runat="server" Label="문제점" ID="pop2_txt_PROBLEM" Field="PROBLEM" Hidden="true" />
            <Its:text runat="server" Label="조치사항" ID="pop2_txt_SOLUTION" Field="SOLUTION" Hidden="true" />
        </Its:div>

        <Its:split runat="server" Type="Horizon" Resizeable="false" />

        <Its:div runat="server" Type="SplitDown">
            <Its:grid runat="server" ID="grid4" />
        </Its:div>
    </Its:pop>

    <Its:pop runat="server" ID="pop_NUM" Title="점검값등록" Width="390">
        <Its:div runat="server" Type="SplitTop" ID="pdiv_NUM" BackColor="White">
            <Its:num runat="server" Label="점검값" ReadOnly="true" ID="txt_VALUE_TAL0001_R08" MarginTop="70" LabelWidth="110" InputWidth="220" />
        </Its:div>

        <Its:split runat="server" Type="Horizon" Resizeable="false" />

        <Its:div runat="server" Type="SplitDown">
            <Its:button runat="server" Label="7" Width="90" Height="80" ID="btn_7_TAL0001_R08" BackColor="Black" />
            <Its:button runat="server" Label="8" Width="90" Height="80" ID="btn_8_TAL0001_R08" BackColor="Black" />
            <Its:button runat="server" Label="9" Width="90" Height="80" ID="btn_9_TAL0001_R08" BackColor="Black" />
            <Its:button runat="server" Label="◀" Width="90" Height="80" ID="btn_DEL_TAL0001_R08" BackColor="Black" />
            <Its:newline runat="server" />

            <Its:button runat="server" Label="4" Width="90" Height="80" ID="btn_4_TAL0001_R08" BackColor="Black" />
            <Its:button runat="server" Label="5" Width="90" Height="80" ID="btn_5_TAL0001_R08" BackColor="Black" />
            <Its:button runat="server" Label="6" Width="90" Height="80" ID="btn_6_TAL0001_R08" BackColor="Black" />
            <Its:button runat="server" Label="C" Width="90" Height="80" ID="btn_CLEAR_TAL0001_R08" ForeColor="White" />
            <Its:newline runat="server" />

            <Its:button runat="server" Label="1" Width="90" Height="80" ID="btn_1_TAL0001_R08" BackColor="Black" />
            <Its:button runat="server" Label="2" Width="90" Height="80" ID="btn_2_TAL0001_R08" BackColor="Black" />
            <Its:button runat="server" Label="3" Width="90" Height="80" ID="btn_3_TAL0001_R08" BackColor="Black" />
            <Its:button runat="server" Label="." Width="90" Height="80" ID="btn_DOT_TAL0001_R08" BackColor="Black" />
            <Its:newline runat="server" />

            <Its:button runat="server" Label="0" Width="186" Height="80" ID="btn_0_TAL0001_R08" BackColor="Black" />
            <Its:button runat="server" Label="등록" Width="186" Height="80" ID="btn_ADDVAL_TAL0001_R08" BackColor="CustomButton" />
        </Its:div>
    </Its:pop>

    <Its:pop runat="server" ID="pop_OK" Title="OK/NG 등록" Width="180">
        <Its:button runat="server" Label="OK" Width="141" Height="95" ID="btn_OK_TAL0001_R08" BackColor="CustomButton" />
        <Its:button runat="server" Label="NG" Width="141" Height="95" ID="btn_NG_TAL0001_R08" BackColor="CustomButton3" />
    </Its:pop>

    <Its:pop runat="server" ID="pop_ITEM_REMARK" Type="add" Title="특이사항" Width="900">
        <Its:textarea runat="server" Label="특이사항" ID="txtArea_ITEM_REMARK" InputWidth="760" InputHeight="200" />
    </Its:pop>

    <Its:pop runat="server" ID="pop_PROB_SOL" Type="add" Title="문제점/조치사항" Width="1250">
        <Its:textarea runat="server" Label="문제점" ID="txtArea_PROBLEM" InputWidth="500" InputHeight="180" />
        <Its:textarea runat="server" Label="조치사항" ID="txtArea_SOLUTION" InputWidth="500" InputHeight="180" />
    </Its:pop>
</asp:Content>
