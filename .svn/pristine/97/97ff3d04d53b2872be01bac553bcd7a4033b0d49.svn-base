/* TQC1002_R02: 품질관리 - 수입검사관리 - 수입검사등록 */

/// <reference path="../../Script/reference.js" />

/* 페이지 로드 시 수행 */
ItsPage.Load = function () {

    ItsGrid.Create('grid1', { isCheckBoxGrid:false }, [

        
        column.create('스캔일자', 'PRDDATE', { width: 80, align: 'center' }),
        column.create('검사유무', 'TQMCHK', { width: 70, columnType: enumColumnTypes.check }),
        column.create('품목코드', 'ITEMCD', { width: 70, align: 'center' }),
        column.create('품명', 'ITEMNM', { width: 130, align: 'center'}),
        column.create('규격', 'ITEMSPEC', { width: 80, align: 'center' }),
        column.create('로트번호', 'LOTKEY', { width: 110, align: 'center' }),
        column.create('로트수량', 'LOTQTY', { width: 70, columnType: enumColumnTypes.number, decimalPrecision: 0 }),
        column.create('검사키', 'TQMRSTKEY', { width: 80, readOnly: false, hidden: true }),
        column.create('출하키', 'SALOUTKEY', { width: 80, readOnly: false, hidden: true }),
        column.split()
        
    ]);
    
    ItsGrid.Create('grid2', { allowMerging: 'Cells' }, [

        column.create('검사항목', 'STDCD', { width: 80, align: 'center', hidden: true }),
        column.create('검사항목명', 'STDNM', { width: 80, align: 'center' }),
        column.create('검사방법', 'STDCHKTP', { width: 80, align: 'center', columnType: enumColumnTypes.combo, gpcd: 'STDCHKTP' }),
        column.create('값유형', 'STDVALTP', { width: 80, align: 'center', columnType: enumColumnTypes.combo, gpcd: 'STDVALTP' }),
        column.create('기준값1', 'STDVAL1', { width: 70, align: 'center' }),
        column.create('범위', 'STDRANGE', { width: 60, align: 'center', columnType: enumColumnTypes.combo, gpcd: 'STDRANGE' }),
        column.create('기준값2', 'STDVAL2', { width: 70, align: 'center' }),
        column.create('단위', 'STDUNIT', { width: 60, align: 'center' , columnType: enumColumnTypes.combo, gpcd: 'STDUNIT' }),

        column.create('검사값x1', 'STDVALCHK', { width: 80, readOnly: false }),
        column.create('검사값x2', 'STDVALCHK2', { width: 80, readOnly: false }),
        column.create('검사값x3', 'STDVALCHK3', { width: 80, readOnly: false }),
        column.create('검사값x4', 'STDVALCHK4', { width: 80, readOnly: false }),
        column.create('검사값x5', 'STDVALCHK5', { width: 80, readOnly: false }),
        column.create('합격여부', 'OKNG', { width: 90, align: 'center', columnType: enumColumnTypes.combo, gpcd: 'OKNG', readOnly: false }),

        column.split()
    ]);

    ItsDateRange.SetValueFrom('dr_DATE', ItsHelper.AddDay(-7, ItsHelper.GetYearMonthDay()));
    ItsDateRange.SetValueTo('dr_DATE', ItsHelper.GetYearMonthDay());
};

/* 조회 */
ItsButton.EventSearch = function () {
    ItsGrid.Clear('grid2');

    var maria = new ItsMaria('TQM0001_R01', 'LIST_PRDRSTLOT');
    maria.AddPanel('sdiv1');
    maria.CallProc();
    if (maria.isError) {
        maria.ShowErrMsg();
        return;
    }
    ItsGrid.SetStore('grid1', maria.store.YnToBool('TQMCHK'));
    ItsMsg.Toast(ItsMsg.CommonMsg.SearchComplete(maria.store.Length()));
};

