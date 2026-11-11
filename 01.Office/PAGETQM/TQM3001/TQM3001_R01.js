/* TQM3001_R01: 품질관리 ▶ 협력사 클레임등록 */
/* 협력사(귀책처) × 발생월로 클레임 1건. 품목 수량은 그 달 불량 판정에서 채우고, 단가·제반비용은 사람이 입력한다. */
/* 발생 손실 비용만 다룬다. 제반비용 산출 표·이의제기·CLAIM 비용은 출력물에서 빈칸 (2026-11-10 사용자 지시) */

/// <reference path="../../Script/reference.js" />

/* 페이지 로드 시 수행 */
ItsPage.Load = function () {

    ItsGrid.Create('grid1', { isCheckBoxGrid: false }, [
        column.create('협력사', 'CUSTNM', { width: 120 }),
        column.create('불량수량', 'BADQTY', { width: 70, columnType: enumColumnTypes.number, decimalPrecision: 0 }),
        column.create('등록', 'SAVEYN', { width: 45, columnType: enumColumnTypes.check }),
        column.create('문서번호', 'CLAIMKEY', { width: 110, align: 'center' }),  // 클레임키 = 문서번호
        column.create('작성일', 'DOCDATE', { width: 85, align: 'center' }),
        column.create('손실비용', 'TOTAMT', { width: 90, columnType: enumColumnTypes.number, decimalPrecision: 0 }),
        column.create('발생월', 'CLAIMMONTH', { width: 70, hidden: true }),
        column.create('귀책처코드', 'CUSTCD', { width: 80, hidden: true }),
        column.split()
    ]);

    ItsGrid.Create('grid2', { isCheckBoxGrid: true }, [
        column.create('품목ID', 'ITEMID', { width: 70, align: 'center', hidden: true }),
        column.create('발생품번', 'ITEMCD', { width: 110 }),
        column.create('발생품명', 'ITEMNM', { width: 150 }),
        column.create('발생내용', 'BADCONT', { width: 180, readOnly: false }),
        column.create('판정수량', 'JUDGEQTY', { width: 65, columnType: enumColumnTypes.number, decimalPrecision: 0 }),
        column.create('수량(EA)', 'CLAIMQTY', { width: 65, columnType: enumColumnTypes.number, decimalPrecision: 0, readOnly: false }),
        column.create('단가구분', 'PRICETP', { width: 75, align: 'center', columnType: enumColumnTypes.combo, gpcd: 'CLAIMPRICETP', readOnly: false }),
        column.create('단가', 'UNITPRICE', { width: 80, columnType: enumColumnTypes.number, decimalPrecision: 2, readOnly: false }),
        column.create('제반비용', 'ETCAMT', { width: 80, columnType: enumColumnTypes.number, decimalPrecision: 0, readOnly: false }),
        column.create('합계금액', 'CLAIMAMT', { width: 95, columnType: enumColumnTypes.number, decimalPrecision: 0 }),
        column.create('비고', 'REMARK', { width: 150, readOnly: false }),
        column.split()
    ]);
};

/* 조회: 발생월 협력사 목록 */
ItsButton.EventSearch = function () {
    ClearClaim();

    var maria = new ItsMaria('TQM3001_R01', 'LIST');
    maria.AddPanel('sdiv1');
    maria.CallProc();
    if (maria.isError) {
        maria.ShowErrMsg();
        return;
    }
    ItsGrid.SetStore('grid1', maria.store.YnToBool('SAVEYN'));
    ItsMsg.Toast(ItsMsg.CommonMsg.SearchComplete(maria.store.Length()));
};

