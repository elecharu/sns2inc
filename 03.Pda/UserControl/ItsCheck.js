/// <reference path="../Script/reference.js" />
var ItsCheck = {
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
            ItsCheck.$changeState($button, $cnVal);
        });
        $button.unbind('keydown');
        $button.on('keydown', function (e) {
            if (e.keyCode == 32) {
                $(this).trigger('click');
            }
        });
    },
    Reset: function () {
        $('div.ItsCheck_button').each(function () {
            ItsCheck._Reset($(this));
            var $cnVal = false;
            if ($(this).attr('data-value') == 'Y') {
                $cnVal = true;
                $(this).attr('data-value', 'N');
            } else {
                $(this).attr('data-value', 'Y');
            }
            ItsCheck.$changeState($(this), $cnVal, true);
        });
    },
    SetValue: function (id, value) {
        var $input = $('div#' + id);
        ItsCheck.$changeState($input, value);
    },
    SetInitValue: function (id, value) {
        var $input = $('div#' + id);
        ItsCheck.$changeState($input, value);
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
        ItsCheck.$changeState($input, defaultValue);
    },
    SetInitObj: function (obj) {
        obj.attr('data-offcolor', '');
        var defaultValue = obj.attr('data-default');
        ItsCheck.$changeState(obj, defaultValue);
    },
    GetField: function (id) {
        var $input = $('div#' + id);
        return $input.attr('data-field');
    },
    Disable: function (id) {
        var $input = $('div#' + id);
        ItsCheck.DisableObj($input);
    },
    DisableObj: function ($input) {
        $input.attr('data-readonly', 'true');
    },
    Enable: function (id) {
        var $input = $('div#' + id);
        ItsCheck.EnableObj($input);
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
    /** 
    @returns {ItsCheck.Listener} 
    */
    Event: function (key) {
        if (ItsPage.EventList[key] == undefined) {
            ItsPage.EventList[key] = new ItsCheck.Listener();
        }
        return ItsPage.EventList[key];
    },
    Listener: function () {
        this.onChanged = function (newValue) { };
    }
};

ItsCheck.$changeState = function (obj, value, isInit) {
    var $icon = obj.find('i').eq(0);
    var $value = obj.attr('data-value');
    var ev = true;
    var $key = obj.attr('id');

    $icon.css('background-color', '');

    if (value == true || value == 'Y') {
        value = 'Y';
        if ($value == value) return;
        $icon.text(obj.attr('data-ontext'));
        $icon.removeClass('fa-square-o');
        $icon.addClass('fa-check-square-o');
        obj.attr('data-value', 'Y');

    } else if (value == false || value == 'N') {
        value = 'N';
        ev = false;
        if ($value == value) return;
        $icon.text(obj.attr('data-offtext'));
        $icon.removeClass('fa-check-square-o');
        $icon.addClass('fa-square-o');
        obj.attr('data-value', 'N');
    }
    if (isInit != true) {
        if ($key != undefined && $key != null && $key != "") {
            ItsCheck.Event($key).onChanged(ev);
        }
    }
    
};