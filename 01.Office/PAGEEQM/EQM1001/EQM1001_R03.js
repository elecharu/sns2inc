/// <reference path="../../Script/reference.js" />

// 페이지 로드
ItsPage.Load = function () {
    // 2026-09-23 설비그룹 점검계획 탭: 좌측 설비그룹 목록 초기화 (설비그룹코드 1행 단위로 그룹 승인상태·반려사유 표시)
    ItsGrid.Create('grid_GRP1', { isCheckBoxGrid: false, isSubTotalGrid: false }, [
        column.create('설비그룹코드', 'EQMGUBUN', { width: 120, align: 'center' }),
        column.create('설비그룹', 'EQMGRPNM', { width: 120, align: 'center' }),
        // 2026-09-30 [설비그룹 점검계획 탭] 좌측 목록 최신 REV 컬럼
        column.create('REV', 'REVNM', { width: 100, align: 'center', readOnly: true }),
        column.create('승인상태', 'APRVSTTNM', { width: 70, align: 'center', readOnly: true }),
        column.create('반려사유', 'REJREASON', { width: 180, readOnly: true }),
        column.split()
    ]);

    // 2026-09-30 [설비그룹 점검계획 탭] 우측 상단 개정 이력(REV) 그리드 초기화
    ItsGrid.Create('grid_GRP_REV', { isCheckBoxGrid: false, isSubTotalGrid: false }, [
        column.create('REV', 'REVNM', { width: 100, align: 'center', readOnly: true }),
        column.create('상태', 'APRVSTTNM', { width: 60, align: 'center', readOnly: true }),
        column.create('개정내용', 'REMARK', { width: 260, readOnly: false }),
        column.create('작성자', 'REQEMP', { width: 80, align: 'center', readOnly: true }),
        column.create('수정일시', 'REQTIME', { width: 130, align: 'center', readOnly: true }),
        column.create('승인자', 'APRVEMP', { width: 80, align: 'center', readOnly: true }),
        column.create('처리일시', 'APRVTIME', { width: 130, align: 'center', readOnly: true }),
        column.create('반려사유', 'REJREASON', { width: 200, readOnly: true }),
        column.create('REV번호', 'REVNUM', { hidden: true }),
        column.create('상태코드', 'APRVSTT', { hidden: true }),
        column.split()
    ]);

    // 설비그룹 점검계획 탭: 정기점검 목록 초기화
    ItsGrid.Create('grid_GRP2', { isCheckBoxGrid: true, isSubTotalGrid: false }, [
        column.create('점검코드', 'CHKKNDCD', { width: 80, align: 'center' }),
        column.create('점검명', 'CHKKNDNM', { width: 300 }),
        // 2026-09-30 [화면 로드 최적화] 점검항목·점검방법·점검값구분은 프로시저에서 받은 코드명으로 표시 (콤보 목록 조회 제거)
        column.create('점검항목', 'CHKLOCNM', { width: 130, align: 'center' }),
        column.create('점검방법', 'CHKMTHNM', { width: 100, align: 'center' }),
        column.create('점검값구분', 'CHKVALTPNM', { width: 90, align: 'center' }),
        column.create('사용여부', 'USEYN', { width: 70, columnType: enumColumnTypes.check, readOnly: false }),
        column.create('정렬순서', 'SORTNO', { width: 80, columnType: enumColumnTypes.number, decimalPrecision: 0, readOnly: false }),
        column.split()
    ]);

    // 설비그룹 점검계획 탭: 복사 대상 그룹 목록 초기화
    ItsGrid.Create('grid_GRP_COPY1', { isCheckBoxGrid: false, isSubTotalGrid: false }, [
        column.create('설비그룹코드', 'EQMGRP', { width: 120, align: 'center' }),
        column.create('설비그룹', 'EQMGRPNM', { width: 120, align: 'center' }),
        column.create('정기점검 건수', 'EQM02CNT', { width: 80, align: 'right', columnType: enumColumnTypes.number, decimalPrecision: 0 }),
        column.create('대표설비코드', 'FANO', { hidden: true }),
        column.split()
    ]);

    // 설비그룹 점검계획 탭: 복사 점검항목 목록 초기화
    ItsGrid.Create('grid_GRP_COPY2', { isCheckBoxGrid: false, isSubTotalGrid: false }, [
        column.create('점검코드', 'CHKKNDCD', { width: 80, align: 'center' }),
        column.create('점검명', 'CHKKNDNM', { width: 300 }),
        // 2026-09-30 [화면 로드 최적화] 점검항목·점검방법·점검값구분은 프로시저에서 받은 코드명으로 표시 (콤보 목록 조회 제거)
        column.create('점검항목', 'CHKLOCNM', { width: 130, align: 'center' }),
        column.create('점검방법', 'CHKMTHNM', { width: 100, align: 'center' }),
        column.create('점검값구분', 'CHKVALTPNM', { width: 90, align: 'center' }),
        column.create('사용여부', 'USEYN', { width: 70, columnType: enumColumnTypes.check, readOnly: true }),
        column.create('정렬순서', 'SORTNO', { width: 80, columnType: enumColumnTypes.number, decimalPrecision: 0 }),
        column.split()
    ]);
    // 설비별 점검계획 탭: 설비 목록 초기화
    ItsGrid.Create('grid1', { isCheckBoxGrid: false, isSubTotalGrid: false }, [
        column.create('설비코드', 'FANO', { width: 80, align: 'center' }),
        column.create('설비명', 'EQMNM', { width: 200 }),
        // 2026-09-30 [설비별 점검계획 탭] 좌측 목록 현재 승인 REV 컬럼 (현장 점검 기준)
        column.create('REV', 'REVNM', { width: 100, align: 'center', readOnly: true }),
        column.create('승인상태', 'APRVSTTNM', { width: 65, align: 'center', readOnly: true }),
        column.create('반려사유', 'REJREASON', { width: 180, readOnly: true }),
        column.split()
    ]);

    // 2026-09-30 [설비별 점검계획 탭] 우측 상단 개정 이력(REV) 그리드 초기화
    ItsGrid.Create('grid_EQM_REV', { isCheckBoxGrid: false, isSubTotalGrid: false }, [
        column.create('REV', 'REVNM', { width: 100, align: 'center', readOnly: true }),
        column.create('상태', 'APRVSTTNM', { width: 60, align: 'center', readOnly: true }),
        column.create('개정내용', 'REMARK', { width: 260, readOnly: false }),
        column.create('작성자', 'REQEMP', { width: 80, align: 'center', readOnly: true }),
        column.create('수정일시', 'REQTIME', { width: 130, align: 'center', readOnly: true }),
        column.create('승인자', 'APRVEMP', { width: 80, align: 'center', readOnly: true }),
        column.create('처리일시', 'APRVTIME', { width: 130, align: 'center', readOnly: true }),
        column.create('반려사유', 'REJREASON', { width: 200, readOnly: true }),
        column.create('REV번호', 'REVNUM', { hidden: true }),
        column.create('상태코드', 'APRVSTT', { hidden: true }),
        column.split()
    ]);

    // 설비별 점검계획 탭: 정기점검 목록 초기화
    ItsGrid.Create('grid3', { isCheckBoxGrid: true, isSubTotalGrid: false }, [
        column.create('점검코드', 'CHKKNDCD', { width: 80, align: 'center' }),
        column.create('점검명', 'CHKKNDNM', { width: 300 }),
        // 2026-09-30 [화면 로드 최적화] 점검항목·점검방법·점검값구분은 프로시저에서 받은 코드명으로 표시 (콤보 목록 조회 제거)
        column.create('점검항목', 'CHKLOCNM', { width: 130, align: 'center' }),
        column.create('점검방법', 'CHKMTHNM', { width: 100, align: 'center' }),
        column.create('점검값구분', 'CHKVALTPNM', { width: 90, align: 'center' }),
        column.create('사용여부', 'USEYN', { width: 70, columnType: enumColumnTypes.check, readOnly: false }),
        column.create('정렬순서', 'SORTNO', { width: 80, columnType: enumColumnTypes.number, decimalPrecision: 0, readOnly: false }),
        column.split()
    ]);

    // 설비별 점검계획 탭: 복사 대상 설비 목록 초기화
    ItsGrid.Create('grid7', { isCheckBoxGrid: false, isSubTotalGrid: false }, [
        column.create('설비코드', 'FANO', { width: 100, readOnly: false }),
        column.create('설비명', 'EQMNM', { width: 150, readOnly: false }),
        column.split()
    ]);

    // 설비별 점검계획 탭: 복사 점검항목 목록 초기화
    ItsGrid.Create('grid8', { isCheckBoxGrid: false, isSubTotalGrid: false }, [
        column.create('점검코드', 'CHKKNDCD', { width: 70, align: 'center' }),
        column.create('점검명', 'CHKKNDNM', { width: 300 }),
        // 2026-09-30 [화면 로드 최적화] 점검항목·점검방법·점검값구분은 프로시저에서 받은 코드명으로 표시 (콤보 목록 조회 제거)
        column.create('점검항목', 'CHKLOCNM', { width: 130, align: 'center' }),
        column.create('점검방법', 'CHKMTHNM', { width: 100, align: 'center' }),
        column.create('점검값구분', 'CHKVALTPNM', { width: 90, align: 'center' }),
        column.split()
    ]);
    // 정기점검 주기관리 탭: 연간 계획 초기화
    ItsGrid.Create('grid9', { isCheckBoxGrid: true }, [
        column.create('설비코드', 'FANO', { width: 100, align: 'center' }),
        column.create('설비명', 'EQMNM', { width: 220 }),
        // 2026-09-30 [정기점검 주기관리 탭] 설비등급은 프로시저에서 받은 코드명으로 표시 (콤보 목록 조회 제거)
        column.create('설비등급', 'EQMGRADENM', { width: 90, align: 'center', readOnly: true }),
        column.create('년도', 'YEAR', { width: 80, align: 'center' }),
        column.create('1월', 'M01', { width: 80, align: 'center', readOnly: true }),
        column.create('2월', 'M02', { width: 80, align: 'center', readOnly: true }),
        column.create('3월', 'M03', { width: 80, align: 'center', readOnly: true }),
        column.create('4월', 'M04', { width: 80, align: 'center', readOnly: true }),
        column.create('5월', 'M05', { width: 80, align: 'center', readOnly: true }),
        column.create('6월', 'M06', { width: 80, align: 'center', readOnly: true }),
        column.create('7월', 'M07', { width: 80, align: 'center', readOnly: true }),
        column.create('8월', 'M08', { width: 80, align: 'center', readOnly: true }),
        column.create('9월', 'M09', { width: 80, align: 'center', readOnly: true }),
        column.create('10월', 'M10', { width: 80, align: 'center', readOnly: true }),
        column.create('11월', 'M11', { width: 80, align: 'center', readOnly: true }),
        column.create('12월', 'M12', { width: 80, align: 'center', readOnly: true }),
        // 2026-10-02 [정기점검 주기관리 탭] 월별 점검자 사원코드 (저장값, 월 칸은 사원명 표시)
        column.create('1월점검자', 'M01CD', { hidden: true }),
        column.create('2월점검자', 'M02CD', { hidden: true }),
        column.create('3월점검자', 'M03CD', { hidden: true }),
        column.create('4월점검자', 'M04CD', { hidden: true }),
        column.create('5월점검자', 'M05CD', { hidden: true }),
        column.create('6월점검자', 'M06CD', { hidden: true }),
        column.create('7월점검자', 'M07CD', { hidden: true }),
        column.create('8월점검자', 'M08CD', { hidden: true }),
        column.create('9월점검자', 'M09CD', { hidden: true }),
        column.create('10월점검자', 'M10CD', { hidden: true }),
        column.create('11월점검자', 'M11CD', { hidden: true }),
        column.create('12월점검자', 'M12CD', { hidden: true }),
        column.split()
    ]);
    // 공통 정기점검 추가 팝업: 점검항목 목록 초기화
    ItsGrid.Create('grid10', { isCheckBoxGrid: true, isSubTotalGrid: false }, [
        column.create('점검코드', 'CHKKNDCD', { width: 70, align: 'center' }),
        column.create('점검명', 'CHKKNDNM', { width: 300 }),
        // 2026-09-30 [화면 로드 최적화] 점검항목·점검방법·점검값구분은 프로시저에서 받은 코드명으로 표시 (콤보 목록 조회 제거)
        column.create('점검항목', 'CHKLOCNM', { width: 130, align: 'center' }),
        column.create('점검방법', 'CHKMTHNM', { width: 100, align: 'center' }),
        column.create('점검값구분', 'CHKVALTPNM', { width: 90, align: 'center' }),
        column.split()
    ]);

    // 조회년도 기본값
    ItsCombo.SetValueByIndex('cmb_SYEAR', 4);

};

