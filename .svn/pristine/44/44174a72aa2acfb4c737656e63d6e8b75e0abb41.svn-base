<%-- PAGE --%>
<%@ Page Title="" Language="C#" MasterPageFile="~/Common/Master/MasterBase.master" AutoEventWireup="true" CodeFile="SYS0001_R01.aspx.cs" Inherits="SYS0001_R01" %>

<%-- HEAD --%>
<asp:Content ContentPlaceHolderID="CPH_HEAD" runat="Server">
    <script type="text/javascript" src="SYS0001_R01.js?ver=<%= BasePage.srcVersion %>"></script>
</asp:Content>

<%-- SEARCH PANEL --%>
<asp:Content ContentPlaceHolderID="CPH_SEARCH" runat="Server">
    <Its:div runat="server" Type="SearchPanel" ID="sdiv1">
        <Its:text runat="server" Label="키워드" Field="KEYWORD" ID="txt_KEYWORD_sdiv1"/>  
        <Its:onoff runat="server" Field="ACCYN" HiddenLabel="true" ID="onoff_ACCYN" OnText="일반코드" OffText="회계코드" Hidden="true" />  
    </Its:div>
</asp:Content>

<%-- BODY --%>
<asp:Content ContentPlaceHolderID="CPH_BODY" Runat="Server">
    <Its:div runat="server" Type="SplitLeft">
        <Its:grid runat="server" ID="grid1" />
    </Its:div>
    <Its:split runat="server" Type="Vertical"/>
    <Its:div runat="server" Type="SplitRight">
        <Its:div runat="server" Type="SplitTop" ID="ddiv1" Hidden="true">
            <Its:div runat="server" Type="SplitLeft" ID="ddiv1_1">
                <Its:text runat="server" Label="상세코드" Field="TPCD" ID="txt_TPCD2" ReadOnly="true" Required="true" />
                <Its:text runat="server" Label="상세명" Field="TPNM" />
                <Its:newline runat="server" />
                <Its:num runat="server" Label="순서" Field="SORTNO" ID="asd"/>
                <Its:onoff runat="server" Label="사용여부" Field="USEYN" />
                <Its:newline runat="server" />
                <Its:textarea runat="server" Label="비고" Field="REMARK" InputWidth="460" />
            </Its:div>
            <Its:split runat="server" Type="Vertical" />
            <Its:div runat="server" Type="SplitRight" ID="ddiv1_2">
                <Its:display runat="server" Label="등록" Field="REGISTER" InputWidth="200" />
                <Its:display runat="server" Label="수정" Field="MODIFY" InputWidth="200" />
                <Its:newline runat="server" />
                <Its:text runat="server" Label="REF01" Field="REF01" ID="REF01" />
                <Its:text runat="server" Label="REF02" Field="REF02" ID="REF02" />
                <Its:text runat="server" Label="REF03" Field="REF03" ID="REF03" />
                <Its:text runat="server" Label="REF04" Field="REF04" ID="REF04" />
                <Its:text runat="server" Label="REF05" Field="REF05" ID="REF05" />
                <Its:text runat="server" Label="REF06" Field="REF06" ID="REF06" />
                <Its:text runat="server" Label="REF07" Field="REF07" ID="REF07" />
                <Its:text runat="server" Label="REF08" Field="REF08" ID="REF08" />
                <Its:text runat="server" Label="REF09" Field="REF09" ID="REF09" />
                <Its:text runat="server" Label="REF10" Field="REF10" ID="REF10" />
                <Its:text runat="server" Label="REF11" Field="REF11" ID="REF11" />
                <Its:text runat="server" Label="REF12" Field="REF12" ID="REF12" />
                <Its:text runat="server" Label="REF13" Field="REF13" ID="REF13" />
                <Its:text runat="server" Label="REF14" Field="REF14" ID="REF14" />
                <Its:text runat="server" Label="REF15" Field="REF15" ID="REF15" />
                <Its:text runat="server" Label="REF16" Field="REF16" ID="REF16" />
                <Its:text runat="server" Label="REF17" Field="REF17" ID="REF17" />
                <Its:text runat="server" Label="REF18" Field="REF18" ID="REF18" />
                <Its:text runat="server" Label="REF19" Field="REF19" ID="REF19" />
                <%--<Its:text runat="server" Label="REF20" Field="REF20" ID="REF20" />--%>
            </Its:div>
        </Its:div>
        <Its:split runat="server" Type="Horizon"/>
        <Its:div runat="server" Type="SplitDown">
            <Its:grid runat="server" ID="grid2" />
        </Its:div>
    </Its:div>
</asp:Content>