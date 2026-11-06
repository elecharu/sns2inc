/// <reference path="../../Script/reference.js" />

/* MST3001_R06: 외주처 소모품 수령확정 (현장 TML1030_R02 불출 → TML1030_R03 수령 → 여기서 확정) */

ItsPage.Load = function () {
    ItsGrid.Create('grid1', { isCheckBoxGrid: true }, [
        column.create("불출일자", "RELEASEDATE", { width: 90, align: 'center' }),
        column.create("불출라인", "EQMNM", { width: 140 }),
        column.create("총수량", "TOTQTY", { width: 70, align: 'right', format: '#,##0' }),
        column.create("불출자", "EMPNM_RELEASE", { width: 80, align: 'center' }),
        column.create("수령자", "EMPNM_RECIEVE", { width: 80, align: 'center' }),
        column.create("수령일자", "RECIEVEDATE", { width: 90, align: 'center' }),
        column.create("확정자", "EMPNM_CONFIRM", { width: 80, align: 'center' }),
        column.create("확정일자", "CONFIRMDATE", { width: 90, align: 'center' }),
    ]);

    ItsGrid.Create('grid2', {}, [
        column.create("소모품ID", "ITEMID", { width: 80, align: 'center' }),
        column.create("소모품코드", "ITEMCD", { width: 120, align: 'center' }),
        column.create("소모품명", "ITEMNM", { width: 160 }),
        column.create("규격", "ITEMSPEC", { width: 140 }),
        column.create("불출수량", "RELQTY", { width: 80, align: 'right', format: '#,##0' }),
        column.create("수령수량", "RECQTY", { width: 80, align: 'right', format: '#,##0' }),
    ]);
};

/* 불출증 조회 (불출일자, 라인) */
ItsButton.EventSearch = function () {
    var maria = new ItsMaria('MST3001_R06', 'SEL_RELEASE');
    maria.AddPanel('sdiv1');
    maria.CallProc();
    if (maria.isError) {
        maria.ShowErrMsg();
        return;
    }

    ItsGrid.SetStore('grid1', maria.store);
    if (maria.store.Length() === 0) {
        ItsGrid.Clear('grid2');   // 0건이면 onSelect 가 안 불려 상세가 남으므로 직접 비움
    }
    ItsMsg.Toast(ItsMsg.CommonMsg.SearchComplete(maria.store.Length()));
};

/* 불출증 선택 → 상세 조회 */
ItsGrid.Event('grid1').onSelect = function (rowIndex) {
    var maria = new ItsMaria('MST3001_R06', 'SEL_RELEASE_DETAIL');
    maria.AddParam('RELEASEKEY', ItsGrid.GetValue('grid1', rowIndex, 'RELEASEKEY'));
    maria.CallProc();
    if (maria.isError) {
        maria.ShowErrMsg();
        return;
    }
    ItsGrid.SetStore('grid2', maria.store);
};

/* [수령확정] → 체크한 불출증 검사 후 확정일자·확정자 팝업 */
ItsButton.Event('btn_CONFIRM').onClick = function () {
    var cnt = 0;
    for (var i = 0; i < ItsGrid.Length('grid1'); i++) {
        if (!ItsGrid.IsChecked('grid1', i)) continue;

        var row = ItsGrid.GetRowData('grid1', i);
        if (row.RECIEVEYN != 'Y') {
            ItsMsg.Alert('[' + row.RELEASEDATE + ' ' + row.EQMNM + '] 수령 전 불출증은 확정할 수 없습니다.');
            return;
        }
        if (row.CONFIRMYN == 'Y') {
            ItsMsg.Alert('[' + row.RELEASEDATE + ' ' + row.EQMNM + '] 이미 수령확정된 불출증입니다.');
            return;
        }
        cnt++;
    }
    if (cnt == 0) {
        ItsMsg.Alert('수령확정할 불출증을 체크하십시오.');
        return;
    }

    ItsDate.SetValue('pop1_date_CONFIRMDATE', ItsHelper.GetYearMonthDay());
    ItsFind.SetValue('pop1_find_EMPCD_CONFIRM', ItsPage.EMPCD);
    $('#pop1').height(170);   // Type="add" 팝업은 열 때마다 45px 씩 커지는 라이브러리 버그가 있어 되돌림
    ItsPop.Open('pop1');
};

