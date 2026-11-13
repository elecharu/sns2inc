/* PRD1001_R04: 생산관리 ▶ 주간출하계획등록 */
/* 생산관리팀 출하계획 엑셀(수출 / 내수)을 올려 화면에 보여주고, 틀린 곳을 고친 뒤 SALOUTPLAN_W 에 저장한다. */
/* 저장은 추가만 한다 (기존 출하계획은 지우지 않음, 2026-11-12 사용자 지시). 고치려면 메인 화면에서 삭제 후 다시 올린다. */

/// <reference path="../../Script/reference.js" />

var CUST_LIST = [];        // 거래처 목록 (엑셀 거래처명과 가장 비슷한 거래처 찾기용, MATCH 결과셋 2)
var UPLOAD_TP = '';        // 올린 엑셀 구분 (EXP 수출 / DOM 내수)

/* 페이지 로드 시 수행 */
ItsPage.Load = function () {

    ItsGrid.Create('grid1', { isCheckBoxGrid: true }, [
        column.create('구분', 'OUTPLANTPNM', { width: 50, align: 'center' }),
        column.create('출하일자', 'OUTDATE', { width: 85, align: 'center' }),
        column.create('거래처', 'CUSTNM', { width: 140 }),
        column.create('고객', 'ENDCUSTNM', { width: 120 }),
        column.create('품번', 'ITEMCD', { width: 120 }),
        column.create('품명', 'ITEMNM', { width: 180 }),
        column.create('출하수량', 'PLANQTY', { width: 80, columnType: enumColumnTypes.number, decimalPrecision: 0 }),
        column.create('적입수량', 'PACKQTY', { width: 70, columnType: enumColumnTypes.number, decimalPrecision: 0 }),
        column.create('파렛트수', 'PLTQTY', { width: 70, columnType: enumColumnTypes.number, decimalPrecision: 0 }),
        column.create('출하시간', 'OUTTIME', { width: 120, align: 'center' }),
        column.create('도착시간', 'ARRVTIME', { width: 120, align: 'center' }),
        column.create('비고', 'REMARK', { width: 200 }),
        column.create('등록시간', 'RTIME', { width: 130, align: 'center' }),
        column.create('출하계획키', 'SALOUTPLANKEY', { width: 80, hidden: true }),
        column.split()
    ]);

    // 체크된 줄만 저장한다. 엑셀에서 읽은 줄은 전부 체크된 채로 나온다
    // 확인 칸에 문구가 있는 줄은 저장 안 됨 (고치거나 체크를 끈다)
    // 글자색: 확인 칸 빨강, 엑셀에서 읽은 그대로인 칸(엑셀~, 고칠 수 없음) 초록
    ItsGrid.Create('grid2', { isCheckBoxGrid: true }, [
        column.create('확인', 'MSG', { width: 170, foreColor: 'red' }),
        column.create('엑셀행', 'XLSROW', { width: 50, align: 'center', foreColor: 'green' }),
        column.create('출하일자', 'OUTDATE', { width: 85, align: 'center', readOnly: false }),
        column.create('엑셀 거래처', 'CUSTNM_XLS', { width: 130, foreColor: 'green' }),
        // 거래처·고객은 코드·명칭 어느 칸이든 더블클릭(또는 Enter)으로 찾기 팝업에서 고른다
        column.create('거래처코드', 'CUSTCD', { width: 80, align: 'center', columnType: enumColumnTypes.find, readOnly: false  }),
        column.create('거래처명', 'CUSTNM', { width: 150, columnType: enumColumnTypes.find }),
        column.create('엑셀 고객', 'ENDCUSTNM_XLS', { width: 100, foreColor: 'green' }),
        column.create('고객코드', 'ENDCUSTCD', { width: 80, align: 'center', columnType: enumColumnTypes.find, readOnly: false  }),
        column.create('고객명', 'ENDCUSTNM', { width: 150, columnType: enumColumnTypes.find }),
        column.create('엑셀 품번', 'ITEMCD_XLS', { width: 110, foreColor: 'green' }),
        // 품번·품명도 더블클릭(또는 Enter)으로 품목 찾기 팝업. 품번은 직접 입력·붙여넣기도 된다
        column.create('품번', 'ITEMCD', { width: 110, columnType: enumColumnTypes.find, readOnly: false }),
        column.create('엑셀 품명', 'ITEMNM_XLS', { width: 150, foreColor: 'green' }),
        column.create('품명', 'ITEMNM', { width: 150, columnType: enumColumnTypes.find }),
        column.create('출하수량', 'PLANQTY', { width: 75, columnType: enumColumnTypes.number, decimalPrecision: 0, readOnly: false }),
        column.create('적입수량', 'PACKQTY', { width: 65, columnType: enumColumnTypes.number, decimalPrecision: 0, readOnly: false }),
        column.create('파렛트수', 'PLTQTY', { width: 65, columnType: enumColumnTypes.number, decimalPrecision: 0, readOnly: false }),
        column.create('출하시간', 'OUTTIME', { width: 120, align: 'center', readOnly: false }),
        column.create('도착시간', 'ARRVTIME', { width: 120, align: 'center', readOnly: false }),
        column.create('비고', 'REMARK', { width: 200, readOnly: false }),
        column.create('품목ID', 'ITEMID', { width: 70, hidden: true }),
        column.split()
    ]);

    ItsDateRange.SetValueFrom('dr_DATE', ItsHelper.AddDay(-7, ItsHelper.GetYearMonthDay()));
    ItsDateRange.SetValueTo('dr_DATE', ItsHelper.AddDay(14, ItsHelper.GetYearMonthDay()));

    ItsButton.EventSearch();
};

