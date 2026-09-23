/// <reference path="../../Script/reference.js" />
/* 페이지 로드 시 수행 */
ItsPage.Load = function () {

    /* 그리드 생성 */
    // 공정검사 그룹
    ItsGrid.Create('grid1', { isCheckBoxGrid: true }, [
        column.create("검사구분", "STDTP", { width: 100, columnType: enumColumnTypes.combo, gpcd: 'STDTP' , readOnly: false, align: 'center', }),
        column.create("검사항목코드", "STDCD", { width: 100, hidden: true }),
        column.create("검사항목", "STDNM", { width: 200, readOnly: false }),
        column.create("검사방법", "STDCHKTP", { width: 100, columnType: enumColumnTypes.combo, gpcd: 'STDCHKTP', readOnly: false, align: 'center' }),
        column.create("측정부위", "STDPOINT", { width: 100, columnType: enumColumnTypes.combo, gpcd: 'STDPOINT', readOnly: false, align: 'center' }),
        column.band('판정기준', {}, [
            column.create("단위", "STDUNIT", { width: 60, columnType: enumColumnTypes.combo, gpcd: 'STDUNIT', readOnly: false, align: 'center' }),
            column.create('범위', 'STDRANGE', { width: 60, columnType: enumColumnTypes.combo, gpcd: 'STDRANGE', readOnly: false }),
            column.create('판정기준', 'STDJUDGE', { width: 300, readOnly: false, multiLine: true }),
        ]),

        column.create("비고", "REMARK", { width: 100, readOnly: false }),

        column.split()
    ]);

   
    // 그리드 Row 높이 자동설정
    ItsGrid.Get('grid1').autoRowHeights = true;

};



/* 조회 */
ItsButton.EventSearch = function () {
    var maria = new ItsMaria('TQM1001_R01 ', 'LIST_MSTSTD');

    maria.AddPanel('sdiv1');

    maria.CallProc();

    if (maria.isError) {
        maria.ShowErrMsg();
        return;
    }

    ItsGrid.SetStore('grid1', maria.store);
    //ItsGrid.Get('grid1').autoSizeColumns();

    ItsMsg.Toast(maria.store.Length() + '건이 조회되었습니다.');

 
};
///*********************************************************************************************************************************************************************************/
/////* 추가 */
ItsButton.EventAdd = function () {
    ItsPage.InitData('pdiv1');
    ItsPop.Open('pop_ADD_MSTSTD');
}

//검사방법이 육안일 경우, 범위와 단위가 선택 X
ItsCombo.Event('cmb_STDCHKTP_ADD').onChanged = function (value, oldValue) {
    console.log(value);
    if (value == '01') {
        //ItsCombo.Disable('cmb_STDRANGE_ADD');
        ItsCombo.SetRef01('cmb_STDRANGE_ADD', '01');
        ItsCombo.Disable('cmb_STDUNIT_ADD');


    } else {
        ItsCombo.Enable('cmb_STDRANGE_ADD');
        ItsCombo.Enable('cmb_STDUNIT_ADD');
        ItsCombo.SetRef01('cmb_STDRANGE_ADD', '02');

    }
}

//////팝업 저장버튼 이벤트
ItsPop.Event('pop_ADD_MSTSTD').onAddBtnClick = function () {


    var maria = new ItsMaria('TQM1001_R01', 'ADD_MSTSTD');
    maria.AddPanel('pdiv1');

    maria.CallProc();
    if (maria.isError) {
        maria.ShowErrMsg();
        return;
    }
    ItsMsg.Toast(ItsMsg.CommonMsg.AddComplete);

    ItsPop.Close('pop_ADD_MSTSTD');
    ItsButton.EventSearch();

}


ItsPop.Event('pop_ADD_MSTSTD').onCancelBtnClick = function () {
    ItsPop.Close('pop_ADD_MSTSTD');
}



ItsGrid.Event('grid1').onChanged = function (rowIndex, field) {

    const STDCHKTP = ItsGrid.GetValue('grid1', rowIndex, 'STDCHKTP');

    if (STDCHKTP === '01') {
        ItsGrid.SetValue('grid1', rowIndex, 'STDUNIT', '');
        ItsGrid.SetValue('grid1', rowIndex, 'STDRANGE', '09');

    }
    
}


ItsPop.Event('pop_ADD_MSTSTD').onCancelBtnClick = function () {
    ItsPop.Close('pop_ADD_MSTSTD');
}

