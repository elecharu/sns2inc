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
            <Its:div runat="server" Type="SplitTop" TopHeightPc="4" BackColor="White" ID="div_GRP">
                <Its:find runat="server" Label="설비그룹" Field="EQMGRP" GPCD="FM116" ID="find_GRP" MarginLeft="10" MarginTop="6" LabelWidth="60" InputWidth="120" NameWidth="150"/>
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
                            <Its:label runat="server" Text="■ 정기점검" Bold="true" MarginLeft="10" ID="lbl_GRP_ITEM"/>
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
                <Its:find runat="server" Label="설비" Field="FANO" GPCD="EQMCD" ID="find_EQMCD" MarginLeft="10" MarginTop="6" LabelWidth="38" InputWidth="80" NameWidth="150"/>                      
                <Its:find runat="server" Label="설비그룹" Field="EQMGRP" GPCD="FM116" ID="find_EQM_GRP" MarginLeft="15" MarginTop="6" LabelWidth="60" InputWidth="120" NameWidth="150"/>
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
                            <Its:label runat="server" Text="■ 정기점검" Bold="true" MarginLeft="10" ID="lbl_EQM_ITEM"/>
                            <Its:button runat="server" Label="복사" ID="bdiv3_btn_COPY" MarginLeft="40" BackColor="CustomButton2" />
                            <Its:button runat="server" Label="추가" ID="bdiv3_btn_ADD" MarginLeft="10" BackColor="CustomButton2" />
                            <Its:button runat="server" Label="저장" ID="bdiv3_btn_SAVE" MarginLeft="10" BackColor="CustomButton" />
                            <Its:button runat="server" Label="삭제" ID="bdiv3_btn_DEL" MarginLeft="10" BackColor="CustomButton3" />
                            <Its:label runat="server" Text="※ 수정 시 소속 설비그룹도 승인 대기로 전환됩니다." ID="lbl_EQM_REV_INFO" ForeColor="BlueDark1" MarginLeft="20"/>
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
            <Its:div runat="server" Type="SplitTop" TopHeightPc="4" BackColor="White" ID="div_CYCLE_EQM">
                <Its:combo runat="server" Label="조회년도" ID="cmb_SYEAR" Field="SYEAR" GPCD="YEAR" REF01="-4" REF02="0" MarginLeft="10" MarginTop="6" LabelWidth="60" />
                <Its:find runat="server" Label="설비" Field="FANO" GPCD="EQMCD" ID="find1" MarginLeft="15" MarginTop="6" LabelWidth="38" />
                <Its:find runat="server" Label="점검자" Field="EMPCD" GPCD="EMPCD" ID="find_EMP" MarginLeft="15" MarginTop="6" LabelWidth="70" InputWidth="90" NameWidth="110" />
                <Its:button runat="server" Label="일괄 주기설정" ID="btn_OPEN_CYCLE_BATCH" Width="100" MarginLeft="25" MarginTop="6" BackColor="CustomButton2" />
                <Its:button runat="server" Label="저장" ID="div_SAVE_CYCLE_EQM" MarginLeft="25" MarginTop="6" BackColor="CustomButton" />
                <Its:button runat="server" Label="삭제" ID="div_DEL_CYCLE_EQM" MarginLeft="10" MarginTop="6" BackColor="CustomButton3" />
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

    <Its:pop runat="server" ID="pop_CYCLE_BATCH" Title="정기점검 일괄 주기설정" Width="640" Height="300">
        <div style="padding: 12px 18px; font-size: 12px; color: #333; line-height: 1.6;">
            <!-- 상단 요약 안내 -->
            <div style="background-color: #f3f6fa; border: 1px solid #d5e0ee; border-radius: 4px; padding: 10px 14px; margin-bottom: 12px;">
                <span style="font-weight: bold; color: #224488;">선택된 대상 설비:</span>
                <span id="lbl_BATCH_CNT" style="font-weight: bold; color: #e53935; font-size: 14px; margin-left: 6px;">0</span> 대
                <span style="color: #666; margin-left: 15px; font-size: 11px;">※ 체크된 설비에 일괄 적용됩니다.</span>
            </div>

            <div style="display: flex; justify-content: space-between; align-items: center; margin-bottom: 8px;">
                <span style="font-weight: bold; color: #444;">적용 대상 월 선택:</span>
                <button type="button" id="btn_ALL_MONTH" style="padding: 4px 12px; font-size: 11px; font-weight: bold; cursor: pointer; border: 1px solid #d32f2f; background: #ffebee; color: #d32f2f; border-radius: 3px;">전체 해제</button>
            </div>

            <!-- 월별 체크박스 (1월 ~ 12월) -->
            <div style="border: 1px solid #dcdcdc; border-radius: 4px; padding: 10px 14px; background: #fafafa; margin-bottom: 15px;">
                <div style="display: grid; grid-template-columns: repeat(6, 1fr); gap: 8px;">
                    <label style="cursor: pointer; background: #fff; padding: 4px 8px; border: 1px solid #e0e0e0; border-radius: 3px; display: flex; align-items: center; justify-content: center;">
                        <input type="checkbox" class="chk_MONTH" value="M01" style="margin-right: 5px;" /> 1월
                    </label>
                    <label style="cursor: pointer; background: #fff; padding: 4px 8px; border: 1px solid #e0e0e0; border-radius: 3px; display: flex; align-items: center; justify-content: center;">
                        <input type="checkbox" class="chk_MONTH" value="M02" style="margin-right: 5px;" /> 2월
                    </label>
                    <label style="cursor: pointer; background: #fff; padding: 4px 8px; border: 1px solid #e0e0e0; border-radius: 3px; display: flex; align-items: center; justify-content: center;">
                        <input type="checkbox" class="chk_MONTH" value="M03" style="margin-right: 5px;" /> 3월
                    </label>
                    <label style="cursor: pointer; background: #fff; padding: 4px 8px; border: 1px solid #e0e0e0; border-radius: 3px; display: flex; align-items: center; justify-content: center;">
                        <input type="checkbox" class="chk_MONTH" value="M04" style="margin-right: 5px;" /> 4월
                    </label>
                    <label style="cursor: pointer; background: #fff; padding: 4px 8px; border: 1px solid #e0e0e0; border-radius: 3px; display: flex; align-items: center; justify-content: center;">
                        <input type="checkbox" class="chk_MONTH" value="M05" style="margin-right: 5px;" /> 5월
                    </label>
                    <label style="cursor: pointer; background: #fff; padding: 4px 8px; border: 1px solid #e0e0e0; border-radius: 3px; display: flex; align-items: center; justify-content: center;">
                        <input type="checkbox" class="chk_MONTH" value="M06" style="margin-right: 5px;" /> 6월
                    </label>
                    <label style="cursor: pointer; background: #fff; padding: 4px 8px; border: 1px solid #e0e0e0; border-radius: 3px; display: flex; align-items: center; justify-content: center;">
                        <input type="checkbox" class="chk_MONTH" value="M07" style="margin-right: 5px;" /> 7월
                    </label>
                    <label style="cursor: pointer; background: #fff; padding: 4px 8px; border: 1px solid #e0e0e0; border-radius: 3px; display: flex; align-items: center; justify-content: center;">
                        <input type="checkbox" class="chk_MONTH" value="M08" style="margin-right: 5px;" /> 8월
                    </label>
                    <label style="cursor: pointer; background: #fff; padding: 4px 8px; border: 1px solid #e0e0e0; border-radius: 3px; display: flex; align-items: center; justify-content: center;">
                        <input type="checkbox" class="chk_MONTH" value="M09" style="margin-right: 5px;" /> 9월
                    </label>
                    <label style="cursor: pointer; background: #fff; padding: 4px 8px; border: 1px solid #e0e0e0; border-radius: 3px; display: flex; align-items: center; justify-content: center;">
                        <input type="checkbox" class="chk_MONTH" value="M10" style="margin-right: 5px;" /> 10월
                    </label>
                    <label style="cursor: pointer; background: #fff; padding: 4px 8px; border: 1px solid #e0e0e0; border-radius: 3px; display: flex; align-items: center; justify-content: center;">
                        <input type="checkbox" class="chk_MONTH" value="M11" style="margin-right: 5px;" /> 11월
                    </label>
                    <label style="cursor: pointer; background: #fff; padding: 4px 8px; border: 1px solid #e0e0e0; border-radius: 3px; display: flex; align-items: center; justify-content: center;">
                        <input type="checkbox" class="chk_MONTH" value="M12" style="margin-right: 5px;" /> 12월
                    </label>
                </div>
            </div>

            <!-- 하단 버튼 영역 -->
            <div style="display: flex; justify-content: center; gap: 10px; margin-top: 15px;">
                <Its:button runat="server" Label="등록" ID="btn_SAVE_BATCH" Width="100" BackColor="CustomButton" />
                <Its:button runat="server" Label="닫기" ID="btn_CLOSE_BATCH" Width="90" BackColor="CustomButton3" />
            </div>
        </div>
    </Its:pop>
</asp:Content>