/* 조회: 저장된 출하계획 */
ItsButton.EventSearch = function () {
    var maria = new ItsMaria('PRD1001_R04', 'LIST');
    maria.AddPanel('sdiv1');
    maria.CallProc();
    if (maria.isError) {
        maria.ShowErrMsg();
        return;
    }
    ItsGrid.SetStore('grid1', maria.store);
    ItsGrid.Get('grid1').autoSizeColumns();
    ItsMsg.Toast(ItsMsg.CommonMsg.SearchComplete(maria.store.Length()));
};

/* 추가: 엑셀 올리기 팝업 */
ItsButton.EventAdd = function () {
    UPLOAD_TP = '';
    ItsText.SetValue('txt_OUTPLANTPNM', '');
    ItsText.SetValue('txt_FILENAME', '');
    ItsGrid.Clear('grid2');
    ItsPop.Open('pop1');
};

/* 삭제: 체크한 출하계획 */
ItsButton.EventDelete = function () {
    if (!ItsGrid.HasChecked('grid1')) {
        ItsMsg.Alert('삭제할 출하계획을 체크하세요.');
        return;
    }

    ItsMsg.Confirm('체크한 출하계획을 삭제하시겠습니까?', function () {
        var maria = new ItsMaria('PRD1001_R04', 'DELETE');
        var cnt = 0;
        for (var i = 0; i < ItsGrid.Length('grid1'); i++) {
            if (ItsGrid.IsChecked('grid1', i)) {
                maria.AddList('SALOUTPLANKEY_LIST', ItsGrid.GetValue('grid1', i, 'SALOUTPLANKEY'));
                cnt++;
            }
        }
        maria.CallProc();
        if (maria.isError) {
            maria.ShowErrMsg();
            return;
        }
        ItsMsg.Toast(ItsMsg.CommonMsg.DeleteComplete(cnt));
        ItsButton.EventSearch();
    });
};

/* 수출 / 내수 엑셀 올리기: 파일 선택 창을 연다 */
ItsButton.Event('btn_UPLOAD_EXP').onClick = function () {
    $('#file_EXP').val('').trigger('click');
};

ItsButton.Event('btn_UPLOAD_DOM').onClick = function () {
    $('#file_DOM').val('').trigger('click');
};

/* 파일을 고르면 엑셀을 읽어 grid2 에 보여준다 */
$(function () {
    $('#file_EXP').change(function () { READ_EXCEL(this, 'EXP'); });
    $('#file_DOM').change(function () { READ_EXCEL(this, 'DOM'); });
});

