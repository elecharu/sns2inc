/* SAL4001_S01: 영업관리 ▶ 고객사 반품이력 조회 */
/* 현장 제품 반입등록(TML6001_R01)이 저장한 출하반품(COMOUT OUTTP 20) 을 반입 1건 한 줄로 보여준다 */
/* 기간 = 반입일자. 고객사·품목은 비우면 전체. 총계는 그리드 자동 합계(isSubTotalGrid + groupType sum) */

/// <reference path="../../Script/reference.js" />

/* 페이지 로드 */
ItsPage.Load = function () {
    // 이번 달 1일 ~ 오늘이 기본
    ItsDateRange.SetInitValueFrom('dr_DATE', ItsHelper.GetYearMonth() + '-01');

    ItsGrid.Create('grid1', { isCheckBoxGrid: false, isSubTotalGrid: true }, [
        column.create('반입일자', 'RTNDATE', { width: 90, align: 'center' }),
        column.create('고객사', 'CUSTNM', { width: 200 }),
        column.create('품번', 'ITEMCD', { width: 120 }),
        column.create('품명', 'ITEMNM', { width: 250 }),
        column.create('규격', 'ITEMSPEC', { width: 120 }),
        column.create('반입구분', 'RTNTPNM', { width: 90, align: 'center' }),
        column.create('로트번호', 'LOTKEY', { width: 150, align: 'center' }),
        column.create('HEAT NO', 'HEATNO', { width: 110, align: 'center' }),
        column.create('반입수량(EA)', 'RTNQTY', { width: 90, columnType: enumColumnTypes.number, decimalPrecision: 0, groupType: enumGrouping.sum }),
        column.create('원출하일자', 'SALOUTDATE', { width: 90, align: 'center' }),
        column.create('반입창고', 'WARENM', { width: 120 }),
        column.create('현재고(EA)', 'LOTQTY', { width: 80, columnType: enumColumnTypes.number, decimalPrecision: 0 }),
        column.create('비고', 'REMARK', { width: 200 }),
        column.create('등록자', 'EMPNM', { width: 80, align: 'center' }),
        column.create('등록시각', 'RTIME', { width: 120, align: 'center' }),
        column.band('부적합 판정', {}, [   // 반입 뒤 등록된 부적합 판정(TQMJUDGE)
            column.create('판정유형', 'JUDGETP', { width: 75, align: 'center', columnType: enumColumnTypes.combo, gpcd: 'JUDGETP' }),
            column.create('판정수량(EA)', 'JUDGEQTY', { width: 85, columnType: enumColumnTypes.number, decimalPrecision: 0 })
        ]),
        column.create('거래처코드', 'CUSTCD', { width: 80, hidden: true }),
        column.create('품목ID', 'ITEMID', { width: 70, hidden: true }),
        column.create('출고키', 'OUTKEY', { width: 100, hidden: true }),
        column.split()
    ]);

    ItsCombo.SetValue('cmb_FACTORYCD', '07');   // 공장 기본값 (onChanged 로 품목 find 법인·공장도 들어감)
};

/* 공장이 정해지면 품목 find 에 법인(REF01)·공장(REF03) 넣기. 법인코드는 공장 콤보 목록 줄의 REF01(DC_COMBO FACTORYCD) */
ItsCombo.Event('cmb_FACTORYCD').onChanged = function (value) {
    var companycd = $('#cmb_FACTORYCD').siblings('ul').children('li').filter('[data-value="' + value + '"]').attr('data-ref01');
    if (companycd == undefined || companycd == 'undefined') companycd = '';
    ItsFind.SetRef01('find_ITEMID', companycd);
    ItsFind.SetRef03('find_ITEMID', value);
};

/* 조회 */
ItsButton.EventSearch = function () {
    var maria = new ItsMaria('SAL4001_S01', 'LIST');
    maria.AddPanel('sdiv1');
    maria.CallProc();
    if (maria.isError) {
        maria.ShowErrMsg();
        return;
    }

    ItsGrid.SetStore('grid1', maria.store);
    ItsGrid.Get('grid1').autoSizeColumns();   // 조회한 내용에 맞춰 컬럼 너비 조정
    ItsMsg.Toast(ItsMsg.CommonMsg.SearchComplete(maria.store.Length()));
};
