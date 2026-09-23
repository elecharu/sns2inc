<%--거래처정보--%>
<%-- 'CodeFile', 'Inherits' --%>
<%@ Page Title="" Language="C#" MasterPageFile="~/Common/Master/MasterBase.master" AutoEventWireup="true" 
    CodeFile="MST0001_R08.aspx.cs" Inherits="MST0001_R08" %>

<%-- HEAD --%>
<asp:Content ContentPlaceHolderID="CPH_HEAD" Runat="Server">
    <style>
        .BorderFloat {
            float:inherit !important;
        }
        #ddiv1 {
            overflow: auto;
            width:100%;
        }
    </style>
    <script type="text/javascript" src="MST0001_R08.js?ver=<%= BasePage.srcVersion %>"></script>
    <script src="https://t1.kakaocdn.net/mapjsapi/bundle/postcode/prod/postcode.v2.js"></script>    <%-- kakao 우편번호 API --%>
</asp:Content>

<%-- SEARCH --%>
<asp:Content ContentPlaceHolderID="CPH_SEARCH" Runat="Server">
    <Its:div runat="server" Type="SearchPanel" ID="sdiv1">
        <Its:check runat="server" Label="구매처" Field="PURYN" Value="false"/>
        <Its:check runat="server" Label="판매처" Field="SALEYN" Value="false"/>
        <Its:check runat="server" Label="외주처" Field="OSCYN" Value="false"/>
        <Its:find runat="server" Label="거래처" Field="CUSTCD" GPCD="CUSTCD"/>      
        <Its:text runat="server" Label="사업자번호" Field="REGBUSSNUM" GPCD="REGBUSSNUM" />
        <%--<Its:find runat="server" Label="영업 지역" Field="SALEAREA" GPCD="AREACD" />--%>
    </Its:div>
</asp:Content>