/* 저장: 체크된 줄을 추가 저장 (기존 출하계획은 지우지 않는다) */
ItsButton.Event('btn_SAVE_PLAN').onClick = function () {
    ItsGrid.FinishEditing('grid2');

    if (UPLOAD_TP == '') {
        ItsMsg.Alert('먼저 엑셀을 올리세요.');
        return;
    }
    if (!ItsGrid.HasChecked('grid2')) {
        ItsMsg.Alert('저장할 줄을 체크하세요.');
        return;
    }

    var rows = [];
    var SDATE = '', EDATE = '';    // 저장한 출하일자 처음 ~ 끝 (저장 뒤 조회 기간)
    for (var i = 0; i < ItsGrid.Length('grid2'); i++) {
        if (!ItsGrid.IsChecked('grid2', i)) continue;

        var row = ItsGrid.GetRowData('grid2', i);
        if (row.ERRYN == 'Y') {
            ItsMsg.Alert('엑셀 ' + row.XLSROW + '행: ' + row.MSG + '\n고치거나 체크를 끄세요.');
            return;
        }
        if (SDATE == '' || row.OUTDATE < SDATE) SDATE = row.OUTDATE;
        if (EDATE == '' || row.OUTDATE > EDATE) EDATE = row.OUTDATE;
        rows.push(row);
    }

    ItsMsg.Confirm(rows.length + '건을 저장하시겠습니까?', function () {
        var maria = new ItsMaria('PRD1001_R04', 'SAVE');
        maria.AddParam('OUTPLANTP', UPLOAD_TP);
        for (var k = 0; k < rows.length; k++) {
            maria.AddList('OUTDATE_LIST', rows[k].OUTDATE);
            maria.AddList('CUSTCD_LIST', rows[k].CUSTCD);
            maria.AddList('ENDCUSTCD_LIST', rows[k].ENDCUSTCD);
            maria.AddList('ITEMID_LIST', rows[k].ITEMID);
            maria.AddList('PLANQTY_LIST', rows[k].PLANQTY);
            maria.AddList('PACKQTY_LIST', rows[k].PACKQTY);
            maria.AddList('PLTQTY_LIST', rows[k].PLTQTY);
            maria.AddList('OUTTIME_LIST', rows[k].OUTTIME);
            maria.AddList('ARRVTIME_LIST', rows[k].ARRVTIME);
            maria.AddList('REMARK_LIST', rows[k].REMARK);
        }
        maria.CallProc();
        if (maria.isError) {
            maria.ShowErrMsg();
            return;
        }
        ItsPop.Close('pop1');
        ItsMsg.Toast(ItsMsg.CommonMsg.SaveComplete(rows.length));

        ItsDateRange.SetValueFrom('dr_DATE', SDATE);
        ItsDateRange.SetValueTo('dr_DATE', EDATE);
        //ItsCombo.SetValue('cmb_OUTPLANTP', UPLOAD_TP);
        ItsButton.EventSearch();
    });
};

/* 고친 줄 다시 확인. 품번을 고치면 품목을, 거래처코드·고객코드를 고치면 이름을 다시 찾는다
   ) 붙여넣기 중(그리드가 값을 넣는 도중)에 바꾸면 반영이 안 되므로 붙여넣기가 끝난 뒤(setTimeout)에 처리한다 */
ItsGrid.Event('grid2').onChanged = function (rowIndex, field, newValue, oldValue, type) {
    setTimeout(function () {
        var row = ItsGrid.GetRowData('grid2', rowIndex);   // 복사본이라 바꾼 값은 SetValue 로 다시 넣는다

        if (field == 'ITEMCD') {
            var maria = new ItsMaria('PRD1001_R04', 'MATCH');
            maria.AddList('ITEMCD_LIST', $.trim(row.ITEMCD));
            maria.CallProc();
            if (maria.isError) {
                maria.ShowErrMsg();
                return;
            }
            row.ITEMCD = maria.store.data[0].ITEMCD;   // 매칭된 품번 (못 찾으면 빈칸)
            row.ITEMID = maria.store.data[0].ITEMID;
            row.ITEMNM = maria.store.data[0].ITEMNM;
            ItsGrid.SetValue('grid2', rowIndex, 'ITEMCD', row.ITEMCD);
            ItsGrid.SetValue('grid2', rowIndex, 'ITEMID', row.ITEMID);
            ItsGrid.SetValue('grid2', rowIndex, 'ITEMNM', row.ITEMNM);
        }
        else if (field == 'CUSTCD' || field == 'ENDCUSTCD') {
            // 코드로 이름 찾기 (CUST_LIST = 법인 60 거래처). 못 찾으면 이름을 비운다
            var nmField = (field == 'CUSTCD') ? 'CUSTNM' : 'ENDCUSTNM';
            var code = $.trim(row[field]);
            var name = '';
            for (var i = 0; i < CUST_LIST.length; i++) {
                if (CUST_LIST[i].CUSTCD == code) { name = CUST_LIST[i].CUSTNM; break; }
            }
            row[field] = code;
            row[nmField] = name;
            ItsGrid.SetValue('grid2', rowIndex, field, code);
            ItsGrid.SetValue('grid2', rowIndex, nmField, name);
        }

        CHECK_ROW(row);
        ItsGrid.SetValue('grid2', rowIndex, 'ERRYN', row.ERRYN);
        ItsGrid.SetValue('grid2', rowIndex, 'MSG', row.MSG);
        ItsGrid.Get('grid2').autoSizeColumns();
    }, 0);
};

