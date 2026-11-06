/// <reference path="../../Script/reference.js" />

var tabstate = 0;

/* 페이지 로드 시 수행 */
ItsPage.Load = function () {
    
    /* 그리드 생성 */
    ItsGrid.Create('grid1', { isCheckBoxGrid: false, isCheckBoxGrid: false, allowMerging: 'Cells' }, [
        column.create("공장", "FACTORYCD", { width: 100, align: 'center', columnType: enumColumnTypes.combo, gpcd: 'FACTORYCD', allowMerging: true }),
        column.create("작업장코드", "LINECD", { width: 100, align: 'center', hidden: true }),
        column.create("작업장", "LINENM", { width: 100, align: 'center', allowMerging: true }),     
        column.create("공정", "PRCNM", { width: 100, allowMerging: true }),
        column.create("라인코드", "EQMCD", { width: 150, align: 'center'}),
        column.create("라인명", "EQMNM", { width: 200}),
        column.create("세부공정", "PRCDETAILNM", { width: 200 }),
        column.create("세부공정 관리", "POP_PRCDETAIL", { width: 100, columnType: enumColumnTypes.button, iconCls: 'fa-pencil' }),
        column.create("설비계획그룹", "GROUP_BC", { width: 100, align: 'center'}),
        column.create("원가부문", "CCCD", { width: 100, align: 'center' }),
        column.create("기준 C/T", "STD_CT", { width: 100, align: 'center' }),
        column.create("시작일", "SDT", { width: 130, align: 'center' }),
        column.create("종료일", "EDT", { width: 130, align: 'center' }),
        column.create("설비구분", "EQM_BC", { width: 100, align: 'center'}),
        column.create("생산설비번호", "EQMNO", { width: 100, align: 'center', columnType: enumColumnTypes.combo, gpcd: 'FANO' }),
        column.create("사용여부", "USEYN", { width: 50, align: 'center', columnType: enumColumnTypes.check }),
        column.create("순번", "SORTNO", { width: 100, align: 'center' }),
        column.create("비고", "REMARK", { width: 150 }),
        //column.create("등록자", "REMP", { width: 100, align: 'center' }),
        //column.create("등록일", "RTIME", { width: 150, align: 'center' })
    ]);

    // 2026-11-03 [설비매칭] 선택한 라인과 같은 작업장의 설비: 체크한 설비만 그 라인에 매칭된다(MSTEQM_MATCH)
    ItsGrid.Create('grid2', { isCheckBoxGrid: true, allowMerging: 'Cells' }, [
        column.create("작업장", "LINENM", { width: 120, align: 'center', allowMerging: true }),
        column.create("설비구분", "EQMTP", { width: 103, align: 'center', columnType: enumColumnTypes.combo, gpcd: 'FM100', allowMerging: true }),
        column.create("설비대분류", "EQMGROUP1", { width: 104, align: 'center', columnType: enumColumnTypes.combo, gpcd: 'FM113', allowMerging: true }),
        column.create("설비번호", "FANO", { width: 120, align: 'center' }),
        column.create("설비명", "EQMNM", { width: 200 }),
    ]);

    // 2026-10-28 [세부공정] 라인별 세부공정 관리 팝업: 체크한 세부공정만 그 라인에 등록된다
    ItsGrid.Create('grid_POP_PRCDETAIL', { isCheckBoxGrid: true }, [
        column.create("세부공정코드", "PRCDETAIL", { width: 100, align: 'center' }),
        column.create("세부공정명", "PRCDETAILNM", { width: 150 }),
        column.create("비고", "REMARK", { width: 300, readOnly: false }),
    ]);
};

/* 조회 */
ItsButton.EventSearch = function () {

    ItsGrid.Clear('grid2');

    var maria = new ItsMaria('MST1002_R05', 'SEL_LINE_EQM');
    maria.AddPanel('sdiv1');
    maria.CallProc();
    if (maria.isError) {
        maria.ShowErrMsg();
        return;
    }

    ItsGrid.SetStore('grid1', maria.store.YnToBool('USEYN')); 

    ItsMsg.Toast(maria.store.Length() + '건이 조회되었습니다.'); 

    ItsGrid.Get('grid1').autoSizeColumns();
};

// 2026-11-03 [설비매칭] 라인 선택 시 같은 작업장 설비 조회 (그 라인에 매칭된 설비는 체크된 채로)
ItsGrid.Event('grid1').onSelect = function (rowIndex) {
    SearchEqmMatch(rowIndex);
};

// 2026-11-03 [설비매칭] 라인별 설비매칭 조회 (라인 선택 시, 저장 후 공용)
function SearchEqmMatch(rowIndex) {

    var maria = new ItsMaria('MST1002_R05', 'SEL_EQMMATCH');
    maria.AddParam('EQMCD', ItsGrid.GetValue('grid1', rowIndex, 'EQMCD'));
    maria.CallProc();
    if (maria.isError) {
        maria.ShowErrMsg();
        return;
    }

    ItsGrid.SetStore('grid2', maria.store.YnToBool('isRowCheck'));
    ItsGrid.Get('grid2').autoSizeColumns();
}

