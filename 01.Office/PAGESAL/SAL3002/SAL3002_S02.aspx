<%-- SAL3002_S02: 영업관리 ▶ 판매계획대비 출하실적조회 --%>

<%-- PAGE --%>
<%@ Page Title="" Language="C#" MasterPageFile="~/Common/Master/MasterBase.master" AutoEventWireup="true" CodeFile="SAL3002_S02.aspx.cs" Inherits="SAL3002_S02" %>

<%-- HEAD --%>
<asp:Content ContentPlaceHolderID="CPH_HEAD" runat="Server">
    <script type="text/javascript" src="SAL3002_S02.js?ver=<%= BasePage.srcVersion %>"></script>
</asp:Content>

<%-- SEARCH --%>
<asp:Content ContentPlaceHolderID="CPH_SEARCH" runat="Server">
    <Its:div runat="server" Type="SearchPanel" ID="sdiv1">
        <Its:month runat="server" Label="조회년월" ID="mon_SMONTH" Field="SMONTH" />
        <Its:button runat="server" Label="엑셀 내보내기" ID="btn_EXPORT" MarginLeft="20" BackColor="CustomButton2" hidden="true"/>
    </Its:div>
</asp:Content>

<%-- BODY --%>
<asp:Content ContentPlaceHolderID="CPH_BODY" runat="Server">
    <Its:tab runat="server" ID="tab1">
        <%-- 메인탭: 엑셀 "표지" 1~4 --%>
        <Its:div runat="server" Type="SplitSingle" TabTitle="메인">
            <Its:div runat="server" Type="SplitLeft" LeftWidthPc="50">
                <Its:div runat="server" Type="SplitTop" TopHeightPc="30">
                    <Its:div runat="server" Type="SplitTop">
                        <Its:label runat="server" Text="■ 1. 판매계획 대비 출하실적 현황 (단위: 원)" Bold="true" MarginLeft="10" />
                    </Its:div>
                    <Its:split runat="server" Type="Horizon" Resizeable="false" />
                    <Its:div runat="server" Type="SplitDown">
                        <Its:grid runat="server" ID="grid_GUBUN" />
                    </Its:div>
                </Its:div>

                <Its:split runat="server" Type="Horizon" />

                <Its:div runat="server" Type="SplitDown">
                    <Its:div runat="server" Type="SplitTop">
                        <Its:label runat="server" Text="■ 2. 고객사별 계획 대비 실적 현황 (단위: 원)" Bold="true" MarginLeft="10" />
                    </Its:div>
                    <Its:split runat="server" Type="Horizon" Resizeable="false" />
                    <Its:div runat="server" Type="SplitDown">
                        <Its:grid runat="server" ID="grid_CUST" />
                    </Its:div>
                </Its:div>
            </Its:div>

            <Its:split runat="server" Type="Vertical" />

            <Its:div runat="server" Type="SplitRight">
                <Its:div runat="server" Type="SplitTop" TopHeightPc="65">
                    <Its:div runat="server" Type="SplitTop">
                        <Its:label runat="server" Text="■ 3. 변동사유 기준 (단위: 원)" Bold="true" MarginLeft="10" />
                    </Its:div>
                    <Its:split runat="server" Type="Horizon" Resizeable="false" />
                    <Its:div runat="server" Type="SplitDown">
                        <Its:grid runat="server" ID="grid_REASON" />
                    </Its:div>
                </Its:div>

                <Its:split runat="server" Type="Horizon" />

                <Its:div runat="server" Type="SplitDown">
                    <Its:div runat="server" Type="SplitTop">
                        <Its:label runat="server" Text="■ 4. 판매계획 대비 실적 (단위: 원)" Bold="true" MarginLeft="10" />
                    </Its:div>
                    <Its:split runat="server" Type="Horizon" Resizeable="false" />
                    <Its:div runat="server" Type="SplitDown">
                        <Its:grid runat="server" ID="grid_PLAN" />
                    </Its:div>
                </Its:div>
            </Its:div>
        </Its:div>

        <%-- 상세탭: 엑셀 "세부내역" 고객사 ~ 비고 --%>
        <Its:div runat="server" Type="SplitSingle" TabTitle="세부내역">
            <Its:grid runat="server" ID="grid_DETAIL" />
        </Its:div>
    </Its:tab>
</asp:Content>
