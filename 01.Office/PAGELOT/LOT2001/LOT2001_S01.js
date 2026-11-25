/* LOT2001_S01: 로트추적 */
/* 로트번호·라벨번호·출하번호로 로트 계보를 조회한다.
   왼쪽 위 = 역추적(0 조회로트, -1, -2 … 투입된 로트를 원소재까지)
   왼쪽 아래 = 정추적(0 조회로트, +1, +2 … 이 로트를 쓴 실적과 출하까지)
   오른쪽 = 왼쪽에서 고른 줄의 기본정보 / 입출고 이력 / 품질 이력(자주검사·부적합 판정) */

/// <reference path="../../Script/reference.js" />

/* 페이지 로드 */
ItsPage.Load = function () {
    // 역추적·정추적 그리드는 컬럼이 같다. 로트번호 칸은 프로시저가 단계만큼 들여쓰기해서 내려준다 (출하 줄은 '출하번호 (출하번호)')
    ['grid_BACK', 'grid_FWD'].forEach(function (gridId) {
        ItsGrid.Create(gridId, { isCheckBoxGrid: false, isSubTotalGrid: false }, [
            column.create('단계', 'LVL', { width: 45, align: 'center' }),
            column.create('로트번호', 'LOTDISP', { width: 230 }),
            column.create('구분', 'NODETPNM', { width: 80, align: 'center' }),
            column.create('품번', 'ITEMCD', { width: 110 }),
            column.create('품명', 'ITEMNM', { width: 150 }),
            column.create('작업장', 'LINENM', { width: 90 }),
            column.create('공정', 'PRCNM', { width: 80, align: 'center' }),
            column.create('라인', 'EQMNM', { width: 90 }),
            column.create('거래처', 'CUSTNM', { width: 110 }),   // 외주 = 외주처, 자재 = 입고거래처, 출하 = 고객사
            column.create('일자', 'WORKDATE', { width: 85, align: 'center' }),
            column.create('수량', 'LOTQTY', { width: 70, columnType: enumColumnTypes.number, decimalPrecision: 0 }),
            column.create('투입수량', 'USEQTY', { width: 70, columnType: enumColumnTypes.number, decimalPrecision: 0 }),
            column.create('현재고', 'STOCKQTY', { width: 70, columnType: enumColumnTypes.number, decimalPrecision: 0 }),
            column.create('로트번호', 'LOTKEY', { width: 100, hidden: true }),
            column.create('구분코드', 'NODETP', { width: 50, hidden: true }),
            column.create('실적번호', 'RSTKEY', { width: 100, hidden: true }),
            column.split()
        ]);
    });

    // 기본정보: 프로시저가 구분(생산·외주·자재·출하)별로 필요한 항목만 '항목 / 내용' 줄로 내려준다
    ItsGrid.Create('grid_INFO', { isCheckBoxGrid: false, isSubTotalGrid: false }, [
        column.create('항목', 'INFONM', { width: 120 }),
        column.create('내용', 'INFOVAL', { width: 250 }),
        column.split()
    ]);

    // 입출고: 모든 창고의 입고(+)·출고(-) 이력
    ItsGrid.Create('grid_IO', { isCheckBoxGrid: false, isSubTotalGrid: false }, [
        column.create('일자', 'IODATE', { width: 85, align: 'center' }),
        column.create('입출고', 'IOTPNM', { width: 55, align: 'center' }),
        column.create('구분', 'TPNM', { width: 100, align: 'center' }),
        column.create('창고', 'WARENM', { width: 110 }),
        column.create('수량', 'IOQTY', { width: 75, columnType: enumColumnTypes.number, decimalPrecision: 0 }),
        column.create('등록일시', 'RTIME', { width: 120, align: 'center' }),
        column.split()
    ]);

    // 품질: 자주검사(생산 줄, 작업 중 검사) + 부적합 판정(이 로트)
    ItsGrid.Create('grid_QC', { isCheckBoxGrid: false, isSubTotalGrid: false }, [
        column.create('구분', 'QCTPNM', { width: 80, align: 'center' }),
        column.create('일시', 'QCTIME', { width: 120, align: 'center' }),
        column.create('결과', 'RESULTNM', { width: 70, align: 'center' }),
        column.create('수량', 'QCQTY', { width: 60, columnType: enumColumnTypes.number, decimalPrecision: 0 }),
        column.create('내용', 'QCDESC', { width: 200 }),
        column.split()
    ]);
};

/* 추적번호 칸에서 엔터: 조회 (바코드 스캔 포함) */
ItsText.Event('txt_KEYVAL').onKeyEnter = function () {
    ItsButton.EventSearch();
};

/* 조회: 역추적(결과 0)·정추적(결과 1). 첫 줄(조회로트)이 자동 선택되며 오른쪽 상세가 채워진다 */
ItsButton.EventSearch = function () {
    if (ItsText.GetValue('txt_KEYVAL') == '') {
        ItsMsg.Alert('추적번호를 입력하세요.');
        return;
    }

    ItsGrid.Clear('grid_BACK');
    ItsGrid.Clear('grid_FWD');
    ItsGrid.Clear('grid_INFO');
    ItsGrid.Clear('grid_IO');
    ItsGrid.Clear('grid_QC');

    var maria = new ItsMaria('LOT2001_S01', 'LIST');
    maria.AddPanel('sdiv1');
    maria.CallProc();
    if (maria.isError) {
        maria.ShowErrMsg();
        return;
    }

    ItsGrid.SetStore('grid_BACK', maria.store);
    ItsGrid.SetStore('grid_FWD', maria.storeExtend1);
    ItsGrid.Get('grid_BACK').autoSizeColumns();
    ItsGrid.Get('grid_FWD').autoSizeColumns();

    // 조회로트 줄은 두 그리드에 다 있으므로 한 번만 센다
    ItsMsg.Toast(ItsMsg.CommonMsg.SearchComplete(maria.store.Length() + maria.storeExtend1.Length() - 1));
};

/* 역추적·정추적 줄 선택: 그 줄의 기본정보·입출고·품질. 지금 보이는 탭의 그리드 너비를 맞춘다 */
['grid_BACK', 'grid_FWD'].forEach(function (gridId) {
    ItsGrid.Event(gridId).onSelect = function (rowIndex) {
        var row = ItsGrid.GetRowData(gridId, rowIndex);

        var maria = new ItsMaria('LOT2001_S01', 'INFO');
        maria.AddParam('LOTKEY', row.LOTKEY);
        maria.AddParam('NODETP', row.NODETP);
        maria.AddParam('RSTKEY', row.RSTKEY);
        maria.CallProc();
        if (maria.isError) {
            maria.ShowErrMsg();
            return;
        }

        ItsGrid.SetStore('grid_INFO', maria.store);
        ItsGrid.SetStore('grid_IO', maria.storeExtend1);
        ItsGrid.SetStore('grid_QC', maria.storeExtend2);
        ItsGrid.Get(['grid_INFO', 'grid_IO', 'grid_QC'][ItsTab.GetIndex('tab1')]).autoSizeColumns();
    };
});

/* 탭 클릭: 그 탭 그리드의 너비를 맞춘다 (숨은 탭에서는 너비를 잴 수 없어서 보일 때 맞춘다) */
ItsTab.Event('tab1').onTabChanged = function (newPanel) {
    ItsGrid.Get(['grid_INFO', 'grid_IO', 'grid_QC'][newPanel]).autoSizeColumns();
};
