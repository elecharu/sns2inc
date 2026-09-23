/// <reference path="../../Script/reference.js" />

/* 페이지 접근 시 수행 */
ItsPage.Load = function () {
    $('.title-text').html('메뉴선택');
    $('.BasicBlock').css('background-color', 'transparent');

    // TMLUID 세팅
    $.ajax({
        async: false,
        url: '../../Controller/SetCookie.aspx',
        type: 'post',
        success: function (data, staus) {
            SET_COOKIE('TMLUID', data);
        },
        error: function (xhr, status, error) {
            alert('TMLUID SETTING ERROR');
        }
    });

    $('.menu').on('click', function () {
        var menupath = $(this).data('menupath');
        location.href = menupath;
    });
};
