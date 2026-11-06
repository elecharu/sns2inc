/// <reference path="../../Script/reference.js" />

// 평가 팝업 수정 가능 여부 (승인된 평가이력은 조회만)
var EVAL_EDIT = true;

/* 페이지 로드 시 수행 */
ItsPage.Load = function () {
    // 설비목록 그리드 (MST1002_R06과 같은 방식 : 작업장·공정·라인·설비그룹 같은 값 셀 병합, ItsGrid 공통 allowMerging)
    ItsGrid.Create('grid1', { isCheckBoxGrid: false, allowMerging: 'Cells' }, [
        column.create('작업장', 'LINENM', { width: 90, align: 'center', allowMerging: true }),
        column.create('공정', 'EQMTP', { width: 80, align: 'center', columnType: enumColumnTypes.combo, gpcd: 'FM100', allowMerging: true }),
        column.create('라인', 'EQMGROUP1', { width: 80, align: 'center', columnType: enumColumnTypes.combo, gpcd: 'FM113', allowMerging: true }),
        column.create('설비그룹', 'EQMGUBUN', { width: 100, align: 'center', columnType: enumColumnTypes.combo, gpcd: 'FM116', allowMerging: true }),
        column.create('설비코드', 'FANO', { width: 100, align: 'center' }),
        column.create('설비명', 'EQMNM', { width: 180 }),
        column.create('설비등급', 'EQMGRADE', { width: 70, align: 'center', columnType: enumColumnTypes.combo, gpcd: 'FM110' }),
        column.split()
    ]);

    // 평가이력 그리드
    ItsGrid.Create('grid2', { isCheckBoxGrid: false }, [
        column.create('평가키', 'EQMGRADEEVALKEY', { width: 100, hidden: true }),
        column.create('평가자코드', 'EMPCD', { width: 100, hidden: true }),
        column.create('비고', 'REMARK', { width: 100, hidden: true }),
        column.create('평가일자', 'EVALDATE', { width: 90, align: 'center' }),
        column.create('평가등급', 'EQMGRADE', { width: 70, align: 'center', columnType: enumColumnTypes.combo, gpcd: 'FM110' }),
        column.create('합계점수', 'TOTSCORE', { width: 70, align: 'right', columnType: enumColumnTypes.number, decimalPrecision: 0 }),
        column.create('평가자', 'EMPNM', { width: 80, align: 'center' }),
        column.create('승인자', 'APRVEMPNM', { width: 80, align: 'center' }),
        column.create('승인일시', 'APRVTIME', { width: 130, align: 'center' }),
        column.create('상세조회', 'BTN_DETAIL', { width: 70, columnType: enumColumnTypes.button, iconCls: 'fa-search' }),
        column.create('평가표출력', 'BTN_PRINT', { width: 80, columnType: enumColumnTypes.button, iconCls: 'fa-print' }),
        column.create('삭제', 'BTN_DEL', { width: 50, columnType: enumColumnTypes.button, iconCls: 'fa-trash' }),
        column.split()
    ]);

    // 평가 팝업 : 평가항목별 점수 그리드
    ItsGrid.Create('grid3', { isCheckBoxGrid: false }, [
        column.create('REVCD', 'REVCD', { width: 100, hidden: true }),
        column.create('GMCD', 'GMCD', { width: 100, hidden: true }),
        column.create('구분', 'GMTP', { width: 80, align: 'center', columnType: enumColumnTypes.combo, gpcd: 'GMTP' }),
        column.create('평가항목', 'GMNM', { width: 220 }),
        column.create('계산구분', 'CALCTP', { width: 80, align: 'center', columnType: enumColumnTypes.combo, gpcd: 'CALCTP' }),
        column.create('산출값', 'CALCVAL', { width: 70, align: 'right', columnType: enumColumnTypes.number, decimalPrecision: 2 }),
        column.create('점수', 'SCORE', { width: 50, align: 'center', columnType: enumColumnTypes.number, decimalPrecision: 0 }),
        column.create('평가기준', 'SCORENM', { width: 220 }),
        column.split()
    ]);

    // 평가 팝업 : 선택 평가항목의 점수별 평가기준 그리드
    ItsGrid.Create('grid4', { isCheckBoxGrid: false }, [
        column.create('점수', 'SCORE', { width: 50, align: 'center', columnType: enumColumnTypes.number, decimalPrecision: 0 }),
        column.create('평가기준', 'SCORENM', { width: 220 }),
        column.create('최소값(이상)', 'MINVAL', { width: 85, align: 'right' }),
        column.create('최대값(미만)', 'MAXVAL', { width: 85, align: 'right' }),
        column.create('비고', 'REMARK', { width: 150 }),
        column.split()
    ]);

    // 평가 팝업 : 설비등급 기준 그리드 (참고용, 행·셀 선택 불가)
    ItsGrid.Create('grid5', { isCheckBoxGrid: false, selectMode: 'None' }, [
        column.create('분류', 'EQMGRADE', { width: 70, align: 'center', columnType: enumColumnTypes.combo, gpcd: 'FM110' }),
        column.create('점수', 'SCORENM', { width: 100, align: 'center' }),
        column.create('최소점수(이상)', 'MINVAL', { width: 95, align: 'right' }),
        column.create('최대점수(미만)', 'MAXVAL', { width: 95, align: 'right' }),
        column.create('구분', 'MNGNM', { width: 90, align: 'center' }),
        column.create('비고(점검주기)', 'CHKCYCLE2', { width: 110, align: 'center' }),
        column.split()
    ]);

    ItsDateRange.SetInitValueFrom('date_SEARCH', ItsHelper.AddDay(-365, ItsHelper.GetYearMonthDay()));
};

