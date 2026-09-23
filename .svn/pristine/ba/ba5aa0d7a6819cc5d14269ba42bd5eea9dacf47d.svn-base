/// <reference path="../Script/reference.js" />
var ItsCombo = {
    
    _Reset: function ($input) {

        // 초기값 설정 ( Combo 목록에서 해당 값 라벨을 찾아 input에 표시 )
        var $ul = $input.siblings('ul');

        gpcd = $input.attr('data-gpcd');
        ref01 = $input.attr('data-ref01');
        ref02 = $input.attr('data-ref02');
        ref03 = $input.attr('data-ref03');
        ref04 = $input.attr('data-ref04');
        ref05 = $input.attr('data-ref05');
        ref06 = $input.attr('data-ref06');
        ref07 = $input.attr('data-ref07');
        ref08 = $input.attr('data-ref08');
        ref09 = $input.attr('data-ref09');
        ref10 = $input.attr('data-ref10');

        if (gpcd == "") {
            ItsMsg.Alert('AddComboTag must have gpcd');
            return;
        }

        if (ref01 != '' || ref02 != '' || ref03 != '' || ref04 != '' || ref05 != '') {
            var params = "GPCD=" + gpcd;
            params += "&REF01=" + ref01 + "&REF02=" + ref02 + "&REF03=" + ref03;
            params += "&REF04=" + ref04 + "&REF05=" + ref05;
            params += "&REF06=" + ref06 + "&REF07=" + ref07 + "&REF08=" + ref08;
            params += "&REF09=" + ref09 + "&REF10=" + ref10;
            $.ajaxSetup({ async: false });
            $.post("/Service/LiList/Combo.aspx", params, function (data) {
                $ul.html(data);
            });
        }
        var pValue = $input.attr('data-value');
        var isSearch = false;
        $ul.children('li').each(function () {
            var $li = $(this);
            if (pValue == $li.attr('data-value')) {
                var label = $li.attr('data-label');
                $input.attr('data-label', label);
                $input.val(label);
                $input.css('color', '');
                isSearch = true;
            }
        });

        if (pValue == "") isSearch = true;
        if (isSearch == false) {
            $input.val(pValue);
            $input.css('color', 'red');
        }
        // 목록 숨김 visibility는 visible, display를 none
        $ul.css('visibility', 'visible');
        $ul.css('display', 'none');

        $input.parent('div.ItsCombo_box').unbind('mouseup');
        $input.parent('div.ItsCombo_box').on('mouseup', function (e) {

            // 읽기 전용 시 빠져나가기
            var $main = $(this).parent().parent();
            if ($main.attr('readonly') == 'readonly') {
                return;
            }

            e.stopPropagation();

            var $ul = $(this).children('ul');

            $ul.children('li').removeClass('select');
            $ul.children('li').removeClass('over');

            var pValue = $input.attr("data-value");
            var $curLi = $ul.children('li').filter('[data-value="' + pValue + '"]');
            if ($curLi == undefined || $curLi == null || $curLi.length == 0) {
                $input.val(pValue);
                $input.css('color', 'red');
            } else {
                $curLi.addClass('select');
            }

            $input.focus();
            $input[0].setSelectionRange(0, 0);
            $('.ItsControl_pop').css('display', 'none');

            $ul.css('top', $input[0].getBoundingClientRect().top);
            $ul.css('display', '');

        });
        $input.siblings('ul').children('li').unbind('mouseover');
        $input.siblings('ul').children('li').on('mouseover', function () {
            var $li = $(this);
            $li.parent().children('li').removeClass('over');
            $li.addClass('over');
        });
        $input.siblings('ul').children('li').unbind('mouseup');
        $input.siblings('ul').children('li').on('mouseup', function (e) {

            e.stopPropagation();

            var $li = $(this);
            var $ul = $(this).parent();
            var $input = $ul.siblings('input');

            var label = $li.attr('data-label');
            var value = $li.attr('data-value');

            var oldValue = $input.attr('data-value');

            $input.attr('data-label', label);
            $input.attr('data-value', value);
            $input.val(label);
            $input.css('color', '');

            $input.focus();
            $ul.css('display', 'none');

            if (oldValue != value) {
                var id = $input[0].id;
                if (id != undefined && id != null && id != "") {
                    ItsCombo.Event(id).onChanged(value, oldValue);
                }
            }
        });
        $input.unbind('keydown');
        $input.on('keydown', function (e) {

            // 읽기 전용 시 빠져나가기
            var $main = $(this).parent().parent().parent();
            if ($main.hasClass('readonly')) {
                return;
            }

            var $ul = $(this).siblings('ul');

            // 취소키 목록창 닫고 빠져나감
            if (e.keyCode == EnumKeys.Esc
                || e.keyCode == EnumKeys.Tab
                || e.keyCode == EnumKeys.BackSpace) {
                $ul.css('display', 'none');
                return;
            }

            if (e.keyCode != EnumKeys.Top
                && e.keyCode != EnumKeys.Down
                && e.keyCode != EnumKeys.Space
                && e.keyCode != EnumKeys.Enter) {
                return;
            }

            $input[0].setSelectionRange(0, 0);

            // 현재 행 설정
            $ul.children('li').removeClass('select');
            var pValue = $input.attr("data-value");
            var $curLi = $ul.children('li').filter('[data-value="' + pValue + '"]');
            if ($curLi == undefined || $curLi == null || $curLi.length == 0) {
                $input.val(pValue);
                $input.css('color', 'red');
            } else {
                $curLi.addClass('select');
            }

            // 닫혀 있는 경우 띄우고 빠져나가기
            if ($ul.css('display') == 'none') {
                $ul.css('display', '');
                $ul.children('li').removeClass('over');
                return;
            }

            // 현재 over 행 설정
            var $overLi = $ul.children('li.over');
            if ($overLi == undefined || $overLi == null || $overLi.length == 0) {
                if ($curLi == undefined || $curLi == null || $curLi.length == 0) {
                    $overLi = $ul.children('li').first();
                } else {
                    $overLi = $curLi;
                }
            }

            $ul.children('li').removeClass('over');
            $overLi.addClass('over');

            // TOP DOWN 일 경우 Over 행 설정
            if (e.keyCode == EnumKeys.Top && $overLi.prev().length == 1) {
                $overLi = $overLi.prev();
            }
            else if (e.keyCode == EnumKeys.Down && $overLi.next().length == 1) {
                $overLi = $overLi.next();
            }
            $ul.children('li').removeClass('over');
            $overLi.addClass('over');

            // Enter 혹은 Space 항목 선택
            if (e.keyCode == EnumKeys.Enter || e.keyCode == EnumKeys.Space) {

                var oldValue = $input.attr('data-value');

                var label = $overLi.attr('data-label');
                var value = $overLi.attr('data-value');
                $input.attr('data-label', label);
                $input.attr('data-value', value);
                $input.val(label);
                $input.css('color', '');

                $ul.css('display', 'none');

                if (oldValue != value) {
                    var id = $input[0].id;
                    if (id != undefined && id != null && id != "") {
                        ItsCombo.Event(id).onChanged(value, oldValue);
                    }
                }
            }
        });
    },

    Reset: function() {
        $('div.ItsCombo_box > input').each(function () {
            ItsCombo._Reset($(this));
        });
    },
    SetValueByIndex: function (id, index) {

        var value = $('#'+ id).siblings('ul').find('li').eq(index).attr('data-value');
        if (value == undefined) {
            return;
        };

        var $input = $('input#' + id);
        var $oldValue = $input.attr('data-value');
        $input.attr('data-value', value);
        var $ul = $input.siblings('ul');
        var $curLi = $ul.children('li').filter('[data-value="' + value + '"]');
        if ($curLi == undefined || $curLi == null || $curLi.length == 0) {
            $input.attr('data-label', value);
            $input.val(value);
            $input.css('color', 'red');
        } else {
            var label = $curLi.attr('data-label');
            $input.attr('data-label', label);
            $input.val(label);
            $input.css('color', '');
        }
        ItsCombo.Event(id).onChanged(value, $oldValue);
    },
    SetValue: function (id, value) {
        var $input = $('input#' + id);
        var $oldValue = $input.attr('data-value');
        $input.attr('data-value', value);
        var $ul = $input.siblings('ul');
        var $curLi = $ul.children('li').filter('[data-value="' + value + '"]');
        if ($curLi == undefined || $curLi == null || $curLi.length == 0) {
            $input.attr('data-label', value);
            $input.val(value);
            $input.css('color', 'red');
        } else {
            var label = $curLi.attr('data-label');
            $input.attr('data-label', label);
            $input.val(label);
            $input.css('color', '');
        }
        ItsCombo.Event(id).onChanged(value, $oldValue);
    },
    SetInitValue: function (id, value) {
        var $input = $('input#' + id);
        $input.attr('data-default', value);
        ItsCombo.SetValue(id, value);
    },
    GetValue: function (id) {
        var $input = $('input#' + id);
        return $input.attr('data-value');
    },
    GetNameValue: function (id) {
        var $input = $('input#' + id);
        return $input.attr('data-label');
    },
    GetField: function (id) {
        var $input = $('input#' + id);
        return $input.attr('data-field');
    },
    SetGpcd: function (id, gpcd) {
        $("#" + id).attr('data-gpcd', gpcd);
        this.Reload(id);
    },
    SetRef01: function (id, ref01) {
        $("#" + id).attr('data-ref01', ref01);
        this.Reload(id);
    },
    SetRef02: function (id, ref02) {
        $("#" + id).attr('data-ref02', ref02);
        this.Reload(id);
    },
    SetRef03: function (id, ref03) {
        $("#" + id).attr('data-ref03', ref03);
        this.Reload(id);
    },
    SetRef04: function (id, ref04) {
        $("#" + id).attr('data-ref04', ref04);
        this.Reload(id);
    },
    SetRef05: function (id, ref05) {
        $("#" + id).attr('data-ref05', ref05);
        this.Reload(id);
    },
    SetRef06: function (id, ref06) {
        $("#" + id).attr('data-ref06', ref06);
        this.Reload(id);
    },
    SetRef07: function (id, ref07) {
        $("#" + id).attr('data-ref07', ref07);
        this.Reload(id);
    },
    SetRef08: function (id, ref08) {
        $("#" + id).attr('data-ref08', ref08);
        this.Reload(id);
    },
    SetRef09: function (id, ref09) {
        $("#" + id).attr('data-ref09', ref09);
        this.Reload(id);
    },
    SetRef10: function (id, ref10) {
        $("#" + id).attr('data-ref10', ref10);
        this.Reload(id);
    },
    GetRefValue: function(id, refName) {
        var $input = $('input#' + id);
        var $value = $input.attr('data-value');
        var $liList = $input.siblings('ul').find('li');
        var $refValue = "";
        for (var i = 0; i < $liList.length; i++) {
            if ($liList.eq(i).attr('data-value') == $value) {
                $refValue = $liList.eq(i).attr('data-' + refName.toLowerCase());
            }
        }
        return $refValue;
    },
    GetRefValueByValue: function (id, value, refName) {
        var res = "";
        $('#' + id).parent().find('li').each(function () {
            if ($(this).attr('data-value') == value) {
                res = $(this).attr('data-' + refName.toLowerCase());
            }
        })
        return res;
    },
    GetValueByRefValue: function (id, refName, refValue) {
        var res = "";
        $('#' + id).parent().find('li').each(function () {
            if ($(this).attr('data-' + refName.toLowerCase()) == refValue) {
                res = $(this).attr('data-value');
            }
        })
        return res;
    },
    SetValueByRefValue: function(id, refName, refValue) {
        $('#' + id).parent().find('li').each(function () {
            if ($(this).attr('data-' + refName.toLowerCase()) == refValue) {
                ItsCombo.SetValue(id, $(this).attr('data-value'))
            }
        })
    },
    Reload: function(id) {
        var $combo = $("#" + id);
        gpcd = $combo.attr('data-gpcd');
        ref01 = $combo.attr('data-ref01');
        ref02 = $combo.attr('data-ref02');
        ref03 = $combo.attr('data-ref03');
        ref04 = $combo.attr('data-ref04');
        ref05 = $combo.attr('data-ref05');
        ref06 = $combo.attr('data-ref06');
        ref07 = $combo.attr('data-ref07');
        ref08 = $combo.attr('data-ref08');
        ref09 = $combo.attr('data-ref09');
        ref10 = $combo.attr('data-ref10');
        var params = "GPCD=" + gpcd;
        params += "&REF01=" + ref01 + "&REF02=" + ref02 + "&REF03=" + ref03;
        params += "&REF04=" + ref04 + "&REF05=" + ref05;
        params += "&REF06=" + ref06 + "&REF07=" + ref07 + "&REF08=" + ref08;
        params += "&REF09=" + ref09 + "&REF10=" + ref10;
        $.post("/Service/LiList/Combo.aspx", params, function (data) {
            $combo.siblings("ul").html(data);
            ItsCombo.Reset();
        });
    },
    SetInit: function (id) {
        var $input = $('input#' + id);
        var defaultValue = $input.attr('data-default');
        ItsCombo.SetValue(id, defaultValue);
    },
    SetInitObj: function (obj) {
        var $input = obj;
        var defaultValue = obj.attr('data-default');
        $input.attr('data-value', defaultValue);
        var $ul = $input.siblings('ul');
        var $curLi = $ul.children('li').filter('[data-value="' + defaultValue + '"]');
        var label = $curLi.attr('data-label');
        if ($curLi == undefined || $curLi == null || $curLi.length == 0) {
            $input.attr('data-label', label);
            $input.val(defaultValue);
            $input.css('color', 'red');
        } else {
            $input.attr('data-label', label);
            $input.val(label);
            $input.css('color', '');
        }
        var $oldValue = $input.attr('data-value');
        var id = $input[0].id;
        if (id != undefined && id != null && id != "") {
            ItsCombo.Event(id).onChanged($input.attr('data-value'), $oldValue);
        }
    },
    Disable: function (id) {
        var $input = $('input#' + id);
        ItsCombo.DisableObj($input);
    },
    DisableObj: function ($input) {
        $input.css('background-color', 'aliceblue');
        $input.parent().parent().parent().attr('readonly', 'readonly');
        return true;
    },
    Enable: function (id) {
        var $input = $('input#' + id);
        ItsCombo.EnableObj($input);
    },
    EnableObj: function ($input) {
        $input.css('background-color', 'white');
        $input.parent().parent().parent().removeAttr('readonly');
        return false;
    },
    Hide: function (id) {
        var $input = $('input#' + id);
        $input.parent().parent().parent().css('display', 'none');
        return true;
    },
    Show: function (id) {
        var $input = $('input#' + id);
        $input.parent().parent().parent().css('display', '');
        return false;
    },
    Focus: function (id) {
        var $input = $('input#' + id);
        setTimeout(function () {
            $input.focus();
        }, 1);
    },
    SetLabel: function (id, text) {
        $('#' + id).parent().siblings('span').text(text);
    },
    /** 
    @returns {ItsCombo.Listener} 
    */
    Event: function (id) {
        if (ItsPage.EventList[id] == undefined) {
            ItsPage.EventList[id] = new ItsCombo.Listener();
        }
        return ItsPage.EventList[id];
    },
    Listener: function () {
        this.onChanged = function (value, oldValue) { };
    }
};