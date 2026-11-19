/* SAL3002_S02: 영업관리 ▶ 판매계획대비 출하실적조회 */
/* 양식: 생산관리팀 "판매계획대비 출하실적(세부)_2공장" 엑셀. 메인탭 = 표지 1~4, 상세탭 = 세부내역 고객사~비고 */
/* 계획 = 조회년월에 수주한 수주(수주일자), 실적 = 그 수주 품목에 연결된 출하. 변동사유·미출고원인·대책·비고만 상세탭에서 입력·저장 */

/// <reference path="../../Script/reference.js" />

/* 페이지 로드 */
ItsPage.Load = function () {
    // 1. 구분별 (수출 / 내수 / Total(1공장제외) / Total(1공장포함))
    ItsGrid.Create('grid_GUBUN', { isCheckBoxGrid: false, isSubTotalGrid: false }, [
        column.create('구분', 'DEBCNM', { width: 140, align: 'center' }),
        column.create('판매계획', 'PLANAMT', { width: 120, columnType: enumColumnTypes.number, decimalPrecision: 0 }),
        column.create('출하금액', 'RSTAMT', { width: 120, columnType: enumColumnTypes.number, decimalPrecision: 0 }),
        column.create('차액', 'DIFFAMT', { width: 120, columnType: enumColumnTypes.number, decimalPrecision: 0 }),
        column.create('달성율(%)', 'RATE', { width: 75, columnType: enumColumnTypes.number, decimalPrecision: 0 }),
        column.split()
    ]);

    // 2. 고객사별 (구분 안에서 고객사, 구분 합계, 총합계)
    ItsGrid.Create('grid_CUST', { isCheckBoxGrid: false, isSubTotalGrid: false, allowMerging: 'Cells' }, [
        column.create('구분', 'DEBCNM', { width: 80, align: 'center', allowMerging: true }),
        column.create('고객사', 'CUSTNM', { width: 150 }),
        column.create('판매계획', 'PLANAMT', { width: 120, columnType: enumColumnTypes.number, decimalPrecision: 0 }),
        column.create('출하금액', 'RSTAMT', { width: 120, columnType: enumColumnTypes.number, decimalPrecision: 0 }),
        column.create('달성율(%)', 'RATE', { width: 75, columnType: enumColumnTypes.number, decimalPrecision: 0 }),
        column.split()
    ]);

    // 3. 변동사유 기준 (상세탭에서 입력한 변동사유별 합. 사유를 안 넣은 품목은 '정상출고')
    ItsGrid.Create('grid_REASON', { isCheckBoxGrid: false, isSubTotalGrid: false }, [
        column.create('변동사유', 'OUTCHGNM', { width: 110, align: 'center' }),
        column.create('판매계획', 'PLANAMT', { width: 120, columnType: enumColumnTypes.number, decimalPrecision: 0 }),
        column.create('출하실적', 'RSTAMT', { width: 120, columnType: enumColumnTypes.number, decimalPrecision: 0 }),
        column.create('차액', 'DIFFAMT', { width: 120, columnType: enumColumnTypes.number, decimalPrecision: 0 }),
        column.split()
    ]);

    // 4. 판매계획 대비 실적: 조정 판매계획 = 판매계획(A) + 조정대상 사유(공통코드 OUTCHGTP REF01 = Y)의 차액(B)
    ItsGrid.Create('grid_PLAN', { isCheckBoxGrid: false, isSubTotalGrid: false }, [
        column.create('판매계획(A)', 'PLANAMT', { width: 115, columnType: enumColumnTypes.number, decimalPrecision: 0 }),
        column.create('조정대상 사유', 'ADJNM', { width: 120, align: 'center' }),
        column.create('조정대상 차액(B)', 'ADJAMT', { width: 115, columnType: enumColumnTypes.number, decimalPrecision: 0 }),
        column.create('판매계획(A+B)', 'ADJPLANAMT', { width: 115, columnType: enumColumnTypes.number, decimalPrecision: 0 }),
        column.create('출하실적', 'RSTAMT', { width: 115, columnType: enumColumnTypes.number, decimalPrecision: 0 }),
        column.create('달성율(%)', 'RATE', { width: 75, columnType: enumColumnTypes.number, decimalPrecision: 0 }),
        column.split()
    ]);

    // 상세: 품목 줄(ROWTP D) + 고객사 Total(C) + 구분 Total(G) + Grand Total(T, 1공장 제외 / 포함). 입력 칸은 품목 줄만 열린다
    // 1공장 품목은 Grand Total (1공장 제외) 아래 '1공장' 구간에 나온다
    // 체크박스는 삭제할 품목 줄을 고르는 용도 (전체 체크로 합계 줄이 체크돼도 삭제할 때 건너뛴다)
    ItsGrid.Create('grid_DETAIL', { isCheckBoxGrid: true, isSubTotalGrid: false }, [
        column.create('구분', 'DEBCNM', { width: 150, align: 'center', allowMerging: true }),
        column.create('고객사', 'CUSTNM', { width: 200, allowMerging: true }),
        column.create('품명', 'ITEMNM', { width: 250 }),
        column.create('품번', 'ITEMCD', { width: 120 }),
        column.create('통화', 'CURYBC', { width: 50, align: 'center', columnType: enumColumnTypes.combo, gpcd: 'BC400' }),
        column.create('외화단가', 'FUP', { width: 75, columnType: enumColumnTypes.number, decimalPrecision: 2 }),
        column.create('원화단가', 'UP', { width: 80, columnType: enumColumnTypes.number, decimalPrecision: 0 }),
        column.band('계획', {}, [
            column.create('수량(EA)', 'PLANQTY', { width: 80, columnType: enumColumnTypes.number, decimalPrecision: 0 }),
            column.create('금액(원)', 'PLANAMT', { width: 105, columnType: enumColumnTypes.number, decimalPrecision: 0 })
        ]),
        column.band('실적', {}, [
            column.create('수량(EA)', 'RSTQTY', { width: 80, columnType: enumColumnTypes.number, decimalPrecision: 0 }),
            column.create('금액(원)', 'RSTAMT', { width: 105, columnType: enumColumnTypes.number, decimalPrecision: 0 }),
            column.create('상세조회', 'BTN_DETAIL', { width: 70, columnType: enumColumnTypes.button, iconCls: 'fa-search' })   // 출하실적조회(SAL3002_S04)로 이동
        ]),        
        column.create('달성율(%)', 'RATE', { width: 70, columnType: enumColumnTypes.number, decimalPrecision: 0 }),
        column.band('차이', {}, [
            column.create('수량(EA)', 'DIFFQTY', { width: 80, columnType: enumColumnTypes.number, decimalPrecision: 0 }),
            column.create('금액(원)', 'DIFFAMT', { width: 105, columnType: enumColumnTypes.number, decimalPrecision: 0 })
        ]),
        column.create('변동사유', 'OUTCHGTP', { width: 100, align: 'center', columnType: enumColumnTypes.combo, gpcd: 'OUTCHGTP', readOnly: false }),
        column.create('미 출고 원인', 'NOOUTCAUSE', { width: 220, readOnly: false }),
        column.create('대책', 'MEASURE', { width: 220, readOnly: false }),
        column.create('비고', 'REMARK', { width: 150, readOnly: false }),
        column.create('거래처코드', 'CUSTCD', { width: 80, hidden: true }),
        column.create('품목ID', 'ITEMID', { width: 70, hidden: true }),
        column.create('줄구분', 'ROWTP', { width: 50, hidden: true }),
        column.create('구분코드', 'DEBC', { width: 60, hidden: true }),
        column.split()
    ]);
    // 밴드(제목줄 병합)와 구분·고객사 셀 병합을 같이 쓰려고 wijmo 병합을 직접 All 로 둔다 (PRD2001_S03 과 같은 이유)
    ItsGrid.Get('grid_DETAIL').allowMerging = wijmo.grid.AllowMerging.All;

    // 합계 줄(ROWTP D 가 아닌 줄)은 변동사유·미출고원인·대책·비고를 입력하지 못하게 한다
    // (ItsGrid.Event().onBeginningEdit 은 취소 인자를 안 넘겨주므로 wijmo 이벤트에 직접 붙인다)
    ItsGrid.Get('grid_DETAIL').beginningEdit.addHandler(function (grid, e) {
        if (ItsGrid.GetValue('grid_DETAIL', e.row, 'ROWTP') != 'D') e.cancel = true;
    });
};

