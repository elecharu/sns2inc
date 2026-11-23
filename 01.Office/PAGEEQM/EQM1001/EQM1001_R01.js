/// <reference path="../../Script/reference.js" />

var wlKey = { wl: '', pop1: '' };
var wlSnap = '';
var partTarget = 'wl';
var arrPartAll = [];
var partChecked = {};
var arrRepImg = [];
var repImgUploadKey = '';

/* 페이지 로드 시 수행 */
ItsPage.Load = function () {
    ItsGrid.Create('grid1', { isCheckBoxGrid: true, isSubTotalGrid: true }, [
        column.create('공장', 'FACTORYCD', { width: 100, align: 'center', columnType: enumColumnTypes.combo, gpcd: 'FACTORYCD', readOnly: true }),
        column.create('작업장', 'LINECD', { width: 80, align: 'center', columnType: enumColumnTypes.combo, gpcd: 'LINECD', readOnly: true }),
        column.create('공정', 'EQMTP', { width: 80, align: 'center', columnType: enumColumnTypes.combo, gpcd: 'FM100', readOnly: true }),
        column.create('라인', 'EQMGROUP1', { width: 80, align: 'center', columnType: enumColumnTypes.combo, gpcd: 'FM113', readOnly: true }),
        column.create('설비코드', 'EQMCD', { width: 110, readOnly: true }),
        column.create('설비명', 'EQMNM', { width: 180, readOnly: true }),
        column.create('수리시작일자', 'REPSDAY', { width: 100, align: 'center', readOnly: true, columnType: enumColumnTypes.date }),
        column.create('시작시간', 'REPSTIME', { width: 70, align: 'center', readOnly: true, mask: '00:00' }),
        column.create('수리종료일자', 'REPEDAY', { width: 100, align: 'center', readOnly: true, columnType: enumColumnTypes.date }),
        column.create('종료시간', 'REPETIME', { width: 70, align: 'center', readOnly: true, mask: '00:00' }),
        column.create('수리시간(분)', 'REPMIN', { width: 85, columnType: enumColumnTypes.number, decimalPrecision: 0, readOnly: true, groupType: enumGrouping.sum }),
        column.split()
    ]);

    WORKLOG_CREATE_GRIDS('wl');
    WORKLOG_CREATE_GRIDS('pop1');

    ItsGrid.Create('grid_REPSEL', {}, [
        column.create('수리종료', 'REPETIME', { width: 130, align: 'center', readOnly: true }),
        column.create('수리시작', 'REPSTIME', { width: 130, align: 'center', readOnly: true }),
        column.create('수리시간(분)', 'REPMIN', { width: 85, columnType: enumColumnTypes.number, decimalPrecision: 0, readOnly: true }),
        column.create('작업장', 'LINECD', { width: 80, align: 'center', columnType: enumColumnTypes.combo, gpcd: 'LINECD', readOnly: true }),
        column.create('설비명', 'EQMNM', { width: 180, readOnly: true }),
        column.create('구분', 'REPGUBUN', { width: 70, align: 'center', readOnly: true }),
        column.create('작업자', 'EMPNMS', { width: 140, readOnly: true }),
        column.create('고장현상(호출이유)', 'MALFUNCTION', { width: 160, readOnly: true })
    ]);

    ItsGrid.Create('grid_PART', { isCheckBoxGrid: true }, [
        column.create('품목코드', 'ITEMCD', { width: 150, readOnly: true }),
        column.create('품목명', 'ITEMNM', { width: 240, readOnly: true }),
        column.create('규격', 'ITEMSPEC', { width: 240, readOnly: true }),
        column.create('단위', 'ITEMUNIT', { width: 60, align: 'center', columnType: enumColumnTypes.combo, gpcd: 'DM150', readOnly: true }),
        column.create('현재고', 'LOTQTY', { width: 85, columnType: enumColumnTypes.number, decimalPrecision: 2, readOnly: true }),
        column.split()
    ]);

    // 팝업 내 그리드 콤보·달력 표시 위치 보정
    var orgShowPopup = wijmo.showPopup;
    wijmo.showPopup = function (popup, ref) {
        var ret = orgShowPopup.apply(this, arguments);
        if (ref instanceof HTMLElement && popup.parentElement != document.body && $(ref).closest('.ui-dialog').length > 0) {
            var rc = ref.getBoundingClientRect();
            var top = rc.bottom;
            if (top + popup.offsetHeight > window.innerHeight && rc.top > popup.offsetHeight) {
                top = rc.top - popup.offsetHeight;
            }
            popup.style.transform = 'none';
            popup.style.left = Math.max(0, Math.min(rc.left, window.innerWidth - popup.offsetWidth)) + 'px';
            popup.style.top = top + 'px';
        }
        return ret;
    };

    $('#pop_PART').on('input', '#pp_txt_KEYWORD', function () {
        PART_FILTER();
    });

    $('#div_REPIMG_LIST').on('click', '.repimg-thumb', function () {
        REPIMG_SELECT(parseInt($(this).attr('data-index'), 10));
    });

    $('#div_REPIMG_LIST').on('click', '.repimg-del', function (e) {
        e.stopPropagation();
        REPIMG_DELETE($(this).attr('data-filekey'));
    });

    ItsDateRange.SetInitValueFrom('date_SEARCH', ItsHelper.AddDay(-7, ItsHelper.GetYearMonthDay()));
    REPIMG_LIST('');
};

