/// <reference path="../../script/reference.js" />
ItsPage.Load = function () {
    ItsPop.LoadFindPopCOM();
    ItsDateRange.SetInitValueFrom('DateRange1', ItsHelper.AddDay(-3, ItsHelper.GetYearMonthDay()));
    ItsDateRange.SetInitValueTo('DateRange1', ItsHelper.AddDay(+3, ItsHelper.GetYearMonthDay()));

    ItsGrid.Create('grid_header', { isSubTotalGrid: true }, [
        column.create('수주상태', 'SALODRSTT', { width: 70, columnType: enumColumnTypes.combo, gpcd: 'SALODRSTT', align: 'center' }),        
        column.create('수주일자', 'ODRDATE', { width: 100, align: 'center' }),
        column.create('거래처코드', 'CUSTCD', { width: 100 }),
        column.create('거래처', 'CUSTNM', { width: 150, backColor: enumColor.greenLight2, align: 'center' }),
        column.create('수주명', 'SALODRNM', { width: 200 }),                
        column.create('담당자', 'EMPCD', { width: 80, columnType: enumColumnTypes.combo, gpcd: 'EMPCD', align: 'center' }),
        column.create('비고', 'REMARK', { width: 150 }),
        column.create('수주번호', 'SALODRKEY', { width: 100, align: 'center' }),
        column.split()
    ]);

    ItsGrid.Create('grid_detail', { isCheckBoxGrid: true, isSubTotalGrid: true, allowSorting: false }, [
        column.create('수주상태', 'SALODRSTT', { width: 70, columnType: enumColumnTypes.combo, gpcd: 'SALODRSTT', align: 'center' }),
        column.create('품목유형', 'ITEMTP', { width: 100, columnType: enumColumnTypes.combo, gpcd: 'ITEMTP', align: 'center' }),        
        column.create('품목코드', 'ITEMCD', { width: 100, columnType: enumColumnTypes.find, gpcd: 'ITEMCD', readOnly: false  }),
        column.create('품명', 'ITEMNM', { width: 250 }),        
        column.create('수주수량', 'ODRQTY', { width: 80, columnType: enumColumnTypes.number, groupType: enumGrouping.sum, readOnly: false }),        
        column.create('단위', 'ITEMUNIT', { width: 80, columnType: enumColumnTypes.combo, gpcd: 'ITEMUNIT', align: 'center', readOnly: false }),
        column.create('납기일자', 'EXPDATE', { width: 120, columnType: enumColumnTypes.date, align: 'center', readOnly: false }),
        column.create('출고예정일', 'OUTDATE', { width: 120, columnType: enumColumnTypes.date, align: 'center', readOnly: false, hidden: true }),     
        
        column.create('비고', 'REMARK', { width: 150, readOnly: false }),
        column.create('SALODRDKEY', 'SALODRDKEY', { width: 80, hidden: true }),

        column.split()
    ]);

    ItsGrid.Create('grid_SALODRD_FILES', { isCheckBoxGrid: true, isSubTotalGrid: false, allowSorting: false }, [
        column.create("파일키", "FILEKEY", { width: 100 }),
        column.create("파일명", "FILENAME", { width: 170 }),        
        column.create('파일보기', 'OPEN_FILE', { width: 80, columnType: enumColumnTypes.button, iconCls: 'fa-search' }),
        column.create('파일다운로드', 'DOWN_FILE', { width: 80, columnType: enumColumnTypes.button, iconCls: 'fa-download' }),
        column.create('파일삭제', 'DELETE_FILE', { width: 80, columnType: enumColumnTypes.button, iconCls: 'fa-trash' }),

        column.split()
    ]);

    ItsGrid.Create('grid_BOM_ROUT', { isCheckBoxGrid: false, isSubTotalGrid: false, allowSorting: false, allowMerging: 'Cells' }, [                
        column.create('제품코드', 'ITEMCD_PRODUCT', { width: 150, align: 'center', allowMerging: true, hidden: true }),
        column.create('품목코드', 'ITEMCD_SUB', { width: 150, align: 'center'}),
        column.create('필요개수', 'CUSAGE', { width: 80, columnType: enumColumnTypes.number }),        
        column.create('가공', 'CUT', { width: 100, align: 'center' }),
        column.create('절곡/압입', 'BENDING_PEMPRESS', { width: 200, align: 'center' }),
        column.create('용접', 'WELDING', { width: 100, align: 'center' }),
        column.create('외주', 'OUTSORCING', { width: 200, align: 'center' }),
        column.create('조립', 'ASY', { width: 100, align: 'center', allowMerging: true  }),
        column.create('품목 삭제', 'DEL_SALODRD_BOM', { width: 100, columnType: enumColumnTypes.button, iconCls: 'fa-trash' }),

        column.split()
    ]);

    ItsGrid.Get('grid_BOM_ROUT').autoRowHeights = true; // 행높이 자동조정


    // 수주품목 BOM,라우팅 그리드 - 공정 컬럼 하이퍼링크 처리
    ItsGrid.Get('grid_BOM_ROUT').formatItem.addHandler(function (s, e) {
        if ((s.columns[e.col].binding == 'CUT' || s.columns[e.col].binding == 'BENDING_PEMPRESS' || s.columns[e.col].binding == 'WELDING' || s.columns[e.col].binding == 'OUTSORCING' || s.columns[e.col].binding == 'ASY')
            && e.panel != s.columnHeaders   // 컬럼헤더 제외
            && e.panel != s.columnFooters) {    // 총계 제외
            var html = e.cell.innerHTML;
            e.cell.innerHTML = '<a href="#" onclick="ItsGrid.Event(\'grid_BOM_ROUT\').onDoubleClick(' + e.row + ',\'' + s.columns[e.col].binding + '\')" >' + html + '</a>';
        }

    })

    ItsGrid.Create('grid_ADD_SUBITEM', { isCheckBoxGrid: false, isSubTotalGrid: false, allowSorting: false }, [
        column.create('공정코드', 'PRCCD', { width: 100, hidden: true }),
        column.create('공정', 'PRCNM', { width: 100, align: 'center' }),
        column.create('필요 자재, 부자재', 'MTRLIST', { width: 400, align: 'center' }),
        column.create('공정 삭제', 'DEL_SALODRD_ROUT', { width: 100, columnType: enumColumnTypes.button, iconCls: 'fa-trash'  }),
        column.create('비고', 'REMARK', { width: 200, align: 'center', readOnly: false }),

        column.split()
    ]);

    // 반제품 BOM, 라우팅 그리드 - 필요 자재, 부자재 컬럼 하이퍼링크 처리
    ItsGrid.Get('grid_ADD_SUBITEM').formatItem.addHandler(function (s, e) {
        if (s.columns[e.col].binding == 'MTRLIST'
            && e.panel != s.columnHeaders   // 컬럼헤더 제외
            && e.panel != s.columnFooters) {    // 총계 제외
            var html = e.cell.innerHTML;
            e.cell.innerHTML = '<a href="#" style="color:#337ab7;" onclick="ItsGrid.Event(\'grid_ADD_SUBITEM\').onDoubleClick(' + e.row + ',\'' + s.columns[e.col].binding + '\')" >' + html + '</a>';
        }

    })

    ItsGrid.Create('grid_ADD_MTRITEM', { isCheckBoxGrid: false, isSubTotalGrid: false, allowSorting: false }, [
        column.create('품목유형', 'ITEMTP', { width: 100, columnType: enumColumnTypes.combo, gpcd: 'ITEMTP', align: 'center' }),
        column.create('품목코드', 'ITEMCD', { width: 100}),
        column.create('품명', 'ITEMNM', { width: 250 }),
        column.create('수요수량', 'CUSAGE', { width: 80, columnType: enumColumnTypes.number }),
        column.create('단위', 'ITEMUNIT', { width: 80, columnType: enumColumnTypes.combo, gpcd: 'ITEMUNIT', align: 'center'}),
        column.create('자재 삭제', 'DEL_MTRITEM', { width: 100, columnType: enumColumnTypes.button, iconCls: 'fa-trash' }),

        column.split()
    ]);

    ItsGrid.Create('grid_ADD_MTRITEM_ASY', { isCheckBoxGrid: false, isSubTotalGrid: false, allowSorting: false }, [
        column.create('품목유형', 'ITEMTP', { width: 100, columnType: enumColumnTypes.combo, gpcd: 'ITEMTP', align: 'center' }),
        column.create('품목코드', 'ITEMCD', { width: 100 }),
        column.create('품명', 'ITEMNM', { width: 250 }),
        column.create('수요수량', 'CUSAGE', { width: 80, columnType: enumColumnTypes.number }),
        column.create('단위', 'ITEMUNIT', { width: 80, columnType: enumColumnTypes.combo, gpcd: 'ITEMUNIT', align: 'center' }),
        column.create('자재 삭제', 'DEL_MTRITEM', { width: 100, columnType: enumColumnTypes.button, iconCls: 'fa-trash' }),

        column.split()
    ]);

    ItsGrid.Create('grid_REOCRD_SUBITEM', { isCheckBoxGrid: false, isSubTotalGrid: false, allowSorting: false, allowMerging: 'Cells' }, [
        column.create('SALODRDKEY', 'SALODRDKEY', { width: 80, hidden: true }),
        column.create('제품코드', 'ITEMCD_PRODUCT', { width: 150, align: 'center', allowMerging: true }),
        column.create('부품도코드', 'ITEMCD_SUB', { width: 150, align: 'center' }),
        column.create('필요개수', 'CUSAGE', { width: 80, columnType: enumColumnTypes.number }),
        column.create('가공', 'CUT', { width: 100, align: 'center' }),
        column.create('절곡/압입', 'BENDING_PEMPRESS', { width: 200, align: 'center' }),
        column.create('용접', 'WELDING', { width: 100, align: 'center' }),
        column.create('외주', 'OUTSORCING', { width: 200, align: 'center' }),
        column.create('조립', 'ASY', { width: 100, align: 'center', allowMerging: true }),
        column.create('부품도 추가', 'ADD_RECORD_SUBTITEMM', { width: 100, columnType: enumColumnTypes.button, iconCls: 'fa-plus' }),

        column.split()
    ]);

    ItsGrid.Get('grid_REOCRD_SUBITEM').autoRowHeights = true; // 행높이 자동조정
};
/**********************************************************************************************************************************************************************/
var insertState = false;
/**********************************************************************************************************************************************************************/
ItsButton.EventSearch = function () {
    var cnt = search();
    ItsMsg.Toast(ItsMsg.CommonMsg.SearchComplete(cnt));
};

