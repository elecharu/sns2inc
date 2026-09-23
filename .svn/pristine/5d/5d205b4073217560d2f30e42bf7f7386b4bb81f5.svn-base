$(function(){
    //토글 show hide
    $('.toggle_btn').on('click', function (e) {
        e.preventDefault();

        var to_ob = $('.toggle_content[data-toggle="' + $(this).attr('data-toggle') + '"]');

        switch (to_ob.attr('data-toggle-type')) {
            case 'slide':
                if (to_ob.css('display') == 'block') {
                    to_ob.slideUp(parseInt(to_ob.attr('data-toggle-duration')));
                } else {
                    to_ob.slideDown(parseInt(to_ob.attr('data-toggle-duration')));
                }
                break;
            case 'fade':
                if (to_ob.css('display') == 'block') {
                    to_ob.fadeOut(parseInt(to_ob.attr('data-toggle-duration')));
                } else {
                    to_ob.fadeIn(parseInt(to_ob.attr('data-toggle-duration')));
                }
                break;
            case 'none':
                if (to_ob.css('display') == 'block') {
                    to_ob.hide();
                } else {
                    to_ob.show();
                }
                break;
        }

    });
});