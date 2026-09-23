/// <reference path="../Script/reference.js" />
var ItsDateRange = {
    _Reset: function ($input, $flag) {
        var $calendar = $input.siblings('.ItsControl_pop').find('.ItsDateRange_calendar_' + $flag);
        $calendar.datetimepicker({
            language: 'kr',
            format: 'yyyy-mm-dd',
            weekStart: 0,
            todayBtn: true,
            todayHighlight: true,
            autoclose: false,
            todayHighlight: 1,
            startView: 2,
            showMeridian: 1,
            minView: 2,
            forceParse: true
        }).on('changeDate', function () {

            $('div.ItsDateRange_btn').css('background-color', 'white');

            var date = $(this).datetimepicker('getDate');
            $input.val(date.format("yyyy-MM-dd"));

            var id = $input[0].id;
            id = id.substr(0, id.length - 2);
            if ($('input#' + id + '_F').val() > $('input#' + id + '_T').val()) {
                $('input#' + id + '_F').val(date.format("yyyy-MM-dd"))
                $('input#' + id + '_T').val(date.format("yyyy-MM-dd"));
                $('input#' + id + '_F').siblings('.ItsControl_pop').find('.ItsDateRange_calendar_F').datetimepicker('setDate', new Date(date.format("yyyy-MM-dd")));
                $('input#' + id + '_T').siblings('.ItsControl_pop').find('.ItsDateRange_calendar_T').datetimepicker('setDate', new Date(date.format("yyyy-MM-dd")));
            }

        });

        $input.mask("0000-00-00");

        $input.unbind('focus');
        $input.on('focus', function () {
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

            var value = $input.val();
            $input.attr('data-oldvalue', value);
            var id = $input[0].id;
            if (id != undefined && id != null && id != "") {
                id = id.substr(0, id.length - 2); // _F, _T 제거
                var fromValue = $('input#' + id + '_F').val();
                var toValue = $('input#' + id + '_F').val();
                ItsDateRange.Event(id).onFocus(fromValue, toValue);
            };
        });
        $input.unbind('change');
        $input.on('change', function () {
            var value = $input.val();
            $calendar.datetimepicker('setDate', new Date(value));
            var id = $input[0].id;
            if (id != undefined && id != null && id != "") {

                id = id.substr(0, id.length - 2); // _F, _T 제거
                var valueFrom = $('input#' + id + '_F').val();
                var valueTo = $('input#' + id + '_T').val();
                var oldValueFrom = $('input#' + id + '_F').attr('data-oldvalue');
                var oldValueTo = $('input#' + id + '_T').attr('data-oldvalue');
                ItsDateRange.Event(id).onChanged(valueFrom, oldValueFrom, valueTo, oldValueTo);
            }
        });
    },

    Reset: function () {
        $('div.ItsDateRange_box > input.ItsDateRange_F').each(function (index) {
            ItsDateRange._Reset($(this), "F");
        });
        $('div.ItsDateRange_box > input.ItsDateRange_T').each(function (index) {
            ItsDateRange._Reset($(this), "T");
        });
        $('div.ItsDateRange_box').unbind('mouseup');
        $('div.ItsDateRange_box').on('mouseup', function (e) {
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
            // 읽기 전용 시 빠져나가기
            var $main = $(this).parent().parent();
            if ($main.attr('readonly') == 'readonly') {
                return;
            }

            e.stopPropagation();

            var $pop = $(this).children('.ItsControl_pop');
            if ($pop.css('display') == 'none') {
                $('.ItsControl_pop').css('display', 'none'); // 모든 컨트롤 팝업 다 닫기
                $pop.css('display', '');
                var fromDate = $pop.siblings('input.ItsDateRange_F').val();
                var toDate = $pop.siblings('input.ItsDateRange_T').val();
                $pop.find('div.ItsDateRange_calendar_F').datetimepicker('setDate', new Date(fromDate));
                $pop.find('div.ItsDateRange_calendar_T').datetimepicker('setDate', new Date(toDate));
            }
        });

        $('div.ItsDateRange_close').on('click', function () {
            var $pop = $(this).parent().parent();
            var fromDate = $pop.find('div.ItsDateRange_calendar_F').datetimepicker('getDate');
            var toDate = $pop.find('div.ItsDateRange_calendar_T').datetimepicker('getDate');

            $pop.siblings('input.ItsDateRange_F').val(fromDate.format("yyyy-MM-dd"));
            $pop.siblings('input.ItsDateRange_T').val(toDate.format("yyyy-MM-dd"));

            $pop.css('display', 'none');
        });

        // 2020-03-03 기간 설정 버튼 추가 문재원
        $('div.ItsDateRange_btn').on('click', function () {

            $('div.ItsDateRange_btn').css('background-color', 'white');
            $(this).css('background-color', '#fde49a');

            var $pop = $(this).parent().parent();
            var $range = $(this).data('btnrange');

            if ($range.indexOf('d') > -1) {
                var fromDate = ItsHelper.AddDay($range.replace('d', '') * -1);
            } else if ($range.indexOf('m') > -1) {
                var fromDate = ItsHelper.AddMonth($range.replace('m', '') * -1);
            } else {
                var fromDate = ItsHelper.GetYearMonthDay();
            }
            var toDate = ItsHelper.GetYearMonthDay();

            $pop.find('div.ItsDateRange_calendar_F').datetimepicker('setDate', new Date(fromDate));
            $pop.find('div.ItsDateRange_calendar_T').datetimepicker('setDate', new Date(toDate));

            $pop.siblings('input.ItsDateRange_F').val(fromDate);
            $pop.siblings('input.ItsDateRange_T').val(toDate);

        });

        $('ItsDateRange_F').add('ItsDateRange_T').on('focusout', function () {
            $('.ItsDateRange_box > .ItsControl_pop').hide();
            try { $(this).datetimepicker('hide'); } catch (e) { }
        });
    },
    SetValueFrom: function (id, value) {
        var $input = $('input#' + id + '_F');
        $input.attr('data-value', value);
        $input.val(value);
        $input.trigger('change');
    },
    SetValueTo: function (id, value) {
        var $input = $('input#' + id + '_T');
        $input.attr('data-value', value);
        $input.val(value);
        $input.trigger('change');
    },
    SetInitValueFrom: function (id, value) {
        var $input = $('input#' + id + "_F");
        $input.val(value);
        $input.attr('data-value', value);
        $input.attr('data-default', value);
    },
    SetInitValueTo: function (id, value) {
        var $input = $('input#' + id + "_T");
        $input.val(value);
        $input.attr('data-value', value);
        $input.attr('data-default', value);
    },
    GetValueFrom: function (id) {
        var $input = $('input#' + id + "_F");
        return $input.val();
    },
    GetValueTo: function (id) {
        var $input = $('input#' + id + "_T");
        return $input.val();
    },
    GetFieldFrom: function (id) {
        var $input = $('input#' + id + "_F");
        return $input.attr('data-field');
    },
    GetFieldTo: function (id) {
        var $input = $('input#' + id + "_T");
        return $input.attr('data-field');
    },
    SetInitFrom: function (id) {
        var $input = $('input#' + id + "_F");
        var defaultValue = $input.attr('data-default');
        $input.attr('data-value', defaultValue);
        $input.val(defaultValue);
    },
    SetInitTo: function (id) {
        var $input = $('input#' + id + '_T');
        var defaultValue = $input.attr('data-default');
        $input.attr('data-value', defaultValue);
        $input.val(defaultValue);
    },
    SetInitObjFrom: function (obj) {
        var $input = obj.find('input.ItsFieldFrom');
        var defaultValue = $input.attr('data-default');
        $input.attr('data-value', defaultValue);
        $input.val(defaultValue);
    },
    SetInitObjTo: function (obj) {
        var $input = obj.find('input.ItsFieldTo');
        var defaultValue = $input.attr('data-default');
        $input.attr('data-value', defaultValue);
        $input.val(defaultValue);
    },
    Disable: function (id) {
        var $input = $('input#' + id + '_F');
        ItsDateRange.DisableObj($input);
    },
    DisableObj: function ($input) {
        $input.css('background-color', 'aliceblue');
        $inputT = $input.siblings('input');
        $inputT.css('background-color', 'aliceblue');
        $inputT.parent().parent().attr('readonly', 'readonly');
        return true;
    },
    Enable: function (id) {
        var $input = $('input#' + id + '_F');
        ItsDateRange.EnableObj($input);
    },
    EnableObj: function ($input) {
        $input.css('background-color', 'white');
        $inputT = $input.siblings('input');
        $inputT.css('background-color', 'white');
        $inputT.parent().parent().parent().removeAttr('readonly');
        return false;
    },
    Hide: function (id) {
        var $input = $('input#' + id + '_F');
        $input.parent().parent().parent().css('display', 'none');
        return true;
    },
    Show: function (id) {
        var $input = $('input#' + id + '_F');
        $input.parent().parent().parent().css('display', '');
        return false;
    },
    Focus: function (id) {
        var $input = $('input#' + id + '_F');
        setTimeout(function () {
            $input.focus();
        }, 1);
    },
    SetLabel: function (id, text) {
        $('input#' + id + '_F').parent().siblings('span').text(text);
    },
    /** 
    @returns {ItsCombo.Listener} 
    */
    Event: function (id) {
        if (ItsPage.EventList[id] == undefined) {
            ItsPage.EventList[id] = new ItsDateRange.Listener();
        }
        return ItsPage.EventList[id];
    },
    Listener: function () {
        this.onChanged = function (valueFrom, oldValueFrom, valueTo, oldValueTo) { };
        this.onFocus = function (valueFrom, valueFrom) { };
    }
};
ItsDateRange.drClose = function (sender) {
    $('.ItsDateRange_box > .ItsControl_pop').hide();
};