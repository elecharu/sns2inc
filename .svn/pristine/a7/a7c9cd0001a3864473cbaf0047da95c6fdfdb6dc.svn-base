$(function () {

    setTimeout(function () {
        img_resize();
    }, 300);

});
//window-onload

$(window).resize(function () {

    img_resize();

});

//img-resize
function img_resize() {
    $('.resize_img').each(function () {

        $(this).css({
            'width': '101%',
            "height": "auto",
            "position": "absolute",
            "top": "50%",
            "left": "50%",
            "transform": "translate(-50%, -50%)"
        });

        $(this).parent().css('position', 'relative');

        if ($(this).height() < $(this).parent().height()) {
            $(this).css({
                'height': '101%',
                "width": "auto"
            });
        }

    });
}