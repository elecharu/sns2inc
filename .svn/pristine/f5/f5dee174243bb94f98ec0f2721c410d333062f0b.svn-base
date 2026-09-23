/// <reference path="../../Script/reference.js" />
$(window).ready(function () {
    wijmo.setLicenseKey(parent.wijmoKey);
    ItsSplit.Init();
    ItsPop.Init();
    ItsTab.Init();

    ItsGrid.Init();

    ItsText.Reset();
    ItsTextArea.Reset();
    ItsNum.Reset();
    ItsDate.Reset();
    ItsDateRange.Reset();
    ItsMonth.Reset();
    ItsCombo.Reset();
    ItsFind.Reset();
    ItsButton.Reset();
    ItsCheck.Reset();

    ItsImage.Reset();
    ItsOnoff.Reset();
    ItsRadio.Reset();

    ItsPage.KeyErr();

    _$SetAut();
    _$SetCentercd();

    //if (ItsPage.name.indexOf('ACC') > -1) {
        //ItsPop.create_ACCPOP(); // after _$SetAut()
    //}

    ItsPage.Load();
    ItsFaxPop.Init();
    ItsRptViewer.Reset(); // after ItsPage.Load()

    keySet();

    // Window Resize 이벤트
    $(window).resize(function () {
        if (ItsPage.domsg) {
            return;
        }
        var maxPopWidth = 0;
        for (var i = 0; i < $('div.ItsPop').length; i++) {
            var $w = $('div.ItsPop')[i].offsetWidth
            if (maxPopWidth < $w) {
                maxPopWidth = $w;
            }
        }

        $('body').css('display', 'none');

        var windowWidth = $(window).width();

        if (maxPopWidth > windowWidth) {
            windowWidth = maxPopWidth;
        }

        var windowHeight = $(window).height();
        $('body').css('display', '');

        var mainBody = $('#MAIN_BODY');
        if (mainBody.length == 0) {
            return;
        }
        var bodyTop = mainBody.offset().top;
        var bodyMargin = parseInt(mainBody.css('margin-left'));
        mainBody.css('width', windowWidth - 24 - bodyMargin * 2 + 'px');
        mainBody.css('height', windowHeight - bodyTop - bodyMargin - 0.2 + 'px');
        setTimeout(function () {
            var tabresize = true;
            $('.wj-tabpanes').each(function (i, e) {
                $(this).parents('.SplitTop').css('overflow-y', 'hidden');
                var $height = $(this).parent().parent().height() - $(this).siblings().eq(0).height();
                $(this).height($height);
                if ($(this).children().eq(ItsTab.GetIndex($(this).parent().parent().attr('id'))).children().eq(0).hasClass('ItsGrid')) {
                    tabresize = false; //탭패널에 그리드만 있을경우 resize 다시 할필요 없고 탭패널 내부에 또 split이 있을경우 내부 resize 처리
                }
            });
            if (tabresize) {
                ItsSplit.Resize($('#MAIN_BODY'));
            }
        }, 1);
        ItsSplit.Resize(mainBody);
    });
    $(window).resize();
    setTimeout(function () {
        // 모든 그리드 더블클릭 이벤트 등록
        ItsGrid.list.forEach(function ($obj) {
            $obj.hostElement.addEventListener('dblclick', function (e) {
                try {
                    var sel = $obj.selection;
                    if (ItsGrid.$isGroupGrid($obj.hostElement.id)) {
                        var row = $obj.itemsSource._idx;
                    } else {
                        var row = sel.row;
                    }
                    var field = $obj.columns[sel.col].binding;


                    // 2020-03-23 체크박스인 경우 전체선택
                    if ($obj.columns[sel.col].dataType == 3 && $obj.columns[sel.col].isReadOnly == false) {
                        if ($obj.columns[sel.col].binding != 'isRowCheck') {
                            for (var i = 0; i < $obj.rows.length; i++) {
                                $obj.rows[i]._data[$obj.columns[sel.col].binding] = $obj.checkFlag;
                            }
                            $obj.checkFlag = !$obj.checkFlag;
                            $obj.refresh();
                        }
                    }

                    ItsGrid.Event($obj.hostElement.id.replace('-targetEl', '')).onDoubleClick(row, field);
                } catch (e) { }
            });
            $obj.hostElement.addEventListener('click', _$cellClickEvent);
            $obj.hostElement.addEventListener('keydown', function (e, parentEvent) {
                if (e.keyCode == 13) {
                    try {
                        var sel = $obj.selection;
                        var field = $obj.columns[sel.col].binding;
                        ItsGrid.Event($obj.hostElement.id.replace('-targetEl', '')).onKeydownEnter(sel.row, field);
                    } catch (e) { }
                } else if (e.keyCode == 46) {
                    try {
                        var sel = $obj.selection;
                        if ($obj.columns[sel.col].format == 'check') {
                            $obj.cells.setCellData(sel.row, sel.col, false);
                        }
                    } catch (e) { }
                } else {
                    try {
                        var sel = $obj.selection;
                        var field = $obj.columns[sel.col].binding;
                        ItsGrid.Event($obj.hostElement.id.replace('-targetEl', '')).onKeydown(sel.row, field, e.keyCode, e.ctrlKey, e.shiftKey, e.altKey);
                    } catch (e) { }
                }
            });
            var bc = new wijmo.grid.selector.BooleanChecker($obj.columns[0]);
            bc.itemChecked.addHandler(function (s, e) {
                ItsGrid.Event($obj.hostElement.id.replace('-targetEl', '')).onCtxMenu('all_chk', {});
            });
        });
        ItsPage.$onReceiveParam();
    }, 1)

    try {
        parent.wait_end();
    } catch (e) { }
    // 디버그 창 닫기 이벤트
    $('#DebugClose').click(function () {
        $('#DebugPanel').css('display', 'none');
        $(window).resize();
    });
    // 빈공간 클릭 시 ItsControl_pop 설정된 목록창 전부 닫기 ( combo, find )
    $(document).on('mouseup', function (e) {
        //$('.ItsControl_pop').not($(e.target)).css('display', 'none');
        $('.ItsControl_pop').not($(e.target)).not($(e.target).parent('div.ItsControl_pop')).css('display', 'none');
    });

    $('[title]').tooltip({ show: { effect: "none", delay: 0 } });

    $('a[href="https://www.grapecity.com/licensing/wijmo"]').parent().css('display', 'none');



    // 2025-03-10 위즈모 라이센스 오류 임시 숨김
    const observer = new MutationObserver((mutationsList) => {
        mutationsList.forEach(mutation => {
            mutation.addedNodes.forEach(node => {
                $('div[style="position: fixed; background: rgba(0, 0, 0, 0.3); left: 0px; top: 0px; width: 100%; height: 100%; font-family: sans-serif; z-index: 10000;"]').remove();
                $('a[href="https://www.grapecity.com/licensing/wijmo?utm_source=Wijmo-In-App&utm_medium=Click-to-Site&utm_campaign=Wijmo-User-Analysis"]').parent().remove();
                $('a[href="https://www.grapecity.com/licensing/wijmo?utm_source=Wijmo-In-App&utm_medium=Click-to-Site&utm_campaign=Wijmo-User-Analysis"]').parent().remove();
            });
        });
    });

    observer.observe(document.body, { childList: true, subtree: true });


});

