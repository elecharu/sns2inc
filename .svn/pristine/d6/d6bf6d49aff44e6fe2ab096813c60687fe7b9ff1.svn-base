/// <reference path="../../Script/reference.js" />
ItsPage.Load = function () {

    ItsGrid.Create('grid1', { isCheckBoxGrid:true }, [
        column.create('권한코드', 'AUTCD', { width: 100 }),
        column.create('권한명', 'AUTNM', { width: 150, readOnly: false }),
        column.create('정렬순서', 'SORTNO', { width: 80, readOnly:false, columnType: enumColumnTypes.number }),
        //column.create('사업장변경', 'BDVYN', { width: 100, readOnly: false, columnType: enumColumnTypes.check }),
        //column.create('부서변경', 'DEPYN', { width: 100, readOnly: false, columnType: enumColumnTypes.check, hidden:true }),
        column.create('비고', 'REMARK', { width: 200, readOnly: false }),
        column.split()
    ]);

    ItsButton.EventSearch();
};

ItsButton.EventSearch = function () {
    var maria = new ItsMaria('SYS3002_R01', 'LIST_SYSAUT');
    maria.AddPanel('sdiv1');
    maria.CallProc();
    if (maria.isError) {
        maria.ShowErrMsg();
        return;
    }
    ItsGrid.SetStore('grid1', maria.store.YnToBool('BDVYN').YnToBool('DEPYN'));
    ItsMsg.Toast(ItsMsg.CommonMsg.SearchComplete());
}

/* 추가 */
ItsButton.EventAdd = function () {
    ItsPop.Open('pop1');
};

ItsPop.Event('pop1').onAddBtnClick = function () {
    var maria = new ItsMaria('SYS3002_R01', 'ADD_SYSAUT');
    maria.AddPanel('pop1');
    maria.CallProc();
    if (maria.isError) {
        maria.ShowErrMsg();
        return;
    }
    ItsPop.Close('pop1');
    ItsMsg.Toast(ItsMsg.CommonMsg.AddComplete());
    ItsButton.EventSearch();
};

ItsPop.Event('pop1').onCancelBtnClick = function () {
    ItsPage.InitData('pop1');
    ItsPop.Close('pop1');
};

/* 저장 */
ItsButton.EventSave = function () {
    var cnt = 0;
    for (var i = 0; i < ItsGrid.Length('grid1') ; i++) {
        if (ItsGrid.IsChecked('grid1', i)) {
            var maria = new ItsMaria('SYS3002_R01', 'UP_SYSAUT');
            maria.AddRecord('grid1', i);
            maria.CallProc();
            if (maria.isError) {
                maria.ShowErrMsg();
            } else {
                cnt++;
            }
        }
    }
    ItsMsg.Toast(ItsMsg.CommonMsg.SaveComplete(cnt));
    ItsButton.EventSearch();
};

/* 삭제 */
ItsButton.EventDelete = function () {
    ItsMsg.Confirm('삭제하시겠습니까?', function () {
        var cnt = 0;
        for (var i = 0; i < ItsGrid.Length('grid1') ; i++) {
            if (ItsGrid.IsChecked('grid1', i)) {
                var maria = new ItsMaria('SYS3002_R01', 'DEL_SYSAUT');
                maria.AddRecord('grid1', i);
                maria.CallProc();
                if (maria.isError) {
                    maria.ShowErrMsg();
                } else {
                    cnt++;
                }
            }
        }
        ItsMsg.Toast(ItsMsg.CommonMsg.DeleteComplete(cnt));
        ItsButton.EventSearch();
    });  
};