
<%-- 'CodeFile', 'Inherits' --%>
<%@ Page Title="" Language="C#" MasterPageFile="~/Common/Kiosk/Kiosk.master" AutoEventWireup="true" 
    CodeFile="TAL1001_R01.aspx.cs" Inherits="TAL1001_R01" %>

<%-- HEAD --%>
<asp:Content ContentPlaceHolderID="CPH_HEAD" Runat="Server">
    <script type="text/javascript" src="TAL1001_R01.js?ver=<%= BasePage.srcVersion %>"></script>

</asp:Content>


<%-- SEARCH --%>
<asp:Content ContentPlaceHolderID="CPH_SEARCH" Runat="Server">
    <Its:div runat="server" Type="SearchPanel" ID="sdiv1">
        <Its:dateRange runat="server" Label="지시일자" ID="dateR_INSDATE"  /> 
        <its:combo runat="server" Label="지시상태" Field="WORKSTT" GPCD="*WORKSTT" ID="cmb_WORKSTT"/>
        <its:combo runat="server" Label="설비코드" Field="EQMCD" GPCD="*EQMCD" ID="cmb_EQMCD" REF02="CUT" InputWidth="200"/>
        <Its:button runat="server" Label="가공 작업지시 조회" ID="btn_LIST_PRDINS_CUT"  Width="200" MarginLeft="40"/>
        <Its:check runat="server" Label="생산완료 포함"  ID ="chk_WORKSTT_99_YN" Field="WORKSTT_99_YN"  Value="N"  MarginLeft="20" MarginTop="6"/>  

    </Its:div>
</asp:Content>

<%-- BODY --%>
<asp:Content ContentPlaceHolderID="CPH_BODY" Runat="Server">
    <Its:div runat="server" Type="SplitSingle">
        <Its:grid runat="server" ID="grid_PRDINS_CUT" />
    </Its:div>
</asp:Content>

<%-- POP --%>
<asp:Content ContentPlaceHolderID="CPH_POP" runat="server">
    <Its:pop runat="server" ID="pop_ADD_PRDINSSCAN" Title="자재투입 등록" Width="1200" Height="500">
        <Its:tab runat="server" ID="tab_ADD_PRDINSSCAN">
            <Its:div runat="server" Type="SplitSingle" TabTitle="자재투입 등록">
                <Its:grid runat="server" ID="grid_COMLOT_MTR"/>
            </Its:div>

            <Its:div runat="server" Type="SplitSingle" TabTitle="자재투입이력 조회">
                <Its:grid runat="server" ID="grid_PRDINSSCAN"/>
            </Its:div>
        </Its:tab>
    </Its:pop>

    <Its:pop runat="server" ID="pop_ADD_PRDRST" Title="생산실적 등록" Width="1100" Height="500">
        <Its:div runat="server" Type="SplitTop" TopHeightPc="25">   
            <Its:button runat="server" Label="양품 등록" ID="btn_ADD_PRDRST_CUT" Width="100" ForeColor="White" MarginTop="10" MarginLeft="20" MarginRight="10"/>                      
            <Its:button runat="server" Label="작업지시서 보기" ID="btn_OPEN_PRDINS_FILE" Width="100" ForeColor="White" MarginTop="10" MarginLeft="20"/>                                                
            <Its:combo runat="server" Label="불량유형" ID="cmb_BADTP" GPCD="*BADTP_PRCCD" Field="BADTP" REF01="CUT" LabelWidth="80" InputWidth="200" Float="right" MarginTop="10" MarginRight="323"/>
            <Its:newline runat="server" />
            <Its:button runat="server" Label="추가생산 등록" ID="btn_ADD_PRDRST_CUT_EXTRA" Width="120" ForeColor="White" MarginTop="10" MarginLeft="20" MarginRight="10"/>          
            <Its:button runat="server" Label="불량 등록" ID="btn_ADD_PRDRSTBAD" Width="80" ForeColor="White" Float="right" MarginTop="10" MarginLeft="10" MarginRight="10"/>
            <Its:num runat="server" Label="불량수량" ID="num_BADQTY" Float="right" LabelWidth="80" MarginTop="10"/>
            <Its:combo runat="server" Label="불량코드" ID="cmb_BADCD" GPCD="BADCD" Field="BADCD" LabelWidth="80" InputWidth="200" Float="right" MarginTop="10" REF02="CUT"/>
        </Its:div>

        <Its:split runat="server" Type="Horizon" Resizeable="false" />

        <Its:div runat="server" Type="SplitDown">
            <Its:grid runat="server" ID="grid_PRDITEM" />
        </Its:div>        
    </Its:pop>

    <Its:pop runat="server" ID="pop_SCANQTY" Title="투입수량" Width="400" Height="100">
        <Its:num runat="server" Label="투입수량" ID="num_SCANQTY" MarginTop="5" MarginLeft="10"/>
        <Its:button runat="server" Label="자재투입 등록" ID="btn_ADD_PRDINSSCAN" ForeColor="White" MarginTop="5" MarginLeft="15"/>
    </Its:pop>

    <Its:pop runat="server" ID="pop_COMLOT_MTRLEFT" Title="잔재 생성"  Width="1300" Height="500">
        <Its:div runat="server" Type="SplitTop" TopHeightPc="14">
            <Its:combo runat="server" Label="보관창고" GPCD="WARECD" Field="WARECD" ID="cmb_WARECD" REF02="MTR" MarginTop="10" MarginLeft="10"/>
            <Its:num runat="server" Label="길이" ID="num_LENGTH2" MarginTop="10" MarginLeft="10"/>
            <Its:num runat="server" Label="폭" ID="num_WIDTH2" MarginTop="10" MarginLeft="10"/>
            <Its:num runat="server" Label="장수" ID="num_LOTQTY" MarginTop="10" MarginLeft="10"/>
            <Its:button runat="server" Label="잔재생성" ID="btn_MAKE_MTRLEFT" ForeColor="White" MarginTop="10" MarginLeft="20" Width="100" />
        </Its:div>        
        <Its:split runat="server" Type="Horizon" Resizeable="false"/>
        <Its:div runat="server" Type="SplitDown">
            <Its:grid runat="server" ID="grid_COMLOT_MTRLEFT" />
        </Its:div>        
    </Its:pop>

    <Its:pop runat="server" ID="pop_SIZECHANGE" Title="잔재사이즈 변경"  Width="400" Height="150">
        <Its:div runat="server" Type="SplitSingle">
            <Its:num runat="server" Label="길이" ID="num_LENGTH" MarginTop="5" MarginLeft="10"/>
            <Its:button runat="server" Label="변경" ID="btn_SIZECHANGE" ForeColor="White" MarginTop="5" MarginLeft="15" Width="90"/>
            <Its:newline runat="server" />
            <Its:num runat="server" Label="폭" ID="num_WIDTH" MarginTop="5" MarginLeft="10"/>
        </Its:div>        
    </Its:pop>

    <Its:pop runat="server" ID="pop_DEL_PRDRST" Title="생산실적 삭제"  Width="1000" Height="500">
        <Its:div runat="server" Type="SplitSingle">
            <Its:grid runat="server" ID="grid_PRDRST" />
        </Its:div>        
    </Its:pop>
</asp:Content>