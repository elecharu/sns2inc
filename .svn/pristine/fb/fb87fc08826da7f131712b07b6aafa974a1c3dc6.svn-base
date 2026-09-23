/// <reference path="../Script/reference.js" />
var ItsFileManager = {
    Reset: function () {
     
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
        $('#' + id + '_fileManger_key').val('');
        var _$imageId = $('#' + id).data('bindimageid');
        if (_$imageId != undefined && _$imageId != '') {
            ItsImage.Clear(_$imageId);
        }
    },
    Disable: function (id) {
        var $obj = $('#' + id);
        ItsFileManager.DisableObj($obj);
    },
    DisableObj: function ($obj) {
        $obj.attr('data-disabled', 'true');
        $obj.find('label').css('opacity', '0.7');
        $obj.find('label').eq(0).attr('for', '');
        return true;
    },
    Enable: function(id) {
        var $obj = $('#' + id);
        ItsFileManager.EnableObj($obj);
    },
    EnableObj: function ($obj) {
        $obj.attr('data-disabled', 'false');
        $obj.find('label').css('opacity', '1.0');
        $obj.find('label').eq(0).attr('for', $obj.attr('id') + 'ex_filename');
        return false;
    },
    GetValue: function (id) {
        var $input = $('input#' + id + '_fileManger_key');
        return $input.val();
    },
    GetField: function (id) {
        var $input = $('input#' + id + '_fileManger_key');
        return $input.attr('data-field');
    },
    IsFileChanged: function(id) {
        var path = $('#' + id + 'ex_filename').val();
        if(path.indexOf('fakepath') > -1) {
            return true;
        } else {
            return false;
        }
    },
    /** 
    @returns {ItsFileManager.Listener} 
    */
    Event: function (key) {
        if (ItsPage.EventList[key] == undefined) {
            ItsPage.EventList[key] = new ItsFileManager.Listener();
        }
        return ItsPage.EventList[key];
    },
    Listener: function () {
        this.onFileChange = function (id, fileName) { };
        this.onUpload = function (id, fileKey) { };
        this.onDelete = function (id, fileKey) { };
    }
};
ItsFileManager.Upload = function (id) {
    ItsFileManager.$upload(id);
};
ItsFileManager.$upload = function (id, WAITSTT, CALLBACK) {
    if ($('#' + id).attr('data-disabled') == 'true') return false;
    if (location.href.indexOf('localhost') > -1) {
        alert('localhost에서는 데이터 왜곡 방지를 위해 파일업로드 기능을 제한하였습니다.');
        return;
    }
    if (document.getElementById(id + "ex_filename").files.length < 1) {
        ItsMsg.Alert('파일을 선택하세요');
        return;
    }
    if (WAITSTT == undefined || WAITSTT == '' || WAITSTT == null) {
        WAITSTT = 'N';
    }

    var formData = new FormData();
    formData.append('FILENAME', document.getElementById(id + "ex_filename").files[0].name);
    formData.append('CALLTYPE', "UPLOAD");
    formData.append('centerYn', "N");
    formData.append('WAITSTT', WAITSTT);
    formData.append('FILEDATA', document.getElementById(id + "ex_filename").files[0]);

    var request = new XMLHttpRequest();
    var $url = '../../Controller/FileUpload.aspx';
    request.open('POST', $url, true);
    request.setRequestHeader('Centent-type', 'application/x-www-form-urlencoded');
    request.send(formData);
    request.onreadystatechange = function (e) {
        if (request.readyState == 4 && request.status == 200) {
            if (request.responseText.indexOf('ERROR') > -1) {
                ItsMsg.Alert(request.responseText);
                return;
            }
            $('#' + id + '_fileManger_key').val(request.responseText);
            ItsFileManager.Event(id).onUpload(id, request.responseText);

            if (CALLBACK != undefined) {
                CALLBACK();
            }
            else {
                ItsMsg.Toast('업로드되었습니다.');
            }
        } else if (request.status == 500) {
            ItsMsg.Alert(request.responseText);
        }
    }
}
ItsFileManager.Delete = function (id) {
    ItsFileManager.$delete(id);
};
ItsFileManager.$delete = function (id) {
    if ($('#' + id).attr('data-disabled') == 'true') return false;
    if (location.href.indexOf('localhost') > -1) {
        alert('localhost에서는 데이터 왜곡 방지를 위해 파일업로드 기능을 제한하였습니다.');
        return;
    }
    var _$keyValue = ItsFileManager.GetFileKey(id);
    if (_$keyValue == '' || _$keyValue == undefined) {
        ItsMsg.Alert('FILEKEY가 비어있습니다.');
        return;
    }

    var formData = new FormData();
    formData.append('FILEKEY', _$keyValue);
    formData.append('CALLTYPE', "DELETE");
    formData.append('centerYn', "N");

    var request = new XMLHttpRequest();
    var $url = '../../Controller/FileUpload.aspx';
    request.open('POST', $url, true);
    request.setRequestHeader('Centent-type', 'application/x-www-form-urlencoded');
    request.send(formData);
    request.onreadystatechange = function (e) {
        if (request.readyState == 4 && request.status == 200) {
            if (request.responseText.indexOf('ERROR') > -1) {
                ItsMsg.Alert(request.responseText);
                return;
            }
            document.getElementById(id + 'ex_filename_visible').value = "";
            ItsFileManager.Event(id).onDelete(id, _$keyValue);
            $('#' + id + '_fileManger_key').val('');
            var _$imageId = $('#' + id).data('bindimageid');
            if (_$imageId != undefined && _$imageId != '') {
                ItsImage.Clear(_$imageId);
            }
            ItsMsg.Toast('삭제되었습니다.');
        } else if (request.status == 500) {
            ItsMsg.Alert(request.responseText);
        }
    }
};
ItsFileManager.$nameChange = function (id) {
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
    ItsFileManager.Event(id).onFileChange(id, filename);
}