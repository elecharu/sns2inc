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
        column.split()
    ]);
};

/* 조회 */
ItsButton.EventSearch = function () {

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