// 공통: 체크 행 존재 여부
function HasCheckedRows(gridId) {
    for (var rowIndex = 0; rowIndex < ItsGrid.Length(gridId); rowIndex++) {
        if (ItsGrid.IsChecked(gridId, rowIndex)) {
            return true;
        }
    }

    return false;
}

// 공통: 탭별 메인 조회
ItsButton.EventSearch = function () {
    var selectedTabIndex = ItsTab.GetIndex('tab1');

    if (selectedTabIndex == 0) {
        // 설비그룹 점검계획 탭: CRUD 후 대상 셀, 일반 조회 후 첫 행 포커스
        // 2026-09-30 [설비그룹 점검계획 탭] 재조회 시 개정 이력(REV) 그리드 초기화
        ItsGrid.Clear('grid_GRP_REV');
        ItsGrid.Clear('grid_GRP2');
        // 2026-09-30 [설비그룹 점검계획 탭] 이전 REV 조회 중 재조회해도 정기점검 버튼·제목·편집 상태 초기화 (조회 0건 대비)
        SetPlanEditButton('G', true, '');

        var maria = new ItsMaria('EQM1001_R03', 'LIST_MSTEQM_GRP');
        maria.AddPanel('div_GRP');
        maria.CallProc();
        if (maria.isError) {
            maria.ShowErrMsg();
            return;
        }

        LoadPlanGrid('grid_GRP1', function () {
            ItsGrid.SetStore('grid_GRP1', maria.store);
        }, true);
        ItsMsg.Toast(ItsMsg.CommonMsg.SearchComplete(maria.store.Length()));
    }
    else if (selectedTabIndex == 1) {
        // 2026-10-07 설비별 점검계획 탭: 표시 체크박스 변환 없이 조회
        // 2026-10-02 [설비별 점검계획 탭] 설비 목록은 조회 결과로 교체
        ItsGrid.Clear('grid_EQM_REV');
        ItsGrid.Clear('grid3');
        // 2026-09-30 [설비별 점검계획 탭] 이전 REV 조회 중 재조회해도 정기점검 버튼·제목·편집 상태 초기화 (조회 0건 대비)
        SetPlanEditButton('E', true, '');

        var maria = new ItsMaria('EQM1001_R03', 'LIST_MSTEQM');
        maria.AddPanel('div_EQM');
        maria.CallProc();
        if (maria.isError) {
            maria.ShowErrMsg();
            return;
        }

        LoadPlanGrid('grid1', function () {
            ItsGrid.SetStore('grid1', maria.store);
        }, true);
        ItsMsg.Toast(ItsMsg.CommonMsg.SearchComplete(maria.store.Length()));
    }
    else if (selectedTabIndex == 2) {
        // 정기점검 주기관리 탭: 데이터 조회
        ItsGrid.Clear('grid9');

        var maria = new ItsMaria('EQM1001_R03', 'LIST_CYCLE_EQMCD');
        maria.AddPanel('div_CYCLE_EQM');
        maria.CallProc();
        if (maria.isError) {
            maria.ShowErrMsg();
            return;
        }

        ItsGrid.SetStore('grid9', maria.store);
        ItsMsg.Toast(ItsMsg.CommonMsg.SearchComplete(maria.store.Length()));
    }
};

// 설비그룹 점검계획 탭: 선택 그룹 정기점검 조회
// 2026-09-30 [설비그룹 점검계획 탭] 선택 그룹의 REV 목록부터 조회하고, 우측 하단 정기점검은 선택한 REV 기준으로 조회
ItsGrid.Event('grid_GRP1').onSelect = function () {
    var curIdx = ItsGrid.GetCurrentIndex('grid_GRP1');
    var selectedEqmGubun = ItsGrid.GetValue('grid_GRP1', curIdx, 'EQMGUBUN');

    if (!selectedEqmGubun) {
        ItsGrid.Clear('grid_GRP_REV');
        ItsGrid.Clear('grid_GRP2');
        SetPlanEditButton('G', true, '');
        return;
    }

    SearchPlanRev('G', selectedEqmGubun);
};

// 설비그룹 점검계획 탭: 정기점검 복사 팝업
ItsButton.Event('bdiv_GRP_btn_COPY').onClick = function () {
    var curIdx = ItsGrid.GetCurrentIndex('grid_GRP1');
    var selectedEqmGubun = ItsGrid.GetValue('grid_GRP1', curIdx, 'EQMGUBUN');

    if (!selectedEqmGubun) {
        ItsMsg.Toast('설비그룹을 먼저 선택해주세요.');
        return;
    }

    ItsGrid.Clear('grid_GRP_COPY1');
    ItsGrid.Clear('grid_GRP_COPY2');
    ItsPop.Open('pop_GRP_EQM02_COPY');

    var maria = new ItsMaria('EQM1001_R03', 'LIST_COPY_GRP_EQM02');
    maria.AddParam('EQMGRP', selectedEqmGubun);
    maria.CallProc();
    if (maria.isError) {
        maria.ShowErrMsg();
        return;
    }

    ItsGrid.SetStore('grid_GRP_COPY1', maria.store);
};

