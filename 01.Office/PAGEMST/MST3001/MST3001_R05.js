/// <reference path="../../Script/reference.js" />

ItsPage.Load = function () {
    ItsGrid.Create('grid1', { isCheckBoxGrid: true }, [
        column.create("품목ID", "ITEMID", { width: 80, align: 'center' }),
        column.create("품목코드", "ITEMCD", { width: 100, align: 'center', backColor: enumColor.greenLight2 }),
        column.create("품명", "ITEMNM", { width: 120 }),
        column.create("규격", "ITEMSPEC", { width: 120 }),
        column.create("안전재고", "SAFEQTY", { width: 70, align: 'right', format: '#,##0', readOnly: false }),
        column.create("현재고", "LOTQTY", { width: 70, align: 'right', format: '#,##0' }),
        column.create("위치수", "LOCCNT", { width: 60, align: 'right', format: '#,##0' }),
        column.create("대분류", "ITEM_LVL1", { width: 100, align: 'center' }),
        column.create("중분류", "ITEM_LVL2", { width: 100, align: 'center' }),
        column.create("소분류", "ITEM_LVL3", { width: 100, align: 'center' }),
        column.create("세분류", "ITEM_LVL4", { width: 100, align: 'center', columnType: enumColumnTypes.combo, gpcd: 'PP310' }),
        column.create("관리단위", "ITEMUNIT", { width: 100, align: 'center', columnType: enumColumnTypes.combo, gpcd: 'DM150' }),
        column.create("공급구분", "ITEMSRC", { width: 100, align: 'center', columnType: enumColumnTypes.combo, gpcd: 'DM160' }),
        column.create("종료여부", "ENDYN", { width: 70, align: 'center', columnType: enumColumnTypes.check }),
    ]);

    // 체크한 품목은 행 색을 바꿔 어떤 품목을 골랐는지 보이게 함 (라이브러리 기본 체크 색 #fbf7ff 은 거의 흰색)
    ItsGrid.Get('grid1').formatItem.addHandler(function (s, e) {
        if (e.panel == s.cells && s.cells.getCellData(e.row, 'isRowCheck', true) == 'true') {
            e.cell.style.backgroundColor = '#cfe8ff';
        }
    });

    ItsGrid.Create('grid2', { isCheckBoxGrid: true }, [
        column.create("작업장", "LINECD", { width: 100, align: 'center', columnType: enumColumnTypes.combo, gpcd: 'LINECD', ref01: '07', readOnly: false }),
        column.create("공정", "PRCCD", { width: 100, align: 'center', columnType: enumColumnTypes.combo, gpcd: 'OSCCONSUM_PRCCD', ref01: '07', readOnly: false }),
        column.create("라인", "EQMCD", { width: 140, align: 'center', columnType: enumColumnTypes.combo, gpcd: 'OSCCONSUM_EQMCD', ref01: '07', readOnly: false }),
        column.create("제품", "ITEMID_PRD", { width: 200, columnType: enumColumnTypes.combo, gpcd: 'OSCCONSUM_ITEMID_PRD', ref01: '07', readOnly: false }),
        column.create("세부공정", "PRCDETAIL", { width: 80, align: 'center', columnType: enumColumnTypes.combo, gpcd: 'OSCCONSUM_PRCDETAIL', ref01: '07', readOnly: false }),
        column.create("터렛", "TURRET", { width: 70, align: 'center', columnType: enumColumnTypes.combo, gpcd: 'TURRET', readOnly: false }),
    ]);

    // 일괄 추가 팝업: 라인마다 제품·세부공정을 고르고, 체크한 라인 x 체크한 터렛 만큼 사용위치를 만든다
    ItsGrid.Create('grid_POP_EQM', { isCheckBoxGrid: true }, [
        column.create("라인", "EQMNM", { width: 160 }),
        column.create("제품", "ITEMID_PRD", { width: 260, columnType: enumColumnTypes.combo, gpcd: 'OSCCONSUM_ITEMID_PRD', ref01: '07', readOnly: false }),
        column.create("세부공정", "PRCDETAIL", { width: 100, align: 'center', columnType: enumColumnTypes.combo, gpcd: 'OSCCONSUM_PRCDETAIL', ref01: '07', readOnly: false }),
    ]);
    ItsGrid.Create('grid_POP_TURRET', { isCheckBoxGrid: true }, [
        column.create("터렛", "TURRETNM", { width: 120, align: 'center' }),
    ]);

    // 팝업 안 그리드 콤보 목록이 화면 왼쪽 위에 뜨는 문제 보정
    //  팝업 안에서는 wijmo 가 팝업 기준 좌표를 transform 으로 주는데, ItsGrid.css 의 .wj-listbox { position:fixed; transform:initial !important }
    //  때문에 지워진다. 목록을 띄운 뒤 셀 바로 아래(공간이 없으면 위)로 다시 놓는다.
    var orgShowPopup = wijmo.showPopup;
    wijmo.showPopup = function (popup, ref) {
        var ret = orgShowPopup.apply(this, arguments);
        if (ref instanceof HTMLElement && popup.parentElement != document.body && $(ref).closest('.ui-dialog').length > 0) {
            var rc = ref.getBoundingClientRect();
            var top = rc.bottom;
            if (top + popup.offsetHeight > window.innerHeight && rc.top > popup.offsetHeight) top = rc.top - popup.offsetHeight;
            popup.style.left = Math.max(0, Math.min(rc.left, window.innerWidth - popup.offsetWidth)) + 'px';
            popup.style.top = top + 'px';
        }
        return ret;
    };

    // 2026-10-28 [외주처 소모품] 법인 60 / 공장 INC 2공장(07) 디폴트, 품목유형 소모공구류(DM100990) 고정 및 품목검색 연동
    ItsCombo.SetValue('cmb_COMPANYCD', '60');
    ItsFind.SetRef02('sdiv1_find_ITEMID', 'DM100990');
};

