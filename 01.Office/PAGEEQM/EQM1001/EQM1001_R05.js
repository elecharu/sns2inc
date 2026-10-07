/// <reference path="../../Script/reference.js" />

/* 페이지 로드 시 수행 */
ItsPage.Load = function () {

    // 2026-09-22 설비그룹별 점검계획 그리드
    ItsGrid.Create('grid_GRP_PLAN', { isCheckBoxGrid: false, isSubTotalGrid: false }, [
        column.create('설비그룹코드', 'PLANCD', { width: 130, align: 'center', readOnly: true }),
        column.create('설비그룹', 'PLANNM', { width: 220, readOnly: true }),
        column.create('점검항목수', 'PLANITEMCNT', { width: 90, align: 'right', columnType: enumColumnTypes.number, decimalPrecision: 0, readOnly: true }),
        // 2026-09-30 [설비그룹별 점검계획 탭] 이번에 승인·반려할 REV와 개정내용 (진행 중 REV가 없으면 현재 승인 REV)
        column.create('REV', 'REVNM', { width: 100, align: 'center', readOnly: true }),
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
        column.create('REV', 'REVNM', { width: 100, align: 'center', readOnly: true }),
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

// 2026-10-06 점검계획 조회: 승인·반려·출력은 R03 개정 이력에서 처리
function GetPlanTab() {
    return ItsTab.GetIndex('tab_PLAN') == 0
        ? { type: 'G', panelId: 'div_GRP_PLAN', gridId: 'grid_GRP_PLAN' }
        : { type: 'E', panelId: 'div_EQM_PLAN', gridId: 'grid_EQM_PLAN' };
}
