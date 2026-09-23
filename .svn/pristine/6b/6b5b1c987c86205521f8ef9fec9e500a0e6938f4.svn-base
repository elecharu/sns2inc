/// <reference path="../Script/reference.js" />
/********************************************
 * >>>>> ItsPop: 팝업 컨트롤 >>>>>
 * 2018-08-14: 문재원: 최초 작성
 *******************************************/
var ItsPop = {
    list: [],
    Init: function () {
        var PopList = $('div.ItsPop');
        for (var i = 0; i < PopList.length; i++) {
            var key = PopList.eq(i).attr('id');
            var width = 210;
            if (parseInt(PopList.eq(i).attr('data-width')) == -1) {
                if ($('#' + key).find('.ItsFind').length > 0) {
                    width = 410;
                }
            } else {
                width = parseInt(PopList.eq(i).attr('data-width'))
            }
            var $modal = true;
            if (PopList.eq(i).attr('data-modal') == 'false') {
                $modal = false;
            }
            var $resizable = true;
            if (PopList.eq(i).attr('data-resizable') == 'false') {
                $resizable = false;
            }
            var $dialogOpt = {
                autoOpen: false,
                modal: $modal,
                resizable: $resizable,
                minWidth: width,
                open: function () {
                    for (var i = 0; i < $(this).find('.ItsGrid').length; i++) {
                        ItsGrid.Get($(this).find('.ItsGrid').eq(i).attr('id')).refresh();
                    }
                    ItsSplit.Resize($(this));
                    $('div.ItsDate_box > input').each(function () {
                        $(this).datetimepicker('hide');
                    });
                    if ($(this).attr('data-type') == 'add' && $(this).height() > 45) {
                        $(this).height($(this).height() + 45);
                    }
                    
                    try {
                        for (var i = 0; i < ItsTab.list.length; i++) {
                            if (ItsTab.list[i].hostElement.id == $(this).find('.ItsTab').eq(0).attr('id')) {
                                ItsTab.list[i].onSelectedIndexChanged();
                            }
                        }
                    } catch (e) { }
                    var $id = $(this).attr('id');
                    if ($id != undefined && $id != null && $id != "") {
                        $('.ui-dialog-titlebar-close').html('<i class="fa fa-times"></i>');
                        if ($(this).parent().width() > $(window).width()) {
                            $(this).parent().width($(window).width());
                        }
                        ItsPop.Event($id).onPopOpened();
                    }
                },
                close: function (event, ui) {
                    var $id = $(this).attr('id');
                    if ($id != undefined && $id != null && $id != "") {
                        ItsPop.Event($id).onPopClosed();
                    }
                }
            };
            if (parseInt(PopList.eq(i).attr('data-height')) > -1) {
                $dialogOpt.height = parseInt(PopList.eq(i).attr('data-height'));
            }
            ItsPop.list.push($('#' + key).dialog($dialogOpt));
        }
    },
    Open: function(id) {
        for (var i = 0; i < ItsPop.list.length; i++) {
            var key = ItsPop.list[i].attr('id');
            if (id == key) {
                ItsPop.list[i].dialog("open");
            }
        }
    },
    Close: function(id) {
        for (var i = 0; i < ItsPop.list.length; i++) {
            var key = ItsPop.list[i].attr('id');
            if (id == key) {
                ItsPop.list[i].dialog("close");
            }
        }
    },
    LoadFindPopCOM: function () {
        return;
        //try {
        //    parent.wait_start();
        //} catch (e) { }
        //setTimeout(function () {
        //    try {
        //        document.getElementById("ifr_COM").src = "../../Service/PopTag/COM.aspx";
        //        parent.wait_end();
        //    } catch (e) { }
        //}, 1);
    },
    LoadFindPopITEMCD: function () {
        try {
            parent.wait_start();
        } catch (e) { }
        setTimeout(function () {
            try {
                document.getElementById("ifr_ITEMCD").src = "../../Service/PopTag/ITEMCD.aspx";
                parent.wait_end();
            } catch (e) { }
        }, 1);
    },
    /**
     * findPop
     */
    _paramsCOM: {
        gpcd: '',
        ref01: '',
        ref02: '',
        ref03: '',
        ref04: '',
        ref05: '',
        keyword: '',
        selectBtn: false,
        brandFind: false,
        endYN: false,
        headStore: []
    },
    _callbackCOM: function (result) { },
    _checkCallbackCOM: function (result) { },
    /**
     * @param {_paramsCOM} params
     */
    OpenFindCOM: function (params, callback, checkCallback) {
        if (ItsPop._paramsCOM.gpcd != params.gpcd) {
            ItsPop._paramsCOM = {
                gpcd: '',
                ref01: '',
                ref02: '',
                ref03: '',
                ref04: '',
                ref05: '',
                ref06: '',
                ref07: '',
                ref08: '',
                ref09: '',
                ref10: '',
                keyword: '',
                headStore: []
            };
            ItsHelper.CopyObj(params, ItsPop._paramsCOM);
            if (params.selectBtn) ItsButton.Show('findPop_COM_check');
            if (params.brandFind) ItsFind.Show('findPop_COM_brandcd');
            if (params.endYN) ItsCheck.Show('findPop_COM_ENDYN')
            else ItsCheck.Hide('findPop_COM_ENDYN');

            var maria = new ItsMaria('DC_FIND');
            maria.AddParam('GPCD', ItsPop._paramsCOM.gpcd + '_HEAD');
            maria.AddParam('REF01', ItsPop._paramsCOM.ref01);
            maria.AddParam('REF02', ItsPop._paramsCOM.ref02);
            maria.AddParam('REF03', ItsPop._paramsCOM.ref03);
            maria.AddParam('REF04', ItsPop._paramsCOM.ref04);
            maria.AddParam('REF05', ItsPop._paramsCOM.ref05);
            maria.AddParam('REF06', ItsPop._paramsCOM.ref06);
            maria.AddParam('REF07', ItsPop._paramsCOM.ref07);
            maria.AddParam('REF08', ItsPop._paramsCOM.ref08);
            maria.AddParam('REF09', ItsPop._paramsCOM.ref09);
            maria.AddParam('REF10', ItsPop._paramsCOM.ref10);
            maria.AddParam('KEYWORD', ItsPop._paramsCOM.keyword);
            maria.AddParam('LIMIT', 500);
            maria.CallProc();
            if (maria.isError) {
                maria.ShowErrMsg();
                return;
            }
            ItsPop._paramsCOM.headStore.push(maria.store);
            ItsPop._paramsCOM.headStore.push(maria.storeExtend1);
            ItsPop._paramsCOM.headStore.push(maria.storeExtend2);
        } else {
            ItsHelper.CopyObj(params, ItsPop._paramsCOM);
        }

        if (callback != undefined) ItsPop._callbackCOM = callback;
        if (checkCallback != undefined) ItsPop._checkCallbackCOM = checkCallback;


        if (params.brandFind) ItsFind.SetInit('findPop_COM_brandcd');
        ItsCheck.SetInit('findPop_COM_ENDYN');

        ItsFindPop.ResetCom();
    },
    _paramsITEMCD: {
        keyword: "",
    },
    _callbackITEMCD: function (result) { },
    /**
     * @param {_paramsITEMCD} params
     */
    OpenFindITEMCD: function (params, callback) {
        ItsPop._paramsITEMCD = {
            KEYWORD: "",
            KEYTYPE: "ITEMCD"
        }
        ItsHelper.CopyObj(params, ItsPop._paramsITEMCD);

        if (callback != undefined) ItsPop._callbackITEMCD = callback;

        var iframe = document.getElementById("ifr_ITEMCD");
        if (iframe.src.indexOf('ITEMCD.aspx') == -1) {
            iframe.src = "../../Service/PopTag/ITEMCD.aspx";
        }
        $('#findPop_ITEMCD').dialog("open");
        $('#findPop_ITEMCD').parent().css('top', 120);
        $('#findPop_ITEMCD').find('iframe').height(500);
        try {
            iframe.contentWindow.Reset();
            //iframe.contentWindow.$('#findPop_ITEMCD_KEYWORD').focus();
        } catch (e) { };
    },
    /** 
    @returns {ItsPop.Listener} 
    */
    Event: function (key) {
        if (ItsPage.EventList[key] == undefined) {
            ItsPage.EventList[key] = new ItsPop.Listener();
        }
        return ItsPage.EventList[key];
    },
    Listener: function () {
        this.onPopOpened = function () { };
        this.onPopClosed = function () { };
        this.onAddBtnClick = function () { };
        this.onCancelBtnClick = function () { };
    }
};

