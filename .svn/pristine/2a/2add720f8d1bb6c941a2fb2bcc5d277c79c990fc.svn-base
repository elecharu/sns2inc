var wijmoKey = 'localhost|mes.optisco.com,177514811214589#B07eYICbuFkI1pjIEJCLi4TPBpHZrImbsdFTYFUestUYrUERONVMr8URUJ4QStURXN6b4wUSBBjQO3yaSFEa8pUY4c4NsNVTKpVTxJTTXRXa0F4NuJWU8YWRZZjN0FTSMV7Y7g7cjh4Uyw4Y9Z7M6JnZVlHMipFelZ7NHtETMVzcnV4VGhETyVWNBBXV7NTcjhmeCFmWql6MSJGcOhVb9dVbH9EV4c6Rox4YUV5d9I7KzQnZv3Ueyhme5EVe9Q5YtF7bqJ6aQVTNOd7dqhDdvBlUWtyMMlGSaZ6aRFzaYJlaxs4bzk4VxRlZ6oVUwgmMzEnSjFHV596czYUctdzZs54aahHM6EHWNNXTJFHaQV7Ynd6U7kTSwYVbwhXNuN4b4RkQxcEdzIFW9oXUPpmTnVXSKBXTYFFW8tUM74mN686ZihHWTZzb6pVSLJlS7xWcWRkQTNEbvMmcXd4KzRVbm3SYMRDboVXYiojITJCLiMkQ6QTQGlTMiojIIJCL9ETM7ADN4AjM0IicfJye35XX3JSSwIjUiojIDJCLi86bpNnblRHeFBCI4VWZoNFelxmRg2Wbql6ViojIOJyes4nI5kkTRJiOiMkIsIibvl6cuVGd8VEIgIXZ7VWaWRncvBXZSBybtpWaXJiOi8kI1xSfis4N8gkI0IyQiwiIu3Waz9WZ4hXRgAydvJVa4xWdNBybtpWaXJiOi8kI1xSfiQjR6QkI0IyQiwiIu3Waz9WZ4hXRgACUBx4TgAybtpWaXJiOi8kI1xSfiMzQwIkI0IyQiwiIlJ7bDBybtpWaXJiOi8kI1xSfiUFO7EkI0IyQiwiIu3Waz9WZ4hXRgACdyFGaDxWYpNmbh9WaGBybtpWaXJiOi8kI1tlOiQmcQJCLiIjM6MDNwAyMxITM4IDMyIiOiQncDJCLi46bj9ybjNXa4B7buMXZtxCdz3GasF6YvxmI0IyctRkIsIyTDNFVJJiOiEmTDJCLikDO5QTMyETM8QTM5czNxIiOiQWSiwSfiMjdwIDMyIiOiIXZ6JCLlNHbhZmOiIKc6J';
var main_right_tabmenu;
var main_left_treemenu;
var main_left_treemenu_search;
var menuClose;
$(document).ready(function () {
    if (location.href.indexOf('www.') > -1) {
        location.href = location.href.replace('www.', '');
    }
    // 탭메뉴 생성
    wijmo.setLicenseKey(wijmoKey);
    $('a[href="https://www.grapecity.com/licensing/wijmo"]').parent().css('display', 'none');

    // 2025-03-10 위즈모 라이센스 오류 임시 숨김
    const observer = new MutationObserver((mutationsList) => {
        mutationsList.forEach(mutation => {
            mutation.addedNodes.forEach(node => {
                $('div[style="position: fixed; background: rgba(0, 0, 0, 0.3); left: 0px; top: 0px; width: 100%; height: 100%; font-family: sans-serif; z-index: 10000;"]').remove();
                $('a[href="https://www.grapecity.com/licensing/wijmo?utm_source=Wijmo-In-App&utm_medium=Click-to-Site&utm_campaign=Wijmo-User-Analysis"]').parent().remove();
                $('a[href="https://www.grapecity.com/licensing/wijmo?utm_source=Wijmo-In-App&utm_medium=Click-to-Site&utm_campaign=Wijmo-User-Analysis"]').parent().remove();
            });
        });
    });

    observer.observe(document.body, { childList: true, subtree: true });

    main_right_tabmenu = new wijmo.nav.TabPanel('#main_right_tabmenu', {
        selectedIndexChanged: function (s, e) {
            try {
                var data = s.selectedTab.header.dataset;
                var star = false;
                if (data.prgnm != '') {//메뉴 버튼
                    if ($(s.selectedTab.header).find('.fa-star').length > 0) {
                        star = true;
                    }
                    top_menu_click(data.menupath, s.selectedTab.header, true);
                } else { //스크롤 버튼
                    if (data.prgcd == 'scrollLeft') {

                    } else if (data.prgcd == 'scrollRight') {

                    }
                }
            } catch(e) {

            }

        }
    });

    // 환경설정 마우스 나가면 닫기
    var mouseoutRight;
    $('#infoLayer').on('mouseout', function () {
        mouseoutRight = setTimeout(function () {
            try {
                $('#infoLayer').hide();
            } catch (e) { }
        }, 1000)
    });
    $('#infoLayer').on('mouseover', function () {
        clearTimeout(mouseoutRight);
    });

	re_size();
    loading();

    $('.windowScreen').hide();

    // 화면모드 전환시 버튼활성화
    document.addEventListener('fullscreenchange', () => {
        if (!document.fullscreenElement) {
            $('.fullScreen').show();
            $('.windowScreen').hide();
        }
        else {
            $('.fullScreen').hide();
            $('.windowScreen').show();
        }
    });
});
//End-onload

