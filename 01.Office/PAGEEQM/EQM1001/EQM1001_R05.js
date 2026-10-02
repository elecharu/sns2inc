/// <reference path="../../Script/reference.js" />

/* 페이지 로드 시 수행 */
ItsPage.Load = function () {

    // 2026-09-22 설비그룹별 점검계획 그리드
    ItsGrid.Create('grid_GRP_PLAN', { isCheckBoxGrid: false, isSubTotalGrid: false }, [
        column.create('설비그룹코드', 'PLANCD', { width: 130, align: 'center', readOnly: true }),
        column.create('설비그룹', 'PLANNM', { width: 220, readOnly: true }),
        column.create('점검항목수', 'PLANITEMCNT', { width: 90, align: 'right', columnType: enumColumnTypes.number, decimalPrecision: 0, readOnly: true }),
        // 2026-09-30 [설비그룹별 점검계획 탭] 이번에 승인·반려할 REV와 개정내용 (진행 중 REV가 없으면 현재 승인 REV)
        column.create('REV', 'REVNM', { width: 70, align: 'center', readOnly: true }),
        column.create('개정내용', 'REMARK', { width: 260, readOnly: true }),
        column.create('승인상태', 'APRVSTTNM', { width: 80, align: 'center', readOnly: true }),
        column.create('승인자', 'APRVEMP', { width: 120, align: 'center', readOnly: true }),
        column.create('요청일시', 'REQTIME', { width: 140, align: 'center', readOnly: true }),
        column.create('처리일시', 'APRVTIME', { width: 140, align: 'center', readOnly: true }),
        column.create('반려사유', 'REJREASON', { width: 260, readOnly: true }),
        column.create('승인상태코드', 'APRVSTT', { hidden: true }),
        column.split()
    ]);

    // 2026-09-22 설비별 점검계획 그리드
    ItsGrid.Create('grid_EQM_PLAN', { isCheckBoxGrid: false, isSubTotalGrid: false }, [
        column.create('설비코드', 'PLANCD', { width: 130, align: 'center', readOnly: true }),
        column.create('설비명', 'PLANNM', { width: 220, readOnly: true }),
        column.create('점검항목수', 'PLANITEMCNT', { width: 90, align: 'right', columnType: enumColumnTypes.number, decimalPrecision: 0, readOnly: true }),
        // 2026-09-30 [설비별 점검계획 탭] 이번에 승인·반려할 REV와 개정내용 (진행 중 REV가 없으면 현재 승인 REV)
        column.create('REV', 'REVNM', { width: 70, align: 'center', readOnly: true }),
        column.create('개정내용', 'REMARK', { width: 260, readOnly: true }),
        column.create('승인상태', 'APRVSTTNM', { width: 80, align: 'center', readOnly: true }),
        column.create('승인자', 'APRVEMP', { width: 120, align: 'center', readOnly: true }),
        column.create('요청일시', 'REQTIME', { width: 140, align: 'center', readOnly: true }),
        column.create('처리일시', 'APRVTIME', { width: 140, align: 'center', readOnly: true }),
        column.create('반려사유', 'REJREASON', { width: 260, readOnly: true }),
        column.create('승인상태코드', 'APRVSTT', { hidden: true }),
        column.split()
    ]);

    // 2026-10-02 [두 탭 조회 필터] 승인상태 콤보 목록 (W: 대기 = 승인·반려가 아닌 계획)
    ItsCombo.SetListByArr('cmb_GRP_APRVSTT', ['전체', '대기', '승인', '반려'], ['', 'W', 'A', 'R']);
    ItsCombo.SetListByArr('cmb_EQM_APRVSTT', ['전체', '대기', '승인', '반려'], ['', 'W', 'A', 'R']);

};

// 현재 탭 계획 목록 조회
ItsButton.EventSearch = function () {
    var tab = GetPlanTab();
    var maria = new ItsMaria('EQM1001_R05', 'LIST_PLAN');
    maria.AddPanel(tab.panelId);
    maria.AddParam('PLANTP', tab.type);
    maria.CallProc();
    if (maria.isError) {
        maria.ShowErrMsg();
        return;
    }

    ItsGrid.SetStore(tab.gridId, maria.store);
    ItsMsg.Toast(ItsMsg.CommonMsg.SearchComplete(maria.store.Length()));
};

// 2026-09-22 설비그룹별 점검계획 탭 하단 그리드 행 선택 시 상단 패널 반려사유 텍스트박스 표시
ItsGrid.Event('grid_GRP_PLAN').onSelect = function () {
    ShowPlanReason('grid_GRP_PLAN', 'txt_GRP_REJREASON');
};

// 2026-09-22 설비별 점검계획 탭 하단 그리드 행 선택 시 상단 패널 반려사유 텍스트박스 표시
ItsGrid.Event('grid_EQM_PLAN').onSelect = function () {
    ShowPlanReason('grid_EQM_PLAN', 'txt_EQM_REJREASON');
};

// 설비그룹별 점검계획: 승인
ItsButton.Event('btn_GRP_APPROVE').onClick = function () {
    SavePlanStatus('A');
};

// 설비그룹별 점검계획: 반려
ItsButton.Event('btn_GRP_REJECT').onClick = function () {
    SavePlanStatus('R');
};

