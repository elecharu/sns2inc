/// <reference path="../../Script/reference.js" />

// 2026-10-12 [설비부품 발주조회] 그리드 초기화 (2026-10-13 실제 품목·발주 컬럼 적용)
ItsPage.Load = function () {

    ItsGrid.Create('grid1', { isCheckBoxGrid: true, isSubTotalGrid: true }, [
        column.create("발주일자", "ODRDATE", { width: 100, align: "center" }),
        column.create("주문서번호", "MTRODRKEY", { width: 110, align: "center" }),
        column.create("라인", "MTRODRSEQ", { width: 60, columnType: enumColumnTypes.number, align: "center" }),

        column.create("발주상태", "MTRODRSTT", { width: 90, columnType: enumColumnTypes.combo, gpcd: 'MM110', align: 'center' }),
        column.create("PO유형", "PO", { width: 80, align: 'center' }),

        column.create("거래처코드", "CUSTCD", { width: 100, align: 'center' }),
        column.create("거래처명", "CUSTNM", { width: 140, align: 'left' }),

        column.create("입고처코드", "INCUSTCD", { width: 100, readOnly: true, align: 'center' }),
        column.create("입고처명", "INCUSTNM", { width: 140, align: 'left' }),

        column.create("품목구분", "ITEMCG", { width: 90, columnType: enumColumnTypes.combo, gpcd: 'DM100', align: 'center' }),
        column.create("품목코드", "ITEMCD", { width: 120, align: 'center' }),
        column.create("품명", "ITEMNM", { width: 220, align: 'left' }),
        column.create("규격", "ITEMSPEC", { width: 150, align: 'left' }),
        column.create("단위", "ITEMUNIT", { width: 60, columnType: enumColumnTypes.combo, gpcd: 'DM150', align: 'center' }),
        column.create("납기일자", "EXPDATE", { width: 90, align: 'center' }),
        column.create("구매담당자ID", "BUYER", { width: 110, align: 'center' }),

        column.create("발주수량", "ODRQTY", { width: 90, columnType: enumColumnTypes.number, decimalPrecision: 5, groupType: enumGrouping.sum }),
        column.create("가입고수량", "MTRINQTY", { width: 90, columnType: enumColumnTypes.number, decimalPrecision: 5, groupType: enumGrouping.sum }),
        column.create("입고확정수량", "COMINQTY", { width: 90, columnType: enumColumnTypes.number, decimalPrecision: 5, groupType: enumGrouping.sum }),
        column.create("미입고수량", "NOTINQTY", { width: 90, columnType: enumColumnTypes.number, decimalPrecision: 5, groupType: enumGrouping.sum }),

        column.split()
    ]);

    ItsGrid.Create('grid_ERP', { isCheckBoxGrid: true, isSubTotalGrid: true }, [
        column.create('수신여부', 'IFYN', { width: 70, columnType: enumColumnTypes.check, readOnly: true }),
        column.create('ERP수신키', 'IF_KEY', { hidden: true }),
        column.create("발주일자", "ODRDATE", { width: 100, align: "center" }),
        column.create("주문서번호", "MTRODRKEY", { width: 110, align: "center" }),
        column.create("라인", "MTRODRSEQ", { width: 60, columnType: enumColumnTypes.number, align: "center" }),

        column.create("발주상태", "MTRODRSTT", { width: 90, columnType: enumColumnTypes.combo, gpcd: 'MM110', align: 'center' }),
        column.create("PO유형", "PO", { width: 80, align: 'center' }),

        column.create("거래처", "CUSTCD", { width: 100, align: 'center' }),
        column.create("거래처명", "CUSTNM", { width: 130, align: 'left' }),

        column.create("품목구분", "ITEMCG", { width: 90, columnType: enumColumnTypes.combo, gpcd: 'DM100', align: 'center' }),
        column.create("품목코드", "ITEMCD", { width: 120, align: 'center' }),
        column.create("품명", "ITEMNM", { width: 220, align: 'left' }),
        column.create("규격", "ITEMSPEC", { width: 150, align: 'left' }),

        column.create("납기일자", "EXPDATE", { width: 90, align: "center" }),
        column.create("구매담당자ID", "BUYER", { width: 110, align: 'center' }),

        column.create("발주수량", "ODRQTY", { width: 90, columnType: enumColumnTypes.number, decimalPrecision: 5, groupType: enumGrouping.sum }),
        column.split(1)
    ]);

    ItsGrid.Create('grid_MES', { isCheckBoxGrid: true, isSubTotalGrid: true }, [
        column.create("발주일자", "ODRDATE", { width: 100, align: "center" }),
        column.create("주문서번호", "MTRODRKEY", { width: 110, align: "center" }),
        column.create("라인", "MTRODRSEQ", { width: 60, columnType: enumColumnTypes.number, align: "center" }),

        column.create("발주상태", "MTRODRSTT", { width: 90, columnType: enumColumnTypes.combo, gpcd: 'MM110', align: 'center' }),
        column.create("PO유형", "PO", { width: 80, align: 'center' }),

        column.create("거래처", "CUSTCD", { width: 100, align: 'center' }),
        column.create("거래처명", "CUSTNM", { width: 130, align: 'left' }),

        column.create("품목구분", "ITEMCG", { width: 90, columnType: enumColumnTypes.combo, gpcd: 'DM100', align: 'center' }),
        column.create("품목코드", "ITEMCD", { width: 120, align: 'center' }),
        column.create("품명", "ITEMNM", { width: 220, align: 'left' }),
        column.create("규격", "ITEMSPEC", { width: 150, align: 'left' }),

        column.create("납기일자", "EXPDATE", { width: 90, align: "center" }),
        column.create("구매담당자ID", "BUYER", { width: 110, align: 'center' }),

        column.create("발주수량", "ODRQTY", { width: 90, columnType: enumColumnTypes.number, decimalPrecision: 5, groupType: enumGrouping.sum }),

        column.create("수신시간", "RCVTIME", { width: 130, align: "center" }),
        column.split(1)
    ]);

    ItsDateRange.SetValueFrom('dr_DATE', ItsHelper.AddDay(-30, ItsHelper.GetYearMonthDay()));

    // 2026-10-12 [설비부품 발주조회] 품목구분 기본값을 설비자재(DM100700)로 설정
    ItsCombo.SetValue('cmb_ITEMCG', 'DM100700');

    ItsFind.SetValue('find_EMPCD', ItsPage.EMPCD);
    ItsFind.SetValue('find_EMPCD2', ItsPage.EMPCD);
};

