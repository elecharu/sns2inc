/// <reference path="../../Script/reference.js" />

/* 페이지 로드 시 수행 */
ItsPage.Load = function () {
    
    /* 그리드 생성 */
    ItsGrid.Create('grid1', { isCheckBoxGrid: false }, [
        column.create("품목분류", "ITEMCG", { width: 100, align: 'center', columnType: enumColumnTypes.combo, gpcd: 'DM100' }),
        column.create("법인", "COMPANYCD", { width: 100, align: 'center' }),
        column.create("대분류", "ITEM_LVL1", { width: 100, align: 'center', /*columnType: enumColumnTypes.combo, gpcd: 'P100'*/ }),
        column.create("중분류", "ITEM_LVL2", { width: 100, align: 'center', /*columnType: enumColumnTypes.combo, gpcd: 'P110'*/ }),
        column.create("소분류", "ITEM_LVL3", { width: 100, align: 'center', /*columnType: enumColumnTypes.combo, gpcd: 'P120'*/ }),
        column.create("세분류", "ITEM_LVL4", { width: 100, align: 'center', columnType: enumColumnTypes.combo, gpcd: 'PP310' }),
        column.create("품목ID", "ITEMID", { width: 100, align: 'center' }),
        column.create("품목코드", "ITEMCD", { width: 100, align: 'center', backColor: enumColor.greenLight2 }),
        column.create("품명", "ITEMNM", { width: 100 }),
        column.create("규격", "ITEMSPEC", { width: 100 }),
        column.create("관리단위", "ITEMUNIT", { width: 100, align: 'center', columnType: enumColumnTypes.combo, gpcd: 'DM150' }),
        column.create("공급구분", "ITEMSRC", { width: 100, align: 'center', columnType: enumColumnTypes.combo, gpcd: 'DM160' }),
        column.create("종료여부", "ENDYN", { width: 100, align: 'center', columnType: enumColumnTypes.check }),
        column.create("종료처리자ID", "ENDUSEID", { width: 100, align: 'center' }),
        column.create("종료사유구분", "ENDREASON", { width: 100, align: 'center', columnType: enumColumnTypes.combo, gpcd: 'DM180' }),

        column.create("차종코드", "MODELCD", { width: 100, align: 'center' }),
        column.create("색상코드", "COLORCD", { width: 100, align: 'center' }),
        column.create("MY코드", "MYCD", { width: 100, align: 'center' }),        
        column.create("품목약칭", "ITEMBNM", { width: 100, align: 'center' }),
        column.create("주요원자재ID", "MAINPARTID", { width: 100, align: 'center' }),
        column.create("대표품목ID", "MAINITEMID", { width: 100, align: 'center' }),
        column.create("전환상품ID", "TRANGOODSID", { width: 100, align: 'center' }),
        column.create("제품ID", "PAIRID", { width: 100, align: 'center' }),
        column.create("제품코드", "PAIRCD", { width: 100, align: 'center' }),               
        
        column.create("적용시작일", "VALID_FROM_DT", { width: 100, align: 'center' }),
        column.create("적용종료일", "VALID_TO_DT", { width: 100, align: 'center' }),

        column.create("검사수준구분", "INSPEC", { width: 100, align: 'center' }),
        column.create("생산계획그룹", "PRDPLANGROUP", { width: 100, align: 'center' }),
        column.create("구품목코드", "ITEMOLDCD", { width: 100, align: 'center' }),
        column.create("BAR CODE", "BARCD", { width: 100, align: 'center' }),
        column.create("등급", "GRADE", { width: 100, align: 'center' }),
        column.create("콤비품번", "CBITEMNO", { width: 100, align: 'center' }),
        column.create("콤비여부", "CBYN", { width: 100, align: 'center' }),
        column.create("세분류", "ITEM_LVL5", { width: 100, align: 'center' }),
        column.create("Part No (Lapping)", "PARTNO", { width: 100, align: 'center' }),
        column.create("Initial No (Lapping)", "INITCD", { width: 100, align: 'center' }),
        column.create("수불미관리여부", "IOYN", { width: 100, align: 'center', columnType: enumColumnTypes.check  }),
        column.create("Separate여부", "SEPAYN", { width: 100, align: 'center', columnType: enumColumnTypes.check  }),
        column.create("원산지", "NAT_CD", { width: 100, align: 'center' }),
        column.create("HS코드", "HS_CD", { width: 100, align: 'center' }),
        column.create("REVISION", "REV", { width: 100, align: 'center' }),
        column.create("도면번호", "EONO", { width: 100, align: 'center' }),
        column.create("Section DWG No", "SECT_NO", { width: 100, align: 'center' }),
        column.create("도면발행일자", "EODT", { width: 100, align: 'center' }),
        column.create("도면Size구분", "EOSIZE", { width: 100, align: 'center' }),
        column.create("도면매수", "EOQTY", { width: 100, align: 'center' }),
        column.create("단위중량", "ITWEIGHT", { width: 100, align: 'center' }),
        column.create("강종", "ITMAT", { width: 100, align: 'center' }),
        column.create("길이", "ITLENGTH", { width: 100, align: 'center' }),
        column.create("직경", "SIZE_UNIT", { width: 100, align: 'center' }),
        column.create("두께", "DUKE", { width: 100, align: 'center' }),
        column.create("폭", "POK", { width: 100, align: 'center' }),
        column.create("재질", "SPEC2", { width: 100, align: 'center' }),
        column.create("S/T", "ST", { width: 100, align: 'center' }),
        column.create("C/T", "CT", { width: 100, align: 'center' }),
        column.create("조달일수", "TRANDAY", { width: 100, align: 'center' }),
        column.create("설계중량", "SPEC1", { width: 100, align: 'center' }),
        column.create("T", "SPEC3", { width: 100, align: 'center' }),
        column.create("Size", "SPEC4", { width: 100, align: 'center' }),
        column.create("유형", "SPEC5", { width: 100, align: 'center' }),
        column.create("강종", "SPEC6", { width: 100 }),
        column.create("가로(mm)", "SPEC7", { width: 100, align: 'center' }),
        column.create("세로(mm)", "SPEC8", { width: 100, align: 'center' }),
        column.create("높이(mm)", "SPEC9", { width: 100, align: 'center' }),
        column.create("규격10", "SPEC10", { width: 100, align: 'center' }),
        column.create("OEM", "SPEC11", { width: 100, align: 'center' }),
        column.create("A/S", "SPEC12", { width: 100, align: 'center' }),
        column.create("규격13", "SPEC13", { width: 100, align: 'center' }),
        column.create("규격14", "SPEC14", { width: 100, align: 'center' }),
        column.create("규격15", "SPEC15", { width: 100, align: 'center' }),
        column.create("A/S", "SPEC16", { width: 100, align: 'center' }),
        column.create("규격17", "SPEC17", { width: 100, align: 'center' }),
        column.create("규격18", "SPEC18", { width: 100, align: 'center' }),
        column.create("규격19", "SPEC19", { width: 100, align: 'center' }),
        column.create("규격20", "SPEC20", { width: 100, align: 'center' }),
        column.create("보관기한(일)", "EXPDAY", { width: 100, align: 'center' }),
        column.create("기준 BOX 내 수량", "BOXQTY", { width: 100, align: 'center' }),
        column.create("Link 품목코드", "LINK_ID", { width: 100, align: 'center' }),
        column.create("원가품목ID", "WONGA_ID", { width: 100, align: 'center' }),
        column.create("양산이관일", "PRODUCT_DT", { width: 100, align: 'center' }),
        column.create("PT적입수/단수", "PACK_QTY", { width: 100, align: 'center' }),
        column.create("적재단수", "PACK_LAY", { width: 100, align: 'center' }),
        column.create("부서코드", "DEPT_CD", { width: 100, align: 'center' }),
        column.create("개발자ID", "DEV_RID", { width: 100, align: 'center' }),
        column.create("비고", "REMARK", { width: 100, align: 'center' }),
        column.create("등록자", "REMP", { width: 100, align: 'center' }),
        column.create("등록일시", "RTIME", { width: 100, align: 'center' })
    ]);
};

/* 조회 */
ItsButton.EventSearch = function () {

    var maria = new ItsMaria('MST1003_R04', 'SEL_ITEM');
    maria.AddPanel('sdiv1');
    maria.CallProc();
    if (maria.isError) {
        maria.ShowErrMsg();
        return;
    }

    ItsGrid.SetStore('grid1', maria.store.YnToBool('IOYN').YnToBool('SEPAYN').YnToBool('ENDYN'));
    ItsMsg.Toast(maria.store.Length() + '건이 조회되었습니다.');

    ItsGrid.Get('grid1').autoSizeColumns();
};

ItsCombo.Event('sdiv1_combo_ITEMCG').onChanged = function (value) {
    ItsFind.SetRef02('sdiv1_find_ITEMID', value);
}