/* 협력사 선택 → 클레임 머리글·품목 조회 (등록 전이면 기본값) */
ItsGrid.Event('grid1').onSelect = function (rowIndex, field) {
    var SMONTH = ItsGrid.GetValue('grid1', rowIndex, 'CLAIMMONTH');
    var CUSTCD = ItsGrid.GetValue('grid1', rowIndex, 'CUSTCD');

    var maria = new ItsMaria('TQM3001_R01', 'INFO_HEAD');
    maria.AddParam('SMONTH', SMONTH);
    maria.AddParam('CUSTCD', CUSTCD);
    maria.CallProc();
    if (maria.isError) {
        maria.ShowErrMsg();
        return;
    }
    var HEAD = maria.store;
    ItsText.SetValue('txt_CLAIMKEY', HEAD.GetValue(0, 'CLAIMKEY'));
    ItsDate.SetValue('date_DOCDATE', HEAD.GetValue(0, 'DOCDATE'));
    ItsDate.SetValue('date_OBJDATE', HEAD.GetValue(0, 'OBJDATE'));
    ItsFind.SetValue('find_EMPCD', HEAD.GetValue(0, 'EMPCD'));
    ItsText.SetValue('txt_RECVNM', HEAD.GetValue(0, 'RECVNM'));
    ItsText.SetValue('txt_REFNM', HEAD.GetValue(0, 'REFNM'));
    ItsText.SetValue('txt_TITLE', HEAD.GetValue(0, 'TITLE'));
    ItsText.SetValue('txt_REMARK', HEAD.GetValue(0, 'REMARK'));

    maria = new ItsMaria('TQM3001_R01', 'LIST_ITEM');
    maria.AddParam('SMONTH', SMONTH);
    maria.AddParam('CUSTCD', CUSTCD);
    maria.CallProc();
    if (maria.isError) {
        maria.ShowErrMsg();
        return;
    }
    ItsGrid.SetStore('grid2', maria.store);
};

/* 수량·단가·제반비용을 고치면 합계금액 = 수량 × 단가 + 제반비용 */
ItsGrid.Event('grid2').onChanged = function (rowIndex, field) {
    if (field != 'CLAIMQTY' && field != 'UNITPRICE' && field != 'ETCAMT') {
        return;
    }
    var CLAIMQTY = Number(ItsGrid.GetValue('grid2', rowIndex, 'CLAIMQTY')) || 0;
    var UNITPRICE = Number(ItsGrid.GetValue('grid2', rowIndex, 'UNITPRICE')) || 0;
    var ETCAMT = Number(ItsGrid.GetValue('grid2', rowIndex, 'ETCAMT')) || 0;
    ItsGrid.SetValue('grid2', rowIndex, 'CLAIMAMT', CLAIMQTY * UNITPRICE + ETCAMT);
};

/* [행삭제] 체크한 품목을 클레임에서 뺀다 (저장해야 반영) */
ItsButton.Event('btn_DEL_ITEM').onClick = function () {
    var DELCNT = 0;
    for (var i = ItsGrid.Length('grid2') - 1; i >= 0; i--) {
        if (ItsGrid.IsChecked('grid2', i)) {
            ItsGrid.RemoveRow('grid2', i);
            DELCNT++;
        }
    }
    if (DELCNT == 0) {
        ItsMsg.Alert('뺄 품목을 체크하세요.');
    }
};

/* 저장: 머리글 + 품목(그리드 전체, 화면 순서 = NO) */
ItsButton.EventSave = function () {
    if (ItsGrid.Length('grid1') == 0) {
        ItsMsg.Alert('협력사를 먼저 조회하세요.');
        return;
    }

    ItsGrid.FinishEditing('grid2');

    if (ItsGrid.Length('grid2') == 0) {
        ItsMsg.Alert('저장할 품목이 없습니다.');
        return;
    }

    var CUSTROW = ItsGrid.GetCurrentIndex('grid1');
    var CUSTCD = ItsGrid.GetValue('grid1', CUSTROW, 'CUSTCD');

    var maria = new ItsMaria('TQM3001_R01', 'SAVE');
    maria.AddParam('SMONTH', ItsGrid.GetValue('grid1', CUSTROW, 'CLAIMMONTH'));
    maria.AddParam('CUSTCD', CUSTCD);
    maria.AddPanel('hdiv1');

    for (var i = 0; i < ItsGrid.Length('grid2'); i++) {
        var ITEMROW = ItsGrid.GetRowData('grid2', i);
        maria.AddList('ITEMID_LIST', ITEMROW.ITEMID);
        maria.AddList('BADCONT_LIST', ITEMROW.BADCONT);
        maria.AddList('CLAIMQTY_LIST', ITEMROW.CLAIMQTY);
        maria.AddList('PRICETP_LIST', ITEMROW.PRICETP);
        maria.AddList('UNITPRICE_LIST', ITEMROW.UNITPRICE);
        maria.AddList('ETCAMT_LIST', ITEMROW.ETCAMT);
        maria.AddList('ITEMREMARK_LIST', ITEMROW.REMARK);
    }

    ItsMsg.Confirm('저장하시겠습니까?', function () {
        maria.CallProc();
        if (maria.isError) {
            maria.ShowErrMsg();
            return;
        }
        ItsMsg.Toast('저장했습니다. 문서번호: ' + maria.store.GetValue(0, 'CLAIMKEY'));
        ItsGrid.Setkey('grid1', 'CUSTCD', CUSTCD);
        ItsButton.EventSearch();
    });
};

