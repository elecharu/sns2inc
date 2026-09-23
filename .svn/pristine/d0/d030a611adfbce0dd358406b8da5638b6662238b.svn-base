<%--설비정보--%>

<%-- PAGE --%>
<%@ Page Title="" Language="C#" MasterPageFile="~/Common/Master/MasterBase.master" AutoEventWireup="true" CodeFile="MST0001_R04.aspx.cs" Inherits="MST0001_R04" %>

<%-- HEAD --%>
<asp:Content ContentPlaceHolderID="CPH_HEAD" runat="Server">
    <script type="text/javascript" src="MST0001_R04.js?ver=<%= BasePage.srcVersion %>"></script>
    <link rel="stylesheet" href="MST0001_R04.css" />                                                    <%-- 스타일시트 --%>
</asp:Content>

<%-- SEARCH PANEL --%>
<asp:Content ContentPlaceHolderID="CPH_SEARCH" runat="Server">
    <Its:div runat="server" Type="SearchPanel" ID="sdiv1">
        <Its:combo runat="server" Label="설비유형" ID="combo_EQMTP" Field="EQMTP" GPCD="*EQMTP" />
        <Its:combo runat="server" Label="사용공정" ID="combo_PRCCD" Field="PRCCD" GPCD="*PRCCD" />
        <Its:text runat="server" Label="키워드" ID="text_KEYWORD" />
    </Its:div>
</asp:Content>

<%-- BODY --%>
<asp:Content ContentPlaceHolderID="CPH_BODY" runat="Server">
    <Its:div runat="server" Type="BasicBlock" ID="div1">
        <Its:div runat="server" Type="BasicFloat">     <%-- 이미지 패널 --%>
            <Its:div runat="server" Type="BorderFloat" >
                <Its:div runat="server" Type="BorderBlock" >
                    <Its:img runat="server" ID="img_EQM" Height="82" Width="82" />
                </Its:div>
                <Its:newline runat="server" />
                <Its:fileManager runat="server" StyleType="simple" FileType="image" Field="IMGFILEKEY" ID="file_EQM" bindImageId="img_EQM" />
            </Its:div>
        </Its:div>
        <Its:div runat="server" Type="BasicFloat">
            <Its:div runat="server" Type="BorderFloat">
                <Its:text runat="server" Label="설비코드" Field="EQMCD" InputWidth="130" ReadOnly="true"/>
                <Its:combo runat="server" Label="사업장" Field="BDVCD" GPCD="BDVCD"/>
                <Its:newline runat="server" />
                <Its:text runat="server" Label="설비명" Field="EQMNM" InputWidth="130" />
                <Its:combo runat="server" Label="사용공정" Field="PRCCD" GPCD="PRCCD"/>
                <Its:newline runat="server" />
                <Its:text runat="server" Label="설비호기" Field="EQMNO" InputWidth="130"/>                
                <Its:combo runat="server" Label="담당부서" Field="DEPTP"  GPCD="DEPTP"/>
                <Its:newline runat="server" />
                <Its:combo runat="server" Label="설비유형" Field="EQMTP" GPCD="EQMTP" InputWidth="90"/>
                <Its:text runat="server" Label="담당사원" Field="EMPCD" />
                <Its:newline runat="server" />
                <Its:text runat="server" Label="설비규격" Field="EQMSPEC" InputWidth="130"/>
                <Its:text runat="server" Label="시리얼번호" Field="EQMSER" />
                <Its:newline runat="server" />
            </Its:div>
            <Its:div runat="server" Type="BorderFloat">
                <Its:num runat="server" Label="전력용량(KW)" Field="EPOWER" DecimalPoint="2" TriggerButton="false"  />
                <Its:num runat="server" Label="작동유량" Field="EQMOIL" DecimalPoint="2" TriggerButton="false" />
                <Its:check runat="server" Label="지시여부" Field="INSYN" MarginLeft="70" Hidden="true"/>
                <Its:newline runat="server" />
                <Its:num runat="server" Label="사용전류(V)" Field="EVOLT"  DecimalPoint="2" TriggerButton="false" />
                <Its:text runat="server" Label="제작업체" Field="MKCUST" />
                <Its:check runat="server" Label="가상설비여부" Field="VTLYN"  MarginLeft="70" Hidden="true"/>
                <Its:newline runat="server" />
                <Its:num runat="server" Label="너비" Field="SIZEWD" DecimalPoint="2" TriggerButton="false"  />
                <Its:date runat="server" Label="제작일자" Field="MKDATE" />
                <Its:num runat="server" Label="순번" Field="SORTNO" TriggerButton="false" />
                <Its:newline runat="server" />
                <Its:num runat="server" Label="높이" Field="SIZEHT"  DecimalPoint="2" TriggerButton="false" />
                <Its:text runat="server" Label="구매업체" Field="BUYCUST" />
                <Its:num runat="server" Label="구매금액" Field="BUYAMT" TriggerButton="false" />
                <Its:newline runat="server" />
                <Its:num runat="server" Label="깊이" Field="SIZEDT" DecimalPoint="2" TriggerButton="false"  />
                <Its:date runat="server" Label="구매일자" Field="BUYDATE" />
                <Its:text runat="server" Label="비고" Field="REMARK" />
                <Its:newline runat="server" />
            </Its:div>
        </Its:div>
    </Its:div>
    <Its:split runat="server" Type="Horizon" />
    <Its:div runat="server" Type="SplitDown">
        <Its:grid runat="server" ID="grid1" />
    </Its:div>
