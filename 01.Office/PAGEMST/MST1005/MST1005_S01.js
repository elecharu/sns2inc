/// <reference path="../../Script/reference.js" />

/* 페이지 로드 시 수행 */
ItsPage.Load = function () {
    // 리비전 그리드
    ItsGrid.Create('grid1', { isCheckBoxGrid: false }, [
        column.create('REVCD', 'REVCD', { width: 100, hidden: true }),
        column.create('사용중', 'USEYN', { width: 60, columnType: enumColumnTypes.check }),
        column.create('리비전', 'REVNUM', { width: 60, align: 'center', columnType: enumColumnTypes.number, decimalPrecision: 0 }),
        column.create('비고', 'REMARK', { width: 200, readOnly: false }),
        column.split()
    ]);

    // 평가항목 그리드
    ItsGrid.Create('grid2', { isCheckBoxGrid: true }, [
        column.create('GMCD', 'GMCD', { width: 100, hidden: true }),
        column.create('NO', 'SORTNO', { width: 50, align: 'center', columnType: enumColumnTypes.number, decimalPrecision: 0, readOnly: false }),
        column.create('구분', 'GMTP', { width: 90, align: 'center', columnType: enumColumnTypes.combo, gpcd: 'GMTP', readOnly: false }),
        column.create('평가항목', 'GMNM', { width: 200, readOnly: false }),
        column.create('계산구분', 'CALCTP', { width: 90, align: 'center', columnType: enumColumnTypes.combo, gpcd: 'CALCTP', readOnly: false }),
        column.create('비고', 'REMARK', { width: 150, readOnly: false }),
        column.split()
    ]);

    // 점수별 평가기준 그리드 (선택 평가항목의 점수별 기준)
    ItsGrid.Create('grid3', { isCheckBoxGrid: true }, [
        column.create('ORG_SCORE', 'ORG_SCORE', { width: 100, hidden: true }),
        column.create('GMCD', 'GMCD', { width: 100, hidden: true }),
        column.create('점수', 'SCORE', { width: 50, align: 'center', columnType: enumColumnTypes.number, decimalPrecision: 0, readOnly: false }),
        column.create('평가기준', 'SCORENM', { width: 220, readOnly: false }),
        column.create('최소값(이상)', 'MINVAL', { width: 85, align: 'right', readOnly: false }),
        column.create('최대값(미만)', 'MAXVAL', { width: 85, align: 'right', readOnly: false }),
        column.create('비고', 'REMARK', { width: 150, readOnly: false }),
        column.split()
    ]);

    // 설비등급 기준 그리드
    ItsGrid.Create('grid4', { isCheckBoxGrid: true }, [
        column.create('ORG_EQMGRADE', 'ORG_EQMGRADE', { width: 100, hidden: true }),
        column.create('분류', 'EQMGRADE', { width: 80, align: 'center', columnType: enumColumnTypes.combo, gpcd: 'FM110', readOnly: false }),
        column.create('점수', 'SCORENM', { width: 110, align: 'center', readOnly: false }),
        column.create('최소점수(이상)', 'MINVAL', { width: 100, align: 'right', readOnly: false }),
        column.create('최대점수(미만)', 'MAXVAL', { width: 100, align: 'right', readOnly: false }),
        column.create('구분', 'MNGNM', { width: 110, align: 'center', readOnly: false }),
        column.create('비고(점검주기)', 'CHKCYCLE2', { width: 120, align: 'center', readOnly: false }),
        column.split()
    ]);
};

// 2026-11-04 [조회] 리비전 목록 조회
ItsButton.EventSearch = function () {
    ItsGrid.Clear('grid2');
    ItsGrid.Clear('grid3');
    ItsGrid.Clear('grid4');

    var maria = new ItsMaria('MST1005_S01', 'LIST_REV');
    maria.CallProc();
    if (maria.isError) {
        maria.ShowErrMsg();
        return;
    }

    ItsGrid.SetStore('grid1', maria.store.YnToBool('USEYN'));
    ItsMsg.Toast(ItsMsg.CommonMsg.SearchComplete(maria.store.Length()));
};

