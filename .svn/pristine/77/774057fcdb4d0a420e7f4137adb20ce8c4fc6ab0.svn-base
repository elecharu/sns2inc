/// <reference path="../../Script/reference.js" />

/* 페이지 접근 시 수행 */
ItsPage.Load = function () {
    ItsGrid.Create('grid1', { isCheckBoxGrid: false, isSubTotalGrid: true }, [
        column.create('비가동키', 'PRDNONKEY', { width: 150, align: 'center', hidden: true }),
        column.create('생산키', 'PRDWORKKEY', { width: 150, align: 'center', hidden: true }),
        column.create('비가동명', 'NONNM', { width: 200, align: 'center' }),
        column.create('시작시간', 'NONSTIME', { width: 200, align: 'center' }),
        column.create('종료시간', 'NONETIME', { width: 200, align: 'center' }),
        column.create('점검사항', 'PROBLEM', { width: 450, align: 'center' }),
        column.create('조치사항', 'SOLUTION', { width: 450, align: 'center' }),
        
    ]);
    
    // 페이지가 열릴때 자동적으로 설비 목록 띄우기
    LIST_EQMCD_BUTTON();
    
    ItsButton.Disable('btn_SEARCH');
    ItsButton.Disable('btn_REG');
    ItsButton.Disable('btn_ADD');
    ItsButton.Disable('btn_EDIT');
    ItsButton.Disable('btn_DELETE');
    ItsButton.Disable('btn_REMARK');
   

};
// ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
 //상단에 설비목록 
LIST_EQMCD_BUTTON = function () {

    var maria = new ItsMaria('TAL0001_R06', 'LIST_EQMCD');


    maria.CallProc();

    if (maria.isError) {
        maria.ShowErrMsg();
        return;
    }

    $('#EQM_LIST').empty();

    for (var i = 0; i < maria.store.Length(); i++) {

        var EQMCD = maria.store.data[i].EQMCD;
        var EQMNM = maria.store.data[i].EQMNM;

        var html = '';

        html += '<button ';
        html += 'class="eqm-btn" ';
        html += 'data-EQMCD="' + EQMCD + '">';

        html += EQMCD;
        html += '<br>';
        html += EQMNM;

        html += '</button>';

        $('#EQM_LIST').append(html);
    }
};

// 상단에 설비 목록중 하나를 선택할때
$(document).on('click', '.eqm-btn', function () {

    $('.eqm-btn').removeClass('active');
    $(this).addClass('active');

    var EQMCD = $(this).data('eqmcd');

    ItsButton.Enable('btn_SEARCH');
    ItsButton.Enable('btn_REG');
    ItsButton.Enable('btn_ADD');
    ItsButton.Enable('btn_EDIT');
    ItsButton.Enable('btn_DELETE');
    ItsButton.Enable('btn_REMARK');
    ItsGrid.Clear('grid1');
    LIST_PRDRSTNON_FUNCTION();
    //SEARCH_LIST();
});
// ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//팝업창  비가동코드
LIST_NONTP_BUTTON = function () {

    var maria = new ItsMaria('TAL0001_R06', 'LIST_NONTP');

    maria.CallProc();

    if (maria.isError) {
        maria.ShowErrMsg();
        return;
    }

    $('#NONTP_LIST').empty();
    $('#NONTP2_LIST').empty();
    $('#NONTP3_LIST').empty();
    for (var i = 0; i < maria.store.Length(); i++) {

        var NONTP = maria.store.data[i].NONTP;
        var TPNM = maria.store.data[i].TPNM;

        var html = '';

        html += '<button ';
        html += 'class="nontp-btn" ';
        html += 'data-NONTP="' + NONTP + '">';

        html += TPNM;

        html += '</button>';

        $('#NONTP_LIST').append(html); 
        $('#NONTP2_LIST').append(html); 
        $('#NONTP3_LIST').append(html);
    }
};


