/// <reference path="../../Script/reference.js" />

/* 페이지 로드 시 수행 */
ItsPage.Load = function () {
    // 검사구분 그리드
    ItsGrid.Create('grid1', { isCheckBoxGrid: false }, [
        column.create("검사구분코드", "STDTP", { width: 110, align: 'center', hidden: false }),
        column.create("검사구분", "STDTPNM", { width: 110, align: 'center' }),
        column.split()
    ]);

    // 품목 리스트 그리드
    ItsGrid.Create('grid2', { isCheckBoxGrid: false }, [
        column.create("등록여부", "EXISTSYN", { width: 70, columnType: enumColumnTypes.check }),
        column.create('품목유형', 'ITEMCG', { width: 80, columnType: enumColumnTypes.combo, gpcd: 'DM100', align: 'center' }),
        column.create('품목ID', 'ITEMID', { width: 150, align: 'center' }),
        column.create('품목코드', 'ITEMCD', { width: 150 }),
        column.create('품명', 'ITEMNM', { width: 300 }),

        column.split()
    ]);

    // 리비전 리스트 그리드
    ItsGrid.Create('grid3', { isCheckBoxGrid: false }, [
        column.create('REVCD', 'REVCD', { width: 100, hidden: true }),
        column.create("사용중", "USEYN", { width: 50, columnType: enumColumnTypes.check }),
        column.create("리비전", "REVNUM", { width: 50, columnType: enumColumnTypes.number, decimalPrecision: 0 }),
        column.create("개정일", "REGDATE", { width: 95, align: 'center', columnType: enumColumnTypes.date, readOnly: false }),   // 갱신 시 오늘 날짜, 수정 가능
        column.create("작성자", "REVEMPNM", { width: 80, align: 'center', columnType: enumColumnTypes.combo, gpcd: 'EMPCD', readOnly: false }),                                      // 갱신 시 로그인 사용자, 수정 가능
        column.create("개정사유", "REVREASON", { width: 250, readOnly: false }),                                                   // 선택 입력
        column.split()
    ]);

    // 검사항목 리스트 그리드
    ItsGrid.Create('grid4', { isCheckBoxGrid: true }, [
        column.create('REVCD', 'REVCD', { width: 100, hidden: true }),
        column.create("검사항목코드", "STDCD", { width: 100, hidden: true }),
        column.create("검사항목", "STDNM", { width: 100}),
        column.create("세부항목", "STDPART", { width: 100, readOnly: false }),
        column.create("세부공정", "PRCDETAIL", { width: 100, columnType: enumColumnTypes.combo, gpcd: 'PRCDETAIL', readOnly: false, align: 'center' }),
        column.create("특성", "FEATURE", { width: 100, readOnly: false, align: 'center' }),
        column.create("검사방법", "STDCHKTP", { width: 100, columnType: enumColumnTypes.combo, gpcd: 'STDCHKTP', readOnly: false, align: 'center'}),
        column.create("측정기기", "STDMACHINE", { width: 100, columnType: enumColumnTypes.combo, gpcd: 'STDMACHINE', readOnly: false, align: 'center'}),
        column.create("측정부위", "STDPOINT", { width: 100, columnType: enumColumnTypes.combo, gpcd: 'STDPOINT', readOnly: false, align: 'center' }),
        column.create("검사주기", "STDCYCLE", { width: 100, columnType: enumColumnTypes.combo, gpcd: 'STDCYCLE', readOnly: false, align: 'center' }),
        column.band('판정기준', {}, [
            column.create('기준값', 'STDVAL', { width: 60, columnType: enumColumnTypes.number, decimalPrecision: 3, readOnly: false }),
            column.create("단위", "STDUNIT", { width: 60, columnType: enumColumnTypes.combo, gpcd: 'STDUNIT', align: 'center' }),
            column.create('범위', 'STDRANGE', { width: 60, columnType: enumColumnTypes.combo, gpcd: 'STDRANGE', readOnly: false, align: 'center' }),
            column.create('오차(-)', 'STDMINUS', { width: 60, columnType: enumColumnTypes.number, decimalPrecision: 3, readOnly: false }),
            column.create('오차(+)', 'STDPLUS', { width: 60, columnType: enumColumnTypes.number, decimalPrecision: 3, readOnly: false }),
            column.create('하한', 'STDLOWER', { width: 70, columnType: enumColumnTypes.number, decimalPrecision: 3 }),   // 자동계산 (기준값·범위·오차), 저장 안 함
            column.create('상한', 'STDUPPER', { width: 70, columnType: enumColumnTypes.number, decimalPrecision: 3 }),   // 자동계산 (기준값·범위·오차), 저장 안 함
            column.create('판정기준', 'STDJUDGE', { width: 300, readOnly: false, multiLine: true }),
        ]),

        column.create('시료수', 'SAMPLESIZE', { width: 60, columnType: enumColumnTypes.number, decimalPrecision: 2, readOnly: false }),
        column.create('정렬순서', 'SORTNO', { width: 70, readOnly: false, columnType: enumColumnTypes.number, decimalPrecision: 0 }),
        column.create('비고', 'REMARK', { width: 100, readOnly: false }),
        column.create('이미지', 'POP_IMG', { width: 70, columnType: enumColumnTypes.button, iconCls: 'fa-image' }),     // 이미지 팝업
        column.create('장수', 'IMGCNT', { width: 50, align: 'center', columnType: enumColumnTypes.number, decimalPrecision: 0 }),
        column.split()
    ]);

    // 검사항목 이미지 팝업 그리드 (항목당 여러 장)
    ItsGrid.Create('grid_IMG', { isCheckBoxGrid: false }, [
        column.create('순번', 'NO', { width: 50, align: 'center' }),
        column.create('파일명', 'FILENAME', { width: 300 }),
        column.create('FILEKEY', 'FILEKEY', { width: 100, hidden: true }),
        column.create('FILEURL', 'FILEURL', { width: 100, hidden: true }),
        column.split()
    ]);

    /*********************************************************************************************************************************************************************************/
    // 추가 팝업 그리드
    ItsGrid.Create('grid_STD', { isCheckBoxGrid: true }, [
        column.create("검사항목코드", "STDCD", { width: 100, hidden: true }),
        column.create("검사항목", "STDNM", { width: 100 }),
        column.create("검사방법", "STDCHKTP", { width: 100, columnType: enumColumnTypes.combo, gpcd: 'STDCHKTP', align: 'center' }),
        column.create("측정기기", "STDMACHINE", { width: 100, columnType: enumColumnTypes.combo, gpcd: 'STDMACHINE', align: 'center' }),
        column.create("측정부위", "STDPOINT", { width: 100, columnType: enumColumnTypes.combo, gpcd: 'STDPOINT', align: 'center' }),
        column.create("검사주기", "STDCYCLE", { width: 100, columnType: enumColumnTypes.combo, gpcd: 'STDCYCLE', align: 'center' }),
        column.band('판정기준', {}, [
            column.create("단위", "STDUNIT", { width: 60, columnType: enumColumnTypes.combo, gpcd: 'STDUNIT', align: 'center' }),
            column.create('범위', 'STDRANGE', { width: 60, columnType: enumColumnTypes.combo, gpcd: 'STDRANGE', align: 'center' }),
            column.create('판정기준', 'STDJUDGE', { width: 200 }),
        ]),
        column.create('시료수', 'SAMPLESIZE', { width: 60, columnType: enumColumnTypes.number, decimalPrecision: 2 }),
        column.create('비고', 'REMARK', { width: 100 }),
        column.split()
    ]);

    ///*********************************************************************************************************************************************************************************/
    // 복사 팝업 그리드
    ItsGrid.Create('grid2_COPY', { isCheckBoxGrid: false }, [
        column.create('품목유형', 'ITEMCG', { width: 80, columnType: enumColumnTypes.combo, gpcd: 'DM100', align: 'center' }),
        column.create('품목ID', 'ITEMID', { width: 150, hidden: true }),
        column.create('품목코드', 'ITEMCD', { width: 150 }),
        column.create('품명', 'ITEMNM', { width: 300 }),
        column.split()
    ]);

    ItsGrid.Create('grid3_COPY', { isCheckBoxGrid: false }, [
        column.create('REVCD', 'REVCD', { width: 100, hidden: true }),
        column.create("사용중", "USEYN", { width: 70, columnType: enumColumnTypes.check }),
        column.create("리비전", "REVNUM", { width: 60, columnType: enumColumnTypes.number, decimalPrecision: 0 }),
        column.split()
    ]);

    ItsGrid.Create('grid4_COPY', { isCheckBoxGrid: true }, [
        column.create('REVCD', 'REVCD', { width: 100, hidden: true }),
        column.create("검사항목코드", "STDCD", { width: 100, hidden: true }),
        column.create("검사항목", "STDNM", { width: 100 }),
        column.create("세부항목", "STDPART", { width: 100, align: 'center' }),
        column.create("검사방법", "STDCHKTP", { width: 100, columnType: enumColumnTypes.combo, gpcd: 'STDCHKTP', align: 'center' }),
        column.create("측정기기", "STDMACHINE", { width: 100, columnType: enumColumnTypes.combo, gpcd: 'STDMACHINE', align: 'center'}),
        column.create("측정부위", "STDPOINT", { width: 100, columnType: enumColumnTypes.combo, gpcd: 'STDPOINT', align: 'center' }),
        column.create("검사주기", "STDCYCLE", { width: 100, columnType: enumColumnTypes.combo, gpcd: 'STDCYCLE', align: 'center' }),
        column.band('판정기준', {}, [
            column.create('기준값', 'STDVAL', { width: 60, columnType: enumColumnTypes.number, decimalPrecision: 2}),
            column.create("단위", "STDUNIT", { width: 60, columnType: enumColumnTypes.combo, gpcd: 'STDUNIT', align: 'center' }),
            column.create('범위', 'STDRANGE', { width: 60, columnType: enumColumnTypes.combo, gpcd: 'STDRANGE', align: 'center' }),
            column.create('오차(-)', 'STDMINUS', { width: 60, columnType: enumColumnTypes.number, decimalPrecision: 2}),
            column.create('오차(+)', 'STDPLUS', { width: 60, columnType: enumColumnTypes.number, decimalPrecision: 2 }),
            column.create('판정기준', 'STDJUDGE', { width: 150,  multiLine: true }),
        ]),

        column.create('시료수', 'SAMPLESIZE', { width: 60, columnType: enumColumnTypes.number, decimalPrecision: 2 }),
        column.create('정렬순서', 'SORTNO', { width: 70, columnType: enumColumnTypes.number, decimalPrecision: 0 }),
        column.create('비고', 'REMARK', { width: 100 }),
        column.split()
    ]);

    ItsCombo.SetValue('cmb_FACTORYCD', '07');   // 공장 기본값 (onChanged 로 품목 find 법인·공장도 들어감)
};