var search = function () {
    setInsertMode(false);

    ItsPage.InitData('div1');
    ItsGrid.Clear('grid_detail');
    ItsGrid.Clear('grid_BOM_ROUT');
    ItsGrid.Clear('grid_SALODRD_FILES');
    ItsFileManager.Clear('fm');

    var maria = new ItsMaria('SAL3002_R01', 'LIST_SALODR');

    maria.AddPanel('sdiv1');

    maria.CallProc();

    if (maria.isError) {
        maria.ShowErrMsg();
        return;
    }

    ItsGrid.SetStore('grid_header', maria.store);
    ItsGrid.Get('grid_header').autoSizeColumns();

    return maria.store.data.length;
}
/**********************************************************************************************************************************************************************/
// 수주헤더 선택시 수주상세 조회
ItsGrid.Event('grid_header').onSelect = function (rowIndex) {
    setInsertMode(false);

    ItsPage.SetStore('div1', ItsGrid.GetRowData('grid_header', rowIndex));

    ItsGrid.Clear('grid_detail');
    ItsGrid.Clear('grid_BOM_ROUT');
    ItsGrid.Clear('grid_SALODRD_FILES');

    var maria = new ItsMaria('SAL3002_R01', 'LIST_SALODRD');

    maria.AddParam('SALODRKEY', ItsGrid.GetValue('grid_header', rowIndex, 'SALODRKEY'));

    maria.CallProc();

    if (maria.isError) {
        maria.ShowErrMsg();
        return;
    }

    ItsGrid.SetStore('grid_detail', maria.store);    
    ItsGrid.Get('grid_detail').autoSizeColumns();
};

// 수주품목 선택시 BOM, 라우팅 조회
ItsGrid.Event('grid_detail').onSelect = function (rowIndex) {
    if (!insertState) {
        var maria = new ItsMaria('SAL3002_R01', 'LIST_SALODRD_BOM_ROUT');
                
        maria.AddParam('SALODRDKEY', ItsGrid.GetValue('grid_detail', rowIndex, 'SALODRDKEY'));

        maria.CallProc();

        if (maria.isError) {
            maria.ShowErrMsg();
            return;
        }

        ItsGrid.SetStore('grid_BOM_ROUT', maria.store);            

        LIST_SALODRD_FILES();
    }
    else {
        ItsGrid.Clear('grid_BOM_ROUT');
        ItsGrid.Clear('grid_SALODRD_FILES');
    }
};

ItsGrid.Event('grid_BOM_ROUT').onDoubleClick = function (rowindex, field) {
    if (field == 'CUT' || field == 'BENDING_PEMPRESS' || field == 'WELDING' || field == 'OUTSORCING') {
        // 공정 클릭시
        var ITEMCD_PRODUCT = ItsGrid.GetValue('grid_BOM_ROUT', rowindex, 'ITEMCD_PRODUCT');
        var ITEMCD_SUB = ItsGrid.GetValue('grid_BOM_ROUT', rowindex, 'ITEMCD_SUB');
        
        LIST_SALODRD_ROUT(ITEMCD_SUB);  // 라우팅조회

        if (ITEMCD_PRODUCT == ITEMCD_SUB) {
            ItsNum.Hide('num_CUSAGE');
            ItsButton.Hide('btn_UPDATE_CUSAGE');
        }
        else {
            ItsNum.Show('num_CUSAGE');
            ItsButton.Show('btn_UPDATE_CUSAGE');
        }

        MAKE_PRCLIST();

        ItsPop.Open('POP_ADD_SUBITEM');
    }
    else if (field == 'ASY') {
        // 조립공정 클릭시
        var ASY_OX = ItsGrid.GetValue('grid_BOM_ROUT', rowindex, 'ASY');

        if (ASY_OX == 'X') {
            ItsMsg.Alert('[조립공정 추가] 버튼을 누른 후 진행하세요.');
            return;
        }


        var SALITEM = ItsGrid.GetValue('grid_detail', ItsGrid.GetCurrentIndex('grid_detail'), 'ITEMCD');
        var PRCCD = 'ASY';
        var PRCNM = '조립';

        ItsText.SetValue('txt_SALITEM', SALITEM);
        ItsText.SetValue('txt_PRCNM_ASY', PRCNM);

        LIST_SALODRD_BOM_ASY(SALITEM, PRCCD);

        ItsPop.Open('POP_ADD_MTRITEM_ASY');
    }
};


