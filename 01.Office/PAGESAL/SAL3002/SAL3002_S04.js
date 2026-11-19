/* SAL3002_S04: 영업관리 ▶ 출하실적조회 (출하 LOT 별) */
/* 판매계획대비 출하실적조회(SAL3002_S02) 세부내역 탭을 품목별로 묶지 않고 출하 LOT 별로 펼친 화면. 금액·계획 칸은 없다 */
/* 기간 = 출하일자. 범위(2공장 사업장 수주, 품목 공장 06/07, 1공장은 맨 아래)는 S02 와 같다 */
/* 조회조건 구분(수출/내수)·고객사·품목은 비우면 전체. 총계는 그리드 자동 합계(isSubTotalGrid + groupType sum) */

/// <reference path="../../Script/reference.js" />

/* 페이지 로드 */
ItsPage.Load = function () {
    // 이번 달 1일 ~ 오늘이 기본
    ItsDateRange.SetInitValueFrom('dr_DATE', ItsHelper.GetYearMonth() + '-01');

    // 구분·고객사 칸만 위아래 같은 값끼리 병합 (S02 세부내역과 같은 모양)
    // 그리드 아래 합계 줄에 출하수량 총계
    ItsGrid.Create('grid1', { isCheckBoxGrid: false, isSubTotalGrid: true, allowMerging: 'Cells' }, [
        column.create('출하일자', 'SALOUTDATE', { width: 90, align: 'center' }),
        column.create('구분', 'DEBCNM', { width: 90, align: 'center', allowMerging: true }),
        column.create('고객사', 'CUSTNM', { width: 200, allowMerging: true }),
        column.create('품명', 'ITEMNM', { width: 250 }),
        column.create('품번', 'ITEMCD', { width: 120 }),                
        column.create('HEAT NO', 'HEATNO', { width: 110, align: 'center' }),
        column.create('로트번호', 'LOTKEY', { width: 150, align: 'center' }),
        column.create('출하수량(EA)', 'OUTQTY', { width: 90, columnType: enumColumnTypes.number, decimalPrecision: 0, groupType: enumGrouping.sum }),
        column.create('거래처코드', 'CUSTCD', { width: 80, hidden: true }),
        column.create('품목ID', 'ITEMID', { width: 70, hidden: true }),
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

/* 판매계획대비 출하실적조회(SAL3002_S02) 세부내역 [상세조회] 버튼으로 열렸을 때
   param = { SMONTH(YYYY-MM), DEBC, CUSTCD, ITEMID } → 조회조건에 넣고 바로 조회
   (새로 열릴 때도, 이미 열린 탭으로 이동할 때도 불린다) */
ItsPage.onReceiveParam = function (param) {
    if (param == undefined || param.SMONTH == undefined) return;

    // 조회년월 → 그 달 1일 ~ 말일
    var year = Number(param.SMONTH.substring(0, 4));
    var month = Number(param.SMONTH.substring(5, 7));
    var lastDay = new Date(year, month, 0).getDate();
    ItsDateRange.SetValueFrom('dr_DATE', param.SMONTH + '-01', false);
    ItsDateRange.SetValueTo('dr_DATE', param.SMONTH + '-' + (lastDay < 10 ? '0' : '') + lastDay, false);

    ItsCombo.SetValue('cmb_DEBC', param.DEBC || '', false);
    ItsFind.SetValue('find_CUSTCD', param.CUSTCD || '', false);
    ItsFind.SetValue('find_ITEMID', param.ITEMID || '', false);

    ItsButton.EventSearch();
};

/* 조회 */
ItsButton.EventSearch = function () {
    var maria = new ItsMaria('SAL3002_S04', 'LIST');
    maria.AddPanel('sdiv1');
    maria.CallProc();
    if (maria.isError) {
        maria.ShowErrMsg();
        return;
    }

    ItsGrid.SetStore('grid1', maria.store);
    ItsMsg.Toast(ItsMsg.CommonMsg.SearchComplete(maria.store.Length()));
};
