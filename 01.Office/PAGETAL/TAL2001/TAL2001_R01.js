/// <reference path="../../Script/reference.js" />

/* 페이지 접근 시 수행 */
ItsPage.Load = function () {
    // 검사항목 (사용중인 자주검사 리비전)
    ItsGrid.Create('grid1', { isCheckBoxGrid: false, isSubTotalGrid: false }, [
        column.create('검사항목', 'STDNM', { width: 150 }),
        column.create('세부항목', 'STDPART', { width: 110, align: 'center'  }),
        column.create('세부공정', 'PRCDETAIL', { width: 100, align: 'center', columnType: enumColumnTypes.combo, gpcd: 'PRCDETAIL' }),
        column.create('특성', 'FEATURE', { width: 70, align: 'center' }),
        column.create('검사방법', 'STDCHKTP', { width: 100, align: 'center', columnType: enumColumnTypes.combo, gpcd: 'STDCHKTP' }),
        column.create('검사규격', 'STDJUDGE', { width: 150 }),
        column.create('검사주기', 'STDCYCLE', { width: 100, align: 'center', columnType: enumColumnTypes.combo, gpcd: 'STDCYCLE' }),        
        column.create('검사게이지', 'STDMACHINE', { width: 100, align: 'center', columnType: enumColumnTypes.combo, gpcd: 'STDMACHINE' }),
        //column.create('검사부위', 'STDPOINT', { width: 100, align: 'center', columnType: enumColumnTypes.combo, gpcd: 'STDPOINT' }),
        
        
        column.create('시료수', 'SAMPLESIZE', { width: 60, columnType: enumColumnTypes.number, decimalPrecision: 0 }),
        column.create('최소값', 'MINVAL', { width: 80, align: 'right' }),   // 이 검사일시의 검사이력
        column.create('최대값', 'MAXVAL', { width: 80, align: 'right' }),
        column.create('평균', 'AVG', { width: 80, align: 'right' }),
        column.create('합불판정', 'JUDGENM', { width: 80, align: 'center' }),
        column.create('합불', 'JUDGE', { width: 100, hidden: true }),
        column.create('검사키', 'TQMRSTKEY', { width: 100, hidden: true }),
        column.create('리비전', 'REVCD', { width: 100, hidden: true }),
        column.create('검사항목코드', 'STDCD', { width: 100, hidden: true }),
        column.create('기준값', 'STDVAL', { width: 100, hidden: true }),
        column.create('범위', 'STDRANGE', { width: 100, hidden: true }),
        column.create('오차(-)', 'STDMINUS', { width: 100, hidden: true }),
        column.create('오차(+)', 'STDPLUS', { width: 100, hidden: true }),
    ]);

    // 검사값 (선택한 검사항목의 시료수만큼)
    ItsGrid.Create('grid2', { isCheckBoxGrid: false, isSubTotalGrid: false }, [
        column.create('검사값(L)', 'VALUE', { width: 100, readOnly: false }),
        column.create('검사값(R)', 'VALUE2', { width: 100, readOnly: false }),
        column.create('판정', 'JUDGE', { width: 80, align: 'center' }),   // 측정검사 행별 판정 (화면 표시용, 저장 안 함)
        column.create('검사값키', 'VALUEKEY', { width: 100, hidden: true }),
    ]);

    // 검사값 엔터: 검사값(L) → 같은 줄 검사값(R), 검사값(R) → 다음 줄 검사값(L) (ItsGrid 는 keyActionEnter 'None' 이라 직접 처리)
    var grid2 = ItsGrid.Get('grid2');
    grid2.addEventListener(grid2.hostElement, 'keydown', function (e) {
        if (e.keyCode != 13 || grid2.selection.row < 0 || grid2.selection.col < 0)
            return;

        var row = grid2.selection.row;
        var field = grid2.columns[grid2.selection.col].binding;
        if (field != 'VALUE' && field != 'VALUE2')
            return;

        e.preventDefault();
        e.stopPropagation();
        grid2.finishEditing(false);   // 입력값 확정 (onChanged 자동 합불 판정)

        if (field == 'VALUE')
            EDIT_GRID2(row, 'VALUE2');
        else if (row + 1 < ItsGrid.Length('grid2'))
            EDIT_GRID2(row + 1, 'VALUE');
    }, true);

    ItsText.SetValue('txt_TQMTIME', new Date().format('HH:mm'));   // 검사시간 기본값: 지금 시각
};
/**********************************************************************************************************************************************************************/
// 작업장·공정·라인 선택

