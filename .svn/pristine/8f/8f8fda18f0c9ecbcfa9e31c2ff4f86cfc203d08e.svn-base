
/// <reference path="../../Script/reference.js" />

/* 페이지 접근 시 수행 */
ItsPage.Load = function () {

    // 수주
    ItsGrid.Create('grid_SALODRD', { isCheckBoxGrid: true, isSubTotalGrid: true, groupField: 'MTRITEMCDNM' }, [
        column.create('원자재', 'MTRITEMCDNM', { width: 100, align: 'center', hidden: true }),     
        column.create('원자재코드', 'MTRITEMCD', { width: 100, align: 'center' }),     
        column.create('원자재명', 'MTRITEMNM', { width: 100, align: 'center' }),     
        column.create('수주일자', 'ODRDATE', { width: 100, align: 'center' }),      
        column.create('수주번호', 'SALODRDKEY', { width: 100, align: 'center' }),
        column.create('거래처', 'CUSTNM', { width: 100, align: 'center' }),        
        column.create('수주상태', 'SALODRSTT', { width: 70, columnType: enumColumnTypes.combo, gpcd: 'SALODRSTT', align: 'center' }),
        column.create('제품코드', 'SALITEMCD', { width: 100}),
        column.create('제품명', 'SALITEMNM', { width: 250 }),
        column.create('수주수량', 'ODRQTY', { width: 80, columnType: enumColumnTypes.number, groupType: enumGrouping.sum }),
        column.create('단위', 'ITEMUNIT', { width: 80, columnType: enumColumnTypes.combo, gpcd: 'ITEMUNIT', align: 'center'}),
        column.create('납기일자', 'EXPDATE', { width: 120, columnType: enumColumnTypes.date, align: 'center'}),
        column.create('출고예정일', 'OUTDATE', { width: 120, columnType: enumColumnTypes.date, align: 'center'}),          
        column.create('수주비고', 'REMARK', { width: 200, align: 'center' }),
        column.create('생산품목코드', 'SUBITEMCD', { width: 100 }),
        column.create('총필요개수', 'NEEDQTY', { width: 80, columnType: enumColumnTypes.number }),

        //column.create('지시수량', 'INSQTY', { width: 100, columnType: enumColumnTypes.number, decimalPrecision: 0, readOnly: false }),        
        
        column.split()
    ]);

    // 작업지시
    ItsGrid.Create('grid_PRDINS', { isCheckBoxGrid: true, isSubTotalGrid: true }, [
        column.create('작업지시번호', 'PRDINSKEY', { width: 100, align: 'center' }),
        column.create('지시일자', 'INSDATE', { width: 100, align: 'center' }),
        column.create('지시상태', 'WORKSTT', { width: 70, columnType: enumColumnTypes.combo, gpcd: 'WORKSTT', align: 'center' }),
        column.create('설비코드', 'EQMCD', { width: 100, align: 'center' }),
        column.create('설비명', 'EQMNM', { width: 100, align: 'center' }),
        column.create('원자재코드', 'MTRITEMCD', { width: 100, align: 'center' }),
        column.create('원자재명', 'MTRITEMNM', { width: 100, align: 'center' }),
        column.create('특이사항', 'REMARK', { width: 100, align: 'center' }),
        column.band('작업지시서', {}, [
            column.create("파일명", "FILENAME", { width: 170 }),
            column.create('파일관리', 'POP_FILE_1', { width: 80, columnType: enumColumnTypes.button, iconCls: 'fa-file' }),
            column.create('파일보기', 'OPEN_FILE_1', { width: 80, columnType: enumColumnTypes.button, iconCls: 'fa-search' }),
            column.create('파일다운로드', 'DOWN_FILE_1', { width: 80, columnType: enumColumnTypes.button, iconCls: 'fa-download' }),    
        ]),

        column.split()
    ]);

    // 작업지시상세
    ItsGrid.Create('grid_PRDINS_DETAIL', { isCheckBoxGrid: true, isSubTotalGrid: true }, [
        column.create('생산품목코드', 'SUBITEMCD', { width: 100 }),
        column.create('지시수량', 'INSQTY', { width: 100, columnType: enumColumnTypes.number, decimalPrecision: 0 }),

        column.band('수주정보', {}, [
            column.create('수주일자', 'ODRDATE', { width: 100, align: 'center' }),
            column.create('수주번호', 'SALODRDKEY', { width: 100, align: 'center' }),
            column.create('거래처', 'CUSTNM', { width: 100, align: 'center' }),
            column.create('수주상태', 'SALODRSTT', { width: 70, columnType: enumColumnTypes.combo, gpcd: 'SALODRSTT', align: 'center' }),
            column.create('제품코드', 'SALITEMCD', { width: 100 }),
            column.create('제품명', 'SALITEMNM', { width: 250 }),
            column.create('수주수량', 'ODRQTY', { width: 80, columnType: enumColumnTypes.number, decimalPrecision: 0, }),
            column.create('단위', 'ITEMUNIT', { width: 80, columnType: enumColumnTypes.combo, gpcd: 'ITEMUNIT', align: 'center' }),
            column.create('납기일자', 'EXPDATE', { width: 120, columnType: enumColumnTypes.date, align: 'center' }),
            column.create('출고예정일', 'OUTDATE', { width: 120, columnType: enumColumnTypes.date, align: 'center' }),
            column.create('수주비고', 'REMARK', { width: 200, align: 'center' }),
            column.create('가공품총필요개수', 'NEEDQTY', { width: 80, columnType: enumColumnTypes.number, decimalPrecision: 0, }),
        ]),

        column.split()
    ]);

    // 수주없는 생산품
    ItsGrid.Create('grid_EXTRA_ITEM', { isCheckBoxGrid: true, isSubTotalGrid: false }, [
        column.create('품목유형', 'ITEMTP', { width: 70, columnType: enumColumnTypes.combo, gpcd: 'ITEMTP', align: 'center' }),
        column.create('품목코드', 'ITEMCD', { width: 150, readOnly: false }),
        column.create('품명', 'ITEMNM', { width: 250 }),
        column.create('단위', 'ITEMUNIT', { width: 70, columnType: enumColumnTypes.combo, gpcd: 'ITEMUNIT', align: 'center' }),
        column.create('지시수량', 'INSQTY', { width: 100, columnType: enumColumnTypes.number, decimalPrecision: 0, readOnly: false }),
        
        column.split()
    ]);
};
/**********************************************************************************************************************************************************************/
// 조회
ItsButton.EventSearch = function () {
    if (ItsTab.GetIndex('tab1') == 0) {
        // 수주조회
        var maria = new ItsMaria('PRD0001_R02', 'LIST_SALODRD');

        maria.AddParam('SDATE', ItsDateRange.GetValueFrom('dateR_ODRDATE'));
        maria.AddParam('EDATE', ItsDateRange.GetValueTo('dateR_ODRDATE'));
        maria.AddParam('ITEMCD', ItsFind.GetValue('find_SALITEM'));
        maria.AddParam('CUSTCD', ItsFind.GetValue('find_SALCUST'));

        maria.CallProc();

        if (maria.isError) {
            maria.ShowErrMsg();
            return;
        }

        ItsGrid.SetStore('grid_SALODRD', maria.store);

        ItsGrid.Get('grid_SALODRD').autoSizeColumns();
    }
    else if (ItsTab.GetIndex('tab1') == 1) {
        ItsGrid.Clear('grid_PRDINS_DETAIL');

        // 가공작업지시 조회 
        var maria = new ItsMaria('PRD0001_R02', 'LIST_PRDINS_CUT');

        maria.AddParam('SDATE', ItsDateRange.GetValueFrom('dataR_INSDATE'));
        maria.AddParam('EDATE', ItsDateRange.GetValueTo('dataR_INSDATE'));
        maria.AddParam('EQMCD', ItsFind.GetValue('find_EQMCD_2'));

        maria.CallProc();

        if (maria.isError) {
            maria.ShowErrMsg();
            return;
        }

        ItsGrid.SetStore('grid_PRDINS', maria.store);

        ItsGrid.Get('grid_PRDINS').autoSizeColumns();
    }

};
/**********************************************************************************************************************************************************************/
// 가공작업지시 선택시 가공작업지시 상세 조회 
// (가공 작업지시 - 수주품목, 수주없는생산품목 매칭정보)
ItsGrid.Event('grid_PRDINS').onSelect = function (rowIndex) {
    var maria = new ItsMaria('PRD0001_R02', 'LIST_PRDINS_SALODRD_EXTRAITEM');

    maria.AddParam('PRDINSKEY', ItsGrid.GetValue('grid_PRDINS', rowIndex, 'PRDINSKEY'));

    maria.CallProc();

    if (maria.isError) {
        maria.ShowErrMsg();
        return;
    }

    ItsGrid.SetStore('grid_PRDINS_DETAIL', maria.store);

    ItsGrid.Get('grid_PRDINS_DETAIL').autoSizeColumns();
};

