<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ITEMCD.aspx.cs" Inherits="ITEMCD" %>
<script src="../../Script/include.js"></script>
<style>
    html{
        overflow-x:hidden;
        overflow-y:hidden;
    }
    body{
        overflow-x:hidden;
        overflow-y:hidden;
        white-space:nowrap;
        border-top: 0px;
    }
    div.SplitLeft {
        overflow:hidden;
    }
    div.SplitRight {
        overflow:hidden;
    }
</style>
<script>
    var Reset = function () {
        var params = parent.window.ItsPop._paramsITEMCD;
        if (params.KEYWORD == '' || params.KEYWORD == undefined) {
            if (ItsGrid.Length('findPop_ITEMCD_grid1') > 0) {
                ItsButton.Event('findPop_ITEMCD_search').onClick();
            } else {
                ItsPage.InitData('findPop_ITEMCD_sdiv');
                ItsText.SetValue('findPop_s_ITEMCD', params.KEYWORD);
                ItsButton.Event('findPop_ITEMCD_search').onClick();
                ItsText.Focus('findPop_s_' + params.KEYTYPE);
            }
        } else {
            ItsPage.InitData('findPop_ITEMCD_sdiv');
            ItsText.SetValue('findPop_s_' + params.KEYTYPE, params.KEYWORD);
            ItsButton.Event('findPop_ITEMCD_search').onClick();
        }
    };
    ItsButton.Event('findPop_HELP').onClick = function () {
        var url = '../../Manual/' + 'ITEMCD.png';
        $.ajax({
            url: url,
            success: function () {
                var top = (window.screen.height / 2) - (744 / 2);
                var win = window.open(url, "_blank", 'height=744px, width=1322px, top=' + top + 'px, left=200px, screenX=200px');
                win.focus();
            },
            error: function (xhr, status, error) {
            }
        });
    };
    
    ItsPage.Load = function () {
        $('#findPop_s_ITEMCD').attr('placeholder', '코드');
        $('#findPop_s_ITEMNM').attr('placeholder', '품명');
        $('#findPop_s_ITEMSPEC').attr('placeholder', '규격');
        $('#findPop_s_MODELNO').attr('placeholder', '품번');
        $('#findPop_s_MATERIAL').attr('placeholder', '재질');
        $('#findPop_s_BRANDNM').attr('placeholder', '차종');
        ItsRadio.SetValue('rd_SEARCH_BOOL', 'AND');
        $('#dis_Title').parent().parent().attr('style', 'margin-top: 10px; float:left');
        ItsDisplay.SetInitValue('dis_CENTER1', '');
        ItsDisplay.SetInitValue('dis_CENTER2', '');
        ItsDisplay.SetInitValue('dis_CENTER3', '');
        ItsGrid.Create('findPop_ITEMCD_grid1', { contextMenu: false }, [
            column.create("품목코드", "ITEMCD", { width: '75*' }),
            column.create("품명", "ITEMNM", { width: '160*' }),
            column.create("규격", "ITEMSPEC", { width: '150*' }),
            column.create("재질", "MATERIAL", { width: '90*' }),
            column.create("품번", "MODELNO", { width: '90*' }),
            column.create("차종", "BRANDNM", { width: '85*' }),
            column.band("재고", {}, [
                column.create("1", "STOCK1", { width: '55*', columnType: enumColumnTypes.number }),
                column.create("2", "STOCK2", { width: '55*', columnType: enumColumnTypes.number }),
                column.create("3", "STOCK3", { width: '55*', columnType: enumColumnTypes.number }),
            ])
        ]);
        ItsGrid.Create('findPop_ITEMCD_grid2', { contextMenu: false }, [
            column.create("매입처", "CUSTCD", { width: 140, columnType: enumColumnTypes.combo, gpcd: 'CUSTCD' }),
            column.create("일자", "PURDT", { width: 100 }),
            column.create("매입단가", "PURCOST", { width: '*', columnType: enumColumnTypes.number })
        ]);
        ItsGrid.Create('findPop_ITEMCD_grid3', { contextMenu: false }, [
            column.create("매출처", "CUSTCD", { width: 140, columnType: enumColumnTypes.combo, gpcd: 'CUSTCD' }),
            column.create("일자", "SALESDT", { width: 100 }),
            column.create("매출단가", "SALESCOST", { width: '*', columnType: enumColumnTypes.number })
        ]);

        ItsGrid.Get('findPop_ITEMCD_grid1').columns[7].width = 0;
        ItsGrid.Get('findPop_ITEMCD_grid1').columns[8].width = 0;
        ItsGrid.Get('findPop_ITEMCD_grid1').columns[9].width = 0;

        // 조회버튼 이벤트
        ItsButton.Event('findPop_ITEMCD_search').onClick = function (stt) {

            var params = parent.window.ItsPop._paramsITEMCD;
            var $custcd = params.CUSTCD;
            if ($custcd == null || $custcd == undefined) {
                $custcd = '';
            }

            var maria = new ItsMaria('DC_FINDPOP', 'ITEMCD_LIST');
            maria.AddPanel('findPop_ITEMCD_sdiv');
            maria.AddParam('CUSTCD', $custcd);
            maria.CallProc();
            if (maria.isError) {
                maria.ShowErrMsg();
                return;
            }
            ItsGrid.Clear('findPop_ITEMCD_grid2');
            ItsGrid.Clear('findPop_ITEMCD_grid3');
            ItsPage.InitData('findPop_ITEMCD_ddiv');
            ItsGrid.SetStore('findPop_ITEMCD_grid1', maria.store);

            for (var i = 1; i <= (maria.storeExtend1.Length() + 1); i++) {
                ItsGrid.Get('findPop_ITEMCD_grid1').columns[6 + i].width = '55*';
                ItsDisplay.Show('dis_CENTER' + i);
                ItsDisplay.SetInitValue('dis_CENTER'+i, maria.storeExtend1.data[0]['CENTERNM'+i]);
            }

            $('#PRICE_02').next().css('background-color', '#fff');
            $('#RATE_06').next().css('background-color', '#fff');
            $('#PRICE_06').next().css('background-color', '#fff');
            $('#RATE_05').next().css('background-color', '#fff');
            $('#PRICE_05').next().css('background-color', '#fff');
            $('#RATE_04').next().css('background-color', '#fff');
            $('#PRICE_04').next().css('background-color', '#fff');
            $('#RATE_03').next().css('background-color', '#fff');
            $('#PRICE_03').next().css('background-color', '#fff');

            var pricetp = params.PRICETP;
            if (pricetp == '정가' || pricetp == 'E') {
                $('#PRICE_02').next().css('background-color', 'gold');
                //$('#PRICE_02').next().css('color', '#fff');
            }
            else if (pricetp == 'A단가' || pricetp == 'A') {
                $('#RATE_06').next().css('background-color', 'gold');
                //$('#RATE_06').next().css('color', '#fff');
                $('#PRICE_06').next().css('background-color', 'gold');
                //$('#PRICE_06').next().css('color', '#fff');
            }
             else if (pricetp == 'B단가' || pricetp == 'B') {
                $('#RATE_05').next().css('background-color', 'gold');
                //$('#RATE_05').next().css('color', '#fff');
                $('#PRICE_05').next().css('background-color', 'gold');
                //$('#PRICE_05').next().css('color', '#fff');
            }
             else if (pricetp == 'C단가' || pricetp == 'C') {
                $('#RATE_04').next().css('background-color', 'gold');
                //$('#RATE_04').next().css('color', '#fff');
                $('#PRICE_04').next().css('background-color', 'gold');
                //$('#PRICE_04').next().css('color', '#fff');
            }
            else if (pricetp == '온라인가' || pricetp == 'D') {
                $('#RATE_03').next().css('background-color', 'gold');
                //$('#RATE_03').next().css('color', '#fff');
                $('#PRICE_03').next().css('background-color', 'gold');
                //$('#PRICE_03').next().css('color', '#fff');
            }
            if (ItsGrid.Length('findPop_ITEMCD_grid1') > 0) {
                ItsGrid.Get('findPop_ITEMCD_grid1').focus();
            }
        }
        // 추가 버튼 이벤트
        ItsButton.Event('findPop_ITEMCD_add').onClick = function () {
            ItsMsg.Confirm('새 상품을 추가 하시겠습니까?', function () {
                var maria = new ItsMaria('DC_FINDPOP', 'ITEMCD_UP');
                maria.AddPanel('findPop_ITEMCD_ddiv');
                maria.AddParam('NEWYN', 'Y');
                maria.CallProc();
                if (maria.isError) {
                    maria.ShowErrMsg();
                    return;
                }
                ItsGrid.Setkey('findPop_ITEMCD_grid1', 'ITEMCD', maria.store.GetValue(0, 'ITEMCD'));
                ItsText.SetValue('findPop_s_ITEMCD', maria.store.GetValue(0, 'ITEMCD'));
                ItsButton.Event('findPop_ITEMCD_search').onClick();
                ItsMsg.Toast('저장되었습니다.');
            });
        }
        // 저장 버튼 이벤트
        ItsButton.Event('findPop_ITEMCD_save').onClick = function () {
            ItsMsg.Confirm('변경사항을 저장 하시겠습니까?', function () {
                var maria = new ItsMaria('DC_FINDPOP', 'ITEMCD_UP');
                maria.AddPanel('findPop_ITEMCD_ddiv');
                maria.AddParam('NEWYN', 'N');
                maria.CallProc();
                if (maria.isError) {
                    maria.ShowErrMsg();
                    return;
                }
                ItsGrid.Setkey('findPop_ITEMCD_grid1', 'ITEMCD', ItsText.GetValue('txt_ITEMCD'));
                ItsButton.Event('findPop_ITEMCD_search').onClick();
                ItsMsg.Toast('저장되었습니다.');
            });
        }
        // 그리드 셀렉트 이벤트
        ItsGrid.Event('findPop_ITEMCD_grid1').onSelect = function (rowindex) {

            ItsPage.InitData('findPop_ITEMCD_ddiv');
            ItsPage.SetBackColor('findPop_ITEMCD_ddiv', enumColor.white);
            //ItsText.Disable('txt_ITEMCD');
            ItsGrid.Clear('findPop_ITEMCD_grid2');
            ItsGrid.Clear('findPop_ITEMCD_grid3');
            ItsPage.SetStore('findPop_ITEMCD_ddiv', ItsGrid.GetRowData('findPop_ITEMCD_grid1', rowindex));
            ItsPage.SetStore('findPop_ITEMCD_div_price', ItsGrid.GetRowData('findPop_ITEMCD_grid1', rowindex));

            // 매입기록
            try {
                var $PURCUSTCD_LIST = ItsGrid.GetValue('findPop_ITEMCD_grid1', rowindex, 'PURCUSTCD_LIST').split(',');
                var $PURDT_LIST = ItsGrid.GetValue('findPop_ITEMCD_grid1', rowindex, 'PURDT_LIST').split(',');
                var $PURCOST_LIST = ItsGrid.GetValue('findPop_ITEMCD_grid1', rowindex, 'PURCOST_LIST').split(',');
                var $store = new Store();
                for (var i = 0; i < $PURCUSTCD_LIST.length; i++) {
                    $store.data.push({ CUSTCD: $PURCUSTCD_LIST[i], PURDT: $PURDT_LIST[i], PURCOST: parseInt($PURCOST_LIST[i]) });
                }
                ItsGrid.SetStore('findPop_ITEMCD_grid2', $store);
            } catch (e) { }
            // 매출기록
            try {
                var $SALESCUSTCD_LIST = ItsGrid.GetValue('findPop_ITEMCD_grid1', rowindex, 'SALESCUSTCD_LIST').split(',');
                var $SALESDT_LIST = ItsGrid.GetValue('findPop_ITEMCD_grid1', rowindex, 'SALESDT_LIST').split(',');
                var $DCRATE_LIST = ItsGrid.GetValue('findPop_ITEMCD_grid1', rowindex, 'DCRATE_LIST').split(',');
                var $SALESCOST_LIST = ItsGrid.GetValue('findPop_ITEMCD_grid1', rowindex, 'SALESCOST_LIST').split(',');
                var $store = new Store();
                for (var i = 0; i < $SALESCUSTCD_LIST.length; i++) {
                    $store.data.push({ CUSTCD: $SALESCUSTCD_LIST[i], SALESDT: $SALESDT_LIST[i], DCRATE: $DCRATE_LIST[i], SALESCOST: parseInt($SALESCOST_LIST[i]) });
                }
                ItsGrid.SetStore('findPop_ITEMCD_grid3', $store);
            } catch (e) { }
        }
        ItsGrid.Event('findPop_ITEMCD_grid1').onDoubleClick = function (rowIndex, field) {
            if (ItsGrid.IsSelect('findPop_ITEMCD_grid1')) {
                var $i = ItsGrid.GetCurrentIndex('findPop_ITEMCD_grid1');
                var $result = ItsGrid.GetRowData('findPop_ITEMCD_grid1', $i);
                parent.window.ItsPop._callbackITEMCD($result);
                parent.window.ItsPop.Close('findPop_ITEMCD');
            }
        }
        ItsGrid.Event('findPop_ITEMCD_grid1').onKeydown = function (rowIndex, field, keyCode, ctrlKey, shiftKey, altKey) {
            if (ctrlKey && keyCode == 38) {
                ItsText.Focus('findPop_s_ITEMCD');
            };
        }
        $(document).on('keydown', function (e) {
            if (e.keyCode == 13) {
                if (e.target.id == 'findPop_s_ITEMCD' || e.target.id == 'findPop_s_ITENM' || e.target.id == 'findPop_s_ITEMSPEC' || e.target.id == 'findPop_s_MODELNO' || e.target.id == 'findPop_s_MATERIAL' || e.target.id == 'findPop_s_BRANDNM') {
                    ItsButton.Event('findPop_ITEMCD_search').onClick();
                    return;
                } else if (e.target.tagName.toUpperCase() == 'INPUT') {
                    return;
                }
                e.preventDefault();
                if (ItsGrid.IsSelect('findPop_ITEMCD_grid1')) {
                    var $i = ItsGrid.GetCurrentIndex('findPop_ITEMCD_grid1');
                    var $result = ItsGrid.GetRowData('findPop_ITEMCD_grid1', $i);
                    parent.window.ItsPop._callbackITEMCD($result);
                    parent.window.ItsPop.Close('findPop_ITEMCD');
                }
            } else if (e.keyCode == 38 || e.keyCode == 40) {
                ItsGrid.Get('findPop_ITEMCD_grid1').focus();
                if (e.target.id == 'findPop_s_ITEMCD' || e.target.id == 'findPop_s_ITEMNM' || e.target.id == 'findPop_s_ITEMSPEC' || e.target.id == 'findPop_s_MODELNO' || e.target.id == 'findPop_s_MATERIAL' || e.target.id == 'findPop_s_BRANDNM') {
                    ItsGrid.SelectCell('findPop_ITEMCD_grid1', ItsGrid.GetCurrentIndex('findPop_ITEMCD_grid1'), 'ITEMCD');
                } else if (e.target.tagName.toUpperCase() == 'INPUT') {
                    return;
                }
            } else if (e.keyCode == 27) {
                parent.window.ItsPop.Close('findPop_ITEMCD');
            } else if (e.keyCode == 81) {
                if (e.altKey) {
                    ItsButton.Event('findPop_ITEMCD_search').onClick();
                }
            } else if (e.keyCode == 65) {
                if (e.altKey) {
                    ItsButton.Event('findPop_ITEMCD_add').onClick();
                }
            } else if (e.keyCode == 83) {
                if (e.altKey) {
                    ItsButton.Event('findPop_ITEMCD_save').onClick();
                }
            }
        });
        ItsNum.Event('RATE_01').onChanged = function (value, oldValue) {
            _priceCommonEvent('RATE_', '01', value, ItsCombo.GetRefValue('txt_PURROUND', 'REF01'), ItsCombo.GetRefValue('txt_PURROUND', 'REF02'));
        }
        ItsNum.Event('RATE_03').onChanged = function (value, oldValue) {
            _priceCommonEvent('RATE_', '03', value, ItsCombo.GetRefValue('txt_SALEROUND', 'REF01'), ItsCombo.GetRefValue('txt_SALEROUND', 'REF02'));
        }
        ItsNum.Event('RATE_04').onChanged = function (value, oldValue) {
            _priceCommonEvent('RATE_', '04', value, ItsCombo.GetRefValue('txt_SALEROUND', 'REF01'), ItsCombo.GetRefValue('txt_SALEROUND', 'REF02'));
        }
        ItsNum.Event('RATE_05').onChanged = function (value, oldValue) {
            _priceCommonEvent('RATE_', '05', value, ItsCombo.GetRefValue('txt_SALEROUND', 'REF01'), ItsCombo.GetRefValue('txt_SALEROUND', 'REF02'));
        }
        ItsNum.Event('RATE_06').onChanged = function (value, oldValue) {
            _priceCommonEvent('RATE_', '06', value, ItsCombo.GetRefValue('txt_SALEROUND', 'REF01'), ItsCombo.GetRefValue('txt_SALEROUND', 'REF02'));
        }
        ItsNum.Event('PRICE_01').onChanged = function (value, oldValue) {
            _priceCommonEvent('PRICE_', '01', value, ItsCombo.GetRefValue('txt_PURROUND', 'REF01'), ItsCombo.GetRefValue('txt_PURROUND', 'REF02'));
        }
        ItsNum.Event('PRICE_02').onChanged = function (value, oldValue) {
            var $Eprice = value;
            if ($Eprice == 0) return;
            ItsNum.Event('RATE_01').onChanged(ItsNum.GetValue('RATE_01'));
            ItsNum.Event('RATE_03').onChanged(ItsNum.GetValue('RATE_03'));
            ItsNum.Event('RATE_04').onChanged(ItsNum.GetValue('RATE_04'));
            ItsNum.Event('RATE_05').onChanged(ItsNum.GetValue('RATE_05'));
            ItsNum.Event('RATE_06').onChanged(ItsNum.GetValue('RATE_06'));
        }
        ItsNum.Event('PRICE_03').onChanged = function (value, oldValue) {
            _priceCommonEvent('PRICE_', '03', value, ItsCombo.GetRefValue('txt_SALEROUND', 'REF01'), ItsCombo.GetRefValue('txt_SALEROUND', 'REF02'));
        }
        ItsNum.Event('PRICE_04').onChanged = function (value, oldValue) {
            _priceCommonEvent('PRICE_', '04', value, ItsCombo.GetRefValue('txt_SALEROUND', 'REF01'), ItsCombo.GetRefValue('txt_SALEROUND', 'REF02'));
        }
        ItsNum.Event('PRICE_05').onChanged = function (value, oldValue) {
            _priceCommonEvent('PRICE_', '05', value, ItsCombo.GetRefValue('txt_SALEROUND', 'REF01'), ItsCombo.GetRefValue('txt_SALEROUND', 'REF02'));
        }
        ItsNum.Event('PRICE_06').onChanged = function (value, oldValue) {
            _priceCommonEvent('PRICE_', '06', value, ItsCombo.GetRefValue('txt_SALEROUND', 'REF01'), ItsCombo.GetRefValue('txt_SALEROUND', 'REF02'));
        }
        ItsCombo.Event('txt_PURROUND').onChanged = function () {
            ItsNum.Event('RATE_01').onChanged(ItsNum.GetValue('RATE_01'));
        }
        ItsCombo.Event('txt_SALEROUND').onChanged = function () {
            ItsNum.Event('RATE_03').onChanged(ItsNum.GetValue('RATE_03'));
            ItsNum.Event('RATE_04').onChanged(ItsNum.GetValue('RATE_04'));
            ItsNum.Event('RATE_05').onChanged(ItsNum.GetValue('RATE_05'));
            ItsNum.Event('RATE_06').onChanged(ItsNum.GetValue('RATE_06'));
        }
    }
    function _priceCommonEvent(type, idx, value, precision, about) {
        if (type == 'PRICE_') {
            var $Eprice = ItsNum.GetValue('PRICE_02');
            if ($Eprice == 0) return;
            var $e = ItsNum.Event('RATE_' + idx).onChanged;
            ItsNum.Event('RATE_' + idx).onChanged = function () { };
            ItsNum.SetValue('RATE_' + idx, Math.floor(value / $Eprice * 100, 1));
            ItsNum.Event('RATE_' + idx).onChanged = $e;
        } else if (type == 'RATE_') {
            var $Eprice = ItsNum.GetValue('PRICE_02');
            if ($Eprice == 0) return;
            var $e = ItsNum.Event('PRICE_' + idx).onChanged;
            ItsNum.Event('PRICE_' + idx).onChanged = function () { };
            if (about == 2)         // 올림
                ItsNum.SetValue('PRICE_' + idx, Math.ceil(($Eprice * value / 100) / Math.pow(10, parseInt(precision) * -1)) * Math.pow(10, parseInt(precision) * -1));
            else if (about == 1)     //반올림
                ItsNum.SetValue('PRICE_' + idx, Math.round(($Eprice * value / 100) / Math.pow(10, parseInt(precision) * -1)) * Math.pow(10, parseInt(precision) * -1));
            else                    // 버림
                ItsNum.SetValue('PRICE_' + idx, Math.floor(($Eprice * value / 100) / Math.pow(10, parseInt(precision) * -1)) * Math.pow(10, parseInt(precision) * -1));
            ItsNum.Event('PRICE_' + idx).onChanged = $e;
        }
    }
