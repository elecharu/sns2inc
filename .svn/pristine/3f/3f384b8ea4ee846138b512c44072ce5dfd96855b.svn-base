/// <reference path="../Script/reference.js" />
var ItsFileManager = {
    Reset: function () {

    },
    SetFileKey: function (id, key, name) {
        $('#' + id + '_fileManager_key').val(key);
        if (name != undefined) {
            document.getElementById(id + "ex_filename_visible").value = name;
        }
    },
    GetFileKey: function (id) {
        return $('#' + id + '_fileManager_key').val();
    },
    SetFileName: function (id, name) {
        document.getElementById(id + "ex_filename_visible").value = name;
    },
    GetFileName: function (id) {
        return document.getElementById(id + "ex_filename_visible").value.split(' | ')[0];
    },
    Clear: function (id) {
        document.getElementById(id + 'ex_filename').value = "";
        document.getElementById(id + 'ex_filename_visible').value = "";
        $('#' + id + '_fileManager_key').val('');
        var _$imageId = $('#' + id).data('bindimageid');
        if (_$imageId != undefined && _$imageId != '') {
            ItsImage.Clear(_$imageId);
        }
        ItsFileManager.Event(id).onClear(id);
    },
    Disable: function (id) {
        var $obj = $('#' + id);
        ItsFileManager.DisableObj($obj);
    },
    Hide: function (id) {
        var $input = $('#' + id);
        $input.css('display', 'none');
        return true;
    },
    Show: function (id) {
        var $input = $('#' + id);
        $input.css('display', '');
        return false;
    },
    DisableObj: function ($obj) {
        $obj.attr('data-disabled', 'true');
        $obj.find('label').css('opacity', '0.7');
        $obj.find('label').eq(0).attr('for', '');
        return true;
    },
    Enable: function (id) {
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
        var $input = $('input#' + id + '_fileManager_key');
        return $input.val();
    },
    GetField: function (id) {
        var $input = $('input#' + id + '_fileManager_key');
        return $input.attr('data-field');
    },
    IsFileChanged: function (id) {
        var path = $('#' + id + 'ex_filename').val();
        if (path.indexOf('fakepath') > -1) {
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
        this.onUpload = function (id, fileKey, fileName) { };
        this.onDelete = function (id, fileKey) { };
        this.onClear = function (id) { };
    },
    SetInitObj: function ($fileManager) {
        if ($fileManager.eq(0).attr('class') == 'ItsFileManager') {
            var id = $fileManager.eq(0).attr('id');
            document.getElementById(id + 'ex_filename').value = "";
            document.getElementById(id + 'ex_filename_visible').value = "";
            $('#' + id + '_fileManager_key').val('');
            var _$imageId = $('#' + id).data('bindimageid');
            if (_$imageId != undefined && _$imageId != '') {
                ItsImage.Clear(_$imageId);
            }
            ItsFileManager.Event(id).onClear(id);
        }        
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
    formData.append('NEWNMYN', "F");
    formData.append('SAVETYPE', $('#' + id).attr('data-savetype'));

    //var request = new XMLHttpRequest();
    //var $url = '../../Controller/FileUpload.aspx';
    //request.open('POST', $url, true);
    //request.setRequestHeader('Content-type', 'application/x-www-form-urlencoded');
    //request.send(formData);
    //request.onreadystatechange = function (e) {
    //    if (request.readyState == 4 && request.status == 200) {
    //        if (request.responseText.indexOf('ERROR') > -1) {
    //            ItsMsg.Alert(request.responseText);
    //            return;
    //        }
    //        $('#' + id + '_fileManger_key').val(request.responseText);
    //        ItsFileManager.Event(id).onUpload(id, request.responseText);

    //        if (CALLBACK != undefined) {
    //            CALLBACK();
    //        }
    //        else {
    //            ItsMsg.Toast('업로드되었습니다.');
    //        }
    //    } else if (request.status == 500) {
    //        ItsMsg.Alert(request.responseText);
    //    }
    //}
    var filename = document.getElementById(id + 'ex_filename').files[0].name;

    $.ajax({
        async: true,
        maria: this,
        url: '../../Controller/FileUpload.aspx',
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
                $('#' + id + '_fileManager_key').val(data);
                ItsFileManager.Event(id).onUpload(id, data, filename);

                if (CALLBACK != undefined) {
                    CALLBACK();
                }
                else {
                    //ItsMsg.Toast('업로드되었습니다.');
                }
            } else {
                ItsMsg.Alert(data);
            }

        },
        error: function (xhr, status, error) {
            ItsMsg.Alert('실패');
        }
    });
}

