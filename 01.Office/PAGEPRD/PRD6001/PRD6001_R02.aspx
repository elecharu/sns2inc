<%-- PRD6001_R02: 설비 일상점검 계획등록 --%>

<%-- PAGE --%>
<%@ Page Title="" Language="C#" MasterPageFile="~/Common/Master/MasterBase.master" AutoEventWireup="true" CodeFile="PRD6001_R02.aspx.cs" Inherits="PRD6001_R02" %>

<%-- HEAD --%>
<asp:Content ContentPlaceHolderID="CPH_HEAD" runat="Server">
    <script type="text/javascript" src="PRD6001_R02.js?ver=<%= BasePage.srcVersion %>"></script>
    <%-- 2026-11-26 점검항목 위치사진 팝업 (EQM1001_R06 사진 목록과 같은 모양) --%>
    <style>
        #pop_IMG_LIST { display: flex; flex-wrap: wrap; gap: 6px; margin: 6px 10px 0 10px; }
        #pop_IMG_LIST .item { position: relative; }
        #pop_IMG_LIST img { width: 200px; height: 150px; object-fit: cover; border: 1px solid #ccc; cursor: pointer; }
        #pop_IMG_LIST .del { position: absolute; top: 2px; right: 2px; width: 20px; height: 20px; line-height: 20px; text-align: center; background: rgba(0,0,0,0.6); color: #fff; cursor: pointer; }
        #pop_IMG_LIST .empty { color: #999; }
    </style>
</asp:Content>


<%-- SEARCH --%>
<%-- 2026-11-26 설비그룹 탭 삭제로 탭이 없어져 조회조건을 검색 영역으로 옮김 (탭 안 구조 그대로면 그리드 높이가 안 잡혀 스크롤이 안 생김) --%>
<asp:Content ContentPlaceHolderID="CPH_SEARCH" runat="Server">
    <Its:div runat="server" Type="SearchPanel" ID="div_EQM">
        <Its:combo runat="server" Label="작업장" Field="LINECD" ID="cmb_LINECD" REF01="07" GPCD="*LINECD" />
        <Its:combo runat="server" Label="공정" Field="EQMTP" ID="cmb_EQMTP" GPCD="*EQMTP" />
        <Its:combo runat="server" Label="라인" Field="EQMGROUP1" ID="cmb_EQMGROUP1" GPCD="*EQMGROUP1" />
        <Its:find runat="server" Label="설비" Field="FANO" GPCD="EQMCD" ID="find_EQMCD" InputWidth="80" NameWidth="120"/>
    </Its:div>
</asp:Content>