ItsGrid.Event('grid_PRDINS').onButtonClick = function (rowindex, field) {
    if (field == 'POP_FILE_1') {
        // 작업지시서 파일관리 오픈
        GET_FILE_1(rowindex);

        ItsPop.Open('pop_FILE_1');
    }
    else if (field == 'OPEN_FILE_1') {
        var url = ItsGrid.GetValue('grid_PRDINS', rowindex, 'FILEURL');

        if (url != "" && url != undefined) {
            window.open(url);
        }
    }
    else if (field == 'DOWN_FILE_1') {
        var url = ItsGrid.GetValue('grid_PRDINS', rowindex, 'FILEURL');
        var FILENAME = ItsGrid.GetValue('grid_PRDINS', rowindex, 'FILENAME');

        if (url != '' && url != undefined) {
            var link = document.createElement('a');
            link.href = url;
            link.download = FILENAME.split(' | ')[0];
            link.click();
        }
        else {
            ItsMsg.Alert('등록된 파일이 없습니다.');
        }
    }
};

GET_FILE_1 = function (rowindex) {
    var maria = new ItsMaria('PRD0001_R02', 'GET_FILE_1');

    maria.AddParam('PRDINSKEY', ItsGrid.GetValue('grid_PRDINS', rowindex, 'PRDINSKEY'));

    maria.CallProc();

    if (maria.isError) {
        maria.ShowErrMsg();
        return;
    }

    ItsFileManager.SetFileKey('fm1', maria.store.data[0]["FILEKEY"]);
    ItsFileManager.SetFileName('fm1', maria.store.data[0]["FILENAME"]);
    ItsText.SetValue('txt_URL_FILE_1', maria.store.data[0]["FILEURL"]);
}

