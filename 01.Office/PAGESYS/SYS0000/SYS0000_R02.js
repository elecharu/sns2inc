/// <reference path="../../Script/reference.js" />

/* 페이지 로드 시 수행 */
ItsPage.Load = function () {
    
    ItsGrid.Create('grid1', { isSubTotalGrid: true, groupField: 'GRP' }, [
        column.create("패키지", "PKGTP", { width: 100, align: 'center', columnType: enumColumnTypes.combo, gpcd: 'PKGTP' }),
        column.create("CATE", "CATECD", { width: 70, align: 'center', hidden: true }),
        column.create("카테고리", "CATENM", { width: 100, align: 'center' }),
        column.create("프로그램코드", "PRGCD", { width: 100, align: 'center' }),
        column.create("화면명", "MENUNM", { width: 180 }),
        column.create("추가", "ADDPRG", { width: 70, columnType: enumColumnTypes.button, iconCls: 'fa-arrow-right' }),
        column.split()
    ]);

    ItsGrid.Create('grid2', { }, [
        column.create("패키지", "PKGTP", { width: 100, align: 'center', columnType: enumColumnTypes.combo, gpcd: 'PKGTP' }),
        column.create("CATE", "CATECD", { width: 70, align: 'center', hidden: true }),
        column.create("카테고리", "CATENM", { width: 100, align: 'center' }),
        column.create("프로그램코드", "PRGCD", { width: 100, align: 'center' }),
        column.create("화면명", "MENUNM", { width: 180 }),
        column.band('상단고정', {}, [
            column.create("★", "HOTYN", { width: 70, columnType: enumColumnTypes.check }),
            column.create("고정/취소", "TOP5", { width: 80, columnType: enumColumnTypes.button, iconCls: 'fa-plus' }),
        ]),   
        column.create("삭제", "DELPRG", { width: 70, columnType: enumColumnTypes.button, iconCls: 'fa-times' }),
        column.split()
    ]);

    ItsGrid.Create('grid3', { }, [
        column.create("패키지", "PKGTP", { width: 100, align: 'center', columnType: enumColumnTypes.combo, gpcd: 'PKGTP' }),
        column.create("프로그램코드", "PRGCD", { width: 100, align: 'center' }),
        column.create("화면명", "PRGNM", { width: 180, columnType: enumColumnTypes.find }),
        column.create("사용횟수", "CNT", { width: 70, columnType: enumColumnTypes.number }),
        column.create("추가", "ADDPRG", { width: 70, columnType: enumColumnTypes.button, iconCls: 'fa-arrow-up' }),
        column.split()
    ]);

    setTimeout(function () {
        ItsButton.EventSearch();
    })
};

/* 조회 */
ItsButton.EventSearch = function (mode) {
    var maria = new ItsMaria('SYS0000_R02', 'LIST_SYSMENUUSER');
    maria.AddSessionUserId();
    maria.CallProc();
    if (maria.isError) {
        maria.ShowErrMsg();
        return;
    }
    if (mode == undefined) {
        ItsGrid.SetStore('grid1', maria.store);
        ItsGrid.SetStore('grid3', maria.storeExtend2);
        ItsMsg.Toast(ItsMsg.CommonMsg.SearchComplete());
    }
    ItsGrid.SetStore('grid2', maria.storeExtend1.YnToBool('HOTYN'));
    ItsOnoff.SetValue('onoff_PLUSKEYYN', maria.storeExtend3.GetValue(0, 'PLUSKEYYN'));
    
};
ItsGrid.Event('grid1').onButtonClick = function (rowIndex, field) {
    if (field == 'ADDPRG') {
        var maria = new ItsMaria('SYS0000_R02', 'ADD_SYSMENUUSER');
        maria.AddSessionUserId();
        maria.AddRecord('grid1', rowIndex);
        maria.CallProc();
        if (maria.isError) {
            maria.ShowErrMsg();
            return;
        }
        ItsButton.EventSearch('insert');
    }
}
ItsGrid.Event('grid3').onButtonClick = function (rowIndex, field) {
    if (field == 'ADDPRG') {
        var maria = new ItsMaria('SYS0000_R02', 'ADD_SYSMENUUSER');
        maria.AddSessionUserId();
        maria.AddRecord('grid3', rowIndex);
        maria.CallProc();
        if (maria.isError) {
            maria.ShowErrMsg();
            return;
        }
        ItsButton.EventSearch('insert');
    }
}
ItsGrid.Event('grid2').onButtonClick = function (rowIndex, field) {
    if (field == 'TOP5') {
        var maria = new ItsMaria('SYS0000_R02', 'ADD_TOP5');
        maria.AddSessionUserId();
        maria.AddRecord('grid2', rowIndex);
        maria.CallProc();
        if (maria.isError) {
            maria.ShowErrMsg();
            return;
        }
        ItsButton.EventSearch('update');

    } else if (field == 'DELPRG') {
        var maria = new ItsMaria('SYS0000_R02', 'REMOVE_MYMENU');
        maria.AddSessionUserId();
        maria.AddRecord('grid2', rowIndex);
        maria.CallProc();
        if (maria.isError) {
            maria.ShowErrMsg();
            return;
        }
        ItsButton.EventSearch('delete');
    }
}
ItsButton.Event('MODIFY_PASSWORD').onClick = function () {

    if (fn_pw_check(ItsText.GetValue('pw_new'), ItsText.GetValue('pw_new2'))) {
        var maria = new ItsMaria('WEBSYSLOGIN', 'MODIFY_PASSWORD');
        maria.AddParam('USERPASS', ItsText.GetValue('pw_bf'));
        maria.AddParam('NEWPASS', ItsText.GetValue('pw_new'));
        maria.AddParam('NEWPASS2', ItsText.GetValue('pw_new2'));
        maria.AddSessionUserId();
        maria.CallProc();
        if (maria.isError) {
            maria.ShowErrMsg();
            return;
        } else {
            ItsMsg.Alert("비밀번호가 변경되었습니다.");
        }
    }
}
ItsButton.Event('MODIFY_PLUSKEY').onClick = function () {
    var maria = new ItsMaria('SYS0000_R02', 'MODIFY_PLUSKEY');
    maria.AddParam('PLUSKEYYN', ItsOnoff.GetValue('onoff_PLUSKEYYN'));
    maria.AddSessionUserId();
    maria.CallProc();
    if (maria.isError) {
        maria.ShowErrMsg();
        return;
    } else {
        ItsMsg.Toast("수정 되었습니다.");
        ItsPage.PLUSKEYYN = ItsOnoff.GetValue('onoff_PLUSKEYYN');
        ItsButton.EventSearch('update');
    }
}