<%-- BODY --%>
<asp:Content ContentPlaceHolderID="CPH_BODY" Runat="Server">
    <Its:div runat="server" Type="BasicBlock" ID="ddiv1">
        <Its:div runat="server" Type="BorderFloat" ID="ddiv1_1">
            <Its:text runat="server" Label="거래처 코드" Field="CUSTCD" ReadOnly="true" />
            <Its:newline runat="server" />
            <Its:text runat="server" Label="사업자 번호" Field="REGBUSSNUM" Type="regno" />
            <Its:text runat="server" Label="종사업자번호" Field="PLACENO" />
            <Its:newline runat="server" />
            <%--<Its:find runat="server" Label="거래처유형" Field="CUSTTP" GPCD="CUSTTP" NameWidth="148"/>--%>
            <Its:newline runat="server" />
            <Its:text runat="server" Label="상호(정식명칭)" Field="CUSTNM" InputWidth="312" />
            <Its:newline runat="server" />
            <Its:text runat="server" Label="대표자성명" Field="PRESIDENT" />
            <Its:text runat="server" Label="대표자전화" Field="REPRETEL" />
            <Its:newline runat="server" />
            <Its:text runat="server" Label="업태" Field="REGBUSSTP" />
            <Its:text runat="server" Label="종목" Field="REGBUSSITEM" />
            <Its:newline runat="server" />
        </Its:div>

        <Its:div runat="server" Type="BorderFloat" ID="ddiv1_2">
            <Its:text runat="server" Label="우편번호" Field="CUSTZIP" ID="txt_CUSTZIP" InputWidth="70" ReadOnly="true"/>
            <Its:button runat="server" Label="검색" ID="SEARCH_ZIP" />
            <Its:text runat="server" Label="도로명 주소" Field="CUSTADDR" ID="txt_CUSTADDR"  InputWidth="230" LabelWidth="104" ReadOnly="true" />
            <Its:newline runat="server" />
            <Its:text runat="server" Label="건물명" Field="CUSTADDRDETAIL" ID="txt_CUSTADDRDETAIL" InputWidth="130" ReadOnly="true"/>
            <Its:text runat="server" Label="상세 주소" Field="CUSTADDRFILL"  ID="txt_CUSTADDRFILL" InputWidth="230" />
            <Its:newline runat="server" />
            <Its:text runat="server" Label="전체 주소" Field="CUSTADDRFULL" ID="txt_ADDRESSFULL" InputWidth="475" ReadOnly="true" />
            <Its:newline runat="server" />
            <Its:text runat="server" Label="영문 주소" Field="CUSTADDRENG" InputWidth="130" />
            <Its:text runat="server" Label="영문 상호명" Field="CUSTNMENG" InputWidth="130" /> 
            <Its:newline runat="server" />
            <Its:text runat="server" Label="전화번호" Field="CUSTTEL" InputWidth="130" Type="tel"/>
            <Its:text runat="server" Label="E-MAIL" Field="EMAIL" InputWidth="230"/>
            <Its:newline runat="server" />
            <Its:text runat="server" Label="팩스번호" Field="CUSTFAX" InputWidth="130" Type="tel"/>
            <Its:text runat="server" Label="홈페이지 URL" Field="HOMEURL" ID="txt_HOMEURL"  InputWidth="175" />
            <Its:button runat="server" Label="이동" ID="MOVE_HOMEPAGE" />
            <Its:newline runat="server" />
            <Its:combo runat="server" Label="은행" Field="BANKCD" GPCD="BANKCD" InputWidth="90"/>
            <Its:text runat="server" Label="계좌번호" Field="BANKACCTNO" InputWidth="230"/>
            <Its:newline runat="server" />
            <Its:text runat="server" Label="계산서 휴대폰" Field="TAXPHONE" InputWidth="130"  Type="tel"/>
            <Its:text runat="server" Label="계산서 E-MAIL" Field="TAXEMAIL" InputWidth="230"/>
            <Its:newline runat="server" />
            <Its:text runat="server" Label="결제구분" Field="PAYTYPE" InputWidth="452"/>
            <Its:display runat="server" Label=""/>
            <Its:newline runat="server" />
        </Its:div>
        <Its:div runat="server" Type="BorderFloat" ID="ddiv1_3">
            <Its:date runat="server" Label="거래 시작일" Field="TRADESDT" LabelWidth="100"  />
            <Its:date runat="server" Label="거래 종료일" Field="TRADEEDT" LabelWidth="100"  />
            <Its:newline runat="server" />
            <Its:text runat="server" Label="담당자" Field="CHARGENM" LabelWidth="100" />
            <Its:text runat="server" Label="담당 부서" Field="CHARGEDEPT" LabelWidth="100" />
            <Its:newline runat="server" />
            <Its:text runat="server" Label="담당자 전화" Field="CHARGETEL" LabelWidth="100"  Type="tel"/>
            <Its:text runat="server" Label="담당자 팩스" Field="PRSNFAXNO" LabelWidth="100"  Type="tel"/>
            <Its:newline runat="server" />
            <Its:text runat="server" Label="담당자 휴대폰" Field="PRSNPHONE" LabelWidth="100"  Type="tel"/>
            <Its:text runat="server" Label="담당자 E-MAIL" Field="CHARGEMAIL" LabelWidth="100"  />
            <Its:newline runat="server" />
            <Its:text runat="server" Label="비고" Field="REMARK" LabelWidth="100"  InputWidth="329" />
            <Its:newline runat="server" />
            <Its:display runat="server" Label="등록" Field="REGISTER" LabelWidth="100" InputWidth="300" />
            <Its:newline runat="server" />
            <Its:display runat="server" Label="수정" Field="MODIFY" LabelWidth="100" InputWidth="300" />
            
        </Its:div>
    </Its:div>
    <Its:split runat="server" Type="Horizon" />
    <Its:div runat="server" Type="SplitDown">
       <Its:grid runat="server" ID="grid1" />
    </Its:div>
</asp:Content>