// 파일 업로드 버튼
ItsFileManager.Event('fm2').onUpload = function (id, filekey) {
    ItsMsg.Alert("파일 업로드 완료");
}

// 파일 업로드 취소
ItsFileManager.Event('fm2').onDelete = function (id, filekey) {
    ItsFileManager.SetFileName('fm2', '');
    ItsMsg.Alert("파일 업로드 취소");
}
/**********************************************************************************************************************************************************************/
// 파일업로드
ItsFileManager.Event('fm1').onUpload = function (id, filekey) {
    var maria = new ItsMaria('PRD0001_R02', 'UPLOAD_FILE_1');

    var PRDINSKEY = ItsGrid.GetValue('grid_PRDINS', ItsGrid.GetCurrentIndex('grid_PRDINS'), 'PRDINSKEY');

    maria.AddParam('PRDINSKEY', PRDINSKEY);
    maria.AddParam('FILEKEY', filekey);

    maria.CallProc();

    if (maria.isError) {
        maria.ShowErrMsg();
        return;
    }

    GET_FILE_1(ItsGrid.GetCurrentIndex('grid_PRDINS'));
    ItsMsg.Toast("업로드 완료");
}

// 파일삭제
ItsFileManager.Event('fm1').onDelete = function (id, filekey) {
    var maria = new ItsMaria('PRD0001_R02', 'DEL_FILE_1');

    var PRDINSKEY = ItsGrid.GetValue('grid_PRDINS', ItsGrid.GetCurrentIndex('grid_PRDINS'), 'PRDINSKEY');

    maria.AddParam('PRDINSKEY', PRDINSKEY);

    maria.CallProc();

    if (maria.isError) {
        maria.ShowErrMsg();
        return;
    }

    ItsPage.InitData('pfdiv1');
    ItsMsg.Toast("삭제 완료");
}

