/// <reference path="../../Script/reference.js" />

/* 페이지 로드 시 수행 */
ItsPage.Load = function () {

    ItsGrid.Create('grid1', { isCheckBoxGrid: false }, [
        column.create('설비코드', 'EQMCD', { width: 100, align: 'center' }),
        column.create('설비명', 'EQMNM', { width: 250 }),
        column.create('년도', 'YEAR', { width: 80, align: 'center' }),

        column.create('1월', 'M01', { width: 105, align: 'center', readOnly: true, multiLine: true }),
        column.create('2월', 'M02', { width: 105, align: 'center', readOnly: true, multiLine: true }),
        column.create('3월', 'M03', { width: 105, align: 'center', readOnly: true, multiLine: true }),
        column.create('4월', 'M04', { width: 105, align: 'center', readOnly: true, multiLine: true }),
        column.create('5월', 'M05', { width: 105, align: 'center', readOnly: true, multiLine: true }),
        column.create('6월', 'M06', { width: 105, align: 'center', readOnly: true, multiLine: true }),
        column.create('7월', 'M07', { width: 105, align: 'center', readOnly: true, multiLine: true }),
        column.create('8월', 'M08', { width: 105, align: 'center', readOnly: true, multiLine: true }),
        column.create('9월', 'M09', { width: 105, align: 'center', readOnly: true, multiLine: true }),
        column.create('10월', 'M10', { width: 105, align: 'center', readOnly: true, multiLine: true }),
        column.create('11월', 'M11', { width: 105, align: 'center', readOnly: true, multiLine: true }),
        column.create('12월', 'M12', { width: 105, align: 'center', readOnly: true, multiLine: true }),

        column.split()
    ]);

    ItsGrid.Get('grid1').autoRowHeights = true;

    // 1~12월 점검상태 색상 및 점검자 줄바꿈 링크 표시
    ItsGrid.Get('grid1').formatItem.addHandler(function (s, e) {
        var field = s.columns[e.col].binding;
        if (e.panel != s.cells || !IS_MONTH(field)) return;

        var val = ItsGrid.GetValue('grid1', e.row, field) || '';
        if (!val) return;

        var color = val.indexOf('점검완료') >= 0 ? '#1DDB16' : '#337ab7';
        var html = e.cell.innerHTML.replace(/\r?\n/g, '<br/>');
        e.cell.innerHTML = '<a href="javascript:void(0);" style="color:' + color + '; display:inline-block; line-height:1.25;" onclick="ItsGrid.Event(\'grid1\').onDoubleClick(' + e.row + ',\'' + field + '\'); return false;">' + html + '</a>';
    });

    ItsGrid.Create('grid2', { isCheckBoxGrid: false, isSubTotalGrid: false }, [
        column.create('적용 REV', 'REVNM', { width: 90, align: 'center', readOnly: true }),
        column.create('계획구분키', 'PLANTP', { hidden: true }),
        column.create('점검코드', 'CHKKNDCD', { width: 80, align: 'center' }),
        column.create('점검명', 'CHKKNDNM', { width: 250, readOnly: true }),
        column.create('점검항목', 'CHKLOC', { width: 110, columnType: enumColumnTypes.combo, gpcd: "CHKLOC", readOnly: true }),
        column.create('점검방법', 'CHKMTH', { width: 80, columnType: enumColumnTypes.combo, gpcd: 'CHKMTH', readOnly: true }),
        column.create('점검값구분', 'CHKVALTP', { width: 90, columnType: enumColumnTypes.combo, gpcd: 'CHKVALTP', readOnly: true }),
        column.create('점검값', 'CHKVALUE', { width: 80, readOnly: false }),
        column.create('특이사항', 'REMARK', { width: 230, readOnly: false }),
        column.split()
    ]);

    ItsGrid.Create('grid3', { isCheckBoxGrid: false, isSubTotalGrid: false }, [
        column.create('적용 REV', 'REVNM', { width: 90, align: 'center', readOnly: true }),
        column.create('계획구분키', 'PLANTP', { hidden: true }),
        column.create('점검코드', 'CHKKNDCD', { width: 80, align: 'center' }),
        column.create('점검명', 'CHKKNDNM', { width: 250, readOnly: true }),
        column.create('점검항목', 'CHKLOC', { width: 110, columnType: enumColumnTypes.combo, gpcd: "CHKLOC", readOnly: true }),
        column.create('점검방법', 'CHKMTH', { width: 80, columnType: enumColumnTypes.combo, gpcd: 'CHKMTH', readOnly: true }),
        column.create('점검값구분', 'CHKVALTP', { width: 90, columnType: enumColumnTypes.combo, gpcd: 'CHKVALTP', readOnly: true }),
        column.create('점검값', 'CHKVALUE', { width: 80, readOnly: false }),
        column.create('특이사항', 'REMARK', { width: 230, readOnly: false }),
        column.split()
    ]);

    ItsCombo.SetValueByIndex('cmb_SYEAR', 4);
};