$(window).resize(function(){
    re_size();
});
function re_size() {
    $(".m_content > iframe").height(window.innerHeight);

    setTimeout(function () {
        try {
            for (var i = 0; i < $('#m_content').children('iframe').length ; i++) {
                if ($('#m_content').children('iframe').eq(0).css('display') != 'none') {
                    $('#m_content').children('iframe')[i].contentWindow.$(window).resize();
                }
            }
        } catch (e) { }
    });
    tabCheck();
};
function tabCheck() {
    var tabWidth = $('#main_right_tabmenu').width() - 16;
    var menuWidth = 0;
    for (var i = 1; i < $('#main_right_tabmenu .wj-tabheader').length; i++) {
        menuWidth += $('#main_right_tabmenu .wj-tabheader').eq(i).width() + 20;
    }
    if (tabWidth < menuWidth) {
        $('#openedTabLeft').show();
        $('#openedTabRight').show();
        $('#openedTabHome').css('position', 'fixed');
        $('#openedTabHome').css('padding', '3px 5px');
        $('#openedTabHome').css('margin-right', '10px');
        $('#openedTabHome').css('z-index', '3');
        $('#openedTabHome').css('top', '70px');
        $('#openedTabHome i').css('padding-top', '2px');
        $('.wj-tabpanel>div>.wj-tabheaders>.wj-tabheader:nth-child(2)').css('margin-left', '35px');
    } else {
        $('#openedTabLeft').hide();
        $('#openedTabRight').hide();
        //$('#openedTabHome').removeAttr('style');
        $('.wj-tabpanel>div>.wj-tabheaders>.wj-tabheader:nth-child(2)').css('margin-left', '');
    }
    $('#main_right_tabmenu').scrollLeft(0);
}
function wait_start() {	
	$('.preloader').css('opacity', '');
	$('.preloader').show();
}
function wait_end() {
	$('.preloader').hide();
}
function loading(){
	$(window).load(function(){
		$('.preloader').fadeOut(1000);

		$(".preloader_btn").on("click",function(){
		$('.preloader').fadeIn(1000);
		});
	});
}
// receiveParams 페이지 점프에서 주고 받는 변수
var receiveParams = {

};
function top_menu_click(menuPath, obj, star) {
    var $stt = false;
    // 검색 후 있으면 이동
    for (var i = 0; i < $(".m_content > iframe").length; i++) {
        if ($(".m_content > iframe")[i].src.toString().indexOf(menuPath.replace('../../', '')) > -1) {
            $stt = true;
            $(".m_content > iframe").css('height', '0px');
            $(".m_content > iframe").css('display', 'none');
            $(".m_content > iframe").eq(i).css('height', '936px');
            $(".m_content > iframe").eq(i).css('display', 'block');
            if (receiveParams[menuPath.split('/')[menuPath.split('/').length - 1].replace('.aspx', '')] != undefined) {
                if ($(".m_content > iframe").get(i).contentWindow.ItsPage != undefined) {
                    $(".m_content > iframe").get(i).contentWindow.ItsPage.$onReceiveParam();
                }
            }
            break;
        }
    }

    if ($stt) {
        re_size();
    } else if (star) {
        var prgcd = $(obj).attr('data-prgcd');
        var menuPath = $(obj).attr('data-menupath');
        var menuName = $(obj).text();

        wait_start();
        setTimeout(function () {
            var $iframe = $("<iframe src='" + menuPath + "' frameborder=0 framespacing=0; style='width:100%'>");
            $(".m_content > iframe").css('height', '0px');
            $(".m_content > iframe").css('display', 'none');
            $(".m_content").append($iframe);

            top_menu_click(menuPath, obj, star);
        }, 100);
    }

    try { $(".m_content > iframe").get(i).contentWindow.ItsPage.onMenuClick(); } catch (e) { }
};