/* 상세탭 [상세조회] 버튼: 출하실적조회(SAL3002_S04) 화면을 열어 그 품목의 출하 LOT 를 조회한다 (품목 줄만)
   넘기는 값: 조회년월(S04 는 그 달 1일~말일 출하일자), 구분, 고객사코드, 품목ID
   1공장 줄의 구분 코드 FAC1 은 S04 구분 콤보에 없어서 빈값(전체)으로 넘긴다 (품목이 1공장 품목이라 결과는 같다) */
ItsGrid.Event('grid_DETAIL').onButtonClick = function (rowIndex, field) {
    if (field != 'BTN_DETAIL') return;
    var row = ItsGrid.GetRowData('grid_DETAIL', rowIndex);
    if (row.ROWTP != 'D') return;

    ItsPage.Jump('SAL3002_S04', {
        SMONTH: ItsMonth.GetValue('mon_SMONTH'),
        DEBC: row.DEBC == 'FAC1' ? '' : row.DEBC,
        CUSTCD: row.CUSTCD,
        ITEMID: row.ITEMID
    });
};

/* 조회: 메인탭 4개 표 + 상세탭 */
ItsButton.EventSearch = function () {
    var maria = new ItsMaria('SAL3002_S02', 'LIST');
    maria.AddPanel('sdiv1');
    maria.CallProc();
    if (maria.isError) {
        maria.ShowErrMsg();
        return;
    }

    ItsGrid.SetStore('grid_GUBUN', maria.store);
    ItsGrid.SetStore('grid_CUST', maria.storeExtend1);
    ItsGrid.SetStore('grid_REASON', maria.storeExtend2);
    ItsGrid.SetStore('grid_PLAN', maria.storeExtend3);
    ItsGrid.SetStore('grid_DETAIL', maria.storeExtend4);

    ItsMsg.Toast(ItsMsg.CommonMsg.SearchComplete(maria.storeExtend4.Length()));
};