// 설비그룹 점검계획 탭: 복사 원본 정기점검 조회
ItsGrid.Event('grid_GRP_COPY1').onSelect = function () {
    var sourceGroupRowIndex = ItsGrid.GetCurrentIndex('grid_GRP_COPY1');
    var sourceEqmGubun = ItsGrid.GetValue('grid_GRP_COPY1', sourceGroupRowIndex, 'EQMGRP');

    if (!sourceEqmGubun) {
        ItsGrid.Clear('grid_GRP_COPY2');
        return;
    }

    var maria = new ItsMaria('EQM1001_R03', 'LIST_COPY_GRP_EQM02_DTL');
    maria.AddParam('EQMGRP', sourceEqmGubun);
    maria.CallProc();
    if (maria.isError) {
        maria.ShowErrMsg();
        return;
    }

    ItsGrid.SetStore('grid_GRP_COPY2', maria.store.YnToBool('USEYN'));
};

// 설비그룹 점검계획 탭: 정기점검 일괄 복사
ItsButton.Event('btn_COPY_GRP_EQM02').onClick = function () {
    var sourceGroupRowIndex = ItsGrid.GetCurrentIndex('grid_GRP_COPY1');
    var sourceEquipmentCode = ItsGrid.GetValue('grid_GRP_COPY1', sourceGroupRowIndex, 'FANO');
    var targetGroupRowIndex = ItsGrid.GetCurrentIndex('grid_GRP1');
    var targetEqmGubun = ItsGrid.GetValue('grid_GRP1', targetGroupRowIndex, 'EQMGUBUN');

    // 2026-10-02 [설비그룹 복사 팝업] 복사 원본·대상 설비그룹 지정 확인은 프로시저(COPY_GRP_EQM02)에서 처리
    // 2026-10-08 [설비그룹 복사 팝업] 정기점검 일괄 복사 확인 메시지 간소화
    ItsMsg.Confirm('선택한 설비그룹의 점검항목을 일괄 복사하시겠습니까?', function () {
        var maria = new ItsMaria('EQM1001_R03', 'COPY_GRP_EQM02');
        maria.AddParam('EQMGRP', targetEqmGubun);
        maria.AddParam('FANO_COPY', sourceEquipmentCode);
        maria.CallProc();
        if (maria.isError) {
            maria.ShowErrMsg();
            return;
        }

        ItsButton.Event('btn_CANCEL_GRP_COPY_EQM02').onClick();
        ItsMsg.Toast(ItsMsg.CommonMsg.CopyComplete());
        RefreshPlan('G', targetEqmGubun);
    }, function () {
        ItsMsg.Toast('복사가 취소되었습니다.');
    });
};

// 설비그룹 점검계획 탭: 복사 팝업 초기화
ItsButton.Event('btn_CANCEL_GRP_COPY_EQM02').onClick = function () {
    ItsGrid.Clear('grid_GRP_COPY1');
    ItsGrid.Clear('grid_GRP_COPY2');
    ItsPop.Close('pop_GRP_EQM02_COPY');
};

// 설비그룹 점검계획 탭: 정기점검 추가
ItsButton.Event('bdiv_GRP_btn_ADD').onClick = function () {
    var curIdx = ItsGrid.GetCurrentIndex('grid_GRP1');
    var selectedEqmGubun = ItsGrid.GetValue('grid_GRP1', curIdx, 'EQMGUBUN');

    if (!selectedEqmGubun) {
        ItsMsg.Toast('설비그룹을 먼저 선택해주세요.');
        return;
    }

    ItsGrid.Clear('grid10');
    ItsPop.Open('pop_EQM02_ADD');

    var maria = new ItsMaria('EQM1001_R03', 'LIST_GRP_EQM02_ADD');
    maria.AddParam('EQMGRP', selectedEqmGubun);
    maria.CallProc();
    if (maria.isError) {
        maria.ShowErrMsg();
        return;
    }

    ItsGrid.SetStore('grid10', maria.store);
};

// 설비그룹 점검계획 탭: 정기점검 저장
ItsButton.Event('bdiv_GRP_btn_SAVE').onClick = function () {
    if (!HasCheckedRows('grid_GRP2')) {
        ItsMsg.Toast('선택된 항목이 없습니다.');
        return;
    }

    var curIdx = ItsGrid.GetCurrentIndex('grid_GRP1');
    var selectedEqmGubun = ItsGrid.GetValue('grid_GRP1', curIdx, 'EQMGUBUN');

    // 2026-10-02 [설비그룹 점검계획 탭] 설비그룹 지정 확인은 프로시저(SAVE_GRP_EQM02)에서 처리
    // 2026-10-08 [설비그룹 점검계획 탭] 정기점검 일괄 저장 확인 메시지 간소화
    var confirmationMessage = '선택한 점검항목을 일괄 저장하시겠습니까?';

    ItsMsg.Confirm(confirmationMessage, function () {
        var maria = new ItsMaria('EQM1001_R03', 'SAVE_GRP_EQM02');
        maria.AddParam('EQMGRP', selectedEqmGubun);

        for (var i = 0; i < ItsGrid.Length('grid_GRP2'); i++) {
            if (ItsGrid.IsChecked('grid_GRP2', i)) {
                maria.AddList('CHKKNDCD_LIST', ItsGrid.GetValue('grid_GRP2', i, 'CHKKNDCD'));
                maria.AddList('SORTNO_LIST', ItsGrid.GetValue('grid_GRP2', i, 'SORTNO'));
                maria.AddList('REMARK_LIST', ItsGrid.GetValue('grid_GRP2', i, 'REMARK'));
                if (ItsGrid.GetValue('grid_GRP2', i, 'USEYN', false) == 'Y')
                    maria.AddList('USEYN_LIST', 'Y');
                else
                    maria.AddList('USEYN_LIST', 'N');
            }
        }

        maria.CallProc();
        if (maria.isError) {
            maria.ShowErrMsg();
            return;
        }
        ItsMsg.Toast(ItsMsg.CommonMsg.SaveComplete());
        RefreshPlan('G', selectedEqmGubun);
    }, function () {
        ItsMsg.Toast('저장이 취소되었습니다.');
    });
};

// 설비그룹 점검계획 탭: 정기점검 삭제
ItsButton.Event('bdiv_GRP_btn_DEL').onClick = function () {
    if (!HasCheckedRows('grid_GRP2')) {
        ItsMsg.Toast('선택된 항목이 없습니다.');
        return;
    }

    var curIdx = ItsGrid.GetCurrentIndex('grid_GRP1');
    var selectedEqmGubun = ItsGrid.GetValue('grid_GRP1', curIdx, 'EQMGUBUN');

    // 2026-10-02 [설비그룹 점검계획 탭] 설비그룹 지정 확인은 프로시저(DEL_GRP_EQM02)에서 처리
    // 2026-10-08 [설비그룹 점검계획 탭] 정기점검 일괄 삭제 확인 메시지 간소화
    var confirmationMessage = '선택한 점검항목을 일괄 삭제하시겠습니까?';

    ItsMsg.Confirm(confirmationMessage, function () {
        var maria = new ItsMaria('EQM1001_R03', 'DEL_GRP_EQM02');
        maria.AddParam('EQMGRP', selectedEqmGubun);

        for (var i = 0; i < ItsGrid.Length('grid_GRP2'); i++) {
            if (ItsGrid.IsChecked('grid_GRP2', i)) {
                maria.AddList('CHKKNDCD_LIST', ItsGrid.GetValue('grid_GRP2', i, 'CHKKNDCD'));
            }
        }

        maria.CallProc();
        if (maria.isError) {
            maria.ShowErrMsg();
            return;
        }
        ItsMsg.Toast(ItsMsg.CommonMsg.DeleteComplete());
        RefreshPlan('G', selectedEqmGubun);
    }, function () {
        ItsMsg.Toast('삭제가 취소되었습니다.');
    });
};

// 설비별 점검계획 탭: 선택 설비 정기점검 조회
// 2026-09-30 [설비별 점검계획 탭] 선택 설비의 REV 목록부터 조회하고, 우측 하단 정기점검은 선택한 REV 기준으로 조회
ItsGrid.Event('grid1').onSelect = function () {
    var selectedEquipmentCode = ItsGrid.GetValue('grid1', ItsGrid.GetCurrentIndex('grid1'), 'FANO');
    if (!selectedEquipmentCode) {
        ItsGrid.Clear('grid_EQM_REV');
        ItsGrid.Clear('grid3');
        SetPlanEditButton('E', true, '');
        return;
    }

    SearchPlanRev('E', selectedEquipmentCode);
};