// 조립공정 추가버튼
ItsButton.Event('btn_ADD_ASY').onClick = function () {
    if (!insertState) {
        var SALODRDKEY = ItsGrid.GetValue('grid_detail', ItsGrid.GetCurrentIndex('grid_detail'), 'SALODRDKEY');        

        if (ItsGrid.Length('grid_detail') == 0) {
            ItsMsg.Alert('수주품목 선택하세요.');
            return;
        }

        if (SALODRDKEY == undefined || SALODRDKEY == '') {
            ItsMsg.Alert('수주품목을 입력 후 저장하세요.');
            return;
        }

        if (ItsGrid.Length('grid_BOM_ROUT') > 0) {
            ItsMsg.Confirm("조립공정을 추가하시겠습니까?", function () {
                var maria = new ItsMaria('SAL3002_R01', 'ADD_ASY');

                var SALODRDKEY = ItsGrid.GetValue('grid_detail', ItsGrid.GetCurrentIndex('grid_detail'), 'SALODRDKEY');
                var ITEMCD = ItsGrid.GetValue('grid_detail', ItsGrid.GetCurrentIndex('grid_detail'), 'ITEMCD');

                maria.AddParam('SALODRDKEY', SALODRDKEY);
                maria.AddParam('ITEMCD', ITEMCD);

                maria.CallProc();

                if (maria.isError) {
                    maria.ShowErrMsg();
                    return;
                }

                ItsGrid.Event('grid_detail').onSelect(ItsGrid.GetCurrentIndex('grid_detail'));
            });
        }
        else {
            ItsMsg.Alert('부품도를 추가하세요.');
        }
    }
    else {
        ItsMsg.Alert('신규수주를 생성하는 중에는 사용할 수 없습니다.\n수주 조회 후 사용하세요.');
    }
};

// 조립공정 삭제버튼
ItsButton.Event('btn_DEL_ASY').onClick = function () {
    if (!insertState) {
        var SALODRDKEY = ItsGrid.GetValue('grid_detail', ItsGrid.GetCurrentIndex('grid_detail'), 'SALODRDKEY');

        if (ItsGrid.Length('grid_detail') == 0) {
            ItsMsg.Alert('수주품목 선택하세요.');
            return;
        }

        if (SALODRDKEY == undefined || SALODRDKEY == '') {
            ItsMsg.Alert('수주품목을 입력 후 저장하세요.');
            return;
        }

        if (ItsGrid.Length('grid_BOM_ROUT') > 0) {
            ItsMsg.Confirm("조립공정을 삭제하시겠습니까?", function () {
                var maria = new ItsMaria('SAL3002_R01', 'DEL_ASY');

                var SALODRDKEY = ItsGrid.GetValue('grid_detail', ItsGrid.GetCurrentIndex('grid_detail'), 'SALODRDKEY');
                var ITEMCD = ItsGrid.GetValue('grid_detail', ItsGrid.GetCurrentIndex('grid_detail'), 'ITEMCD');

                maria.AddParam('SALODRDKEY', SALODRDKEY);
                maria.AddParam('ITEMCD', ITEMCD);

                maria.CallProc();

                if (maria.isError) {
                    maria.ShowErrMsg();
                    return;
                }

                ItsGrid.Event('grid_detail').onSelect(ItsGrid.GetCurrentIndex('grid_detail'));
            });
        }
        else {
            ItsMsg.Alert('부품도를 추가하세요.');
        }
    }
    else {
        ItsMsg.Alert('신규수주를 생성하는 중에는 사용할 수 없습니다.\n수주 조회 후 사용하세요.');
    }
};