// 2026-10-28 [외주처 소모품] 법인 변경 시 공장 목록을 해당 법인 공장으로 갱신
ItsCombo.Event('cmb_COMPANYCD').onChanged = function (value) {
    ItsCombo.SetRef01('cmb_FACTORYCD', value);
    ItsCombo.SetValueByIndex('cmb_FACTORYCD', 2);
};

// 2026-10-28 [외주처 소모품] INC 2공장 소모품 조회 (첫 행 선택 시 오른쪽에 사용위치 조회)
ItsButton.EventSearch = function () {

    var maria = new ItsMaria('MST3001_R05', 'SEL_ITEM');
    maria.AddPanel('sdiv1');
    maria.CallProc();
    if (maria.isError) {
        maria.ShowErrMsg();
        return;
    }

    // 저장 때 안전재고가 바뀐 품목만 골라내려고 조회 당시 값을 보관
    var store = maria.store.YnToBool('ENDYN');
    for (var i = 0; i < store.data.length; i++) {
        store.data[i]._ORG_SAFEQTY = store.data[i].SAFEQTY;
    }

    ItsGrid.SetStore('grid1', store);
    ItsGrid.Get('grid1').autoSizeColumns();
    if (maria.store.Length() === 0) {
        ItsGrid.Clear('grid2');
    }
    ItsMsg.Toast(maria.store.Length() + '건이 조회되었습니다.');
};

