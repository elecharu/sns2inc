/// <reference path="../Script/reference.js" />
/********************************************
 * >>>>> ItsRptViewer: 리포트뷰어 컨트롤 >>>>>
 * 2018-08-17: 문재원: 최초 작성
 *******************************************/
var ItsRptViewer = {
    Reset: function () {
        $('.ItsRptViewer').each(function () {
            var $id = $(this).attr('data-id');
            var $if = '<iframe ';
            if ($id != undefined) {
                $if += 'id="' + $id + '" ';
            }
            $if += 'src="../../Script/pdfjs/web/viewer.html?file=emptyFile.pdf" width="100%" height="99%" frameborder="0" framespacing="0" style="width:100%;" />';
            $(this).html($if);
        });
    },
    SetSrc: function (id, src) {
        $('#' + id)[0].src = '../../Script/pdfjs/web/viewer.html?file=' + src;
    },
    Print: function (id) {
        document.getElementById(id).contentWindow.document.getElementById('print').click();
    },
    Download: function (id, src) {
        document.getElementById(id).contentWindow.document.getElementById('download').click();
    },
    Clear: function (id) {
        $('#' + id)[0].src = '../../Script/pdfjs/web/viewer.html?file=emptyFile.pdf';
    }
};
/********************************************
 * >>>>> ItsRpt: 리포트 생성 >>>>>
 * 2018-08-21: 문재원: 최초 작성
 *******************************************/
var ItsRpt = function () {
    this.waitStartFlag = false;
    this.isError = false;
    this.errMessage = '';
    this.procName = '';
    this.callType = '';
    this.timeout = 120;
    this.params = [];
    this.values = [];
    this.query = '';
    this.src = '';
    this.url = '../../CONTROLLER/Report.aspx';
    this.path = '';
    this.fileName = '';
    this.subReportSectionName = '';
    this.subReportObjectName = '';
    this.subReportFileName = '';
    this.subReportQueryIndex = '';
    this.subReportParentSubReport = '';
    this.imageUrlFieldName = '';
    this.imageFieldName = '';
    this.imageQueryIndex = '';
    this.chartSectionName = '';
    this.chartObjectName = '';
    this.chartQueryIndex = '';
    this.password = '';
};
ItsRpt.prototype.SetProc = function (procName, callType, timeout) {
    this.procName = procName;
    this.callType = callType;
    if (timeout == undefined) timeout = 120;
    this.timeout = timeout;
}
ItsRpt.prototype.AddParam = function (field, value) {
    if (value == undefined) {
        value = '';
    }
    if (ItsHelper.toString(field) == '') {
        return false;
    } else {
        var $index = this.params.indexOf(field);
        if ($index > -1) {
            this.values[$index] = value;
            return true;
        } else {
            this.params.push(field);
            this.values.push(value);
            return true;
        }
    }
}
ItsRpt.prototype.AddList = function (field, value) {
    if (ItsHelper.toString(field) == '') {
        return false;
    } else {
        var $index = this.params.indexOf(field);
        if ($index == -1) {
            this.params.push(field);
            this.values.push('');
            $index = this.params.length - 1;
        }
        if (value == undefined) value = '';
        this.values[$index] += value + '»';
        return true;
    }
};
ItsRpt.prototype.AddPanel = function (id) {
    var $panel = $('#' + id);
    this._$addPanel($panel);
};
ItsRpt.prototype.AddRecord = function (gridId, index) {
    this._$addRecord(gridId, index);
};
ItsRpt.prototype.ToString = function () {
    if (this.procName != undefined && this.procName != null && this.procName != '') {
        var $query = "CALL COMCALLC ('" + this.procName + "','" + this.callType + "','Y',";
        var $paramStr = "'";
        if (this.params.length > 0) {
            $paramStr += "┃";
            for (var i = 0; i < this.params.length; i++) {
                $paramStr += this.params[i] + '»' + this.values[i] + '┃';
            };
        }
        $query = $query + $paramStr + "');";
        return $query;
    };
    return this.query;
};
ItsRpt.prototype.AddQuery = function (str) {
    this.query = this.query + '\n' + str;
};
ItsRpt.prototype.CallPop = function () {
    this.$callPop(false);
},
ItsRpt.prototype.CallPopCenter = function () {
    this.$callPop(true);
},
ItsRpt.prototype.Call = function (viererId) {
    return this.$call(false, viererId, false);
},
ItsRpt.prototype.CallCenter = function (viererId) {
    this.$call(true, viererId, false);
},
//비밀번호 생성
ItsRpt.prototype.CallSecurity = function (viererId) {
    return this.$call(false, viererId, true);
},

