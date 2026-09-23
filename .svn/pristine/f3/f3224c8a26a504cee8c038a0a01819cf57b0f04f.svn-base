
<%-- PAGE --%>
<%@ Page Title="" Language="C#" MasterPageFile="~/Common/Master/MasterBase.master" AutoEventWireup="true" CodeFile="PRD0001_R02.aspx.cs" Inherits="PRD0001_R02" %>

<%-- HEAD --%>
<asp:Content ContentPlaceHolderID="CPH_HEAD" runat="Server">
    <script type="text/javascript" src="PRD0001_R02.js?ver=<%= BasePage.srcVersion %>"></script>
</asp:Content>

<%-- SEARCH PANEL --%>
<asp:Content ContentPlaceHolderID="CPH_SEARCH" runat="Server">
    <Its:div runat="server" Type="SearchPanel" ID="sdiv1">             

    </Its:div>
</asp:Content>

<%-- BODY --%>
<asp:Content ContentPlaceHolderID="CPH_BODY" runat="Server">
    <Its:tab runat="server" ID="tab1">
        <Its:div runat="server" Type="SplitSingle" TabTitle="가공 작업지시 등록">
            <Its:div runat="server" Type="SplitTop" >
                <Its:label runat="server" Text="■ 수주 리스트" Bold="true" Margin="0px 0px 0px 10px"/> 

                <Its:dateRange runat="server" Label="수주일자" ID="dateR_ODRDATE"/>
                <Its:find runat="server" Label= "수주품목" Field="ITEMCD" GPCD ="ITEMCD" ID="find_SALITEM"/>
                <Its:find runat="server" Label= "거래처" Field="CUSTCD" GPCD ="CUSTCD" ID="find_SALCUST"/>

                <Its:button runat="server" Label="작업지시 등록" ID="btn_POP_MAKE_PRDINS_CUT" BackColor="CustomButton2" MarginLeft="50"/>
            </Its:div>

            <Its:split runat="server" Type="Horizon" Resizeable="false" />

            <Its:div runat="server" Type="SplitDown" >
                <Its:grid runat="server" ID="grid_SALODRD"/>
            </Its:div>            
        </Its:div>

        <Its:div runat="server" Type="SplitSingle" TabTitle="가공 작업지시 조회">
            <Its:div runat="server" Type="SplitTop" TopHeightPc="50">
                <Its:div runat="server" Type="SplitTop" >
                    <Its:label runat="server" Text="■ 작업지시 리스트" Bold="true" Margin="0px 0px 0px 10px"/> 
                    <Its:dateRange runat="server" Label="지시일자" ID="dataR_INSDATE"/>
                    <Its:find runat="server" Label= "설비코드" ID="find_EQMCD_2" Field="EQMCD" GPCD ="EQMCD"/>
                    <Its:button runat="server" Label="작업지시 삭제" BackColor="CustomButton3" ID="btn_DEL_PRDINS_CUT" MarginLeft="50"/>
                </Its:div>

                <Its:split runat="server" Type="Horizon" Resizeable="false" />

                <Its:div runat="server" Type="SplitDown" >
                    <Its:grid runat="server" ID="grid_PRDINS"/>
                </Its:div>       
            </Its:div>

            <Its:split runat="server" Type="Horizon" />
       

            <Its:div runat="server" Type="SplitDown">
                <Its:div runat="server" Type="SplitTop" >
                    <Its:label runat="server" Text="■ 작업지시 상세" Bold="true" Margin="0px 0px 0px 10px"/> 
                    <Its:button runat="server" Label="작업지시 상세 수정" ID="btn_UPDATE_PRDINS_DETAIL" MarginLeft="50"/>
                    <Its:button runat="server" Label="작업지시 상세 삭제" ID="btn_DEL_PRDINS_DETAIL" />
                </Its:div>

                <Its:split runat="server" Type="Horizon" Resizeable="false" />

                <Its:div runat="server" Type="SplitDown" >
                    <Its:grid runat="server" ID="grid_PRDINS_DETAIL"/>
                </Its:div>            
            </Its:div>
        </Its:div>
    </Its:tab>
