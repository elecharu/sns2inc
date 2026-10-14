/// <reference path="../../Script/reference.js" />

ItsPage.Load = function () {
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
        column.create("중요도등급", "GRADE", { width: 90, align: 'center', readOnly: false }),
        column.create("안전재고", "SAFEQTY", { width: 90, align: 'right', format: '#,##0', readOnly: false }),
        column.create("현재고", "LOTQTY", { width: 90, align: 'right', format: '#,##0', readOnly: true }),
        column.create("로케이션코드", "LOCACD", { width: 160, align: 'center', columnType: enumColumnTypes.find, readOnly: false }),
        column.create("로케이션명", "LOCANM", { width: 160, align: 'center' }),
        column.create("관리단위", "ITEMUNIT", { width: 100, align: 'center', columnType: enumColumnTypes.combo, gpcd: 'DM150' }),
        column.create("공급구분", "ITEMSRC", { width: 100, align: 'center', columnType: enumColumnTypes.combo, gpcd: 'DM160' }),
        column.create("종료여부", "ENDYN", { width: 100, align: 'center', columnType: enumColumnTypes.check }),
    ]);

    // 2026-10-13 [설비부품 로케이션] 팝업 로케이션 
    ItsGrid.Create('grid_LOCA', { isCheckBoxGrid: true }, [
        column.create("로케이션코드", "LOCACD", { width: 180, align: 'center', readOnly: false }),
        column.create("로케이션 명", "LOCANM", { width: 360, align: 'left', readOnly: false }),
    ]);

    ItsCombo.SetValueByIndex('cmb_COMPANYCD', 0);

    // 2026-10-13 [설비부품정보] 품목유형 설비자재(DM100700) 고정값 설정 및 품목검색 연동
    ItsCombo.SetValue('sdiv1_combo_ITEMCG', 'DM100700');
    ItsFind.SetRef02('sdiv1_find_ITEMID', 'DM100700');

    // 2026-10-14 [설비부품정보] Delete 키 입력 시 로케이션코드·로케이션명 일괄 초기화
    var grid1 = ItsGrid.Get('grid1');
    if (grid1 && grid1.hostElement) {
        grid1.hostElement.addEventListener('keydown', function (e) {
            if (e.keyCode === 46) {
                var isEditing = grid1.activeEditor || (e.target && e.target.tagName === 'INPUT');
                if (isEditing) return;

                var sel = grid1.selection;
                if (!sel || sel.row < 0 || sel.col < 0) return;
                var col = grid1.columns[sel.col];
                if (!col) return;
                var field = col.binding;
                if (field === 'LOCACD' || field === 'LOCANM') {
                    e.preventDefault();
                    e.stopPropagation();
                    var top = sel.topRow !== undefined ? sel.topRow : Math.min(sel.row, sel.row2);
                    var bottom = sel.bottomRow !== undefined ? sel.bottomRow : Math.max(sel.row, sel.row2);
                    grid1.deferUpdate(function () {
                        for (var r = top; r <= bottom; r++) {
                            SetLoca(r, '', '');
                        }
                    });
                }
            }
        }, true);
    }
};

// 2026-10-14 [설비부품정보] 로케이션 직접 입력 또는 삭제 시 코드·명 동기화
ItsGrid.Event('grid1').onChanged = function (rowIndex, field, newValue, oldValue) {
    if (rowIndex < 0 || newValue === oldValue) return;
    var val = (newValue || '').toString().trim();
    if (field === 'LOCACD') {
        if (val === '') {
            SetLoca(rowIndex, '', '');
        } else {
            ItsGrid.SetValue('grid1', rowIndex, 'LOCANM', '');
            ItsGrid.CheckRow('grid1', rowIndex);
        }
    } else if (field === 'LOCANM') {
        if (val === '') {
            SetLoca(rowIndex, '', '');
        } else {
            ItsGrid.SetValue('grid1', rowIndex, 'LOCACD', '');
            ItsGrid.CheckRow('grid1', rowIndex);
        }
    }
};

