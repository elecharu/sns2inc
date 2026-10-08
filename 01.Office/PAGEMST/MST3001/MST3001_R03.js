/// <reference path="../../Script/reference.js" />

/* 페이지 로드 시 수행 */
ItsPage.Load = function () {

    ItsGrid.Create('grid1', { isCheckBoxGrid: true }, [
        column.create('부품코드', 'PARTCD', { width: 90 }),
        column.create('부품명', 'PARTNM', { width: 150, readOnly: false }),
        column.create('타입', 'TYPE', { width: 150, readOnly: false }),
        column.create('규격', 'SPEC', { width: 150, readOnly: false }),
        column.create('재고수량', 'STOCKQTY', { width: 90, readOnly: true, columnType: enumColumnTypes.number }),
        column.create('안전재고수량', 'SAFEQTY', { width: 90, readOnly: false, columnType: enumColumnTypes.number }),
        column.create('단위', 'UNIT', { width: 80, align:'center', readOnly: false, columnType: enumColumnTypes.combo, gpcd: 'ITEMUNIT' }),
        column.create('특이사항', 'REMARK', { width: 250, readOnly: false }),
        column.band('사진관리', {}, [
            column.create("파일등록", "FILEKEY", { width: 80, columnType: enumColumnTypes.button, iconCls: 'fa-file' }),
            column.create('파일명', 'FILENAME', { width: 200 }),
            column.create("파일보기", "OPENFILE", { width: 80, columnType: enumColumnTypes.button, iconCls: 'fa-search' }),
        ]),
        column.split()
    ]);


    //ItsButton.EventSearch();
};

/* 조회 */
ItsButton.EventSearch = function () {
    var maria = new ItsMaria('MST3001_R03', 'LIST_EQMPART');

    maria.AddPanel('sdiv1');

    maria.CallProc();

    if (maria.isError) {
        maria.ShowErrMsg();
        return;
    }

    ItsGrid.SetStore('grid1', maria.store);

    ItsMsg.Toast(ItsMsg.CommonMsg.SearchComplete(maria.store.Length()));
};


/* 추가 */
ItsButton.EventAdd = function () {
    ItsPage.InitData('pdiv1');
    ItsPop.Open('pop1');
};

//팝업 저장버튼 이벤트
ItsPop.Event('pop1').onAddBtnClick = function () {    
    ItsMsg.Confirm("해당부품을 추가하시겠습니까?", function () {
        uploadStatus = { file1Done: false,  fileKey1: '' };

        const changed1 = ItsFileManager.IsFileChanged('pop_file_PART');
        
        if (changed1) ItsFileManager.Upload('pop_file_PART');

        if (!changed1) {
            addEqm('');
        }
    })
}

ItsFileManager.Event('pop_file_PART').onUpload = function (id, fileKey) {
    uploadStatus.file1Done = true;
    uploadStatus.fileKey1 = fileKey;
    tryAddEqm();
};


function tryAddEqm() {
    const changed1 = ItsFileManager.IsFileChanged('pop_file_PART');
    
    if (!changed1 || uploadStatus.file1Done)  {
        addEqm(uploadStatus.fileKey1);
    }
}

function addEqm(fileKey) {
    var maria = new ItsMaria('MST3001_R03', 'ADD_EQMPART');
    maria.AddPanel('pdiv1');
    maria.AddParam('IMGFILEKEY', fileKey);

    maria.CallProc();
    if (maria.isError) {
        maria.ShowErrMsg();
        return;
    }
    ItsMsg.Toast(ItsMsg.CommonMsg.AddComplete);
    ItsPop.Close('pop1');
    ItsButton.EventSearch();
}

//팝업 취소버튼
ItsPop.Event('pop1').onCancelBtnClick = function () {
    ItsPop.Close('pop1');
}