(function ($) {
    $.each(['show', 'hide'], function (i, ev) {
        var el = $.fn[ev];
        $.fn[ev] = function () {
            this.trigger(ev);
            return el.apply(this, arguments);
        };
    });
})(jQuery);

var $pathName = window.location.pathname.split('/'); //페이지 이름 추출
ItsPage.name = $pathName[$pathName.length - 1].toUpperCase().replace('.ASPX', '');
ItsPage.url = window.location.pathname.split('/PAGE')[0];
ItsPage.$onReceiveParam = function () {
    if (parent.receiveParams == undefined) {
        return;
    }
    if (parent.receiveParams[ItsPage.name] == undefined) {
        return;
    }
    ItsPage.onReceiveParam(ItsPage.GetReceiveParams());
    parent.receiveParams[ItsPage.name] = undefined;
}

function _$SetAut() {
    if (ItsPage.name.toUpperCase() == 'LOGIN') {
        return;
    } else if (ItsPage.name.toUpperCase() == 'MAIN') {
        return;
    } else if (ItsPage.name.toUpperCase() == 'SYS0000_R01') {
        $('#MAIN_TITLE_TEXT').text('');
        $('#MAIN_MENUPATH').text('');
        $('#MAIN_PAGENAME').text('[ ' + ItsPage.name + ' ]');
      //  return;
    }
    var maria = new ItsMaria('WEBSYSMAIN', 'PAGE_LOAD');
    maria.AddParam("PRGCD", ItsPage.name);
    maria.AddSessionUserId();
    maria.CallProcCenter();
    if (maria.isError) {
        //maria.showErrMsg();
        return;
    }
    var $res = maria.store.YnToBool();
    // 2025-03-25 카테고리가 빈값인 경우 예외처리
    if ($res.GetValue(0, 'NAVINAME2') == undefined || $res.GetValue(0, 'NAVINAME2') == '' || $res.GetValue(0, 'NAVINAME2') == null) {
        $('#MAIN_MENUPATH').text($res.GetValue(0, 'NAVINAME1') + ' > ' + $res.GetValue(0, 'TITLE'));
    } else {
        $('#MAIN_MENUPATH').text($res.GetValue(0, 'NAVINAME1') + ' > ' + $res.GetValue(0, 'NAVINAME2') + ' > ' + $res.GetValue(0, 'TITLE'));
    }
    $('#MAIN_PAGENAME').text('[ ' + ItsPage.name + ' ]');
    $('#MAIN_TITLE_TEXT').text($res.GetValue(0, 'TITLE'));
    ItsPage.CENTERCD = $res.GetValue(0, 'CENTERCD');
    ItsPage.EMPCD = $res.GetValue(0, 'EMPCD');
    ItsPage.USERID = $res.GetValue(0, 'USERID');
    ItsPage.PLUSKEYYN = $res.GetValue(0, 'PLUSKEYYN');
    // 권한정보
    ItsPage.autSearch= $res.GetValue(0, 'SEARCHYN');
    ItsPage.autSave = $res.GetValue(0, 'SAVEYN');
    ItsPage.autDelete = $res.GetValue(0, 'DELETEYN');
    ItsPage.autAdd = $res.GetValue(0, 'ADDYN');
    ItsPage.autPrint = $res.GetValue(0, 'PRINTYN');
    ItsPage.autFax = $res.GetValue(0, 'FAXYN');
    ItsPage.autExport = $res.GetValue(0, 'EXPORTYN');
    // 권한세팅
    if (ItsPage.autSearch == 'Y') ItsButton.Enable('COMMON_SEARCH');
    if (ItsPage.autSearch == 'Y') ItsButton.Enable('COMMON_INIT');
    if (ItsPage.autSave == 'Y') ItsButton.Enable('COMMON_SAVE');
    if (ItsPage.autDelete == 'Y') ItsButton.Enable('COMMON_DELETE');
    if (ItsPage.autAdd == 'Y') ItsButton.Enable('COMMON_ADD');
    if (ItsPage.autPrint == 'Y') ItsButton.Enable('COMMON_PRINT');
    //if (ItsPage.autFax == 'N') ItsButton.Disable('COMMON_SEARCH');
    //if (ItsPage.autExport == 'N') ItsButton.Disable('COMMON_CLOSE');
    ItsPage.isToastTop = $res.GetValue(0, 'TOAST');
    // 그리드 스타일 정보
    ItsPage.gridStyle = maria.storeExtend1;
}
function _$SetCentercd() {
    if (ItsPage.CENTERCD == '') {
        return;
    }
    $('div.ItsCombo').find('input').each(function () {
        var $input = $(this);
        var value = ItsPage.CENTERCD
        var gpcd = $input.attr('data-gpcd');
        if (gpcd == 'BDVCD') {

            $input.attr('data-value', value);
            $input.attr('data-default', value);
            var $ul = $input.siblings('ul');
            var $curLi = $ul.children('li').filter('[data-value="' + value + '"]');
            if ($curLi == undefined || $curLi == null || $curLi.length == 0) {
                $input.attr('data-label', value);
                $input.val(value);
                $input.css('color', 'red');
            } else {
                var label = $curLi.attr('data-label');
                $input.attr('data-label', label);
                $input.val(label);
                $input.css('color', '');
            }
        }
    });
}
function keySet() {
    var prgList = parent.$(".m_content > iframe");

    var ENTER = 13, TAB = 9, SHIFT = 16, CTRL = 17, ALT = 18;

    var altDown = false;
    var ctrlDown = false;
    var shiftDown = false;

    $(document).keydown(function (e, parentEvent) {
        if ($('.msgbox-msg').length > 0) {
            if (e.keyCode == 13 || e.keyCode == 32) {
                $('.msgbox-ok').eq(0).trigger('click');
                return false;
            } else if (e.keyCode == 27) {
                if ($('.msgbox-no').length > 0) {
                    $('.msgbox-no').eq(0).trigger('click');
                } else {
                    $('.msgbox-ok').eq(0).trigger('click');
                }
            }
        }
        if (e.keyCode == undefined) e = parentEvent;
        if (e.keyCode == ALT) altDown = true;
        if (e.keyCode == CTRL) ctrlDown = true;
        if (e.keyCode == SHIFT) shiftDown = true;
    }).keyup(function (e, parentEvent) {
        if (e.keyCode == undefined) e = parentEvent;
        if (e.keyCode == ALT) altDown = false;
        if (e.keyCode == CTRL) ctrlDown = false;
        if (e.keyCode == SHIFT) shiftDown = false;
    });
    $(document).keydown(function (e, parentEvent) {

        if (e.keyCode == undefined) e = parentEvent;
            // 단독 키
            //if (e.keyCode == 112) { ItsPop.Open('help_openpop'); return false; }
            // alt 키 조합
        else if (e.altKey) {
            if (e.keyCode == 81) { if (ItsPage.autSearch == 'Y') { ItsButton.EventSearch(); } return false; }
            else if (e.keyCode == 65) { if (ItsPage.autAdd == 'Y') { ItsButton.EventAdd(); } return false; }
            else if (e.keyCode == 83) { if (ItsPage.autSave == 'Y') { ItsButton.EventSave(); } return false; }
            else if (e.keyCode == 68) { if (ItsPage.autDelete == 'Y') { ItsButton.EventDelete(); } return false; }
            else if (e.keyCode == 80) { if (ItsPage.autPrint == 'Y') { ItsButton.EventPrint(); } return false; }
            else if (e.keyCode == 82) { ItsButton.EventInit(); return false; }
            else if (e.keyCode == 88) { ItsButton.EventClose(); return false; }
        }
    });
}

function _$cellClickEvent(e) {
    try {
        var sel = $obj.selection;
        $obj.startEditing(true, sel.row, sel.col, true);
    } catch (e) { }
}

ItsPop.Event('findPop_ITEMCD').onPopOpened = function () {
    if (userfontsize == '12') {
        $('#findPop_ITEMCD').parent().css('width', 1160);
    }
    else if (userfontsize == '14') {
        $('#findPop_ITEMCD').parent().css('width', 1170);
    }
    else if (userfontsize == '16') {
        $('#findPop_ITEMCD').parent().css('width', 1205);
    }
}