// 2026-10-12 [설비부품 발주조회] 입고처 팝업 (2026-10-13 같은 발주의 모든 행에 적용)
ItsGrid.Event('grid1').onDoubleClick = function (rowIndex, field) {
    ItsGrid.Event('grid1').onKeydownEnter(rowIndex, field);
};

ItsGrid.Event('grid1').onKeydownEnter = function (rowIndex, field) {
    if (field == 'INCUSTCD') {
        ItsPop.OpenFindCOM({
            gpcd: 'CUSTCD',
        }, function (res) {
            var odrKey = ItsGrid.GetValue('grid1', rowIndex, 'MTRODRKEY');
            for (var i = 0; i < ItsGrid.Length('grid1'); i++) {
                if (ItsGrid.GetValue('grid1', i, 'MTRODRKEY') == odrKey) {
                    ItsGrid.SetValue('grid1', i, 'INCUSTCD', res['CODE']);
                    ItsGrid.SetValue('grid1', i, 'INCUSTNM', res['NAME']);
                    ItsGrid.CheckRow('grid1', i);
                }
            }
        });
    }
};

// 2026-10-12 [설비부품 발주조회] 탭별 검색 분기 처리
ItsButton.EventSearch = function () {
    if (ItsTab.GetIndex('tab1') == 0) {
        SearchList();
    }
    else if (ItsTab.GetIndex('tab1') == 1) {
        SearchErpList();
    }
};

// 2026-10-12 [설비부품 발주조회] 발주 내역 조회
var SearchList = function () {
    var maria = new ItsMaria('MTR0001_R04', 'LIST_MTRODR');
    maria.AddPanel('sdiv1');
    maria.CallProc();

    if (maria.isError) {
        maria.ShowErrMsg();
        return;
    }

    ItsGrid.SetStore('grid1', maria.store);
    ItsMsg.Toast(ItsMsg.CommonMsg.SearchComplete(maria.store.Length()));
    ItsGrid.Get('grid1').autoSizeColumns();
};