/* 삭제: 선택한 협력사의 클레임 삭제 */
ItsButton.EventDelete = function () {
    if (ItsGrid.Length('grid1') == 0) {
        ItsMsg.Alert('협력사를 먼저 조회하세요.');
        return;
    }

    var CUSTROW = ItsGrid.GetCurrentIndex('grid1');
    if (ItsGrid.GetValue('grid1', CUSTROW, 'CLAIMKEY') == '') {
        ItsMsg.Alert('등록한 클레임이 없습니다.');
        return;
    }

    var CUSTCD = ItsGrid.GetValue('grid1', CUSTROW, 'CUSTCD');
    var maria = new ItsMaria('TQM3001_R01', 'DELETE');
    maria.AddParam('SMONTH', ItsGrid.GetValue('grid1', CUSTROW, 'CLAIMMONTH'));
    maria.AddParam('CUSTCD', CUSTCD);

    ItsMsg.Confirm('[' + ItsGrid.GetValue('grid1', CUSTROW, 'CUSTNM') + '] 클레임을 삭제하시겠습니까?', function () {
        maria.CallProc();
        if (maria.isError) {
            maria.ShowErrMsg();
            return;
        }
        ItsMsg.Toast(ItsMsg.CommonMsg.DeleteComplete(1));
        ItsGrid.Setkey('grid1', 'CUSTCD', CUSTCD);
        ItsButton.EventSearch();
    });
};

/* [클레임통보서 출력] 선택한 협력사의 저장된 클레임 → 공문서 + 산출내역서 (리포트 TQM3001.exe R01) */
ItsButton.Event('btn_PRINT_CLAIM').onClick = function () {
    if (ItsGrid.Length('grid1') == 0) {
        ItsMsg.Alert('협력사를 먼저 조회하세요.');
        return;
    }

    var CUSTROW = ItsGrid.GetCurrentIndex('grid1');
    if (ItsGrid.GetValue('grid1', CUSTROW, 'CLAIMKEY') == '') {
        ItsMsg.Alert('저장한 클레임만 출력할 수 있습니다. 먼저 저장하세요.');
        return;
    }

    var rpt = new ItsXtraRpt('TQM3001_R01');
    rpt.AddParam('SMONTH', ItsGrid.GetValue('grid1', CUSTROW, 'CLAIMMONTH'));
    rpt.AddParam('CUSTCD', ItsGrid.GetValue('grid1', CUSTROW, 'CUSTCD'));
    rpt.CallPop();
    if (rpt.isError) {
        ItsMsg.Alert(rpt.errMessage);
    }
};

/* 오른쪽(머리글·품목) 비우기 */
function ClearClaim() {
    ItsText.SetValue('txt_CLAIMKEY', '');
    ItsDate.SetValue('date_DOCDATE', '');
    ItsDate.SetValue('date_OBJDATE', '');
    ItsFind.SetValue('find_EMPCD', '');
    ItsText.SetValue('txt_RECVNM', '');
    ItsText.SetValue('txt_REFNM', '');
    ItsText.SetValue('txt_TITLE', '');
    ItsText.SetValue('txt_REMARK', '');
    ItsGrid.Clear('grid2');
}
