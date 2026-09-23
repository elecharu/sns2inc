<%-- PAGE --%>
<%@ Page Title="" Language="C#" MasterPageFile="~/Common/Master/MasterBase.master" AutoEventWireup="true" CodeFile="SAL3002_R01.aspx.cs" Inherits="SAL3002_R01" %>

<%-- HEAD --%>
<asp:Content ContentPlaceHolderID="CPH_HEAD" runat="Server">
    <script type="text/javascript" src="SAL3002_R01.js?ver=<%= BasePage.srcVersion %>"></script>
    <script src="https://unpkg.com/xlsx@0.11.18/dist/xlsx.full.min.js"></script>    <%-- XLSX, XLS 엑셀 파일 읽기 --%>
</asp:Content>

<%-- SEARCH --%>
<asp:Content ContentPlaceHolderID="CPH_SEARCH" Runat="Server">
    <Its:div runat="server" Type="SearchPanel" ID="sdiv1">
        <Its:dateRange runat="server" Label="수주일자" FieldFrom="SDATE" FieldTo="EDATE" ID="DateRange1" />
        <Its:find runat="server" Label="거래처" Field="CUSTCD" GPCD="CUSTCD" />
        <Its:combo runat="server" Label="수주상태" Field="SALODRSTT" GPCD="*SALODRSTT" />
    </Its:div>
</asp:Content>

<asp:Content ContentPlaceHolderID="CPH_CUSTOM_BUTTON" runat="server">

</asp:Content>

<asp:Content ContentPlaceHolderID="CPH_BODY" Runat="Server">
    <Its:div runat="server" Type="SplitTop">
        <Its:div runat="server"  Type="SplitLeft"  ID="div1" LeftWidthPc="27">
            <Its:newline runat="server" Height="20" />
            <Its:text runat="server" Label="SALODRKEY" Field="SALODRKEY" ID="hid_SALODRKEY" Hidden="true" />
            <Its:date runat="server" Label="수주일자" Field="ODRDATE" ID="date_ODRDATE" ReadOnly="true" />            
            <Its:find runat="server" Label="담당자" Field="EMPCD" ID="find_EMPCD" GPCD="EMPCD" FindType="mini" />
            <Its:newline runat="server" />
            <Its:find runat="server" Label="거래처" Field="CUSTCD" ID="find_CUSTCD" GPCD="CUSTCD" InputWidth="114" NameWidth="182" Required="true" ReadOnly="true" />
            <Its:newline runat="server" />
            <Its:text runat="server" Label="수주명" Field="SALODRNM" InputWidth="313" />
            <Its:newline runat="server" />
            <Its:text runat="server" Label="비고" Field="REMARK" InputWidth="313"/>
            <Its:newline runat="server" />
            <Its:combo runat="server" Label="수주상태" Field="SALODRSTT" GPCD ="SALODRSTT" ReadOnly="true" />
            <Its:newline runat="server" Height="20" />
        </Its:div>
        <Its:split runat="server" Type="Vertical" Resizeable="false" />
        <Its:div runat="server" Type="SplitRight">
            <Its:grid runat="server" ID="grid_header" />
        </Its:div>
    </Its:div>

    <Its:split runat="server" Type="Horizon" Resizeable="false"/>

    <Its:div runat="server" Type="SplitDown">
        <Its:div runat="server" Type="SplitTop" TopHeightPc="50">
            <Its:div runat="server" Type="SplitTop" TopHeightPc="12" >
                <Its:label runat="server" Text="■ 수주품목" Bold="true" Margin="2px 0px 0px 10px"/> 
                <Its:button runat="server" Label="행 추가" ID="ADD_ROW" MarginTop="5" MarginLeft="50" />
                <Its:button runat="server" Label="행 삭제" ID="DEL_ORDERD" MarginTop="5" />
                <Its:button runat="server" Label="신규제품 생성" ID="btn_POP_NEWITEM" BackColor="CustomButton2" MarginTop="5" MarginLeft="50"/>
                <Its:button runat="server" Label="제품버전 갱신" ID="btn_POP_RENEW_ITEM" BackColor="CustomButton2" MarginTop="5" MarginLeft="10"/>
                
                <Its:label runat="server" Text="파일등록" Bold="true" MarginLeft="100" MarginTop="5" MarginRight="10"/>
                <Its:fileManager runat="server" ID="fm" FileType="basic" MarginTop="3"/>                  
            </Its:div>

            <Its:split runat="server" Type="Horizon" Resizeable="false" />

            <Its:div runat="server" Type="SplitDown" >
                <Its:div runat="server" Type="SplitLeft" LeftWidthPc="65">
                    <Its:grid runat="server" ID="grid_detail"/>
                </Its:div>
                <Its:split runat="server" Type="Vertical" Resizeable="false" />
                <Its:div runat="server" Type="SplitRight">
                    <Its:grid runat="server" ID="grid_SALODRD_FILES"/>
                </Its:div>                
            </Its:div>            
        </Its:div>

        <Its:split runat="server" Type="Horizon" />

        <Its:div runat="server" Type="SplitDown">
            <Its:div runat="server" Type="SplitTop" >
                <Its:label runat="server" Text="■ 생산 BOM, 라우팅" Bold="true" Margin="0px 0px 0px 10px"/>            

                <Its:button runat="server" Label="제품 추가" ID="btn_POP_ADD_PRODUCT" BackColor="CustomButton2" MarginLeft="50"/>
                <Its:button runat="server" Label="부품도 추가" ID="btn_POP_ADD_SUBITEM" BackColor="CustomButton2" MarginLeft="10"/>
                <Its:button runat="server" Label="조립공정 추가" ID="btn_ADD_ASY" BackColor="CustomButton2" MarginLeft="50"/>
                <Its:button runat="server" Label="조립공정 삭제" ID="btn_DEL_ASY" BackColor="CustomButton2" MarginLeft="10"/>
            </Its:div>

            <Its:split runat="server" Type="Horizon" Resizeable="false" />

            <Its:div runat="server" Type="SplitDown" >
                <Its:grid runat="server" ID="grid_BOM_ROUT"/>
            </Its:div>                     
        </Its:div>
        
    </Its:div>