var FindPop_Focus = false; // 행동 기준 포커스 false : 검색창 true : 그리드
var ItsFindPop = {
    ResetCom: function () {
        var $params = ItsPop._paramsCOM;
        if ($params.headStore.length == 0) {
            return;
        }
        var $CODE = $params.headStore[0].data[0]['CODE'];
        var $NAME = $params.headStore[0].data[0]['NAME'];
        var $REF01 = $params.headStore[0].data[0]['REF01']; if ($REF01 == undefined) $REF01 = '참조1';
        var $REF02 = $params.headStore[0].data[0]['REF02']; if ($REF02 == undefined) $REF02 = '참조2';
        var $REF03 = $params.headStore[0].data[0]['REF03']; if ($REF03 == undefined) $REF03 = '참조3';
        var $REF04 = $params.headStore[0].data[0]['REF04']; if ($REF04 == undefined) $REF04 = '참조4';
        var $REF05 = $params.headStore[0].data[0]['REF05']; if ($REF05 == undefined) $REF05 = '참조5';
        var $REF05 = $params.headStore[0].data[0]['REF05']; if ($REF05 == undefined) $REF05 = '참조5';
        var $REF06 = $params.headStore[0].data[0]['REF06']; if ($REF06 == undefined) $REF06 = '참조6';
        var $REF07 = $params.headStore[0].data[0]['REF07']; if ($REF07 == undefined) $REF07 = '참조7';
        var $REF08 = $params.headStore[0].data[0]['REF08']; if ($REF08 == undefined) $REF08 = '참조8';
        var $REF09 = $params.headStore[0].data[0]['REF09']; if ($REF09 == undefined) $REF09 = '참조9';
        var $REF10 = $params.headStore[0].data[0]['REF10']; if ($REF10 == undefined) $REF10 = '참조10';
        var $REF01_HIDDEN = false;
        var $REF02_HIDDEN = false;
        var $REF03_HIDDEN = false;
        var $REF04_HIDDEN = false;
        var $REF05_HIDDEN = false;
        var $REF06_HIDDEN = false;
        var $REF07_HIDDEN = false;
        var $REF08_HIDDEN = false;
        var $REF09_HIDDEN = false;
        var $REF10_HIDDEN = false;
        var $CODE_WIDTH = $params.headStore[1].data[0]['CODE']; if ($CODE_WIDTH == undefined) { $CODE_WIDTH = 0; }
        var $NAME_WIDTH = $params.headStore[1].data[0]['NAME']; if ($NAME_WIDTH == undefined) { $NAME_WIDTH = 0; }
        var $REF01_WIDTH = $params.headStore[1].data[0]['REF01']; if ($REF01_WIDTH == undefined) { $REF01_WIDTH = 0; $REF01_HIDDEN = true; }
        var $REF02_WIDTH = $params.headStore[1].data[0]['REF02']; if ($REF02_WIDTH == undefined) { $REF02_WIDTH = 0; $REF02_HIDDEN = true; }
        var $REF03_WIDTH = $params.headStore[1].data[0]['REF03']; if ($REF03_WIDTH == undefined) { $REF03_WIDTH = 0; $REF03_HIDDEN = true; }
        var $REF04_WIDTH = $params.headStore[1].data[0]['REF04']; if ($REF04_WIDTH == undefined) { $REF04_WIDTH = 0; $REF04_HIDDEN = true; }
        var $REF05_WIDTH = $params.headStore[1].data[0]['REF05']; if ($REF05_WIDTH == undefined) { $REF05_WIDTH = 0; $REF05_HIDDEN = true; }
        var $REF06_WIDTH = $params.headStore[1].data[0]['REF06']; if ($REF06_WIDTH == undefined) { $REF06_WIDTH = 0; $REF06_HIDDEN = true; }
        var $REF07_WIDTH = $params.headStore[1].data[0]['REF07']; if ($REF07_WIDTH == undefined) { $REF07_WIDTH = 0; $REF07_HIDDEN = true; }
        var $REF08_WIDTH = $params.headStore[1].data[0]['REF08']; if ($REF08_WIDTH == undefined) { $REF08_WIDTH = 0; $REF08_HIDDEN = true; }
        var $REF09_WIDTH = $params.headStore[1].data[0]['REF09']; if ($REF09_WIDTH == undefined) { $REF09_WIDTH = 0; $REF09_HIDDEN = true; }
        var $REF10_WIDTH = $params.headStore[1].data[0]['REF10']; if ($REF10_WIDTH == undefined) { $REF10_WIDTH = 0; $REF10_HIDDEN = true; }
        var $fullWidth = parseInt($CODE_WIDTH) + parseInt($NAME_WIDTH)
                       + parseInt($REF01_WIDTH) + parseInt($REF02_WIDTH) + parseInt($REF03_WIDTH) + parseInt($REF04_WIDTH) + parseInt($REF05_WIDTH)
                       + parseInt($REF06_WIDTH) + parseInt($REF07_WIDTH) + parseInt($REF08_WIDTH) + parseInt($REF09_WIDTH) + parseInt($REF10_WIDTH) + 40;
        FindPop_Focus = false;

        if (ItsGrid.Get('findPop_COM_grid1') != undefined) {
            var $grid = ItsGrid.Get('findPop_COM_grid1');
            for (var i = 0; i < ItsGrid.list.length; i ++) {
                try{
                    if ('findPop_COM_grid1' == ItsGrid.list[i]._e.id) {
                        ItsGrid.list.splice(i, 1);
                    }
                } catch (e) {
                    console.log(e);
                }
            }
            try{
                $grid.dispose();
            } catch (e) {
                console.log(e);
            }
            
        }

        ItsGrid.Create('findPop_COM_grid1', { isCheckBoxGrid:$params.selectBtn }, [
            column.create($CODE, "CODE", { width: $CODE_WIDTH }),
            column.create($NAME, "NAME", { width: $NAME_WIDTH }),
            column.create($REF01, "REF01", { width: $REF01_WIDTH, hidden: $REF01_HIDDEN }),
            column.create($REF02, "REF02", { width: $REF02_WIDTH, hidden: $REF02_HIDDEN }),
            column.create($REF03, "REF03", { width: $REF03_WIDTH, hidden: $REF03_HIDDEN }),
            column.create($REF04, "REF04", { width: $REF04_WIDTH, hidden: $REF04_HIDDEN }),
            column.create($REF05, "REF05", { width: $REF05_WIDTH, hidden: $REF05_HIDDEN }),
            column.create($REF06, "REF06", { width: $REF06_WIDTH, hidden: $REF06_HIDDEN }),
            column.create($REF07, "REF07", { width: $REF07_WIDTH, hidden: $REF07_HIDDEN }),
            column.create($REF08, "REF08", { width: $REF08_WIDTH, hidden: $REF08_HIDDEN }),
            column.create($REF09, "REF09", { width: $REF09_WIDTH, hidden: $REF09_HIDDEN }),
            column.create($REF10, "REF10", { width: $REF10_WIDTH, hidden: $REF10_HIDDEN })
        ]);
        // 조회버튼 이벤트
        ItsButton.Event('findPop_COM_search').onClick = function () {
            var maria = new ItsMaria('DC_FIND');
            maria.AddParam('GPCD', $params.gpcd + '_LIST');
            maria.AddParam('KEYWORD', ItsText.GetValue('findPop_COM_KEYWORD'));
            maria.AddParam('REF01', $params.ref01);
            maria.AddParam('REF02', $params.ref02);
            maria.AddParam('REF03', $params.ref03);
            if ($params.brandFind) {
                maria.AddParam('REF05', ItsFind.GetValue('findPop_COM_brandcd'));
            } else {
                maria.AddParam('REF05', $params.ref05);
            }
            if ($params.endYN) {
                maria.AddParam('REF04', ItsCheck.GetValue('findPop_COM_ENDYN'));
            } else {
                maria.AddParam('REF04', $params.ref04);
            }
            
            maria.AddParam('LIMIT', 500);
            maria.CallProc();
            if (maria.isError) {
                maria.ShowErrMsg();
                return;
            }
            ItsGrid.SetStore('findPop_COM_grid1', maria.store);
            if (maria.store.Length() == 1) {
                var sel = ItsGrid.Get('findPop_COM_grid1').selection;
                if (ItsGrid.IsSelect('findPop_COM_grid1')) {
                    var $i = ItsGrid.GetCurrentIndex('findPop_COM_grid1');
                    var $result = ItsGrid.GetRowData('findPop_COM_grid1', $i);
                    ItsPop._callbackCOM($result);
                    ItsPop.Close('findPop_COM');
                }
            }

            ItsGrid.Get('findPop_COM_grid1').columns.forEach(function (c) {
                if (c.dataType == 2) {
                    c.align = 'right';
                }
            });
            ItsGrid.Get('findPop_COM_grid1').refresh();
            FindPop_Focus = true;
            ItsText.Focus('findPop_COM_KEYWORD');
            //if (ItsGrid.Length('findPop_COM_grid1') == 0) {
            //    ItsText.Focus('findPop_COM_KEYWORD');
            //}
            //else {
            //    if (ItsText.GetValue('findPop_COM_KEYWORD') != '') {
            //        ItsGrid.Focus('findPop_COM_grid1', 0);
            //        //ItsGrid.Get('findPop_COM_grid1').focus();
            //    }
            //}
        }
        // 선택버튼 이벤트
        ItsButton.Event('findPop_COM_check').onClick = function () {
            var $result = [];
            for(var i = 0; i < ItsGrid.Length('findPop_COM_grid1'); i++) {
                if(ItsGrid.IsChecked('findPop_COM_grid1', i)) {
                    $result.push(ItsGrid.GetRowData('findPop_COM_grid1', i));
                }
            }
            ItsPop._checkCallbackCOM($result);
            ItsPop.Close('findPop_COM');
        }
        $('#findPop_COM_grid1').on('dblclick').unbind();
        ItsGrid.Get('findPop_COM_grid1').hostElement.addEventListener('dblclick', function (e) {
            var sel = ItsGrid.Get('findPop_COM_grid1').selection;
            if (ItsGrid.IsSelect('findPop_COM_grid1')) {
                var $i = ItsGrid.GetCurrentIndex('findPop_COM_grid1');
                var $result = ItsGrid.GetRowData('findPop_COM_grid1', $i);
                ItsPop._callbackCOM($result);
                ItsPop.Close('findPop_COM');
            }
        });
        $('#findPop_COM').on('keydown').unbind();
        $('#findPop_COM').on('keydown', function (e) {
            if (ItsGrid.Get('findPop_COM_grid1') != undefined) {
                if (e.keyCode == 13) {
                    //엔터키
                    if (FindPop_Focus) {
                        var e = jQuery.Event("dblclick", e);
                        $("#findPop_COM_grid1").trigger(e);
                        return;
                    }
                    if (e.target.nodeName == 'INPUT') {
                        ItsButton.Event('findPop_COM_search').onClick();
                        return;
                    }
                    e.preventDefault();
                    if (ItsGrid.IsSelect('findPop_COM_grid1')) {
                        if ($params.gpcd == 'ITEMCDPOP') {
                            ItsButton.Event('findPop_COM_check').onClick();
                        } else {
                            var $i = ItsGrid.GetCurrentIndex('findPop_COM_grid1');
                            var $result = ItsGrid.GetRowData('findPop_COM_grid1', $i);
                            ItsPop._callbackCOM($result);
                            ItsPop.Close('findPop_COM');
                        }
                    }
                    //} else if (e.keyCode == 38 || e.keyCode == 40) {
                    //    //방향키
                    //    var rowindex = ItsGrid.GetCurrentIndex('findPop_COM_grid1');
                    //    if(rowindex > -1)
                    //        ItsGrid.Focus('findPop_COM_grid1', rowindex + 1);
                    //    else
                    //        ItsGrid.Focus('findPop_COM_grid1', 0);
                    //    //ItsGrid.Get('findPop_COM_grid1').focus();
                }else if(e.keyCode == 38){
                    var rowindex = ItsGrid.GetCurrentIndex('findPop_COM_grid1');
                    if (rowindex > 0) {
                        ItsGrid.SelectRow('findPop_COM_grid1', rowindex - 1);
                    }
                    else {
                        ItsGrid.SelectRow('findPop_COM_grid1', 0);
                    }
                    FindPop_Focus = true;
                    ItsText.Focus('findPop_COM_KEYWORD');
                } else if (e.keyCode == 40) {
                    var rowindex = ItsGrid.GetCurrentIndex('findPop_COM_grid1');
                    var max = ItsGrid.Length('findPop_COM_grid1');
                    if (rowindex < max - 1) {
                        ItsGrid.SelectRow('findPop_COM_grid1', rowindex + 1);
                    }
                    else {
                        ItsGrid.SelectRow('findPop_COM_grid1', max - 1);
                    }
                    FindPop_Focus = true;
                    ItsText.Focus('findPop_COM_KEYWORD');
                                    
                } else if (e.keyCode == 27) {
                    //esc키
                    ItsPop.Close('findPop_COM');
                }
                else {
                    FindPop_Focus = false;
                }
            }
        });

        $('#findPop_COM_grid1').on('keydown').unbind();
        $('#findPop_COM_grid1').on('keydown', function (e) {
            if (e.keyCode > 36 && e.keyCode < 41) {
                //방향키
                if (e.keyCode == 38 && ItsGrid.GetCurrentIndex('findPop_COM_grid1') == 0)
                    //위에키
                    ItsText.Focus('findPop_COM_KEYWORD');
                FindPop_Focus = true;
            }
            else if ((e.keyCode < 17 || e.keyCode > 19) && (e.keyCode < 33 || e.keyCode > 36)) {
                //쉬프트만 살리고 나머지 특이키 제외
                ItsText.Focus('findPop_COM_KEYWORD');
                var text = ItsText.GetValue('findPop_COM_KEYWORD');
                if ((e.keyCode > 47 && e.keyCode < 58) || (e.keyCode > 95 && e.keyCode < 112) || (e.keyCode > 185 && e.keyCode < 223) || (e.keyCode > 64 && e.keyCode < 91)) {
                    if ((e.keyCode > 64 && e.keyCode < 91)) {
                        //아직 보류 ㅠㅠ 영어 소문자를 한글로
                    }
                    else {
                        ItsText.SetValue('findPop_COM_KEYWORD', text + e.key);
                    }
                }
                else if (e.keyCode == 8) {
                    text = text.substr(0, text.length - 1);
                    ItsText.SetValue('findPop_COM_KEYWORD', text + e.key);
                }
                else if (e.keyCode == 9 || e.keyCode == 32) {
                    ItsText.SetValue('findPop_COM_KEYWORD', text + ' ');
                }
                FindPop_Focus = false;
                var e = jQuery.Event("keydown", { keyCode: e.keyCode });
                $("#findPop_COM").trigger(e);
            }
        });

        if (ItsGrid.Get('findPop_COM_grid1').columns[0].visible == true) {
            $fullWidth += 50;
        }
        $('#findPop_COM').parent().css('width', $fullWidth + 20);
        $('#findPop_COM').dialog("option", "minWidth", $fullWidth + 20);
        ItsGrid.Get('findPop_COM_grid1').refresh();
        var $params = ItsPop._paramsCOM;
        ItsText.SetValue('findPop_COM_KEYWORD', $params.keyword);
        $('#findPop_COM').dialog("open");
        ItsButton.Event('findPop_COM_search').onClick();
    }
}