// 2026-10-28 [외주처 소모품] 품목 선택 시 그 품목의 사용위치 조회
ItsGrid.Event('grid1').onSelect = function (rowIndex) {
    var item = ItsGrid.GetRowData('grid1', rowIndex);

    var maria = new ItsMaria('MST3001_R05', 'SEL_CLASSIFY');
    maria.AddParam('ITEMID', item.ITEMID);
    maria.CallProc();
    if (maria.isError) {
        maria.ShowErrMsg();
        return;
    }

    // 저장·삭제 때 원래 행을 찾을 수 있게 조회 당시 사용위치를 보관 (PK 컬럼이라 수정되면 원래 값이 필요)
    var store = maria.store;
    for (var i = 0; i < store.data.length; i++) {
        var row = store.data[i];
        row._ORG_LINECD = row.LINECD;
        row._ORG_PRCCD = row.PRCCD;
        row._ORG_EQMCD = row.EQMCD;
        row._ORG_ITEMID_PRD = row.ITEMID_PRD;
        row._ORG_PRCDETAIL = row.PRCDETAIL;
        row._ORG_TURRET = row.TURRET;
    }
    ItsGrid.SetStore('grid2', store);

    // 저장·삭제 후 다시 조회했을 때 왼쪽 위치수도 맞춘다
    ItsGrid.SetValue('grid1', rowIndex, 'LOCCNT', store.Length());
};

// 2026-10-30 [외주처 소모품] 사용위치 추가 팝업 열기 (터렛 목록·첫 작업장 라인 조회)
ItsButton.EventAdd = function () {

    if (GetBulkItems().length === 0) {
        ItsMsg.Toast('사용위치를 추가할 품목을 체크하거나 선택해주세요.');
        return;
    }

    ItsPop.Open('pop_BULK');

    var maria = new ItsMaria('MST3001_R05', 'SEL_POP_TURRET');
    maria.CallProc();
    if (maria.isError) {
        maria.ShowErrMsg();
        return;
    }
    ItsGrid.SetStore('grid_POP_TURRET', maria.store);

    ItsCombo.SetRef01('pop_combo_PRCCD', ItsCombo.GetValue('pop_combo_LINECD'));
    ItsCombo.SetValueByIndex('pop_combo_PRCCD', 0);
    SearchPopEqm();
};

