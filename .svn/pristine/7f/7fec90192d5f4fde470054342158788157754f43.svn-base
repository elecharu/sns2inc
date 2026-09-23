<%-- 'CodeFile', 'Inherits' --%>
<%@ Page Title="" Language="C#" MasterPageFile="~/Common/Master/MasterBase.master" AutoEventWireup="true" 
    CodeFile="SYS1001_R01.aspx.cs" Inherits="SYS1001_R01" %>

<%-- HEAD --%>
<asp:Content ContentPlaceHolderID="CPH_HEAD" Runat="Server">
    <script type="text/javascript" src="SYS1001_R01.js?ver=<%= BasePage.srcVersion %>"></script>
    <link rel="stylesheet" href="SYS1001_R01.css?ver=<%= BasePage.srcVersion %>" />
    <script src="http://dmaps.daum.net/map_js_init/postcode.v2.js"></script>    <%-- DAUM 우편번호 API --%>
</asp:Content>

<%-- BODY --%>
<asp:Content ContentPlaceHolderID="CPH_BODY" Runat="Server" >
    <Its:div runat="server" Type="SplitTop" ID="ddiv1">
        <Its:div runat="server" Type="BasicBlock" >
            <Its:div runat="server" Type="SplitLeft">
                <Its:div runat="server" Type="BasicFloat" >
                    <Its:div runat="server" Type="BasicFloat">    
                        <Its:div runat="server" Type="BorderFloat" >
                            <div><b>로고 이미지</b></div>
                            <Its:newline runat="server" />
                            <Its:div runat="server" Type="BorderBlock" >
                                <Its:img runat="server" ID="img_LOGO" Height="160" Width="160" />
                            </Its:div>
                            <Its:newline runat="server" />
                            <Its:fileManager runat="server" StyleType="simple" FileType="image" Field="LOGOIMAGE" ID="file_LOGOIMAGE" bindImageId="img_LOGO" />
                        </Its:div>
                    </Its:div>

                    <Its:div runat="server" Type="BasicFloat" >
                        <Its:text runat="server" Label="회사명(약칭)" Field="COMPNM" LabelWidth="100" InputWidth="180"/>
                        <Its:newline runat="server" />
                        <Its:text runat="server" Label="대표자명" Field="REPRENM" LabelWidth="100" InputWidth="180"/>
                        <Its:newline runat="server" />
                        <Its:text runat="server" Label="대표자 직위" Field="COLONELCY" LabelWidth="100" InputWidth="180" />
                        <Its:newline runat="server" />
                        <Its:text runat="server" Label="회사명(정식)" Field="COMPNMFULL" LabelWidth="100" InputWidth="180"/>
                        <Its:newline runat="server" />
                        <Its:text runat="server" Label="업태" Field="INDTYPE" LabelWidth="100" InputWidth="180" />
                        <Its:newline runat="server" />
                        <Its:text runat="server" Label="종목" Field="INDCLASS" LabelWidth="100" InputWidth="180" />
                        <Its:newline runat="server" />
<%--                        <Its:text runat="server" Label="사업자 등록번호" Field="COMPREGNO" ID="txt_COMPREGNO" LabelWidth="100" InputWidth="180" />
                        <Its:newline runat="server" />--%>
                        <Its:text runat="server" Label="홈페이지" Field="HOMEURL" LabelWidth="100" InputWidth="180" ID="txt_HOMEURL" />
                        <Its:newline runat="server" />
                        <Its:display runat="server" HiddenLabel="true" InputWidth="90" />
                        <%--<Its:button runat="server" Label="이동" ID="MOVE_HOMEPAGE" BackColor="Theme" />--%>
                    </Its:div>  <%-- 사명(약칭), 대표자명, 사명(정식)  --%>
                </Its:div>
                <Its:div runat="server" Type="BasicFloat" >
                        <Its:text runat="server" Label="우편번호" Field="ZIPCD" ID="txt_ZIPCD" LabelWidth="100" InputWidth="70" ReadOnly="true"/>
                        <Its:button runat="server" Label="검색" ID="SEARCH_ZIP" />
                        <Its:text runat="server" Label="도로명 주소" Field="ADDRESS" ID="txt_ADDRESS" InputWidth="250" LabelWidth="134" ReadOnly="true"/>
                        <Its:newline runat="server" />
                        <Its:text runat="server" Label="건물명" Field="ADDRESSDETAIL" ID="txt_ADDRESSDETAIL" LabelWidth="100"  InputWidth="150" ReadOnly="true" />
                        <Its:text runat="server" Label="상세 주소" Field="ADDRESSOTHER" ID="txt_ADDRESSOTHER" LabelWidth="100" InputWidth="250" />
                        <Its:newline runat="server" />
                        <Its:text runat="server" Label="전체 주소" Field="ADDRESSFULL" ID="txt_ADDRESSFULL" LabelWidth="100" InputWidth="525"  ReadOnly="true"/>
                        <Its:newline runat="server" />
                        <Its:text runat="server" Label="전화번호" Field="TELNO" LabelWidth="100" InputWidth="150" Type="tel"/>
                        <Its:text runat="server" Label="팩스번호" Field="FAXNO" LabelWidth="100" InputWidth="150" Type="tel"/>
                        <Its:newline runat="server" />
                        <Its:text runat="server" Label="이메일" Field="EMAIL" LabelWidth="100" InputWidth="150"/>                        
                        <Its:newline runat="server" />
                        <Its:text runat="server" Label="담당자 성명" Field="PRSNNM" InputWidth="150" LabelWidth="100"/>                        
                        <Its:text runat="server" Label="담당 부서" Field="PRSNDEPT" LabelWidth="100" InputWidth="150"/>
                        <Its:newline runat="server" />
                        <Its:text runat="server" Label="담당자 전화번호" Field="PRSNTELNO" LabelWidth="100" InputWidth="150" Type="tel"/>
                        <Its:text runat="server" Label="담당자 휴대폰" Field="PRSNPHONE" LabelWidth="100" InputWidth="150" Type="tel"/>
                        <Its:text runat="server" Label="자사 코드" Field="COMPCD" ID="txt_COMPCD" Hidden="true" />
                        <Its:newline runat="server" />
                        <Its:text runat="server" Label="담당자 팩스번호" Field="PRSNFAXNO" LabelWidth="100" InputWidth="150" Type="tel"/>
                        <Its:text runat="server" Label="담당자 이메일" Field="PRSNEMAIL" LabelWidth="100" InputWidth="150"/>
                        <Its:newline runat="server" />
                        <Its:text runat="server" Label="대표자 영문 이름" Field="REPRENMENG" LabelWidth="100" InputWidth="150" />
                        <Its:text runat="server" Label="회사 영문 이름" Field="COMPNMENG" LabelWidth="100" InputWidth="150" />                               
                    </Its:div>
            </Its:div>
                
            </Its:div>
        </Its:div>
    <Its:split runat="server" Type="Horizon" />
   
</asp:Content>