//팝업창  비가동명
LIST_MSTNON_BUTTON = function (NONTP) {
    
    var maria = new ItsMaria('TAL0001_R06', 'LIST_MSTNON');
    maria.AddParam('NONTP', NONTP);
    maria.CallProc();

    if (maria.isError) {
        maria.ShowErrMsg();
        return;
    }

    $('#MSTNON_LIST').empty();
    $('#MSTNON2_LIST').empty();
    $('#MSTNON3_LIST').empty();
    for (var i = 0; i < maria.store.Length(); i++) {

        var NONCD = maria.store.data[i].NONCD;
        var NONNM = maria.store.data[i].NONNM;

        var html = '';

        html += '<button ';
        html += 'class="mstnon-btn" ';
        html += 'data-NONCD="' + NONCD + '">';

        html += NONNM;

        html += '</button>';

        $('#MSTNON_LIST').append(html);
        $('#MSTNON2_LIST').append(html);
        $('#MSTNON3_LIST').append(html);
    }

 
};



// 팝업에 비가동유형 목록중 하나를 선택할때
$(document).on('click', '.nontp-btn', function () {

    $('.nontp-btn').removeClass('active');
    $(this).addClass('active');

    var NONTP = $(this).data('nontp');

    LIST_MSTNON_BUTTON(NONTP);
});

// 팝업에 비가동유형 목록중 하나를 선택할때
$(document).on('click', '.mstnon-btn', function () {

    $('.mstnon-btn').removeClass('active');
    $(this).addClass('active');
});
// ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
// 비가동 조회
ItsButton.Event('btn_SEARH').onClick = function () {
    LIST_PRDRSTNON_FUNCTION();
}

LIST_PRDRSTNON_FUNCTION = function () {
    ItsGrid.Clear('grid1');
    var EQMCD = $('.eqm-btn.active').data('eqmcd');
    var maria = new ItsMaria('TAL0001_R06', 'LIST_PRDRSTNON');
    maria.AddParam('EQMCD', EQMCD);

    maria.CallProc();
    if (maria.isError) {
        maria.ShowErrMsg();
        return;
    }
    ItsGrid.SetStore('grid1', maria.store);
    ItsMsg.Toast(ItsMsg.CommonMsg.SearchComplete(maria.store.Length()));
    //ItsGrid.Get('grid1').autoSizeColumns();
}


// 자동을 시간이 들어가고 시간이 업데이트되는 함수
START_TIMER_FUNCTION = function () {

    clearInterval(window.START_TIMER);

    function setCurrentTime() {

        var now = new Date();

        var hh = String(now.getHours()).padStart(2, '0');
        var mm = String(now.getMinutes()).padStart(2, '0');
        var ss = String(now.getSeconds()).padStart(2, '0');

        var currentTime = hh + ':' + mm + ':' + ss;

        ItsText.SetValue("pop1_txt_STARTTIME", currentTime);
    }

    setCurrentTime();

    window.START_TIMER = setInterval(setCurrentTime, 1000);
}

END_TIMER_FUNCTION = function () {

    clearInterval(window.START_TIMER);

    function setCurrentTime() {

        var now = new Date();

        var hh = String(now.getHours()).padStart(2, '0');
        var mm = String(now.getMinutes()).padStart(2, '0');
        var ss = String(now.getSeconds()).padStart(2, '0');

        var currentTime = hh + ':' + mm + ':' + ss;

        ItsText.SetValue("pop1_txt_ENDTIME", currentTime);
    }

    setCurrentTime();

    window.START_TIMER = setInterval(setCurrentTime, 1000);
}

