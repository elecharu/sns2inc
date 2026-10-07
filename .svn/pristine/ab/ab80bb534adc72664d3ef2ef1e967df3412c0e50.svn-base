/// <reference path="../../Script/reference.js" />

var CHKRSTKEY = '', BASEDATE = '', TOOLGR = '', TOOLCD = '';
var rowNum = '';

// 2026-10-06 페이지 로드 시 금형 점검 기본 설정 및 그리드 초기화
ItsPage.Load = function () {
    ItsDate.SetValue('b1date_BASEDATE', ItsHelper.GetYearMonthDay());
    grade();

    ItsTextArea.SetValue('tea_CHECKREMARK', '대상금형 정비기준 : 경정비 및 중정비 해당 금형\n경정비 : 매 5, 000 Shot 마다 실시\n중정비 : D등급 매회 주조생산시 실시\n주) 정비의 의미는 수리 난이도가 아닌 단수 "Shot수" 를 의미함\n    제외 대상 기준:\n    1. 양산 Item이나 6개월 이상 미사용 금형(Ex 증작금형 존재)\n    2. 단종된 Item(6개월 이상 양산 無)\n    3. SVC품 금형');

    ItsGrid.Create('grid_TOOL', {}, [
        column.create('금형코드', 'TOOLCD', { width: 80 }),
        column.create('금형명', 'TOOLNM', { width: 120 }),
        column.create('등록여부', 'SAVEYN', { width: 40, columnType: enumColumnTypes.check }),
        column.create('금형그룹', 'TOOLGR', { width: 120, hidden: true })
    ]);

    ItsGrid.Create('grid_List', {}, [
        column.create('점검키', 'CHKRSTKEY', { width: 120, hidden: true }),
        column.create('점검일자', 'BASEDATE', { width: 80, columnType: enumColumnTypes.date, align: 'center' }),
        column.create('기준타수', 'CURCNT', { width: 50 })
    ]);

    ItsGrid.Create('grid_PURI', { allowMerging: 'Cells' }, [
        column.create('금 형 등 급', 'REF01', { width: 120 }),
        column.create('세척, 정기점검', 'REF02', { width: 200 }),
        column.create('비고', 'REF03', { width: 250, allowMerging: true, align: 'center' })
    ]);

    ItsGrid.Create('grid_PPURI', { allowMerging: 'Cells' }, [
        column.create('금 형 등 급', 'REF01', { width: 120 }),
        column.create('세척, 정기점검', 'REF02', { width: 200 }),
        column.create('비고', 'REF03', { width: 250, allowMerging: true, align: 'center' })
    ]);

    ItsGrid.Create('grid_A', {}, [
        column.create('점검상세키', 'CHKRSTDKEY', { width: 120, hidden: true }),
        column.create('점검코드', 'CHKKNDCD', { width: 0 }),
        column.create('점검명', 'CHKKNDNM', { width: 150 }),
        column.create('OK/NG', 'CHKVALUE', { width: 60, columnType: enumColumnTypes.check, readOnly: false }),
        column.create('문제점', 'PROBLEM', { width: 180, readOnly: false }),
        column.create('조치사항', 'SOLUTION', { width: 180, readOnly: false })
    ]);

    ItsGrid.Create('grid_B', {}, [
        column.create('점검상세키', 'CHKRSTDKEY', { width: 120, hidden: true }),
        column.create('점검코드', 'CHKKNDCD', { width: 0 }),
        column.create('점검명', 'CHKKNDNM', { width: 150 }),
        column.create('OK/NG', 'CHKVALUE', { width: 60, columnType: enumColumnTypes.check, readOnly: false }),
        column.create('문제점', 'PROBLEM', { width: 180, readOnly: false }),
        column.create('조치사항', 'SOLUTION', { width: 180, readOnly: false })
    ]);

    ItsGrid.Create('grid_C', {}, [
        column.create('점검상세키', 'CHKRSTDKEY', { width: 120, hidden: true }),
        column.create('점검코드', 'CHKKNDCD', { width: 0 }),
        column.create('점검명', 'CHKKNDNM', { width: 150 }),
        column.create('OK/NG', 'CHKVALUE', { width: 60, columnType: enumColumnTypes.check, readOnly: false }),
        column.create('문제점', 'PROBLEM', { width: 180, readOnly: false }),
        column.create('조치사항', 'SOLUTION', { width: 180, readOnly: false })
    ]);

    ItsGrid.Create('grid_D', {}, [
        column.create('점검상세키', 'CHKRSTDKEY', { width: 120, hidden: true }),
        column.create('점검코드', 'CHKKNDCD', { width: 0 }),
        column.create('점검명', 'CHKKNDNM', { width: 150 }),
        column.create('OK/NG', 'CHKVALUE', { width: 60, columnType: enumColumnTypes.check, readOnly: false }),
        column.create('문제점', 'PROBLEM', { width: 180, readOnly: false }),
        column.create('조치사항', 'SOLUTION', { width: 180, readOnly: false })
    ]);

    ItsGrid.Create('grid_PA', {}, [
        column.create('점검코드', 'CHKKNDCD', { width: 0 }),
        column.create('점검명', 'CHKKNDNM', { width: 180 }),
        column.create('OK/NG', 'CHKVALUE', { width: 60, columnType: enumColumnTypes.check, readOnly: false }),
        column.create('문제점', 'PROBLEM', { width: 180, readOnly: false }),
        column.create('조치사항', 'SOLUTION', { width: 180, readOnly: false })
    ]);

    ItsGrid.Create('grid_PB', {}, [
        column.create('점검코드', 'CHKKNDCD', { width: 0 }),
        column.create('점검명', 'CHKKNDNM', { width: 180 }),
        column.create('OK/NG', 'CHKVALUE', { width: 60, columnType: enumColumnTypes.check, readOnly: false }),
        column.create('문제점', 'PROBLEM', { width: 180, readOnly: false }),
        column.create('조치사항', 'SOLUTION', { width: 180, readOnly: false })
    ]);

    ItsGrid.Create('grid_PC', {}, [
        column.create('점검코드', 'CHKKNDCD', { width: 0 }),
        column.create('점검명', 'CHKKNDNM', { width: 180 }),
        column.create('OK/NG', 'CHKVALUE', { width: 60, columnType: enumColumnTypes.check, readOnly: false }),
        column.create('문제점', 'PROBLEM', { width: 180, readOnly: false }),
        column.create('조치사항', 'SOLUTION', { width: 180, readOnly: false })
    ]);

    ItsGrid.Create('grid_PD', {}, [
        column.create('점검코드', 'CHKKNDCD', { width: 0 }),
        column.create('점검명', 'CHKKNDNM', { width: 180 }),
        column.create('OK/NG', 'CHKVALUE', { width: 60, columnType: enumColumnTypes.check, readOnly: false }),
        column.create('문제점', 'PROBLEM', { width: 180, readOnly: false }),
        column.create('조치사항', 'SOLUTION', { width: 180, readOnly: false })
    ]);

    ItsGrid.Create('grid_CHECKSCO', {}, [
        column.create('순서', 'SEQ', { width: 50, columnType: enumColumnTypes.number, hidden: true }),
        column.create('SHOT 수', 'SHOT', { width: 150, readOnly: false }),
        column.create('점수', 'SHOTSCO', { width: 50, columnType: enumColumnTypes.number, readOnly: false }),
        column.create('CHECK', 'SHOTCHK', { width: 60, columnType: enumColumnTypes.check, readOnly: false }),
        column.create('미사용 기간', 'PERIOD', { width: 150, readOnly: false }),
        column.create('점수', 'PERIODSCO', { width: 50, columnType: enumColumnTypes.number, readOnly: false }),
        column.create('CHECK', 'PERIODCHK', { width: 60, columnType: enumColumnTypes.check, readOnly: false }),
        column.create('Slide Core 수량', 'CORE', { width: 150, readOnly: false }),
        column.create('SHOT', 'CORESCO', { width: 50, columnType: enumColumnTypes.number, readOnly: false }),
        column.create('CHECK', 'CORECHK', { width: 60, columnType: enumColumnTypes.check, readOnly: false }),
        column.create('수리 빈도', 'REPAIR', { width: 150, readOnly: false }),
        column.create('점수', 'REPAIRSCO', { width: 50, columnType: enumColumnTypes.number, readOnly: false }),
        column.create('CHECK', 'REPAIRCHK', { width: 60, columnType: enumColumnTypes.check, readOnly: false })
    ]);

    ItsGrid.Create('grid_CHECKSCO_P', {}, [
        column.create('SHOT 수', 'SHOT', { width: 150, readOnly: false }),
        column.create('점수', 'SHOTSCO', { width: 50, columnType: enumColumnTypes.number, readOnly: false }),
        column.create('CHECK', 'SHOTCHK', { width: 60, columnType: enumColumnTypes.check, readOnly: false }),
        column.create('미사용 기간', 'PERIOD', { width: 150, readOnly: false }),
        column.create('점수', 'PERIODSCO', { width: 60, columnType: enumColumnTypes.number, readOnly: false }),
        column.create('CHECK', 'PERIODCHK', { width: 60, columnType: enumColumnTypes.check, readOnly: false }),
        column.create('Slide Core 수량', 'CORE', { width: 150, readOnly: false }),
        column.create('SHOT', 'CORESCO', { width: 50, columnType: enumColumnTypes.number, readOnly: false }),
        column.create('CHECK', 'CORECHK', { width: 60, columnType: enumColumnTypes.check, readOnly: false }),
        column.create('수리 빈도', 'REPAIR', { width: 150, readOnly: false }),
        column.create('점수', 'REPAIRSCO', { width: 50, columnType: enumColumnTypes.number, readOnly: false }),
        column.create('CHECK', 'REPAIRCHK', { width: 60, columnType: enumColumnTypes.check, readOnly: false })
    ]);

    puri('grid_PURI');
    toolGrade('grid_CHECKSCO');
    toolGrade('grid_CHECKSCO_P');
};

