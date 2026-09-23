<%-- PAGE --%>
<%@ Page Title="" Language="C#" MasterPageFile="~/Common/Master/MasterBase.master" AutoEventWireup="true" CodeFile="EQM1001_R03.aspx.cs" Inherits="EQM1001_R03" %>

<%-- HEAD --%>
<asp:Content ContentPlaceHolderID="CPH_HEAD" runat="Server">
    <script type="text/javascript" src="EQM1001_R03.js?ver=<%= BasePage.srcVersion %>"></script>
</asp:Content>


<%-- BODY --%>
<asp:Content ContentPlaceHolderID="CPH_BODY" runat="Server">
    <Its:tab runat="server" ID="tab1">
        <%-- 설비그룹 점검계획 탭: 화면 영역 --%>
        <Its:div runat="server" Type="SplitSingle" TabTitle="설비그룹 점검계획">         
            <Its:div runat="server" Type="SplitTop" TopHeightPc="3.5" BackColor="White" ID="div_GRP">
                <Its:find runat="server" Label="설비그룹" Field="EQMGRP" GPCD="FM116" ID="find_GRP" MarginLeft="-25" MarginTop="3" InputWidth="120" NameWidth="150"/>
            </Its:div>
            
            <Its:split runat="server" Type="Horizon" Resizeable="false"/>                

            <Its:div runat="server" Type="SplitDown">
                <Its:div runat="server" Type="SplitLeft" LeftWidthPc="26">
                    <Its:grid runat="server" ID="grid_GRP1" />   
                </Its:div>
                
                <Its:split runat="server" Type="Vertical" />            

                <Its:div runat="server" Type="SplitRight">
                    <Its:div runat="server" Type="SplitDown">
                        <Its:div runat="server" Type="SplitTop" TopHeightPc="7">
                            <Its:label runat="server" Text="■ 정기점검" Bold="true" MarginLeft="10"/>
                            <Its:button runat="server" Label="복사" ID="bdiv_GRP_btn_COPY" MarginLeft="40" BackColor="CustomButton2" />
                            <Its:button runat="server" Label="추가" ID="bdiv_GRP_btn_ADD" MarginLeft="10" BackColor="CustomButton2" />
                            <Its:button runat="server" Label="저장" ID="bdiv_GRP_btn_SAVE" MarginLeft="10" BackColor="CustomButton" />
                            <Its:button runat="server" Label="삭제" ID="bdiv_GRP_btn_DEL" MarginLeft="10" BackColor="CustomButton3" />
                        </Its:div>

                        <Its:split runat="server" Type="Horizon" Resizeable="false" />

                        <Its:div runat="server" Type="SplitDown">
                            <Its:grid runat="server" ID="grid_GRP2" />       
                        </Its:div>                                              
                    </Its:div>     
                </Its:div>                   
            </Its:div>
        </Its:div>

        <%-- 설비별 점검계획 탭: 화면 영역 --%>
        <Its:div runat="server" Type="SplitSingle" TabTitle="설비별 점검계획">         
            <Its:div runat="server" Type="SplitTop" TopHeightPc="3.5" BackColor="White" ID="div_EQM">
                <Its:find runat="server" Label="설비" Field="FANO" GPCD="EQMCD" ID="find_EQMCD" MarginLeft="-50" MarginTop="3" InputWidth="80" NameWidth="150"/>                      
            </Its:div>
            
            <Its:split runat="server" Type="Horizon" Resizeable="false"/>                

            <Its:div runat="server" Type="SplitDown">
                <Its:div runat="server" Type="SplitLeft" LeftWidthPc="26">
                    <Its:grid runat="server" ID="grid1" />   
                </Its:div>
                
                <Its:split runat="server" Type="Vertical" />            

                <Its:div runat="server" Type="SplitRight">              
                    <Its:div runat="server" Type="SplitDown">
                        <Its:div runat="server" Type="SplitTop" TopHeightPc="7">
                            <Its:label runat="server" Text="■ 정기점검" Bold="true" MarginLeft="10"/>
                            <Its:button runat="server" Label="복사" ID="bdiv3_btn_COPY" MarginLeft="40" BackColor="CustomButton2" />
                            <Its:button runat="server" Label="추가" ID="bdiv3_btn_ADD" MarginLeft="10" BackColor="CustomButton2" />
                            <Its:button runat="server" Label="저장" ID="bdiv3_btn_SAVE" MarginLeft="10" BackColor="CustomButton" />
                            <Its:button runat="server" Label="삭제" ID="bdiv3_btn_DEL" MarginLeft="10" BackColor="CustomButton3" />
                        </Its:div>

                        <Its:split runat="server" Type="Horizon" Resizeable="false" />

                        <Its:div runat="server" Type="SplitDown">
                            <Its:grid runat="server" ID="grid3" />       
                        </Its:div>                                              
                    </Its:div>     
                </Its:div>                   
            </Its:div>
        </Its:div>
        
        <%-- 정기점검 주기관리 탭: 화면 영역 --%>
        <Its:div runat="server" Type="SplitSingle" TabTitle="정기점검 주기관리">
            <Its:div runat="server" Type="SplitTop" TopHeightPc="3.5" BackColor="White" ID="div_CYCLE_EQM">
                <Its:combo runat="server" Label="조회년도" ID="cmb_SYEAR" Field="SYEAR" GPCD="YEAR" REF01="-4" REF02="0" />
                <Its:find runat="server" Label="설비" Field="FANO" GPCD="EQMCD" ID="find1" />
                <Its:button runat="server" Label="저장" ID="div_SAVE_CYCLE_EQM" MarginLeft="50" BackColor="CustomButton" />
                <Its:button runat="server" Label="삭제" ID="div_DEL_CYCLE_EQM" MarginLeft="10" BackColor="CustomButton3" />
            </Its:div>
            
            <Its:split runat="server" Type="Horizon" Resizeable="false"/>                

            <Its:div runat="server" Type="SplitDown">
                <Its:grid runat="server" ID="grid9" />   
            </Its:div>
        </Its:div>   

    </Its:tab>