/* 공장이 정해지면 품목 find 에 법인(REF01)·공장(REF03) 넣기. 법인코드는 공장 콤보 목록 줄의 REF01(DC_COMBO FACTORYCD) */
ItsCombo.Event('cmb_FACTORYCD').onChanged = function (value) {
    var companycd = $('#cmb_FACTORYCD').siblings('ul').children('li').filter('[data-value="' + value + '"]').attr('data-ref01');
    if (companycd == undefined || companycd == 'undefined') companycd = '';
    ItsFind.SetRef01('sdiv1_find_ITEMID', companycd);
    ItsFind.SetRef03('sdiv1_find_ITEMID', value);
};
/*********************************************************************************************************************************************************************************/
/* 조회 */
//grid1
ItsButton.EventSearch = function () {
    ItsGrid.Clear('grid2');

    var maria = new ItsMaria('TQC1001_R02 ', 'LIST_STDTP');

    maria.AddPanel('sdiv1');

    maria.CallProc();

    if (maria.isError) {
        maria.ShowErrMsg();
        return;
    }

    ItsGrid.SetStore('grid1', maria.store);
    ItsMsg.Toast(maria.store.Length() + '건이 조회되었습니다.');
};

// 검사구분 선택시 - 품목조회 (grid2)
ItsGrid.Event('grid1').onSelect = function (rowIndex, field) {
    ItsGrid.Clear('grid2');
    ItsGrid.Clear('grid3');
    ItsGrid.Clear('grid4');
    // 품목 조회 
    var maria = new ItsMaria('TQC1001_R02 ', 'LIST_MSTITEM');

    maria.AddParam('STDTP', ItsGrid.GetValue('grid1', rowIndex, 'STDTP'));
    maria.AddPanel('sdiv1');

    maria.CallProc();

    if (maria.isError) {
        maria.ShowErrMsg();
        return;
    }

    ItsGrid.SetStore('grid2', maria.store.YnToBool('EXISTSYN'));
    ItsGrid.Get('grid2').autoSizeColumns();
};

// 품목 선택시 - 검사리비전 조회(grid3) (3d측정값 부분 더 필요함)
ItsGrid.Event('grid2').onSelect = function (rowIndex, field) {
    //ItsGrid.Clear('grid_detail');
    ItsGrid.Clear('grid3');
    ItsGrid.Clear('grid4');
    // 검사리비전 조회 
    var maria = new ItsMaria('TQC1001_R02', 'LIST_RPTREV');

    maria.AddParam('STDTP', ItsGrid.GetValue('grid1', ItsGrid.GetCurrentIndex('grid1'), 'STDTP'));
    maria.AddParam('ITEMID', ItsGrid.GetValue('grid2', ItsGrid.GetCurrentIndex('grid2'), 'ITEMID'));

    maria.CallProc();

    if (maria.isError) {
        maria.ShowErrMsg();
        return;
    }

    ItsButton.Show('btn_COPY_POP');
    ItsButton.Show('btn_ADD_POP');
    ItsButton.Show('btn_COPY_LIST');
    ItsButton.Show('btn_XLS_UPLOAD');
    ItsButton.Show('btn_SAVE_DETAIL');
    ItsButton.Show('btn_DEL_DETAIL');
   
    ItsGrid.SetStore('grid3', maria.store.YnToBool('USEYN'));
};

// 리비전 선택시 -  검사항목리스트 조회(grid4)
ItsGrid.Event('grid3').onSelect = function (rowIndex) {
    // 검사항목 리스트 조회 
    ItsGrid.Clear('grid4');

    var maria = new ItsMaria('TQC1001_R02 ', 'LIST_MSTRPTREV_DETAIL');
    maria.AddParam('REVCD', ItsGrid.GetValue('grid3', rowIndex, 'REVCD'));

    maria.CallProc();
    if (maria.isError) {
        maria.ShowErrMsg();
        return;
    }

    ItsGrid.SetStore('grid4', maria.store);
    _calcLimitAll();
};

