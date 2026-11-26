/// <reference path="../../Script/reference.js" />

// 2026-11-26 설비그룹 점검계획 탭 삭제 (설비별 점검계획만 씀, 프로시저 PLANTP = 'E')
//            점검주기는 이 화면에서 선택, 점검기준(글자) 입력 → 판정범위 자동 해석 (CHKSTD_PARSE), 점검항목 위치사진

/* 페이지 접근 시 수행 */
ItsPage.Load = function () {

    // 설비 목록
    ItsGrid.Create('grid1', { isCheckBoxGrid: false, isSubTotalGrid: false }, [
        column.create('작업장', 'LINENM', { width: 80, align: 'center' }),
        column.create('공정', 'EQMTPNM', { width: 60, align: 'center' }),
        column.create('라인', 'EQMGROUP1NM', { width: 60, align: 'center' }),
        column.create('설비그룹', 'EQMGUBUNNM', { width: 100, align: 'center' }),
        column.create('설비코드', 'FANO', { width: 80, align: 'center' }),
        column.create('설비명', 'EQMNM', { width: 200 }),
        column.create('REV', 'REVNM', { width: 100, align: 'center' }),
        column.create('승인상태', 'APRVSTTNM', { width: 65, align: 'center' }),
        column.split()
    ]);

    // 개정 이력(REV)
    ItsGrid.Create('grid_EQM_REV', { isCheckBoxGrid: false, isSubTotalGrid: false }, [
        column.create('REV', 'REVNM', { width: 100, align: 'center' }),
        column.create('상태', 'APRVSTTNM', { width: 60, align: 'center' }),
        column.create('개정내용', 'REMARK', { width: 260, readOnly: false }),
        column.create('작성자', 'REQEMP', { width: 80, align: 'center' }),
        column.create('수정일시', 'REQTIME', { width: 130, align: 'center' }),
        column.create('승인자', 'APRVEMP', { width: 80, align: 'center' }),
        column.create('처리일시', 'APRVTIME', { width: 130, align: 'center' }),
        column.create('REV번호', 'REVNUM', { hidden: true }),
        column.create('상태코드', 'APRVSTT', { hidden: true }),
        column.split()
    ]);

    // 일상점검 항목
    // 2026-11-26 점검기준(입력) · 판정범위(자동) · 점검주기(선택) · 위치사진 장수
    ItsGrid.Create('grid3', { isCheckBoxGrid: true, isSubTotalGrid: false }, [
        column.create('점검코드', 'CHKKNDCD', { width: 80, align: 'center' }),
        column.create('점검명', 'CHKKNDNM', { width: 220 }),
        column.create('점검항목', 'CHKLOCNM', { width: 110, align: 'center' }),
        column.create('점검방법', 'CHKMTHNM', { width: 90, align: 'center' }),
        column.create('점검값구분', 'CHKVALTPNM', { width: 80, align: 'center' }),
        column.create('점검기준', 'CHKSTD', { width: 150, readOnly: false }),
        column.create('판정범위', 'STDRANGE', { width: 110, align: 'center' }),
        column.create('점검주기', 'CHKCYCLE', { width: 90, align: 'center', columnType: enumColumnTypes.combo, gpcd: 'CHKCYCLE', readOnly: false }),
        column.create('사진', 'IMGCNT', { width: 50, align: 'center' }),
        column.create('정렬순서', 'SORTNO', { width: 70, columnType: enumColumnTypes.number, decimalPrecision: 0, readOnly: false }),
        column.create('점검값구분코드', 'CHKVALTP', { hidden: true }),
        column.create('판정방식', 'STDTP', { hidden: true }),
        column.create('하한', 'MINVAL', { hidden: true }),
        column.create('상한', 'MAXVAL', { hidden: true }),
        column.split()
    ]);

    // 설비 복사 팝업: 복사 원본 설비
    ItsGrid.Create('grid7', { isCheckBoxGrid: false, isSubTotalGrid: false }, [
        column.create('설비코드', 'PLANCD', { width: 100, align: 'center' }),
        column.create('설비명', 'PLANNM', { width: 150 }),
        column.create('일상점검 건수', 'ITEMCNT', { width: 80, columnType: enumColumnTypes.number, decimalPrecision: 0 }),
        column.split()
    ]);

    // 설비 복사 팝업: 복사 원본 일상점검 항목
    ItsGrid.Create('grid8', { isCheckBoxGrid: false, isSubTotalGrid: false }, [
        column.create('점검코드', 'CHKKNDCD', { width: 70, align: 'center' }),
        column.create('점검명', 'CHKKNDNM', { width: 250 }),
        column.create('점검항목', 'CHKLOCNM', { width: 110, align: 'center' }),
        column.create('점검방법', 'CHKMTHNM', { width: 90, align: 'center' }),
        column.create('점검값구분', 'CHKVALTPNM', { width: 80, align: 'center' }),
        column.create('점검기준', 'CHKSTD', { width: 130 }),
        column.create('점검주기', 'CHKCYCLE', { width: 80, align: 'center', columnType: enumColumnTypes.combo, gpcd: 'CHKCYCLE', readOnly: true }),
        column.split()
    ]);

    // 일상점검 항목 추가 팝업 (2026-11-26 점검주기 열 삭제: 추가 후 일상점검 그리드에서 선택)
    ItsGrid.Create('grid10', { isCheckBoxGrid: true, isSubTotalGrid: false }, [
        column.create('점검코드', 'CHKKNDCD', { width: 70, align: 'center' }),
        column.create('점검명', 'CHKKNDNM', { width: 300 }),
        column.create('점검항목', 'CHKLOCNM', { width: 130, align: 'center' }),
        column.create('점검방법', 'CHKMTHNM', { width: 100, align: 'center' }),
        column.create('점검값구분', 'CHKVALTPNM', { width: 90, align: 'center' }),
        column.split()
    ]);

    // 위치사진 팝업의 [✕] → 사진 삭제 (등록 삭제 후, 다른 REV 가 안 쓰는 파일이면 파일도 삭제)
    $('#pop_IMG_LIST').on('click', '.del', function () {
        var fileKey = $(this).data('filekey');
        ItsMsg.Confirm('사진을 삭제하시겠습니까?', function () {
            var maria = new ItsMaria('PRD6001_R02', 'DEL_ITEMIMG');
            maria.AddParam('PLANTP', 'E');
            maria.AddParam('PLANCD', CUR_FANO());
            maria.AddParam('REVNUM', ItsGrid.GetValue('grid_EQM_REV', 0, 'REVNUM'));
            maria.AddParam('CHKKNDCD', ItsText.GetValue('pop_IMG_txt_CHKKNDCD'));
            maria.AddParam('FILEKEY', fileKey);
            maria.CallProc();
            if (maria.isError) {
                maria.ShowErrMsg();
                return;
            }
            if (maria.store.data.length > 0 && maria.store.data[0].FILEDELYN == 'Y') {
                ItsFileManager.Delete('pop_IMG_file', fileKey);
            }
            ItsMsg.Toast(ItsMsg.CommonMsg.DeleteComplete());
            POP_IMG_LIST('');
        });
    });

    // 위치사진 클릭 → 새 창으로 크게 보기
    $('#pop_IMG_LIST').on('click', 'img', function () {
        window.open($(this).attr('src'), '_blank');
    });
};
/**********************************************************************************************************************************************************************/
// 조회
ItsButton.EventSearch = function () {
    // 설비 목록 조회 (선택 행의 REV·점검항목은 onSelect 에서 조회)
    ItsGrid.Clear('grid_EQM_REV');
    ItsGrid.Clear('grid3');

    var maria = new ItsMaria('PRD6001_R02', 'LIST_MSTEQM');
    maria.AddPanel('div_EQM');
    maria.CallProc();
    if (maria.isError) {
        maria.ShowErrMsg();
        return;
    }

    ItsGrid.SetStore('grid1', maria.store);
    ItsGrid.Get('grid1').autoSizeColumns();   // 2026-11-26 조회 후 컬럼 너비를 내용에 맞춤 (그리드 오른쪽 클릭 '컬럼 너비 맞춤'과 같음)
    ItsMsg.Toast(ItsMsg.CommonMsg.SearchComplete(maria.store.Length()));
};

