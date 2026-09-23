/// <reference path="../Script/reference.js" />
var ItsSplit = {
    splitBar: null,
    Init: function () {

        $(".SplitVBar").parent().css('overflow', 'hidden');
        $(".SplitHBar").parent().css('overflow', 'hidden');

        $(".SplitVBar").add('.SplitHBar').on('dblclick', function (e) {
            var $parent = $(this).parent();
            ItsSplit.Resize($parent);
        });

        // 좌우 Splitter 이벤트
        $(".SplitVBar").on("mousedown", function (e) {
            ItsSplit.splitBar = $(this);

            var $mainBody = $('#MAIN_BODY');
            $mainBody.css('cursor', 'col-resize');
            $mainBody.unbind('mousemove');
            $mainBody.unbind('mouseup');
            $mainBody.on('mousemove', function (e) {
                var $splitDrag = $('#SplitDragV');
                $splitDrag.css('display', 'block');
                $splitDrag.css('left', e.pageX + 'px');
                var $splitFocus = $('#SplitDragF');
                $splitFocus.focus();
            });
            $mainBody.on('mouseup', function (e) {

                if ($("#SplitDragV").css('display') != 'none') {

                    var $split = ItsSplit.splitBar;
                    var $parent = $split.parent();
                    var $left = $parent.children('.SplitLeft');
                    var $right = $parent.children('.SplitRight');

                    var pLeft = $parent.offset().left;
                    var pWidth = $parent.outerWidth();
                    var pPad = parseInt($parent.css('padding-left'));
                    var sWidth = $split.outerWidth();

                    var leftWidth = e.pageX - pLeft - 2 * pPad;
                    if (leftWidth < 10) leftWidth = 10;
                    if (leftWidth > pWidth - 10) leftWidth = pWidth - 10;
                    $left.outerWidth(leftWidth);

                    var rightWidth = pWidth - leftWidth - sWidth - 4 * pPad;
                    $right.outerWidth(rightWidth);

                    ItsSplit.Resize($left);
                    ItsSplit.Resize($right);
                }

                ItsSplit.splitBar = null;
                $(this).css('cursor', '');
                $("#SplitDragV").css('display', 'none');
                $(this).unbind('mousemove');
                $(this).unbind('mouseup');
            });
        });

        // 상하 스크롤바 클릭시
        $(".SplitHBar").on("mousedown", function (e) {

            ItsSplit.splitBar = $(this);

            var $mainBody = $('#MAIN_BODY');
            $mainBody.css('cursor', 'row-resize');
            $mainBody.unbind('mousemove');
            $mainBody.unbind('mouseup');
            $mainBody.on('mousemove', function (e) {

                var $splitDrag = $('#SplitDragH');
                $splitDrag.css('display', 'block');
                $splitDrag.css('top', e.pageY + 'px');

                var $splitFocus = $('#SplitDragF');
                $splitFocus.focus();
            });
            $mainBody.on('mouseup', function (e) {

                if ($("#SplitDragH").css('display') != 'none') {

                    var $split = ItsSplit.splitBar;
                    var $parent = $split.parent();
                    var $top = $parent.children('.SplitTop');
                    var $down = $parent.children('.SplitDown');

                    var pTop = $parent.offset().top;
                    var pPad = parseInt($parent.css('padding-left'));
                    var pHeight = $parent.outerHeight();
                    var sHeight = $split.outerHeight();

                    var topHeight = e.pageY - pTop - 2 * pPad;
                    if (topHeight < 10) topHeight = 10;
                    if (topHeight > pHeight - 10) topHeight = pHeight - 10;
                    $top.outerHeight(topHeight);

                    var downHeight = pHeight - topHeight - sHeight - 4 * pPad;
                    $down.outerHeight(downHeight);

                    ItsSplit.Resize($top);
                    ItsSplit.Resize($down);
                }

                ItsSplit.splitBar = null;
                $(this).css('cursor', '');
                $("#SplitDragH").css('display', 'none');
                $(this).unbind('mousemove');
                $(this).unbind('mouseup');
            });
        });
    },
    Resize: function (parent) {
        ItsGrid.list.forEach(function (grid) {
            grid.refresh();
        });
        var $cls = parent.children().eq(0).attr('class');
        if ($cls == undefined) return;
        if ($cls.indexOf('wj-tabpanel') > -1) {
            parent = parent.find('[role=tabpanel]');
            for (var i = 0; i < parent.length; i++) {
                ItsSplit._$Resize(parent.eq(i));
            }
        } else {
            ItsSplit._$Resize(parent);
        }
        // 그리드 subtotal 깨짐 현상 방지
        $('.wj-btn.wj-btn-glyph.wj-elem-collapse').parent().css('width', 500);
        $('.wj-btn.wj-btn-glyph.wj-elem-collapse').parent().css('z-index', 5);
    }
};
ItsSplit._$Resize = function (obj) {
    obj.children('.SplitLeft').css('width', 'auto');
    //obj.children('.SplitLeft').css('height', '100%');
    //obj.children('.SplitRight').css('width', 'auto');
    //obj.children('.SplitRight').css('height', '100%');
    obj.children('.SplitTop').css('height', 'auto');
    //obj.children('.SplitTop').css('width', '100%');
    //obj.children('.SplitDown').css('height', 'auto');
    //obj.children('.SplitDown').css('width', '100%');
    //obj.children('.SplitSingle').css('width', '100%');
    //obj.children('.SplitSingle').css('height', '100%');

    var $split = obj.children('.SplitVBar');
    if ($split != undefined && $split != null && $split.length > 0) {
        $split.css('height', '100%');
        var $left = obj.children('.SplitLeft');
        var $right = obj.children('.SplitRight');
        var pPad = parseInt(obj.css('padding-left'));
        var pWidth = obj.outerWidth();
        var leftwidthpc = $left.attr('data-leftwidthpc');
        if (leftwidthpc != "" && leftwidthpc != undefined) {
            $left.outerWidth('calc(' + leftwidthpc + '% - ' + 2 * pPad + 'px)');
            $right.outerWidth('calc(' + (100 - 0.3 - parseFloat(leftwidthpc)) + '% - ' + 2 * pPad + 'px)');
        } else {
            var splitLeft = ItsPage.Position($split).left;
            var splitWidth = $split.outerWidth();
            $left.outerWidth(splitLeft - 2 * pPad);
            $right.outerWidth(pWidth - splitLeft - splitWidth - 2 * pPad);
        }
        ItsSplit.Resize($left);
        ItsSplit.Resize($right);
    }
    var $split = obj.children('.SplitHBar');
    if ($split != undefined && $split != null && $split.length > 0) {
        $split.css('width', '100%');
        var $top = obj.children('.SplitTop');
        var $down = obj.children('.SplitDown');
        var pHeight = obj.outerHeight();
        var pPad = parseInt(obj.css('padding-left'));
        var topheightpc = $top.attr('data-topheightpc');
        if (topheightpc != "" && topheightpc != undefined) {
            $top.outerHeight('calc(' + topheightpc + '% - ' + 2 * pPad + 'px)');
            $down.outerHeight('calc(' + (100 - parseFloat(topheightpc)) + '% - ' + 2 * pPad + 'px)');
        } else {
            var splitTop = ItsPage.Position($split).top;
            var splitHeight = $split.outerHeight();
            $top.outerHeight(splitTop - 2 * pPad);
            $down.outerHeight(pHeight - splitTop - splitHeight - 2 * pPad);
        }
        ItsSplit.Resize($top);
        ItsSplit.Resize($down);
    }
}