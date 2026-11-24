<%-- 기준관리 ▶ 기준관리 ▷ 공정라우팅 --%>

<%-- PAGE --%>
<%@ Page Title="" Language="C#" MasterPageFile="~/Common/Master/MasterBase.master" AutoEventWireup="true" CodeFile="MST1004_R01.aspx.cs" Inherits="MST1004_R01" %>

<%-- HEAD --%>
<asp:Content ContentPlaceHolderID="CPH_HEAD" runat="Server">
    <script type="text/javascript" src="MST1004_R01.js?ver=<%= BasePage.srcVersion %>"></script>
</asp:Content>

<%-- SEARCH --%>
<asp:Content ContentPlaceHolderID="CPH_SEARCH" Runat="Server">
    <Its:div runat="server" Type="SearchPanel" ID="sdiv1">
        <Its:combo runat="server" Label="작업장" Field="LINECD" GPCD="*LINECD" ID="cb_S_LINECD" REF01="07"/>
        <Its:find runat="server" Label="사원" Field="EMPCD" GPCD="EMPCD" REF01="44F30"/>
    </Its:div>
</asp:Content>

<%-- BODY --%>
<asp:Content ContentPlaceHolderID="CPH_BODY" Runat="Server">
    <Its:div runat="server" Type="SplitSingle">
        <Its:grid runat="server" ID="grid1" />
    </Its:div>
</asp:Content>

<%-- POP --%>
<asp:Content ContentPlaceHolderID="CPH_POP" runat="server" ID="pdiv1">
    <Its:pop runat="server" ID="pop1" Type="add" Title="호출사원 등록" Width="350" Height="380">
        <Its:div runat="server" Type="SplitTop" ID="pdiv2" TopHeightPc="14">
            <its:find runat="server" Label="사원" ID="find_EMPCD" GPCD="EMPCD" REF01="44F30" Field="EMPCD" LabelWidth="40"/>
            <Its:button runat="server" Label="조회" ID="btn_SEARCH" Width="80" Margin_Left="30px"/>          
        </Its:div>
        <Its:split runat="server" Type="Horizon" />
        <Its:div runat="server" Type="SplitDown" ID="pdiv3">
            <Its:div runat="server" Type="SplitTop" TopHeightPc="70">
                <Its:div runat="server" Type="SplitSingle">
                    <Its:grid runat="server" ID="grid2" />
                </Its:div>
            </Its:div>
            <Its:split runat="server" Type="Horizon" />
            <Its:div runat="server" Type="SplitDown" ID="pdiv4">
                <Its:newline runat="server" Height="10"/>
                <its:find runat="server" Label="작업장" GPCD="LINECD" Field="LINECD" ID="find_LINECD" InputWidth="80" LabelWidth="70"/>
                <Its:num runat="server" Label="호출도착&lt;br/&gt;지연시간(분)" Field="DELAYMIN_ARRIVE" Value="0" LabelWidth="70" InputWidth="70"/>
                <Its:num runat="server" Label="수리종료&lt;br/&gt;지연시간(분)" Field="DELAYMIN_REPAIR" Value="0" LabelWidth="70" InputWidth="70"/>
            </Its:div>
        </Its:div>
    </Its:pop>
</asp:Content>