// 월 컬럼(M01~M12) 여부
function IS_MONTH(field) {
    return /^M(0[1-9]|1[0-2])$/.test(field || '');
}

/* 메인 영역 이벤트 */

// 설비별 정기점검 연간 현황 조회
ItsButton.EventSearch = function () {
    var maria = new ItsMaria('EQM1001_R04', 'LIST_CYCLE_EQMCD');

    maria.AddPanel('sdiv1');

    maria.CallProc();

    if (maria.isError) {
        maria.ShowErrMsg();
        return;
    }

    ItsGrid.SetStore('grid1', maria.store);
    ItsMsg.Toast(ItsMsg.CommonMsg.SearchComplete(maria.store.data.length));
};

// 월 점검상태 클릭 시 점검필요는 등록, 점검완료는 수정 팝업 오픈
ItsGrid.Event('grid1').onDoubleClick = function (rowindex, field) {
    if (!IS_MONTH(field)) return;

    var cellVal = ItsGrid.GetValue('grid1', rowindex, field) || '';
    var EQMCD = ItsGrid.GetValue('grid1', rowindex, 'EQMCD');
    var YYYYMM = ItsGrid.GetValue('grid1', rowindex, 'YEAR') + '-' + field.substr(1, 2);

    if (cellVal.indexOf('점검필요') >= 0) {
        if (LIST_PLAN_EQM02(EQMCD, YYYYMM)) {
            ItsPop.Open('pop1');
        }
    }
    else if (cellVal.indexOf('점검완료') >= 0) {
        if (SEARCH_CHKRSTEQM(EQMCD, YYYYMM)) {
            ItsPop.Open('pop2');
        }
    }
};

// 정기점검 등록 팝업 점검항목 조회
var LIST_PLAN_EQM02 = function (EQMCD, YYYYMM) {
    ItsPage.InitData('pdiv1');
    ShowPlanRev([]);

    var maria = new ItsMaria('EQM1001_R04', 'LIST_PLAN_EQM02');

    maria.AddParam('EQMCD', EQMCD);
    maria.AddParam('YYYYMM', YYYYMM);

    maria.CallProc();

    if (maria.isError) {
        maria.ShowErrMsg();
        return false;
    }

    ItsFind.SetValue('pop1_find_EQMCD', EQMCD);
    ItsText.SetValue('txt_YYYYMM', YYYYMM);

    ItsGrid.SetStore('grid2', maria.store);
    ShowPlanRev(maria.store.data);
    ShowPlanEmp(maria.store.data);
    return true;
};

// 주기관리에서 지정한 해당 월 점검자를 기본 점검자로 표시
function ShowPlanEmp(rows) {
    var row = rows.length > 0 ? rows[0] : {};

    if (row.PLANEMPCD) {
        ItsFind.SetValue('pop1_find_EMPCD', row.PLANEMPCD);
    } else if (row.PLANEMPNM) {
        ItsMsg.Toast('주기관리 점검자(' + row.PLANEMPNM + ')를 사원 목록에서 하나로 찾지 못했습니다. 점검자를 직접 선택해주세요.');
    }
}

// 그룹·설비 적용 계획키 보관
function ShowPlanRev(rows) {
    var row = rows.length > 0 ? rows[0] : {};
    ItsText.SetValue('pop1_txt_REVCD', row.EQMREVCD || '');
    ItsText.SetValue('pop1_txt_GRPREVCD', row.GRPREVCD || '');
}

// 정기점검 수정 팝업 실적 조회
var SEARCH_CHKRSTEQM = function (EQMCD, YYYYMM) {
    ItsPage.InitData('pdiv3');
    ItsGrid.Clear('grid3');

    var maria = new ItsMaria('EQM1001_R04', 'SEARCH_CHKRSTEQM');

    maria.AddParam('EQMCD', EQMCD);
    maria.AddParam('YYYYMM', YYYYMM);

    maria.CallProc();

    if (maria.isError) {
        maria.ShowErrMsg();
        return false;
    }

    ItsPage.SetStore('pdiv3', maria.store.data[0]);
    ItsText.SetValue('pop2_txt_YYYYMM', YYYYMM);
    ItsGrid.SetStore('grid3', maria.storeExtend1);
    return true;
};

