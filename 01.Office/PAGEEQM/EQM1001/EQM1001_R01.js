/// <reference path="../../Script/reference.js" />

ItsPage.Load = function () {

    ItsGrid.Create('grid1', { isCheckBoxGrid: true, isSubTotalGrid: true }, [
        column.create('수리키', 'EQMREPKEY', { width: 130, align: 'center', readOnly: true }),
        column.create('공장', 'FACTORYCD', { width: 100, align: 'center', columnType: enumColumnTypes.combo, gpcd: 'FACTORYCD', readOnly: true }),
        column.create('작업장', 'LINECD', { width: 80, align: 'center', columnType: enumColumnTypes.combo, gpcd: 'LINECD', readOnly: true }),
        column.create('공정', 'EQMTP', { width: 80, align: 'center', columnType: enumColumnTypes.combo, gpcd: 'FM100', readOnly: true }),
        column.create('라인', 'EQMGROUP1', { width: 80, align: 'center', columnType: enumColumnTypes.combo, gpcd: 'FM113', readOnly: true }),
        column.create('설비코드', 'EQMCD', { width: 110, readOnly: true }),
        column.create('설비명', 'EQMNM', { width: 180, readOnly: true }),
        column.create('수리시작일자', 'REPSDAY', { width: 100, align: 'center', readOnly: true, columnType: enumColumnTypes.date }),
        column.create('시작시간', 'REPSTIME', { width: 70, align: 'center', readOnly: true, mask: "00:00" }),
        column.create('수리종료일자', 'REPEDAY', { width: 100, align: 'center', readOnly: true, columnType: enumColumnTypes.date }),
        column.create('종료시간', 'REPETIME', { width: 70, align: 'center', readOnly: true, mask: "00:00" }),
        column.create('수리시간(분)', 'REPMIN', { width: 85, columnType: enumColumnTypes.number, decimalPrecision: 0, readOnly: true, groupType: enumGrouping.sum }),
        column.split()
    ]);

    // 공무작업일지 작업자·사용 부품 그리드 (wl = 가운데 수정, pop1 = 등록 팝업)
    WORKLOG_CREATE_GRIDS('wl');
    WORKLOG_CREATE_GRIDS('pop1');

    // 공무작업일지 등록할 수리 기록 선택 (태블릿 수리시작·종료 기록)
    ItsGrid.Create('grid_REPSEL', {}, [
        column.create('수리종료', 'REPETIME', { width: 130, align: 'center', readOnly: true }),
        column.create('수리시작', 'REPSTIME', { width: 130, align: 'center', readOnly: true }),
        column.create('수리시간(분)', 'REPMIN', { width: 85, columnType: enumColumnTypes.number, decimalPrecision: 0, readOnly: true }),
        column.create('작업장', 'LINECD', { width: 80, align: 'center', columnType: enumColumnTypes.combo, gpcd: 'LINECD', readOnly: true }),
        column.create('설비명', 'EQMNM', { width: 180, readOnly: true }),
        column.create('구분', 'REPGUBUN', { width: 70, align: 'center', readOnly: true }),
        column.create('작업자', 'EMPNMS', { width: 140, readOnly: true }),
        column.create('고장현상(호출이유)', 'MALFUNCTION', { width: 160, readOnly: true }),
        column.create('설비수리키', 'EQMREPKEY', { width: 100, hidden: true })
    ]);

    // 공무작업일지 출고 부품 선택
    ItsGrid.Create('grid_PART', { isCheckBoxGrid: true }, [
        column.create('출고일자', 'INOUTDATE', { width: 95, align: 'center', readOnly: true }),
        column.create('구분', 'OUTGUBUN', { width: 85, align: 'center', readOnly: true }),
        column.create('라인', 'EQMGROUP1NM', { width: 70, align: 'center', readOnly: true }),
        column.create('품목코드', 'ITEMCD', { width: 120, readOnly: true }),
        column.create('품목명', 'ITEMNM', { width: 200, readOnly: true }),
        column.create('규격', 'ITEMSPEC', { width: 180, readOnly: true }),
        column.create('단위', 'ITEMUNIT', { width: 60, align: 'center', columnType: enumColumnTypes.combo, gpcd: 'DM150', readOnly: true }),
        column.create('출고수량', 'INOUTQTY', { width: 85, columnType: enumColumnTypes.number, decimalPrecision: 2, readOnly: true }),
        column.create('사용수량', 'USEDQTY', { width: 85, columnType: enumColumnTypes.number, decimalPrecision: 2, readOnly: true }),
        column.create('출고키', 'INOUTKEY', { width: 100, hidden: true }),
        column.create('품목ID', 'ITEMID', { width: 80, hidden: true })
    ]);

    // 그리드 Row 높이 자동설정
    ItsGrid.Get('grid1').autoRowHeights = true;

    // 팝업 안 그리드 콤보 목록·날짜 달력이 셀과 떨어진 곳에 뜨는 문제 보정 (ItsGrid.css 의 position:fixed·transform 지정으로 wijmo 위치값이 무시됨 → 셀 바로 아래, 공간이 없으면 위로 다시 놓음)
    var orgShowPopup = wijmo.showPopup;
    wijmo.showPopup = function (popup, ref) {
        var ret = orgShowPopup.apply(this, arguments);
        if (ref instanceof HTMLElement && popup.parentElement != document.body && $(ref).closest('.ui-dialog').length > 0) {
            var rc = ref.getBoundingClientRect();
            var top = rc.bottom;
            if (top + popup.offsetHeight > window.innerHeight && rc.top > popup.offsetHeight) top = rc.top - popup.offsetHeight;
            popup.style.transform = 'none';
            popup.style.left = Math.max(0, Math.min(rc.left, window.innerWidth - popup.offsetWidth)) + 'px';
            popup.style.top = top + 'px';
        }
        return ret;
    };

    ItsDateRange.SetInitValueFrom('date_SEARCH', ItsHelper.AddDay(-7, ItsHelper.GetYearMonthDay()));

    // 2026-11-09 [수리 사진] 썸네일 클릭 시 미리보기 변경, [✕] 클릭 시 사진 삭제
    $('#div_REPIMG_LIST').on('click', '.repimg-thumb', function () {
        REPIMG_SELECT(parseInt($(this).attr('data-index'), 10));
    });
    $('#div_REPIMG_LIST').on('click', '.repimg-del', function (e) {
        e.stopPropagation();
        REPIMG_DELETE($(this).attr('data-filekey'));
    });
    REPIMG_LIST('');
};

