<%-- PAGE --%>
<%@ Page Title="" Language="C#" MasterPageFile="~/Common/Master/MasterBase.master" AutoEventWireup="true" CodeFile="MST1005_S01.aspx.cs" Inherits="MST1005_S01" %>

<%-- HEAD --%>
<asp:Content ContentPlaceHolderID="CPH_HEAD" runat="Server">
    <script type="text/javascript" src="MST1005_S01.js?ver=<%= BasePage.srcVersion %>"></script>
</asp:Content>

<%-- SEARCH --%>
<asp:Content ContentPlaceHolderID="CPH_SEARCH" runat="Server">

</asp:Content>

<%-- BODY --%>
<asp:Content ContentPlaceHolderID="CPH_BODY" runat="Server">
    <Its:div runat="server" Type="SplitLeft" LeftWidthPc="20">
        <Its:div runat="server" Type="SplitTop" TopHeightPc="4">
            <Its:label runat="server" Text="■ 리비전" Bold="true" Margin="3px 0px 0px 10px" />
            <Its:button runat="server" Label="리비전 갱신" ID="btn_RENEW_REV" BackColor="CustomButton2" MarginTop="4" MarginLeft="4" />
            <Its:button runat="server" Label="저장" ID="btn_SAVE_REV" BackColor="CustomButton" MarginTop="4" MarginLeft="4" />
            <Its:button runat="server" Label="삭제" ID="btn_DEL_REV" BackColor="CustomButton3" MarginTop="4" MarginLeft="4" />
        </Its:div>

        <Its:split runat="server" Type="Horizon" Resizeable="false" />

        <Its:div runat="server" Type="SplitDown">
            <Its:grid runat="server" ID="grid1" />
        </Its:div>
    </Its:div>

    <Its:split runat="server" Type="Vertical" />

    <Its:div runat="server" Type="SplitRight">
        <Its:div runat="server" Type="SplitLeft" LeftWidthPc="50">
            <Its:div runat="server" Type="SplitTop" TopHeightPc="50">
                <Its:div runat="server" Type="SplitTop" TopHeightPc="7.5">
                    <Its:label runat="server" Text="■ 평가항목" Bold="true" Margin="3px 0px 0px 10px" />
                    <Its:button runat="server" Label="추가" ID="btn_ADD_D" BackColor="CustomButton2" MarginTop="4" MarginLeft="50" />
                    <Its:button runat="server" Label="저장" ID="btn_SAVE_D" BackColor="CustomButton" MarginTop="4" MarginLeft="4" />
                    <Its:button runat="server" Label="삭제" ID="btn_DEL_D" BackColor="CustomButton3" MarginTop="4" MarginLeft="4" />
                </Its:div>

                <Its:split runat="server" Type="Horizon" Resizeable="false" />

                <Its:div runat="server" Type="SplitDown">
                    <Its:grid runat="server" ID="grid2" />
                </Its:div>
            </Its:div>

            <Its:split runat="server" Type="Horizon" />

            <Its:div runat="server" Type="SplitDown">
                <Its:div runat="server" Type="SplitTop" TopHeightPc="7.5">
                    <Its:label runat="server" Text="점수별 평가기준" Bold="true" Margin="3px 0px 0px 10px" />
                    <Its:button runat="server" Label="추가" ID="btn_ADD_D2" BackColor="CustomButton2" MarginTop="4" MarginLeft="50" />
                    <Its:button runat="server" Label="저장" ID="btn_SAVE_D2" BackColor="CustomButton" MarginTop="4" MarginLeft="4" />
                    <Its:button runat="server" Label="삭제" ID="btn_DEL_D2" BackColor="CustomButton3" MarginTop="4" MarginLeft="4" />
                </Its:div>

                <Its:split runat="server" Type="Horizon" Resizeable="false" />

                <Its:div runat="server" Type="SplitDown">
                    <Its:grid runat="server" ID="grid3" />
                </Its:div>
            </Its:div>
        </Its:div>

        <Its:split runat="server" Type="Vertical" />

        <Its:div runat="server" Type="SplitRight">
            <Its:div runat="server" Type="SplitTop" TopHeightPc="4">
                <Its:label runat="server" Text="■ 설비등급 기준 (평가항목 점수 합계로 등급 판정)" Bold="true" Margin="3px 0px 0px 10px" />
                <Its:button runat="server" Label="추가" ID="btn_ADD_SCORE" BackColor="CustomButton2" MarginTop="4" MarginLeft="50" />
                <Its:button runat="server" Label="저장" ID="btn_SAVE_SCORE" BackColor="CustomButton" MarginTop="4" MarginLeft="4" />
                <Its:button runat="server" Label="삭제" ID="btn_DEL_SCORE" BackColor="CustomButton3" MarginTop="4" MarginLeft="4" />
            </Its:div>

            <Its:split runat="server" Type="Horizon" Resizeable="false" />

            <Its:div runat="server" Type="SplitDown">
                <Its:grid runat="server" ID="grid4" />
            </Its:div>
        </Its:div>
    </Its:div>
</asp:Content>
