/// <reference path="../Script/reference.js" />

var Store = function (storeName, data) {
    this.storeName = storeName;
    if (data != undefined) {
        this.data = data;
    } else {
        this.data = [];
    }
};

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
    if (field == undefined || field == null) {
        field = "";
    } 
    if (field == '') {
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

ItsMaria.prototype.AddQuery = function (str) {
    this.query = this.query + '\n' + str;
};

ItsMaria.prototype.CallProcCenter = function () {
    this.AddParam('CALLPRG', this.procName);
    this.AddParam('SESSION_USERID', 'SESSION_USERID');
    this.AddParam('CALLEMP', 'CALLEMP');
    this.AddParam('CALLIP', 'CALLIP');
    this._$call("CENTER");
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
    ItsMsg.Alert(this.errMessage);
    console.log(this.errMessage);
    console.log(this.ToString());
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
            iscallcenter: 'Y',
            isService: 'N',
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
