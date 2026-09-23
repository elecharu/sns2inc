/// <reference path="../../Script/reference.js" />

$(document).ready(function () {
    // 2025-03-10 위즈모 라이센스 오류 임시 숨김
    const observer = new MutationObserver((mutationsList) => {
        mutationsList.forEach(mutation => {
            mutation.addedNodes.forEach(node => {
                $('div[style="position: fixed; background: rgba(0, 0, 0, 0.3); left: 0px; top: 0px; width: 100%; height: 100%; font-family: sans-serif; z-index: 10000;"]').remove();
                $('div[style="position:fixed;background:rgba(0,0,0,0.3);left:0;top:0;width:100%;height:100%;font-family: sans-serif;z-index:10000;"]').remove();
                $('a[href="https://www.grapecity.com/licensing/wijmo?utm_source=Wijmo-In-App&utm_medium=Click-to-Site&utm_campaign=Wijmo-User-Analysis"]').parent().remove();
                $('a[href="https://www.grapecity.com/licensing/wijmo?utm_source=Wijmo-In-App&utm_medium=Click-to-Site&utm_campaign=Wijmo-User-Analysis"]').parent().remove();
            });
        });
    });
    observer.observe(document.body, { childList: true, subtree: true });

    window.addEventListener("load", function () {
        setTimeout(scrollTo, 0, 0, 1);
    }, false);

    wijmo.setLicenseKey('localhost|mes.optisco.com,177514811214589#B07eYICbuFkI1pjIEJCLi4TPBpHZrImbsdFTYFUestUYrUERONVMr8URUJ4QStURXN6b4wUSBBjQO3yaSFEa8pUY4c4NsNVTKpVTxJTTXRXa0F4NuJWU8YWRZZjN0FTSMV7Y7g7cjh4Uyw4Y9Z7M6JnZVlHMipFelZ7NHtETMVzcnV4VGhETyVWNBBXV7NTcjhmeCFmWql6MSJGcOhVb9dVbH9EV4c6Rox4YUV5d9I7KzQnZv3Ueyhme5EVe9Q5YtF7bqJ6aQVTNOd7dqhDdvBlUWtyMMlGSaZ6aRFzaYJlaxs4bzk4VxRlZ6oVUwgmMzEnSjFHV596czYUctdzZs54aahHM6EHWNNXTJFHaQV7Ynd6U7kTSwYVbwhXNuN4b4RkQxcEdzIFW9oXUPpmTnVXSKBXTYFFW8tUM74mN686ZihHWTZzb6pVSLJlS7xWcWRkQTNEbvMmcXd4KzRVbm3SYMRDboVXYiojITJCLiMkQ6QTQGlTMiojIIJCL9ETM7ADN4AjM0IicfJye35XX3JSSwIjUiojIDJCLi86bpNnblRHeFBCI4VWZoNFelxmRg2Wbql6ViojIOJyes4nI5kkTRJiOiMkIsIibvl6cuVGd8VEIgIXZ7VWaWRncvBXZSBybtpWaXJiOi8kI1xSfis4N8gkI0IyQiwiIu3Waz9WZ4hXRgAydvJVa4xWdNBybtpWaXJiOi8kI1xSfiQjR6QkI0IyQiwiIu3Waz9WZ4hXRgACUBx4TgAybtpWaXJiOi8kI1xSfiMzQwIkI0IyQiwiIlJ7bDBybtpWaXJiOi8kI1xSfiUFO7EkI0IyQiwiIu3Waz9WZ4hXRgACdyFGaDxWYpNmbh9WaGBybtpWaXJiOi8kI1tlOiQmcQJCLiIjM6MDNwAyMxITM4IDMyIiOiQncDJCLi46bj9ybjNXa4B7buMXZtxCdz3GasF6YvxmI0IyctRkIsIyTDNFVJJiOiEmTDJCLikDO5QTMyETM8QTM5czNxIiOiQWSiwSfiMjdwIDMyIiOiIXZ6JCLlNHbhZmOiIKc6J');

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

    _$SetCentercd();

    ItsPage.Load();

    $('.title-menu').click(function () {
        //if (GET_COOKIE('BDVCD') == '200')
        //    location.href = '../../PDA_MENU_F2/PDA_MENU_F2.aspx';
        //else
            location.href =  '../../PAGEPDA/PDA_MENU/PDA_MENU.aspx';
    });

    setTimeout(function () {
        $('a[href="https://www.grapecity.com/en/licensing/wijmo"]').parent().css('display', 'none');
        $('input.ItsField.ItsFind').each(function () {
            ItsFind._$searchName($(this));
        });
        // 모든 그리드 더블클릭 이벤트 등록
        ItsGrid.list.forEach(function ($obj) {
            $obj.hostElement.addEventListener('dblclick', function (e) {
                try{
                    var sel = $obj.selection;
                    if ($obj.groupField != undefined) {
                        var row = $obj.itemsSource._idx;
                    } else {
                        var row = sel.row;
                    }
                    var field = $obj.columns[sel.col].binding;
                    ItsGrid.Event($obj.hostElement.id.replace('-targetEl', '')).onDoubleClick(row, field);
                } catch (e) {
                    console.log(e);
                }
            }); 
            $obj.hostElement.addEventListener('click', _$cellClickEvent);
            $obj.hostElement.addEventListener('keydown', function (e) {
                if (e.keyCode == 13) {
                    try {
                        var sel = $obj.selection;
                        var field = $obj.columns[sel.col].binding;
                        ItsGrid.Event($obj.hostElement.id.replace('-targetEl', '')).onKeydownEnter(sel.row, field);
                    } catch (e) { }
                } else {
                    try {
                        var sel = $obj.selection;
                        var field = $obj.columns[sel.col].binding;
                        ItsGrid.Event($obj.hostElement.id.replace('-targetEl', '')).onKeydown(sel.row, field, e.keyCode, e.ctrlKey, e.shiftKey, e.altKey);
                    } catch (e) { }
                }
            });
        });
        ItsPage.$onReceiveParam();
    }, 1)
    try{
        parent.wait_end();
    } catch(e) {}
    // 디버그 창 닫기 이벤트
    $('#DebugClose').click(function () {
        $('#DebugPanel').css('display', 'none');
        $(window).resize();
    });
    // 빈공간 클릭 시 ItsControl_pop 설정된 목록창 전부 닫기 ( combo, find )
    $(document).on('mouseup', function (e) {
        if (!$(e.target).hasClass('ItsControl_pop')) {
            if (!$(e.target).offsetParent().hasClass('ItsControl_pop')) {
                $('.ItsControl_pop').css('display', 'none');
            }
        }
    });
});

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

function _$SetCentercd() {
    if (ItsPage.CENTERCD == '') {
        return;
    }
    $('div.ItsCombo').find('input').each(function () {
        var $input = $(this);
        var value = ItsPage.CENTERCD
        var gpcd = $input.attr('data-gpcd');
        if (gpcd == 'CENTERCD') {

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

function _$cellClickEvent(e) {
    try{
        var sel = $obj.selection;
        $obj.startEditing(true, sel.row, sel.col, true);
    } catch(e) {}
}

//ItsPop.Event('findPop_ITEMCD').onPopOpened = function () {
//    if (userfontsize == '12') {
//        $('#findPop_ITEMCD').parent().css('width', 1160);
//    }
//    else if (userfontsize == '14') {
//        $('#findPop_ITEMCD').parent().css('width', 1170);
//    }
//    else if (userfontsize == '16') {
//        $('#findPop_ITEMCD').parent().css('width', 1205);       
//    }
//}