// 작업장 변경 시 공정·라인 콤보를 그 작업장 기준으로 변경
ItsCombo.Event('cmb_LINECD').onChanged = function (value, oldValue) {
    ItsCombo.SetRef01('cmb_EQMTP', ItsCombo.GetValue('cmb_LINECD'));
    ItsCombo.SetValue('cmb_EQMTP', '', false);

    ItsCombo.SetRef01('cmb_EQMGROUP1', ItsCombo.GetValue('cmb_LINECD'), false);
    ItsCombo.SetRef02('cmb_EQMGROUP1', '');
    ItsCombo.SetValue('cmb_EQMGROUP1', '', false);
};

// 공정 변경 시 라인 콤보를 그 공정 기준으로 변경
ItsCombo.Event('cmb_EQMTP').onChanged = function (value, oldValue) {
    ItsCombo.SetRef02('cmb_EQMGROUP1', ItsCombo.GetValue('cmb_EQMTP'));
    ItsCombo.SetValue('cmb_EQMGROUP1', '', false);
};

/* 조회 (공무작업일지를 작성한 수리 기록만) */
ItsButton.EventSearch = function () {
    WORKLOG_PANEL_OPEN('');
    var maria = new ItsMaria('EQM1001_R01', 'LIST_EQMREP');
    maria.AddPanel('sdiv1');
    maria.CallProc();
    if (maria.isError) {
        maria.ShowErrMsg();
        return;
    }
    ItsGrid.SetStore('grid1', maria.store);
    ItsGrid.Get('grid1').autoSizeColumns();
    ItsMsg.Toast(ItsMsg.CommonMsg.SearchComplete(maria.store.Length()));
};

// 2026-11-09 선택한 수리이력의 사진 목록도 함께 조회
// 선택한 공무작업일지를 가운데에 불러와 수정 (사진은 오른쪽)
ItsGrid.Event('grid1').onSelect = function () {
    var eqmRepKey = ItsGrid.GetValue('grid1', ItsGrid.GetCurrentIndex('grid1'), 'EQMREPKEY');
    if (eqmRepKey == WL_KEY.wl) {
        return;
    }
    WORKLOG_PANEL_OPEN(eqmRepKey);
}

// 화면별 공무작업일지 수리키 (wl = 가운데 수정, pop1 = 등록 팝업), 새 수리 기록은 만들지 않고 이 기록에 저장
var WL_KEY = { wl: '', pop1: '' };
// 출고 부품 선택 팝업이 부품을 넣을 화면 (wl / pop1)
var partTarget = 'wl';

