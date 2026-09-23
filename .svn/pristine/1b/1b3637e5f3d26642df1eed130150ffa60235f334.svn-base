$(function () {

    visual_set();

});

//비주얼 설정
var visual = {};

function visual_set() {

    $('.visual').each(function (key) {

        $(this).attr('data-visual-key', key);

        var th = this;

        if ($(this).attr('data-visual-auto') == 'on') {

            visual['slider' + key] = {
                on: function () {
                    visual['slider' + key].off();
                    this.timer = setTimeout(function (e) {
                        $(th).find('.arrows.right').click();
                    }, parseInt($(th).attr('data-visual-delay')));

                },
                off: function () {
                    clearTimeout(this.timer);
                }
            }

            visual['slider' + $(th).attr('data-visual-key')].on();

        }

        if ($(this).attr('data-visual-auto') == 'on') {

            $(this).find('.pos_wrap').append('<a href="./" class="stop auto_key clearfix"><span>1</span><span>2</span></a>');

        }

        $(this).find('ul li').each(function (key) {

            if (key == 0) var active = "active";

            if ($(th).attr('data-visual-pos_type') == 'thumb') {

                $(this).parent().siblings('.pos_wrap').append('<a href="./" class="' + active + '" data-visual-ind="' + key + '">' + $(this).find('.image_wrap').html() + '</a>');

            } else {

                $(this).parent().siblings('.pos_wrap').append('<a href="./" class="' + active + '" data-visual-ind="' + key + '">' + key + '</a>');

            }

        });

        $(this).attr('data-visual-ind', '0').attr('data-visual-ok', 'true');

        visual_event(this);

        if ($(this).attr('data-visual-img_type') == "full") {
        }
        
        setTimeout(function () {
            visual_img_resize(th);

            $('.ibox-content').fadeOut(500, function(){

                $('.main_wrap .text_wrap').addClass('active');

                setTimeout(function(){

                    $('.main_wrap .text_wrap p').addClass('active');

                }, 400);

            });
        }, 500);
        
        $(window).resize(function () {

            if ($(th).attr('data-visual-img_type') == "full") {
                visual_img_resize(th);
            }

        });

        if ($(this).hasClass('reaction')) {

            $(this).prepend($(this).find('ul li:first-child .image_wrap *:first-child').clone());

            if ($(this).attr('data-visual-max') == 'full') {

                $(this).children('img, video').css({
                    "width": "auto",
                    "height": "101vh"
                });

                $(this).css({
                    "min-height": $(this).attr('data-visual-min') + "px",
                    "max-height": "101vh"
                });

            } else {

                $(this).css({
                    "min-height": $(this).attr('data-visual-min') + "px",
                    "max-height": $(this).attr('data-visual-max') + "px"
                });

            }

        }

    });

}

//비주얼 이미지 설정
function visual_img_resize(th) {

    $(th).find('ul li').each(function () {

        var img_ob = $(this).find('.image_wrap *:first-child').css('display') != 'none' ? $(this).find('.image_wrap *:first-child') : $(this).find('.image_wrap *:last-child');

        img_ob.css({
            'width': '101%',
            "height": "auto"
        });

        if (img_ob.height() < img_ob.parent().height()) {
            img_ob.css({
                "width": "auto",
                "height": "101%"
            });
        }

    });

}

//비주얼 이벤트
function visual_event(th) {

    $(th).find('.pos_wrap a').on('click', function (e) {

        e.preventDefault();

        if ($(th).attr('data-visual-ok') == 'true' && !$(this).hasClass('active') && !$(this).hasClass('auto_key')) {

            $(th).attr('data-visual-ok', 'false');

            visual_animation($(this).attr('data-visual-ind'), th);

        }

        if ($(this).hasClass('stop')) {

            $(this).removeClass('stop').addClass('play');

            visual["slider" + $(th).attr('data-visual-key')].off();

        } else if ($(this).hasClass('play')) {

            $(this).removeClass('play').addClass('stop');

            visual["slider" + $(th).attr('data-visual-key')].on();

        }

    });

    $(th).find('.arrows').on('click', function (e) {

        e.preventDefault();

        if ($(th).attr('data-visual-ok') == 'true') {

            $(th).attr('data-visual-ok', 'false');

            var visual_total = $(th).find('ul li').length - 1;

            if ($(this).hasClass('left')) { //LeftButton

                var ind = parseInt($(th).attr('data-visual-ind')) == 0 ? visual_total : parseInt($(th).attr('data-visual-ind')) - 1;

                visual_animation(ind, th);

            } else { //RightButton

                var ind = parseInt($(th).attr('data-visual-ind')) == visual_total ? 0 : parseInt($(th).attr('data-visual-ind')) + 1;

                visual_animation(ind, th);

            }

        }

    });

}

