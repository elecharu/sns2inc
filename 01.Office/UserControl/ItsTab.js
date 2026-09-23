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
                            ItsSplit.Resize($('#' + s.hostElement.id).find('[role=tabpanel]').eq(s.selectedIndex));
                        }, 1);
                        if (s._e.initState === false) {
                            ItsTab.Event(s.hostElement.id).onTabChanged(s.selectedIndex);
                        }
                        s._e.initState = false;
                    }
            }));
            ItsTab.list.forEach(function (tab) {
                tab.initState = true;
            })
        }
    },
    Get: function (id) {
        try {
            for (var i = 0; i < ItsTab.list.length; i++) {
                if (id == ItsTab.list[i]._e.id) {
                    return ItsTab.list[i];
                }
            }
        } catch (e) { return undefined; }

    },
    GetIndex: function(id) {
        return ItsTab.Get(id).selectedIndex;
    },
    Select: function(id, index) {
        ItsTab.list.forEach(function (t) {
            if (t._e.id == id) {
                t.selectedIndex = index;
            }
        })
    },
    Enable: function (id, index) {
        ItsTab.Get(id).tabs[index].isDisabled = false;
    },
    Disable: function(id, index) {
        ItsTab.Get(id).tabs[index].isDisabled = true;
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