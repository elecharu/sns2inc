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
            $if += 'src="../../Script/pdfjs/web/viewer.html?file=emptyFile.pdf&ver=1.00" width="100%" height="99%" frameborder="0" framespacing="0" style="width:100%;" />';
            $(this).html($if);
        });
    },
    SetSrc: function (id, src) {
        $('#' + id)[0].src = '../../Script/pdfjs/web/viewer.html?file=' + src;
    },
    SetUrl: function (id, src) {
        $('#' + id)[0].src = src;
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
 * >>>>> ItsXtraRpt: devexpress 리포트 >>>>>
 *******************************************/
var ItsXtraRpt = function (procName) {
    this.procName = procName;
    this.fileName = '';
    this.timeout = 120;
    this.params = [];
    this.values = [];
    this.isError = false;
    this.errMessage = '';
};
ItsXtraRpt.prototype.FileName = function (filename) {
    this.fileName = filename;
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
ItsXtraRpt.prototype.SetPassword = function (pw) {
    this.AddParam('PW', pw);
};
ItsXtraRpt.prototype.Call = function (viewerId) {
    this.$call(viewerId);
};
ItsXtraRpt.prototype.CallPop = function () {
    this.$call('');
};
ItsXtraRpt.prototype.CallExcel = function (viewerId, fileType) {
    if (fileType == undefined || fileType == '') {
        this.$call(viewerId, 'xlsx');
    }
    else {
        this.$call(viewerId, fileType);
    }
};
ItsXtraRpt.prototype.CallExcelReport = function (viewerId, fileType) {
    this.$call(viewerId, 'CallExcelReport');
};
//레포트 생성 후 비동기식 실행
ItsXtraRpt.prototype.CallSyn = function (params, callback) {
    params.iscenter = false;
    return this.$callSyn(params, callback);
};
ItsXtraRpt.prototype.CallSynExcel = function (params, callback) {
    params.iscenter = false;
    return this.$callSyn(params, callback, 'xlsx');
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
ItsXtraRpt.prototype.$call = function (viewerId, fileType) {
    var rpt = this;
    if (fileType == undefined) {
        fileType = 'pdf';
    }
    $.ajax({
        async: false,
        url: '../../CONTROLLER/XtraReport.aspx',
        type: 'post',
        dataType: 'text',
        data: {
            procName: this.procName,
            paramStr: this.ToString(),
            fileType: fileType,
            fileName: this.fileName
        },
        success: function (data, staus) {
            var $resText = data;
            if ($resText.substring(0, 6).toUpperCase() == 'ERROR:') {
                rpt.isError = true;
                rpt.errMessage = $resText.substring(6);
            } else if ($resText.substring(0, 8).toUpperCase() == 'SESSION:') {
                rpt.isError = true;
                rpt.errMessage = "session expired";
                location.replace('/PAGECOM/PORTAL/index.aspx');
            } else {

                rpt.path = $resText;

                if (fileType == "CallExcelReport") {
                    location.href = rpt.path;
                    return;
                }

                if (viewerId != undefined && viewerId != '') {
                    if ($('#' + viewerId).length > 0) {
                        ItsRptViewer.SetSrc(viewerId, $resText);
                    }
                } else {
                    function printPdf(url) {
                        var iframe = document.createElement('iframe');
                        // iframe.id = 'pdfIframe'
                        iframe.className = 'pdfIframe'
                        document.body.appendChild(iframe);
                        iframe.style.display = 'none';
                        iframe.onload = function () {
                            setTimeout(function () {
                                iframe.focus();
                                iframe.contentWindow.print();
                                URL.revokeObjectURL(url)
                                // document.body.removeChild(iframe)
                            }, 1);
                        };
                        iframe.src = url;
                        // URL.revokeObjectURL(url)
                    }
                    printPdf($resText);
                }
            }
        },
        error: function (xhr, status, error) {
            this.isError = true;
            this.errMessage = error;
        }
    });
};

//비동기식 호출
ItsXtraRpt.prototype.$callSyn = function (params, callback, fileType) {
    var rpt = this;
    if (fileType == undefined) {
        fileType = 'pdf';
    }
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
        url: '../../CONTROLLER/XtraReport.aspx',
        type: 'post',
        dataType: 'text',
        data: {
            procName: this.procName,
            paramStr: this.ToString(),
            fileType: fileType,
            fileName: fileName
        },
        success: function (data, staus) {
            var $resText = data;
            if ($resText.substring(0, 6).toUpperCase() == 'ERROR:') {
                rpt.isError = true;
                rpt.errMessage = $resText.substring(6);
            } else if ($resText.substring(0, 8).toUpperCase() == 'SESSION:') {
                rpt.isError = true;
                rpt.errMessage = "session expired";
                location.replace('/PAGECOM/PORTAL/index.aspx');
            } else {
                rpt.path = $resText;
                params.path = $resText;
                callback(params);
            }            
        },
        error: function (xhr, status, error) {
            rpt.isError = true;
            rpt.errMessage = error;
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
    obj.find(".ItsField.ItsDateRange_F").each(function () {
        var $input = $(this);
        rpt.AddParam($input.attr('data-field'), $input.val());
    });
    obj.find(".ItsField.ItsDateRange_T").each(function () {
        var $input = $(this);
        rpt.AddParam($input.attr('data-field'), $input.val());
    });
    obj.find(".ItsField.ItsCheck_button").each(function () {
        var $input = $(this);
        rpt.AddParam($input.attr('data-field'), $input.attr('data-value'));
    });
    obj.find(".ItsField.ItsRadio").each(function () {
        var $input = $(this);
        rpt.AddParam($input.children('.ItsRadio_table').attr('data-field'), $input.children('.ItsRadio_table').attr('data-value'));
    });
};
ItsXtraRpt.prototype.AddList = function (field, value) {
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
/********************************************
 * >>>>> ItsExcelRpt: 엑셀파일에 바인딩 >>>>>
 *******************************************/
var ItsExcelRpt = function (srcName, query, fileType, fname) {
    this.srcName = srcName;
    this.query = query;
    this.resName = '';
    this.isError = false;
    this.errMessage = '';
    if (fileType == undefined)
        fileType = '';
    this.fileType = fileType;
    this.fname = fname;
};
ItsExcelRpt.prototype.Call = function () {
    var rpt = this;
    $.ajax({
        async: false,
        url: this.srcName + '.aspx',
        type: 'post',
        dataType: 'text',
        data: {
            fileType: rpt.fileType,
            query: rpt.query,
            fname: rpt.fname
        },
        success: function (data, staus) {
            var $resText = data;
            if ($resText.substring(0, 6).toUpperCase() == 'ERROR:') {
                rpt.isError = true;
                rpt.errMessage = $resText.substring(6);
            } else if ($resText.substring(0, 8).toUpperCase() == 'SESSION:') {
                rpt.isError = true;
                rpt.errMessage = "session expired";
                location.replace('/PAGECOM/PORTAL/index.aspx');
            } else if ($resText.indexOf('COMException') > -1) {
                rpt.isError = true;
                rpt.errMessage = "엑셀 변환에 실패했습니다. 잠시 후 다시 시도해 주세요.";
            } else {
                rpt.resName = $resText;
            }
        },
        error: function (xhr, status, error) {
            rpt.isError = true;
            rpt.errMessage = error;
        }
    });
};
ItsExcelRpt.prototype.DownLoad = function () {
    location.href = this.resName;
};
/********************************************
 * >>>>> ItsTmlLabel: wpf에서 만든 라벨양식 >>>>>
 *******************************************/
var ItsTmlLabel = function (labelcd, query) {
    this.labelcd = labelcd;
    this.query = query;
    this.isError = false;
    this.errMessage = '';
};
ItsTmlLabel.prototype.Call = function (viewerId) {
    var rpt = this;
    $.ajax({
        async: false,
        url: '../../CONTROLLER/TmlLabel.aspx',
        type: 'post',
        dataType: 'text',
        data: {
            labelcd : rpt.labelcd,
            query: rpt.query
        },
        success: function (data, staus) {
            var $resText = data;
            if ($resText.substring(0, 6).toUpperCase() == 'ERROR:') {
                rpt.isError = true;
                rpt.errMessage = $resText.substring(6);
            } else if ($resText.substring(0, 8).toUpperCase() == 'SESSION:') {
                rpt.isError = true;
                rpt.errMessage = "session expired";
                location.replace('/PAGECOM/PORTAL/index.aspx');
            } else {
                rpt.path = $resText;
                if (viewerId != undefined && viewerId != '') {
                    if ($('#' + viewerId).length > 0) {
                        ItsRptViewer.SetSrc(viewerId, $resText);
                    }
                } else {
                    function printPdf(url) {
                        var iframe = document.createElement('iframe');
                        // iframe.id = 'pdfIframe'
                        iframe.className = 'pdfIframe'
                        document.body.appendChild(iframe);
                        iframe.style.display = 'none';
                        iframe.onload = function () {
                            setTimeout(function () {
                                iframe.focus();
                                iframe.contentWindow.print();
                                URL.revokeObjectURL(url)
                                // document.body.removeChild(iframe)
                            }, 1);
                        };
                        iframe.src = url;
                        // URL.revokeObjectURL(url)
                    }
                    setTimeout(function () {
                        printPdf($resText);
                    }, 1000);
                }
            }
        },
        error: function (xhr, status, error) {
            rpt.isError = true;
            rpt.errMessage = error;
        }
    });
};