// grid1 선택시
ItsGrid.Event('grid1').onSelect = function () {
    var maria = new ItsMaria('TQM0001_R01', 'LIST_TQMRSTKND');

    maria.AddParam('TQMRSTKEY', ItsGrid.GetValue('grid1', ItsGrid.GetCurrentIndex('grid1'), 'TQMRSTKEY'));
    maria.AddParam('ITEMCD', ItsGrid.GetValue('grid1', ItsGrid.GetCurrentIndex('grid1'), 'ITEMCD'));
    maria.CallProc();

    if (maria.isError) {
        maria.ShowErrMsg();
        return;
    }

    ItsGrid.SetStore('grid2', maria.store);

}

// 출하검사 등록
ItsButton.EventSave = function () {
    if (ItsGrid.Length('grid2') > 0) {
        ItsMsg.Confirm("저장하시겠습니까?", function () {
            var maria = new ItsMaria('TQM0001_R01', 'SAVE_TQMRSTKND');
            maria.AddRecord('grid1', ItsGrid.GetCurrentIndex('grid1'));
            for (var i = 0; i < ItsGrid.Length('grid2'); i++) {
                maria.AddList('STDCD_LIST', ItsGrid.GetValue('grid2', i, 'STDCD'));

                maria.AddList('STDNM_LIST', ItsGrid.GetValue('grid2', i, 'STDNM'));
                maria.AddList('STDCHKTP_LIST', ItsGrid.GetValue('grid2', i, 'STDCHKTP'));
                maria.AddList('STDVALTP_LIST', ItsGrid.GetValue('grid2', i, 'STDVALTP'));
                maria.AddList('STDVAL1_LIST', ItsGrid.GetValue('grid2', i, 'STDVAL1'));
                maria.AddList('STDRANGE_LIST', ItsGrid.GetValue('grid2', i, 'STDRANGE'));
                maria.AddList('STDVAL2_LIST', ItsGrid.GetValue('grid2', i, 'STDVAL2'));
                maria.AddList('STDUNIT_LIST', ItsGrid.GetValue('grid2', i, 'STDUNIT'));


                maria.AddList('STDVALCHK_LIST', ItsGrid.GetValue('grid2', i, 'STDVALCHK'));
                maria.AddList('STDVALCHK2_LIST', ItsGrid.GetValue('grid2', i, 'STDVALCHK2'));
                maria.AddList('STDVALCHK3_LIST', ItsGrid.GetValue('grid2', i, 'STDVALCHK3'));
                maria.AddList('STDVALCHK4_LIST', ItsGrid.GetValue('grid2', i, 'STDVALCHK4'));
                maria.AddList('STDVALCHK5_LIST', ItsGrid.GetValue('grid2', i, 'STDVALCHK5'));

                maria.AddList('OKNG_LIST', ItsGrid.GetValue('grid2', i, 'OKNG'));
            }
            maria.CallProc();
            if (maria.isError) {
                maria.ShowErrMsg();
                return;
            }

            ItsGrid.Setkey('grid1', 'LOTKEY', ItsGrid.GetValue('grid1', ItsGrid.GetCurrentIndex('grid1'), 'LOTKEY'));
            ItsButton.EventSearch();
        });
    }    
}
// 출하검사이력 삭제
ItsButton.EventDelete = function () {
    var maria = new ItsMaria('TQM0001_R01', 'DELETE_TQMRST');

    maria.AddParam('TQMRSTKEY', ItsGrid.GetValue('grid1', ItsGrid.GetCurrentIndex('grid1'), 'TQMRSTKEY'));
    maria.AddParam('SALOUTKEY', ItsGrid.GetValue('grid1', ItsGrid.GetCurrentIndex('grid1'), 'SALOUTKEY'));
    maria.CallProc();

    if (maria.isError) {
        maria.ShowErrMsg();
        return;
    }

    ItsButton.EventSearch();
}

//// 자동 합격 불합격 만들기 -> 추후 기준점을 찾고 다시 만들기
//ItsGrid.Event('grid2').onChanged = function (rowindex, field, newValue, oldValue) {
//    if (field == 'STDVALCHK' || field == 'STDVALCHK2' || field == 'STDVALCHK3' || field == 'STDVALCHK4' || field == 'STDVALCHK5') {
//        var STDVAL1 =
//    }