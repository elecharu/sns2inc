<%-- PAGE --%>
<%@ Page Title="" Language="C#" MasterPageFile="~/Common/Master/MasterBase.master" AutoEventWireup="true" CodeFile="EQM1001_R01.aspx.cs" Inherits="EQM1001_R01" %>

<%-- HEAD --%>
<asp:Content ContentPlaceHolderID="CPH_HEAD" runat="Server">
    <script type="text/javascript" src="EQM1001_R01.js?ver=<%= BasePage.srcVersion %>"></script>
    <style>
        .repimg-box { display: flex; flex-direction: column; height: 100%; padding: 6px 8px 0 8px; box-sizing: border-box; white-space: normal; }
        .repimg-view { position: relative; flex: 1; min-height: 0; border: 1px dashed #bbb; border-radius: 4px; background: #fafafa; }
        .repimg-view > div { width: 100% !important; height: 100% !important; line-height: normal !important; display: flex; align-items: center; justify-content: center; }
        .repimg-view img { cursor: zoom-in; }
        .repimg-page { display: none; position: absolute; top: 6px; left: 8px; z-index: 1; padding: 1px 6px; border-radius: 3px; background: #e6f1fb; color: #0c447c; font-size: 11px; }
        .repimg-list { display: flex; flex-wrap: wrap; gap: 10px; flex: 0 0 auto; max-height: 136px; padding: 4px 2px 6px 2px; overflow-x: hidden; overflow-y: auto; box-sizing: border-box; }
        .repimg-thumb { position: relative; flex: 0 0 auto; width: 54px; height: 54px; margin-top: 6px; border: 1px solid #bbb; border-radius: 3px; background: #fff; cursor: pointer; box-sizing: border-box; }
        .repimg-thumb img { width: 100%; height: 100%; object-fit: cover; border-radius: 2px; }
        .repimg-thumb.on { border: 2px solid #378add; }
        .repimg-del { position: absolute; top: -7px; right: -7px; width: 16px; height: 16px; line-height: 14px; border: 1px solid #bbb; border-radius: 50%; background: #fff; color: #d32f2f; font-size: 11px; text-align: center; cursor: pointer; }
        .repimg-empty { display: none; position: absolute; top: 50%; left: 0; right: 0; transform: translateY(-50%); color: #999; font-size: 13px; text-align: center; }
        .repimg-view.empty > div { display: none !important; }
        .repimg-view.empty .repimg-empty { display: block; }
        #file_REPIMG { display: none !important; }
        .wl-body { height: 100%; overflow-y: auto; overflow-x: hidden; padding: 10px 12px; box-sizing: border-box; background: #f4f6f9; }
        .wl-pop { height: calc(100% - 52px); }
        #pp_div1 { margin-bottom: 8px; }
        .wl-card { background: #fff; border: 1px solid #e1e6ed; border-radius: 6px; padding: 0 14px 12px 14px; margin-bottom: 10px; overflow: hidden; }
        .wl-card-hd { margin: 0 -14px 10px -14px; padding: 0 14px; height: 36px; line-height: 36px; border-bottom: 1px solid #eef1f5; font-weight: bold; color: #1f3b63; }
        .wl-card-hd .ItsButton { margin-top: 6px; line-height: normal; }
        .wl-no { display: inline-block; width: 20px; height: 20px; line-height: 20px; margin-right: 8px; border-radius: 50%; background: #378add; color: #fff; font-size: 11px; text-align: center; vertical-align: 1px; }
        .wl-sub { clear: both; height: 30px; line-height: 30px; margin-top: 8px; padding-top: 6px; border-top: 1px dashed #e1e6ed; font-weight: bold; color: #1f3b63; }
        .wl-sub .ItsButton { margin-top: 3px; line-height: normal; }
        .wl-grid { clear: both; height: 130px; margin-top: 4px; }
        .wl-grid-emp { width: 440px; height: 110px; }
        .wl-body div.ItsTextArea { float: none !important; display: block; width: 100%; }
        .wl-body div.ItsTextArea_table { display: block; width: 100%; }
        .wl-body div.ItsTextArea_table > span { display: none; }
        .wl-body div.ItsTextArea_table > textarea { width: 100% !important; border-radius: 4px; line-height: 18px; }
        .wl-head { height: 100%; line-height: 38px; padding-left: 12px; white-space: nowrap; }
        .wl-head .ItsButton { margin-top: 5px; line-height: normal; }
        .wl-title { font-weight: bold; font-size: 14px; color: #1f3b63; }
        .wl-key { margin-left: 10px; font-weight: bold; color: #378add; }
        .wl-note { margin-left: 8px; font-size: 12px; color: #8a96a3; }
    </style>
</asp:Content>

<%-- SEARCH PANEL --%>
<asp:Content ContentPlaceHolderID="CPH_SEARCH" runat="Server">
    <Its:div runat="server" ID="sdiv1" Type="SearchPanel">
        <Its:dateRange runat="server" Label="등록일자" ID="date_SEARCH" FieldFrom="SDATE" FieldTo="EDATE" />
        <Its:combo runat="server" Label="작업장" ID="cmb_LINECD" Field="LINECD" GPCD="*LINECD" REF01="07" />
        <Its:combo runat="server" Label="공정" ID="cmb_EQMTP" Field="EQMTP" GPCD="*EQMTP" InputWidth="70" />
        <Its:combo runat="server" Label="라인" ID="cmb_EQMGROUP1" Field="EQMGROUP1" GPCD="*EQMGROUP1" InputWidth="70" />
        <Its:find runat="server" Label="설비코드" ID="find_code" GPCD="EQMCD" Field="EQMCD" InputWidth="80" NameWidth="120"/>
        <Its:find runat="server" Label="작업자" ID="find_EMP" GPCD="EMPCD" Field="EMPCD" InputWidth="90" NameWidth="80" />
        <Its:button runat="server" Label="공무작업일지 인쇄" ID="sdiv1_btn_PRINT" MarginLeft="10" BackColor="CustomButton2" />
    </Its:div>
</asp:Content>

<%-- BODY --%>
<asp:Content ContentPlaceHolderID="CPH_BODY" runat="Server">
    <%-- 3단: 수리 기록 목록 | 공무작업일지 편집 | 수리 사진 --%>
    <Its:div runat="server" Type="SplitLeft" ID="bdiv1" LeftWidthPc="36">
        <Its:grid runat="server" ID="grid1"/>
    </Its:div>
    <Its:split runat="server" Type="Vertical" />
    <Its:div runat="server" Type="SplitRight" ID="bdiv2">
        <%-- 공무작업일지 수정 = 왼쪽에서 선택한 작성된 공무작업일지 수정, 툴바 [저장] (새 작성은 [추가] → 등록 팝업) --%>
        <Its:div runat="server" Type="SplitLeft" ID="bdiv3" LeftWidthPc="70">
            <Its:div runat="server" Type="SplitTop">
                <div class="wl-head">
                    <span class="wl-title">공무작업일지</span>
                    <span id="spn_WL_KEY" class="wl-key"></span>
                    <span id="spn_WL_NOTE" class="wl-note">왼쪽 목록에서 공무작업일지를 선택하세요.</span>
                </div>
            </Its:div>

            <Its:split runat="server" Type="Horizon" Resizeable="false" />

            <Its:div runat="server" Type="SplitDown">
                <div class="wl-body">
                    <Its:div runat="server" Type="BasicBlock" ID="wl_div1">
                        <div class="wl-card">
                            <div class="wl-card-hd"><span class="wl-no">1</span>기본정보</div>
                            <Its:find runat="server" Label="설비코드" ID="wl_find_EQMCD" Field="EQMCD" GPCD="EQMCD" InputWidth="100" NameWidth="210" ReadOnly="true" />
                            <Its:combo runat="server" Label="작업구분" ID="wl_cmb_WORKTP" Field="WORKTP" GPCD="@FM300" InputWidth="150" Required="true" />
                            <Its:newline runat="server" />
                            <Its:combo runat="server" Label="고장유형" ID="wl_cmb_FAILTP" Field="FAILTP" GPCD="@FM307" InputWidth="150" />
                            <Its:combo runat="server" Label="고장부위" ID="wl_cmb_FAILPART" Field="FAILPART" GPCD="@SELECT TPNM, TPCD FROM COMTYPE WHERE GPCD = 'FM303' AND USEYN = 'Y' AND TPCD LIKE 'FM303I2%N' ORDER BY TPCD" InputWidth="150" />
                            <Its:combo runat="server" Label="중단구분" ID="wl_cmb_STOPTP" Field="STOPTP" GPCD="@FM304" InputWidth="150" />
                        </div>
                    </Its:div>

                    <Its:div runat="server" Type="BasicBlock" ID="wl_div2">
                        <div class="wl-card">
                            <div class="wl-card-hd"><span class="wl-no">2</span>발생 및 조치 시간 · 작업자</div>
                            <Its:date runat="server" Label="수리시작" ID="wl_date_REPSDAY" Field="REPSDAY" Value="" ReadOnly="true" />
                            <Its:text runat="server" HiddenLabel="true" ID="wl_txt_REPSTIME" Field="REPSTIME" InputWidth="60" Type="hhmm" ReadOnly="true" />
                            <Its:date runat="server" Label="수리종료" ID="wl_date_REPEDAY" Field="REPEDAY" Value="" ReadOnly="true" />
                            <Its:text runat="server" HiddenLabel="true" ID="wl_txt_REPETIME" Field="REPETIME" InputWidth="60" Type="hhmm" ReadOnly="true" />
                            <Its:num runat="server" Label="수리시간(분)" ID="wl_num_REPMIN" Field="REPMIN" Value="0" ReadOnly="true" InputWidth="70" />
                            <Its:newline runat="server" />
                            <Its:date runat="server" Label="비가동발생" ID="wl_date_NONSDAY" Field="NONSDAY" Value="" ReadOnly="true" />
                            <Its:text runat="server" HiddenLabel="true" ID="wl_txt_NONSTIME" Field="NONSTIME" InputWidth="60" Type="hhmm" ReadOnly="true" />
                            <Its:date runat="server" Label="비가동종료" ID="wl_date_NONEDAY" Field="NONEDAY" Value="" ReadOnly="true" />
                            <Its:text runat="server" HiddenLabel="true" ID="wl_txt_NONETIME" Field="NONETIME" InputWidth="60" Type="hhmm" ReadOnly="true" />
                            <Its:num runat="server" Label="정지시간(분)" ID="wl_num_STOPMIN" Field="STOPMIN" Value="0" ReadOnly="true" InputWidth="70" />
                            <Its:newline runat="server" />
                            <Its:text runat="server" Label="비가동명" ID="wl_txt_NONINFO" Field="NONINFO" InputWidth="210" ReadOnly="true" />
                            <Its:text runat="server" Label="비가동키" ID="wl_txt_PRDNONKEY" Field="PRDNONKEY" Hidden="true" />

                            <div class="wl-sub">
                                <span>작업자</span>
                                <Its:button runat="server" Label="행삭제" ID="wl_btn_EMPDEL" Float="right" MarginLeft="6" BackColor="CustomButton3" />
                                <Its:button runat="server" Label="행추가" ID="wl_btn_EMPADD" Float="right" BackColor="CustomButton2" />
                            </div>
                            <div class="wl-grid wl-grid-emp"><Its:grid runat="server" ID="wl_grid_EMP" Height="110" /></div>
                        </div>
                    </Its:div>

                    <Its:div runat="server" Type="BasicBlock" ID="wl_div3">
                        <div class="wl-card">
                            <div class="wl-card-hd"><span class="wl-no">3</span>고장현상 / 작업내용</div>
                            <Its:textarea runat="server" HiddenLabel="true" ID="wl_txtarea_MALFUNCTION" Field="MALFUNCTION" InputHeight="70" />
                        </div>
                        <div class="wl-card">
                            <div class="wl-card-hd"><span class="wl-no">4</span>원인분석</div>
                            <Its:textarea runat="server" HiddenLabel="true" ID="wl_txtarea_CAUSE" Field="CAUSE" InputHeight="70" />
                        </div>
                        <div class="wl-card">
                            <div class="wl-card-hd"><span class="wl-no">5</span>조치내역</div>
                            <Its:textarea runat="server" HiddenLabel="true" ID="wl_txtarea_HANDLE" Field="HANDLE" InputHeight="70" />
                        </div>
                    </Its:div>

                    <div class="wl-card">
                        <div class="wl-card-hd"><span class="wl-no">6</span>사용 자재 / 부품
                            <Its:button runat="server" Label="행삭제" ID="wl_btn_PARTDEL" Float="right" MarginLeft="6" BackColor="CustomButton3" />
                            <Its:button runat="server" Label="스페셜 부품 추가" ID="wl_btn_PARTSP" Float="right" MarginLeft="6" BackColor="CustomButton2" />
                            <Its:button runat="server" Label="부품 선택" ID="wl_btn_PART" Float="right" BackColor="CustomButton2" />
                        </div>
                        <div class="wl-grid"><Its:grid runat="server" ID="wl_grid_PART" Height="130" /></div>
                    </div>

                    <Its:div runat="server" Type="BasicBlock" ID="wl_div4">
                        <div class="wl-card">
                            <div class="wl-card-hd"><span class="wl-no">7</span>특이사항 및 재발방지대책</div>
                            <Its:textarea runat="server" HiddenLabel="true" ID="wl_txtarea_PREVENT" Field="PREVENT" InputHeight="70" />
                        </div>
                    </Its:div>
                </div>
            </Its:div>
        </Its:div>

        <Its:split runat="server" Type="Vertical" />

        <%-- 수리 사진 (편집 중인 수리 기록의 사진) --%>
        <Its:div runat="server" Type="SplitRight" ID="bdiv4">
            <Its:div runat="server" Type="SplitTop">
                <Its:label runat="server" Text="■ 수리 사진 (0)" Bold="true" MarginLeft="10" ID="lbl_REPIMG" />
                <Its:button runat="server" Label="사진 등록" ID="btn_REPIMG_ADD" Float="right" MarginRight="10" BackColor="CustomButton2" />
                <Its:fileManager runat="server" StyleType="simple" FileType="image" ID="file_REPIMG" />
            </Its:div>

            <Its:split runat="server" Type="Horizon" Resizeable="false" />

            <Its:div runat="server" Type="SplitDown">
                <div class="repimg-box">
                    <div class="repimg-view empty">
                        <span id="spn_REPIMG_PAGE" class="repimg-page"></span>
                        <span id="spn_REPIMG_EMPTY" class="repimg-empty"></span>
                        <Its:img runat="server" ID="img_REPIMG" Width="300" Height="200" />
                    </div>
                    <div id="div_REPIMG_LIST" class="repimg-list"></div>
                </div>
            </Its:div>
        </Its:div>
    </Its:div>
</asp:Content>

<%-- POP --%>
<asp:Content ContentPlaceHolderID="CPH_POP" runat="server">
    <%-- 공무작업일지 등록 ([추가] → 수리 기록 선택 → 작성, 설비·수리시작/종료·비가동은 수리 기록 값 표시만) --%>
    <Its:pop runat="server" Type="add" ID="pop1" Title="공무작업일지 등록" Width="1200" Height="780">
        <div class="wl-body wl-pop">
            <Its:div runat="server" Type="BasicBlock" ID="pop1_div1">
                <div class="wl-card">
                    <div class="wl-card-hd"><span class="wl-no">1</span>기본정보</div>
                    <Its:find runat="server" Label="설비코드" ID="pop1_find_EQMCD" Field="EQMCD" GPCD="EQMCD" InputWidth="100" NameWidth="210" ReadOnly="true" />
                    <Its:combo runat="server" Label="작업구분" ID="pop1_cmb_WORKTP" Field="WORKTP" GPCD="@FM300" InputWidth="150" Required="true" />
                    <Its:newline runat="server" />
                    <Its:combo runat="server" Label="고장유형" ID="pop1_cmb_FAILTP" Field="FAILTP" GPCD="@FM307" InputWidth="150" />
                    <Its:combo runat="server" Label="고장부위" ID="pop1_cmb_FAILPART" Field="FAILPART" GPCD="@SELECT TPNM, TPCD FROM COMTYPE WHERE GPCD = 'FM303' AND USEYN = 'Y' AND TPCD LIKE 'FM303I2%N' ORDER BY TPCD" InputWidth="150" />
                    <Its:combo runat="server" Label="중단구분" ID="pop1_cmb_STOPTP" Field="STOPTP" GPCD="@FM304" InputWidth="150" />
                </div>
            </Its:div>

            <Its:div runat="server" Type="BasicBlock" ID="pop1_div2">
                <div class="wl-card">
                    <div class="wl-card-hd"><span class="wl-no">2</span>발생 및 조치 시간 · 작업자</div>
                    <Its:date runat="server" Label="수리시작" ID="pop1_date_REPSDAY" Field="REPSDAY" Value="" ReadOnly="true" />
                    <Its:text runat="server" HiddenLabel="true" ID="pop1_txt_REPSTIME" Field="REPSTIME" InputWidth="60" Type="hhmm" ReadOnly="true" />
                    <Its:date runat="server" Label="수리종료" ID="pop1_date_REPEDAY" Field="REPEDAY" Value="" ReadOnly="true" />
                    <Its:text runat="server" HiddenLabel="true" ID="pop1_txt_REPETIME" Field="REPETIME" InputWidth="60" Type="hhmm" ReadOnly="true" />
                    <Its:num runat="server" Label="수리시간(분)" ID="pop1_num_REPMIN" Field="REPMIN" Value="0" ReadOnly="true" InputWidth="70" />
                    <Its:newline runat="server" />
                    <Its:date runat="server" Label="비가동발생" ID="pop1_date_NONSDAY" Field="NONSDAY" Value="" ReadOnly="true" />
                    <Its:text runat="server" HiddenLabel="true" ID="pop1_txt_NONSTIME" Field="NONSTIME" InputWidth="60" Type="hhmm" ReadOnly="true" />
                    <Its:date runat="server" Label="비가동종료" ID="pop1_date_NONEDAY" Field="NONEDAY" Value="" ReadOnly="true" />
                    <Its:text runat="server" HiddenLabel="true" ID="pop1_txt_NONETIME" Field="NONETIME" InputWidth="60" Type="hhmm" ReadOnly="true" />
                    <Its:num runat="server" Label="정지시간(분)" ID="pop1_num_STOPMIN" Field="STOPMIN" Value="0" ReadOnly="true" InputWidth="70" />
                    <Its:newline runat="server" />
                    <Its:text runat="server" Label="비가동명" ID="pop1_txt_NONINFO" Field="NONINFO" InputWidth="210" ReadOnly="true" />
                    <Its:text runat="server" Label="비가동키" ID="pop1_txt_PRDNONKEY" Field="PRDNONKEY" Hidden="true" />

                    <div class="wl-sub">
                        <span>작업자</span>
                        <Its:button runat="server" Label="행삭제" ID="pop1_btn_EMPDEL" Float="right" MarginLeft="6" BackColor="CustomButton3" />
                        <Its:button runat="server" Label="행추가" ID="pop1_btn_EMPADD" Float="right" BackColor="CustomButton2" />
                    </div>
                    <div class="wl-grid wl-grid-emp"><Its:grid runat="server" ID="pop1_grid_EMP" Height="110" /></div>
                </div>
            </Its:div>

            <Its:div runat="server" Type="BasicBlock" ID="pop1_div3">
                <div class="wl-card">
                    <div class="wl-card-hd"><span class="wl-no">3</span>고장현상 / 작업내용</div>
                    <Its:textarea runat="server" HiddenLabel="true" ID="pop1_txtarea_MALFUNCTION" Field="MALFUNCTION" InputHeight="70" />
                </div>
                <div class="wl-card">
                    <div class="wl-card-hd"><span class="wl-no">4</span>원인분석</div>
                    <Its:textarea runat="server" HiddenLabel="true" ID="pop1_txtarea_CAUSE" Field="CAUSE" InputHeight="70" />
                </div>
                <div class="wl-card">
                    <div class="wl-card-hd"><span class="wl-no">5</span>조치내역</div>
                    <Its:textarea runat="server" HiddenLabel="true" ID="pop1_txtarea_HANDLE" Field="HANDLE" InputHeight="70" />
                </div>
            </Its:div>

            <div class="wl-card">
                <div class="wl-card-hd"><span class="wl-no">6</span>사용 자재 / 부품
                    <Its:button runat="server" Label="행삭제" ID="pop1_btn_PARTDEL" Float="right" MarginLeft="6" BackColor="CustomButton3" />
                    <Its:button runat="server" Label="스페셜 부품 추가" ID="pop1_btn_PARTSP" Float="right" MarginLeft="6" BackColor="CustomButton2" />
                    <Its:button runat="server" Label="부품 선택" ID="pop1_btn_PART" Float="right" BackColor="CustomButton2" />
                </div>
                <div class="wl-grid"><Its:grid runat="server" ID="pop1_grid_PART" Height="130" /></div>
            </div>

            <Its:div runat="server" Type="BasicBlock" ID="pop1_div4">
                <div class="wl-card">
                    <div class="wl-card-hd"><span class="wl-no">7</span>특이사항 및 재발방지대책</div>
                    <Its:textarea runat="server" HiddenLabel="true" ID="pop1_txtarea_PREVENT" Field="PREVENT" InputHeight="70" />
                </div>
            </Its:div>
        </div>
    </Its:pop>

    <%-- 공무작업일지 등록할 수리 기록 선택 (수리가 끝났고 작업일지 미작성, 수리종료일이 조회기간 안) --%>
    <Its:pop runat="server" Type="add" ID="pop_REPSEL" Title="공무작업일지 등록 - 수리 기록 선택" AddBtnName="선택" Width="1100" Height="480">
        <Its:div runat="server" Type="SplitSingle">
            <Its:grid runat="server" ID="grid_REPSEL" Height="380" />
        </Its:div>
    </Its:pop>

    <%-- 공무작업일지 부품 선택 (법인 60·설비부품(DM100700)·사용 품목 중 2공장(07) 설비부품 재고에 등록된 품목, 재고 0 포함) --%>
    <Its:pop runat="server" Type="add" ID="pop_PART" Title="부품 선택" AddBtnName="선택 추가" Width="1100" Height="600">
        <Its:div runat="server" Type="BasicBlock" ID="pp_div1">
            <Its:text runat="server" Label="검색어" ID="pp_txt_KEYWORD" Field="PARTKEYWORD" InputWidth="280" Tooltip="품목코드·품목명·규격에 들어간 글자 (띄어 쓰면 모두 포함)" />
        </Its:div>
        <div id="div_PART_GRID"><Its:grid runat="server" ID="grid_PART" Height="430" /></div>
    </Its:pop>

    <Its:pop runat="server" ID="pop_REPIMG" Title="수리 사진 크게 보기" Width="650">
        <Its:div runat="server" Type="BorderBlock">
            <Its:img runat="server" ID="big_img_REPIMG" Height="600" Width="600" />
        </Its:div>
    </Its:pop>
</asp:Content>