//시작/종료
ItsButton.Event('btn_REG').onClick = function () {
  
    $('#MSTNON_LIST').empty();
    LIST_NONTP_BUTTON();


    var EQMCD = $('.eqm-btn.active').data('eqmcd');
    var maria = new ItsMaria('TAL0001_R06', 'CHK_TIMER');

    maria.AddParam('EQMCD', EQMCD);
    maria.CallProc();
    if (maria.isError) {
        maria.ShowErrMsg();
        return;
        ItsPop.Close('pop_STARTEND');
    }


    var CHK = maria.store.data[0]['CHK'];
    var NONTP = maria.store.data[0]['NONTP'];
    var NONCD = maria.store.data[0]['NONCD'];

    if (CHK == 'N') {
        ItsButton.Hide("pop1_btn_END");
        // 기존 타이머 제거

        START_TIMER_FUNCTION();

        ItsText.Disable('pop1_txt_ENDTIME')
        ItsDate.Disable('pop1_date_ENDDATE')

        ItsButton.Show("pop1_btn_START");
        ItsText.Enable('pop1_txt_STARTTIME')
        ItsDate.Enable('pop1_date_STARTDATE')
        ItsText.SetValue('pop1_txt_ENDTIME', '');

    } else{

        $('.nontp-btn[data-NONTP="' + NONTP + '"]').trigger('click');
        $('.mstnon-btn[data-NONCD="' + NONCD + '"]').trigger('click');
        ItsButton.Hide("pop1_btn_START");
        // 기존 타이머 제거
      
        ItsText.Disable('pop1_txt_STARTTIME');
        ItsDate.Disable('pop1_date_STARTDATE');

        ItsButton.Show("pop1_btn_END");
        ItsText.Enable('pop1_txt_ENDTIME');
        ItsDate.Enable('pop1_date_ENDDATE');
 
        ItsText.SetValue('pop1_txt_STARTTIME', maria.store.data[0]['TIME'])
        ItsDate.SetValue('pop1_date_STARTDATE', maria.store.data[0]['DATE'])
        END_TIMER_FUNCTION();

    }
 
    ItsPop.Open('pop_STARTEND');
}
////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
// 시작/종료 팝업 시작
ItsButton.Event('pop1_btn_START').onClick = function () {
    var EQMCD = $('.eqm-btn.active').data('eqmcd');
    var NONCD = $('.mstnon-btn.active').data('noncd');
    var NONSTIME = ItsDate.GetValue('pop1_date_STARTDATE') + ' ' + ItsText.GetValue('pop1_txt_STARTTIME');

    var maria = new ItsMaria('TAL0001_R06', 'START_NON');

    maria.AddParam('EQMCD', EQMCD);
    maria.AddParam('NONCD', NONCD);
    maria.AddParam('NONSTIME', NONSTIME);
    maria.CallProc();
    if (maria.isError) {
        maria.ShowErrMsg();
        return;
    }


    ItsButton.Hide("pop1_btn_START");
    // 기존 타이머 제거
    ItsButton.Show("pop1_btn_END");
    ItsText.Enable('pop1_txt_ENDTIME')
    ItsDate.Enable('pop1_date_ENDDATE')
    END_TIMER_FUNCTION();

    ItsText.Disable('pop1_txt_STARTTIME')
    ItsDate.Disable('pop1_date_STARTDATE')
    
    LIST_PRDRSTNON_FUNCTION();
}


// 종료 버튼
ItsButton.Event('pop1_btn_END').onClick = function () {
    var EQMCD = $('.eqm-btn.active').data('eqmcd');
    var NONCD = $('.mstnon-btn.active').data('noncd');
    var NONETIME = ItsDate.GetValue('pop1_date_ENDDATE') + ' ' + ItsText.GetValue('pop1_txt_ENDTIME');

    var maria = new ItsMaria('TAL0001_R06', 'END_NON');

    maria.AddParam('EQMCD', EQMCD);
    maria.AddParam('NONCD', NONCD);
    maria.AddParam('NONETIME', NONETIME);
    maria.CallProc();
    if (maria.isError) {
        maria.ShowErrMsg();
        return;
    }

    ItsPop.Close('pop_STARTEND')
    LIST_PRDRSTNON_FUNCTION();
}

