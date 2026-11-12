/* TQM3001_R01: 품질관리 ▶ 협력사 클레임등록 */
/* 협력사(귀책처) × 발생월로 클레임 1건. 품목 수량은 그 달 불량 판정에서 채우고, 단가·제반비용은 사람이 입력한다. */
/* 발생 손실 비용만 다룬다. 제반비용 산출 표·이의제기·CLAIM 비용은 출력물에서 빈칸 (2026-11-10 사용자 지시) */

/// <reference path="../../Script/reference.js" />

/* 페이지 로드 시 수행 */
ItsPage.Load = function () {

    ItsGrid.Create('grid1', { isCheckBoxGrid: false }, [
        column.create('협력사', 'CUSTNM', { width: 100, align: 'center' }),
        column.create('불량수량', 'BADQTY', { width: 70, columnType: enumColumnTypes.number, decimalPrecision: 0 }),
        column.create('등록', 'SAVEYN', { width: 45, columnType: enumColumnTypes.check }),
        column.create('문서번호', 'CLAIMKEY', { width: 110, align: 'center' }),  // 클레임키 = 문서번호
        column.create('예정일자', 'PLANDATE', { width: 85, align: 'center' }),
        column.create('손실비용', 'TOTAMT', { width: 90, columnType: enumColumnTypes.number, decimalPrecision: 0 }),
        column.create('발생월', 'CLAIMMONTH', { width: 70, hidden: true }),
        column.create('귀책처코드', 'CUSTCD', { width: 80, hidden: true }),
        column.split()
    ]);

    ItsGrid.Create('grid2', { isCheckBoxGrid: false }, [
        column.create('품목ID', 'ITEMID', { width: 70, align: 'center', hidden: true }),
        column.create('발생품번', 'ITEMCD', { width: 120 }),
        column.create('발생품명', 'ITEMNM', { width: 200 }),
        column.create('발생내용', 'BADCONT', { width: 180, readOnly: false }),
        // 청구수량 = 판정수량 (처음 조회할 때 발생월 판정수량 합으로 채워지고, 저장한 뒤엔 저장한 값). 고칠 수 없음
        column.create('수량(EA)', 'CLAIMQTY', { width: 65, columnType: enumColumnTypes.number, decimalPrecision: 0 }),
        // 단가는 입고·제조·판매 중 하나만 입력한다 (합계금액에 그 단가를 쓴다)
        column.create('입고단가', 'INPRICE', { width: 75, columnType: enumColumnTypes.number, decimalPrecision: 2, readOnly: false }),
        column.create('제조단가', 'MFGPRICE', { width: 75, columnType: enumColumnTypes.number, decimalPrecision: 2, readOnly: false }),
        column.create('판매단가', 'SALEPRICE', { width: 75, columnType: enumColumnTypes.number, decimalPrecision: 2, readOnly: false }),
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
    ItsGrid.Get('grid1').autoSizeColumns();
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
    ItsDate.SetValue('date_PLANDATE', HEAD.GetValue(0, 'PLANDATE'));
    ItsDate.SetValue('date_CONFDATE', HEAD.GetValue(0, 'CONFDATE'));
    // 담당: 등록 전이면 로그인한 사원 (TQM2001_R01 판정자 기본값과 같은 방식)
    ItsFind.SetValue('find_EMPCD', HEAD.GetValue(0, 'CLAIMKEY') == '' ? ItsPage.EMPCD : HEAD.GetValue(0, 'EMPCD'));
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

/* 단가·제반비용을 고치면 합계금액 = 수량 × 단가 + 제반비용 (단가는 입고·제조·판매 중 입력한 하나) */
ItsGrid.Event('grid2').onChanged = function (rowIndex, field) {
    if (['INPRICE', 'MFGPRICE', 'SALEPRICE', 'ETCAMT'].indexOf(field) < 0) {
        return;
    }
    var CLAIMQTY = Number(ItsGrid.GetValue('grid2', rowIndex, 'CLAIMQTY')) || 0;
    var INPRICE = Number(ItsGrid.GetValue('grid2', rowIndex, 'INPRICE')) || 0;
    var MFGPRICE = Number(ItsGrid.GetValue('grid2', rowIndex, 'MFGPRICE')) || 0;
    var SALEPRICE = Number(ItsGrid.GetValue('grid2', rowIndex, 'SALEPRICE')) || 0;
    var ETCAMT = Number(ItsGrid.GetValue('grid2', rowIndex, 'ETCAMT')) || 0;
    ItsGrid.SetValue('grid2', rowIndex, 'CLAIMAMT', CLAIMQTY * (INPRICE + MFGPRICE + SALEPRICE) + ETCAMT);
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
        maria.AddList('INPRICE_LIST', ITEMROW.INPRICE);
        maria.AddList('MFGPRICE_LIST', ITEMROW.MFGPRICE);
        maria.AddList('SALEPRICE_LIST', ITEMROW.SALEPRICE);
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

    ItsMsg.Confirm('[' + ItsGrid.GetValue('grid1', CUSTROW, 'CUSTNM') + '] 저장된 클레임(' + ItsGrid.GetValue('grid1', CUSTROW, 'CLAIMKEY') + ')을 품목까지 모두 삭제하시겠습니까?', function () {
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
    ItsDate.SetValue('date_PLANDATE', '');
    ItsDate.SetValue('date_CONFDATE', '');
    ItsFind.SetValue('find_EMPCD', '');
    ItsText.SetValue('txt_RECVNM', '');
    ItsText.SetValue('txt_REFNM', '');
    ItsText.SetValue('txt_TITLE', '');
    ItsText.SetValue('txt_REMARK', '');
    ItsGrid.Clear('grid2');
}