// 설비별 점검계획 탭: 정기점검 추가
ItsButton.Event('bdiv3_btn_ADD').onClick = function () {
    var selectedEquipmentCode = ItsGrid.GetValue('grid1', ItsGrid.GetCurrentIndex('grid1'), 'FANO');
    if (!selectedEquipmentCode) {
        ItsMsg.Toast('설비를 먼저 선택해주세요.');
        return;
    }

    ItsGrid.Clear('grid10');
    ItsPop.Open('pop_EQM02_ADD');

    var maria = new ItsMaria('EQM1001_R03', 'LIST_EQM02');
    maria.AddParam('FANO', selectedEquipmentCode);
    maria.CallProc();
    if (maria.isError) {
        maria.ShowErrMsg();
        return;
    }

    ItsGrid.SetStore('grid10', maria.store);
};

// 설비별 점검계획 탭: 정기점검 저장
ItsButton.Event('bdiv3_btn_SAVE').onClick = function () {
    if (!HasCheckedRows('grid3')) {
        ItsMsg.Toast('선택된 항목이 없습니다.');
        return;
    }

    var selectedEquipmentCode = ItsGrid.GetValue('grid1', ItsGrid.GetCurrentIndex('grid1'), 'FANO');

    ItsMsg.Confirm('선택하신 항목을 저장하시겠습니까?', function () {
        var maria = new ItsMaria('EQM1001_R03', 'SAVE_EQM02');
        maria.AddParam('FANO', selectedEquipmentCode);

        for (var i = 0; i < ItsGrid.Length('grid3'); i++) {
            if (ItsGrid.IsChecked('grid3', i)) {
                maria.AddList('CHKKNDCD_LIST', ItsGrid.GetValue('grid3', i, 'CHKKNDCD'));
                maria.AddList('SORTNO_LIST', ItsGrid.GetValue('grid3', i, 'SORTNO'));
                maria.AddList('REMARK_LIST', ItsGrid.GetValue('grid3', i, 'REMARK'));
                if (ItsGrid.GetValue('grid3', i, 'USEYN', false) == 'Y')
                    maria.AddList('USEYN_LIST', 'Y');
                else
                    maria.AddList('USEYN_LIST', 'N');
            }
        }

        maria.CallProc();
        if (maria.isError) {
            maria.ShowErrMsg();
            return;
        }
        ItsMsg.Toast(ItsMsg.CommonMsg.SaveComplete());
        // 2026-09-30 [설비별 점검계획 탭] 저장 후 진행 중 REV로 포커스
        RefreshPlan('E', selectedEquipmentCode);
    }, function () {
        ItsMsg.Toast('저장이 취소되었습니다.');
    });
};

// 설비별 점검계획 탭: 정기점검 삭제
ItsButton.Event('bdiv3_btn_DEL').onClick = function () {
    if (!HasCheckedRows('grid3')) {
        ItsMsg.Toast('선택된 항목이 없습니다.');
        return;
    }

    var selectedEquipmentCode = ItsGrid.GetValue('grid1', ItsGrid.GetCurrentIndex('grid1'), 'FANO');

    ItsMsg.Confirm('선택한 항목을 삭제하시겠습니까?', function () {
        var maria = new ItsMaria('EQM1001_R03', 'DEL_EQM02');
        maria.AddParam('FANO', selectedEquipmentCode);

        for (var i = 0; i < ItsGrid.Length('grid3'); i++) {
            if (ItsGrid.IsChecked('grid3', i)) {
                maria.AddList('CHKKNDCD_LIST', ItsGrid.GetValue('grid3', i, 'CHKKNDCD'));
            }
        }

        maria.CallProc();
        if (maria.isError) {
            maria.ShowErrMsg();
            return;
        }
        ItsMsg.Toast(ItsMsg.CommonMsg.DeleteComplete());
        // 2026-09-30 [설비별 점검계획 탭] 삭제 후 진행 중 REV로 포커스
        RefreshPlan('E', selectedEquipmentCode);
    }, function () {
        ItsMsg.Toast('삭제가 취소되었습니다.');
    });
};

// 설비별 점검계획 탭: 정기점검 복사 팝업
ItsButton.Event('bdiv3_btn_COPY').onClick = function () {
    var selectedEquipmentCode = ItsGrid.GetValue('grid1', ItsGrid.GetCurrentIndex('grid1'), 'FANO');
    if (!selectedEquipmentCode) {
        ItsMsg.Toast('설비를 먼저 선택해주세요.');
        return;
    }

    ItsGrid.Clear('grid7');
    ItsGrid.Clear('grid8');
    ItsPop.Open('pop_EQM02_COPY');

    var maria = new ItsMaria('EQM1001_R03', 'LIST_COPY_EQM02');
    maria.AddParam('FANO', selectedEquipmentCode);
    maria.CallProc();
    if (maria.isError) {
        maria.ShowErrMsg();
        return;
    }

    ItsGrid.SetStore('grid7', maria.store);
};

// 설비별 점검계획 탭: 복사 원본 정기점검 조회
ItsGrid.Event('grid7').onSelect = function () {
    var sourceEquipmentCode = ItsGrid.GetValue('grid7', ItsGrid.GetCurrentIndex('grid7'), 'FANO');
    if (!sourceEquipmentCode) {
        ItsGrid.Clear('grid8');
        return;
    }

    var maria = new ItsMaria('EQM1001_R03', 'LIST_COPY_EQM02');
    maria.AddParam('FANO', sourceEquipmentCode);
    maria.CallProc();
    if (maria.isError) {
        maria.ShowErrMsg();
        return;
    }

    ItsGrid.SetStore('grid8', maria.storeExtend1);
};

// 설비별 점검계획 탭: 정기점검 복사
ItsButton.Event('btn_COPY_EQM02').onClick = function () {
    var sourceEquipmentCode = ItsGrid.GetValue('grid7', ItsGrid.GetCurrentIndex('grid7'), 'FANO');
    var targetEquipmentCode = ItsGrid.GetValue('grid1', ItsGrid.GetCurrentIndex('grid1'), 'FANO');

    // 2026-10-02 [설비별 복사 팝업] 복사 원본·대상 설비 지정 확인은 프로시저(COPY_EQM02)에서 처리
    ItsMsg.Confirm('선택한 항목을 복사하시겠습니까?', function () {
        var maria = new ItsMaria('EQM1001_R03', 'COPY_EQM02');
        maria.AddParam('FANO', targetEquipmentCode);
        maria.AddParam('FANO_COPY', sourceEquipmentCode);
        maria.CallProc();
        if (maria.isError) {
            maria.ShowErrMsg();
            return;
        }

        ItsButton.Event('btn_CANCEL_COPY_EQM02').onClick();
        ItsMsg.Toast(ItsMsg.CommonMsg.CopyComplete());
        // 2026-09-30 [설비별 점검계획 탭] 복사 후 진행 중 REV로 포커스
        RefreshPlan('E', targetEquipmentCode);
    }, function () {
        ItsMsg.Toast('복사가 취소되었습니다.');
    });
};

// 설비별 점검계획 탭: 복사 팝업 초기화
ItsButton.Event('btn_CANCEL_COPY_EQM02').onClick = function () {
    ItsGrid.Clear('grid7');
    ItsGrid.Clear('grid8');
    ItsPop.Close('pop_EQM02_COPY');
};

// 정기점검 주기관리 탭

// 연간 월별 점검 그리드 더블클릭 이벤트
ItsGrid.Event('grid9').onDoubleClick = function (rowIndex, field) {
    ItsGrid.Event('grid9').onKeydownEnter(rowIndex, field);
};

// 2026-09-29 [정기점검 주기관리 탭] Delete/Backspace 키로 선택 월 셀 점검자 삭제
ItsGrid.Event('grid9').onKeydown = function (rowIndex, field, keyCode) {
    if (keyCode === 46 || keyCode === 8) { // 46: Delete, 8: Backspace
        if (field == 'M01' || field == 'M02' || field == 'M03' || field == 'M04' || field == 'M05' || field == 'M06' ||
            field == 'M07' || field == 'M08' || field == 'M09' || field == 'M10' || field == 'M11' || field == 'M12') {
            var val = (ItsGrid.GetValue('grid9', rowIndex, field) || '').toString().trim();
            if (val !== '') {
                // 2026-10-02 [정기점검 주기관리 탭] 월 칸 점검자명·사원코드 함께 삭제
                SetCycleEmp(rowIndex, field, '', '');
                ItsGrid.CheckRow('grid9', rowIndex);
            }
        }
    }
};