</script>
<Its:div runat="server" Type="BasicFloat">
    <its:div runat="server" Type="SplitTop" ID="findPop_ITEMCD_sdiv" >
        <Its:text runat="server" Field="ITEMCD" HiddenLabel="true" ID="findPop_s_ITEMCD" InputWidth="60" />
        <Its:text runat="server" Field="ITEMNM" HiddenLabel="true" ID="findPop_s_ITEMNM" InputWidth="70" />
        <Its:text runat="server" Field="ITEMSPEC" HiddenLabel="true" ID="findPop_s_ITEMSPEC" InputWidth="70" />
        <Its:text runat="server" Field="MODELNO" HiddenLabel="true" ID="findPop_s_MODELNO" InputWidth="60" />
        <Its:text runat="server" Field="MATERIAL" HiddenLabel="true" ID="findPop_s_MATERIAL" InputWidth="60" />
        <Its:text runat="server" Field="BRANDCD" HiddenLabel="true" ID="findPop_s_BRANDNM" InputWidth="60" />
        <Its:button runat="server" Label="조회" FaIcon="fa-search" ID="findPop_ITEMCD_search" />
        <Its:radio runat="server" Label="" LabelWidth="10" Field="SEARCH_BOOL" ID="rd_SEARCH_BOOL" GPCD="BOOLEAN" Value="AND" />
        <Its:onoff runat="server" Label="" LabelWidth="10" Field="SEARCH_CUST" ID="onoff_SEARCH_CUST" OnText="ALL" OffText="거래품목" />
        <%--<Its:button runat="server" Label="초기화" FaIcon="fa-refresh" ID="findPop_ITEMCD_refresh" />--%>
        <Its:newline runat="server" />
        <Its:grid runat="server" ID="findPop_ITEMCD_grid1" Height="330" />
    </its:div>
    <Its:split runat="server" Type="Horizon" />
    <its:div runat="server" Type="SplitDown" ID="Div1" >
        <div style="display: flex;">
            <div style="width:429px;">
                <Its:grid runat="server" ID="findPop_ITEMCD_grid2" Height="130"/>
            </div>
            <div style="width:429px;">
                <Its:grid runat="server" ID="findPop_ITEMCD_grid3" Height="130"/>
            </div>
        </div>
    </Its:div>
