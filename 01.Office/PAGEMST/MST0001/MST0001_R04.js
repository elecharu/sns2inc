//설비정보
/// <reference path="../../Script/reference.js" />
/* 페이지 접근 시 수행 */
ItsPage.Load = function () {

    ItsGrid.Create('grid1', { isCheckBoxGrid: false }, [
        column.create('설비코드', 'EQMCD', { width: 90 }),
        column.create('설비호기', 'EQMNO', { width: 100 }),
        column.create('설비명', 'EQMNM', { width: 200 }),
        column.create('설비유형', 'EQMTP', { width: 150, columnType: enumColumnTypes.combo, gpcd: 'EQMTP' }),
        column.create('사용공정', 'PRCCD', { width: 100, columnType: enumColumnTypes.combo, gpcd: 'PRCCD' }),
        column.create('설비규격', 'EQMSPEC', { width: 100 }),
        column.create('담당부서', 'DEPTP', { width: 100, columnType: enumColumnTypes.combo, gpcd: 'DEPTP' }),
        column.create('구매일자', 'BUYDATE', { width: 100, columnType: enumColumnTypes.date }),
        column.create('사업장', 'BDVCD', { width: 100, columnType: enumColumnTypes.combo, gpcd: 'BDVCD' }),
        column.create('비고', 'REMARK', { width: 100 }),
        column.split()
    ]);
    ItsButton.EventSearch();
};

/* 조회 */
ItsButton.EventSearch = function () {
    ItsPage.InitData('div1');

    var maria = new ItsMaria('MST0001_R04', 'LIST_MSTEQM');
    maria.AddPanel('sdiv1');
    maria.CallProc();
    if (maria.isError) {
        maria.ShowErrMsg();
        return;
    }
    ItsGrid.SetStore('grid1', maria.store);
    ItsPage.SetStore('grid1', maria.store.FirstRecord());
    ItsMsg.Toast(ItsMsg.CommonMsg.SearchComplete(maria.store.Length()));
};

ItsGrid.Event('grid1').onSelect = function (rowIndex) {
    ItsPage.SetStore('div1', ItsGrid.GetRowData('grid1', rowIndex));

    var src = ItsGrid.GetValue('grid1', rowIndex, 'IMAGEURL');
    var key = ItsGrid.GetValue('grid1', rowIndex, 'IMGFILEKEY');
    if (src != null) {
        ItsImage.SetImage('img_EQM', src, key);
    } else {
        ItsImage.SetImage('img_EQM', '../../UploadFiles/404IMAGE.jpg', '');
    }
}

/* 삭제 */
ItsButton.EventDelete = function () {
    ItsMsg.Confirm("선택항목을 삭제하시겠습니까?",
        function () {
            
         var maria = new ItsMaria('MST0001_R04', 'DEL_MSTEQM');
         maria.AddParam('EQMCD', ItsGrid.GetValue('grid1', ItsGrid.GetCurrentIndex('grid1'), 'EQMCD'));
         maria.CallProc();

            if (maria.isError) {
                maria.ShowErrMsg();
            }
            
         ItsMsg.Toast(ItsMsg.CommonMsg.DeleteComplete());
         ItsButton.EventSearch();
        }
    );
}

/* 수정 저장 */
ItsButton.EventSave = function () {

    var fileKey = ItsFileManager.GetFileKey('file_EQM');
    var dbFileKey = ItsGrid.GetValue('grid1', ItsGrid.GetCurrentIndex('grid1'), 'IMGFILEKEY');

    if (fileKey == '' && dbFileKey != '' && dbFileKey != undefined) {                // db에는 파일이 있으나 clear 되어있다면 삭제
        ItsFileManager.Delete('file_EQM', dbFileKey);
    } else if (ItsFileManager.IsFileChanged('file_EQM')) { // 파일이 바뀐 흔적이 있다면 파일 업로드
        ItsFileManager.Upload('file_EQM');
    } else {                                               // 이쪽으로 탔을때는 파일 처리할 일이 없을듯? 바로 다른필드 수정만
        saveEqm(dbFileKey);
    }
}

// 이미지 업로드, 삭제 후에 키를 받아온 것으로 처리
ItsFileManager.Event('file_EQM').onUpload = function (id, fileKey) {
    saveEqm(fileKey);
};
ItsFileManager.Event('file_EQM').onDelete = function (id, fileKey) {
    saveEqm(fileKey);
};

ItsImage.Event('img_EQM').onClick = function (url) {
    ItsImage.SetImage('big_img_EQM', url, "");
    ItsPop.Open('pop2');
}

function saveEqm(filekey) {
    var maria = new ItsMaria('MST0001_R04', 'UP_MSTEQM');
    maria.AddPanel('div1');
    maria.AddParam('IMGFILEKEY', filekey);
    maria.CallProc();
    if (maria.isError) {
        maria.ShowErrMsg();
        return;
    }
    ItsMsg.Toast(ItsMsg.CommonMsg.SaveComplete());
    ItsButton.EventSearch();
}

ItsButton.EventAdd = function () {
    ItsPage.InitData('pdiv1');
    ItsFileManager.Clear('pop_file_EQM');
    ItsPop.Open('pop1');
}

ItsPop.Event('pop1').onAddBtnClick = function () {
    if (ItsFileManager.IsFileChanged('pop_file_EQM')) {
        ItsFileManager.Upload('pop_file_EQM');
    } else {
        addEqm('');
    }
}

ItsFileManager.Event('pop_file_EQM').onUpload = function (id, fileKey) {
    addEqm(fileKey);
};

function addEqm(filekey) {
    var maria = new ItsMaria('MST0001_R04', 'ADD_MSTEQM');
    maria.AddPanel('pdiv1');
    maria.AddParam('IMGFILEKEY', filekey);
    maria.CallProc();
    if (maria.isError) {
        maria.ShowErrMsg();
        return;
    }
    ItsMsg.Toast(ItsMsg.CommonMsg.AddComplete);
    ItsPop.Close('pop1');
    ItsButton.EventSearch();
}

ItsPop.Event('pop1').onCancelBtnClick = function () {
    ItsPop.Close('pop1');
}