/// <reference path="../../Script/reference.js" />

// 2026-10-13 [설비부품정보] 페이지 초기 로드 및 그리드 정의
ItsPage.Load = function () {

    // 2026-10-13 [설비부품 메인] 체크박스 그리드 생성 및 재고·로케이션 수정 가능 설정
    ItsGrid.Create('grid1', { isCheckBoxGrid: true }, [
        column.create("법인", "COMPANYCD", { width: 100, align: 'center', columnType: enumColumnTypes.combo, gpcd: 'COMPANYCD' }),
        column.create("품목유형", "ITEMCG", { width: 100, align: 'center', columnType: enumColumnTypes.combo, gpcd: 'DM100', readOnly: true }),
        column.create("대분류", "ITEM_LVL1", { width: 100, align: 'center' }),
        column.create("중분류", "ITEM_LVL2", { width: 100, align: 'center' }),
        column.create("소분류", "ITEM_LVL3", { width: 100, align: 'center' }),
        column.create("세분류", "ITEM_LVL4", { width: 100, align: 'center', columnType: enumColumnTypes.combo, gpcd: 'PP310' }),
        column.create("품목ID", "ITEMID", { width: 100, align: 'center' }),
        column.create("품목코드", "ITEMCD", { width: 100, align: 'center', backColor: enumColor.greenLight2 }),
        column.create("품명", "ITEMNM", { width: 120 }),
        column.create("규격", "ITEMSPEC", { width: 120 }),
        column.create("중요도등급", "GRADE", { width: 90, align: 'center' }),
        column.create("안전재고", "SAFEQTY", { width: 90, align: 'right', format: '#,##0', readOnly: false }),
        column.create("현재고", "LOTQTY", { width: 90, align: 'right', format: '#,##0', readOnly: false }),
        column.create("로케이션", "LOCANM", { width: 110, align: 'center', readOnly: false }),
        column.create("관리단위", "ITEMUNIT", { width: 100, align: 'center', columnType: enumColumnTypes.combo, gpcd: 'DM150' }),
        column.create("공급구분", "ITEMSRC", { width: 100, align: 'center', columnType: enumColumnTypes.combo, gpcd: 'DM160' }),
        column.create("종료여부", "ENDYN", { width: 100, align: 'center', columnType: enumColumnTypes.check }),
    ]);

    // 2026-10-13 [설비부품 로케이션] 팝업 로케이션 그리드 생성 (로케이션코드·명 모두 직접 수정 가능)
    ItsGrid.Create('grid_LOCA', { isCheckBoxGrid: true }, [
        column.create("로케이션코드", "LOCACD", { width: 180, align: 'center', readOnly: false }),
        column.create("로케이션 명", "LOCANM", { width: 450, align: 'left', readOnly: false }),
    ]);

    ItsCombo.SetValueByIndex('cmb_COMPANYCD', 0);
    // 2026-10-13 [설비부품정보] 품목유형 설비자재(DM100700) 고정값 설정 및 품목검색 연동
    ItsCombo.SetValue('sdiv1_combo_ITEMCG', 'DM100700');
    ItsFind.SetRef02('sdiv1_find_ITEMID', 'DM100700');
};

// 2026-10-13 [설비부품정보] 셀 수정 시 해당 행 체크박스 자동 선택
ItsGrid.Event('grid1').onChanged = function (rowIndex, field, newValue, oldValue) {
    if (field === 'SAFEQTY' || field === 'LOTQTY' || field === 'LOCANM') {
        ItsGrid.CheckRow('grid1', rowIndex);
    }
};