/* 인쇄: 조회년월로 리포트(SAL3002.exe S02, 엑셀 양식처럼 메인 + 세부내역)를 출력 (뷰어 팝업 없이 CallPop) */
ItsButton.EventPrint = function () {
    if (ItsGrid.Length('grid_DETAIL') == 0) {
        ItsMsg.Alert('먼저 조회하세요.');
        return;
    }

    var rpt = new ItsXtraRpt('SAL3002_S02');
    rpt.AddParam('SMONTH', ItsMonth.GetValue('mon_SMONTH'));
    rpt.CallPop();
    if (rpt.isError) {
        ItsMsg.Alert(rpt.errMessage);
    }
};

/* 엑셀 내보내기: 생산관리팀 양식처럼 메인 시트(표지 1~4) + 세부내역 시트(상세탭)
   그리드를 그대로 변환하지 않고 조회 데이터로 칸을 직접 채워 서식(색·테두리·숫자형식)을 넣는다
   (그리드 변환은 숫자 소수점이 그대로 나오고, 탭 안 그리드는 색을 못 가져온다) */
ItsButton.Event('btn_EXPORT').onClick = function () {
    if (ItsGrid.Length('grid_DETAIL') == 0) {
        ItsMsg.Alert('먼저 조회하세요.');
        return;
    }
    ItsGrid.FinishEditing('grid_DETAIL');

    var xl = wijmo.xlsx;
    var month = ItsMonth.GetValue('mon_SMONTH');   // YYYY-MM

    // 칸 서식. o = { bold, size, color(글자색), fill(바탕색), align(left/center/right), format(엑셀 숫자형식), border(얇은 테두리) }
    var makeStyle = function (o) {
        var style = new xl.WorkbookStyle();
        style.font = new xl.WorkbookFont();
        style.font.family = '맑은 고딕';
        style.font.size = (o.size || 10) * 96 / 72;   // wijmo 는 글자 크기를 px 로 받는다 (pt → px)
        style.font.bold = o.bold == true;
        if (o.color) style.font.color = o.color;
        if (o.fill) {
            style.fill = new xl.WorkbookFill();
            style.fill.color = o.fill;
        }
        if (o.format) style.format = o.format;
        if (o.align == 'left') style.hAlign = xl.HAlign.Left;
        if (o.align == 'center') style.hAlign = xl.HAlign.Center;
        if (o.align == 'right') style.hAlign = xl.HAlign.Right;
        style.vAlign = xl.VAlign.Center;
        if (o.border) {
            style.borders = new xl.WorkbookBorder();
            ['left', 'right', 'top', 'bottom'].forEach(function (side) {
                style.borders[side] = new xl.WorkbookBorderSetting();
                style.borders[side].style = xl.BorderStyle.Thin;
                style.borders[side].color = '#000000';
            });
        }
        return style;
    };
    var makeCell = function (value, style) {
        var cell = new xl.WorkbookCell();
        if (value !== null && value !== undefined && value !== '') cell.value = value;
        if (style) cell.style = style;
        return cell;
    };
    // 제목 줄: 왼쪽에 제목, unitCol 칸(0부터)에 '단위: 원'
    var addTitle = function (sheet, text, size, unitCol) {
        var row = new xl.WorkbookRow();
        row.cells.push(makeCell(text, makeStyle({ bold: true, size: size, align: 'left' })));
        for (var c = 1; c <= unitCol; c++) {
            row.cells.push(c == unitCol ? makeCell('단위: 원', makeStyle({ align: 'right' })) : makeCell(null, null));
        }
        sheet.rows.push(row);
    };

    // 숫자 형식 (양식과 같게 소수점 없음, 차이는 음수 빨강, 달성율은 %)
    var FORMAT = { amt: '#,##0', diff: '#,##0;[Red]-#,##0', rate: '0%', fup: '#,##0.00' };

    // 표 하나를 sheet 에 그린다
    //   heads   : 제목 줄 배열. 칸 = { text, colSpan, rowSpan }, 병합에 가려지는 자리는 null
    //   cols    : { field, type(text/amt/diff/rate/fup), align, merge(위아래 같은 값 병합) }
    //   look(rowtp) : 줄 종류별 { fill, color, bold }
    var writeTable = function (sheet, gridId, heads, cols, headStyle, look) {
        for (var h = 0; h < heads.length; h++) {
            var headRow = new xl.WorkbookRow();
            for (var c = 0; c < cols.length; c++) {
                var head = heads[h][c];
                var headCell = makeCell(head ? head.text : null, headStyle);
                if (head && head.colSpan) headCell.colSpan = head.colSpan;
                if (head && head.rowSpan) headCell.rowSpan = head.rowSpan;
                headRow.cells.push(headCell);
            }
            sheet.rows.push(headRow);
        }

        var flex = ItsGrid.Get(gridId);
        var data = [];
        for (var i = 0; i < ItsGrid.Length(gridId); i++) data.push(ItsGrid.GetRowData(gridId, i));

        // 병합 칸: k 번째 줄이 바로 윗줄과 (앞쪽 병합 칸까지 포함해) 같은 값인지
        var sameAsAbove = function (k, c) {
            if (k == 0 || data[k][cols[c].field] == null || data[k][cols[c].field] === '') return false;
            for (var j = 0; j <= c; j++) {
                if (cols[j].merge && data[k][cols[j].field] != data[k - 1][cols[j].field]) return false;
            }
            return true;
        };

        for (var r = 0; r < data.length; r++) {
            var rowLook = look(data[r].ROWTP) || {};
            var dataRow = new xl.WorkbookRow();
            for (var c = 0; c < cols.length; c++) {
                var col = cols[c];
                var style = makeStyle({
                    bold: rowLook.bold, color: rowLook.color, fill: rowLook.fill, border: true,
                    align: col.align || (col.type == 'text' ? 'left' : 'right'),
                    format: FORMAT[col.type]
                });

                var value = data[r][col.field];
                var gridCol = flex.getColumn(col.field);
                if (gridCol && gridCol.dataMap && value != null && value !== '') value = gridCol.dataMap.getDisplayValue(value);   // 통화·변동사유는 코드 대신 이름
                if (col.type != 'text') value = (value == null || value === '') ? null : Number(value);
                if (col.type == 'rate' && value != null) value = value / 100;

                if (col.merge && sameAsAbove(r, c)) {   // 윗줄 칸에 병합돼 가려지는 자리
                    dataRow.cells.push(makeCell(null, style));
                    continue;
                }
                var cell = makeCell(value, style);
                if (col.merge) {
                    var span = 1;
                    while (r + span < data.length && sameAsAbove(r + span, c)) span++;
                    if (span > 1) cell.rowSpan = span;
                }
                dataRow.cells.push(cell);
            }
            sheet.rows.push(dataRow);
        }
    };
    var oneHead = function (labels) {
        return [labels.map(function (text) { return { text: text }; })];
    };

    // 메인 시트 (양식 "표지"): 제목 칸은 진한 청회색, Total·합계 줄은 회색
    var mainSheet = new xl.WorkSheet();
    mainSheet.name = '메인';
    [130, 170, 130, 130, 130, 90].forEach(function (width, c) {
        mainSheet.columns[c] = new xl.WorkbookColumn();
        mainSheet.columns[c].width = width;
    });
    var mainHead = makeStyle({ fill: '#333F4F', color: '#FFFFFF', align: 'center', border: true });
    var mainLook = function (rowtp) {
        if (rowtp == 'G') return { fill: '#BFBFBF' };
        if (rowtp == 'T') return { fill: '#D9D9D9' };
        return null;
    };
    var blankRow = function (sheet) { sheet.rows.push(new xl.WorkbookRow()); };

    addTitle(mainSheet, '▣ ' + month.substring(0, 4) + '年 ' + month.substring(5, 7) + '月 판매계획 대비 출하실적', 14, 0);
    blankRow(mainSheet);

    addTitle(mainSheet, '1. 판매계획 대비 출하실적 현황', 11, 4);
    writeTable(mainSheet, 'grid_GUBUN', oneHead(['구분', '판매계획', '출하금액', '차액', '달성율(%)']), [
        { field: 'DEBCNM', type: 'text', align: 'center' },
        { field: 'PLANAMT', type: 'amt' },
        { field: 'RSTAMT', type: 'amt' },
        { field: 'DIFFAMT', type: 'diff' },
        { field: 'RATE', type: 'rate', align: 'center' }
    ], mainHead, mainLook);
    blankRow(mainSheet);

    addTitle(mainSheet, '2. 고객사별 계획 대비 실적 현황', 11, 4);
    writeTable(mainSheet, 'grid_CUST', oneHead(['구분', '고객사', '판매계획', '출하금액', '달성율(%)']), [
        { field: 'DEBCNM', type: 'text', align: 'center', merge: true },
        { field: 'CUSTNM', type: 'text', align: 'center' },
        { field: 'PLANAMT', type: 'amt' },
        { field: 'RSTAMT', type: 'amt' },
        { field: 'RATE', type: 'rate', align: 'center' }
    ], mainHead, mainLook);
    blankRow(mainSheet);

    addTitle(mainSheet, '3. 변동사유 기준', 11, 3);
    writeTable(mainSheet, 'grid_REASON', oneHead(['변동사유', '판매계획', '출하실적', '차액']), [
        { field: 'OUTCHGNM', type: 'text', align: 'center' },
        { field: 'PLANAMT', type: 'amt' },
        { field: 'RSTAMT', type: 'amt' },
        { field: 'DIFFAMT', type: 'diff' }
    ], mainHead, mainLook);
    blankRow(mainSheet);

    addTitle(mainSheet, '4. 판매계획 대비 실적', 11, 5);
    writeTable(mainSheet, 'grid_PLAN', oneHead(['판매계획(A)', '조정대상 사유', '조정대상 차액(B)', '판매계획(A+B)', '출하실적', '달성율(%)']), [
        { field: 'PLANAMT', type: 'amt' },
        { field: 'ADJNM', type: 'text', align: 'center' },
        { field: 'ADJAMT', type: 'diff' },
        { field: 'ADJPLANAMT', type: 'diff' },
        { field: 'RSTAMT', type: 'amt' },
        { field: 'RATE', type: 'rate', align: 'center' }
    ], mainHead, mainLook);

    // 세부내역 시트 (양식 "세부내역"): 제목 칸은 연한 청회색, 고객사 Total 연두, 구분 Total 진한 연두, Grand Total 남색
    var detailSheet = new xl.WorkSheet();
    detailSheet.name = '세부내역';
    [90, 160, 230, 120, 50, 75, 75, 80, 110, 80, 110, 65, 80, 110, 95, 250, 250, 150].forEach(function (width, c) {
        detailSheet.columns[c] = new xl.WorkbookColumn();
        detailSheet.columns[c].width = width;
    });
    addTitle(detailSheet, '■ (' + month.substring(0, 4) + '년 ' + Number(month.substring(5, 7)) + '월) 출하계획 대비 실적', 14, 0);
    blankRow(detailSheet);

    var detailHeads = [
        ['구분', '고객사', '품명', '품번', '통화', '외화단가', '단가'].map(function (text) { return { text: text, rowSpan: 2 }; })
            .concat([{ text: '계획', colSpan: 2 }, null, { text: '실적', colSpan: 2 }, null,
                     { text: '달성율(%)', rowSpan: 2 }, { text: '차이', colSpan: 2 }, null])
            .concat(['변동사유', '미 출고 원인', '대책', '비고'].map(function (text) { return { text: text, rowSpan: 2 }; })),
        [null, null, null, null, null, null, null,
         { text: '수량(EA)' }, { text: '금액(원)' }, { text: '수량(EA)' }, { text: '금액(원)' }, null,
         { text: '수량(EA)' }, { text: '금액(원)' }, null, null, null, null]
    ];
    writeTable(detailSheet, 'grid_DETAIL', detailHeads, [
        { field: 'DEBCNM', type: 'text', align: 'center', merge: true },
        { field: 'CUSTNM', type: 'text', merge: true },
        { field: 'ITEMNM', type: 'text' },
        { field: 'ITEMCD', type: 'text' },
        { field: 'CURYBC', type: 'text', align: 'center' },
        { field: 'FUP', type: 'fup' },
        { field: 'UP', type: 'amt' },
        { field: 'PLANQTY', type: 'amt' },
        { field: 'PLANAMT', type: 'amt' },
        { field: 'RSTQTY', type: 'amt' },
        { field: 'RSTAMT', type: 'amt' },
        { field: 'RATE', type: 'rate', align: 'center' },
        { field: 'DIFFQTY', type: 'diff' },
        { field: 'DIFFAMT', type: 'diff' },
        { field: 'OUTCHGTP', type: 'text', align: 'center' },
        { field: 'NOOUTCAUSE', type: 'text' },
        { field: 'MEASURE', type: 'text' },
        { field: 'REMARK', type: 'text' }
    ], makeStyle({ fill: '#D6DCE4', bold: true, align: 'center', border: true }), function (rowtp) {
        if (rowtp == 'C') return { fill: '#E2EFDA' };
        if (rowtp == 'G') return { fill: '#A9D08E' };
        if (rowtp == 'T') return { fill: '#002060', color: '#FFFFFF' };
        return null;
    });
    // 제목·빈 줄·머리글 2줄은 고정
    detailSheet.frozenPane = new xl.WorkbookFrozenPane();
    detailSheet.frozenPane.rows = 4;
    detailSheet.frozenPane.columns = 0;

    var book = new xl.Workbook();
    book.sheets.push(mainSheet);
    book.sheets.push(detailSheet);
    book.saveAsync('판매계획대비 출하실적_' + month + '.xlsx');
};

