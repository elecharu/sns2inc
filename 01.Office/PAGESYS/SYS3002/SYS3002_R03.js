/// <reference path="../../Script/reference.js" />

/* 페이지 로드 시 수행 */
ItsPage.Load = function () {
   
    var maria = new ItsMaria('SYS3002_R03', 'LIST_SYSAUT');
    maria.CallProc();
    if (maria.isError) {
        maria.ShowErrMsg();
        ItsMsg.Toast('권한정보를 불러오는데 실패했습니다.');
        return;
    }

    // 컬럼 편집
    var columnList = [];
    columnList.push(column.create("사업장", "BDVCD", { width: 85, columnType:enumColumnTypes.combo, gpcd:'BDVCD' }));
    columnList.push(column.create("부서코드", "DEPTP", { hidden: true }));
    columnList.push(column.create("부서", "DEPTNM", { width: 150 }));

    maria.store.data.forEach(function (d) {
        columnList.push(column.band(d['AUTNM'], {}, [
            column.create("내부", d['AUTCD'] + '_IN', { width: 50, readOnly:false, columnType:enumColumnTypes.check }),
            column.create("외부", d['AUTCD'] + '_OUT', { width: 50, readOnly: false, columnType: enumColumnTypes.check })
        ]));
    });

    columnList.push(column.split());

    /* 그리드 생성 */
    ItsGrid.Create('grid1', { isCheckBoxGrid: true }, columnList);

    ItsButton.EventSearch();
};


/* 조회 */
ItsButton.EventSearch = function () {
    var maria = new ItsMaria('SYS3002_R03', 'LIST_SYSDEPTAUT');
    maria.AddPanel('sdiv1');
    maria.CallProc();
    if (maria.isError) {
        maria.ShowErrMsg();
        return;
    }
    maria.store.data.forEach(function (d) {
        var keys = Object.keys(d);
        keys.forEach(function (k) {
            var $value = d[k];
            if ($value == "Y" || $value == "TRUE") {
                d[k] = true;
            } else if ($value == "N" || $value == "FALSE") {
                d[k] = false;
            }
        });
    });

    ItsGrid.SetStore('grid1', maria.store);

    var cnt = maria.store.Length();
    ItsMsg.Toast(ItsMsg.CommonMsg.SearchComplete(cnt));
};


/* 저장 */
ItsButton.EventSave = function () {
    var cnt = 0;
    for (var i = 0; i < ItsGrid.Length('grid1') ; i++) {
        if (ItsGrid.IsChecked('grid1', i)) {
            var maria = new ItsMaria('SYS3002_R03', 'UP_SYSDEPTAUT');
            maria.AddParam('BDVCD', ItsGrid.GetValue('grid1', i, 'BDVCD'));
            maria.AddParam('DEPTP', ItsGrid.GetValue('grid1', i, 'DEPTP'));

            var colList = ItsGrid.Get('grid1').columns;

            colList.forEach(function (c) {
                if (c.binding.indexOf('_IN') > -1) {
                    maria.AddList('INOUTTP_LIST', 'IN');
                    maria.AddList('AUTCD_LIST', c.binding.replace('_IN', ''));
                    maria.AddList('AUTYN_LIST', ItsHelper.ToYn(ItsGrid.GetValue('grid1', i, c.binding)));
                } else if(c.binding.indexOf('_OUT') > -1) {
                    maria.AddList('INOUTTP_LIST', 'OUT');
                    maria.AddList('AUTCD_LIST', c.binding.replace('_OUT', ''));
                    maria.AddList('AUTYN_LIST', ItsHelper.ToYn(ItsGrid.GetValue('grid1', i, c.binding)));
                }
            });
            maria.CallProc();
            if (maria.isError) {
                maria.ShowErrMsg();
                return;
            }
            else {
                cnt++;
            }
        }
    }
    ItsMsg.Toast(ItsMsg.CommonMsg.SaveComplete(cnt));
    ItsButton.EventSearch();
};