/*********************************************************************************************************************************************************************************/
/* 저장 */
ItsButton.EventSave = function () {
    var maria = new ItsMaria('TQM1001_R01', 'UPDATE_MSTSTD');
    var hasChecked = false;

    for (var i = 0; i < ItsGrid.Length('grid1'); i++) {
        if (ItsGrid.IsChecked('grid1', i)) {
            hasChecked = true;
            maria.AddList('STDTP_LIST', ItsGrid.GetValue('grid1', i, 'STDTP'));
            maria.AddList('STDCD_LIST', ItsGrid.GetValue('grid1', i, 'STDCD'));
            maria.AddList('STDNM_LIST', ItsGrid.GetValue('grid1', i, 'STDNM'));
            maria.AddList('STDCHKTP_LIST', ItsGrid.GetValue('grid1', i, 'STDCHKTP'));
            maria.AddList('STDPOINT_LIST', ItsGrid.GetValue('grid1', i, 'STDPOINT'));
            maria.AddList('STDUNIT_LIST', ItsGrid.GetValue('grid1', i, 'STDUNIT'));
            maria.AddList('STDRANGE_LIST', ItsGrid.GetValue('grid1', i, 'STDRANGE'));
            maria.AddList('STDJUDGE_LIST', ItsGrid.GetValue('grid1', i, 'STDJUDGE'));
            maria.AddList('REMARK_LIST', ItsGrid.GetValue('grid1', i, 'REMARK'));
        }
    }


    if (!hasChecked) {
        ItsMsg.Alert("저장할 항목을 선택하세요.");
        return;
    }

    ItsMsg.Confirm("선택항목을 저장하시겠습니까?", function () {

        maria.CallProc();

        if (maria.isError) {
            maria.ShowErrMsg();
            return;
        }

        ItsMsg.Toast(ItsMsg.CommonMsg.SaveComplete());
        ItsButton.EventSearch();
    });
};
///*********************************************************************************************************************************************************************************/
///* 삭제 */
//ItsButton.EventDelete = function () {
//    var maria = new ItsMaria('TQM1001_R01', 'DELETE_MSTSTD');
//    var hasChecked = false;

//    for (var i = 0; i < ItsGrid.Length('grid1'); i++) {
//        if (ItsGrid.IsChecked('grid1', i)) {
//            hasChecked = true;
//            maria.AddList('STDCD_LIST', ItsGrid.GetValue('grid1', i, 'STDCD'));
//        }
//    }
    
//    if (!hasChecked) {
//        ItsMsg.Alert("삭제할 검사항목을 선택하세요.");
//        return;
//    }

//    ItsMsg.Confirm("선택항목을 삭제하시겠습니까?", function () {

//        maria.CallProc();

//        if (maria.isError) {
//            maria.ShowErrMsg();
//            return;
//        }

//        ItsMsg.Toast(ItsMsg.CommonMsg.DeleteComplete());
//        ItsButton.EventSearch();
//    });
//};
///*********************************************************************************************************************************************************************************/
///* 복사 */
//ItsButton.Event('btn_COPY').onClick = function () {

//    ItsMsg.Confirm("선택항목을 복사하시겠습니까?",
//        function () {

//            var maria = new ItsMaria('TQM1001_R01', 'COPY_MSTSTD');
//            for (var i = 0; i < ItsGrid.Length('grid1'); i++) {
//                if (ItsGrid.IsChecked('grid1', i)) {
//                    maria.AddList('STDTP_LIST', ItsGrid.GetValue('grid1', i, 'STDTP'))
//                    //maria.AddList('STDCD_LIST', ItsGrid.GetValue('grid1', i, 'STDCD'))
//                    maria.AddList('STDNM_LIST', ItsGrid.GetValue('grid1', i, 'STDNM'))
//                    maria.AddList('STDCHKTP_LIST', ItsGrid.GetValue('grid1', i, 'STDCHKTP'))
//                    maria.AddList('STDMACHINE_LIST', ItsGrid.GetValue('grid1', i, 'STDMACHINE'))
//                    maria.AddList('STDPOINT_LIST', ItsGrid.GetValue('grid1', i, 'STDPOINT'))
//                    maria.AddList('STDCYCLE_LIST', ItsGrid.GetValue('grid1', i, 'STDCYCLE'))
//                    maria.AddList('STDUNIT_LIST', ItsGrid.GetValue('grid1', i, 'STDUNIT'))
//                    maria.AddList('STDRANGE_LIST', ItsGrid.GetValue('grid1', i, 'STDRANGE'))
//                    maria.AddList('STDJUDGE_LIST', ItsGrid.GetValue('grid1', i, 'STDJUDGE'))
//                    maria.AddList('REMARK_LIST', ItsGrid.GetValue('grid1', i, 'REMARK'))
//                }

//            }
//            maria.CallProc();
//            if (maria.isError) {
//                maria.ShowErrMsg();
//                return;
//            }

