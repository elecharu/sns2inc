/// <reference path="../../Script/reference.js" />

/* 페이지 로드 시 수행 */
ItsPage.Load = function () {
    
    /* 그리드 생성 */
    ItsGrid.Create('grid1', { isCheckBoxGrid: false }, [
        column.create("불량코드", "BADCD", { width: 100, align: 'center' }),
        column.create("불량유형", "BADNM", { width: 100 }),
        column.create("대분류", "BADTP1", { width: 100, align: 'center' }),
        column.create("중분류", "BADTP2", { width: 100, align: 'center' }),
        column.create("소분류", "BADTP3", { width: 100, align: 'center', columnType: enumColumnTypes.check }),
        column.create("불량제외", "M5", { width: 100, align: 'center', columnType: enumColumnTypes.check }),
        column.create("폐각제외", "M6", { width: 100, align: 'center', columnType: enumColumnTypes.check }),
        column.create("만성불량", "M7", { width: 100, align: 'center', columnType: enumColumnTypes.check  }),
        column.create("수입검사", "IQCYN", { width: 100, align: 'center', columnType: enumColumnTypes.check  }),
        column.create("공정검사", "PQCYN", { width: 100, align: 'center', columnType: enumColumnTypes.check }),
        column.create("완성검사", "OQCYN", { width: 100, align: 'center', columnType: enumColumnTypes.check  }),
        column.create("입고후검사", "M11", { width: 100, align: 'center', columnType: enumColumnTypes.check  }),
        column.create("콤비동시등록", "M12", { width: 100, align: 'center', columnType: enumColumnTypes.check  }),
        column.create("공장", "M20", { width: 100, align: 'center', columnType: enumColumnTypes.combo, gpcd: 'FACTORYCD'  }),
        //column.create("순번", "SORTNO", { width: 100, align: 'center' }),
        column.create("사용여부", "USEYN", { width: 100, align: 'center', columnType: enumColumnTypes.check }),
        column.create("연결 검사항목", "STDNMS", { width: 150 }),
        column.split()
    ]);

    // 2026-11-27 [연결 검사항목] 자주검사 검사항목: 체크한 항목만 선택한 불량코드에 연결된다(MSTBAD_STD)
    ItsGrid.Create('grid2', { isCheckBoxGrid: true }, [
        column.create("검사항목코드", "STDCD", { width: 110, align: 'center' }),
        column.create("검사항목", "STDNM", { width: 150 }),
        column.create("측정부위", "STDPOINT", { width: 100, align: 'center', columnType: enumColumnTypes.combo, gpcd: 'STDPOINT' }),
    ]);
};

/* 조회 */
ItsButton.EventSearch = function () {

    ItsGrid.Clear('grid2');

    var maria = new ItsMaria('MST1003_R03', 'SEL_BAD');
    maria.AddPanel('sdiv1');
    maria.CallProc();
    if (maria.isError) {
        maria.ShowErrMsg();
        return;
    }

    ItsGrid.SetStore('grid1', maria.store.YnToBool('USEYN').YnToBool('BADTP3').YnToBool('M5').YnToBool('M6').YnToBool('M7').YnToBool('IQCYN').YnToBool('PQCYN').YnToBool('OQCYN').YnToBool('M11').YnToBool('M12'));
    ItsMsg.Toast(maria.store.Length() + '건이 조회되었습니다.');

    //ItsGrid.Get('grid1').autoSizeColumns();
};

// 2026-11-27 [연결 검사항목] 불량코드 선택 시 자주검사 검사항목 조회 (그 불량코드에 연결된 항목은 체크된 채로)
ItsGrid.Event('grid1').onSelect = function (rowIndex) {
    SearchBadStd(rowIndex);
};

// 2026-11-27 [연결 검사항목] 조회 (불량코드 선택 시, 저장 후 공용)
function SearchBadStd(rowIndex) {

    var maria = new ItsMaria('MST1003_R03', 'SEL_BADSTD');
    maria.AddParam('BADCD', ItsGrid.GetValue('grid1', rowIndex, 'BADCD'));
    maria.CallProc();
    if (maria.isError) {
        maria.ShowErrMsg();
        return;
    }

    ItsGrid.SetStore('grid2', maria.store.YnToBool('isRowCheck'));
}

// 2026-11-27 [연결 검사항목] 선택한 불량코드에 체크한 검사항목은 연결 등록, 체크를 푼 항목은 연결 삭제
ItsButton.EventSave = function () {

    if (!ItsGrid.IsSelect('grid1')) {
        ItsMsg.Toast('불량코드를 선택해주세요.');
        return;
    }

    var rowIndex = ItsGrid.GetCurrentIndex('grid1');
    var badcd = ItsGrid.GetValue('grid1', rowIndex, 'BADCD');

    var arrRows = [];
    for (var i = 0; i < ItsGrid.Length('grid2'); i++) {
        if (ItsGrid.IsChecked('grid2', i)) arrRows.push(ItsGrid.GetRowData('grid2', i));
    }

    var msg = arrRows.length === 0
        ? '체크한 검사항목이 없습니다.\n이 불량코드에 연결된 검사항목이 모두 삭제됩니다. 저장하시겠습니까?'
        : '검사항목 ' + arrRows.length + '건으로 저장하시겠습니까?';

    ItsMsg.Confirm(msg, function () {
        var maria = new ItsMaria('MST1003_R03', 'SAVE_BADSTD');
        maria.AddParam('BADCD', badcd);
        for (var i = 0; i < arrRows.length; i++) {
            maria.AddList('STDCD_LIST', arrRows[i].STDCD);
        }

        maria.CallProc();
        if (maria.isError) {
            maria.ShowErrMsg();
            return;
        }

        ItsMsg.Toast(ItsMsg.CommonMsg.SaveComplete());

        // 위 그리드 선택은 그대로 두고 연결 검사항목 칸만 맞춘 뒤 오른쪽 그리드를 다시 조회
        ItsGrid.SetValue('grid1', rowIndex, 'STDNMS', arrRows.map(function (r) { return r.STDNM; }).sort().join(', '));
        SearchBadStd(rowIndex);
    });
};









