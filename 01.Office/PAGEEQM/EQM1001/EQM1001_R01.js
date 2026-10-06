/// <reference path="../../Script/reference.js" />

// 2026-10-06 수리이력 그리드의 고장원인구분과 작업자 찾기 표시
ItsPage.Load = function () {

    ItsGrid.Create('grid1', { isCheckBoxGrid: true, isSubTotalGrid: true }, [
        column.create('등록일자', 'REGDAY', { width: 90, align: 'center', columnType: enumColumnTypes.date, readOnly: false }),
        column.create('등록일시', 'REGTIME', { width: 90, align: 'center', readOnly: false, mask: "00:00" }),
        column.create('발생일자', 'REPSDAY', { width: 90, align: 'center', readOnly: false, columnType: enumColumnTypes.date }),
        column.create('발생일시', 'REPSTIME', { width: 90, align: 'center', readOnly: false, mask: "00:00" }),
        column.create('완료일자', 'REPEDAY', { width: 90, align: 'center', readOnly: false, columnType: enumColumnTypes.date }),
        column.create('완료일시', 'REPETIME', { width: 90, align: 'center', readOnly: false, mask: "00:00" }),
        column.create('소요일', 'REPUTIME', { width: 80, columnType: enumColumnTypes.number, decimalPrecision: 0 }),
        column.create('설비코드', 'EQMCD', { width: 120, readOnly: true }),
        column.create('설비명', 'EQMNM', { width: 180, readOnly: true }),
        column.create('금액(만원)', 'REPAMT', { width: 80, columnType: enumColumnTypes.number, readOnly: false, groupType: enumGrouping.sum }),
        column.create('수리업체', 'REPCUST', { width: 120, readOnly: false }),
        column.create('고장원인구분', 'ISSUE', { width: 100, columnType: enumColumnTypes.combo, gpcd: 'ISSUE', readOnly: false }),
        column.create('고장원인', 'MALFUNCTION', { width: 230, readOnly: false, multiLine: true }),
        column.create('처리내용', 'HANDLE', { width: 230, readOnly: false, multiLine: true }),
        column.create('비고', 'REMARK', { width: 230, readOnly: false, multiLine: true }),
        column.create('설비수리키', 'EQMREPKEY', { width: 100, hidden: true }),
        column.split()
    ]);


    ItsGrid.Create('grid2', { isCheckBoxGrid: true }, [
        column.create('설비수리키', 'EQMREPKEY', { width: 100, hidden: true }),
        column.create('사번', 'EMPCD', { width: 80, columnType: enumColumnTypes.find, gpcd: 'EMPCD', readOnly: true }),
        column.create('사원명', 'EMPNM', { width: 150 }),

    ]);

    ItsGrid.Create('grid3', { isCheckBoxGrid: true }, [
        column.create('사번', 'EMPCD', { width: 80, columnType: enumColumnTypes.find, gpcd: 'EMPCD', readOnly: false }),
        column.create('사원명', 'EMPNM', { width: 150 }),

    ]);

    // 그리드 Row 높이 자동설정
    ItsGrid.Get('grid1').autoRowHeights = true;
    ItsDateRange.SetInitValueFrom('date_SEARCH', ItsHelper.AddDay(-7, ItsHelper.GetYearMonthDay()));
};

/* 조회 */
ItsButton.EventSearch = function () {
    ItsGrid.Clear('grid2');
    var maria = new ItsMaria('EQM1001_R01', 'LIST_EQMREP');
    maria.AddPanel('sdiv1');
    maria.CallProc();
    if (maria.isError) {
        maria.ShowErrMsg();
        return;
    }


    ItsGrid.SetStore('grid1', maria.store);
    ItsMsg.Toast(ItsMsg.CommonMsg.SearchComplete(maria.store.Length()));
};

// 2026-10-06 수리이력 선택이 없으면 작업자 목록 초기화
ItsGrid.Event('grid1').onSelect = function () {
    var eqmRepKey = ItsGrid.GetValue('grid1', ItsGrid.GetCurrentIndex('grid1'), 'EQMREPKEY');
    ItsGrid.Clear('grid2');
    if (!eqmRepKey) {
        return;
    }

    var maria = new ItsMaria('EQM1001_R01', 'LIST_EMPCD');
    maria.AddParam('EQMREPKEY', eqmRepKey);
    maria.CallProc();

    if (maria.isError) {
        maria.ShowErrMsg();
        return;
    }

    ItsGrid.SetStore('grid2', maria.store);


}

// 2026-10-06 수리이력 등록 팝업의 완료일시 초기화
ItsButton.EventAdd = function () {
    ItsPage.InitData('pdiv1');
    ItsGrid.Clear('grid3');
    ItsCheck.Event('pop1_check_REPEYN').onChanged(false);
    ItsPop.Open('pop1');
};

