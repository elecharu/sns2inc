var u_menu_ok;

$(function () {
    document.getElementById('myname').innerText = GET_COOKIE('MPUSERNM');
    // 숫자만 입력
    $(".numberonly").on("keypress keyup blur", function (event) {
        $(this).val($(this).val().replace(/[^\d].+/, ""));
        if ((event.which < 48 || event.which > 57)) {
            event.preventDefault();
        }
    });

    // 금액입력
    $(".moneyinput").on("keypress keyup blur", function (event) {
        if ((event.which < 48 || event.which > 57) && event.which != 188) {
            event.preventDefault();
        }
        var val = String($(this).val().match(/[0-9|,]+/, ""));
        val = val.split(',').join('');
        if (val == "" || val == "null" || val == undefined) val = '0';
        $(this).val(val.replace(/(\d)(?=(?:\d{3})+(?!\d))/g, '$1,'));
    });

    // 엔터누르면 검색
    $('.search_input').on("keydown", function (key) {
        if (key.keyCode == 13) {
            $(this).next('img').trigger('click');
        }
    });

    //var floatprev = '';
    //$(".floatonly").on("keypress keyup blur", function (event) {
    //    if ((event.which < 48 || event.which > 57) && event.which != 190 && event.which != 110 && (event.which < 96 || event.which > 105)) {
    //        event.preventDefault();
    //    } else {
    //        var regexp = /^\d*(\.\d{0,1})?$/;
    //        if (this.value.search(regexp) == -1) {
    //            this.value = floatprev;
    //        } else {
    //            floatprev = this.value;
    //        }
    //    }
    //});

    u_menu_ok = $(window).width() > 600 ? true : false;
    // 모달
    //$(".line_btns").on("click", "button", function () {
    //    //$(this).attr("target")
    //    var add = $("#person").val();
    //    var target = $(this).attr("target");
    //    $("#" + target).append("<option value='" + add[0] + "'>" + add[0] + "</option>");
    //});
    //$(".sort_btn").on("click", "button", function () {
    //    var target = $(this).attr("target");
    //    var action = $(this).attr("action");
    //    var selected = $("#" + target + " option:selected");
    //    if (action == "up") {
    //        var index = $(selected[0]).index();
    //        if (index == 0) return;
    //        // if(index == 1) $(selected[0]).insertBefore("#" + target + " option:nth-child(1)");
    //        $(selected[0]).insertBefore("#" + target + " option:nth-child(" + (index) + ")");
    //        for (var i = 1; i < selected.length; i++) {
    //            $(selected[i]).insertAfter(selected[i - 1]);
    //        }
    //    } else if (action == "down") {
    //        var index = $(selected[selected.length - 1]).index();
    //        if (index == $("#" + target + " option").length - 1) return;
    //        $(selected[0]).insertAfter("#" + target + " option:nth-child(" + (index + 2) + ")");
    //        for (var i = 1; i < selected.length; i++) {
    //            $(selected[i]).insertAfter(selected[i - 1]);
    //        }
    //    } else {
    //        for (var i = 0; i < selected.length; i++) {
    //            $(selected[i]).remove();
    //        }
    //    }
    //});

});

$(window).resize(function () {
    u_menu_ok = $(window).width() > 600 ? true : false;

    $('.backdrop').hide();
    $('.user_hidden_menu').removeClass('active');
});

$(window).scroll(function () {
    wind = $(window);

    if (wind.scrollTop() > 200) {
        $('#go_to_top').show();
    } else {
        $('#go_to_top').hide();
    }

    if (wind.scrollTop() <= 0) {
        $(".user_menu").css("border-bottom", "0");
        $(".user_m_ca").css("border-bottom", "0");
    } else {
        $(".user_menu").css("border-bottom", "1px solid #dadada");
        $(".user_m_ca").css("border-bottom", "1px solid #dadada");
    }
});

