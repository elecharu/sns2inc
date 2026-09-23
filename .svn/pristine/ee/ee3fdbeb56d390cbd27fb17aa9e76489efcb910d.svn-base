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
        $input.unbind('input');
        $input.on('input', function (e) {
            var telno = $input.attr('data-telno');
            var regno = $input.attr('data-regno');
            var hhmm = $input.attr('data-hhmm');
            var hhmmss = $input.attr('data-hhmmss');
            var hhmm99 = $input.attr('data-hhmm99');
            if (telno == "Y") {
                try {
                    var h = $input.val().replace(/[^0-9]/g, "");
                    if ($input.val().length > 11) {
                        if (h.substring(0, 1) == "1") {
                            if (h.length > 5 && h.length < 8) {
                                $input.val(h.replace(/([0-9]{4})([0-9])/, "$1-$2"));
                            } else {
                                $input.val(h.replace(/(^1.{3})([0-9]{4})/, "$1-$2"));
                            }
                        } else {
                            if ($input.val().indexOf('/') > -1 || $input.val().indexOf('~') > -1) {

                            } else {
                                if (h.length > 3 && h.length < 8) {
                                    $input.val(h.replace(/(^02.{0}|^01.{1}|[0-9]{3})([0-9])/, "$1-$2"));
                                } else if (h.length >= 8 && h.length < 10) {
                                    $input.val($input.val().replace(/[^0-9]/g, "").replace(/(^02.{0}|^01.{1}|[0-9]{3})([0-9]{4})([0-9])/, "$1-$2-$3"));
                                } else {
                                    $input.val($input.val().replace(/[^0-9]/g, "").replace(/(^02.{0}|^01.{1}|[0-9]{3})([0-9]+)([0-9]{4})/, "$1-$2-$3"));
                                }
                            }
                        }
                    }
                } catch(e) { }
            } else if (regno == "Y") {
                try {
                    var h = $input.val().replace(/[^0-9]/g, "");
                    if (h.length == 4 || h.length == 5) {
                        $input.val(h.replace(/([0-9]{3})([0-9])/, "$1-$2"));
                    } else if (h.length > 5 && h.length < 10) {
                        $input.val(h.replace(/([0-9]{3})([0-9]{2})([0-9])/, "$1-$2-$3"));
                    } else {
                        $input.val(h.replace(/([0-9]{3})([0-9]{2})([0-9]{5})/, "$1-$2-$3"));
                    }
                } catch (e) { }
            } else if (hhmm == "Y") {
                try {
                    $input.attr('maxlength', 6);
                    var h = $input.val().replace(/[^0-9]/g, "");

                    var startpos = $input[0].selectionStart;
                    var endpos = $input[0].selectionEnd;

                    if (h.length > 4) {
                        if (startpos < 3)
                            h = h.substring(0, startpos) + h.substring(startpos + 1);
                        else if (startpos < 5)
                            h = h.substring(0, 3) + h.substring(4);
                        else
                            h = h.substring(0, 4);

                        if (startpos == 3) {
                            startpos++;
                            endpos++;
                        }
                    }
                    else if (h.length < 4) {
                        var zerotext = '';
                        for (var i = 0; i < (4 - h.length); i++)
                            zerotext += '0';

                        if (startpos == 0)
                            h = zerotext + h
                        else if (startpos == 1)
                            h = h.substring(0, 1) + zerotext + h.substring(1);
                        else if (startpos < 4)
                            h = h.substring(0, 2) + zerotext + h.substring(2);
                        else
                            h = h + zerotext;
                    }

                    if (h.substring(0, 2) > 23) 
                        h = '00' + h.substring(2);
                    if (h.substring(2) > 59) 
                        h = h.substring(0, 2) + '00';

                    $input.val(h.replace(/([0-9]{2})([0-9]{2})/, "$1:$2"));

                    $input[0].setSelectionRange(startpos, endpos);
                } catch (e) { }
            } else if (hhmmss == "Y") {
                try {
                    $input.attr('maxlength', 9);
                    var h = $input.val().replace(/[^0-9]/g, "");

                    var startpos = $input[0].selectionStart;
                    var endpos = $input[0].selectionEnd;

                    if (h.length > 6) {
                        if (startpos < 3)
                            h = h.substring(0, startpos) + h.substring(startpos + 1);
                        else if (startpos < 5)
                            h = h.substring(0, 3) + h.substring(4);
                        else if (startpos == 5)
                            h = h.substring(0, 4) + h.substring(5);
                        else if (startpos < 8)
                            h = h.substring(0, 5) + h.substring(6);
                        else
                            h = h.substring(0, 6);

                        if (startpos == 3 || startpos == 6) {
                            startpos++;
                            endpos++;
                        }
                    }
                    else if (h.length < 6) {
                        var zerotext = '';
                        for (var i = 0; i < (6 - h.length); i++)
                            zerotext += '0';

                        if (startpos == 0)
                            h = zerotext + h
                        else if (startpos == 1)
                            h = h.substring(0, 1) + zerotext + h.substring(1);
                        else if (startpos < 4)
                            h = h.substring(0, 2) + zerotext + h.substring(2);
                        else if (startpos == 4)
                            h = h.substring(0, 3) + zerotext + h.substring(3);
                        else if (startpos < 7)
                            h = h.substring(0, 4) + zerotext + h.substring(4);
                        else
                            h = h + zerotext;
                    }

                    if (h.substring(0, 2) > 23)
                        h = '00' + h.substring(2);
                    if (h.substr(2, 2) > 59)
                        h = h.substring(0, 2) + '00' + h.substring(4);
                    if (h.substring(4) > 59)
                        h = h.substring(0, 4) + '00';

                    $input.val(h.replace(/([0-9]{2})([0-9]{2})([0-9]{2})/, "$1:$2:$3"));

                    $input[0].setSelectionRange(startpos, endpos);
                } catch (e) { }
            }
            else if (hhmm99 == "Y") {
                try {
                    $input.attr('maxlength', 6);
                    var h = $input.val().replace(/[^0-9]/g, "");

                    var startpos = $input[0].selectionStart;
                    var endpos = $input[0].selectionEnd;

                    if (h.length > 4) {
                        if (startpos < 3)
                            h = h.substring(0, startpos) + h.substring(startpos + 1);
                        else if (startpos < 5)
                            h = h.substring(0, 3) + h.substring(4);
                        else
                            h = h.substring(0, 4);

                        if (startpos == 3) {
                            startpos++;
                            endpos++;
                        }
                    }
                    else if (h.length < 4) {
                        var zerotext = '';
                        for (var i = 0; i < (4 - h.length) ; i++)
                            zerotext += '0';

                        if (startpos == 0)
                            h = zerotext + h
                        else if (startpos == 1)
                            h = h.substring(0, 1) + zerotext + h.substring(1);
                        else if (startpos < 4)
                            h = h.substring(0, 2) + zerotext + h.substring(2);
                        else
                            h = h + zerotext;
                    }

                    if (h.substring(2) > 59)
                        h = h.substring(0, 2) + '00';

                    $input.val(h.replace(/([0-9]{2})([0-9]{2})/, "$1:$2"));

                    $input[0].setSelectionRange(startpos, endpos);
                } catch (e) { }
            }
        });
    },
    Reset: function () {
        $('div.ItsText_table > input').each(function () {
            ItsText._Reset($(this));
        });
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