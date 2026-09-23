/// <reference path="../Script/reference.js" />
var ItsMssql = function (SpName, WorkCode) {
    this.DbName = '';
    this.isError = false;
    this.errMessage = '';
    this.SpName = SpName;
    this.WorkCode = WorkCode;
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
    this.params = [];
    this.values = [];
    this.query = '';
};

ItsMssql.prototype.AddParam = function (field, value) {
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
ItsMssql.prototype.AddPanel = function (id) {
    var $panel = $('#' + id);
    this._$addPanel($panel);
};
ItsMssql.prototype.AddRecord = function (gridId, index) {
    this._$addRecord(gridId, index);
};

ItsMssql.prototype.AddQuery = function (str) {
    this.query = this.query + ' ' + str;
};
ItsMssql.prototype.ToString = function () {
    if (this.SpName != undefined && this.SpName != null && this.SpName != '') {
        var $paramStr = "'";
        if (this.params.length > 0) {
            $paramStr += "┃";
            for (var i = 0; i < this.params.length; i++) {
                $paramStr += this.params[i] + '»' + this.values[i] + '┃';
            };
        }
        return $paramStr;
    } else {
        return this.query;
    }
};

ItsMssql.prototype.Call = function () {
    this._$call();
};
ItsMssql.prototype.ShowErrMsg = function () {
    if (this.errMessage.indexOf('session expired') > -1 || this.errMessage.indexOf('ERROR:로그인 세션이 끊겼습니다.') > -1 || this.errMessage.indexOf('Unable to connect to any of the specified MySQL hosts.') > -1) {

        if (parent.$('.left_list_first_li').length <= 1) {
            parent.location.href = '../../PAGECOM/PORTAL/index.aspx';
            return;
        }

        if (parent.login_pop == undefined) { // iframe으로 구성되지 않은 상태일때
            ItsMsg.Confirm('개발자모드 : 로그인 세션이 만료 되었습니다.', function () {
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
        ItsMsg.Alert(this.errMessage);
        console.log(this.errMessage);
        console.log(this.ToString());
    }
};

ItsMssql.prototype._$call = function () {
    $.ajax({
        async: false,
        mssql: this,
        url: '../../Controller/MssqlCall.aspx',
        type: 'post',
        dataType: 'text',
        data: {
            DbName: this.DbName,
            SpName: this.SpName,
            WorkCode: this.WorkCode,
            Params: this.ToString(),
            query: this.ToString()
        },
        success: function (data, staus) {
            var $resText = data;
            if ($resText.substring(0, 6).toUpperCase() == 'ERROR:') {
                this.mssql.isError = true;

                this.mssql.errMessage = $resText.substring(6);
            } else if ($resText.substring(0, 8).toUpperCase() == 'SESSION:') {
                this.mssql.isError = true;
                this.mssql.errMessage = "session expired";
            } else {
                this.mssql._$json($resText);
            }
        },
        error: function (xhr, status, error) {

            this.mssql.isError = true;
            this.mssql.errMessage = error;
        }
    });
};

ItsMssql.prototype._$json = function (resText) {
    var $model = null;
    while (resText.trim() != '') {
        var $index = resText.indexOf('▥');
        if ($index > -1) {
            var $jsonText = resText.substring(0, $index);
            this._$store($jsonText);
            resText = resText.substring($index + 1);
        } else {
            this._$store(resText);
            resText = '';
        }
    };
};

ItsMssql.prototype._$store = function (jsonText) {

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
        alert('DEBUG: Exceed the maximum number of extend store');
    };
};


ItsMssql.prototype._$addPanel = function (obj) {
    var mssql = this;
    obj.find(".ItsField.ItsText").each(function () {
        var $input = $(this);
        mssql.AddParam($input.attr('data-field'), $input.val());
    });
    obj.find(".ItsField.ItsCombo").each(function () {
        var $input = $(this);
        mssql.AddParam($input.attr('data-field'), $input.attr('data-value'));
    });
    obj.find(".ItsField.ItsNum").each(function () {
        var $input = $(this);
        var value = $input.val();
        value = parseFloat(value.replace(/[^0-9.-]/g, ""));
        if (value.toString() == 'NaN') value = '';
        mssql.AddParam($input.attr('data-field'), value);
    });
    obj.find(".ItsField.ItsDate").each(function () {
        var $input = $(this);
        mssql.AddParam($input.attr('data-field'), $input.val());
    });
    obj.find(".ItsField.ItsDateRange_F").each(function () {
        var $input = $(this);
        mssql.AddParam($input.attr('data-field'), $input.val());
    });
    obj.find(".ItsField.ItsDateRange_T").each(function () {
        var $input = $(this);
        mssql.AddParam($input.attr('data-field'), $input.val());
    });
    obj.find(".ItsField.ItsFind").each(function () {
        var $input = $(this);
        mssql.AddParam($input.attr('data-field'), $input.val());
    });
    obj.find(".ItsField.ItsFileManager").each(function () {
        var $input = $(this);
        mssql.AddParam($input.attr('data-field'), $input.val());
    });
    obj.find(".ItsField.ItsDisplay").each(function () {
        var $input = $(this);
        mssql.AddParam($input.attr('data-field'), $input.text());
    });
    obj.find(".ItsField.ItsOnoff_button").each(function () {
        var $input = $(this);
        mssql.AddParam($input.attr('data-field'), $input.attr('data-value'));
    });
    obj.find(".ItsField.ItsTextArea").each(function () {
        var $input = $(this);
        mssql.AddParam($input.attr('data-field'), $input.val());
    });
    obj.find("div.ItsRadio_table").each(function () {
        var $input = $(this);
        mssql.AddParam($input.attr('data-field'), $input.children('input:checked').attr('data-value'));
    });
    obj.find("div.ItsCheck_button").each(function () {
        var $input = $(this);
        mssql.AddParam($input.attr('data-field'), $input.attr('data-value'));
    });
 };

ItsMssql.prototype._$addRecord = function (gridId, index) {
    var mssql = this;
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
                mssql.AddParam(key, $val);
            }
        });
    }
};

