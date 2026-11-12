/* TQM2001_R01: 품질관리 ▶ 부적합관리 ▷ 부적합 판정등록 */
/* 불량창고 재고를 보고 판정(양품/불량/재작업)만 등록한다. 후처리는 다른 화면에서 한다. */

/// <reference path="../../Script/reference.js" />

/* 페이지 로드 시 수행 */
ItsPage.Load = function () {

    ItsGrid.Create('grid1', { isCheckBoxGrid: true }, [
        column.create('불량창고', 'WARENM', { width: 100, align: 'center' }),
        column.create('로트번호', 'LOTKEY', { width: 130, align: 'center' }),
        column.create('품목유형', 'ITEMCG', { width: 80, align: 'center', columnType: enumColumnTypes.combo, gpcd: 'DM100' }),
        column.create('품목코드', 'ITEMCD', { width: 90, align: 'center' }),
        column.create('품명', 'ITEMNM', { width: 150 }),
        column.create('규격', 'ITEMSPEC', { width: 90 }),
        column.create('공정', 'PRCNM', { width: 80, align: 'center' }),
        column.create('생산일자', 'PRDDATE', { width: 85, align: 'center' }),
        column.create('재고수량', 'LOTQTY', { width: 70, columnType: enumColumnTypes.number, decimalPrecision: 0 }),
        column.create('판정수량', 'JUDGEQTY', { width: 70, columnType: enumColumnTypes.number, decimalPrecision: 0 }),
        column.create('미판정수량', 'REMAINQTY', { width: 75, columnType: enumColumnTypes.number, decimalPrecision: 0 }),
        column.create('판정상태', 'JUDGESTT', { width: 70, align: 'center', columnType: enumColumnTypes.combo, gpcd: 'JUDGESTT' }),
        column.create('창고코드', 'WARECD', { width: 80, hidden: true }),
        column.create('품목ID', 'ITEMID', { width: 80, hidden: true }),
        column.split()
    ]);

    ItsGrid.Create('grid2', { isCheckBoxGrid: true }, [
        column.create('판정키', 'JUDGEKEY', { width: 80, hidden: true }),
        column.create('판정일자', 'JUDGEDATE', { width: 90, align: 'center', columnType: enumColumnTypes.date, readOnly: false }),
        column.create('판정유형', 'JUDGETP', { width: 80, align: 'center', columnType: enumColumnTypes.combo, gpcd: 'JUDGETP', readOnly: false }),
        column.create('불량구분', 'JUDGEBADTP', { width: 80, align: 'center', columnType: enumColumnTypes.combo, gpcd: 'JUDGEBADTP', readOnly: false }),
        column.create('불량코드', 'BADCD', { width: 90, align: 'center', columnType: enumColumnTypes.find, gpcd: 'BADCD', readOnly: false }),
        column.create('불량명', 'BADNM', { width: 120 }),
        column.create('판정수량', 'JUDGEQTY', { width: 70, columnType: enumColumnTypes.number, decimalPrecision: 0, readOnly: false }),
        column.create('판정자코드', 'EMPCD', { width: 80, align: 'center', columnType: enumColumnTypes.find, gpcd: 'EMPCD', readOnly: false }),
        column.create('판정자명', 'EMPNM', { width: 80, align: 'center' }),
        column.create('비고', 'REMARK', { width: 150, readOnly: false }),
        column.create('후처리', 'PROCYN', { width: 55, columnType: enumColumnTypes.check }),
        column.split()
    ]);
};

