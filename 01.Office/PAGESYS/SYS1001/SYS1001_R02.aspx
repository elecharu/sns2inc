<%-- 'CodeFile', 'Inherits' --%>
<%@ Page Title="" Language="C#" MasterPageFile="~/Common/Master/MasterBase.master" AutoEventWireup="true" 
    CodeFile="SYS1001_R02.aspx.cs" Inherits="SYS1001_R02" %>

<%-- HEAD 'src' --%>
<asp:Content ContentPlaceHolderID="CPH_HEAD" Runat="Server">
    <script type="text/javascript" src="SYS1001_R02.js?ver=<%= BasePage.srcVersion %>"></script>
    <script src="http://dmaps.daum.net/map_js_init/postcode.v2.js"></script>    <%-- DAUM 우편번호 API --%>
</asp:Content>

<%-- SEARCH --%>
<asp:Content ContentPlaceHolderID="CPH_SEARCH" Runat="Server">

</asp:Content>

<%-- BODY --%>
<asp:Content ContentPlaceHolderID="CPH_BODY" Runat="Server">
    <Its:div runat="server" Type="SplitTop" ID="ddiv1">
        <Its:div runat="server" Type="BasicFloat">    
            <Its:div runat="server" Type="BorderFloat" >
                <div><b>도장 이미지</b></div>
                <Its:newline runat="server" />
                <Its:div runat="server" Type="BorderBlock" >
                    <Its:img runat="server" ID="img_MARK" Height="125" Width="125" />
                </Its:div>
                <Its:newline runat="server" />
                <Its:fileManager runat="server" StyleType="simple" FileType="image" Field="MARKIMAGE" ID="file_MARKIMAGE" bindImageId="img_MARK" />
            </Its:div>
        </Its:div>
        <Its:div runat="server" Type="BasicFloat" ID="ddiv1_1">
            <Its:text runat="server" Label="사업장 코드" Field="BDVCD" ID="txt_BDVCD" Required="true" ReadOnly="true" InputWidth="190" />
            <Its:newline runat="server" />
            <Its:text runat="server" Label="사업자등록번호" Field="BDVREGNO" ID="txt_BDVREGNO" InputWidth="190"/>
            <Its:newline runat="server" />
            <Its:text runat="server" Label="사업장명" Field="BDVNM" InputWidth="190"/>
            <Its:newline runat="server" />
            <Its:text runat="server" Label="사업장 정식명" Field="BDVNMFULL" InputWidth="190" ID="txt_COMPNMFULL"/>
            <Its:newline runat="server" />
            <Its:text runat="server" Label="전화번호" Field="TELNO" InputWidth="190" ID="txt_TELNO" />
            <Its:newline runat="server" />
            <Its:text runat="server" Label="팩스번호" Field="FAXNO" InputWidth="190" />
            <Its:newline runat="server" />
            <Its:text runat="server" Label="대표자" Field="PRESIDENT" InputWidth="190" ID="txt_REPRENM" />
            <Its:newline runat="server" />
            <Its:text runat="server" Label="대표자 영문명" Field="PRESIDENTENG" InputWidth="190" ID="txt_PEPRENMENG" />            
        </Its:div>
        <Its:div runat="server" Type="BasicFloat" ID="ddiv1_2">
            <Its:text runat="server" Label="우편번호" Field="ZIPCD" ID="txt_ZIPCD" InputWidth="80" ReadOnly="true" />
            <Its:button runat="server" Label="검색" ID="SEARCH_ZIP" />
            <Its:text runat="server" Label="도로명 주소" Field="ADDRESS" ID="txt_ADDRESS" InputWidth="200" LabelWidth="115" ReadOnly="true" />            
            <Its:newline runat="server" />
            <Its:text runat="server" Label="건물명" Field="ADDRESSDETAIL" ID="txt_ADDRESSDETAIL" InputWidth="150" ReadOnly="true" />
            <Its:text runat="server" Label="상세 주소" Field="ADDRESSOTHER" ID="txt_ADDRESSOTHER"  InputWidth="200" />
            <Its:newline runat="server" />
            <Its:text runat="server" Label="전체 주소" Field="ADDRESSFULL" InputWidth="465" ID="txt_ADDRESSFULL" ReadOnly="true" />
            <Its:newline runat="server" />
            <Its:label runat="server" Text="인증서 등록" Margin="0px 0px 0px 28px"/>
            <Its:div runat="server" Type="BorderFloat" >
                <Its:newline runat="server" />
                <Its:display runat="server" Label="signPri.key 파일" LabelWidth="130" InputWidth="0" />
                <Its:TaxfileManager runat="server" ID="keyTaxFile" Type="Key" />
                <Its:display runat="server" Label="signCert.der 파일" LabelWidth="130" InputWidth="0" />
                <Its:TaxfileManager runat="server" ID="derTaxFile" Type="Der" />
                <Its:text runat="server" Label="인증서 비밀번호" Field="CERTPASSWORD" LabelWidth="130" ID="txt_PASSWORD" InputWidth="110" Type="password"/>
                <Its:button runat="server" Label="전송" ID="btn_PASSWORD" Width="60" />
            </Its:div>
        </Its:div>
        <Its:div runat="server" Type="BasicFloat" ID="ddiv1_3">
            <Its:text runat="server" Label="사업장 영문명" Field="BDVNMENG" InputWidth="190" ID="txt_BDVNMENG" />
            <Its:newline runat="server" />
            <Its:text runat="server" Label="업태" Field="INDTYPE" ID="txt_INDTYPE" />
            <Its:display runat="server" Label="등록" Field="REGISTER" InputWidth="300" />
            <Its:newline runat="server" />
            <Its:text runat="server" Label="종목" Field="INDCLASS" ID="txt_INDCLASS" />
            <Its:display runat="server" Label="수정" Field="MODIFY" InputWidth="300" />
            <Its:newline runat="server" />
            <Its:text runat="server" Label="계산서휴대폰" Field="PRSNPHONE" ID="txt_TAXPHONE" />
            <Its:newline runat="server" />
            <Its:text runat="server" Label="계산서이메일" Field="PRSNEMAIL" ID="txt_TAXEMAIL" />
            <Its:newline runat="server" />
            <Its:find runat="server" Label="관리자부서" Field="PRSNDEPT" GPCD="DEPTP"/>
            <Its:newline runat="server" />
            <Its:text runat="server" Label="관리자명" Field="PRSNNM" ID="txt_PRSNNM" />
            <Its:newline runat="server" />
            <Its:text runat="server" Label="관리자전화" Field="PRSNTELNO" />
            <Its:text runat="server" Label="LGTAXID" Field="LGTAXID" ID="txt_LGTAXID" Hidden="true" />
            <Its:text runat="server" Label="LGTAXPW" Field="LGTAXPW" ID="txt_LGTAXPW" Hidden="true" />
        </Its:div>
    </Its:div>
    <Its:split runat="server" Type="Horizon" />
    <Its:div runat="server" Type="SplitDown">
       <Its:grid runat="server" ID="grid1" />
    </Its:div>