</asp:Content>

<%-- POP --%>
<asp:Content ContentPlaceHolderID="CPH_POP" runat="server">
    <Its:pop runat="server" ID="pop1" Type="add" Title="설비정보 추가" Width="683">
        <Its:div runat="server" Type="SplitSingle" ID="pdiv1">
            <Its:div runat="server" Type="BasicFloat">     <%-- 이미지 패널 --%>
                <Its:div runat="server" Type="BorderFloat" >
                    <Its:div runat="server" Type="BorderBlock" >
                        <Its:img runat="server" ID="pop_img_EQM" Height="82" Width="82" />
                    </Its:div>
                    <Its:newline runat="server" />
                    <Its:fileManager runat="server" StyleType="simple" FileType="image" Field="IMGFILEKEY" ID="pop_file_EQM" bindImageId="pop_img_EQM" />
                </Its:div>
                <Its:div runat="server" Type="BorderFloat">
                    <Its:text runat="server" Label="설비코드" Field="EQMCD" InputWidth="130"/>
                    <Its:combo runat="server" Label="사업장" Field="BDVCD" GPCD="BDVCD"/>
                    <Its:newline runat="server" />
                    <Its:text runat="server" Label="설비명" Field="EQMNM" InputWidth="130" />
                    <Its:combo runat="server" Label="사용공정" Field="PRCCD" GPCD="PRCCD"/>
                    <Its:newline runat="server" />
                    <Its:text runat="server" Label="설비호기" Field="EQMNO" InputWidth="130"/>
                    <Its:combo runat="server" Label="담당부서" Field="DEPTP"  GPCD="DEPTP"/>
                    <Its:newline runat="server" />
                    <Its:combo runat="server" Label="설비유형" Field="EQMTP" GPCD="EQMTP" InputWidth="90"/>
                    <Its:text runat="server" Label="담당사원" Field="EMPCD" />
                    <Its:newline runat="server" />
                    <Its:text runat="server" Label="설비규격" Field="EQMSPEC" InputWidth="130"/>
                    <Its:text runat="server" Label="시리얼번호" Field="EQMSER" />
                    <Its:newline runat="server" />
                </Its:div>
            </Its:div>
            <Its:newline runat="server" />
            <Its:div runat="server" Type="BasicFloat">
                <Its:div runat="server" Type="BorderFloat">
                    <Its:num runat="server" Label="전력용량(KW)" Field="EPOWER" DecimalPoint="2" TriggerButton="false"  />
                    <Its:num runat="server" Label="작동유량" Field="EQMOIL" DecimalPoint="2" TriggerButton="false" />
                    <Its:check runat="server" Label="지시여부" Field="INSYN" MarginLeft="70" Value="false" Hidden="true"/>
                    <Its:newline runat="server" />
                    <Its:num runat="server" Label="사용전류(V)" Field="EVOLT"  DecimalPoint="2" TriggerButton="false" />
                    <Its:text runat="server" Label="제작업체" Field="MKCUST" />
                    <Its:check runat="server" Label="가상설비여부" Field="VTLYN"  MarginLeft="70" Value="false" Hidden="true"/>
                    <Its:newline runat="server" />
                    <Its:num runat="server" Label="너비" Field="SIZEWD" DecimalPoint="2" TriggerButton="false"  />
                    <Its:date runat="server" Label="제작일자" Field="MKDATE" />
                    <Its:num runat="server" Label="순번" Field="SORTNO" TriggerButton="false" />
                    <Its:newline runat="server" />
                    <Its:num runat="server" Label="높이" Field="SIZEHT"  DecimalPoint="2" TriggerButton="false" />
                    <Its:text runat="server" Label="구매업체" Field="BUYCUST" />
                    <Its:num runat="server" Label="구매금액" Field="BUYAMT" TriggerButton="false" />
                    <Its:newline runat="server" />
                    <Its:num runat="server" Label="깊이" Field="SIZEDT" DecimalPoint="2" TriggerButton="false"  />
                    <Its:date runat="server" Label="구매일자" Field="MKDATE" />
                    <Its:text runat="server" Label="비고" Field="REMARK" />
                    <Its:newline runat="server" />
                </Its:div>
            </Its:div>
        </Its:div>
    </Its:pop>
    <Its:pop runat="server" ID="pop2" Title="이미지 확대 보기" Width="650">
        <Its:div runat="server" Type="BorderBlock" >
            <Its:img runat="server" ID="big_img_EQM" Height="600" Width="600" />
        </Its:div>
    </Its:pop>
</asp:Content>