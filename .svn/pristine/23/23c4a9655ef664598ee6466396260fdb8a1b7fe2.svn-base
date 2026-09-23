$(function(){
    //탭메뉴
    $('.tab_menu > li').on('click', function (e) {
        e.preventDefault();

        if ($(this).attr('data-url') != undefined) {

            if ($(this).attr('data-url').search('download') != -1) {

                $('body').append('<a href="' + $(this).attr('data-url') + '" download class="download_btn"></a>');

                $('.download_btn')[0].click();

                $('.download_btn').remove();

            } else if ($(this).attr('target') == '_blank') {

                window.open($(this).attr('data-url'));

            } else {

                location.href = $(this).attr('data-url');

            }

        } else {

            $(this).parent().children('li').removeClass('active');

            if ($(this).hasClass('sub_ok')) {
                var ind = $(this).index();

                $(this).next().addClass('active');
            } else if ($(this).hasClass('sub') && $(this).prev().hasClass('sub_ok')) {
                var ind = $(this).index() - 1;

                $(this).addClass('active');
            } else {
                var ind = $(this).index();

                $(this).addClass('active');
            }

            $(".tab_content[data-tab='" + $(this).parent().attr('data-tab') + "']").children('div').hide();

            if (!$(this).parent().hasClass('not_fade')) {

                $(".tab_content[data-tab='" + $(this).parent().attr('data-tab') + "']").each(function () {

                    $(this).children('div').eq(ind).fadeIn(500);

                });

            } else {

                $(".tab_content[data-tab='" + $(this).parent().attr('data-tab') + "']").each(function () {

                    $(this).children('div').eq(ind).show();

                });

            }

        }

    });
});