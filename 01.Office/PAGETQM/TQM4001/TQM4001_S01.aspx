<%-- PAGE --%>
<%@ Page Title="" Language="C#" MasterPageFile="~/Common/Master/MasterBase.master" AutoEventWireup="true" CodeFile="TQM4001_S01.aspx.cs" Inherits="TQM4001_S01" %>

<%-- HEAD --%>
<asp:Content ContentPlaceHolderID="CPH_HEAD" runat="Server">
    <script type="text/javascript" src="TQM4001_S01.js?ver=<%= BasePage.srcVersion %>"></script>
    <script src="https://d3js.org/d3.v5.min.js"></script>                                               <%-- 네이버 차트 라이브러리는 d3.js 기반 --%>
    <script type="text/javascript" src="../../Script/billboardjs/billboard.min.js?ver=1.0"></script>    <%-- 차트 라이브러리 --%>
    <link rel="stylesheet" href="../../Script/billboardjs/billboard.min.css?ver=1.0"/>
    <link rel="stylesheet" href="../../Script/billboardjs/insight.min.css?ver=1.0"/>
</asp:Content>

<%-- SEARCH --%>
<asp:Content ContentPlaceHolderID="CPH_SEARCH" runat="Server">
    <Its:div runat="server" Type="SearchPanel" ID="sdiv1">
        <Its:dateRange runat="server" Label="조회일자" FieldFrom="SDATE" FieldTo="EDATE" ID="dataRange1"/>
        <Its:combo runat="server" Label="공장" ID="cmb_FACTORYCD" Field="FACTORYCD" GPCD="FACTORYCD" InputWidth="120" Hidden="true"/>   <%-- 숨김: 언제나 2공장(07, JS Load) --%>
        <Its:find runat="server" Label="품목" ID="sdiv1_find_ITEMID" GPCD="ITEMID" Field="ITEMID" InputWidth="130" />
        <Its:num runat="server" Label="n" Field="NVALUE" ID="num_NVALUE" Required="true" Value="2"/>
    </Its:div>
</asp:Content>

<%-- BODY --%>
<asp:Content ContentPlaceHolderID="CPH_BODY" runat="Server">
    <Its:div runat="server" Type="SplitLeft" LeftWidthPc="25">
        <Its:div runat="server" Type="SplitTop" TopHeightPc="40">
            <Its:grid runat="server" ID="grid2" />
        </Its:div>
        <Its:split runat="server" Type="Horizon" />
        <Its:div runat="server" Type="SplitDown" ID="ddiv1">
            <Its:div runat="server" Type="BasicFloat">
                <Its:num runat="server" Label="상한치" DecimalPoint="4" ID="num_STDMAX" ReadOnly="true"/>
                <Its:newline runat="server" />
                <Its:num runat="server" Label="하한치" DecimalPoint="4" ID="num_STDMIN" ReadOnly="true"/>
                <Its:newline runat="server" />
                <Its:num runat="server" Label="N" DecimalPoint="0" ID="num_BIGN" ReadOnly="true"/>
                <Its:newline runat="server" />
                <Its:num runat="server" Label="n" DecimalPoint="0" ID="num_NVALUE_2" ReadOnly="true"/>
                <Its:newline runat="server" />
                <Its:num runat="server" Label="평균" DecimalPoint="4" ID="num_AVG" ReadOnly="true"/>
                <Its:newline runat="server" />
                <Its:num runat="server" Label="표준편차 (전체)" DecimalPoint="4" ID="num_STDEV_ALL" ReadOnly="true"/>
                <Its:newline runat="server" />
                <Its:num runat="server" Label="표준편차 (군내)" DecimalPoint="4" ID="num_STDEV_GROUP" ReadOnly="true"/>
                <Its:newline runat="server" />
                <Its:num runat="server" Label="d2" DecimalPoint="4" ID="num_d2" ReadOnly="true"/>
            </Its:div>
            <Its:newline runat="server" Height="10" />
            <Its:div runat="server" Type="BasicFloat">
                <Its:label runat="server" Text="공정능력지수" Margin="0px 2px 0px 20px" />
                <Its:newline runat="server" />
                <Its:num runat="server" Label="PP" DecimalPoint="4" Field="PP" ID="num_PP" ReadOnly="true" InputWidth="70" />
                <Its:newline runat="server" />
                <Its:num runat="server" Label="PPL" DecimalPoint="4" Field="PPL" ID="num_PPL" ReadOnly="true" InputWidth="70"/>
                <Its:num runat="server" Label="PPK" DecimalPoint="4" Field="PPK" ID="num_PPK" ReadOnly="true" InputWidth="70" LabelWidth="70"/>
                <Its:newline runat="server" />
                <Its:num runat="server" Label="PPU" DecimalPoint="4" Field="PPU" ID="num_PPU" ReadOnly="true" InputWidth="70"/>
                <Its:label runat="server" Text="→ 결과:" MarginLeft="31" ID="label_RESULT_PPK"/>
                <Its:label runat="server" Text="" ID="label_PPK" Width="70" Align="center"/>
                <Its:newline runat="server" />

                <Its:num runat="server" Label="CP" DecimalPoint="4" Field="CP" ID="num_CP" ReadOnly="true" InputWidth="70"/>
                <Its:num runat="server" Label="CPK" DecimalPoint="4" Field="CPK" ID="num_CPK" ReadOnly="true" InputWidth="70" LabelWidth="70"/>
                <Its:newline runat="server" />
                <Its:num runat="server" Label="CPL" DecimalPoint="4" Field="CPL" ID="num_CPL" ReadOnly="true" InputWidth="70" />
                <Its:label runat="server" Text="→ 결과:" MarginLeft="31" ID="label_RESULT_CPK"/>
                <Its:label runat="server" Text="" ID="label_CPK" Width="70" Align="center"/>
                <Its:newline runat="server" />
                <Its:num runat="server" Label="CPU" DecimalPoint="4" Field="CPU" ID="num_CPU" ReadOnly="true" InputWidth="70"/>
            </Its:div>
        </Its:div>
    </Its:div>
    <Its:split runat="server" Type="Vertical"/>
    <Its:div runat="server" Type="SplitRight">
        <Its:div runat="server" Type="SplitTop" TopHeightPc="65">
            <Its:div runat="server" Type="SplitTop" TopHeightPc="50" ID="div_chart1">
                <div id="chart1"></div>
            </Its:div>
            <Its:split runat="server" Type="Horizon" />
            <Its:div runat="server" Type="SplitDown" ID="div_chart2">
                <div id="chart2"></div>
            </Its:div>
        </Its:div>
        <Its:split runat="server" Type="Horizon" />
        <Its:div runat="server" Type="SplitDown">
            <Its:grid runat="server" ID="grid1" />
        </Its:div>
    </Its:div>
</asp:Content>
