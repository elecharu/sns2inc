/* 페이지 로드 시 최초 실행 */
ItsPage.Load = function () {
    ItsGrid.Create('grid1', {}, [
        column.create('공지자', 'EMPNM', { width: 100, align: 'center' }),
        column.create('공지일자', 'NOTICEFRDT', { width: 100, align: 'center' }),
        column.create('공지제목', 'SUBJECT', { width: 300 }),
        column.create('만료일자', 'NOTICETODT', { width: 100, align: 'center' }),
    ]);

    $('div[style="position: fixed; background: rgba(0, 0, 0, 0.3); left: 0px; top: 0px; width: 100%; height: 100%; font-family: sans-serif; z-index: 10000;"]').remove();
    $('a[href="https://www.grapecity.com/licensing/wijmo?utm_source=Wijmo-In-App&utm_medium=Click-to-Site&utm_campaign=Wijmo-User-Analysis"]').parent().remove();
    $('a[href="https://www.grapecity.com/licensing/wijmo?utm_source=Wijmo-In-App&utm_medium=Click-to-Site&utm_campaign=Wijmo-User-Analysis"]').parent().remove();

    ItsButton.EventSearch();
};

/* 조회 */
ItsButton.EventSearch = function () {
    ItsPage.InitData('div2');
    var maria = new ItsMaria('SYS0000_R01', 'LIST_NOTICE');
    maria.AddPanel('sdiv1');
    maria.CallProc();
    if (maria.isError) {
        maria.ShowErrMsg();
        return;
    }

    ItsGrid.SetStore('grid1', maria.store);

    ItsText.SetValue('text_ENDTIME', maria.storeExtend1.GetValue(0, 'ENDTIME'));
    if (maria.storeExtend1.GetValue(0, 'DIFF') > 3) {
        ItsMsg.Alert('지그비 데이터 수신 장애 발생 추정 ' + maria.storeExtend1.GetValue(0, 'DIFF') + '시간 경과');
    }

};

ItsGrid.Event('grid1').onSelect = function (rowIndex) {
    ItsPage.SetStore('div2', ItsGrid.GetRowData('grid1', rowIndex));
}