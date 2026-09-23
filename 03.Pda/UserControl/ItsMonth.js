/// <reference path="../Script/reference.js" />
var ItsMonth = {
    _Reset: function ($input) {

        $input.unbind('focus');
        $input.on('focus', function () {
            var value = $input.val();
            $input.attr('data-oldvalue', value);
            var id = $input[0].id;
            if (id != undefined && id != null && id != "") {
                ItsMonth.Event(id).onFocus(value);
            }
        });
        $input.unbind('change');
        $input.on('change', function () {
            var value = $input.val();
            var id = $input[0].id;
            if (id != undefined && id != null && id != "") {
                var oldValue = $input.attr('data-oldvalue');
                ItsMonth.Event(id).onChanged(value, oldValue);
            }
        });

        $input.datetimepicker({
            language: 'kr',
            format: 'yyyy-mm',
            weekStart: 0,
            todayBtn: true,
            todayHighlight: true,
            autoclose: true,
            todayHighlight: 1,
            startView: 3,
            showMeridian: 1,
            minView: 3,
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
            var $main = $(this).parent().parent().parent();
            if ($main.attr('readonly') == 'readonly') {
                $(this).datetimepicker('hide');
                return;
            }

            $(this).data('enterclose', 'Y');
            $(this).data('isopen', 'Y');
            $('.ItsControl_pop').css('display', 'none');
        }).on('hide', function () {
            $(this).data('isopen', 'N');
        }).on('keydown', function (e) {
            if (e.keyCode == EnumKeys.Esc) {
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
        $input.mask("0000-00");

        $input.parent('div.ItsMonth_box').unbind('mouseup');
        $input.parent('div.ItsMonth_box').on('mouseup', function (e) {
            $input.trigger('focus');
        });
    },

    Reset: function () {
        $('div.ItsMonth_box > input').each(function () {
            ItsMonth._Reset($(this));
        });
    },
    SetValue: function (id, value) {
        var $input = $('input#' + id);
        $input.attr('data-value', value);
        $input.val(value);
        $input.trigger('change');
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
        ItsMonth.DisableObj($input);
    },
    DisableObj: function ($input) {
        $input.css('background-color', 'aliceblue');
        $input.parent().parent().attr('readonly', 'readonly');
        return true;
    },
    Enable: function (id) {
        var $input = $('input#' + id);
        ItsMonth.EnableObj($input);
    },
    EnableObj: function ($input) {
        $input.css('background-color', 'white');
        $input.parent().parent().parent().removeAttr('readonly');
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