</asp:Content>

<%-- POP --%>
<asp:Content ContentPlaceHolderID="CPH_POP" Runat="Server">
    <Its:pop runat="server" ID="pop_MAKE_PRDINS_CUT" Type="common" Title="작업지시 등록" Width="1300" Height="340">
        <Its:div runat="server" Type="SplitLeft" ID="div_MAKE_PRDINS_CUT" LeftWidthPc="35" > 
            <Its:label runat="server" Text="■ 작업지시 정보" Bold="true" Margin="10px 0px 0px 10px"/> 
            <Its:newline runat="server" />
            <Its:text runat="server" Label="원자재코드" ID="txt_MTRITEMCD" MarginTop="10" InputWidth="300" ReadOnly="true"/>
            <Its:newline runat="server" />
            <Its:text runat="server" Label="원자재명" ID="txt_MTRITEMNM" InputWidth="300" ReadOnly="true"/>
            <Its:newline runat="server" />
            <Its:date runat="server" Label="지시일자" ID="date_INSDATE" MarginTop="10"/>
            <Its:newline runat="server" />
            <Its:find runat="server" Label="설비코드" ID="find_EQMCD" GPCD="EQMCD" Field="EQMCD" REF03 ="CUT" InputWidth="130" NameWidth="150"/>
            <Its:newline runat="server" />
<%--            <Its:find runat="server" Label="잔재코드" ID="find_MTRITEMCD_LEFT" GPCD="ITEMCDMTRLEFT" Field="ITEMCD_MTRLEFT" InputWidth="130" NameWidth="150"/>
            <Its:newline runat="server" />--%>
            <Its:text runat="server" Label="작업 특이사항" ID="txt_REMARK_PRDINS" InputWidth="300"/>
            <Its:newline runat="server" />          
            <Its:label runat="server" Text="작업지시서 파일등록" MarginTop="10"/>
            <Its:fileManager runat="server" ID="fm2" Field="FILEKEY" MarginTop="10"/>
            <Its:newline runat="server" />
            <Its:button runat="server" Label="작업지시 등록" BackColor="CustomButton2" ID="btn_MAKE_PRDINS_CUT" Width="160" Height="30" MarginTop="20" MarginLeft="130"/>
            <Its:newline runat="server" />
        </Its:div>
        <Its:split runat="server" Type="Vertical" Resizeable="false" />
        <Its:div runat="server" Type="SplitRight">
            <Its:div runat="server" Type="SplitTop" >
                <Its:label runat="server" Text="■ 수주없는 생산품" Bold="true" Margin="0px 0px 0px 10px"/> 
                <Its:button runat="server" Label="추가" ID="btn_ADD_ROW" MarginLeft="50"/>
                <Its:button runat="server" Label="삭제" ID="btn_DEL_ROW" />
            </Its:div>

            <Its:split runat="server" Type="Horizon" Resizeable="false" />

            <Its:div runat="server" Type="SplitDown" >
                <Its:grid runat="server" ID="grid_EXTRA_ITEM"/>
            </Its:div>  
        </Its:div>
    </Its:pop>

    <Its:pop runat="server" ID="pop_FILE_1" Type="common" Title="작업지시서 파일관리" Width="330" Height="120">
        <Its:div runat="server" Type="SplitSingle" ID="pfdiv1">
            <Its:fileManager runat="server" ID="fm1" Field="FILEKEY" MarginLeft="20" MarginTop="20" />
            <Its:button runat="server" Label="다운로드" ID="btn_DOWN_FILE_1" MarginLeft="20" MarginTop="5"/>
            <Its:text runat="server" Label="URL" Field="FILEURL" ID="txt_URL_FILE_1" Hidden="true" />
        </Its:div>
    </Its:pop>
</asp:Content>
