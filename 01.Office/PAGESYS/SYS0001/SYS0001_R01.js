/// <reference path="../../Script/reference.js" />

/* 페이지 로드 시 수행 */
ItsPage.Load = function () {
    /* 그리드 생성 */
    ItsGrid.Create('grid1', {}, [
        column.create("헤더코드", "GPCD1", { width: 150 }),
        column.create("헤더명", "GPNM", { width: 200 }),
        column.create('MES컬럼', 'MESCOLUMN', { width: 100 }),
    ]);
    ItsGrid.Create('grid2', {}, [
        column.create('상세코드', 'TPCD', { width: 90 }),
        column.create('상세명', 'TPNM', { width: 200 }),
        column.create('순서', 'SORTNO', { width: 70, columnType: enumColumnTypes.number }),
        column.create('사용여부', 'USEYN', { width: 80, columnType: enumColumnTypes.check }),
        column.create('REF01', 'REF01', { width: 150, hidden: true }),
        column.create('REF02', 'REF02', { width: 150, hidden: true }),
        column.create('REF03', 'REF03', { width: 150, hidden: true }),
        column.create('REF04', 'REF04', { width: 150, hidden: true }),
        column.create('REF05', 'REF05', { width: 150, hidden: true }),
        column.create('REF06', 'REF06', { width: 150, hidden: true }),
        column.create('REF07', 'REF07', { width: 150, hidden: true }),
        column.create('REF08', 'REF08', { width: 150, hidden: true }),
        column.create('REF09', 'REF09', { width: 150, hidden: true }),
        column.create('REF10', 'REF10', { width: 150, hidden: true }),
        column.create('REF11', 'REF11', { width: 150, hidden: true }),
        column.create('REF12', 'REF12', { width: 150, hidden: true }),
        column.create('REF13', 'REF13', { width: 150, hidden: true }),
        column.create('REF14', 'REF14', { width: 150, hidden: true }),
        column.create('REF15', 'REF15', { width: 150, hidden: true }),
        column.create('REF16', 'REF16', { width: 150, hidden: true }),
        column.create('REF17', 'REF17', { width: 150, hidden: true }),
        column.create('REF18', 'REF18', { width: 150, hidden: true }),
        column.create('REF19', 'REF19', { width: 150, hidden: true }),
        column.create('REF20', 'REF20', { width: 150, hidden: true })
    ])
    ItsButton.EventSearch();
    ItsPage.SetBackColor('ddiv1_1', enumColor.transparent);
    ItsPage.SetBackColor('ddiv1_2', enumColor.transparent);
};

ItsPage.onReceiveParam = function (param) {
    if (param.substring(0, 3) == 'ACC') {
        ItsOnoff.SetValue('onoff_ACCYN', 'N');
    } else {
        ItsOnoff.SetValue('onoff_ACCYN', 'Y');
    }
    ItsText.SetValue('txt_KEYWORD_sdiv1', param);
    ItsButton.EventSearch();
};

/* 조회 */
ItsButton.EventSearch = function () {
    ItsPage.InitData('ddiv1');
    ItsGrid.Clear('grid2');
    var maria = new ItsMaria('SYS0001_R01', 'LIST_COMTYPEGP');
    maria.AddPanel('sdiv1');
    maria.CallProc();
    if (maria.isError) {
        maria.ShowErrMsg();
        return;
    }
    ItsGrid.SetStore('grid1', maria.store);
    ItsMsg.Toast(ItsMsg.CommonMsg.SearchComplete(maria.store.Length()));
    ItsGrid.Event('grid1').onSelect(ItsGrid.GetCurrentIndex('grid1'));
};

/* 추가 */
ItsButton.EventAdd = function () {
    ItsPage.InitData('ddiv1');
    ItsPage.SetBackColor('ddiv1', enumColor.addPanel);
    ItsText.Enable('txt_TPCD2');
    ItsText.Focus('txt_TPCD2');
};

