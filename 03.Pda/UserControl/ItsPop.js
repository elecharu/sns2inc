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
            ItsPop.list.push($('#' + key).dialog({
                autoOpen: false,
                modal: $modal,
                resizable: $resizable,
                minWidth: width,
                open: function () {
                    if ($(this).attr('data-type') == 'add' && $(this).height() > 76) {
                        $(this).height($(this).height() + 30);
                    }
                    var $id = $(this).attr('id');
                    if ($id != undefined && $id != null && $id != "") {
                        $('.ui-dialog-titlebar-close').html('<i class="fa fa-times"></i>');
		$('.datetimepicker').hide();
                        ItsPop.Event($id).onPopOpened();
                    }
                },
                close: function (event, ui) {
                    var $id = $(this).attr('id');
                    if ($id != undefined && $id != null && $id != "") {
                        ItsPop.Event($id).onPopClosed();
                    }
                }
            }));
        }
    },
    Open: function(id) {
        for (var i = 0; i < ItsPop.list.length; i++) {
            var key = ItsPop.list[i].attr('id');
            if (id == key) {
                ItsPop.list[i].dialog("open");
            }
        }
        ItsGrid.list.forEach(function ($obj) {
            $obj.refresh();
        })
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
        headStore: []
    },
    _callbackCOM: function (result) { },
    /**
     * @param {_paramsCOM} params
     */
    OpenFindCOM: function (params, callback) {
        ItsPop._paramsCOM = {
            gpcd: '',
            ref01: '',
            ref02: '',
            ref03: '',
            ref04: '',
            ref05: '',
            keyword: '',
            headStore: []
        };
        ItsHelper.CopyObj(params, ItsPop._paramsCOM);

        if (callback != undefined) ItsPop._callbackCOM = callback;

        var maria = new ItsMaria('DC_FIND');
        maria.AddParam('GPCD', ItsPop._paramsCOM.gpcd + '_HEAD');
        maria.AddParam('REF01', ItsPop._paramsCOM.ref01);
        maria.AddParam('REF02', ItsPop._paramsCOM.ref02);
        maria.AddParam('REF03', ItsPop._paramsCOM.ref03);
        maria.AddParam('REF04', ItsPop._paramsCOM.ref04);
        maria.AddParam('REF05', ItsPop._paramsCOM.ref05);
        maria.CallProc();
        if (maria.isError) {
            maria.ShowErrMsg();
            return;
        }
        ItsPop._paramsCOM.headStore.push(maria.store);
        ItsPop._paramsCOM.headStore.push(maria.storeExtend1);
        ItsPop._paramsCOM.headStore.push(maria.storeExtend2);
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
        var $REF01_HIDDEN = false;
        var $REF02_HIDDEN = false;
        var $REF03_HIDDEN = false;
        var $REF04_HIDDEN = false;
        var $REF05_HIDDEN = false;
        var $CODE_WIDTH = $params.headStore[1].data[0]['CODE']; if ($CODE_WIDTH == undefined) { $CODE_WIDTH = 0; }
        var $NAME_WIDTH = $params.headStore[1].data[0]['NAME']; if ($NAME_WIDTH == undefined) { $NAME_WIDTH = 0; }
        var $REF01_WIDTH = $params.headStore[1].data[0]['REF01']; if ($REF01_WIDTH == undefined) { $REF01_WIDTH = 0; $REF01_HIDDEN = true; }
        var $REF02_WIDTH = $params.headStore[1].data[0]['REF02']; if ($REF02_WIDTH == undefined) { $REF02_WIDTH = 0; $REF02_HIDDEN = true; }
        var $REF03_WIDTH = $params.headStore[1].data[0]['REF03']; if ($REF03_WIDTH == undefined) { $REF03_WIDTH = 0; $REF03_HIDDEN = true; }
        var $REF04_WIDTH = $params.headStore[1].data[0]['REF04']; if ($REF04_WIDTH == undefined) { $REF04_WIDTH = 0; $REF04_HIDDEN = true; }
        var $REF05_WIDTH = $params.headStore[1].data[0]['REF05']; if ($REF05_WIDTH == undefined) { $REF05_WIDTH = 0; $REF05_HIDDEN = true; }
        var $fullWidth = parseInt($CODE_WIDTH) + parseInt($NAME_WIDTH) + parseInt($REF01_WIDTH) + parseInt($REF02_WIDTH) + parseInt($REF03_WIDTH) + parseInt($REF04_WIDTH) + parseInt($REF05_WIDTH) + 40;

        if (ItsGrid.Get('findPop_COM_grid1') != undefined) {
            var $grid = ItsGrid.Get('findPop_COM_grid1');
            for (var i = 0; i < ItsGrid.list.length; i ++) {
                try{
                    if ('findPop_COM_grid1' == ItsGrid.list[i]._e.id) {
                        ItsGrid.list.splice(i, 1);
                    }
                }catch(e){ }
            }
            $grid.dispose();
        }

        ItsGrid.Create('findPop_COM_grid1', { contextMenu: false }, [
            column.create($CODE, "CODE", { width: $CODE_WIDTH }),
            column.create($NAME, "NAME", { width: $NAME_WIDTH }),
            column.create($REF01, "REF01", { width: $REF01_WIDTH, hidden: $REF01_HIDDEN }),
            column.create($REF02, "REF02", { width: $REF02_WIDTH, hidden: $REF02_HIDDEN }),
            column.create($REF03, "REF03", { width: $REF03_WIDTH, hidden: $REF03_HIDDEN }),
            column.create($REF04, "REF04", { width: $REF04_WIDTH, hidden: $REF04_HIDDEN }),
            column.create($REF05, "REF05", { width: $REF05_WIDTH, hidden: $REF05_HIDDEN })
        ]);
        // 조회버튼 이벤트
        ItsButton.Event('findPop_COM_search').onClick = function () {
            var maria = new ItsMaria('DC_FIND');
            maria.AddParam('GPCD', $params.gpcd + '_LIST');
            maria.AddParam('KEYWORD', ItsText.GetValue('findPop_COM_KEYWORD'));
            maria.AddParam('REF01', $params.ref01);
            maria.AddParam('REF02', $params.ref02);
            maria.AddParam('REF03', $params.ref03);
            maria.AddParam('REF04', $params.ref04);
            maria.AddParam('REF05', $params.ref05);
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
        }
        ItsGrid.Get('findPop_COM_grid1').hostElement.addEventListener('dblclick', function (e) {
            var sel = ItsGrid.Get('findPop_COM_grid1').selection;
            if (ItsGrid.IsSelect('findPop_COM_grid1')) {
                var $i = ItsGrid.GetCurrentIndex('findPop_COM_grid1');
                var $result = ItsGrid.GetRowData('findPop_COM_grid1', $i);
                ItsPop._callbackCOM($result);
                ItsPop.Close('findPop_COM');
            }
        });
        $('#findPop_COM').on('keydown', function (e) {
            if (ItsGrid.Get('findPop_COM_grid1') != undefined) {
                if (e.keyCode == 13) {
                    if (e.target.nodeName == 'INPUT') {
                        ItsButton.Event('findPop_COM_search').onClick();
                        return;
                    }
                    e.preventDefault();
                    if (ItsGrid.IsSelect('findPop_COM_grid1')) {
                        var $i = ItsGrid.GetCurrentIndex('findPop_COM_grid1');
                        var $result = ItsGrid.GetRowData('findPop_COM_grid1', $i);
                        ItsPop._callbackCOM($result);
                        ItsPop.Close('findPop_COM');

                    }
                } else if (e.keyCode == 37 || e.keyCode == 38 || e.keyCode == 39 || e.keyCode == 40) {
                    ItsGrid.Get('findPop_COM_grid1').focus();
                } else if (e.keyCode == 27) {
                    ItsPop.Close('findPop_COM');
                }
            }
        });
        $('#findPop_COM').dialog("open");
        $('#findPop_COM').parent().css('width', $fullWidth + 20);
        ItsGrid.Get('findPop_COM_grid1').refresh();
        var $params = ItsPop._paramsCOM;
        ItsText.SetValue('findPop_COM_KEYWORD', $params.keyword);
        ItsButton.Event('findPop_COM_search').onClick();
    }
}