// 2026-10-14 [설비부품정보] Delete 키로 로케이션 코드·명 초기화
ItsGrid.Event('grid1').onKeydown = function (rowIndex, field, keyCode) {
    if (keyCode === 46 && (field === 'LOCANM' || field === 'LOCACD')) {
        SetLoca(rowIndex, '', '');
    }
};

// 2026-10-13 [설비부품정보] 더블클릭·Enter 검색 통합 
ItsGrid.Event('grid1').onDoubleClick = OpenLoca;
ItsGrid.Event('grid1').onKeydownEnter = OpenLoca;

// 2026-10-14 [설비부품정보] 로케이션코드(LOCACD)에서만 로케이션 검색 팝업 연동
function OpenLoca(rowIndex, field) {
    if (field !== 'LOCACD') return;

    var grid = ItsGrid.Get('grid1');
    if (!grid.rows[rowIndex]) return;

    var item = grid.rows[rowIndex].dataItem;
    if (!item || !grid.finishEditing()) return;

    ItsPop.OpenFindCOM({ gpcd: 'LOCACD_EQMPARTS', keyword: '' }, function (res) {
        if (!res) return;
        for (var i = 0; i < grid.rows.length; i++) {
            if (grid.rows[i].dataItem === item) {
                SetLoca(i, res.CODE, res.NAME);
                return;
            }
        }
    });
}

// 2026-10-14 [설비부품정보] 로케이션과 체크 상태를 한 번에 갱신
function SetLoca(rowIndex, locaCd, locaNm) {
    var grid = ItsGrid.Get('grid1');
    if (!grid.rows[rowIndex] || !grid.rows[rowIndex].dataItem) return;
    grid.deferUpdate(function () {
        ItsGrid.SetValue('grid1', rowIndex, 'LOCACD', locaCd);
        ItsGrid.SetValue('grid1', rowIndex, 'LOCANM', locaNm);
        ItsGrid.CheckRow('grid1', rowIndex);
    });
}

// 2026-10-13 [설비부품정보] 품목 및 부품 재고현황 조회
ItsButton.EventSearch = function () {

    var maria = new ItsMaria('MST3001_R03', 'SEL_ITEM');
    maria.AddPanel('sdiv1');
    maria.CallProc();
    if (maria.isError) {
        maria.ShowErrMsg();
        return;
    }

    var store = maria.store.YnToBool('ENDYN');
    for (var i = 0; i < store.data.length; i++) {
        var row = store.data[i];
        row._ORG_GRADE = row.GRADE;
        row._ORG_SAFEQTY = row.SAFEQTY;
        row._ORG_LOTQTY = row.LOTQTY;
        row._ORG_LOCACD = row.LOCACD;
        row._ORG_LOCANM = row.LOCANM;
    }

    ItsGrid.SetStore('grid1', store);
    ItsGrid.Get('grid1').autoSizeColumns();
    ItsMsg.Toast(maria.store.Length() + '건이 조회되었습니다.');
};