/* 저장 */
ItsButton.EventSave = function () {

    if (!ItsGrid.IsSelect('grid1')) {
        ItsMsg.Alert('헤더가 선택되지 않았습니다.');
        return;
    }

    var maria = new ItsMaria('SYS0001_R01', 'UP_COMTYPE');
    maria.AddParam('GPCD1', ItsGrid.GetValue('grid1', ItsGrid.GetCurrentIndex('grid1'), 'GPCD1'));
    maria.AddPanel('ddiv1');
    maria.CallProc();
    if (maria.isError) {
        maria.ShowErrMsg();
        return;
    }

    ItsPage.SetBackColor('ddiv1', enumColor.transparent);
    ItsText.Disable('txt_TPCD2');

    ItsGrid.Setkey('grid1', 'GPCD1', ItsGrid.GetValue('grid1', ItsGrid.GetCurrentIndex('grid1'), 'GPCD1'));
    ItsGrid.Setkey('grid2', 'TPCD', ItsText.GetValue('txt_TPCD2'));
    //ItsButton.EventSearch();
    ItsMsg.Toast('저장되었습니다.');
    ItsGrid.Event('grid1').onSelect(ItsGrid.GetCurrentIndex('grid1'));
};

/* 삭제 */
ItsButton.EventDelete = function () {
    if (!ItsGrid.IsSelect('grid1')) {
        ItsMsg.Alert('헤더가 선택되지 않았습니다.');
        return;
    }
    ItsMsg.Confirm('삭제하시겠습니까?',
        function () {
            var maria = new ItsMaria('SYS0001_R01', 'DEL_COMTYPE');

            maria.AddParam('GPCD1', ItsGrid.GetValue('grid1', ItsGrid.GetCurrentIndex('grid1'), 'GPCD1'));
            maria.AddPanel('ddiv1');

            maria.CallProc();

            if (maria.isError) {
                maria.ShowErrMsg();
                return;
            }

            var $index = ItsGrid.GetCurrentIndex('grid1');
            ItsGrid.Setkey('grid1', 'GPCD1', ItsGrid.GetValue('grid1', ItsGrid.GetCurrentIndex('grid1'), 'GPCD1'));

            ItsButton.EventSearch();

            ItsGrid.SelectRow('grid1', $index);

            ItsPage.SetBackColor('ddiv1', enumColor.transparent);
            ItsText.Disable('txt_TPCD2');

            ItsMsg.Toast('삭제되었습니다.');
        }, function () {
            ItsMsg.Toast("취소되었습니다.");
        }
    );
};

/* 그리드 선택 */
ItsGrid.Event('grid1').onSelect = function (rowIndex) {
    ItsPage.InitData('ddiv1');

    var maria = new ItsMaria('SYS0001_R01', 'LIST_COMTYPE');

    maria.AddParam('GPCD1', ItsGrid.GetValue('grid1', rowIndex, 'GPCD1'));

    maria.CallProc();

    if (maria.isError) {
        maria.ShowErrMsg();
        return;
    }

    ItsGrid.SetStore('grid2', maria.store.YnToBool('USEYN'));

    for (var i = 1; i < 20; i++) {
        var $i = i.toString();
        if (i < 10) $i = '0' + $i;
        ItsText.Hide('REF' + $i);
        if (maria.store.GetValue(0, 'REF' + $i + 'NM') != '' && maria.store.GetValue(0, 'REF' + $i + 'NM') != undefined && maria.store.GetValue(0, 'REF' + $i + 'NM') != null) {
            $('#REF' + $i).siblings('span').eq(0).text(maria.store.GetValue(0, 'REF' + $i + 'NM'));
            ItsText.Show('REF' + $i);
            ItsGrid.SetColumnName('grid2', i + 4, maria.store.GetValue(0, 'REF' + $i + 'NM'));
            ItsGrid.Get('grid2').columns[i + 4].visible = true;
        } else {
            ItsGrid.Get('grid2').columns[i + 4].visible = false;
        }
    }

    ItsPage.SetStore('ddiv1', ItsGrid.GetRowData('grid1', rowIndex));
    //ItsSplit.Resize($('.SplitRight'));

    ItsPage.SetBackColor('ddiv1', enumColor.transparent);
    ItsText.Disable('txt_TPCD2');
    ItsGrid.Event('grid2').onSelect(0);
};

/* 그리드 선택 */
ItsGrid.Event('grid2').onSelect = function (rowIndex) {
    ItsPage.SetStore('ddiv1', ItsGrid.GetRowData('grid2', rowIndex));
    ItsPage.SetBackColor('ddiv1', enumColor.transparent);
    ItsText.Disable('txt_TPCD2');
};

ItsText.Event('txt_KEYWORD_sdiv1').onKeyEnter = function (value, oldValue) {
    ItsButton.EventSearch();
};