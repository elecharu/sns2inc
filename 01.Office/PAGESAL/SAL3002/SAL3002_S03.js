/* SAL3002_S03: 영업관리 ▶ 재고 입출고 조회 (일일 마감) */
/* 양식: 생산관리팀 "일일 마감 (2공장 - 외부 재고출고나 이동이력 조회)". 2공장과 외부(1공장, 외주처, 고객사) 사이의 입출고 이력 */
/* 구분: 사업장이동(1->2, 2->1), 외주반출, 외주재작업반출, 외주이동, 외주입고, 출하이동 (프로시저 SAL3002_S03 주석 참고) */

/// <reference path="../../Script/reference.js" />

/* 페이지 로드 */
ItsPage.Load = function () {
    // 하루치 조회가 기본
    ItsDateRange.SetInitValueFrom('dr_DATE', ItsHelper.GetYearMonthDay());
    ItsDateRange.SetInitValueTo('dr_DATE', ItsHelper.GetYearMonthDay());

    ItsGrid.Create('grid1', { isCheckBoxGrid: false, isSubTotalGrid: false }, [
        column.create('구분', 'GUBUN', { width: 110, align: 'center' }),
        column.create('일자', 'IODATE', { width: 90, align: 'center' }),
        column.create('거래처명', 'CUSTNM', { width: 180 }),
        column.create('명세서번호', 'DOCNO', { width: 130, align: 'center' }),
        column.create('품목코드', 'ITEMCD', { width: 140 }),
        column.create('품목명', 'ITEMNM', { width: 350 }),
        column.create('규격', 'ITEMSPEC', { width: 180 }),
        column.create('수량', 'QTY', { width: 90, columnType: enumColumnTypes.number, decimalPrecision: 0 }),
        column.create('로트번호', 'LOTKEY', { width: 140, hidden: true }),
        column.split()
    ]);
};

/* 조회 */
ItsButton.EventSearch = function () {
    var maria = new ItsMaria('SAL3002_S03', 'LIST');
    maria.AddPanel('sdiv1');
    maria.CallProc();
    if (maria.isError) {
        maria.ShowErrMsg();
        return;
    }

    ItsGrid.SetStore('grid1', maria.store);
    ItsMsg.Toast(ItsMsg.CommonMsg.SearchComplete(maria.store.Length()));
};

/* 인쇄: 조회기간으로 리포트(SAL3002.exe S03, 일일 마감 양식)를 출력 (뷰어 팝업 없이 CallPop) */
ItsButton.EventPrint = function () {
    if (ItsGrid.Length('grid1') == 0) {
        ItsMsg.Alert('먼저 조회하세요.');
        return;
    }

    var rpt = new ItsXtraRpt('SAL3002_S03');
    rpt.AddParam('SDATE', ItsDateRange.GetValueFrom('dr_DATE'));
    rpt.AddParam('EDATE', ItsDateRange.GetValueTo('dr_DATE'));
    rpt.CallPop();
    if (rpt.isError) {
        ItsMsg.Alert(rpt.errMessage);
    }
};