// 추가: 조회조건(수리종료일·작업장·공정·라인·설비)으로 공무작업일지를 아직 작성하지 않은 수리 기록 선택 → 등록 팝업
ItsButton.EventAdd = function () {
    var maria = new ItsMaria('EQM1001_R01', 'LIST_REP_WAIT');
    maria.AddPanel('sdiv1');
    maria.CallProc();
    if (maria.isError) {
        maria.ShowErrMsg();
        return;
    }
    if (maria.store.Length() == 0) {
        ItsMsg.Toast('조회기간(수리종료일)에 공무작업일지를 등록할 수리 기록이 없습니다.');
        return;
    }
    ItsGrid.SetStore('grid_REPSEL', maria.store);
    ItsPop.Open('pop_REPSEL');
};

ItsPop.Event('pop_REPSEL').onAddBtnClick = function () {
    var eqmRepKey = ItsGrid.GetValue('grid_REPSEL', ItsGrid.GetCurrentIndex('grid_REPSEL'), 'EQMREPKEY');
    if (!eqmRepKey) {
        ItsMsg.Toast('수리 기록을 선택해주세요.');
        return;
    }
    ItsPop.Close('pop_REPSEL');
    var r = WORKLOG_LOAD('pop1', eqmRepKey);
    if (!r) {
        return;
    }
    if (r.NONAUTO == 'Y') {
        ItsMsg.Toast('수리시간과 겹친 생산라인 비가동을 자동으로 연결했습니다. 저장하면 반영됩니다.');
    }
    ItsPop.Open('pop1');
};

ItsPop.Event('pop_REPSEL').onCancelBtnClick = function () {
    ItsPop.Close('pop_REPSEL');
};

// 등록 팝업 저장 → 왼쪽 목록에 작성된 일지로 나타나고 가운데에 불러옴
ItsPop.Event('pop1').onAddBtnClick = function () {
    var editKey = WL_KEY.pop1;
    if (!WORKLOG_SAVE('pop1')) {
        return;
    }
    ItsPop.Event('pop1').onCancelBtnClick();
    ItsMsg.Toast(ItsMsg.CommonMsg.SaveComplete());
    ItsGrid.Setkey('grid1', 'EQMREPKEY', editKey);
    ItsButton.EventSearch();
    if (WL_KEY.wl != editKey) {
        WORKLOG_PANEL_OPEN(editKey);
    }
};

ItsPop.Event('pop1').onCancelBtnClick = function () {
    WORKLOG_INIT('pop1');
    ItsPop.Close('pop1');
};

/* 저장: 가운데에서 수정한 공무작업일지 저장 (입력항목 + 작업자 전체(사번 빈 행 제외) + 사용 부품 전체) */
ItsButton.EventSave = function () {
    var editKey = WL_KEY.wl;
    if (!editKey) {
        ItsMsg.Toast('왼쪽 목록에서 공무작업일지를 선택하세요.');
        return;
    }
    if (!WORKLOG_SAVE('wl')) {
        return;
    }
    ItsMsg.Toast(ItsMsg.CommonMsg.SaveComplete());
    ItsGrid.Setkey('grid1', 'EQMREPKEY', editKey);
    ItsButton.EventSearch();
    if (WL_KEY.wl != editKey) {
        WORKLOG_PANEL_OPEN(editKey);
    }
};

// 가운데 공무작업일지 불러오기 (빈 키 = 비움)
function WORKLOG_PANEL_OPEN(eqmRepKey) {
    var r = WORKLOG_LOAD('wl', eqmRepKey);
    if (!r) {
        WORKLOG_STATE('', '', '', '왼쪽 목록에서 공무작업일지를 선택하세요.');
        REPIMG_LIST('');
        return;
    }
    if (r.WORKTP) {
        WORKLOG_STATE(eqmRepKey, '작성', 'done', '');
    } else {
        WORKLOG_STATE(eqmRepKey, '미작성', 'todo', '');
    }
    REPIMG_LIST(eqmRepKey);
}