// 2026-10-06 금형 목록(grid_TOOL) 선택 시 해당 금형의 점검 이력 및 기준정보 조회
ItsGrid.Event('grid_TOOL').onSelect = function (rowIndex, field) {
    ItsGrid.Clear('grid_A');
    ItsGrid.Clear('grid_B');
    ItsGrid.Clear('grid_C');
    ItsGrid.Clear('grid_D');
    ItsGrid.Clear('grid_PA');
    ItsGrid.Clear('grid_PB');
    ItsGrid.Clear('grid_PC');
    ItsGrid.Clear('grid_PD');
    ItsGrid.Clear('grid_CHECKSCO');
    ItsGrid.Clear('grid_List');

    CHKRSTKEY = '';
    BASEDATE = '';

    ItsPage.InitData('Div2');

    ItsTextArea.SetValue('tea_CHECKREMARK', '대상금형 정비기준 : 경정비 및 중정비 해당 금형\n경정비 : 매 5, 000 Shot 마다 실시\n중정비 : D등급 매회 주조생산시 실시\n주) 정비의 의미는 수리 난이도가 아닌 단수 "Shot수" 를 의미함\n    제외 대상 기준:\n    1. 양산 Item이나 6개월 이상 미사용 금형(Ex 증작금형 존재)\n    2. 단종된 Item(6개월 이상 양산 無)\n    3. SVC품 금형');

    rowNum = rowIndex;
    TOOLGR = ItsGrid.GetValue('grid_TOOL', rowIndex, 'TOOLGR');
    TOOLCD = ItsGrid.GetValue('grid_TOOL', rowIndex, 'TOOLCD');

    gradeList(TOOLGR, '');
    if (window.parent && window.parent.wait_start) window.parent.wait_start();
    setTimeout(function () {
        var maria = new ItsMaria('TOL0003_R05', 'LIST_CHKRSTTOOL');
        maria.AddParam('TOOLCD', ItsGrid.GetValue('grid_TOOL', rowIndex, 'TOOLCD'));
        maria.AddParam('SMONTH', ItsMonth.GetValue('sdiv1_mon_SMONTH'));
        maria.CallProc();
        if (maria.isError) {
            maria.ShowErrMsg();
            if (window.parent && window.parent.wait_end) window.parent.wait_end();
            return;
        }
        ItsGrid.SetStore('grid_List', maria.store);
    });

    grade();
    puri('grid_PURI');
    toolGrade('grid_CHECKSCO');
    gradeList(TOOLGR, '');
    toolSearch(rowIndex);

    if (window.parent && window.parent.wait_end) window.parent.wait_end();
};

