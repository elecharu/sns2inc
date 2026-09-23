/// <reference path="../Script/reference.js" />
var ItsButton = {
    _Reset: function ($button) {
        $button.on('keydown', function (e) {
            if (e.keyCode == 13 || e.keyCode == 32) {
                if ($('.msgbox-msg').length > 0) {
                    return;
                }
                $button.trigger('click');
            }
        });
        $button.click(function () {
            if ($(this).parent().attr('data-disabled') == "true") {
                return;
            }
            var $parent = $button.parent();
            var id = $parent.attr('id');
            if (id == undefined) {
                alert('버튼에 ID가 없습니다.');
                return;
            }
            if (id == "COMMON_SEARCH") {
                try { parent.wait_start(); } catch (e) { }
                setTimeout(function () {
                    ItsButton.EventSearch();
                    try { parent.wait_end(); } catch (e) { }
                }, 1);
            } else if (id == "COMMON_INIT") {
                ItsButton.EventInit();
            } else if (id == "COMMON_ADD") {
                try { parent.wait_start(); } catch (e) { }
                setTimeout(function () {
                    ItsButton.EventAdd();
                    try { parent.wait_end(); } catch (e) { }
                }, 1);
            } else if (id == "COMMON_SAVE") {
                try { parent.wait_start(); } catch (e) { }
                setTimeout(function () {
                    ItsButton.EventSave();
                    try { parent.wait_end(); } catch (e) { }
                }, 1);
            } else if (id == "COMMON_DELETE") {
                try { parent.wait_start(); } catch (e) { }
                setTimeout(function () {
                    ItsButton.EventDelete();
                    try { parent.wait_end(); } catch (e) { }
                }, 1);
            } else if (id == "COMMON_PRINT") {
                try { parent.wait_start(); } catch (e) { }
                setTimeout(function () {
                    ItsButton.EventPrint();
                    try { parent.wait_end(); } catch (e) { }
                }, 1);
            } else if (id == "COMMON_EXPORT") {
                ItsButton.EventExport();
            } else if (id == "COMMON_CLOSE") {
                ItsButton.EventClose();
            } else if (id == "COMMON_HELP") {
                ItsButton.EventHelp();
            } else if (id.indexOf('_ItsPopADD') > -1) {
                ItsPop.Event(id.replace('_ItsPopADD', '')).onAddBtnClick();
            } else if (id.indexOf('_ItsPopCANCEL') > -1) {
                ItsPop.Event(id.replace('_ItsPopCANCEL', '')).onCancelBtnClick();
            } else if (id.indexOf('_ItsPopRefresh') > -1) {
                ItsPage.InitData(id.replace('_ItsPopRefresh', ''));
            } else {
                if ($(this).parent().attr('data-loading') == "false") {
                    ItsButton.Event(id).onClick();
                } else {
                    try { parent.wait_start(); } catch (e) { }
                    setTimeout(function () {
                        ItsButton.Event(id).onClick();
                        try { parent.wait_end(); } catch (e) { }
                    }, 1);
                }
            }
        }); 
    },
    Reset: function () {
        $('div.ItsButton_table').each(function () {
            ItsButton._Reset($(this));
        });
    },
    EventSearch: function () {},
    EventInit: function () {
        ItsPage.InitData('ItsBodyEl');
        ItsGrid.list.forEach(function (grid) {
            grid.itemsSource = [];
        });
    },
    EventAdd: function() {},
    EventSave: function() {},
    EventDelete: function() {},
    EventPrint: function () {
        window.print();
    },
    EventExport: function () {},
    EventClose: function () {
        var $menuPath = location.pathname;
        parent.remove_iframe(ItsPage.name, true);
    },
    EventHelp: function () {
        var url = '../../Manual/' + ItsPage.name + '.png';
        $.ajax({
            url: url,
            success: function () {
                var top = (window.screen.height / 2) - (744 / 2);
                if (ItsPage.$helpPop != undefined) {
                    ItsPage.$helpPop.close();
                }
                ItsPage.$helpPop = window.open(url, "_blank", 'height=744px, width=1322px, top=' + top + 'px, left=200px, screenX=200px');
                ItsPage.$helpPop.focus();
            },
            error: function (xhr, status, error) {
                if (xhr.status == 404) {
                    var path = '../../../Manual/' + ItsPage.name + '.pdf';
                    if ($('#manual_content_pop').length == 0) {
                        var $iframeReport = "";
                        $iframeReport += "<div id='report_content_pop' class='ItsPop' title='Report Viewer' style='width:1200;hright:780'>";
                        $iframeReport += "<iframe id='manual_content' src = '../../Script/pdfjs/web/viewer.html?file=emptyFile.pdf' ";
                        $iframeReport += "scrolling='no' marginwidth='0' seamless ";
                        $iframeReport += "width='100%' height='100%'' frameborder=0 framespacing=0 ";
                        $iframeReport += "></iframe></div>";
                        var rptPop = $($iframeReport);
                        rptPop.dialog({
                            width: 1000,
                            height: 780,
                            autoOpen: false,
                            modal: true,
                            resizable: false,
                            open: function () {
                                $('.ui-dialog-titlebar-close').html('<i class="fa fa-times"></i>');
                                if (parseFloat($('#report_content_pop').parent().css('top').replace('px', '')) < 0) {
                                    $('#report_content_pop').parent().css('top', '0px')
                                }
                            },
                            close: function (event, ui) {
                                document.getElementById('manual_content').src = '../../Script/pdfjs/web/viewer.html?file=emptyFile.pdf';
                            }
                        })
                    }
                    $('#report_content_pop').dialog("open");
                    document.getElementById('manual_content').src = '../../Script/pdfjs/web/viewer.html?file=' + path;
                };
            }
        });
    },
    StyleSearch: function (label, backColor, faIcon) {
        ItsButton.$SetStyle($('#COMMON_SEARCH'), label, backColor, faIcon);
    },
    StyleInit: function (label, backColor, faIcon) {
        ItsButton.$SetStyle($('#COMMON_INIT'), label, backColor, faIcon);
    },
    StyleAdd: function (label, backColor, faIcon) {
        ItsButton.$SetStyle($('#COMMON_ADD'), label, backColor, faIcon);
    },
    StyleSave: function (label, backColor, faIcon) {
        ItsButton.$SetStyle($('#COMMON_SAVE'), label, backColor, faIcon);
    },
    StyleDelete: function (label, backColor, faIcon) {
        ItsButton.$SetStyle($('#COMMON_DELETE'), label, backColor, faIcon);
    },
    StylePrint: function (label, backColor, faIcon) {
        ItsButton.$SetStyle($('#COMMON_PRINT'), label, backColor, faIcon);
    },
    StyleExport: function (label, backColor, faIcon) {
        ItsButton.$SetStyle($('#COMMON_Export'), label, backColor, faIcon);
    },
    StyleClose: function (label, backColor, faIcon) {
        ItsButton.$SetStyle($('#COMMON_Close'), label, backColor, faIcon);
    },
    $SetStyle: function (btn, label, backColor, faIcon) {
        btn.find('span').html(label);
        if (faIcon != undefined && faIcon != null && faIcon != "")
        {
            var $i = btn.find('i');
            $i.removeClass();
            $i.addClass("fa");
            $i.addClass(faIcon.replace("fa ", ""));
        }
        btn.children('.ItsButton_table').css('background-color', backColor);
        btn.children('.ItsButton_table').css('border-color', backColor);
    },
    Hide: function (id) {
        var $input = $('div#' + id);
        $input.css('display', 'none');
        return true;
    },
    Show: function (id) {
        var $input = $('div#' + id);
        $input.css('display', '');
        return false;
    },
    Disable: function(id) {
        var $input = $('div#' + id);
        ItsButton.DisableObj($input);
    },
    DisableObj: function ($input) {
        $input.attr('data-disabled', 'true');
        $input.addClass('ItsButton_disabled');
    },
    Enable: function(id) {
        var $input = $('div#' + id);
        ItsButton.EnableObj($input);
    },
    EnableObj: function ($input) {
        $input.attr('data-disabled', 'false');
        $input.removeClass('ItsButton_disabled');
    },
    SetLabel: function (id, text) {
        $('#' + id).find('span').text(text);
    },
    Focus: function(id) {
        $('#' + id + ' .ItsButton_table').focus()
    },
    /** 
    @returns {ItsButton.Listener} 
    */
    Event: function (key) {
        if (ItsPage.EventList[key] == undefined) {
            ItsPage.EventList[key] = new ItsButton.Listener();
        }
        return ItsPage.EventList[key];
    },
    Listener: function () {
        this.onClick = function () { };
    }
};