// 작업장 변경 시 공정·라인 콤보 연동
ItsCombo.Event('cmb_LINECD').onChanged = function () {
    var lineCd = ItsCombo.GetValue('cmb_LINECD');
    ItsCombo.SetRef01('cmb_EQMTP', lineCd);
    ItsCombo.SetValue('cmb_EQMTP', '', false);

    ItsCombo.SetRef01('cmb_EQMGROUP1', lineCd, false);
    ItsCombo.SetRef02('cmb_EQMGROUP1', '');
    ItsCombo.SetValue('cmb_EQMGROUP1', '', false);
};

// 공정 변경 시 라인 콤보 연동
ItsCombo.Event('cmb_EQMTP').onChanged = function () {
    ItsCombo.SetRef02('cmb_EQMGROUP1', ItsCombo.GetValue('cmb_EQMTP'));
    ItsCombo.SetValue('cmb_EQMGROUP1', '', false);
};

// 공무작업일지 목록 조회
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

// 공무작업일지 등록 대상 수리 기록 조회
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

// 가운데 공무작업일지 수정 저장
ItsButton.EventSave = function () {
    var editKey = wlKey.wl;
    if (!editKey) {
        ItsMsg.Toast('왼쪽 목록에서 공무작업일지를 선택하세요.');
        return;
    }
    if (!WORKLOG_SAVE('wl')) {
        return;
    }
    WORKLOG_AFTER_SAVE(editKey);
};