// 파일 다운로드
ItsButton.Event('btn_DOWN_FILE_1').onClick = function () {
    var url = ItsText.GetValue('txt_URL_FILE_1');
    var FILENAME = ItsFileManager.GetFileName('fm1');

    if (url != '' && url != undefined) {
        var link = document.createElement('a');
        //url = url.replace('http://mes.optisco.com:8019//', '../../');
        link.href = url;
        link.download = FILENAME.split(' | ')[0];
        link.click();
    }
    else {
        ItsMsg.Alert('등록된 파일이 없습니다.');
    }
}

ItsPop.Event('pop_FILE_1').onPopClosed = function () {
    var PRDINSKEY = ItsGrid.GetValue('grid_PRDINS', ItsGrid.GetCurrentIndex('grid_PRDINS'), 'PRDINSKEY');
    ItsGrid.Setkey('grid_PRDINS', 'PRDINSKEY', PRDINSKEY);
    ItsButton.EventSearch();
}
/**********************************************************************************************************************************************************************/
// 작업지시등록 팝업오픈
ItsButton.Event('btn_POP_MAKE_PRDINS_CUT').onClick = function () {
    if (ItsGrid.Length('grid_SALODRD') == 0) {
        ItsMsg.Alert('수주품목을 조회하세요.');
        return;
    }

    var count_checked = 0;
    var MTRITEMCD = '';
    var MTRITEMNM = '';

    for (var i = 0; i < ItsGrid.Length('grid_SALODRD'); i++) {
        if (ItsGrid.IsChecked('grid_SALODRD', i)) {
            count_checked += 1;
            
            if (MTRITEMCD == '') {
                MTRITEMCD = ItsGrid.GetValue('grid_SALODRD', i, 'MTRITEMCD');
                MTRITEMNM = ItsGrid.GetValue('grid_SALODRD', i, 'MTRITEMNM');
            }
            else {
                if (MTRITEMCD != ItsGrid.GetValue('grid_SALODRD', i, 'MTRITEMCD')) {
                    ItsMsg.Alert('원자재가 같은 수주품목만 선택하세요.');
                    return;
                }
            }

        }
    }

    if (count_checked == 0) {
        ItsMsg.Alert('수주품목을 체크하세요.');
        return;
    }

    ItsPage.InitData('div_MAKE_PRDINS_CUT');

    ItsText.SetValue('txt_MTRITEMCD', MTRITEMCD);
    ItsText.SetValue('txt_MTRITEMNM', MTRITEMNM);

    ItsPop.Open('pop_MAKE_PRDINS_CUT');
}
/**********************************************************************************************************************************************************************/

ItsGrid.Event('grid_EXTRA_ITEM').onDoubleClick = function (rowIndex, field) {
    ItsGrid.Event('grid_EXTRA_ITEM').onKeydownEnter(rowIndex, field);
}

