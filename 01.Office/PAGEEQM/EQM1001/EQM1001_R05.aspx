<%-- PAGE --%>
<%@ Page Title="" Language="C#" MasterPageFile="~/Common/Master/MasterBase.master" AutoEventWireup="true" CodeFile="EQM1001_R05.aspx.cs" Inherits="EQM1001_R05" %>

<%-- HEAD --%>
<asp:Content ContentPlaceHolderID="CPH_HEAD" runat="Server">
    <script type="text/javascript" src="EQM1001_R05.js?ver=<%= BasePage.srcVersion %>"></script>
</asp:Content>

<%-- BODY --%>
<asp:Content ContentPlaceHolderID="CPH_BODY" runat="Server">
    <Its:tab runat="server" ID="tab_PLAN">
        <%-- 설비그룹별 점검계획 승인관리 탭 --%>
        <Its:div runat="server" Type="SplitSingle" TabTitle="설비그룹별 점검계획">
            <Its:div runat="server" Type="SplitTop" TopHeightPc="3" BackColor="White" ID="div_GRP_PLAN">
                <Its:find runat="server" Label="설비그룹" Field="EQMGRP" GPCD="FM116" ID="find_GRP" MarginLeft="-25" MarginTop="3" InputWidth="120" NameWidth="150" />
                <Its:combo runat="server" Label="승인상태" Field="APRVSTT" ID="cmb_GRP_APRVSTT" MarginLeft="20" MarginTop="3" InputWidth="80" />
                <Its:text runat="server" Label="반려사유" Field="REJREASON" ID="txt_GRP_REJREASON" MarginLeft="20" MarginTop="3" InputWidth="300" />
                <Its:button runat="server" Label="승인" ID="btn_GRP_APPROVE" MarginLeft="20" MarginTop="3" BackColor="CustomButton" />
                <Its:button runat="server" Label="반려" ID="btn_GRP_REJECT" MarginLeft="10" MarginTop="3" BackColor="CustomButton3" />
                <Its:button runat="server" Label="계획서 출력" ID="btn_GRP_PLAN_RPT" Float="right" MarginRight="10" MarginTop="3" BackColor="CustomButton2" />
            </Its:div>

            <Its:split runat="server" Type="Horizon" Resizeable="false" />

            <Its:div runat="server" Type="SplitDown">
                <Its:grid runat="server" ID="grid_GRP_PLAN" />
            </Its:div>
        </Its:div>

        <%-- 설비별 점검계획 승인관리 탭 --%>
        <Its:div runat="server" Type="SplitSingle" TabTitle="설비별 점검계획">
            <Its:div runat="server" Type="SplitTop" TopHeightPc="3" BackColor="White" ID="div_EQM_PLAN">
                <Its:find runat="server" Label="설비" Field="FANO" GPCD="EQMCD" ID="find_EQMCD" MarginLeft="-25" MarginTop="3" InputWidth="100" NameWidth="180" />
                <Its:combo runat="server" Label="승인상태" Field="APRVSTT" ID="cmb_EQM_APRVSTT" MarginLeft="20" MarginTop="3" InputWidth="80" />
                <Its:text runat="server" Label="반려사유" Field="REJREASON" ID="txt_EQM_REJREASON" MarginLeft="20" MarginTop="3" InputWidth="300" />
                <Its:button runat="server" Label="승인" ID="btn_EQM_APPROVE" MarginLeft="20" MarginTop="3" BackColor="CustomButton" />
                <Its:button runat="server" Label="반려" ID="btn_EQM_REJECT" MarginLeft="10" MarginTop="3" BackColor="CustomButton3" />
                <Its:button runat="server" Label="계획서 출력" ID="btn_EQM_PLAN_RPT" Float="right" MarginRight="10" MarginTop="3" BackColor="CustomButton2" />
            </Its:div>

            <Its:split runat="server" Type="Horizon" Resizeable="false" />

            <Its:div runat="server" Type="SplitDown">
                <Its:grid runat="server" ID="grid_EQM_PLAN" />
            </Its:div>
        </Its:div>
    </Its:tab>
</asp:Content>