// 고른 설비코드
function CUR_FANO() {
    return ItsGrid.GetValue('grid1', ItsGrid.GetCurrentIndex('grid1'), 'FANO');
}
/**********************************************************************************************************************************************************************/
// 조회조건

// 작업장 변경 시 공정·라인 콤보와 설비 찾기를 그 작업장 기준으로 바꿈
ItsCombo.Event('cmb_LINECD').onChanged = function (value, oldValue) {
    ItsCombo.SetRef01('cmb_EQMTP', ItsCombo.GetValue('cmb_LINECD'));
    ItsCombo.SetValue('cmb_EQMTP', '', false);

    ItsCombo.SetRef01('cmb_EQMGROUP1', ItsCombo.GetValue('cmb_LINECD'), false);
    ItsCombo.SetRef02('cmb_EQMGROUP1', '');
    ItsCombo.SetValue('cmb_EQMGROUP1', '', false);

    // 설비 찾기 (DC_FIND EQMCD: REF05 작업장, REF01 공정, REF02 라인)
    ItsFind.SetRef05('find_EQMCD', ItsCombo.GetValue('cmb_LINECD'));
    ItsFind.SetRef01('find_EQMCD', '');
    ItsFind.SetRef02('find_EQMCD', '');
    ItsFind.SetValue('find_EQMCD', '');
};