// 설비그룹별 점검계획: 승인된 계획서 출력
ItsButton.Event('btn_GRP_PLAN_RPT').onClick = function () {
    var rowIndex = ItsGrid.GetCurrentIndex('grid_GRP_PLAN');
    var planCode = ItsGrid.GetValue('grid_GRP_PLAN', rowIndex, 'PLANCD');
    var approvalStatus = ItsGrid.GetValue('grid_GRP_PLAN', rowIndex, 'APRVSTT');

    if (!planCode) {
        ItsMsg.Toast('출력할 설비그룹 점검계획을 선택해주세요.');
        return;
    }

    if (approvalStatus != 'A') {
        ItsMsg.Toast('승인된 설비그룹 점검계획만 출력할 수 있습니다.');
        return;
    }

    var rpt = new ItsXtraRpt('EQM1001_S05A');
    rpt.FileName('제조설비_정기점검계획서');
    rpt.AddParam('EQMGRP', planCode);
    rpt.CallPop();
    if (rpt.isError) {
        ItsMsg.Alert(rpt.errMessage);
    }
};

// 2026-10-02 [설비별 점검계획 탭] 승인된 설비 점검계획서 출력 (최신 승인 REV 기준)
ItsButton.Event('btn_EQM_PLAN_RPT').onClick = function () {
    var rowIndex = ItsGrid.GetCurrentIndex('grid_EQM_PLAN');
    var planCode = ItsGrid.GetValue('grid_EQM_PLAN', rowIndex, 'PLANCD');
    var aprvStt = ItsGrid.GetValue('grid_EQM_PLAN', rowIndex, 'APRVSTT');

    if (!planCode) {
        ItsMsg.Toast('출력할 설비 점검계획을 선택해주세요.');
        return;
    }

    if (aprvStt != 'A') {
        ItsMsg.Toast('승인된 설비 점검계획만 출력할 수 있습니다.');
        return;
    }

    var rpt = new ItsXtraRpt('EQM1001_S05A');
    rpt.FileName('제조설비_정기점검계획서_' + planCode);
    rpt.AddParam('PLANTP', 'E');
    rpt.AddParam('FANO', planCode);
    rpt.CallPop();
    if (rpt.isError) {
        ItsMsg.Alert(rpt.errMessage);
    }
};

// 설비별 점검계획: 승인
ItsButton.Event('btn_EQM_APPROVE').onClick = function () {
    SavePlanStatus('A');
};

// 설비별 점검계획: 반려
ItsButton.Event('btn_EQM_REJECT').onClick = function () {
    SavePlanStatus('R');
};

// 현재 승인관리 탭 정보
function GetPlanTab() {
    return ItsTab.GetIndex('tab_PLAN') == 0
        ? { type: 'G', panelId: 'div_GRP_PLAN', gridId: 'grid_GRP_PLAN', reasonId: 'txt_GRP_REJREASON' }
        : { type: 'E', panelId: 'div_EQM_PLAN', gridId: 'grid_EQM_PLAN', reasonId: 'txt_EQM_REJREASON' };
}

// 2026-09-29 선택 계획이 반려 상태인 경우에만 상단 패널 반려사유 표시
function ShowPlanReason(gridId, reasonId) {
    var rowIndex = ItsGrid.GetCurrentIndex(gridId);
    var approvalStatus = ItsGrid.GetValue(gridId, rowIndex, 'APRVSTT');
    var rejectionReason = ItsGrid.GetValue(gridId, rowIndex, 'REJREASON');
    ItsText.SetValue(reasonId, approvalStatus == 'R' ? (rejectionReason || '') : '');
}


// 2026-09-29 선택 계획 승인/반려 상태 저장 및 확인 팝업창 분기 처리
// 2026-09-30 승인 전 개정내용 확인, 확인 팝업창·완료 토스트에 REV 번호 표시
function SavePlanStatus(approvalStatus) {
    var tab = GetPlanTab();
    var rowIndex = ItsGrid.GetCurrentIndex(tab.gridId);
    var planCode = ItsGrid.GetValue(tab.gridId, rowIndex, 'PLANCD');
    var revNm = ItsGrid.GetValue(tab.gridId, rowIndex, 'REVNM') || '';
    var remark = ItsGrid.GetValue(tab.gridId, rowIndex, 'REMARK') || '';
    var rejectionReason = approvalStatus == 'R' ? ItsText.GetValue(tab.reasonId) : '';
    var isApprove = approvalStatus == 'A';
    var actionName = isApprove ? '승인' : '반려';

    if (!planCode) {
        ItsMsg.Toast(actionName + '할 점검계획을 선택해주세요.');
        return;
    }

    if (!isApprove && !rejectionReason) {
        ItsMsg.Toast('반려 사유를 입력해주세요.');
        return;
    }

    if (isApprove && !remark) {
        ItsMsg.Toast('개정내용이 없는 REV는 승인할 수 없습니다.');
        return;
    }

    ItsMsg.Confirm('선택한 점검계획' + (revNm ? '(' + revNm + ')' : '') + '을 ' + actionName + '하시겠습니까?', function () {
        var maria = new ItsMaria('EQM1001_R05', 'SAVE_PLAN_STATUS');
        maria.AddParam('PLANTP', tab.type);
        maria.AddParam('PLANCD', planCode);
        maria.AddParam('APRVSTT', approvalStatus);
        maria.AddParam('REJREASON', rejectionReason);
        maria.CallProc();
        if (maria.isError) {
            maria.ShowErrMsg();
            return;
        }

        ItsMsg.Toast((revNm ? revNm + ' ' : '') + actionName + ' 처리가 완료되었습니다.');
        ItsText.SetValue(tab.reasonId, '');
        ItsGrid.Setkey(tab.gridId, 'PLANCD', planCode);
        ItsButton.EventSearch();
    }, function () {
        ItsMsg.Toast((isApprove ? '승인이' : '반려가') + ' 취소되었습니다.');
    });
}
