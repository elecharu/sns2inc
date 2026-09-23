//사원정보
/// <reference path="../../Script/reference.js" />

/* 페이지 로드 시 수행 */
ItsPage.Load = function () {

    ItsGrid.Create('grid_EMPLIST', { isCheckBoxGrid: true }, [
        //column.create('사원아이디', 'EMPID', { width: 90, align: 'center' }),
        column.create('사번', 'EMPCD', { width: 90, align: 'center' }),
        column.create('성명', 'EMPNM', { width: 90, align: 'center' }),
        column.create('사업장코드', 'BDVCD', { width: 120, align: 'center', columnType: enumColumnTypes.combo, gpcd: 'BDVCD' }),
        column.create('공장코드', 'FACTORYCD', { width: 90, align: 'center', columnType: enumColumnTypes.combo, gpcd: 'FACTORYCD' }),
        column.create('부서코드', 'DEPTCD', { width: 90, align: 'center', columnType: enumColumnTypes.combo, gpcd: 'DEPTCD' }),
        column.create('진행상태', 'STATBC', { width: 90, align: 'center', columnType: enumColumnTypes.combo, gpcd: 'HR125' }),
        column.create('근무직구분', 'WORKTP', { width: 90, align: 'center', columnType: enumColumnTypes.combo, gpcd: 'HR160' }),
        column.create('직위구분', 'POSBC', { width: 90, align: 'center', columnType: enumColumnTypes.combo, gpcd: 'HR151' }),
        column.create('직책구분', 'DUTYBC', { width: 90, align: 'center', columnType: enumColumnTypes.combo, gpcd: 'HR150' }),
        column.create('성별구분', 'GENDERTP', { width: 90, align: 'center', columnType: enumColumnTypes.combo, gpcd: 'HR120' }),
        column.create('생년월일', 'BIRTHDT', { width: 90, align: 'center' }),
        column.create('Email', 'EMAIL', { width: 150 }),
        column.create('핸드폰', 'MOBILE', { width: 120, align: 'center', }),
        column.create('부서전화', 'DEPTTEL', { width: 90, align: 'center',}),
        column.create('구사번', 'OLDEMPCD', { width: 90, align: 'center',}),
        column.create('퇴사일', 'LEAVEDATE', { width: 90, align: 'center', }),
        column.create('사원유형', 'EMPTP', { width: 90, align: 'center' }),
        column.split()
    ]);
};

/* 초기화 */
ItsButton.EventInit = function () {
    ItsPage.InitData('sdiv1');
    ItsGrid.Clear('grid_EMPLIST');
};

/* 조회 */
ItsButton.EventSearch = function () {
    var maria = new ItsMaria('MST0001_R07', 'LIST_EMP');
    maria.AddPanel('sdiv1');
    maria.CallProc();
    if (maria.isError) {
        maria.ShowErrMsg();
        return;
    }

    ItsGrid.SetStore('grid_EMPLIST', maria.store);

    ItsMsg.Toast(ItsMsg.CommonMsg.SearchComplete(maria.store.Length()));
}