/// <reference path="../../Script/reference.js" />

/* 페이지 로드 시 수행 */
ItsPage.Load = function () {
    
    /* 그리드 생성 */
    ItsGrid.Create('grid1', { isCheckBoxGrid: false }, [
        column.create("비가동코드", "NONCD", { width: 100, align: 'center'}),
        column.create("비가동명", "NONNM", { width: 150 }),
        column.create("공장코드", "FACTORYCD", { width: 100, columnType: enumColumnTypes.combo, gpcd: 'FACTORYCD', align: 'center' }),
        column.create("작업장", "LINECD", { width: 100, columnType: enumColumnTypes.combo, gpcd: 'LINECD', align: 'center' }),
        column.create("계획여부", "PLANYN", { width: 80, align: 'center', columnType: enumColumnTypes.check  }),
        column.create("정지로스", "STOPYN", { width: 80, align: 'center', columnType: enumColumnTypes.check  }),
        column.create("속도로스 ", "SPEEDYN", { width: 80, align: 'center', columnType: enumColumnTypes.check  }),
        column.create("고장여부", "BADYN", { width: 80, align: 'center', columnType: enumColumnTypes.check  }),
        //column.create("비가동대분류", "NONGROUPCD1", { width: 100, align: 'center' }),
        //column.create("비가동중분류", "NONGROUPCD2", { width: 100, align: 'center' }),
        column.create("사용여부", "USEYN", { width: 80, align: 'center', columnType: enumColumnTypes.check  }),
        column.create("비고", "REMARK", { width: 150}),
        //column.create("등록자", "REMP", { width: 100, align: 'center' }),
        //column.create("등록시간", "RTIME", { width: 150, align: 'center' }),
        //column.create("수정자", "MEMP", { width: 100, align: 'center' }),
        //column.create("수정시간", "MTIME", { width: 100, align: 'center' }),
        
        column.split()
    ]);

};

/* 조회 */
ItsButton.EventSearch = function () {

    var maria = new ItsMaria('MST1003_R02', 'SEL_NON');
    maria.AddPanel('sdiv1');
    maria.CallProc();
    if (maria.isError) {
        maria.ShowErrMsg();
        return;
    }

    ItsGrid.SetStore('grid1', maria.store.YnToBool('PLANYN').YnToBool('STOPYN').YnToBool('SPEEDYN').YnToBool('BADYN').YnToBool('USEYN'));
    ItsMsg.Toast(maria.store.Length() + '건이 조회되었습니다.');

    //ItsGrid.Get('grid1').autoSizeColumns();
};









