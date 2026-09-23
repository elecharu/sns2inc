/// <reference path="../Script/reference.js" />
var _AddTagParams = function () {
    this.id = '';
    this.label = '';
    this.field = '';
    this.value = '';
    this.gpcd = '';
    this.ref01 = '';
    this.ref02 = '';
    this.ref03 = '';
    this.ref04 = '';
    this.ref05 = '';
};
var ItsPage = {
    name: '',
    url: '',
    CENTERCD: '',
    EMPCD: '',
    USERID: '',
    CDN: '',
    Load: function () { },
    onReceiveParam: function (param) { },
    DebugErr: function(errMsg) {
        var html = $('#DebugPanel').html();
        $('#DebugPanel').html(html + '<div class="DebugError">' + errMsg + '</div>');
        $('#DebugPanel').css('display', 'block');
    },
    EventList: {},
    IdCount: {},
    KeyErr: function () {
        var _AddCount = function(obj) {
            var id = obj.id;
            if (id != "") {
                var oldCount = parseInt(ItsPage.IdCount[id]);
                if (isNaN(oldCount)) oldCount = 0;
                ItsPage.IdCount[id] = oldCount + 1;
            }
        };
        // 아이디 등록 및 중복 체크
        $('div.ItsText')
            .add('div.ItsCombo')
            .add('div.ItsNum')
            .add('div.ItsDate')
            .add('div.ItsMonth')
            .add('div.ItsFind')
            .find('input')
            .each(function () {
                _AddCount($(this)[0]);
            });
        $('div.ItsTextArea')
            .find('textarea')
            .each(function () {
                _AddCount($(this)[0]);
            });
        $('div.ItsGrid')
            .add('div.ItsPop')
            .add('div.ItsButton')
            .add('div.ItsTab')
            .add('img.ItsImage')
            .add('div.ItsFileManager')
            .add('div.ItsField.ItsOnoff_button')
            .add('div.ItsField.ItsDisplay')
            .add('div.ItsRadio_table')
            .add('div.ItsCheck_button')
            .add('input.ItsDateRange_F')
            .add('input.ItsDateRange_T')
            .add('div.ItsTree')
            .each(function () {
                _AddCount($(this)[0]);
            });
        $.each(ItsPage.IdCount, function (id, val) {
            if (val > 1) {
                ItsPage.DebugErr("ID 중복: " + id + ", " + val + "ea");
            }
        });
        $.each(ItsPage.EventList, function (id) {
            if (ItsPage.IdCount[id] == undefined && ItsPage.IdCount['findPop_' + id] == undefined && ItsPage.IdCount[id + '_F'] == undefined) {
                ItsPage.DebugErr("EventID Invalid: " + id);
            }
        });
    },
    Position: function(child) {
        var childLeft = child.offset().left;
        var childTop = child.offset().top;
        var parent = child.parent();
        parentLeft = parent.offset().left;
        parentTop = parent.offset().top;
        return {
            left: childLeft - parentLeft,
            top: childTop - parentTop
        };
    },
    Jump: function (prgcd, params) { // 페이지 점프
        if (parent.receiveParams == undefined) {
            return;
        }
        var maria = new ItsMaria('WEBSYSMAIN', 'PRG_INFO');
        maria.AddParam('PRGCD', prgcd);
        maria.CallProcCenter();
        if (maria.isError) {
            maria.ShowErrMsg();
            return;
        }
        if (maria.store.Length() > 0) {
            parent.receiveParams[prgcd.replace('.', '_')] = params;
            parent.add_iframe(prgcd, maria.store.GetValue(0, 'MENUPATH'), maria.store.GetValue(0, 'MENUNM'));
        } else {
            alert('Can not search menu');
        }
    },
    GetReceiveParams: function () { // 페이지 점프 했을경우 변수 받음
        return parent.receiveParams[ItsPage.name.replace('.', '_')];
    },
    SetStore: function (panelId, data) {
        if (data == undefined) return false;
        var obj = $('#' + panelId);
        obj.find(".ItsField.ItsText").each(function () {
            var $input = $(this);
            $input.val(data[$input.attr('data-field')]);
        });
        obj.find(".ItsField.ItsCombo").each(function () {
            var $input = $(this);
            var value = data[$input.attr('data-field')];
            $input.attr('data-value', value);
            var $ul = $input.siblings('ul');
            var isSearch = false;
            $ul.children('li').each(function () {
                var $li = $(this);
                if (value == $li.attr('data-value')) {
                    var label = $li.attr('data-label');
                    $input.val(label);
                    $input.css('color', '');
                    isSearch = true;
                }
            });
            if (isSearch == false)
            {
                $input.val(value);
                $input.css('color', 'red');
            }
        });
        obj.find(".ItsField.ItsNum").each(function () {
            var $input = $(this);
            $input.val(data[$input.attr('data-field')]);
            $input.trigger('change');
        });
        obj.find(".ItsField.ItsDate").each(function () {
            var $input = $(this);
            $input.val(data[$input.attr('data-field')]);
        });
        obj.find(".ItsField.ItsDateRange_F").each(function () {
            var $input = $(this);
            $input.val(data[$input.attr('data-field')]);
        });
        obj.find(".ItsField.ItsDateRange_T").each(function () {
            var $input = $(this);
            $input.val(data[$input.attr('data-field')]);
        });
        obj.find(".ItsField.ItsFind").each(function () {
            var $input = $(this);
            $input.val(data[$input.attr('data-field')]);
            ItsFind._$searchName($input);
            $input.trigger('change');
        });
        obj.find(".ItsField.ItsFileManager").each(function () {
            var $input = $(this);
            $input.val(data[$input.attr('data-field')]);
        });
        obj.find(".ItsField.ItsDisplay").each(function () {
            var $input = $(this);
            $input.text(data[$input.attr('data-field')]);
        });
        obj.find(".ItsField.ItsOnoff_button").each(function () {
            var $input = $(this);
            var $val = data[$input.attr('data-field')];
            if ($val == true || $val == 'Y') {
                ItsOnoff.$changeState($input, 'Y');
                var $cnVal = true;
            } else if ($val == false || $val == 'N') {
                ItsOnoff.$changeState($input, 'N');
                var $cnVal = false;
            }
            var key = $(this).attr('id');
            if (key != undefined && key != null && key != "") {
                ItsOnoff.Event(key).onChanged($cnVal);
            }

        });
        obj.find(".ItsField.ItsTextArea").each(function () {
            var $input = $(this);
            $input.val(data[$input.attr('data-field')]);
            $input.trigger('change');
        });
        obj.find("div.ItsRadio_table").each(function () {

            var $div = $(this);
            var $oldValue = $div.attr('data-value');
            var value = data[$div.attr('data-field')];
            var $input = $div.children('input').filter('[data-value="' + value + '"]');

            if (value == '') {
                return;
            }

            $div.attr('data-value', value);
            if ($input == undefined || $input == null || $input.length == 0) {
                $div.css('color', 'red');
                $input.prop("checked", true);

            } else {
                var label = $input.attr('data-label');
                $div.css('color', '');
                $input.prop("checked", true);

            }
            var key = $(this).attr('id');
            if (key != undefined && key != null && key != "") {
                ItsRadio.Event(key).onChanged(value, $oldValue);
            }
        });
        obj.find(".ItsField.ItsCheck_button").each(function () {
            var $input = $(this);
            var $val = data[$input.attr('data-field')];
            if ($val == true || $val == 'Y') {
                ItsCheck.$changeState($input, 'Y');
                var $cnVal = true;
            } else if ($val == false || $val == 'N') {
                ItsCheck.$changeState($input, 'N');
                var $cnVal = false;
            }
            var key = $(this).attr('id');
            if (key != undefined && key != null && key != "") {
                ItsCheck.Event(key).onChanged($cnVal);
            }
        });
    },
    GetStore: function (panelId) {
        var result = {};
        var $panel = $("#" + panelId);
        $panel.find("input.ItsField").each(function () {
            var $input = $(this);
            if ($input.hasClass('ItsText')) {
                var field = $input.attr('data-field');
                result[field] = $input.val();
            } else if ($input.hasClass('ItsCombo')) {
                var field = $input.attr('data-field');
                result[field] = $input.attr('data-value');
            } else if ($input.hasClass('ItsNum')) {
                var field = $input.attr('data-field');
                try{
                    result[field] = parseFloat($input.val());
                } catch (e) {
                    result[field] = 0;
                }
            } else if ($input.hasClass('ItsDate')) {
                var field = $input.attr('data-field');
                result[field] = $input.val();
            } else if ($input.hasClass('ItsDateRange_F')) {
                var field = $input.attr('data-field');
                result[field] = $input.val();
            } else if ($input.hasClass('ItsDateRange_T')) {
                var field = $input.attr('data-field');
                result[field] = $input.val();
            } else if ($input.hasClass('ItsFind')) {
                var field = $input.attr('data-field');
                result[field] = $input.val();
            } else if ($input.hasClass('ItsFileManager')) {
                var field = $input.attr('data-field');
                result[field] = $input.val();
            } else if ($input.hasClass('ItsDisplay')) {
                var field = $input.attr('data-field');
                result[field] = $input.text();
            } else if ($input.hasClass('ItsOnoff_button')) {
                var field = $input.attr('data-field');
                result[field] = $input.attr('data-value');
            } else if ($input.hasClass('ItsCheck_button')) {
                var field = $input.attr('data-field');
                result[field] = $input.attr('data-value');
            }
        });
        $panel.find(".ItsField.ItsOnoff_button").each(function () {
            var $div = $(this);
            if ($div.hasClass('ItsOnoff_button')) {
                var field = $div.attr('data-field');
                result[field] = $div.attr('data-value');
            }
        });
        $panel.find("div.ItsRadio_table").each(function () {
            var $div = $(this);
            var field = $div.attr('data-field');
            result[field] = $div.attr('data-value');
        });
        $panel.find("textarea").each(function () {
            var $div = $(this);
            var field = $div.attr('data-field');
            result[field] = $div.val();
        });
        return result;
    },
    InitData: function (panelId) {
        $('#' + panelId).find('.ItsText').each(function () {
            ItsText.SetInitObj($(this));
        });
        $('#' + panelId).find('.ItsNum').each(function () {
            ItsNum.SetInitObj($(this));
        });
        $('#' + panelId).find('.ItsField.ItsCombo').each(function () {
            ItsCombo.SetInitObj($(this));
        });
        $('#' + panelId).find('.ItsDate').each(function () {
            ItsDate.SetInitObj($(this));
        });
        $('#' + panelId).find('.ItsDateRange').each(function () {
            ItsDateRange.SetInitObjFrom($(this));
            ItsDateRange.SetInitObjTo($(this));
        });
        $('#' + panelId).find('.ItsFind').each(function () {
            ItsFind.SetInitObj($(this));
        });
        $('#' + panelId).find('.ItsDisplay').each(function () {
            ItsDisplay.SetInitObj($(this));
        });
        $('#' + panelId).find('.ItsOnoff_button').each(function () {
            ItsOnoff.SetInitObj($(this));
        });
        $('#' + panelId).find('.ItsTextArea').each(function () {
            ItsTextArea.SetInitObj($(this));
        });
        $('#' + panelId).find('div.ItsRadio_table').each(function () {
            ItsRadio.SetInitObj($(this));
        });
        $('#' + panelId).find('.ItsCheck_button').each(function () {
            ItsCheck.SetInitObj($(this));
        });
        $('#' + panelId).find('.ItsMonth').each(function () {
            ItsMonth.SetInitObj($(this));
        });
        $('#' + panelId).find('.ItsImage').each(function () {
            ItsImage.SetInitObj($(this));
        });
        $('#' + panelId).find('.ItsFileManager').each(function () {
            ItsFileManager.SetInitObj($(this));
        });
    },
    ResetData: function (panelId) {
        $('#' + panelId).find('.ItsText').each(function () {
            $(this).val('');
        });
        $('#' + panelId).find('.ItsNum').each(function () {
            $(this).val(null);
            ItsNum.ValueView($(this));
        });
        $('#' + panelId).find('.ItsCombo').each(function () {
            $(this).val(null);
        });
        $('#' + panelId).find('.ItsDate').each(function () {
            ItsDate.SetInitObj($(this));
        });
        $('#' + panelId).find('.ItsDateRange').each(function () {
            ItsDateRange.SetInitObjFrom($(this));
            ItsDateRange.SetInitObjTo($(this));
        });
        $('#' + panelId).find('.ItsFind').each(function () {
            $(this).val(null);
            $(this).siblings('span').text(null);
        });
        $('#' + panelId).find('.ItsDisplay').each(function () {
            $(this).text(null);
        });
        $('#' + panelId).find('.ItsOnoff_button').each(function () {
            ItsOnoff.SetInitObj($(this));
        });
        $('#' + panelId).find('.ItsTextArea').each(function () {
            $(this).val(null);
        });
        $('#' + panelId).find('div.ItsRadio_table').each(function () {
            $(this).children('input:checked').prop('checked', false);
        });
        $('#' + panelId).find('.ItsCheck_button').each(function () {
            ItsCheck.SetInitObj($(this));
        });
        $('#' + panelId).find('.ItsMonth').each(function () {
            ItsMonth.SetInitObj($(this));
        });
        $('#' + panelId).find('.ItsImage').each(function () {
            ItsImage.SetInitObj($(this));
        });
        $('#' + panelId).find('.ItsFileManager').each(function () {
            ItsFileManager.SetInitObj($(this));
        });
    },
    Disable: function (panelId) {
        $('#' + panelId).find('input.ItsText').each(function () {
            ItsText.DisableObj($(this));
        });
        $('#' + panelId).find('input.ItsNum').each(function () {
            ItsNum.DisableObj($(this));
        });
        $('#' + panelId).find('input.ItsCombo').each(function () {
            ItsCombo.DisableObj($(this));
        });
        $('#' + panelId).find('input.ItsDate').each(function () {
            ItsDate.DisableObj($(this));
        });
        $('#' + panelId).find('.ItsDateRange_F').each(function () {
            ItsDateRange.DisableObj($(this));
        });
        $('#' + panelId).find('input.ItsFind').each(function () {
            ItsFind.DisableObj($(this));
        });
        $('#' + panelId).find('.ItsOnoff_button').each(function () {
            ItsOnoff.DisableObj($(this));
        });
        $('#' + panelId).find('textarea.ItsTextArea').each(function () {
            ItsTextArea.DisableObj($(this));                    
        });
        $('#' + panelId).find('div.ItsRadio_table').each(function () {
            ItsRadio.DisableObj($(this));
        });
        $('#' + panelId).find('.ItsCheck_button').each(function () {
            ItsCheck.DisableObj($(this));
        });
        $('#' + panelId).find('input.ItsMonth').each(function () {
            ItsMonth.DisableObj($(this));
        });
        $('#' + panelId).find('.ItsButton').each(function () {
            ItsButton.DisableObj($(this));
        });
    },
    Enable: function (panelId) {
        $('#' + panelId).find('input.ItsText').each(function () {
            ItsText.EnableObj($(this));
        });
        $('#' + panelId).find('input.ItsNum').each(function () {
            ItsNum.EnableObj($(this));
        });
        $('#' + panelId).find('input.ItsCombo').each(function () {
            ItsCombo.EnableObj($(this));
        });
        $('#' + panelId).find('input.ItsDate').each(function () {
            ItsDate.EnableObj($(this));
        });
        $('#' + panelId).find('.ItsDateRange_F').each(function () {
            ItsDateRange.EnableObj($(this));
        });
        $('#' + panelId).find('input.ItsFind').each(function () {
            ItsFind.EnableObj($(this));
        });
        $('#' + panelId).find('.ItsOnoff_button').each(function () {
            ItsOnoff.EnableObj($(this));
        });
        $('#' + panelId).find('textarea.ItsTextArea').each(function () {
            ItsTextArea.EnableObj($(this));
        });
        $('#' + panelId).find('div.ItsRadio_table').each(function () {
            ItsRadio.EnableObj($(this));
        });
        $('#' + panelId).find('.ItsCheck_button').each(function () {
            ItsCheck.EnableObj($(this));
        });
        $('#' + panelId).find('input.ItsMonth').each(function () {
            ItsMonth.EnableObj($(this));
        });
        $('#' + panelId).find('.ItsButton').each(function () {
            ItsButton.EnableObj($(this));
        });
    },
    SetBackColor: function (panelId, color) {
        var $panel = $('div#' + panelId);
        $panel.css('background-color', color);
    },
    Hide: function (panelId) {
        var $panel = $('div#' + panelId);
        $panel.css('display', 'none');
        if ($panel.attr('class').indexOf('Split') > -1) {
            $(window).resize();
        }
    },
    Show: function (panelId) {
        var $panel = $('div#' + panelId);
        var $cls = $('div#' + panelId).attr('class');
        if($cls.indexOf('Block')> -1) {
            $panel.css('display', 'block');
        } else if ($cls.indexOf('Float') > -1) {
            $panel.css('display', 'inline-block');
        } else if ($cls.indexOf('Split') > -1) {
            $panel.css('display', 'block');
        } else if ($cls.indexOf('SearchPanel') > -1) {
            $panel.css('display', 'block');
        }
        if ($panel.attr('class').indexOf('Split') > -1) {
            $(window).resize();
        }		
    },
    _AddTextTag: '',
    /**
     * @param {String} divId
     * @param {_AddTagParams} params
     */
    AddTextTag: function (divId, params) {
        var div = $('#' + divId);
        var $params = new _AddTagParams();
        ItsHelper.CopyObj(params, $params);
        if (ItsHelper.toString($params.id) == '') {
            ItsMsg.Alert('AddTextTag must have id');
            return;
        }
        var result = ItsPage._AddTextTag;
        if (result == '') {
            $.ajax({
                async: false,
                url: '../../Service/Control/GetTag.aspx',
                type: 'post',
                dataType: 'text',
                data: {
                    TYPE: 'TEXT'
                },
                success: function (data, staus) {
                    result = data.toString();
                    ItsPage._AddTextTag = result;
                },
                error: function (xhr, status, error) {
                    result = 'ERROR:' + status + ': ' + error;
                }
            });
        };

        result = result.replace('>Label</span>', '>' + $params.label + '</span>');
        result = result.replace('data-field="Field"', 'data-field="' + $params.field + '"');
        result = result.replace('id="TEXT_ID"', 'id="' + $params.id + '"');

        if (result.substring(0, 6) == 'ERROR:') {
            ItsMsg.Alert(result);
            return;
        }
        div.append(result);

        var $input = $('#' + $params.id);
        if ($input.length == 1) {
            ItsText._Reset($input);
        } else {
            ItsMsg.Alert('AddTextTag duplicate id => ' + $params.id);
            return;
        }
    },
    _AddNumTag: '',
    /**
     * @param {String} divId
     * @param {_AddTagParams} params
     */
    AddNumTag: function (divId, params) {
        var div = $('#' + divId);
        var $params = new _AddTagParams();
        ItsHelper.CopyObj(params, $params);
        if (ItsHelper.toString($params.id) == '') {
            ItsMsg.Alert('AddNumTag must have id');
            return;
        }
        var result = ItsPage._AddNumTag;
        if (result == '') {
            $.ajax({
                async: false,
                url: '../../Service/Control/GetTag.aspx',
                type: 'post',
                dataType: 'text',
                data: {
                    TYPE: 'NUM'
                },
                success: function (data, staus) {
                    result = data.toString();
                    ItsPage._AddNumTag = result;
                },
                error: function (xhr, status, error) {
                    result = 'ERROR:' + status + ': ' + error;
                }
            });
        }
        result = result.replace('>Label</span>', '>' + $params.label + '</span>');
        result = result.replace('data-field="Field"', 'data-field="' + $params.field + '"');
        result = result.replace('id="NUM_ID"', 'id="' + $params.id + '"');
        
        if (result.substring(0, 6) == 'ERROR:') {
            ItsMsg.Alert(result);
            return;
        }
        div.append(result);

        var $input = $('#' + $params.id);
        if ($input.length == 1) {
            ItsNum._Reset($input);
        } else {
            ItsMsg.Alert('AddNumTag duplicate id => ' + $params.id);
            return;
        }
    },
    _AddFindTag: '',
    /**
     * @param {String} divId
     * @param {_AddTagParams} params
     */
    AddFindTag: function (divId, params) {
        var div = $('#' + divId);
        var $params = new _AddTagParams();
        ItsHelper.CopyObj(params, $params);
        if (ItsHelper.toString($params.id) == '') {
            ItsMsg.Alert('ERROR: AddFindTag must have id');
            return;
        }
        var result = '';
        var result = ItsPage._AddFindTag;
        if (result == '') {
            $.ajax({
                async: false,
                url: '../../Service/Control/GetTag.aspx',
                type: 'post',
                dataType: 'text',
                data: {
                    TYPE: 'FIND'
                },
                success: function (data, staus) {
                    result = data.toString();
                    ItsPage._AddFindTag = result;
                },
                error: function (xhr, status, error) {
                    result = 'ERROR:' + status + ': ' + error;
                }
            });
        }

        result = result.replace('>Label</span>', '>' + $params.label + '</span>');
        result = result.replace('data-field="Field"', 'data-field="' + $params.field + '"');
        result = result.replace('id="FIND_ID"', 'id="' + $params.id + '"');
        result = result.replace('data-gpcd="GPCD"', 'data-gpcd="' + $params.gpcd + '"');
        result = result.replace('data-ref01="REF01"', 'data-ref01="' + $params.ref01 + '"');
        result = result.replace('data-ref02="REF02"', 'data-ref02="' + $params.ref02 + '"');
        result = result.replace('data-ref03="REF03"', 'data-ref03="' + $params.ref03 + '"');
        result = result.replace('data-ref04="REF04"', 'data-ref04="' + $params.ref04 + '"');
        result = result.replace('data-ref05="REF05"', 'data-ref05="' + $params.ref05 + '"');

        var FindHeadInfo = "";
        $.ajax({
            async: false,
            url: '../../Service/Control/GetTag.aspx',
            type: 'post',
            dataType: 'text',
            data: {
                TYPE: 'FIND_HEAD',
                GPCD: $params.gpcd
            },
            success: function (data, staus) {
                FindHeadInfo = data.toString();
            },
            error: function (xhr, status, error) {
                FindHeadInfo = 'ERROR:' + status + ': ' + error;
            }
        });

        try {
            result = result.replace('data-field="_GridField_"', 'data-field="' + FindHeadInfo.split('_GridField')[1] + '"');
            result = result.replace('data-title="_GridTitle_"', 'data-title="' + FindHeadInfo.split('_GridTitle_')[1] + '"');
            result = result.replace('data-width="_GridWidth_"', 'data-width="' + FindHeadInfo.split('_GridWidth_')[1] + '"');
            result = result.replace('data-length="_GridLength_"', 'data-length="' + FindHeadInfo.split('_GridLength_')[1] + '"');
            result = result.replace('_TAG_HEAD_', FindHeadInfo.split('_HEAD_TAG_')[1]);
        } 
        catch(e)
        {
            ItsMsg.Alert('ERROR: Not found ItsFind HeadTag');
            return;
        }

        if (result.substring(0, 6) == 'ERROR:') {
            ItsMsg.Alert(result);
            return;
        }
        div.append(result);

        var $input = $('#' + $params.id);
        if ($input.length == 1) {
            ItsFind._Reset($input);
        } else {
            ItsMsg.Alert('AddFindTag duplicate id => ' + $params.id);
            return;
        }
    },
    _AddComboTag: '',
    /**
     * @param {String} divId
     * @param {_AddTagParams} params
     */
    AddComboTag: function (divId, params) {
        var div = $('#' + divId);
        var $params = new _AddTagParams();
        ItsHelper.CopyObj(params, $params);
        if (ItsHelper.toString($params.id) == '') {
            ItsMsg.Alert('AddComboTag must have id');
            return;
        }
        var result = '';
        var result = ItsPage._AddComboTag;
        if (result == '') {
            $.ajax({
                async: false,
                url: '../../Service/Control/GetTag.aspx',
                type: 'post',
                dataType: 'text',
                data: {
                    TYPE: 'COMBO'
                },
                success: function (data, staus) {
                    result = data.toString();
                    ItsPage._AddComboTag = result;
                },
                error: function (xhr, status, error) {
                    result = 'ERROR:' + status + ': ' + error;
                }
            });
        }

        result = result.replace('>Label</span>', '>' + $params.label + '</span>');
        result = result.replace('data-field="Field"', 'data-field="' + $params.field + '"');
        result = result.replace('id="COMBO_ID"', 'id="' + $params.id + '"');
        result = result.replace('data-gpcd="GPCD"', 'data-gpcd="' + $params.gpcd + '"');
        result = result.replace('data-ref01="REF01"', 'data-ref01="' + $params.ref01 + '"');
        result = result.replace('data-ref02="REF02"', 'data-ref02="' + $params.ref02 + '"');
        result = result.replace('data-ref03="REF03"', 'data-ref03="' + $params.ref03 + '"');
        result = result.replace('data-ref04="REF04"', 'data-ref04="' + $params.ref04 + '"');
        result = result.replace('data-ref05="REF05"', 'data-ref05="' + $params.ref05 + '"');

        if (result.substring(0, 6) == 'ERROR:') {
            ItsMsg.Alert(result);
            return;
        }
        div.append(result);

        var $input = $('#' + $params.id);
        if ($input.length == 1) {
            ItsCombo._Reset($input);
        } else {
            ItsMsg.Alert('AddComboTag duplicate id => ' + $params.id);
            return;
        }
    },
    _AddDateTag: '',
    /**
     * @param {String} divId
     * @param {_AddTagParams} params
     */
    AddDateTag: function (divId, params) {
        var div = $('#' + divId);
        var $params = new _AddTagParams();
        ItsHelper.CopyObj(params, $params);
        if (ItsHelper.toString($params.id) == '') {
            ItsMsg.Alert('AddDateTag must have id');
            return;
        }
        var result = '';
        var result = ItsPage._AddDateTag;
        if (result == '') {
            $.ajax({
                async: false,
                url: '../../Service/Control/GetTag.aspx',
                type: 'post',
                dataType: 'text',
                data: {
                    TYPE: 'DATE'
                },
                success: function (data, staus) {
                    result = data.toString();
                    ItsPage._AddDateTag = result;
                },
                error: function (xhr, status, error) {
                    result = 'ERROR:' + status + ': ' + error;
                }
            });
        }

        result = result.replace('>Label</span>', '>' + $params.label + '</span>');
        result = result.replace('data-field="Field"', 'data-field="' + $params.field + '"');
        result = result.replace('id="DATE_ID"', 'id="' + $params.id + '"');

        if (result.substring(0, 6) == 'ERROR:') {
            ItsMsg.Alert(result);
            return;
        }
        div.append(result);

        var $input = $('#' + $params.id);
        if ($input.length == 1) {
            ItsDate._Reset($input);
        } else {
            ItsMsg.Alert('AddDateTag duplicate id => ' + $params.id);
            return;
        }
    },
    _AddOnoffTag: '',
    /**
     * @param {String} divId
     * @param {_AddTagParams} params
     */
    AddOnoffTag: function (divId, params) {
        var div = $('#' + divId);
        var $params = new _AddTagParams();
        ItsHelper.CopyObj(params, $params);
        if (ItsHelper.toString($params.id) == '') {
            ItsMsg.Alert('AddOnoffTag must have id');
            return;
        }
        var result = '';
        var result = ItsPage._AddOnoffTag;
        if (result == '') {
            $.ajax({
                async: false,
                url: '../../Service/Control/GetTag.aspx',
                type: 'post',
                dataType: 'text',
                data: {
                    TYPE: 'ONOFF'
                },
                success: function (data, staus) {
                    result = data.toString();
                    ItsPage._AddOnoffTag = result;
                },
                error: function (xhr, status, error) {
                    result = 'ERROR:' + status + ': ' + error;
                }
            });
        }

        result = result.replace('>Label</span>', '>' + $params.label + '</span>');
        result = result.replace('data-field="Field"', 'data-field="' + $params.field + '"');
        result = result.replace('id="ONOFF_ID"', 'id="' + $params.id + '"');

        if (result.substring(0, 6) == 'ERROR:') {
            ItsMsg.Alert(result);
            return;
        }
        div.append(result);

        var $input = $('#' + $params.id);
        if ($input.length == 1) {
            ItsOnoff._Reset($input);
        } else {
            ItsMsg.Alert('AddOnoffTag duplicate id => ' + $params.id);
            return;
        }
    },
    _AddButtonTag: '',
    /**
     * @param {String} divId
     * @param {_AddTagParams} params
     */
    AddButtonTag: function (divId, params) {
        var div = $('#' + divId);
        var $params = new _AddTagParams();
        ItsHelper.CopyObj(params, $params);
        if (ItsHelper.toString($params.id) == '') {
            ItsMsg.Alert('AddButtonTag must have id');
            return;
        }
        var result = '';
        var result = ItsPage._AddButtonTag;
        if (result == '') {
            $.ajax({
                async: false,
                url: '../../Service/Control/GetTag.aspx',
                type: 'post',
                dataType: 'text',
                data: {
                    TYPE: 'BUTTON'
                },
                success: function (data, staus) {
                    result = data.toString();
                    ItsPage._AddButtonTag = result;
                },
                error: function (xhr, status, error) {
                    result = 'ERROR:' + status + ': ' + error;
                }
            });
        }

        result = result.replace('>Label</span>', '>' + $params.label + '</span>');
        result = result.replace('data-field="Field"', 'data-field="' + $params.field + '"');
        result = result.replace('id="BUTTON_ID"', 'id="' + $params.id + '"');

        if (result.substring(0, 6) == 'ERROR:') {
            ItsMsg.Alert(result);
            return;
        }
        div.append(result);

        var $input = $('#' + $params.id).find('.ItsButton_table');
        if ($params.class != undefined) {
            $input.addClass($params.class);
        }
        if ($input.length == 1) {
            ItsButton._Reset($input);
        } else {
            ItsMsg.Alert('AddButtonTag duplicate id => ' + $params.id);
            return;
        }
    }
};
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
        try {
            num = num.replace(/[^0-9.-]/g, "");
            var rtnNum = parseFloat(num);
            if (rtnNum == null || rtnNum == undefined || isNaN(rtnNum)) rtnNum = 0;
            return rtnNum;
        } catch (e) {
            return rtnNum;
        }

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
        if (bool == true || bool == 'Y') {
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
    AddMonth: function (month, baseDate, format) {
        if (month == undefined) {
            return new Date().format('yyyy-MM-dd');
        }
        var $date = baseDate;
        if ($date == undefined || $date == '' || $date == null) {
            $date = new Date();
        }
        try {
            $date = new Date($date);
        } catch (e) {
            $date = new Date();
        }
        // month달 후의 1일
        var addMonthFirstDate = new Date($date.getFullYear(), $date.getMonth() + month, 1);
  
        // month달 후의 말일
        var addMonthLastDate = new Date(addMonthFirstDate.getFullYear(), addMonthFirstDate.getMonth() + 1, 0);
  
        var result = addMonthFirstDate;
        if ($date.getDate() > addMonthLastDate.getDate())
        {
            result.setDate(addMonthLastDate.getDate());
        } 
        else 
        {
            result.setDate($date.getDate());
        }
        if (format == undefined) {
            format = 'yyyy-MM-dd';
        }
        return result.format(format);
    },
    /**
     * @param {Number} day
     */
    AddDay: function (day, baseDate, format) {
        var $date = baseDate;
        if ($date == undefined || $date == '' || $date == null) {
            $date = new Date();
        }
        try {
            $date = new Date($date);
        } catch (e) {
            $date = new Date();
        }
        if (format == undefined) {
            format = 'yyyy-MM-dd';
        }
        if (day == undefined || day == '' || day == null) {
            return $date.format(format);
        }

        $date.setDate($date.getDate() + day);
        return $date.format(format);
    },
    AddHour: function (hour, baseDate, format) {
        var $date = baseDate;
        if ($date == undefined || $date == '' || $date == null) {
            $date = new Date();
        }
        try {
            $date = new Date($date);
        } catch (e) {
            $date = new Date();
        }
        if (format == undefined) {
            format = 'yyyy-MM-dd HH:mm:ss';
        }
        if (hour == undefined || hour == '' || hour == null) {
            return $date.format(format);
        }

        $date.setHours($date.getHours() + hour);
        return $date.format(format);
    },
    AddMinutes: function (minutes, baseDate, format) {
        var $date = baseDate;
        if ($date == undefined || $date == '' || $date == null) {
            $date = new Date();
        }
        try {
            $date = new Date($date);
        } catch (e) {
            $date = new Date();
        }
        if (format == undefined) {
            format = 'yyyy-MM-dd HH:mm:ss';
        }
        if (minutes == undefined || minutes == '' || minutes == null) {
            return $date.format(format);
        }

        $date.setMinutes($date.getMinutes() + minutes);
        return $date.format(format);
    },
    AddSeconds: function (seconds, baseDate, format) {
        var $date = baseDate;
        if ($date == undefined || $date == '' || $date == null) {
            $date = new Date();
        }
        try {
            $date = new Date($date);
        } catch (e) {
            $date = new Date();
        }
        if (format == undefined) {
            format = 'yyyy-MM-dd HH:mm:ss';
        }
        if (seconds == undefined || seconds == '' || seconds == null) {
            return $date.format(format);
        }

        $date.setSeconds($date.getSeconds() + seconds);
        return $date.format(format);
    },
    GetDateFull: function (date) {
        if (date == undefined || date == '' || date == null) {
            return new Date().format('yyyy-MM-dd HH:mm:ss');
        } else {
            return new Date(date).format('yyyy-MM-dd HH:mm:ss');
        }
    },
    GetYearMonth: function(date) {
        if (date == undefined || date == '' || date == null) {
            return new Date().format('yyyy-MM');
        } else {
            return new Date(date).format('yyyy-MM');
        }
    },
    GetYearMonthDay: function (date) {
        if (date == undefined || date == '' || date == null) {
            return new Date().format('yyyy-MM-dd');
        } else {
            return new Date(date).format('yyyy-MM-dd');
        }
    },
    GetHourMinute: function (date) {
        if (date == undefined || date == '' || date == null) {
            return new Date().format('HH:mm');
        } else {
            return new Date(date).format('HH:mm:ss');
        }
    },
    GetHourMinuteSecond: function (date) {
        if (date == undefined || date == '' || date == null) {
            return new Date().format('HH:mm:ss');
        } else {
            return new Date(date).format('HH:mm:ss');
        }
    },
    CopyFile: function (filePath) {
        var $filename = '';
        if (filePath != '') {
            try {
                //filePath = filePath.replace(/\//gi, '\\'); // 'UploadFiles' + filePath.split('UploadFiles')[1].replace(/\//gi, '\\');


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
                        if ($pathText.length > 2 && $pathText != '') {
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
            catch (exception) {}
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
                var $resText = data.split('»');
                var TITLE = $resText[0].substring(6);
                var TOID = $resText[1].substring(5);
                var SENDYN = $resText[2].substring(7, 8);

                var maria = new ItsMaria('MAIL_SERVICE', 'LOG_MAIL');
                maria.AddSessionUserId();
                maria.AddParam('SUBJECT', TITLE);
                maria.AddParam('SENDADDR', TOID);
                maria.AddParam('SENDYN', SENDYN);
                maria.CallProcCenter();
                if (maria.isError) {
                    maria.ShowErrMsg();
                    return $returnval;
                }

                if (SENDYN == 'Y') {
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
    },
    
    FloatFormat: function (val, d) {
        //if ((val * parseFloat(Math.pow(0.1, -d).toFixed(d))) % 1 > 0) {
            
        //}
        try {
            if (val % 1 == 0) {
                val = Math.floor(val * parseFloat(Math.pow(0.1, -d).toFixed(d))) * parseFloat(Math.pow(0.1, d).toFixed(d));
            } else {
                val = val.toString();
                val = parseFloat(val.substr(0, val.indexOf('.') + 1 + d));

            }
            if (isNaN(val)) val = 0;
            return val;
        } catch (e) {
            return 0;
        }       
    },
    NumberComma: function (num) {
        var res = '';
        num = num.toString();
        if (num.indexOf('.') > -1) {
            res = num.split('.')[0].replace(/\B(?=(\d{3})+(?!\d))/g, ",") + '.' + num.split('.')[1];
        } else {
            res = num.replace(/\B(?=(\d{3})+(?!\d))/g, ",");
        }
        return res;
    },
    NumberUncomma: function (num) {
        return num.toString().replace(/[^\d]+/g, '');
    },
    NumberDecimal: function (num, decimal) {
        var floatList = num.toString().split('.');
        var decimal = parseInt(decimal);
        var strNum = '0';

        if (decimal > 0) {
            var decimalNum = "";
            if (floatList.length > 1) {
                decimalNum = floatList[1].substr(0, decimal).padEnd(decimal, '0');
            }
            else {
                decimalNum = decimalNum.padEnd(decimal, '0');
            }

            strNum = floatList[0] + '.' + decimalNum;
        }
        else {
            strNum = floatList[0];
        }

        return parseFloat(strNum);
    }

};
/********************************************
 * >>>>> JavaScript 내장 문자열 객체 override 함수 추가 >>>>>
 * 2017-10-01: 김동학: 최초 작성
 *******************************************/
String.prototype.AddZero = function (length) {
    var rtnStr = ItsHelper.RepeatStr("0", length) + this;
    return rtnStr.substring(rtnStr.length - length);
};
String.prototype.AddSpace = function (length) {
    var rtnStr = ItsHelper.RepeatStr(" ", length) + this;
    return rtnStr.substring(rtnStr.length - length);
};
String.prototype.AddStr = function (length, str) {
    var rtnStr = ItsHelper.RepeatStr(str, length) + this;
    return rtnStr.substring(rtnStr.length - length);
};
String.prototype.Concat = function (strList) {
    return this.ConcatStr("", strList);
};
String.prototype.ConcatStr = function (sep, strList) {
    var rtnStr = this;
    if (rtnStr != "") rtnStr += sep;
    return rtnStr + ItsHelper.ConcatStr(sep, strList);
};

/********************************************
 * >>>>> StringBuillder: 문자 배열화 처리 >>>>>
 * 2017-10-01: 김동학: 최초 작성
 *******************************************/
var StringBuilder = function () {
    this.strList = [];
};
StringBuilder.prototype.Append = function (str) {
    this.strList.push(str);
};
StringBuilder.prototype.AppendLine = function (str) {
    if (this.strList.length == 0) {
        this.strli.push(str);
    } else {
        this.strList.push("\n" + str);
    }
};
StringBuilder.prototype.Clear = function () {
    this.strli.push = [];
};
StringBuilder.prototype.ToString = function () {
    return this.strList.join("");
};
Date.prototype.format = function (f) {
    if (!this.valueOf()) return " ";
    var weekKorName = ["일요일", "월요일", "화요일", "수요일", "목요일", "금요일", "토요일"];
    var weekKorShortName = ["일", "월", "화", "수", "목", "금", "토"];
    var weekEngName = ["Sunday", "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday"];
    var weekEngShortName = ["Sun", "Mon", "Tue", "Wed", "Thu", "Fri", "Sat"];
    var d = this;
    return f.replace(/(yyyy|yy|MM|dd|KS|KL|ES|EL|HH|hh|mm|ss|a\/p)/gi, function ($1) {
        switch ($1) {
            case "yyyy": return d.getFullYear(); // 년 (4자리)
            case "yy": return (d.getFullYear() % 1000).zf(2); // 년 (2자리)
            case "MM": return (d.getMonth() + 1).zf(2); // 월 (2자리)
            case "dd": return d.getDate().zf(2); // 일 (2자리)
            case "KS": return weekKorShortName[d.getDay()]; // 요일 (짧은 한글)
            case "KL": return weekKorName[d.getDay()]; // 요일 (긴 한글)
            case "ES": return weekEngShortName[d.getDay()]; // 요일 (짧은 영어)
            case "EL": return weekEngName[d.getDay()]; // 요일 (긴 영어)
            case "HH": return d.getHours().zf(2); // 시간 (24시간 기준, 2자리)
            case "hh": return ((h = d.getHours() % 12) ? h : 12).zf(2); // 시간 (12시간 기준, 2자리)
            case "mm": return d.getMinutes().zf(2); // 분 (2자리)
            case "ss": return d.getSeconds().zf(2); // 초 (2자리)
            case "a/p": return d.getHours() < 12 ? "오전" : "오후"; // 오전/오후 구분
            default: return $1;
        }
    });
};
String.prototype.string = function (len) { var s = '', i = 0; while (i++ < len) { s += this; } return s; };
String.prototype.zf = function (len) { return "0".string(len - this.length) + this; };
Number.prototype.zf = function (len) { return this.toString().zf(len); };
Array.prototype.filterObjects = function (key, value) {
    return this.filter(function (x) { return x[key] === value; })
}
/********************************************
 * >>>>> store: 데이터 저장소 >>>>>
 * 2017-10-01: 김동학: 최초 작성
 * 
 *******************************************/
var Store = function (storeName, data) {
    this.storeName = storeName;
    if (data != undefined) {
        this.data = data;
    } else {
        this.data = [];
    }
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
/**********************************************
 * store: 스토어 내부 함수
 **********************************************/
Store.$showDebug = function (storeName) {
    alert("DEBUG: " + storeName + "가 비어 있습니다.");
    return "";
};
/**********************************************
 * store: 스토어 내부 함수
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
function SET_COOKIE(cookieName, cookieValue) {
    if (cookieName == 'TMLUID' && GET_COOKIE('TMLUID') != '') return;
    var cookieText = escape(cookieName) + '=' + escape(cookieValue);
    cookieText += ';path=/;EXPIRES=' + (new Date(2999, 12, 31)).toGMTString() + ';';
    document.cookie = cookieText;
}
/**************************************************
 * Enums: 열거형 변수
 **************************************************/
var EnumKeys = {
    Esc: 27,
    Enter: 13,
    Left: 37,
    Top: 38,
    Right: 39,
    Down: 40,
    Tab: 9,
    BackSpace: 8,
    Space: 32
}
var enumAut = {
    search: 'autSearch',
    save: 'autSave',
    delete: 'autDelete',
    add: 'autAdd',
    print: 'autPrint',
    fax: 'autFax',
    export: 'autExport'
};
var enumSelectMode = {
    row: 'Row',
    cell: 'CellRange',
    MultiRange: 'MultiRange'
};
var enumGrouping = {
    none:'None',        //No aggregate.
    sum:'Sum',          //Returns the sum of the numeric values in the group.
    cnt:'Cnt',          //Returns the count of non-null values in the group.
    avg:'Avg',          //Returns the average value of the numeric values in the group.
    max:'Max',          //Returns the maximum value in the group.
    min:'Min',          //Returns the minimum value in the group.
    rng:'Rng',          //Returns the difference between the maximum and minimum numeric values in the group.
    std:'Std',          //Returns the sample standard deviation of the numeric values in the group (uses the formula based on n-1).
    vaR:'Var',          //Returns the sample variance of the numeric values in the group (uses the formula based on n-1).
    stdPop:'StdPop',    //Returns the population standard deviation of the values in the group (uses the formula based on n).
    varPop:'VarPop',    //Returns the population variance of the values in the group (uses the formula based on n).
    cntAll:'CntAll',    //Returns the count of all values in the group (including nulls).
    first:'Frist',      //Returns the first non-null value in the group.
    last:'Last'         //Returns the last non-null value in the group.
}
var enumColumnTypes = {
    text: 'textfield',
    number: 'numberfield',
    date: 'datefield',
    check: 'checkbox',
    button: 'button',
    combo: 'combo',
    find: 'find',
    finditem: 'finditem'
};
var enumPosition = {
    left: 'left',
    right: 'right',
    top: 'top',
    bottom: 'bottom',
    center: 'center'
};
var enumColor = {
    transparent: 'transparent',
    theme: '#7691d9',
    black: 'black',
    white: 'white',
    grayDark2: 'dimGray',
    grayDark1: 'gray',
    gray: 'silver',
    grayLight1: 'lightGray',
    grayLight2: 'whiteSmoke',
    redDark2: 'darkRed',
    redDark1: 'indianRed',
    red: 'red',
    redLight1: 'pink',
    redLight2: 'lavenderBlush',
    blueDark2: 'navy',
    blueDark1: 'steelBlue',
    blue: 'blue',
    blueLight1: 'lightSteelBlue',
    blueLight2: 'aliceBlue',
    greenDark2: 'darkGreen',
    greenDark1: 'seaGreen',
    green: 'green',
    greenLight1: 'greenYellow',
    greenLight2: 'mintCream',
    yellowDark2: 'darkGoldenRod',
    yellowDark1: 'orange',
    yellow: 'gold',
    yellowLight1: 'yellow',
    yellowLight2: 'lightYellow',
    purpleDark2: 'purple',
    purpleDark1: 'darkViolet',
    purple: 'blueViolet',
    purpleLight1: 'mediumPurple',
    purpleLight2: 'thistle',
    purpleLight3: '#F4E8F4',
    orangeDark1: '#ffc192',
    orangeLight1: '#fff1d1',

    searchButton: '#b490f5',
    addButton: '#18d2ba',
    saveButton: '#7691d9',
    deleteButton: '#f45b93',
    resetButton: '#31c0e1',
    searchButtonIcon: 'searchButtonIcon',
    addButtonIcon: 'addButtonIcon',
    saveButtonIcon: 'saveButtonIcon',
    deleteButtonIcon: 'deleteButtonIcon',
    resetButtonIcon: 'resetButtonIcon',

    addPanel: 'linen',
    textHighlightBack: 'mintCream',
    numHighlightBack: 'lightYellow',
    customButton: '#74D178',
    customButton2: '#4774B9',
    customButton3: '#F34F4F',

    gridBackColorYellow: '#FFF8E6',
    gridBackColorRed: '#FFF1F1',
    gridBackColorGreen: '#F3FCF6',
};
// 지정 이름으로 공식명칭 찾기 위함, 사용은 하지말것
enumColor.$reverseColorName = {
    transparent: 'transparent',
    theme: 'theme',
    black: 'black',
    white: 'white',
    dimGray: 'grayDark2',
    gray: 'grayDark1',
    silver: 'gray',
    lightGray: 'grayLight1',
    whiteSmoke: 'grayLight2',
    darkRed: 'redDark2',
    indianRed: 'redDark1',
    red: 'red',
    redLight1: 'pink',
    lavenderBlush: 'redLight2',
    navy: 'blueDark2',
    steelBlue: 'blueDark1',
    blue: 'blue',
    lightSteelBlue: 'blueLight1',
    aliceBlue: 'blueLight2',
    darkGreen: 'greenDark2',
    seaGreen: 'greenDark1',
    green: 'green',
    greenYellow: 'greenLight1',
    mintCream: 'greenLight2',
    darkGoldenRod: 'yellowDark2',
    orange: 'yellowDark1',
    gold: 'yellow',
    yellow: 'yellowLight1',
    lightYellow: 'yellowLight2',
    purple: 'purpleDark2',
    darkViolet: 'purpleDark1',
    blueViolet: 'purple',
    mediumPurple: 'purpleLight1',
    thistle: 'purpleLight2'
};

function fn_pw_check(pw, newpw) {
    if (pw == '') {
        alert('현재 패스워드를 입력해주세요.');
        return false;
    }

    var pw_passed = true;

    var pattern1 = /[0-9]/;
    var pattern2 = /[a-zA-Z]/;
    var pattern3 = /[~,!,@,#,$,%,^,&,*,(,),<,>,\[,\],\\,?]/;     // 원하는 특수문자 추가 제거
    var pw_msg = "";

    if (pw == '') {
        alert('변경할 패스워드를 입력하십시오.');
        return false;
    }

    if (!pattern1.test(pw) || !pattern2.test(pw) || !pattern3.test(pw) || pw.length < 8 || pw.length > 50) {
        alert("영문+숫자+특수문자 8자리 이상으로 구성하여야 합니다.\n사용가능 특수문자 종류 : ~ ! @ # $ % ^ & * ( ) < > [ ] \ ?");
        return false;
    }

    if (newpw == '') {
        alert('재확인 패스워드를 입력하십시오.');
        return false;
    }

    if (newpw != pw) {
        alert('재확인 패스워드가 변경할 패스워드와 다릅니다.');
        return false;
    }

    var SamePass_0 = 0; //동일문자 카운트
    var SamePass_1 = 0; //연속성(+) 카운드
    var SamePass_2 = 0; //연속성(-) 카운드

    for (var i = 0; i < pw.length; i++) {
        var chr_pass_0;
        var chr_pass_1;
        var chr_pass_2;

        if (i >= 2) {
            chr_pass_0 = pw.charCodeAt(i - 2);
            chr_pass_1 = pw.charCodeAt(i - 1);
            chr_pass_2 = pw.charCodeAt(i);

            //동일문자 카운트
            if ((chr_pass_0 == chr_pass_1) && (chr_pass_1 == chr_pass_2)) {
                SamePass_0++;
            }
            else {
                SamePass_0 = 0;
            }

            //연속성(+) 카운드
            if (chr_pass_0 - chr_pass_1 == 1 && chr_pass_1 - chr_pass_2 == 1) {
                SamePass_1++;
            }
            else {
                SamePass_1 = 0;
            }

            //연속성(-) 카운드
            if (chr_pass_0 - chr_pass_1 == -1 && chr_pass_1 - chr_pass_2 == -1) {
                SamePass_2++;
            }
            else {
                SamePass_2 = 0;
            }
        }
        if (SamePass_0 > 0) {
            alert("동일문자를 3자 이상 연속 입력할 수 없습니다.");
            pw_passed = false;
        }
        if (SamePass_1 > 0 || SamePass_2 > 0) {
            alert("영문, 숫자는 3자 이상 연속 입력할 수 없습니다.");

            pw_passed = false;
        }
        if (!pw_passed) {
            return false;
            break;
        }
    }
    return true;

}