/* 품목·거래처·고객 찾기 팝업 (더블클릭 또는 Enter) */
ItsGrid.Event('grid2').onDoubleClick = function (rowIndex, field) {
    ItsGrid.Event('grid2').onKeydownEnter(rowIndex, field);
};

ItsGrid.Event('grid2').onKeydownEnter = function (rowIndex, field) {
    if (field == 'ITEMCD' || field == 'ITEMNM') {
        // 법인 60 사용 중 품목. 검색어는 품번, 비었으면 엑셀 품번 (결과가 1건이면 팝업이 바로 고른다)
        var keyword = ItsGrid.GetValue('grid2', rowIndex, 'ITEMCD') || ItsGrid.GetValue('grid2', rowIndex, 'ITEMCD_XLS') || '';

        ItsPop.OpenFindCOM({ gpcd: 'ITEMID', ref01: '60', keyword: keyword }, function (res) {
            var row = ItsGrid.GetRowData('grid2', rowIndex);   // 복사본이라 바꾼 값은 SetValue 로 다시 넣는다
            row.ITEMID = res['CODE'];     // DC_FIND ITEMID: CODE = 품목ID, NAME = 품번, REF01 = 품명
            row.ITEMCD = res['NAME'];
            row.ITEMNM = res['REF01'];
            ItsGrid.SetValue('grid2', rowIndex, 'ITEMID', row.ITEMID);
            ItsGrid.SetValue('grid2', rowIndex, 'ITEMCD', row.ITEMCD);
            ItsGrid.SetValue('grid2', rowIndex, 'ITEMNM', row.ITEMNM);

            CHECK_ROW(row);
            ItsGrid.SetValue('grid2', rowIndex, 'ERRYN', row.ERRYN);
            ItsGrid.SetValue('grid2', rowIndex, 'MSG', row.MSG);
            ItsGrid.Get('grid2').autoSizeColumns();
        });
        return;
    }

    if (field != 'CUSTCD' && field != 'CUSTNM' && field != 'ENDCUSTCD' && field != 'ENDCUSTNM') return;

    ItsPop.OpenFindCOM({ gpcd: 'CUSTCD_COMPANY', ref01: '60' }, function (res) {
        var row = ItsGrid.GetRowData('grid2', rowIndex);   // 복사본이라 바꾼 값은 SetValue 로 다시 넣는다
        if (field == 'CUSTCD' || field == 'CUSTNM') {
            row.CUSTCD = res['CODE'];
            row.CUSTNM = res['NAME'];
            ItsGrid.SetValue('grid2', rowIndex, 'CUSTCD', row.CUSTCD);
            ItsGrid.SetValue('grid2', rowIndex, 'CUSTNM', row.CUSTNM);
        }
        else {
            row.ENDCUSTCD = res['CODE'];
            row.ENDCUSTNM = res['NAME'];
            ItsGrid.SetValue('grid2', rowIndex, 'ENDCUSTCD', row.ENDCUSTCD);
            ItsGrid.SetValue('grid2', rowIndex, 'ENDCUSTNM', row.ENDCUSTNM);
        }

        CHECK_ROW(row);
        ItsGrid.SetValue('grid2', rowIndex, 'ERRYN', row.ERRYN);
        ItsGrid.SetValue('grid2', rowIndex, 'MSG', row.MSG);
        ItsGrid.Get('grid2').autoSizeColumns();   // 바뀐 거래처명·확인 글자에 맞춰 컬럼 너비 다시 맞춤
    });
};

/* ---------------------------------------------------------------------------------------------------- */