//레포트 생성 후 비동기식 실행
ItsRpt.prototype.CallSyn = function (params, callback) {
    params.iscenter = false;
    return this.$callSyn(params, callback);
};

/**********************************************
 * report: 설정
 **********************************************/
/**
 * 메인리포트 세팅
 * @param {String} path 폴더이름 ex) SYS0101
 * @param {String} fileName 파일이름 (확장자 제외) ex) SYS0101.R01.rpt1
 */
ItsRpt.prototype.SetReport = function (path, fileName) {
    this.path = path;
    this.fileName = fileName;
    this.subReportSectionName = '';
    this.subReportObjectName = ''
    this.subReportFileName = '';
    this.subReportQueryIndex = '';
    this.subReportparentSubReport = '';
    this.imageUrlFieldName = '';
    this.imageFieldName = '';
    this.imageQueryIndex = '';
    this.chartSectionName = '';
    this.chartObjectName = '';
    this.chartQueryIndex = '';
    this.password = '';
};
/**
 * 서브리포트 세팅
 * @param {String} sectionType 섹션타입 ex) Detail, PageHeader
 * @param {String} objectName 객체 이름 ex) SubReport1
 * @param {String} fileName 파일이름 (확장자 제외) ex) SYS0101.R01.rpt1.sub1
 * @param {number} queryIndex DataTable 순서
 * @param {String} parentSubReport 서브리포트 내부의 서브리포트일 경우 부모 서브리포트 입력
 */
ItsRpt.prototype.AddSubReport = function (sectionType, objectName, fileName, queryIndex, parentSubReport) {
    if (this.subReportSectionName == '') {
        this.subReportSectionName = sectionType;
    } else {
        this.subReportSectionName += "»" + sectionType;
    }
    if (this.subReportObjectName == '') {
        this.subReportObjectName = objectName;
    } else {
        this.subReportObjectName += "»" + objectName;
    }
    if (this.subReportFileName == '') {
        this.subReportFileName = fileName;
    } else {
        this.subReportFileName += "»" + fileName;
    }
    if (this.subReportQueryIndex == '') {
        this.subReportQueryIndex = queryIndex.toString();
    } else {
        this.subReportQueryIndex += "»" + queryIndex.toString();
    }
    if (parentSubReport == undefined) {
        parentSubReport = '-';
    }
    if (this.subReportparentSubReport == '') {
        this.subReportparentSubReport = parentSubReport.toString();
    } else {
        this.subReportparentSubReport += "»" + parentSubReport.toString();
    }
};
/**
 * 이미지 세팅
 * @param {String} imageFieldName 이미지 필드네임 (레포트의 필드네임, DB에서 조회하지 않은 컬럼임)
 * @param {String} imageUrlFieldName 이미지 URL (DB조회 값)
 * @param {number} queryIndex URL 컬럼이 존재하는 DataTable 순서 및 바인딩할 DataTable 순서
 */
ItsRpt.prototype.AddImage = function (imageFieldName, imageUrlFieldName, queryIndex) {
    if (this.imageFieldName == '') {
        this.imageFieldName = imageFieldName;
    } else {
        this.imageFieldName += "»" + imageFieldName;
    }
    if (this.imageUrlFieldName == '') {
        this.imageUrlFieldName = imageUrlFieldName;
    } else {
        this.imageUrlFieldName += "»" + imageUrlFieldName;
    }
    if (this.imageQueryIndex == '') {
        this.imageQueryIndex = queryIndex.toString();
    } else {
        this.imageQueryIndex += "»" + queryIndex.toString();
    }
};
/**
 * 차트에 넣을 데이터인덱스 세팅
 * @param {String} sectionName 섹션이름 ex) Detail, PageHeader
 * @param {String} objectName 객체 이름 ex) chart1
 * @param {number} queryIndex DataTable 순서
 */