ItsPop.create_ACCPOP = function () {
    ItsGrid.Create('COMMON_ACCPOP_grid1', { isSubTotalGrid: true, allowMerging: 'Cells' }, [
        column.create('전표일자', 'ACCTDT', { width: 90, align: 'center', allowMerging: true }),
        column.create('전표번호', 'ACCTHKEY', { width: 100, allowMerging: true, align: 'center' }),
        column.create('계정코드', 'ACCTCD', { width: 80 }),
        column.create('계정명', 'ACCTNM', { width: 150, backColor: enumColor.greenLight2 }),
        column.create('증빙', 'ACCPROCDNM', { width: 100 }),
        column.create('적요', 'ACCTEPIT', { width: 200 }),
        column.create('거래처명', 'CUSTNM', { width: 150 }),
        column.create('차변금액', 'CRAMT', { width: 90, columnType: enumColumnTypes.number, groupType: enumGrouping.sum, backColor: enumColor.yellowLight2 }),
        column.create('대변금액', 'DRAMT', { width: 90, columnType: enumColumnTypes.number, groupType: enumGrouping.sum, backColor: enumColor.yellowLight2 }),
        column.create('사용부서', 'DEPTNM', { width: 90, allowMerging: true }),
        column.create('작성자', 'EMPNM', { width: 70, allowMerging: true }),
        column.create('작성부서', 'EMPDEPTNM', { width: 70, allowMerging: true }),
        column.create('전표구분', 'ACCTTP', { width: 70, columnType: enumColumnTypes.combo, gpcd: 'ACCTTP', allowMerging: true, align: 'center' }),
        column.split()
    ]);
};