// 공정 변경 시 라인 콤보와 설비 찾기를 그 공정 기준으로 바꿈
ItsCombo.Event('cmb_EQMTP').onChanged = function (value, oldValue) {
    ItsCombo.SetRef02('cmb_EQMGROUP1', ItsCombo.GetValue('cmb_EQMTP'));
    ItsCombo.SetValue('cmb_EQMGROUP1', '', false);

    ItsFind.SetRef01('find_EQMCD', ItsCombo.GetValue('cmb_EQMTP'));
    ItsFind.SetRef02('find_EQMCD', '');
    ItsFind.SetValue('find_EQMCD', '');
};

// 라인 변경 시 설비 찾기를 그 라인 기준으로 바꿈
ItsCombo.Event('cmb_EQMGROUP1').onChanged = function (value, oldValue) {
    ItsFind.SetRef02('find_EQMCD', ItsCombo.GetValue('cmb_EQMGROUP1'));
    ItsFind.SetValue('find_EQMCD', '');
};
/**********************************************************************************************************************************************************************/
// 설비 · REV · 일상점검 항목

// 설비 선택 시 개정 이력(REV) 조회
ItsGrid.Event('grid1').onSelect = function (rowIndex) {
    ItsGrid.Clear('grid3');

    var maria = new ItsMaria('PRD6001_R02', 'LIST_PLAN_REV');
    maria.AddParam('PLANTP', 'E');
    maria.AddParam('PLANCD', ItsGrid.GetValue('grid1', rowIndex, 'FANO'));
    maria.CallProc();
    if (maria.isError) {
        maria.ShowErrMsg();
        return;
    }

    ItsGrid.SetStore('grid_EQM_REV', maria.store);
};

// REV 선택 시 그 REV 의 일상점검 항목 조회
ItsGrid.Event('grid_EQM_REV').onSelect = function (rowIndex) {
    var maria = new ItsMaria('PRD6001_R02', 'LIST_PLAN_REV_ITEM');
    maria.AddParam('PLANTP', 'E');
    maria.AddParam('PLANCD', CUR_FANO());
    maria.AddParam('REVNUM', ItsGrid.GetValue('grid_EQM_REV', rowIndex, 'REVNUM'));
    maria.CallProc();
    if (maria.isError) {
        maria.ShowErrMsg();
        return;
    }

    ItsGrid.SetStore('grid3', maria.store);

    // 판정범위 글자는 저장된 판정값(STDTP, MINVAL, MAXVAL)으로 표시 (SetValue 는 행 체크를 하지 않음)
    for (var i = 0; i < ItsGrid.Length('grid3'); i++) {
        ItsGrid.SetValue('grid3', i, 'STDRANGE', STDRANGE_TEXT({
            STDTP: ItsGrid.GetValue('grid3', i, 'STDTP'),
            MINVAL: ItsGrid.GetValue('grid3', i, 'MINVAL'),
            MAXVAL: ItsGrid.GetValue('grid3', i, 'MAXVAL')
        }));
    }
};

// 점검기준을 고치면 바로 해석해서 판정범위·판정값을 바꿈
ItsGrid.Event('grid3').onChanged = function (rowIndex, field, newValue, oldValue, type) {
    if (field != 'CHKSTD') {
        return;
    }
    var r = CHKSTD_PARSE(newValue, ItsGrid.GetValue('grid3', rowIndex, 'CHKVALTP'));
    ItsGrid.SetValue('grid3', rowIndex, 'STDTP', r.STDTP);
    ItsGrid.SetValue('grid3', rowIndex, 'MINVAL', r.MINVAL);
    ItsGrid.SetValue('grid3', rowIndex, 'MAXVAL', r.MAXVAL);
    ItsGrid.SetValue('grid3', rowIndex, 'STDRANGE', r.ERROR ? '⚠ 해석 불가' : STDRANGE_TEXT(r));
};

// 사진 열 더블클릭 → 위치사진 팝업
ItsGrid.Event('grid3').onDoubleClick = function (rowIndex, field) {
    if (field == 'IMGCNT') {
        POP_IMG_OPEN(rowIndex);
    }
};

