/// <reference path="../Script/reference.js" />
var ItsRadio = {
    _Reset: function ($input) {
        gpcd = $input.attr('data-gpcd');
        ref01 = $input.attr('data-ref01');
        ref02 = $input.attr('data-ref02');
        ref03 = $input.attr('data-ref03');
        ref04 = $input.attr('data-ref04');
        ref05 = $input.attr('data-ref05');
        length = $input.attr('data-length');
        field = $input.attr('data-field');
        marginItem = $input.attr('data-marginitem');
        if ($input.attr('data-name') != undefined && $input.attr('data-name') != '') {
            name = $input.attr('data-name');
        } else {
            name = $input.attr('data-field');
        }

        if (field == "") {
            ItsMsg.Alert('AddRadioTag must have field');
            return;
        }

        if (gpcd != "") {
            var params = "GPCD=" + gpcd;
            params += "&REF01=" + ref01 + "&REF02=" + ref02 + "&REF03=" + ref03;
            params += "&REF04=" + ref04 + "&REF05=" + ref05 + "&LENGTH=" + length;
            params += "&FIELD=" + field + "&NAME=" + name + "&MARGINITEM=" + marginItem;
            $.ajaxSetup({ async: false });
            $.post("../../Service/LiList/Radio.aspx", params, function (data) {
                $input.html($input.html() + data);
            });
        }

        if ($input.parent().attr('readonly') == 'readonly') {
            var $div = $('div#' + $input[0].id);
            ItsRadio.DisableObj($div);
        }
        
        $input.unbind('change');
        $input.on('change', function (e) {
            var value = $input.children('input:checked').attr('data-value');
            var id = $input[0].id;
            if (id != undefined && id != null && id != "") {
                var oldValue = $input.attr('data-value');
                $input.attr('data-value', value);
                ItsRadio.Event(id).onChanged(value, oldValue);
            }
        });
    },
    Reset: function () {
        $('div.ItsRadio_table').each(function () {
            ItsRadio._Reset($(this));
        });
        for (var i = 0; i < $('.ItsRadio_input').length; i++) {
            $('.ItsRadio_input').eq(i).attr('id', 'ItsRadioInputId' + i.toString());
            $('.ItsRadio_input').eq(i).next().attr('for', 'ItsRadioInputId' + i.toString());
        }
    },
    Default: function (id, bool) {
        if (bool) {
            var $div = $('div#' + id);
            $div.children('input').removeAttr("checked");
            var $input = $div.children('input').eq(0);
            $input.prop("checked", true);
        }
    },

    SetValue: function (id, value, isChangeEvent) {
        var $div = $('div#' + id);
        var $oldValue = $div.attr('data-value');
        var $input = $div.children('input').filter('[data-value="' + value + '"]');
   
        if (value == '') {
            return;
        }

        $div.attr('data-value', value);
        if ($input == undefined || $input == null || $input.length == 0) {
            $div.css('color', 'red');
            $input.prop("checked", true);
            
        } else {
            var label = $input.attr('data-label');
            $div.css('color', '');
            $input.prop("checked", true);
            
        }
        if (isChangeEvent != false) {
            ItsRadio.Event(id).onChanged(value, $oldValue);
        }
    },

    SetInitValue: function (id, value) {
        var $div = $('div#' + id);
        $div.attr('data-default', value);
        ItsRadio.SetValue(id, value);
    },
    GetValue: function (id) {
        var $div = $('div#' + id);
        var $input = $div.children('input:checked');
        return $input.attr('data-value');
    },
    GetField: function (id) {
        var $div = $('div#' + id);
        var $input = $div.children('input:checked');
        return $input.attr('data-field');
    },
    GetRefValue: function (id, refName) {
        var $input = $('#' + id);
        var $value = $input.attr('data-value');
        var $liList = $input.find('input');
        var $refValue = "";
        for (var i = 0; i < $liList.length; i++) {
            if ($liList.eq(i).attr('data-value') == $value) {
                $refValue = $liList.eq(i).attr('data-' + refName.toLowerCase());
            }
        }
        return $refValue;
    },
    GetValueByRefValue: function (id, refName, refValue) {
        $('#' + id).find('input').each(function () {
            if ($(this).attr('data-' + refName.toLowerCase()) == refValue) {
                return $(this).attr('data-value');
            }
        })
    },
    SetValueByRefValue: function (id, refName, refValue) {
        $('#' + id).find('input').each(function () {
            if ($(this).attr('data-' + refName.toLowerCase()) == refValue) {
                ItsRadio.SetValue(id, $(this).attr('data-value'))
            }
        })
    },
    HideItem: function(id, value) {
        var $input = $('#' + id);
        $('#' + id).find('input').each(function () {
            if ($(this).attr('data-value') == value) {
                $(this).css('display', 'none');
                $(this).next().css('display', 'none');
            }
        })
    },
    ShowItem: function (id, value) {
        var $input = $('#' + id);
        $('#' + id).find('input').each(function () {
            if ($(this).attr('data-value') == value) {
                $(this).css('display', 'inline');
                $(this).next().css('display', 'inline');
            }
        })
    },
    Reload: function (id) {
        var $radio = $("#" + id);
        gpcd = $radio.attr('data-gpcd');
        ref01 = $radio.attr('data-ref01');
        ref02 = $radio.attr('data-ref02');
        ref03 = $radio.attr('data-ref03');
        ref04 = $radio.attr('data-ref04');
        ref05 = $radio.attr('data-ref05');
        length = $radio.attr('data-length');
        field = $radio.attr('data-field');
        marginItem = $input.attr('data-marginitem');
        if ($input.attr('data-name') != undefined && $input.attr('data-name') != '') {
            name = $input.attr('data-name');
        } else {
            name = $input.attr('data-field');
        }

        var params = "GPCD=" + gpcd;
        params += "&REF01=" + ref01 + "&REF02=" + ref02 + "&REF03=" + ref03;
        params += "&REF04=" + ref04 + "&REF05=" + ref05 + "&LENGTH=" + length;
        params += "&FIELD=" + field + "&NAME=" + name + "&MARGINITEM=" + marginItem;
        $.post("../../Service/LiList/Radio.aspx", params, function (data) {
            $radio.html(data);
            ItsRadio.Reset();
        });
    },
    SetInit: function (id) {
        var $div = $('div#' + id);
        ItsRadio.SetInitObj($div);
    },
    SetInitObj: function (obj) {

        var value = obj.attr('data-default');
        var $div = obj;
        var $oldValue = $div.attr('data-value');
        var $input = $div.children('input').filter('[data-value="' + value + '"]');
        $div.children('input:checked').prop("checked", false);

        if (value == '') {
            return;
        }

        $div.attr('data-value', value);
        if ($input == undefined || $input == null || $input.length == 0) {
            $div.attr('data-label', value);
            $div.val(value);
            //$div.css('color', 'red');
            
            $input.prop("checked", true);
        } else {
            var label = $input.attr('data-label');
            $div.attr('data-label', label);
            $div.val(label);
            //$div.css('color', '');
            
            $input.prop("checked", true);
        }

        var id = $div.attr('id');

        ItsRadio.Event(id).onChanged(value, $oldValue);
    },
    Disable: function (id) {
        var $div = $('div#' + id);
        ItsRadio.DisableObj($div);
    },
    DisableObj: function ($div) {
        $div.css('background-color', 'whitesmoke');
        var $input = $div.children('input');
        $div.parent().attr('readonly', 'readonly');
        $input.attr('disabled', true);
        return true;
    },
    Enable: function (id) {
        var $div = $('div#' + id);
        ItsRadio.EnableObj($div);
    },
    EnableObj: function ($div) {
        $div.css('background-color', 'white');
        var $input = $div.children('input');
        $div.parent().removeAttr('readonly');
        $input.removeAttr('disabled');
        return false;
    },
    Hide: function (id) {
        var $div = $('div#' + id);
        $div.parent().css('display', 'none');
        return true;
    },
    Show: function (id) {
        var $div = $('div#' + id);
        $div.parent().css('display', '');
        return false;
    },
    Focus: function (id) {
        var $div = $('div#' + id);
        setTimeout(function () {
            $div.focus();
        }, 1);
    },
    AddItem: function (id, label, value) {
        var $input = $('div#' + id);
        var addname = $input.attr('data-field');
        var marginItem = $input.attr('data-marginitem');
        if ($input.attr('data-name') != undefined && $input.attr('data-name') != '') {
            addname = $input.attr('data-name');
        }
        var $div = $('#' + id);
        var $html = '<input class="ItsRadio_input" type="radio" name="' + addname +
            '" id="' + ($div.attr('data-field') + value) + '" style="width: 13px; height: 13px; margin-left:' + marginItem + 'px;" value="' + value +
            '" data-label="' + label + '" data-value="' + value + '" /> <label class="ItsRadio_label" for="' + ($div.attr('data-field') + value) +
            '" style="width: 80px; align-content :center;  color: black; font-weight: normal; display: inline; padding-right: 5px; vertical-align: middle;">' + label + '</label>';
        $div.html($div.html() + $html);
        $div.css('color', 'black');
    },
    /** 
    @returns {ItsRadio.Listener} 
    */
    Event: function (id) {
        if (ItsPage.EventList[id] == undefined) {
            ItsPage.EventList[id] = new ItsRadio.Listener();
        }
        return ItsPage.EventList[id];
    },
    Listener: function () {
        this.onChanged = function (value, oldValue) { };
    }
};