// 2026-10-06 점검 이력 목록(grid_List) 선택 시 상세 점검 결과 및 정비내역 조회
ItsGrid.Event('grid_List').onSelect = function (rowIndex, field) {
    CHKRSTKEY = ItsGrid.GetValue('grid_List', rowIndex, 'CHKRSTKEY');
    BASEDATE = ItsGrid.GetValue('grid_List', rowIndex, 'BASEDATE');
   
    if (window.parent && window.parent.wait_start) window.parent.wait_start();
    setTimeout(function () {
        // 금형 타수 정보
        var maria0 = new ItsMaria('TOL0003_R05', 'LIST_TOOLTASU');
        maria0.AddParam('TOOLCD', TOOLCD);
        maria0.CallProc();
        if (maria0.isError) {
            maria0.ShowErrMsg();
            if (window.parent && window.parent.wait_end) window.parent.wait_end();
            return;
        }
        if (maria0.store.Length() == 0) {
            if (window.parent && window.parent.wait_end) window.parent.wait_end();
            return;
        }
        ItsPage.SetStore('BDIVTOOL', maria0.store.data[0]);

        grade();

        // 점검 결과 상세
        var maria = new ItsMaria('TOL0003_R05', 'LIST_GRADERESULT');
        maria.AddParam('CHKRSTKEY', CHKRSTKEY);
        maria.CallProc();
        if (maria.isError) {
            maria.ShowErrMsg();
            if (window.parent && window.parent.wait_end) window.parent.wait_end();
            return;
        }

        if (maria.store.Length() == 0) {
            if (window.parent && window.parent.wait_end) window.parent.wait_end();
            return;
        }

        ItsNum.SetValue('p_CURCNT', maria.store.data[0].CURCNT);
        ItsCombo.SetValue('TOOLCHK', maria.store.data[0].TOOLCHK);
        ItsDate.SetValue('b1date_BASEDATE', maria.store.data[0].BASEDATE);
        ItsFind.SetValue('b1find_EMPCD', maria.store.data[0].EMPCD);
        ItsTextArea.SetValue('Tea_REMARK', maria.store.data[0].REMARK);
    
        ItsGrid.SetStore('grid_A', maria.storeExtend1.YnToBool('CHKVALUE'));
        ItsGrid.SetStore('grid_B', maria.storeExtend2.YnToBool('CHKVALUE'));
        ItsGrid.SetStore('grid_C', maria.storeExtend3.YnToBool('CHKVALUE'));
        ItsGrid.SetStore('grid_D', maria.storeExtend4.YnToBool('CHKVALUE'));
        ItsGrid.SetStore('grid_CHECKSCO', maria.storeExtend5.YnToBool('SHOTCHK').YnToBool('PERIODCHK').YnToBool('CORECHK').YnToBool('REPAIRCHK'));

        ItsTextArea.SetValue('tea_CHECKREMARK', maria.store.data[0].CHECKREMARK);

        if (window.parent && window.parent.wait_end) window.parent.wait_end();
    });
};

