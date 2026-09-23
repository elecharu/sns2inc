/// <reference path="../Script/reference.js" />
var $dblClick = 0;
var ItsFind = {
    _Reset: function ($input) {
        var $pop = $input.siblings('.ItsControl_pop');
        $pop.hide();
        $pop.on('show', function () {
            $pop.css('left', '');
            if ($input.offset().left + $pop.width() > $('#MAIN_BODY').width()) {
                $pop.css('left', $input.offset().left - ($input.offset().left + $pop.width() - $('#MAIN_BODY').width()));
            }
        })
        $input.siblings('div.ItsControl_pop')
            .children('ul')
            .children('li')
            .unbind('mouseover');
        $input.siblings('div.ItsControl_pop')
            .children('ul')
            .children('li')
            .on('mouseover', function () {
                var $li = $(this);
                $li.parent().children('li').removeClass('over');
                $li.addClass('over');
            });
        $input.siblings('div.ItsControl_pop')
            .children('ul')
            .children('li')
            .unbind('click');
        $input.siblings('div.ItsControl_pop')
            .children('ul')
            .children('li')
            .on('click', function (e) {
                //e.stopPropagation();
                ItsFind._$valueChangedEvent($(this));

            });
        $input.siblings('div.ItsFind_button').unbind('mouseup');
        $input.siblings('div.ItsFind_button').on('mouseup', function (e) {
            $.each($('.ItsCombo_box'), function () {
                ItsCombo.$ulEvt($(this).children('input'), undefined, false);
            });
            var $main = $(this).parent().parent().parent();
            if ($main.hasClass('readonly')) {
                return;
            }
            $input.focus();

            var length = $input.val().length;
            $input[0].setSelectionRange(length, length);
            var $pop = $input.siblings('div.ItsControl_pop');
            $pop.show();
            if ($input.val() == '')
                ItsFind.GetList($input, '');
            else
                $input.trigger('input');
            e.stopPropagation();
        });

        $input.unbind('focus');
        $input.on('focus', function () {
            var value = $input.val();
            $input.attr('data-oldvalue', value);
            var id = $input[0].id;
            if (id != undefined && id != null && id != "") {
                ItsFind.Event(id).onFocus(value);
            }
            $input[0].setSelectionRange(0, 100);
        });
        //2018-11-20 수정자 : 왕현준
        //파인드에 ID를 부여할 시에 값을 선택한 후 빈 값으로 변경 시 
        //첫번째 값이 무조건 선택되는 문제 때문에 들어온 값이 ''일때 예외
        //(빈 값이 전체 조회에 쓰이므로 해당 부분 수정)

        $input.unbind('change');
        $input.on('change', function () {
            var value = $input.val();
            var id = $input[0].id;
            ItsFind._$searchName($input);
            if (id != undefined && id != null && id != "") {
                var oldValue = $input.attr('data-oldvalue');
                if (value != oldValue) {  
                    ItsFind.Event(id).onChanged(value, oldValue);
                }
            }
        });
        $input.unbind('focusout');
        $input.on('focusout', function () {
            if ($input.attr('data-findtype') == 'mini') {
                if ($dblClick > 0)
                    $dblClick = 0;
                var value = $input.val();
                var findtype = $input.attr('data-findtype');
                if (findtype == 'mini') {
                    $input.siblings('.ItsFind_name').show();
                    $input.hide();
                }
                var id = $input[0].id;
                if (id != undefined && id != null && id != "") {
                    var oldValue = $input.attr('data-oldvalue');
                    if (value != oldValue) {
                        ItsFind.Event(id).onChanged(value, oldValue);
                    }
                }
            } else {
                if ($dblClick > 0)
                    $dblClick = 0;
                var value = $input.val();
                var findtype = $input.attr('data-findtype');
                if (findtype == 'mini') {
                    $input.siblings('.ItsFind_name').show();
                    $input.hide();
                }
                var id = $input[0].id;
                if (id != undefined && id != null && id != "") {
                    var oldValue = $input.attr('data-oldvalue');
                    if (value != oldValue) {
                        ItsFind.Event(id).onChanged(value, oldValue);
                    }
                }
            }
            

        });
        //2018-11-22 수정자 : 왕현준
        //파인드 입력 창 더블 클릭 시에 PopUp 출력

        $input.dblclick(function () {
            if ($dblClick == 0) {
                var $pop = $input.siblings('div.ItsControl_pop');

                if ($input.attr('readonly') != 'readonly') {
                    $pop.show();
                    ItsFind.GetList($input, '');
                    $dblClick += 1;
                }
           }
        });

        $input.siblings('.ItsFind_name').on('focus', function () {

            if ($dblClick == 0) {
                var findtype = $input.attr('data-findtype');
                if (findtype == 'mini') {
                    if ($input.attr('readonly') != 'readonly') {
                        $pop.show();
                        ItsFind.GetList($input, '');
                        $dblClick += 1;
                    }
                    $(this).hide();
                    $input.show();
                    $input.focus();
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

            var $pop = $input.siblings('div.ItsControl_pop');
            var $ul = $pop.children('ul');
            var $overLi = $ul.find('li.over');

            // 취소키 목록창 닫고 빠져나감
            if (e.keyCode == EnumKeys.Esc || e.keyCode == EnumKeys.BackSpace) {
                if (e.keyCode == EnumKeys.BackSpace) {
                    $input.siblings('.ItsFind_name').val('');
                }
                $pop.hide();
                return;
            }

            if (e.keyCode == EnumKeys.Top || e.keyCode == EnumKeys.Down) {
                // 현재 over 행 설정
                if ($overLi == undefined || $overLi == null || $overLi.length == 0) {
                    $overLi = $ul.children('li').first();
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

                var scrollHeight = 0;
                var _liList = $input.siblings('.ItsControl_pop').find('ul').find('li');
                for (var i = 0; i < _liList.length; i++) {
                    if (_liList.eq(i).hasClass('over')) {
                        break;
                    }
                    scrollHeight += _liList.eq(i).height() + 7;
                }
                //2018-11-20 수정자 : 왕현준
                //키보드로 스크롤 내릴때 10개 넘어가면 스크롤이 안내려가는 현상 해결
                $ul.scrollTop(scrollHeight);
                return;
            }
            // Enter 혹은 Tab 항목 선택
            if (e.keyCode == EnumKeys.Enter || e.keyCode == EnumKeys.Tab) {
                if ($pop.css('display') == 'none') {
                    var cnt = ItsFind.GetList($input);
                    $pop.show();
                    if (cnt == 1) {
                        ItsFind._$valueChangedEvent($ul.find('li.over'));
                        ItsFind._$searchName($input);
                    } else {
                        ItsFind.Event($input.attr('id')).onChanged($input.val(), '');
                        ItsFind._$searchName($input);
                    }
                } else {
                    if ($input.attr('data-keyword') == $input.val()) {
                        ItsFind._$valueChangedEvent($ul.find('li.over'));
                        ItsFind._$searchName($input);
                    } else {
                        var cnt = ItsFind.GetList($input);
                        $pop.show();
                        if (cnt == 1) {
                            ItsFind._$valueChangedEvent($ul.find('li.over'));
                        }
                    }
                    if ($input.attr('data-findtype') == 'mini') {
                        $input.parent().parent().parent().nextAll().find('input:visible').eq(0).focus();
                    }
                }
                if (e.keyCode == EnumKeys.Tab) {
                    $pop.hide();
                }
            }
        });
        $input.siblings('div.ItsControl_pop')
            .children('div.ItsFind_limit')
            .children('span')
            .unbind('mouseup');
        $input.siblings('div.ItsControl_pop')
            .children('div.ItsFind_limit')
            .children('span')
            .on('mouseup', function (e) {
                var $span = $(this);
                $span.parent().children("span").removeClass("select");
                $span.addClass("select");
                var limit = $span.attr("data-limit");
                $span.parent().parent().attr("data-limit", limit);

                $input.focus();
                var length = $input.val().length;
                $input[0].setSelectionRange(length, length);
                $input.trigger('change');

                //2020-05-18 왕현준 건수 변경시 바로 적용됨
                var $pop = $input.siblings('div.ItsControl_pop');

                $pop.show();
                ItsFind.GetList($input);


                e.stopPropagation();
            });
        //if ($input.attr('isinit') == 'Y') {
        //    ItsFind.GetList($input, '', true);
        //}
    },
    Reset: function () {
        $('div.ItsFind_box > .ItsFind_code').each(function () {
            ItsFind._Reset($(this));
        });
    },
    SetValue: function (id, value, isChangeEvent) {
        var $input = $('input#' + id);
        $input.val(value);
        ItsFind._$searchName($input);
        if (isChangeEvent != false) {
            $input.trigger('change');
        }
    },
    SetInitValue: function (id, value, isChangeEvent) {
        var $input = $('input#' + id);
        $input.attr('data-default', value);
        $input.val(value);
        ItsFind._$searchName($input);
        if (isChangeEvent != false) {
            $input.trigger('change');
        }
    },
    GetValue: function (id) {
        var $input = $('input#' + id);
        return $input.val();
    },
    IsFindName: function (id) {
        var $input = $('input#' + id);
        var $name = $input.siblings('.ItsFind_name').val();
        if ($name == null || $name == undefined || $name == '') {
            return false;
        } else {
            return true;
        }
    },
    GetNameValue: function (id) {
        var $input = $('input#' + id);
        return $input.siblings('.ItsFind_name').val();
    },
    GetRef01: function (id) {
        var $input = $('input#' + id);
        return $input.attr('data-ref01');
    },
    GetRef02: function (id) {
        var $input = $('input#' + id);
        return $input.attr('data-ref02');
    },
    GetRef03: function (id) {
        var $input = $('input#' + id);
        return $input.attr('data-ref03');
    },
    GetRef04: function (id) {
        var $input = $('input#' + id);
        return $input.attr('data-ref04');
    },
    GetRef05: function (id) {
        var $input = $('input#' + id);
        return $input.attr('data-ref05');
    },
    GetRef06: function (id) {
        var $input = $('input#' + id);
        return $input.attr('data-ref06');
    },
    GetRef07: function (id) {
        var $input = $('input#' + id);
        return $input.attr('data-ref07');
    },
    GetRef08: function (id) {
        var $input = $('input#' + id);
        return $input.attr('data-ref08');
    },
    GetRef09: function (id) {
        var $input = $('input#' + id);
        return $input.attr('data-ref09');
    },
    GetRef10: function (id) {
        var $input = $('input#' + id);
        return $input.attr('data-ref10');
    },
    GetRef01Value: function (id) {
        var $input = $('input#' + id);
        return $input.attr('data-ref01value');
    },
    GetRef02Value: function (id) {
        var $input = $('input#' + id);
        return $input.attr('data-ref02value');
    },
    GetRef03Value: function (id) {
        var $input = $('input#' + id);
        return $input.attr('data-ref03value');
    },
    GetRef04Value: function (id) {
        var $input = $('input#' + id);
        return $input.attr('data-ref04value');
    },
    GetRef05Value: function (id) {
        var $input = $('input#' + id);
        return $input.attr('data-ref05value');
    },
    GetRef06Value: function (id) {
        var $input = $('input#' + id);
        return $input.attr('data-ref06value');
    },
    GetRef07Value: function (id) {
        var $input = $('input#' + id);
        return $input.attr('data-ref07value');
    },
    GetRef08Value: function (id) {
        var $input = $('input#' + id);
        return $input.attr('data-ref08value');
    },
    GetRef09Value: function (id) {
        var $input = $('input#' + id);
        return $input.attr('data-ref09value');
    },
    GetRef10Value: function (id) {
        var $input = $('input#' + id);
        return $input.attr('data-ref10value');
    },
    GetField: function (id) {
        var $input = $('input#' + id);
        return $input.attr('data-field');
    },
    SetInit: function (id) {
        var $input = $('input#' + id);
        var defaultValue = $input.attr('data-default');
        $input.val(defaultValue);
        ItsFind._$searchName($input);
        if (defaultValue != '') {
            $input.trigger('change');
        }
    },
    SetInitObj: function (obj) {
        var $input = obj.find('input.ItsField');
        var defaultValue = $input.attr('data-default');
        $input.val(defaultValue);
        ItsFind._$searchName($input);
        if (defaultValue != '') {
            $input.trigger('change');
        }
    },
    Disable: function (id) {
        var $input = $('input#' + id);
        ItsFind.DisableObj($input);
    },
    DisableObj: function ($input) {
        $input.attr('readonly', 'readonly');
        $input.parent().parent().parent().addClass('readonly');
        return true;
    },
    Enable: function (id) {
        var $input = $('input#' + id);
        ItsFind.EnableObj($input);
    },
    EnableObj: function ($input) {
        $input.removeAttr('readonly');
        $input.parent().parent().parent().removeClass('readonly');
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
    SetProc: function (id, proc) {
        $('input#' + id).attr('data-proc', proc);
    },
    GetGpcd: function (id) {
        return $('input#' + id).attr('data-gpcd');
    },
    SetGpcd: function (id, gpcd) {
        $('input#' + id).attr('data-gpcd', gpcd);
        var $proc = $('input#' + id).attr('data-proc');
        $('input#' + id).trigger('change');

        var tag_head = '<span class=\"no\">No.</span>';

        var maria = new ItsMaria($proc, '');
        maria.AddParam("GPCD", gpcd + '_HEAD');
        maria.CallProc();
        var $keys = Object.keys(maria.store.data[0]);
        var GridField = "";
        var GridTitle = "";
        var GridWidth = "";
        for (var i = 0; i < $keys.length; i++) {
            var field = $keys[i];
            var title = maria.store.GetValue(0, $keys[i]);
            var width = maria.storeExtend1.GetValue(0, $keys[i]);

            GridField = GridField + "»" + field;
            GridTitle = GridTitle + "»" + title;
            GridWidth = GridWidth + "»" + width;

            tag_head += "<span class=\"list\" style=\"width:" + width + "px;\">" + title + "</span>";
        }
        var GridLength = maria.storeExtend2.GetValue(0, 'EVENTLENGTH');
        var $ctp = $('input#' + id).siblings('.ItsControl_pop');
        $ctp.attr('data-field', GridField);
        $ctp.attr('data-title', GridTitle);
        $ctp.attr('data-width', GridWidth);
        $ctp.attr('data-length', GridLength);
        $ctp.children().eq(0).html(tag_head);
    },
    SetRef01: function (id, ref01) {
        $('input#' + id).attr('data-ref01', ref01);
        $('input#' + id).trigger('change');
    },
    SetRef02: function (id, ref02) {
        $('input#' + id).attr('data-ref02', ref02);
        $('input#' + id).trigger('change');
    },
    SetRef03: function (id, ref03) {
        $('input#' + id).attr('data-ref03', ref03);
        $('input#' + id).trigger('change');
    },
    SetRef04: function (id, ref04) {
        $('input#' + id).attr('data-ref04', ref04);
        $('input#' + id).trigger('change');
    },
    SetRef05: function (id, ref05) {
        $('input#' + id).attr('data-ref05', ref05);
        $('input#' + id).trigger('change');
    },
    // 2023-06-29 추가
    SetRef06: function (id, ref06) {
        $('input#' + id).attr('data-ref06', ref06);
        $('input#' + id).trigger('change');
    },
    SetRef07: function (id, ref07) {
        $('input#' + id).attr('data-ref07', ref07);
        $('input#' + id).trigger('change');
    },
    SetRef08: function (id, ref08) {
        $('input#' + id).attr('data-ref08', ref08);
        $('input#' + id).trigger('change');
    },
    SetRef09: function (id, ref09) {
        $('input#' + id).attr('data-ref09', ref09);
        $('input#' + id).trigger('change');
    },
    SetRef10: function (id, ref10) {
        $('input#' + id).attr('data-ref10', ref10);
        $('input#' + id).trigger('change');
    },

    SetLabel: function (id, text) {
        $('#' + id).parent().siblings('span').text(text);
    },
    GetList: function (input, keyword, isInit) {
        var cnt = 0;
        var async = false;
        if (keyword == undefined) {
            keyword = input.val();
        }
        if (isInit == undefined) {
            isInit = false;
        }
        if (isInit) {
            async = true;
        }
        input.attr('data-keyword', keyword);
        var gpcd = input.attr('data-gpcd');
        var proc = input.attr('data-proc');
        var ref01 = input.attr('data-ref01');
        var ref02 = input.attr('data-ref02');
        var ref03 = input.attr('data-ref03');
        var ref04 = input.attr('data-ref04');
        var ref05 = input.attr('data-ref05');
        var ref06 = input.attr('data-ref06');
        var ref07 = input.attr('data-ref07');
        var ref08 = input.attr('data-ref08');
        var ref09 = input.attr('data-ref09');
        var ref10 = input.attr('data-ref10');
        if (gpcd == "" || gpcd == undefined) {
            return;
        }
        var $pop = input.siblings('div.ItsControl_pop');
        var width = $pop.attr('data-width');
        var title = $pop.attr('data-title');
        var limit = $pop.attr('data-limit');

        var params = "GPCD=" + gpcd;
        params += "&PROC=" + proc;
        params += "&KEYWORD=" + keyword;
        params += "&REF01=" + ref01 + "&REF02=" + ref02 + "&REF03=" + ref03;
        params += "&REF04=" + ref04 + "&REF05=" + ref05;
        params += "&REF06=" + ref06 + "&REF07=" + ref07 + "&REF08=" + ref08;
        params += "&REF09=" + ref09 + "&REF10=" + ref10;
        params += "&WIDTH=" + width + "&TITLE=" + title + "&LIMIT=" + limit;
        $.ajaxSetup({ async: async });
        $.post("../../Service/LiList/Find.aspx", params, function (data) {
            $pop.children("ul").html(data);
            var display = $pop.css('display');
            if (!isInit) {
                ItsFind.Reset();
            }
            $pop.css('display', display);
            var liList = $pop.children('ul').children('li');
            if (liList.length > 0) {
                liList.first().addClass('over');
            }

            if (liList.length <= 10) {
                input.siblings('.ItsControl_pop').children('.ItsFind_limit').css('display', 'none');
            }
            else {
                input.siblings('.ItsControl_pop').children('.ItsFind_limit').css('display', '');
            }

            cnt = liList.length;
        });

        var $ul = $pop.children('ul');
        var $overLi = $ul.find('li.over');

        $ul.scrollTop($overLi.index() * $ul.children('li').outerHeight());
        input.attr('isinit', 'N');
        return cnt;
    },
    /** 
    @returns {ItsFind.Listener} 
    */
    Event: function (id) {
        if (ItsPage.EventList[id] == undefined) {
            ItsPage.EventList[id] = new ItsFind.Listener();
        }
        return ItsPage.EventList[id];
    },
    Listener: function () {
        this.onChanged = function (value, oldValue) { };
        this.onFocus = function (value) { };
    }
};
ItsFind._$valueChangedEvent = function (obj) {
    var $li = obj;
    var $pop = obj.parent().parent();
    var $input = $pop.siblings('.ItsFind_code').eq(0);
    var $inputName = $pop.siblings('input.ItsFind_name');

    var value = $li.children('span').eq(1).text();
    var label = $li.children('span').eq(2).text();
    var ref01Value = $li.children('span').eq(3).text();
    var ref02Value = $li.children('span').eq(4).text();
    var ref03Value = $li.children('span').eq(5).text();
    var ref04Value = $li.children('span').eq(6).text();
    var ref05Value = $li.children('span').eq(7).text();
    var ref06Value = $li.children('span').eq(8).text();
    var ref07Value = $li.children('span').eq(9).text();
    var ref08Value = $li.children('span').eq(10).text();
    var ref09Value = $li.children('span').eq(11).text();
    var ref10Value = $li.children('span').eq(12).text();

    var oldValue = $input.attr('data-oldvalue');

    $input.attr('data-oldvalue', value);
    $input.attr('data-value', value);
    $input.attr('data-ref01value', ref01Value);
    $input.attr('data-ref02value', ref02Value);
    $input.attr('data-ref03value', ref03Value);
    $input.attr('data-ref04value', ref04Value);
    $input.attr('data-ref05value', ref05Value);
    $input.attr('data-ref06value', ref06Value);
    $input.attr('data-ref07value', ref07Value);
    $input.attr('data-ref08value', ref08Value);
    $input.attr('data-ref09value', ref09Value);
    $input.attr('data-ref10value', ref10Value);
    $input.val(value);
    $inputName.val(label);

    $pop.hide();

    var findtype = $input.attr('data-findtype');
    if (oldValue != value) {
        var id = $input.eq(0).attr('id');
        if (id != undefined && id != null && id != "") {
            ItsFind.Event(id).onChanged(value, oldValue);
        }
    }
}
ItsFind._$searchName = function (obj) {
    var $input = obj;
    var $pop = $input.siblings('div.ItsControl_pop');
    var $inputName = $input.siblings('.ItsFind_name');
    //2018-11-21 수정자 : 왕현준
    //입력한 값이 코드와 일치하는게 있는지 확인
    //일치하는게 있을 경우 팝업 목록 재 조정 후에 해당 값 이름 출력
    //입력한 값이 없다면 span 초기화
    var searchValue = '';
    var $val = $input.val();
    var $matchIndex = -1;
    for (var i = 0; i < $pop.children('ul').children('li').length; i++) {
        if ($val == $pop.children('ul').children('li').eq(i).children('span').eq(1).text()) {
            searchValue = $pop.children('ul').children('li').eq(i).children('span').eq(1).text();
            $matchIndex = i;
            break;
        }
        $inputName.val('');
    }
    if ($matchIndex == -1) {
        ItsFind.GetList($input);
        var li = $pop.children('ul').children('li').eq(0);
        $inputName.val('');
        $input.attr('data-value', '');
        $input.attr('data-oldvalue', '');
        $input.attr('data-ref01value', '');
        $input.attr('data-ref02value', '');
        $input.attr('data-ref03value', '');
        $input.attr('data-ref04value', '');
        $input.attr('data-ref05value', '');
        $input.attr('data-ref06value', '');
        $input.attr('data-ref07value', '');
        $input.attr('data-ref08value', '');
        $input.attr('data-ref09value', '');
        $input.attr('data-ref10value', '');
    } else {
        var li = $pop.children('ul').children('li').eq($matchIndex);
        //var li = $pop.children('ul').children('li').eq(0);
        var value = li.children('span').eq(1).text();
        var name = li.children('span').eq(2).text();
        var ref01Value = li.children('span').eq(3).text();
        var ref02Value = li.children('span').eq(4).text();
        var ref03Value = li.children('span').eq(5).text();
        var ref04Value = li.children('span').eq(6).text();
        var ref05Value = li.children('span').eq(7).text();
        var ref06Value = li.children('span').eq(8).text();
        var ref07Value = li.children('span').eq(9).text();
        var ref08Value = li.children('span').eq(10).text();
        var ref09Value = li.children('span').eq(11).text();
        var ref10Value = li.children('span').eq(12).text();
        //if ($input.val() == value) {
        $input.attr('data-value', value);
        $input.val(value);
        $inputName.val(name);
        $input.attr('data-oldvalue', value);
        $input.attr('data-ref01value', ref01Value);
        $input.attr('data-ref02value', ref02Value);
        $input.attr('data-ref03value', ref03Value);
        $input.attr('data-ref04value', ref04Value);
        $input.attr('data-ref05value', ref05Value);
        $input.attr('data-ref06value', ref06Value);
        $input.attr('data-ref07value', ref07Value);
        $input.attr('data-ref08value', ref08Value);
        $input.attr('data-ref09value', ref09Value);
        $input.attr('data-ref10value', ref10Value);

        $pop.hide();
    }
}