var pos = 0;
var ok = 1;
function v_animation(type) {

    if (ok == 1) {
        ok = 0;

        slider.on();
        var s_count = $('.view_slide_wrap ul li:last-child').index();
        $('.view_slide_wrap ul').css("width", ((s_count + 1) * 100) + "%");
        $('.view_slide_wrap ul li').css('width', (100 / (s_count + 1)) + '%');
        var str = "";
        for (var i = 0; i < s_count; i++) {
            str += "<span></span>";
        }

        $('.view_slide_po').html(str);

        switch (type) {
            case 'left':
                if (pos == 0) {
                    $('.view_slide_wrap ul').css('left', '-' + ((s_count) * 100) + '%');
                    pos = s_count - 1;
                } else {
                    pos--;
                }
                break;
            case 'right':
                pos++;
                break;
            default:
                if (pos == 0 && type == s_count - 1) {
                    $('.view_slide_wrap ul').css('left', '-' + ((s_count) * 100) + '%');
                    pos = s_count - 1;
                } else if (pos == s_count - 1 && type == 0) {
                    pos++;
                } else {
                    pos = type;
                }
                break;
        }

        var ppos = pos + 1 >= $('.view_slide_wrap ul li').length ? 1 : pos + 1;

        $('.view_slide_num p:first-child').text(ppos);
        $('.view_slide_num p:last-child').text($('.view_slide_wrap ul li').length - 1);

        $('.view_slide_wrap ul').animate({ "left": "-" + (100 * pos) + "%" }, 500, function () {
            if (pos == s_count) {
                $(this).css('left', '0%');
                pos = 0;
            }
            ok = 1;

            slider.on();
        });
    }
}

var ItsFileManager = {};
ItsFileManager.$upload = function (id, WAITSTT, CALLBACK) {
    if (location.href.indexOf('localhost') > -1) {
        alert('localhost에서는 데이터 왜곡 방지를 위해 파일업로드 기능을 제한하였습니다.');
        return;
    }
    if (document.getElementById(id) == null) {
        if (CALLBACK != undefined) {
            CALLBACK('');
            return;
        }
    }
    if (document.getElementById(id).files.length < 1) {
        if (CALLBACK != undefined) {
            CALLBACK('');
            return;
        }
    }
    if (WAITSTT == undefined || WAITSTT == '' || WAITSTT == null) {
        WAITSTT = 'N';
    }

    var formData = new FormData();
    formData.append('FILENAME', document.getElementById(id).files[0].name);
    formData.append('CALLTYPE', "UPLOAD");
    formData.append('centerYn', "N");
    formData.append('WAITSTT', WAITSTT);
    formData.append('FILEDATA', document.getElementById(id).files[0]);

    var request = new XMLHttpRequest();
    var $url = '../../CONTROLLER/FileUpload.aspx';
    request.open('POST', $url, true);
    request.setRequestHeader('Content-type', 'application/x-www-form-urlencoded');
    request.send(formData);
    request.onreadystatechange = function (e) {
        if (request.readyState == 4 && request.status == 200) {
            var imagekey = request.responseText;
            if (request.responseText.indexOf('ERROR') > -1) {
                ItsMsg.Alert(request.responseText);
                if (CALLBACK != undefined) {
                    CALLBACK('');
                    return;
                }
            }
            if (CALLBACK != undefined) {
                CALLBACK(imagekey);
                return;
            }
        } else if (request.status == 500) {
            ItsMsg.Alert(request.responseText);
            if (CALLBACK != undefined) {
                CALLBACK('');
                return;
            }
        }
    }
}

String.prototype.number_format = function () {
    return this.replace(/(\d)(?=(?:\d{3})+(?!\d))/g, '$1,');
};

Number.prototype.number_format = function () {
    var rt = String(this);
    return rt.replace(/(\d)(?=(?:\d{3})+(?!\d))/g, '$1,');
};

function getParameterByName(name) {
    name = name.replace(/[\[]/, "\\[").replace(/[\]]/, "\\]");
    var regex = new RegExp("[\\?&]" + name + "=([^&#]*)"),
        results = regex.exec(location.search);
    return results === null ? "" : decodeURIComponent(results[1].replace(/\+/g, " "));
}

function paging(recentPage, listSize, line, link) {
    // 현재페이지, 전체 행 수(count(*)), 한페이지에 표시할 행 수, href안에 넣을 링크
    // div.paging 안에 넣어야함 / link에 @을 페이지로 replace pagemove(@) -> pagemove(2)
    // recentPage = 현재페이지
    // totalPage  = 마지막페이지
    // startPage  = 맨 앞에 보이는 페이지
    // endPage    = 맨 뒤에 보이는 페이지

    var html = '<ul>';

    var totalPage = Math.ceil(listSize / line);
    if (totalPage == 1) {
        html += '<strong>1</strong>';
        html += '</ul>';
        return html;
    }
    var startPage = recentPage > 2 && totalPage > 5 ? recentPage - 2 : 1;
    var endPage = startPage + 4;
    if (totalPage <= endPage) {
        endPage = totalPage;
        startPage = (totalPage - 4 < 1 ? 1 : totalPage - 4);
    }

    if (recentPage > 3) html += '<a href="' + getLink(link, (recentPage- 5 < 1 ? 1 : recentPage - 5)) + '" class="jump"><img src="../../images/page_l.png" style="cursor:pointer"></a>';

    for (startPage; startPage <= endPage; startPage++) {

        if (startPage == recentPage) html += '<strong>' + startPage + '</strong>';
        else html += '<a href="'+ getLink(link, startPage) +'">' + startPage + '</a>';

    }

    if (endPage < totalPage) html += '<a href="' + getLink(link, (recentPage + 5 <= totalPage ? recentPage + 5 : totalPage)) + '" class="jump"><img src="../../images/page_r.png" style="cursor:pointer"></a>';

    html += '</ul>';

    return html;
}