// 2026-11-05 [조회] 조회조건(작업장·공정·라인)의 설비목록 조회
ItsButton.EventSearch = function () {
    ItsGrid.Clear('grid2');

    var maria = new ItsMaria('MST1005_R01', 'LIST_EQM');
    maria.AddPanel('sdiv1');
    maria.CallProc();
    if (maria.isError) {
        maria.ShowErrMsg();
        return;
    }

    ItsGrid.SetStore('grid1', maria.store);
    ItsMsg.Toast(ItsMsg.CommonMsg.SearchComplete(maria.store.Length()));
};

// 2026-11-05 [조회조건] 작업장 변경시 공정·라인 콤보를 그 작업장 기준으로 변경
ItsCombo.Event('cmb_LINECD').onChanged = function () {
    ItsCombo.SetRef01('cmb_EQMTP', ItsCombo.GetValue('cmb_LINECD'));
    ItsCombo.SetValue('cmb_EQMTP', '', false);

    ItsCombo.SetRef01('cmb_EQMGROUP1', ItsCombo.GetValue('cmb_LINECD'), false);
    ItsCombo.SetRef02('cmb_EQMGROUP1', '');
    ItsCombo.SetValue('cmb_EQMGROUP1', '', false);
};

// 2026-11-05 [조회조건] 공정 변경시 라인 콤보를 그 공정 기준으로 변경
ItsCombo.Event('cmb_EQMTP').onChanged = function () {
    ItsCombo.SetRef02('cmb_EQMGROUP1', ItsCombo.GetValue('cmb_EQMTP'));
    ItsCombo.SetValue('cmb_EQMGROUP1', '', false);
};

// 2026-11-05 [설비목록 그리드] 설비 선택시 평가이력 조회
ItsGrid.Event('grid1').onSelect = function () {
    SEARCH_EVAL();
};

// 2026-11-05 [설비목록 그리드] 선택 설비번호
function GET_FANO() {
    return ItsGrid.GetValue('grid1', ItsGrid.GetCurrentIndex('grid1'), 'FANO') || '';
}

// 2026-11-05 [평가이력 그리드] 선택 평가키
function GET_EVALKEY() {
    return ItsGrid.GetValue('grid2', ItsGrid.GetCurrentIndex('grid2'), 'EQMGRADEEVALKEY') || '';
}