ItsGrid.Event('grid_EXTRA_ITEM').onKeydownEnter = function (rowIndex, field) {
    if (field == 'ITEMCD' || field == 'ITEMNM') {
        ItsPop.OpenFindCOM({ gpcd: 'ITEMCD', keyword: ItsGrid.GetValue('grid_EXTRA_ITEM', rowIndex, 'ITEMCD') }, function (res) {
            ItsGrid.SetValue('grid_EXTRA_ITEM', rowIndex, 'ITEMCD', res['CODE']);
            ItsGrid.SetValue('grid_EXTRA_ITEM', rowIndex, 'ITEMNM', res['NAME']);
            ItsGrid.SetValue('grid_EXTRA_ITEM', rowIndex, 'ITEMTP', res['REF01']);
            ItsGrid.SetValue('grid_EXTRA_ITEM', rowIndex, 'ITEMUNIT', res['REF06']);
            ItsGrid.CheckRow('grid_EXTRA_ITEM', rowIndex);
        });

    }

}

// 행 추가 
ItsButton.Event('btn_ADD_ROW').onClick = function () {
    ItsGrid.AddRow('grid_EXTRA_ITEM');
};

// 가공 작업지시 등록
ItsButton.Event('btn_MAKE_PRDINS_CUT').onClick = function () {
    var maria = new ItsMaria('PRD0001_R02', 'MAKE_PRDINS_CUT');

    maria.AddParam('INSDATE', ItsDate.GetValue('date_INSDATE'));
    maria.AddParam('EQMCD', ItsFind.GetValue('find_EQMCD'));
    maria.AddParam('MTRITEMCD', ItsText.GetValue('txt_MTRITEMCD'));
    maria.AddParam('REMARK', ItsFind.GetValue('txt_REMARK_PRDINS'));
    maria.AddParam('FILEKEY', ItsFileManager.GetFileKey('fm2'));

    if (ItsFileManager.GetFileName('fm2') != '' && ItsFileManager.GetFileKey('fm2') == '') { 
        ItsMsg.Alert('파일업로드 되지 않았습니다.\n파일 업로드 버튼을 누른 후 진행해주세요. \n(선택 오른쪽 파란색 버튼)');
        return;
    }

    for (var i = 0; i < ItsGrid.Length('grid_SALODRD'); i++) {
        if (ItsGrid.IsChecked('grid_SALODRD', i)) {
            maria.AddList('SALODRDKEY_LIST', ItsGrid.GetValue('grid_SALODRD', i, 'SALODRDKEY'));
            maria.AddList('SUBITEM_LIST', ItsGrid.GetValue('grid_SALODRD', i, 'SUBITEMCD'));
            maria.AddList('INSQTY_LIST', ItsGrid.GetValue('grid_SALODRD', i, 'NEEDQTY'));
        }
    }

    for (var i = 0; i < ItsGrid.Length('grid_EXTRA_ITEM'); i++) {
        if (ItsGrid.IsChecked('grid_EXTRA_ITEM', i)) {
            var INSQTY = ItsGrid.GetValue('grid_EXTRA_ITEM', i, 'INSQTY');
            
            if (INSQTY == undefined || INSQTY == 0) {
                ItsMsg.Alert('지시수량을 입력하세요. (수주없는 생산품)');
                return;
            }

            maria.AddList('EXTRAITEM_LIST', ItsGrid.GetValue('grid_EXTRA_ITEM', i, 'ITEMCD'));
            maria.AddList('INSQTY_LIST_2', INSQTY);
        }
    }

    maria.CallProc();

    if (maria.isError) {
        maria.ShowErrMsg();
        return;
    }

    ItsPop.Close('pop_MAKE_PRDINS_CUT');

    ItsButton.EventSearch();

    ItsMsg.Alert('가공 작업지시가 등록되었습니다.');
};