/* 팝업 행추가 */
ItsButton.Event('pdiv2_btn_ADD').onClick = function () {
    ItsGrid.AddRow('grid3', 0);
};

/* 팝업 행삭제 */
ItsButton.Event('pdiv2_btn_DEL').onClick = function () {

    var RowCount = ItsGrid.Length('grid3');

    for (var i = RowCount - 1; i >= 0; i--) {
        if (ItsGrid.IsChecked('grid3', i)) {
            ItsGrid.RemoveRow('grid3', i);

        }
    }
};

/* 팝업 그리드팝업 */
ItsGrid.Event('grid3').onDoubleClick = function (rowIndex, field) {
    ItsGrid.Event('grid3').onKeydownEnter(rowIndex, field);
};

ItsGrid.Event('grid3').onKeydownEnter = function (rowIndex, field) {

    if (field == 'EMPCD') {

        ItsPop.OpenFindCOM({ gpcd: 'EMPCD' }, function (res) {
            for (var i = 0; i < ItsGrid.Length('grid3'); i++) {

                if (i != rowIndex && ItsGrid.GetValue('grid3', i, 'EMPCD') == res['CODE']) {
                    ItsMsg.Alert(res['NAME'] + '는 추가되어 있는 사원입니다.')
                    return;
                }
            }
            ItsGrid.SetValue('grid3', rowIndex, 'EMPCD', res['CODE']);
            ItsGrid.SetValue('grid3', rowIndex, 'EMPNM', res['NAME']);
            ItsGrid.CheckRow('grid3', rowIndex);

        })

    };
}
// 2026-10-06 수리이력 날짜의 월 경계와 미완료 소요일 계산
function GetRepDays(start, end) {
    if (!start || !end) {
        return 0;
    }
    var arrStart = start.split('-');
    var arrEnd = end.split('-');
    var startDay = Date.UTC(+arrStart[0], +arrStart[1] - 1, +arrStart[2]);
    var endDay = Date.UTC(+arrEnd[0], +arrEnd[1] - 1, +arrEnd[2]);
    var days = (endDay - startDay) / 86400000 + 1;
    return isNaN(days) ? 0 : Math.max(days, 0);
}

// 2026-10-06 등록 팝업의 완료일시 사용 여부 반영
ItsCheck.Event('pop1_check_REPEYN').onChanged = function (newValue) {
    if (newValue === true || newValue === 'Y') {
        ItsDate.Enable('pop1_date_REPEDAY');
        ItsText.Enable('pop1_txt_REPETIME');
        ItsDate.SetValue('pop1_date_REPEDAY', ItsHelper.GetYearMonthDay());
        ItsDate.Event('pop1_date_REPEDAY').onChanged();
    } else {
        ItsDate.SetValue('pop1_date_REPEDAY', '');
        ItsDate.Disable('pop1_date_REPEDAY');
        ItsText.SetValue('pop1_txt_REPETIME', '');
        ItsText.Disable('pop1_txt_REPETIME');
        ItsNum.SetValue('pop1_num_REPUTIME', 0);
    }
};

// 2026-10-06 등록 팝업의 발생일자 변경 시 소요일 표시
ItsDate.Event('pop1_date_REPSDAY').onChanged = function () {
    ItsNum.SetValue('pop1_num_REPUTIME', GetRepDays(ItsDate.GetValue('pop1_date_REPSDAY'), ItsDate.GetValue('pop1_date_REPEDAY')));
};

// 2026-10-06 등록 팝업의 완료일자 변경 시 소요일 표시
ItsDate.Event('pop1_date_REPEDAY').onChanged = function () {
    ItsDate.Event('pop1_date_REPSDAY').onChanged();
};

// 2026-10-06 등록 팝업의 작업자 목록을 프로시저 검증에 전달
ItsPop.Event('pop1').onAddBtnClick = function () {
    var RowCount = ItsGrid.Length('grid3');


    var maria = new ItsMaria('EQM1001_R01', 'ADD_EQMREP');
    maria.AddPanel('pdiv1');

    for (var i = 0; i < RowCount; i++) {
        if (ItsGrid.IsChecked('grid3', i)) {
            maria.AddList('EMPCD_LIST', ItsGrid.GetValue('grid3', i, 'EMPCD'));
        }
    }

    maria.CallProc();

    if (maria.isError) {
        maria.ShowErrMsg();
        return;
    } else {
        ItsPop.Event('pop1').onCancelBtnClick();
        ItsMsg.Toast(ItsMsg.CommonMsg.AddComplete);
        ItsButton.EventSearch();
    }
}

// 팝업창 창닫기
ItsPop.Event('pop1').onCancelBtnClick = function () {
    ItsPage.InitData('pdiv1');
    ItsPop.Close('pop1');
}