/* 팝업 [수령확정] → 확정한 불출증 출력 */
ItsPop.Event('pop1').onAddBtnClick = function () {
    var keys = [];
    var maria = new ItsMaria('MST3001_R06', 'CONFIRM');
    maria.AddPanel('pdiv1');
    for (var i = 0; i < ItsGrid.Length('grid1'); i++) {
        if (ItsGrid.IsChecked('grid1', i)) {
            maria.AddList('RELEASEKEY_LIST', ItsGrid.GetValue('grid1', i, 'RELEASEKEY'));
            keys.push(ItsGrid.GetValue('grid1', i, 'RELEASEKEY'));
        }
    }
    maria.CallProc();
    if (maria.isError) {
        maria.ShowErrMsg();
        return;
    }
    ItsMsg.Toast('수령확정 되었습니다.');
    ItsPop.Close('pop1');
    ItsButton.EventSearch();

    PrintRelease(keys);
};

/* 툴바 [인쇄] → 체크한 불출증 재출력 */
ItsButton.EventPrint = function () {
    var keys = [];
    for (var i = 0; i < ItsGrid.Length('grid1'); i++) {
        if (ItsGrid.IsChecked('grid1', i)) {
            keys.push(ItsGrid.GetValue('grid1', i, 'RELEASEKEY'));
        }
    }
    if (keys.length == 0) {
        ItsMsg.Alert('출력할 불출증을 체크하십시오.');
        return;
    }

    PrintRelease(keys);
};

/* 공구불출증 출력 (04.Report\PAGEMST\MST3001 R06A, 여러 건은 한 PDF 에 불출증마다 새 페이지) */
function PrintRelease(keys) {
    var rpt = new ItsXtraRpt('MST3001_R06A');
    rpt.AddParam('RELEASEKEY_LIST', keys.join(','));
    rpt.CallPop();
    if (rpt.isError) {
        ItsMsg.Alert(rpt.errMessage);
    }
}

ItsPop.Event('pop1').onCancelBtnClick = function () {
    ItsPop.Close('pop1');
};

/* [확정취소] → 체크한 불출증의 확정일자·확정자 비움 */
ItsButton.Event('btn_CANCEL').onClick = function () {
    var cnt = 0;
    for (var i = 0; i < ItsGrid.Length('grid1'); i++) {
        if (!ItsGrid.IsChecked('grid1', i)) continue;

        var row = ItsGrid.GetRowData('grid1', i);
        if (row.CONFIRMYN != 'Y') {
            ItsMsg.Alert('[' + row.RELEASEDATE + ' ' + row.EQMNM + '] 수령확정되지 않은 불출증입니다.');
            return;
        }
        cnt++;
    }
    if (cnt == 0) {
        ItsMsg.Alert('확정취소할 불출증을 체크하십시오.');
        return;
    }

    ItsMsg.Confirm(cnt + '건 수령확정을 취소하시겠습니까?', function () {
        var maria = new ItsMaria('MST3001_R06', 'CANCEL_CONFIRM');
        for (var i = 0; i < ItsGrid.Length('grid1'); i++) {
            if (ItsGrid.IsChecked('grid1', i)) {
                maria.AddList('RELEASEKEY_LIST', ItsGrid.GetValue('grid1', i, 'RELEASEKEY'));
            }
        }
        maria.CallProc();
        if (maria.isError) {
            maria.ShowErrMsg();
            return;
        }
        ItsMsg.Toast('확정취소 되었습니다.');
        ItsButton.EventSearch();
    });
};