// 일상점검 항목 추가 팝업
ItsButton.Event('bdiv3_btn_ADD').onClick = function () {
    var FANO = CUR_FANO();
    if (!FANO) {
        ItsMsg.Toast('설비를 선택하세요.');
        return;
    }

    if (ItsGrid.GetCurrentIndex('grid_EQM_REV') > 0) {
        ItsMsg.Toast('최신 REV 에서만 수정할 수 있습니다.');
        return;
    }

    var maria = new ItsMaria('PRD6001_R02', 'LIST_CHKKND_ADD');
    maria.AddParam('PLANTP', 'E');
    maria.AddParam('PLANCD', FANO);
    maria.CallProc();
    if (maria.isError) {
        maria.ShowErrMsg();
        return;
    }

    ItsPop.Open('pop_EQM02_ADD');
    ItsGrid.SetStore('grid10', maria.store);
};

// 일상점검 항목 저장 (정렬순서·비고·점검주기·점검기준)
ItsButton.Event('bdiv3_btn_SAVE').onClick = function () {
    var FANO = CUR_FANO();

    if (ItsGrid.GetCurrentIndex('grid_EQM_REV') > 0) {
        ItsMsg.Toast('최신 REV 에서만 수정할 수 있습니다.');
        return;
    }

    ItsGrid.FinishEditing('grid3');

    var hasChecked = false;
    for (var i = 0; i < ItsGrid.Length('grid3'); i++) {
        if (!ItsGrid.IsChecked('grid3', i)) {
            continue;
        }
        hasChecked = true;

        // 저장 전에 점검기준을 다시 해석 (해석 못 하는 기준·점검값구분과 안 맞는 기준은 저장 안 함)
        var r = CHKSTD_PARSE(ItsGrid.GetValue('grid3', i, 'CHKSTD'), ItsGrid.GetValue('grid3', i, 'CHKVALTP'));
        if (r.ERROR) {
            ItsMsg.Alert('점검기준을 해석할 수 없습니다.\n\n- 점검명: ' + ItsGrid.GetValue('grid3', i, 'CHKKNDNM')
                + '\n- 점검기준: ' + ItsGrid.GetValue('grid3', i, 'CHKSTD') + '\n\n' + r.ERROR);
            return;
        }
        ItsGrid.SetValue('grid3', i, 'STDTP', r.STDTP);
        ItsGrid.SetValue('grid3', i, 'MINVAL', r.MINVAL);
        ItsGrid.SetValue('grid3', i, 'MAXVAL', r.MAXVAL);
        ItsGrid.SetValue('grid3', i, 'STDRANGE', STDRANGE_TEXT(r));
    }

    if (!hasChecked) {
        ItsMsg.Toast('선택된 항목이 없습니다.');
        return;
    }

    ItsMsg.Confirm('선택한 점검항목을 저장하시겠습니까?', function () {
        var maria = new ItsMaria('PRD6001_R02', 'SAVE_PLAN_ITEM');
        maria.AddParam('PLANTP', 'E');
        maria.AddParam('PLANCD', FANO);
        maria.AddParam('REVNUM', ItsGrid.GetValue('grid_EQM_REV', 0, 'REVNUM'));

        for (var i = 0; i < ItsGrid.Length('grid3'); i++) {
            if (ItsGrid.IsChecked('grid3', i)) {
                maria.AddList('CHKKNDCD_LIST', ItsGrid.GetValue('grid3', i, 'CHKKNDCD'));
                maria.AddList('SORTNO_LIST', ItsGrid.GetValue('grid3', i, 'SORTNO'));
                maria.AddList('REMARK_LIST', ItsGrid.GetValue('grid3', i, 'REMARK'));
                maria.AddList('CHKCYCLE_LIST', ItsGrid.GetValue('grid3', i, 'CHKCYCLE'));
                maria.AddList('CHKSTD_LIST', ItsGrid.GetValue('grid3', i, 'CHKSTD'));
                maria.AddList('STDTP_LIST', ItsGrid.GetValue('grid3', i, 'STDTP'));
                maria.AddList('MINVAL_LIST', ItsGrid.GetValue('grid3', i, 'MINVAL'));
                maria.AddList('MAXVAL_LIST', ItsGrid.GetValue('grid3', i, 'MAXVAL'));
            }
        }

        maria.CallProc();
        if (maria.isError) {
            maria.ShowErrMsg();
            return;
        }

        ItsMsg.Toast(ItsMsg.CommonMsg.SaveComplete());
        ItsGrid.Setkey('grid1', 'FANO', FANO);
        ItsButton.EventSearch();
    }, function () {
        ItsMsg.Toast('저장이 취소되었습니다.');
    });
};

