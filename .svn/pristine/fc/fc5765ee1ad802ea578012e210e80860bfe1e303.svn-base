$(function(){
    //다른 추천 제품 슬라이드
    rotate_init();

    var rotate_ok = true;
    $('.rotate_list_wrap>.arrows').on('click', function(e){
        e.preventDefault();

        if (rotate_ok == false) return false;
        rotate_ok = false;

        var t_ul = $(this).siblings('.rotate_wrap').children('ul');
        var w_li = t_ul.children('li').width();

        if (t_ul.width() <= $(this).siblings('.rotate_wrap').width()) return false;

        if ($(this).hasClass('right')) { //Right

            t_ul.animate({"left" : "-" + w_li + "px"}, 300, function(){
                t_ul.append(t_ul.children('li:first-child').clone());
                t_ul.children('li:first-child').remove();
                t_ul.css({"left" : "0"});
                rotate_ok = true;
            });

        } else { //Left

            t_ul.css({"left" : "-" + w_li + "px"}).prepend(t_ul.children('li:last-child').clone());
            t_ul.children('li:last-child').remove();
            t_ul.animate({"left" : "0"}, 300, function(){
                rotate_ok = true;
            });

        }

    });
});

$(window).resize(function(){
    rotate_init();
});

function rotate_init() {
    $('.rotate_list_wrap .rotate_wrap ul li').width($('.rotate_list_wrap .rotate_wrap').width() / $('.rotate_list_wrap .rotate_wrap').attr('data-ind'));
    $('.rotate_list_wrap .rotate_wrap ul').width($('.rotate_list_wrap .rotate_wrap ul li').width() * $('.rotate_list_wrap .rotate_wrap ul li').length);
}