function logout() {
    ItsMsg.Confirm('로그아웃 하시겠습니까?', function () {
        var maria = new ItsMaria('WEBSYSLOGIN', 'LOGOUT');
		maria.AddParam("---", "---");
		maria.AddSessionLoginKey();
		maria.CallProcCenter();
		if(maria.isError) {
			maria.ShowErrMsg();
			return;
		}
		location.href = "../../PAGECOM/PORTAL/index.aspx";
	});
};

function showInfo() {
    // 버전정보 보기
    var maria = new ItsMaria('WEBSYSLOGIN', 'SHOW_INFO');
    maria.CallProcCenter();
    if (maria.isError) {
        console.log(maria.errMessage)
    }
    $('#lastVersion').text(maria.store.GetValue(0, 'REF01'));
    $("#infoLayer").show();

};
function cancel_info() {
    $("#infoLayer").hide();
}
function passChange() {
    if (fn_pw_check($('#newpass').val(), $('#newpass2').val())) {
        var maria = new ItsMaria('WEBSYSLOGIN', 'MODIFY_PASSWORD');
        maria.AddParam('USERPASS', $('#curpass').val());
        maria.AddParam('NEWPASS', $('#newpass').val());
        maria.AddParam('NEWPASS2', $('#newpass2').val());
        maria.AddSessionUserId();
        maria.CallProcCenter();
        if (maria.isError) {
            $('.passwordform > .passerr').text(maria.errMessage);
            maria.ShowErrMsg();
            return;
        } else {
            $('.passwordform > .passerr').text('비밀번호가 변경되었습니다.');
        }
    }
}
var login_pop = function() {
    $("#modalLayer").show();
	$(".mask").show();
	$(".modalContent").css({"margin-top" : -$(".modalContent").outerHeight()/2, "margin-left" : -$(".modalContent").outerWidth()/2});
	// $(this).blur();
	$(".modalContent > a").focus();
	$(".mask").on("click",function(){
	    cancel_login();
	});
	return false;
};
var login_pop_btn = function() {
	var login_id = document.getElementById("login_id_pop").value;
	var login_pw = document.getElementById("login_pw_pop").value;
	var maria = new ItsMaria('WEBSYSLOGIN', 'MAIN_LOGIN');
	maria.AddParam('USERID', login_id);
	maria.AddParam('USERPASS', login_pw);
	maria.AddParam("---", "---");
	maria.CallProcCenter();
	if(maria.isError) {
		document.getElementById("login_errMsg_pop").innerText = maria.errMessage;
		return;
	}
	$("#modalLayer").hide();
	$(".mask").hide();
};
var cancel_login = function() {
    ItsMsg.Confirm('작업중인 내용이 저장되지 않습니다. 종료하시겠습니까?', function() {
        var maria = new ItsMaria('WEBSYSLOGIN', 'LOGOUT');
		maria.AddParam("---", "---");
		maria.AddSessionLoginKey();
		maria.CallProcCenter();
		if(maria.isError) {
			maria.ShowErrMsg();
			return;
		}
		location.href = "../../PAGECOM/PORTAL/index.aspx";
	});
};
function search_menu_btn_click(key) {
    if ($('#left_search_menu').attr('data-status') == 'search' || key == 'enter') {
        search_menulist($('#left_search_menu').val());
    } else {
        search_close();
    }
}
function search_menulist(keyword) {
    if (keyword == '') {
        return;
    }
    var maria = new ItsMaria('WEBSYSMAIN', 'SEARCH_MENU');
    maria.AddParam("MENUNM", keyword);
    maria.AddSessionUserId();
    maria.CallProcCenter();
    if (maria.isError) {
        maria.ShowErrMsg();
        return;
    }
    for (var i = 0; i < maria.storeExtend1.data.length; i++) {
        maria.store.data.push(maria.storeExtend1.data[i]);
    }
    main_left_menu_list_search.itemsSource = SetRelation(maria.store.data, 'MENUCD', 'PMENUCD');
    $('#left_search_img').css('background-image', 'url(../../images/menu/ic_menu_close.png)');
    $('#left_search_menu').attr('data-status', 'close');
    $('#main_left_menu_list').hide();
    $('#main_left_menu_list_search').show();
};
function search_close() {
    $('#left_search_img').css('background-image', 'url(../../images/menu/ic_menu_search.png)');
    $('#left_search_menu').attr('data-status', 'search');
    $('#left_search_menu').val('');
    $('#main_left_menu_list').show();
    $('#main_left_menu_list_search').hide();
}
function add_iframe(prgcd, menuPath, menuName) {
    var maria = new ItsMaria('COMSESSION', 'CHECK');
    maria.CallProc();
    if (maria.isError) {
        maria.ShowErrMsg();
        return;
    }
    //탭에 있으면 그쪽으로 이동
    for(var i = 0; i < main_right_tabmenu.tabs.length; i++) {
        if (prgcd == main_right_tabmenu.tabs[i].header.attributes['data-prgcd'].value) {
            main_right_tabmenu.selectedIndex = i;
            return;
        }
    }
    wait_start();
    setTimeout(function () {
        var $iframe = $("<iframe src='" + menuPath + "' frameborder=0 framespacing=0; style='width:100%'>");
        $(".m_content > iframe").css('height', '0px');
        $(".m_content > iframe").css('display', 'none');
        $(".m_content").append($iframe);
        //탭헤더 추가
        var elHeader = document.createElement('a');
        elHeader.href = '#';
        elHeader.innerText = menuName;
        elHeader.dataset.prgcd = prgcd;
        elHeader.dataset.prgnm = menuName;
        elHeader.dataset.menupath = menuPath;
        elHeader.dataset.menupath = menuPath;
        var closeIcon = document.createElement('i');
        closeIcon.className = 'fa fa-times fa-white';
        closeIcon.setAttribute('aria-hidden', 'true');
        closeIcon.setAttribute('onclick', 'remove_iframe(\'' + prgcd + '\', true)');
        elHeader.appendChild(closeIcon);
        var elPane = document.createElement('div');
        main_right_tabmenu.tabs.push(new wijmo.nav.Tab(elHeader, elPane));
        main_right_tabmenu.selectedIndex = main_right_tabmenu.tabs.length - 1;
        tabCheck();
        contextmenu();
        $('iframe').load(function (e) {
            try {
                var iframe = $('iframe')[$('iframe').length - 1];
                var ifTitle = iframe.contentDocument.title;
                if (ifTitle.indexOf("리소스를 찾을 수 없습니다.") >= 0 || ifTitle.indexOf("404") >= 0 || ifTitle.indexOf("파일이 없습니다") >= 0) {
                    remove_iframe(prgcd, true);
                    wait_end();
                }
            } catch (e) {
                console.log(e);
            } finally {
                wait_end();
            }
        });
    }, 100);
};
function addMymenu(prgcd, menupath, sender) {
	var maria = new ItsMaria('SYS0000_R02', 'ADD_SYSMENUUSER');
	maria.AddParam("PRGCD", prgcd);
	maria.AddSessionLoginKey();
	maria.AddSessionUserId();
	maria.CallProcCenter();
	if(maria.isError) {
		maria.ShowErrMsg();
		return;
	}
	toastr.options = {
	    closeButton: true,
	    progressBar: false,
	    showMethod: 'slideUp',
	    positionClass: 'toast-bottom-right',
	    timeOut: 1000
	};
	toastr.success('추가되었습니다.새로고침시 반영됩니다.');
};