// 2026-09-29 [정기점검 주기관리 탭] 선택 점검자명을 월별 셀에 설정 또는 토글 삭제
ItsGrid.Event('grid9').onKeydownEnter = function (rowIndex, field) {
    if (field == 'M01' || field == 'M02' || field == 'M03' || field == 'M04' || field == 'M05' || field == 'M06' ||
        field == 'M07' || field == 'M08' || field == 'M09' || field == 'M10' || field == 'M11' || field == 'M12') {
        var cellVal = (ItsGrid.GetValue('grid9', rowIndex, field) || '').toString().trim();
        // 2026-10-02 [정기점검 주기관리 탭] 월 칸 저장값(사원코드)과 선택 점검자 사원코드·사원명
        var cellCd = (ItsGrid.GetValue('grid9', rowIndex, field + 'CD') || '').toString().trim();
        var emp = GetCycleEmp();

        // 점검자 미선택 시
        if (!emp.cd) {
            if (cellVal !== '') {
                SetCycleEmp(rowIndex, field, '', '');
                ItsGrid.CheckRow('grid9', rowIndex);
            } else {
                ItsMsg.Toast('점검자를 선택해주세요.');
            }
            return;
        }

        // 2026-10-02 [정기점검 주기관리 탭] 동일 점검자(사원코드 기준, 동명이인 구분) 토글 삭제, 다른 점검자 설정
        if (cellCd === emp.cd) {
            SetCycleEmp(rowIndex, field, '', '');
        } else {
            SetCycleEmp(rowIndex, field, emp.cd, emp.nm);
        }
        ItsGrid.CheckRow('grid9', rowIndex);
    }
};

// 2026-10-02 [정기점검 주기관리 탭] 선택한 점검자 사원코드·사원명 (사원명이 없으면 사원코드)
function GetCycleEmp() {
    var cd = (ItsFind.GetValue('find_EMP') || '').trim();
    return { cd: cd, nm: cd ? ((ItsFind.GetNameValue('find_EMP') || '').trim() || cd) : '' };
}

// 2026-10-02 [정기점검 주기관리 탭] 월 칸에 점검자 설정 (화면은 사원명, 저장은 사원코드)
function SetCycleEmp(rowIndex, field, empCd, empNm) {
    ItsGrid.SetValue('grid9', rowIndex, field, empNm);
    ItsGrid.SetValue('grid9', rowIndex, field + 'CD', empCd);
}

// 2026-09-29 [정기점검 주기관리 탭] 일괄 주기설정 팝업 열기
ItsButton.Event('btn_OPEN_CYCLE_BATCH').onClick = function () {
    if (!HasCheckedRows('grid9')) {
        // 2026-10-08 [정기점검 주기관리 탭] 대상 설비 미체크 알림 메시지 간소화
        ItsMsg.Toast('대상 설비를 체크해주세요.');
        return;
    }

    var empNm = (ItsFind.GetNameValue('find_EMP') || ItsFind.GetValue('find_EMP') || '').trim();
    if (!empNm) {
        ItsMsg.Toast('점검자를 먼저 선택해주세요.');
        return;
    }

    // 선택 설비 수 및 기존 등록 월 확인
    var cnt = 0;
    var existMonths = {};
    var existCnt = 0;
    var arrMonth = ['M01', 'M02', 'M03', 'M04', 'M05', 'M06', 'M07', 'M08', 'M09', 'M10', 'M11', 'M12'];

    for (var i = 0; i < ItsGrid.Length('grid9'); i++) {
        if (ItsGrid.IsChecked('grid9', i)) {
            cnt++;
            for (var m = 0; m < arrMonth.length; m++) {
                var field = arrMonth[m];
                var val = (ItsGrid.GetValue('grid9', i, field) || '').toString().trim();
                if (val !== '' && !existMonths[field]) {
                    existMonths[field] = true;
                    existCnt++;
                }
            }
        }
    }
    $('#lbl_BATCH_CNT').text(cnt);

    // 기존 등록된 월이 있으면 해당 월만 선택, 없으면 전체 선택
    if (existCnt > 0) {
        $('.chk_MONTH').each(function () {
            $(this).prop('checked', !!existMonths[$(this).val()]);
        });
        SetAllMonthButton(existCnt === arrMonth.length);
    } else {
        $('.chk_MONTH').prop('checked', true);
        SetAllMonthButton(true);
    }

    ItsPop.Open('pop_CYCLE_BATCH');
};

// 2026-09-29 [정기점검 주기관리 탭] 전체 선택/해제 버튼 상태 설정
function SetAllMonthButton(isAll) {
    $('#btn_ALL_MONTH').text(isAll ? '전체 해제' : '전체 선택')
        .css(isAll ? { 'border-color': '#d32f2f', 'background': '#ffebee', 'color': '#d32f2f' }
            : { 'border-color': '#1976d2', 'background': '#e3f2fd', 'color': '#1976d2' });
}

// 2026-09-29 [정기점검 주기관리 탭] 전체 선택/해제 토글 버튼 클릭
$(document).on('click', '#btn_ALL_MONTH', function () {
    var totalCnt = $('.chk_MONTH').length;
    var chkCnt = $('.chk_MONTH:checked').length;
    var isCheck = (chkCnt < totalCnt);

    $('.chk_MONTH').prop('checked', isCheck);
    SetAllMonthButton(isCheck);
});

// 2026-09-29 [정기점검 주기관리 탭] 월 체크박스 상태 변경 시 토글 버튼 동기화
$(document).on('change', '.chk_MONTH', function () {
    var totalCnt = $('.chk_MONTH').length;
    var chkCnt = $('.chk_MONTH:checked').length;
    SetAllMonthButton(chkCnt === totalCnt);
});

// 2026-09-29 [정기점검 주기관리 탭] 일괄 설정 팝업 닫기
ItsButton.Event('btn_CLOSE_BATCH').onClick = function () {
    ItsPop.Close('pop_CYCLE_BATCH');
};

// 2026-09-29 [정기점검 주기관리 탭] 일괄 주기설정 점검자 등록/변경 및 즉시 저장
ItsButton.Event('btn_SAVE_BATCH').onClick = function () {
    var empNm = (ItsFind.GetNameValue('find_EMP') || ItsFind.GetValue('find_EMP') || '').trim();
    if (!empNm) {
        ItsMsg.Toast('등록할 점검자를 먼저 선택해주세요.');
        return;
    }

    var arrSelMonth = [];
    $('.chk_MONTH:checked').each(function () {
        arrSelMonth.push($(this).val());
    });

    if (arrSelMonth.length === 0) {
        ItsMsg.Toast('적용할 대상 월을 1개 이상 선택해주세요.');
        return;
    }

    // 선택 설비 월별 점검자 바인딩
    var saveCnt = 0;
    for (var i = 0; i < ItsGrid.Length('grid9'); i++) {
        if (ItsGrid.IsChecked('grid9', i)) {
            saveCnt++;
            for (var m = 0; m < arrSelMonth.length; m++) {
                // 2026-10-02 [일괄 주기설정 팝업] 선택 월에 점검자명·사원코드 함께 설정
                SetCycleEmp(i, arrSelMonth[m], ItsFind.GetValue('find_EMP').trim(), empNm);
            }
            ItsGrid.CheckRow('grid9', i);
        }
    }

    ItsPop.Close('pop_CYCLE_BATCH');

    // 연간 점검계획 즉시 저장
    // 2026-10-02 [일괄 주기설정 팝업] 월별 점검자는 사원코드(MxxCD) 저장
    var maria = new ItsMaria('EQM1001_R03', 'SAVE_CYCLE_EQMCD');

    for (var i = 0; i < ItsGrid.Length('grid9'); i++) {
        if (ItsGrid.IsChecked('grid9', i)) {
            maria.AddList('FANO_LIST', ItsGrid.GetValue('grid9', i, 'FANO'));
            maria.AddList('YEAR_LIST', ItsGrid.GetValue('grid9', i, 'YEAR'));
            maria.AddList('M01_LIST', ItsGrid.GetValue('grid9', i, 'M01CD'));
            maria.AddList('M02_LIST', ItsGrid.GetValue('grid9', i, 'M02CD'));
            maria.AddList('M03_LIST', ItsGrid.GetValue('grid9', i, 'M03CD'));
            maria.AddList('M04_LIST', ItsGrid.GetValue('grid9', i, 'M04CD'));
            maria.AddList('M05_LIST', ItsGrid.GetValue('grid9', i, 'M05CD'));
            maria.AddList('M06_LIST', ItsGrid.GetValue('grid9', i, 'M06CD'));
            maria.AddList('M07_LIST', ItsGrid.GetValue('grid9', i, 'M07CD'));
            maria.AddList('M08_LIST', ItsGrid.GetValue('grid9', i, 'M08CD'));
            maria.AddList('M09_LIST', ItsGrid.GetValue('grid9', i, 'M09CD'));
            maria.AddList('M10_LIST', ItsGrid.GetValue('grid9', i, 'M10CD'));
            maria.AddList('M11_LIST', ItsGrid.GetValue('grid9', i, 'M11CD'));
            maria.AddList('M12_LIST', ItsGrid.GetValue('grid9', i, 'M12CD'));
            maria.AddList('REMARK_LIST', ItsGrid.GetValue('grid9', i, 'REMARK'));
        }
    }

    maria.CallProc();
    if (maria.isError) {
        maria.ShowErrMsg();
        return;
    }

    ItsMsg.Toast(saveCnt + '대 설비의 일괄 주기설정이 정상 등록되었습니다.');
    ItsGrid.Setkey('grid9', 'FANO', ItsGrid.GetValue('grid9', ItsGrid.GetCurrentIndex('grid9'), 'FANO'));
    ItsButton.EventSearch();
};

