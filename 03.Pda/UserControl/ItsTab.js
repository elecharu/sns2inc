/********************************************
 * >>>>> ItsTab: 탭패널 컨트롤 >>>>>
 * 2018-08-14: 문재원: 최초 작성
 *******************************************/
var ItsTab = {
    list: [],
    Init: function () {
        var TabList = $('div.ItsTab');
        for (var i = 0; i < TabList.length; i++) {
            var key = TabList.eq(i).attr('id');
            ItsTab.list.push(
                new wijmo.nav.TabPanel('#' + key, {
                    selectedIndexChanged: function (s, e) {

                        setTimeout(function () {
                            $('.wj-tabpanes').each(function (i, e) {
                                var $height = $(this).parent().parent().height() - $(this).siblings().eq(0).height();
                                $(this).height($height);
                            });
                            ItsSplit.Resize($('#' + key).find('[role=tabpanel]').eq(s.selectedIndex));
                            // 탭 내부 그리드 subtotal 깨짐 현상 방지
                            $('.wj-tabpanes').find('.wj-btn.wj-btn-glyph.wj-elem-collapse').parent().css('width', 500);
                            $('.wj-tabpanes').find('.wj-btn.wj-btn-glyph.wj-elem-collapse').parent().css('z-index', 5);
                        }, 1);
                        if (s._e.initState === false) {
                            ItsTab.Event(key).onTabChanged(s.selectedIndex);
                        }
                        s._e.initState = false;
                    }
            }));
            ItsTab.list.forEach(function (tab) {
                tab.initState = true;
            })
        }
    },
    Select: function(id, index) {
        ItsTab.list.forEach(function (t) {
            if (t._e.id == id) {
                t.selectedIndex = index;
            }
        })
    },
    /** 
    @returns {ItsTab.Listener} 
    */
    Event: function (key) {
        if (ItsPage.EventList[key] == undefined) {
            ItsPage.EventList[key] = new ItsTab.Listener();
        }
        return ItsPage.EventList[key];
    },
    Listener: function () {
        this.onTabChanged = function (newPanel) { };
    }
};