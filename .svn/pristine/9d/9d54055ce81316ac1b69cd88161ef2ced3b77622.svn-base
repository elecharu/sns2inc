/// <reference path="../../Script/reference.js" />
var dbFileKey;

/* 페이지 로드 시 수행 */
ItsPage.Load = function () {

    ItsButton.EventSearch();

};

/* 조회 버튼 */
ItsButton.EventSearch = function () {
    var maria = new ItsMaria('SYS1001_R01', 'INFO_COMPANY');
    maria.CallProc();
    if (maria.isError) {
        maria.ShowErrMsg();
        return;
    }
    dbFileKey = maria.store.GetValue(0, 'LOGOIMAGE');
    ItsImage.SetImage('img_LOGO', maria.store.GetValue(0, 'LOGOIMAGEURL'));
    ItsPage.SetStore('ddiv1', maria.store.FirstRecord());
    ItsPage.SetStore('ddiv2', maria.store.FirstRecord());
    ItsText.SetValue('txt_COMPCD', maria.store.GetValue(0, 'COMPCD'));
};

/* 저장 버튼 */
ItsButton.EventSave = function () {
    var fileKey = ItsFileManager.GetFileKey('file_LOGOIMAGE');

    if (fileKey == '' && dbFileKey != '' && dbFileKey != undefined) {                // db에는 파일이 있으나 clear 되어있다면 삭제
        ItsFileManager.Delete('file_LOGOIMAGE');
    } else if (ItsFileManager.IsFileChanged('file_LOGOIMAGE')) { // 파일이 바뀐 흔적이 있다면 파일 업로드
        ItsFileManager.Upload('file_LOGOIMAGE');
    } else {                                               // 이쪽으로 탔을때는 파일 처리할 일이 없을듯? 바로 다른필드 수정만
        _saveCompany(dbFileKey);
    }

};

// 이미지 업로드, 삭제 후에 키를 받아온 것으로 처리
ItsFileManager.Event('file_LOGOIMAGE').onUpload = function (id, fileKey) {
    _saveCompany(fileKey);
};
ItsFileManager.Event('file_LOGOIMAGE').onDelete = function (id, fileKey) {
    _saveCompany(fileKey);
};

function _saveCompany(filekey) {
    var maria = new ItsMaria('SYS1001_R01', 'UP_COMPANY');
    maria.AddPanel('ddiv1');
    maria.AddPanel('ddiv2');
    maria.AddParam('LOGOIMAGE', filekey);
    maria.CallProc();
    if (maria.isError) {
        maria.ShowErrMsg();
        return;
    }
    ItsButton.EventSearch();
    ItsMsg.Toast('저장되었습니다.');
    ItsButton.EventSearch();
}

/* 우편번호 검색 버튼 */
ItsButton.Event('SEARCH_ZIP').onClick = function () {
    // -----------------------------------------------------------------------------------
    var width = 500; //팝업의 너비
    var height = 600; //팝업의 높이
    new daum.Postcode({
        width: width,
        height: height,
        popupName: 'postcode',
        oncomplete: function (data) {
            // ---- 수정 가능 ----------------------------------------------------------------- //
            ItsText.SetValue('txt_ZIPCD', data.zonecode);
            ItsText.SetValue('txt_ADDRESS', data.roadAddress);
            ItsText.SetValue('txt_ADDRESSDETAIL', ' (' + data.buildingName + ') ');
            ItsText.SetValue('txt_ADDRESSOTHER', '');
            ItsText.SetValue('txt_ADDRESSFULL', data.roadAddress + ' (' + data.buildingName + ') ');
            // ---- 수정 가능 ----------------------------------------------------------------- //
        }
    }).open({ // 가운데 정렬 (듀얼 디스플레이에선 위치 안맞을수 있음)
        left: (window.screen.width / 2) - (width / 2),
        top: (window.screen.height / 2) - (height / 2)
    });
};

/* 상세주소 변경 시 전체 주소에 반영 */
ItsText.Event('txt_ADDRESSOTHER').onChanged = function (value, oldValue) {
    ItsText.SetValue('txt_ADDRESSFULL', ItsText.GetValue('txt_ADDRESS') + ' ' + value + ' ' + ItsText.GetValue('txt_ADDRESSDETAIL'));
};

/* 건물명 변경 시 전체 주소에 반영 */
ItsText.Event('txt_ADDRESSDETAIL').onChanged = function (value, oldValue) {
    ItsText.SetValue('txt_ADDRESSFULL', ItsText.GetValue('txt_ADDRESS') + ' ' + ItsText.GetValue('txt_ADDRESSOTHER') + ' ' + value);
};