// 2026-11-05 [평가이력 그리드] 선택 설비의 조회일자 내 평가이력 조회 (evalKey가 있으면 그 평가이력 선택)
function SEARCH_EVAL(evalKey) {
    ItsGrid.Clear('grid2');

    var fano = GET_FANO();
    if (fano == '') {
        return;
    }

    var maria = new ItsMaria('MST1005_R01', 'LIST_EVAL');
    maria.AddPanel('sdiv1');
    maria.AddParam('FANO', fano);
    maria.CallProc();
    if (maria.isError) {
        maria.ShowErrMsg();
        return;
    }

    if (evalKey) {
        ItsGrid.Setkey('grid2', 'EQMGRADEEVALKEY', evalKey);
    }
    ItsGrid.SetStore('grid2', maria.store);
}

// 2026-11-05 [평가이력 영역] 신규평가 : 선택 설비를 사용중 평가기준으로 평가 (평가일자 오늘, 평가자 로그인 사원)
ItsButton.Event('btn_NEW_EVAL').onClick = function () {
    if (GET_FANO() == '') {
        ItsMsg.Toast('설비를 선택하세요.');
        return;
    }

    OPEN_EVAL({
        EQMGRADEEVALKEY: '',
        FANO: GET_FANO(),
        EQMNM: ItsGrid.GetValue('grid1', ItsGrid.GetCurrentIndex('grid1'), 'EQMNM'),
        EVALDATE: ItsHelper.GetYearMonthDay(),
        EMPCD: ItsPage.EMPCD,
        REMARK: ''
    }, true);
};

// 2026-11-05 [평가이력 그리드] 상세조회(승인 이력은 조회만)·평가표출력(MST1005_R01 레포트)·삭제 버튼
ItsGrid.Event('grid2').onButtonClick = function (rowIndex, field) {
    var key = ItsGrid.GetValue('grid2', rowIndex, 'EQMGRADEEVALKEY');

    if (field == 'BTN_DETAIL') {
        OPEN_EVAL({
            EQMGRADEEVALKEY: key,
            FANO: GET_FANO(),
            EQMNM: ItsGrid.GetValue('grid1', ItsGrid.GetCurrentIndex('grid1'), 'EQMNM'),
            EVALDATE: ItsGrid.GetValue('grid2', rowIndex, 'EVALDATE'),
            EMPCD: ItsGrid.GetValue('grid2', rowIndex, 'EMPCD'),
            REMARK: ItsGrid.GetValue('grid2', rowIndex, 'REMARK')
        }, (ItsGrid.GetValue('grid2', rowIndex, 'APRVTIME') || '') == '');
    } else if (field == 'BTN_PRINT') {
        // 2026-11-05 설비등급 평가표 출력
        var rpt = new ItsXtraRpt('MST1005_R01');
        rpt.AddParam('EQMGRADEEVALKEY', key);
        rpt.CallPop();
        if (rpt.isError) {
            ItsMsg.Alert(rpt.errMessage);
        }
    } else if (field == 'BTN_DEL') {
        ItsMsg.Confirm(ItsGrid.GetValue('grid2', rowIndex, 'EVALDATE') + ' 평가이력을 삭제하시겠습니까?', function () {
            var maria = new ItsMaria('MST1005_R01', 'DEL_EVAL');
            maria.AddParam('EQMGRADEEVALKEY', key);
            maria.CallProc();
            if (maria.isError) {
                maria.ShowErrMsg();
                return;
            }

            ItsMsg.Toast(ItsMsg.CommonMsg.DeleteComplete());
            SEARCH_EVAL();
        });
    }
};

// 2026-11-05 [평가 팝업] 평가 팝업 열기 (평가항목별 점수·설비등급 기준 조회)
function OPEN_EVAL(data, isEdit) {
    ItsPage.InitData('pdiv1');
    ItsText.SetValue('pop1_txt_EQMGRADEEVALKEY', data.EQMGRADEEVALKEY, false);
    ItsText.SetValue('pop1_txt_FANO', data.FANO, false);
    ItsText.SetValue('pop1_txt_EQMNM', data.EQMNM, false);
    ItsDate.SetValue('pop1_date_EVALDATE', data.EVALDATE, false);
    ItsFind.SetValue('pop1_find_EMPCD', data.EMPCD, false);
    ItsText.SetValue('pop1_txt_REMARK', data.REMARK, false);
    SET_EVAL_EDIT(isEdit);

    if (!SEARCH_EVAL_D()) {
        return;
    }
    ItsPop.Open('pop1');
}