// 수리 기록(설비·수리시작/종료·수리시간·작업자·고장현상)과 작업일지 항목·사용 부품을 화면(p = wl / pop1)에 불러옴, 불러온 행 반환
function WORKLOG_LOAD(p, eqmRepKey) {
    WL_KEY[p] = '';
    WORKLOG_INIT(p);
    if (!eqmRepKey) {
        return null;
    }
    var maria = new ItsMaria('EQM1001_R01', 'GET_EQMREP_WORK');
    maria.AddParam('EQMREPKEY', eqmRepKey);
    maria.CallProc();
    if (maria.isError) {
        maria.ShowErrMsg();
        return null;
    }
    if (maria.store.Length() == 0) {
        ItsMsg.Toast('수리 기록이 없습니다. 다시 조회하세요.');
        return null;
    }

    WL_KEY[p] = eqmRepKey;

    var r = maria.store.data[0];
    ItsFind.SetValue(p + '_find_EQMCD', r.EQMCD, false);
    ItsCombo.SetValue(p + '_cmb_WORKTP', r.WORKTP, false);
    ItsCombo.SetValue(p + '_cmb_FAILTP', r.FAILTP, false);
    ItsCombo.SetValue(p + '_cmb_FAILPART', r.FAILPART, false);
    ItsCombo.SetValue(p + '_cmb_STOPTP', r.STOPTP, false);
    ItsDate.SetValue(p + '_date_REPSDAY', r.REPSDAY, false);
    ItsText.SetValue(p + '_txt_REPSTIME', r.REPSTIME, false);
    ItsDate.SetValue(p + '_date_REPEDAY', r.REPEDAY, false);
    ItsText.SetValue(p + '_txt_REPETIME', r.REPETIME, false);
    WORKLOG_REPMIN(p);
    WORKLOG_NON_SET(p, r);
    ItsTextArea.SetValue(p + '_txtarea_MALFUNCTION', r.MALFUNCTION);
    ItsTextArea.SetValue(p + '_txtarea_CAUSE', r.CAUSE);
    ItsTextArea.SetValue(p + '_txtarea_HANDLE', r.HANDLE);
    ItsTextArea.SetValue(p + '_txtarea_PREVENT', r.PREVENT);

    // 작업자는 사번이 있는 행 전체 저장, 체크는 [행삭제] 대상
    maria.storeExtend1.data.forEach(function (emp, i) {
        ItsGrid.AddRow(p + '_grid_EMP', i, { isRowCheck: false, EMPCD: emp.EMPCD, EMPNM: emp.EMPNM });
    });
    maria.storeExtend2.data.forEach(function (part, i) {
        ItsGrid.AddRow(p + '_grid_PART', i, {
            isRowCheck: false,
            PARTTP: part.PARTTP,
            PARTTPNM: part.PARTTPNM,
            INOUTKEY: part.INOUTKEY,
            ITEMID: part.ITEMID,
            INOUTDATE: part.INOUTDATE,
            PARTNM: part.PARTNM,
            PARTSPEC: part.PARTSPEC,
            PARTQTY: part.PARTQTY,
            PARTUNIT: part.PARTUNIT,
            REMARK: part.REMARK
        });
    });
    return r;
}

// 가운데 제목 줄 상태 (수리키 · 작성/미작성 배지 · 안내 문구)
function WORKLOG_STATE(eqmRepKey, badge, badgeClass, note) {
    $('#spn_WL_KEY').text(eqmRepKey);
    $('#spn_WL_BADGE').text(badge).attr('class', 'wl-badge' + (badgeClass ? ' ' + badgeClass : '')).toggle(badge != '');
    $('#spn_WL_NOTE').text(note);
}

function WORKLOG_INIT(p) {
    ItsPage.InitData(p + '_div1');
    ItsPage.InitData(p + '_div2');
    ItsPage.InitData(p + '_div3');
    ItsPage.InitData(p + '_div4');
    ItsGrid.Clear(p + '_grid_EMP');
    ItsGrid.Clear(p + '_grid_PART');
    ItsDate.SetValue(p + '_date_REPSDAY', '');
    ItsDate.SetValue(p + '_date_REPEDAY', '');
    ItsText.SetValue(p + '_txt_REPSTIME', '');
    ItsText.SetValue(p + '_txt_REPETIME', '');
    WORKLOG_NON_SET(p, {});
    WORKLOG_REPMIN(p);
}

// 수리시간(분) = 수리종료 - 수리시작 (둘 다 있는 경우만)
function WORKLOG_REPMIN(p) {
    var sday = ItsDate.GetValue(p + '_date_REPSDAY');
    var stime = ItsText.GetValue(p + '_txt_REPSTIME');
    var eday = ItsDate.GetValue(p + '_date_REPEDAY');
    var etime = ItsText.GetValue(p + '_txt_REPETIME');
    var min = 0;
    if (sday && stime && eday && etime) {
        var s = new Date(sday + 'T' + stime + ':00');
        var e = new Date(eday + 'T' + etime + ':00');
        min = Math.round((e - s) / 60000);
        if (isNaN(min) || min < 0) {
            min = 0;
        }
    }
    ItsNum.SetValue(p + '_num_REPMIN', min);
}

// 수리 기록에 연결된 비가동(유형·발생일시·종료일시·정지시간) 표시 (화면에서 변경 불가, 비가동키는 숨김 필드로 저장)
function WORKLOG_NON_SET(p, non) {
    ItsText.SetValue(p + '_txt_PRDNONKEY', non.PRDNONKEY || '');
    ItsText.SetValue(p + '_txt_NONINFO', non.NONINFO || '');
    ItsDate.SetValue(p + '_date_NONSDAY', non.NONSDAY || '', false);
    ItsText.SetValue(p + '_txt_NONSTIME', non.NONSTIME || '', false);
    ItsDate.SetValue(p + '_date_NONEDAY', non.NONEDAY || '', false);
    ItsText.SetValue(p + '_txt_NONETIME', non.NONETIME || '', false);
    ItsNum.SetValue(p + '_num_STOPMIN', non.STOPMIN || 0);
}