<%-- BODY --%>
<asp:Content ContentPlaceHolderID="CPH_BODY" runat="Server">
                <Its:div runat="server" Type="SplitLeft" LeftWidthPc="40">
                    <Its:grid runat="server" ID="grid1" />   
                </Its:div>
                
                <Its:split runat="server" Type="Vertical" />            

                <Its:div runat="server" Type="SplitRight">              
                    <Its:div runat="server" Type="SplitTop" TopHeightPc="40">
                        <Its:div runat="server" Type="SplitTop">
                            <Its:label runat="server" Text="■ 개정 이력 (REV)" Bold="true" MarginLeft="10"/>
                            <Its:button runat="server" Label="개정내용 저장" ID="btn_EQM_REV_SAVE" MarginLeft="40" BackColor="CustomButton2" />
                            <Its:button runat="server" Label="승인" ID="btn_EQM_APPROVE" MarginLeft="10" BackColor="CustomButton" />
                            <%-- 2026-11-26 명칭 '계획서 출력' → '점검표 출력' (리포트 PRD6001_R02 설비 일상점검표, 고른 REV) --%>
                            <Its:button runat="server" Label="점검표 출력" ID="btn_EQM_PLAN_RPT" MarginRight="10" Float="right" BackColor="CustomButton2" />
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
                            <%-- 2026-11-26 고른 점검항목의 위치사진 (사진 열 더블클릭해도 열림) --%>
                            <Its:button runat="server" Label="위치사진" ID="bdiv3_btn_IMG" MarginLeft="10" BackColor="CustomButton2" />
                        </Its:div>

                        <Its:split runat="server" Type="Horizon" Resizeable="false" />

                        <Its:div runat="server" Type="SplitDown">
                            <Its:grid runat="server" ID="grid3" />
                        </Its:div>
                    </Its:div>
                </Its:div>

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

    <%-- 2026-11-26 복사 원본 조회조건(작업장·공정·라인·설비) + [조회] 버튼, 열이 다 보이게 팝업 크기 1200x500 → 1500x620 --%>
    <Its:pop runat="server" ID="pop_EQM02_COPY" Title="일상점검항목 복사" Width="1500" Height="620">
        <Its:div runat="server" Type="SplitTop" ID="pdiv_COPY">
            <Its:combo runat="server" Label="작업장" Field="LINECD" ID="pop_COPY_cmb_LINECD" REF01="07" GPCD="*LINECD" MarginLeft="10" MarginTop="6" MarginBottom="10" LabelWidth="50" InputWidth="100" />
            <Its:combo runat="server" Label="공정" Field="EQMTP" ID="pop_COPY_cmb_EQMTP" GPCD="*EQMTP" MarginLeft="15" MarginTop="6" LabelWidth="40" InputWidth="80" />
            <Its:combo runat="server" Label="라인" Field="EQMGROUP1" ID="pop_COPY_cmb_EQMGROUP1" GPCD="*EQMGROUP1" MarginLeft="15" MarginTop="6" LabelWidth="40" InputWidth="80" />
            <Its:text runat="server" Label="설비" Field="FANO" ID="pop_COPY_txt_FANO" MarginLeft="15" MarginTop="6" LabelWidth="38" InputWidth="150" />
            <Its:button runat="server" Label="조회" ID="pop_COPY_btn_SEARCH" Width="80" MarginLeft="15" MarginTop="6" BackColor="CustomButton2" />
        </Its:div>

        <Its:split runat="server" Type="Horizon" Resizeable="false" />

        <Its:div runat="server" Type="SplitDown">
            <Its:div runat="server" Type="SplitTop" TopHeightPc="90">
                <Its:div runat="server" Type="SplitLeft" LeftWidthPc="37">
                    <Its:grid runat="server" ID="grid7" />
                </Its:div>

                <Its:split runat="server" Type="Vertical" Resizeable="false" />

                <Its:div runat="server" Type="SplitRight">
                    <Its:grid runat="server" ID="grid8" />
                </Its:div>
            </Its:div>

            <Its:split runat="server" Type="Horizon" Resizeable="false" />

            <Its:div runat="server" Type="SplitDown" BackColor="GrayLight2">
                <Its:button runat="server" Label="저장" ID="btn_COPY_EQM02" Width="100" MarginTop="5" MarginLeft="640" Height="30"/>
                <Its:button runat="server" Label="취소" ID="btn_CANCEL_COPY_EQM02" Width="100" MarginTop="5" MarginLeft="20" Height="30"/>
            </Its:div>
        </Its:div>
    </Its:pop>

    <%-- 2026-11-26 설비그룹 일상점검 복사 팝업 삭제 (설비그룹 탭 삭제) --%>

    <%-- 2026-11-26 점검항목 위치사진: 선택하면 바로 업로드·등록, 사진 클릭하면 크게 보기, ✕ 는 삭제 --%>
    <Its:pop runat="server" ID="pop_IMG" Title="점검항목 위치사진" Width="900" Height="560">
        <Its:div runat="server" Type="SplitSingle" ID="pdiv_IMG">
            <Its:text runat="server" Label="점검항목" ID="pop_IMG_txt_CHKKNDNM" InputWidth="400" ReadOnly="true" MarginLeft="10" MarginTop="6" />
            <Its:text runat="server" Label="REV" ID="pop_IMG_txt_REVNM" InputWidth="80" ReadOnly="true" MarginTop="6" />
            <Its:text runat="server" Label="점검코드" ID="pop_IMG_txt_CHKKNDCD" Hidden="true" />
            <Its:newline runat="server" />
            <Its:fileManager runat="server" StyleType="simple" FileType="image" ID="pop_IMG_file" MarginLeft="10" />
            <div id="pop_IMG_LIST"></div>
        </Its:div>
    </Its:pop>
</asp:Content>
