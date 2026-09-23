$(function () {
    //mask
    // var mask = new ax5.ui.mask();
    // mask.open();

    //dialog
    // var myDialog = new ax5.ui.dialog({
    //     title: '<i class="axi axi-ion-alert"></i> Default alert',
    //     onStateChanged: function(){

    //     }
    // });
    // $('#btn').click(function () {
    //     myDialog.alert({
    //         msg: 'Alert message'
    //     }, function () {
    //         console.log(this);
    //     });
    // });

    //modal
    // var mask = new ax5.ui.mask();
    // var modal = new ax5.ui.modal();
    // var modalCallBack = function () {
    //     modal.close();
    // };

    // $('#modal-open').click(function () {
    //     modal.open({
    //         width: 600,
    //         iframe: {
    //             method: "get",
    //             url: "address.html",
    //             param: "callBack=modalCallBack"
    //         },
    //         onStateChanged: function () {
    //             // mask
    //             if (this.state === "open") {
    //                 mask.open();
    //             } else if (this.state === "close") {
    //                 mask.close();
    //             }
    //         }
    //     }, function () {

    //     });
    // });

    //calendar
    // $(document.body).ready(function () {
    //     var myCalendar = new ax5.ui.calendar({
    //         target: document.getElementById("calendar-target"),
    //         displayDate: (new Date()),
    //         onClick: function () {
    //             console.log(this);
    //             console.log(myCalendar.getSelection());
    //         },
    //         onStateChanged: function () {
    //             console.log(this);
    //         }
    //     });
    // });

    //date picker
    // $('[data-ax5picker="basic"]').ax5picker({
    //     direction: "top",
    //     content: {
    //         type: 'date'
    //     }
    // });
    var picker = new ax5.ui.picker();
    picker.bind({
        target: $('[data-ax5picker="basic"]'),
        direction: "top",
        content: {
            width: 270,
            margin: 10,
            type: 'date',
            config: {
                control: {
                    left: '<i class="fa fa-chevron-left"></i>',
                    yearTmpl: '%s',
                    monthTmpl: '%s',
                    right: '<i class="fa fa-chevron-right"></i>'
                },
                lang: {
                    yearTmpl: "%s년",
                    months: ['01', '02', '03', '04', '05', '06', '07', '08', '09', '10', '11', '12'],
                    dayTmpl: "%s"
                }
            }
        },
        onStateChanged: function () {

        }
    });

    picker.bind({
        target: $('[data-ax5picker="basic1"]'),
        direction: "top",
        content: {
            width: 270,
            margin: 10,
            type: 'date',
            config: {
                control: {
                    left: '<i class="fa fa-chevron-left"></i>',
                    yearTmpl: '%s',
                    monthTmpl: '%s',
                    right: '<i class="fa fa-chevron-right"></i>'
                },
                lang: {
                    yearTmpl: "%s년",
                    months: ['01', '02', '03', '04', '05', '06', '07', '08', '09', '10', '11', '12'],
                    dayTmpl: "%s"
                }
            }
        },
        onStateChanged: function () {

        }
    });
    

    //formatter
    // $('[data-ax5formatter]').ax5formatter();

    //layout
    $('[data-ax5layout]').ax5layout();

    var gridList = [
        {a: "대구수성구만촌동", b : "885-4", c : "대", d : "128", e : "2002/11/07", f : "2002/12/03", g : "나대지", h : "등기상태", i : ""},
        {a: "대구수성구만촌동", b : "1354-1", c : "대", d : "128", e : "2002/11/07", f : "2002/12/03", g : "나대지", h : "등기상태", i : ""},
        {a: "대구수성구만촌동", b : "1354-1", c : "대", d : "128", e : "2002/11/07", f : "2002/12/03", g : "나대지", h : "등기상태", i : ""},
        {a: "대구수성구만촌동", b : "1354-1", c : "대", d : "128", e : "2002/11/07", f : "2002/12/03", g : "나대지", h : "등기상태", i : ""},
        {a: "대구수성구만촌동", b : "1354", c : "대", d : "128", e : "2002/11/07", f : "2002/12/03", g : "나대지", h : "등기상태", i : ""},
        {a: "대구수성구만촌동", b : "422-3", c : "주차장", d : "128", e : "2002/11/07", f : "2002/12/03", g : "나대지", h : "등기상태", i : ""},
        {a: "대구수성구만촌동", b : "1343-18", c : "대", d : "128", e : "2002/11/07", f : "2002/12/03", g : "나대지", h : "등기상태", i : ""},
        {a: "대구수성구만촌동", b : "1343-34", c : "대", d : "128", e : "2002/11/07", f : "2002/12/03", g : "나대지", h : "등기상태", i : ""},
        {a: "대구수성구만촌동", b : "422-2", c : "대", d : "128", e : "2002/11/07", f : "2002/12/03", g : "나대지", h : "등기상태", i : ""},
        {a: "대구수성구만촌동", b : "863-42", c : "도로", d : "128", e : "2002/11/07", f : "2002/12/03", g : "나대지", h : "등기상태", i : ""},
        { a: "대구수성구만촌동", b: "885-4", c: "대", d: "128", e: "2002/11/07", f: "2002/12/03", g: "나대지", h: "등기상태", i: "" },
        { a: "대구수성구만촌동", b: "1354-1", c: "대", d: "128", e: "2002/11/07", f: "2002/12/03", g: "나대지", h: "등기상태", i: "" },
        { a: "대구수성구만촌동", b: "1354-1", c: "대", d: "128", e: "2002/11/07", f: "2002/12/03", g: "나대지", h: "등기상태", i: "" },
        { a: "대구수성구만촌동", b: "1354-1", c: "대", d: "128", e: "2002/11/07", f: "2002/12/03", g: "나대지", h: "등기상태", i: "" },
        { a: "대구수성구만촌동", b: "1354", c: "대", d: "128", e: "2002/11/07", f: "2002/12/03", g: "나대지", h: "등기상태", i: "" },
        { a: "대구수성구만촌동", b: "422-3", c: "주차장", d: "128", e: "2002/11/07", f: "2002/12/03", g: "나대지", h: "등기상태", i: "" },
        { a: "대구수성구만촌동", b: "1343-18", c: "대", d: "128", e: "2002/11/07", f: "2002/12/03", g: "나대지", h: "등기상태", i: "" },
        { a: "대구수성구만촌동", b: "1343-34", c: "대", d: "128", e: "2002/11/07", f: "2002/12/03", g: "나대지", h: "등기상태", i: "" },
        { a: "대구수성구만촌동", b: "422-2", c: "대", d: "128", e: "2002/11/07", f: "2002/12/03", g: "나대지", h: "등기상태", i: "" },
        { a: "대구수성구만촌동", b: "863-42", c: "도로", d: "128", e: "2002/11/07", f: "2002/12/03", g: "나대지", h: "등기상태", i: "" },
        { a: "대구수성구만촌동", b: "885-4", c: "대", d: "128", e: "2002/11/07", f: "2002/12/03", g: "나대지", h: "등기상태", i: "" },
        { a: "대구수성구만촌동", b: "1354-1", c: "대", d: "128", e: "2002/11/07", f: "2002/12/03", g: "나대지", h: "등기상태", i: "" },
        { a: "대구수성구만촌동", b: "1354-1", c: "대", d: "128", e: "2002/11/07", f: "2002/12/03", g: "나대지", h: "등기상태", i: "" },
        { a: "대구수성구만촌동", b: "1354-1", c: "대", d: "128", e: "2002/11/07", f: "2002/12/03", g: "나대지", h: "등기상태", i: "" },
        { a: "대구수성구만촌동", b: "1354", c: "대", d: "128", e: "2002/11/07", f: "2002/12/03", g: "나대지", h: "등기상태", i: "" },
        { a: "대구수성구만촌동", b: "422-3", c: "주차장", d: "128", e: "2002/11/07", f: "2002/12/03", g: "나대지", h: "등기상태", i: "" },
        { a: "대구수성구만촌동", b: "1343-18", c: "대", d: "128", e: "2002/11/07", f: "2002/12/03", g: "나대지", h: "등기상태", i: "" },
        { a: "대구수성구만촌동", b: "1343-34", c: "대", d: "128", e: "2002/11/07", f: "2002/12/03", g: "나대지", h: "등기상태", i: "" },
        { a: "대구수성구만촌동", b: "422-2", c: "대", d: "128", e: "2002/11/07", f: "2002/12/03", g: "나대지", h: "등기상태", i: "" },
        { a: "대구수성구만촌동", b: "863-42", c: "도로", d: "128", e: "2002/11/07", f: "2002/12/03", g: "나대지", h: "등기상태", i: "" },
        { a: "대구수성구만촌동", b: "885-4", c: "대", d: "128", e: "2002/11/07", f: "2002/12/03", g: "나대지", h: "등기상태", i: "" },
        { a: "대구수성구만촌동", b: "1354-1", c: "대", d: "128", e: "2002/11/07", f: "2002/12/03", g: "나대지", h: "등기상태", i: "" },
        { a: "대구수성구만촌동", b: "1354-1", c: "대", d: "128", e: "2002/11/07", f: "2002/12/03", g: "나대지", h: "등기상태", i: "" },
        { a: "대구수성구만촌동", b: "1354-1", c: "대", d: "128", e: "2002/11/07", f: "2002/12/03", g: "나대지", h: "등기상태", i: "" },
        { a: "대구수성구만촌동", b: "1354", c: "대", d: "128", e: "2002/11/07", f: "2002/12/03", g: "나대지", h: "등기상태", i: "" },
        { a: "대구수성구만촌동", b: "422-3", c: "주차장", d: "128", e: "2002/11/07", f: "2002/12/03", g: "나대지", h: "등기상태", i: "" },
        { a: "대구수성구만촌동", b: "1343-18", c: "대", d: "128", e: "2002/11/07", f: "2002/12/03", g: "나대지", h: "등기상태", i: "" },
        { a: "대구수성구만촌동", b: "1343-34", c: "대", d: "128", e: "2002/11/07", f: "2002/12/03", g: "나대지", h: "등기상태", i: "" },
        { a: "대구수성구만촌동", b: "422-2", c: "대", d: "128", e: "2002/11/07", f: "2002/12/03", g: "나대지", h: "등기상태", i: "" },
        { a: "대구수성구만촌동", b: "863-42", c: "도로", d: "128", e: "2002/11/07", f: "2002/12/03", g: "나대지", h: "등기상태", i: "" },
    ];

    var API_SERVER = "http://api-demo.ax5.io";
    var firstGrid = new ax5.ui.grid();

    firstGrid.setConfig({
        target: $('[data-ax5grid="first-grid"]'),
        columns: [
            {key: "a", label: "소재지", width : "10%"},
            { key: "b", label: "지번", width: "10%", sortable: true},
            {key: "c", label: "지목", width : "10%"},
            {key: "d", label: "면적(m²)", width : "10%"},
            {key: "e", label: "계약일자", width : "10%"},
            {key: "f", label: "등기일자", width : "10%"},
            {key: "g", label: "현재용도", width : "10%"},
            {key: "h", label: "상태구분", width : "10%"},
            {key: "i", label: "임대여부", width : "10%"}
        ]
    });

    // {a: "A", b: "A01", c:"C", d:"D", e:"E", f:"F", g:"G"}
    // 값이 없는 h 는 표현안됨
    firstGrid.setData(gridList);
    // 그리드 데이터 가져오기
    /*
    $.ajax({
        method: "GET",
        url: API_SERVER + "/api/v1/ax5grid",
        success: function (res) {
            firstGrid.setData(res);
        }
    });
    */
});
//window-onload