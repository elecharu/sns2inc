/// <reference path="../../Script/reference.js" />
ItsPage.Load = function () {
    ItsGrid.Create('grid1', {  }, [
        column.create('사용자ID', 'USERID', { width: 90 }),
        column.create('사원번호', 'EMPCD', { width: 80, align: 'center' }),
        column.create('사용자명', 'EMPNM', { width: 100 }),
        column.create('부서', 'DEPNM', { width: 120 }),
        column.create('IP', 'IP', { width: 110, align: 'center' }),
        column.create('모바일', 'MOBILEYN', { width: 110, align: 'center', columnType:enumColumnTypes.check }),
        column.create('로그인일시', 'LOGINTIME', { width: 150, align: 'center' }),
        column.create('로그아웃일시', 'LOGOUTTIME', { width: 150, align: 'center' }),
        column.create('비고', 'REMARK', { width: 500 }),
        column.split()
    ]);
    
    ItsDateRange.SetInitValueFrom('dr_DATE', ItsHelper.AddDay(-6));
};
ItsButton.EventSearch = function () {
    var maria = new ItsMaria('SYS3003_R01', 'LIST_LOGINHIS');
    maria.AddPanel('sdiv1');
    maria.CallProc();
    if (maria.isError) {
        maria.ShowErrMsg();
        return;
    }
    ItsGrid.SetStore('grid1', maria.store.YnToBool('MOBILEYN'));
    ItsMsg.Toast(ItsMsg.CommonMsg.SearchComplete);
}