/*********************************************************************************************************************************************************************************/
// 상·하한 자동계산 (측정 항목만, 판정은 TQM1002 JUDGE_ROW 와 같은 규칙)
//   범위 01 최대 / 04 이내 : 상한 = 기준값
//   범위 02 최소 / 03 이상 : 하한 = 기준값
//   범위 05 =              : 상한 = 하한 = 기준값
//   범위 06 ~              : 하한 = 기준값 + 오차(-), 상한 = 기준값 + 오차(+)
var _calcingLimit = false;

function _round8(v) { return Math.round(v * 100000000) / 100000000; }

function _calcLimit(rowIndex) {
    if (rowIndex == undefined || rowIndex < 0 || rowIndex >= ItsGrid.Length('grid4')) return;

    var lower = '', upper = '';

    if (ItsGrid.GetValue('grid4', rowIndex, 'STDCHKTP') === '02') {
        var range = ItsGrid.GetValue('grid4', rowIndex, 'STDRANGE');
        var val = Number(ItsGrid.GetValue('grid4', rowIndex, 'STDVAL')) || 0;
        var minus = Number(ItsGrid.GetValue('grid4', rowIndex, 'STDMINUS')) || 0;
        var plus = Number(ItsGrid.GetValue('grid4', rowIndex, 'STDPLUS')) || 0;

        if (range === '01' || range === '04') { upper = _round8(val); }
        else if (range === '02' || range === '03') { lower = _round8(val); }
        else if (range === '05') { lower = _round8(val); upper = _round8(val); }
        else if (range === '06' || range === '07') { lower = _round8(val + minus); upper = _round8(val + plus); }
    }

    _calcingLimit = true;
    ItsGrid.SetValue('grid4', rowIndex, 'STDLOWER', lower);
    ItsGrid.SetValue('grid4', rowIndex, 'STDUPPER', upper);
    _calcingLimit = false;
}

function _calcLimitAll() {
    for (var i = 0; i < ItsGrid.Length('grid4'); i++) _calcLimit(i);
}

/*********************************************************************************************************************************************************************************/
// 리비전 갱신 버튼
ItsButton.Event('btn_RENEW_REV').onClick = function () {
    ItsMsg.Confirm("갱신하시겠습니까?", function () {
        var maria2 = new ItsMaria('TQC1001_R02', 'RENEW_REV');

        maria2.AddParam('STDTP', ItsGrid.GetValue('grid1', ItsGrid.GetCurrentIndex('grid1'), 'STDTP'));
        maria2.AddParam('ITEMID', ItsGrid.GetValue('grid2', ItsGrid.GetCurrentIndex('grid2'), 'ITEMID'));
        maria2.AddParam('OLDREVCD', ItsGrid.GetValue('grid3', ItsGrid.GetCurrentIndex('grid3'), 'REVCD'));
        maria2.CallProc();

        if (maria2.isError) {
            maria2.ShowErrMsg();
            return;
        }


        ItsGrid.Setkey('grid3', 'REVCD', maria2.store.data[0]['REVCD']);

        // 리비전 리스트 조회
        ItsGrid.Event('grid2').onSelect(ItsGrid.GetCurrentIndex('grid_MSTITEM'));
    });
};

// 리비전 저장 버튼 (선택한 리비전의 개정일·작성자·개정사유)
ItsButton.Event('btn_SAVE_REV').onClick = function () {
    var rowIndex = ItsGrid.GetCurrentIndex('grid3');
    var revcd = ItsGrid.GetValue('grid3', rowIndex, 'REVCD');

    if (revcd == undefined || revcd == '') {
        ItsMsg.Alert('리비전을 선택하세요.');
        return;
    }

    ItsMsg.Confirm("리비전 정보를 저장하시겠습니까?", function () {
        var maria = new ItsMaria('TQC1001_R02', 'UPDATE_REV');

        maria.AddParam('REVCD', revcd);
        maria.AddParam('REGDATE', ItsGrid.GetValue('grid3', rowIndex, 'REGDATE'));
        maria.AddParam('REVEMPNM', ItsGrid.GetValue('grid3', rowIndex, 'REVEMPNM'));
        maria.AddParam('REVREASON', ItsGrid.GetValue('grid3', rowIndex, 'REVREASON'));
        maria.CallProc();

        if (maria.isError) {
            maria.ShowErrMsg();
            return;
        }

        ItsMsg.Toast('저장되었습니다.');

        // 리비전 리스트 재조회 후 저장한 리비전 선택
        ItsGrid.Event('grid2').onSelect(ItsGrid.GetCurrentIndex('grid2'));
        ItsGrid.Setkey('grid3', 'REVCD', revcd);
    });
};

// 리비전 삭제 버튼
ItsButton.Event('btn_DEL_REV').onClick = function () {

    // 리비전 삭제
    var maria = new ItsMaria('TQC1001_R02 ', 'DEL_REV');

    maria.AddParam('STDTP', ItsGrid.GetValue('grid1', ItsGrid.GetCurrentIndex('grid1'), 'STDTP'));
    maria.AddParam('ITEMID', ItsGrid.GetValue('grid2', ItsGrid.GetCurrentIndex('grid2'), 'ITEMID'));
    maria.AddParam('REVCD', ItsGrid.GetValue('grid3', ItsGrid.GetCurrentIndex('grid3'), 'REVCD'));
    maria.CallProc();

    if (maria.isError) {
        maria.ShowErrMsg();
        return;
    }

    // 리비전 리스트 조회
    ItsGrid.Event('grid2').onSelect(ItsGrid.GetCurrentIndex('grid2'));
}


///*********************************************************************************************************************************************************************************/
// 추가(팝업) 버튼
ItsButton.Event('btn_ADD_POP').onClick = function () {

    if (ItsGrid.Length('grid3') > 0) {
        ItsCombo.SetValue('cmb_STDTP_ADDSTD', ItsGrid.GetValue('grid1', ItsGrid.GetCurrentIndex('grid1'), 'STDTP'));
        ItsText.SetValue('txt_ITEMID_ADDSTD', ItsGrid.GetValue('grid2', ItsGrid.GetCurrentIndex('grid2'), 'ITEMCD'));

        //ItsGrid.Clear('grid_STD');

        var maria = new ItsMaria('TQC1001_R02', 'LIST_STD');

        maria.AddParam('STDTP', ItsGrid.GetValue('grid1', ItsGrid.GetCurrentIndex('grid1'), 'STDTP'));
        maria.AddParam('REVCD', ItsGrid.GetValue('grid3', ItsGrid.GetCurrentIndex('grid3'), 'REVCD'));

        maria.CallProc();

        if (maria.isError) {
            maria.ShowErrMsg();
            return;
        }


        ItsGrid.SetStore('grid_STD', maria.store);

        ItsPop.Open('pop_ADDSTD');

        ItsGrid.Get('grid_STD').autoSizeColumns();
    }
}