// 2026-10-06 수리이력 그리드의 발생·완료일 변경 시 소요일 표시
ItsGrid.Event('grid1').onChanged = function (rowIndex, field) {
    if (field == 'REPSDAY' || field == 'REPEDAY') {
        ItsGrid.SetValue('grid1', rowIndex, 'REPUTIME', GetRepDays(
            ItsGrid.GetValue('grid1', rowIndex, 'REPSDAY'), ItsGrid.GetValue('grid1', rowIndex, 'REPEDAY')));
    }
};

// 2026-10-06 수리이력 그리드의 설비 변경
ItsGrid.Event('grid1').onKeydownEnter = function (rowIndex, field) {
    if (field == 'EQMCD') {
        ItsPop.OpenFindCOM({ gpcd: 'EQMCD', }, function (res) {
            if (ItsGrid.GetValue('grid1', rowIndex, 'EQMCD') == res['CODE']) {
                ItsMsg.Alert(res['CODE'] + '는 추가되어 있는 설비입니다.')
                return;
            }
            ItsGrid.SetValue('grid1', rowIndex, 'EQMCD', res['CODE']);
            ItsGrid.SetValue('grid1', rowIndex, 'EQMNM', res['NAME']);
            ItsGrid.CheckRow('grid1', rowIndex);
        })
    }

};

ItsGrid.Event('grid1').onDoubleClick = function (rowIndex, field) {
    ItsGrid.Event('grid1').onKeydownEnter(rowIndex, field);
}

// 2026-10-06 수리이력 저장에서 부품 미사용 항목 제외
ItsButton.EventSave = function () {
    ItsGrid.Get('grid1').finishEditing();
    var hasChecked = false;
    for (var i = 0; i < ItsGrid.Length('grid1'); i++) {
        if (ItsGrid.IsChecked('grid1', i)) {
            hasChecked = true;
            break;
        }
    }

    if (!hasChecked) {
        ItsMsg.Toast('선택된 항목이 없습니다.');
        return;
    }

    ItsMsg.Confirm('선택하신 설비이력을 저장하시겠습니까?', function () {

        var maria = new ItsMaria('EQM1001_R01', 'SAVE_EQMREP');

        for (var i = 0; i < ItsGrid.Length('grid1'); i++) {
            if (ItsGrid.IsChecked('grid1', i)) {

                maria.AddList('EQMREPKEY_LIST', ItsGrid.GetValue('grid1', i, 'EQMREPKEY'));
                maria.AddList('REGDAY_LIST', ItsGrid.GetValue('grid1', i, 'REGDAY'));
                maria.AddList('REGTIME_LIST', ItsGrid.GetValue('grid1', i, 'REGTIME'));
                maria.AddList('REPSDAY_LIST', ItsGrid.GetValue('grid1', i, 'REPSDAY'));
                maria.AddList('REPSTIME_LIST', ItsGrid.GetValue('grid1', i, 'REPSTIME'));
                maria.AddList('REPEDAY_LIST', ItsGrid.GetValue('grid1', i, 'REPEDAY'));
                maria.AddList('REPETIME_LIST', ItsGrid.GetValue('grid1', i, 'REPETIME'));
                maria.AddList('REPUTIME_LIST', ItsGrid.GetValue('grid1', i, 'REPUTIME'));
                maria.AddList('EQMCD_LIST', ItsGrid.GetValue('grid1', i, 'EQMCD'));
                maria.AddList('REPAMT_LIST', ItsGrid.GetValue('grid1', i, 'REPAMT'));
                maria.AddList('REPCUST_LIST', ItsGrid.GetValue('grid1', i, 'REPCUST'));
                maria.AddList('ISSUE_LIST', ItsGrid.GetValue('grid1', i, 'ISSUE'));
                maria.AddList('MALFUNCTION_LIST', ItsGrid.GetValue('grid1', i, 'MALFUNCTION'));
                maria.AddList('HANDLE_LIST', ItsGrid.GetValue('grid1', i, 'HANDLE'));
                maria.AddList('REMARK_LIST', ItsGrid.GetValue('grid1', i, 'REMARK'));

            }
        }
        maria.CallProc();
        if (maria.isError) {
            maria.ShowErrMsg();
            return;
        }
        ItsMsg.Toast(ItsMsg.CommonMsg.SaveComplete());
        ItsButton.EventSearch();
    },

        function () {
            ItsMsg.Toast('수정이 취소되었습니다.');
            return;
        }

    )
}