function getLink(link, pagenum) {
    return link.replace(/[@]/g, pagenum);
}

function getComboList(id, gpcd, noval, ref01, ref02, ref03, ref04, ref05) {
    var maria = new ItsMaria('DC_COMBO', '');
    maria.AddParam("GPCD", gpcd);
    maria.AddParam("REF01", ref01);
    maria.AddParam("REF02", ref02);
    maria.AddParam("REF03", ref03);
    maria.AddParam("REF04", ref04);
    maria.AddParam("REF05", ref05);
    maria.CallProc();
    if (maria.isError) {
        maria.ShowErrMsg();
        return;
    }
    var $select = $('#' + id);
    var option = '';
    if (noval !== undefined && noval !== '') option += '<option value="">' + noval + '</option>';
    else if (noval !== undefined && noval === '') option += '<option value="">선택</option>';
    maria.store.data.forEach(function (d) {
        option += '<option value="' + d['Value'] + '">' + d['Label'] + '</option>';
    });
    $select.html(option);
}


function byte(fileSize) {
    var str;

    //MB 단위 이상일때 MB 단위로 환산
    if (fileSize >= 1024 * 1000) {
        fileSize = fileSize / (1024 * 1024);
        fileSize = fileSize.toFixed(2);
        str = fileSize + ' MB';
    }
    //KB 단위 이상일때 KB 단위로 환산
    //else if (fileSize >= 1000) {
    else {
        fileSize = fileSize / 1024;
        fileSize = fileSize.toFixed(2);
        str = fileSize + ' KB';
    }
        //KB 단위보다 작을때 byte 단위로 환산
    //else {
    //    fileSize = fileSize;
    //    str = fileSize + ' byte';
    //}
    return str;
}

function mobilemain() {
    location.href = '/PAGEGWM/GWM0000/GWM0000_R01.aspx';
}

function mobilepage() {
    location.href = location.href.replace(/GWS/g, 'GWM');
}

function mailcheck() {
    if (ItsMailService.GetEmpInfo().EMPCD == null) ItsMsg.Alert("메일서비스 미사용 유저입니다.");
}

function maillink(href) {
    if (ItsMailService.GetEmpInfo().EMPCD != null) {
        location.href = href;
    } else {
        ItsMsg.Alert("메일서비스 미사용 유저입니다.");
    }
}

function maillink2(href, href2) {
    if (ItsMailService.GetEmpInfo().EMPCD != null) {
        location.href = href;
    } else {
        ItsMsg.Alert("메일서비스 미사용 유저입니다.");
        //location.href = href2;
    }
}

function mailfunction(callback) {
    if (ItsMailService.GetEmpInfo().EMPCD != null) {
        callback();
    } else {
        ItsMsg.Alert("메일서비스 미사용 유저입니다.");
    }
}

function daumwrite() {
    var form = document.createElement('form');
    var obj1;
    obj1 = document.createElement('input');
    obj1.setAttribute('name', 'mailtp');
    obj1.setAttribute('value', 'DAUM');
    form.appendChild(obj1);
    form.setAttribute('method', 'post');
    form.setAttribute('action', "../GWS1001/GWS1001_R01.aspx");
    document.body.appendChild(form);
    form.submit();
}

function StateBtn(state) {
    switch (state) {
        case 'W':
            return '<td><button><img src="../../images/statebtn_01.png"></button></td>';
            break;
        case 'I':
            return '<td><button><img src="../../images/statebtn_02.png"></button></td>';
            break;
        case 'S':
            return '<td><button><img src="../../images/statebtn_03.png"></button></td>';
            break;
        case 'C':
            return '<td><button><img src="../../images/statebtn_04.png"></button></td>';
            break;
        case 'F':
            return '<td><button><img src="../../images/statebtn_05.png"></button></td>';
            break;
        case 'H':
            return '<td><button><img src="../../images/statebtn_06.png"></button></td>';
            break;
        default:
            break;
    }
}