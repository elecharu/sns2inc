<%-- 'CodeFile', 'Inherits' --%>
<%@ Page Title="" Language="C#" MasterPageFile="~/Common/Master/MasterBase.master" AutoEventWireup="true" 
    CodeFile="SYS0000_R02.aspx.cs" Inherits="SYS0000_R02" %>

<%-- HEAD 'src' --%>
<asp:Content ContentPlaceHolderID="CPH_HEAD" Runat="Server">
    <script type="text/javascript" src="SYS0000_R02.js?ver=<%= BasePage.srcVersion %>"></script>
    <style>
        #div_pass, #div_pluskey {
             width: 300px;
             height: 180px;
             margin: 10px;
             padding: 10px;
        }
    </style>
</asp:Content>

<%-- SEARCH --%>
<asp:Content ContentPlaceHolderID="CPH_SEARCH" Runat="Server">
    <Its:div runat="server" Type="SearchPanel" ID="sdiv1">
    </Its:div>
</asp:Content>

<%-- BODY --%>
<asp:Content ContentPlaceHolderID="CPH_BODY" Runat="Server">
    <Its:tab runat="server" ID="tab1">
        <Its:div runat="server" Type="SplitSingle" TabTitle="마이메뉴 관리">
            <Its:div runat="server" Type="SplitLeft">
                <Its:grid runat="server" ID="grid1" />
            </Its:div>
            <Its:split runat="server" Type="Vertical" />
            <Its:div runat="server" Type="SplitRight">
                <Its:div runat="server" Type="SplitTop" TopHeightPc="60">
                    <Its:div runat="server" Type="SplitTop">
                        <Its:label runat="server" Text=" * 마이 메뉴" Bold="true" />
                    </Its:div>
                    <Its:split runat="server" Type="Horizon" />
                    <Its:div runat="server" Type="SplitDown">
                        <Its:grid runat="server" ID="grid2"/>
                    </Its:div>
                </Its:div>
                <Its:split runat="server" Type="Horizon" />
                <Its:div runat="server" Type="SplitDown">
                    <Its:div runat="server" Type="SplitTop">
                        <Its:label runat="server" Text=" * 자주 사용한 메뉴" Bold="true" />
                    </Its:div>
                    <Its:split runat="server" Type="Horizon" />
                    <Its:div runat="server" Type="SplitDown">
                        <Its:grid runat="server" ID="grid3"/>
                    </Its:div>
                </Its:div>
            </Its:div>
        </Its:div>
        <Its:div runat="server" Type="SplitSingle" TabTitle="사용자 관리">
            <Its:div runat="server" Type="BorderFloat" ID="div_pass">
                <Its:newline runat="server" Height="20" />
                <Its:label runat="server" Text=" * 패스워드 변경 " Bold="true" Margin="0px 10px" />
                <Its:newline runat="server" />
                <Its:text runat="server" ID="pw_bf" LabelWidth="100" Label="이전 비밀번호" Type="password" />
                <Its:newline runat="server" />
                <Its:text runat="server" ID="pw_new" LabelWidth="100" Label="새 비밀번호" Type="password" />
                <Its:newline runat="server" />
                <Its:text runat="server" ID="pw_new2" LabelWidth="100" Label="비밀번호 확인" Type="password" />
                <Its:newline runat="server" Height="5" />
                <Its:button runat="server" ID="MODIFY_PASSWORD" Label="패스워드 변경" MarginLeft="120" />
                <Its:newline runat="server" Height="5" />
            </Its:div>
            <Its:div runat="server" Type="BorderFloat" ID="div_pluskey">
                <Its:newline runat="server" Height="30" />
                <Its:label runat="server" Text=" * 숫자 입력 컨트롤  우측 키패드 + 입력시 000 입력 " Bold="true" Margin="0px 10px" />
                <Its:newline runat="server" Height="5" />
                <Its:label runat="server" Text=" * 저장 후 재 로그인시 적용 됩니다." Bold="true" Margin="0px 10px" />
                <Its:newline runat="server" Height="40" />
                <Its:onoff runat="server" OnText="사용" OffText="미사용" InputWidth="55" LabelWidth="60" Field="PLUSKEYYN" ID="onoff_PLUSKEYYN" />
                <Its:button runat="server" ID="MODIFY_PLUSKEY" Label="저장" />
                <Its:newline runat="server" Height="30" />
            </Its:div>
        </Its:div>
    </Its:tab>
</asp:Content>