</Its:div>
<Its:div runat="server" Type="BasicFloat" ID="findPop_ITEMCD_ddiv" BackColor="White">
    <Its:button runat="server" Label="추가" FaIcon="fa-plus" ID="findPop_ITEMCD_add" Margin="0px 0px 0px 20px" />
    <Its:button runat="server" Label="저장" FaIcon="fa-save" ID="findPop_ITEMCD_save" />
    <Its:button runat="server" ForeColor="BlueDark1" FaIcon="fa-2x fa-question-circle" ID="findPop_HELP" Float="right" />
    <Its:newline runat="server" />    
    <Its:text runat="server" Label="상품코드" Field="ITEMCD" Required="true" ID="txt_ITEMCD" InputWidth="162" LabelWidth="90"/>
    <Its:newline runat="server" />
    <Its:text runat="server" Label="품명" Field="ITEMNM" InputWidth="162" LabelWidth="90"/>
    <Its:newline runat="server" />
    <Its:text runat="server" Label="규격" Field="ITEMSPEC" InputWidth="162" LabelWidth="90"/>
    <Its:newline runat="server" />
    <Its:text runat="server" Label="품번" Field="MODELNO" InputWidth="162" LabelWidth="90" />
    <Its:newline runat="server" />
    <Its:text runat="server" Label="재질" Field="MATERIAL" InputWidth="162" LabelWidth="90" />
    <Its:newline runat="server" />
    <Its:onoff runat="server" Label="쇼핑몰 판매" Field="SHOPDISPYN" LabelWidth="90" />
    <Its:newline runat="server" />
    <Its:num runat="server" Label="" Hidden="true" Field="RATE_02" ReadOnly="true" TriggerButton="false" ID="RATE_02" Value="100"/>
    <Its:num runat="server" Label="정가" InputWidth="122" Field="PRICE_02" TriggerButton="false" ID="PRICE_02" LabelWidth="90" />
    <Its:display runat="server" LabelWidth="15" InputWidth="0" Label="원" />
    <Its:newline runat="server" />
    <Its:combo runat="server" Label="매입끝전" Field="PURROUND" ID="txt_PURROUND" GPCD="MONEY_ROUND" InputWidth="137" LabelWidth="90"/>
    <Its:newline runat="server" />
    <Its:num runat="server" Label="매입" InputWidth="15" Field="RATE_01" TriggerButton="false" ID="RATE_01" LabelWidth="90" />
    <Its:num runat="server" Label="%" LabelWidth="15" InputWidth="50" Field="PRICE_01" TriggerButton="false" ID="PRICE_01" />
    <Its:display runat="server" LabelWidth="15" InputWidth="0" Label="원" />
    <Its:newline runat="server" />
    <Its:combo runat="server" Label="매출끝전" Field="SALEROUND" ID="txt_SALEROUND" GPCD="MONEY_ROUND" InputWidth="137" LabelWidth="90" />
    <Its:newline runat="server" />
    <Its:num runat="server" Label="A단가" InputWidth="15" Field="RATE_06" TriggerButton="false" ID="RATE_06" LabelWidth="90" />
    <Its:num runat="server" Label="%" LabelWidth="15" InputWidth="50" Field="PRICE_06" TriggerButton="false" ID="PRICE_06" />
    <Its:display runat="server" LabelWidth="15" InputWidth="0" Label="원" />
    <Its:newline runat="server" />
    <Its:num runat="server" Label="B단가" InputWidth="15" Field="RATE_05" TriggerButton="false" ID="RATE_05" LabelWidth="90" />
    <Its:num runat="server" Label="%" LabelWidth="15" InputWidth="50" Field="PRICE_05" TriggerButton="false" ID="PRICE_05"/>
    <Its:display runat="server" LabelWidth="15" InputWidth="0" Label="원" />
    <Its:newline runat="server" />
    <Its:num runat="server" Label="C단가" InputWidth="15" Field="RATE_04" TriggerButton="false" ID="RATE_04" LabelWidth="90" />
    <Its:num runat="server" Label="%" LabelWidth="15" InputWidth="50" Field="PRICE_04" TriggerButton="false" ID="PRICE_04"/>
    <Its:display runat="server" LabelWidth="15" InputWidth="0" Label="원" />
    <Its:newline runat="server" />
    <Its:num runat="server" Label="온라인" InputWidth="15" Field="RATE_03" TriggerButton="false" ID="RATE_03" LabelWidth="90" />
    <Its:num runat="server" Label="%" LabelWidth="15" InputWidth="50" Field="PRICE_03" TriggerButton="false" ID="PRICE_03" />
    <Its:display runat="server" LabelWidth="15" InputWidth="0" Label="원" />
    <Its:newline runat="server" />
    <Its:text runat="server" Label="수정일자" Field="FROMDT_SHOW" ReadOnly="true" InputWidth="162" LabelWidth="90" />
    <Its:text runat="server" Label="수정일자" Field="FROMDT" Hidden="true" />
    <Its:newline runat="server" />
    <Its:display runat="server" Label="재고 지점 번호" LabelWidth="120" ID="dis_Title" />
    <Its:newline runat="server" />
    <Its:display runat="server" Label="1 :" ID="dis_CENTER1" Hidden="true" LabelWidth="90" />
    <Its:newline runat="server" />
    <Its:display runat="server" Label="2 :" ID="dis_CENTER2" Hidden="true" LabelWidth="90" />
    <Its:newline runat="server" />
    <Its:display runat="server" Label="3 :" ID="dis_CENTER3" Hidden="true" LabelWidth="90" />
    <Its:newline runat="server" />
</Its:div>