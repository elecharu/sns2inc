<%-- PAGE --%>
<%@ Page Title="" Language="C#" MasterPageFile="~/Common/Master/MasterBase.master" AutoEventWireup="true" CodeFile="MST1005_R01.aspx.cs" Inherits="MST1005_R01" %>

<%-- HEAD --%>
<asp:Content ContentPlaceHolderID="CPH_HEAD" runat="Server">
    <script type="text/javascript" src="MST1005_R01.js?ver=<%= BasePage.srcVersion %>"></script>
</asp:Content>

<%-- SEARCH --%>
<asp:Content ContentPlaceHolderID="CPH_SEARCH" runat="Server">
    <Its:div runat="server" Type="SearchPanel" ID="sdiv1">
        <Its:dateRange runat="server" Label="조회일자" ID="date_SEARCH" FieldFrom="SDATE" FieldTo="EDATE" />
        <Its:combo runat="server" Label="작업장" Field="LINECD" ID="cmb_LINECD" REF01="07" GPCD="*LINECD" />
        <Its:combo runat="server" Label="공정" Field="EQMTP" ID="cmb_EQMTP" GPCD="*EQMTP" />
        <Its:combo runat="server" Label="라인" Field="EQMGROUP1" ID="cmb_EQMGROUP1" GPCD="*EQMGROUP1" />
    </Its:div>
</asp:Content>

<%-- BODY --%>
<asp:Content ContentPlaceHolderID="CPH_BODY" runat="Server">
    <Its:div runat="server" Type="SplitLeft" LeftWidthPc="45">
        <Its:div runat="server" Type="SplitTop" TopHeightPc="3">
            <Its:label runat="server" Text="■ 설비목록" Bold="true" Margin="3px 0px 0px 10px" />
        </Its:div>

        <Its:split runat="server" Type="Horizon" Resizeable="false" />

        <Its:div runat="server" Type="SplitDown">
            <Its:grid runat="server" ID="grid1" />
        </Its:div>
    </Its:div>

    <Its:split runat="server" Type="Vertical" />

    <Its:div runat="server" Type="SplitRight">
        <Its:div runat="server" Type="SplitTop" TopHeightPc="3">
            <Its:label runat="server" Text="■ 평가이력" Bold="true" Margin="3px 0px 0px 10px" />
            <Its:button runat="server" Label="신규평가" ID="btn_NEW_EVAL" BackColor="CustomButton2" MarginTop="4" MarginLeft="50" />
            <Its:button runat="server" Label="승인" ID="btn_APRV" BackColor="CustomButton" MarginTop="4" MarginLeft="4" />
        </Its:div>

        <Its:split runat="server" Type="Horizon" Resizeable="false" />

        <Its:div runat="server" Type="SplitDown">
            <Its:grid runat="server" ID="grid2" />
        </Its:div>
    </Its:div>
</asp:Content>

<%-- POP --%>
<asp:Content ContentPlaceHolderID="CPH_POP" runat="server">
    <Its:pop runat="server" ID="pop1" Type="add" Title="설비등급 평가" Width="1300" Height="700">
        <Its:div runat="server" Type="SplitTop" ID="pdiv1" TopHeightPc="15">
            <Its:text runat="server" Label="평가키" ID="pop1_txt_EQMGRADEEVALKEY" Field="EQMGRADEEVALKEY" Hidden="true" />
            <Its:text runat="server" Label="설비코드" ID="pop1_txt_FANO" Field="FANO" ReadOnly="true" LabelWidth="70" InputWidth="180" />
            <Its:text runat="server" Label="설비명" ID="pop1_txt_EQMNM" Field="EQMNM" ReadOnly="true" LabelWidth="70" InputWidth="330" />
            <Its:date runat="server" Label="평가일자" ID="pop1_date_EVALDATE" Field="EVALDATE" LabelWidth="70" InputWidth="183" />
            <Its:find runat="server" Label="평가자" ID="pop1_find_EMPCD" Field="EMPCD" GPCD="EMPCD" LabelWidth="70" InputWidth="100" NameWidth="169" />
            <Its:newline runat="server" />
            <Its:num runat="server" Label="합계점수" ID="pop1_num_TOTSCORE" Field="TOTSCORE" Value="0" ReadOnly="true" LabelWidth="70" InputWidth="180" />
            <Its:combo runat="server" Label="평가등급" ID="pop1_cmb_EQMGRADE" Field="EQMGRADE" GPCD="@FM110" ReadOnly="true" LabelWidth="70" InputWidth="289" />
            <Its:text runat="server" Label="비고" ID="pop1_txt_REMARK" Field="REMARK" LabelWidth="70" InputWidth="544" />
            <Its:newline runat="server" />
            <Its:label runat="server" Text="※ 계산구분이 없는 평가항목은 오른쪽 점수별 평가기준을 더블클릭하여 점수를 선택합니다." Margin="3px 0px 0px 0px" />
        </Its:div>

        <Its:split runat="server" Type="Horizon" Resizeable="false" />

        <Its:div runat="server" Type="SplitDown">
            <Its:div runat="server" Type="SplitLeft" LeftWidthPc="55">
                <Its:grid runat="server" ID="grid3" />
            </Its:div>

            <Its:split runat="server" Type="Vertical" />

            <Its:div runat="server" Type="SplitRight">
                <Its:div runat="server" Type="SplitTop" TopHeightPc="55">
                    <Its:grid runat="server" ID="grid4" />
                </Its:div>

                <Its:split runat="server" Type="Horizon" />

                <Its:div runat="server" Type="SplitDown">
                    <Its:grid runat="server" ID="grid5" />
                </Its:div>
            </Its:div>
        </Its:div>
    </Its:pop>

    <Its:pop runat="server" ID="pop2" Type="add" Title="평가 승인" Width="510" AddBtnName="승인">
        <Its:div runat="server" Type="SplitSingle" ID="pdiv2">
            <Its:find runat="server" Label="승인자" ID="pop2_find_APRVEMP" Field="APRVEMP" GPCD="EMPCD" LabelWidth="70" InputWidth="70" NameWidth="110" />
            <Its:date runat="server" Label="승인일자" ID="pop2_date_APRVDATE" Field="APRVDATE" LabelWidth="70" InputWidth="105" MarginLeft="8" />
            <Its:newline runat="server" />
            <Its:text runat="server" Label="비고" ID="pop2_txt_REMARK" Field="REMARK" LabelWidth="70" InputWidth="385" MarginTop="6" />
        </Its:div>
    </Its:pop>
</asp:Content>