// 2026-11-04 [리비전 그리드] 리비전 선택시 평가항목·설비등급 기준 조회 (2026-11-05 이전 리비전은 조회만 가능)
ItsGrid.Event('grid1').onSelect = function () {
    SET_EDIT_MODE(IS_LATEST_REV());
    ItsGrid.Clear('grid3');
    SEARCH_GRID('grid2', 'LIST_D');
    SEARCH_GRID('grid4', 'LIST_SCORE');
};

// 2026-11-04 [평가항목 그리드] 평가항목 선택시 해당 항목의 점수별 평가기준만 조회
ItsGrid.Event('grid2').onSelect = function () {
    SEARCH_D2();
};

// 2026-11-05 [그리드 공통] 저장된 행 여부 (조회 시점 키 ORG_ 값이 있으면 저장된 행)
function IS_SAVED_ROW(gridId, rowIndex, orgField) {
    var org = ItsGrid.GetValue(gridId, rowIndex, orgField);
    return org !== undefined && org !== null && org !== '';
}

// 2026-11-05 [리비전 그리드] 선택 리비전이 가장 최근 리비전인지 여부
function IS_LATEST_REV() {
    var revNum = Number(ItsGrid.GetValue('grid1', ItsGrid.GetCurrentIndex('grid1'), 'REVNUM')) || 0;
    for (var i = 0; i < ItsGrid.Length('grid1'); i++) {
        if ((Number(ItsGrid.GetValue('grid1', i, 'REVNUM')) || 0) > revNum) {
            return false;
        }
    }
    return true;
}

// 2026-11-05 [우측 영역 공통] 이전 리비전은 평가항목·점수별 평가기준·설비등급 기준을 조회만 (버튼 숨김, 그리드 읽기 전용)
function SET_EDIT_MODE(isEdit) {
    var arrBtn = ['btn_ADD_D', 'btn_SAVE_D', 'btn_DEL_D', 'btn_ADD_D2', 'btn_SAVE_D2', 'btn_DEL_D2', 'btn_ADD_SCORE', 'btn_SAVE_SCORE', 'btn_DEL_SCORE'];
    for (var i = 0; i < arrBtn.length; i++) {
        if (isEdit) {
            ItsButton.Show(arrBtn[i]);
        } else {
            ItsButton.Hide(arrBtn[i]);
        }
    }

    ItsGrid.Get('grid2').isReadOnly = !isEdit;
    ItsGrid.Get('grid3').isReadOnly = !isEdit;
    ItsGrid.Get('grid4').isReadOnly = !isEdit;
}

// 2026-11-04 [리비전 그리드] 선택 리비전 코드
function GET_REVCD() {
    return ItsGrid.GetValue('grid1', ItsGrid.GetCurrentIndex('grid1'), 'REVCD') || '';
}

// 2026-11-04 [우측 그리드 공통] 선택 리비전 기준 그리드 조회
function SEARCH_GRID(gridId, callType) {
    ItsGrid.Clear(gridId);

    var maria = new ItsMaria('MST1005_S01', callType);
    maria.AddParam('REVCD', GET_REVCD());
    maria.CallProc();
    if (maria.isError) {
        maria.ShowErrMsg();
        return;
    }

    ItsGrid.SetStore(gridId, maria.store);
}

// 2026-11-04 [점수별 평가기준 그리드] 선택 평가항목의 점수별 평가기준 조회 (미저장 신규 항목은 조회 안 함)
function SEARCH_D2() {
    ItsGrid.Clear('grid3');

    var gmcd = ItsGrid.GetValue('grid2', ItsGrid.GetCurrentIndex('grid2'), 'GMCD') || '';
    if (gmcd == '') {
        return;
    }

    var maria = new ItsMaria('MST1005_S01', 'LIST_D2');
    maria.AddParam('REVCD', GET_REVCD());
    maria.AddParam('GMCD', gmcd);
    maria.CallProc();
    if (maria.isError) {
        maria.ShowErrMsg();
        return;
    }

    ItsGrid.SetStore('grid3', maria.store);
}

