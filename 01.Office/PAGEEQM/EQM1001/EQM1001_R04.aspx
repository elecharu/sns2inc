<%-- PAGE --%>
<%@ Page Title="" Language="C#" MasterPageFile="~/Common/Master/MasterBase.master" AutoEventWireup="true" CodeFile="EQM1001_R04.aspx.cs" Inherits="EQM1001_R04" %>

<%-- HEAD --%>
<asp:Content ContentPlaceHolderID="CPH_HEAD" runat="Server">
    <script type="text/javascript" src="EQM1001_R04.js?ver=<%= BasePage.srcVersion %>"></script>
</asp:Content>

<%-- SEARCH PANEL --%>
<asp:Content ContentPlaceHolderID="CPH_SEARCH" runat="Server">
    <Its:div runat="server" Type="SearchPanel" ID="sdiv1">
       <Its:combo runat="server" Label="조회년도" ID="cmb_SYEAR" Field="SYEAR" GPCD="YEAR" REF01="-4" REF02="0" />
       <Its:find runat="server" Label="설비" Field="EQMCD" GPCD="EQMCD" ID="find_EQMCD"/>       
    </Its:div>
</asp:Content>


<%-- BODY --%>
<asp:Content ContentPlaceHolderID="CPH_BODY" runat="Server">
    <Its:div runat="server" Type="SplitSingle">
        <Its:grid runat="server" ID="grid1" />   
    </Its:div>
</asp:Content>


<%-- POP --%>
<asp:Content ContentPlaceHolderID="CPH_POP" runat="server">
    <Its:pop runat="server" ID="pop1" Title="정기점검 등록" Type="add" Width="900" Height="350">        
        <Its:div runat="server" Type="SplitTop" ID="pdiv1">
            <Its:find runat="server" Label="설비코드" ID="pop1_find_EQMCD" Field="EQMCD" GPCD="EQMCD" InputWidth="80" ReadOnly="true" />
            <Its:date runat="server" Label="점검일자" ID="pop1_date_BASEDATE" Field="BASEDATE"  InputWidth="120" />
            <Its:find runat="server" Label="점검자" ID="pop1_find_EMPCD" Field="EMPCD" GPCD="EMPCD"   InputWidth="110" />
            <%-- 2026-09-30 정기점검 등록 팝업: 적용 REV 표시(라벨이라 저장 값에 포함되지 않음), 저장 시 적용 REV 번호 전달, 새 REV 승인 대기 안내 --%>
            <Its:label runat="server" Text="" ID="pop1_lbl_REVNM" Bold="true" MarginLeft="10"/>
            <Its:text runat="server" Label="REV번호" ID="pop1_txt_REVNUM" Field="REVNUM" Hidden="true"/>
            <Its:label runat="server" Text="" ID="pop1_lbl_REV_INFO" ForeColor="Danger" MarginLeft="10"/>
            <Its:newline runat="server" />
            <Its:textarea runat="server" Label="문제점" ID="pop1_txtarea_PROBLEM" Field="PROBLEM" InputWidth="345" />
            <Its:textarea runat="server" Label="조치사항" ID="pop1_txtarea_SOLUTION" Field="SOLUTION" InputWidth="345" />
            <Its:text runat="server" Label="년월" ID="txt_YYYYMM" Field="YYYYMM" Hidden="true"/>
        </Its:div>

        <Its:split runat="server" Type="Horizon" Resizeable="false"/>

        <Its:div runat="server" Type="SplitDown" ID="pdiv2"  >
            <Its:grid runat="server" ID="grid2"/>
        </Its:div> 
    </Its:pop>

    <Its:pop runat="server" ID="pop2" Title="정기점검 수정" Type="add" Width="900" Height="350">        
        <Its:div runat="server" Type="SplitTop" ID="pdiv3">
            <Its:find runat="server" Label="설비코드" ID="pop2_find_EQMCD" Field="EQMCD" GPCD="EQMCD" InputWidth="80" ReadOnly="true" />
            <Its:date runat="server" Label="점검일자" ID="pop2_date_BASEDATE" Field="BASEDATE"  InputWidth="120" />
            <Its:find runat="server" Label="점검자" ID="pop2_find_EMPCD" Field="EMPCD" GPCD="EMPCD"   InputWidth="110" />
            <%-- 2026-09-30 정기점검 수정 팝업: 실적에 기록된 적용 REV 표시(라벨이라 저장 값에 포함되지 않음) --%>
            <Its:label runat="server" Text="" ID="pop2_lbl_REVNM" Bold="true" MarginLeft="10"/>
            <Its:newline runat="server" />
            <Its:textarea runat="server" Label="문제점" ID="pop2_txtarea_PROBLEM" Field="PROBLEM" InputWidth="345" />
            <Its:textarea runat="server" Label="조치사항" ID="pop2_txtarea_SOLUTION" Field="SOLUTION" InputWidth="345" />          
            <Its:newline runat="server" />
            <Its:button runat="server" Label="점검삭제" ID="pop2_btn_DELETE_CHKRSTEQM" BackColor="CustomButton3" Float="right"/>
            <Its:newline runat="server" />
            <Its:text runat="server" Label="년월" ID="pop2_txt_YYYYMM" Field="YYYYMM" Hidden="true"/>
            <Its:text runat="server" Label="점검키" ID="pop2_txt_CHKRSTKEY" Field="CHKRSTKEY" Hidden="true"/>
        </Its:div>

        <Its:split runat="server" Type="Horizon" Resizeable="false"/>

        <Its:div runat="server" Type="SplitDown" ID="Div2"  >              
            <Its:grid runat="server" ID="grid3"/>               
        </Its:div>         
    </Its:pop>
</asp:Content>