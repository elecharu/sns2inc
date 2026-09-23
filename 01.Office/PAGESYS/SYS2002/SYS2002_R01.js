/// <reference path="../../Script/reference.js" />
ItsPage.Load = function () {
    ItsGrid.Create('grid1', { isCheckBoxGrid:true }, [
        column.create('헤더코드', 'GPCD1', { width: 100 }),
        column.create('헤더명', 'GPNM', { width: 180, readOnly:false }),
        column.create('사용여부', 'SYSYN', { width: 80, readOnly: false, columnType: enumColumnTypes.check }),
        column.create('상세', 'DETAIL', { width: 70, columnType: enumColumnTypes.button, iconCls: 'fa-list-ul', foreColor:enumColor.gray }),
        column.create('참조설명01', 'REF01NM', { width: 100, readOnly: false }),
        column.create('참조설명02', 'REF02NM', { width: 100, readOnly: false }),
        column.create('참조설명03', 'REF03NM', { width: 100, readOnly: false }),
        column.create('참조설명04', 'REF04NM', { width: 100, readOnly: false }),
        column.create('참조설명05', 'REF05NM', { width: 100, readOnly: false }),
        column.create('참조설명06', 'REF06NM', { width: 100, readOnly: false }),
        column.create('참조설명07', 'REF07NM', { width: 100, readOnly: false }),
        column.create('참조설명08', 'REF08NM', { width: 100, readOnly: false }),
        column.create('참조설명09', 'REF09NM', { width: 100, readOnly: false }),
        column.create('참조설명10', 'REF10NM', { width: 100, readOnly: false }),
        column.create('참조설명11', 'REF11NM', { width: 100, readOnly: false }),
        column.create('참조설명12', 'REF12NM', { width: 100, readOnly: false }),
        column.create('참조설명13', 'REF13NM', { width: 100, readOnly: false }),
        column.create('참조설명14', 'REF14NM', { width: 100, readOnly: false }),
        column.create('참조설명15', 'REF15NM', { width: 100, readOnly: false }),
        column.create('참조설명16', 'REF16NM', { width: 100, readOnly: false }),
        column.create('참조설명17', 'REF17NM', { width: 100, readOnly: false }),
        column.create('참조설명18', 'REF18NM', { width: 100, readOnly: false }),
        column.create('참조설명19', 'REF19NM', { width: 100, readOnly: false }),
        column.create('참조설명20', 'REF20NM', { width: 100, readOnly: false }),
    ]);
};
ItsButton.EventSearch = function () {
    var maria = new ItsMaria('SYS2002_R01', 'LIST_COMTYPEGP');
    maria.AddPanel('sdiv1');
    maria.CallProc();
    if (maria.isError) {
        maria.ShowErrMsg();
        return;
    }
    ItsGrid.SetStore('grid1', maria.store.YnToBool('SYSYN'));
    ItsMsg.Toast(ItsMsg.CommonMsg.SearchComplete(maria.store.Length()));
}
ItsButton.EventAdd = function () {
    ItsPop.Open('pop1');
}
ItsPop.Event('pop1').onAddBtnClick = function () {
    var maria = new ItsMaria('SYS2002_R01', 'ADD_COMTYPEGP');
    maria.AddPanel('pop1');
    maria.CallProc();
    if (maria.isError) {
        maria.ShowErrMsg();
        return;
    }
    ItsGrid.Setkey('grid1', 'GPCD1', ItsText.GetValue('txt_GPCD_ddiv1'));
    ItsPage.InitData('pop1');
    ItsPop.Close('pop1');
    ItsButton.EventSearch();
    ItsMsg.Toast(ItsMsg.CommonMsg.AddComplete);
};
ItsPop.Event('pop1').onCancelBtnClick = function () {
    ItsPage.InitData('pop1');
    ItsPop.Close('pop1');
};
ItsButton.EventSave = function () {
    var comp = 0;
    for (var i = 0; i < ItsGrid.Length('grid1') ; i++) {
        if (ItsGrid.IsChecked('grid1', i)) {
            var maria = new ItsMaria('SYS2002_R01', 'UP_COMTYPEGP');
            maria.AddRecord('grid1', i);
            maria.CallProc();
            if (maria.isError) {
                maria.ShowErrMsg();
            } else {
                comp++;
            }
        }
    }
    ItsButton.EventSearch();
    ItsMsg.Toast(ItsMsg.CommonMsg.SaveComplete(comp));
};
ItsButton.EventDelete = function () {
    ItsMsg.Confirm('삭제하시겠습니까?', function () {
        var comp = 0;
        for (var i = 0; i < ItsGrid.Length('grid1') ; i++) {
            if (ItsGrid.IsChecked('grid1', i)) {
                var maria = new ItsMaria('SYS2002_R01', 'DEL_COMTYPEGP');
                maria.AddRecord('grid1', i);
                maria.CallProc();
                if (maria.isError) {
                    maria.ShowErrMsg();
                } else {
                    comp++;
                }
            }
        }
        ItsButton.EventSearch();
        ItsMsg.Toast('삭제되었습니다.');
    });
};
ItsGrid.Event('grid1').onButtonClick = function (rowIndex, field) {
    if (field == 'DETAIL') {
        ItsPage.Jump('MST1001_R05', ItsGrid.GetValue('grid1', rowIndex, 'GPCD1'));
    }
};