// 작업장 변경 시 공정·라인 콤보를 그 작업장 기준으로 바꾸고 다시 조회
ItsCombo.Event('cmb_LINECD').onChanged = function (value, oldValue) {
    ItsCombo.SetRef01('cmb_PRCCD', ItsCombo.GetValue('cmb_LINECD'));
    ItsCombo.SetValue('cmb_PRCCD', '', false);

    ItsCombo.SetRef01('cmb_EQMCD', ItsCombo.GetValue('cmb_LINECD'), false);
    ItsCombo.SetRef02('cmb_EQMCD', '');
    ItsCombo.SetValue('cmb_EQMCD', '', false);

    LIST_STD();
};

// 공정 변경 시 라인 콤보를 그 공정 기준으로 바꾸고 다시 조회
ItsCombo.Event('cmb_PRCCD').onChanged = function (value, oldValue) {
    ItsCombo.SetRef02('cmb_EQMCD', ItsCombo.GetValue('cmb_PRCCD'));
    ItsCombo.SetValue('cmb_EQMCD', '', false);

    LIST_STD();
};

// 라인 변경 시 다시 조회
ItsCombo.Event('cmb_EQMCD').onChanged = function (value, oldValue) {
    LIST_STD();
};

// 검사시간 엔터 시 그 검사일시로 다시 조회
ItsText.Event('txt_TQMTIME').onKeyEnter = function (value, oldValue) {
    LIST_STD();
};
/**********************************************************************************************************************************************************************/
// 조회

// 라인 생산품, 사용중인 자주검사 리비전의 검사항목 조회 (작업장·공정·라인을 다 골랐을 때만)
LIST_STD = function () {
    ItsText.SetValue('txt_ITEMID', '');
    ItsText.SetValue('txt_ITEMCD', '');
    ItsText.SetValue('txt_ITEMNM', '');
    ItsText.SetValue('txt_ITEMSPEC', '');
    ItsGrid.Clear('grid1');
    ItsGrid.Clear('grid2');

    if (ItsCombo.GetValue('cmb_LINECD') == '' || ItsCombo.GetValue('cmb_PRCCD') == '' || ItsCombo.GetValue('cmb_EQMCD') == '') {
        return;
    }

    var maria = new ItsMaria('TAL2001_R01', 'LIST_STD');
    maria.AddParam('LINECD', ItsCombo.GetValue('cmb_LINECD'));
    maria.AddParam('PRCCD', ItsCombo.GetValue('cmb_PRCCD'));
    maria.AddParam('EQMCD', ItsCombo.GetValue('cmb_EQMCD'));
    maria.AddPanel('div2');     // 검사일자(TQMDATE), 검사시간(TQMTIME): 이 검사일시의 검사이력 조회
    maria.CallProc();
    if (maria.isError) {
        maria.ShowErrMsg();
        return;
    }

    // 라인 생산품 (없으면 빈칸)
    if (maria.store.Length() > 0) {
        ItsText.SetValue('txt_ITEMID', maria.store.data[0]["ITEMID"]);
        ItsText.SetValue('txt_ITEMCD', maria.store.data[0]["ITEMCD"]);
        ItsText.SetValue('txt_ITEMNM', maria.store.data[0]["ITEMNM"]);
        ItsText.SetValue('txt_ITEMSPEC', maria.store.data[0]["ITEMSPEC"]);
    }

    // 검사항목
    ItsGrid.SetStore('grid1', maria.storeExtend1);
    ItsGrid.Get('grid1').autoSizeColumns();

    // 불합격 판정은 빨간 글자 (SetStore 가 색을 초기화하므로 그 뒤에)
    for (var i = 0; i < ItsGrid.Length('grid1'); i++) {
        if (ItsGrid.GetValue('grid1', i, 'JUDGE') == 'N')
            ItsGrid.SetCellForeColor('grid1', i, 'JUDGENM', '#FF0000');
    }
    ItsMsg.Toast(ItsMsg.CommonMsg.SearchComplete(maria.storeExtend1.Length()));
};
/**********************************************************************************************************************************************************************/
// 검사값