// 2026-10-30 [외주처 소모품] 왼쪽 안전재고가 바뀐 품목과, 오른쪽 체크한 사용위치(선택한 품목)를 저장
ItsButton.EventSave = function () {

    if (!ItsGrid.Get('grid1').finishEditing()) return;
    if (!ItsGrid.Get('grid2').finishEditing()) return;

    var arrSafe = [];
    for (var i = 0; i < ItsGrid.Length('grid1'); i++) {
        var item = ItsGrid.GetRowData('grid1', i);
        if ((parseFloat(item.SAFEQTY) || 0) !== (parseFloat(item._ORG_SAFEQTY) || 0)) {
            arrSafe.push({ rowIndex: i, data: item });
        }
    }

    // 같은 사용위치가 두 행 이상이면 저장하지 않고 다시 설정하게 함
    //  (오른쪽에는 선택한 품목의 위치가 모두 보이므로 이미 등록된 위치와의 중복도 여기서 걸린다)
    var keyRow = {};
    for (var i = 0; i < ItsGrid.Length('grid2'); i++) {
        var loc = ItsGrid.GetRowData('grid2', i);
        var key = [loc.LINECD, loc.PRCCD, loc.EQMCD, loc.ITEMID_PRD, loc.PRCDETAIL, loc.TURRET]
            .map(function (v) { return v === undefined || v === null ? '' : String(v); }).join('|');
        if (keyRow[key] !== undefined) {
            ItsGrid.SelectRow('grid2', i);
            ItsMsg.Alert((i + 1) + '번째 행이 ' + (keyRow[key] + 1) + '번째 행과 같은 사용위치입니다. 다시 설정하십시오.');
            return;
        }
        keyRow[key] = i;
    }

    var arrRows = [];
    for (var i = 0; i < ItsGrid.Length('grid2'); i++) {
        if (ItsGrid.IsChecked('grid2', i)) {
            var row = ItsGrid.GetRowData('grid2', i);
            if (!row.LINECD && !row.PRCCD && !row.EQMCD && !row.ITEMID_PRD && !row.PRCDETAIL && !row.TURRET) {
                ItsMsg.Toast((i + 1) + '번째 행의 사용위치를 입력하십시오.');
                return;
            }
            // 제품·세부공정·터렛은 빈 값으로 저장하지 않음
            var emptyName = !row.ITEMID_PRD ? '제품' : !row.PRCDETAIL ? '세부공정' : !row.TURRET ? '터렛' : '';
            if (emptyName !== '') {
                ItsGrid.SelectRow('grid2', i);
                ItsMsg.Alert((i + 1) + '번째 행의 ' + emptyName + '을(를) 선택하십시오.');
                return;
            }
            arrRows.push(row);
        }
    }
    if (arrSafe.length === 0 && arrRows.length === 0) {
        ItsMsg.Toast('수정되거나 선택된 항목이 없습니다.');
        return;
    }

    var selItem = ItsGrid.GetRowData('grid1', ItsGrid.GetCurrentIndex('grid1'));
    var arrMsg = [];
    if (arrSafe.length > 0) arrMsg.push('안전재고 ' + arrSafe.length + '건');
    if (arrRows.length > 0) arrMsg.push('[' + selItem.ITEMCD + '] 의 사용위치 ' + arrRows.length + '건');
    ItsMsg.Confirm(arrMsg.join(', ') + '을 저장하시겠습니까?', function () {

        if (arrSafe.length > 0) {
            var mariaSafe = new ItsMaria('MST3001_R05', 'SAVE_SAFEQTY');
            for (var i = 0; i < arrSafe.length; i++) {
                mariaSafe.AddList('ITEMID_LIST', arrSafe[i].data.ITEMID);
                mariaSafe.AddList('SAFEQTY_LIST', parseFloat(arrSafe[i].data.SAFEQTY) || 0);
            }
            mariaSafe.CallProc();
            if (mariaSafe.isError) {
                mariaSafe.ShowErrMsg();
                return;
            }

            // 저장한 값을 원래 값으로 삼고, 안전재고 미만 표시(분홍)를 다시 맞춘다
            ItsGrid.Get('grid1').deferUpdate(function () {
                for (var i = 0; i < arrSafe.length; i++) {
                    var item = arrSafe[i].data;
                    item._ORG_SAFEQTY = item.SAFEQTY;
                    ItsGrid.SetValue('grid1', arrSafe[i].rowIndex, 'BACKGROUND',
                        (parseFloat(item.LOTQTY) || 0) < (parseFloat(item.SAFEQTY) || 0) ? 'PINK' : '');
                }
            });
        }

        if (arrRows.length === 0) {
            ItsMsg.Toast('안전재고 ' + arrSafe.length + '건 저장');
            return;
        }

        var maria = new ItsMaria('MST3001_R05', 'SAVE_ITEM');
        for (var i = 0; i < arrRows.length; i++) {
            var row = arrRows[i];
            maria.AddList('ITEMID_LIST', selItem.ITEMID);
            maria.AddList('LINECD_LIST', row.LINECD || '');
            maria.AddList('PRCCD_LIST', row.PRCCD || '');
            maria.AddList('EQMCD_LIST', row.EQMCD || '');
            maria.AddList('ITEMID_PRD_LIST', row.ITEMID_PRD || '');
            maria.AddList('PRCDETAIL_LIST', row.PRCDETAIL || '');
            maria.AddList('TURRET_LIST', row.TURRET || '');
            maria.AddList('OLD_LINECD_LIST', row._ORG_LINECD || '');
            maria.AddList('OLD_PRCCD_LIST', row._ORG_PRCCD || '');
            maria.AddList('OLD_EQMCD_LIST', row._ORG_EQMCD || '');
            maria.AddList('OLD_ITEMID_PRD_LIST', row._ORG_ITEMID_PRD || '');
            maria.AddList('OLD_PRCDETAIL_LIST', row._ORG_PRCDETAIL || '');
            maria.AddList('OLD_TURRET_LIST', row._ORG_TURRET || '');
        }

        maria.CallProc();
        if (maria.isError) {
            maria.ShowErrMsg();
            return;
        }

        ItsMsg.Toast((arrSafe.length > 0 ? '안전재고 ' + arrSafe.length + '건, ' : '') + '사용위치 ' + maria.store.data[0].SAVECNT + '건 저장');
        ItsGrid.Event('grid1').onSelect(ItsGrid.GetCurrentIndex('grid1'));
    });
};