// 일상점검 항목 삭제
ItsButton.Event('bdiv3_btn_DEL').onClick = function () {
    var FANO = CUR_FANO();

    if (ItsGrid.GetCurrentIndex('grid_EQM_REV') > 0) {
        ItsMsg.Toast('최신 REV 에서만 수정할 수 있습니다.');
        return;
    }

    var hasChecked = false;
    for (var i = 0; i < ItsGrid.Length('grid3'); i++) {
        if (ItsGrid.IsChecked('grid3', i)) {
            hasChecked = true;
            break;
        }
    }

    if (!hasChecked) {
        ItsMsg.Toast('선택된 항목이 없습니다.');
        return;
    }

    ItsMsg.Confirm('선택한 점검항목을 삭제하시겠습니까?', function () {
        var maria = new ItsMaria('PRD6001_R02', 'DELETE_PLAN_ITEM');
        maria.AddParam('PLANTP', 'E');
        maria.AddParam('PLANCD', FANO);
        maria.AddParam('REVNUM', ItsGrid.GetValue('grid_EQM_REV', 0, 'REVNUM'));

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
        ItsGrid.Setkey('grid1', 'FANO', FANO);
        ItsButton.EventSearch();
    }, function () {
        ItsMsg.Toast('삭제가 취소되었습니다.');
    });
};

// 일상점검 항목 복사 팝업
ItsButton.Event('bdiv3_btn_COPY').onClick = function () {
    var FANO = CUR_FANO();
    if (!FANO) {
        ItsMsg.Toast('설비를 선택하세요.');
        return;
    }

    if (ItsGrid.GetCurrentIndex('grid_EQM_REV') > 0) {
        ItsMsg.Toast('최신 REV 에서만 수정할 수 있습니다.');
        return;
    }

    ItsGrid.Clear('grid8');

    var maria = new ItsMaria('PRD6001_R02', 'LIST_COPY_PLAN');
    maria.AddParam('PLANTP', 'E');
    maria.AddParam('PLANCD', FANO);
    maria.CallProc();
    if (maria.isError) {
        maria.ShowErrMsg();
        return;
    }

    ItsPop.Open('pop_EQM02_COPY');
    ItsGrid.SetStore('grid7', maria.store);
};

// 복사 원본 설비 선택 시 일상점검 항목 조회
ItsGrid.Event('grid7').onSelect = function (rowIndex) {
    var maria = new ItsMaria('PRD6001_R02', 'LIST_PLAN_REV_ITEM');
    maria.AddParam('PLANTP', 'E');
    maria.AddParam('PLANCD', ItsGrid.GetValue('grid7', rowIndex, 'PLANCD'));
    maria.AddParam('REVNUM', '');
    maria.CallProc();
    if (maria.isError) {
        maria.ShowErrMsg();
        return;
    }

    ItsGrid.SetStore('grid8', maria.store);
};

// 일상점검 항목 복사 (선택한 설비의 항목·점검기준·위치사진으로 전체 교체)
ItsButton.Event('btn_COPY_EQM02').onClick = function () {
    var FANO = CUR_FANO();

    ItsMsg.Confirm('선택한 설비의 점검항목으로 복사하시겠습니까?', function () {
        var maria = new ItsMaria('PRD6001_R02', 'COPY_PLAN_ITEM');
        maria.AddParam('PLANTP', 'E');
        maria.AddParam('PLANCD', FANO);
        maria.AddParam('PLANCD_COPY', ItsGrid.GetValue('grid7', ItsGrid.GetCurrentIndex('grid7'), 'PLANCD'));
        maria.AddParam('REVNUM', ItsGrid.Length('grid_EQM_REV') > 0 ? ItsGrid.GetValue('grid_EQM_REV', 0, 'REVNUM') : '');
        maria.CallProc();
        if (maria.isError) {
            maria.ShowErrMsg();
            return;
        }

        ItsPop.Close('pop_EQM02_COPY');
        ItsMsg.Toast(ItsMsg.CommonMsg.CopyComplete());
        ItsGrid.Setkey('grid1', 'FANO', FANO);
        ItsButton.EventSearch();
    }, function () {
        ItsMsg.Toast('복사가 취소되었습니다.');
    });
};

// 복사 팝업 닫기
ItsButton.Event('btn_CANCEL_COPY_EQM02').onClick = function () {
    ItsPop.Close('pop_EQM02_COPY');
};