/* 엑셀 파일 읽기 → 수출 / 내수 양식대로 줄 만들기 → 품목·거래처 찾기 → grid2 */
function READ_EXCEL(fileInput, tp) {
    if (fileInput.files.length == 0) return;

    var file = fileInput.files[0];
    var reader = new FileReader();

    parent.wait_start();
    reader.onload = function (evt) {
        var rows = [];
        try {
            var workbook = XLSX.read(new Uint8Array(evt.target.result), { type: 'array' });
            rows = (tp == 'EXP') ? PARSE_EXP(workbook) : PARSE_DOM(workbook);
        } catch (e) {
            try { parent.wait_end(); } catch (e2) { }
            ItsMsg.Alert(e.message || '엑셀 파일을 읽지 못했습니다.');
            return;
        }

        if (rows.length == 0) {
            try { parent.wait_end(); } catch (e2) { }
            ItsMsg.Alert('출하수량이 있는 줄이 없습니다.');
            return;
        }

        // 품번 → 품목ID·품명, 거래처 목록
        var maria = new ItsMaria('PRD1001_R04', 'MATCH');
        for (var i = 0; i < rows.length; i++) {
            maria.AddList('ITEMCD_LIST', rows[i].ITEMCD);
        }
        maria.CallProc();
        if (maria.isError) {
            try { parent.wait_end(); } catch (e2) { }
            maria.ShowErrMsg();
            return;
        }
        CUST_LIST = maria.storeExtend1.data;

        for (var i = 0; i < rows.length; i++) {
            rows[i].ITEMCD = maria.store.data[i].ITEMCD;   // 매칭된 품번 (못 찾으면 빈칸, 엑셀 원문은 ITEMCD_XLS)
            rows[i].ITEMID = maria.store.data[i].ITEMID;
            rows[i].ITEMNM = maria.store.data[i].ITEMNM;

            var cust = FIND_CUST(rows[i].CUSTNM_XLS);
            rows[i].CUSTCD = cust.CUSTCD;
            rows[i].CUSTNM = cust.CUSTNM;

            var endCust = FIND_CUST(rows[i].ENDCUSTNM_XLS);
            rows[i].ENDCUSTCD = endCust.CUSTCD;
            rows[i].ENDCUSTNM = endCust.CUSTNM;

            CHECK_ROW(rows[i]);
        }

        var $store = new Store();
        $store.data = rows;
        ItsGrid.SetStore('grid2', $store);

        // 수출은 고객·적입수량·파렛트수, 내수는 출하·도착시간만 쓴다
        var isExp = (tp == 'EXP');
        ItsGrid.Get('grid2').columns[ItsGrid.$colIndex('grid2', 'ENDCUSTNM_XLS')].visible = isExp;
        ItsGrid.Get('grid2').columns[ItsGrid.$colIndex('grid2', 'ENDCUSTCD')].visible = isExp;
        ItsGrid.Get('grid2').columns[ItsGrid.$colIndex('grid2', 'ENDCUSTNM')].visible = isExp;
        ItsGrid.Get('grid2').columns[ItsGrid.$colIndex('grid2', 'PACKQTY')].visible = isExp;
        ItsGrid.Get('grid2').columns[ItsGrid.$colIndex('grid2', 'PLTQTY')].visible = isExp;
        ItsGrid.Get('grid2').columns[ItsGrid.$colIndex('grid2', 'OUTTIME')].visible = !isExp;
        ItsGrid.Get('grid2').columns[ItsGrid.$colIndex('grid2', 'ARRVTIME')].visible = !isExp;
        ItsGrid.Get('grid2').refresh();
        ItsGrid.Get('grid2').autoSizeColumns();   // 컬럼 너비를 읽은 내용에 맞춘다

        UPLOAD_TP = tp;
        ItsText.SetValue('txt_OUTPLANTPNM', isExp ? '수출' : '내수');
        ItsText.SetValue('txt_FILENAME', file.name);

        try { parent.wait_end(); } catch (e2) { }
        // 토스트는 본문(#MAIN_TOAST)에 떠서 팝업에 가려지므로 확인창으로 알린다
        ItsMsg.Alert('엑셀 ' + rows.length + '줄을 읽었습니다. 확인 칸을 보고 고친 뒤 저장하세요.');
    };
    reader.readAsArrayBuffer(file);
}

/* 수출 출하 확정물량 엑셀
   - '매출처' 머리글이 있는 시트를 읽는다 (시트 이름은 주차마다 바뀐다. 예: 11월(46주차))
   - 머리글 1줄째: 매출처, 고객, PART NO., Part Name, 적입수량, 출하일자 / 3줄째: 출하, Pallet수, 비고
   - 출하 수량이 있는 줄만. 아래 합계 줄·다른 시트(출하지 정보 등)는 읽지 않는다 */