// 2026-10-06 선택 금형 상세정보 및 등급 기준 표시
function toolSearch(rowIndex) {
    var maria_TOOL = new ItsMaria('TOL0003_R05', 'LIST_TOOLCD');
    maria_TOOL.AddParam('TOOLCD', ItsGrid.GetValue('grid_TOOL', rowIndex, 'TOOLCD'));
    maria_TOOL.CallProc();
    if (maria_TOOL.isError) {
        maria_TOOL.ShowErrMsg();
        return;
    }
    ItsPage.SetStore('Div3', maria_TOOL.store.data[0]);
    ItsPage.SetStore('PDiv18', maria_TOOL.store.data[0]);

    ItsTextArea.SetValue('tea_CHECKREMARK', '대상금형 정비기준 : 경정비 및 중정비 해당 금형\n경정비 : 매 5, 000 Shot 마다 실시\n중정비 : D등급 매회 주조생산시 실시\n주) 정비의 의미는 수리 난이도가 아닌 단수 "Shot수" 를 의미함\n    제외 대상 기준:\n    1. 양산 Item이나 6개월 이상 미사용 금형(Ex 증작금형 존재)\n    2. 단종된 Item(6개월 이상 양산 無)\n    3. SVC품 금형');

    // 금형 타수 정보
    var maria0 = new ItsMaria('TOL0003_R05', 'LIST_TOOLTASU');
    maria0.AddParam('TOOLCD', TOOLCD);
    maria0.CallProc();
    if (maria0.isError) {
        maria0.ShowErrMsg();
        return;
    }

    ItsText.SetValue('LAB_A1', 'A');
    ItsText.SetValue('LAB_B1', 'B');
    ItsText.SetValue('LAB_C1', 'C');
    ItsText.SetValue('LAB_D1', 'D');

    if (maria0.store.data[0].ANUM == 0) {
        var maria = new ItsMaria('TOL0003_R05', 'LIST_TOOLGRADE');
        maria.AddParam('TOOLCD', TOOLCD);
        maria.CallProc();
        if (maria.isError) {
            maria.ShowErrMsg();
            return;
        }
        ItsText.SetValue('LAB_A2', maria.store.data[0].SHOT);
        ItsText.SetValue('LAB_B2', maria.store.data[1].SHOT);
        ItsText.SetValue('LAB_C2', maria.store.data[2].SHOT);
        ItsText.SetValue('LAB_D2', maria.store.data[3].SHOT);
    }
    else {
        ItsText.SetValue('LAB_A2', maria0.store.data[0].A);
        ItsText.SetValue('LAB_B2', maria0.store.data[0].B);
        ItsText.SetValue('LAB_C2', maria0.store.data[0].C);
        ItsText.SetValue('LAB_D2', maria0.store.data[0].D);
    }
}
var TOOL_search = toolSearch;