// 검사항목 선택 시 시료수만큼 검사값 행 생성 (이 검사일시에 저장된 항목이면 저장된 검사값과 합불을 불러옴)
ItsGrid.Event('grid1').onSelect = function (rowIndex) {
    ItsGrid.Clear('grid2');
    ItsCheck.SetValue('check_OK', 'N');
    ItsCheck.SetValue('check_NG', 'N');

    // 측정검사(02)가 아니면 합격을 기본으로 체크 (측정은 검사값 입력으로 자동 판정)
    if (ItsGrid.GetValue('grid1', rowIndex, 'STDCHKTP') != '02')
        ItsCheck.SetValue('check_OK', 'Y');

    var TQMRSTKEY = ItsGrid.GetValue('grid1', rowIndex, 'TQMRSTKEY');
    var isSaved = TQMRSTKEY != null && TQMRSTKEY != '';
    if (isSaved) {
        var maria = new ItsMaria('TAL2001_R01', 'LIST_VALUE');
        maria.AddParam('TQMRSTKEY', TQMRSTKEY);
        maria.AddParam('PRCCD', ItsCombo.GetValue('cmb_PRCCD'));
        maria.AddParam('STDCD', ItsGrid.GetValue('grid1', rowIndex, 'STDCD'));
        maria.AddParam('STDPART', ItsGrid.GetValue('grid1', rowIndex, 'STDPART'));
        maria.AddParam('PRCDETAIL', ItsGrid.GetValue('grid1', rowIndex, 'PRCDETAIL'));
        maria.CallProc();
        if (maria.isError) {
            maria.ShowErrMsg();
            return;
        }

        ItsGrid.SetStore('grid2', maria.store);
    }

    // 시료수만큼 행 (저장된 검사값이 있으면 그 뒤에 빈 행, L·R 둘 다 빈 행은 저장하지 않았으므로)
    var SAMPLESIZE = Number(ItsGrid.GetValue('grid1', rowIndex, 'SAMPLESIZE'));
    for (var i = ItsGrid.Length('grid2'); i < SAMPLESIZE; i++) {
        ItsGrid.AddRow('grid2', i);
    }

    if (isSaved) {
        JUDGE_GRID2(rowIndex);   // 빨간 글자·판정 컬럼 표시

        var JUDGE = ItsGrid.GetValue('grid1', rowIndex, 'JUDGE');
        ItsCheck.SetValue('check_OK', JUDGE == 'Y' ? 'Y' : 'N');
        ItsCheck.SetValue('check_NG', JUDGE == 'N' ? 'Y' : 'N');
    }
};

// 검사값 입력 시 합불 판정
ItsGrid.Event('grid2').onChanged = function (row, field) {
    if (field != 'VALUE' && field != 'VALUE2') {
        return;
    }

    JUDGE_GRID2(ItsGrid.GetCurrentIndex('grid1'));
};

