/// <reference path="../Script/reference.js" />
var ItsDate = {
    _Reset: function ($input) {

        $input.unbind('focus');
        $input.on('focus', function () {
            var value = $input.val();
            $input.attr('data-oldvalue', value);
            var id = $input[0].id;
            if (id != undefined && id != null && id != "") {
                ItsDate.Event(id).onFocus(value);
            }
        });
        $input.unbind('change');
        $input.on('change', function () {
            var value = $input.val();
            var id = $input[0].id;
            if (id != undefined && id != null && id != "") {
                var oldValue = $input.attr('data-oldvalue');
                ItsDate.Event(id).onChanged(value, oldValue);
            }
        });

        $input.datetimepicker({
            language: 'kr',
            format: 'yyyy-mm-dd',
            weekStart: 0,
            todayBtn: true,
            todayHighlight: true,
            autoclose: true,
            todayHighlight: 1,
            startView: 2,
            showMeridian: 1,
            minView: 2,
            forceParse: true
        }).on('show', function () {
            $('.glyphicon.icon-arrow-right').each(function () {
                $(this).removeClass('glyphicon');
                $(this).removeClass('icon-arrow-right');
                $(this).addClass('fa');
                $(this).addClass('fa-chevron-right');
            });
            $('.glyphicon.icon-arrow-left').each(function () {
                $(this).removeClass('glyphicon');
                $(this).removeClass('icon-arrow-left');
                $(this).addClass('fa');
                $(this).addClass('fa-chevron-left');
            });

            if ($(this).attr('readonly') == 'readonly') {
                $(this).datetimepicker('hide');
                return;
            }

            $(this).data('enterclose', 'Y');
            $(this).data('isopen', 'Y');
            $('.ItsControl_pop').css('display', 'none');
        }).on('hide', function () {
            $(this).data('isopen', 'N');
        }).on('keydown', function (e) {
            if (e.keyCode == EnumKeys.Esc || e.keyCode == EnumKeys.Tab) {
                if ($(this).data('isopen') == 'N') {
                    $(this).data('enterclose', 'N');
                }
                return;
            }
            if (e.keyCode != EnumKeys.Enter) {
                $(this).datetimepicker('show');
                return;
            }
            var flag = $(this).data('enterclose');
            if (flag != "N") {
                $(this).datetimepicker('hide');
                $(this).data('enterclose', "N");
            } else {
                $(this).datetimepicker('show');
                $(this).data('enterclose', "Y");
            }
        });
        $input.mask("0000-00-00");

        $input.parent('div.ItsDate_box').unbind('mouseup');
        $input.parent('div.ItsDate_box').on('mouseup', function (e) {
            $input.trigger('focus');
        });
    },

    Reset: function () {

        $.fn.datetimepicker.dates['kr'] = {
            days: ["일요일", "월요일", "화요일", "수요일", "목요일", "금요일", "토요일", "일요일"],
            daysShort: ["일", "월", "화", "수", "목", "금", "토", "일"],
            daysMin: ["일", "월", "화", "수", "목", "금", "토", "일"],
            months: ["1월", "2월", "3월", "4월", "5월", "6월", "7월", "8월", "9월", "10월", "11월", "12월"],
            monthsShort: ["1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12"],
            meridiem: ["오전", "오후"],
            // suffix: ["st", "nd", "rd", "th"],
            today: "오늘"
        };

        $('div.ItsDate_box > input').each(function () {
            ItsDate._Reset($(this));
        });
    },

    FormatDate: function (date, format) {
        var year = date.getFullYear();
        var month = '00' + (date.getMonth() + 1);
        month = month.substr(month.length - 2, 2);
        var day = '00' + date.getDate();
        day = day.substr(day.length - 2, 2);
        if (format == "yyyy-MM-dd") {
            return year + '-' + month + '-' + day;
        } else if (format == "yyyy") {
            return year;
        } else if (format == "yyyy-MM") {
            return year + "-" + month;
        }
    },
    SetValue: function (id, value, isChangeEvent) {
        var $input = $('input#' + id);
        $input.attr('data-value', value);
        $input.val(value);
        if (isChangeEvent != false) {
            $input.trigger('change');
        }
    },
    SetInitValue: function (id, value) {
        var $input = $('input#' + id);
        $input.val(value);
        $input.attr('data-value', value);
        $input.attr('data-default', value);
    },
    GetValue: function (id) {
        var $input = $('input#' + id);
        return $input.val();
    },
    GetField: function (id) {
        var $input = $('input#' + id);
        return $input.attr('data-field');
    },
    SetInit: function (id) {
        var $input = $('input#' + id);
        var defaultValue = $input.attr('data-default');
        $input.attr('data-value', defaultValue);
        $input.val(defaultValue);
    },
    SetInitObj: function (obj) {
        var $input = obj.find('input.ItsField');
        var defaultValue = $input.attr('data-default');
        $input.attr('data-value', defaultValue);
        $input.val(defaultValue);
    },
    Disable: function (id) {
        var $input = $('input#' + id);
        ItsDate.DisableObj($input);
    },
    DisableObj: function ($input) {
        $input.css('background-color', '#F0F0F0');
        $input.attr('readonly', 'readonly');
        return true;
    },
    Enable: function (id) {
        var $input = $('input#' + id);
        ItsDate.EnableObj($input);
    },
    EnableObj: function ($input) {
        $input.css('background-color', 'white');
        $input.removeAttr('readonly');
        return false;
    },
    Hide: function (id) {
        var $input = $('input#' + id);
        $input.parent().parent().parent().css('display', 'none');
        return true;
    },
    Show: function (id) {
        var $input = $('input#' + id);
        $input.parent().parent().parent().css('display', '');
        return false;
    },
    Focus: function (id) {
        var $input = $('input#' + id);
        setTimeout(function () {
            $input.focus();
        }, 1);
    },
    SetLabel: function (id, text) {
        $('#' + id).parent().siblings('span').text(text);
    },
    /** 
    @returns {ItsCombo.Listener} 
    */
    Event: function (id) {
        if (ItsPage.EventList[id] == undefined) {
            ItsPage.EventList[id] = new ItsDate.Listener();
        }
        return ItsPage.EventList[id];
    },
    Listener: function () {
        this.onChanged = function (value, oldValue) { };
        this.onFocus = function (value) { };
    }
};