// 가공 작업지시 삭제
ItsButton.Event('btn_DEL_PRDINS_CUT').onClick = function () {
    ItsMsg.Confirm("가공 작업지시를 삭제하시겠습니까?", function () {
        var maria = new ItsMaria('PRD0001_R02', 'DEL_PRDINS_CUT');

        var PRDINSKEY = ItsGrid.GetValue('grid_PRDINS', ItsGrid.GetCurrentIndex('grid_PRDINS'), 'PRDINSKEY');

        maria.AddParam('PRDINSKEY', PRDINSKEY);

        maria.CallProc();

        if (maria.isError) {
            maria.ShowErrMsg();
            return;
        }

        ItsButton.EventSearch();
        
        ItsMsg.Alert('가공 작업지시가 삭제되었습니다.');
    });
}

// 작업지시 상세 수정 
//ItsButton.Event('btn_UPDATE_PRDINS_DETAIL').onClick = function () {
//    ItsMsg.Confirm("작업지시 상세를 수정하시겠습니까?", function () {
//        var maria = new ItsMaria('PRD0001_R02', 'UPDATE_PRDINS_DETAIL');

//        var PRDINSKEY = ItsGrid.GetValue('grid_PRDINS', ItsGrid.GetCurrentIndex('grid_PRDINS'), 'PRDINSKEY');

//        maria.AddParam('PRDINSKEY', PRDINSKEY);

//        for (var i = 0; i < ItsGrid.Length('grid_PRDINS_DETAIL'); i++) {
//            if (ItsGrid.IsChecked('grid_PRDINS_DETAIL', i)) {
//                maria.AddList('SALODRDKEY_LIST', ItsGrid.GetValue('grid_PRDINS_DETAIL', i, 'SALODRDKEY'));
//                maria.AddList('SUBITEM_LIST', ItsGrid.GetValue('grid_PRDINS_DETAIL', i, 'SUBITEMCD'));
//                maria.AddList('INSQTY_LIST', ItsGrid.GetValue('grid_PRDINS_DETAIL', i, 'INSQTY'));
//            }
//        }

//        maria.CallProc();

//        if (maria.isError) {
//            maria.ShowErrMsg();
//            return;
//        }

//        ItsGrid.Setkey('grid_PRDINS', 'PRDINSKEY', PRDINSKEY);
//        ItsButton.EventSearch();

//        ItsMsg.Alert('작업지시 상세가 수정되었습니다.');
//    });
//}

// 작업지시 상세 삭제
ItsButton.Event('btn_DEL_PRDINS_DETAIL').onClick = function () {
    ItsMsg.Confirm("작업지시 상세를 삭제하시겠습니까?", function () {
        var maria = new ItsMaria('PRD0001_R02', 'DEL_PRDINS_DETAIL');

        var PRDINSKEY = ItsGrid.GetValue('grid_PRDINS', ItsGrid.GetCurrentIndex('grid_PRDINS'), 'PRDINSKEY');

        maria.AddParam('PRDINSKEY', PRDINSKEY);

        for (var i = 0; i < ItsGrid.Length('grid_PRDINS_DETAIL'); i++) {
            if (ItsGrid.IsChecked('grid_PRDINS_DETAIL', i)) {
                maria.AddList('SALODRDKEY_LIST', ItsGrid.GetValue('grid_PRDINS_DETAIL', i, 'SALODRDKEY'));
                maria.AddList('SUBITEM_LIST', ItsGrid.GetValue('grid_PRDINS_DETAIL', i, 'SUBITEMCD'));
            }
        }

        maria.CallProc();

        if (maria.isError) {
            maria.ShowErrMsg();
            return;
        }

        ItsGrid.Setkey('grid_PRDINS', 'PRDINSKEY', PRDINSKEY);
        ItsButton.EventSearch();

        ItsMsg.Alert('작업지시 상세가 삭제되었습니다.');
    });
}
/**********************************************************************************************************************************************************************/