// 추가(팝업) "추가" 버튼
ItsButton.Event('btn_ADDSTD').onClick = function () {

    var indx = ItsGrid.Length('grid4');

    for (var i = 0; i < ItsGrid.Length('grid_STD'); i++) {
        if (ItsGrid.IsChecked('grid_STD', i)) {
            var data = ItsGrid.GetRowData('grid_STD', i);
            var newSTDCHKTP = data['STDCHKTP'];
          
            ItsGrid.AddRow('grid4', indx, data);

            ItsGrid.SetValue('grid4', indx, 'SAMPLESIZE', 1);

            if (newSTDCHKTP == '01') {
                ItsGrid.SetValue('grid4', indx, 'STDVAL', 0);
                ItsGrid.SetValue('grid4', indx, 'STDMINUS', 0);
                ItsGrid.SetValue('grid4', indx, 'STDPLUS', 0);
            }
            
            var sortNo = 1;
            if (indx - 1 >= 0) {
                sortNo = ItsGrid.GetValue('grid4', indx - 1, 'SORTNO') + 1;
            }
            ItsGrid.SetValue('grid4', indx, 'SORTNO', sortNo);
            indx = ItsGrid.Length('grid4');
        }
    }

    _calcLimitAll();
    ItsPop.Close('pop_ADDSTD');

}

// "저장" 버튼
ItsButton.Event('btn_SAVE_DETAIL').onClick = function () {

    var comboSet = new Set();

    for (var i = 0; i < ItsGrid.Length('grid4'); i++) {
        var stdcd = (ItsGrid.GetValue('grid4', i, 'STDCD') || '').trim();
        var stdpart = (ItsGrid.GetValue('grid4', i, 'STDPART') || '').trim();
        var eqmgroup = (ItsGrid.GetValue('grid4', i, 'PRCDETAIL') || '').trim();

        if (stdcd !== '') {

            var comboKey = stdcd + '|' +
                (stdpart === '' ? 'NULL' : stdpart) + '|' +
                (eqmgroup === '' ? 'NULL' : eqmgroup);

            if (comboSet.has(comboKey)) {
                ItsMsg.Alert('검사항목 + 세부항목 + 설비중분류 조합이 중복되었습니다.');
                return;
            }

            comboSet.add(comboKey);

        }
    }

    ItsMsg.Confirm("저장하시겠습니까?", function () {
        // 디테일정보 저장(검사항목 리스트)
        var maria2 = new ItsMaria('TQC1001_R02', 'UPDATE_MSTRPTREV_DETAIL');

        maria2.AddParam('REVCD', ItsGrid.GetValue('grid3', ItsGrid.GetCurrentIndex('grid3'), 'REVCD'));

        for (var i = 0; i < ItsGrid.Length('grid4'); i++) {
            if (ItsGrid.IsChecked('grid4', i)) {

                var stdrange = ItsGrid.GetValue('grid4', i, 'STDRANGE');
                var samplesize = ItsGrid.GetValue('grid4', i, 'SAMPLESIZE');

                if (samplesize == '') {
                    ItsMsg.Alert('시료수 값이 비어있습니다');
                    return;
                }
                // 출하검사 등록 측정치가 X1~X10 이라 시료수는 1~10 정수 (2026-11-26 사용자 지시)
                if (Number(samplesize) < 1 || Number(samplesize) > 10 || Number(samplesize) !== Math.floor(Number(samplesize))) {
                    ItsMsg.Alert('시료수는 1~10 사이의 정수만 입력할 수 있습니다.\n - 검사항목 : ' + ItsGrid.GetValue('grid4', i, 'STDNM'));
                    return;
                }
                if (stdrange === '06') {
                    if (ItsGrid.GetValue('grid4', i, 'STDMINUS') === '' || ItsGrid.GetValue('grid4', i, 'STDPLUS') === '') {
                        var STDNM = ItsGrid.GetValue('grid4', i, 'STDNM');
                        ItsMsg.Alert(STDNM + '의 오차(-,+) 값이 잘못 입력되었습니다.');
                        return;
                    }
                }
                if (stdrange === '') {
                    if (ItsGrid.GetValue('grid4', i, 'STDMINUS') !== 0 || ItsGrid.GetValue('grid4', i, 'STDPLUS') !== 0 || ItsGrid.GetValue('grid4', i, 'STDVAL') !== 0) {
                        var STDNM = ItsGrid.GetValue('grid4', i, 'STDNM');
                        ItsMsg.Alert(STDNM + '의 오차(-,+) 값과 기준값은 항상 0입니다');
                        return;
                    }
                } else {
                    if (ItsGrid.GetValue('grid4', i, 'STDVAL') === '') {
                        var STDNM = ItsGrid.GetValue('grid4', i, 'STDNM');
                        ItsMsg.Alert(STDNM + '의 기준값이 잘못 입력되었습니다.');
                        
                        return;
                    }
                }

                maria2.AddList('STDCD_LIST', ItsGrid.GetValue('grid4', i, 'STDCD'));
                maria2.AddList('STDNM_LIST', ItsGrid.GetValue('grid4', i, 'STDNM'));
                maria2.AddList('STDPART_LIST', ItsGrid.GetValue('grid4', i, 'STDPART'));   // 세부항목 저장
                maria2.AddList('PRCDETAIL_LIST', ItsGrid.GetValue('grid4', i, 'PRCDETAIL'));   // 세부항목 저장
                maria2.AddList('FEATURE_LIST', ItsGrid.GetValue('grid4', i, 'FEATURE'));   // 세부항목 저장
                maria2.AddList('STDCHKTP_LIST', ItsGrid.GetValue('grid4', i, 'STDCHKTP'));
                maria2.AddList('STDMACHINE_LIST', ItsGrid.GetValue('grid4', i, 'STDMACHINE'));
                maria2.AddList('STDPOINT_LIST', ItsGrid.GetValue('grid4', i, 'STDPOINT'));
                maria2.AddList('STDCYCLE_LIST', ItsGrid.GetValue('grid4', i, 'STDCYCLE'));
                maria2.AddList('STDVAL_LIST', ItsGrid.GetValue('grid4', i, 'STDVAL'));
                maria2.AddList('STDRANGE_LIST', ItsGrid.GetValue('grid4', i, 'STDRANGE'));
                maria2.AddList('STDMINUS_LIST', ItsGrid.GetValue('grid4', i, 'STDMINUS'));

                maria2.AddList('STDPLUS_LIST', ItsGrid.GetValue('grid4', i, 'STDPLUS'));
                maria2.AddList('STDUNIT_LIST', ItsGrid.GetValue('grid4', i, 'STDUNIT'));
                maria2.AddList('STDJUDGE_LIST', ItsGrid.GetValue('grid4', i, 'STDJUDGE'));
                
                maria2.AddList('REMARK_LIST', ItsGrid.GetValue('grid4', i, 'REMARK'));
                maria2.AddList('SORTNO_LIST', ItsGrid.GetValue('grid4', i, 'SORTNO'));

                maria2.AddList('SAMPLESIZE_LIST', ItsGrid.GetValue('grid4', i, 'SAMPLESIZE'));
            }
        }
        maria2.CallProc();

        if (maria2.isError) {
            maria2.ShowErrMsg();
            return;
        }

        var REVCD = ItsGrid.GetValue('grid3', ItsGrid.GetCurrentIndex('grid3'), 'REVCD');

        ItsGrid.Setkey('grid3', 'REVCD', REVCD);

        ItsGrid.Event('grid2').onSelect(ItsGrid.GetCurrentIndex('grid2'));
    });
};