ItsFileManager.UploadNM = function (id, WAITSTT, CALLBACK, NAME) {
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
    if (NAME != '' && NAME != undefined) {
        formData.append('NEWNMYN', "Y");
        formData.append('NEWNM', NAME);
    }
    else {
        formData.append('NEWNMYN', "N");
        formData.append('NEWNM', "");
    }
    formData.append('SAVETYPE', $('#' + id).attr('data-savetype'));

    $.ajax({
        async: false,
        maria: this,
        url: '../../Controller/FileUpload.aspx',
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
                $('#' + id + '_fileManager_key').val(data);
                ItsFileManager.Event(id).onUpload(id, data);

                if (CALLBACK != undefined) {
                    CALLBACK();
                }
                else {
                    //ItsMsg.Toast('업로드되었습니다.');
                }
            } else {
                ItsMsg.Alert(data);
            }

        },
        error: function (xhr, status, error) {
            ItsMsg.Alert('실패');
        }
    });
}

ItsFileManager.Delete = function (id, filekey) {
    ItsFileManager.$delete(id, filekey);
};
ItsFileManager.$delete = function (id, filekey, CALLBACK) {
    if ($('#' + id).attr('data-disabled') == 'true') return false;
    if (location.href.indexOf('localhost') > -1) {
        alert('localhost에서는 데이터 왜곡 방지를 위해 파일업로드 기능을 제한하였습니다.');
        return;
    }
    var _$keyValue = ItsFileManager.GetFileKey(id);
    if (_$keyValue == '' || _$keyValue == undefined) {
        if (filekey != undefined && filekey != '' && filekey != null) {
            _$keyValue = filekey;
        } else {
            ItsMsg.Alert('FILEKEY가 비어있습니다.');
            return;
        }
    }

    var formData = new FormData();
    formData.append('FILEKEY', _$keyValue);
    formData.append('CALLTYPE', "DELETE");
    formData.append('centerYn', "N");

    $.ajax({
        async: false,
        maria: this,
        url: '../../Controller/FileUpload.aspx',
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
                $('#' + id + '_fileManager_key').val('');
                ItsFileManager.Event(id).onDelete(id, data);

                if (CALLBACK != undefined) {
                    CALLBACK();
                }
                else {
                    //ItsMsg.Toast('삭제되었습니다.');
                }
            } else {
                ItsMsg.Alert(data);
            }

        },
        error: function (xhr, status, error) {
            ItsMsg.Alert('실패');
        }
    });



    //var request = new XMLHttpRequest();
    //var $url = '../../Controller/FileUpload.aspx';
    //request.open('POST', $url, true);
    //request.setRequestHeader('Content-type', 'application/x-www-form-urlencoded');
    //request.send(formData);
    //request.onreadystatechange = function (e) {
    //    if (request.readyState == 4 && request.status == 200) {
    //        if (request.responseText.indexOf('ERROR') > -1) {
    //            ItsMsg.Alert(request.responseText);
    //            return;
    //        }
    //        document.getElementById(id + 'ex_filename_visible').value = "";
    //        ItsFileManager.Event(id).onDelete(id, _$keyValue);
    //        $('#' + id + '_fileManager_key').val('');
    //        var _$imageId = $('#' + id).data('bindimageid');
    //        if (_$imageId != undefined && _$imageId != '') {
    //            ItsImage.Clear(_$imageId);
    //        }
    //        ItsMsg.Toast('삭제되었습니다.');
    //    } else if (request.status == 500) {
    //        ItsMsg.Alert(request.responseText);
    //    }
    //}
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