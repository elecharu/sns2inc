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
        .repimg-list { display: flex; gap: 12px; flex: 0 0 auto; height: 66px; padding: 4px 4px 0 2px; overflow-x: auto; overflow-y: hidden; box-sizing: border-box; }
        .repimg-thumb { position: relative; flex: 0 0 auto; width: 46px; height: 46px; margin-top: 6px; border: 1px solid #bbb; border-radius: 3px; background: #fff; cursor: pointer; box-sizing: border-box; }
        .repimg-thumb img { width: 100%; height: 100%; object-fit: cover; border-radius: 2px; }
        .repimg-thumb.on { border: 2px solid #378add; }
        .repimg-del { position: absolute; top: -7px; right: -7px; width: 16px; height: 16px; line-height: 14px; border: 1px solid #bbb; border-radius: 50%; background: #fff; color: #d32f2f; font-size: 11px; text-align: center; cursor: pointer; }
        .repimg-empty { display: none; position: absolute; top: 50%; left: 0; right: 0; transform: translateY(-50%); color: #999; font-size: 13px; text-align: center; }
        .repimg-view.empty > div { display: none !important; }
        .repimg-view.empty .repimg-empty { display: block; }
        #file_REPIMG { display: none !important; }
    </style>
</asp:Content>

<%-- SEARCH PANEL --%>
<asp:Content ContentPlaceHolderID="CPH_SEARCH" runat="Server">
    <Its:div runat="server" ID="sdiv1" Type="SearchPanel">
        <Its:dateRange runat="server" Label="등록일자" ID="date_SEARCH" FieldFrom="SDATE" FieldTo="EDATE" />
        <Its:combo runat="server" Label="공장" ID="cmb_FACTORYCD" Field="FACTORYCD" GPCD="*FACTORYCD" InputWidth="100" Value="07" />
        <Its:combo runat="server" Label="작업장" ID="cmb_LINECD" Field="LINECD" GPCD="*LINECD" REF01="07" />
        <Its:combo runat="server" Label="설비구분" ID="cmb_EQMTP" Field="EQMTP" GPCD="*FM100" InputWidth="70" REF10="07" />
        <Its:combo runat="server" Label="설비대분류" ID="cmb_EQMGROUP1" Field="EQMGROUP1" GPCD="*FM113" InputWidth="70" REF10="07" />
        <Its:find runat="server" Label="설비코드" ID="find_code" GPCD="EQMCD" Field="EQMCD" InputWidth="90" NameWidth="100"/>
        <Its:find runat="server" Label="작업자" ID="find_EMP" GPCD="EMPCD" Field="EMPCD" InputWidth="90" NameWidth="80" />
    </Its:div>
</asp:Content>

<%-- BODY --%>
<asp:Content ContentPlaceHolderID="CPH_BODY" runat="Server">
     <Its:div runat="server" Type="SplitLeft" ID="bdiv1" LeftWidthPc ="70">
        <Its:grid runat="server" ID="grid1"/>
    </Its:div>
    <Its:split runat="server" Type="Vertical" />
    <Its:div runat="server" Type="SplitRight" ID="bdiv2"  >
        <Its:div runat="server" Type="SplitTop" TopHeightPc="35">
            <Its:div runat="server" Type="SplitTop">
                <Its:button runat="server" Label="행추가" ID="bdiv2_btn_ADD" MarginLeft="50" BackColor="CustomButton2" />
                <Its:button runat="server" Label="행삭제" ID="bdiv2_btn_DEL" MarginLeft="10" BackColor="CustomButton3" />
                <Its:text runat="server" Label="설비수리키" ID="bdiv2_txt_EQMREPKEY" Field="EQMREPKEY" Hidden="true" />
            </Its:div>

            <Its:split runat="server" Type="Horizon" Resizeable="false" />

            <Its:div runat="server" Type="SplitDown">
                <Its:grid runat="server" ID="grid2"/>
            </Its:div>
        </Its:div>

        <Its:split runat="server" Type="Horizon" />

        <Its:div runat="server" Type="SplitDown">
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
    <Its:pop runat="server" Type="add" ID="pop1" Title="설비이력 추가" Width="850" Height="470">
        <Its:div runat="server" Type="SplitTop" ID="pdiv1" LeftWidthPc ="80">
            <Its:find runat="server" Label="설비코드" ID="pop1_find_EQMCD" Field="EQMCD" GPCD="EQMCD" InputWidth="100"  NameWidth="198" />

            <Its:newline runat="server" />
            <Its:date runat="server" Label="등록일자" ID="pop1_date_REGDAY" Field="REGDAY" />
            <Its:date runat="server" Label="발생일자" ID="pop1_date_REPSDAY" Field="REPSDAY" />
            <Its:date runat="server" Label="완료일자" ID="pop1_date_REPEDAY" Field="REPEDAY" ReadOnly="true" Value="" />
            <Its:check runat="server" Label="완료일자 사용여부" Field="REPEYN" ID="pop1_check_REPEYN"  MarginLeft="82" Value="N" />
           
            <Its:newline runat="server" />
            <Its:text runat="server" Label="등록일시" ID="pop1_txt_REGDAYTIME"  Field="REGTIME" InputWidth="111" Type="hhmm"  />
            <Its:text runat="server" Label="발생일시" ID="pop1_txt_REPSTIME"  Field="REPSTIME" InputWidth="110" Type="hhmm"  />
            <Its:text runat="server" Label="완료일시" ID="pop1_txt_REPETIME"  Field="REPETIME" InputWidth="111" Type="hhmm" ReadOnly="true" />     
            <Its:num runat="server" Label="소요일" ID="pop1_num_REPUTIME" Field="REPUTIME" Value="0" ReadOnly="true" />
            <Its:newline runat="server" />
            
            <Its:text runat="server" Label="수리업체" ID="pop1_txt_REPCUST" Field="REPCUST" InputWidth="315" />
            <Its:num runat="server" Label="수리금액(만원)" ID="pop1_num_REPAMT" Field="REPAMT" Value="0" />
            <Its:combo runat="server" Label="수리유형" ID="pop1_com_ISSUE" Field="ISSUE" GPCD="ISSUE" />
            <Its:newline runat="server" />
            <Its:textarea runat="server" Label="고장원인" ID="pop1_txtarea_MALFUNCTION" Field="MALFUNCTION" InputWidth="723" />
            <Its:newline runat="server" />
            <Its:textarea runat="server" Label="처리내용" ID="pop1_txtarea_HANDLE" Field="HANDLE" InputWidth="723" />
            <Its:newline runat="server" />
            <Its:textarea runat="server" Label="비고" ID="pop1_txtarea_REMARK" Field="REMARK" InputWidth="723" />
        </Its:div>

        <Its:split runat="server" Type="Horizon" />

        <Its:div runat="server" Type="SplitDown" ID="pdiv2"  >            
            <Its:button runat="server" Label="행추가" ID="pdiv2_btn_ADD" MarginLeft="700" BackColor="CustomButton2"   />
            <Its:button runat="server" Label="행삭제" ID="pdiv2_btn_DEL" MarginLeft="10" BackColor="CustomButton3" />
            <Its:newline runat="server" />
            <Its:grid runat="server" ID="grid3"/>
        </Its:div>

    </Its:pop>

    <Its:pop runat="server" ID="pop_REPIMG" Title="수리 사진 크게 보기" Width="650">
        <Its:div runat="server" Type="BorderBlock">
            <Its:img runat="server" ID="big_img_REPIMG" Height="600" Width="600" />
        </Its:div>
    </Its:pop>
</asp:Content>