// 2026-10-30 [외주처 소모품] 체크한 사용위치를 선택한 품목에서 삭제 (아직 저장 안 한 행은 화면에서만 지움)
ItsButton.EventDelete = function () {

    var arrRows = [];
    for (var i = 0; i < ItsGrid.Length('grid2'); i++) {
        if (ItsGrid.IsChecked('grid2', i)) {
            arrRows.push(ItsGrid.GetRowData('grid2', i));
        }
    }
    if (arrRows.length === 0) {
        ItsMsg.Toast('삭제할 행을 선택해주세요.');
        return;
    }

    var selItem = ItsGrid.GetRowData('grid1', ItsGrid.GetCurrentIndex('grid1'));
    ItsMsg.Confirm('[' + selItem.ITEMCD + '] 에서 선택한 위치 ' + arrRows.length + '곳을 삭제하시겠습니까?', function () {
        var maria = new ItsMaria('MST3001_R05', 'DEL_ITEM');
        var delCnt = 0;
        for (var i = 0; i < arrRows.length; i++) {
            var row = arrRows[i];
            if (row._ORG_LINECD === '' && row._ORG_PRCCD === '' && row._ORG_EQMCD === ''
                && row._ORG_ITEMID_PRD === '' && row._ORG_PRCDETAIL === '' && row._ORG_TURRET === '') continue;

            maria.AddList('ITEMID_LIST', selItem.ITEMID);
            maria.AddList('OLD_LINECD_LIST', row._ORG_LINECD);
            maria.AddList('OLD_PRCCD_LIST', row._ORG_PRCCD);
            maria.AddList('OLD_EQMCD_LIST', row._ORG_EQMCD);
            maria.AddList('OLD_ITEMID_PRD_LIST', row._ORG_ITEMID_PRD);
            maria.AddList('OLD_PRCDETAIL_LIST', row._ORG_PRCDETAIL);
            maria.AddList('OLD_TURRET_LIST', row._ORG_TURRET);
            delCnt++;
        }

        if (delCnt > 0) {
            maria.CallProc();
            if (maria.isError) {
                maria.ShowErrMsg();
                return;
            }
        }

        ItsMsg.Toast(ItsMsg.CommonMsg.DeleteComplete(delCnt));
        ItsGrid.Event('grid1').onSelect(ItsGrid.GetCurrentIndex('grid1'));
    });
};

// 2026-10-28 [외주처 소모품] 앞 분류값을 바꾸면 뒤 분류값은 비움
ItsGrid.Event('grid2').onChanged = function (rowIndex, field) {
    var clearFields = {
        LINECD: ['PRCCD', 'EQMCD', 'ITEMID_PRD', 'PRCDETAIL'],
        PRCCD: ['EQMCD', 'ITEMID_PRD', 'PRCDETAIL'],
        EQMCD: ['ITEMID_PRD', 'PRCDETAIL']
    }[field];
    if (!clearFields) return;

    ItsGrid.Get('grid2').deferUpdate(function () {
        for (var i = 0; i < clearFields.length; i++) {
            ItsGrid.SetValue('grid2', rowIndex, clearFields[i], '');
        }
    });
};

// 2026-10-28 [외주처 소모품] 공정·라인·제품·세부공정 콤보는 그 행의 앞 분류값으로 목록을 거름
ItsGrid.Event('grid2').onBeginningEdit = function (rowIndex, field) {
    FilterComboByRow('grid2', field, {
        PRCCD: ['LINECD'],
        EQMCD: ['LINECD', 'PRCCD'],
        ITEMID_PRD: ['EQMCD'],
        PRCDETAIL: ['EQMCD']
    }[field]);
};