<asp:Content ContentPlaceHolderID="CPH_POP" runat="server">
    <Its:pop runat="server" ID="pop1" Type="add" Title="거래처추가" Width="715">
        <Its:div runat="server" Type="BasicBlock" ID="pdiv1">
            <Its:div runat="server" Type="BorderFloat" ID="pdiv1_1">
                <Its:text runat="server" Label="거래처 코드" Field="CUSTCD" ID="txt_CUSTCD" ReadOnly="true" Required="true"/>
                <Its:onoff runat="server" Label="자동 채번" Field="GETCDYN" ID="onoff_GETCDYN" OnText="Y" OffText="N" />
                <Its:newline runat="server" />
                <Its:text runat="server" Label="사업자 번호" Field="REGBUSSNUM" ID="txt_REGBUSSNUM" Mask="000-00-00000" />
                <Its:text runat="server" Label="종사업장번호" Field="PLACENO" ID="txt_PLACENO" />
                <Its:newline runat="server" />
                <Its:text runat="server" Label="상호(정식명칭)" Field="CUSTNM" InputWidth="315"  Required="true"/>
                <Its:newline runat="server" />
                <Its:text runat="server" Label="대표자성명" Field="PRESIDENT" />
                <Its:text runat="server" Label="대표자전화" Field="REPRETEL" />
                <Its:newline runat="server" />
                <Its:text runat="server" Label="업태" Field="REGBUSSTP" />
                <Its:text runat="server" Label="종목" Field="REGBUSSITEM" />
                <Its:newline runat="server" />
                <%--<Its:find runat="server" Label="거래처유형" Field="CUSTTP" GPCD="CUSTTP" NameWidth="148" />--%>
                <Its:newline runat="server" />
                <Its:date runat="server" Label="거래 시작일" Field="TRADESDT" ID="date_TRADESDT"/>
                <Its:date runat="server" Label="거래 종료일" Field="TRADEEDT" ID="date_TRADEEDT" />
            </Its:div>
            <Its:div runat="server" Type="BorderFloat" ID="pdiv1_3">
                <Its:text runat="server" Label="담당자" Field="CHARGENM" LabelWidth="100" />
                <Its:newline runat="server" />
                <Its:text runat="server" Label="담당 부서" Field="CHARGEDEPT" LabelWidth="100" />
                <Its:newline runat="server" />
                <Its:text runat="server" Label="담당자 전화" Field="CHARGETEL" LabelWidth="100"  Type="tel"/>
                <Its:newline runat="server" />
                <Its:text runat="server" Label="담당자 팩스" Field="PRSNFAXNO" LabelWidth="100"  Type="tel"/>
                <Its:newline runat="server" />
                <Its:text runat="server" Label="담당자 휴대폰" Field="PRSNPHONE" LabelWidth="100"  Type="tel"/>
                <Its:newline runat="server" />
                <Its:text runat="server" Label="담당자 E-MAIL" Field="CHARGEMAIL" LabelWidth="100"  />
                <Its:newline runat="server" />
                <Its:check runat="server" Label="구매처여부" Field="PURYN" MarginLeft="34" Value="false"/>
                <Its:newline runat="server" />
                <Its:check runat="server" Label="판매처여부" Field="SALEYN" MarginLeft="34" Value="false"/>
                <Its:newline runat="server" />
                <Its:check runat="server" Label="외주처여부" Field="OSCYN" MarginLeft="34" Value="false"/>
            </Its:div>
            <Its:newline runat="server" />
            <Its:div runat="server" Type="BorderFloat" ID="pdiv1_2">
                <Its:text runat="server" Label="우편번호" Field="CUSTZIP" ID="pop_txt_CUSTZIP" InputWidth="70" ReadOnly="true"/>
                <Its:button runat="server" Label="검색" ID="pop_SEARCH_ZIP" />
                <Its:text runat="server" Label="도로명 주소" Field="CUSTADDR" ID="pop_txt_CUSTADDR"  InputWidth="230" LabelWidth="104" ReadOnly="true" />
                <Its:newline runat="server" />
                <Its:text runat="server" Label="건물명" Field="CUSTADDRDETAIL" ID="pop_txt_CUSTADDRDETAIL" InputWidth="130" ReadOnly="true"/>
                <Its:text runat="server" Label="상세 주소" Field="CUSTADDRFILL"  ID="pop_txt_CUSTADDRFILL" InputWidth="230" />
                <Its:newline runat="server" />
                <Its:text runat="server" Label="전체 주소" Field="CUSTADDRFULL" ID="pop_txt_CUSTADDRFULL" InputWidth="475" ReadOnly="true" />
                <Its:newline runat="server" />
                <Its:text runat="server" Label="전화번호" Field="CUSTTEL" InputWidth="130" Type="tel"/>
                <Its:text runat="server" Label="E-MAIL" Field="EMAIL" InputWidth="230"/>
                <Its:newline runat="server" />
                <Its:text runat="server" Label="팩스번호" Field="CUSTFAX" InputWidth="130" Type="tel"/>
                <Its:text runat="server" Label="홈페이지 URL" Field="HOMEURL" ID="pop_txt_HOMEURL"  InputWidth="175" />
                <Its:button runat="server" Label="이동" ID="pop_MOVE_HOMEPAGE" />
                <Its:newline runat="server" />
                <Its:text runat="server" Label="계산서 휴대폰" Field="TAXPHONE" InputWidth="130"  Type="tel"/>
                <Its:text runat="server" Label="계산서 E-MAIL" Field="TAXEMAIL" InputWidth="230"/>
                <Its:newline runat="server" />
                <Its:text runat="server" Label="비고" Field="REMARK"  InputWidth="475" />
            </Its:div>

        </Its:div>
    </Its:pop>
</asp:Content>
