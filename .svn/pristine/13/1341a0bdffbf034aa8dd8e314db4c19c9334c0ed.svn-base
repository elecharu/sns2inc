/// <reference path="../Script/reference.js" />
var ItsText = {
    _Reset: function ($input) {
        var $mask = $input.attr('data-mask');
        if ($mask != undefined && $mask != '' && $mask != null) {
            $input.mask($mask);
        };

        $input.unbind('focus');
        $input.on('focus', function () {
            var value = $input.val();
            $input.attr('data-oldvalue', value);
            var key = $input[0].id;
            if (key != undefined && key != null && key != "") {
                ItsText.Event(key).onFocus(value);
            }
        });
        $input.unbind('change');
        $input.on('change', function () {
            var value = $input.val();
            var id = $input[0].id;
            if (id != undefined && id != null && id != "") {
                var oldValue = $input.attr('data-oldvalue');
                ItsText.Event(id).onChanged(value, oldValue);
            }
        });
        $input.unbind('keydown');
        $input.on('keydown', function (e) {
            var value = $input.val();
            var keyCode = e.keyCode;
            var key = $input[0].id;
            var oldValue = $input.attr('data-oldvalue');
            if (key != undefined && key != null && key != "") {
                if (keyCode == EnumKeys.Enter) {
                    ItsText.Event(key).onKeyEnter(value, oldValue);
                } else {
                    ItsText.Event(key).onKeyDown(value, keyCode);
                }
            }
        });
    },
    Reset: function () {
        $('div.ItsText_table > input').each(function () {
            ItsText._Reset($(this));
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
        $input.attr('data-default', value);
        $input.attr('data-value', value);
    },
    GetValue: function (id) {
        var $input = $('input#' + id);
        return $input.val();
    },
    SetInit: function(id) {
        var $input = $('input#' + id);
        var defaultValue = $input.attr('data-default');
        $input.attr('data-value', defaultValue);
        $input.val(defaultValue);
    },
    SetInitObj: function(obj) {
        var $input = obj.find('input.ItsField');
        var defaultValue = $input.attr('data-default');
        $input.attr('data-value', defaultValue);
        $input.val(defaultValue);
    },
    GetField: function(id) {
        var $input = $('input#' + id);
        return $input.attr('data-field');
    },
    Disable: function (id) {
        var $input = $('input#' + id);
        ItsText.DisableObj($input);
    },
    DisableObj: function ($input) {
        $input.attr('readonly', 'readonly');
        $input.attr('tabindex', -1);
        return true;
    },
    Enable: function (id) {
        var $input = $('input#' + id);
        ItsText.EnableObj($input);
    },
    EnableObj: function ($input) {
        $input.removeAttr('readonly');
        $input.removeAttr('tabindex');
        return false;
    },
    Hide: function (id) {
        var $input = $('input#' + id);
        $input.parent().parent().css('display', 'none');
        return true;
    },
    Show: function (id) {
        var $input = $('input#' + id);
        $input.parent().parent().css('display', '');
        return false;
    },
    Focus: function (id) {
        var $input = $('input#' + id);
        setTimeout(function () {
            $input.focus();
        }, 1);
    },
    SetLabel: function (id, text) {
        $('#' + id).siblings('span').text(text);
    },
    /** 
    @returns {ItsText.Listener} 
    */
    Event: function (id) {
        if (ItsPage.EventList[id] == undefined) {
            ItsPage.EventList[id] = new ItsText.Listener();
        }
        return ItsPage.EventList[id];
    },
    Listener: function () {
        this.onChanged = function (value, oldValue) { };
        this.onKeyEnter = function (value, oldValue) { };
        this.onKeyDown = function (value, keyCode) { };
        this.onFocus = function (value) { };
    }
};