// 개정내용 저장 (승인요청)
ItsButton.Event('btn_EQM_REV_SAVE').onClick = function () {
    var FANO = CUR_FANO();

    if (ItsGrid.Length('grid_EQM_REV') == 0) {
        ItsMsg.Toast('저장할 REV 가 없습니다. 점검항목을 먼저 등록하세요.');
        return;
    }

    ItsGrid.FinishEditing('grid_EQM_REV');

    ItsMsg.Confirm('개정내용을 저장하시겠습니까?', function () {
        var maria = new ItsMaria('PRD6001_R02', 'SAVE_PLAN_REV');
        maria.AddParam('PLANTP', 'E');
        maria.AddParam('PLANCD', FANO);
        maria.AddParam('REVNUM', ItsGrid.GetValue('grid_EQM_REV', 0, 'REVNUM'));
        maria.AddParam('REMARK', ItsGrid.GetValue('grid_EQM_REV', 0, 'REMARK'));
        maria.CallProc();
        if (maria.isError) {
            maria.ShowErrMsg();
            return;
        }

        ItsMsg.Toast(ItsMsg.CommonMsg.SaveComplete());
        ItsGrid.Setkey('grid1', 'FANO', FANO);
        ItsButton.EventSearch();
    });
};

// 최신 REV 승인
ItsButton.Event('btn_EQM_APPROVE').onClick = function () {
    var FANO = CUR_FANO();

    if (ItsGrid.Length('grid_EQM_REV') == 0) {
        ItsMsg.Toast('승인할 REV 가 없습니다.');
        return;
    }

    ItsMsg.Confirm('[' + FANO + '] ' + ItsGrid.GetValue('grid_EQM_REV', 0, 'REVNM') + '을 승인하시겠습니까?', function () {
        var maria = new ItsMaria('PRD6001_R02', 'SAVE_PLAN_STATUS');
        maria.AddParam('PLANTP', 'E');
        maria.AddParam('PLANCD', FANO);
        maria.AddParam('REVNUM', ItsGrid.GetValue('grid_EQM_REV', 0, 'REVNUM'));
        maria.AddParam('REMARK', ItsGrid.GetValue('grid_EQM_REV', 0, 'REMARK'));
        maria.CallProc();
        if (maria.isError) {
            maria.ShowErrMsg();
            return;
        }

        ItsMsg.Toast('승인 처리가 완료되었습니다.');
        ItsGrid.Setkey('grid1', 'FANO', FANO);
        ItsButton.EventSearch();
    });
};

// 점검표 출력 (2026-11-26 정기점검 계획서 EQM1001_R03 → 설비 일상점검표 PRD6001_R02, 고른 REV, 없으면 최신)
ItsButton.Event('btn_EQM_PLAN_RPT').onClick = function () {
    var FANO = CUR_FANO();
    if (!FANO) {
        ItsMsg.Toast('설비를 선택하세요.');
        return;
    }

    var revIndex = ItsGrid.GetCurrentIndex('grid_EQM_REV');
    var rpt = new ItsXtraRpt('PRD6001_R02');
    rpt.AddParam('PLANTP', 'E');
    rpt.AddParam('PLANCD', FANO);
    rpt.AddParam('REVNUM', revIndex < 0 ? '' : ItsGrid.GetValue('grid_EQM_REV', revIndex, 'REVNUM'));
    rpt.CallPop();
    if (rpt.isError) {
        ItsMsg.Alert(rpt.errMessage);
    }
};
/**********************************************************************************************************************************************************************/
// 일상점검 항목 추가 팝업

// 체크한 항목 추가
ItsButton.Event('btn_ADD_EQM02').onClick = function () {
    var hasChecked = false;
    for (var i = 0; i < ItsGrid.Length('grid10'); i++) {
        if (ItsGrid.IsChecked('grid10', i)) {
            hasChecked = true;
            break;
        }
    }

    if (!hasChecked) {
        ItsMsg.Toast('선택된 항목이 없습니다.');
        return;
    }

    var PLANCD = CUR_FANO();
    var maria = new ItsMaria('PRD6001_R02', 'ADD_PLAN_ITEM');
    maria.AddParam('PLANTP', 'E');
    maria.AddParam('PLANCD', PLANCD);
    maria.AddParam('REVNUM', ItsGrid.Length('grid_EQM_REV') > 0 ? ItsGrid.GetValue('grid_EQM_REV', 0, 'REVNUM') : '');

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

    ItsPop.Close('pop_EQM02_ADD');
    ItsMsg.Toast(ItsMsg.CommonMsg.AddComplete);
    ItsGrid.Setkey('grid1', 'FANO', PLANCD);
    ItsButton.EventSearch();
};

// 팝업 닫기
ItsButton.Event('btn_CANCEL_ADD_EQM02').onClick = function () {
    ItsPop.Close('pop_EQM02_ADD');
};
/**********************************************************************************************************************************************************************/
// 2026-11-26 점검항목 위치사진 팝업