// 측정검사(02) 검사값을 판정범위로 합불 판정: 벗어난 칸은 빨간 글자, 행별 판정, 합격·불합격 체크 자동 설정
JUDGE_GRID2 = function (STDROW) {
    if (ItsGrid.GetValue('grid1', STDROW, 'STDCHKTP') != '02') {
        return;
    }

    var STDRANGE = ItsGrid.GetValue('grid1', STDROW, 'STDRANGE');
    var STDVAL = Number(ItsGrid.GetValue('grid1', STDROW, 'STDVAL'));
    var STDMINUS = Number(ItsGrid.GetValue('grid1', STDROW, 'STDMINUS'));
    var STDPLUS = Number(ItsGrid.GetValue('grid1', STDROW, 'STDPLUS'));

    // 범위 코드(STDRANGE): 01 최대, 02 최소, 03 이상, 04 이내, 05 =, 06 ~ (경계값 포함 합격)
    var isOk = function (text) {
        var value = Number(text);
        if (isNaN(value)) return false;
        if (STDRANGE == '01' || STDRANGE == '04') return value <= STDVAL;
        if (STDRANGE == '02' || STDRANGE == '03') return value >= STDVAL;
        if (STDRANGE == '05') return value == STDVAL;
        if (STDRANGE == '06') return value >= STDVAL + STDMINUS && value <= STDVAL + STDPLUS;
        return true;
    };

    // 전체 검사값으로 합격·불합격 체크 (하나라도 벗어나면 불합격, 모든 행에 값이 있고 다 맞으면 합격)
    var hasNg = false;
    var allEntered = true;
    for (var i = 0; i < ItsGrid.Length('grid2'); i++) {
        var VALUE = String(ItsGrid.GetValue('grid2', i, 'VALUE') == null ? '' : ItsGrid.GetValue('grid2', i, 'VALUE')).trim();
        var VALUE2 = String(ItsGrid.GetValue('grid2', i, 'VALUE2') == null ? '' : ItsGrid.GetValue('grid2', i, 'VALUE2')).trim();

        if (VALUE == '' && VALUE2 == '') allEntered = false;

        // 칸 글자색 (벗어나면 빨간색, 아니면 원래 글자색)
        ItsGrid.SetCellForeColor('grid2', i, 'VALUE', VALUE != '' && !isOk(VALUE) ? '#FF0000' : '');
        ItsGrid.SetCellForeColor('grid2', i, 'VALUE2', VALUE2 != '' && !isOk(VALUE2) ? '#FF0000' : '');

        // 행별 판정: L·R 중 하나라도 벗어나면 불합격(빨간 글자), 입력한 값이 다 맞으면 합격, 둘 다 비면 빈칸
        var rowNg = (VALUE != '' && !isOk(VALUE)) || (VALUE2 != '' && !isOk(VALUE2));
        if (rowNg) hasNg = true;
        ItsGrid.SetValue('grid2', i, 'JUDGE', VALUE == '' && VALUE2 == '' ? '' : (rowNg ? '불합격' : '합격'));
        ItsGrid.SetCellForeColor('grid2', i, 'JUDGE', rowNg ? '#FF0000' : '');
    }

    ItsCheck.SetValue('check_NG', hasNg ? 'Y' : 'N');
    ItsCheck.SetValue('check_OK', !hasNg && allEntered ? 'Y' : 'N');
};

// 검사값 칸을 입력 상태로 (커서 표시, 태블릿 키보드)
EDIT_GRID2 = function (row, field) {
    var grid2 = ItsGrid.Get('grid2');
    var col = grid2.columns.getColumn(field).index;
    grid2.select(row, col);
    grid2.focus();
    grid2.startEditing(true, row, col);   // ItsGrid.SelectCell 은 startEditing 이 주석 처리돼 있어 직접 호출
};

// 합격·불합격은 하나만 체크
ItsCheck.Event('check_OK').onChanged = function () {
    if (ItsCheck.GetValue('check_OK') == 'Y')
        ItsCheck.SetValue('check_NG', 'N');
};

ItsCheck.Event('check_NG').onChanged = function () {
    if (ItsCheck.GetValue('check_NG') == 'Y')
        ItsCheck.SetValue('check_OK', 'N');
};
/**********************************************************************************************************************************************************************/
// 저장

