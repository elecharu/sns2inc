/// <reference path="../../Script/reference.js" />

// 2026-10-14 [설비부품 발주관리] 페이지 초기 로드 및 발주헤더·상세 그리드 정의 (MTR0001_R01 기반)
ItsPage.Load = function () {

    // 2026-10-14 [발주헤더 목록] 좌측 발주헤더 그리드 생성 (설비부품 포함 발주헤더 대상)
    ItsGrid.Create('grid1', {}, [
        column.create('발주일자', 'MTRODRDATE', { width: 90, align: 'center' }),
        column.create('발주번호', 'MTRODRKEY', { width: 100, align: 'center' }),
        column.create('발주상태', 'MTRODRSTT', { width: 80, align: 'center', columnType: enumColumnTypes.combo, gpcd: 'MM110' }),
        column.create('거래처코드', 'CUSTCD', { width: 100, align: 'center', hidden: true }),
        column.create('거래처명', 'CUSTNM', { width: 150, align: 'center' }),
        column.create('납기일자', 'EXPDATE', { width: 100, align: 'center' }),
        column.create('구매담당자', 'ODREMPID', { width: 80, align: 'center' }),
    ]);

    // 2026-10-14 [발주상세 목록] 우측 발주상세 그리드 생성 (MTR0001_R01 컬럼 구성 기반)
    ItsGrid.Create('grid2', {}, [
        column.create('발주순번', 'MTRODRSEQ', { width: 50, align: 'center', hidden: true }),
        column.create('발주상태', 'MTRODRSTT', { width: 100, align: 'center', columnType: enumColumnTypes.combo, gpcd: 'MM110' }),
        column.create('품목유형', 'ITEMCG', { width: 100, align: 'center', columnType: enumColumnTypes.combo, gpcd: 'DM100' }),
        column.create('품목코드', 'ITEMCD', { width: 200, align: 'center' }),
        column.create('품명', 'ITEMNM', { width: 250, align: 'center' }),
        column.create('규격', 'ITEMSPEC', { width: 200, align: 'center' }),
        column.create('납기일자', 'EXPDATE', { width: 100, align: 'center' }),
        column.create('구매담당자', 'ODRDELEMPID', { width: 100, align: 'center', hidden: true }),
        column.create('발주수량', 'ODRQTY', { width: 80, columnType: enumColumnTypes.number }),
        column.create('구매단가', 'MTRODRPRICE', { width: 80, columnType: enumColumnTypes.number }),
        column.create('구매금액', 'MTRODRAMT', { width: 80, columnType: enumColumnTypes.number }),
        column.create('발주단가', 'MTRODRFPRICE', { width: 80, columnType: enumColumnTypes.number }),
        column.create('발주금액', 'MTRODRFAMT', { width: 80, columnType: enumColumnTypes.number })
    ]);

    ItsDateRange.SetInitValueFrom('date_DATE', ItsHelper.AddDay(-7, ItsHelper.GetYearMonthDay()));

    // 2026-10-14 [설비부품 발주관리] 법인 고정(60) 및 공장 "INC 2공장(07)" 디폴트 설정
    ItsCombo.SetValue('sdiv1_combo_COMPANYCD', '60');
    ItsCombo.SetRef01('sdiv1_combo_FACTORYCD', '60');
    ItsCombo.SetValueByIndex('sdiv1_combo_FACTORYCD', 2);
    ItsCombo.SetValue('sdiv1_combo_FACTORYCD', '07');
};

// 2026-10-14 [설비부품 발주관리] 설비부품이 포함된 발주헤더 목록 조회
ItsButton.EventSearch = function () {

    ItsGrid.Clear('grid2');

    var maria = new ItsMaria('MTR0001_R04', 'LIST_MTRODR');
    maria.AddPanel('sdiv1');
    maria.CallProc();
    if (maria.isError) {
        maria.ShowErrMsg();
        return;
    }

    ItsGrid.SetStore('grid1', maria.store);
    ItsMsg.Toast(ItsMsg.CommonMsg.SearchComplete(maria.store.Length()));
};

// 2026-10-14 [설비부품 발주관리] 선택된 발주헤더의 설비부품 상세 목록 조회
ItsGrid.Event('grid1').onSelect = function (rowIndex) {

    if (rowIndex < 0) return;

    var maria = new ItsMaria('MTR0001_R04', 'LIST_MTRODRD');
    maria.AddPanel('sdiv1');
    maria.AddRecord('grid1', rowIndex);
    maria.CallProc();
    if (maria.isError) {
        maria.ShowErrMsg();
        return;
    }

    ItsGrid.SetStore('grid2', maria.store);
    ItsGrid.Get('grid1').autoSizeColumns();
    ItsGrid.Get('grid2').autoSizeColumns();
};

// 2026-10-14 [설비부품 발주관리] 법인 선택 시 공장 연동 (INC 2공장(07) 디폴트)
ItsCombo.Event('sdiv1_combo_COMPANYCD').onChanged = function (value) {
    ItsCombo.SetRef01('sdiv1_combo_FACTORYCD', value);
    ItsCombo.SetValueByIndex('sdiv1_combo_FACTORYCD', 2);
    ItsCombo.SetValue('sdiv1_combo_FACTORYCD', '07');
};

// 2026-10-14 [상단 검색영역] 선택된 발주헤더의 설비부품 발주서 PDF 리포트(S04A) 팝업 출력
ItsButton.Event('btn_PRINT').onClick = function () {

    var rowIndex = ItsGrid.GetCurrentIndex('grid1');
    if (rowIndex < 0) {
        ItsMsg.Toast('출력할 발주를 선택해주세요.');
        return;
    }

    var mtrOdrKey = ItsGrid.GetValue('grid1', rowIndex, 'MTRODRKEY');
    if (!mtrOdrKey) {
        ItsMsg.Toast('출력할 발주를 선택해주세요.');
        return;
    }

    var rpt = new ItsXtraRpt('MTR0001_S04A');
    rpt.AddParam('MTRODRKEY', mtrOdrKey);
    rpt.CallPop();

    if (rpt.isError) {
        ItsMsg.Alert(rpt.errMessage);
    }
};
