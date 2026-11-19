/// <reference path="../../Script/reference.js" />

ItsPage.Load = function () {
    ItsGrid.Create('grid1', { isCheckBoxGrid: true }, [
        column.create("법인", "COMPANYCD", { width: 100, align: 'center', columnType: enumColumnTypes.combo, gpcd: 'COMPANYCD' }),
        column.create("공장", "FACTORYCD", { width: 100, align: 'center', columnType: enumColumnTypes.combo, gpcd: 'FACTORYCD' }),
        column.create("품목유형", "ITEMCG", { width: 100, align: 'center', columnType: enumColumnTypes.combo, gpcd: 'DM100', readOnly: true }),
        column.create("대분류", "ITEM_LVL1", { width: 100, align: 'center' }),
        column.create("중분류", "ITEM_LVL2", { width: 100, align: 'center' }),
        column.create("소분류", "ITEM_LVL3", { width: 100, align: 'center' }),
        column.create("세분류", "ITEM_LVL4", { width: 100, align: 'center', columnType: enumColumnTypes.combo, gpcd: 'PP310' }),
        column.create("품목ID", "ITEMID", { width: 100, align: 'center' }),
        column.create("품목코드", "ITEMCD", { width: 100, align: 'center', backColor: enumColor.greenLight2 }),
        column.create("품명", "ITEMNM", { width: 120 }),
        column.create("규격", "ITEMSPEC", { width: 120 }),
        column.create("안전재고", "SAFEQTY", { width: 90, align: 'right', format: '#,##0', readOnly: false }),
        column.create("현재고", "LOTQTY", { width: 90, align: 'right', format: '#,##0', readOnly: true }),
        column.create("관리단위", "ITEMUNIT", { width: 100, align: 'center', columnType: enumColumnTypes.combo, gpcd: 'DM150' }),
        column.create("공급구분", "ITEMSRC", { width: 100, align: 'center', columnType: enumColumnTypes.combo, gpcd: 'DM160' }),
        column.create("종료여부", "ENDYN", { width: 100, align: 'center', columnType: enumColumnTypes.check }),
    ]);

    // 2026-10-27 [생산팀 소모품] 공장 INC 2공장(07) 디폴트, 품목유형 소모자재(DM100750) 고정 및 품목검색 연동 (법인은 공장의 법인코드를 씀)
    ItsCombo.SetValue('cmb_FACTORYCD', '07');
    ItsCombo.SetValue('sdiv1_combo_ITEMCG', 'DM100750');
    ItsFind.SetRef02('sdiv1_find_ITEMID', 'DM100750');
};

/* 공장이 정해지면 품목 find 에 법인(REF01)·공장(REF03) 넣기. 법인코드는 공장 콤보 목록 줄의 REF01(DC_COMBO FACTORYCD) */
ItsCombo.Event('cmb_FACTORYCD').onChanged = function (value) {
    var companycd = $('#cmb_FACTORYCD').siblings('ul').children('li').filter('[data-value="' + value + '"]').attr('data-ref01');
    if (companycd == undefined || companycd == 'undefined') companycd = '';
    ItsFind.SetRef01('sdiv1_find_ITEMID', companycd);
    ItsFind.SetRef03('sdiv1_find_ITEMID', value);
};

// 2026-10-27 [생산팀 소모품] INC 2공장 소모품 및 재고현황 조회
ItsButton.EventSearch = function () {

    var maria = new ItsMaria('MST3001_R04', 'SEL_ITEM');
    maria.AddPanel('sdiv1');
    maria.AddParam('COMPANYCD', ItsFind.GetRef01('sdiv1_find_ITEMID'));   // 법인 = 선택한 공장의 법인코드
    maria.CallProc();
    if (maria.isError) {
        maria.ShowErrMsg();
        return;
    }

    var store = maria.store.YnToBool('ENDYN');
    for (var i = 0; i < store.data.length; i++) {
        store.data[i]._ORG_SAFEQTY = store.data[i].SAFEQTY;
    }

    ItsGrid.SetStore('grid1', store);
    ItsGrid.Get('grid1').autoSizeColumns();
    ItsMsg.Toast(maria.store.Length() + '건이 조회되었습니다.');
};

// 2026-10-27 [생산팀 소모품] 수정·선택 행 안전재고 저장
ItsButton.EventSave = function () {

    if (ItsGrid.Length('grid1') === 0) {
        ItsMsg.Toast('조회된 데이터가 없습니다.');
        return;
    }

    var arrRows = GetCheckedRows('grid1');
    if (!arrRows) return;
    if (arrRows.length === 0) {
        ItsMsg.Toast('수정되거나 선택된 항목이 없습니다.');
        return;
    }

    ItsMsg.Confirm('선택된 소모품 ' + arrRows.length + '건을 저장하시겠습니까?', function () {
        var maria = new ItsMaria('MST3001_R04', 'SAVE_ITEM');
        maria.AddPanel('sdiv1');
        maria.AddParam('COMPANYCD', ItsFind.GetRef01('sdiv1_find_ITEMID'));   // 법인 = 선택한 공장의 법인코드
        for (var i = 0; i < arrRows.length; i++) {
            var row = arrRows[i];
            maria.AddList('ITEMID_LIST', (row.ITEMID || '').trim());
            maria.AddList('SAFEQTY_LIST', parseFloat(row.SAFEQTY) || 0);
        }

        maria.CallProc();
        if (maria.isError) {
            maria.ShowErrMsg();
            return;
        }

        ItsMsg.Toast(ItsMsg.CommonMsg.SaveComplete());
        ItsButton.EventSearch();
    });
};

// 2026-10-27 [생산팀 소모품] 안전재고가 바뀐 행은 체크 후 체크 행 반환
function GetCheckedRows(gridId) {
    var grid = ItsGrid.Get(gridId);
    if (!grid.finishEditing()) return null;

    var arrRows = [];
    grid.deferUpdate(function () {
        for (var i = 0; i < grid.rows.length; i++) {
            var row = grid.rows[i].dataItem;
            if (!row) continue;

            if ((parseFloat(row.SAFEQTY) || 0) !== (parseFloat(row._ORG_SAFEQTY) || 0)) {
                if (row.isRowCheck !== true && row.isRowCheck !== 'true') {
                    ItsGrid.CheckRow(gridId, i);
                }
            }

            if (row.isRowCheck === true || row.isRowCheck === 'true') {
                arrRows.push(row);
            }
        }
    });

    return arrRows;
}