ItsRpt.prototype.SetChartData = function (sectionName, objectName, queryIndex) {
    if (this.chartSectionName == '') {
        this.chartSectionName = sectionName;
    } else {
        this.chartSectionName += "»" + sectionName;
    }
    if (this.chartObjectName == '') {
        this.chartObjectName = objectName;
    } else {
        this.chartObjectName += "»" + objectName;
    }
    if (this.chartQueryIndex == '') {
        this.chartQueryIndex = queryIndex.toString();
    } else {
        this.chartQueryIndex += "»" + queryIndex.toString();
    }
};

// pdf 패스워드 설정
ItsRpt.prototype.SetPassword = function (password) {
    this.password = password;

};
/**********************************************
 * report: 내부 함수
 **********************************************/
ItsRpt.prototype.$call = function (iscenter, viewerId, security) {
    var $rpt = this;
    var $security = '';
    if (iscenter) {
        iscenter = "Y";
    } else {
        iscenter = "N";
    }
    if (security) {
        $security = 'security';
    }

    $.ajax({
        async: false,
        maria: this,
        url: '../../CONTROLLER/Report.aspx?centerYn=' + iscenter,
        type: 'post',
        dataType: 'text',
        data: {
            query: this.ToString(),
            centerYn: iscenter,
            path: this.path,
            fileName: this.fileName,
            subReportSectionName: this.subReportSectionName,
            subReportObjectName: this.subReportObjectName,
            subReportFileName: this.subReportFileName,
            imageUrlFieldName: this.imageUrlFieldName,
            imageFieldName: this.imageFieldName,
            imageQueryIndex: this.imageQueryIndex,
            subReportQueryIndex: this.subReportQueryIndex,
            subReportparentSubReport: this.subReportparentSubReport,
            chartSectionName: this.chartSectionName,
            chartObjectName: this.chartObjectName,
            chartQueryIndex: this.chartQueryIndex,
            security: $security,
            password: this.password
        },
        success: function (data, staus) {
            var $resText = data;
            if ($resText.substring(0, 6).toUpperCase() == 'ERROR:') {
                $rpt.isError = true;
                $rpt.errMessage = $resText.substring(6);
                if ($resText.indexOf('LicenseException') > -1) {
                    $rpt.errMessage = 'Active Report 라이센스 등록 후 사용하세요.';
                }
            } else if ($resText.substring(0, 8).toUpperCase() == 'SESSION:') {
                $rpt.isError = true;
                $rpt.errMessage = "session expired";
                location.replace('/PAGECOM/PORTAL/index.aspx');
            } else {
                $rpt.path = $resText;
                if (viewerId != undefined && viewerId != '')
                    ItsRptViewer.SetSrc(viewerId, $resText);

            }
        },
        error: function (xhr, status, error) {
            $rpt.isError = true;
            $rpt.errMessage = error;
        }
    });
};
ItsRpt.prototype.$callPop = function (iscenter) {
    var $rpt = this;
    if (iscenter) {
        var $centerYn = "Y";
    } else {
        var $centerYn = "N";
    }
    $.ajax({
        async: false,
        maria: this,
        url: '../../CONTROLLER/Report.aspx?centerYn=' + $centerYn,
        type: 'post',
        dataType: 'text',
        data: {
            query: this.ToString(),
            centerYn: $centerYn,
            path: this.path,
            fileName: this.fileName,
            subReportSectionName: this.subReportSectionName,
            subReportObjectName: this.subReportObjectName,
            subReportFileName: this.subReportFileName,
            imageUrlFieldName: this.imageUrlFieldName,
            imageFieldName: this.imageFieldName,
            imageQueryIndex: this.imageQueryIndex,
            subReportQueryIndex: this.subReportQueryIndex,
            subReportparentSubReport: this.subReportparentSubReport,
            chartSectionName: this.chartSectionName,
            chartObjectName: this.chartObjectName,
            chartQueryIndex: this.chartQueryIndex
        },
        success: function (data, staus) {
            var $resText = data;
            if ($resText.substring(0, 6).toUpperCase() == 'ERROR:') {
                $rpt.isError = true;
                $rpt.errMessage = $resText.substring(6);
                if ($resText.indexOf('LicenseException') > -1) {
                    $rpt.errMessage = 'Active Report 라이센스 등록 후 사용하세요.';
                }
            } else if ($resText.substring(0, 8).toUpperCase() == 'SESSION:') {
                $rpt.isError = true;
                $rpt.errMessage = "session expired";
                location.replace('/PAGECOM/PORTAL/index.aspx');
            } else {
                $rpt.path = $resText;
                if ($('#report_content_pop').length == 0) {
                    var $iframeReport = "";
                    $iframeReport += "<div id='report_content_pop' class='ItsPop' title='Report Viewer' style='width:1200;hright:780'>";
                    $iframeReport += "<iframe id='report_content' src = '../../Script/pdfjs/web/viewer.html?file=emptyFile.pdf' ";
                    $iframeReport += "scrolling='no' marginwidth='0' seamless ";
                    $iframeReport += "width='100%' height='100%'' frameborder=0 framespacing=0 ";
                    $iframeReport += "></iframe></div>";
                    var rptPop = $($iframeReport);
                    rptPop.dialog({
                        width: 1000,
                        height: 780,
                        autoOpen: false,
                        modal: true,
                        resizable: false,
                        open: function() {
                            $('.ui-dialog-titlebar-close').html('<i class="fa fa-times"></i>');
                        },
                        close: function (event, ui) {
                            document.getElementById('report_content').src = '../../Script/pdfjs/web/viewer.html?file=emptyFile.pdf';
                        }
                    })
                }
                $('#report_content_pop').dialog("open");
                document.getElementById('report_content').src = '../../Script/pdfjs/web/viewer.html?file=' + $resText;
            }
        },
        error: function (xhr, status, error) {
            $rpt.isError = true;
            $rpt.errMessage = error;
        }
    });
};