// 선택한 검사항목의 검사결과(합불)와 검사값 저장
ItsButton.Event('btn_SAVE').onClick = function () {
    if (ItsGrid.Length('grid1') == 0) {
        ItsMsg.Toast('검사항목을 선택하세요.');
        return;
    }

    var STDROW = ItsGrid.GetCurrentIndex('grid1');
    var JUDGE = '';
    if (ItsCheck.GetValue('check_OK') == 'Y')
        JUDGE = 'Y';
    else if (ItsCheck.GetValue('check_NG') == 'Y')
        JUDGE = 'N';

    var maria = new ItsMaria('TAL2001_R01', 'SAVE_RST');
    maria.AddParam('LINECD', ItsCombo.GetValue('cmb_LINECD'));
    maria.AddParam('PRCCD', ItsCombo.GetValue('cmb_PRCCD'));
    maria.AddParam('EQMCD', ItsCombo.GetValue('cmb_EQMCD'));
    maria.AddParam('ITEMID', ItsText.GetValue('txt_ITEMID'));
    maria.AddPanel('div2');     // 검사일자(TQMDATE), 검사시간(TQMTIME), 검사자(EMPCD)
    maria.AddParam('REVCD', ItsGrid.GetValue('grid1', STDROW, 'REVCD'));
    maria.AddParam('STDCD', ItsGrid.GetValue('grid1', STDROW, 'STDCD'));
    maria.AddParam('STDPART', ItsGrid.GetValue('grid1', STDROW, 'STDPART'));
    maria.AddParam('PRCDETAIL', ItsGrid.GetValue('grid1', STDROW, 'PRCDETAIL'));
    maria.AddParam('SAMPLESIZE', ItsGrid.GetValue('grid1', STDROW, 'SAMPLESIZE'));
    maria.AddParam('JUDGE', JUDGE);

    for (var i = 0; i < ItsGrid.Length('grid2'); i++) {
        maria.AddList('SEQ_LIST', i + 1);
        maria.AddList('VALUE_LIST', ItsGrid.GetValue('grid2', i, 'VALUE') == null ? '' : ItsGrid.GetValue('grid2', i, 'VALUE'));
        maria.AddList('VALUE2_LIST', ItsGrid.GetValue('grid2', i, 'VALUE2') == null ? '' : ItsGrid.GetValue('grid2', i, 'VALUE2'));
    }

    maria.CallProc();
    if (maria.isError) {
        maria.ShowErrMsg();
        return;
    }

    ItsMsg.Toast(ItsMsg.CommonMsg.SaveComplete());

    // 저장한 검사항목 결과를 검사항목 줄에 표시
    if (maria.store.Length() > 0) {
        ItsGrid.SetValue('grid1', STDROW, 'TQMRSTKEY', maria.store.data[0]["TQMRSTKEY"]);
        ItsGrid.SetValue('grid1', STDROW, 'MINVAL', maria.store.data[0]["MINVAL"]);
        ItsGrid.SetValue('grid1', STDROW, 'MAXVAL', maria.store.data[0]["MAXVAL"]);
        ItsGrid.SetValue('grid1', STDROW, 'AVG', maria.store.data[0]["AVG"]);
        ItsGrid.SetValue('grid1', STDROW, 'JUDGE', maria.store.data[0]["JUDGE"]);
        ItsGrid.SetValue('grid1', STDROW, 'JUDGENM', maria.store.data[0]["JUDGENM"]);
        ItsGrid.SetCellForeColor('grid1', STDROW, 'JUDGENM', maria.store.data[0]["JUDGE"] == 'N' ? '#FF0000' : '');
    }

    // 다음 검사항목 선택 (마지막 항목이면 첫 항목), 행이 바뀌면 onSelect 가 검사값 행을 다시 만듦
    var NEXTROW = STDROW + 1 < ItsGrid.Length('grid1') ? STDROW + 1 : 0;
    if (NEXTROW == STDROW)
        ItsGrid.Event('grid1').onSelect(STDROW);   // 검사항목이 하나뿐이면 그 항목을 다시 불러옴
    else
        ItsGrid.SelectRow('grid1', NEXTROW);

    // 검사값 첫 칸 입력 상태로 (SelectRow 가 setTimeout 으로 행을 바꾸고 grid1 에 포커스를 주므로 그 뒤에 실행)
    setTimeout(function () {
        if (ItsGrid.Length('grid2') > 0)
            EDIT_GRID2(0, 'VALUE');
    }, 10);
};
/**********************************************************************************************************************************************************************/
