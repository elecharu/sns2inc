/// <reference path="../../Script/reference.js" />

/* 페이지 로드 시 수행 */
ItsPage.Load = function () {
    // 검사구분 
    ItsGrid.Create('grid1', { isCheckBoxGrid: false }, [
        column.create("검사구분코드", "STDTP", { width: 110, align: 'center', hidden: false }),
        column.create("검사구분", "STDTPNM", { width: 110, align: 'center' }),
        column.split()
    ]);

    // 품목 리스트 
    ItsGrid.Create('grid2', { isCheckBoxGrid: false }, [
        column.create("등록여부", "EXISTSYN", { width: 70, columnType: enumColumnTypes.check }),
        column.create('품목유형', 'ITEMTP', { width: 80, columnType: enumColumnTypes.combo, gpcd: 'ITEMTP', align: 'center' }),
        column.create('품목코드', 'ITEMCD', { width: 150 }),
        column.create('품명', 'ITEMNM', { width: 300 }),

        column.split()
    ]);

    // 리비전 리스트 
    ItsGrid.Create('grid3', { isCheckBoxGrid: false }, [
        column.create('REVCD', 'REVCD', { width: 100, hidden: true }),
        column.create("사용중", "USEYN", { width: 50, columnType: enumColumnTypes.check }),
        column.create("리비전", "REVNUM", { width: 50, columnType: enumColumnTypes.number, decimalPrecision: 0 }),
        column.create('등록일자', 'REGDATE', { width: 100 }),
        column.split()
    ]);

    // 검사항목 리스트 
    ItsGrid.Create('grid4', { isCheckBoxGrid: true }, [
        column.create('REVCD', 'REVCD', { width: 100, hidden: true }),
        column.create("공정코드", "PRCCD", { width: 100, readOnly: false }),
        column.create("공정명", "PRCNM", { width: 100 }),
        column.create("검사항목코드", "STDCD", { width: 100, hidden: true }),        
        column.create("검사항목", "STDNM", { width: 100}),
        column.create("검사방법", "STDCHKTP", { width: 100, columnType: enumColumnTypes.combo, gpcd: 'STDCHKTP', align: 'center' }),
        column.create("측정부위", "STDPOINT", { width: 100, columnType: enumColumnTypes.combo, gpcd: 'STDPOINT', align: 'center' }),
        column.band('판정기준', {}, [
            column.create('기준값', 'STDVAL', { width: 60,  readOnly: false }),
            column.create("단위", "STDUNIT", { width: 60, columnType: enumColumnTypes.combo, gpcd: 'STDUNIT', align: 'center' }),
            column.create('범위', 'STDRANGE', { width: 60, columnType: enumColumnTypes.combo, gpcd: 'STDRANGE', align: 'center' }),
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
    // 추가 팝업 
    ItsGrid.Create('grid_STD', { isCheckBoxGrid: true }, [
        column.create("검사항목코드", "STDCD", { width: 200, hidden: true }),
        column.create("검사항목", "STDNM", { width: 200 }),
        column.create("검사방법", "STDCHKTP", { width: 60, columnType: enumColumnTypes.combo, gpcd: 'STDCHKTP', align: 'center' }),
        column.create("측정부위", "STDPOINT", { width: 60, columnType: enumColumnTypes.combo, gpcd: 'STDPOINT', align: 'center' }),
        column.band('판정기준', {}, [
            column.create("단위", "STDUNIT", { width: 60, columnType: enumColumnTypes.combo, gpcd: 'STDUNIT', align: 'center' }),
            column.create('범위', 'STDRANGE', { width: 60, columnType: enumColumnTypes.combo, gpcd: 'STDRANGE', align: 'center' }),
            column.create('판정기준', 'STDJUDGE', { width: 200 }),
        ]),
        
        column.create('비고', 'REMARK', { width: 200 }),
        column.split()
    ]);

    /*********************************************************************************************************************************************************************************/
    // 복사 팝업 
    ItsGrid.Create('grid2_COPY', { isCheckBoxGrid: false }, [
        column.create('품목유형', 'ITEMTP', { width: 80, columnType: enumColumnTypes.combo, gpcd: 'ITEMTP', align: 'center' }),
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
        column.create("공정코드", "PRCCD", { width: 100 }),
        column.create("공정명", "PRCNM", { width: 100 }),
        column.create("검사항목코드", "STDCD", { width: 100, hidden: true }),
        column.create("검사항목", "STDNM", { width: 100 }),
        column.create("검사방법", "STDCHKTP", { width: 100, columnType: enumColumnTypes.combo, gpcd: 'STDCHKTP', align: 'center' }),
        column.create("측정부위", "STDPOINT", { width: 100, columnType: enumColumnTypes.combo, gpcd: 'STDPOINT', align: 'center' }),
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
        //column.create("파일키", "FILEKEY", { width: 80, hidden: true }),
        //column.create('사진', 'FILENAME', { width: 100, columnType: enumColumnTypes.button, iconCls: 'fa-file' }),
        column.split()
    ]);

    ItsGrid.Get('grid4').columns[ItsGrid.$colIndex('grid4', 'PRCCD')].visible = false;
    ItsGrid.Get('grid4').columns[ItsGrid.$colIndex('grid4', 'PRCNM')].visible = false;
   
};
/*********************************************************************************************************************************************************************************/
// 검사구분 조회
ItsButton.EventSearch = function () {
    ItsGrid.Clear('grid2');

    var maria = new ItsMaria('TQM1001_R02 ', 'LIST_STDTP');

    maria.AddPanel('sdiv1');

    maria.CallProc();

    if (maria.isError) {
        maria.ShowErrMsg();
        return;
    }

    ItsGrid.SetStore('grid1', maria.store);
    ItsMsg.Toast(maria.store.Length() + '건이 조회되었습니다.');
};

// 검사구분 선택시 - 품목조회
ItsGrid.Event('grid1').onSelect = function (rowIndex, field) {
    ItsGrid.Clear('grid2');
    ItsGrid.Clear('grid3');
    ItsGrid.Clear('grid4');

    var maria = new ItsMaria('TQM1001_R02 ', 'LIST_MSTITEM');

    var STDTP = ItsGrid.GetValue('grid1', rowIndex, 'STDTP')

    maria.AddParam('STDTP', STDTP);
    maria.AddPanel('sdiv1');

    maria.CallProc();

    if (maria.isError) {
        maria.ShowErrMsg();
        return;
    }

    ItsGrid.SetStore('grid2', maria.store.YnToBool('EXISTSYN'));
    ItsGrid.Get('grid2').autoSizeColumns();

    if (STDTP == 'PRCTEST') {
        ItsGrid.Get('grid4').columns[ItsGrid.$colIndex('grid4', 'PRCCD')].visible = true;
        ItsGrid.Get('grid4').columns[ItsGrid.$colIndex('grid4', 'PRCNM')].visible = true;
    }
    else {
        ItsGrid.Get('grid4').columns[ItsGrid.$colIndex('grid4', 'PRCCD')].visible = false;
        ItsGrid.Get('grid4').columns[ItsGrid.$colIndex('grid4', 'PRCNM')].visible = false;
    }
        
};

// 품목 선택시 - 검사리비전 조회
ItsGrid.Event('grid2').onSelect = function (rowIndex, field) {
    ItsGrid.Clear('grid3');
    ItsGrid.Clear('grid4');
    
    var maria = new ItsMaria('TQM1001_R02', 'LIST_RPTREV');

    maria.AddParam('STDTP', ItsGrid.GetValue('grid1', ItsGrid.GetCurrentIndex('grid1'), 'STDTP'));
    maria.AddParam('ITEMCD', ItsGrid.GetValue('grid2', ItsGrid.GetCurrentIndex('grid2'), 'ITEMCD'));

    maria.CallProc();

    if (maria.isError) {
        maria.ShowErrMsg();
        return;
    } 

    ItsGrid.SetStore('grid3', maria.store.YnToBool('USEYN'));

    var USEYN = ItsGrid.GetValue('grid3', ItsGrid.GetCurrentIndex('grid3'), 'USEYN')

    if (USEYN == true) {
        ItsButton.Show('btn_COPY_POP');
        ItsButton.Show('btn_ADD_POP');
        ItsButton.Show('btn_SAVE_DETAIL');
        ItsButton.Show('btn_DEL_DETAIL');
    } else {
        ItsButton.Hide('btn_COPY_POP');
        ItsButton.Hide('btn_ADD_POP');
        ItsButton.Hide('btn_SAVE_DETAIL');
        ItsButton.Hide('btn_DEL_DETAIL');
    }
};

// 리비전 선택시 - 검사항목리스트 조회
ItsGrid.Event('grid3').onSelect = function (rowIndex, field) {
    ItsGrid.Clear('grid4');

    var maria = new ItsMaria('TQM1001_R02 ', 'LIST_MSTRPTREV_DETAIL');

    maria.AddParam('REVCD', ItsGrid.GetValue('grid3', rowIndex, 'REVCD'));
    maria.CallProc();

    if (maria.isError) {
        maria.ShowErrMsg();
        return;
    }

    ItsGrid.SetStore('grid4', maria.store);
    ItsGrid.Get('grid4').autoSizeColumns();
};
/*********************************************************************************************************************************************************************************/
// 리비전 갱신 버튼
ItsButton.Event('btn_RENEW_REV').onClick = function () {
    ItsMsg.Confirm("추가/갱신하시겠습니까?", function () {
        var maria2 = new ItsMaria('TQM1001_R02', 'RENEW_REV');

        maria2.AddParam('STDTP', ItsGrid.GetValue('grid1', ItsGrid.GetCurrentIndex('grid1'), 'STDTP'));
        maria2.AddParam('ITEMCD', ItsGrid.GetValue('grid2', ItsGrid.GetCurrentIndex('grid2'), 'ITEMCD'));
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
    ItsMsg.Confirm("리비전을 삭제하시겠습니까?", function () {
        var maria = new ItsMaria('TQM1001_R02 ', 'DEL_REV');

        maria.AddParam('STDTP', ItsGrid.GetValue('grid1', ItsGrid.GetCurrentIndex('grid1'), 'STDTP'));
        maria.AddParam('ITEMCD', ItsGrid.GetValue('grid2', ItsGrid.GetCurrentIndex('grid2'), 'ITEMCD'));
        maria.AddParam('REVCD', ItsGrid.GetValue('grid3', ItsGrid.GetCurrentIndex('grid3'), 'REVCD'));
        maria.CallProc();

        if (maria.isError) {
            maria.ShowErrMsg();
            return;
        }

        // 리비전 리스트 조회
        ItsGrid.Event('grid2').onSelect(ItsGrid.GetCurrentIndex('grid2'));
    });

}


///*********************************************************************************************************************************************************************************/
// 검사항목 추가팝업 오픈
ItsButton.Event('btn_ADD_POP').onClick = function () {
    if (ItsGrid.Length('grid3') > 0) {
        ItsCombo.SetValue('cmb_STDTP_ADDSTD', ItsGrid.GetValue('grid1', ItsGrid.GetCurrentIndex('grid1'), 'STDTP'));
        ItsText.SetValue('txt_ITEMCD_ADDSTD', ItsGrid.GetValue('grid2', ItsGrid.GetCurrentIndex('grid2'), 'ITEMCD'));

        //ItsGrid.Clear('grid_STD');

        var maria = new ItsMaria('TQM1001_R02', 'LIST_STD');

        maria.AddParam('STDTP', ItsGrid.GetValue('grid1', ItsGrid.GetCurrentIndex('grid1'), 'STDTP'));
        maria.AddParam('REVCD', ItsGrid.GetValue('grid3', ItsGrid.GetCurrentIndex('grid3'), 'REVCD'));

        maria.CallProc();

        if (maria.isError) {
            maria.ShowErrMsg();
            return;
        }


        ItsGrid.SetStore('grid_STD', maria.store);

        ItsPop.Open('pop_ADDSTD');

        //ItsGrid.Get('grid_STD').autoSizeColumns();
    }
}

// 검사항목 추가
ItsButton.Event('btn_ADDSTD').onClick = function () {
    var indx = ItsGrid.Length('grid4');

    for (var i = 0; i < ItsGrid.Length('grid_STD'); i++) {
        if (ItsGrid.IsChecked('grid_STD', i)) {
            var data = ItsGrid.GetRowData('grid_STD', i);
            var newSTDCD = data['STDCD'];
            var newSTDCHKTP = data['STDCHKTP'];
            var STDTP = ItsGrid.GetValue('grid1', ItsGrid.GetCurrentIndex('grid1'), 'STDTP');
            var newSTDRANGE = data['STDRANGE'];
            // 수입검사와 출고검사 일때는 동일한 STDCD가 존재하는지 확인하고 복사가 안되도록
            var isDuplicate = false;
                for (var j = 0; j < ItsGrid.Length('grid4'); j++) {
                    if (ItsGrid.GetValue('grid4', j, 'STDCD') === newSTDCD) {
                        isDuplicate = true;
                        break;
                    }
                }

            if (isDuplicate)
                continue; // 중복이면 복사하지 않음            
          
            // 중복이 아니면 복사
            ItsGrid.AddRow('grid4', indx, data);

            ItsGrid.SetValue('grid4', indx, 'SAMPLESIZE', 1);

            if (newSTDCHKTP == '01') {
                //ItsGrid.SetValue('grid4', indx, 'STDVAL', 'OK/NG');
                //ItsGrid.SetValue('grid4', indx, 'STDMINUS', 0);
                //ItsGrid.SetValue('grid4', indx, 'STDPLUS', 0);
            }

            //if (newSTDCHKTP === '02') {
            //    if (['01', '02', '03', '04', '05'].includes(newSTDRANGE)) {
            //        ItsGrid.SetValue('grid4', indx, 'STDMINUS', 0);
            //        ItsGrid.SetValue('grid4', indx, 'STDPLUS', 0);
            //    } else if (newSTDRANGE === '06') {
            //        ItsGrid.SetValue('grid4', indx, 'STDVAL', 0);
            //    }
            //}

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
/*********************************************************************************************************************************************************************************/

ItsGrid.Event('grid4').onChanged = function (rowIndex, field) {
    var STDCHKTP = ItsGrid.GetValue('grid4', rowIndex, 'STDCHKTP');
    var STDRANGE = ItsGrid.GetValue('grid4', rowIndex, 'STDRANGE');
    var SAMPLESIZE = ItsGrid.GetValue('grid4', rowIndex, 'SAMPLESIZE');
    var STDJUDEG = ItsGrid.GetValue('grid4', rowIndex, 'STDJUDGE');

    // 1. 검사타입
    if (STDCHKTP === '01') {
        //ItsGrid.SetValue('grid4', rowIndex, 'STDVAL', 'OK/NG');
        //ItsGrid.SetValue('grid4', rowIndex, 'STDMINUS', '0');
        //ItsGrid.SetValue('grid4', rowIndex, 'STDPLUS', '0');        

    } else {
        // 값이 숫자가 아니면 0으로 표현
        ItsGrid.SetValue('grid4', rowIndex, 'STDMINUS',
            isNaN(Number(ItsGrid.GetValue('grid4', rowIndex, 'STDMINUS'))) ? 0 : Number(ItsGrid.GetValue('grid4', rowIndex, 'STDMINUS'))
        );

        ItsGrid.SetValue('grid4', rowIndex, 'STDPLUS',
            isNaN(Number(ItsGrid.GetValue('grid4', rowIndex, 'STDPLUS'))) ? 0 : Number(ItsGrid.GetValue('grid4', rowIndex, 'STDPLUS'))
        );
        ItsGrid.SetValue('grid4', rowIndex, 'STDVAL',
            isNaN(Number(ItsGrid.GetValue('grid4', rowIndex, 'STDPLUS'))) ? 0 : Number(ItsGrid.GetValue('grid4', rowIndex, 'STDVAL'))
        );


        if (['01', '02', '03', '04', '05'].includes(STDRANGE)) {
            ItsGrid.SetValue('grid4', rowIndex, 'STDMINUS', 0);
            ItsGrid.SetValue('grid4', rowIndex, 'STDPLUS', 0);
                   
            var newSTDVAL = ItsGrid.GetValue('grid4', rowIndex, 'STDVAL');
       
            //if (isNaN(newSTDVAL)  || newSTDVAL == null || newSTDVAL == '') {
            //    ItsGrid.SetValue('grid4', rowIndex, 'STDVAL', 0);
            //}


        } else if (STDRANGE === '06') {

            var newSTDVAL = ItsGrid.GetValue('grid4', rowIndex, 'STDVAL');

            //ItsGrid.SetValue('grid4', rowIndex, 'STDVAL', 0);
        }
        var newSTDVAL = ItsGrid.GetValue('grid4', rowIndex, 'STDVAL');
        var newSTDPLUS = ItsGrid.GetValue('grid4', rowIndex, 'STDPLUS');
        var newSTDMINUS = ItsGrid.GetValue('grid4', rowIndex, 'STDMINUS');

        //if (isNaN(newSTDVAL) || newSTDVAL == null || newSTDVAL == '') {
        //    ItsGrid.SetValue('grid4', rowIndex, 'STDVAL', 0);
        //}
        //if (isNaN(newSTDPLUS) || newSTDPLUS == null || newSTDPLUS == '') {
        //    ItsGrid.SetValue('grid4', rowIndex, 'STDPLUS', 0);
        //}
        //if (isNaN(newSTDMINUS) || newSTDMINUS == null || newSTDMINUS == '') {
        //    ItsGrid.SetValue('grid4', rowIndex, 'STDMINUS', 0);
        //}
    }

}
/*********************************************************************************************************************************************************************************/

// 검사항목리스트 저장
ItsButton.Event('btn_SAVE_DETAIL').onClick = function () {
    ItsMsg.Confirm("저장하시겠습니까?", function () {
        var maria = new ItsMaria('TQM1001_R02', 'UPDATE_MSTRPTREV_DETAIL');

        maria.AddParam('REVCD', ItsGrid.GetValue('grid3', ItsGrid.GetCurrentIndex('grid3'), 'REVCD'));

        for (var i = 0; i < ItsGrid.Length('grid4'); i++) {
            if (ItsGrid.IsChecked('grid4', i)) {
                maria.AddList('PRCCD_LIST', ItsGrid.GetValue('grid4', i, 'PRCCD'));
                maria.AddList('STDCD_LIST', ItsGrid.GetValue('grid4', i, 'STDCD'));
                maria.AddList('STDNM_LIST', ItsGrid.GetValue('grid4', i, 'STDNM'));
                maria.AddList('STDCHKTP_LIST', ItsGrid.GetValue('grid4', i, 'STDCHKTP'));
                maria.AddList('STDPOINT_LIST', ItsGrid.GetValue('grid4', i, 'STDPOINT'));
                maria.AddList('STDVAL_LIST', ItsGrid.GetValue('grid4', i, 'STDVAL'));
                maria.AddList('STDRANGE_LIST', ItsGrid.GetValue('grid4', i, 'STDRANGE'));
                maria.AddList('STDMINUS_LIST', ItsGrid.GetValue('grid4', i, 'STDMINUS'));
                maria.AddList('STDPLUS_LIST', ItsGrid.GetValue('grid4', i, 'STDPLUS'));
                maria.AddList('STDUNIT_LIST', ItsGrid.GetValue('grid4', i, 'STDUNIT'));
                maria.AddList('STDJUDGE_LIST', ItsGrid.GetValue('grid4', i, 'STDJUDGE'));
                maria.AddList('REMARK_LIST', ItsGrid.GetValue('grid4', i, 'REMARK'));
                maria.AddList('SORTNO_LIST', ItsGrid.GetValue('grid4', i, 'SORTNO'));

                maria.AddList('SAMPLESIZE_LIST', ItsGrid.GetValue('grid4', i, 'SAMPLESIZE'));

            }
        }

        maria.CallProc();

        if (maria.isError) {
            maria.ShowErrMsg();
            return;
        }

        var REVCD = ItsGrid.GetValue('grid3', ItsGrid.GetCurrentIndex('grid3'), 'REVCD');

        ItsGrid.Setkey('grid3', 'REVCD', REVCD);

        ItsGrid.Event('grid2').onSelect(ItsGrid.GetCurrentIndex('grid2'));
    });
};

// 검사항목 삭제
ItsButton.Event('btn_DEL_DETAIL').onClick = function () {
    ItsMsg.Confirm("검사항목을 삭제하시겠습니까?", function () {
        var maria = new ItsMaria('TQM1001_R02', 'DELETE_MSTRPTREV_DETAIL');

        maria.AddParam('REVCD', ItsGrid.GetValue('grid3', ItsGrid.GetCurrentIndex('grid3'), 'REVCD'));

        for (var i = 0; i < ItsGrid.Length('grid4'); i++) {
            if (ItsGrid.IsChecked('grid4', i)) {             
                 maria.AddList('STDCD_LIST', ItsGrid.GetValue('grid4', i, 'STDCD'));
            }
        }

        maria.CallProc();

        if (maria.isError) {
            maria.ShowErrMsg();
            return;
        }

        var REVCD = ItsGrid.GetValue('grid3', ItsGrid.GetCurrentIndex('grid3'), 'REVCD');

        ItsGrid.Setkey('grid3', 'REVCD', REVCD);

        ItsGrid.Event('grid2').onSelect(ItsGrid.GetCurrentIndex('grid2'));
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

        var maria = new ItsMaria('TQM1001_R02', 'LIST_MSTITEM_COPY');

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
    var maria = new ItsMaria('TQM1001_R02', 'LIST_RPTREV');

    maria.AddParam('STDTP', ItsGrid.GetValue('grid1', ItsGrid.GetCurrentIndex('grid1'), 'STDTP'));
    maria.AddParam('ITEMCD', ItsGrid.GetValue('grid2_COPY', rowIndex, 'ITEMCD'));

    maria.CallProc();

    if (maria.isError) {
        maria.ShowErrMsg();
        return;
    }
    ItsGrid.SetStore('grid3_COPY', maria.store.YnToBool('USEYN'));    
}


// 리비전 선택시 -  검사항목리스트 조회 (검사항목복사 팝업)
ItsGrid.Event('grid3_COPY').onSelect = function (rowIndex, field) {
    // 검사항목 리스트 조회 
    var maria = new ItsMaria('TQM1001_R02 ', 'LIST_MSTRPTREV_DETAIL');    

    maria.AddParam('STDTP', ItsGrid.GetValue('grid1', ItsGrid.GetCurrentIndex('grid1'), 'STDTP'));
    maria.AddParam('REVCD', ItsGrid.GetValue('grid3_COPY', rowIndex, 'REVCD'));

    maria.CallProc();

    if (maria.isError) {
        maria.ShowErrMsg();
        return;
    }

    ItsGrid.SetStore('grid4_COPY', maria.store);
    //ItsGrid.Get('grid_detail').autoSizeColumns();
};

// 검사항목 복사
ItsButton.Event('btn_COPYSTD').onClick = function () {
    var indx = ItsGrid.Length('grid4');

    for (var i = 0; i < ItsGrid.Length('grid4_COPY'); i++) {
        if (ItsGrid.IsChecked('grid4_COPY', i)) {
            var data = ItsGrid.GetRowData('grid4_COPY', i);
            var newSTDCD = data['STDCD'];
            var newSTDCHKTP = data['STDCHKTP'];
            var STDTP = ItsGrid.GetValue('grid1', ItsGrid.GetCurrentIndex('grid1'), 'STDTP');
            var newSTDRANGE = data['STDRANGE'];
            // 수입검사와 출고검사 일때는 동일한 STDCD가 존재하는지 확인하고 복사가 안되도록
            var isDuplicate = false;
            for (var j = 0; j < ItsGrid.Length('grid4'); j++) {
                if (ItsGrid.GetValue('grid4', j, 'STDCD') === newSTDCD) {
                    isDuplicate = true;
                    break;
                }
            }

            if (isDuplicate) continue; // 중복이면 복사하지 않음

            // 중복이 아니면 복사
            ItsGrid.AddRow('grid4', indx, data);


            if (newSTDCHKTP == '01') {
                //ItsGrid.SetValue('grid4', indx, 'STDVAL', 'OK/NG');
                //ItsGrid.SetValue('grid4', indx, 'STDMINUS', 0);
                //ItsGrid.SetValue('grid4', indx, 'STDPLUS', 0);
            }

            //if (newSTDCHKTP === '02') {
            //    if (['01', '02', '03', '04', '05'].includes(newSTDRANGE)) {
            //        ItsGrid.SetValue('grid4', indx, 'STDMINUS', 0);
            //        ItsGrid.SetValue('grid4', indx, 'STDPLUS', 0);
            //    } else if (newSTDRANGE === '06') {
            //        ItsGrid.SetValue('grid4', indx, 'STDVAL', 0);
            //    }
            //}

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
/*********************************************************************************************************************************************************************************/
ItsGrid.Event('grid4').onDoubleClick = function (rowIndex, field) {
    ItsGrid.Event('grid4').onKeydownEnter(rowIndex, field);
}

ItsGrid.Event('grid4').onKeydownEnter = function (rowIndex, field) {
    if (field == 'PRCCD') {
        ItsPop.OpenFindCOM({ gpcd: 'PRCCD', ref01: 'IN', keyword: ItsGrid.GetValue('grid4', rowIndex, field) }, function (res) {
            ItsGrid.SetValue('grid4', rowIndex, 'PRCCD', res['CODE']);
            ItsGrid.SetValue('grid4', rowIndex, 'PRCNM', res['NAME']);
            ItsGrid.CheckRow('grid4', rowIndex);
        });
    }
}
/*********************************************************************************************************************************************************************************/