// 2026-11-04 [그리드 공통] 추가 행 번호 : 그리드에 없는 가장 작은 번호 (1,2,3 삭제 후 4,5만 있으면 1부터 다시 사용)
function GET_NEXT_NO(gridId, field) {
    var arrNo = {};
    for (var i = 0; i < ItsGrid.Length(gridId); i++) {
        arrNo[Number(ItsGrid.GetValue(gridId, i, field)) || 0] = true;
    }

    var no = 1;
    while (arrNo[no]) {
        no++;
    }
    return no;
}

// 2026-11-04 [그리드 공통] 체크 행 번호 목록
function GET_CHECKED_ROWS(gridId) {
    var arrRow = [];
    for (var i = 0; i < ItsGrid.Length(gridId); i++) {
        if (ItsGrid.IsChecked(gridId, i)) {
            arrRow.push(i);
        }
    }
    return arrRow;
}

// 2026-11-04 [리비전 영역] 리비전 갱신: 선택 리비전을 복사해 새 리비전 생성 (리비전이 없으면 빈 리비전 생성)
ItsButton.Event('btn_RENEW_REV').onClick = function () {
    var oldRevcd = GET_REVCD();
    var msg = oldRevcd == '' ? '새 리비전을 생성하시겠습니까?' : '선택한 리비전을 복사하여<br>새 리비전을 생성하시겠습니까?';

    ItsMsg.Confirm(msg, function () {
        var maria = new ItsMaria('MST1005_S01', 'RENEW_REV');
        maria.AddParam('OLDREVCD', oldRevcd);
        maria.CallProc();
        if (maria.isError) {
            maria.ShowErrMsg();
            return;
        }

        ItsGrid.Setkey('grid1', 'REVCD', maria.store.data[0]['REVCD']);
        ItsButton.EventSearch();
    });
};

// 2026-11-04 [리비전 영역] 선택 리비전 비고 저장
ItsButton.Event('btn_SAVE_REV').onClick = function () {
    var revcd = GET_REVCD();

    ItsMsg.Confirm('리비전 비고를 저장하시겠습니까?', function () {
        var maria = new ItsMaria('MST1005_S01', 'SAVE_REV');
        maria.AddParam('REVCD', revcd);
        maria.AddParam('REMARK', ItsGrid.GetValue('grid1', ItsGrid.GetCurrentIndex('grid1'), 'REMARK'));
        maria.CallProc();
        if (maria.isError) {
            maria.ShowErrMsg();
            return;
        }

        ItsMsg.Alert(ItsMsg.CommonMsg.SaveComplete());
    });
};

// 2026-11-04 [평가항목 영역] 체크한 평가항목 저장 (2026-11-05 재조회 후 선택했던 행을 다시 선택, 신규 행은 발번된 코드로 선택)
ItsButton.Event('btn_SAVE_D').onClick = function () {
    var arrRow = GET_CHECKED_ROWS('grid2');

    if (arrRow.length == 0) {
        ItsMsg.Alert('저장할 행을 체크하세요.');
        return;
    }

    ItsMsg.Confirm(arrRow.length + '건을 저장하시겠습니까?', function () {
        var curIdx = ItsGrid.GetCurrentIndex('grid2');
        var gmcd = ItsGrid.GetValue('grid2', curIdx, 'GMCD');
        var maria = new ItsMaria('MST1005_S01', 'SAVE_D');
        maria.AddParam('REVCD', GET_REVCD());

        for (var j = 0; j < arrRow.length; j++) {
            maria.AddList('GMCD_LIST', ItsGrid.GetValue('grid2', arrRow[j], 'GMCD'));
            maria.AddList('GMNM_LIST', ItsGrid.GetValue('grid2', arrRow[j], 'GMNM'));
            maria.AddList('GMTP_LIST', ItsGrid.GetValue('grid2', arrRow[j], 'GMTP'));
            maria.AddList('CALCTP_LIST', ItsGrid.GetValue('grid2', arrRow[j], 'CALCTP'));
            maria.AddList('SORTNO_LIST', ItsGrid.GetValue('grid2', arrRow[j], 'SORTNO'));
            maria.AddList('REMARK_LIST', ItsGrid.GetValue('grid2', arrRow[j], 'REMARK'));
        }

        maria.CallProc();
        if (maria.isError) {
            maria.ShowErrMsg();
            return;
        }

        // 선택했던 행이 저장 대상이면 프로시저가 돌려준 코드(신규 행은 발번 코드)로 다시 선택
        var pos = arrRow.indexOf(curIdx);
        if (pos > -1 && maria.store.data.length > 0) {
            gmcd = (maria.store.data[0]['GMCD_LIST'] || '').split('»')[pos];
        }

        ItsMsg.Alert(ItsMsg.CommonMsg.SaveComplete(arrRow.length));
        if (gmcd) {
            ItsGrid.Setkey('grid2', 'GMCD', gmcd);
        }
        SEARCH_GRID('grid2', 'LIST_D');
    });
};

