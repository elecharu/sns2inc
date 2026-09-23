/// <reference path="../../Script/reference.js" />

/* 페이지 로드 시 수행 */
ItsPage.Load = function () {
    
    /* 그리드 생성 */
    ItsGrid.Create('grid1', { isCheckBoxGrid: false }, [
        column.create("Routing코드", "ROUTCD", { width: 80, align: 'center' }),
        column.create("품목ID", "ITEMID", { width: 50, align: 'center' }),
        column.create("계획공장", "FACTORYCD", { width: 50, align: 'center', columnType: enumColumnTypes.combo, gpcd: 'FACTORYCD' }),
        column.create("기본여부", "BASEYN", { width: 50, align: 'center', columnType: enumColumnTypes.check }),
        column.create("계획비율", "PLAN_RT", { width: 50, align: 'center' }),
        column.create("적정생산LOT", "LOT_FIT", { width: 80, align: 'center' }),
        column.create("최소생산LOT", "LOT_MIN", { width: 80, align: 'center' }),
        column.create("최대생산LOT", "LOT_MAX", { width: 80, align: 'center' }),
        column.create("사용여부", "USEYN", { width: 100, align: 'center', columnType: enumColumnTypes.check })
        //column.create("적용시작일", "SDT", { width: 100, align: 'center' }),
        //column.create("적용종료일", "EDT", { width: 100, align: 'center' }),
        //column.create("비고", "REMARK", { width: 50, align: 'center' })
        //column.create("등록자", "REMP", { width: 100, align: 'center' }),
        //column.create("등록시간", "RTIME", { width: 100, align: 'center' })
    ]);

    ItsGrid.Create('grid2', { isCheckBoxGrid: false }, [
        column.create("Routing코드", "ROUTCD", { width: 100, align: 'center', hidden: true }),
        column.create("Routing명", "ROUTNM", { width: 100, align: 'center' }),
        column.create("Routing구분", "ROUT_BC", { width: 100, align: 'center' }),
        //column.create("계획공장", "FACTORYCD", { width: 100, align: 'center', columnType: enumColumnTypes.combo, gpcd: 'FACTORYCD' }),
        column.create("적용시작일", "SDT", { width: 100, align: 'center' }),
        column.create("적용종료일", "EDT", { width: 100, align: 'center' }),
        column.create("생산기준등록ID", "ENTID", { width: 100, align: 'center' }),
        column.create("비고", "REMARK", { width: 100, align: 'center' }),
        //column.create("등록자", "REMP", { width: 100, align: 'center' }),
        //column.create("등록시간", "RTIME", { width: 100, align: 'center' }),
        //column.create("수정자", "MEMP", { width: 100, align: 'center' }),
        //column.create("수정시간", "MTIME", { width: 100, align: 'center' }),
        column.create("(구)라우팅코드", "OLDROUTCD", { width: 100, align: 'center' }),
    ]);

    ItsGrid.Create('grid3', { isCheckBoxGrid: false }, [
        column.create("Routing코드", "ROUTCD", { width: 100, align: 'center', hidden: true }),
        column.create("Routing순번", "ROUTSEQ", { width: 100, align: 'center' }),
        column.create("공정", "PRCCD", { width: 100, align: 'center', columnType: enumColumnTypes.combo, gpcd: 'PRCCD' }),
        //column.create("공장", "FACTORYCD", { width: 100, align: 'center', columnType: enumColumnTypes.combo, gpcd: 'FACTORYCD'}),
        column.create("작업장", "LINCD", { width: 100, align: 'center', columnType: enumColumnTypes.combo, gpcd: 'LINECD' }),
        //column.create("생산설비", "EQMCD", { width: 100, align: 'center', columnType: enumColumnTypes.combo, gpcd: 'EQMCD' }),
        column.create("생산투입보고여부", "ENTYN", { width: 100, align: 'center', columnType: enumColumnTypes.check  }),
        column.create("생산실적보고여부", "ENDYN", { width: 100, align: 'center', columnType: enumColumnTypes.check  }),
        column.create("자동실적처리여부", "AUTOYN", { width: 100, align: 'center', columnType: enumColumnTypes.check  }),
        column.create("자동출고처리여부", "OUTYN", { width: 100, align: 'center', columnType: enumColumnTypes.check  }),
        column.create("검사구분", "INSPC_BC", { width: 100, align: 'center' }),
        column.create("공정간리드타임", "READTIME", { width: 100, align: 'center' }),
        column.create("적용시작일", "SDT", { width: 100, align: 'center' }),
        column.create("적용종료일", "EDT", { width: 100, align: 'center' }),
        column.create("비고", "REMARK", { width: 100, align: 'center' }),
        //column.create("등록자", "REMP", { width: 100, align: 'center' }),
        //column.create("등록시간", "RTIME", { width: 100, align: 'center' })
    ]);
};

/* 조회 */
ItsButton.EventSearch = function () {

    ItsGrid.Clear('grid2');
    ItsGrid.Clear('grid3');

    var maria = new ItsMaria('MST1003_R01', 'SEL_ROUT_MATCH');
    maria.AddPanel('sdiv1');
    maria.CallProc();
    if (maria.isError) {
        maria.ShowErrMsg();
        return;
    }

    ItsGrid.SetStore('grid1', maria.store.YnToBool('BASEYN').YnToBool('USEYN'));
    ItsMsg.Toast(maria.store.Length() + '건이 조회되었습니다.');

    ItsGrid.Get('grid1').autoSizeColumns();
};

ItsGrid.Event('grid1').onSelect = function (rowIndex) {

    ItsGrid.Clear('grid2');
    ItsGrid.Clear('grid3');

    var maria = new ItsMaria('MST1003_R01', 'SEL_ROUT');
    maria.AddParam('ROUTCD', ItsGrid.GetValue('grid1', rowIndex, 'ROUTCD'));
    maria.CallProc();

    if (maria.isError) {
        maria.ShowErrMsg();
        return;
    }

    ItsGrid.SetStore('grid2', maria.store.YnToBool('USEYN'));

    ItsGrid.Get('grid2').autoSizeColumns();
}

ItsGrid.Event('grid2').onSelect = function (rowIndex) {

    ItsGrid.Clear('grid3');

    var maria = new ItsMaria('MST1003_R01', 'SEL_ROUT_DETAIL');
    maria.AddParam('ROUTCD', ItsGrid.GetValue('grid2', rowIndex, 'ROUTCD'));
    maria.CallProc();

    if (maria.isError) {
        maria.ShowErrMsg();
        return;
    }

    ItsGrid.SetStore('grid3', maria.store.YnToBool('ENTYN').YnToBool('ENDYN').YnToBool('AUTOYN').YnToBool('OUTYN'));

    ItsGrid.Get('grid3').autoSizeColumns();
}








