/// <reference path="../../Script/reference.js" />

/* 페이지 로드 */
ItsPage.Load = function () {
    // 협력업체 + 품목별 일자(1~31일) 불량수량. 맨 아래 합계는 그리드 소계
    // 목표(PPM)·주요 ISSUE 및 대책은 칸만 두고 값 없음
    var dayColumns = [];
    for (var day = 1; day <= 31; day++) {
        var field = 'D' + (day < 10 ? '0' : '') + day;
        dayColumns.push(column.create(day + '일', field, { width: 45, columnType: enumColumnTypes.number, decimalPrecision: 0, groupType: enumGrouping.sum }));
    }

    ItsGrid.Create('grid1', { isCheckBoxGrid: false, isSubTotalGrid: true }, [
        column.create('협력업체', 'CUSTNM', { width: 110, align: 'center', allowMerging: true }),
        column.create('품목ID', 'ITEMID', { width: 70, align: 'center' }),
        column.create('품목코드', 'ITEMCD', { width: 120 }),
        column.create('품명', 'ITEMNM', { width: 200 }),
        column.create('목표(PPM)', 'TARGETPPM', { width: 70, columnType: enumColumnTypes.number, decimalPrecision: 0 }),
        column.band('협력업체 불량 현황', {}, dayColumns),
        column.create('합계', 'TOTQTY', { width: 70, columnType: enumColumnTypes.number, decimalPrecision: 0, groupType: enumGrouping.sum }),
        column.create('주요 ISSUE 및 대책', 'ISSUE', { width: 250 }),
        column.split()
    ]);
    // 밴드(제목줄 병합)와 협력업체 셀 병합을 같이 쓰려고 wijmo 병합을 직접 All 로 둔다 (PRD2001_S02 와 같은 이유).
    // allowMerging: 'Cells' 는 제목줄 병합이 꺼져 밴드가 칸마다 찍히고, ItsGrid 의 'All' 은 데이터 칸 전용 병합으로 덮어쓴다
    ItsGrid.Get('grid1').allowMerging = wijmo.grid.AllowMerging.All;

    // 일자 칸 제목: 조회월 기준 토요일은 파란 글씨, 일요일은 빨간 글씨 (밴드 줄 아래 일자 제목 줄만)
    ItsGrid.Get('grid1').formatItem.addHandler(function (s, e) {
        if (e.panel != s.columnHeaders || e.row != s.columnHeaders.rows.length - 1) {
            return;
        }
        // 가로 스크롤 때 제목 칸이 재사용되므로 먼저 원래 색으로 되돌린다
        e.cell.style.color = '';

        var binding = s.columns[e.col].binding;
        var month = (ItsMonth.GetValue('mon_SMONTH') || '').split('-');
        if (!/^D\d\d$/.test(binding) || month.length != 2) {
            return;
        }
        var weekday = new Date(+month[0], +month[1] - 1, +binding.substr(1)).getDay();
        if (weekday == 6) {
            e.cell.style.color = 'blue';
        } else if (weekday == 0) {
            e.cell.style.color = 'red';
        }
    });

    SetDayColumns();
};

/* 조회월 날짜 수만큼만 일자 칸을 보인다 (29~31일 칸) */
function SetDayColumns() {
    var month = (ItsMonth.GetValue('mon_SMONTH') || '').split('-');
    var lastDay = month.length == 2 ? new Date(+month[0], +month[1], 0).getDate() : 31;
    var grid = ItsGrid.Get('grid1');
    for (var day = 29; day <= 31; day++) {
        grid.columns[ItsGrid.$colIndex('grid1', 'D' + day)].visible = day <= lastDay;
    }
}

/* 조회 */
ItsButton.EventSearch = function () {
    var maria = new ItsMaria('TQM3001_S01', 'LIST');
    maria.AddPanel('sdiv1');
    maria.CallProc();
    if (maria.isError) {
        maria.ShowErrMsg();
        return;
    }

    SetDayColumns();
    ItsGrid.SetStore('grid1', maria.store);
    ItsMsg.Toast(ItsMsg.CommonMsg.SearchComplete(maria.store.Length()));
};
