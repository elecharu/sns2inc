$(function () {
    win_resize();
});
//window-onload

$(window).resize(function () {
    win_resize();
});

//window-resize
function win_resize() {

    var wi = $(window).width();

    if (wi <= 425) { //425px

        table_reaction(425);

    } else if (wi <= 768) { //768px

        table_reaction(768);

    } else {
        $('.reaction').each(function () {

            if ($(this).hasClass('re_768') || $(this).hasClass('re_425')) {

                $(this).removeClass('re_768 re_425');

                $(this).find('col').show();

                $(this).find('th').show();

                $(this).find('td').show();

                $(this).find('.reaction_wrap').remove();

            }

        });
    }

}

//Table 반응형
function table_reaction(wi) {

    var re = wi == 768 ? "re_768" : "re_425";

    $('.reaction').each(function () {

        var re_array = [];
        var area_ind = 0;
        var re_text_array = [];
        var re_title_array = [];
        var str = '';

        if ((!$(this).hasClass('re_768') && wi == 768) || (!$(this).hasClass('re_425') && wi == 425)) {

            $(this).find('thead').find('tr').find('th').each(function () {

                if ($(this).hasClass('area')) area_ind = $(this).index();

                if (re == 're_768') {

                    if ($(this).hasClass('re_768')) {
                        re_array.push($(this).index());

                        re_title_array.push($(this).text());

                        $(this).hide();
                    }

                } else {

                    if ($(this).hasClass('re')) {
                        re_array.push($(this).index());

                        re_title_array.push($(this).text());

                        $(this).hide();
                    }

                }


            });

            $(this).find('colgroup').find('col').each(function () {

                for (var i = 0; i < re_array.length; i++) {

                    if ($(this).index() == re_array[i]) $(this).hide();

                }

            });

            $(this).find('tbody').find('tr').each(function () {

                $(this).find('td').each(function () {

                    for (var i = 0; i < re_array.length; i++) {

                        if ($(this).index() == re_array[i]) {
                            re_text_array.push('<span> <strong>' + re_title_array[i] + '</strong> : ' + $(this).text() + '</span>');

                            $(this).hide();
                        }

                    }

                    if ($(this).index() == area_ind && $('.reaction_wrap', this).html() == undefined) $(this).append('<div class="reaction_wrap"></div>');

                });

                str = '';
                for (var i = 0; i < re_text_array.length; i++) {

                    str += re_text_array[i];

                }

                $(this).find('.reaction_wrap').html(str);

                re_text_array = [];

            });

            $(this).addClass(re);

        }

    });
}