// "삭제" 버튼
ItsButton.Event('btn_DEL_DETAIL').onClick = function () {
    ItsMsg.Confirm("검사항목을 삭제하시겠습니까?", function () {
        var maria = new ItsMaria('TQC1001_R02', 'DELETE_MSTRPTREV_DETAIL');
        var deleteList = false; // DB 삭제 대상 존재 여부 체크용

        var REVCD = ItsGrid.GetValue('grid3', ItsGrid.GetCurrentIndex('grid3'), 'REVCD');

        // 삭제할 행 인덱스들을 저장 (반복 중 삭제하면 인덱스 꼬이기 때문)
        var rowsToDelete = [];

        for (var i = 0; i < ItsGrid.Length('grid4'); i++) {
            if (ItsGrid.IsChecked('grid4', i)) {
                var rowREVCD = ItsGrid.GetValue('grid4', i, 'REVCD');
                var rowSTDCD = ItsGrid.GetValue('grid4', i, 'STDCD');
                var rowSTDPART = ItsGrid.GetValue('grid4', i, 'STDPART');
                var rowPRCDETAIL = ItsGrid.GetValue('grid4', i, 'PRCDETAIL');

                if (rowREVCD && rowSTDCD) {
                    // DB 삭제 대상
                    maria.AddList('REVCD_LIST', rowREVCD);
                    maria.AddList('STDCD_LIST', rowSTDCD);
                    maria.AddList('STDPART_LIST', rowSTDPART);
                    maria.AddList('PRCDETAIL_LIST', rowPRCDETAIL);
                    deleteList = true;
                }

                // 무조건 화면에서도 삭제할 행으로 기록
                rowsToDelete.push(i);
            }
        }

        // DB 삭제 실행
        if (deleteList) {
            maria.AddParam('REVCD', REVCD);
            maria.CallProc();

            if (maria.isError) {
                maria.ShowErrMsg();
                return;
            }
        }

        // 화면에서 해당 행 삭제 (뒤에서부터 해야 인덱스 안 꼬임)
        for (var j = rowsToDelete.length - 1; j >= 0; j--) {
            ItsGrid.RemoveRow('grid4', rowsToDelete[j]);
        }
    });
}; 


/*********************************************************************************************************************************************************************************/
 //검사항목복사 팝업 오픈
ItsButton.Event('btn_COPY_POP').onClick = function () {
    if (ItsGrid.Length('grid3') > 0) {
        ItsCombo.SetValue('cmb_STDTP_COPYSTD', ItsGrid.GetValue('grid1', ItsGrid.GetCurrentIndex('grid1'), 'STDTP'));
     
        ItsGrid.Clear('grid2_COPY');
        ItsGrid.Clear('grid3_COPY');
        ItsGrid.Clear('grid4_COPY');

        var maria = new ItsMaria('TQC1001_R02', 'LIST_MSTITEM_COPY');

        maria.AddParam('STDTP', ItsGrid.GetValue('grid1', ItsGrid.GetCurrentIndex('grid1'), 'STDTP'));
        maria.AddParam('REVCD', ItsGrid.GetValue('grid3', ItsGrid.GetCurrentIndex('grid3'), 'REVCD'));
        maria.CallProc();

        if (maria.isError) {
            maria.ShowErrMsg();
            return;
        }

        ItsGrid.SetStore('grid2_COPY', maria.store);

        ItsPop.Open('pop_COPYSTD');

        //ItsGrid.Get('grid_STD').autoSizeColumns();
    }
}

// 품목 선택시 - 검사리비전 조회 (검사항목복사 팝업)
ItsGrid.Event('grid2_COPY').onSelect = function (rowIndex, field) {
    // 검사리비전 조회 
    var maria = new ItsMaria('TQC1001_R02 ', 'LIST_RPTREV');
    var STDTP = ItsCombo.GetValue('cmb_STDTP_COPYSTD');
    maria.AddParam('STDTP', STDTP);
    maria.AddParam('ITEMID', ItsGrid.GetValue('grid2_COPY', rowIndex, 'ITEMID'));
    if (STDTP == 'INTEST' || STDTP == 'OUTTEST') {
        ItsGrid.Get('grid4_COPY').columns[ItsGrid.$colIndex('grid4_COPY', 'STDPART')].visible = false;
        ItsGrid.Get('grid4_COPY').columns[ItsGrid.$colIndex('grid4_COPY', 'STDPART')].visible = false;
    }
    else {
        ItsGrid.Get('grid4_COPY').columns[ItsGrid.$colIndex('grid4_COPY', 'STDPART')].visible = true;
        ItsGrid.Get('grid4_COPY').columns[ItsGrid.$colIndex('grid4_COPY', 'STDPART')].visible = true;
    }


    maria.CallProc();

    if (maria.isError) {
        maria.ShowErrMsg();
        return;
    }

    ItsGrid.SetStore('grid3_COPY', maria.store.YnToBool('USEYN'));
    //ItsGrid.Get('grid_rev').autoSizeColumns();
};

// 리비전 선택시 -  검사항목리스트 조회 (검사항목복사 팝업)
ItsGrid.Event('grid3_COPY').onSelect = function (rowIndex, field) {
    // 검사항목 리스트 조회 
    var STDTP = ItsCombo.GetValue('cmb_STDTP_COPYSTD');
    var maria = new ItsMaria('TQC1001_R02 ', 'LIST_MSTRPTREV_DETAIL');
    
    maria.AddParam('STDTP', STDTP);
    maria.AddParam('REVCD', ItsGrid.GetValue('grid3_COPY', rowIndex, 'REVCD'));

    maria.CallProc();

    if (maria.isError) {
        maria.ShowErrMsg();
        return;
    }

    ItsGrid.SetStore('grid4_COPY', maria.store);
    //ItsGrid.Get('grid_detail').autoSizeColumns();
};

// 검사항목 추가
ItsButton.Event('btn_COPYSTD').onClick = function () {
    var indx = ItsGrid.Length('grid4');

    for (var i = 0; i < ItsGrid.Length('grid4_COPY'); i++) {
        if (ItsGrid.IsChecked('grid4_COPY', i)) {
            var data = ItsGrid.GetRowData('grid4_COPY', i);

            ItsGrid.AddRow('grid4', indx, data);
            var sortNo = 1;
            if (indx - 1 >= 0) {
                sortNo = ItsGrid.GetValue('grid4', indx - 1, 'SORTNO') + 1;
            }
            ItsGrid.SetValue('grid4', indx, 'SORTNO', sortNo);
            indx = ItsGrid.Length('grid4');
        }
    }

    _calcLimitAll();
    ItsPop.Close('pop_COPYSTD');
}

///*********************************************************************************************************************************************************************************/
////////////////////// 2025-10-30 범위에 따른 판정기준 기준값 오차 넣는 부분 제한 
// GRID4 에 범위가 07 일때 오차값을 넣으면 -에 넣으면 +값에 바로 똑같은 숫자가 들어갈 수 있도록
ItsGrid.Event('grid4').onChanged = function (rowIndex, field) {
    if (_calcingLimit) return;   // 상·하한 자동계산이 값을 넣을 때는 건너뜀

    _grid4Changed(rowIndex, field);   // 범위·검사방법에 따른 기준값·오차 정리
    _calcLimit(ItsGrid.GetCurrentIndex('grid4'));   // 정리가 끝난 값으로 상·하한 계산
};

