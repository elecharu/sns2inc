/// <reference path="../Script/reference.js" />
var ItsOnoff = {
    _Reset: function ($button) {
        $button.unbind('click');
        $button.on('click', function (e) {
            if ($button.attr('data-readonly') == 'true') {
                return false;
            }
            var value = $button.attr('data-value');
            var $cnVal = true;
            if (value == 'Y') {
                $cnVal = false;
            }
            ItsOnoff.$changeState($button, $cnVal);
            var key = $button.attr('id');
            if (key != undefined && key != null && key != "") {
                ItsOnoff.Event(key).onChanged($cnVal);
            }
        });
        $button.unbind('keydown');
        $button.on('keydown', function (e) {
            if (e.keyCode == 32) {
                $(this).trigger('click');
            }
        });
    },
    Reset: function () {
        $('div.ItsOnoff_button').each(function () {
            ItsOnoff._Reset($(this));
            var $cnVal = false;
            if ($(this).attr('data-value') == 'Y') {
                $cnVal = true;
                $(this).attr('data-value', 'N');
            } else {
                $(this).attr('data-value', 'Y');
            }
            ItsOnoff.$changeState($(this), $cnVal);
        });
    },
    SetValue: function (id, value) {
        var $input = $('div#' + id);
        ItsOnoff.$changeState($input, value);
        if (value == true || value == 'Y') {
            value = true;
        } else {
            value = false;
        }
        ItsOnoff.Event(id).onChanged(value);
    },
    SetInitValue: function (id, value) {
        var $input = $('div#' + id);
        ItsOnoff.$changeState($input, value);
        $input.attr('data-default', value);
    },
    GetValue: function (id) {
        var $input = $('div#' + id);
        return $input.attr('data-value');
    },
    SetInit: function (id) {
        var $input = $('div#' + id);
        $input.attr('data-offcolor', '');
        var defaultValue = $input.attr('data-default');
        ItsOnoff.$changeState($input, defaultValue);
    },
    SetInitObj: function (obj) {
        obj.attr('data-offcolor', '');
        var defaultValue = obj.attr('data-default');
        ItsOnoff.$changeState(obj, defaultValue);
    },
    GetField: function (id) {
        var $input = $('div#' + id);
        return $input.attr('data-field');
    },
    Disable: function (id) {
        var $input = $('div#' + id);
        ItsOnoff.DisableObj($input);
    },
    DisableObj: function ($input) {
        $input.attr('data-readonly', 'true');
    },
    Enable: function (id) {
        var $input = $('div#' + id);
        ItsOnoff.EnableObj($input);
    },
    EnableObj: function ($input) {
        $input.attr('data-readonly', 'false');
    },
    Hide: function (id) {
        var $input = $('div#' + id);
        $input.parent().parent().css('display', 'none');
    },
    Show: function (id) {
        var $input = $('div#' + id);
        $input.parent().parent().css('display', '');
    },
    Focus: function (id) {
        var $input = $('div#' + id);
        setTimeout(function () {
            $input.focus();
        }, 1);
    },
    SetLabel: function (id, text) {
        $('#' + id).siblings('span').text(text);
    },
    SetOnColor: function (id, value) {
        var $input = $('div#' + id);
        $input.attr('data-oncolor', value);

        var $cnVal = false;
        if ($input.attr('data-value') == 'Y') {
            $cnVal = true;
            $input.attr('data-value', 'N');
        } else {
            $input.attr('data-value', 'Y');
        }
        ItsOnoff.$changeState($input, $cnVal);
    },
    SetOffColor: function (id, value) {
        var $input = $('div#' + id);
        $input.attr('data-offcolor', value);

        var $cnVal = false;
        if ($input.attr('data-value') == 'Y') {
            $cnVal = true;
            $input.attr('data-value', 'N');
        } else {
            $input.attr('data-value', 'Y');
        }
        ItsOnoff.$changeState($input, $cnVal);
    },
    /** 
    @returns {ItsOnoff.Listener} 
    */
    Event: function (key) {
        if (ItsPage.EventList[key] == undefined) {
            ItsPage.EventList[key] = new ItsOnoff.Listener();
        }
        return ItsPage.EventList[key];
    },
    Listener: function () {
        this.onChanged = function (newValue) { };
    }
};

//2018-11-22 수정자 : 왕현준
//On Off 버튼 디자인 변경, 각 버튼별 색상 변경 가능하도록 하는 함수 추가
ItsOnoff.$changeState = function (obj, value) {
    var $icon = obj.find('strong').eq(0);
    var $span = obj.find('span').eq(0);
    var $value = obj.attr('data-value');
    var $key = obj.attr('id');
    var $oncolor = obj.attr('data-oncolor');
    var $offcolor = obj.attr('data-offcolor');

    $icon.css('background-color', '');

    if (value == true || value == 'Y') {
        value = 'Y';
        if ($value == value) return;
        $span.insertAfter($icon);
        $span.text(obj.attr('data-offtext'));
        $icon.text(obj.attr('data-ontext'));
        $icon.removeClass('ItsOnoff_button_off');
        $icon.addClass('ItsOnoff_button_on');
        obj.attr('data-value', 'Y');
        if ($oncolor != '') {
            $icon.css('background-color', $oncolor);
        }
    } else if (value == false || value == 'N') {
        value = 'N';
        if ($value == value) return;
        $icon.insertAfter($span);
        $span.text(obj.attr('data-ontext'));
        $icon.text(obj.attr('data-offtext'));
        $icon.removeClass('ItsOnoff_button_on');
        $icon.addClass('ItsOnoff_button_off');
        obj.attr('data-value', 'N');
        if ($offcolor != '') {
            $icon.css('background-color', $offcolor);
        }
    }
    
};