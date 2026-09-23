/// <reference path="../Script/reference.js" />
var ItsDisplay = {
    SetValue: function (id, value) {
        var $input = $('span#' + id);
        $input.attr('data-value', value);
        $input.text(value);
    },
    SetInitValue: function (id, value) {
        var $input = $('span#' + id);
        $input.val(value);
        $input.attr('data-value', value);
        $input.attr('data-default', value);
    },
    GetValue: function (id) {
        var $input = $('span#' + id);
        return $input.text();
    },
    SetInit: function(id) {
        var $input = $('span#' + id);
        var defaultValue = $input.attr('data-default');
        $input.attr('data-value', defaultValue);
        $input.text(defaultValue);
    },
    SetInitObj: function(obj) {
        var $input = obj.find('span.ItsField');
        var defaultValue = $input.attr('data-default');
        $input.attr('data-value', defaultValue);
        $input.text(defaultValue);
    },
    GetField: function(id) {
        var $input = $('span#' + id);
        return $input.attr('data-field');
    },
    Hide: function (id) {
        var $input = $('span#' + id);
        $input.parent().parent().css('display', 'none');
        return true;
    },
    Show: function (id) {
        var $input = $('span#' + id);
        $input.parent().parent().css('display', '');
        return false;
    },
    SetLabel: function (id, text) {
        $('#' + id).siblings('span').text(text);
    }
};