// 2026-10-06 금형 목록 조회 (grid_TOOL)
function searchTool() {
    ItsPage.InitData('Div14');
    ItsGrid.Clear('grid_A');
    ItsGrid.Clear('grid_B');
    ItsGrid.Clear('grid_C');
    ItsGrid.Clear('grid_D');
    ItsGrid.Clear('grid_PA');
    ItsGrid.Clear('grid_PB');
    ItsGrid.Clear('grid_PC');
    ItsGrid.Clear('grid_PD');
    ItsGrid.Clear('grid_CHECKSCO');

    ItsTextArea.SetValue('tea_CHECKREMARK', '대상금형 정비기준 : 경정비 및 중정비 해당 금형\n경정비 : 매 5, 000 Shot 마다 실시\n중정비 : D등급 매회 주조생산시 실시\n주) 정비의 의미는 수리 난이도가 아닌 단수 "Shot수" 를 의미함\n    제외 대상 기준:\n    1. 양산 Item이나 6개월 이상 미사용 금형(Ex 증작금형 존재)\n    2. 단종된 Item(6개월 이상 양산 無)\n    3. SVC품 금형');

    var maria = new ItsMaria('TOL0003_R05', 'LIST_TOOLCD');
    maria.AddPanel('sdiv1');
    maria.CallProc();
    if (maria.isError) {
        maria.ShowErrMsg();
        return 0;
    }

    ItsGrid.Setkey('grid_TOOL', 'TOOLCD', ItsGrid.GetValue('grid_TOOL', ItsGrid.GetCurrentIndex('grid_TOOL'), 'TOOLCD'));
    ItsGrid.SetStore('grid_TOOL', maria.store.YnToBool('SAVEYN'));
    return maria.store.Length();
}
var _search = searchTool;

// 2026-10-06 금형 등급 기본 기준 표시
function grade() {
    ItsText.SetValue('LAB_A1', 'A');
    ItsText.SetValue('LAB_B1', 'B');
    ItsText.SetValue('LAB_C1', 'C');
    ItsText.SetValue('LAB_D1', 'D');

    ItsText.SetValue('LAB_A2', '0~25');
    ItsText.SetValue('LAB_B2', '26~50');
    ItsText.SetValue('LAB_C2', '51~75');
    ItsText.SetValue('LAB_D2', '76~100');

    ItsText.SetValue('LAB_PA1', 'A');
    ItsText.SetValue('LAB_PB1', 'B');
    ItsText.SetValue('LAB_PC1', 'C');
    ItsText.SetValue('LAB_PD1', 'D');

    ItsText.SetValue('LAB_PA2', '0~25');
    ItsText.SetValue('LAB_PB2', '26~50');
    ItsText.SetValue('LAB_PC2', '51~75');
    ItsText.SetValue('LAB_PD2', '76~100');
}
var GRADE = grade;

// 2026-10-06 세척 및 점검 주기 정보 조회
function puri(grid) {
    var maria = new ItsMaria('TOL0003_R05', 'LIST_TOOLPURI');
    maria.CallProc();
    if (maria.isError) {
        maria.ShowErrMsg();
        return;
    }
    ItsGrid.SetStore(grid, maria.store);
}
var PURI = puri;

// 2026-10-06 금형 등급 평가 기준 점수 조회
function toolGrade(grid) {
    var maria = new ItsMaria('TOL0003_R05', 'LIST_TOOLGRADE');
    maria.CallProc();
    if (maria.isError) {
        maria.ShowErrMsg();
        return;
    }
    ItsGrid.SetStore(grid, maria.store);
}
var TOOLGRADE = toolGrade;

// 2026-10-06 금형그룹별 A~D 등급 정비 항목 목록 조회
function gradeList(toolGr, gubun) {
    var maria = new ItsMaria('TOL0003_R05', 'LIST_GRADELIST');
    maria.AddParam('TOOLGR', toolGr);
    maria.CallProc();
    if (maria.isError) {
        maria.ShowErrMsg();
        return;
    }

    ItsGrid.SetStore('grid_' + gubun + 'A', maria.store);
    ItsGrid.SetStore('grid_' + gubun + 'B', maria.storeExtend1);
    ItsGrid.SetStore('grid_' + gubun + 'C', maria.storeExtend2);
    ItsGrid.SetStore('grid_' + gubun + 'D', maria.storeExtend3);
}
var GRADELIST = gradeList;

// 2026-10-06 점검등록 팝업 필수 입력값 유효성 검증
function checkErr() {
    if (ItsCombo.GetValue('p_TOOLCHK') == '') {
        ItsMsg.Alert('정비항목은 필수입니다.');
        return false;
    }

    if (ItsDate.GetValue('p_BASEDATE') == '') {
        ItsMsg.Alert('점검일자는 필수입니다.');
        return false;
    }

    if (ItsFind.GetValue('p_EMPCD') == '') {
        ItsMsg.Alert('작업자는 필수입니다.');
        return false;
    }

    return true;
}
var ERR_CHK = checkErr;