// 정기점검 주기관리 탭: 연간 계획 저장
ItsButton.Event('div_SAVE_CYCLE_EQM').onClick = function () {
    if (!HasCheckedRows('grid9')) {
        ItsMsg.Toast('선택된 항목이 없습니다.');
        return;
    }

    ItsMsg.Confirm('선택하신 항목을 저장하시겠습니까?', function () {
        // 2026-10-02 [정기점검 주기관리 탭] 월별 점검자는 사원코드(MxxCD) 저장
        var maria = new ItsMaria('EQM1001_R03', 'SAVE_CYCLE_EQMCD');

        for (var i = 0; i < ItsGrid.Length('grid9'); i++) {
            if (ItsGrid.IsChecked('grid9', i)) {
                maria.AddList('FANO_LIST', ItsGrid.GetValue('grid9', i, 'FANO'));
                maria.AddList('YEAR_LIST', ItsGrid.GetValue('grid9', i, 'YEAR'));
                maria.AddList('M01_LIST', ItsGrid.GetValue('grid9', i, 'M01CD'));
                maria.AddList('M02_LIST', ItsGrid.GetValue('grid9', i, 'M02CD'));
                maria.AddList('M03_LIST', ItsGrid.GetValue('grid9', i, 'M03CD'));
                maria.AddList('M04_LIST', ItsGrid.GetValue('grid9', i, 'M04CD'));
                maria.AddList('M05_LIST', ItsGrid.GetValue('grid9', i, 'M05CD'));
                maria.AddList('M06_LIST', ItsGrid.GetValue('grid9', i, 'M06CD'));
                maria.AddList('M07_LIST', ItsGrid.GetValue('grid9', i, 'M07CD'));
                maria.AddList('M08_LIST', ItsGrid.GetValue('grid9', i, 'M08CD'));
                maria.AddList('M09_LIST', ItsGrid.GetValue('grid9', i, 'M09CD'));
                maria.AddList('M10_LIST', ItsGrid.GetValue('grid9', i, 'M10CD'));
                maria.AddList('M11_LIST', ItsGrid.GetValue('grid9', i, 'M11CD'));
                maria.AddList('M12_LIST', ItsGrid.GetValue('grid9', i, 'M12CD'));
                maria.AddList('REMARK_LIST', ItsGrid.GetValue('grid9', i, 'REMARK'));
            }
        }

        maria.CallProc();
        if (maria.isError) {
            maria.ShowErrMsg();
            return;
        }

        ItsMsg.Toast(ItsMsg.CommonMsg.SaveComplete());
        ItsGrid.Setkey('grid9', 'FANO', ItsGrid.GetValue('grid9', ItsGrid.GetCurrentIndex('grid9'), 'FANO'));
        ItsButton.EventSearch();
    }, function () {
        ItsMsg.Toast('저장이 취소되었습니다.');
    });
};

// 정기점검 주기관리 탭: 연간 계획 삭제
ItsButton.Event('div_DEL_CYCLE_EQM').onClick = function () {
    if (!HasCheckedRows('grid9')) {
        ItsMsg.Toast('선택된 항목이 없습니다.');
        return;
    }

    ItsMsg.Confirm('선택한 항목을 삭제하시겠습니까?', function () {
        var maria = new ItsMaria('EQM1001_R03', 'DELETE_CYCLE_EQMCD');

        for (var i = 0; i < ItsGrid.Length('grid9'); i++) {
            if (ItsGrid.IsChecked('grid9', i)) {
                maria.AddList('FANO_LIST', ItsGrid.GetValue('grid9', i, 'FANO'));
                maria.AddList('YEAR_LIST', ItsGrid.GetValue('grid9', i, 'YEAR'));
            }
        }

        maria.CallProc();
        if (maria.isError) {
            maria.ShowErrMsg();
            return;
        }

        ItsMsg.Toast(ItsMsg.CommonMsg.DeleteComplete());
        ItsGrid.Setkey('grid9', 'FANO', ItsGrid.GetValue('grid9', ItsGrid.GetCurrentIndex('grid9'), 'FANO'));
        ItsButton.EventSearch();
    }, function () {
        ItsMsg.Toast('삭제가 취소되었습니다.');
    });
};

// 공통 정기점검 항목 추가 팝업: 저장
ItsButton.Event('btn_ADD_EQM02').onClick = function () {
    if (!HasCheckedRows('grid10')) {
        ItsMsg.Toast('선택된 항목이 없습니다.');
        return;
    }

    var selectedTabIndex = ItsTab.GetIndex('tab1');
    var maria;
    var selectedEquipmentCode;

    if (selectedTabIndex == 0) {
        var curIdx = ItsGrid.GetCurrentIndex('grid_GRP1');
        var selectedEqmGubun = ItsGrid.GetValue('grid_GRP1', curIdx, 'EQMGUBUN');
        // 2026-10-02 [정기점검 추가 팝업] 설비그룹 지정 확인은 프로시저(REG_GRP_EQM02)에서 처리

        maria = new ItsMaria('EQM1001_R03', 'REG_GRP_EQM02');
        maria.AddParam('EQMGRP', selectedEqmGubun);
    } else {
        selectedEquipmentCode = ItsGrid.GetValue('grid1', ItsGrid.GetCurrentIndex('grid1'), 'FANO');
        maria = new ItsMaria('EQM1001_R03', 'REG_EQM02');
        maria.AddParam('FANO', selectedEquipmentCode);
    }

    for (var i = 0; i < ItsGrid.Length('grid10'); i++) {
        if (ItsGrid.IsChecked('grid10', i)) {
            maria.AddList('CHKKNDCD_LIST', ItsGrid.GetValue('grid10', i, 'CHKKNDCD'));
            maria.AddList('REMARK_LIST', ItsGrid.GetValue('grid10', i, 'REMARK'));
        }
    }

    maria.CallProc();
    if (maria.isError) {
        maria.ShowErrMsg();
        return;
    }

    ItsButton.Event('btn_CANCEL_ADD_EQM02').onClick();
    ItsMsg.Toast(ItsMsg.CommonMsg.AddComplete);
    if (selectedTabIndex == 0) {
        RefreshPlan('G', selectedEqmGubun);
    } else {
        // 2026-09-30 [설비별 점검계획 탭] 추가 후 진행 중 REV로 포커스
        RefreshPlan('E', selectedEquipmentCode);
    }
};

// 공통 정기점검 항목 추가 팝업: 초기화
ItsButton.Event('btn_CANCEL_ADD_EQM02').onClick = function () {
    ItsGrid.Clear('grid10');
    ItsPop.Close('pop_EQM02_ADD');
};

/* 점검계획 개정 이력 (REV) */

// 2026-09-30 [설비그룹·설비별 점검계획 탭] 우측 하단 정기점검 편집 가능 여부 (이전 REV 승인본 조회 중이면 false)
var isPlanEdit = { G: true, E: true };

// 2026-09-30 [설비그룹·설비별 점검계획 탭] 좌측 목록에서 선택한 설비그룹코드·설비코드
function GetPlanCd(planTp) {
    if (planTp == 'G') {
        return ItsGrid.GetValue('grid_GRP1', ItsGrid.GetCurrentIndex('grid_GRP1'), 'EQMGUBUN');
    }
    return ItsGrid.GetValue('grid1', ItsGrid.GetCurrentIndex('grid1'), 'FANO');
}

// 2026-10-07 설비그룹·설비별 점검계획 탭: 원본 목록의 최신 REV
function GetLatestPlanRev(planTp) {
    var data = ItsGrid.GetStore(planTp == 'G' ? 'grid_GRP_REV' : 'grid_EQM_REV');
    return data ? data[0] : null;
}