$.fn.selectRange = function(start, end) {
    return this.each(function() {
        if(this.setSelectionRange) {
            this.focus();
            this.setSelectionRange(start, end);
        } else if(this.createTextRange) {
            var range = this.createTextRange();
            range.collapse(true);
            range.moveEnd('character', end);
            range.moveStart('character', start);
            range.select();
        }
    });
};

// 메뉴 우클릭 이벤트
function contextmenu() {
    $('#main_right_tabmenu .wj-tabheader').bind('contextmenu', function (e) {
        if ($(this)[0].dataset.prgcd != 'SYS0000_R01') {
            wijmo.showPopup(menuClose.hostElement, $(this), false, true, false);
            menuClose.focus();
            menuClose.dataset = $(this)[0].dataset;
            menuClose.hostElement.style.left = ($(this).offset().left + 30) + 'px';
            menuClose.hostElement.style.top = ($(this).offset().top + 17) + 'px';
            menuClose.selectedIndex = -1;
        }
        return false;
    });
}
// 창닫기 관련
function remove_iframe(prgcd, single) {

    var curIndex = main_right_tabmenu.selectedIndex;

    for (var i = 0; i < main_right_tabmenu.tabs.length; i++) {
        if (prgcd == main_right_tabmenu.tabs[i].header.attributes['data-prgcd'].value) {
            if (main_right_tabmenu.tabs.length - 1 == i) {
                curIndex = i - 1;
            } else {
                curIndex = i;
            }
            main_right_tabmenu.tabs.remove(main_right_tabmenu.tabs[i]);
            
        }
    }
    for (var i = 1; i < $(".m_content > iframe").length; i++) {
        if ($(".m_content > iframe")[i].src.toString().split('/').slice(-1)[0] == prgcd + '.aspx') {
            $(".m_content > iframe").eq(i).remove();
            break;
        }
    }
    tabCheck();
    if (single) {
        main_right_tabmenu.selectedIndex = curIndex;
    }
}
function SetRelation(data, key, parentCode) {
    var oldData = [];
    data.forEach(function (node) {
        if (node[key] == node[parentCode]) {
            node[parentCode] = null;
        }
        oldData.push(node);
    });
    var dataMap = oldData.reduce(function (map, node) {
        map[node[key]] = node;
        return map;
    }, {});
    var tree = [];
    oldData.forEach(function (node) {
        var parent = dataMap[node[parentCode]];
        if (parent) {
            (parent.items || (parent.items = []))
                .push(node);
        } else {
            tree.push(node);
        }
    });
    return tree;
}


/* 전제화면 */
function fullScreen() {
    let doc = document.documentElement;

    if (doc.requestFullscreen)
        doc.requestFullscreen();
    else if (doc.webkitRequestFullscreen) // Chrome, Safari (webkit)
        doc.webkitRequestFullscreen();
    else if (doc.mozRequestFullScreen) // Firefox
        doc.mozRequestFullScreen();
    else if (doc.msRequestFullscreen) // IE or Edge
        doc.msRequestFullscreen();

    $('.windowScreen').show();
    $('.fullScreen').hide();
}

// 창모드
function windowScreen() {
    if (document.exitFullscreen)
        document.exitFullscreen();
    else if (document.webkitExitFullscreen) // Chrome, Safari (webkit)
        document.webkitExitFullscreen();
    else if (document.mozCancelFullScreen) // Firefox
        document.mozCancelFullScreen();
    else if (document.msExitFullscreen) // IE or Edge
        document.msExitFullscreen();

    $('.windowScreen').hide();
    $('.fullScreen').show();
}
