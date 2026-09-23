/// <reference path="../Script/reference.js" />
var ItsLabel = {
    Style: {
        Width: 'width',
        BackColor: 'background-color',
        fontSize: 'font-size',
        Bold: 'font-weight',
        Italic: 'font-style',
        ForeColor: 'color',
        Align: 'text-align'
    },
    SetStyle: function (id, attr, value) {
        if (attr == 'width') {
            $('#' + id).css(attr, value);
        } else if (attr == 'background-color') {
            $('#' + id).parent().css(attr, value);
        } else if (attr == 'font-size') {
            if (attr.indexOf('px') > -1) attr += 'px';
        } else if (attr == 'font-weight') {
            if(value)
                $('#' + id).css(attr, 'bold');
            else 
                $('#' + id).css(attr, '');
        } else if (attr == 'font-style') {
            if (value)
                $('#' + id).css(attr, 'italic');
            else
                $('#' + id).css(attr, '');
        } else if (attr == 'color') {
            $('#' + id).css(attr, value);
        } else if (attr == 'text-align') {
            $('#' + id).css(attr, value);
        }
    },
    SetText: function (id, text) {
        $('#' + id).text(text);
    },
    Hide: function (id) {
        var $span = $('span#' + id);
        $span.parent().parent().css('display', 'none');
        return true;
    },
    Show: function (id) {
        var $span = $('span#' + id);
        $span.parent().parent().css('display', '');
        return false;
    }
};