// 2026-11-05 [평가 팝업] 승인된 평가이력은 저장 버튼 숨김, 입력 잠금
function SET_EVAL_EDIT(isEdit) {
    EVAL_EDIT = isEdit;

    if (isEdit) {
        ItsButton.Show('pop1_ItsPopADD');
        ItsDate.Enable('pop1_date_EVALDATE');
        ItsFind.Enable('pop1_find_EMPCD');
        ItsText.Enable('pop1_txt_REMARK');
    } else {
        ItsButton.Hide('pop1_ItsPopADD');
        ItsDate.Disable('pop1_date_EVALDATE');
        ItsFind.Disable('pop1_find_EMPCD');
        ItsText.Disable('pop1_txt_REMARK');
    }
}

// 2026-11-05 [평가 팝업] 평가일자 기준 평가항목별 산출값·점수 조회
function SEARCH_EVAL_D() {
    var maria = new ItsMaria('MST1005_R01', 'LIST_EVAL_D');
    maria.AddParam('EQMGRADEEVALKEY', ItsText.GetValue('pop1_txt_EQMGRADEEVALKEY'));
    maria.AddParam('FANO', ItsText.GetValue('pop1_txt_FANO'));
    maria.AddParam('EVALDATE', ItsDate.GetValue('pop1_date_EVALDATE'));
    maria.CallProc();
    if (maria.isError) {
        maria.ShowErrMsg();
        return false;
    }

    ItsGrid.Clear('grid4');
    ItsGrid.SetStore('grid3', maria.store);
    SEARCH_EVAL_SCORE();
    return true;
}

// 2026-11-05 [평가 팝업] 평가기준 리비전의 설비등급 기준 조회
function SEARCH_EVAL_SCORE() {
    ItsGrid.Clear('grid5');

    var maria = new ItsMaria('MST1005_R01', 'LIST_EVAL_SCORE');
    maria.AddParam('REVCD', ItsGrid.GetValue('grid3', 0, 'REVCD'));
    maria.CallProc();
    if (maria.isError) {
        maria.ShowErrMsg();
        return;
    }

    ItsGrid.SetStore('grid5', maria.store);
    SET_TOTAL();
}

// 2026-11-05 [평가 팝업] 평가일자 변경시 산출값·자동 점수 다시 조회 (직접 선택한 점수는 유지)
ItsDate.Event('pop1_date_EVALDATE').onChanged = function () {
    var arrScore = {};
    for (var i = 0; i < ItsGrid.Length('grid3'); i++) {
        if ((ItsGrid.GetValue('grid3', i, 'CALCTP') || '') == '') {
            arrScore[ItsGrid.GetValue('grid3', i, 'GMCD')] = {
                SCORE: ItsGrid.GetValue('grid3', i, 'SCORE'),
                SCORENM: ItsGrid.GetValue('grid3', i, 'SCORENM')
            };
        }
    }

    if (!SEARCH_EVAL_D()) {
        return;
    }

    for (var j = 0; j < ItsGrid.Length('grid3'); j++) {
        var score = arrScore[ItsGrid.GetValue('grid3', j, 'GMCD')];
        if (score) {
            ItsGrid.SetValue('grid3', j, 'SCORE', score.SCORE);
            ItsGrid.SetValue('grid3', j, 'SCORENM', score.SCORENM);
        }
    }
    SET_TOTAL();
};