function _grid4Changed(rowIndex, field) {
    const currentIndex = ItsGrid.GetCurrentIndex('grid4');
    const stdrange = ItsGrid.GetValue('grid4', currentIndex, 'STDRANGE');
    const samplesize = ItsGrid.GetValue('grid4', currentIndex, 'SAMPLESIZE');
    const stdtp = ItsGrid.GetValue('grid1', ItsGrid.GetCurrentIndex('grid1'), 'STDTP');
    const stdchktp = ItsGrid.GetValue('grid4', ItsGrid.GetCurrentIndex('grid4'), 'STDCHKTP');

    if (stdchktp === '02') {

        // 검사범위(STDRANGE)에 따른 기준값 초기화
        switch (stdrange) {
            case '01':
                break;
            case '02':
                break;
            case '03':
                break;
            case '04':
                break;
            case '05':
                break;
            case '06':
                break;
            case '07':
                break;
            case '08':
                ItsGrid.SetValue('grid4', currentIndex, 'STDMINUS', '0');
                ItsGrid.SetValue('grid4', currentIndex, 'STDPLUS', '0');
                break;
            case '10': // + 
                ItsGrid.SetValue('grid4', currentIndex, 'STDMINUS', '0');
                break;

            case '11': // - 
                ItsGrid.SetValue('grid4', currentIndex, 'STDPLUS', '0');
                break;
            case '': // 빈 값일 경우: 모든 기준값 초기화
                ItsGrid.SetValue('grid4', currentIndex, 'STDVAL', '0');
                ItsGrid.SetValue('grid4', currentIndex, 'STDMINUS', '0');
                ItsGrid.SetValue('grid4', currentIndex, 'STDPLUS', '0');
                break;
        }

    }
    else {
        ItsGrid.SetValue('grid4', currentIndex, 'STDVAL', '0');
        ItsGrid.SetValue('grid4', currentIndex, 'STDMINUS', '0');
        ItsGrid.SetValue('grid4', currentIndex, 'STDPLUS', '0');
    }
};

///*********************************************************************************************************************************************************************************/
// 검사항목 이미지 팝업 (항목당 여러 장 등록)
var imgKey = {};   // 팝업이 열려 있는 검사항목 키 (REVCD, STDCD, STDPART, PRCDETAIL)

ItsGrid.Event('grid4').onButtonClick = function (rowIndex, field) {
    if (field != 'POP_IMG') return;

    imgKey = {
        REVCD: ItsGrid.GetValue('grid3', ItsGrid.GetCurrentIndex('grid3'), 'REVCD'),
        STDCD: ItsGrid.GetValue('grid4', rowIndex, 'STDCD'),
        STDPART: ItsGrid.GetValue('grid4', rowIndex, 'STDPART') || '',
        PRCDETAIL: ItsGrid.GetValue('grid4', rowIndex, 'PRCDETAIL') || ''
    };
    imgKey.ROWINDEX = rowIndex;

    ItsText.SetValue('txt_STDNM_IMG', ItsGrid.GetValue('grid4', rowIndex, 'STDNM'));
    ItsFileManager.Clear('file_DTLIMG');
    ItsImage.Clear('img_DTLIMG');

    if (!_loadDetailImage()) return;
    ItsPop.Open('pop_IMG');
};

// 항목 이미지 조회 (저장된 항목이 아니면 프로시저가 에러를 주지 않고 빈 목록)
function _loadDetailImage() {
    var maria = new ItsMaria('TQC1001_R02', 'LIST_DETAIL_IMAGE');
    maria.AddParam('REVCD', imgKey.REVCD);
    maria.AddParam('STDCD', imgKey.STDCD);
    maria.AddParam('STDPART', imgKey.STDPART);
    maria.AddParam('PRCDETAIL', imgKey.PRCDETAIL);
    maria.CallProc();

    if (maria.isError) {
        maria.ShowErrMsg();
        return false;
    }

    ItsGrid.SetStore('grid_IMG', maria.store);
    ItsImage.Clear('img_DTLIMG');
    return true;
}

// 이미지 선택 시 미리보기
ItsGrid.Event('grid_IMG').onSelect = function (rowIndex) {
    ItsImage.SetImage('img_DTLIMG', ItsGrid.GetValue('grid_IMG', rowIndex, 'FILEURL'));
};

// [업로드(추가)] : 선택한 파일 업로드 → 등록
ItsButton.Event('btn_DTLIMG_ADD').onClick = function () {
    if (!ItsFileManager.IsFileChanged('file_DTLIMG')) {
        ItsMsg.Alert('추가할 이미지 파일을 선택하세요.');
        return;
    }
    ItsFileManager.Upload('file_DTLIMG');
};

ItsFileManager.Event('file_DTLIMG').onUpload = function (id, fileKey) {
    var maria = new ItsMaria('TQC1001_R02', 'ADD_DETAIL_IMAGE');
    maria.AddParam('REVCD', imgKey.REVCD);
    maria.AddParam('STDCD', imgKey.STDCD);
    maria.AddParam('STDPART', imgKey.STDPART);
    maria.AddParam('PRCDETAIL', imgKey.PRCDETAIL);
    maria.AddParam('FILEKEY', fileKey);
    maria.CallProc();

    if (maria.isError) {
        maria.ShowErrMsg();
        return;
    }

    ItsFileManager.Clear('file_DTLIMG');
    _loadDetailImage();
    _refreshImgCount();
    ItsMsg.Toast('이미지가 추가되었습니다.');
};

// [선택 삭제] : 선택한 1장 삭제
ItsButton.Event('btn_DTLIMG_DEL').onClick = function () {
    var idx = ItsGrid.GetCurrentIndex('grid_IMG');
    if (idx < 0 || ItsGrid.Length('grid_IMG') == 0) {
        ItsMsg.Alert('삭제할 이미지를 선택하세요.');
        return;
    }

    ItsMsg.Confirm('선택한 이미지를 삭제하시겠습니까?', function () {
        var maria = new ItsMaria('TQC1001_R02', 'DEL_DETAIL_IMAGE');
        maria.AddParam('REVCD', imgKey.REVCD);
        maria.AddParam('STDCD', imgKey.STDCD);
        maria.AddParam('STDPART', imgKey.STDPART);
        maria.AddParam('PRCDETAIL', imgKey.PRCDETAIL);
        maria.AddParam('IMGNO', ItsGrid.GetValue('grid_IMG', idx, 'NO'));
        maria.CallProc();

        if (maria.isError) {
            maria.ShowErrMsg();
            return;
        }

        _loadDetailImage();
        _refreshImgCount();
        ItsMsg.Toast('삭제되었습니다.');
    });
};

// 팝업에서 추가·삭제한 뒤 항목 그리드의 장수 갱신
function _refreshImgCount() {
    ItsGrid.SetValue('grid4', imgKey.ROWINDEX, 'IMGCNT', ItsGrid.Length('grid_IMG'));
}