</asp:Content>

<%-- POP --%>
<asp:Content ContentPlaceHolderID="CPH_POP" Runat="Server">
    <Its:pop runat="server" ID="pop1" Type="add" Title="사업장 등록" Width="820">
        <Its:div runat="server" Type="BasicBlock" ID="pdiv1">
            <Its:div runat="server" Type="BasicFloat">    
                <Its:div runat="server" Type="BorderFloat" >
                    <div><b>도장 이미지</b></div>
                    <Its:newline runat="server" />
                    <Its:div runat="server" Type="BorderBlock" >
                        <Its:img runat="server" ID="pop_img_MARK" Height="125" Width="125" />
                    </Its:div>
                    <Its:newline runat="server" />
                    <Its:fileManager runat="server" StyleType="simple" FileType="image" Field="MARKIMAGE" ID="pop_file_MARKIMAGE" bindImageId="pop_img_MARK" />
                </Its:div>
            </Its:div>
            <Its:div runat="server" Type="BasicFloat">    
                <Its:div runat="server" Type="BasicFloat" >
                    <Its:text runat="server" Label="사업장 코드" Field="BDVCD" Required="true" ID="pop_txt_BDVCD" />
                    <Its:text runat="server" Label="사업자등록번호" Field="BDVREGNO" ID="pop_txt_BDVREGNO"/>
                    <Its:text runat="server" Label="사업장명" Field="BDVNM"/>
                    <Its:newline runat="server" />
                    <Its:text runat="server" Label="사업장 정식명" Field="BDVNMFULL" ID="pop_txt_COMPNMFULL"/>
                    <Its:text runat="server" Label="업태" Field="INDTYPE" ID="pop_txt_INDTYPE" />
                    <Its:text runat="server" Label="종목" Field="INDCLASS" ID="pop_txt_INDCLASS" />
                    <Its:newline runat="server" />
                    <Its:text runat="server" Label="전화번호" Field="TELNO" ID="pop_txt_TELNO" />
                    <Its:text runat="server" Label="팩스번호" Field="FAXNO" />
                    <Its:text runat="server" Label="대표자" Field="PRESIDENT" ID="pop_txt_REPRENM" />
                    <Its:newline runat="server" />
                    <Its:text runat="server" Label="관리자" Field="PRSNNM" ID="pop_txt_PRSNNM"/>
                    <Its:find runat="server" Label="관리자부서" Field="PRSNDEPT" GPCD="DEPTP"/>
                    <Its:newline runat="server" />
                    <Its:text runat="server" Label="관리자전화" Field="PRSNTELNO"/>
                    <Its:text runat="server" Label="계산서휴대폰" Field="PRSNPHONE" ID="pop_txt_TAXPHONE" />
                    <Its:text runat="server" Label="계산서이메일" Field="PRSNEMAIL" ID="pop_txt_TAXEMAIL" />
                </Its:div>
                <Its:newline runat="server" />
                <Its:div runat="server" Type="BasicFloat">
                    <Its:text runat="server" Label="우편번호" Field="ZIPCD" ID="pop_txt_ZIPCD" ReadOnly="true" />
                    <Its:button runat="server" Label="검색" ID="pop_SEARCH_ZIP" />
                    <Its:text runat="server" Label="도로명 주소" Field="ADDRESS" ID="pop_txt_ADDRESS" InputWidth="270" LabelWidth="92" ReadOnly="true" />            
                    <Its:newline runat="server" />
                    <Its:text runat="server" Label="건물명" Field="ADDRESSDETAIL" ID="pop_txt_ADDRESSDETAIL" InputWidth="150" ReadOnly="true" />
                    <Its:text runat="server" Label="상세 주소" Field="ADDRESSOTHER" ID="pop_txt_ADDRESSOTHER"  InputWidth="270" />
                    <Its:newline runat="server" />
                    <Its:text runat="server" Label="전체 주소" Field="ADDRESSFULL" InputWidth="534" ID="pop_txt_ADDRESSFULL" ReadOnly="true" />
                    <Its:newline runat="server" />
                    <Its:label runat="server" Text="인증서 등록" Width="90" Align="right" Margin="0px" />
                    <Its:div runat="server" Type="BorderFloat" >
                        <Its:newline runat="server" />
                        <Its:display runat="server" Label="signPri.key 파일" LabelWidth="130" InputWidth="0" />
                        <Its:TaxfileManager runat="server" ID="pop_keyTaxFile" Type="Key" />
                        <Its:display runat="server" Label="signCert.der 파일" LabelWidth="130" InputWidth="0" />
                        <Its:TaxfileManager runat="server" ID="pop_derTaxFile" Type="Der" />
                        <Its:text runat="server" Label="인증서 비밀번호" Field="CERTPASSWORD" LabelWidth="130" ID="pop_txt_PASSWORD" InputWidth="110" Type="password"/>
                        <Its:button runat="server" Label="전송" ID="pop_btn_PASSWORD" Width="60" />
                    </Its:div>
                </Its:div>
            </Its:div>
            
        </Its:div>
    </Its:pop>
</asp:Content>