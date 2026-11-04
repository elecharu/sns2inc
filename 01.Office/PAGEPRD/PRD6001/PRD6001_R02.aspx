<%-- PRD6001_R02: 설비 일상점검 계획등록 --%>

<%-- PAGE --%>
<%@ Page Title="" Language="C#" MasterPageFile="~/Common/Master/MasterBase.master" AutoEventWireup="true" CodeFile="PRD6001_R02.aspx.cs" Inherits="PRD6001_R02" %>

<%-- HEAD --%>
<asp:Content ContentPlaceHolderID="CPH_HEAD" runat="Server">
    <script type="text/javascript" src="PRD6001_R02.js?ver=<%= BasePage.srcVersion %>"></script>
</asp:Content>


<%-- BODY --%>
<asp:Content ContentPlaceHolderID="CPH_BODY" runat="Server">
    <Its:tab runat="server" ID="tab1">
        <%-- 설비그룹 점검계획 탭: 화면 영역 --%>
        <Its:div runat="server" Type="SplitSingle" TabTitle="설비그룹 점검계획">         
            <Its:div runat="server" Type="SplitTop" TopHeightPc="4" BackColor="White" ID="div_GRP">
                <Its:find runat="server" Label="설비그룹" Field="EQMGRP" GPCD="FM116" ID="find_GRP" MarginLeft="10" MarginTop="6" LabelWidth="60" InputWidth="80" NameWidth="120"/>
                <Its:button runat="server" Label="계획서 출력" ID="btn_GRP_PLAN_RPT" Width="100" Float="right" MarginRight="10" MarginTop="6" BackColor="CustomButton2" />
            </Its:div>
            
            <Its:split runat="server" Type="Horizon" Resizeable="false"/>                

            <Its:div runat="server" Type="SplitDown">
                <Its:div runat="server" Type="SplitLeft" LeftWidthPc="26">
                    <Its:grid runat="server" ID="grid_GRP1" />   
                </Its:div>
                
                <Its:split runat="server" Type="Vertical" />            

                <Its:div runat="server" Type="SplitRight">
                    <Its:div runat="server" Type="SplitTop" TopHeightPc="40">
                        <Its:div runat="server" Type="SplitTop">
                            <Its:label runat="server" Text="■ 개정 이력 (REV)" Bold="true" MarginLeft="10"/>
                            <Its:button runat="server" Label="개정내용 저장" ID="btn_GRP_REV_SAVE" MarginLeft="40" BackColor="CustomButton2" />
                            <Its:button runat="server" Label="승인" ID="btn_GRP_APPROVE" MarginLeft="10" BackColor="CustomButton" />
                        </Its:div>

                        <Its:split runat="server" Type="Horizon" Resizeable="false" />

                        <Its:div runat="server" Type="SplitDown">
                            <Its:grid runat="server" ID="grid_GRP_REV" />
                        </Its:div>
                    </Its:div>

                    <Its:split runat="server" Type="Horizon" />

                    <Its:div runat="server" Type="SplitDown">
                        <Its:div runat="server" Type="SplitTop">
                            <Its:label runat="server" Text="■ 일상점검" Bold="true" MarginLeft="10" ID="lbl_GRP_ITEM"/>
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
            <Its:div runat="server" Type="SplitTop" TopHeightPc="4" BackColor="White" ID="div_EQM">
                <Its:combo runat="server" Label="작업장" Field="LINECD" ID="cmb_LINECD" REF01="07" GPCD="*LINECD" MarginLeft="10" MarginTop="6" LabelWidth="50" InputWidth="100" />
                <Its:combo runat="server" Label="공정" Field="EQMTP" ID="cmb_EQMTP" GPCD="*EQMTP" MarginLeft="15" MarginTop="6" LabelWidth="40" InputWidth="80" />
                <Its:combo runat="server" Label="라인" Field="EQMGROUP1" ID="cmb_EQMGROUP1" GPCD="*EQMGROUP1" MarginLeft="15" MarginTop="6" LabelWidth="40" InputWidth="80" />                
                <Its:find runat="server" Label="설비" Field="FANO" GPCD="EQMCD" ID="find_EQMCD" MarginLeft="15" MarginTop="6" LabelWidth="38" InputWidth="80" NameWidth="120"/>               
                <Its:button runat="server" Label="계획서 출력" ID="btn_EQM_PLAN_RPT" Width="100" Float="right" MarginRight="10" MarginTop="6" BackColor="CustomButton2" />
            </Its:div>
            
            <Its:split runat="server" Type="Horizon" Resizeable="false"/>                

            <Its:div runat="server" Type="SplitDown">
                <Its:div runat="server" Type="SplitLeft" LeftWidthPc="26">
                    <Its:grid runat="server" ID="grid1" />   
                </Its:div>
                
                <Its:split runat="server" Type="Vertical" />            

                <Its:div runat="server" Type="SplitRight">              
                    <Its:div runat="server" Type="SplitTop" TopHeightPc="40">
                        <Its:div runat="server" Type="SplitTop">
                            <Its:label runat="server" Text="■ 개정 이력 (REV)" Bold="true" MarginLeft="10"/>
                            <Its:button runat="server" Label="개정내용 저장" ID="btn_EQM_REV_SAVE" MarginLeft="40" BackColor="CustomButton2" />
                            <Its:button runat="server" Label="승인" ID="btn_EQM_APPROVE" MarginLeft="10" BackColor="CustomButton" />
                        </Its:div>

                        <Its:split runat="server" Type="Horizon" Resizeable="false" />

                        <Its:div runat="server" Type="SplitDown">
                            <Its:grid runat="server" ID="grid_EQM_REV" />
                        </Its:div>
                    </Its:div>

                    <Its:split runat="server" Type="Horizon" />

                    <Its:div runat="server" Type="SplitDown">
                        <Its:div runat="server" Type="SplitTop">
                            <Its:label runat="server" Text="■ 일상점검" Bold="true" MarginLeft="10" ID="lbl_EQM_ITEM"/>
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

    </Its:tab>
</asp:Content>


<%-- POP --%>
<asp:Content ContentPlaceHolderID="CPH_POP" runat="server">
    <Its:pop runat="server" ID="pop_EQM02_ADD" Title="일상점검항목 추가" Width="900" Height="500">
        <Its:div runat="server" Type="SplitTop" ID="Div1" TopHeightPc="93">
            <Its:grid runat="server" ID="grid10" />
        </Its:div>
        <Its:split runat="server" Type="Horizon" Resizeable="false" />
        <Its:div runat="server" Type="Splitdown" ID="Div3">
            <Its:button runat="server" Label="저장" ID="btn_ADD_EQM02" Width="100" MarginLeft="350" BackColor="CustomButton" />
            <Its:button runat="server" Label="취소" ID="btn_CANCEL_ADD_EQM02" Width="100" BackColor="CustomButton3"/>
        </Its:div>
    </Its:pop>

    <Its:pop runat="server" ID="pop_EQM02_COPY" Title="일상점검항목 복사" Width="1200" Height="500">    
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

    <Its:pop runat="server" ID="pop_GRP_EQM02_COPY" Title="설비그룹 일상점검 복사" Width="1200" Height="500">
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