// 점검항목 그리드 값을 저장 파라미터 목록에 추가
function ADD_CHK_LIST(maria, gridId) {
    for (var i = 0; i < ItsGrid.Length(gridId); i++) {
        maria.AddList('CHKKNDCD_LIST', ItsGrid.GetValue(gridId, i, 'CHKKNDCD'));
        maria.AddList('PLANTP_LIST', ItsGrid.GetValue(gridId, i, 'PLANTP'));
        maria.AddList('CHKVALUE_LIST', ItsGrid.GetValue(gridId, i, 'CHKVALUE'));
        maria.AddList('REMARK_LIST', ItsGrid.GetValue(gridId, i, 'REMARK'));
    }
}

/* 정기점검 등록 팝업 (pop1) 이벤트 */

// 정기점검 등록 저장
ItsPop.Event('pop1').onAddBtnClick = function () {
    var maria = new ItsMaria('EQM1001_R04', 'ADD_CHKRSTEQM');

    maria.AddPanel('pdiv1');
    ADD_CHK_LIST(maria, 'grid2');

    maria.CallProc();

    if (maria.isError) {
        maria.ShowErrMsg();
        return;
    }

    ItsPop.Close('pop1');
    ItsButton.EventSearch();
};

// 정기점검 등록 팝업 닫기
ItsPop.Event('pop1').onCancelBtnClick = function () {
    ItsPop.Close('pop1');
    ItsButton.EventSearch();
};

/* 정기점검 수정 팝업 (pop2) 이벤트 */

// 정기점검 수정 저장
ItsPop.Event('pop2').onAddBtnClick = function () {
    var maria = new ItsMaria('EQM1001_R04', 'SAVE_CHKRSTEQM');

    maria.AddPanel('pdiv3');
    ADD_CHK_LIST(maria, 'grid3');

    maria.CallProc();

    if (maria.isError) {
        maria.ShowErrMsg();
        return;
    }

    ItsMsg.Alert("수정되었습니다.", function () {
        ItsPop.Close('pop2');
        ItsButton.EventSearch();
    });
};

// 정기점검 실적 삭제
ItsButton.Event('pop2_btn_DELETE_CHKRSTEQM').onClick = function () {
    ItsMsg.Confirm("정기점검이력을 [삭제] 하시겠습니까?", function () {
        var maria = new ItsMaria('EQM1001_R04', 'DELETE_CHKRSTEQM');

        maria.AddParam('CHKRSTKEY', ItsText.GetValue('pop2_txt_CHKRSTKEY'));

        maria.CallProc();

        if (maria.isError) {
            maria.ShowErrMsg();
            return;
        }

        ItsPop.Close('pop2');
        ItsButton.EventSearch();
    });
};

// 정기점검 수정 팝업 닫기
ItsPop.Event('pop2').onCancelBtnClick = function () {
    ItsPop.Close('pop2');
    ItsButton.EventSearch();
};

/* 점검값 입력 그리드 (grid2, grid3) 이벤트 */

// 점검값 입력 보정 (03: OK/NG, 그 외: 숫자)
function CHECK_CHKVALUE(gridId, rowIndex) {
    var CHKVALTP = ItsGrid.GetValue(gridId, rowIndex, 'CHKVALTP');
    var VALUE = (ItsGrid.GetValue(gridId, rowIndex, 'CHKVALUE') || '').toString().trim();

    if (CHKVALTP === '03') {
        VALUE = VALUE.toUpperCase();
        ItsGrid.SetValue(gridId, rowIndex, 'CHKVALUE', (VALUE === 'OK' || VALUE === 'NG') ? VALUE : '');
    } else {
        ItsGrid.SetValue(gridId, rowIndex, 'CHKVALUE', /^-?\d+(\.\d+)?$/.test(VALUE) ? Number(VALUE) : '');
    }
}

ItsGrid.Event('grid2').onChanged = function (rowIndex, field) {
    if (field === 'CHKVALUE') CHECK_CHKVALUE('grid2', rowIndex);
};

ItsGrid.Event('grid3').onChanged = function (rowIndex, field) {
    if (field === 'CHKVALUE') CHECK_CHKVALUE('grid3', rowIndex);
};