/* 메인 삭제 이벤트*/
ItsButton.EventDelete = function () {
    var hasChecked = false;
    for (var i = 0; i < ItsGrid.Length('grid1'); i++) {
        if (ItsGrid.IsChecked('grid1', i)) {
            hasChecked = true;
            break;
        }
    }

    if (!hasChecked) {
        ItsMsg.Toast('선택된 항목이 없습니다.');
        return;
    }
    ItsMsg.Confirm("선택한 항목을 삭제하시겠습니까?", function () {

        var maria = new ItsMaria('EQM1001_R01', 'DELETE_EQMREP');
        for (var i = 0; i < ItsGrid.Length('grid1'); i++) {
            if (ItsGrid.IsChecked('grid1', i)) {
                maria.AddList('EQMREPKEY_LIST', ItsGrid.GetValue('grid1', i, 'EQMREPKEY'));

            }
        }
        maria.CallProc();
        if (maria.isError) {
            maria.ShowErrMsg();
            return;
        }

        ItsMsg.Toast(ItsMsg.CommonMsg.DeleteComplete());
        ItsButton.EventSearch();

    },
        function () {
            ItsMsg.Toast('삭제가 취소되었습니다.');
            return;
        }


    )
}

// 2026-10-06 선택한 수리이력에 작업자 입력 행 추가
ItsButton.Event('bdiv2_btn_ADD').onClick = function () {

    var EQMREPKEY = ItsGrid.GetValue('grid1', ItsGrid.GetCurrentIndex('grid1'), 'EQMREPKEY');
    if (EQMREPKEY == null) {
        return;
    }

    var rowIndex = ItsGrid.Length('grid2');
    ItsGrid.AddRow('grid2', rowIndex, { EQMREPKEY: EQMREPKEY, EMPCD: '', EMPNM: '', isRowCheck: true });
};

// 2026-10-06 작업자 목록의 신규 행에 사원 선택 후 저장·재조회
ItsGrid.Event('grid2').onDoubleClick = function (rowIndex, field) {
    ItsGrid.Event('grid2').onKeydownEnter(rowIndex, field);
};
ItsGrid.Event('grid2').onKeydownEnter = function (rowIndex, field) {
    var eqmRepKey = ItsGrid.GetValue('grid1', ItsGrid.GetCurrentIndex('grid1'), 'EQMREPKEY');
    if (field != 'EMPCD' || !eqmRepKey || ItsGrid.GetValue('grid2', rowIndex, 'EMPCD')) {
        return;
    }
    ItsPop.OpenFindCOM({ gpcd: 'EMPCD' }, function (res) {
        var maria = new ItsMaria('EQM1001_R01', 'SAVE_EMPCD');
        maria.AddParam('EQMREPKEY', eqmRepKey);
        maria.AddParam('EMPCD', res['CODE']);
        maria.CallProc();
        if (maria.isError) {
            maria.ShowErrMsg();
            return;
        }
        ItsGrid.Event('grid1').onSelect();
        ItsMsg.Toast(ItsMsg.CommonMsg.SaveComplete());
    });
};

// 2026-10-06 작업자 목록의 미저장 행은 화면에서 삭제
ItsButton.Event('bdiv2_btn_DEL').onClick = function () {
    for (var i = ItsGrid.Length('grid2') - 1; i >= 0; i--) {
        if (ItsGrid.IsChecked('grid2', i) && !ItsGrid.GetValue('grid2', i, 'EMPCD')) {
            ItsGrid.RemoveRow('grid2', i);
        }
    }
    var checkedCount = 0;
    var totalCount = ItsGrid.Length('grid2');

    for (var i = 0; i < totalCount; i++) {
        if (ItsGrid.IsChecked('grid2', i)) {
            checkedCount++;
        }
    }

    if (checkedCount === 0) {
        ItsMsg.Toast('선택된 사원이 없습니다.');
        return;
    }

    if (checkedCount === totalCount) {
        ItsMsg.Toast('모든 사원을 삭제할 수 없습니다.');
        return;
    }

    ItsMsg.Confirm("선택한 항목을 삭제하시겠습니까?", function () {

        var maria = new ItsMaria('EQM1001_R01', 'DELETE_EMPCD');
        maria.AddParam('EQMREPKEY', ItsGrid.GetValue('grid1', ItsGrid.GetCurrentIndex('grid1'), 'EQMREPKEY'));
        for (var i = 0; i < ItsGrid.Length('grid2'); i++) {
            if (ItsGrid.IsChecked('grid2', i)) {
                maria.AddList('EMPCD_LIST', ItsGrid.GetValue('grid2', i, 'EMPCD'));
            }
        }

        maria.CallProc();
        if (maria.isError) {
            maria.ShowErrMsg();
            return;
        }
        ItsMsg.Toast(ItsMsg.CommonMsg.DeleteComplete());
        ItsGrid.Setkey('grid1', 'EQMREPKEY', ItsGrid.GetValue('grid1', ItsGrid.GetCurrentIndex('grid1'), 'EQMREPKEY'));
        ItsButton.EventSearch();

    },
        function () {
            ItsMsg.Toast('삭제가 취소되었습니다.');
            return;
        }
    )
};