//비동기식 호출
ItsRpt.prototype.$callSyn = function (params, callback) {
    var $rpt = this;
    var $security = '';
    var iscenter = params.iscenter;
    var password = params.password;
    if (iscenter) {
        iscenter = "Y";
    } else {
        iscenter = "N";
    }
    if (password != '' && password != undefined) {
        $security = 'security';
    }

    $.ajax({
        async: true,
        maria: this,
        url: '../../CONTROLLER/Report.aspx?centerYn=' + iscenter,
        type: 'post',
        dataType: 'text',
        data: {
            query: this.ToString(),
            centerYn: iscenter,
            path: this.path,
            fileName: this.fileName,
            subReportSectionName: this.subReportSectionName,
            subReportObjectName: this.subReportObjectName,
            subReportFileName: this.subReportFileName,
            imageUrlFieldName: this.imageUrlFieldName,
            imageFieldName: this.imageFieldName,
            imageQueryIndex: this.imageQueryIndex,
            subReportQueryIndex: this.subReportQueryIndex,
            subReportparentSubReport: this.subReportparentSubReport,
            chartSectionName: this.chartSectionName,
            chartObjectName: this.chartObjectName,
            chartQueryIndex: this.chartQueryIndex,
            security: $security,
            password: password
        },
        success: function (data, staus) {
            var $resText = data;
            if ($resText.substring(0, 6).toUpperCase() == 'ERROR:') {
                $rpt.isError = true;
                $rpt.errMessage = $resText.substring(6);
                if ($resText.indexOf('LicenseException') > -1) {
                    $rpt.errMessage = 'Active Report 라이센스 등록 후 사용하세요.';
                }
            } else if ($resText.substring(0, 8).toUpperCase() == 'SESSION:') {
                $rpt.isError = true;
                $rpt.errMessage = "session expired";
                location.replace('/PAGECOM/PORTAL/index.aspx');
            } else {
                $rpt.path = $resText;
                params.path = $resText;
                callback(params);
            }
        },
        error: function (xhr, status, error) {
            $rpt.isError = true;
            $rpt.errMessage = error;
        }
    });
};

