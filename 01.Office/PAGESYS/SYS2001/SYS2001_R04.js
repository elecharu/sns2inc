/// <reference path="../../Script/reference.js" />

var IsNew = false;

/* 페이지 로드 시 최초 실행 */
ItsPage.Load = function () {
    ItsGrid.Create('grid1', {}, [
        column.create('공지자', 'EMPNM', { width: 100, align: 'center' }),
        column.create('등록일자', 'NOTICEFRDT', { width: 100, align: 'center' }),
        column.create('현재상태', 'STATUS', { width: 90, align: 'center' }),
        column.create('공지제목', 'SUBJECT', { width: 300 }),
    ]);
    ItsDateRange.SetInitValueFrom('dr_DATE', ItsHelper.AddMonth(-6, ItsHelper.GetYearMonthDay()));
    ItsDateRange.SetInitValueTo('dr_DATE', ItsHelper.GetYearMonthDay());
    ItsButton.EventAdd();
};

/* 조회 */
ItsButton.EventSearch = function () {
    ItsPage.InitData('div2');
    var maria = new ItsMaria('SYS2001_R03', 'LIST_NOTICE');
    maria.AddPanel('sdiv1');
    maria.CallProc();
    if (maria.isError) {
        maria.ShowErrMsg();
        return;
    }

    IsNew = false;
    ItsDate.Disable('date_NOTICEFRDT');
    ItsPage.SetBackColor('div2', enumColor.transparent);
    ItsGrid.SetStore('grid1', maria.store);
    ItsMsg.Toast(ItsMsg.CommonMsg.SearchComplete(maria.store.Length()));
};

ItsGrid.Event('grid1').onSelect = function (rowIndex) {
    ItsPage.SetStore('div2', ItsGrid.GetRowData('grid1', rowIndex));
    IsNew = false;
    ItsDate.Disable('date_NOTICEFRDT');
    ItsPage.SetBackColor('div2', enumColor.transparent);
}

ItsButton.EventAdd = function () {
    ItsPage.InitData('div2');
    ItsDate.SetValue('date_NOTICEFRDT', ItsHelper.GetYearMonthDay());
    ItsDate.SetValue('date_NOTICETODT', ItsHelper.AddMonth(6, ItsHelper.GetYearMonthDay()));
    ItsImage.SetImage('img_WORK', '../../UploadFiles/404IMAGE.jpg', '');
    ItsPage.SetBackColor('div2', enumColor.addPanel);
    IsNew = true;
    ItsDate.Enable('date_NOTICEFRDT');
}

/* 수정 저장 */
ItsButton.EventSave = function () {
    var maria = new ItsMaria('SYS2001_R03', 'UP_NOTICE');
    maria.AddPanel('div2');
    if (IsNew == false)
        maria.AddParam('NOTICEKEY', ItsGrid.GetValue('grid1', ItsGrid.GetCurrentIndex('grid1'), 'NOTICEKEY'));
    else
        maria.AddParam('NOTICEKEY', '');
    maria.AddParam('EMPCD', ItsPage.EMPCD);
    maria.CallProc();
    if (maria.isError) {
        maria.ShowErrMsg();
        return;
    }
    ItsMsg.Toast(ItsMsg.CommonMsg.SaveComplete());
    ItsButton.EventSearch();
}

ItsButton.EventDelete = function () {
    ItsMsg.Confirm("선택항목을 삭제하시겠습니까?",
        function () {
            var maria = new ItsMaria('SYS2001_R03', 'DEL_NOTICE');
            maria.AddParam('NOTICEKEY', ItsGrid.GetValue('grid1', ItsGrid.GetCurrentIndex('grid1'), 'NOTICEKEY'));
            maria.CallProc();
            if (maria.isError) {
                maria.ShowErrMsg();
                return;
            }
            ItsMsg.Toast(ItsMsg.CommonMsg.DeleteComplete());
            ItsButton.EventSearch();
        }
    );
}