/* 저장: 상세탭 품목 줄의 변동사유·미출고원인·대책·비고 (네 칸이 다 비면 지운다) */
ItsButton.EventSave = function () {
    ItsGrid.FinishEditing('grid_DETAIL');

    var maria = new ItsMaria('SAL3002_S02', 'SAVE');
    maria.AddPanel('sdiv1');
    var cnt = 0;
    for (var i = 0; i < ItsGrid.Length('grid_DETAIL'); i++) {
        var row = ItsGrid.GetRowData('grid_DETAIL', i);
        if (row.ROWTP != 'D') continue;
        maria.AddList('CUSTCD_LIST', row.CUSTCD);
        maria.AddList('ITEMID_LIST', row.ITEMID);
        maria.AddList('OUTCHGTP_LIST', row.OUTCHGTP);
        maria.AddList('NOOUTCAUSE_LIST', row.NOOUTCAUSE);
        maria.AddList('MEASURE_LIST', row.MEASURE);
        maria.AddList('REMARK_LIST', row.REMARK);
        cnt++;
    }
    if (cnt == 0) {
        ItsMsg.Alert('저장할 품목이 없습니다. 먼저 조회하세요.');
        return;
    }

    ItsMsg.Confirm('저장하시겠습니까?', function () {
        maria.CallProc();
        if (maria.isError) {
            maria.ShowErrMsg();
            return;
        }
        ItsMsg.Toast(ItsMsg.CommonMsg.SaveComplete(cnt));
        ItsButton.EventSearch();
    });
};