// 체크한 공무작업일지 내용 삭제
ItsButton.EventDelete = function () {
    var keys = WORKLOG_CHECKED_KEYS();
    if (keys.length == 0) {
        ItsMsg.Toast('선택된 항목이 없습니다.');
        return;
    }

    ItsMsg.Confirm('선택한 항목을 삭제하시겠습니까?', function () {
        var maria = new ItsMaria('EQM1001_R01', 'DELETE_WORKLOG');
        for (var i = 0; i < keys.length; i++) {
            maria.AddList('EQMREPKEY_LIST', keys[i]);
        }
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

// 체크한 공무작업일지 PDF 출력
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

// 목록 행 선택 시 가운데 공무작업일지 및 수리 사진 조회 (저장 안 한 수정이 있으면 이동 확인)
ItsGrid.Event('grid1').onSelect = function () {
    var eqmRepKey = ItsGrid.GetValue('grid1', ItsGrid.GetCurrentIndex('grid1'), 'EQMREPKEY');
    if (eqmRepKey == wlKey.wl) {
        return;
    }
    if (!WORKLOG_IS_CHANGED()) {
        WORKLOG_PANEL_OPEN(eqmRepKey);
        return;
    }

    ItsMsg.Confirm('저장하지 않은 공무작업일지 수정 내용이 있습니다.<br/>이동하면 수정 내용이 사라집니다. 이동하시겠습니까?', function () {
        WORKLOG_PANEL_OPEN(eqmRepKey);
    }, function () {
        WORKLOG_SELECT_EDIT_ROW();
    });
};

// 목록에서 가운데 공무작업일지 행 다시 선택
function WORKLOG_SELECT_EDIT_ROW() {
    for (var i = 0; i < ItsGrid.Length('grid1'); i++) {
        if (ItsGrid.GetValue('grid1', i, 'EQMREPKEY') == wlKey.wl) {
            ItsGrid.SelectRow('grid1', i);
            return;
        }
    }
}

// 수리 기록 선택 팝업 확인
ItsPop.Event('pop_REPSEL').onAddBtnClick = function () {
    var eqmRepKey = ItsGrid.GetValue('grid_REPSEL', ItsGrid.GetCurrentIndex('grid_REPSEL'), 'EQMREPKEY');
    if (!eqmRepKey) {
        ItsMsg.Toast('수리 기록을 선택해주세요.');
        return;
    }

    ItsPop.Close('pop_REPSEL');
    var row = WORKLOG_LOAD('pop1', eqmRepKey);
    if (!row) {
        return;
    }
    if (row.NONAUTO == 'Y') {
        ItsMsg.Toast('수리시간과 겹친 생산라인 비가동을 자동으로 연결했습니다. 저장하면 반영됩니다.');
    }
    ItsPop.Open('pop1');
};

// 수리 기록 선택 팝업 닫기
ItsPop.Event('pop_REPSEL').onCancelBtnClick = function () {
    ItsPop.Close('pop_REPSEL');
};

// 공무작업일지 등록 팝업 저장
ItsPop.Event('pop1').onAddBtnClick = function () {
    var editKey = wlKey.pop1;
    if (!WORKLOG_SAVE('pop1')) {
        return;
    }
    WORKLOG_INIT('pop1');
    ItsPop.Close('pop1');
    WORKLOG_AFTER_SAVE(editKey);
};

// 공무작업일지 등록 팝업 닫기
ItsPop.Event('pop1').onCancelBtnClick = function () {
    WORKLOG_INIT('pop1');
    ItsPop.Close('pop1');
};

// 부품 선택 팝업 높이 맞춤
ItsPop.Event('pop_PART').onPopOpened = function () {
    var height = $('#pop_PART').height() - $('#pp_div1').outerHeight(true) - 56;
    if (height > 100) {
        $('#grid_PART').height(height);
        ItsGrid.Get('grid_PART').refresh(true);
    }
};

// 부품 선택 팝업에서 체크한 부품 추가
ItsPop.Event('pop_PART').onAddBtnClick = function () {
    PART_KEEP_CHECKED();
    var gridPart = partTarget + '_grid_PART';
    ItsGrid.Get(gridPart).finishEditing();

    var added = {};
    for (var j = 0; j < ItsGrid.Length(gridPart); j++) {
        if (ItsGrid.GetValue(gridPart, j, 'PARTTP') == 'PART') {
            added[ItsGrid.GetValue(gridPart, j, 'ITEMID')] = true;
        }
    }

    var addCnt = 0;
    for (var i = 0; i < arrPartAll.length; i++) {
        var r = arrPartAll[i];
        if (partChecked[r.ITEMID] != true || added[r.ITEMID] == true) {
            continue;
        }
        ItsGrid.AddRow(gridPart, ItsGrid.Length(gridPart), {
            isRowCheck: false,
            PARTTP: 'PART',
            INOUTKEY: '',
            ITEMID: r.ITEMID,
            INOUTDATE: '',
            PARTNM: r.ITEMNM,
            PARTSPEC: r.ITEMSPEC,
            PARTQTY: '',
            PARTUNIT: r.ITEMUNIT,
            REMARK: ''
        });
        addCnt++;
    }

    if (addCnt == 0) {
        ItsMsg.Toast('추가할 부품을 선택해주세요. (이미 추가된 부품은 제외)');
        return;
    }
    ItsPop.Close('pop_PART');
};

// 부품 선택 팝업 닫기
ItsPop.Event('pop_PART').onCancelBtnClick = function () {
    ItsPop.Close('pop_PART');
};

// 공무작업일지 작업자·사용 부품 그리드 생성
function WORKLOG_CREATE_GRIDS(p) {
    ItsGrid.Create(p + '_grid_EMP', { isCheckBoxGrid: true }, [
        column.create('사번', 'EMPCD', { width: 80, columnType: enumColumnTypes.find, gpcd: 'EMPCD', readOnly: false }),
        column.create('사원명', 'EMPNM', { width: 150 })
    ]);

    ItsGrid.Create(p + '_grid_PART', { isCheckBoxGrid: true }, [
        column.create('부품명', 'PARTNM', { width: 260, readOnly: false }),
        column.create('규격', 'PARTSPEC', { width: 200, readOnly: false }),
        column.create('수량', 'PARTQTY', { width: 90, columnType: enumColumnTypes.number, decimalPrecision: 2, readOnly: false }),
        column.create('단위', 'PARTUNIT', { width: 80, align: 'center', columnType: enumColumnTypes.combo, gpcd: 'DM150', readOnly: false }),
        column.create('비고', 'REMARK', { width: 270, readOnly: false })
    ]);
}

// 공무작업일지 작업자·사용 부품 버튼 및 그리드 이벤트 바인딩
function WORKLOG_BIND_EVENTS(p) {
    var gridEmp = p + '_grid_EMP';
    var gridPart = p + '_grid_PART';
    var partEditChecked = false;
    var empEditChecked = false;

    ItsButton.Event(p + '_btn_PART').onClick = function () {
        var maria = new ItsMaria('EQM1001_R01', 'LIST_PART');
        maria.CallProc();
        if (maria.isError) {
            maria.ShowErrMsg();
            return;
        }
        if (maria.store.Length() == 0) {
            ItsMsg.Alert('등록된 설비부품이 없습니다.');
            return;
        }

        partTarget = p;
        arrPartAll = maria.store.data;
        partChecked = {};
        ItsGrid.Clear('grid_PART');
        ItsText.SetValue('pp_txt_KEYWORD', '');
        PART_FILTER();
        ItsPop.Open('pop_PART');
    };

    ItsButton.Event(p + '_btn_PARTSP').onClick = function () {
        ItsGrid.AddRow(gridPart, ItsGrid.Length(gridPart), {
            isRowCheck: false,
            PARTTP: 'SPECIAL',
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
        WORKLOG_DELETE_CHECKED(gridPart);
    };

    ItsButton.Event(p + '_btn_EMPADD').onClick = function () {
        ItsGrid.AddRow(gridEmp, 0);
    };

    ItsButton.Event(p + '_btn_EMPDEL').onClick = function () {
        WORKLOG_DELETE_CHECKED(gridEmp);
    };

    ItsGrid.Event(gridPart).onBeginningEdit = function (rowIndex, field) {
        partEditChecked = ItsGrid.IsChecked(gridPart, rowIndex);
        var partTp = ItsGrid.GetValue(gridPart, rowIndex, 'PARTTP');
        if (partTp == 'OUT' && field != 'REMARK') {
            throw '';
        }
        if (partTp == 'PART' && (field == 'PARTNM' || field == 'PARTSPEC' || field == 'PARTUNIT')) {
            throw '';
        }
    };

    ItsGrid.Event(gridPart).onChanged = function (rowIndex, field, newValue, oldValue, type) {
        if (type == 'cellEditEnded' && field != 'isRowCheck') {
            ItsGrid.SetValue(gridPart, rowIndex, 'isRowCheck', partEditChecked);
        }
    };

    ItsGrid.Event(gridEmp).onBeginningEdit = function (rowIndex) {
        empEditChecked = ItsGrid.IsChecked(gridEmp, rowIndex);
    };

    ItsGrid.Event(gridEmp).onChanged = function (rowIndex, field, newValue, oldValue, type) {
        if (type == 'cellEditEnded' && field != 'isRowCheck') {
            ItsGrid.SetValue(gridEmp, rowIndex, 'isRowCheck', empEditChecked);
        }
    };

    ItsGrid.Event(gridEmp).onDoubleClick = function (rowIndex, field) {
        ItsGrid.Event(gridEmp).onKeydownEnter(rowIndex, field);
    };

    ItsGrid.Event(gridEmp).onKeydownEnter = function (rowIndex, field) {
        if (field != 'EMPCD') {
            return;
        }
        ItsPop.OpenFindCOM({ gpcd: 'EMPCD' }, function (res) {
            for (var i = 0; i < ItsGrid.Length(gridEmp); i++) {
                if (i != rowIndex && ItsGrid.GetValue(gridEmp, i, 'EMPCD') == res.CODE) {
                    ItsMsg.Alert(res.NAME + '는 추가되어 있는 사원입니다.');
                    return;
                }
            }
            ItsGrid.SetValue(gridEmp, rowIndex, 'EMPCD', res.CODE);
            ItsGrid.SetValue(gridEmp, rowIndex, 'EMPNM', res.NAME);
        });
    };
}

WORKLOG_BIND_EVENTS('wl');
WORKLOG_BIND_EVENTS('pop1');

// 가운데 공무작업일지 및 수리 사진 로드
function WORKLOG_PANEL_OPEN(eqmRepKey) {
    var row = WORKLOG_LOAD('wl', eqmRepKey);
    if (!row) {
        wlSnap = '';
        $('#spn_WL_KEY').text('');
        $('#spn_WL_NOTE').text('왼쪽 목록에서 공무작업일지를 선택하세요.');
        REPIMG_LIST('');
        return;
    }

    wlSnap = WORKLOG_SNAP('wl');
    $('#spn_WL_KEY').text(eqmRepKey);
    $('#spn_WL_NOTE').text('');
    REPIMG_LIST(eqmRepKey);
}

// 가운데 공무작업일지 저장 안 한 수정 여부 (불러온 때의 내용과 비교)
function WORKLOG_IS_CHANGED() {
    return wlKey.wl != '' && WORKLOG_SNAP('wl') != wlSnap;
}

// 공무작업일지 현재 내용 (입력 영역 값, 작업자 사번, 사용 부품 행 데이터)
function WORKLOG_SNAP(p) {
    var gridEmp = p + '_grid_EMP';
    var gridPart = p + '_grid_PART';
    ItsGrid.Get(gridEmp).finishEditing();
    ItsGrid.Get(gridPart).finishEditing();

    var panel = new ItsMaria('EQM1001_R01', '');
    panel.AddPanel(p + '_div1');
    panel.AddPanel(p + '_div2');
    panel.AddPanel(p + '_div3');
    panel.AddPanel(p + '_div4');

    var emp = [];
    for (var i = 0; i < ItsGrid.Length(gridEmp); i++) {
        emp.push(ItsGrid.GetValue(gridEmp, i, 'EMPCD') || '');
    }

    var part = [];
    for (var j = 0; j < ItsGrid.Length(gridPart); j++) {
        var row = $.extend({}, ItsGrid.Get(gridPart).rows[j].dataItem);
        delete row.isRowCheck;
        part.push(row);
    }

    return panel.ToString() + JSON.stringify(emp.filter(Boolean)) + JSON.stringify(part);
}

// 공무작업일지 상세·작업자·사용 부품 조회 및 바인딩
function WORKLOG_LOAD(p, eqmRepKey) {
    wlKey[p] = '';
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

    wlKey[p] = eqmRepKey;

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

    if (maria.storeExtend1.Length() > 0) {
        ItsGrid.SetStore(p + '_grid_EMP', maria.storeExtend1);
    }
    if (maria.storeExtend2.Length() > 0) {
        ItsGrid.SetStore(p + '_grid_PART', maria.storeExtend2);
    }
    return r;
}

// 공무작업일지 입력 영역 초기화
function WORKLOG_INIT(p) {
    ItsPage.InitData(p + '_div1');
    ItsPage.InitData(p + '_div2');
    ItsPage.InitData(p + '_div3');
    ItsPage.InitData(p + '_div4');
    ItsGrid.Clear(p + '_grid_EMP');
    ItsGrid.Clear(p + '_grid_PART');
    ItsDate.SetValue(p + '_date_REPSDAY', '');
    ItsDate.SetValue(p + '_date_REPEDAY', '');
    ItsNum.SetValue(p + '_num_REPMIN', 0);
    WORKLOG_NON_SET(p, {});
}

// 수리시간(분) 계산
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

// 연결 비가동 정보 표시
function WORKLOG_NON_SET(p, non) {
    ItsText.SetValue(p + '_txt_PRDNONKEY', non.PRDNONKEY || '');
    ItsText.SetValue(p + '_txt_NONINFO', non.NONINFO || '');
    ItsDate.SetValue(p + '_date_NONSDAY', non.NONSDAY || '', false);
    ItsText.SetValue(p + '_txt_NONSTIME', non.NONSTIME || '', false);
    ItsDate.SetValue(p + '_date_NONEDAY', non.NONEDAY || '', false);
    ItsText.SetValue(p + '_txt_NONETIME', non.NONETIME || '', false);
    ItsNum.SetValue(p + '_num_STOPMIN', non.STOPMIN || 0);
}

// 공무작업일지 저장
function WORKLOG_SAVE(p) {
    var gridEmp = p + '_grid_EMP';
    var gridPart = p + '_grid_PART';
    ItsGrid.Get(gridEmp).finishEditing();
    ItsGrid.Get(gridPart).finishEditing();

    var maria = new ItsMaria('EQM1001_R01', 'ADD_EQMREP_WORK');
    maria.AddParam('EQMREPKEY', wlKey[p]);
    maria.AddPanel(p + '_div1');
    maria.AddPanel(p + '_div2');
    maria.AddPanel(p + '_div3');
    maria.AddPanel(p + '_div4');

    for (var i = 0; i < ItsGrid.Length(gridEmp); i++) {
        var empCd = ItsGrid.GetValue(gridEmp, i, 'EMPCD');
        if (empCd) {
            maria.AddList('EMPCD_LIST', empCd);
        }
    }

    for (var j = 0; j < ItsGrid.Length(gridPart); j++) {
        var qty = ItsGrid.GetValue(gridPart, j, 'PARTQTY');
        maria.AddList('PARTTP_LIST', ItsGrid.GetValue(gridPart, j, 'PARTTP') || '');
        maria.AddList('INOUTKEY_LIST', ItsGrid.GetValue(gridPart, j, 'INOUTKEY') || '');
        maria.AddList('ITEMID_LIST', ItsGrid.GetValue(gridPart, j, 'ITEMID') || '');
        maria.AddList('PARTNM_LIST', ItsGrid.GetValue(gridPart, j, 'PARTNM') || '');
        maria.AddList('PARTSPEC_LIST', ItsGrid.GetValue(gridPart, j, 'PARTSPEC') || '');
        maria.AddList('PARTQTY_LIST', qty == null ? '' : qty);
        maria.AddList('PARTUNIT_LIST', ItsGrid.GetValue(gridPart, j, 'PARTUNIT') || '');
        maria.AddList('PARTREMARK_LIST', ItsGrid.GetValue(gridPart, j, 'REMARK') || '');
        maria.AddList('INOUTDATE_LIST', ItsGrid.GetValue(gridPart, j, 'INOUTDATE') || '');
    }

    maria.CallProc();
    if (maria.isError) {
        maria.ShowErrMsg();
        return false;
    }
    return true;
}

// 공무작업일지 저장 후 목록 재조회 및 포커스 유지
function WORKLOG_AFTER_SAVE(editKey) {
    ItsMsg.Toast(ItsMsg.CommonMsg.SaveComplete());
    ItsGrid.Setkey('grid1', 'EQMREPKEY', editKey);
    ItsButton.EventSearch();
    if (wlKey.wl != editKey) {
        WORKLOG_PANEL_OPEN(editKey);
    }
}

// 작업자·사용 부품 그리드 체크 행 삭제
function WORKLOG_DELETE_CHECKED(gridId) {
    ItsGrid.Get(gridId).finishEditing();
    var delCnt = 0;
    for (var i = ItsGrid.Length(gridId) - 1; i >= 0; i--) {
        if (ItsGrid.IsChecked(gridId, i)) {
            ItsGrid.RemoveRow(gridId, i);
            delCnt++;
        }
    }
    if (delCnt == 0) {
        ItsMsg.Toast('선택된 항목이 없습니다.');
    }
}

// 목록 그리드 체크 행의 수리키 배열 반환
function WORKLOG_CHECKED_KEYS() {
    var arrKey = [];
    for (var i = 0; i < ItsGrid.Length('grid1'); i++) {
        if (ItsGrid.IsChecked('grid1', i)) {
            arrKey.push(ItsGrid.GetValue('grid1', i, 'EQMREPKEY'));
        }
    }
    return arrKey;
}

// 부품 선택 그리드 현재 체크 상태 보관
function PART_KEEP_CHECKED() {
    for (var i = 0; i < ItsGrid.Length('grid_PART'); i++) {
        var itemId = ItsGrid.GetValue('grid_PART', i, 'ITEMID');
        if (ItsGrid.IsChecked('grid_PART', i)) {
            partChecked[itemId] = true;
        } else {
            delete partChecked[itemId];
        }
    }
}

// 부품 선택 목록 검색어 필터링
function PART_FILTER() {
    PART_KEEP_CHECKED();
    var raw = $.trim(ItsText.GetValue('pp_txt_KEYWORD') || '').toUpperCase();
    var arrWord = raw ? raw.split(/\s+/) : [];
    var arrRow = [];

    for (var i = 0; i < arrPartAll.length; i++) {
        var r = arrPartAll[i];
        var text = ((r.ITEMCD || '') + ' ' + (r.ITEMNM || '') + ' ' + (r.ITEMSPEC || '')).toUpperCase();
        var isMatch = true;
        for (var w = 0; w < arrWord.length; w++) {
            if (text.indexOf(arrWord[w]) < 0) {
                isMatch = false;
                break;
            }
        }
        if (isMatch) {
            var row = $.extend({}, r);
            row.isRowCheck = partChecked[r.ITEMID] == true;
            arrRow.push(row);
        }
    }

    ItsGrid.SetStore('grid_PART', new Store('grid_PART', arrRow));
}

// 수리 사진 목록 조회 및 썸네일 표시
function REPIMG_LIST(eqmRepKey, selectFileKey) {
    arrRepImg = [];
    if (eqmRepKey) {
        var maria = new ItsMaria('EQM1001_R01', 'LIST_EQMREP_IMG');
        maria.AddParam('EQMREPKEY', eqmRepKey);
        maria.CallProc();
        if (maria.isError) {
            maria.ShowErrMsg();
        } else {
            arrRepImg = maria.store.data;
        }
    }

    var selIdx = 0;
    var html = '';
    for (var i = 0; i < arrRepImg.length; i++) {
        var img = arrRepImg[i];
        if (img.FILEKEY == selectFileKey) {
            selIdx = i;
        }
        html += '<div class="repimg-thumb" data-index="' + i + '"><img src="' + img.FILEURL + '" />'
            + '<span class="repimg-del" data-filekey="' + img.FILEKEY + '" title="사진 삭제">✕</span></div>';
    }

    $('#div_REPIMG_LIST').html(html);
    $('#spn_REPIMG_EMPTY').text(eqmRepKey ? '등록된 사진이 없습니다. [사진 등록]으로 추가하세요.' : '수리이력을 선택하면 사진이 표시됩니다.');
    ItsLabel.SetText('lbl_REPIMG', '■ 수리 사진 (' + arrRepImg.length + ')');
    REPIMG_SELECT(arrRepImg.length > 0 ? selIdx : -1);
}

// 선택한 수리 사진 미리보기 표시
function REPIMG_SELECT(index) {
    $('#div_REPIMG_LIST .repimg-thumb').removeClass('on');
    if (index < 0 || index >= arrRepImg.length) {
        ItsImage.Clear('img_REPIMG');
        $('#spn_REPIMG_PAGE').hide();
        $('#spn_REPIMG_EMPTY').parent().addClass('empty');
        return;
    }

    $('#spn_REPIMG_EMPTY').parent().removeClass('empty');
    $('#div_REPIMG_LIST .repimg-thumb[data-index="' + index + '"]').addClass('on');
    ItsImage.SetImage('img_REPIMG', arrRepImg[index].FILEURL, arrRepImg[index].FILEKEY);
    $('#spn_REPIMG_PAGE').text((index + 1) + ' / ' + arrRepImg.length).show();
}

// 수리 사진 삭제
function REPIMG_DELETE(fileKey) {
    var eqmRepKey = wlKey.wl;
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

// 수리 사진 파일 선택창 열기
ItsButton.Event('btn_REPIMG_ADD').onClick = function () {
    repImgUploadKey = wlKey.wl;
    if (!repImgUploadKey) {
        ItsMsg.Toast('수리이력을 선택해주세요.');
        return;
    }
    ItsFileManager.Clear('file_REPIMG');
    document.getElementById('file_REPIMGex_filename').click();
};

// 선택한 수리 사진 자동 업로드
ItsFileManager.Event('file_REPIMG').onFileChange = function (id) {
    if (document.getElementById(id + 'ex_filename').files.length < 1) {
        return;
    }
    ItsFileManager.Upload(id);
};

// 업로드 완료된 수리 사진 DB 연결
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
    if (repImgUploadKey == wlKey.wl) {
        REPIMG_LIST(repImgUploadKey, fileKey);
    }
};

// 수리 사진 크게 보기 팝업 열기
ItsImage.Event('img_REPIMG').onClick = function (url, key) {
    if (!key) {
        return;
    }
    ItsImage.SetImage('big_img_REPIMG', url, key);
    ItsPop.Open('pop_REPIMG');
};