///*********************************************************************************************************************************************************************************/
// 새롭게 추가된 사항 (기준서 프린트)
ItsGrid.Event('grid3').onButtonClick = function (rowIndex, field) {
    if (field == 'PRINT') {
         //수입검사, 초중종검사를 따로 구분 할수 있도록
        var STDTP = ItsGrid.GetValue('grid1', ItsGrid.GetCurrentIndex('grid1'), 'STDTP');

        if (STDTP == 'INTEST') {
            var rpt = new ItsXtraRpt('TQC1001_R02INTEST');
            rpt.AddParam('ITEMID', null);
            if (rpt.isError) {
                ItsMsg.Alert(rpt.errMessage);
                return;
            }

            rpt.Call();
        }
        else if (STDTP == 'PRCTEST') {
            var revcd = ItsGrid.GetValue('grid3', rowIndex, 'REVCD');
            var itemcd = ItsGrid.GetValue('grid2', ItsGrid.GetCurrentIndex('grid2'), 'ITEMID');

            var rpt = new ItsXtraRpt('TQC1001_R02PRCTESTA');
            rpt.AddParam('REVCD', revcd);
            rpt.AddParam('ITEMID', itemcd);
           
            if (rpt.isError) {
                ItsMsg.Alert(rpt.errMessage);
                return;
            }

            rpt.Call();
        
        }
   
    }
};

///*********************************************************************************************************************************************************************************/
// 2026-11-26 엑셀로 검사항목 리스트 올리기
//   양식은 "엑셀 양식" 버튼으로 받는다 (첫 시트 = 입력, 둘째 시트 = 콤보 입력값 안내).
//   검사항목은 검사항목 마스터(MSTSTD) 이름과 같아야 하고, 비워 둔 칸은 마스터 값을 쓴다 (추가(팝업)으로 넣을 때와 같다).
//   엑셀에서 읽은 줄은 grid4 에 추가만 하고, 확인한 뒤 기존 "저장" 버튼으로 저장한다.
var XLS_HEAD = ['검사항목', '세부항목', '세부공정', '특성', '검사방법', '측정기기', '측정부위', '검사주기', '기준값', '단위', '범위', '오차(-)', '오차(+)', '판정기준', '시료수', '정렬순서', '비고'];
var XLS_FIELD = ['STDNM', 'STDPART', 'PRCDETAIL', 'FEATURE', 'STDCHKTP', 'STDMACHINE', 'STDPOINT', 'STDCYCLE', 'STDVAL', 'STDUNIT', 'STDRANGE', 'STDMINUS', 'STDPLUS', 'STDJUDGE', 'SAMPLESIZE', 'SORTNO', 'REMARK'];
var XLS_COMBO = ['PRCDETAIL', 'STDCHKTP', 'STDMACHINE', 'STDPOINT', 'STDCYCLE', 'STDUNIT', 'STDRANGE'];   // 이름 또는 코드로 적을 수 있는 칸
var XLS_NUM = ['STDVAL', 'STDMINUS', 'STDPLUS', 'SAMPLESIZE', 'SORTNO'];

// 콤보 칸의 (코드, 이름) 목록
function _xlsOptions(field) {
    var col = ItsGrid.Get('grid4').columns[ItsGrid.$colIndex('grid4', field)];
    var list = (col && col.dataMap && col.dataMap._originData) ? col.dataMap._originData : [];
    return list.map(function (d) { return { code: d['Value'], name: d[Object.keys(d)[1]] }; });
}

// 엑셀 양식 내려받기
ItsButton.Event('btn_XLS_TEMPLATE').onClick = function () {
    var wb = XLSX.utils.book_new();

    var guide = [XLS_HEAD.slice(), ['외경', '', '', '', '측정', '', '', '', 10, '', '', '', '', '', 1, 1, '']];
    XLSX.utils.book_append_sheet(wb, XLSX.utils.aoa_to_sheet(guide), '입력');

    var info = [['칸', '입력할 수 있는 값 (이름 또는 코드)']];
    info.push(['검사항목', '검사항목 마스터에 등록된 이름과 똑같이 적는다. (필수)']);
    info.push(['비워 둔 칸', '검사항목 마스터 값을 쓴다. 기준값·오차는 비우면 0, 시료수는 1, 정렬순서는 맨 뒤 순번.']);
    info.push(['시료수', '1 ~ 10 정수']);
    for (var i = 0; i < XLS_COMBO.length; i++) {
        var f = XLS_COMBO[i];
        var opts = _xlsOptions(f);
        info.push([XLS_HEAD[XLS_FIELD.indexOf(f)], opts.map(function (o) { return o.name + '(' + o.code + ')'; }).join(', ')]);
    }
    var ws2 = XLSX.utils.aoa_to_sheet(info);
    ws2['!cols'] = [{ wch: 12 }, { wch: 120 }];
    XLSX.utils.book_append_sheet(wb, ws2, '입력값 안내');

    // XLSX.writeFile 은 브라우저에서 파일 저장 도구(FileSaver)가 없으면 오류가 나서 Blob 으로 직접 내려받는다
    var out = XLSX.write(wb, { bookType: 'xlsx', type: 'array' });
    var blob = new Blob([out], { type: 'application/octet-stream' });
    if (window.navigator.msSaveOrOpenBlob) {
        window.navigator.msSaveOrOpenBlob(blob, '검사기준_업로드양식.xlsx');
    } else {
        var url = URL.createObjectURL(blob);
        var link = document.createElement('a');
        link.href = url;
        link.download = '검사기준_업로드양식.xlsx';
        document.body.appendChild(link);
        link.click();
        document.body.removeChild(link);
        setTimeout(function () { URL.revokeObjectURL(url); }, 1000);
    }
};

// 엑셀 올리기: 파일 선택 창
ItsButton.Event('btn_XLS_UPLOAD').onClick = function () {
    if (ItsGrid.Length('grid3') < 1 || ItsGrid.GetCurrentIndex('grid3') < 0) {
        ItsMsg.Alert('리비전을 선택하세요.');
        return;
    }
    $('#file_XLS').val('').trigger('click');
};

$(function () {
    $('#file_XLS').change(function () { _readStdExcel(this); });
});

function _xlsText(v) { return v === undefined || v === null ? '' : String(v).trim(); }

function _readStdExcel(fileInput) {
    if (fileInput.files.length == 0) return;

    var reader = new FileReader();
    reader.onload = function (evt) {
        try {
            _applyStdExcel(XLSX.read(new Uint8Array(evt.target.result), { type: 'array' }));
        } catch (e) {
            ItsMsg.Alert(e.message || '엑셀 파일을 읽지 못했습니다.');
        }
    };
    reader.readAsArrayBuffer(fileInput.files[0]);
}