// 2026-10-13 [설비부품정보] 품목 및 부품 재고현황 조회
ItsButton.EventSearch = function () {

    var maria = new ItsMaria('MST3001_R03', 'SEL_ITEM');
    maria.AddPanel('sdiv1');
    maria.CallProc();
    if (maria.isError) {
        maria.ShowErrMsg();
        return;
    }

    var store = maria.store.YnToBool('IOYN').YnToBool('SEPAYN').YnToBool('ENDYN');
    for (var i = 0; i < store.data.length; i++) {
        var row = store.data[i];
        row._ORG_SAFEQTY = row.SAFEQTY;
        row._ORG_LOTQTY  = row.LOTQTY;
        row._ORG_LOCANM  = row.LOCANM;
    }

    ItsGrid.SetStore('grid1', store);
    ItsMsg.Toast(maria.store.Length() + '건이 조회되었습니다.');

    ItsGrid.Get('grid1').autoSizeColumns();
};

// 2026-10-13 [설비부품정보] 상단 헤더 저장 (수정 항목 자동 체크 후 저장)
ItsButton.EventSave = function () {

    var totalRows = ItsGrid.Length('grid1');
    if (totalRows === 0) {
        ItsMsg.Toast('조회된 데이터가 없습니다.');
        return;
    }

    // 안전재고, 현재고, 로케이션 수정한 항목에 대해 왼쪽 체크박스 자동 선택
    for (var i = 0; i < totalRows; i++) {
        var curSafeQty = parseFloat(ItsGrid.GetValue('grid1', i, 'SAFEQTY')) || 0;
        var curLotQty  = parseFloat(ItsGrid.GetValue('grid1', i, 'LOTQTY'))  || 0;
        var curLocaNm  = (ItsGrid.GetValue('grid1', i, 'LOCANM') || '').trim();

        var orgSafeQty = parseFloat(ItsGrid.GetValue('grid1', i, '_ORG_SAFEQTY')) || 0;
        var orgLotQty  = parseFloat(ItsGrid.GetValue('grid1', i, '_ORG_LOTQTY'))  || 0;
        var orgLocaNm  = (ItsGrid.GetValue('grid1', i, '_ORG_LOCANM') || '').trim();

        if (curSafeQty !== orgSafeQty || curLotQty !== orgLotQty || curLocaNm !== orgLocaNm) {
            ItsGrid.CheckRow('grid1', i);
        }
    }

    if (!HasCheckedRows('grid1')) {
        ItsMsg.Toast('수정되거나 선택된 항목이 없습니다.');
        return;
    }

    var saveCnt = 0;
    for (var i = 0; i < totalRows; i++) {
        if (ItsGrid.IsChecked('grid1', i)) {
            saveCnt++;
        }
    }

    ItsMsg.Confirm('선택된 설비부품 ' + saveCnt + '건을 저장하시겠습니까?', function () {
        var maria = new ItsMaria('MST3001_R03', 'SAVE_ITEM');
        maria.AddPanel('sdiv1');

        for (var i = 0; i < totalRows; i++) {
            if (ItsGrid.IsChecked('grid1', i)) {
                var itemId  = (ItsGrid.GetValue('grid1', i, 'ITEMID')  || '').trim();
                var safeQty = parseFloat(ItsGrid.GetValue('grid1', i, 'SAFEQTY')) || 0;
                var lotQty  = parseFloat(ItsGrid.GetValue('grid1', i, 'LOTQTY'))  || 0;
                var locaNm  = (ItsGrid.GetValue('grid1', i, 'LOCANM')  || '').trim();

                maria.AddList('ITEMID_LIST', itemId);
                maria.AddList('SAFEQTY_LIST', safeQty);
                maria.AddList('LOTQTY_LIST', lotQty);
                maria.AddList('LOCANM_LIST', locaNm);
            }
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

ItsCombo.Event('sdiv1_combo_ITEMCG').onChanged = function (value) {
    ItsFind.SetRef02('sdiv1_find_ITEMID', value);
};

// 2026-10-13 [로케이션 관리] 로케이션 기준정보 관리 팝업 열기
ItsButton.Event('btn_LOCA_MNG').onClick = function () {
    ItsPop.Open('pop_LOCA');
    SearchLoca();
};

// 2026-10-13 [로케이션 관리] 팝업 조회
ItsButton.Event('btn_POP_SEARCH').onClick = function () {
    SearchLoca();
};

// 2026-10-13 [로케이션 관리] 로케이션 기준정보 조회 처리
function SearchLoca() {
    var maria = new ItsMaria('MST3001_R03', 'SEL_LOCA');
    maria.CallProc();
    if (maria.isError) {
        maria.ShowErrMsg();
        return;
    }

    for (var i = 0; i < maria.store.data.length; i++) {
        maria.store.data[i]._ORG_LOCACD = maria.store.data[i].LOCACD;
    }

    ItsGrid.SetStore('grid_LOCA', maria.store);
    ItsMsg.Toast(maria.store.Length() + '건의 로케이션이 조회되었습니다.');
}

// 2026-10-13 [로케이션 관리] 팝업 행추가
ItsButton.Event('btn_POP_ADD').onClick = function () {
    ItsGrid.AddRow('grid_LOCA', undefined, { isRowCheck: true, LOCACD: '', LOCANM: '', _ORG_LOCACD: '' });
};

// 2026-10-13 [로케이션 관리] 팝업 저장 (선택된 행 프로시저 전송 및 프로시저 검증)
ItsButton.Event('btn_POP_SAVE').onClick = function () {
    if (!HasCheckedRows('grid_LOCA')) {
        ItsMsg.Toast('저장할 로케이션을 선택해주세요.');
        return;
    }

    ItsMsg.Confirm('선택한 로케이션을 저장하시겠습니까?', function () {
        var maria = new ItsMaria('MST3001_R03', 'SAVE_LOCA');

        for (var i = 0; i < ItsGrid.Length('grid_LOCA'); i++) {
            if (ItsGrid.IsChecked('grid_LOCA', i)) {
                var locaCd    = (ItsGrid.GetValue('grid_LOCA', i, 'LOCACD') || '').trim();
                var locaNm    = (ItsGrid.GetValue('grid_LOCA', i, 'LOCANM') || '').trim();
                var oldLocaCd = (ItsGrid.GetValue('grid_LOCA', i, '_ORG_LOCACD') || '').trim();

                maria.AddList('LOCACD_LIST', locaCd);
                maria.AddList('LOCANM_LIST', locaNm);
                maria.AddList('OLD_LOCACD_LIST', oldLocaCd);
            }
        }

        maria.CallProc();
        if (maria.isError) {
            maria.ShowErrMsg();
            return;
        }

        ItsMsg.Toast(ItsMsg.CommonMsg.SaveComplete());
        SearchLoca();
    });
};

// 2026-10-13 [로케이션 관리] 팝업 삭제 (체크된 행 삭제)
ItsButton.Event('btn_POP_DEL').onClick = function () {
    if (!HasCheckedRows('grid_LOCA')) {
        ItsMsg.Toast('삭제할 로케이션을 선택해주세요.');
        return;
    }

    ItsMsg.Confirm('선택한 로케이션을 삭제하시겠습니까?', function () {
        var maria = new ItsMaria('MST3001_R03', 'DEL_LOCA');
        var delCnt = 0;

        for (var i = 0; i < ItsGrid.Length('grid_LOCA'); i++) {
            if (ItsGrid.IsChecked('grid_LOCA', i)) {
                var locaCd = (ItsGrid.GetValue('grid_LOCA', i, 'LOCACD') || '').trim();
                if (locaCd !== '') {
                    maria.AddList('LOCACD_LIST', locaCd);
                    delCnt++;
                }
            }
        }

        if (delCnt === 0) {
            SearchLoca();
            return;
        }

        maria.CallProc();
        if (maria.isError) {
            maria.ShowErrMsg();
            return;
        }

        ItsMsg.Toast(ItsMsg.CommonMsg.DeleteComplete());
        SearchLoca();
    });
};

// 2026-10-13 [공통 유틸] 체크된 행 존재 여부 확인
function HasCheckedRows(gridId) {
    for (var i = 0; i < ItsGrid.Length(gridId); i++) {
        if (ItsGrid.IsChecked(gridId, i)) {
            return true;
        }
    }
    return false;
}