</asp:Content>


<%-- POP --%>
<asp:Content ContentPlaceHolderID="CPH_POP" Runat="Server">
    <Its:pop runat="server" ID="POP_NEWITEM" Type="common" Title="신규제품 생성" Width="330" Height="220"  >
        <Its:div runat="server" Type="SplitSingle" ID="pdiv_NEWITEM">
            <Its:text runat="server" Label= "품목코드" ID="txt_ITEMCD_NEW" Field="ITEMCD_NEW" InputWidth="190" MarginTop="15"/>
            <Its:text runat="server" Label= "품명" ID="txt_ITEMNM_NEW"  Field="ITEMNM_NEW" InputWidth="190"/>
            <Its:combo runat="server" Label="품목유형" ID="cmb_ITEMTP_NEW" GPCD="ITEMTP" Field="ITEMTP_NEW" />
            <Its:combo runat="server" Label="단위" ID="cmb_ITEMUNIT_NEW" GPCD="ITEMUNIT" Field="ITEMUNIT_NEW" />
            <Its:find runat="server" Label="거래처" ID="find_CUSTCD_NEW" GPCD="CUSTCD" REF03="Y" Field="CUSTCD_NEW" ReadOnly="true"/>
            <Its:button runat="server" Label="저장" ID="btn_INSERT_NEWITEM" Width="100" BackColor="CustomButton2" MarginLeft="115" MarginTop="10"/>
        </Its:div>   
    </Its:pop>

    <Its:pop runat="server" ID="POP_ADD_SUBITEM" Type="common" Title="품목 추가" Width="900" Height="530"  >
        <Its:div runat="server" Type="SplitTop" ID="pdiv_1_ADD_SUBITEM" TopHeightPc="35">
            <Its:text runat="server" Label= "품목코드" ID="txt_ITEMCD_SUB" Field="ITEMCD_SUB" InputWidth="177" MarginTop="15" ReadOnly="true"/>
            <Its:num runat="server" Label="순번" ID="num_SORTNO" Field="SORTNO" Hidden="true"/>
            <Its:button runat="server" Label="지난이력 불러오기" ID="btn_POP_RECORD_SUBITEM" BackColor="CustomButton2" MarginLeft="10" MarginTop="15"/>
            <Its:num runat="server" Label="단품수량" ID="num_CUSAGE" Field="CUSAGE" LabelWidth="80" MarginTop="15" MinValue="0"/>
            <Its:button runat="server" Label="단품수량 수정" ID="btn_UPDATE_CUSAGE" BackColor="CustomButton2" MarginLeft="10" MarginTop="15"/>
            <Its:button runat="server" Label="비고 저장" ID="btn_UPDATE_REMARK_ROUT" BackColor="CustomButton2" MarginLeft="10" MarginTop="15"/>
            <Its:newline runat="server" />
            <Its:text runat="server" Label= "품명" ID="txt_ITEMNM_SUB" Field="ITEMNM_SUB" InputWidth="300" MarginTop="15" ReadOnly="true"/>
            <Its:newline runat="server" />

            <%--공정버튼 리스트--%>
            <Its:div runat="server" Type="BasicFloat" ID="Div5_ButtonList">

            </Its:div>
        </Its:div>   

        <Its:split runat="server" Type="Horizon" Resizeable="false"/>

        <Its:div runat="server" Type="SplitDown">
            <Its:grid runat="server" ID="grid_ADD_SUBITEM"/>
        </Its:div>
    </Its:pop>

    <%--조립이외 공정용--%>
    <Its:pop runat="server" ID="POP_ADD_MTRITEM" Type="common" Title="자재, 부자재 추가" Width="750" Height="400"  >
        <Its:div runat="server" Type="SplitTop" ID="pdiv_1_ADD_MTRITEM" TopHeightPc="25">
            <Its:text runat="server" Label= "반제품목코드" ID="txt_ITEMCD_SUB_2" Field="ITEMCD_SUB" InputWidth="190" MarginTop="15" ReadOnly="true"/>            
            <Its:text runat="server" Label= "공정" ID="txt_PRCNM" Field="PRCNM" InputWidth="190" MarginTop="15" ReadOnly="true"/>
            <Its:newline runat="server" />
            <Its:find runat="server" Label="자재품목코드" ID="find_MTRITEM" GPCD="ITEMCDMTR" Field="MTRITEM" InputWidth="80" NameWidth="93"  MarginTop="15" />
            <Its:num runat="server" Label="소요수량" ID="num_MTR_CUSAGE" Field="CUSAGE" InputWidth="190" MarginTop="15" MinValue="0"/>
            <Its:button runat="server" Label="자재 추가" ID="btn_ADD_MTRITEM" BackColor="CustomButton2" MarginLeft="10" MarginTop="15"/>
        </Its:div>   

        <Its:split runat="server" Type="Horizon" Resizeable="false"/>

        <Its:div runat="server" Type="SplitDown">
            <Its:grid runat="server" ID="grid_ADD_MTRITEM"/>
        </Its:div>
    </Its:pop>

    <%--조립공정용--%>
    <Its:pop runat="server" ID="POP_ADD_MTRITEM_ASY" Type="common" Title="자재, 부자재 추가" Width="750" Height="400"  >
        <Its:div runat="server" Type="SplitTop" ID="pdiv_1_ADD_MTRITEM_ASY" TopHeightPc="25">
            <Its:text runat="server" Label= "제품목코드" ID="txt_SALITEM" Field="ITEMCD" InputWidth="190" MarginTop="15" ReadOnly="true"/>            
            <Its:text runat="server" Label= "공정" ID="txt_PRCNM_ASY" Field="PRCNM" InputWidth="190" MarginTop="15" ReadOnly="true"/>
            <Its:newline runat="server" />
            <Its:find runat="server" Label="자재품목코드" ID="find_MTRITEM_ASY" GPCD="ITEMCDMTR" Field="MTRITEM" InputWidth="80" NameWidth="93"  MarginTop="15" />
            <Its:num runat="server" Label="소요수량" ID="num_MTR_CUSAGE_ASY" Field="CUSAGE" InputWidth="190" MarginTop="15" MinValue="0"/>
            <Its:button runat="server" Label="자재 추가" ID="btn_ADD_MTRITEM_ASY" BackColor="CustomButton2" MarginLeft="10" MarginTop="15"/>
        </Its:div>   

        <Its:split runat="server" Type="Horizon" Resizeable="false"/>

        <Its:div runat="server" Type="SplitDown">
            <Its:grid runat="server" ID="grid_ADD_MTRITEM_ASY"/>
        </Its:div>
    </Its:pop>

    <%--지난이력 불러오기--%>
    <Its:pop runat="server" ID="POP_RECORD_SUBITEM" Type="common" Title="지난이력 불러오기" Width="1300" Height="400"  >
        <Its:div runat="server" Type="SplitSingle">
            <Its:grid runat="server" ID="grid_REOCRD_SUBITEM"/>
        </Its:div>
    </Its:pop>


    <Its:pop runat="server" ID="pop_RENEW_MSTITEM" Type="common" Title="제품버전 갱신" Width="430" Height="210">
        <Its:div runat="server" Type="SplitSingle" ID="div_RENEW_MSTITEM">
            <Its:find runat="server" Label="품목코드" ID="find_ITEMCD_BEFORE" GPCD="ITEMCD" Field="ITEMCD_BEFORE" REF01="40" InputWidth="170" MarginTop="30"/>
            <Its:text runat="server" Label="품명" ID="txt_ITEMNM_BEFORE" ReadOnly="true" InputWidth="300" />     
            <Its:text runat="server" Label="버전" ID="txt_REV_BEFORE" ReadOnly="true" InputWidth="300"/>     
            <Its:newline runat="server" />
            <Its:button runat="server" Label="제품버전 갱신" BackColor="CustomButton" ID="btn_RENEW_MSTITEM" Width="160" Height="30" MarginTop="15" MarginLeft="130"/>
            <Its:newline runat="server" />
        </Its:div>
    </Its:pop>
</asp:Content>