</asp:Content>


<%-- POP --%>
<asp:Content ContentPlaceHolderID="CPH_POP" runat="server">

    <Its:pop runat="server" ID="pop_EQM02_ADD" Title="정기점검항목 추가" Width="900" Height="500">
        <Its:div runat="server" Type="SplitTop" ID="Div1" TopHeightPc="93">
            <Its:grid runat="server" ID="grid10" />
        </Its:div>
        <Its:split runat="server" Type="Horizon" Resizeable="false" />
        <Its:div runat="server" Type="Splitdown" ID="Div3">
            <Its:button runat="server" Label="저장" ID="btn_ADD_EQM02" Width="100" MarginLeft="350" BackColor="CustomButton" />
            <Its:button runat="server" Label="취소" ID="btn_CANCEL_ADD_EQM02" Width="100" BackColor="CustomButton3"/>
        </Its:div>
    </Its:pop>

    <Its:pop runat="server" ID="pop_EQM02_COPY" Title="정기점검항목 복사" Width="1200" Height="500">    
        <Its:div runat="server" Type="SplitTop" TopHeightPc="90">
            <Its:div runat="server" Type="SplitLeft" LeftWidthPc="30"> 
                <Its:grid runat="server" ID="grid7" />   
            </Its:div>
        
            <Its:split runat="server" Type="Vertical" Resizeable="false" />
            
            <Its:div runat="server" Type="SplitRight">
                <Its:grid runat="server" ID="grid8" />   
            </Its:div> 
        </Its:div>

        <Its:split runat="server" Type="Horizon" Resizeable="false" />

        <Its:div runat="server" Type="SplitDown" BackColor="GrayLight2">
            <Its:button runat="server" Label="저장" ID="btn_COPY_EQM02" Width="100" MarginTop="5" MarginLeft="500" Height="30"/>
            <Its:button runat="server" Label="취소" ID="btn_CANCEL_COPY_EQM02" Width="100" MarginTop="5" MarginLeft="20" Height="30"/>
        </Its:div>
    </Its:pop>    

    <%-- 2026-09-21 설비그룹 정기점검 복사: 설비별 복사 모달과 분리하여 설비그룹과 그룹별 점검항목을 조회 --%>
    <Its:pop runat="server" ID="pop_GRP_EQM02_COPY" Title="설비그룹 정기점검 복사" Width="1200" Height="500">
        <Its:div runat="server" Type="SplitTop" TopHeightPc="90">
            <Its:div runat="server" Type="SplitLeft" LeftWidthPc="30">
                <Its:grid runat="server" ID="grid_GRP_COPY1" />
            </Its:div>

            <Its:split runat="server" Type="Vertical" Resizeable="false" />

            <Its:div runat="server" Type="SplitRight">
                <Its:grid runat="server" ID="grid_GRP_COPY2" />
            </Its:div>
        </Its:div>

        <Its:split runat="server" Type="Horizon" Resizeable="false" />

        <Its:div runat="server" Type="SplitDown" BackColor="GrayLight2">
            <Its:button runat="server" Label="저장" ID="btn_COPY_GRP_EQM02" Width="100" MarginTop="5" MarginLeft="500" Height="30"/>
            <Its:button runat="server" Label="취소" ID="btn_CANCEL_GRP_COPY_EQM02" Width="100" MarginTop="5" MarginLeft="20" Height="30"/>
        </Its:div>
    </Its:pop>
</asp:Content>