/* 삭제: 상세탭에서 체크한 품목 줄들의 변동사유·미출고원인·대책·비고 (합계 줄은 건너뛴다) */
ItsButton.EventDelete = function () {
    if (ItsTab.GetIndex('tab1') != 1) {
        ItsMsg.Alert('상세탭에서 삭제할 품목 줄을 체크하세요.');
        return;
    }
    ItsGrid.FinishEditing('grid_DETAIL');

    var maria = new ItsMaria('SAL3002_S02', 'DELETE');
    maria.AddPanel('sdiv1');
    var cnt = 0;
    for (var i = 0; i < ItsGrid.Length('grid_DETAIL'); i++) {
        if (!ItsGrid.IsChecked('grid_DETAIL', i)) continue;
        var row = ItsGrid.GetRowData('grid_DETAIL', i);
        if (row.ROWTP != 'D') continue;
        maria.AddList('CUSTCD_LIST', row.CUSTCD);
        maria.AddList('ITEMID_LIST', row.ITEMID);
        cnt++;
    }
    if (cnt == 0) {
        ItsMsg.Alert('삭제할 품목 줄을 체크하세요.');
        return;
    }

    ItsMsg.Confirm('체크한 ' + cnt + '건의 변동사유·미출고원인·대책·비고를 삭제하시겠습니까?', function () {
        maria.CallProc();
        if (maria.isError) {
            maria.ShowErrMsg();
            return;
        }
        ItsMsg.Toast(ItsMsg.CommonMsg.DeleteComplete(cnt));
        ItsButton.EventSearch();
    });
};
