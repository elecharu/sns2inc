$(function () {

    //사용자 메인 메뉴
    u_menu_ok = $(window).width() > 600 ? true : false;
    $('.mpusernm').text(GET_COOKIE('MPUSERNM'));
    $('.mpusergrade').text(GET_COOKIE('MPUSERDEPT') + ' ' + GET_COOKIE('MPUSERJOBGRADE'));
    $('.mpuserimg').attr('src', GET_COOKIE('MPUSERIMG'));

    $('.user_m_ca').on('click', function (e) {


        if ($(this).hasClass('active')) {
            $(this).removeClass('active')

            if (u_menu_ok == true) {
                $(".user_hidden_menu").stop().slideUp("fast");
                $(".user_hidden_menu").removeClass("active");
            }
        } else {
            $(this).addClass('active');

            $('.user_hidden_menu').stop().slideDown('fast');
            $('.user_hidden_menu').addClass('active');


        }

        // $("#hiddenCategory").customScrollbar();

    });



    $(document).mouseup(function (e) {

        if ($(window).width() > 600) {

            var area = $(".user_hidden_menu, .user_m_ca");

            var container = $(".user_hidden_menu");

            if (area.has(e.target).length === 0) {
                container.stop().slideUp("fast");
                container.removeClass("active");
                $(".user_m_ca").removeClass("active");
            }
        }
    });








    // 메인메뉴 닫기 버튼
    $(".user_hidden_close_btn").on("click", function () {
        $(this).parent().stop().slideUp("fast");
        $(this).parent().removeClass("active");
        $(".user_m_ca").removeClass("active");
        $(".user_m_ca h1").removeClass("active");
    })




    // 서브페이지 왼쪽 공통 메뉴
    $(".con_wrapper_left > ul > li > a").on("click", function () {
        $(this).parent().toggleClass('active');

        // if($(this).parent().hasClass("active")){
        //     $(".con_wrapper_left > ul > li").removeClass("active");
        // } else {
        //     $(".con_wrapper_left > ul > li").removeClass("active");
        //
        //     $(this).parent().addClass("active")
        // }

        var submenu = $(this).next("ul");

        if (submenu.is(":visible")) {
            submenu.slideUp('fast');
        } else {
            submenu.slideDown('fast');
        }
    });

    // common top slide
    $('.slide_btn').on('click', function (e) {
        e.preventDefault();
        if ($(this).hasClass('left')) {
            v_animation('left');
        } else {
            v_animation('right');
        }
        // slide_count();
    });


    //모바일 메뉴
    $('.m_toggle_btn').on('click', function (e) {
        e.preventDefault();

        $('.user_hidden_menu').toggleClass('active');

        if ($('.user_hidden_menu').hasClass('active')) {

            $('.backdrop').fadeIn('fast');
            $('body').addClass('noscroll');

        } else {
            
            $('.backdrop').fadeOut('fast');
            $('body').removeClass('noscroll');

        }

    });

    $('.backdrop').on('click', function () {
        if ($('.user_hidden_menu').hasClass('active')) $('.m_toggle_btn')[0].click();
    });

    // 우측 메뉴
    $('#cssmenu li.has-sub>a').on('click', function(){
        //$(this).removeAttr('href');
        var element = $(this).parent('li');
        if (element.hasClass('open')) {
            element.removeClass('open');
            element.find('li').removeClass('open');
            element.find('ul').slideUp('fast');
        } else {
            element.addClass('open');
            element.children('ul').slideDown('fast');
            element.siblings('li').children('ul').slideUp('fast');
            element.siblings('li').removeClass('open');
            element.siblings('li').find('li').removeClass('open');
            element.siblings('li').find('ul').slideUp('fast');
        }
    });

    $('#cssmenu>ul>li.has-sub>a').append('<span class="holder"></span>');

    (function getColor() {
        var r, g, b;
        var textColor = $('#cssmenu').css('color');
        textColor = textColor.slice(4);
        r = textColor.slice(0, textColor.indexOf(','));
        textColor = textColor.slice(textColor.indexOf(' ') + 1);
        g = textColor.slice(0, textColor.indexOf(','));
        textColor = textColor.slice(textColor.indexOf(' ') + 1);
        b = textColor.slice(0, textColor.indexOf(')'));
        var l = rgbToHsl(r, g, b);
        if (l > 0.7) {
            $('#cssmenu>ul>li>a').css('text-shadow', '0 1px 1px rgba(0, 0, 0, .35)');
            $('#cssmenu>ul>li>a>span').css('border-color', 'rgba(0, 0, 0, .35)');
        }
        else
        {
            $('#cssmenu>ul>li>a').css('text-shadow', '0 1px 0 rgba(255, 255, 255, .35)');
            $('#cssmenu>ul>li>a>span').css('border-color', 'rgba(255, 255, 255, .35)');
        }
    })();

    function rgbToHsl(r, g, b) {
        r /= 255, g /= 255, b /= 255;
        var max = Math.max(r, g, b), min = Math.min(r, g, b);
        var h, s, l = (max + min) / 2;

        if(max == min){
            h = s = 0;
        }
        else {
            var d = max - min;
            s = l > 0.5 ? d / (2 - max - min) : d / (max + min);
            switch(max){
                case r: h = (g - b) / d + (g < b ? 6 : 0); break;
                case g: h = (b - r) / d + 2; break;
                case b: h = (r - g) / d + 4; break;
            }
            h /= 6;
        }
        return l;
    }

});
//window-onload




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

function pcmain() {
    location.href = '/PAGEGWS/GWS0000/GWS0000_R01.aspx';
}

function pcpage() {
    location.href = location.href.replace(/GWM/g, 'GWS');
}

function mailcheck() {
    if (ItsMailService.GetEmpInfo().EMPCD == null) ItsMsg.Alert("메일서비스 미사용 유저입니다.", function () { location.href='/PAGEGWM/GWM0000/GWS0000_R01.aspx' });
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
        location.href = href2;
    }
}

function mailfunction(callback) {
    if (ItsMailService.GetEmpInfo().EMPCD != null) {
        callback();
    } else {
        ItsMsg.Alert("메일서비스 미사용 유저입니다.");
    }
}

function StateImg(state) {
    switch (state) {
        case 'W':
            return '<img class="stateimg" src="../../images/statebtn_01.png">';
            break;
        case 'I':
            return '<img class="stateimg" src="../../images/statebtn_02.png">';
            break;
        case 'S':
            return '<img class="stateimg" src="../../images/statebtn_03.png">';
            break;
        case 'C':
            return '<img class="stateimg" src="../../images/statebtn_04.png">';
            break;
        case 'F':
            return '<img class="stateimg" src="../../images/statebtn_05.png">';
            break;
        case 'H':
            return '<img class="stateimg" src="../../images/statebtn_06.png">';
            break;
        default:
            break;
    }
}

function signbox(seq) {
    var form = document.createElement('form');
    var objs;
    objs = document.createElement('input');
    objs.setAttribute('name', 'seq');
    objs.setAttribute('value', seq);
    form.appendChild(objs);
    form.setAttribute('method', 'post');
    form.setAttribute('action', "/PAGEGWM/GWM2002/GWM2002_S11.aspx");
    form.style.display = 'none';
    document.body.appendChild(form);
    form.submit();
}