//            ItsMsg.Toast(ItsMsg.CommonMsg.DeleteComplete());

//            ItsButton.EventSearch();
//        }
//    );
//}
///*********************************************************************************************************************************************************************************/
///* 3D 측정파일 조회 */
////조회 버튼
//ItsButton.Event('btn_pop_3D').onClick = function () {
//    ItsGrid.UnCheckAll('grid1');

//    ItsPop.Open('pop2');
//    ItsButton.Event('btn_3D_RESULT').onClick();
//}

////팝업창 조회 버튼
//ItsButton.Event('btn_3D_RESULT').onClick = function () {

//    ItsGrid.Clear('grid3');
//    var maria = new ItsMaria('TQM1001_R01', 'LIST_FILE_3D');
//    maria.AddPanel('pdiv2');

//    maria.CallProc();

//    if (maria.isError) {
//        maria.ShowErrMsg();
//        return;
//    }

//    ItsGrid.SetStore('grid2', maria.store);

//};

////팝업창 닫기
//ItsPop.Event('pop2').onPopClosed = function () {
//    ItsGrid.Clear('grid2');
//    ItsGrid.Clear('grid3');
//}

////팝업 그리드 2 선택시
//ItsGrid.Event('grid2').onSelect = function (rowIndex, field) {

//    var maria = new ItsMaria('TQM1001_R01', 'LIST_DEVICE_3D');

//    maria.AddParam('DEVKEY', ItsGrid.GetValue('grid2', ItsGrid.GetCurrentIndex('grid2'), 'DEVKEY'));

//    maria.CallProc();

//    if (maria.isError) {
//        maria.ShowErrMsg();
//        return;
//    }

//    ItsGrid.SetStore('grid3', maria.store);

//};

////3D 측정 검사항목등록시
//ItsButton.Event('btn_3D_REG').onClick = function () {

//    // grid3의 중복 없는 CHECKPOINT 목록 만들기
//    var NAMESET = new Set();
//    var UNIQUECHECKNAME = [];

//    for (var i = 0; i < ItsGrid.Length('grid3'); i++) {
//        var NAME = ItsGrid.GetValue('grid3', i, 'NAME');
//        if (NAME && ! NAMESET.has(NAME)) {
//            NAMESET.add(NAME);
//            UNIQUECHECKNAME.push(NAME);
//        }
//    }

//    // grid1에 이미 존재하는 STDNM 목록 수집
//    var EXISTING_NAMES = new Set();
//    for (var i = 0; i < ItsGrid.Length('grid1'); i++) {
//        var STDNM = ItsGrid.GetValue('grid1', i, 'STDNM');
//        if (STDNM) {
//            EXISTING_NAMES.add(STDNM.trim());
//        }
//    }

//    //  중복되지 않은 CHECKPOINT만 grid1에 추가
//    UNIQUECHECKNAME.forEach(function (NAME) {
//        if (!EXISTING_NAMES.has(NAME.trim())) {
//            ItsGrid.AddRow('grid1');
//            var lastIndex = ItsGrid.Length('grid1') - 1;

//            ItsGrid.SetValue('grid1', lastIndex, 'STDNM', NAME);
//            ItsGrid.SetValue('grid1', lastIndex, 'STDTP', 'REGULARTEST');
//            ItsGrid.SetValue('grid1', lastIndex, 'STDCHKTP', '02');
//            ItsGrid.SetValue('grid1', lastIndex, 'STDRANGE', '07');
//            ItsGrid.CheckRow('grid1', lastIndex);
//        }
//    });

//    // 4️⃣ 팝업 닫고 갱신 이벤트 호출
//    ItsPop.Close('pop2');
//    ItsGrid.Event('grid2').onChanged();
//};



///*********************************************************************************************************************************************************************************/
//// 사진 클릭
////ItsGrid.Event('grid1').onButtonClick = function (rowIndex, field) {
////    if (field == "FILEKEY") {
////        var maria = new ItsMaria('TQM1001_R01', 'GET_FILEURL');
////        maria.AddRecord('grid1', rowIndex);
////        maria.CallProc();
////        if (maria.isError) {
////            maria.ShowErrMsg();
////            return;
////        }

////        ItsFileManager.SetFileKey('pdiv2_FILEKEY', maria.store.data[0]["FILEKEY"]);
////        ItsFileManager.SetFileName('pdiv2_FILEKEY', maria.store.data[0]['FILENAME']);
////        ItsText.SetValue('pdiv2_FILEURL', maria.store.data[0]['FILEURL']);

////        ItsPop.Open('pop2');
////    }
////}