// 2026-10-13 [설비부품정보] 수정·선택 행 저장 
ItsButton.EventSave = function () {

    if (ItsGrid.Length('grid1') === 0) {
        ItsMsg.Toast('조회된 데이터가 없습니다.');
        return;
    }

    var arrRows = GetCheckedRows('grid1', true);
    if (!arrRows) return;
    if (arrRows.length === 0) {
        ItsMsg.Toast('수정되거나 선택된 항목이 없습니다.');
        return;
    }

    ItsMsg.Confirm('선택된 설비부품 ' + arrRows.length + '건을 저장하시겠습니까?', function () {
        var maria = new ItsMaria('MST3001_R03', 'SAVE_ITEM');
        maria.AddPanel('sdiv1');
        for (var i = 0; i < arrRows.length; i++) {
            var row = arrRows[i];
            maria.AddList('ITEMID_LIST', (row.ITEMID || '').trim());
            maria.AddList('GRADE_LIST', (row.GRADE || '').trim());
            maria.AddList('SAFEQTY_LIST', parseFloat(row.SAFEQTY) || 0);
            maria.AddList('LOTQTY_LIST', parseFloat(row.LOTQTY) || 0);
            maria.AddList('LOCACD_LIST', (row.LOCACD || '').trim());
            maria.AddList('LOCANM_LIST', (row.LOCANM || '').trim());
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

// 2026-10-13 [설비부품정보] 품목유형 변경 시 품목검색 조건 연동
ItsCombo.Event('sdiv1_combo_ITEMCG').onChanged = function (value) {
    ItsFind.SetRef02('sdiv1_find_ITEMID', value);
};

// 2026-10-13 [로케이션 관리] 로케이션 기준정보 관리 팝업 열기
ItsButton.Event('btn_LOCA_MNG').onClick = function () {
    ItsPop.Open('pop_LOCA');
    SearchLoca();
};

// 2026-10-13 [로케이션 관리] 팝업 조회
ItsButton.Event('btn_POP_SEARCH').onClick = SearchLoca;

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

// 2026-10-13 [로케이션 관리] 선택 행 저장
ItsButton.Event('btn_POP_SAVE').onClick = function () {
    var arrRows = GetCheckedRows('grid_LOCA');
    if (!arrRows) return;
    if (arrRows.length === 0) {
        ItsMsg.Toast('저장할 로케이션을 선택해주세요.');
        return;
    }

    ItsMsg.Confirm('선택한 로케이션을 저장하시겠습니까?', function () {
        var maria = new ItsMaria('MST3001_R03', 'SAVE_LOCA');

        for (var i = 0; i < arrRows.length; i++) {
            var row = arrRows[i];
            maria.AddList('LOCACD_LIST', (row.LOCACD || '').trim());
            maria.AddList('LOCANM_LIST', (row.LOCANM || '').trim());
            maria.AddList('OLD_LOCACD_LIST', (row._ORG_LOCACD || '').trim());
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

// 2026-10-13 [로케이션 관리] 선택 행 삭제
ItsButton.Event('btn_POP_DEL').onClick = function () {
    var arrRows = GetCheckedRows('grid_LOCA');
    if (!arrRows) return;
    if (arrRows.length === 0) {
        ItsMsg.Toast('삭제할 로케이션을 선택해주세요.');
        return;
    }

    ItsMsg.Confirm('선택한 로케이션을 삭제하시겠습니까?', function () {
        var maria = new ItsMaria('MST3001_R03', 'DEL_LOCA');
        var delCnt = 0;

        for (var i = 0; i < arrRows.length; i++) {
            var locaCd = (arrRows[i]._ORG_LOCACD || '').trim();
            if (locaCd !== '') {
                maria.AddList('LOCACD_LIST', locaCd);
                delCnt++;
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

// 2026-10-13 [공통 유틸] 체크 행 확인
function GetCheckedRows(gridId, isCheckChange) {
    var grid = ItsGrid.Get(gridId);
    if (!grid.finishEditing()) return null;

    var arrRows = [];
    grid.deferUpdate(function () {
        for (var i = 0; i < grid.rows.length; i++) {
            var row = grid.rows[i].dataItem;
            if (!row) continue;

            if (isCheckChange && (
                (row.GRADE || '').trim() !== (row._ORG_GRADE || '').trim()
                || (parseFloat(row.SAFEQTY) || 0) !== (parseFloat(row._ORG_SAFEQTY) || 0)
                || (row.LOCACD || '').trim() !== (row._ORG_LOCACD || '').trim()
                || (row.LOCANM || '').trim() !== (row._ORG_LOCANM || '').trim())) {
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
