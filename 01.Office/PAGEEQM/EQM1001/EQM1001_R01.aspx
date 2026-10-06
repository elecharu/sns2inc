<%-- PAGE --%>
<%@ Page Title="" Language="C#" MasterPageFile="~/Common/Master/MasterBase.master" AutoEventWireup="true" CodeFile="EQM1001_R01.aspx.cs" Inherits="EQM1001_R01" %>

<%-- HEAD --%>
<asp:Content ContentPlaceHolderID="CPH_HEAD" runat="Server">
    <script type="text/javascript" src="EQM1001_R01.js?ver=<%= BasePage.srcVersion %>"></script>
</asp:Content>

<%-- SEARCH PANEL --%>
<asp:Content ContentPlaceHolderID="CPH_SEARCH" runat="Server">
    <Its:div runat="server" ID="sdiv1" Type="SearchPanel">
        <Its:dateRange runat="server" Label="등록일자" ID="date_SEARCH" FieldFrom="SDATE" FieldTo="EDATE" />
        <Its:find runat="server" Label="설비코드" ID="find_code" GPCD="EQMCD" Field="EQMCD" />
        <Its:find runat="server" Label="작업자" ID="find_EMP" GPCD="EMPCD" Field="EMPCD" InputWidth="70" NameWidth="160" />
    </Its:div>
</asp:Content>

<%-- BODY --%>
<asp:Content ContentPlaceHolderID="CPH_BODY" runat="Server">
     <Its:div runat="server" Type="SplitLeft" ID="bdiv1" LeftWidthPc ="80">
        <Its:grid runat="server" ID="grid1"/>
    </Its:div>
    <Its:split runat="server" Type="Vertical" />
    <Its:div runat="server" Type="SplitRight" ID="bdiv2"  >       
            <Its:button runat="server" Label="행추가" ID="bdiv2_btn_ADD" MarginLeft="50" BackColor="CustomButton2" />
            <Its:button runat="server" Label="행삭제" ID="bdiv2_btn_DEL" MarginLeft="10" BackColor="CustomButton3" />
            <Its:text runat="server" Label="설비수리키" ID="bdiv2_txt_EQMREPKEY" Field="EQMREPKEY" Hidden="true" />
            <Its:newline runat="server" />
        <Its:grid runat="server" ID="grid2"/>
    </Its:div>


</asp:Content>

<%-- POP --%>
<asp:Content ContentPlaceHolderID="CPH_POP" runat="server">
    <Its:pop runat="server" Type="add" ID="pop1" Title="설비이력 추가" Width="850" Height="470">
        <Its:div runat="server" Type="SplitTop" ID="pdiv1" LeftWidthPc ="80">
            <Its:find runat="server" Label="설비코드" ID="pop1_find_EQMCD" Field="EQMCD" GPCD="EQMCD" InputWidth="100"  NameWidth="198" />

            <Its:newline runat="server" />
            <Its:date runat="server" Label="등록일자" ID="pop1_date_REGDAY" Field="REGDAY" />
            <Its:date runat="server" Label="발생일자" ID="pop1_date_REPSDAY" Field="REPSDAY" />
            <Its:date runat="server" Label="완료일자" ID="pop1_date_REPEDAY" Field="REPEDAY" ReadOnly="true" Value="" />
            <Its:check runat="server" Label="완료일자 사용여부" Field="REPEYN" ID="pop1_check_REPEYN"  MarginLeft="82" Value="N" />
           
            <Its:newline runat="server" />
            <Its:text runat="server" Label="등록일시" ID="pop1_txt_REGDAYTIME"  Field="REGTIME" InputWidth="111" Type="hhmm"  />
            <Its:text runat="server" Label="발생일시" ID="pop1_txt_REPSTIME"  Field="REPSTIME" InputWidth="110" Type="hhmm"  />
            <Its:text runat="server" Label="완료일시" ID="pop1_txt_REPETIME"  Field="REPETIME" InputWidth="111" Type="hhmm" ReadOnly="true" />     
            <Its:num runat="server" Label="소요일" ID="pop1_num_REPUTIME" Field="REPUTIME" Value="0" ReadOnly="true" />
            <Its:newline runat="server" />
            
            <Its:text runat="server" Label="수리업체" ID="pop1_txt_REPCUST" Field="REPCUST" InputWidth="315" />
            <Its:num runat="server" Label="수리금액(만원)" ID="pop1_num_REPAMT" Field="REPAMT" Value="0" />
            <Its:combo runat="server" Label="고장원인구분" ID="pop1_com_ISSUE" Field="ISSUE" GPCD="ISSUE" />
            <Its:newline runat="server" />
            <Its:textarea runat="server" Label="고장원인" ID="pop1_txtarea_MALFUNCTION" Field="MALFUNCTION" InputWidth="723" />
            <Its:newline runat="server" />
            <Its:textarea runat="server" Label="처리내용" ID="pop1_txtarea_HANDLE" Field="HANDLE" InputWidth="723" />
            <Its:newline runat="server" />
            <Its:textarea runat="server" Label="비고" ID="pop1_txtarea_REMARK" Field="REMARK" InputWidth="723" />
        </Its:div>

        <Its:split runat="server" Type="Horizon" />

        <Its:div runat="server" Type="SplitDown" ID="pdiv2"  >            
            <Its:button runat="server" Label="행추가" ID="pdiv2_btn_ADD" MarginLeft="700" BackColor="CustomButton2"   />
            <Its:button runat="server" Label="행삭제" ID="pdiv2_btn_DEL" MarginLeft="10" BackColor="CustomButton3" />
            <Its:newline runat="server" />
            <Its:grid runat="server" ID="grid3"/>
        </Its:div>

    </Its:pop>
</asp:Content>