// 2026-10-06 점검항목 등록 팝업(pop1) 저장 버튼 이벤트
ItsPop.Event('pop1').onAddBtnClick = function () {
    if (window.parent && window.parent.wait_start) window.parent.wait_start();
    setTimeout(function () {
        if (!checkErr()) {
            if (window.parent && window.parent.wait_end) window.parent.wait_end();
            return;
        }

        var maria = new ItsMaria('TOL0003_R05', 'ADD_GRADE');

        maria.AddParam('TOOLCD', ItsText.GetValue('p_TOOLCD'));
        maria.AddParam('TOOLCHK', ItsCombo.GetValue('p_TOOLCHK'));
        maria.AddParam('BASEDATE', ItsDate.GetValue('p_BASEDATE'));
        maria.AddParam('EMPCD', ItsFind.GetValue('p_EMPCD'));
        maria.AddParam('CURCNT', ItsFind.GetValue('p_CURCNT'));
        maria.AddParam('CHECKREMARK', ItsTextArea.GetValue('tea_CHECKREMARK_P'));

        for (var i = 0; i < ItsGrid.Length('grid_CHECKSCO_P'); i++) {
            maria.AddList('SEQSTR', ItsGrid.GetValue('grid_CHECKSCO_P', i, 'SEQ'));
            maria.AddList('SHOTSTR', ItsGrid.GetValue('grid_CHECKSCO_P', i, 'SHOT'));
            maria.AddList('SHOTSCOSTR', ItsGrid.GetValue('grid_CHECKSCO_P', i, 'SHOTSCO'));
            maria.AddList('SHOTCHKSTR', ItsHelper.ToYn(ItsGrid.GetValue('grid_CHECKSCO_P', i, 'SHOTCHK')));

            maria.AddList('PERIODSTR', ItsGrid.GetValue('grid_CHECKSCO_P', i, 'PERIOD'));
            maria.AddList('PERIODSCOSTR', ItsGrid.GetValue('grid_CHECKSCO_P', i, 'PERIODSCO'));
            maria.AddList('PERIODCHKSTR', ItsHelper.ToYn(ItsGrid.GetValue('grid_CHECKSCO_P', i, 'PERIODCHK')));

            maria.AddList('CORESTR', ItsGrid.GetValue('grid_CHECKSCO_P', i, 'CORE'));
            maria.AddList('CORESCOSTR', ItsGrid.GetValue('grid_CHECKSCO_P', i, 'CORESCO'));
            maria.AddList('CORECHKSTR', ItsHelper.ToYn(ItsGrid.GetValue('grid_CHECKSCO_P', i, 'CORECHK')));

            maria.AddList('REPAIRSTR', ItsGrid.GetValue('grid_CHECKSCO_P', i, 'REPAIR'));
            maria.AddList('REPAIRSCOSTR', ItsGrid.GetValue('grid_CHECKSCO_P', i, 'REPAIRSCO'));
            maria.AddList('REPAIRCHKSTR', ItsHelper.ToYn(ItsGrid.GetValue('grid_CHECKSCO_P', i, 'REPAIRCHK')));
        }

        for (var i = 0; i < ItsGrid.Length('grid_PA'); i++) {
            maria.AddList('CHKKNDCDSTR', ItsGrid.GetValue('grid_PA', i, 'CHKKNDCD'));
            maria.AddList('CHKVALUESTR', ItsHelper.ToYn(ItsGrid.GetValue('grid_PA', i, 'CHKVALUE')));
            maria.AddList('PROBLEMSTR', ItsGrid.GetValue('grid_PA', i, 'PROBLEM'));
            maria.AddList('SOLUTIONSTR', ItsGrid.GetValue('grid_PA', i, 'SOLUTION'));
        }

        for (var i = 0; i < ItsGrid.Length('grid_PB'); i++) {
            maria.AddList('CHKKNDCDSTR', ItsGrid.GetValue('grid_PB', i, 'CHKKNDCD'));
            maria.AddList('CHKVALUESTR', ItsHelper.ToYn(ItsGrid.GetValue('grid_PB', i, 'CHKVALUE')));
            maria.AddList('PROBLEMSTR', ItsGrid.GetValue('grid_PB', i, 'PROBLEM'));
            maria.AddList('SOLUTIONSTR', ItsGrid.GetValue('grid_PB', i, 'SOLUTION'));
        }

        for (var i = 0; i < ItsGrid.Length('grid_PC'); i++) {
            maria.AddList('CHKKNDCDSTR', ItsGrid.GetValue('grid_PC', i, 'CHKKNDCD'));
            maria.AddList('CHKVALUESTR', ItsHelper.ToYn(ItsGrid.GetValue('grid_PC', i, 'CHKVALUE')));
            maria.AddList('PROBLEMSTR', ItsGrid.GetValue('grid_PC', i, 'PROBLEM'));
            maria.AddList('SOLUTIONSTR', ItsGrid.GetValue('grid_PC', i, 'SOLUTION'));
        }

        for (var i = 0; i < ItsGrid.Length('grid_PD'); i++) {
            maria.AddList('CHKKNDCDSTR', ItsGrid.GetValue('grid_PD', i, 'CHKKNDCD'));
            maria.AddList('CHKVALUESTR', ItsHelper.ToYn(ItsGrid.GetValue('grid_PD', i, 'CHKVALUE')));
            maria.AddList('PROBLEMSTR', ItsGrid.GetValue('grid_PD', i, 'PROBLEM'));
            maria.AddList('SOLUTIONSTR', ItsGrid.GetValue('grid_PD', i, 'SOLUTION'));
        }

        maria.AddParam('REMARK', ItsTextArea.GetValue('PTea_REMARK'));

        maria.CallProc();
        if (maria.isError) {
            maria.ShowErrMsg();
            if (window.parent && window.parent.wait_end) window.parent.wait_end();
            return;
        }

        ItsGrid.Event('grid_TOOL').onSelect(ItsGrid.GetCurrentIndex('grid_TOOL'), '');
        ItsPop.Close('pop1');
        if (window.parent && window.parent.wait_end) window.parent.wait_end();
        ItsButton.EventSearch();
    });
};

