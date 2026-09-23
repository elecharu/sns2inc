/// <reference path="../../Script/reference.js" />

var calendar;

ItsPage.Load = function () {
    setCalendar();

    setEvent();

    ///* 기본버튼 커스터마이징 */
    //ItsButton.StyleAdd('작업시간 일괄등록', undefined, 'fa fa-plus');

};

/* 조회 */
ItsButton.EventSearch = function (YMD) {
    if (YMD == '' || YMD == undefined || YMD == null) {
        YMD = getCalendarDate();
    }
    if (typeof (YMD) != typeof ('string')) {
        YMD = getCalendarDate();
    }
    calendar.render();
    setEvent();
    ItsMsg.Toast(ItsMsg.CommonMsg.SearchComplete());
};

// 캘린더 디자인 생성
function setCalendar() {
    calendar = new FullCalendar.Calendar(document.getElementById('calendar'), {
        plugins: ['dayGrid', 'timeGrid', 'interaction', 'list'],
        locale: 'ko',
        eventOrder: '-backgroundColor',
        views: {
            dayGridMonth: {
                buttonText: '월간',
            },
            listWeek: { buttonText: '주간' },
            listDay: { buttonText: '일일' }
        },
        header: {
            left: 'comp,dpt,att',
            center: 'prev title next',
            right: 'dayGridMonth,listWeek,listDay'
        },
        defaultDate: ItsHelper.GetYearMonthDay(),
        dateClick: function (info) {
            var day = '';
            //$("#sday, #eday").val(info.dateStr);
            //$("#addSchedule").modal({ backdrop: 'static', keyboard: false, attentionAnimation: '' });
            if (info.view.title.replace('월', '').substr(6, 2) < 10)
                day = 0 + info.view.title.replace('월', '').substr(6, 2);
            else
                day = info.view.title.replace('월', '').substr(6, 2);
            
            if (day == info.dateStr.substr(5, 2)) {
                ItsDate.SetValue('date_WORKDATE_pdiv2', info.dateStr);

                var maria = new ItsMaria('PRD9001_R02', 'GET_WORKTIME');
                maria.AddParam('WORKDATE', info.dateStr);
                maria.CallProc();
                if (maria.isError) {
                    maria.ShowErrMsg();
                    return;
                }
                ItsPage.SetStore('pdiv2', maria.store.FirstRecord());
                ItsPop.Open('pop2');
            }
            else
                return;            
        },
        allDaySlot: false,
        slotEventOverlap: false,

        noEventsMessage: '등록된 작업시간이 없습니다.',
        height: 700,
    });
    calendar.render();
}
var $events = [];

function setEvent(YMD) {
    if (YMD == '' || YMD == undefined || YMD == null) {
        YMD = getCalendarDate();
    }
    if (typeof (YMD) != typeof ('string')) {
        YMD = getCalendarDate();
    }
    var maria = new ItsMaria('PRD9001_R02', 'LIST_WORKTIME');
    maria.AddParam('WORKDATE', YMD);
    maria.CallProc();
    if (maria.isError) {
        maria.ShowErrMsg();
        return;
    }

    $events = [];
    for (var i = 0; i < maria.store.Length() ; i++) {
        $events.push({
            title: maria.store.GetValue(i, 'CONTENT'),
            start: maria.store.GetValue(i, 'YMD'),
            end: maria.store.GetValue(i, 'YMD'),
            backgroundColor: maria.store.GetValue(i, 'BACKGROUND'),
            borderColor: maria.store.GetValue(i, 'BORDER')
        });
    }
    calendar.removeAllEvents();
    calendar.addEventSource($events);
    
    $(".fc-prev-button").unbind('click');
    $(".fc-prev-button").click(function () {
        var $YMD = getCalendarDate();
        setEvent($YMD);
    });
    $(".fc-next-button").unbind('click');
    $(".fc-next-button").click(function () {
        var $YMD = getCalendarDate();
        setEvent($YMD);
    });
};

function getCalendarDate(ItsDate) {

    if (ItsDate == undefined || ItsDate == null || ItsDate == '') {
        var $ItsDate = calendar.getDate();
    }
    else {
        var $ItsDate = ItsDate
    }
    var $Y = $ItsDate.getFullYear();
    var $M = ($ItsDate.getMonth() + 1);
    var $D = $ItsDate.getDate();
    if ($M.toString().length == 1) {
        $M = '0' + $M.toString();
    }
    if ($D.toString().length == 1) {
        $D = '0' + $D.toString();
    }
    var $YMD = $Y.toString() + "-" + $M.toString() + "-" + $D.toString();
    return $YMD;
};

/* ------------------------------------------------------------------------------------------------------------------------------------------------------ */
/* 초기화 */
ItsButton.EventInit = function () {
    calendar.removeAllEvents();
}

/* 작업시간 일괄등록 */
ItsButton.EventAdd = function () {
    ItsPage.InitData('pdiv1');
    ItsPop.Open('pop1');
};


ItsPop.Event('pop1').onAddBtnClick = function () {
    var maria = new ItsMaria('PRD9001_R02', 'SET_WORKTIME');
    maria.AddPanel('pdiv1');
    maria.CallProc();
    if (maria.isError) {
        maria.ShowErrMsg();
        return;
    }
    ItsPop.Close('pop1');
    ItsMsg.Toast('일괄등록 처리되었습니다');

    ItsButton.EventSearch();
}


ItsPop.Event('pop1').onCancelBtnClick = function () {
    ItsPop.Close('pop1');
}

/* 수정 팝업 */
ItsPop.Event('pop2').onAddBtnClick = function () {
    var maria = new ItsMaria('PRD9001_R02', 'UP_WORKTIME');
    maria.AddPanel('pdiv2');
    maria.CallProc();
    if (maria.isError) {
        maria.ShowErrMsg();
        return;
    }
    setEvent();
    ItsPop.Close('pop2');
    ItsMsg.Toast(ItsMsg.CommonMsg.SaveComplete());
}

ItsPop.Event('pop2').onCancelBtnClick = function () {
    ItsPop.Close('pop2');
}