// 2026-10-28 [외주처 소모품] 일괄 추가 팝업: 제품·세부공정 콤보는 그 행의 라인으로 목록을 거름
ItsGrid.Event('grid_POP_EQM').onBeginningEdit = function (rowIndex, field) {
    FilterComboByRow('grid_POP_EQM', field, {
        ITEMID_PRD: ['EQMCD'],
        PRCDETAIL: ['EQMCD']
    }[field]);
};

// 2026-10-28 [외주처 소모품] 그리드 콤보 목록을 행 값으로 거름 (grid2·팝업 라인 그리드 공용)
//  콤보 데이터의 REF01(·REF02) 가 refFields 순서대로 행의 값과 같은 것만 보인다 (DC_COMBO OSCCONSUM_* 분기).
//  wijmo DataMap.getDisplayValues 에 편집 중인 행이 넘어온다. 스타일초기화 때 DataMap 이 새로 만들어지므로 편집 시작마다 다시 건다.
function FilterComboByRow(gridId, field, refFields) {
    if (!refFields) return;

    var dataMap = ItsGrid.Get(gridId).columns[ItsGrid.$colIndex(gridId, field)].dataMap;
    dataMap.getDisplayValues = function (row) {
        return dataMap._originData.filter(function (d) {
            if (!row) return true;
            for (var i = 0; i < refFields.length; i++) {
                var ref = d['REF0' + (i + 1)];
                if (ref !== '' && ref !== row[refFields[i]]) return false;
            }
            return true;
        }).map(function (d) { return d.Label; });
    };
}

// 2026-10-28 [외주처 소모품] 일괄 추가 대상 품목: 왼쪽에서 체크한 품목, 체크가 없으면 선택한 품목 1건
function GetBulkItems() {
    var arrItem = [];
    for (var i = 0; i < ItsGrid.Length('grid1'); i++) {
        if (ItsGrid.IsChecked('grid1', i)) arrItem.push(ItsGrid.GetRowData('grid1', i));
    }
    if (arrItem.length === 0 && ItsGrid.IsSelect('grid1')) {
        arrItem.push(ItsGrid.GetRowData('grid1', ItsGrid.GetCurrentIndex('grid1')));
    }
    return arrItem;
}

// 2026-10-28 [외주처 소모품] 팝업 작업장 변경 시 공정 목록 갱신 후 라인 조회
ItsCombo.Event('pop_combo_LINECD').onChanged = function (value) {
    ItsCombo.SetRef01('pop_combo_PRCCD', value);
    ItsCombo.SetValueByIndex('pop_combo_PRCCD', 0);
    SearchPopEqm();
};

// 2026-10-28 [외주처 소모품] 팝업 공정 변경 시 라인 조회
ItsCombo.Event('pop_combo_PRCCD').onChanged = function () {
    SearchPopEqm();
};

// 2026-10-28 [외주처 소모품] 팝업 라인 목록 조회 (작업장·공정 기준)
function SearchPopEqm() {
    var maria = new ItsMaria('MST3001_R05', 'SEL_POP_EQM');
    maria.AddParam('LINECD', ItsCombo.GetValue('pop_combo_LINECD'));
    maria.AddParam('PRCCD', ItsCombo.GetValue('pop_combo_PRCCD'));
    maria.CallProc();
    if (maria.isError) {
        maria.ShowErrMsg();
        return;
    }
    ItsGrid.SetStore('grid_POP_EQM', maria.store);
}