// 2026-10-06 점검항목 등록 팝업(pop1) 취소 버튼 이벤트
ItsPop.Event('pop1').onCancelBtnClick = function () {
    ItsPop.Close('pop1');
};

// 2026-10-06 금형 목록 조회 버튼 클릭 이벤트
ItsButton.EventSearch = function () {
    rowNum = '';
    TOOLGR = '';
    TOOLCD = '';

    var cnt = searchTool();
    ItsMsg.Toast(ItsMsg.CommonMsg.SearchComplete(cnt));
};

// 2026-10-06 점검항목 추가 버튼 클릭 시 등록 팝업(pop1) 오픈
ItsButton.EventAdd = function () {
    rowNum = ItsGrid.GetCurrentIndex('grid_TOOL');
    TOOLGR = ItsGrid.GetValue('grid_TOOL', rowNum, 'TOOLGR');
    TOOLCD = ItsGrid.GetValue('grid_TOOL', rowNum, 'TOOLCD');

    if (!TOOLCD) {
        ItsMsg.Alert('금형을 먼저 선택해주세요.');
        return;
    }

    ItsPage.InitData('pop1');
    ItsPop.Open('pop1');

    gradeList(TOOLGR, 'P');
    grade();
    puri('grid_PPURI');
    toolGrade('grid_CHECKSCO_P');
    toolSearch(rowNum);

    ItsTextArea.SetValue('tea_CHECKREMARK_P', '대상금형 정비기준 : 경정비 및 중정비 해당 금형\n경정비 : 매 5, 000 Shot 마다 실시\n중정비 : D등급 매회 주조생산시 실시\n주) 정비의 의미는 수리 난이도가 아닌 단수 "Shot수" 를 의미함\n    제외 대상 기준:\n    1. 양산 Item이나 6개월 이상 미사용 금형(Ex 증작금형 존재)\n    2. 단종된 Item(6개월 이상 양산 無)\n    3. SVC품 금형');
};