// [위치사진] 버튼 → 고른 점검항목의 사진 팝업
ItsButton.Event('bdiv3_btn_IMG').onClick = function () {
    var rowIndex = ItsGrid.GetCurrentIndex('grid3');
    if (rowIndex < 0 || !ItsGrid.GetValue('grid3', rowIndex, 'CHKKNDCD')) {
        ItsMsg.Toast('점검항목을 선택하세요.');
        return;
    }
    POP_IMG_OPEN(rowIndex);
};

function POP_IMG_OPEN(rowIndex) {
    var revIndex = ItsGrid.GetCurrentIndex('grid_EQM_REV');
    ItsText.SetValue('pop_IMG_txt_CHKKNDCD', ItsGrid.GetValue('grid3', rowIndex, 'CHKKNDCD'));
    ItsText.SetValue('pop_IMG_txt_CHKKNDNM', ItsGrid.GetValue('grid3', rowIndex, 'CHKKNDNM'));
    ItsText.SetValue('pop_IMG_txt_REVNM', ItsGrid.GetValue('grid_EQM_REV', revIndex, 'REVNM'));

    // 예전 REV 는 보기만 (올리기·삭제는 최신 REV 에서)
    var editable = (revIndex <= 0);
    $('div#pop_IMG_file').toggle(editable);   // ItsFileManager 바깥 div 의 id 가 컨트롤 ID
    ItsFileManager.Clear('pop_IMG_file');

    POP_IMG_LIST(editable ? '' : ItsGrid.GetValue('grid_EQM_REV', revIndex, 'REVNUM'), editable);
    ItsPop.Open('pop_IMG');
}

// 사진 목록 (revNum 빈값 = 최신 REV)
function POP_IMG_LIST(revNum, editable) {
    if (editable === undefined) {
        editable = true;
    }
    var maria = new ItsMaria('PRD6001_R02', 'LIST_ITEMIMG');
    maria.AddParam('PLANTP', 'E');
    maria.AddParam('PLANCD', CUR_FANO());
    maria.AddParam('REVNUM', revNum);
    maria.AddParam('CHKKNDCD', ItsText.GetValue('pop_IMG_txt_CHKKNDCD'));
    maria.CallProc();
    if (maria.isError) {
        maria.ShowErrMsg();
        return;
    }
    var html = '';
    maria.store.data.forEach(function (img) {
        html += '<div class="item"><img src="' + img.FILEURL + '" />'
            + (editable ? '<span class="del" data-filekey="' + img.FILEKEY + '">✕</span>' : '') + '</div>';
    });
    if (html == '') {
        html = '<span class="empty">사진 없음</span>';
    }
    $('#pop_IMG_LIST').html(html);
}

// 사진 선택 → 바로 업로드 → 파일키 등록 (최신 REV 가 승인돼 있으면 프로시저가 새 REV 를 만듦)
ItsFileManager.Event('pop_IMG_file').onFileChange = function (id) {
    ItsFileManager.Upload(id);
};
ItsFileManager.Event('pop_IMG_file').onUpload = function (id, fileKey) {
    var maria = new ItsMaria('PRD6001_R02', 'ADD_ITEMIMG');
    maria.AddParam('PLANTP', 'E');
    maria.AddParam('PLANCD', CUR_FANO());
    maria.AddParam('REVNUM', ItsGrid.GetValue('grid_EQM_REV', 0, 'REVNUM'));
    maria.AddParam('CHKKNDCD', ItsText.GetValue('pop_IMG_txt_CHKKNDCD'));
    maria.AddParam('FILEKEY', fileKey);
    maria.CallProc();
    if (maria.isError) {
        maria.ShowErrMsg();
        ItsFileManager.Delete(id, fileKey);   // 등록 못 한 파일은 지움
        return;
    }
    ItsFileManager.Clear(id);
    POP_IMG_LIST('');
};

