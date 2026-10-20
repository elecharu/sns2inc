/// <reference path="../../Script/reference.js" />
/* 페이지 로드 시 수행 */
ItsPage.Load = function () {

    /* 그리드 생성 */
    // 공정검사 그룹
    ItsGrid.Create('grid1', { isCheckBoxGrid: true }, [
        column.create("검사구분", "STDTP", { width: 100, columnType: enumColumnTypes.combo, gpcd: 'STDTP', ref01:'Y' , readOnly: false, align: 'center', }),
        column.create("검사항목코드", "STDCD", { width: 100, hidden: true }),
        column.create("검사항목", "STDNM", { width: 200, readOnly: false }),
        column.create("검사방법", "STDCHKTP", { width: 100, columnType: enumColumnTypes.combo, gpcd: 'STDCHKTP', readOnly: false, align: 'center' }),
        column.create("측정기기", "STDMACHINE", { width: 100, columnType: enumColumnTypes.combo, gpcd: 'STDMACHINE', align: 'center', readOnly: false }),
        column.create("측정부위", "STDPOINT", { width: 100, columnType: enumColumnTypes.combo, gpcd: 'STDPOINT', readOnly: false, align: 'center' }),
        column.create("검사주기", "STDCYCLE", { width: 100, columnType: enumColumnTypes.combo, gpcd: 'STDCYCLE', readOnly: false, align: 'center' }),
        column.band('판정기준', {}, [
            column.create("단위", "STDUNIT", { width: 60, columnType: enumColumnTypes.combo, gpcd: 'STDUNIT', readOnly: false, align: 'center' }),
            column.create('범위', 'STDRANGE', { width: 60, columnType: enumColumnTypes.combo, gpcd: 'STDRANGE', readOnly: false }),
            column.create('판정기준', 'STDJUDGE', { width: 300, readOnly: false, multiLine: true }),
        ]),

        column.create("비고", "REMARK", { width: 100, readOnly: false }),

        column.split()
    ]);

    // 그리드 Row 높이 자동설정
    ItsGrid.Get('grid1').autoRowHeights = true;
    ItsButton.Hide('btn_COPY')
};

/* 조회 */
ItsButton.EventSearch = function () {
    var maria = new ItsMaria('TQC1001_R01 ', 'LIST_MSTSTD');

    maria.AddPanel('sdiv1');

    maria.CallProc();

    if (maria.isError) {
        maria.ShowErrMsg();
        return;
    }

    ItsButton.Show('btn_COPY')
    ItsGrid.SetStore('grid1', maria.store);
    //ItsGrid.Get('grid1').autoSizeColumns();

    ItsMsg.Toast(maria.store.Length() + '건이 조회되었습니다.');

 
};
/*********************************************************************************************************************************************************************************/
///* 추가 */
ItsButton.EventAdd = function () {
    ItsPage.InitData('pdiv1');
    ItsPop.Open('pop_ADD_MSTSTD');
}

// 그리드내에서 검사방법이 육안이면 범위를 선택할 수 없도록
ItsGrid.Event('grid1').onChanged = function (rowIndex, field) {
    const currentIndex = ItsGrid.GetCurrentIndex('grid1');
    const STDCHKTP = ItsGrid.GetValue('grid1', currentIndex, 'STDCHKTP');
    const STDRANGE = ItsGrid.GetValue('grid1', currentIndex, 'STDRANGE');

    if (STDCHKTP === '01') {
        ItsGrid.SetValue('grid1', currentIndex, 'STDRANGE', '');
    }
}

// 검사방법이 측정일때 
ItsCombo.Event('cmb_STDCHKTP_ADD').onChanged = function () {
    if (ItsCombo.GetValue('cmb_STDCHKTP_ADD') == '02') {
        ItsCombo.Enable('cmb_STDRANGE_ADD');
       
    }
    else {

        ItsCombo.Disable('cmb_STDRANGE_ADD');
        ItsCombo.SetValue('cmb_STDRANGE_ADD', ' ');
    }
};
////팝업 저장버튼 이벤트
ItsPop.Event('pop_ADD_MSTSTD').onAddBtnClick = function () {


    var maria = new ItsMaria('TQC1001_R01', 'ADD_MSTSTD');
    maria.AddPanel('pdiv1');

    maria.CallProc();
    if (maria.isError) {
        maria.ShowErrMsg();
        return;
    }
    ItsMsg.Toast(ItsMsg.CommonMsg.AddComplete);

    ItsPop.Close('pop_ADD_MSTSTD');
    ItsButton.EventSearch();

}


ItsPop.Event('pop_ADD_MSTSTD').onCancelBtnClick = function () {
    ItsPop.Close('pop_ADD_MSTSTD');
}