// 추가 버튼 클릭
ItsButton.Event('btn_ADD').onClick = function () {

    var EQMCD = $('.eqm-btn.active').data('eqmcd');

    var maria = new ItsMaria('TAL0001_R06', 'CHK_ADD_PRDRSTNON');
    maria.AddParam('EQMCD', EQMCD);
    maria.CallProc();
    if (maria.isError) {
        maria.ShowErrMsg();
        return;

    }
    var CHK = maria.store.data[0]['CHK'];

    if (CHK == 'N') {
        ItsMsg.Alert('진행중인 비가동을 종료하세요.')
        return
    } else {


        var now = new Date();

        var hh = String(now.getHours()).padStart(2, '0');
        var mm = String(now.getMinutes()).padStart(2, '0');
        var ss = String(now.getSeconds()).padStart(2, '0');

        var currentTime = hh + ':' + mm + ':' + ss;

        LIST_NONTP_BUTTON();
        ItsText.SetValue('pop2_txt_STARTTIME', currentTime)
        ItsText.SetValue('pop2_txt_ENDTIME', currentTime)
        ItsPop.Open('pop_ADD');
    }
}


ItsButton.Event('pop2_btn_ADD').onClick = function () {
    var EQMCD = $('.eqm-btn.active').data('eqmcd');

    var NONCD = $('.mstnon-btn.active').data('noncd');
    var NONSTIME = ItsDate.GetValue('pop2_date_STARTDATE') + ' ' + ItsText.GetValue('pop2_txt_STARTTIME');
    var NONETIME = ItsDate.GetValue('pop2_date_ENDDATE') + ' ' + ItsText.GetValue('pop2_txt_ENDTIME');

    var maria = new ItsMaria('TAL0001_R06', 'ADD_PRDRSTNON');
    maria.AddParam('EQMCD', EQMCD);
    maria.AddParam('NONCD', NONCD);
    maria.AddParam('NONSTIME', NONSTIME);
    maria.AddParam('NONETIME', NONETIME);


    maria.CallProc();
    if (maria.isError) {
        maria.ShowErrMsg();
        return;

    }


    ItsPop.Close('pop_ADD');
    LIST_PRDRSTNON_FUNCTION();
}

// 수정 버튼 클릭
ItsButton.Event('btn_EDIT').onClick = function () {
    var PRDNONKEY = ItsGrid.GetValue('grid1', ItsGrid.GetCurrentIndex('grid1'), 'PRDNONKEY');
    if (PRDNONKEY == '' || PRDNONKEY == undefined || PRDNONKEY == null) {
        return
    }

    LIST_NONTP_BUTTON();

    var EQMCD = $('.eqm-btn.active').data('eqmcd');


    var maria = new ItsMaria('TAL0001_R06', 'EDIT_LIST_PRDRSTNON');
    maria.AddParam('EQMCD', EQMCD);
    maria.AddParam('PRDNONKEY', PRDNONKEY);

    maria.CallProc();
    if (maria.isError) {
        maria.ShowErrMsg();
        return;

    }
    var NONTP = maria.store.data[0]['NONTP'];
    var NONCD = maria.store.data[0]['NONCD'];
    $('.nontp-btn[data-NONTP="' + NONTP + '"]').trigger('click');
    $('.mstnon-btn[data-NONCD="' + NONCD + '"]').trigger('click');
    ItsText.SetValue('pop3_txt_STARTTIME', maria.store.data[0]['STIME'])
    ItsDate.SetValue('pop3_date_STARTDATE', maria.store.data[0]['SDATE'])
    ItsText.SetValue('pop3_txt_ENDTIME', maria.store.data[0]['ETIME'])
    ItsDate.SetValue('pop3_date_ENDDATE', maria.store.data[0]['EDATE'])
    ItsPop.Open('pop_EDIT');
}