function PARSE_EXP(workbook) {
    var ws = null, hr = -1;
    for (var s = 0; s < workbook.SheetNames.length && ws == null; s++) {
        var sheet = workbook.Sheets[workbook.SheetNames[s]];
        if (sheet['!ref'] == undefined) continue;
        var ref = XLSX.utils.decode_range(sheet['!ref']);
        for (var r = ref.s.r; r <= Math.min(ref.e.r, 20) && ws == null; r++) {
            for (var c = ref.s.c; c <= Math.min(ref.e.c, 10); c++) {
                if (XLS_KEY(sheet, r, c) == '매출처') { ws = sheet; hr = r; break; }
            }
        }
    }
    if (ws == null) throw new Error('수출 출하계획 양식이 아닙니다. (\'매출처\' 머리글을 찾지 못했습니다)');

    var ref = XLSX.utils.decode_range(ws['!ref']);
    var col = {};
    for (var c = ref.s.c; c <= ref.e.c; c++) {
        var h1 = XLS_KEY(ws, hr, c), h3 = XLS_KEY(ws, hr + 2, c);
        if (h1 == '매출처') col.CUST = c;
        else if (h1 == '고객') col.ENDCUST = c;
        else if (h1 == 'PARTNO.') col.ITEMCD = c;
        else if (h1 == 'PARTNAME') col.ITEMNM = c;
        else if (h1.indexOf('적입수량') == 0) col.PACKQTY = c;
        else if (h1 == '출하일자') col.OUTDATE = c;
        if (h3 == '출하') col.PLANQTY = c;
        else if (h3 == 'PALLET수') col.PLTQTY = c;
        else if (h3 == '비고' && col.REMARK == undefined) col.REMARK = c;
    }
    var need = { CUST: '매출처', ENDCUST: '고객', ITEMCD: 'PART NO.', OUTDATE: '출하일자', PLANQTY: '출하', PLTQTY: 'Pallet수' };
    for (var k in need) {
        if (col[k] == undefined) throw new Error('수출 엑셀에서 \'' + need[k] + '\' 칸을 찾지 못했습니다.');
    }

    var rows = [];
    for (var r = hr + 3; r <= ref.e.r; r++) {
        var ITEMCD = XLS_TEXT(ws, r, col.ITEMCD);
        var PLANQTY = XLS_NUM(ws, r, col.PLANQTY);
        if (ITEMCD == '' || !(PLANQTY > 0)) continue;

        rows.push({
            isRowCheck: true,
            XLSROW: r + 1,
            OUTDATE: XLS_DATE(ws, r, col.OUTDATE),
            CUSTNM_XLS: XLS_TEXT(ws, r, col.CUST),
            ENDCUSTNM_XLS: XLS_TEXT(ws, r, col.ENDCUST),
            ITEMCD_XLS: ITEMCD,
            ITEMCD: ITEMCD,
            ITEMNM_XLS: col.ITEMNM == undefined ? '' : XLS_TEXT(ws, r, col.ITEMNM),
            PLANQTY: PLANQTY,
            PACKQTY: col.PACKQTY == undefined ? 0 : XLS_NUM(ws, r, col.PACKQTY),
            PLTQTY: XLS_NUM(ws, r, col.PLTQTY),
            OUTTIME: '',
            ARRVTIME: '',
            REMARK: col.REMARK == undefined ? '' : XLS_TEXT(ws, r, col.REMARK)
        });
    }
    return rows;
}

/* 내수 출하계획 엑셀
   - 첫 번째 시트만 읽는다 (CTR 시트·순회차량 운행일정·Sheet2 는 읽지 않음, 2026-11-12 사용자 지시)
   - 머리글: 고객사, 품명, 품번, 날짜 칸마다 [수량, 출하, 도착] 3칸, 비고
   - 날짜별로 수량이 있는 칸마다 한 줄. 출하·도착은 'YYYY-MM-DD HH:mm' (명일이면 다음날) */