// 2026-10-28 [외주처 소모품] 체크한 품목 x 체크한 라인 x 체크한 터렛 만큼 사용위치 일괄 등록 (이미 있는 위치는 건너뜀)
ItsButton.Event('btn_POP_ADD').onClick = function () {
    if (!ItsGrid.Get('grid_POP_EQM').finishEditing()) return;

    var arrEqm = [];
    for (var i = 0; i < ItsGrid.Length('grid_POP_EQM'); i++) {
        if (ItsGrid.IsChecked('grid_POP_EQM', i)) arrEqm.push(ItsGrid.GetRowData('grid_POP_EQM', i));
    }
    var arrTurret = [];
    for (var i = 0; i < ItsGrid.Length('grid_POP_TURRET'); i++) {
        if (ItsGrid.IsChecked('grid_POP_TURRET', i)) arrTurret.push(ItsGrid.GetValue('grid_POP_TURRET', i, 'TURRET'));
    }
    if (arrEqm.length === 0) {
        ItsMsg.Toast('라인을 선택해주세요.');
        return;
    }
    // 제품·세부공정·터렛은 빈 값으로 등록하지 않음
    for (var i = 0; i < arrEqm.length; i++) {
        if (!arrEqm[i].ITEMID_PRD || !arrEqm[i].PRCDETAIL) {
            ItsMsg.Alert('[' + arrEqm[i].EQMNM + '] 라인의 ' + (!arrEqm[i].ITEMID_PRD ? '제품' : '세부공정') + '을(를) 선택하십시오.');
            return;
        }
    }
    if (arrTurret.length === 0) {
        ItsMsg.Alert('터렛을 선택하십시오.');
        return;
    }

    var arrItem = GetBulkItems();
    if (arrItem.length === 0) {
        ItsMsg.Toast('사용위치를 추가할 품목을 체크하거나 선택해주세요.');
        return;
    }
    var itemText = arrItem.length === 1 ? '[' + arrItem[0].ITEMCD + ']' : '품목 ' + arrItem.length + '개';
    var cnt = arrItem.length * arrEqm.length * arrTurret.length;

    ItsMsg.Confirm(itemText + ' 에 사용위치 ' + cnt + '건(라인 ' + arrEqm.length + ' x 터렛 '
        + arrTurret.length + ')을 추가하시겠습니까?', function () {
        var maria = new ItsMaria('MST3001_R05', 'ADD_ITEM');
        for (var k = 0; k < arrItem.length; k++) {
            for (var i = 0; i < arrEqm.length; i++) {
                for (var j = 0; j < arrTurret.length; j++) {
                    maria.AddList('ITEMID_LIST', arrItem[k].ITEMID);
                    maria.AddList('LINECD_LIST', arrEqm[i].LINECD);
                    maria.AddList('PRCCD_LIST', arrEqm[i].PRCCD);
                    maria.AddList('EQMCD_LIST', arrEqm[i].EQMCD);
                    maria.AddList('ITEMID_PRD_LIST', arrEqm[i].ITEMID_PRD || '');
                    maria.AddList('PRCDETAIL_LIST', arrEqm[i].PRCDETAIL || '');
                    maria.AddList('TURRET_LIST', arrTurret[j]);
                }
            }
        }

        maria.CallProc();
        if (maria.isError) {
            maria.ShowErrMsg();
            return;
        }

        var result = maria.store.data[0];
        ItsMsg.Toast(result.ADDCNT + '건 추가' + (result.SKIPCNT > 0 ? ' (이미 등록된 ' + result.SKIPCNT + '건 제외)' : ''));
        ItsPop.Close('pop_BULK');

        // 여러 품목에 넣었으면 왼쪽 위치수를 모두 다시 보려고 재조회, 한 품목이면 오른쪽만 갱신
        if (arrItem.length > 1) {
            ItsButton.EventSearch();
            return;
        }
        ItsGrid.Event('grid1').onSelect(ItsGrid.GetCurrentIndex('grid1'));
    });
};

// 2026-10-28 [외주처 소모품] 일괄 추가 팝업 닫기
ItsButton.Event('btn_POP_CLOSE').onClick = function () {
    ItsPop.Close('pop_BULK');
};
