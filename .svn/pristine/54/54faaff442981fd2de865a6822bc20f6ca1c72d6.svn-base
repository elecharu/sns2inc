/// <reference path="../../Script/reference.js" />

// 2026-09-16 화면 초기 로드 시 메인 그리드(grid1) 및 팝업 점검 그리드(grid2, grid3) 생성 및 조회년도 기본값 설정
ItsPage.Load = function () {

    ItsGrid.Create('grid1', { isCheckBoxGrid: false }, [
        column.create('설비코드', 'EQMCD', { width: 100, align: 'center' }),
        column.create('설비명', 'EQMNM', { width: 250 }),
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

        column.split()
    ]);

    // 2026-09-16 메인 그리드(grid1) 1~12월 점검상태(점검필요/점검완료) 텍스트 색상 지정 및 클릭 이벤트 바인딩
    ItsGrid.Get('grid1').formatItem.addHandler(function (s, e) {
        if ((s.columns[e.col].binding == 'M01' || s.columns[e.col].binding == 'M02' || s.columns[e.col].binding == 'M03' || s.columns[e.col].binding == 'M04' || s.columns[e.col].binding == 'M05'
            || s.columns[e.col].binding == 'M06' || s.columns[e.col].binding == 'M07' || s.columns[e.col].binding == 'M08' || s.columns[e.col].binding == 'M09' || s.columns[e.col].binding == 'M10'
            || s.columns[e.col].binding == 'M11' || s.columns[e.col].binding == 'M12')
            && e.panel != s.columnHeaders       // 컬럼헤더 제외
            && e.panel != s.columnFooters) {    // 총계 제외

            var html = e.cell.innerHTML;
            var value = ItsGrid.GetValue('grid1', e.row, s.columns[e.col].binding);

            var color = '#337ab7';

            if (value == '점검완료')
                color = '#1DDB16';

            e.cell.innerHTML = '<a href="javascript:void(0);" style="color:' + color + '" onclick="ItsGrid.Event(\'grid1\').onDoubleClick(' + e.row + ',\'' + s.columns[e.col].binding + '\'); return false;">' + html + '</a>';
        }
    });

    ItsGrid.Create('grid2', { isCheckBoxGrid: false, isSubTotalGrid: false }, [
        column.create('점검코드', 'CHKKNDCD', { width: 80, align: 'center' }),
        column.create('점검명', 'CHKKNDNM', { width: 290, readOnly: true }),
        column.create('점검항목', 'CHKLOC', { width: 110, columnType: enumColumnTypes.combo, gpcd: "CHKLOC", readOnly: true }),
        column.create('점검방법', 'CHKMTH', { width: 80, columnType: enumColumnTypes.combo, gpcd: 'CHKMTH', readOnly: true }),
        column.create('점검값구분', 'CHKVALTP', { width: 90, columnType: enumColumnTypes.combo, gpcd: 'CHKVALTP', readOnly: true }),
        column.create('점검값', 'CHKVALUE', { width: 80, readOnly: false }),
        column.split()
    ]);

    ItsGrid.Create('grid3', { isCheckBoxGrid: false, isSubTotalGrid: false }, [
        column.create('점검코드', 'CHKKNDCD', { width: 80, align: 'center' }),
        column.create('점검명', 'CHKKNDNM', { width: 290, readOnly: true }),
        column.create('점검항목', 'CHKLOC', { width: 110, columnType: enumColumnTypes.combo, gpcd: "CHKLOC", readOnly: true }),
        column.create('점검방법', 'CHKMTH', { width: 80, columnType: enumColumnTypes.combo, gpcd: 'CHKMTH', readOnly: true }),
        column.create('점검값구분', 'CHKVALTP', { width: 90, columnType: enumColumnTypes.combo, gpcd: 'CHKVALTP', readOnly: true }),
        column.create('점검값', 'CHKVALUE', { width: 80, readOnly: false }),
        column.split()
    ]);

    ItsCombo.SetValueByIndex('cmb_SYEAR', 4);
};

/* 메인 영역 이벤트 */

// 2026-09-16 검색 조건(sdiv1) 기준 설비별 정기점검 연간 계획 및 점검상태 목록 조회 (grid1)
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