// 2026-11-05 [평가 팝업] 평가항목 선택시 해당 항목의 점수별 평가기준 조회 (계산구분이 없으면 최소·최대값 숨김)
ItsGrid.Event('grid3').onSelect = function () {
    ItsGrid.Clear('grid4');

    var row = ItsGrid.GetCurrentIndex('grid3');
    var isRange = (ItsGrid.GetValue('grid3', row, 'CALCTP') || '') != '';
    ItsGrid.Get('grid4').columns[ItsGrid.$colIndex('grid4', 'MINVAL')].visible = isRange;
    ItsGrid.Get('grid4').columns[ItsGrid.$colIndex('grid4', 'MAXVAL')].visible = isRange;

    var maria = new ItsMaria('MST1005_R01', 'LIST_EVAL_D2');
    maria.AddParam('REVCD', ItsGrid.GetValue('grid3', row, 'REVCD'));
    maria.AddParam('GMCD', ItsGrid.GetValue('grid3', row, 'GMCD'));
    maria.CallProc();
    if (maria.isError) {
        maria.ShowErrMsg();
        return;
    }

    var score = ItsGrid.GetValue('grid3', row, 'SCORE');
    var selectIndex = 0;
    if (score !== null && score !== undefined && score !== '') {
        for (var i = 0; i < maria.store.Length(); i++) {
            if (maria.store.data[i]['SCORE'] == score) {
                selectIndex = i;
                ItsGrid.Setkey('grid4', 'SCORE', score);
                break;
            }
        }
    }

    ItsGrid.SetStore('grid4', maria.store, selectIndex);
    ItsGrid.SelectRow('grid4', selectIndex);
};

// 2026-11-05 [평가 팝업] 점수별 평가기준 더블클릭시 계산구분 없는 평가항목의 점수 선택
ItsGrid.Event('grid4').onDoubleClick = function (rowIndex) {
    if (!EVAL_EDIT) {
        return;
    }

    var row = ItsGrid.GetCurrentIndex('grid3');
    if ((ItsGrid.GetValue('grid3', row, 'CALCTP') || '') != '') {
        ItsMsg.Toast('계산구분이 있는 평가항목은 산출값으로 점수가 정해집니다.');
        return;
    }

    ItsGrid.SetValue('grid3', row, 'SCORE', ItsGrid.GetValue('grid4', rowIndex, 'SCORE'));
    ItsGrid.SetValue('grid3', row, 'SCORENM', ItsGrid.GetValue('grid4', rowIndex, 'SCORENM'));
    SET_TOTAL();
};

ItsGrid.Event('grid4').onKeydownEnter = function (rowIndex) {
    ItsGrid.Event('grid4').onDoubleClick(rowIndex);
};

// 2026-11-05 [평가 팝업] 항목 점수 합계와 평가등급 표시 (점수가 빠진 항목이 있으면 평가등급 비움, 점수 선택 즉시 표시칸 갱신)
function SET_TOTAL() {
    var tot = 0;
    var isAll = ItsGrid.Length('grid3') > 0;

    for (var i = 0; i < ItsGrid.Length('grid3'); i++) {
        var score = ItsGrid.GetValue('grid3', i, 'SCORE');
        if (score === null || score === undefined || score === '') {
            isAll = false;
        } else {
            tot += Number(score);
        }
    }

    // 화면 표시칸(ItsNumView)은 change 이벤트에서 갱신되므로 이벤트를 발생시켜 설정
    ItsNum.SetValue('pop1_num_TOTSCORE', tot);
    ItsCombo.SetValue('pop1_cmb_EQMGRADE', isAll ? GET_GRADE(tot) : '', false);
}

// 2026-11-05 [평가 팝업] 합계점수가 들어가는 설비등급 (최소점수 이상 ~ 최대점수 미만, 최소 = 최대면 그 점수, 빈 값은 제한 없음)
function GET_GRADE(tot) {
    for (var i = 0; i < ItsGrid.Length('grid5'); i++) {
        var min = ItsGrid.GetValue('grid5', i, 'MINVAL') || '';
        var max = ItsGrid.GetValue('grid5', i, 'MAXVAL') || '';
        if (min == '' && max == '') {
            continue;
        }

        var isIn = (min != '' && min == max) ? tot == Number(min)
            : (min == '' || tot >= Number(min)) && (max == '' || tot < Number(max));
        if (isIn) {
            return ItsGrid.GetValue('grid5', i, 'EQMGRADE');
        }
    }
    return '';
}