function PARSE_DOM(workbook) {
    var ws = workbook.Sheets[workbook.SheetNames[0]];
    if (ws == undefined || ws['!ref'] == undefined) throw new Error('첫 번째 시트가 비어 있습니다.');

    var ref = XLSX.utils.decode_range(ws['!ref']);
    var hr = -1;
    for (var r = ref.s.r; r <= Math.min(ref.e.r, 20) && hr == -1; r++) {
        for (var c = ref.s.c; c <= Math.min(ref.e.c, 10); c++) {
            if (XLS_KEY(ws, r, c) == '고객사') { hr = r; break; }
        }
    }
    if (hr == -1) throw new Error('내수 출하계획 양식이 아닙니다. (첫 번째 시트에서 \'고객사\' 머리글을 찾지 못했습니다)');

    var col = {}, dateCols = [];
    for (var c = ref.s.c; c <= ref.e.c; c++) {
        var h = XLS_KEY(ws, hr, c);
        if (h == '고객사') col.CUST = c;
        else if (h == '품번') col.ITEMCD = c;
        else if (h == '품명') col.ITEMNM = c;
        else if (h == '비고') col.REMARK = c;
        else if (XLS_DATE(ws, hr, c) != '') dateCols.push({ C: c, DATE: XLS_DATE(ws, hr, c) });
    }
    if (col.CUST == undefined || col.ITEMCD == undefined) throw new Error('내수 엑셀에서 \'고객사\', \'품번\' 칸을 찾지 못했습니다.');
    if (dateCols.length == 0) throw new Error('내수 엑셀 머리글에서 날짜를 찾지 못했습니다.');

    var rows = [];
    for (var r = hr + 2; r <= ref.e.r; r++) {
        var ITEMCD = XLS_TEXT(ws, r, col.ITEMCD);
        if (ITEMCD == '') continue;

        for (var d = 0; d < dateCols.length; d++) {
            var c = dateCols[d].C;
            var PLANQTY = XLS_NUM(ws, r, c);
            if (!(PLANQTY > 0)) continue;

            rows.push({
                isRowCheck: true,
                XLSROW: r + 1,
                OUTDATE: dateCols[d].DATE,
                CUSTNM_XLS: XLS_TEXT(ws, r, col.CUST),
                ENDCUSTNM_XLS: '',
                ITEMCD_XLS: ITEMCD,
                ITEMCD: ITEMCD,
                ITEMNM_XLS: col.ITEMNM == undefined ? '' : XLS_TEXT(ws, r, col.ITEMNM),
                PLANQTY: PLANQTY,
                PACKQTY: 0,
                PLTQTY: 0,
                OUTTIME: XLS_DATETIME(ws, r, c + 1, dateCols[d].DATE),
                ARRVTIME: XLS_DATETIME(ws, r, c + 2, dateCols[d].DATE),
                REMARK: col.REMARK == undefined ? '' : XLS_TEXT(ws, r, col.REMARK)
            });
        }
    }
    return rows;
}

/* 엑셀 셀 값 읽기 (r, c 는 0부터). 오류 셀(#REF! 등)은 빈 값 */
function XLS_TEXT(ws, r, c) {
    var cell = ws[XLSX.utils.encode_cell({ r: r, c: c })];
    if (cell == undefined || cell.t == 'e' || cell.v == undefined) return '';
    return $.trim(String(cell.v).replace(/\s+/g, ' '));
}

/* 머리글 비교용: 공백·줄바꿈 빼고 대문자 */
function XLS_KEY(ws, r, c) {
    return XLS_TEXT(ws, r, c).replace(/\s/g, '').toUpperCase();
}

function XLS_NUM(ws, r, c) {
    var cell = ws[XLSX.utils.encode_cell({ r: r, c: c })];
    if (cell == undefined) return 0;
    if (cell.t == 'n') return cell.v;
    if (cell.t == 's') {
        var n = parseFloat(cell.v.replace(/,/g, ''));
        return isNaN(n) ? 0 : n;
    }
    return 0;
}

/* 날짜 셀(엑셀 일련번호) → 'YYYY-MM-DD'. 날짜가 아니면 '' (시간만 있는 0:00 셀 포함) */
function XLS_DATE(ws, r, c) {
    var cell = ws[XLSX.utils.encode_cell({ r: r, c: c })];
    if (cell == undefined || cell.t != 'n' || cell.v < 1) return '';
    var d = new Date(Math.round((Math.floor(cell.v) - 25569) * 86400000));
    return d.getUTCFullYear() + '-' + ('0' + (d.getUTCMonth() + 1)).slice(-2) + '-' + ('0' + d.getUTCDate()).slice(-2);
}

/* 내수 출하·도착 시간 → 'YYYY-MM-DD HH:mm'
   '14시', '명일 08시', '10시 45분', '10시반', '14:30', 시간 셀 모두 받는다. '명일'·'익일'이면 출하일자 다음날
   못 바꾸면 엑셀 글자를 그대로 두고, 확인 칸에 '형식 오류'로 표시된다 */
function XLS_DATETIME(ws, r, c, baseDate) {
    var cell = ws[XLSX.utils.encode_cell({ r: r, c: c })];
    if (cell == undefined || cell.t == 'e') return '';

    var hh = -1, mm = 0, day = baseDate;
    if (cell.t == 'n') {
        var mins = Math.round((cell.v % 1) * 1440);
        hh = Math.floor(mins / 60);
        mm = mins % 60;
    } else {
        var s = XLS_TEXT(ws, r, c);
        if (s == '') return '';

        var m1 = s.match(/(\d{1,2})\s*:\s*(\d{2})/);
        var m2 = s.match(/(\d{1,2})\s*시\s*(?:(\d{1,2})\s*분|(반))?/);
        if (m1) { hh = parseInt(m1[1], 10); mm = parseInt(m1[2], 10); }
        else if (m2) { hh = parseInt(m2[1], 10); mm = m2[2] ? parseInt(m2[2], 10) : (m2[3] ? 30 : 0); }
        else return s;

        if (/명일|익일|다음\s*날/.test(s)) day = ItsHelper.AddDay(1, baseDate);
    }
    if (hh < 0 || hh > 23 || mm > 59) return XLS_TEXT(ws, r, c);

    return day + ' ' + ('0' + hh).slice(-2) + ':' + ('0' + mm).slice(-2);
}

