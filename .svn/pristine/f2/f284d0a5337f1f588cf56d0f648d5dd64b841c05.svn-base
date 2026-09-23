/// <reference path="../Script/reference.js" />
var ItsTaxFileManager = {
    Reset: function () {
     
    },
    SendFaxFile: function (id, FROMNO, FROMTITLE, FROMNM, TONM, TONO, CLEARYN ) {
        if ($('#' + id).attr('data-disabled') == 'true') return false;
        if (location.href.indexOf('localhost') > -1) {
            alert('localhost에서는 데이터 왜곡 방지를 위해 파일업로드 기능을 제한하였습니다.');
            return;
        }
        if (document.getElementById(id + "ex_filename").files.length < 1) {
            ItsMsg.Alert('파일을 선택하세요');
            return;
        }

        var formData = new FormData();
        formData.append('FILENAME', document.getElementById(id + "ex_filename").files[0].name);
        formData.append('CALLTYPE', "UPLOAD");
        formData.append('centerYn', "Y");
        formData.append('FILEDATA', document.getElementById(id + "ex_filename").files[0]);
        formData.append('TYPE', "Fax");
        formData.append('DBNAME', "MES_SBCF");

        $.ajax({
            async: false,
            maria: this,
            url: 'http://09mipl.co.kr/Controller/TaxFileUpload.aspx',
            type: 'post',
            enctype: 'multipart/form-data',
            contentType: false,
            processData: false,
            data: formData,
            success: function (data, staus) {
                if (staus == 'success') {
                    if (data.indexOf('ERROR') > -1) {
                        ItsMsg.Alert(data);
                        return;
                    }
                    $('#' + id + '_fileManger_key').val(data.split('File:')[1]);
                    $('#' + id + 'ex_filepath').val(data.split('File:')[2]);
                    ItsTaxFileManager.Event(id).onUpload(id, data);

                    ItsFaxPop.SetData(FROMNO, FROMTITLE, FROMNM, TONM, TONO);
                    ItsFaxPop.SendFax($('#' + id + 'ex_filepath').val(), TONM);
                    ItsMsg.Toast('FAX 전송완료');
                    if (CLEARYN != 'N' && CLEARYN != false) {
                        ItsTaxFileManager.Clear(id);
                    }
                } else {
                    ItsMsg.Alert(data);
                }

            },
            error: function (xhr, status, error) {
                ItsMsg.Alert('실패');
            }
        });
    },
    SetFileKey: function (id, key) {
        $('#' + id + '_fileManger_key').val(key);
    },
    GetFileKey: function (id) {
        return $('#' + id + '_fileManger_key').val();
    },
    Clear: function(id) {
        document.getElementById(id + 'ex_filename').value = "";
        document.getElementById(id + 'ex_filename_visible').value = "";
    },
    Disable: function (id) {
        var obj = $('#' + id);
        ItsTaxFileManager.DisableObj(obj);
    },
    DisableObj: function (obj) {
        obj.attr('data-disabled', 'true');
        obj.find('label').css('opacity', '0.7');
        obj.find('label').eq(0).attr('for', '');
        return true;
    },
    Enable: function(id) {
        var obj = $('#' + id);
        ItsTaxFileManager.EnableObj(obj);
    },
    EnableObj: function (obj) {
        obj.attr('data-disabled', 'false');
        obj.find('label').css('opacity', '1.0');
        obj.find('label').eq(0).attr('for', id + 'ex_filename');
        return false;
    },
    GetValue: function (id) {
        var $input = $('input#' + id + '_fileManger_key');
        return $input.val();
    },
    GetPath: function (id) {
        var $input = $('input#' + id + 'ex_filepath');
        return $input.val();
    },
    GetField: function (id) {
        var $input = $('input#' + id + '_fileManger_key');
        return $input.attr('data-field');
    },
    SetCompregno: function (id, compregno) {
        $('#' + id + '_compregno').val(compregno);
    },
    GetCompregno: function (id) {
        return $('#' + id + '_compregno').val();
    },
    /** 
    @returns {ItsTaxFileManager.Listener}
    */
    Event: function (key) {
        if (ItsPage.EventList[key] == undefined) {
            ItsPage.EventList[key] = new ItsTaxFileManager.Listener();
        }
        return ItsPage.EventList[key];
    },
    Listener: function () {
        this.onFileChange = function (id, fileName) { };
        this.onUpload = function (id, fileKey) { };
        this.onDelete = function (id, fileKey) { };
    },
    TaxFileCheck: function (COMPCD) {
        if (COMPCD == undefined) COMPCD = '';
        var maria = new ItsMaria('SAL3001_R02', 'GET_COMP');
        maria.AddParam('COMPCD', COMPCD);
        maria.CallProc();
        if (maria.isError) {
            maria.ShowErrMsg();
            return;
        }

        var COMPREGNO = maria.store.FirstRecord()['COMPREGNO'].replace(/-/gi, '');
        //for (var i = 0; i < maria.store.Length; i++) {
        //    COMPREGNO += maria.store.GetValue(i, 'BDVREGNO') + '»';
        //}

        var formData = new FormData();
        formData.append('COMPREGNO', COMPREGNO);
        var value = '';

        $.ajax({
            async: false,
            maria: this,
            url: 'http://09mipl.co.kr/Controller/TaxFileCheck.aspx',
            type: 'post',
            enctype: 'multipart/form-data',
            contentType: false,
            processData: false,
            data: formData,
            success: function (data, staus) {
                if (staus == 'success') {
                    if (data.indexOf('ERROR') > -1) {
                        ItsMsg.Alert(data);
                        return;
                    }

                    value = data.substr(0, data.length - 1);

                } else {
                    ItsMsg.Alert(data);
                }

            },
            error: function (xhr, status, error) {
                ItsMsg.Alert(error);
                return;
            }
        });

        return value;

    }

};
ItsTaxFileManager.$upload = function (id) {
    if ($('#' + id).attr('data-disabled') == 'true') return false;
    if (location.href.indexOf('localhost') > -1) {
        alert('localhost에서는 데이터 왜곡 방지를 위해 파일업로드 기능을 제한하였습니다.');
        return;
    }
    if (document.getElementById(id + "ex_filename").files.length < 1) {
        ItsMsg.Alert('파일을 선택하세요');
        return;
    }

    var $Type = $('#' + id).attr('data-type');

    if ($Type != 'Tax' && $Type != 'Key' && $Type != 'Der' && $Type != 'Fax') {
        ItsMsg.Alert('속성 Type를 확인하십시오.');
        return;
    }

    var formData = new FormData();
    formData.append('FILENAME', document.getElementById(id + "ex_filename").files[0].name);
    formData.append('CALLTYPE', "UPLOAD");
    formData.append('centerYn', "Y");
    formData.append('FILEDATA', document.getElementById(id + "ex_filename").files[0]);
    formData.append('TYPE', $Type);
    formData.append('DBNAME', "MES_SBCF");
    formData.append('COMPREGNO', $('#' + id + '_compregno').val());
    
    $.ajax({
        async: false,
        maria: this,
        url: 'http://09mipl.co.kr/Controller/TaxFileUpload.aspx',
        type: 'post',
        enctype: 'multipart/form-data',
        contentType: false,
        processData: false,
        data: formData,
        success: function (data, staus) {
            if (staus == 'success') {
                if (data.indexOf('ERROR') > -1) {
                    ItsMsg.Alert(data);
                    return;
                }
                $('#' + id + '_fileManger_key').val(data.split('File:')[1]);
                $('#' + id + 'ex_filepath').val(data.split('File:')[2]);
                ItsTaxFileManager.Event(id).onUpload(id, data);
                ItsMsg.Toast(data);                
            } else {
                ItsMsg.Alert(data);
            }

        },
        error: function (xhr, status, error) {
            ItsMsg.Alert('실패');
        }
    });

}
ItsTaxFileManager.$nameChange = function (id) {
    if (window.FileReader) {
        // modern browser 
        var filename = "";
        try {
            filename = document.getElementById(id + "ex_filename").files[0].name;
        }
        catch (exception) {
            filename = "파일선택";
        }
    } else {
        // old IE 
        var filename = document.getElementById(id + "ex_filename").val().split('/').pop().split('\\').pop(); // 파일명만 추출 
    }
    document.getElementById(id + "ex_filename_visible").value = filename;
    var _$imageId = $('#' + id).data('bindimageid');
    if (_$imageId != undefined && _$imageId != '') {
        try {
            var $obj = document.getElementById(id + "ex_filename");
            if ($obj.files && $obj.files[0]) {
                var reader = new FileReader();
                reader.onload = function (e) {
                    var $image = document.getElementById(_$imageId);
                    $image.setAttribute("src", e.target.result);
                }
                reader.readAsDataURL($obj.files[0]);
            }
        } catch (e) { }
    }
    ItsTaxFileManager.Event(id).onFileChange(id, filename);
}