// 2026-11-05 [평가 팝업] 평가 저장 (계산구분 없는 항목의 선택 점수만 전송, 계산구분 항목 점수·평가등급은 프로시저에서 판정)
ItsPop.Event('pop1').onAddBtnClick = function () {
    var maria = new ItsMaria('MST1005_R01', 'SAVE_EVAL');
    maria.AddPanel('pdiv1');
    for (var i = 0; i < ItsGrid.Length('grid3'); i++) {
        if ((ItsGrid.GetValue('grid3', i, 'CALCTP') || '') == '') {
            var score = ItsGrid.GetValue('grid3', i, 'SCORE');
            maria.AddList('GMCD_LIST', ItsGrid.GetValue('grid3', i, 'GMCD'));
            maria.AddList('SCORE_LIST', score === null || score === undefined ? '' : score);
        }
    }
    maria.CallProc();
    if (maria.isError) {
        maria.ShowErrMsg();
        return;
    }

    ItsPop.Close('pop1');
    ItsMsg.Toast(ItsMsg.CommonMsg.SaveComplete());
    SEARCH_EVAL(maria.store.data[0]['EQMGRADEEVALKEY']);
};

ItsPop.Event('pop1').onCancelBtnClick = function () {
    ItsPop.Close('pop1');
};

// 2026-11-06 [평가이력 영역] 승인 : 선택 평가이력의 승인자·승인일자·비고 입력 (기본값 로그인 사원, 오늘, 기존 평가비고)
ItsButton.Event('btn_APRV').onClick = function () {
    if (GET_EVALKEY() == '') {
        ItsMsg.Alert('평가이력을 선택하세요.');
        return;
    }

    // 2026-11-06 이미 승인된 평가이력은 승인 팝업을 열지 않음
    if ((ItsGrid.GetValue('grid2', ItsGrid.GetCurrentIndex('grid2'), 'APRVTIME') || '') != '') {
        ItsMsg.Alert('이미 승인된 평가이력입니다.');
        return;
    }

    ItsPage.InitData('pdiv2');
    ItsFind.SetValue('pop2_find_APRVEMP', ItsPage.EMPCD, false);
    ItsDate.SetValue('pop2_date_APRVDATE', ItsHelper.GetYearMonthDay(), false);
    ItsText.SetValue('pop2_txt_REMARK', ItsGrid.GetValue('grid2', ItsGrid.GetCurrentIndex('grid2'), 'REMARK') || '', false);
    ItsPop.Open('pop2');
};

// 2026-11-06 [승인 팝업] 승인 저장 (비고 포함) 후 설비목록의 설비등급을 평가등급으로 표시, 평가이력 다시 조회
ItsPop.Event('pop2').onAddBtnClick = function () {
    ItsMsg.Confirm('승인 후에는 수정·삭제할 수 없고<br>설비등급이 평가등급으로 변경됩니다.<br>승인하시겠습니까?', function () {
        var key = GET_EVALKEY();
        var maria = new ItsMaria('MST1005_R01', 'APPROVE_EVAL');
        maria.AddPanel('pdiv2');
        maria.AddParam('EQMGRADEEVALKEY', key);
        maria.AddParam('REMARK', ItsText.GetValue('pop2_txt_REMARK'));
        maria.CallProc();
        if (maria.isError) {
            maria.ShowErrMsg();
            return;
        }

        ItsPop.Close('pop2');
        ItsGrid.SetValue('grid1', ItsGrid.GetCurrentIndex('grid1'), 'EQMGRADE', ItsGrid.GetValue('grid2', ItsGrid.GetCurrentIndex('grid2'), 'EQMGRADE'));
        SEARCH_EVAL(key);
        ItsMsg.Toast('승인되었습니다.');
    });
};

ItsPop.Event('pop2').onCancelBtnClick = function () {
    ItsPop.Close('pop2');
};
