$(document).ready(function () {
    $("input[type=date]").attr("placeholder", "20XX-XX-XX");
    $("input[type=time]").attr("placeholder", "00:00:00");
    //date, time 유효성검사 추가... 익플용...
});
function Print() {
    $('.printhd').hide();
    window.print();
    $('.printhd').show();
}
function reservationPop() {
    window.open('./addreservation.aspx', 'reservation', 'width=400, height=320, top=0, left=0');
}

/**********************************************
 * 공용 함수 및 로그인 함수
 **********************************************/
function GET_COOKIE(cookieName) {
    var cookieValue = "";
    if (document.cookie != "") {
        var array = document.cookie.split(escape(cookieName) + '=');
        if (array.length >= 2) {
            var arraySub = array[1].split(";");
            cookieValue = unescape(arraySub[0]);
        }
    }
    return cookieValue;
}
function SET_COOKIE(cookieName, cookieValue, adddate) {
    if (cookieName == 'TMLUID' && GET_COOKIE('TMLUID') != '') return;
    var cookieText = escape(cookieName) + '=' + escape(cookieValue);
    if (!adddate) {
        cookieText += ';path=/;EXPIRES=' + (new Date(2999, 12, 31)).toGMTString() + ';';
    } else {
        var deldate = new Date();
        deldate.setDate(deldate.getDate() + adddate);
        cookieText += ';path=/;EXPIRES=' + deldate.toGMTString() + ';';
    }
    document.cookie = cookieText;
}
function sessionCheck() {
    var maria = new ItsMaria('COMSESSION', 'CHECK'); maria.AddSessionUserId(); maria.CallProc(); if (maria.isError) { usernm = ''; userid = ''; return false } else { usernm = maria.storeExtend1.GetValue(0, 'USERNM'); userid = maria.storeExtend1.GetValue(0, 'USERID'); return true }
};
function LoginCheck() {
    if (sessionCheck() == false) {
        ItsMsg.Alert("로그인 후 사용가능합니다.");
        return false;
    }
    return true;
}
/********************************************
 * >>>>> object: 오브젝트 처리 >>>>>
 * 2017-10-01: 김동학: 최초 작성
 * 2018-02-13: 문재원: ItsHelper.GetDate() 추가
 * 2018-11-15: 왕현준: CopyFile(filePath) 추가
 * 2018-12-14: 왕현준: SendMail(To_ID, Title, Body, FilePath, FileName) 추가
 *******************************************/