/* 조회 */
ItsButton.EventSearch = function () {
    ItsGrid.Clear('grid2');

    var maria = new ItsMaria('TQM2001_R01', 'LIST_LOT');
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

/* 불량재고 선택 → 판정이력 조회 */
ItsGrid.Event('grid1').onSelect = function (rowIndex, field) {
    var maria = new ItsMaria('TQM2001_R01', 'LIST_JUDGE');
    maria.AddParam('LOTKEY', ItsGrid.GetValue('grid1', rowIndex, 'LOTKEY'));
    maria.AddParam('WARECD', ItsGrid.GetValue('grid1', rowIndex, 'WARECD'));
    maria.CallProc();
    if (maria.isError) {
        maria.ShowErrMsg();
        return;
    }
    ItsGrid.SetStore('grid2', maria.store.YnToBool('PROCYN'));
};

/* 추가: 선택한 불량재고에 판정 한 줄 추가 (판정수량은 미판정수량으로 채움) */
ItsButton.EventAdd = function () {
    if (ItsGrid.Length('grid1') == 0) {
        ItsMsg.Alert('불량재고를 먼저 조회하세요.');
        return;
    }

    var REMAINQTY = ItsGrid.GetValue('grid1', ItsGrid.GetCurrentIndex('grid1'), 'REMAINQTY');
    if (REMAINQTY <= 0) {
        ItsMsg.Alert('미판정수량이 없습니다. 기존 판정의 수량을 고치거나 삭제하세요.');
        return;
    }

    // 판정자 기본값: 로그인 사원
    var maria = new ItsMaria('TQM2001_R01', 'INFO_EMP');
    maria.AddParam('EMPCD', ItsPage.EMPCD);
    maria.CallProc();
    if (maria.isError) {
        maria.ShowErrMsg();
        return;
    }

    ItsGrid.AddRow('grid2', ItsGrid.Length('grid2'), {
        isRowCheck: true,
        JUDGEKEY: '',
        JUDGEDATE: ItsHelper.GetYearMonthDay(),
        JUDGETP: '',
        JUDGEBADTP: '',
        BADCD: '',
        BADNM: '',
        JUDGEQTY: REMAINQTY,
        EMPCD: ItsPage.EMPCD,
        EMPNM: maria.store.Length() > 0 ? maria.store.GetValue(0, 'EMPNM') : '',
        REMARK: '',
        PROCYN: false
    });
};

/* 판정자코드 칸 더블클릭·Enter → 사원 찾기 팝업, 발생내용코드 칸 → 폐기 불량코드 찾기 팝업 */
ItsGrid.Event('grid2').onDoubleClick = function (rowIndex, field) {
    ItsGrid.Event('grid2').onKeydownEnter(rowIndex, field);
};

ItsGrid.Event('grid2').onKeydownEnter = function (rowIndex, field) {
    if (field == 'EMPCD') {
        ItsPop.OpenFindCOM({ gpcd: 'EMPCD', keyword: ItsGrid.GetValue('grid2', rowIndex, field) }, function (res) {
            ItsGrid.SetValue('grid2', rowIndex, 'EMPCD', res['CODE']);
            ItsGrid.SetValue('grid2', rowIndex, 'EMPNM', res['NAME']);
            ItsGrid.CheckRow('grid2', rowIndex);
        });
    } else if (field == 'BADCD') {
        // 발생내용: 대분류(QM210)가 폐기(QM210I210N)인 불량코드만
        ItsPop.OpenFindCOM({ gpcd: 'BADCD', ref01: '07', ref02: 'QM210I210N', keyword: ItsGrid.GetValue('grid2', rowIndex, field) }, function (res) {
            ItsGrid.SetValue('grid2', rowIndex, 'BADCD', res['CODE']);
            ItsGrid.SetValue('grid2', rowIndex, 'BADNM', res['NAME']);
            ItsGrid.CheckRow('grid2', rowIndex);
        });
    }
};

/* 판정자코드·발생내용코드를 지우면 이름도 지움 */
ItsGrid.Event('grid2').onChanged = function (rowIndex, field, newValue) {
    if (newValue != undefined && newValue != '') return;

    if (field == 'EMPCD') {
        ItsGrid.SetValue('grid2', rowIndex, 'EMPNM', '');
    } else if (field == 'BADCD') {
        ItsGrid.SetValue('grid2', rowIndex, 'BADNM', '');
    }
};

/* 저장: 체크된 판정(새로 추가하거나 고친 줄)을 한 번에 저장 */
ItsButton.EventSave = function () {
    if (ItsGrid.Length('grid1') == 0) {
        ItsMsg.Alert('불량재고를 먼저 조회하세요.');
        return;
    }

    ItsGrid.FinishEditing('grid2');

    var LOTROW = ItsGrid.GetCurrentIndex('grid1');
    var maria = new ItsMaria('TQM2001_R01', 'SAVE_JUDGE');
    maria.AddParam('LOTKEY', ItsGrid.GetValue('grid1', LOTROW, 'LOTKEY'));
    maria.AddParam('WARECD', ItsGrid.GetValue('grid1', LOTROW, 'WARECD'));

    var SAVECNT = 0;
    for (var i = 0; i < ItsGrid.Length('grid2'); i++) {
        if (ItsGrid.IsChecked('grid2', i)) {
            var ROWDATA = ItsGrid.GetRowData('grid2', i);
            maria.AddList('JUDGEKEY_LIST', ROWDATA.JUDGEKEY);
            maria.AddList('JUDGEDATE_LIST', ROWDATA.JUDGEDATE);
            maria.AddList('JUDGETP_LIST', ROWDATA.JUDGETP);
            maria.AddList('JUDGEBADTP_LIST', ROWDATA.JUDGEBADTP);
            maria.AddList('BADCD_LIST', ROWDATA.BADCD);
            maria.AddList('JUDGEQTY_LIST', ROWDATA.JUDGEQTY);
            maria.AddList('EMPCD_LIST', ROWDATA.EMPCD);
            maria.AddList('REMARK_LIST', ROWDATA.REMARK);
            SAVECNT++;
        }
    }

    if (SAVECNT == 0) {
        ItsMsg.Alert('저장할 판정이 없습니다.');
        return;
    }

    ItsMsg.Confirm('저장하시겠습니까?', function () {
        maria.CallProc();
        if (maria.isError) {
            maria.ShowErrMsg();
            return;
        }
        ItsMsg.Toast(ItsMsg.CommonMsg.SaveComplete(SAVECNT));
        ItsGrid.Setkey('grid1', 'LOTKEY', ItsGrid.GetValue('grid1', LOTROW, 'LOTKEY'));
        ItsButton.EventSearch();

        // 저장한 판정의 공정이동표 출력
        var JUDGEKEYS = maria.store.GetValue(0, 'JUDGEKEYS');
        ItsMsg.Confirm('공정이동표를 출력하시겠습니까?', function () {
            PrintMove(JUDGEKEYS);
        });
    });
};

/* [공정이동표 출력] → grid2 에 체크한 판정 (체크가 없으면 선택한 줄) */
ItsButton.Event('btn_PRINT_MOVE').onClick = function () {
    ItsGrid.FinishEditing('grid2');

    var JUDGEKEYS = '';
    for (var i = 0; i < ItsGrid.Length('grid2'); i++) {
        if (!ItsGrid.IsChecked('grid2', i)) continue;

        if (!ItsGrid.GetValue('grid2', i, 'JUDGEKEY')) {
            ItsMsg.Alert('저장하지 않은 판정이 있습니다. 먼저 저장하세요.');
            return;
        }
        JUDGEKEYS += (JUDGEKEYS == '' ? '' : ',') + ItsGrid.GetValue('grid2', i, 'JUDGEKEY');
    }

    if (JUDGEKEYS == '') {
        var ROW = ItsGrid.GetCurrentIndex('grid2');
        if (ItsGrid.Length('grid2') == 0 || ROW < 0) {
            ItsMsg.Alert('출력할 판정을 선택하세요.');
            return;
        }
        if (!ItsGrid.GetValue('grid2', ROW, 'JUDGEKEY')) {
            ItsMsg.Alert('저장하지 않은 판정입니다. 먼저 저장하세요.');
            return;
        }
        JUDGEKEYS = ItsGrid.GetValue('grid2', ROW, 'JUDGEKEY');
    }

    PrintMove(JUDGEKEYS);
};

/* 공정이동표 출력 (판정 1건에 1장, 리포트 TQM2001.exe R01). JUDGEKEYS = 판정키 쉼표 구분 */
function PrintMove(JUDGEKEYS) {
    var rpt = new ItsXtraRpt('TQM2001_R01');
    rpt.AddParam('JUDGEKEYS', JUDGEKEYS);
    rpt.AddParam('EMPCD', ItsPage.EMPCD);
    rpt.CallPop();
    if (rpt.isError) {
        ItsMsg.Alert(rpt.errMessage);
    }
}

/* [일괄판정] → 체크한 불량재고 확인 후 판정 입력 팝업 */
ItsButton.Event('btn_JUDGE_MULTI').onClick = function () {
    var LOTCNT = 0;
    for (var i = 0; i < ItsGrid.Length('grid1'); i++) {
        if (!ItsGrid.IsChecked('grid1', i)) continue;

        if (ItsGrid.GetValue('grid1', i, 'REMAINQTY') <= 0) {
            ItsMsg.Alert('[' + ItsGrid.GetValue('grid1', i, 'LOTKEY') + '] 미판정수량이 없습니다.');
            return;
        }
        LOTCNT++;
    }
    if (LOTCNT == 0) {
        ItsMsg.Alert('일괄판정할 불량재고를 체크하세요.');
        return;
    }

    ItsDate.SetValue('pop1_date_JUDGEDATE', ItsHelper.GetYearMonthDay());
    ItsFind.SetValue('pop1_find_EMPCD', ItsPage.EMPCD);
    ItsCombo.SetValue('pop1_cmb_JUDGETP', '');
    ItsCombo.SetValue('pop1_cmb_JUDGEBADTP', '');
    ItsFind.SetValue('pop1_find_BADCD', '');
    ItsText.SetValue('pop1_txt_REMARK', '');
    $('#pop1').height(245);   // Type="add" 팝업은 열 때마다 45px 씩 커지는 라이브러리 버그가 있어 되돌림
    ItsPop.Open('pop1');
};

/* 팝업 [판정등록] → 체크한 로트마다 미판정수량 전부로 판정 1건씩 등록 */
ItsPop.Event('pop1').onAddBtnClick = function () {
    var maria = new ItsMaria('TQM2001_R01', 'SAVE_JUDGE_MULTI');
    maria.AddPanel('pdiv1');

    var LOTCNT = 0;
    for (var i = 0; i < ItsGrid.Length('grid1'); i++) {
        if (ItsGrid.IsChecked('grid1', i)) {
            maria.AddList('LOTKEY_LIST', ItsGrid.GetValue('grid1', i, 'LOTKEY'));
            maria.AddList('WARECD_LIST', ItsGrid.GetValue('grid1', i, 'WARECD'));
            LOTCNT++;
        }
    }

    ItsMsg.Confirm(LOTCNT + '건을 일괄판정 하시겠습니까?', function () {
        maria.CallProc();
        if (maria.isError) {
            maria.ShowErrMsg();
            return;
        }
        ItsMsg.Toast(ItsMsg.CommonMsg.SaveComplete(LOTCNT));
        ItsPop.Close('pop1');
        ItsButton.EventSearch();

        // 일괄판정한 판정의 공정이동표 출력 (로트마다 1장)
        var JUDGEKEYS = maria.store.GetValue(0, 'JUDGEKEYS');
        ItsMsg.Confirm('공정이동표를 출력하시겠습니까?', function () {
            PrintMove(JUDGEKEYS);
        });
    });
};

ItsPop.Event('pop1').onCancelBtnClick = function () {
    ItsPop.Close('pop1');
};

/* 삭제: 체크된 판정 삭제 (아직 저장 안 한 줄은 다시 조회하면 사라진다) */
ItsButton.EventDelete = function () {
    if (ItsGrid.Length('grid1') == 0) {
        ItsMsg.Alert('불량재고를 먼저 조회하세요.');
        return;
    }

    var LOTROW = ItsGrid.GetCurrentIndex('grid1');
    var maria = new ItsMaria('TQM2001_R01', 'DELETE_JUDGE');

    var DELCNT = 0;
    for (var i = 0; i < ItsGrid.Length('grid2'); i++) {
        if (ItsGrid.IsChecked('grid2', i) && ItsGrid.GetValue('grid2', i, 'JUDGEKEY') != '') {
            maria.AddList('JUDGEKEY_LIST', ItsGrid.GetValue('grid2', i, 'JUDGEKEY'));
            DELCNT++;
        }
    }

    if (DELCNT == 0) {
        ItsMsg.Alert('삭제할 판정을 선택하세요.');
        return;
    }

    ItsMsg.Confirm('선택한 판정을 삭제하시겠습니까?', function () {
        maria.CallProc();
        if (maria.isError) {
            maria.ShowErrMsg();
            return;
        }
        ItsMsg.Toast(ItsMsg.CommonMsg.DeleteComplete(DELCNT));
        ItsGrid.Setkey('grid1', 'LOTKEY', ItsGrid.GetValue('grid1', LOTROW, 'LOTKEY'));
        ItsButton.EventSearch();
    });
};