/* 엑셀 거래처명과 가장 비슷한 거래처 (CUST_LIST = 법인 60 거래처)
   - 거래처명·영문명을 공백·괄호·(주) 빼고 비교
   - '이원(HMC)', '한온시스템_2WD', 'CTR(울산)-동우 HST' 처럼 뒤에 붙은 납품처는 떼고도 비교한다
   - 같은 이름이 없으면 글자 두 개씩 겹치는 정도로 가장 비슷한 곳 (너무 다르면 비워 둔다) */
function FIND_CUST(name) {
    if ($.trim(name) == '') return { CUSTCD: '', CUSTNM: '' };

    var norm = function (v) {
        return String(v || '').toUpperCase().replace(/\(주\)|㈜|주식회사|\s|[.,·]/g, '');
    };
    var bigram = function (v) {
        var list = [];
        for (var i = 0; i < v.length - 1; i++) list.push(v.substr(i, 2));
        return list.length == 0 ? [v] : list;
    };
    var similar = function (a, b) {
        if (a == '' || b == '') return 0;
        if (a == b) return 1;
        if (a.indexOf(b) > -1 || b.indexOf(a) > -1) return 0.8 * Math.min(a.length, b.length) / Math.max(a.length, b.length) + 0.2;
        var x = bigram(a), y = bigram(b).slice(), hit = 0;
        for (var i = 0; i < x.length; i++) {
            var p = y.indexOf(x[i]);
            if (p > -1) { hit++; y.splice(p, 1); }
        }
        return 2 * hit / (x.length + bigram(b).length) * 0.8;
    };

    // 엑셀 이름, 괄호·_·- 뒤를 뗀 이름
    var keys = [norm(name), norm(String(name).split(/[\(_\-]/)[0])];

    var best = { CUSTCD: '', CUSTNM: '', SCORE: 0 };
    for (var i = 0; i < CUST_LIST.length; i++) {
        var names = [norm(CUST_LIST[i].CUSTNM), norm(CUST_LIST[i].CUSTNMEN)];
        for (var a = 0; a < keys.length; a++) {
            for (var b = 0; b < names.length; b++) {
                var score = similar(keys[a], names[b]) - (a == 1 ? 0.01 : 0);   // 엑셀 이름 그대로 같은 쪽을 먼저
                if (score > best.SCORE) best = { CUSTCD: CUST_LIST[i].CUSTCD, CUSTNM: CUST_LIST[i].CUSTNM, SCORE: score };
            }
        }
    }

    if (best.SCORE < 0.4) return { CUSTCD: '', CUSTNM: '' };
    return { CUSTCD: best.CUSTCD, CUSTNM: best.CUSTNM };
}

/* 한 줄 확인 → 확인(MSG), 저장 막기(ERRYN)
   확인 칸에는 저장을 막는 문구만 쓴다 (자동으로 고른 거래처 등의 안내는 쓰지 않음, 2026-11-12 사용자 지시) */
function CHECK_ROW(row) {
    var err = [];
    var dt = /^\d{4}-\d{2}-\d{2} \d{2}:\d{2}$/;

    if (!/^\d{4}-\d{2}-\d{2}$/.test(row.OUTDATE || '')) err.push('출하일자 없음');
    if (row.ITEMID == undefined || row.ITEMID == '') err.push('품번 없음');
    if (row.CUSTCD == undefined || row.CUSTCD == '') err.push('거래처 없음');
    else if ((row.CUSTNM || '') == '') err.push('거래처코드 없음');
    if ((row.ENDCUSTNM_XLS || '') != '') {    // 고객은 수출만
        if (row.ENDCUSTCD == undefined || row.ENDCUSTCD == '') err.push('고객 없음');
        else if ((row.ENDCUSTNM || '') == '') err.push('고객코드 없음');
    }
    if (!(parseFloat(row.PLANQTY) > 0)) err.push('출하수량 없음');
    if ((row.OUTTIME || '') != '' && !dt.test(row.OUTTIME)) err.push('출하시간 형식 오류');
    if ((row.ARRVTIME || '') != '' && !dt.test(row.ARRVTIME)) err.push('도착시간 형식 오류');

    row.ERRYN = err.length > 0 ? 'Y' : 'N';
    row.MSG = err.join(', ');
}