// 2026-11-04 [점수별 평가기준 영역] 점수별 평가기준 행 추가 (저장된 평가항목 선택 필요, 점수는 비어 있는 가장 작은 번호)
ItsButton.Event('btn_ADD_D2').onClick = function () {
    var gmcd = ItsGrid.GetValue('grid2', ItsGrid.GetCurrentIndex('grid2'), 'GMCD') || '';

    if (gmcd == '') {
        ItsMsg.Alert('저장된 평가항목을 먼저 선택하세요.');
        return;
    }

    ItsGrid.AddRow('grid3', ItsGrid.Length('grid3'), { isRowCheck: true, GMCD: gmcd, SCORE: GET_NEXT_NO('grid3', 'SCORE') });
};

// 2026-11-04 [점수별 평가기준 영역] 체크한 평가기준 저장 (같은 점수 중복 입력 확인)
ItsButton.Event('btn_SAVE_D2').onClick = function () {
    var arrRow = GET_CHECKED_ROWS('grid3');
    var arrScore = {};

    if (arrRow.length == 0) {
        ItsMsg.Alert('저장할 행을 체크하세요.');
        return;
    }

    for (var i = 0; i < ItsGrid.Length('grid3'); i++) {
        var score = ItsGrid.GetValue('grid3', i, 'SCORE');
        if (score === '' || score === undefined || score === null) {
            continue;
        }
        if (arrScore[score]) {
            ItsMsg.Alert(score + '점이 중복 입력되었습니다.');
            return;
        }
        arrScore[score] = true;
    }

    ItsMsg.Confirm(arrRow.length + '건을 저장하시겠습니까?', function () {
        var maria = new ItsMaria('MST1005_S01', 'SAVE_D2');
        maria.AddParam('REVCD', GET_REVCD());

        for (var j = 0; j < arrRow.length; j++) {
            maria.AddList('D2_GMCD_LIST', ItsGrid.GetValue('grid3', arrRow[j], 'GMCD'));
            maria.AddList('D2_SCORE_LIST', ItsGrid.GetValue('grid3', arrRow[j], 'SCORE'));
            maria.AddList('D2_ORG_SCORE_LIST', ItsGrid.GetValue('grid3', arrRow[j], 'ORG_SCORE'));
            maria.AddList('D2_SCORENM_LIST', ItsGrid.GetValue('grid3', arrRow[j], 'SCORENM'));
            maria.AddList('D2_MINVAL_LIST', ItsGrid.GetValue('grid3', arrRow[j], 'MINVAL'));
            maria.AddList('D2_MAXVAL_LIST', ItsGrid.GetValue('grid3', arrRow[j], 'MAXVAL'));
            maria.AddList('D2_REMARK_LIST', ItsGrid.GetValue('grid3', arrRow[j], 'REMARK'));
        }

        maria.CallProc();
        if (maria.isError) {
            maria.ShowErrMsg();
            return;
        }

        ItsMsg.Alert(ItsMsg.CommonMsg.SaveComplete(arrRow.length));
        SEARCH_D2();
    });
};