// 그리드 빈 칸(null)은 빈값으로 전달
function WORKLOG_VAL(v) {
    return v == null ? '' : v;
}

// 화면(p) 공무작업일지를 그 수리 기록에 저장, 성공하면 true
function WORKLOG_SAVE(p) {
    var gridEmp = p + '_grid_EMP';
    var gridPart = p + '_grid_PART';
    ItsGrid.Get(gridEmp).finishEditing();
    ItsGrid.Get(gridPart).finishEditing();

    var maria = new ItsMaria('EQM1001_R01', 'ADD_EQMREP_WORK');
    maria.AddParam('EQMREPKEY', WL_KEY[p]);
    maria.AddPanel(p + '_div1');
    maria.AddPanel(p + '_div2');
    maria.AddPanel(p + '_div3');
    maria.AddPanel(p + '_div4');

    for (var i = 0; i < ItsGrid.Length(gridEmp); i++) {
        if (ItsGrid.GetValue(gridEmp, i, 'EMPCD')) {
            maria.AddList('EMPCD_LIST', ItsGrid.GetValue(gridEmp, i, 'EMPCD'));
        }
    }

    for (var j = 0; j < ItsGrid.Length(gridPart); j++) {
        maria.AddList('PARTTP_LIST', WORKLOG_VAL(ItsGrid.GetValue(gridPart, j, 'PARTTP')));
        maria.AddList('INOUTKEY_LIST', WORKLOG_VAL(ItsGrid.GetValue(gridPart, j, 'INOUTKEY')));
        maria.AddList('ITEMID_LIST', WORKLOG_VAL(ItsGrid.GetValue(gridPart, j, 'ITEMID')));
        maria.AddList('PARTNM_LIST', WORKLOG_VAL(ItsGrid.GetValue(gridPart, j, 'PARTNM')));
        maria.AddList('PARTSPEC_LIST', WORKLOG_VAL(ItsGrid.GetValue(gridPart, j, 'PARTSPEC')));
        maria.AddList('PARTQTY_LIST', WORKLOG_VAL(ItsGrid.GetValue(gridPart, j, 'PARTQTY')));
        maria.AddList('PARTUNIT_LIST', WORKLOG_VAL(ItsGrid.GetValue(gridPart, j, 'PARTUNIT')));
        maria.AddList('PARTREMARK_LIST', WORKLOG_VAL(ItsGrid.GetValue(gridPart, j, 'REMARK')));
        maria.AddList('INOUTDATE_LIST', WORKLOG_VAL(ItsGrid.GetValue(gridPart, j, 'INOUTDATE')));
    }

    maria.CallProc();
    if (maria.isError) {
        maria.ShowErrMsg();
        return false;
    }
    return true;
}

// 화면(p)의 작업자·사용 부품 그리드 생성
function WORKLOG_CREATE_GRIDS(p) {
    ItsGrid.Create(p + '_grid_EMP', { isCheckBoxGrid: true }, [
        column.create('사번', 'EMPCD', { width: 80, columnType: enumColumnTypes.find, gpcd: 'EMPCD', readOnly: false }),
        column.create('사원명', 'EMPNM', { width: 150 })
    ]);

    // 사용 자재·부품 (출고 부품 / 스페셜 부품)
    ItsGrid.Create(p + '_grid_PART', { isCheckBoxGrid: true }, [
        column.create('구분', 'PARTTPNM', { width: 70, align: 'center', readOnly: true }),
        column.create('부품명', 'PARTNM', { width: 260, readOnly: false }),
        column.create('규격', 'PARTSPEC', { width: 200, readOnly: false }),
        column.create('수량', 'PARTQTY', { width: 90, columnType: enumColumnTypes.number, decimalPrecision: 2, readOnly: false }),
        column.create('단위', 'PARTUNIT', { width: 80, align: 'center', columnType: enumColumnTypes.combo, gpcd: 'DM150', readOnly: false }),
        column.create('비고', 'REMARK', { width: 270, readOnly: false }),
        column.create('출고일자', 'INOUTDATE', { width: 110, align: 'center', columnType: enumColumnTypes.date, readOnly: false }),
        column.create('부품구분', 'PARTTP', { width: 60, hidden: true }),
        column.create('출고키', 'INOUTKEY', { width: 100, hidden: true }),
        column.create('품목ID', 'ITEMID', { width: 80, hidden: true })
    ]);
}

