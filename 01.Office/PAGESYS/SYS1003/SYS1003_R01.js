/// <reference path="../../Script/reference.js" />

/* 페이지 로드 시 수행 */
ItsPage.Load = function () {
    /* 그리드 생성 */
    ItsGrid.Create('grid1', {}, [
        column.create("패키지유형", "PKGTP", { hidden: true }),
        column.create("패키지명", "PKGNM", { width: 150 }),
        column.create("코드", "CATECD", { width: 150 }),
        column.create("이름", "CATENM", { width: 200 }),
    ]);
    ItsGrid.Create('grid2', {}, [
        column.create('메뉴이름', 'MENUNM', { width: 300 }),
        column.create('프로그램 코드', 'PRGCD', { width: 120 }),
        column.create('정렬 순서', 'SORTNO', { width: 100 }),
        column.create('비고', 'REMARK', { width: 200 }),
    ])
    ItsButton.EventSearch();
    ItsPage.SetBackColor('ddiv1', enumColor.transparent);
};


/* 조회 */
ItsButton.EventSearch = function () {
    var maria = new ItsMaria('SYS1003_R01', 'LIST_CATEGORY');
    maria.AddParam('PKGTP', ItsCombo.GetValue('cmb_PKGTP'));
    maria.CallProc();
    if (maria.isError) {
        maria.ShowErrMsg();
        return;
    }
    ItsGrid.SetStore('grid1', maria.store);
    ItsGrid.SelectRow('grid1', 0);
    var cnt = maria.store.Length();        // 조회건수
    ItsMsg.Toast(cnt + '건이 조회되었습니다.');
};

/* 콤보박스 선택 */
ItsCombo.Event('cmb_PKGTP').onChanged = function (newValue, oldValue) {
    ItsButton.EventSearch();
}

///* 그리드 선택 */
ItsGrid.Event('grid1').onSelect = function (rowIndex) {
    var maria = new ItsMaria('SYS1003_R01', 'LIST_MENU');
    maria.AddParam('PKGTP', ItsGrid.GetValue('grid1', rowIndex, 'PKGTP'));
    maria.AddParam('CATECD', ItsGrid.GetValue('grid1', rowIndex, 'CATECD'));
    maria.CallProc();
    if (maria.isError) {
        maria.ShowErrMsg();
        return;
    }
    ItsGrid.SetStore('grid2', maria.store);
};

ItsGrid.Event('grid2').onSelect = function (rowIndex) {
    ItsPage.SetStore('ddiv1', ItsGrid.GetRowData('grid2', rowIndex));
    ItsPage.SetBackColor('ddiv1', enumColor.transparent);
    ItsText.Disable('txt_PRGCD');
    ItsOnoff.SetValue('onoff_NEWYN', 'N');
}

/* 추가 */
ItsButton.EventAdd = function () {
    ItsPage.InitData('ddiv1');
    ItsPage.SetBackColor('ddiv1', enumColor.addPanel);
    ItsText.Enable('txt_PRGCD');
    ItsText.Focus('txt_PRGCD');
    ItsOnoff.SetValue('onoff_NEWYN', 'Y');
};

/* 저장 */
ItsButton.EventSave = function () {
    if (ItsOnoff.GetValue('onoff_NEWYN') == "Y") {
        var maria = new ItsMaria('SYS1003_R01', 'ADD_MENU');
        maria.AddParam('PKGTP', ItsGrid.GetValue('grid2', ItsGrid.GetCurrentIndex('grid2'), 'PKGTP'));
        maria.AddParam('CATECD', ItsGrid.GetValue('grid2', ItsGrid.GetCurrentIndex('grid2'), 'CATECD'));
        maria.AddPanel('ddiv1');
        maria.CallProc();
        if (maria.isError) {
            maria.ShowErrMsg();
            return;
        }
        ItsMsg.Toast('저장되었습니다.');
    }
    else {
        var maria = new ItsMaria('SYS1003_R01', 'UPDATE_MENU');
        maria.AddParam('PKGTP', ItsGrid.GetValue('grid2', ItsGrid.GetCurrentIndex('grid2'), 'PKGTP'));
        maria.AddParam('CATECD', ItsGrid.GetValue('grid2', ItsGrid.GetCurrentIndex('grid2'), 'CATECD'));
        maria.AddPanel('ddiv1');
        maria.CallProc();
        if (maria.isError) {
            maria.ShowErrMsg();
            return;
        }
        ItsMsg.Toast('수정되었습니다.');
    }
    ItsButton.EventSearch();

    //if (!ItsGrid.IsSelect('grid1')) {
    //    ItsMsg.Alert('헤더가 선택되지 않았습니다.');
    //    return;
    //}
    //ItsPage.SetBackColor('ddiv1', enumColor.transparent);
    //ItsText.Disable('txt_TPCD2');

};

/* 삭제 */
ItsButton.EventDelete = function () {
    ItsMsg.Confirm('삭제하시겠습니까?', function () {
        var maria = new ItsMaria('SYS1003_R01', 'DEL_MENU');
        maria.AddParam('PKGTP', ItsGrid.GetValue('grid2', ItsGrid.GetCurrentIndex('grid2'), 'PKGTP'));
        maria.AddParam('CATECD', ItsGrid.GetValue('grid2', ItsGrid.GetCurrentIndex('grid2'), 'CATECD'));
        maria.AddPanel('ddiv1');
        maria.CallProc();

        if (maria.isError) {
            maria.ShowErrMsg();
            return;
        }

        ItsButton.EventSearch();
        ItsMsg.Toast("삭제되었습니다.");
    });
};


/* 카테고리 추가 버튼 */
ItsButton.Event('ADD_CATEGORY').onClick = function () {
    ItsPop.Open('pop1');
}

/* 카테고리 등록 버튼 */
ItsButton.Event('SAVE_CATEGORY').onClick = function () {
    var maria = new ItsMaria('SYS1003_R01', 'ADD_CATEGORY');
    maria.AddPanel('pop1');
    maria.CallProc();
    if (maria.isError) {
        maria.ShowErrMsg();
        return;
    }

    ItsButton.EventSearch();
    ItsMsg.Toast('추가되었습니다.');
    ItsPop.Close('pop1');
}

/* 카테고리 삭제 버튼 */
ItsButton.Event('DEL_CATEGORY').onClick = function () {
    ItsMsg.Confirm('삭제하시겠습니까?', function () {
        var maria = new ItsMaria('SYS1003_R01', 'DEL_CATEGORY');
        maria.AddParam('CATECD', ItsGrid.GetValue('grid1', ItsGrid.GetCurrentIndex('grid1'), 'CATECD'));
        maria.CallProc();
        if (maria.isError) {
            maria.ShowErrMsg();
            return;
        }

        ItsButton.EventSearch();
        ItsMsg.Toast("삭제되었습니다.");
    });
}