var ItsHelper = {
    IsDefined: function (obj) {
        if (obj == undefined || obj == null) return false;
        else return true;
    },
    IsUndefined: function (obj) {
        if (obj == undefined || obj == null) return true;
        else return false;
    },
    CopyObj: function (source, target) {
        if (source == undefined || source == null) {
            return;
        };
        var $datafield = Object.keys(source);
        for (var i = 0; i < $datafield.length; i++) {
            var $name = $datafield[i];
            target[$name] = source[$name];
        };
    },
    ToString: function (str) {
        if (str == undefined || str == null) {
            return "";
        } else {
            return str.toString();
        }
    },
    ToInt: function (num) {
        var rtnNum = parseInt(num);
        if (rtnNum == null || rtnNum == undefined || isNaN(rtnNum)) rtnNum = 0;
        return rtnNum;
    },
    ToDecimal: function (num) {
        var rtnNum = parseFloat(num);
        if (rtnNum == null || rtnNum == undefined || isNaN(rtnNum)) rtnNum = 0;
        return rtnNum;
    },
    // 날자문자열 변환 
    ToDate: function (date) {
        var $date = date.replace(/\-/g, '').replace(/\//g, '').replace(/\./g, '');
        if ($date.length >= 8) $date = $date.substr(0, 4) + '-' + $date.substr(4, 2) + '-' + $date.substr(6, 2);
        else if ($date.length >= 6) $date = $date.substr(0, 4) + '-' + $date.substr(6, 2) + '-01';
        else if ($date.length >= 4) $date = $date.substr(0, 4) + '-01-01';
        else $date = '';

        if (Date.parse($date) > 0) return $date;
        else return '';
    },
    ToTime: function (time) {
        var $time = time.replace(/\:/g, '');
        if ($time.length >= 6) $time = $time.substr(0, 2) + ':' + $time.substr(2, 2) + ':' + $time.substr(4, 2);
        else if ($time.length >= 4) $time = $time.substr(0, 2) + ':' + $time.substr(2, 2) + ':' + '00';
        else if ($time.length >= 2) $time = $time.substr(0, 2) + ':00:00';
        else $time = '';

        if (Date.parse('2000-01-01 ' + $time) > 0) return $time;
        else return '';
    },
    ToBoolean: function (yn) {
        if (yn == 'Y' || yn == true) {
            yn = true
        } else {
            yn = false;
        };
        return yn;
    },
    ToYn: function (bool) {
        if (bool == true || bool == 'Y' || bool.toUpperCase() == "TRUE") {
            bool = 'Y';
        } else {
            bool = 'N';
        };
        return bool;
    },
    Append: function (strList) {
        var $rtnStr = '';
        for (var i = 0; i < strList.length; i++) {
            $rtnStr += strList[i];
        };
        return $rtnStr;
    },
    AppendLine: function (strList) {
        var $rtnStr = '';
        for (var i = 0; i < strList.length; i++) {
            if (i == 0) {
                $rtnStr += strList[0];
            } else {
                $rtnStr += "\n" + strList[i];
            }
        };
        return $rtnStr;
    },
    /** 
     * sep를 구분자로 [] strList 배열속 문자열 합치기
     */
    ConcatStr: function (sep, strList) {
        var joinStr = "";
        if (sep == undefined || sep == null) {
            sep = "";
        };
        for (var i = 0; i < strList.length; i++) {
            if (i == 0) {
                joinStr = strList[0];
            } else {
                joinStr += sep + strList[i];
            };
        }
        return joinStr;
    },
    /** 
     * 문자열을 정해진 count 만큼 반복 병합
     */
    RepeatStr: function (str, count) {
        var repeatStr = "";
        for (var i = 0; i < count; i++) {
            repeatStr += str;
        };
        return repeatStr;
    },
    /**
     * @param {Number} month
     */
    AddMonth: function (month, baseDate) {
        if (month == undefined) {
            return new Date().format('yyyy-MM-dd');
        }
        var $date = baseDate;
        if ($date == undefined || $date == null) {
            $date = new Date();
        }
        try {
            $date = new Date($date);
        } catch (e) {
            $date = new Date();
        }
        $date.setMonth($date.getMonth() + month);
        return $date.format('yyyy-MM-dd');
    },
    /**
     * @param {Number} day
     */
    AddDay: function (day, baseDate) {
        if (day == undefined) {
            return new Date().format('yyyy-MM-dd');
        }
        var $date = baseDate;
        if ($date == undefined || $date == null) {
            $date = new Date();
        }
        try {
            $date = new Date($date);
        } catch (e) {
            $date = new Date();
        }
        $date.setDate($date.getDate() + day);
        return $date.format('yyyy-MM-dd');
    },
    // addHour: function(hour) {
    //     var $date = Ext.Date.add(new Date(), Ext.Date.HOUR, hour);
    //     return Ext.Date.toString($date).replace('T', ' ').substr(0, 19);
    // },

    // addMinute: function(minute) {
    //     if(minute == undefined) {
    //         alert('minute is required.');
    //         return '';
    //     }
    //     var date = new Date((new Date()).getTime() + minute * 60 * 1000);
    //     return Ext.Date.toString(date).substr(0, 10);
    // },
    GetDateFull: function (date) {
        if (date == undefined) {
            return new Date().format('yyyy-MM-dd HH:mm:ss');
        } else {
            return new Date(date).format('yyyy-MM-dd HH:mm:ss');
        }
    },
    GetYearMonth: function (date) {
        if (date == undefined) {
            return new Date().format('yyyy-MM');
        } else {
            return new Date(date).format('yyyy-MM');
        }
    },
    GetYearMonthDay: function (date) {
        if (date == undefined) {
            return new Date().format('yyyy-MM-dd');
        } else {
            return new Date(date).format('yyyy-MM-dd');
        }
    },
    GetHourMinute: function (date) {
        if (date == undefined) {
            return new Date().format('HH:mm');
        } else {
            return new Date(date).format('HH:mm:ss');
        }
    },
    GetHourMinuteSecond: function (date) {
        if (date == undefined) {
            return new Date().format('HH:mm:ss');
        } else {
            return new Date(date).format('HH:mm:ss');
        }
    },
    CopyFile: function (filePath) {
        var $filename = '';
        if (filePath != '') {
            try {
                filePath = 'UploadFiles' + filePath.split('UploadFiles')[1].replace(/\//gi, '\\');


                $.ajax({
                    async: false,
                    maria: this,
                    url: 'http://09mipl.co.kr/CONTROLLER/FaxFileCopy.aspx?filepath=' + filePath,
                    type: 'post',
                    dataType: 'text',
                    data: {
                        filePath: filePath,
                        centerYn: 'Y'
                    },
                    success: function (data, staus) {
                        var $pathText = data;
                        if ($pathText != '') {
                            var pathAllay = $pathText.split('\\');
                            pathAllay = pathAllay[pathAllay.length - 1].split('\n');
                            $filename = pathAllay[0];
                        }
                        else
                            ItsMsg.Alert('서버에 파일 등록 실패');

                    },
                    error: function (xhr, status, error) {
                        ItsMsg.Alert('서버에 파일 등록 실패');
                    }
                });
            }
            catch (exception) { }
        }
        return $filename;
    },

    SendMail: function (To_ID, Title, Body, FilePath, FileName, async) {
        var $returnval = false;

        var maria = new ItsMaria('MAIL_SERVICE', 'SEND_MAIL');
        maria.AddSessionUserId();
        maria.CallProcCenter();
        if (maria.isError) {
            maria.ShowErrMsg();
            return $returnval;
        }

        if (async == '' || async == undefined) {
            async = false;
        }
        else {
            async = true;
            $returnval = true;
        }

        $.ajax({
            async: async,
            maria: this,
            url: 'http://09mipl.co.kr/CONTROLLER/SendMail.aspx?fromaddr=' + maria.store.data[0]['EMAILID'],
            type: 'post',
            dataType: 'text',
            data: {
                frompw: maria.store.data[0]['EMAILPW'],
                host: maria.store.data[0]['HOST'],
                port: maria.store.data[0]['PORT'],
                toid: To_ID,
                title: Title,
                body: Body,
                filepath: FilePath,
                filename: FileName,
                displayname: maria.store.data[0]['NAME']
            },
            success: function (data, staus) {
                var $resText = data;
                if ($resText.length > 2) {
                    $returnval = true;
                }
                else {
                    $returnval = false;
                }

            },
            error: function (xhr, status, error) {
                $returnval = false;
            }
        });
        return $returnval;
    }
};
/********************************************
 * >>>>> store: 데이터 저장소 >>>>>
 * 2017-10-01: 김동학: 최초 작성
 *******************************************/
var Store = function (storeName) {
    this.storeName = storeName;
    this.data = [];
};
Store.$showDebug = function (storeName) {
    alert("DEBUG: " + storeName + "가 비어 있습니다.");
    return "";
};
/**********************************************
 * store: 스토어 프로토타입
 * Ext Store prototype 함수명과 일치화
 * 개발자 코딩 시 인텔리전스 및 debug 편의성
 **********************************************/
Store.prototype.GetValue = function (rowIndex, fieldName) {
    try {
        return this.data[rowIndex][fieldName];
    } catch (e) {
        return undefined;
    }
};
Store.prototype.Length = function () {
    try {
        return this.data.length;
    } catch (e) {
        return 0;
    }
};
Store.prototype.FirstRecord = function () {
    try {
        return this.data[0];
    } catch (e) {
        return undefined;
    }
};
Store.prototype.LastRecord = function () {
    try {
        return this.data[this.data.length - 1];
    } catch (e) {
        return undefined;
    }
};
Store.prototype.GetRecord = function (index) {
    try {
        return this.data[index];
    } catch (e) {
        return undefined;
    }
};
Store.prototype.YnToBool = function (field) {
    for (var j = 0; j < this.data.length; j++) {
        var $value = this.data[j][field];
        if ($value == null) {
            $value = "";
        } else {
            $value = $value.toString().toUpperCase()
        }
        if ($value == "Y" || $value == "TRUE") {
            this.data[j][field] = true;
        } else if ($value == "N" || $value == "FALSE") {
            this.data[j][field] = false;
        }
    }
    return this;
}