/* 저장 */
ItsButton.EventSave = function () {
    ItsMsg.Confirm("선택항목을 수정하시겠습니까?", function () {
        var maria = new ItsMaria('MST3001_R03', 'UPDATE_EQMPART');

        for (var i = 0; i < ItsGrid.Length('grid1'); i++) {
             if (ItsGrid.IsChecked('grid1', i)) {
                maria.AddList('PARTCD_LIST', ItsGrid.GetValue('grid1', i, 'PARTCD'));
                maria.AddList('PARTNM_LIST', ItsGrid.GetValue('grid1', i, 'PARTNM'));
                maria.AddList('SPEC_LIST', ItsGrid.GetValue('grid1', i, 'SPEC'));
                maria.AddList('REMARK_LIST', ItsGrid.GetValue('grid1', i, 'REMARK'));
                maria.AddList('SAFEQTY_LIST', ItsGrid.GetValue('grid1', i, 'SAFEQTY'));
                maria.AddList('TYPE_LIST', ItsGrid.GetValue('grid1', i, 'TYPE'));
                maria.AddList('UNIT_LIST', ItsGrid.GetValue('grid1', i, 'UNIT'));                 
             }
        }

        maria.CallProc();

        if (maria.isError) {
            maria.ShowErrMsg();
            return;
        } 

        ItsMsg.Toast('수정되었습니다.');
        ItsMsg.Toast(ItsMsg.CommonMsg.SaveComplete());
        ItsButton.EventSearch();

    });
};

/* 삭제 */
ItsButton.EventDelete = function () {
    ItsMsg.Confirm("선택항목을 삭제하시겠습니까?", function () {
        var maria = new ItsMaria('MST3001_R03', 'DELETE_EQMPART');

        for (var i = 0; i < ItsGrid.Length('grid1'); i++) {
            if (ItsGrid.IsChecked('grid1', i)) {
                maria.AddList('PARTCD_LIST', ItsGrid.GetValue('grid1', i, 'PARTCD'));
            }
        }

        maria.CallProc();

        if (maria.isError) {
            maria.ShowErrMsg();
            return;
        }

        ItsMsg.Toast('삭제가되었습니다.');
        ItsButton.EventSearch();
    });

};


ItsGrid.Event('grid1').onButtonClick = function (rowIndex, field) {
    if (field == "FILEKEY") {
        var maria = new ItsMaria('MST3001_R03', 'GET_FILEURL');
        maria.AddRecord('grid1', rowIndex);
        maria.CallProc();
        if (maria.isError) {
            maria.ShowErrMsg();
            return;
        }

        ItsFileManager.SetFileKey('pdiv2_FILEKEY', maria.store.data[0]["FILEKEY"]);
        ItsFileManager.SetFileName('pdiv2_FILEKEY', maria.store.data[0]['FILENAME']);
        ItsText.SetValue('pdiv2_FILEURL', maria.store.data[0]['FILEURL']);

        ItsPop.Open('pop2');
    }
    else if (field == "OPENFILE") {
        // 파일보기 버튼
        var maria = new ItsMaria('MST3001_R03', 'GET_FILEURL');

        maria.AddRecord('grid1', rowIndex);
        maria.CallProc();

        if (maria.isError) {
            maria.ShowErrMsg();
            return;
        }

        var url = maria.store.data[0]['FILEURL'];

        if (url != "" && url != undefined) {
            window.open(url, '_blank');
        }
    }
}



ItsGrid.Event('grid1').onDoubleClick = function (rowIndex, field) {
    if (field == "FILENAME" && ItsGrid.GetValue('gird1', rowIndex, 'FILENAME') != "" && ItsGrid.GetValue('grid1', rowIndex, 'FILENAME') != undefined) {
        showPdf(ItsGrid.GetValue('grid1', rowIndex, 'FILEURL'), ItsGrid.GetValue('grid1', rowIndex, 'FILEURL'));
    }
}