/*********************************************************************************************************************************************************************************/
/* 저장 */
ItsButton.EventSave = function () {
    var maria = new ItsMaria('TQC1001_R01', 'UPDATE_MSTSTD');
    var hasChecked = false;

    for (var i = 0; i < ItsGrid.Length('grid1'); i++) {
        if (ItsGrid.IsChecked('grid1', i)) {
            hasChecked = true;
            maria.AddList('STDTP_LIST', ItsGrid.GetValue('grid1', i, 'STDTP'));
            maria.AddList('STDCD_LIST', ItsGrid.GetValue('grid1', i, 'STDCD'));
            maria.AddList('STDNM_LIST', ItsGrid.GetValue('grid1', i, 'STDNM'));
            maria.AddList('STDCHKTP_LIST', ItsGrid.GetValue('grid1', i, 'STDCHKTP'));
            maria.AddList('STDMACHINE_LIST', ItsGrid.GetValue('grid1', i, 'STDMACHINE'));
            maria.AddList('STDPOINT_LIST', ItsGrid.GetValue('grid1', i, 'STDPOINT'));
            maria.AddList('STDCYCLE_LIST', ItsGrid.GetValue('grid1', i, 'STDCYCLE'));
            maria.AddList('STDUNIT_LIST', ItsGrid.GetValue('grid1', i, 'STDUNIT'));
            maria.AddList('STDRANGE_LIST', ItsGrid.GetValue('grid1', i, 'STDRANGE'));
            maria.AddList('STDJUDGE_LIST', ItsGrid.GetValue('grid1', i, 'STDJUDGE'));
            maria.AddList('REMARK_LIST', ItsGrid.GetValue('grid1', i, 'REMARK'));
        }
    }


    if (!hasChecked) {
        ItsMsg.Alert("저장할 항목을 선택하세요.");
        return;
    }

    ItsMsg.Confirm("선택항목을 저장하시겠습니까?", function () {

        maria.CallProc();

        if (maria.isError) {
            maria.ShowErrMsg();
            return;
        }

        ItsMsg.Toast(ItsMsg.CommonMsg.SaveComplete());
        ItsButton.EventSearch();
    });
};
/*********************************************************************************************************************************************************************************/
/* 삭제 */
ItsButton.EventDelete = function () {
    var maria = new ItsMaria('TQC1001_R01', 'DELETE_MSTSTD');
    var hasChecked = false;

    for (var i = 0; i < ItsGrid.Length('grid1'); i++) {
        if (ItsGrid.IsChecked('grid1', i)) {
            hasChecked = true;
            maria.AddList('STDCD_LIST', ItsGrid.GetValue('grid1', i, 'STDCD'));
        }
    }
    
    if (!hasChecked) {
        ItsMsg.Alert("삭제할 검사항목을 선택하세요.");
        return;
    }

    ItsMsg.Confirm("선택항목을 삭제하시겠습니까?", function () {

        maria.CallProc();

        if (maria.isError) {
            maria.ShowErrMsg();
            return;
        }

        ItsMsg.Toast(ItsMsg.CommonMsg.DeleteComplete());
        ItsButton.EventSearch();
    });
};
/*********************************************************************************************************************************************************************************/
/* 복사 */
ItsButton.Event('btn_COPY').onClick = function () {

    ItsMsg.Confirm("선택항목을 복사하시겠습니까?",
        function () {

            var maria = new ItsMaria('TQC1001_R01', 'COPY_MSTSTD');
            for (var i = 0; i < ItsGrid.Length('grid1'); i++) {
                if (ItsGrid.IsChecked('grid1', i)) {
                    maria.AddList('STDTP_LIST', ItsGrid.GetValue('grid1', i, 'STDTP'))
                    //maria.AddList('STDCD_LIST', ItsGrid.GetValue('grid1', i, 'STDCD'))
                    maria.AddList('STDNM_LIST', ItsGrid.GetValue('grid1', i, 'STDNM'))
                    maria.AddList('STDCHKTP_LIST', ItsGrid.GetValue('grid1', i, 'STDCHKTP'))
                    maria.AddList('STDMACHINE_LIST', ItsGrid.GetValue('grid1', i, 'STDMACHINE'))
                    maria.AddList('STDPOINT_LIST', ItsGrid.GetValue('grid1', i, 'STDPOINT'))
                    maria.AddList('STDCYCLE_LIST', ItsGrid.GetValue('grid1', i, 'STDCYCLE'))
                    maria.AddList('STDUNIT_LIST', ItsGrid.GetValue('grid1', i, 'STDUNIT'))
                    maria.AddList('STDRANGE_LIST', ItsGrid.GetValue('grid1', i, 'STDRANGE'))
                    maria.AddList('STDJUDGE_LIST', ItsGrid.GetValue('grid1', i, 'STDJUDGE'))
                    maria.AddList('REMARK_LIST', ItsGrid.GetValue('grid1', i, 'REMARK'))
                }

            }
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