ItsPop.ShowAccbookInfo = function (ACCTHKEY) {
    $('#COMMON_ACCPOP_ItsPopADD').hide();
    //if (ItsPage.name.indexOf('ACC') == -1) {
    //    return;
    //}
    var maria = new ItsMaria('ACC0202_S01', 'LIST_BOOK');
    maria.AddParam('ACCTHKEY', ACCTHKEY);
    maria.CallProc();
    if (maria.isError) {
        maria.ShowErrMsg();
        return;
    }
    if (maria.store.Length() > 0) {
        ItsGrid.SetStore('COMMON_ACCPOP_grid1', maria.store);
        ItsPop.Open('COMMON_ACCPOP');
    }
};
ItsPop.Event('COMMON_ACCPOP').onCancelBtnClick = function () {
    ItsPop.Close('COMMON_ACCPOP');
}
ItsPop.CloseAccbookInfo = function () {
    ItsPop.Close('COMMON_ACCPOP');
}
ItsGrid.Event('COMMON_ACCPOP_grid1').onDoubleClick = function (rowIndex, field) {
    if (field == 'ACCTHKEY') {
        var param = [];
        param.push({
            "PAGE": ItsPage.name,
            "VALUE": ItsGrid.GetValue('COMMON_ACCPOP_grid1', rowIndex, 'ACCTHKEY')
        });
        ItsPage.Jump('ACC0202_R01', param[0]);
    }
}