// 2026-11-03 [설비매칭] 선택한 라인에 체크한 설비는 매칭 등록, 체크를 푼 설비는 매칭 삭제
ItsButton.EventSave = function () {

    if (!ItsGrid.IsSelect('grid1')) {
        ItsMsg.Toast('라인을 선택해주세요.');
        return;
    }

    var rowIndex = ItsGrid.GetCurrentIndex('grid1');
    var eqmcd = ItsGrid.GetValue('grid1', rowIndex, 'EQMCD');

    var arrRows = [];
    for (var i = 0; i < ItsGrid.Length('grid2'); i++) {
        if (ItsGrid.IsChecked('grid2', i)) arrRows.push(ItsGrid.GetRowData('grid2', i));
    }

    var msg = arrRows.length === 0
        ? '체크한 설비가 없습니다.\n이 라인에 매칭된 설비가 모두 삭제됩니다. 저장하시겠습니까?'
        : '설비 ' + arrRows.length + '건으로 저장하시겠습니까?';

    ItsMsg.Confirm(msg, function () {
        var maria = new ItsMaria('MST1002_R05', 'SAVE_EQMMATCH');
        maria.AddParam('EQMCD', eqmcd);
        for (var i = 0; i < arrRows.length; i++) {
            maria.AddList('FANO_LIST', arrRows[i].FANO);
        }

        maria.CallProc();
        if (maria.isError) {
            maria.ShowErrMsg();
            return;
        }

        ItsMsg.Toast(ItsMsg.CommonMsg.SaveComplete());

        // 위 그리드 선택은 그대로 두고 매칭설비 칸만 맞춘 뒤 아래 그리드를 다시 조회
        ItsGrid.SetValue('grid1', rowIndex, 'FANONM', arrRows.map(function (r) { return r.EQMNM || r.FANO; }).join(', '));
        ItsGrid.Get('grid1').autoSizeColumns();
        SearchEqmMatch(rowIndex);
    });
};

// 2026-10-28 [세부공정] 세부공정 관리 팝업 열기 (전체 세부공정 중 그 라인에 등록된 것은 체크된 채로 조회)
ItsGrid.Event('grid1').onButtonClick = function (rowIndex, field) {
    if (field != 'POP_PRCDETAIL') return;

    var row = ItsGrid.GetRowData('grid1', rowIndex);
    ItsCombo.SetValue('cmb_POP_EQMCD', row.EQMCD);

    var maria = new ItsMaria('MST1002_R05', 'SEL_POP_PRCDETAIL');
    maria.AddParam('EQMCD', row.EQMCD);
    maria.CallProc();
    if (maria.isError) {
        maria.ShowErrMsg();
        return;
    }

    ItsPop.Open('pop_PRCDETAIL');
    ItsGrid.SetStore('grid_POP_PRCDETAIL', maria.store.YnToBool('isRowCheck'));
};

// 2026-10-28 [세부공정] 체크한 세부공정은 등록(비고 수정), 체크를 푼 세부공정은 삭제
ItsButton.Event('btn_POP_SAVE').onClick = function () {
    if (!ItsGrid.Get('grid_POP_PRCDETAIL').finishEditing()) return;

    var arrRows = [];
    for (var i = 0; i < ItsGrid.Length('grid_POP_PRCDETAIL'); i++) {
        if (ItsGrid.IsChecked('grid_POP_PRCDETAIL', i)) arrRows.push(ItsGrid.GetRowData('grid_POP_PRCDETAIL', i));
    }

    var msg = arrRows.length === 0
        ? '체크한 세부공정이 없습니다.\n이 라인에 등록된 세부공정이 모두 삭제됩니다. 저장하시겠습니까?'
        : '세부공정 ' + arrRows.length + '건으로 저장하시겠습니까?';

    ItsMsg.Confirm(msg, function () {
        var maria = new ItsMaria('MST1002_R05', 'SAVE_PRCDETAIL');
        maria.AddParam('EQMCD', ItsCombo.GetValue('cmb_POP_EQMCD'));
        for (var i = 0; i < arrRows.length; i++) {
            maria.AddList('PRCDETAIL_LIST', arrRows[i].PRCDETAIL);
            maria.AddList('REMARK_LIST', arrRows[i].REMARK || '');
        }

        maria.CallProc();
        if (maria.isError) {
            maria.ShowErrMsg();
            return;
        }

        ItsMsg.Toast(ItsMsg.CommonMsg.SaveComplete());
        ItsPop.Close('pop_PRCDETAIL');
        ItsButton.EventSearch();
    });
};

// 2026-10-28 [세부공정] 세부공정 관리 팝업 닫기
ItsButton.Event('btn_POP_CLOSE').onClick = function () {
    ItsPop.Close('pop_PRCDETAIL');
};