function _applyStdExcel(workbook) {
    var ws = workbook.Sheets[workbook.SheetNames[0]];
    var aoa = XLSX.utils.sheet_to_json(ws, { header: 1, defval: '', raw: true });

    // 머리글 줄 찾기 ('검사항목' 이 있는 첫 줄)
    var hr = -1;
    for (var r = 0; r < aoa.length && hr < 0; r++) {
        for (var c = 0; c < aoa[r].length; c++) {
            if (_xlsText(aoa[r][c]) == '검사항목') { hr = r; break; }
        }
    }
    if (hr < 0) throw new Error("엑셀에서 '검사항목' 머리글을 찾지 못했습니다.\n'엑셀 양식' 버튼으로 받은 양식을 쓰세요.");

    var col = {};   // 필드 → 엑셀 열 번호
    for (var c = 0; c < aoa[hr].length; c++) {
        var idx = XLS_HEAD.indexOf(_xlsText(aoa[hr][c]));
        if (idx > -1) col[XLS_FIELD[idx]] = c;
    }

    // 검사항목 마스터 (추가(팝업)과 같은 프로시저)
    var STDTP = ItsGrid.GetValue('grid1', ItsGrid.GetCurrentIndex('grid1'), 'STDTP');
    var maria = new ItsMaria('TQC1001_R02', 'LIST_STD');
    maria.AddParam('STDTP', STDTP);
    maria.AddParam('REVCD', ItsGrid.GetValue('grid3', ItsGrid.GetCurrentIndex('grid3'), 'REVCD'));
    maria.CallProc();
    if (maria.isError) {
        maria.ShowErrMsg();
        return;
    }
    var master = {};
    for (var m = 0; m < maria.store.Length(); m++) {
        var md = maria.store.data[m];
        master[_xlsText(md.STDNM)] = md;
    }

    var opts = {};
    XLS_COMBO.forEach(function (f) { opts[f] = _xlsOptions(f); });

    // 이미 있는 줄과 중복 검사용 (저장 시 검사항목+세부항목+세부공정 중복 불가)
    var used = {};
    for (var g = 0; g < ItsGrid.Length('grid4'); g++) {
        used[(ItsGrid.GetValue('grid4', g, 'STDCD') || '') + '|' + (ItsGrid.GetValue('grid4', g, 'STDPART') || '') + '|' + (ItsGrid.GetValue('grid4', g, 'PRCDETAIL') || '')] = true;
    }

    var errors = [], newRows = [];
    for (var r = hr + 1; r < aoa.length; r++) {
        var line = aoa[r];
        var cell = function (f) { return col[f] === undefined ? '' : _xlsText(line[col[f]]); };
        if (cell('STDNM') == '') {
            var any = false;
            for (var k = 0; k < line.length; k++) { if (_xlsText(line[k]) != '') any = true; }
            if (any) errors.push((r + 1) + '행: 검사항목이 비어 있습니다.');
            continue;
        }

        var std = master[cell('STDNM')];
        if (std == undefined) { errors.push((r + 1) + '행: 검사항목 마스터에 없는 이름입니다. (' + cell('STDNM') + ')'); continue; }

        // 비워 둔 칸은 마스터 값
        var data = {
            STDCD: std.STDCD, STDNM: std.STDNM, STDPART: cell('STDPART'), FEATURE: cell('FEATURE'), PRCDETAIL: '',
            STDCHKTP: std.STDCHKTP, STDMACHINE: std.STDMACHINE, STDPOINT: std.STDPOINT, STDCYCLE: std.STDCYCLE,
            STDUNIT: std.STDUNIT, STDRANGE: std.STDRANGE, STDJUDGE: std.STDJUDGE, REMARK: std.REMARK,
            STDVAL: '', STDMINUS: '', STDPLUS: '', SAMPLESIZE: '', SORTNO: ''
        };
        var bad = false;

        XLS_COMBO.forEach(function (f) {
            var v = cell(f);
            if (v == '') return;
            var hit = null;
            opts[f].forEach(function (o) { if (o.name == v || o.code == v) hit = o; });
            if (hit == null && opts[f].length > 0) {
                errors.push((r + 1) + '행: ' + XLS_HEAD[XLS_FIELD.indexOf(f)] + " '" + v + "' 은(는) 없는 값입니다. (양식의 '입력값 안내' 시트 참고)");
                bad = true;
            } else {
                data[f] = hit == null ? v : hit.code;
            }
        });

        XLS_NUM.forEach(function (f) {
            var v = cell(f);
            if (v == '') return;
            var n = Number(v.replace(/,/g, ''));
            if (isNaN(n)) {
                errors.push((r + 1) + '행: ' + XLS_HEAD[XLS_FIELD.indexOf(f)] + " '" + v + "' 은(는) 숫자가 아닙니다.");
                bad = true;
            } else {
                data[f] = n;
            }
        });
        if (cell('STDJUDGE') != '') data.STDJUDGE = cell('STDJUDGE');
        if (cell('REMARK') != '') data.REMARK = cell('REMARK');
        if (bad) continue;

        // 저장 화면 검사와 같은 규칙
        if (data.SAMPLESIZE === '') data.SAMPLESIZE = 1;
        if (data.SAMPLESIZE < 1 || data.SAMPLESIZE > 10 || data.SAMPLESIZE !== Math.floor(data.SAMPLESIZE)) {
            errors.push((r + 1) + '행: 시료수는 1~10 사이의 정수여야 합니다.');
            continue;
        }
        if (data.STDRANGE == '' || data.STDCHKTP == '01') {
            if (data.STDCHKTP != '01' && (data.STDVAL !== '' || data.STDMINUS !== '' || data.STDPLUS !== '')) {
                errors.push((r + 1) + '행: 범위가 비어 있으면 기준값과 오차는 입력할 수 없습니다. (범위를 적으세요)');
                continue;
            }
            data.STDVAL = 0; data.STDMINUS = 0; data.STDPLUS = 0;
        } else {
            if (data.STDVAL === '') { errors.push((r + 1) + '행: 기준값이 비어 있습니다.'); continue; }
            if (data.STDRANGE === '06' && (data.STDMINUS === '' || data.STDPLUS === '')) { errors.push((r + 1) + '행: 범위 ~ 는 오차(-), 오차(+) 가 필요합니다.'); continue; }
            if (data.STDMINUS === '') data.STDMINUS = 0;
            if (data.STDPLUS === '') data.STDPLUS = 0;
        }

        var key = data.STDCD + '|' + data.STDPART + '|' + data.PRCDETAIL;
        if (used[key]) { errors.push((r + 1) + '행: 검사항목 + 세부항목 + 세부공정이 이미 있거나 엑셀에서 중복됩니다. (' + data.STDNM + ')'); continue; }
        used[key] = true;

        newRows.push(data);
    }

    if (errors.length > 0) {
        ItsMsg.Alert('엑셀에 고칠 곳이 ' + errors.length + '건 있어 한 줄도 올리지 않았습니다.\n\n' + errors.slice(0, 15).join('\n') + (errors.length > 15 ? '\n... 외 ' + (errors.length - 15) + '건' : ''));
        return;
    }
    if (newRows.length == 0) {
        ItsMsg.Alert('올릴 줄이 없습니다.');
        return;
    }

    var indx = ItsGrid.Length('grid4');
    var sortNo = indx > 0 ? (Number(ItsGrid.GetValue('grid4', indx - 1, 'SORTNO')) || 0) : 0;
    for (var n = 0; n < newRows.length; n++) {
        if (newRows[n].SORTNO === '') newRows[n].SORTNO = ++sortNo; else sortNo = Math.max(sortNo, newRows[n].SORTNO);
        ItsGrid.AddRow('grid4', indx, newRows[n]);
        indx = ItsGrid.Length('grid4');
    }

    _calcLimitAll();
    ItsMsg.Alert(newRows.length + '줄을 검사항목 리스트에 추가했습니다.\n내용을 확인한 뒤 "저장" 버튼을 눌러야 저장됩니다.');
}
