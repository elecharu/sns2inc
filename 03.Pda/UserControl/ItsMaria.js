/// <reference path="../Script/reference.js" />
var ItsMaria = function (procName, callType, timeout) {
    this.waitStartFlag = false;
    this.isError = false;
    this.errMessage = '';
    this.procName = procName;
    this.callType = callType;
    this.stores = [];
    this.async = false;
    this.callbackFn = undefined;
    this.store = new Store('store');
    this.storeExtend1 = new Store('storeExtend1');
    this.storeExtend2 = new Store('storeExtend2');
    this.storeExtend3 = new Store('storeExtend3');
    this.storeExtend4 = new Store('storeExtend4');
    this.storeExtend5 = new Store('storeExtend5');
    this.storeExtend6 = new Store('storeExtend6');
    this.storeExtend7 = new Store('storeExtend7');
    this.storeExtend8 = new Store('storeExtend8');
    this.storeExtend9 = new Store('storeExtend9');
    this.storeExtend10 = new Store('storeExtend10');
    if (timeout == undefined) timeout = 120;
    this.timeout = timeout;
    this.params = [];
    this.values = [];
    this.query = '';
};

ItsMaria.prototype.AddParam = function (field, value) {
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
};
ItsMaria.prototype.AddSessionUserId = function () {
    this.AddParam('SESSION_USERID', 'SESSION_USERID');
};
ItsMaria.prototype.AddSessionUserNm = function () {
    this.AddParam('SESSION_USERNM', 'SESSION_USERNM');
};
ItsMaria.prototype.AddSessionLoginKey = function () {
    this.AddParam('SESSION_LOGINKEY', 'SESSION_LOGINKEY');
};

ItsMaria.prototype.AddList = function (field, value) {
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
        //else if (value == true || value == 'true') value = 'Y';
        //else if (value == false || value == 'false') value = 'N';
        this.values[$index] += value + '»';
        return true;
    }
};

ItsMaria.prototype.AddPanel = function (id) {
    var $panel = $('#' + id);
    this._$addPanel($panel);
};
ItsMaria.prototype.AddRecord = function (gridId, index) {
    this._$addRecord(gridId, index);
};

ItsMaria.prototype.AddQuery = function (str) {
    this.query = this.query + '\n' + str;
};
ItsMaria.prototype.CallProc = function () {
    this.AddParam('CALLPRG', this.procName);
    this.AddParam('CALLEMP', 'CALLEMP');
    this.AddParam('CALLIP', 'CALLIP');
    this._$call("");
};
ItsMaria.prototype.CallProcCenter = function () {
    this.AddParam('CALLPRG', this.procName);
    this.AddParam('SESSION_USERID', 'SESSION_USERID');
    this.AddParam('CALLEMP', 'CALLEMP');
    this.AddParam('CALLIP', 'CALLIP');
    this._$call("CENTER");
};
ItsMaria.prototype.CallProcService = function () {
    this.AddParam('CALLPRG', this.procName);
    this.AddParam('SESSION_USERID', 'SESSION_USERID');
    this.AddParam('CALLEMP', 'CALLEMP');
    this.AddParam('CALLIP', 'CALLIP');
    this._$call("SERVICE");
};
ItsMaria.prototype.CallProcIF = function () {
    this.AddParam('CALLPRG', this.procName);
    this.AddParam('CALLEMP', 'CALLEMP');
    this.AddParam('CALLIP', 'CALLIP');
    this._$call("IF_FINE");
};

ItsMaria.prototype.Query = function () {
    this._$call("");
};
ItsMaria.prototype.QueryCenter = function () {
    this._$call("CENTER");
};