// 2026-10-06 점검 결과 수정 저장 버튼 이벤트
ItsButton.EventSave = function () {
    if (!CHKRSTKEY) {
        ItsMsg.Alert('수정할 점검 이력을 선택해주세요.');
        return;
    }

    var maria = new ItsMaria('TOL0003_R05', 'UP_GRADERESULT');

    maria.AddParam('CHKRSTKEY', CHKRSTKEY);
    maria.AddParam('TOOLCHK', ItsCombo.GetValue('TOOLCHK'));
    maria.AddParam('BASEDATE', ItsDate.GetValue('b1date_BASEDATE'));
    maria.AddParam('EMPCD', ItsFind.GetValue('b1find_EMPCD'));
    maria.AddParam('REMARK', ItsTextArea.GetValue('Tea_REMARK'));
    maria.AddParam('CHECKREMARK', ItsTextArea.GetValue('tea_CHECKREMARK'));

    for (var i = 0; i < ItsGrid.Length('grid_CHECKSCO'); i++) {
        maria.AddList('SEQSTR', ItsGrid.GetValue('grid_CHECKSCO', i, 'SEQ'));
        maria.AddList('SHOTSTR', ItsGrid.GetValue('grid_CHECKSCO', i, 'SHOT'));
        maria.AddList('SHOTSCOSTR', ItsGrid.GetValue('grid_CHECKSCO', i, 'SHOTSCO'));
        maria.AddList('SHOTCHKSTR', ItsHelper.ToYn(ItsGrid.GetValue('grid_CHECKSCO', i, 'SHOTCHK')));

        maria.AddList('PERIODSTR', ItsGrid.GetValue('grid_CHECKSCO', i, 'PERIOD'));
        maria.AddList('PERIODSCOSTR', ItsGrid.GetValue('grid_CHECKSCO', i, 'PERIODSCO'));
        maria.AddList('PERIODCHKSTR', ItsHelper.ToYn(ItsGrid.GetValue('grid_CHECKSCO', i, 'PERIODCHK')));

        maria.AddList('CORESTR', ItsGrid.GetValue('grid_CHECKSCO', i, 'CORE'));
        maria.AddList('CORESCOSTR', ItsGrid.GetValue('grid_CHECKSCO', i, 'CORESCO'));
        maria.AddList('CORECHKSTR', ItsHelper.ToYn(ItsGrid.GetValue('grid_CHECKSCO', i, 'CORECHK')));

        maria.AddList('REPAIRSTR', ItsGrid.GetValue('grid_CHECKSCO', i, 'REPAIR'));
        maria.AddList('REPAIRSCOSTR', ItsGrid.GetValue('grid_CHECKSCO', i, 'REPAIRSCO'));
        maria.AddList('REPAIRCHKSTR', ItsHelper.ToYn(ItsGrid.GetValue('grid_CHECKSCO', i, 'REPAIRCHK')));
    }

    for (var i = 0; i < ItsGrid.Length('grid_A'); i++) {
        maria.AddList('CHKRSTDKEYSTR', ItsGrid.GetValue('grid_A', i, 'CHKRSTDKEY'));
        maria.AddList('CHKKNDCDSTR', ItsGrid.GetValue('grid_A', i, 'CHKKNDCD'));
        maria.AddList('CHKVALUESTR', ItsHelper.ToYn(ItsGrid.GetValue('grid_A', i, 'CHKVALUE')));
        maria.AddList('PROBLEMSTR', ItsGrid.GetValue('grid_A', i, 'PROBLEM'));
        maria.AddList('SOLUTIONSTR', ItsGrid.GetValue('grid_A', i, 'SOLUTION'));
    }

    for (var i = 0; i < ItsGrid.Length('grid_B'); i++) {
        maria.AddList('CHKRSTDKEYSTR', ItsGrid.GetValue('grid_B', i, 'CHKRSTDKEY'));
        maria.AddList('CHKKNDCDSTR', ItsGrid.GetValue('grid_B', i, 'CHKKNDCD'));
        maria.AddList('CHKVALUESTR', ItsHelper.ToYn(ItsGrid.GetValue('grid_B', i, 'CHKVALUE')));
        maria.AddList('PROBLEMSTR', ItsGrid.GetValue('grid_B', i, 'PROBLEM'));
        maria.AddList('SOLUTIONSTR', ItsGrid.GetValue('grid_B', i, 'SOLUTION'));
    }

    for (var i = 0; i < ItsGrid.Length('grid_C'); i++) {
        maria.AddList('CHKRSTDKEYSTR', ItsGrid.GetValue('grid_C', i, 'CHKRSTDKEY'));
        maria.AddList('CHKKNDCDSTR', ItsGrid.GetValue('grid_C', i, 'CHKKNDCD'));
        maria.AddList('CHKVALUESTR', ItsHelper.ToYn(ItsGrid.GetValue('grid_C', i, 'CHKVALUE')));
        maria.AddList('PROBLEMSTR', ItsGrid.GetValue('grid_C', i, 'PROBLEM'));
        maria.AddList('SOLUTIONSTR', ItsGrid.GetValue('grid_C', i, 'SOLUTION'));
    }

    for (var i = 0; i < ItsGrid.Length('grid_D'); i++) {
        maria.AddList('CHKRSTDKEYSTR', ItsGrid.GetValue('grid_D', i, 'CHKRSTDKEY'));
        maria.AddList('CHKKNDCDSTR', ItsGrid.GetValue('grid_D', i, 'CHKKNDCD'));
        maria.AddList('CHKVALUESTR', ItsHelper.ToYn(ItsGrid.GetValue('grid_D', i, 'CHKVALUE')));
        maria.AddList('PROBLEMSTR', ItsGrid.GetValue('grid_D', i, 'PROBLEM'));
        maria.AddList('SOLUTIONSTR', ItsGrid.GetValue('grid_D', i, 'SOLUTION'));
    }

    maria.CallProc();
    if (maria.isError) {
        maria.ShowErrMsg();
        return;
    }
    ItsGrid.Event('grid_List').onSelect(ItsGrid.GetCurrentIndex('grid_List'), '');
    ItsMsg.Toast(ItsMsg.CommonMsg.SaveComplete());
};

// 2026-10-06 점검 결과 삭제 버튼 이벤트
ItsButton.EventDelete = function () {
    if (!CHKRSTKEY) {
        ItsMsg.Alert('삭제할 자료를 선택해주세요.');
        return;
    }

    ItsMsg.Confirm('선택한 항목을 삭제하시겠습니까?', function () {
        var maria = new ItsMaria('TOL0003_R05', 'DEL_GRADERESULT');
        maria.AddParam('CHKRSTKEY', CHKRSTKEY);
        maria.AddParam('TOOLCD', TOOLCD);
        maria.AddParam('BASEDATE', BASEDATE);
        maria.CallProc();
        if (maria.isError) {
            maria.ShowErrMsg();
            return;
        }
        ItsMsg.Toast(ItsMsg.CommonMsg.DeleteComplete());
        ItsButton.EventSearch();
    });
};