// 2026-10-12 [설비부품 발주조회] ERP 수신 탭 데이터 조회
var SearchErpList = function () {
    var maria = new ItsMaria('MTR0001_R04', 'LIST_MTRODR_1');
    maria.AddPanel('sdiv1');
    maria.CallProc();

    if (maria.isError) {
        maria.ShowErrMsg();
        return;
    }

    ItsGrid.SetStore('grid_ERP', maria.store.YnToBool('IFYN'));
    ItsGrid.SetStore('grid_MES', maria.storeExtend1);
    ItsGrid.Get('grid_ERP').autoSizeColumns();
    ItsGrid.Get('grid_MES').autoSizeColumns();

    ItsMsg.Toast(ItsMsg.CommonMsg.SearchComplete(maria.store.Length()));
};

// 2026-10-12 [설비부품 발주조회] ERP 수신 (2026-10-13 수신키로 원본을 저장)
ItsButton.Event('btn_RCV_ERPDATA').onClick = function () {
    ItsMsg.Confirm("선택항목을 수신하시겠습니까?", function () {
        var cnt = 0;
        var maria = new ItsMaria('MTR0001_R04', 'RCV_ERPDATA');
        maria.AddParam('EMPCD', ItsFind.GetValue('find_EMPCD'));

        for (var i = 0; i < ItsGrid.Length('grid_ERP'); i++) {
            if (ItsGrid.IsChecked('grid_ERP', i)) {
                maria.AddList('IF_KEY_LIST', ItsGrid.GetValue('grid_ERP', i, 'IF_KEY'));
                cnt++;
            }
        }

        if (cnt == 0) {
            ItsMsg.Alert('수신할 대상을 선택해주세요.');
            return;
        }

        maria.CallProc();

        if (maria.isError) {
            maria.ShowErrMsg();
            return;
        }

        ItsMsg.Toast('수신이 완료되었습니다.');
        ItsButton.EventSearch();
    });
};

// 2026-10-12 [설비부품 발주조회] MES 데이터 삭제 실행
ItsButton.Event('btn_DELETE_MESDATA').onClick = function () {
    ItsMsg.Confirm("선택항목을 삭제하시겠습니까?", function () {
        var cnt = 0;

        for (var i = 0; i < ItsGrid.Length('grid_MES'); i++) {
            if (ItsGrid.IsChecked('grid_MES', i)) {
                var maria = new ItsMaria('MTR0001_R04', 'DELETE_MESDATA');
                maria.AddParam('EMPCD', ItsFind.GetValue('find_EMPCD2'));
                maria.AddParam('MTRODRKEY', ItsGrid.GetValue('grid_MES', i, 'MTRODRKEY'));
                maria.AddParam('MTRODRSEQ', ItsGrid.GetValue('grid_MES', i, 'MTRODRSEQ'));
                maria.CallProc();

                if (maria.isError) {
                    maria.ShowErrMsg();
                    return;
                }
                cnt++;
            }
        }

        if (cnt == 0) {
            ItsMsg.Alert('삭제할 대상을 선택해주세요.');
            return;
        }

        ItsMsg.Toast(ItsMsg.CommonMsg.DeleteComplete(cnt));
        ItsButton.EventSearch();
    });
};

// 2026-10-12 [설비부품 발주조회] 입고처 저장 (2026-10-13 발주 전체에 적용)
ItsButton.EventSave = function () {
    ItsMsg.Confirm("선택된 내용을 저장합니다.", function () {
        var maria = new ItsMaria('MTR0001_R04', 'UPDATE_INCUSTCD');
        var cnt = 0;

        var orders = Object.create(null);
        for (var i = 0; i < ItsGrid.Length('grid1'); i++) {
            if (ItsGrid.IsChecked('grid1', i)) {
                var odrKey = ItsGrid.GetValue('grid1', i, 'MTRODRKEY');
                if (!orders[odrKey]) {
                    maria.AddList('MTRODRKEY_LIST', odrKey);
                    maria.AddList('INCUSTCD_LIST', ItsGrid.GetValue('grid1', i, 'INCUSTCD'));
                    orders[odrKey] = true;
                    cnt++;
                }
            }
        }

        if (cnt == 0) {
            ItsMsg.Alert('저장할 대상을 선택해주세요.');
            return;
        }

        maria.CallProc();

        if (maria.isError) {
            maria.ShowErrMsg();
            return;
        }

        ItsMsg.Toast('저장이 완료되었습니다.');
        ItsButton.EventSearch();
    });
};