// 팝업 닫힘 → 사진 장수·REV(새 REV 가 생겼을 수 있음) 다시 조회
ItsPop.Event('pop_IMG').onPopClosed = function () {
    var FANO = CUR_FANO();
    ItsGrid.Setkey('grid1', 'FANO', FANO);
    ItsButton.EventSearch();
};
/**********************************************************************************************************************************************************************/
// 2026-11-26 점검기준 글자 해석 (혼합 방식: 글자로 입력 → 판정범위로 해석해 저장 → 점검등록은 저장된 하한·상한으로 자동판정)
//
//   0.5 ±0.1MPa / 0.5+-0.1 / 0.5±0.1     → RANGE  0.4 ~ 0.6
//   5%~15% / 5 ~ 15 / MIN 100 ~ MAX 220L  → RANGE  5 ~ 15
//   30% 이상 / 30%↑ / ≥30 / 30 >=         → RANGE  30 이상 (상한 없음)
//   0.3 이하 / 0.3↓ / ≤0.3                → RANGE  0.3 이하 (하한 없음)
//   OK/NG 마스터 / 작동여부 확인          → OKNG   (점검값 OK 면 합격)
//
//   점검값구분(CHKVALTP)이 '01'(수치) 이면 숫자 기준만, 그 밖(OK/NG)이면 글자와 상관없이 OKNG
//   결과: { STDTP: 'RANGE'|'OKNG'|'', MINVAL: '0.4'|'', MAXVAL: '0.6'|'', ERROR: ''|안내문 }
function CHKSTD_PARSE(text, chkValTp) {
    var r = { STDTP: '', MINVAL: '', MAXVAL: '', ERROR: '' };
    var s = $.trim(text || '');
    if (s == '') {
        return r;   // 기준 없음 (판정 안 함)
    }

    if (chkValTp != '01') {
        r.STDTP = 'OKNG';
        return r;
    }

    // 공백·천단위 쉼표 제거, 비슷한 기호 통일
    var t = s.replace(/\s+/g, '').replace(/,/g, '')
        .replace(/[＋]/g, '+').replace(/[－−–—]/g, '-').replace(/[～〜]/g, '~')
        .replace(/\+\/-|\+-|-\+/g, '±');
    var N = '(-?\\d+(?:\\.\\d+)?)';
    var m;

    // 기준 ± 공차
    m = t.match(new RegExp(N + '[^\\d±]*±' + N));
    if (m) {
        var dec = Math.max(DECIMALS(m[1]), DECIMALS(m[2]));
        r.STDTP = 'RANGE';
        r.MINVAL = NUM_TEXT(parseFloat(m[1]) - parseFloat(m[2]), dec);
        r.MAXVAL = NUM_TEXT(parseFloat(m[1]) + parseFloat(m[2]), dec);
        return r;
    }

    // 하한 ~ 상한 (사이에 단위·MIN/MAX 글자가 있어도 됨)
    m = t.match(new RegExp(N + '[^\\d~]*~[^\\d-]*' + N));
    if (m) {
        var a = parseFloat(m[1]), b = parseFloat(m[2]);
        r.STDTP = 'RANGE';
        r.MINVAL = NUM_TEXT(Math.min(a, b), DECIMALS(a < b ? m[1] : m[2]));
        r.MAXVAL = NUM_TEXT(Math.max(a, b), DECIMALS(a < b ? m[2] : m[1]));
        return r;
    }

    // 이상
    m = t.match(new RegExp(N + '[^\\d]*(이상|↑|>=|≥)')) || t.match(new RegExp('(?:>=|≥)' + N));
    if (m) {
        r.STDTP = 'RANGE';
        r.MINVAL = NUM_TEXT(parseFloat(m[1]), DECIMALS(m[1]));
        return r;
    }

    // 이하
    m = t.match(new RegExp(N + '[^\\d]*(이하|↓|<=|≤)')) || t.match(new RegExp('(?:<=|≤)' + N));
    if (m) {
        r.STDTP = 'RANGE';
        r.MAXVAL = NUM_TEXT(parseFloat(m[1]), DECIMALS(m[1]));
        return r;
    }

    if (/\d/.test(t)) {
        r.ERROR = '숫자 기준은 아래 형식으로 입력하세요.\n0.5 ±0.1MPa / 5%~15% / 30% 이상 / 0.3 이하';
    } else {
        r.ERROR = '점검값구분이 수치인 항목은 숫자 기준을 입력하세요.\n예) 0.5 ±0.1MPa / 5%~15% / 30% 이상 / 0.3 이하';
    }
    return r;
}

// 판정범위 표시 글자
function STDRANGE_TEXT(r) {
    if (r.STDTP == 'OKNG') {
        return 'OK/NG';
    }
    if (r.STDTP != 'RANGE') {
        return '';
    }
    if (r.MINVAL !== '' && r.MAXVAL !== '') {
        return r.MINVAL + ' ~ ' + r.MAXVAL;
    }
    if (r.MINVAL !== '') {
        return r.MINVAL + ' 이상';
    }
    if (r.MAXVAL !== '') {
        return r.MAXVAL + ' 이하';
    }
    return '';
}

// 소수 자릿수 ("0.25" → 2)
function DECIMALS(numText) {
    var p = String(numText).split('.');
    return p.length > 1 ? p[1].length : 0;
}

// 계산 오차를 자릿수로 정리해 글자로 (0.5 - 0.1 = 0.39999… → "0.4")
function NUM_TEXT(value, dec) {
    return String(parseFloat(value.toFixed(dec)));
}
