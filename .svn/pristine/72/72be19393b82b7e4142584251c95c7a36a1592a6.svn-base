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
};

/* 조회 */
ItsButton.EventSearch = function () {

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











