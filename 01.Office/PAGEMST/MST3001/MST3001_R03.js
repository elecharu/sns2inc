/// <reference path="../../Script/reference.js" />

var uploadStatus = { file1Done: false, fileKey1: '' };

// 2026-10-06 페이지 로드 시 설비부품 그리드(grid1) 초기화
ItsPage.Load = function () {

    ItsGrid.Create('grid1', { isCheckBoxGrid: true }, [
        column.create('부품코드', 'PARTCD', { width: 90 }),
        column.create('부품명', 'PARTNM', { width: 150, readOnly: false }),
        column.create('타입', 'TYPE', { width: 150, readOnly: false }),
        column.create('규격', 'SPEC', { width: 150, readOnly: false }),
        column.create('재고수량', 'STOCKQTY', { width: 90, readOnly: true, columnType: enumColumnTypes.number }),
        column.create('안전재고수량', 'SAFEQTY', { width: 90, readOnly: false, columnType: enumColumnTypes.number }),
        column.create('단위', 'UNIT', { width: 80, align: 'center', readOnly: false, columnType: enumColumnTypes.combo, gpcd: 'ITEMUNIT' }),
        column.create('특이사항', 'REMARK', { width: 250, readOnly: false }),
        column.band('사진관리', {}, [
            column.create('파일등록', 'FILEKEY', { width: 80, columnType: enumColumnTypes.button, iconCls: 'fa-file' }),
            column.create('파일명', 'FILENAME', { width: 200 }),
            column.create('파일보기', 'OPENFILE', { width: 80, columnType: enumColumnTypes.button, iconCls: 'fa-search' })
        ]),
        column.split()
    ]);
};

// 2026-10-06 검색 조건 기준 설비부품 목록 조회 (grid1)
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

// 2026-10-06 설비부품 추가 팝업(pop1) 오픈
ItsButton.EventAdd = function () {
    ItsPage.InitData('pdiv1');
    ItsPop.Open('pop1');
};

// 2026-10-06 설비부품 추가 팝업(pop1) 저장 버튼 이벤트
ItsPop.Event('pop1').onAddBtnClick = function () {
    ItsMsg.Confirm('해당 부품을 추가하시겠습니까?', function () {
        uploadStatus = { file1Done: false, fileKey1: '' };

        var changed = ItsFileManager.IsFileChanged('pop_file_PART');

        if (changed) {
            ItsFileManager.Upload('pop_file_PART');
        } else {
            addEqm('');
        }
    });
};

// 2026-10-06 이미지 파일 업로드 콜백 이벤트
ItsFileManager.Event('pop_file_PART').onUpload = function (id, fileKey) {
    uploadStatus.file1Done = true;
    uploadStatus.fileKey1 = fileKey;
    tryAddEqm();
};

function tryAddEqm() {
    var changed = ItsFileManager.IsFileChanged('pop_file_PART');

    if (!changed || uploadStatus.file1Done) {
        addEqm(uploadStatus.fileKey1);
    }
}

// 2026-10-06 설비부품 정보 DB 저장
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

// 2026-10-06 설비부품 추가 팝업(pop1) 취소 버튼
ItsPop.Event('pop1').onCancelBtnClick = function () {
    ItsPop.Close('pop1');
};

// 2026-10-06 선택 설비부품 수정 저장 (grid1)
ItsButton.EventSave = function () {
    ItsMsg.Confirm('선택항목을 수정하시겠습니까?', function () {
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

        ItsMsg.Toast(ItsMsg.CommonMsg.SaveComplete());
        ItsButton.EventSearch();
    });
};

// 2026-10-06 선택 설비부품 삭제 (grid1)
ItsButton.EventDelete = function () {
    ItsMsg.Confirm('선택항목을 삭제하시겠습니까?', function () {
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

        ItsMsg.Toast(ItsMsg.CommonMsg.DeleteComplete());
        ItsButton.EventSearch();
    });
};