// 화면(p)의 작업자·사용 부품 버튼과 그리드 이벤트
function WORKLOG_BIND_EVENTS(p) {
    var gridEmp = p + '_grid_EMP';
    var gridPart = p + '_grid_PART';

    // 출고 부품 선택: 설비부품 출고 전체 (기간·라인 제한 없음)
    ItsButton.Event(p + '_btn_PARTOUT').onClick = function () {
        var maria = new ItsMaria('EQM1001_R01', 'LIST_OUTPART');
        maria.AddParam('EQMREPKEY', WL_KEY[p]);
        maria.CallProc();
        if (maria.isError) {
            maria.ShowErrMsg();
            return;
        }
        if (maria.store.Length() == 0) {
            ItsMsg.Alert('출고된 설비부품이 없습니다.');
            return;
        }
        partTarget = p;
        ItsGrid.SetStore('grid_PART', maria.store);
        ItsPop.Open('pop_PART');
    };

    // 스페셜 부품: 기준정보 없이 부품명·규격·수량·단위 직접 입력
    ItsButton.Event(p + '_btn_PARTSP').onClick = function () {
        ItsGrid.AddRow(gridPart, ItsGrid.Length(gridPart), {
            isRowCheck: false,
            PARTTP: 'SPECIAL',
            PARTTPNM: '스페셜',
            INOUTKEY: '',
            ITEMID: '',
            INOUTDATE: '',
            PARTNM: '',
            PARTSPEC: '',
            PARTQTY: '',
            PARTUNIT: '',
            REMARK: ''
        });
    };

    ItsButton.Event(p + '_btn_PARTDEL').onClick = function () {
        for (var i = ItsGrid.Length(gridPart) - 1; i >= 0; i--) {
            if (ItsGrid.IsChecked(gridPart, i)) {
                ItsGrid.RemoveRow(gridPart, i);
            }
        }
    };

    // 출고 부품은 출고 기록 값(부품명·규격·수량·단위·출고일자) 수정 불가 (비고만 입력), 스페셜 부품은 모두 입력
    ItsGrid.Event(gridPart).onBeginningEdit = function (rowIndex, field, value) {
        if (ItsGrid.GetValue(gridPart, rowIndex, 'PARTTP') == 'OUT' && field != 'REMARK') {
            throw '';
        }
    };

    /* 작업자 행추가 */
    ItsButton.Event(p + '_btn_EMPADD').onClick = function () {
        ItsGrid.AddRow(gridEmp, 0);
    };

    /* 작업자 행삭제 */
    ItsButton.Event(p + '_btn_EMPDEL').onClick = function () {
        for (var i = ItsGrid.Length(gridEmp) - 1; i >= 0; i--) {
            if (ItsGrid.IsChecked(gridEmp, i)) {
                ItsGrid.RemoveRow(gridEmp, i);
            }
        }
    };

    /* 작업자 사원 찾기 */
    ItsGrid.Event(gridEmp).onDoubleClick = function (rowIndex, field) {
        ItsGrid.Event(gridEmp).onKeydownEnter(rowIndex, field);
    };

    ItsGrid.Event(gridEmp).onKeydownEnter = function (rowIndex, field) {
        if (field != 'EMPCD') {
            return;
        }
        ItsPop.OpenFindCOM({ gpcd: 'EMPCD' }, function (res) {
            for (var i = 0; i < ItsGrid.Length(gridEmp); i++) {
                if (i != rowIndex && ItsGrid.GetValue(gridEmp, i, 'EMPCD') == res['CODE']) {
                    ItsMsg.Alert(res['NAME'] + '는 추가되어 있는 사원입니다.');
                    return;
                }
            }
            ItsGrid.SetValue(gridEmp, rowIndex, 'EMPCD', res['CODE']);
            ItsGrid.SetValue(gridEmp, rowIndex, 'EMPNM', res['NAME']);
        });
    };
}

WORKLOG_BIND_EVENTS('wl');
WORKLOG_BIND_EVENTS('pop1');