ItsMaria.prototype.ToString = function () {
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

ItsMaria.prototype.ShowErrMsg = function () {
    if (this.errMessage.indexOf('session expired') > -1 || this.errMessage.indexOf('ERROR:로그인 세션이 끊겼습니다.') > -1 || this.errMessage.indexOf('Unable to connect to any of the specified MySQL hosts.') > -1) {

        if (parent.login_pop == undefined) { // iframe으로 구성되지 않은 상태일때
            ItsMsg.Confirm('로그인 세션이 만료 되었습니다.', function () {
                window.parent.location.replace('/PAGECOM/PORTAL/index.aspx');
            }, function () {
                return;
            });
            console.log(this.ToString());
        } else {
            if (parent.$('#modalLayer').length == 0) {
                alert('로그인 세션이 만료되었습니다.');
                parent.location.replace('/PAGECOM/PORTAL/index.aspx');
            } else {
                $('#login_errMsg_pop').text('');
                parent.login_pop();
            }
        }
    } else {
        if (location.href.indexOf('GWS') > -1 || location.href.indexOf('GWM') > -1) {
            ItsMsg.AlertGw(this.errMessage);
        } else {
            ItsMsg.Alert(this.errMessage);
        }
        console.log(this.errMessage);
        console.log(this.ToString());
    }
};

ItsMaria.prototype._$call = function (connDB) {

    $.ajax({
        async: this.async,
        maria: this,
        url: '../../Controller/MariaCall.aspx',
        type: 'post',
        dataType: 'text',
        data: {
            conndb: connDB,
            query: this.ToString()
        },
        success: function (data, staus) {
            var $resText = data;
            if ($resText.substring(0, 6).toUpperCase() == 'ERROR:') {
                this.maria.isError = true;
                // if($resText.indexOf("Unable to connect to any of the specified MySQL hosts") > -1) {
                //     maria.errMessage = "session expired";
                // } else {
                //     maria.errMessage = $resText.substring(6);
                // }
                this.maria.errMessage = $resText.substring(6);
            } else if ($resText.substring(0, 8).toUpperCase() == 'SESSION:') {
                this.maria.isError = true;
                this.maria.errMessage = "session expired";
            } else {
                if (this.maria.async) {
                    this.maria._$json($resText);
                    this.maria.callbackFn(this.maria.stores);
                }
                this.maria._$json($resText);
            }
        },
        error: function (xhr, status, error) {

            this.maria.isError = true;
            this.maria.errMessage = error;
        }
    });
};

ItsMaria.prototype._$json = function (resText) {
    var $model = null;
    while (resText.trim() != '') {
        var $index = resText.indexOf('▥');
        if ($index > -1) {
            var $jsonText = resText.substring(0, $index);
            this._$store($jsonText);
            resText = resText.substring($index + 1);
            this.stores.push(new Store('', JSON.parse($jsonText)));
        } else {
            this._$store(resText);
            this.stores.push(new Store('', JSON.parse(resText)));
            resText = '';
        }
    };
};

ItsMaria.prototype._$store = function (jsonText) {

    var $data = JSON.parse(jsonText);

    var $store = $data;
    if (this.store.storeName != undefined) { this.store.data = $store; this.store.storeName = undefined; }
    else if (this.storeExtend1.storeName != undefined) { this.storeExtend1.data = $store; this.storeExtend1.storeName = undefined; }
    else if (this.storeExtend2.storeName != undefined) { this.storeExtend2.data = $store; this.storeExtend2.storeName = undefined; }
    else if (this.storeExtend3.storeName != undefined) { this.storeExtend3.data = $store; this.storeExtend3.storeName = undefined; }
    else if (this.storeExtend4.storeName != undefined) { this.storeExtend4.data = $store; this.storeExtend4.storeName = undefined; }
    else if (this.storeExtend5.storeName != undefined) { this.storeExtend5.data = $store; this.storeExtend5.storeName = undefined; }
    else if (this.storeExtend6.storeName != undefined) { this.storeExtend6.data = $store; this.storeExtend6.storeName = undefined; }
    else if (this.storeExtend7.storeName != undefined) { this.storeExtend7.data = $store; this.storeExtend7.storeName = undefined; }
    else if (this.storeExtend8.storeName != undefined) { this.storeExtend8.data = $store; this.storeExtend8.storeName = undefined; }
    else if (this.storeExtend9.storeName != undefined) { this.storeExtend9.data = $store; this.storeExtend9.storeName = undefined; }
    else if (this.storeExtend10.storeName != undefined) { this.storeExtend10.data = $store; this.storeExtend10.storeName = undefined; }
    else {
        //alert('DEBUG: Exceed the maximum number of extend store');
    };
};


ItsMaria.prototype._$addPanel = function (obj) {
    var maria = this;
    obj.find(".ItsField.ItsText").each(function () {
        var $input = $(this);
        maria.AddParam($input.attr('data-field'), $input.val());
    });
    obj.find(".ItsField.ItsCombo").each(function () {
        var $input = $(this);
        maria.AddParam($input.attr('data-field'), $input.attr('data-value'));
    });
    obj.find(".ItsField.ItsNum").each(function () {
        var $input = $(this);
        var value = $input.val();
        value = parseFloat(value.replace(/[^0-9.-]/g, ""));
        if (value.toString() == 'NaN') value = '';
        maria.AddParam($input.attr('data-field'), value);
    });
    obj.find(".ItsField.ItsDate").each(function () {
        var $input = $(this);
        maria.AddParam($input.attr('data-field'), $input.val());
    });
    obj.find(".ItsField.ItsDateRange_F").each(function () {
        var $input = $(this);
        maria.AddParam($input.attr('data-field'), $input.val());
    });
    obj.find(".ItsField.ItsDateRange_T").each(function () {
        var $input = $(this);
        maria.AddParam($input.attr('data-field'), $input.val());
    });
    obj.find(".ItsField.ItsFind").each(function () {
        var $input = $(this);
        maria.AddParam($input.attr('data-field'), $input.val());
    });
    obj.find(".ItsField.ItsFindItem").each(function () {
        var $input = $(this);
        maria.AddParam($input.attr('data-field'), $input.val());
    });
    obj.find(".ItsField.ItsFileManager").each(function () {
        var $input = $(this);
        maria.AddParam($input.attr('data-field'), $input.val());
    });
    obj.find(".ItsField.ItsDisplay").each(function () {
        var $input = $(this);
        maria.AddParam($input.attr('data-field'), $input.text());
    });
    obj.find(".ItsField.ItsOnoff_button").each(function () {
        var $input = $(this);
        maria.AddParam($input.attr('data-field'), $input.attr('data-value'));
    });
    obj.find(".ItsField.ItsTextArea").each(function () {
        var $input = $(this);
        maria.AddParam($input.attr('data-field'), $input.val());
    });
    obj.find("div.ItsRadio_table").each(function () {
        var $input = $(this);
        maria.AddParam($input.attr('data-field'), $input.children('input:checked').attr('data-value'));
    });
    obj.find("div.ItsCheck_button").each(function () {
        var $input = $(this);
        maria.AddParam($input.attr('data-field'), $input.attr('data-value'));
    });
};

ItsMaria.prototype._$addRecord = function (gridId, index) {
    var maria = this;
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
                maria.AddParam(key, $val);
            }
        });
    }
};

