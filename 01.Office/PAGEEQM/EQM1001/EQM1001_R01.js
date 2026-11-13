/// <reference path="../../Script/reference.js" />

// 2026-10-06 [메인 그리드] 수리이력 그리드의 수리유형과 작업자 찾기 표시
ItsPage.Load = function () {

    ItsGrid.Create('grid1', { isCheckBoxGrid: true, isSubTotalGrid: true }, [
        column.create('등록일자', 'REGDAY', { width: 100, align: 'center', columnType: enumColumnTypes.date, readOnly: false }),
        column.create('등록일시', 'REGTIME', { width: 90, align: 'center', readOnly: false, mask: "00:00" }),
        column.create('발생일자', 'REPSDAY', { width: 100, align: 'center', readOnly: false, columnType: enumColumnTypes.date }),
        column.create('발생일시', 'REPSTIME', { width: 90, align: 'center', readOnly: false, mask: "00:00" }),
        column.create('완료일자', 'REPEDAY', { width: 100, align: 'center', readOnly: false, columnType: enumColumnTypes.date }),
        column.create('완료일시', 'REPETIME', { width: 90, align: 'center', readOnly: false, mask: "00:00" }),
        column.create('소요일', 'REPUTIME', { width: 80, columnType: enumColumnTypes.number, decimalPrecision: 0 }),
        column.create('공장', 'FACTORYCD', { width: 100, align: 'center', columnType: enumColumnTypes.combo, gpcd: 'FACTORYCD', readOnly: true }),
        column.create('작업장', 'LINECD', { width: 80, align: 'center', columnType: enumColumnTypes.combo, gpcd: 'LINECD', readOnly: true }),
        column.create('설비구분', 'EQMTP', { width: 80, align: 'center', columnType: enumColumnTypes.combo, gpcd: 'FM100', readOnly: true }),
        column.create('설비대분류', 'EQMGROUP1', { width: 80, align: 'center', columnType: enumColumnTypes.combo, gpcd: 'FM113', readOnly: true }),
        column.create('설비코드', 'EQMCD', { width: 110, readOnly: true }),
        column.create('설비명', 'EQMNM', { width: 180, readOnly: true }),
        column.create('금액(만원)', 'REPAMT', { width: 80, columnType: enumColumnTypes.number, readOnly: false, groupType: enumGrouping.sum }),
        column.create('수리업체', 'REPCUST', { width: 120, readOnly: false }),
        column.create('수리유형', 'ISSUE', { width: 100, columnType: enumColumnTypes.combo, gpcd: 'ISSUE', readOnly: false }),
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

    // 2026-11-09 [수리 사진] 썸네일 클릭 시 미리보기 변경, [✕] 클릭 시 사진 삭제
    $('#div_REPIMG_LIST').on('click', '.repimg-thumb', function () {
        REPIMG_SELECT(parseInt($(this).attr('data-index'), 10));
    });
    $('#div_REPIMG_LIST').on('click', '.repimg-del', function (e) {
        e.stopPropagation();
        REPIMG_DELETE($(this).attr('data-filekey'));
    });
    REPIMG_LIST('');
};

// 공장 변경 시 작업장·설비구분·설비대분류 콤보 갱신
ItsCombo.Event('cmb_FACTORYCD').onChanged = function (value) {
    ItsCombo.SetRef01('cmb_LINECD', value || '');
    ItsCombo.SetRef10('cmb_EQMTP', value || '');
    ItsCombo.SetRef10('cmb_EQMGROUP1', value || '');
};

/* 조회 */
ItsButton.EventSearch = function () {
    ItsGrid.Clear('grid2');
    REPIMG_LIST('');
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
// 2026-11-09 선택한 수리이력의 사진 목록도 함께 조회
ItsGrid.Event('grid1').onSelect = function () {
    var eqmRepKey = ItsGrid.GetValue('grid1', ItsGrid.GetCurrentIndex('grid1'), 'EQMREPKEY');
    ItsGrid.Clear('grid2');
    REPIMG_LIST(eqmRepKey);
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

        // 2026-11-09 삭제할 수리이력의 사진 파일키를 먼저 모아 두고, 이력 삭제 후 파일도 삭제
        var arrFileKey = [];
        var maria = new ItsMaria('EQM1001_R01', 'DELETE_EQMREP');
        for (var i = 0; i < ItsGrid.Length('grid1'); i++) {
            if (ItsGrid.IsChecked('grid1', i)) {
                maria.AddList('EQMREPKEY_LIST', ItsGrid.GetValue('grid1', i, 'EQMREPKEY'));
                arrFileKey = arrFileKey.concat(GetRepImgList(ItsGrid.GetValue('grid1', i, 'EQMREPKEY')).map(function (img) { return img.FILEKEY; }));
            }
        }
        maria.CallProc();
        if (maria.isError) {
            maria.ShowErrMsg();
            return;
        }
        ItsFileManager.Clear('file_REPIMG');
        arrFileKey.forEach(function (fileKey) {
            ItsFileManager.Delete('file_REPIMG', fileKey);
        });

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

// 2026-11-09 [수리 사진] 사진 목록·선택 상태, 업로드 대상 수리이력 키 (업로드 중 다른 이력을 선택해도 처음 이력에 등록)
var repImgList = [];
var repImgUploadKey = '';

// 2026-11-09 [수리 사진] 수리이력의 등록 사진 조회
function GetRepImgList(eqmRepKey) {
    if (!eqmRepKey) {
        return [];
    }
    var maria = new ItsMaria('EQM1001_R01', 'LIST_EQMREP_IMG');
    maria.AddParam('EQMREPKEY', eqmRepKey);
    maria.CallProc();
    if (maria.isError) {
        maria.ShowErrMsg();
        return [];
    }
    return maria.store.data;
}

// 2026-11-09 [수리 사진] 썸네일 목록 표시 후 지정 사진(없으면 첫 사진) 미리보기
function REPIMG_LIST(eqmRepKey, selectFileKey) {
    repImgList = GetRepImgList(eqmRepKey);
    var selectIndex = 0;
    var html = '';
    repImgList.forEach(function (img, i) {
        if (img.FILEKEY == selectFileKey) {
            selectIndex = i;
        }
        html += '<div class="repimg-thumb" data-index="' + i + '"><img src="' + img.FILEURL + '" />'
              + '<span class="repimg-del" data-filekey="' + img.FILEKEY + '" title="사진 삭제">✕</span></div>';
    });
    $('#div_REPIMG_LIST').html(html);
    $('#spn_REPIMG_EMPTY').text(eqmRepKey ? '등록된 사진이 없습니다. [사진 등록]으로 추가하세요.' : '수리이력을 선택하면 사진이 표시됩니다.');
    ItsLabel.SetText('lbl_REPIMG', '■ 수리 사진 (' + repImgList.length + ')');
    REPIMG_SELECT(repImgList.length > 0 ? selectIndex : -1);
}

// 2026-11-09 [수리 사진] 선택 사진 미리보기·썸네일 강조·순번 표시 (사진이 없으면 기본 이미지 대신 안내 문구)
function REPIMG_SELECT(index) {
    $('#div_REPIMG_LIST .repimg-thumb').removeClass('on');
    if (index < 0 || index >= repImgList.length) {
        ItsImage.Clear('img_REPIMG');
        $('#spn_REPIMG_PAGE').hide();
        $('#spn_REPIMG_EMPTY').parent().addClass('empty');
        return;
    }
    $('#spn_REPIMG_EMPTY').parent().removeClass('empty');
    $('#div_REPIMG_LIST .repimg-thumb[data-index="' + index + '"]').addClass('on');
    ItsImage.SetImage('img_REPIMG', repImgList[index].FILEURL, repImgList[index].FILEKEY);
    $('#spn_REPIMG_PAGE').text((index + 1) + ' / ' + repImgList.length).show();
}

// 2026-11-09 [수리 사진] 사진 등록 → 공통 파일선택(이미지) 열기
ItsButton.Event('btn_REPIMG_ADD').onClick = function () {
    repImgUploadKey = ItsGrid.GetValue('grid1', ItsGrid.GetCurrentIndex('grid1'), 'EQMREPKEY');
    if (!repImgUploadKey) {
        ItsMsg.Toast('수리이력을 선택해주세요.');
        return;
    }
    ItsFileManager.Clear('file_REPIMG');
    document.getElementById('file_REPIMGex_filename').click();
};

// 2026-11-09 [수리 사진] 사진 선택 즉시 업로드
ItsFileManager.Event('file_REPIMG').onFileChange = function (id) {
    if (document.getElementById(id + 'ex_filename').files.length < 1) {
        return;
    }
    ItsFileManager.Upload(id);
};

// 2026-11-09 [수리 사진] 업로드한 파일키를 수리이력에 등록, 등록 실패 시 업로드 파일 삭제
ItsFileManager.Event('file_REPIMG').onUpload = function (id, fileKey) {
    ItsFileManager.Clear(id);
    var maria = new ItsMaria('EQM1001_R01', 'ADD_EQMREP_IMG');
    maria.AddParam('EQMREPKEY', repImgUploadKey);
    maria.AddParam('FILEKEY', fileKey);
    maria.CallProc();
    if (maria.isError) {
        maria.ShowErrMsg();
        ItsFileManager.Delete(id, fileKey);
        return;
    }
    ItsMsg.Toast(ItsMsg.CommonMsg.SaveComplete());
    if (repImgUploadKey == ItsGrid.GetValue('grid1', ItsGrid.GetCurrentIndex('grid1'), 'EQMREPKEY')) {
        REPIMG_LIST(repImgUploadKey, fileKey);
    }
};

// 2026-11-09 [수리 사진] 사진 삭제 (등록 삭제 후 파일 삭제)
function REPIMG_DELETE(fileKey) {
    var eqmRepKey = ItsGrid.GetValue('grid1', ItsGrid.GetCurrentIndex('grid1'), 'EQMREPKEY');
    if (!eqmRepKey || !fileKey) {
        return;
    }
    ItsMsg.Confirm('사진을 삭제하시겠습니까?', function () {
        var maria = new ItsMaria('EQM1001_R01', 'DELETE_EQMREP_IMG');
        maria.AddParam('EQMREPKEY', eqmRepKey);
        maria.AddParam('FILEKEY', fileKey);
        maria.CallProc();
        if (maria.isError) {
            maria.ShowErrMsg();
            return;
        }
        ItsFileManager.Clear('file_REPIMG');
        ItsFileManager.Delete('file_REPIMG', fileKey);
        ItsMsg.Toast(ItsMsg.CommonMsg.DeleteComplete());
        REPIMG_LIST(eqmRepKey);
    });
}

// 2026-11-09 [수리 사진] 미리보기 클릭 → 크게 보기 팝업
ItsImage.Event('img_REPIMG').onClick = function (url, key) {
    if (!key) {
        return;
    }
    ItsImage.SetImage('big_img_REPIMG', url, key);
    ItsPop.Open('pop_REPIMG');
};