////ItsGrid.Event('grid1').onDoubleClick = function (rowIndex, field) {
////    if (field == "FILENAME" && ItsGrid.GetValue('gird1', rowIndex, 'FILENAME') != "" && ItsGrid.GetValue('grid1', rowIndex, 'FILENAME') != undefined) {
////        showPdf(ItsGrid.GetValue('grid1', rowIndex, 'FILEURL'), ItsGrid.GetValue('grid1', rowIndex, 'FILEURL'));
////    }
////}

////function showPdf(url, RUrl) {

////    if (RUrl.substr(RUrl.length - 3, 3) != "pdf") {
////        var top = (window.screen.height / 2) - (744 / 2);
////        if (ItsPage.$helpPop != undefined) {
////            ItsPage.$helpPop.close();
////        }
////        ItsPage.$helpPop = window.open(url, "_blank", 'height=500px, width=400px, top=' + top + 'px, left=200px, screenX=600px');
////        //ItsPage.$helpPop.focus();
////    }
////    else {
////        var path = RUrl;
////        if ($('#manual_content_pop').length == 0) {
////            var $iframeReport = "";
////            $iframeReport += "<div id='report_content_pop' class='ItsPop' title='Report Viewer' style='width:1200;hright:780'>";
////            $iframeReport += "<iframe id='manual_content' src = '../../Script/pdfjs/web/viewer.html?file=emptyFile.pdf' ";
////            $iframeReport += "scrolling='no' marginwidth='0' seamless ";
////            $iframeReport += "width='100%' height='100%'' frameborder=0 framespacing=0 ";
////            $iframeReport += "></iframe></div>";
////            var rptPop = $($iframeReport);
////            rptPop.dialog({
////                width: 1000,
////                height: 780,
////                autoOpen: false,
////                modal: true,
////                resizable: false,
////                open: function () {
////                    $('.ui-dialog-titlebar-close').html('<i class="fa fa-times"></i>');
////                    if (parseFloat($('#report_content_pop').parent().css('top').replace('px', '')) < 0) {
////                        $('#report_content_pop').parent().css('top', '0px')
////                    }
////                },
////                close: function (event, ui) {
////                    document.getElementById('manual_content').src = '../../Script/pdfjs/web/viewer.html?file=emptyFile.pdf';
////                }
////            })
////        }
////        $('#report_content_pop').dialog("open");
////        document.getElementById('manual_content').src = '../../Script/pdfjs/web/viewer.html?file=' + path;
////    };
////}

////// 파일업로드 이벤트
////ItsFileManager.Event('pdiv2_FILEKEY').onUpload = function (id, filekey) {
////    var maria = new ItsMaria('TQM1001_R01', 'UPLOAD_FILE');
////    maria.AddRecord('grid1', ItsGrid.GetCurrentIndex('grid1'));
////    maria.AddParam('FILEKEY', filekey);
////    maria.CallProc();
////    if (maria.isError) {
////        maria.ShowErrMsg();
////        return;
////    }

////    ItsPop.Close('pop2');
////    ItsMsg.Toast("업로드 완료");

////    ItsButton.EventSearch();
////}

////ItsFileManager.Event('pdiv2_FILEKEY').onDelete = function (id, filekey) {
////    var maria = new ItsMaria('TQM1001_R01', 'DEL_FILE');
////    maria.AddRecord('grid1', ItsGrid.GetCurrentIndex('grid1'));
////    maria.AddParam('FILEKEY', filekey);
////    maria.CallProc();
////    if (maria.isError) {
////        maria.ShowErrMsg();
////        return;
////    }

////    ItsPop.Close('pop2');
////    ItsMsg.Toast("삭제 완료");

////    ItsButton.EventSearch();
////}





////ItsFileManager.Event('pop_file_STD').onUpload = function (id, fileKey) {
////    uploadStatus.file1Done = true;
////    uploadStatus.fileKey1 = fileKey;
////    tryAddStd();
////};


////function tryAddStd() {
////    const changed1 = ItsFileManager.IsFileChanged('pop_file_STD');

////    if (!changed1 || uploadStatus.file1Done) {
////        addStd(uploadStatus.fileKey1);
////    }   
////}

////function addStd(fileKey) {
////    var maria = new ItsMaria('TQM1001_R01', 'ADD_MSTSTD');
////    maria.AddPanel('pdiv1');
////    maria.AddParam('IMGFILEKEY', fileKey);

////    maria.CallProc();
////    if (maria.isError) {
////        maria.ShowErrMsg();
////        return;
////    }
////    ItsMsg.Toast(ItsMsg.CommonMsg.AddComplete);

////    ItsPop.Close('pop_ADD_MSTSTD');
////    ItsButton.EventSearch();
////}