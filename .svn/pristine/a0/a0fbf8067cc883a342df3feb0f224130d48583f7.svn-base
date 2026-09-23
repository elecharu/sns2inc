/// <reference path="../Script/reference.js" />
var ItsNum = {
    _Reset: function ($input) {
        //ItsNum 시작시 내부용은 숨김
        if ($input.attr('class') == 'ItsField ItsNum') {
            $input.css('display', 'none');
            ItsNum.ValueView($input);
        }
        $input.unbind('focus');
        $input.on('focus', function () {
            if ($input.attr('class') == 'ItsNumView') {
                $input.css('display', 'none');
                $input.siblings('.ItsField.ItsNum').css('display', '');
                $input.siblings('.ItsField.ItsNum').trigger('focus');
            }
            else if ($input.attr('class') == 'ItsField ItsNum') {
                var value = $input.val().replace(/[^0-9.-]/g, "");
                $input.val(value);
                $input.attr('data-oldvalue', value);
                var id = $input[0].id;
                if (id != undefined && id != null && id != "") {
                    ItsNum.Event(id).onFocus(value);
                }
                $input[0].setSelectionRange(0, 100);
            }
        });
        $input.focusout(function () {
            if ($input.attr('class') == 'ItsField ItsNum') {
                $input.css('display', 'none');
                $input.siblings('.ItsNumView').css('display', '');
                ItsNum.ValueView($input);
            }
        });

        $input.unbind('change');
        $input.on('change', function () {
            var value = $input.val();
            var id = $input[0].id;
            if (id != undefined && id != null && id != "") {
                var oldValue = $input.attr('data-oldvalue');
                ItsNum.Event(id).onChanged(value, oldValue);
            }
            ItsNum.ValueView($input);
        });
        $input.unbind('keydown');
        $input.on('keydown', function (e) {
            var keyCode = e.keyCode;
            //if (keyCode >= 65 && keyCode <= 90)
            //{
            //    e.stopPropagation();
            //    return;
            //}
            var value = $input.val();
            var id = $input[0].id;
            var oldValue = $input.attr('data-oldvalue');
            if (id != undefined && id != null && id != "") {
                if (keyCode == EnumKeys.Enter) {
                    ItsNum.Event(id).onKeyEnter(value, oldValue);
                } else {
                    ItsNum.Event(id).onKeyDown(value, keyCode);
                }
                
            }
        });
        $input.unbind('input');
        $input.on('input', function (e) {
            var value = $(this).val();
            if (value == "-")
            {
                return;
            }
            if (value.length > 2 && value.substr(0, 2) == '-0') {
                value = value.replace('-0', '-1');
            };

            var $decimal = $(this).attr('data-point');
            $value = parseFloat(value.replace(/[^0-9.-]/g, ""));
            $point = $(this)[0].selectionStart;
            if (isNaN($value) || $value == undefined || $value == null)
            {
                $value = 0;
            }

            var newValue = $value.toFixed($decimal);
            $(this).val(newValue);
            $(this)[0].setSelectionRange($point, $point);

            if (newValue >= 0)
            {
                $(this).css('color', '');
            } else {
                $(this).css('color', 'red');
            }

            ItsNum.ValueView($input);
        });
        $input.siblings('div.ItsNum_button').children('div.ItsNum_plus').on('mouseup', function (e) {
            if ($input.attr('data-readonly') == 'true' || $input.attr('class') == 'ItsNumView') {
                return false;
            }
            var id = $input[0].id;
            var value = $input.val().replace(/[^0-9.-]/g, "");
            var minValue = parseFloat($input.attr('data-minvalue'));
            var maxValue = parseFloat($input.attr('data-maxvalue'));
            
            value = parseFloat(value);
            if (isNaN(value)) value = minValue;
            if (value + 1 > maxValue) {
                value = maxValue;
            } else {
                value = value + 1;
            }

            $input.val(value);
            $input.attr('data-oldvalue', value);
            $input.trigger('input');

            $(this).focus();
            ItsNum.Event(id).onChanged(value, value - 1);
            
        });
        $input.siblings('div.ItsNum_button').children('div.ItsNum_minus').on('mouseup', function (e) {
            if ($input.attr('data-readonly') == 'true' || $input.attr('class') == 'ItsNumView') {
                return false;
            }
            var id = $input[0].id;
            var value = $input.val().replace(/[,]/gi, '');
            var minValue = parseFloat($input.attr('data-minvalue'));
            var maxValue = parseFloat($input.attr('data-maxvalue'));

            value = parseFloat(value);
            if (isNaN(value)) value = minValue;
            if (value - 1 < minValue) {
                value = minValue;
            } else {
                value = value - 1;
            }

            $input.val(value);
            $input.attr('data-oldvalue', value);
            $input.trigger('input');

            $(this).focus();
            ItsNum.Event(id).onChanged(value, value + 1);
        });
    },
    Reset: function() {
        $('div.ItsNum_table > input').each(function () {
            ItsNum._Reset($(this));
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
        ItsNum.ValueView($input);
    },
    GetValue: function (id) {
        var $input = $('input#' + id);
        var $value = $input.val();
        $value = $value.replace(/[^0-9.-]/g, "");
        $value = parseFloat($value);
        if ($value.toString() == 'NaN') {
            $value = 0;
        }
        return $value;
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
        ItsNum.ValueView($input);
    },
    SetInitObj: function (obj) {
        var $input = obj.find('input.ItsField');
        var defaultValue = $input.attr('data-default');
        $input.attr('data-value', defaultValue);
        $input.val(defaultValue);
        ItsNum.ValueView($input);
    },
    Disable: function (id) {
        var $input = $('input#' + id);
        ItsNum.DisableObj($input);
    },
    DisableObj: function ($input) {
        $input.attr('readonly', 'readonly');
        $input.attr('data-readonly', 'true');
        $input.siblings('.ItsNumView').attr('readonly', 'readonly');
        return true;
    },
    Enable: function (id) {
        var $input = $('input#' + id);
        ItsNum.EnableObj($input);
    },
    EnableObj: function ($input) {
        $input.removeAttr('readonly');
        $input.attr('data-readonly', 'false');
        $input.siblings('.ItsNumView').removeAttr('readonly');
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
            $input.siblings('.ItsNumView').css('display', 'none');
            $input.css('display', '');
            $input.trigger('focus');
        }, 1);
    },
    //입력받은 값이 출력용 input에 콤마를 찍어 출력
    ValueView: function ($input) {
        if ($input.attr('class') == 'ItsField ItsNum') {
            var $value = comma($input.val());
            $input.siblings('.ItsNumView').attr('value', $value);
        }
    },
    SetLabel: function (id, text) {
        $('#' + id).siblings('span').text(text);
    },
    /** 
    @returns {ItsNum.Listener} 
    */
    Event: function (key) {
        if (ItsPage.EventList[key] == undefined) {
            ItsPage.EventList[key] = new ItsNum.Listener();
        }
        return ItsPage.EventList[key];
    },
    Listener: function () {
        this.onChanged = function (value, oldValue) { };
        this.onKeyEnter = function (value, oldValue) { };
        this.onKeyDown = function (value, keyCode) { };
        this.onFocus = function (value) { };
    }
};



//정규식
function comma(num) {
    return num.toString().replace(/\B(?=(\d{3})+(?!\d))/g, ",");
}

function uncomma(num) {
    return num.toString().replace(/[^\d]+/g, '');
}
