<%@ Page Language="C#" AutoEventWireup="true" CodeFile="COM.aspx.cs" Inherits="COM" %>
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
    }
</style>
<script>
    var Reset = function () {
        ItsPage.Load();
        var $params = parent.window.ItsPop._paramsCOM;
        ItsText.SetValue('findPop_COM_KEYWORD', $params.keyword);
        ItsButton.Event('findPop_COM_search').onClick();
    };
    
    ItsPage.Load = function () {
        
        var $params = parent.window.ItsPop._paramsCOM;
        if ($params.headStore.length == 0) {
            return;
        }

        var $CODE = $params.headStore[0].data[0]['CODE'];
        var $NAME = $params.headStore[0].data[0]['NAME'];
        var $REF01 = $params.headStore[0].data[0]['REF01']; if ($REF01 == undefined) $REF01 = '참조1';
        var $REF02 = $params.headStore[0].data[0]['REF02']; if ($REF02 == undefined) $REF02 = '참조2';
        var $REF03 = $params.headStore[0].data[0]['REF03']; if ($REF03 == undefined) $REF03 = '참조3';
        var $REF04 = $params.headStore[0].data[0]['REF04']; if ($REF04 == undefined) $REF04 = '참조4';
        var $REF05 = $params.headStore[0].data[0]['REF05']; if ($REF05 == undefined) $REF05 = '참조5';
        var $REF01_HIDDEN = false;
        var $REF02_HIDDEN = false;
        var $REF03_HIDDEN = false;
        var $REF04_HIDDEN = false;
        var $REF05_HIDDEN = false;
        var $CODE_WIDTH = $params.headStore[1].data[0]['CODE']; if ($CODE_WIDTH == undefined) { $CODE_WIDTH = 0; }
        var $NAME_WIDTH = $params.headStore[1].data[0]['NAME']; if ($NAME_WIDTH == undefined) { $NAME_WIDTH = 0; }
        var $REF01_WIDTH = $params.headStore[1].data[0]['REF01']; if ($REF01_WIDTH == undefined) { $REF01_WIDTH = 0; $REF01_HIDDEN = true; }
        var $REF02_WIDTH = $params.headStore[1].data[0]['REF02']; if ($REF02_WIDTH == undefined) { $REF02_WIDTH = 0; $REF02_HIDDEN = true; }
        var $REF03_WIDTH = $params.headStore[1].data[0]['REF03']; if ($REF03_WIDTH == undefined) { $REF03_WIDTH = 0; $REF03_HIDDEN = true; }
        var $REF04_WIDTH = $params.headStore[1].data[0]['REF04']; if ($REF04_WIDTH == undefined) { $REF04_WIDTH = 0; $REF04_HIDDEN = true; }
        var $REF05_WIDTH = $params.headStore[1].data[0]['REF05']; if ($REF05_WIDTH == undefined) { $REF05_WIDTH = 0; $REF05_HIDDEN = true; }
        var $fullWidth = parseInt($CODE_WIDTH) + parseInt($NAME_WIDTH) + parseInt($REF01_WIDTH) + parseInt($REF02_WIDTH) + parseInt($REF03_WIDTH) + parseInt($REF04_WIDTH) + parseInt($REF05_WIDTH) + 40;
        
        if (ItsGrid.Get('findPop_COM_grid1') != undefined) {
            ItsGrid.Get('findPop_COM_grid1').dispose();
            ItsGrid.list = [];
        }
        
        ItsGrid.Create('findPop_COM_grid1', { contextMenu: false }, [
            column.create($CODE, "CODE", { width: $CODE_WIDTH }),
            column.create($NAME, "NAME", { width: $NAME_WIDTH }),
            column.create($REF01, "REF01", { width: $REF01_WIDTH, hidden: $REF01_HIDDEN }),
            column.create($REF02, "REF02", { width: $REF02_WIDTH, hidden: $REF02_HIDDEN }),
            column.create($REF03, "REF03", { width: $REF03_WIDTH, hidden: $REF03_HIDDEN }),
            column.create($REF04, "REF04", { width: $REF04_WIDTH, hidden: $REF04_HIDDEN }),
            column.create($REF05, "REF05", { width: $REF05_WIDTH, hidden: $REF05_HIDDEN })
        ]);
        // 조회버튼 이벤트
        ItsButton.Event('findPop_COM_search').onClick = function () {
            var maria = new ItsMaria('DC_FIND');
            maria.AddParam('GPCD', $params.gpcd + '_LIST');
            maria.AddParam('KEYWORD', ItsText.GetValue('findPop_COM_KEYWORD'));
            maria.AddParam('REF01', $params.ref01);
            maria.AddParam('REF02', $params.ref02);
            maria.AddParam('REF03', $params.ref03);
            maria.AddParam('REF04', $params.ref04);
            maria.AddParam('REF05', $params.ref05);
            maria.CallProc();
            if (maria.isError) {
                maria.ShowErrMsg();
                return;
            }
            ItsGrid.SetStore('findPop_COM_grid1', maria.store);
        }
        ItsGrid.Get('findPop_COM_grid1').hostElement.addEventListener('dblclick', function (e) {
            var sel = ItsGrid.Get('findPop_COM_grid1').selection;
            if (ItsGrid.IsSelect('findPop_COM_grid1')) {
                var $i = ItsGrid.GetCurrentIndex('findPop_COM_grid1');
                var $result = ItsGrid.GetRowData('findPop_COM_grid1', $i);
                parent.window.ItsPop._callbackCOM($result);
                parent.window.ItsPop.Close('findPop_COM');
            }
        });
        $(document).on('keydown', function (e) {
            if (e.keyCode == 13) {
                if (e.target.nodeName == 'INPUT') {
                    ItsButton.Event('findPop_COM_search').onClick();
                    return;
                }
                e.preventDefault();
                if (ItsGrid.IsSelect('findPop_COM_grid1')) {
                    var $i = ItsGrid.GetCurrentIndex('findPop_COM_grid1');
                    var $result = ItsGrid.GetRowData('findPop_COM_grid1', $i);
                    parent.window.ItsPop._callbackCOM($result);
                    parent.window.ItsPop.Close('findPop_COM');
                }
            } else if (e.keyCode == 38 || e.keyCode == 40) {
                ItsGrid.Get('findPop_COM_grid1').focus();
            } else if(e.keyCode == 27) {
                parent.window.ItsPop.Close('findPop_COM');
            }
        });
        $(window).ready(function () {
            parent.window.$('#findPop_COM').parent().css('width', $fullWidth + 20);
            $('a[href="https://www.grapecity.com/en/licensing/wijmo"]').parent().css('display', 'none');
        });        
    }
</script>
<its:div runat="server" Type="BorderBlock" ID="findPop_COM_sdiv" >
    <Its:text runat="server" Label="키워드" Field="KEYWORD" LabelWidth="45" ID="findPop_COM_KEYWORD" />
    <Its:button runat="server" Label="조회" FaIcon="fa-search" ID="findPop_COM_search" />
</its:div>
<Its:grid runat="server" ID="findPop_COM_grid1" Height="350" />