// 2026-10-07 설비그룹·설비별 점검계획 탭: 바인딩 중 중복 선택 이벤트 차단, 완료 후 한 번 조회
function LoadPlanGrid(gridId, bind, isSelect) {
    var event = ItsGrid.Event(gridId);
    var onSelect = event.onSelect;
    event.onSelect = undefined;
    try {
        bind();
    } finally {
        event.onSelect = onSelect;
    }
    if (isSelect && ItsGrid.Length(gridId) > 0 && onSelect) {
        onSelect(ItsGrid.GetCurrentIndex(gridId));
    }
}

// 2026-10-07 설비그룹·설비별 점검계획 탭: 공통 SetRowData로 현재 행과 최신 REV 갱신
function RefreshPlanRev(planTp, planCd) {
    var gridId = planTp == 'G' ? 'grid_GRP1' : 'grid1';
    var rowIndex = ItsGrid.GetCurrentIndex(gridId);
    if (rowIndex < 0 || GetPlanCd(planTp) != planCd) {
        return false;
    }
    var revGridId = planTp == 'G' ? 'grid_GRP_REV' : 'grid_EQM_REV';
    var revGrid = ItsGrid.Get(revGridId);
    var rev = GetLatestPlanRev(planTp);
    var maria = new ItsMaria('EQM1001_R03', 'LIST_PLAN_REV');
    maria.AddParam('PLANTP', planTp);
    maria.AddParam('PLANCD', planCd);
    maria.AddParam('REVNUM', 'LATEST');
    maria.CallProc();
    if (maria.isError) {
        maria.ShowErrMsg();
        return false;
    }
    var data = maria.store.data[0];
    if (!data) {
        return false;
    }
    LoadPlanGrid(revGridId, function () {
        if (rev && rev.REVNUM == data.REVNUM) {
            var revIndex = revGrid.collectionView.items.indexOf(rev);
            ItsGrid.SetRowData(revGridId, revIndex, data);
        } else if (rev) {
            ItsGrid.AddRow(revGridId, 0, data);
        } else {
            ItsGrid.SetStore(revGridId, maria.store);
        }
    });
    ItsGrid.SetRowData(gridId, rowIndex, {
        REVNM: data.REVNM,
        APRVSTTNM: data.APRVSTTNM,
        REJREASON: data.REJREASON
    });
    return true;
}

// 2026-10-07 설비그룹·설비별 점검계획 탭: CRUD 후 항목 갱신 및 개정내용 포커스
function RefreshPlan(planTp, planCd) {
    if (RefreshPlanRev(planTp, planCd)) {
        var grid = ItsGrid.Get(planTp == 'G' ? 'grid_GRP_REV' : 'grid_EQM_REV');
        SearchPlanRevItem(planTp, planCd, grid.collectionView.items.indexOf(GetLatestPlanRev(planTp)));
        FocusPlanRev(planTp);
    }
}

// 2026-09-30 [설비그룹·설비별 점검계획 탭] 우측 상단 REV 목록 조회 (REV가 있으면 맨 위 REV 선택 이벤트로 정기점검 조회, 없으면 작업본 바로 조회)
// 2026-10-06 [개정 이력] R03 전용 프로시저로 REV 조회·저장 처리
function SearchPlanRev(planTp, planCd) {
    var gridId = planTp == 'G' ? 'grid_GRP_REV' : 'grid_EQM_REV';
    var maria = new ItsMaria('EQM1001_R03', 'LIST_PLAN_REV');
    maria.AddParam('PLANTP', planTp);
    maria.AddParam('PLANCD', planCd);
    maria.CallProc();
    if (maria.isError) {
        maria.ShowErrMsg();
        return;
    }

    LoadPlanGrid(gridId, function () {
        ItsGrid.SetStore(gridId, maria.store);
    }, true);

    if (ItsGrid.Length(gridId) == 0) {
        SearchPlanRevItem(planTp, planCd, 0);
    }
}

// 2026-09-30 [설비그룹·설비별 점검계획 탭] 선택한 REV의 우측 하단 정기점검 조회 (맨 위 REV: 작업본 편집, 이전 REV: 승인본 조회 전용)
// 2026-10-06 [개정 이력] R03 전용 프로시저로 REV 조회·저장 처리
function SearchPlanRevItem(planTp, planCd, rowIndex) {
    var revGridId = planTp == 'G' ? 'grid_GRP_REV' : 'grid_EQM_REV';
    var itemGridId = planTp == 'G' ? 'grid_GRP2' : 'grid3';
    // 2026-10-07 설비그룹·설비별 점검계획 탭: 최신 승인본에서 변경 시 새 REV, 이전 REV는 조회 전용
    var rev = GetLatestPlanRev(planTp);
    var isEdit = !rev || ItsGrid.GetValue(revGridId, rowIndex, 'REVNUM') == rev.REVNUM;
    var maria;

    if (!planCd) {
        ItsGrid.Clear(itemGridId);
        SetPlanEditButton(planTp, true, '');
        return;
    }

    if (!isEdit || (rev && rev.APRVSTT == 'A')) {
        maria = new ItsMaria('EQM1001_R03', 'LIST_PLAN_REV_ITEM');
        maria.AddParam('PLANTP', planTp);
        maria.AddParam('PLANCD', planCd);
        maria.AddParam('REVNUM', ItsGrid.GetValue(revGridId, rowIndex, 'REVNUM'));
    } else if (planTp == 'G') {
        maria = new ItsMaria('EQM1001_R03', 'LIST_GRP_EQM02');
        maria.AddParam('EQMGRP', planCd);
    } else {
        maria = new ItsMaria('EQM1001_R03', 'LIST_MSTEQM_EQM02');
        maria.AddParam('FANO', planCd);
    }

    maria.CallProc();
    if (maria.isError) {
        maria.ShowErrMsg();
        return;
    }

    ItsGrid.SetStore(itemGridId, maria.store.YnToBool('USEYN'));
    SetPlanEditButton(planTp, isEdit, isEdit ? '' : ItsGrid.GetValue(revGridId, rowIndex, 'REVNM'));
}

// 2026-09-30 [설비그룹·설비별 점검계획 탭] 우측 하단 복사·추가·저장·삭제 버튼 표시·숨김 및 제목에 조회 중인 REV 표시
// 2026-10-07 설비그룹·설비별 점검계획 탭: 최신 승인 REV에서 새 개정 허용
function SetPlanEditButton(planTp, isEdit, revNm) {
    var prefix = planTp == 'G' ? 'bdiv_GRP_btn_' : 'bdiv3_btn_';
    var arrBtn = ['COPY', 'ADD', 'SAVE', 'DEL'];
    var rev = GetLatestPlanRev(planTp);
    var isApproved = isEdit && rev && rev.APRVSTT == 'A';

    isPlanEdit[planTp] = isEdit;
    for (var i = 0; i < arrBtn.length; i++) {
        if (isEdit) {
            ItsButton.Show(prefix + arrBtn[i]);
        } else {
            ItsButton.Hide(prefix + arrBtn[i]);
        }
    }

    if (isEdit && !isApproved) {
        ItsButton.Show(planTp == 'G' ? 'btn_GRP_REV_SAVE' : 'btn_EQM_REV_SAVE');
    } else {
        ItsButton.Hide(planTp == 'G' ? 'btn_GRP_REV_SAVE' : 'btn_EQM_REV_SAVE');
    }

    var title = isApproved ? '■ 정기점검 (' + rev.REVNM + ' 승인본 · 변경 시 새 REV)' :
        isEdit ? '■ 정기점검' : '■ 정기점검 (' + revNm + ' 승인본 · 조회 전용)';
    ItsLabel.SetText(planTp == 'G' ? 'lbl_GRP_ITEM' : 'lbl_EQM_ITEM', title);
}

// 2026-09-30 [설비그룹·설비별 점검계획 탭] 우측 상단 진행 중 REV 개정내용 저장
// 2026-10-06 [개정 이력] R03 전용 프로시저로 REV 조회·저장 처리
function SavePlanRev(planTp) {
    var gridId = planTp == 'G' ? 'grid_GRP_REV' : 'grid_EQM_REV';
    var planCd = GetPlanCd(planTp);
    ItsGrid.FinishEditing(gridId);
    // 2026-10-02 [개정 이력 그리드] 진행 중 REV 확인은 프로시저(SAVE_PLAN_REV)에서 처리 (REV가 없으면 빈 값 전달)
    var rev = GetLatestPlanRev(planTp);

    // 2026-10-07 설비그룹·설비별 점검계획 탭: 개정내용 저장, 선택 위치 유지
    var save = function () {
        var maria = new ItsMaria('EQM1001_R03', 'SAVE_PLAN_REV');
        maria.AddParam('PLANTP', planTp);
        maria.AddParam('PLANCD', planCd || '');
        maria.AddParam('REVNUM', rev ? rev.REVNUM : '');
        maria.AddParam('REMARK', rev ? (rev.REMARK || '') : '');
        maria.CallProc();
        if (maria.isError) {
            maria.ShowErrMsg();
            return;
        }
        ItsMsg.Toast('개정내용 저장이 완료되었습니다.');
        RefreshPlanRev(planTp, planCd);
    };
    if (planTp == 'G') {
        // 2026-10-08 [설비그룹 점검계획 탭] 개정내용 저장 확인 메시지
        ItsMsg.Confirm('개정내용 저장하시겠습니까?', save);
    } else {
        save();
    }
}