ItsGrid.Event('grid_SALODRD_FILES').onButtonClick = function (rowindex, field) {
    if (field == 'OPEN_FILE') {
        var url = ItsGrid.GetValue('grid_SALODRD_FILES', rowindex, 'FILEURL');

        if (url != "" && url != undefined) {
            window.open(url);
        }
    }
    else if (field == 'DOWN_FILE') {
        var url = ItsGrid.GetValue('grid_SALODRD_FILES', rowindex, 'FILEURL');
        var FILENAME = ItsGrid.GetValue('grid_SALODRD_FILES', rowindex, 'FILENAME');

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
    else if (field == 'DELETE_FILE') {
        ItsMsg.Confirm("선택항목을 삭제하시겠습니까?",
            function () {
                var maria = new ItsMaria('SAL3002_R01', 'DELETE_SALODRD_FILES');

                var SALODRDKEY = ItsGrid.GetValue('grid_detail', ItsGrid.GetCurrentIndex('grid_detail'), 'SALODRDKEY');
                var FILEKEY = ItsGrid.GetValue('grid_SALODRD_FILES', rowindex, 'FILEKEY')

                maria.AddParam('SALODRDKEY', SALODRDKEY);
                maria.AddParam('FILEKEY', FILEKEY);

                maria.CallProc();

                if (maria.isError) {
                    maria.ShowErrMsg();
                    return;
                }

                ItsFileManager.SetFileKey('fm', FILEKEY);
                ItsFileManager.Delete('fm', FILEKEY);

                LIST_SALODRD_FILES();
            }
        );
    }
};

/**********************************************************************************************************************************************************************/
// 파일업로드
ItsFileManager.Event('fm').onUpload = function (id, fileKey) {
    if (ItsGrid.Length('grid_detail') <= 0) {
        ItsMsg.Alert('수주품목을 등록하세요.');
        return;
    }

    var SALODRDKEY = ItsGrid.GetValue('grid_detail', ItsGrid.GetCurrentIndex('grid_detail'), 'SALODRDKEY');

    if (SALODRDKEY == undefined || SALODRDKEY == '') {
        ItsMsg.Alert('수주품목을 등록하세요.');
        return;
    }

    var maria = new ItsMaria('SAL3002_R01', 'SAVE_SALODRD_FILES');

    maria.AddParam('SALODRDKEY', SALODRDKEY);
    maria.AddParam('FILEKEY', fileKey);

    maria.CallProc();

    if (maria.isError) {
        maria.ShowErrMsg();
        return;
    }

    ItsFileManager.Clear('fm');
    LIST_SALODRD_FILES();
};

// 수주품목 파일조회
function LIST_SALODRD_FILES() {
    var maria = new ItsMaria('SAL3002_R01', 'LIST_SALODRD_FILES');

    var SALODRDKEY = ItsGrid.GetValue('grid_detail', ItsGrid.GetCurrentIndex('grid_detail'), 'SALODRDKEY');

    maria.AddParam('SALODRDKEY', SALODRDKEY);
    
    maria.CallProc();

    if (maria.isError) {
        maria.ShowErrMsg();
        return;
    }

    ItsGrid.SetStore('grid_SALODRD_FILES', maria.store);
}

/**********************************************************************************************************************************************************************/
ItsGrid.Event('grid_BOM_ROUT').onButtonClick = function (rowindex, field) {
    if (field == 'DEL_SALODRD_BOM') {
        // 제품BOM에서 반제품 삭제
        ItsMsg.Confirm("삭제하시겠습니까?", function () {
            var maria = new ItsMaria('SAL3002_R01', 'DEL_SALODRD_BOM');

            var SALODRDKEY = ItsGrid.GetValue('grid_detail', ItsGrid.GetCurrentIndex('grid_detail'), 'SALODRDKEY');
            var SUBITEM = ItsGrid.GetValue('grid_BOM_ROUT', rowindex, 'ITEMCD_SUB');

            maria.AddParam('SALODRDKEY', SALODRDKEY);
            maria.AddParam('SUBITEM', SUBITEM);

            maria.CallProc();

            if (maria.isError) {
                maria.ShowErrMsg();
                return;
            }

            ItsGrid.Event('grid_detail').onSelect(ItsGrid.GetCurrentIndex('grid_detail'));
        });
    }
}

ItsGrid.Event('grid_ADD_SUBITEM').onButtonClick = function (rowindex, field) {
    if (field == 'DEL_SALODRD_ROUT') {
        // 반제품의 라우팅에서 공정삭제
        ItsMsg.Confirm("삭제하시겠습니까?", function () {
            var maria = new ItsMaria('SAL3002_R01', 'DEL_SALODRD_ROUT');

            var SALODRDKEY = ItsGrid.GetValue('grid_detail', ItsGrid.GetCurrentIndex('grid_detail'), 'SALODRDKEY');
            var SUBITEM = ItsText.GetValue('txt_ITEMCD_SUB');
            var PRCCD = ItsGrid.GetValue('grid_ADD_SUBITEM', rowindex, 'PRCCD');

            maria.AddParam('SALODRDKEY', SALODRDKEY);
            maria.AddParam('SUBITEM', SUBITEM);
            maria.AddParam('PRCCD', PRCCD);

            maria.CallProc();

            if (maria.isError) {
                maria.ShowErrMsg();
                return;
            }

            LIST_SALODRD_ROUT(SUBITEM); // 반제품의 라우팅조회
        });
    }
}

// 자재, 부자재 추가팝업 오픈
ItsGrid.Event('grid_ADD_SUBITEM').onDoubleClick = function (rowindex, field) {
    if (field == 'MTRLIST') {
        // 필요자재, 부자재 클릭시
        var ITEMCD_SUB = ItsText.GetValue('txt_ITEMCD_SUB');
        var PRCCD = ItsGrid.GetValue('grid_ADD_SUBITEM', rowindex, 'PRCCD');
        var PRCNM = ItsGrid.GetValue('grid_ADD_SUBITEM', rowindex, 'PRCNM');

        ItsText.SetValue('txt_ITEMCD_SUB_2', ITEMCD_SUB);
        ItsText.SetValue('txt_PRCNM', PRCNM);

        LIST_SALODRD_BOM(ITEMCD_SUB, PRCCD);

        ItsPop.Open('POP_ADD_MTRITEM');
    }
};

ItsGrid.Event('grid_ADD_MTRITEM').onButtonClick = function (rowindex, field) {
    if (field == 'DEL_MTRITEM') {
        // 반제품의 BOM에서 자제삭제
        ItsMsg.Confirm("삭제하시겠습니까?", function () {
            var maria = new ItsMaria('SAL3002_R01', 'DEL_MTRITEM');

            var SALODRDKEY = ItsGrid.GetValue('grid_detail', ItsGrid.GetCurrentIndex('grid_detail'), 'SALODRDKEY');
            var SUBITEM = ItsText.GetValue('txt_ITEMCD_SUB_2');
            var PRCCD = ItsGrid.GetValue('grid_ADD_SUBITEM', ItsGrid.GetCurrentIndex('grid_ADD_SUBITEM'), 'PRCCD');
            var MTRITEM = ItsGrid.GetValue('grid_ADD_MTRITEM', rowindex, 'ITEMCD');

            maria.AddParam('SALODRDKEY', SALODRDKEY);
            maria.AddParam('SUBITEM', SUBITEM);
            maria.AddParam('PRCCD', PRCCD);
            maria.AddParam('MTRITEM', MTRITEM);

            maria.CallProc();

            if (maria.isError) {
                maria.ShowErrMsg();
                return;
            }

            LIST_SALODRD_BOM(SUBITEM, PRCCD);
        });
    }
}

ItsGrid.Event('grid_ADD_MTRITEM_ASY').onButtonClick = function (rowindex, field) {
    if (field == 'DEL_MTRITEM') {
        // 조립공정 BOM에서 자제삭제
        ItsMsg.Confirm("삭제하시겠습니까?", function () {
            var maria = new ItsMaria('SAL3002_R01', 'DEL_MTRITEM');

            var SALODRDKEY = ItsGrid.GetValue('grid_detail', ItsGrid.GetCurrentIndex('grid_detail'), 'SALODRDKEY');
            var SALITEM = ItsText.GetValue('txt_SALITEM');
            var PRCCD = 'ASY'
            var MTRITEM = ItsGrid.GetValue('grid_ADD_MTRITEM_ASY', rowindex, 'ITEMCD');

            maria.AddParam('SALODRDKEY', SALODRDKEY);
            maria.AddParam('SUBITEM', SALITEM);
            maria.AddParam('PRCCD', PRCCD);
            maria.AddParam('MTRITEM', MTRITEM);

            maria.CallProc();

            if (maria.isError) {
                maria.ShowErrMsg();
                return;
            }

            LIST_SALODRD_BOM_ASY(SALITEM, PRCCD);
        });
    }
}

ItsGrid.Event('grid_REOCRD_SUBITEM').onButtonClick = function (rowindex, field) {
    if (field == 'ADD_RECORD_SUBTITEMM') {
        // 최근반제품이력 선택
        var maria = new ItsMaria('SAL3002_R01', 'ADD_RECORD_SUBTITEMM');

        var SALODRDKEY = ItsGrid.GetValue('grid_detail', ItsGrid.GetCurrentIndex('grid_detail'), 'SALODRDKEY');
        var SALODRDKEY_LAST = ItsGrid.GetValue('grid_REOCRD_SUBITEM', rowindex, 'SALODRDKEY');
        var SUBITEM = ItsGrid.GetValue('grid_REOCRD_SUBITEM', rowindex, 'ITEMCD_SUB');

        maria.AddParam('SALODRDKEY', SALODRDKEY);
        maria.AddParam('SALODRDKEY_LAST', SALODRDKEY_LAST);
        maria.AddParam('SUBITEM', SUBITEM);

        maria.CallProc();

        if (maria.isError) {
            maria.ShowErrMsg();
            return;
        }

        ItsPop.Close('POP_RECORD_SUBITEM');

        // 추가된 반제품이력으로 팝업창에 출력
        LIST_SALODRD_ROUT(SUBITEM);  
    }
}
/**********************************************************************************************************************************************************************/
// 추가모드 설정
setInsertMode = function (isinsert) {
    if (isinsert) {
        insertState = true;
        
        ItsPage.InitData('div1');
        ItsGrid.Clear('grid_detail');
        ItsGrid.Clear('grid_BOM_ROUT');
        ItsGrid.Clear('grid_SALODRD_FILES');
        ItsPage.SetBackColor('div1', enumColor.addPanel);
        ItsFind.Enable('find_CUSTCD');
        ItsDate.Enable('date_ODRDATE');
    }
    else {
        insertState = false;
        ItsPage.SetBackColor('div1', enumColor.transparent);
        ItsFind.Disable('find_CUSTCD');
        ItsDate.Disable('date_ODRDATE');
    }
}

/**********************************************************************************************************************************************************************/
// 추가버튼 클릭
ItsButton.EventAdd = function () {
    setInsertMode(true);

    var $store = new Store();

    for (var i = 0; i < 5; i++) {
        $store.data.push({ isRowCheck: false});
    }

    ItsGrid.SetStore('grid_detail', $store);
    ItsFind.SetValue('find_EMPCD', ItsPage.EMPCD);
}
/**********************************************************************************************************************************************************************/
ItsGrid.Event('grid_detail').onDoubleClick = function (rowIndex, field) {
    ItsGrid.Event('grid_detail').onKeydownEnter(rowIndex, field);
}

ItsGrid.Event('grid_detail').onKeydownEnter = function (rowIndex, field) {

    if (!ItsFind.IsFindName('find_CUSTCD')) {
        ItsMsg.Alert('거래처를 선택하세요');
        return;
    }
    if (ItsGrid.GetValue('grid_detail', rowIndex, 'SALODRSTT') != undefined
        && ItsGrid.GetValue('grid_detail', rowIndex, 'SALODRSTT') != '01') {
        ItsMsg.Alert('수주상태가 [ 수주 ]인 경우만 수정이 가능합니다.');
        return;
    }
    if (field == 'ITEMCD') {
        ItsPop.OpenFindCOM({ gpcd: 'ITEMCD', keyword: ItsGrid.GetValue('grid_detail', rowIndex, field), ref01: '40' }, function (res) {
            var maria = new ItsMaria('SAL3002_R01', 'SEARCH_ITEMUNIT');

            maria.AddParam('ITEMCD', res['CODE']);
            
            maria.CallProc();

            if (maria.isError) {
                maria.ShowErrMsg();
                return;
            }

            ItsGrid.SetValue('grid_detail', rowIndex, 'ITEMCD', res['CODE']);
            ItsGrid.SetValue('grid_detail', rowIndex, 'ITEMNM', res['NAME']);
            ItsGrid.SetValue('grid_detail', rowIndex, 'ITEMTP', res['REF01']);
            ItsGrid.SetValue('grid_detail', rowIndex, 'ITEMUNIT', maria.store.GetValue(0, 'ITEMUNIT'));
            ItsGrid.CheckRow('grid_detail', rowIndex);
        })
    }
}

ItsGrid.Event('grid_detail').onChanged = function (rowIndex, field, newValue, oldValue) {
    if (!ItsFind.IsFindName('find_CUSTCD')) {
        ItsMsg.Alert('거래처를 선택하세요');
        return;
    }

    if (field == 'ITEMCD') {
        if (newValue == '' || newValue == null && newValue != undefined) {
            ItsGrid.SetValue('grid_detail', rowIndex, 'ITEMNM', '');
            ItsGrid.SetValue('grid_detail', rowIndex, 'ITEMTP', '');
            ItsGrid.SetValue('grid_detail', rowIndex, 'CARMODEL', '');
            ItsGrid.SetValue('grid_detail', rowIndex, 'ITEMUNIT', '');
            ItsGrid.SetValue('grid_detail', rowIndex, 'ODRQTY', 0);
            ItsGrid.SetValue('grid_detail', rowIndex, 'EXPDATE', '');
            ItsGrid.SetValue('grid_detail', rowIndex, 'OUTDATE', '');
            ItsGrid.SetValue('grid_detail', rowIndex, 'REMARK', '');
        }
    }
}


/**********************************************************************************************************************************************************************/
ItsButton.EventSave = function () {
    var orderseq = 0;

    if (insertState) {
        var maria = new ItsMaria('SAL3002_R01', 'ADD_SALODRD');

        maria.AddPanel('div1');

        for (var i = 0; i < ItsGrid.Length('grid_detail') ; i++) {
            if (ItsGrid.IsChecked('grid_detail', i)) {
                if (ItsGrid.GetValue('grid_detail', i, 'ODRQTY') == undefined || ItsGrid.GetValue('grid_detail', i, 'ODRQTY') == '') {
                    ItsMsg.Alert('수주수량을 입력하세요.');
                    return;
                }

                maria.AddList('ITEMCD_LIST', ItsGrid.GetValue('grid_detail', i, 'ITEMCD'));
                maria.AddList('ODRQTY_LIST', ItsGrid.GetValue('grid_detail', i, 'ODRQTY'));
                maria.AddList('ITEMUNIT_LIST', ItsGrid.GetValue('grid_detail', i, 'ITEMUNIT'));
                maria.AddList('EXPDATE_LIST', ItsGrid.GetValue('grid_detail', i, 'EXPDATE'));
                maria.AddList('OUTDATE_LIST', ItsGrid.GetValue('grid_detail', i, 'OUTDATE'));
                maria.AddList('REMARK_LIST', ItsGrid.GetValue('grid_detail', i, 'REMARK'));
            }
        }

        maria.CallProc();

        if (maria.isError) {
            maria.ShowErrMsg();
            return;
        }

        ItsMsg.Toast(ItsMsg.CommonMsg.AddComplete);

        ItsGrid.Setkey('grid_header', 'SALODRKEY', maria.store.GetValue(0, 'SALODRKEY'));

        search();
    }
    else {
        var maria = new ItsMaria('SAL3002_R01', 'UPDATE_SALODRD');

        maria.AddParam('SALODRKEY', ItsGrid.GetValue('grid_header', ItsGrid.GetCurrentIndex('grid_header'), 'SALODRKEY'));        
        maria.AddPanel('div1');
        
        for (var i = 0; i < ItsGrid.Length('grid_detail') ; i++) {
            if (ItsGrid.IsChecked('grid_detail', i)) {
                maria.AddList('SALODRDKEY_LIST', ItsGrid.GetValue('grid_detail', i, 'SALODRDKEY'));
                maria.AddList('ITEMCD_LIST', ItsGrid.GetValue('grid_detail', i, 'ITEMCD'));
                maria.AddList('ODRQTY_LIST', ItsGrid.GetValue('grid_detail', i, 'ODRQTY'));
                maria.AddList('ITEMUNIT_LIST', ItsGrid.GetValue('grid_detail', i, 'ITEMUNIT'));
                maria.AddList('EXPDATE_LIST', ItsGrid.GetValue('grid_detail', i, 'EXPDATE'));
                maria.AddList('OUTDATE_LIST', ItsGrid.GetValue('grid_detail', i, 'OUTDATE'));
                maria.AddList('REMARK_LIST', ItsGrid.GetValue('grid_detail', i, 'REMARK'));
            }
        }
        
        maria.CallProc();

        if (maria.isError) {
            maria.ShowErrMsg();
            return;
        }

        ItsMsg.Toast(ItsMsg.CommonMsg.SaveComplete());

        ItsGrid.Setkey('grid_header', 'SALODRKEY', maria.store.GetValue(0, 'SALODRKEY'));

        search();
    }
}
 /**********************************************************************************************************************************************************************/
/* 행 추가 */
ItsButton.Event('ADD_ROW').onClick = function () {
    var cnt = ItsGrid.Length('grid_detail');
    ItsGrid.AddRow('grid_detail', cnt);
};

// 행삭제 : 수주품목
ItsButton.Event('DEL_ORDERD').onClick = function () {
    if (insertState) {
        ItsGrid.RemoveRow('grid_detail', ItsGrid.GetCurrentIndex('grid_detail'));
        return;
    } else {
        ItsMsg.Confirm('선택한 수주품목을 삭제하시겠습니까?',
            function () {
                var maria = new ItsMaria('SAL3002_R01', 'DEL_ORDERD');

                maria.AddParam('SALODRKEY', ItsGrid.GetValue('grid_header', ItsGrid.GetCurrentIndex('grid_header'), 'SALODRKEY'));

                for (var i = 0; i < ItsGrid.Length('grid_detail') ; i++) {
                    if (ItsGrid.IsChecked('grid_detail', i)) {
                        maria.AddList('SALODRDKEY_LIST', ItsGrid.GetValue('grid_detail', i, 'SALODRDKEY'));
                    }
                }

                maria.CallProc();

                if (maria.isError) {
                    maria.ShowErrMsg();
                    return;
                }

                ItsMsg.Toast(ItsMsg.CommonMsg.DeleteComplete());

                ItsGrid.Event('grid_header').onSelect(ItsGrid.GetCurrentIndex('grid_header'));
            }
        );
    }
}

// 신규제품 생성 팝업오픈
ItsButton.Event('btn_POP_NEWITEM').onClick = function () {
    if (!ItsFind.IsFindName('find_CUSTCD')) {
        ItsMsg.Alert('거래처를 선택하세요');
        return;
    }

    ItsCombo.SetValue('cmb_ITEMTP_NEW', '40');
    ItsCombo.SetValue('cmb_ITEMUNIT_NEW', '01');
    ItsFind.SetValue('find_CUSTCD_NEW', ItsFind.GetValue('find_CUSTCD'));

    ItsPop.Open('POP_NEWITEM');
};

// 신규제품 생성
ItsButton.Event('btn_INSERT_NEWITEM').onClick = function () {
    var maria = new ItsMaria('SAL3002_R01', 'INSERT_NEWITEM');

    maria.AddPanel('pdiv_NEWITEM');
    
    maria.CallProc();

    if (maria.isError) {
        maria.ShowErrMsg();
        return;
    }

    var index_emptyRow = -1;

    for (var i = 0; i < ItsGrid.Length('grid_detail'); i++) {
        if (ItsGrid.GetValue('grid_detail', i, 'ITEMCD') == '' || ItsGrid.GetValue('grid_detail', i, 'ITEMCD') == undefined) {
            index_emptyRow = i;
            break;
        }
    }

    if (index_emptyRow == -1) {
        ItsButton.Event('ADD_ROW').onClick();
        index_emptyRow = ItsGrid.Length('grid_detail') - 1;
    }

    ItsGrid.SetValue('grid_detail', index_emptyRow, 'ITEMCD', ItsText.GetValue('txt_ITEMCD_NEW'));
    ItsGrid.SetValue('grid_detail', index_emptyRow, 'ITEMNM', ItsText.GetValue('txt_ITEMNM_NEW'));
    ItsGrid.SetValue('grid_detail', index_emptyRow, 'ITEMTP', ItsCombo.GetValue('cmb_ITEMTP_NEW'));
    ItsGrid.SetValue('grid_detail', index_emptyRow, 'ITEMUNIT', ItsCombo.GetValue('cmb_ITEMUNIT_NEW'));

    ItsPop.Close('POP_NEWITEM');
};

// 공정버튼 리스트 생성
MAKE_PRCLIST = function () {
    var maria = new ItsMaria('SAL3002_R01', 'LIST_PRCCD');
    
    maria.CallProc();

    if (maria.isError) {
        maria.ShowErrMsg();
        return;
    }

    var data = maria.store.data || [];
    var config = [];

    for (var i = 0; i < data.length; i++) {
        var row = data[i];
        var value1 = (row.PRCCD != null && row.PRCCD !== '') ? String(row.PRCCD) : ('Div5_' + (i + 1));
        var value2 = (row.PRCNM != null) ? String(row.PRCNM) : '';
        config.push({
            id: 'btn_' + value1,
            label: value2,
            width: 100,
            PRCTP: row.PRCTP
        });
    }
    createDiv5Buttons(config, { buttonsPerRow: 5 });
}

/**
 * Div5 영역에 버튼 리스트를 가변 생성
 * @param {Array} config - 버튼 설정 배열. 각 항목: { id, label, width, onClick(선택) }
 * @param {Object} options - { buttonsPerRow: 한 줄에 표시할 버튼 수 (기본 5) }
 */
function createDiv5Buttons(config, options) {
    var opts = options || {};
    var buttonsPerRow = opts.buttonsPerRow != null ? opts.buttonsPerRow : 5;
    var $container = $('#Div5_ButtonList');
    if (!$container.length) return;
    $container.empty();

    var $lastSelectedDiv5Btn = null;

    for (var i = 0; i < config.length; i++) {
        var item = config[i];
        var id = item.id || ('btn_Div5_' + (i + 1));
        var label = item.label != null ? item.label : '';
        var width = item.width != null ? item.width : 100;
        var background_color = item.PRCTP == 'IN' ? '#74D178' : 'gold';
        var wStyle = width ? 'width:' + width + 'px; height: 30px; border-color: transparent; background-color:' + background_color + ';' : '';
        
        var color = item.PRCTP == 'IN' ? '#FFFFFF' : '#727171';        

        var $wrap = $('<div class="ItsButton" id="' + id + '" data-disabled="false" data-loading="false" style="float:left; margin-left:10px; margin-top:10px;">')
            .append(
                $('<div class="ItsButton_table" tabindex="0" style="' + wStyle + 'text-align:center;">')
                .append($('<span class="ItsButton_span" style="font-weight:bold;' + 'color:' + color + ';' + '">').text(label))
            );
        $container.append($wrap);

        (function (btnId, btnLabel, customOnClick) {
            var valueAfterBtn = (btnId.indexOf('btn_') === 0) ? btnId.substring(4) : btnId;
            ItsButton.Event(btnId).onClick = function () {
                ADD_SUBITEM_ROUT(btnId.replace('btn_', ''));
            };
        })(id, label, item.onClick);

        ItsButton._Reset($wrap.find('.ItsButton_table'));

        if ((i + 1) % buttonsPerRow === 0) {
            $container.append($('<div style="clear:both; width:100%; height:0;">'));
        }
    }
    $container.append($('<div style="clear:both;">'));
}
/**********************************************************************************************************************************************************************/
// 삭제 : 수주전체
ItsButton.EventDelete = function () {
    if (insertState) {
        return;
    } else {
        ItsMsg.Confirm('수주 전체를 삭제하시겠습니까? ',
            function () {
                var maria = new ItsMaria('SAL3002_R01', 'DEL_ORDER');

                maria.AddParam('SALODRKEY', ItsGrid.GetValue('grid_header', ItsGrid.GetCurrentIndex('grid_header'), 'SALODRKEY'));

                maria.CallProc();

                if (maria.isError) {
                    maria.ShowErrMsg();
                    return;
                }

                ItsMsg.Toast(ItsMsg.CommonMsg.DeleteComplete());                

                search();
            }
        );
    }   
};
/**********************************************************************************************************************************************************************/
// 제품 추가 팝업오픈
ItsButton.Event('btn_POP_ADD_PRODUCT').onClick = function () {
    if (!insertState) {
        if (ItsGrid.Length('grid_BOM_ROUT') > 0) {
            var SALITEM = ItsGrid.GetValue('grid_detail', ItsGrid.GetCurrentIndex('grid_detail'), 'ITEMCD');
            var SUBITEM = ItsGrid.GetValue('grid_BOM_ROUT', 0, 'ITEMCD_SUB');

            if (SALITEM == SUBITEM) {
                ItsMsg.Alert('하나의 제품만 가능합니다.');
                return;
            }
            else {
                ItsMsg.Alert('부품도를 추가했을 때는 제품 추가가 불가능 합니다.');
                return;
            }
        }

        var SALODRDKEY = ItsGrid.GetValue('grid_detail', ItsGrid.GetCurrentIndex('grid_detail'), 'SALODRDKEY');
        var ITEMCD = ItsGrid.GetValue('grid_detail', ItsGrid.GetCurrentIndex('grid_detail'), 'ITEMCD');

        if (ItsGrid.Length('grid_detail') == 0) {
            ItsMsg.Alert('수주품목 선택하세요.');
            return;
        }

        if (SALODRDKEY == undefined || SALODRDKEY == '') {
            ItsMsg.Alert('수주품목을 입력 후 저장하세요.');
            return;
        }

        LIST_SALODRD_ROUT(ITEMCD);  // 라우팅조회

        ItsNum.SetValue('num_CUSAGE', 1);
        ItsNum.Hide('num_CUSAGE');
        ItsButton.Hide('btn_UPDATE_CUSAGE');

        MAKE_PRCLIST();

        ItsPop.Open('POP_ADD_SUBITEM');
    }
    else {
        ItsMsg.Alert('신규수주를 생성하는 중에는 사용할 수 없습니다.\n수주 조회 후 사용하세요.');
    }
};

// 부품도 추가 팝업오픈
ItsButton.Event('btn_POP_ADD_SUBITEM').onClick = function () {
    if (!insertState) {
        if (ItsGrid.Length('grid_BOM_ROUT') > 0) {
            var SALITEM = ItsGrid.GetValue('grid_detail', ItsGrid.GetCurrentIndex('grid_detail'), 'ITEMCD');
            var SUBITEM = ItsGrid.GetValue('grid_BOM_ROUT', 0, 'ITEMCD_SUB');

            if (SALITEM == SUBITEM) {
                ItsMsg.Alert('제품을 추가했을 때는 부품도 추가가 불가능 합니다.');
                return;
            }
        }

        var SALODRDKEY = ItsGrid.GetValue('grid_detail', ItsGrid.GetCurrentIndex('grid_detail'), 'SALODRDKEY');
        var ITEMCD = ItsGrid.GetValue('grid_detail', ItsGrid.GetCurrentIndex('grid_detail'), 'ITEMCD');

        if (ItsGrid.Length('grid_detail') == 0) {
            ItsMsg.Alert('수주품목 선택하세요.');
            return;
        }

        if (SALODRDKEY == undefined || SALODRDKEY == '') {
            ItsMsg.Alert('수주품목을 입력 후 저장하세요.');
            return;
        }

        var SORTNO = 1;

        // 반제품코드 자동생성
        if (ItsGrid.Length('grid_BOM_ROUT') == 0) {
            ITEMCD_SUB = ITEMCD + '-01';
        }
        else {
            SORTNO = ItsGrid.GetValue('grid_BOM_ROUT', ItsGrid.Length('grid_BOM_ROUT') - 1, 'SORTNO_SUBITEM');
            SORTNO = SORTNO + 1
            ITEMCD_SUB = ITEMCD + '-' + (SORTNO).toString().padStart(2, '0');
        }

        LIST_SALODRD_ROUT(ITEMCD_SUB);  // 반제품의 라우팅조회

        var maria = new ItsMaria('SAL3002_R01', 'SEARCH_ITEMNM');

        maria.AddParam('ITEMCD', ITEMCD_SUB);

        maria.CallProc();

        if (maria.isError) {
            maria.ShowErrMsg();
            return;
        }

        ItsText.SetValue('txt_ITEMNM_SUB', maria.store.GetValue(0, 'ITEMNM'));
        ItsNum.SetValue('num_SORTNO', SORTNO);
        ItsNum.SetValue('num_CUSAGE', 1);
        ItsNum.Show('num_CUSAGE');
        ItsButton.Show('btn_UPDATE_CUSAGE');

        MAKE_PRCLIST();

        ItsPop.Open('POP_ADD_SUBITEM');        
    }
    else {
        ItsMsg.Alert('신규수주를 생성하는 중에는 사용할 수 없습니다.\n수주 조회 후 사용하세요.');
    }
};

// 품목의 라우팅조회
LIST_SALODRD_ROUT = function (SUBITEM) {
    var maria = new ItsMaria('SAL3002_R01', 'LIST_SALODRD_ROUT');

    maria.AddParam('SALODRDKEY', ItsGrid.GetValue('grid_detail', ItsGrid.GetCurrentIndex('grid_detail'), 'SALODRDKEY'));
    maria.AddParam('SUBITEM', SUBITEM);

    maria.CallProc();

    if (maria.isError) {
        maria.ShowErrMsg();
        return;
    }

    ItsGrid.SetStore('grid_ADD_SUBITEM', maria.store);   

    if (maria.storeExtend1.Length() > 0) {
        ItsNum.SetValue('num_CUSAGE', maria.storeExtend1.GetValue(0, 'CUSAGE'));
        ItsNum.SetValue('num_SORTNO', maria.storeExtend1.GetValue(0, 'SORTNO'));
        ItsText.SetValue('txt_ITEMNM_SUB', maria.storeExtend1.GetValue(0, 'ITEMNM') );
    }

    ItsText.SetValue('txt_ITEMCD_SUB', SUBITEM);
}

//// 가공 버튼
//ItsButton.Event('btn_PRC_CUT').onClick = function () {
//    ADD_SUBITEM_ROUT('CUT');
//}

//// 절곡 버튼
//ItsButton.Event('btn_PRC_BENDING').onClick = function () {
//    ADD_SUBITEM_ROUT('BENDING');
//}

//// 압입 버튼
//ItsButton.Event('btn_PRC_PEMPRESS').onClick = function () {
//    ADD_SUBITEM_ROUT('PEMPRESS');
//}

//// 용접 버튼
//ItsButton.Event('btn_PRC_WELDING').onClick = function () {
//    ADD_SUBITEM_ROUT('WELDING');
//}

//// 도장 버튼
//ItsButton.Event('btn_PRC_PAINT').onClick = function () {
//    ADD_SUBITEM_ROUT('PAINT');
//}

//// 아노다이징 버튼
//ItsButton.Event('btn_PRC_ANODIZING').onClick = function () {
//    ADD_SUBITEM_ROUT('ANODIZING');
//}

//// 도금 버튼
//ItsButton.Event('btn_PRC_PLATING').onClick = function () {
//    ADD_SUBITEM_ROUT('PLATING');
//}

// 지난이력 불러오기 버튼
ItsButton.Event('btn_POP_RECORD_SUBITEM').onClick = function () {
    ItsPop.Open('POP_RECORD_SUBITEM');
    LIST_RECORD_SUBITEM();
}

// 최근반제품이력 조회
LIST_RECORD_SUBITEM = function () {
    var maria = new ItsMaria('SAL3002_R01', 'LIST_RECORD_SUBITEM');

    maria.AddParam('SALODRDKEY', ItsGrid.GetValue('grid_detail', ItsGrid.GetCurrentIndex('grid_detail'), 'SALODRDKEY'));

    maria.CallProc();

    if (maria.isError) {
        maria.ShowErrMsg();
        return;
    }

    ItsGrid.SetStore('grid_REOCRD_SUBITEM', maria.store);
}

// 필요개수수정 버튼
ItsButton.Event('btn_UPDATE_CUSAGE').onClick = function () {
    var maria = new ItsMaria('SAL3002_R01', 'UPDATE_CUSAGE');

    var SALODRDKEY = ItsGrid.GetValue('grid_detail', ItsGrid.GetCurrentIndex('grid_detail'), 'SALODRDKEY');
    var SUBITEM = ItsText.GetValue('txt_ITEMCD_SUB');
    var CUSAGE = ItsNum.GetValue('num_CUSAGE');

    maria.AddParam('SALODRDKEY', SALODRDKEY);
    maria.AddParam('SUBITEM', SUBITEM);
    maria.AddParam('CUSAGE', CUSAGE);

    maria.CallProc();

    if (maria.isError) {
        maria.ShowErrMsg();
        return;
    }

    LIST_SALODRD_ROUT(SUBITEM); // 반제품의 라우팅조회

    ItsMsg.Alert('저장되었습니다.');
}

// 비고저장 버튼
ItsButton.Event('btn_UPDATE_REMARK_ROUT').onClick = function () {
    var maria = new ItsMaria('SAL3002_R01', 'UPDATE_REMARK_ROUT');

    var SALODRDKEY = ItsGrid.GetValue('grid_detail', ItsGrid.GetCurrentIndex('grid_detail'), 'SALODRDKEY');
    var SUBITEM = ItsText.GetValue('txt_ITEMCD_SUB');

    maria.AddParam('SALODRDKEY', SALODRDKEY);
    maria.AddParam('SUBITEM', SUBITEM);

    for (var i = 0; i < ItsGrid.Length('grid_ADD_SUBITEM'); i++) {
        maria.AddList('PRCCD_LIST', ItsGrid.GetValue('grid_ADD_SUBITEM', i, 'PRCCD'));
        maria.AddList('REMARK_LIST', ItsGrid.GetValue('grid_ADD_SUBITEM', i, 'REMARK'));
    }

    maria.CallProc();

    if (maria.isError) {
        maria.ShowErrMsg();
        return;
    }

    LIST_SALODRD_ROUT(SUBITEM); // 반제품의 라우팅조회

    ItsMsg.Alert('저장되었습니다.');
}

// 반제품의 라우팅에 공정추가
ADD_SUBITEM_ROUT = function (PRCCD) {
    var maria = new ItsMaria('SAL3002_R01', 'ADD_SUBITEM_ROUT');

    var SALODRDKEY = ItsGrid.GetValue('grid_detail', ItsGrid.GetCurrentIndex('grid_detail'), 'SALODRDKEY');
    var SUBITEM = ItsText.GetValue('txt_ITEMCD_SUB');
    var CUSAGE = ItsNum.GetValue('num_CUSAGE');
    var SORTNO = ItsNum.GetValue('num_SORTNO');

    maria.AddParam('SALODRDKEY', SALODRDKEY);
    maria.AddParam('SUBITEM', SUBITEM);
    maria.AddParam('CUSAGE', CUSAGE);
    maria.AddParam('PRCCD', PRCCD);
    maria.AddParam('SORTNO', SORTNO);

    maria.CallProc();

    if (maria.isError) {
        maria.ShowErrMsg();
        return;
    }

    LIST_SALODRD_ROUT(SUBITEM); // 반제품의 라우팅조회
}


ItsPop.Event('POP_ADD_SUBITEM').onPopClosed = function () {
    ItsGrid.Event('grid_detail').onSelect(ItsGrid.GetCurrentIndex('grid_detail'));
}

/**********************************************************************************************************************************************************************/
// 자재추가
ItsButton.Event('btn_ADD_MTRITEM').onClick = function () {
    var maria = new ItsMaria('SAL3002_R01', 'ADD_MTRITEM');

    var SALODRDKEY = ItsGrid.GetValue('grid_detail', ItsGrid.GetCurrentIndex('grid_detail'), 'SALODRDKEY');
    var SUBITEM = ItsText.GetValue('txt_ITEMCD_SUB_2');
    var PRCCD = ItsGrid.GetValue('grid_ADD_SUBITEM', ItsGrid.GetCurrentIndex('grid_ADD_SUBITEM'), 'PRCCD');
    var MTRITEM = ItsFind.GetValue('find_MTRITEM');
    var CUSAGE = ItsNum.GetValue('num_MTR_CUSAGE');

    maria.AddParam('SALODRDKEY', SALODRDKEY);
    maria.AddParam('SUBITEM', SUBITEM);
    maria.AddParam('PRCCD', PRCCD);
    maria.AddParam('MTRITEM', MTRITEM);
    maria.AddParam('CUSAGE', CUSAGE);    

    maria.CallProc();

    if (maria.isError) {
        maria.ShowErrMsg();
        return;
    }

    ItsFind.SetValue('find_MTRITEM', '');    

    LIST_SALODRD_BOM(SUBITEM, PRCCD);
}

// 반제품의 BOM조회
LIST_SALODRD_BOM = function (SUBITEM, PRCCD) {
    var maria = new ItsMaria('SAL3002_R01', 'LIST_SALODRD_BOM');

    maria.AddParam('SALODRDKEY', ItsGrid.GetValue('grid_detail', ItsGrid.GetCurrentIndex('grid_detail'), 'SALODRDKEY'));
    maria.AddParam('SUBITEM', SUBITEM);
    maria.AddParam('PRCCD', PRCCD);

    maria.CallProc();

    if (maria.isError) {
        maria.ShowErrMsg();
        return;
    }

    ItsGrid.SetStore('grid_ADD_MTRITEM', maria.store);
}

ItsPop.Event('POP_ADD_MTRITEM').onPopClosed = function () {
    LIST_SALODRD_ROUT(ItsText.GetValue('txt_ITEMCD_SUB'));
}
/**********************************************************************************************************************************************************************/
// 조립공정 BOM조회
LIST_SALODRD_BOM_ASY = function (SALITEM, PRCCD) {
    var maria = new ItsMaria('SAL3002_R01', 'LIST_SALODRD_BOM');

    maria.AddParam('SALODRDKEY', ItsGrid.GetValue('grid_detail', ItsGrid.GetCurrentIndex('grid_detail'), 'SALODRDKEY'));
    maria.AddParam('SUBITEM', SALITEM);
    maria.AddParam('PRCCD', PRCCD);

    maria.CallProc();

    if (maria.isError) {
        maria.ShowErrMsg();
        return;
    }

    ItsGrid.SetStore('grid_ADD_MTRITEM_ASY', maria.store);
}

// 조립공정 자재추가
ItsButton.Event('btn_ADD_MTRITEM_ASY').onClick = function () {
    var maria = new ItsMaria('SAL3002_R01', 'ADD_MTRITEM');

    var SALODRDKEY = ItsGrid.GetValue('grid_detail', ItsGrid.GetCurrentIndex('grid_detail'), 'SALODRDKEY');
    var SALITEM = ItsText.GetValue('txt_SALITEM');
    var PRCCD = 'ASY';
    var MTRITEM = ItsFind.GetValue('find_MTRITEM_ASY');
    var CUSAGE = ItsNum.GetValue('num_MTR_CUSAGE_ASY');

    maria.AddParam('SALODRDKEY', SALODRDKEY);
    maria.AddParam('SUBITEM', SALITEM);
    maria.AddParam('PRCCD', PRCCD);
    maria.AddParam('MTRITEM', MTRITEM);
    maria.AddParam('CUSAGE', CUSAGE);

    maria.CallProc();

    if (maria.isError) {
        maria.ShowErrMsg();
        return;
    }

    ItsFind.SetValue('find_MTRITEM_ASY', '');

    LIST_SALODRD_BOM_ASY(SALITEM, PRCCD);
}

ItsPop.Event('POP_ADD_MTRITEM_ASY').onPopClosed = function () {
    ItsGrid.Event('grid_detail').onSelect(ItsGrid.GetCurrentIndex('grid_detail'));
}
/**********************************************************************************************************************************************************************/
// 제품버전갱신 팝업오픈
ItsButton.Event('btn_POP_RENEW_ITEM').onClick = function () {
    ItsPage.InitData('div_RENEW_MSTITEM');
    ItsPop.Open('pop_RENEW_MSTITEM');
};

// 제품버전갱신
ItsButton.Event('btn_RENEW_MSTITEM').onClick = function () {
    ItsMsg.Confirm('제품버전을 갱신하시겠습니까?? ',
        function () {
            var maria = new ItsMaria('SAL3002_R01', 'RENEW_MSTITEM');

            maria.AddParam('ITEMCD_BEFORE', ItsFind.GetValue('find_ITEMCD_BEFORE'));

            maria.CallProc();

            if (maria.isError) {
                maria.ShowErrMsg();
                return;
            }

            ItsPop.Close('pop_RENEW_MSTITEM');

            ItsMsg.Toast('갱신되었습니다.');
        }
    );
};

ItsFind.Event('find_ITEMCD_BEFORE').onChanged = function (value, oldValue) {
    var REV = '';
    var ITEMNM = '';

    if (value != '' || value != undefined) {        
        ITEMNM = ItsFind.GetNameValue('find_ITEMCD_BEFORE');
        REV = ItsFind.GetRef07Value('find_ITEMCD_BEFORE');
    }

    ItsText.SetValue('txt_REV_BEFORE', REV);
    ItsText.SetValue('txt_ITEMNM_BEFORE', ITEMNM);
}
/**********************************************************************************************************************************************************************/