// 2026-11-04 [설비등급 기준 영역] 체크한 설비등급 기준 저장 (같은 설비등급 중복 입력 확인)
ItsButton.Event('btn_SAVE_SCORE').onClick = function () {
    var arrRow = GET_CHECKED_ROWS('grid4');
    var arrGrade = {};

    if (arrRow.length == 0) {
        ItsMsg.Alert('저장할 행을 체크하세요.');
        return;
    }

    for (var i = 0; i < ItsGrid.Length('grid4'); i++) {
        var grade = ItsGrid.GetValue('grid4', i, 'EQMGRADE') || '';
        if (grade != '' && arrGrade[grade]) {
            ItsMsg.Alert('설비등급이 중복 입력되었습니다.');
            return;
        }
        arrGrade[grade] = true;
    }

    ItsMsg.Confirm(arrRow.length + '건을 저장하시겠습니까?', function () {
        var maria = new ItsMaria('MST1005_S01', 'SAVE_SCORE');
        maria.AddParam('REVCD', GET_REVCD());

        for (var j = 0; j < arrRow.length; j++) {
            maria.AddList('EQMGRADE_LIST', ItsGrid.GetValue('grid4', arrRow[j], 'EQMGRADE'));
            maria.AddList('GR_ORG_EQMGRADE_LIST', ItsGrid.GetValue('grid4', arrRow[j], 'ORG_EQMGRADE'));
            maria.AddList('GR_SCORENM_LIST', ItsGrid.GetValue('grid4', arrRow[j], 'SCORENM'));
            maria.AddList('GR_MINVAL_LIST', ItsGrid.GetValue('grid4', arrRow[j], 'MINVAL'));
            maria.AddList('GR_MAXVAL_LIST', ItsGrid.GetValue('grid4', arrRow[j], 'MAXVAL'));
            maria.AddList('MNGNM_LIST', ItsGrid.GetValue('grid4', arrRow[j], 'MNGNM'));
            maria.AddList('CHKCYCLE2_LIST', ItsGrid.GetValue('grid4', arrRow[j], 'CHKCYCLE2'));
        }

        maria.CallProc();
        if (maria.isError) {
            maria.ShowErrMsg();
            return;
        }

        ItsMsg.Alert(ItsMsg.CommonMsg.SaveComplete(arrRow.length));
        SEARCH_GRID('grid4', 'LIST_SCORE');
    });
};

// 2026-11-04 [리비전 영역] 선택 리비전 삭제 (평가이력이 있으면 프로시저에서 차단)
ItsButton.Event('btn_DEL_REV').onClick = function () {
    var revcd = GET_REVCD();

    ItsMsg.Confirm('선택한 리비전을 삭제하시겠습니까?', function () {
        var maria = new ItsMaria('MST1005_S01', 'DEL_REV');
        maria.AddParam('REVCD', revcd);
        maria.CallProc();
        if (maria.isError) {
            maria.ShowErrMsg();
            return;
        }

        ItsMsg.Alert(ItsMsg.CommonMsg.DeleteComplete());
        ItsButton.EventSearch();
    });
};

// 2026-11-04 [평가항목 영역] 평가항목 행 추가 (NO는 비어 있는 가장 작은 번호, 구분은 마지막 행과 같게)
ItsButton.Event('btn_ADD_D').onClick = function () {
    if (GET_REVCD() == '') {
        ItsMsg.Alert('리비전을 먼저 선택하세요.');
        return;
    }

    var cnt = ItsGrid.Length('grid2');
    var gmtp = cnt > 0 ? ItsGrid.GetValue('grid2', cnt - 1, 'GMTP') : '';

    ItsGrid.AddRow('grid2', cnt, { isRowCheck: true, SORTNO: GET_NEXT_NO('grid2', 'SORTNO'), GMTP: gmtp });
};

// 2026-11-04 [평가항목 영역] 체크한 평가항목 삭제 (저장된 항목은 점수별 평가기준과 함께 DB 삭제, 신규 행은 화면에서만 제거, 남은 선택 항목 기준 재조회)
ItsButton.Event('btn_DEL_D').onClick = function () {
    var arrRow = GET_CHECKED_ROWS('grid2');

    if (arrRow.length == 0) {
        ItsMsg.Alert('삭제할 행을 체크하세요.');
        return;
    }

    ItsMsg.Confirm(arrRow.length + '건을 삭제하시겠습니까? (점수별 평가기준 포함)', function () {
        var maria = new ItsMaria('MST1005_S01', 'DEL_D');
        var isDb = false;

        for (var j = 0; j < arrRow.length; j++) {
            var gmcd = ItsGrid.GetValue('grid2', arrRow[j], 'GMCD');
            if (gmcd) {
                maria.AddList('GMCD_LIST', gmcd);
                isDb = true;
            }
        }

        if (isDb) {
            maria.AddParam('REVCD', GET_REVCD());
            maria.CallProc();
            if (maria.isError) {
                maria.ShowErrMsg();
                return;
            }
        }

        for (var k = arrRow.length - 1; k >= 0; k--) {
            ItsGrid.RemoveRow('grid2', arrRow[k]);
        }
        if (ItsGrid.Length('grid2') == 0) {
            ItsGrid.Clear('grid3');
        }

        ItsMsg.Alert(ItsMsg.CommonMsg.DeleteComplete(arrRow.length));
    });
};