//비주얼 애니메이션
function visual_animation(ind, th) {

    var type = 0;
    var ac_type = 0;
    var visual_total = $(th).find('ul li').length - 1;
    var way = 'left';
    if ($(th).attr('data-visual-way') == 'up') way = 'top';

    if (ind < parseInt($(th).attr('data-visual-ind'))) {
        type = -100;
        ac_type = 100;
    } else {
        type = 100;
        ac_type = -100;
    }

    if (parseInt($(th).attr('data-visual-ind')) == 0 && ind == visual_total) {
        type = -100;
        ac_type = 100;
    } else if (parseInt($(th).attr('data-visual-ind')) == visual_total && ind == 0) {
        type = 100;
        ac_type = -100;
    }

    $(th).attr('data-visual-ind', ind);

    $(th).find('.pos_wrap a').removeClass('active');

    $(th).find('.pos_wrap a[data-visual-ind="' + ind + '"]').addClass('active');

    if ($(th).attr('data-visual-type') == 'slide') {

        if ($(th).attr('data-visual-slide-type') == "top") {

            $(th).find('ul li.active').animate({
                "top": ac_type + "%"
            }, parseInt($(th).attr('data-visual-duration')), function () {

                if ($('video', this).html() != undefined) {

                    var vid = $('video', this)[0];

                    vid.pause();

                }

            });

            $(th).find('ul li').eq(ind).css({"z-index": "2", "top": type + "%"}).animate({"top": "0%"}, parseInt($(th).attr('data-visual-duration')), function () {

                $(th).find('ul li.active').css('z-index', '1').removeClass('active');

                $(this).css({"z-index": "1"}).addClass('active');

                $(th).attr('data-visual-ok', 'true');

                if ($(th).attr('data-visual-auto') == 'on' && $(th).find('.pos_wrap a.auto_key').hasClass('stop')) {
                    visual['slider' + $(th).attr('data-visual-key')].on();
                }

                if ($('video', this).html() != undefined) {

                    var vid = $('video', this)[0];

                    vid.play();

                    visual['slider' + $(th).attr('data-visual-key')].off();

                    video_time_check($('video', this)[0], $(th).attr('data-visual-key'));

                }

            });

        } else {

            $(th).find('ul li.active').animate({"left": ac_type + "%"}, parseInt($(th).attr('data-visual-duration')), function () {

                if ($('video', this).html() != undefined) {

                    var vid = $('video', this)[0];

                    vid.pause();

                }

            });

            $(th).find('ul li').eq(ind).css({"z-index": "2", "left": type + "%"}).animate({"left": "0%"}, parseInt($(th).attr('data-visual-duration')), function () {

                $(th).find('ul li.active').css('z-index', '1').removeClass('active');

                $(this).css({"z-index": "1"}).addClass('active');

                $(th).attr('data-visual-ok', 'true');

                if ($(th).attr('data-visual-auto') == 'on' && $(th).find('.pos_wrap a.auto_key').hasClass('stop')) {
                    visual['slider' + $(th).attr('data-visual-key')].on();
                }

                if ($('video', this).html() != undefined) {

                    var vid = $('video', this)[0];

                    vid.play();

                    visual['slider' + $(th).attr('data-visual-key')].off();

                    video_time_check($('video', this)[0], $(th).attr('data-visual-key'));

                }

            });

        }

    } else {

        if ($(th).find('ul li').eq(ind).find('video').html() != undefined) {
            $('.header_wrap').addClass('video');
        } else {
            $('.header_wrap').removeClass('video');
        }

        $(th).find('ul li').eq(ind).css({"z-index": "2"}).animate({"opacity": "1"}, parseInt($(th).attr('data-visual-duration')));

        $(th).find('ul li.active').css('z-index', '1').animate({"opacity": "0"}, parseInt($(th).attr('data-visual-duration')), function () {
            $(th).find('ul li.active').css('z-index', '0').removeClass('active');

            $(th).find('ul li').eq(ind).addClass('active');

            $(th).attr('data-visual-ok', 'true');

            if ($(th).attr('data-visual-auto') == 'on' && $(th).find('.pos_wrap a.auto_key').hasClass('stop')) {
                visual['slider' + $(th).attr('data-visual-key')].on();
            }
        });

    }

}

//동영상 시간 체크
function video_time_check(vid, visual_key) {

    var current = vid.currentTime;

    var duration = vid.duration;

    if (current == duration) {

        visual['slider' + visual_key].on();

    } else {

        setTimeout(function () {
            video_time_check(vid, visual_key);
        }, 1000);

    }

}