// 2026-09-30 [설비그룹·설비별 점검계획 탭] 정기점검 저장 후 진행 중 REV 개정내용 칸으로 이동
function FocusPlanRev(planTp) {
    var gridId = planTp == 'G' ? 'grid_GRP_REV' : 'grid_EQM_REV';
    var grid = ItsGrid.Get(gridId);
    var rev = GetLatestPlanRev(planTp);
    if (rev && rev.APRVSTT != 'A') {
        ItsGrid.Focus(gridId, grid.collectionView.items.indexOf(rev), 'REMARK');
        // 2026-10-08 [설비그룹·설비별 점검계획 탭] 정기점검 저장 후 개정내용 입력 유도 알림 간소화
        ItsMsg.Toast('개정내용을 입력 후 저장해주세요.');
    }
}

// 2026-09-30 [설비그룹 점검계획 탭] REV 선택 시 우측 하단 정기점검 조회
ItsGrid.Event('grid_GRP_REV').onSelect = function (rowIndex, field) {
    SearchPlanRevItem('G', GetPlanCd('G'), rowIndex);
};

// 2026-09-30 [설비별 점검계획 탭] REV 선택 시 우측 하단 정기점검 조회
ItsGrid.Event('grid_EQM_REV').onSelect = function (rowIndex, field) {
    SearchPlanRevItem('E', GetPlanCd('E'), rowIndex);
};

// 2026-09-30 [설비그룹 점검계획 탭] 개정내용은 새로 등록된 진행 중(대기) REV 행(맨 위)에서만 입력, 승인된 REV 행은 수정 불가
ItsGrid.Event('grid_GRP_REV').onBeginningEdit = function (rowIndex, field, value) {
    var rev = GetLatestPlanRev('G');
    if (!rev || field != 'REMARK' || ItsGrid.GetValue('grid_GRP_REV', rowIndex, 'REVNUM') != rev.REVNUM || rev.APRVSTT == 'A') {
        throw '';
    }
};

// 2026-09-30 [설비별 점검계획 탭] 개정내용은 새로 등록된 진행 중(대기) REV 행(맨 위)에서만 입력, 승인된 REV 행은 수정 불가
ItsGrid.Event('grid_EQM_REV').onBeginningEdit = function (rowIndex, field, value) {
    var rev = GetLatestPlanRev('E');
    if (!rev || field != 'REMARK' || ItsGrid.GetValue('grid_EQM_REV', rowIndex, 'REVNUM') != rev.REVNUM || rev.APRVSTT == 'A') {
        throw '';
    }
};

// 2026-09-30 [설비그룹 점검계획 탭] 이전 REV 승인본 조회 중에는 우측 하단 정기점검 편집 불가
ItsGrid.Event('grid_GRP2').onBeginningEdit = function (rowIndex, field, value) {
    if (!isPlanEdit.G) {
        throw '';
    }
};

// 2026-09-30 [설비별 점검계획 탭] 이전 REV 승인본 조회 중에는 우측 하단 정기점검 편집 불가
ItsGrid.Event('grid3').onBeginningEdit = function (rowIndex, field, value) {
    if (!isPlanEdit.E) {
        throw '';
    }
};

// 2026-09-30 [설비그룹 점검계획 탭] 우측 상단 개정내용 저장
ItsButton.Event('btn_GRP_REV_SAVE').onClick = function () {
    SavePlanRev('G');
};

// 2026-09-30 [설비별 점검계획 탭] 우측 상단 개정내용 저장
ItsButton.Event('btn_EQM_REV_SAVE').onClick = function () {
    SavePlanRev('E');
};

// 2026-10-06 개정 이력: 선택한 리비전 정보
function GetPlanRev(planTp, rowIndex) {
    var gridId = planTp == 'G' ? 'grid_GRP_REV' : 'grid_EQM_REV';
    ItsGrid.FinishEditing(gridId);
    var idx = rowIndex == undefined ? ItsGrid.GetCurrentIndex(gridId) : rowIndex;
    if (idx < 0 || idx >= ItsGrid.Length(gridId) || !GetPlanCd(planTp)) {
        ItsMsg.Toast('리비전을 선택해주세요.');
        return null;
    }
    return {
        planTp: planTp,
        planCd: GetPlanCd(planTp),
        revNum: ItsGrid.GetValue(gridId, idx, 'REVNUM'),
        revNm: ItsGrid.GetValue(gridId, idx, 'REVNM'),
        remark: ItsGrid.GetValue(gridId, idx, 'REMARK') || ''
    };
}

// 2026-10-06 개정 이력: 승인 확인
function SavePlanStatus(planTp) {
    var rev = GetPlanRev(planTp);
    if (!rev) {
        return;
    }
    // 2026-10-06 개정 이력: 개정내용이 없으면 승인 차단
    if (!rev.remark.trim()) {
        ItsMsg.Toast('개정내용 저장 후 승인해주세요.');
        return;
    }
    SavePlanRevStatus(rev);
}

// 2026-10-06 개정 이력: 선택 REV 승인 저장 후 대상 목록 갱신
function SavePlanRevStatus(rev) {
    ItsMsg.Confirm(rev.planCd + ' ' + rev.revNm + '을 승인하시겠습니까?', function () {
        var maria = new ItsMaria('EQM1001_R03', 'SAVE_PLAN_STATUS');
        maria.AddParam('PLANTP', rev.planTp);
        maria.AddParam('PLANCD', rev.planCd);
        maria.AddParam('REVNUM', rev.revNum);
        maria.AddParam('REMARK', rev.remark);
        maria.AddParam('APRVSTT', 'A');
        maria.AddParam('REJREASON', '');
        maria.CallProc();
        if (maria.isError) {
            maria.ShowErrMsg();
            return;
        }
        // 2026-10-07 개정 이력: 선택 위치를 유지하며 처리한 REV만 갱신
        if (RefreshPlanRev(rev.planTp, rev.planCd)) {
            SearchPlanRevItem(rev.planTp, rev.planCd, ItsGrid.GetCurrentIndex(rev.planTp == 'G' ? 'grid_GRP_REV' : 'grid_EQM_REV'));
        }
        ItsMsg.Toast(rev.revNm + ' 승인 처리가 완료되었습니다.');
    });
}

// 2026-10-06 개정 이력: 계획서 출력
// 2026-10-07 설비그룹·설비별 점검계획 탭: 선택 대상의 최신 계획·전체 개정이력 출력
function PrintPlanRev(planTp) {
    var gridId = planTp == 'G' ? 'grid_GRP1' : 'grid1';
    if (ItsGrid.GetCurrentIndex(gridId) < 0) {
        ItsMsg.Toast(planTp == 'G' ? '설비그룹을 선택해주세요.' : '설비를 선택해주세요.');
        return;
    }
    var planCd = GetPlanCd(planTp);
    if (!planCd) {
        ItsMsg.Toast(planTp == 'G' ? '설비그룹을 선택해주세요.' : '설비를 선택해주세요.');
        return;
    }
    var rpt = new ItsXtraRpt('EQM1001_S05A');
    rpt.FileName('제조설비_정기점검계획서_' + planCd);
    rpt.AddParam('PLANTP', planTp);
    rpt.AddParam('PLANCD', planCd);
    rpt.CallPop();
    if (rpt.isError) {
        ItsMsg.Alert(rpt.errMessage);
    }
}

// 2026-10-06 설비그룹 점검계획 탭: 승인·계획서 출력 버튼
ItsButton.Event('btn_GRP_APPROVE').onClick = function () { SavePlanStatus('G'); };
ItsButton.Event('btn_GRP_PLAN_RPT').onClick = function () { PrintPlanRev('G'); };

// 2026-10-06 설비별 점검계획 탭: 승인·계획서 출력 버튼
ItsButton.Event('btn_EQM_APPROVE').onClick = function () { SavePlanStatus('E'); };
ItsButton.Event('btn_EQM_PLAN_RPT').onClick = function () { PrintPlanRev('E'); };