// 2026-10-06 그리드 내 파일등록 및 파일보기 버튼 클릭 이벤트
ItsGrid.Event('grid1').onButtonClick = function (rowIndex, field) {
    if (field == 'FILEKEY') {
        var maria = new ItsMaria('MST3001_R03', 'GET_FILEURL');
        maria.AddRecord('grid1', rowIndex);
        maria.CallProc();
        if (maria.isError) {
            maria.ShowErrMsg();
            return;
        }

        ItsFileManager.SetFileKey('pdiv2_FILEKEY', maria.store.data[0]['FILEKEY']);
        ItsFileManager.SetFileName('pdiv2_FILEKEY', maria.store.data[0]['FILENAME']);
        ItsText.SetValue('pdiv2_FILEURL', maria.store.data[0]['FILEURL']);

        ItsPop.Open('pop2');
    }
    else if (field == 'OPENFILE') {
        var maria = new ItsMaria('MST3001_R03', 'GET_FILEURL');

        maria.AddRecord('grid1', rowIndex);
        maria.CallProc();

        if (maria.isError) {
            maria.ShowErrMsg();
            return;
        }

        var url = maria.store.data[0]['FILEURL'];

        if (url != '' && url != undefined) {
            window.open(url, '_blank');
        }
    }
};

// 2026-10-06 그리드 파일명 더블클릭 시 미리보기
ItsGrid.Event('grid1').onDoubleClick = function (rowIndex, field) {
    if (field == 'FILENAME' && ItsGrid.GetValue('grid1', rowIndex, 'FILENAME') != '' && ItsGrid.GetValue('grid1', rowIndex, 'FILENAME') != undefined) {
        showPdf(ItsGrid.GetValue('grid1', rowIndex, 'FILEURL'), ItsGrid.GetValue('grid1', rowIndex, 'FILEURL'));
    }
};

// 2026-10-06 문서/이미지 파일 뷰어
function showPdf(url, RUrl) {
    if (!RUrl) return;

    if (RUrl.substr(RUrl.length - 3, 3) != 'pdf') {
        var top = (window.screen.height / 2) - (744 / 2);
        if (ItsPage.$helpPop != undefined) {
            ItsPage.$helpPop.close();
        }
        ItsPage.$helpPop = window.open(url, '_blank', 'height=500px, width=400px, top=' + top + 'px, left=200px, screenX=600px');
    }
    else {
        var path = RUrl;
        if ($('#manual_content_pop').length == 0) {
            var $iframeReport = '';
            $iframeReport += "<div id='report_content_pop' class='ItsPop' title='Report Viewer' style='width:1200px;height:780px;'>";
            $iframeReport += "<iframe id='manual_content' src='../../Script/pdfjs/web/viewer.html?file=emptyFile.pdf' ";
            $iframeReport += "scrolling='no' marginwidth='0' seamless ";
            $iframeReport += "width='100%' height='100%' frameborder='0' framespacing='0'>";
            $iframeReport += '</iframe></div>';
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
                        $('#report_content_pop').parent().css('top', '0px');
                    }
                },
                close: function (event, ui) {
                    document.getElementById('manual_content').src = '../../Script/pdfjs/web/viewer.html?file=emptyFile.pdf';
                }
            });
        }
        $('#report_content_pop').dialog('open');
        document.getElementById('manual_content').src = '../../Script/pdfjs/web/viewer.html?file=' + path;
    }
}

// 2026-10-06 사진 등록 팝업(pop2) 파일 업로드 완료 이벤트
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
    ItsMsg.Toast('업로드 완료');
    ItsButton.EventSearch();
};

// 2026-10-06 사진 등록 팝업(pop2) 파일 삭제 완료 이벤트
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
    ItsMsg.Toast(ItsMsg.CommonMsg.DeleteComplete());
    ItsButton.EventSearch();
};

// 2026-10-06 사진 등록 팝업(pop2) 다운로드 버튼
ItsButton.Event('pdiv2_btn_DOWNLOAD').onClick = function () {
    var url = ItsText.GetValue('pdiv2_FILEURL');
    var fileName = ItsFileManager.GetFileName('pdiv2_FILEKEY');

    if (url != '' && url != undefined) {
        var link = document.createElement('a');
        link.href = url;
        link.download = fileName || 'download';
        link.click();
    }
    else {
        ItsMsg.Alert('등록된 파일이 없습니다.');
    }
};

// 2026-10-06 사진 등록 팝업(pop2) 파일보기 버튼
ItsButton.Event('pdiv2_btn_OPEN_FILE').onClick = function () {
    var url = ItsText.GetValue('pdiv2_FILEURL');

    if (url != '' && url != undefined) {
        window.open(url, '_blank');
    }
    else {
        ItsMsg.Alert('등록된 파일이 없습니다.');
    }
};