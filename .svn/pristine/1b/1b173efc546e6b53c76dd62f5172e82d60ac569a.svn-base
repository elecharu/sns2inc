<%-- PAGE --%>
<%@ Page Title="" Language="C#" MasterPageFile="~/Common/Master/MasterBase.master" AutoEventWireup="true" CodeFile="TQM1001_R02.aspx.cs" Inherits="TQM1001_R02" %>

<%-- HEAD --%>
<asp:Content ContentPlaceHolderID="CPH_HEAD" runat="Server">
    <script type="text/javascript" src="TQM1001_R02.js?ver=<%= BasePage.srcVersion %>"></script>
</asp:Content>

<%-- SEARCH --%>
<asp:Content ContentPlaceHolderID="CPH_SEARCH" Runat="Server">
    <Its:div runat="server" Type="SearchPanel" ID="sdiv1"> 
        <Its:combo runat="server" Label="품목유형" GPCD="*ITEMTP" Field="ITEMTP" />                       
        <Its:find runat="server" Label="품목코드" GPCD="ITEMCD" Field="ITEMCD"  InputWidth="130"/>   
    </Its:div>   
</asp:Content>

<%-- BODY --%>
<asp:Content ContentPlaceHolderID="CPH_BODY" Runat="Server">
        <Its:div runat="server" Type="SplitTop" TopHeightPc="40">
                <Its:div runat="server" Type="SplitLeft" LeftWidthPc="75">
                    <Its:div runat="server" Type="SplitLeft"  LeftWidthPc="30">
                        <Its:grid runat="server" ID="grid1" />
                    </Its:div>
                    <Its:split runat="server" Type="Vertical" Resizeable="true"/>
                    <Its:div runat="server" Type="SplitRight">
                        <Its:grid runat="server" ID="grid2" />
                    </Its:div>
                </Its:div>
            <Its:split runat="server" Type="Vertical" Resizeable="true"/>
                <Its:div runat="server" Type="SplitRight" >
                 
                    <Its:div runat="server" Type="SplitLeft"  LeftWidthPc="49" >
                            <Its:div runat="server" Type="SplitTop" TopHeightPc="10">
                                <Its:label runat="server" Text="■ 리비전" Bold="true" Margin="3px 0px 0px 10px"/>                     
                                <Its:button runat="server" Label="리비전 추가/갱신"  ID="btn_RENEW_REV" BackColor="CustomButton" MarginTop="4" MarginLeft="4"/>  
                                <Its:button runat="server" Label="리비전 삭제" ID="btn_DEL_REV"  BackColor="CustomButton3" MarginTop="4" MarginLeft="4"/>  
                            </Its:div>
                            <Its:split runat="server" Type="Horizon" Resizeable="false" />
                            <Its:div runat="server" Type="SplitDown">
                                <Its:grid runat="server" ID="grid3" />
                            </Its:div>   
                        </Its:div>   
                   
                 </Its:div>            
        
            </Its:div>   
        
        <Its:split runat="server" Type="Horizon"/>

        <Its:div runat="server" Type="SplitDown">
            
            <Its:div runat="server" Type="SplitTop" TopHeightPc="6.5">
                <Its:label runat="server" Text="■ 검사항목 리스트" Bold="true" Margin="3px 0px 0px 10px"/>
                
                <Its:button runat="server" Label="복사(팝업)"  ID="btn_COPY_POP" BackColor="CustomButton2" MarginTop="4" MarginLeft="50" Hidden="true"/>
                <Its:button runat="server" Label="추가(팝업)"  ID="btn_ADD_POP" BackColor="CustomButton2" MarginTop="4" Hidden="true"/>

                <Its:button runat="server" Label="저장"  ID="btn_SAVE_DETAIL" BackColor="CustomButton" MarginTop="4" Hidden="true" />
                <Its:button runat="server" Label="삭제"  ID="btn_DEL_DETAIL" BackColor="CustomButton3" MarginTop="4" Hidden="true"/>


            </Its:div>

            <Its:split runat="server" Type="Horizon" Resizeable="false"/>

            <Its:div runat="server" Type="SplitDown">
                <Its:grid runat="server" ID="grid4" />
            </Its:div>
          
        </Its:div>
</asp:Content>

<%-- POP --%>
<asp:Content ContentPlaceHolderID="CPH_POP" runat="server">
    <%--*****************************************************추가(팝업)*****************************************--%>
    <Its:pop runat="server" ID="pop_ADDSTD" Type="common" Title="검사항목 추가" Width="1000" Height="400">
        <Its:div runat="server" Type="SplitTop" TopHeightPc="12" ID="Div2" >
            <Its:combo runat="server" Label="검사구분" GPCD="STDTP" Field="STDTP" ID="cmb_STDTP_ADDSTD" ReadOnly="true" LabelWidth="70" InputWidth="100"/>                
            <Its:text runat="server" Label="품목코드"   ID="txt_ITEMCD_ADDSTD" ReadOnly="true" InputWidth="150" LabelWidth="70" />
            <Its:button runat="server" Label="추가" BackColor="CustomButton2" ID="btn_ADDSTD" MarginLeft="27"/>        
        </Its:div>

        <Its:split runat="server" Type="Horizon" Resizeable="false" />

        <Its:div runat="server" Type="SplitDown">
            <Its:grid runat="server" ID="grid_STD" />
        </Its:div>
    </Its:pop>

    <%--******************************************************복사(팝업*****************************************--%>
    <Its:pop runat="server" ID="pop_COPYSTD" Type="common" Title="검사항목 복사" Width="1600" Height="600">
        <Its:div runat="server" Type="SplitTop" TopHeightPc="5" ID="Div1" >
            <Its:combo runat="server" Label="검사구분" GPCD="STDTP" Field="STDTP" ID="cmb_STDTP_COPYSTD" ReadOnly="true" LabelWidth="70" InputWidth="100"/>   
            <Its:button runat="server" Label="복사" BackColor="CustomButton2" ID="btn_COPYSTD" MarginLeft="27"/>        
        </Its:div>

        <Its:split runat="server" Type="Horizon" Resizeable="false" />

        <Its:div runat="server" Type="SplitDown">
            <Its:div runat="server" Type="SplitTop" TopHeightPc="40">
                <Its:grid runat="server" ID="grid2_COPY" />
            </Its:div>

            <Its:split runat="server" Type="Horizon" Resizeable="false" />

            <Its:div runat="server" Type="SplitDown">
                <Its:div runat="server" Type="SplitLeft" LeftWidthPc="20">
                    <Its:grid runat="server" ID="grid3_COPY" />
                </Its:div>

                <Its:split runat="server" Type="Vertical" Resizeable="false" />

                <Its:div runat="server" Type="SplitRight">
                    <Its:grid runat="server" ID="grid4_COPY" />
                </Its:div>                            
            </Its:div>
        </Its:div>
    </Its:pop>

</asp:Content>