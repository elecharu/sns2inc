/// <reference path="../Script/reference.js" />
var ItsTextArea = {
    _Reset: function ($input) {
        $input.unbind('focus');
        $input.on('focus', function () {
            var value = $input.val();
            $input.attr('data-oldvalue', value);
            var key = $input[0].id;
            if (key != undefined && key != null && key != "") {
                ItsTextArea.Event(key).onFocus(value);
            }
        });
        $input.unbind('change');
        $input.on('change', function () {
            var value = $input.val();
            var id = $input[0].id;
            if (id != undefined && id != null && id != "") {
                var oldValue = $input.attr('data-oldvalue');
                ItsTextArea.Event(id).onChanged(value, oldValue);
            }
        });
        $input.unbind('keydown');
        $input.on('keydown', function (e) {
            var value = $input.val();
            var keyCode = e.keyCode;
            var key = $input[0].id;
            if (key != undefined && key != null && key != "") {
                if (keyCode == EnumKeys.Enter) {
                    ItsTextArea.Event(key).onKeyEnter(value);
                } else {
                    ItsTextArea.Event(key).onKeyDown(value, keyCode);
                }
            }
        });
    },
    Reset: function() {
        $('div.ItsTextArea_table > textarea').each(function () {
            ItsTextArea._Reset($(this));
        });
    },
    SetValue: function (id, value) {
        var $input = $('textarea#' + id);
        $input.val(value);
    },
    SetInitValue: function (id, value) {
        var $input = $('textarea#' + id);
        $input.val(value);
        $input.attr('data-value', value);
        $input.attr('data-default', value);
    },
    GetValue: function (id) {
        var $input = $('textarea#' + id);
        return $input.val();
    },
    GetField: function(id) {
        var $input = $('textarea#' + id);
        return $input.attr('data-field');
    },
    SetInit: function (id) {
        var $input = $('textarea#' + id);
        var defaultValue = $input.attr('data-default');
        $input.attr('data-value', defaultValue);
        $input.val(defaultValue);
    },
    SetInitObj: function (obj) {
        var $input = obj.find('textarea.ItsField');
        var defaultValue = $input.attr('data-default');
        $input.attr('data-value', defaultValue);
        $input.val(defaultValue);
    },
    Disable: function (id) {
        var $input = $('textarea#' + id);
        ItsTextArea.DisableObj($input);
    },
    DisableObj: function ($input) {
        $input.attr('readonly', 'readonly');
    },
    Enable: function (id) {
        var $input = $('textarea#' + id);
        ItsTextArea.EnableObj($input);
    },
    EnableObj: function ($input) {
        $input.removeAttr('readonly');
    },
    Hide: function (id) {
        var $input = $('textarea#' + id);
        $input.parent().parent().css('display', 'none');
    },
    Show: function (id) {
        var $input = $('textarea#' + id);
        $input.parent().parent().css('display', '');
    },
    Focus: function (id) {
        var $input = $('textarea#' + id);
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
        this.onKeyEnter = function (value) { };
        this.onKeyDown = function (value, keyCode) { };
        this.onFocus = function (value) { };
    }
};