ItsRpt.prototype._$addPanel = function (obj) {
    var rpt = this;
    obj.find(".ItsField.ItsText").each(function () {
        var $input = $(this);
        rpt.AddParam($input.attr('data-field'), $input.val());
    });
    obj.find(".ItsField.ItsCombo").each(function () {
        var $input = $(this);
        rpt.AddParam($input.attr('data-field'), $input.attr('data-value'));
    });
    obj.find(".ItsField.ItsNum").each(function () {
        var $input = $(this);
        var value = $input.val();
        value = parseFloat(value.replace(/[^0-9]/g, ""));
        if (value.toString() == 'NaN') value = '';
        rpt.AddParam($input.attr('data-field'), value);
    });
    obj.find(".ItsField.ItsDate").each(function () {
        var $input = $(this);
        rpt.AddParam($input.attr('data-field'), $input.val());
    });
    obj.find(".ItsField.ItsFind").each(function () {
        var $input = $(this);
        rpt.AddParam($input.attr('data-field'), $input.val());
    });
    obj.find(".ItsField.ItsFileManager").each(function () {
        var $input = $(this);
        rpt.AddParam($input.data('field'), $input.val());
    });
    obj.find(".ItsField.ItsDisplay").each(function () {
        var $input = $(this);
        rpt.AddParam($input.attr('data-field'), $input.text());
    });
    obj.find(".ItsField.ItsOnoff_button").each(function () {
        var $input = $(this);
        rpt.AddParam($input.attr('data-field'), $input.attr('data-value'));
    });
    obj.find(".ItsField.ItsTextArea").each(function () {
        var $input = $(this);
        rpt.AddParam($input.attr('data-field'), $input.val());
    });
};

ItsRpt.prototype._$addRecord = function (gridId, index) {
    var rpt = this;
    var $rowData = ItsGrid.GetRowData(gridId, index);
    if ($rowData != undefined) {
        var $keys = Object.keys($rowData);
        $keys.forEach(function (key) {
            if (key != 'isRowCheck' && key != 'BACKGROUND' && key != 'FOREGROUND') {
                var $val = $rowData[key];
                if ($val === true || $val === 'true') {
                    $val = 'Y';
                } else if ($val === false || $val === 'false') {
                    $val = 'N';
                }
                rpt.AddParam(key, $val);
            }
        });
    }
};