// 2026-09-16 메인 그리드(grid1) 특정 월 점검상태 클릭 시 점검등록(pop1) 또는 점검수정(pop2) 팝업 오픈
ItsGrid.Event('grid1').onDoubleClick = function (rowindex, field) {
    var CellValue = ItsGrid.GetValue('grid1', rowindex, field);
    var EQMCD = ItsGrid.GetValue('grid1', rowindex, 'EQMCD');
    var YEAR = ItsGrid.GetValue('grid1', rowindex, 'YEAR');
    var MONTH = '';

    if (field == 'M01' || field == 'M02' || field == 'M03' || field == 'M04' || field == 'M05' || field == 'M06' || field == 'M07' || field == 'M08' || field == 'M09' || field == 'M10'
        || field == 'M11' || field == 'M12') {
        MONTH = field.substr(1, 2);
    }

    if (MONTH != '') {
        if (CellValue == '점검필요') {
            LIST_CHKPLANEQM_EQM02(EQMCD, YEAR + '-' + MONTH);
            ItsPop.Open('pop1');
        }
        else if (CellValue == '점검완료') {
            SEARCH_CHKRSTEQM(EQMCD, YEAR + '-' + MONTH);
            ItsPop.Open('pop2');
        }
    }
};

// 2026-09-16 정기점검 등록 모달(pop1) 상단 패널 초기화 및 해당 설비의 점검항목 목록(grid2) 조회
var LIST_CHKPLANEQM_EQM02 = function (EQMCD, YYYYMM) {
    ItsPage.InitData('pdiv1');

    var maria = new ItsMaria('EQM1001_R04', 'LIST_CHKPLANEQM_EQM02');

    maria.AddParam('EQMCD', EQMCD);

    maria.CallProc();

    if (maria.isError) {
        maria.ShowErrMsg();
        return;
    }

    ItsFind.SetValue('pop1_find_EQMCD', EQMCD);
    ItsText.SetValue('txt_YYYYMM', YYYYMM);

    ItsGrid.SetStore('grid2', maria.store);
};

// 2026-09-16 정기점검 수정 모달(pop2) 상단 패널(pdiv3) 및 해당월 점검실적 항목(grid3) 조회
var SEARCH_CHKRSTEQM = function (EQMCD, YYYYMM) {
    ItsPage.InitData('pdiv3');
    ItsGrid.Clear('grid3');

    var maria = new ItsMaria('EQM1001_R04', 'SEARCH_CHKRSTEQM');

    maria.AddParam('EQMCD', EQMCD);
    maria.AddParam('YYYYMM', YYYYMM);

    maria.CallProc();

    if (maria.isError) {
        maria.ShowErrMsg();
        return;
    }

    ItsPage.SetStore('pdiv3', maria.store.data[0]);
    ItsText.SetValue('pop2_txt_YYYYMM', YYYYMM);
    ItsGrid.SetStore('grid3', maria.storeExtend1);
};

/* 정기점검 등록 팝업 (pop1) 이벤트 */

// 2026-09-16 정기점검 등록 모달(pop1) 상단 입력값 및 그리드(grid2) 점검값 저장
ItsPop.Event('pop1').onAddBtnClick = function () {
    var CHKPLANEQM = ItsGrid.Length('grid2');

    if (CHKPLANEQM == 0) {
        ItsMsg.Toast('해당설비의 정기점검 계획이 존재하지 않습니다.');
        ItsPop.Event('pop1').onCancelBtnClick();
        return;
    }

    var maria = new ItsMaria('EQM1001_R04', 'ADD_CHKRSTEQM');

    maria.AddPanel('pdiv1');

    for (var i = 0; i < ItsGrid.Length('grid2'); i++) {
        maria.AddList('CHKKNDCD_LIST', ItsGrid.GetValue('grid2', i, 'CHKKNDCD'));
        maria.AddList('CHKKNDNM_LIST', ItsGrid.GetValue('grid2', i, 'CHKKNDNM'));
        maria.AddList('CHKLOC_LIST', ItsGrid.GetValue('grid2', i, 'CHKLOC'));
        maria.AddList('CHKMTH_LIST', ItsGrid.GetValue('grid2', i, 'CHKMTH'));
        maria.AddList('CHKVALTP_LIST', ItsGrid.GetValue('grid2', i, 'CHKVALTP'));
        maria.AddList('CHKCYCLE_LIST', ItsGrid.GetValue('grid2', i, 'CHKCYCLE'));
        maria.AddList('CHKVALUE_LIST', ItsGrid.GetValue('grid2', i, 'CHKVALUE'));
    }

    maria.CallProc();

    if (maria.isError) {
        maria.ShowErrMsg();
        return;
    }

    ItsPop.Close('pop1');
    ItsButton.EventSearch();
};

// 2026-09-16 정기점검 등록 모달(pop1) 닫기 및 메인 목록 재조회
ItsPop.Event('pop1').onCancelBtnClick = function () {
    ItsPop.Close('pop1');
    ItsButton.EventSearch();
};

/* 정기점검 수정 팝업 (pop2) 이벤트 */