// 출고 부품 선택 팝업에서 체크한 부품을 화면(partTarget) 사용 부품에 추가 (이미 추가한 출고 부품 제외)
ItsPop.Event('pop_PART').onAddBtnClick = function () {
    var gridPart = partTarget + '_grid_PART';
    ItsGrid.Get(gridPart).finishEditing();
    var addCount = 0;
    for (var i = 0; i < ItsGrid.Length('grid_PART'); i++) {
        if (!ItsGrid.IsChecked('grid_PART', i)) {
            continue;
        }
        var inoutKey = ItsGrid.GetValue('grid_PART', i, 'INOUTKEY');
        var exists = false;
        for (var j = 0; j < ItsGrid.Length(gridPart); j++) {
            if (ItsGrid.GetValue(gridPart, j, 'INOUTKEY') == inoutKey) {
                exists = true;
                break;
            }
        }
        if (exists) {
            continue;
        }
        ItsGrid.AddRow(gridPart, ItsGrid.Length(gridPart), {
            isRowCheck: false,
            PARTTP: 'OUT',
            PARTTPNM: '출고',
            INOUTKEY: inoutKey,
            ITEMID: ItsGrid.GetValue('grid_PART', i, 'ITEMID'),
            INOUTDATE: ItsGrid.GetValue('grid_PART', i, 'INOUTDATE'),
            PARTNM: ItsGrid.GetValue('grid_PART', i, 'ITEMNM'),
            PARTSPEC: ItsGrid.GetValue('grid_PART', i, 'ITEMSPEC'),
            PARTQTY: ItsGrid.GetValue('grid_PART', i, 'INOUTQTY'),
            PARTUNIT: ItsGrid.GetValue('grid_PART', i, 'ITEMUNIT'),
            REMARK: ''
        });
        addCount++;
    }
    if (addCount == 0) {
        ItsMsg.Toast('추가할 부품을 선택해주세요. (이미 추가된 출고 부품은 제외)');
        return;
    }
    ItsPop.Close('pop_PART');
};

ItsPop.Event('pop_PART').onCancelBtnClick = function () {
    ItsPop.Close('pop_PART');
};

// 2026-11-09 [수리 사진] 사진 목록·선택 상태, 업로드 대상 수리이력 키 (업로드 중 다른 이력을 선택해도 처음 이력에 등록)
var repImgList = [];
var repImgUploadKey = '';

// 2026-11-09 [수리 사진] 수리이력의 등록 사진 조회
function GetRepImgList(eqmRepKey) {
    if (!eqmRepKey) {
        return [];
    }
    var maria = new ItsMaria('EQM1001_R01', 'LIST_EQMREP_IMG');
    maria.AddParam('EQMREPKEY', eqmRepKey);
    maria.CallProc();
    if (maria.isError) {
        maria.ShowErrMsg();
        return [];
    }
    return maria.store.data;
}

// 2026-11-09 [수리 사진] 썸네일 목록 표시 후 지정 사진(없으면 첫 사진) 미리보기
function REPIMG_LIST(eqmRepKey, selectFileKey) {
    repImgList = GetRepImgList(eqmRepKey);
    var selectIndex = 0;
    var html = '';
    repImgList.forEach(function (img, i) {
        if (img.FILEKEY == selectFileKey) {
            selectIndex = i;
        }
        html += '<div class="repimg-thumb" data-index="' + i + '"><img src="' + img.FILEURL + '" />'
              + '<span class="repimg-del" data-filekey="' + img.FILEKEY + '" title="사진 삭제">✕</span></div>';
    });
    $('#div_REPIMG_LIST').html(html);
    $('#spn_REPIMG_EMPTY').text(eqmRepKey ? '등록된 사진이 없습니다. [사진 등록]으로 추가하세요.' : '수리이력을 선택하면 사진이 표시됩니다.');
    ItsLabel.SetText('lbl_REPIMG', '■ 수리 사진 (' + repImgList.length + ')');
    REPIMG_SELECT(repImgList.length > 0 ? selectIndex : -1);
}

// 2026-11-09 [수리 사진] 선택 사진 미리보기·썸네일 강조·순번 표시 (사진이 없으면 기본 이미지 대신 안내 문구)
function REPIMG_SELECT(index) {
    $('#div_REPIMG_LIST .repimg-thumb').removeClass('on');
    if (index < 0 || index >= repImgList.length) {
        ItsImage.Clear('img_REPIMG');
        $('#spn_REPIMG_PAGE').hide();
        $('#spn_REPIMG_EMPTY').parent().addClass('empty');
        return;
    }
    $('#spn_REPIMG_EMPTY').parent().removeClass('empty');
    $('#div_REPIMG_LIST .repimg-thumb[data-index="' + index + '"]').addClass('on');
    ItsImage.SetImage('img_REPIMG', repImgList[index].FILEURL, repImgList[index].FILEKEY);
    $('#spn_REPIMG_PAGE').text((index + 1) + ' / ' + repImgList.length).show();
}

// 2026-11-09 [수리 사진] 사진 등록 → 공통 파일선택(이미지) 열기
ItsButton.Event('btn_REPIMG_ADD').onClick = function () {
    repImgUploadKey = WL_KEY.wl;
    if (!repImgUploadKey) {
        ItsMsg.Toast('수리이력을 선택해주세요.');
        return;
    }
    ItsFileManager.Clear('file_REPIMG');
    document.getElementById('file_REPIMGex_filename').click();
};