var ItsXtraRpt = function (procName) {
    this.procName = procName;
    this.timeout = 120;
    this.params = [];
    this.values = [];
    this.isError = false;
    this.errMessage = '';
};
ItsXtraRpt.prototype.AddParam = function (name, value) {
    this.params.push(name);
    this.values.push(value);
};
ItsXtraRpt.prototype.AddPanel = function (id) {
    var $panel = $('#' + id);
    this._$addPanel($panel);
};
ItsXtraRpt.prototype.AddRecord = function (gridId, index) {
    this._$addRecord(gridId, index);
};
ItsXtraRpt.prototype.Call = function (viewerId) {
    this.$call(viewerId);
};
ItsXtraRpt.prototype.CallPop = function () {
    this.$call('');
};
ItsXtraRpt.prototype.ToString = function () {
    var $paramStr = "";
    if (this.params.length > 0) {
        for (var i = 0; i < this.params.length; i++) {
            if (i == this.params.length - 1) {
                $paramStr += this.params[i] + '»' + this.values[i];
            } else {
                $paramStr += this.params[i] + '»' + this.values[i] + '┃';
            }
        };
    }
    return $paramStr;
};
ItsXtraRpt.prototype.$call = function (viewerId) {
    $.ajax({
        async: false,
        url: '../../CONTROLLER/XtraReport.aspx',
        type: 'post',
        dataType: 'text',
        data: {
            procName: this.procName,
            paramStr: this.ToString(),
        },
        success: function (data, staus) {
            var $resText = data;
            if ($resText.substring(0, 6).toUpperCase() == 'ERROR:') {
                this.isError = true;
                this.errMessage = $resText.substring(6);
            } else if ($resText.substring(0, 8).toUpperCase() == 'SESSION:') {
                this.isError = true;
                this.errMessage = "session expired";
                location.replace('/PAGECOM/PORTAL/index.aspx');
            } else {
                this.path = $resText;
                if (viewerId != undefined && viewerId != '') {
                    ItsRptViewer.SetSrc(viewerId, $resText);
                } else {
                    if ($('#report_content_pop').length == 0) {
                        var $iframeReport = "";
                        $iframeReport += "<div id='report_content_pop' class='ItsPop' title='Report Viewer' style='width:1200;hright:780'>";
                        $iframeReport += "<iframe id='report_content' src = '../../Script/pdfjs/web/viewer.html?file=emptyFile.pdf' ";
                        $iframeReport += "scrolling='no' marginwidth='0' seamless ";
                        $iframeReport += "width='100%' height='100%'' frameborder=0 framespacing=0 ";
                        $iframeReport += "></iframe></div>";
                        var rptPop = $($iframeReport);
                        rptPop.dialog({
                            width: 1000,
                            height: 780,
                            autoOpen: false,
                            modal: true,
                            resizable: false,
                            open: function () {
                                $('.ui-dialog-titlebar-close').html('<i class="fa fa-times"></i>');
                            },
                            close: function (event, ui) {
                                document.getElementById('report_content').src = '../../Script/pdfjs/web/viewer.html?file=emptyFile.pdf';
                            }
                        })
                    }
                    $('#report_content_pop').dialog("open");
                    document.getElementById('report_content').src = '../../Script/pdfjs/web/viewer.html?file=' + $resText;
                }
            }
        },
        error: function (xhr, status, error) {
            this.isError = true;
            this.errMessage = error;
        }
    });
};
ItsXtraRpt.prototype._$addPanel = function (obj) {
    var rpt = this;
    obj.find(".ItsField.ItsText").each(function () {
        var $input = $(this);
        rpt.AddParam($input.attr('data-field'), $input.val());
    });
    obj.find(".ItsField.ItsCombo").each(function () {
        var $input = $(this);
        rpt.AddParam($input.attr('data-field'), $input.attr('data-value'));
    });
    obj.find(".ItsField.ItsNum").each(function () {
        var $input = $(this);
        var value = $input.val();
        value = parseFloat(value.replace(/[^0-9]/g, ""));
        if (value.toString() == 'NaN') value = '';
        rpt.AddParam($input.attr('data-field'), value);
    });
    obj.find(".ItsField.ItsDate").each(function () {
        var $input = $(this);
        rpt.AddParam($input.attr('data-field'), $input.val());
    });
    obj.find(".ItsField.ItsFind").each(function () {
        var $input = $(this);
        rpt.AddParam($input.attr('data-field'), $input.val());
    });
    obj.find(".ItsField.ItsFileManager").each(function () {
        var $input = $(this);
        rpt.AddParam($input.data('field'), $input.val());
    });
    obj.find(".ItsField.ItsDisplay").each(function () {
        var $input = $(this);
        rpt.AddParam($input.attr('data-field'), $input.text());
    });
    obj.find(".ItsField.ItsOnoff_button").each(function () {
        var $input = $(this);
        rpt.AddParam($input.attr('data-field'), $input.attr('data-value'));
    });
    obj.find(".ItsField.ItsTextArea").each(function () {
        var $input = $(this);
        rpt.AddParam($input.attr('data-field'), $input.val());
    });
};

ItsXtraRpt.prototype._$addRecord = function (gridId, index) {
    var rpt = this;
    var $rowData = ItsGrid.GetRowData(gridId, index);
    if ($rowData != undefined) {
        var $keys = Object.keys($rowData);
        $keys.forEach(function (key) {
            if (key != 'isRowCheck' && key != 'BACKGROUND' && key != 'FOREGROUND') {
                var $val = $rowData[key];
                if ($val === true || $val === 'true') {
                    $val = 'Y';
                } else if ($val === false || $val === 'false') {
                    $val = 'N';
                }
                rpt.AddParam(key, $val);
            }
        });
    }
};