// 2026-09-16 정기점검 수정 모달(pop2) 상단 수정값 및 그리드(grid3) 점검값 저장
ItsPop.Event('pop2').onAddBtnClick = function () {
    var maria = new ItsMaria('EQM1001_R04', 'SAVE_CHKRSTEQM');

    maria.AddPanel('pdiv3');

    for (var i = 0; i < ItsGrid.Length('grid3'); i++) {
        maria.AddList('CHKKNDCD_LIST', ItsGrid.GetValue('grid3', i, 'CHKKNDCD'));
        maria.AddList('CHKKNDNM_LIST', ItsGrid.GetValue('grid3', i, 'CHKKNDNM'));
        maria.AddList('CHKLOC_LIST', ItsGrid.GetValue('grid3', i, 'CHKLOC'));
        maria.AddList('CHKMTH_LIST', ItsGrid.GetValue('grid3', i, 'CHKMTH'));
        maria.AddList('CHKVALTP_LIST', ItsGrid.GetValue('grid3', i, 'CHKVALTP'));
        maria.AddList('CHKCYCLE_LIST', ItsGrid.GetValue('grid3', i, 'CHKCYCLE'));
        maria.AddList('CHKVALUE_LIST', ItsGrid.GetValue('grid3', i, 'CHKVALUE'));
    }

    maria.CallProc();

    if (maria.isError) {
        maria.ShowErrMsg();
        return;
    }

    ItsMsg.Alert("수정되었습니다.");
};

// 2026-09-16 정기점검 수정 모달(pop2) 현재 점검실적 삭제
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

// 2026-09-16 정기점검 수정 모달(pop2) 닫기 및 메인 목록 재조회
ItsPop.Event('pop2').onCancelBtnClick = function () {
    ItsPop.Close('pop2');
    ItsButton.EventSearch();
};

/* 점검값 입력 그리드 (grid2, grid3) 이벤트 */

// 2026-09-16 정기점검 등록 팝업 그리드(grid2) 점검값(CHKVALUE) 입력 시 검사타입(03: OK/NG, 기타: 숫자) 유효성 검증 및 자동 변환
ItsGrid.Event('grid2').onChanged = function (rowIndex, field) {
    if (field !== 'CHKVALUE') return;

    var CHKVALTP = ItsGrid.GetValue('grid2', rowIndex, 'CHKVALTP');
    var VALUE = ItsGrid.GetValue('grid2', rowIndex, 'CHKVALUE');

    // 03: 외관/기능 검사 (OK / NG 판정)
    if (CHKVALTP === '03') {
        if (VALUE) {
            VALUE = VALUE.toString().trim().toUpperCase();
        }

        if (VALUE === 'OK') {
            ItsGrid.SetValue('grid2', rowIndex, 'CHKVALUE', 'OK');
        } else if (VALUE === 'NG') {
            ItsGrid.SetValue('grid2', rowIndex, 'CHKVALUE', 'NG');
        } else {
            ItsGrid.SetValue('grid2', rowIndex, 'CHKVALUE', '');
        }
    } else {
        var isValidNumber = /^-?\d+(\.\d+)?$/.test(VALUE);

        if (!isValidNumber) {
            ItsGrid.SetValue('grid2', rowIndex, 'CHKVALUE', '');
        } else {
            var num = Number(VALUE);
            ItsGrid.SetValue('grid2', rowIndex, 'CHKVALUE', num);
        }
    }
};

// 2026-09-16 정기점검 수정 팝업 그리드(grid3) 점검값(CHKVALUE) 입력 시 검사타입(03: OK/NG, 기타: 숫자) 유효성 검증 및 자동 변환
ItsGrid.Event('grid3').onChanged = function (rowIndex, field) {
    if (field !== 'CHKVALUE') return;

    var CHKVALTP = ItsGrid.GetValue('grid3', rowIndex, 'CHKVALTP');
    var VALUE = ItsGrid.GetValue('grid3', rowIndex, 'CHKVALUE');

    // 03: 외관/기능 검사 (OK / NG 판정)
    if (CHKVALTP === '03') {
        if (VALUE) {
            VALUE = VALUE.toString().trim().toUpperCase();
        }

        if (VALUE === 'OK') {
            ItsGrid.SetValue('grid3', rowIndex, 'CHKVALUE', 'OK');
        } else if (VALUE === 'NG') {
            ItsGrid.SetValue('grid3', rowIndex, 'CHKVALUE', 'NG');
        } else {
            ItsGrid.SetValue('grid3', rowIndex, 'CHKVALUE', '');
        }
    } else {
        var isValidNumber = /^-?\d+(\.\d+)?$/.test(VALUE);

        if (!isValidNumber) {
            ItsGrid.SetValue('grid3', rowIndex, 'CHKVALUE', '');
        } else {
            var num = Number(VALUE);
            ItsGrid.SetValue('grid3', rowIndex, 'CHKVALUE', num);
        }
    }
};