// 2026-11-09 [수리 사진] 사진 선택 즉시 업로드
ItsFileManager.Event('file_REPIMG').onFileChange = function (id) {
    if (document.getElementById(id + 'ex_filename').files.length < 1) {
        return;
    }
    ItsFileManager.Upload(id);
};

// 2026-11-09 [수리 사진] 업로드한 파일키를 수리이력에 등록, 등록 실패 시 업로드 파일 삭제
ItsFileManager.Event('file_REPIMG').onUpload = function (id, fileKey) {
    ItsFileManager.Clear(id);
    var maria = new ItsMaria('EQM1001_R01', 'ADD_EQMREP_IMG');
    maria.AddParam('EQMREPKEY', repImgUploadKey);
    maria.AddParam('FILEKEY', fileKey);
    maria.CallProc();
    if (maria.isError) {
        maria.ShowErrMsg();
        ItsFileManager.Delete(id, fileKey);
        return;
    }
    ItsMsg.Toast(ItsMsg.CommonMsg.SaveComplete());
    if (repImgUploadKey == WL_KEY.wl) {
        REPIMG_LIST(repImgUploadKey, fileKey);
    }
};

// 2026-11-09 [수리 사진] 사진 삭제 (등록 삭제 후 파일 삭제)
function REPIMG_DELETE(fileKey) {
    var eqmRepKey = WL_KEY.wl;
    if (!eqmRepKey || !fileKey) {
        return;
    }
    ItsMsg.Confirm('사진을 삭제하시겠습니까?', function () {
        var maria = new ItsMaria('EQM1001_R01', 'DELETE_EQMREP_IMG');
        maria.AddParam('EQMREPKEY', eqmRepKey);
        maria.AddParam('FILEKEY', fileKey);
        maria.CallProc();
        if (maria.isError) {
            maria.ShowErrMsg();
            return;
        }
        ItsFileManager.Clear('file_REPIMG');
        ItsFileManager.Delete('file_REPIMG', fileKey);
        ItsMsg.Toast(ItsMsg.CommonMsg.DeleteComplete());
        REPIMG_LIST(eqmRepKey);
    });
}

// 2026-11-09 [수리 사진] 미리보기 클릭 → 크게 보기 팝업
ItsImage.Event('img_REPIMG').onClick = function (url, key) {
    if (!key) {
        return;
    }
    ItsImage.SetImage('big_img_REPIMG', url, key);
    ItsPop.Open('pop_REPIMG');
};

// 왼쪽 목록에서 체크한 공무작업일지의 수리키
function WORKLOG_CHECKED_KEYS() {
    var keys = [];
    for (var i = 0; i < ItsGrid.Length('grid1'); i++) {
        if (ItsGrid.IsChecked('grid1', i)) {
            keys.push(ItsGrid.GetValue('grid1', i, 'EQMREPKEY'));
        }
    }
    return keys;
}

/* 삭제: 체크한 수리 기록의 공무작업일지 내용만 삭제 (작업일지 항목·사용 부품, 태블릿 수리 기록·작업자·사진은 그대로) */
ItsButton.EventDelete = function () {
    var keys = [];
    for (var i = 0; i < ItsGrid.Length('grid1'); i++) {
        if (ItsGrid.IsChecked('grid1', i)) {
            keys.push(ItsGrid.GetValue('grid1', i, 'EQMREPKEY'));
        }
    }
    if (keys.length == 0) {
        ItsMsg.Toast('선택된 항목이 없습니다.');
        return;
    }
    ItsMsg.Confirm('선택한 항목을 삭제하시겠습니까?', function () {
        var maria = new ItsMaria('EQM1001_R01', 'DELETE_WORKLOG');
        keys.forEach(function (key) {
            maria.AddList('EQMREPKEY_LIST', key);
        });
        maria.CallProc();
        if (maria.isError) {
            maria.ShowErrMsg();
            return;
        }
        ItsMsg.Toast(ItsMsg.CommonMsg.DeleteComplete());
        ItsButton.EventSearch();
    }, function () {
        ItsMsg.Toast('삭제가 취소되었습니다.');
    });
};

// 공무작업일지 인쇄: 체크한 일지를 한 PDF로 출력 (일지 1건 = A4 1장)
ItsButton.Event('sdiv1_btn_PRINT').onClick = function () {
    var keys = WORKLOG_CHECKED_KEYS();
    if (keys.length == 0) {
        ItsMsg.Alert('인쇄할 공무작업일지를 체크해주세요.');
        return;
    }
    var rpt = new ItsXtraRpt('EQM1001_R01');
    rpt.AddParam('EQMREPKEY_LIST', keys.join(','));
    rpt.CallPop();
    if (rpt.isError) {
        ItsMsg.Alert(rpt.errMessage);
    }
};