// 팝업 수정 버튼
ItsButton.Event('pop3_btn_EDIT').onClick = function () {

    var EQMCD = $('.eqm-btn.active').data('eqmcd');
    var PRDNONKEY = ItsGrid.GetValue('grid1', ItsGrid.GetCurrentIndex('grid1'), 'PRDNONKEY');
    var NONCD = $('.mstnon-btn.active').data('noncd');
    var NONSTIME = ItsDate.GetValue('pop3_date_STARTDATE') + ' ' + ItsText.GetValue('pop3_txt_STARTTIME');
    var NONETIME = ItsDate.GetValue('pop3_date_ENDDATE') + ' ' + ItsText.GetValue('pop3_txt_ENDTIME');

    var maria = new ItsMaria('TAL0001_R06', 'EDIT_PRDRSTNON');
    maria.AddParam('EQMCD', EQMCD);
    maria.AddParam('PRDNONKEY', PRDNONKEY);
    maria.AddParam('NONCD', NONCD);
    maria.AddParam('NONSTIME', NONSTIME);
    maria.AddParam('NONETIME', NONETIME);
  

    maria.CallProc();
    if (maria.isError) {
        maria.ShowErrMsg();
        return;

    }


    ItsPop.Close('pop_EDIT');
    LIST_PRDRSTNON_FUNCTION();
}



//삭제 버튼
ItsButton.Event('btn_DELETE').onClick = function () {
    var PRDNONKEY = ItsGrid.GetValue('grid1', ItsGrid.GetCurrentIndex('grid1'), 'PRDNONKEY');
    if (PRDNONKEY == '' || PRDNONKEY == undefined || PRDNONKEY == null) {
        return
    }
    var EQMCD = $('.eqm-btn.active').data('eqmcd');
   

    var maria = new ItsMaria('TAL0001_R06', 'DEL_PRDRSTNON');

    maria.AddParam('EQMCD', EQMCD);
    maria.AddParam('PRDNONKEY', PRDNONKEY);
    maria.CallProc();

    if (maria.isError) {
        maria.ShowErrMsg();
        return;

    }
    LIST_PRDRSTNON_FUNCTION();
}


// 점검사항/조치사항
ItsButton.Event('btn_REMARK').onClick = function () {
    var EQMCD = $('.eqm-btn.active').data('eqmcd');
    var PRDNONKEY = ItsGrid.GetValue('grid1', ItsGrid.GetCurrentIndex('grid1'), 'PRDNONKEY');
    if (PRDNONKEY == '' || PRDNONKEY == undefined || PRDNONKEY == null) {
        return;
    }

    var maria = new ItsMaria('TAL0001_R06', 'LIST_ERR');
    maria.AddParam('PRDNONKEY', PRDNONKEY);
    maria.AddParam('EQMCD', EQMCD);

    maria.CallProc();
    if (maria.isError) {
        maria.ShowErrMsg();
        return;
    }


    ItsTextArea.SetValue('txtArea_PROBLEM', maria.store.data[0]["PROBLEM"]);
    ItsTextArea.SetValue('txtArea_SOLUTION', maria.store.data[0]["SOLUTION"]);
    ItsPop.Open('pop_PROB_SOL');
}

ItsPop.Event('pop_PROB_SOL').onAddBtnClick = function () {
    var EQMCD = $('.eqm-btn.active').data('eqmcd');
    var PRDNONKEY = ItsGrid.GetValue('grid1', ItsGrid.GetCurrentIndex('grid1'), 'PRDNONKEY');
    if (PRDNONKEY == '' || PRDNONKEY == undefined || PRDNONKEY == null) {
        return;
    }

    var maria = new ItsMaria('TAL0001_R06', 'ADD_ERR');
    maria.AddParam('PRDNONKEY', PRDNONKEY);
    maria.AddParam('EQMCD', EQMCD);

    maria.AddParam('PROBLEM', ItsTextArea.GetValue('txtArea_PROBLEM'));
    maria.AddParam('SOLUTION', ItsTextArea.GetValue('txtArea_SOLUTION'));


    maria.CallProc();
    if (maria.isError) {
        maria.ShowErrMsg();
        return;
    }
    ItsPop.Close('pop_PROB_SOL');
    LIST_PRDRSTNON_FUNCTION();
}

ItsPop.Event('pop_PROB_SOL').onCancelBtnClick = function () {
    ItsTextArea.SetValue('txtArea_PROBLEM', '');
    ItsTextArea.SetValue('txtArea_SOLUTION', '');
    ItsPop.Close('pop_PROB_SOL');
}