// 2026-11-04 [점수별 평가기준 영역] 체크한 평가기준 삭제 (저장된 행만 조회 시점 점수로 DB 삭제, 신규 행은 화면에서만 제거)
ItsButton.Event('btn_DEL_D2').onClick = function () {
    var arrRow = GET_CHECKED_ROWS('grid3');

    if (arrRow.length == 0) {
        ItsMsg.Alert('삭제할 행을 체크하세요.');
        return;
    }

    ItsMsg.Confirm(arrRow.length + '건을 삭제하시겠습니까?', function () {
        var maria = new ItsMaria('MST1005_S01', 'DEL_D2');
        var isDb = false;

        for (var j = 0; j < arrRow.length; j++) {
            if (IS_SAVED_ROW('grid3', arrRow[j], 'ORG_SCORE')) {
                maria.AddList('D2_SCORE_LIST', ItsGrid.GetValue('grid3', arrRow[j], 'ORG_SCORE'));
                isDb = true;
            }
        }

        if (isDb) {
            maria.AddParam('REVCD', GET_REVCD());
            maria.AddParam('GMCD', ItsGrid.GetValue('grid2', ItsGrid.GetCurrentIndex('grid2'), 'GMCD'));
            maria.CallProc();
            if (maria.isError) {
                maria.ShowErrMsg();
                return;
            }
        }

        for (var k = arrRow.length - 1; k >= 0; k--) {
            ItsGrid.RemoveRow('grid3', arrRow[k]);
        }

        ItsMsg.Alert(ItsMsg.CommonMsg.DeleteComplete(arrRow.length));
    });
};

// 2026-11-04 [설비등급 기준 영역] 설비등급 행 추가
ItsButton.Event('btn_ADD_SCORE').onClick = function () {
    if (GET_REVCD() == '') {
        ItsMsg.Alert('리비전을 먼저 선택하세요.');
        return;
    }

    ItsGrid.AddRow('grid4', ItsGrid.Length('grid4'), { isRowCheck: true });
};

// 2026-11-04 [설비등급 기준 영역] 체크한 설비등급 삭제 (저장된 행만 조회 시점 설비등급으로 DB 삭제, 신규 행은 화면에서만 제거)
ItsButton.Event('btn_DEL_SCORE').onClick = function () {
    var arrRow = GET_CHECKED_ROWS('grid4');

    if (arrRow.length == 0) {
        ItsMsg.Alert('삭제할 행을 체크하세요.');
        return;
    }

    ItsMsg.Confirm(arrRow.length + '건을 삭제하시겠습니까?', function () {
        var maria = new ItsMaria('MST1005_S01', 'DEL_SCORE');
        var isDb = false;

        for (var j = 0; j < arrRow.length; j++) {
            if (IS_SAVED_ROW('grid4', arrRow[j], 'ORG_EQMGRADE')) {
                maria.AddList('EQMGRADE_LIST', ItsGrid.GetValue('grid4', arrRow[j], 'ORG_EQMGRADE'));
                isDb = true;
            }
        }

        if (isDb) {
            maria.AddParam('REVCD', GET_REVCD());
            maria.CallProc();
            if (maria.isError) {
                maria.ShowErrMsg();
                return;
            }
        }

        for (var k = arrRow.length - 1; k >= 0; k--) {
            ItsGrid.RemoveRow('grid4', arrRow[k]);
        }

        ItsMsg.Alert(ItsMsg.CommonMsg.DeleteComplete(arrRow.length));
    });
};