function showPdf(url, RUrl) {

    if (RUrl.substr(RUrl.length - 3, 3) != "pdf") {
        var top = (window.screen.height / 2) - (744 / 2);
        if (ItsPage.$helpPop != undefined) {
            ItsPage.$helpPop.close();
        }
        ItsPage.$helpPop = window.open(url, "_blank", 'height=500px, width=400px, top=' + top + 'px, left=200px, screenX=600px');
        //ItsPage.$helpPop.focus();
    }
    else {
        var path = RUrl;
        if ($('#manual_content_pop').length == 0) {
            var $iframeReport = "";
            $iframeReport += "<div id='report_content_pop' class='ItsPop' title='Report Viewer' style='width:1200;hright:780'>";
            $iframeReport += "<iframe id='manual_content' src = '../../Script/pdfjs/web/viewer.html?file=emptyFile.pdf' ";
            $iframeReport += "scrolling='no' marginwidth='0' seamless ";
            $iframeReport += "width='100%' height='100%'' frameborder=0 framespacing=0 ";
            $iframeReport += "></iframe></div>";
            var rptPop = $($iframeReport);
            rptPop.dialog({
                width: 1000,
                height: 780,
                autoOpen: false,
                modal: true,
                resizable: false,
                open: function () {
                    $('.ui-dialog-titlebar-close').html('<i class="fa fa-times"></i>');
                    if (parseFloat($('#report_content_pop').parent().css('top').replace('px', '')) < 0) {
                        $('#report_content_pop').parent().css('top', '0px')
                    }
                },
                close: function (event, ui) {
                    document.getElementById('manual_content').src = '../../Script/pdfjs/web/viewer.html?file=emptyFile.pdf';
                }
            })
        }
        $('#report_content_pop').dialog("open");
        document.getElementById('manual_content').src = '../../Script/pdfjs/web/viewer.html?file=' + path;
    };
}

// 파일업로드 이벤트
ItsFileManager.Event('pdiv2_FILEKEY').onUpload = function (id, filekey) {
    var maria = new ItsMaria('MST3001_R03', 'UPLOAD_FILE');
    maria.AddRecord('grid1', ItsGrid.GetCurrentIndex('grid1'));
    maria.AddParam('FILEKEY', filekey);
    maria.CallProc();
    if (maria.isError) {
        maria.ShowErrMsg();
        return;
    }

    ItsPop.Close('pop2');
    ItsMsg.Toast("업로드 완료");

    ItsButton.EventSearch();
}

ItsFileManager.Event('pdiv2_FILEKEY').onDelete = function (id, filekey) {
    var maria = new ItsMaria('MST3001_R03', 'DEL_FILE');
    maria.AddRecord('grid1', ItsGrid.GetCurrentIndex('grid1'));
    maria.AddParam('FILEKEY', filekey);
    maria.CallProc();
    if (maria.isError) {
        maria.ShowErrMsg();
        return;
    }

    ItsPop.Close('pop2');
    ItsMsg.Toast("삭제 완료");

    ItsButton.EventSearch();
}

// 다운로드 버튼
ItsButton.Event('pdiv2_btn_DOWNLOAD').onClick = function () {
    var url = ItsText.GetValue('pdiv2_FILEURL');

    if (url != '' && url != undefined) {
        var link = document.createElement('a');

        url = url.replace('http://183.106.107.163:8001', '../..');  // 앞주소 날려줘야 pdf, 이미지파일이 바로 오픈안되고 다운로드됨        
        link.href = url;
        link.download = ItsFileManager.GetFileName('pdiv2_FILEKEY');
        link.click();
        link.remove();
    }
    else {
        ItsMsg.Alert('등록된 파일이 없습니다.');
        return;
    }
}

// 파일보기
ItsButton.Event('pdiv2_btn_OPEN_FILE').onClick = function () {
    var url = ItsText.GetValue('pdiv2_FILEURL');

    if (url != '' && url != undefined) {
        window.open(url, '_blank');
    }
    else {
        ItsMsg.Alert('등록된 파일이 없습니다.');
        return;
    }
}