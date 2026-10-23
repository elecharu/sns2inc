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
        column.split()
    ]);

    // 검사항목 리스트 그리드
    ItsGrid.Create('grid4', { isCheckBoxGrid: true }, [
        column.create('REVCD', 'REVCD', { width: 100, hidden: true }),
        column.create("검사항목코드", "STDCD", { width: 100, hidden: true }),
        column.create("검사항목", "STDNM", { width: 100}),
        column.create("세부항목", "STDPART", { width: 100, readOnly: false }),
        column.create("설비중분류", "EQMGROUP2", { width: 100, columnType: enumColumnTypes.combo, gpcd: 'FM114', readOnly: false, align: 'center' }),
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
            column.create('판정기준', 'STDJUDGE', { width: 300, readOnly: false, multiLine: true }),
        ]),

        column.create('시료수', 'SAMPLESIZE', { width: 60, columnType: enumColumnTypes.number, decimalPrecision: 2, readOnly: false }),
        column.create('정렬순서', 'SORTNO', { width: 70, readOnly: false, columnType: enumColumnTypes.number, decimalPrecision: 0 }),
        column.create('비고', 'REMARK', { width: 100, readOnly: false }),
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
};

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

    ItsPop.Close('pop_ADDSTD');

}

// "저장" 버튼
ItsButton.Event('btn_SAVE_DETAIL').onClick = function () {

    var comboSet = new Set();

    for (var i = 0; i < ItsGrid.Length('grid4'); i++) {
        var stdcd = (ItsGrid.GetValue('grid4', i, 'STDCD') || '').trim();
        var stdpart = (ItsGrid.GetValue('grid4', i, 'STDPART') || '').trim();
        var eqmgroup = (ItsGrid.GetValue('grid4', i, 'EQMGROUP2') || '').trim();

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
                maria2.AddList('EQMGROUP2_LIST', ItsGrid.GetValue('grid4', i, 'EQMGROUP2'));   // 세부항목 저장
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
                var rowEQMGROUP2 = ItsGrid.GetValue('grid4', i, 'EQMGROUP2');

                if (rowREVCD && rowSTDCD) {
                    // DB 삭제 대상
                    maria.AddList('REVCD_LIST', rowREVCD);
                    maria.AddList('STDCD_LIST', rowSTDCD);
                    maria.AddList('STDPART_LIST', rowSTDPART);
                    maria.AddList('EQMGROUP2_LIST', rowEQMGROUP2);
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

    ItsPop.Close('pop_COPYSTD');
}

///*********************************************************************************************************************************************************************************/
////////////////////// 2025-10-30 범위에 따른 판정기준 기준값 오차 넣는 부분 제한 
// GRID4 에 범위가 07 일때 오차값을 넣으면 -에 넣으면 +값에 바로 똑같은 숫자가 들어갈 수 있도록
ItsGrid.Event('grid4').onChanged = function (rowIndex, field) {
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
