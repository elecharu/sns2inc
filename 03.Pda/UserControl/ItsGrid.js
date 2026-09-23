/// <reference path="../Script/reference.js" />
/********************************************
 * >>>>> grid: 그리드 컨트롤 >>>>>
 * 2017-11-01: 문재원: 최초 작성
 * 2018-08-07: 문재원: 전체적인 소스 변경 ( wijmo 모듈 변경)
 * 2018-08-07: 문재원: 밴드기능 보류 -> 2018-09-04 완
 *******************************************/
var _gridParams = function () {
    this.id = '';
    this.padding = 0;
    this.rowNumber = true;
    this.selectMode = enumSelectMode.cell;
    this.allowAddNew = false;
    this.allowSorting = false; // PDA의 경우 그리드 정렬이 필요없기 때문에
    this.allowDragging = true;
    this.autoClipboard = true;
    this.rowMerging = false;
    this.colMerging = false;
    this.isTopAddNew = false;
    this.isCheckBoxGrid = false;
    this.isSubTotalGrid = false;
    this.groupField = undefined;
    this.groupASC = true;
    this.lockColumn = 0;
    this.contextMenu = true;
    this.selectFirstRowAtSetStore = true;
};
var _columnParams = function () {
    this.width = 100;
    this.align = undefined;
    this.readOnly = true;
    this.columnType = enumColumnTypes.text;
    this.mask = undefined;
    this.allowMerging = false;
    this.allowDragging = true;
    this.backColor = 'white';
    this.foreColor = 'black';
    this.hidden = false;
    this.iconCls = '';
    this.decimalPrecision = 0;
    this.gpcd = '';
    this.ref01 = '';
    this.ref02 = '';
    this.ref03 = '';
    this.ref04 = '';
    this.ref05 = '';
    this.callCenter = false;
    this.groupType = enumGrouping.none;
};
var ItsGrid = {
    list: [],
    Init: function () {

    },
    /**
     * @param {String} id
     * @param {_gridParams} params
     * @param {Object[]} columns
     */
    Create: function (id, params, columns) {
        params.id = id;
        var $params = new _gridParams();
        ItsHelper.CopyObj(params, $params);

        if ($params.id == undefined) {
            alert('Grid control must have attribute \'id\'.');
            return;
        }
        if ($('#' + $params.id).length == 0) {
            alert('Can not find \'' + $params.id + '\' tag.');
            return;
        }
        if ($params.allowDragging) {
            $params.allowDragging = 1;
        } else {
            $params.allowDragging = 0;
        }
        var colList = []; // 그리드에 넣을 컬럼
        var notBandCol = []; // 밴드가 아닌 컬럼
        var bandCol = []; // 밴드인 컬럼
        var bandText = []; // 밴드 라벨 목록
        var btnColumn = []; // 버튼형 컬럼 목록
        var dateColumn = []; // 데이트피커형 컬럼 목록
        var comboColumn = []; // 콤보박스형 컬럼 목록
        var checkColumn = []; // 체크박스형 컬럼 목록
        colList.push({
            header: '선택',
            binding: 'isRowCheck',
            width: 60,
            visible: $params.isCheckBoxGrid,
            isReadOnly: false
        });
        columns.forEach(function (col) {
            if (col.type == 'column') {
                notBandCol.push(col.field);
                colList.push(col.colObj);
            } else if (col.type == 'band') {
                col.columns.forEach(function (col2) {
                    bandText.push(col.text);
                    bandCol.push({ field: col2.field, text: col.text, obj: col2.colObj });
                    colList.push(col2.colObj);
                    if (col2.editType == enumColumnTypes.button) {
                        btnColumn.push({ obj: col2.colObj, buttonClass: col2.buttonClass, field: col2.field });
                    } else if (col2.editType == enumColumnTypes.date) {
                        dateColumn.push({ obj: col2.colObj, field: col2.field });
                    } else if (col2.editType == enumColumnTypes.combo) {
                        comboColumn.push({ obj: col2.colObj, field: col2.field, gpcd: col2.gpcd, ref01: col2.ref01, ref02: col2.ref02, ref03: col2.ref03, ref04: col2.ref04, ref05: col2.ref05, callCenter: col2.callCenter });
                    } else if (col2.editType == enumColumnTypes.check) {
                        checkColumn.push({ obj: col2.colObj, field: col2.field });
                    }
                });
            }
            if (col.editType == enumColumnTypes.button) {
                btnColumn.push({ obj: col.colObj, buttonClass: col.buttonClass, field: col.field });
            } else if (col.editType == enumColumnTypes.date) {
                dateColumn.push({ obj: col.colObj, field: col.field });
            } else if (col.editType == enumColumnTypes.combo) {
                comboColumn.push({ obj: col.colObj, field: col.field, gpcd: col.gpcd, ref01: col.ref01, ref02: col.ref02, ref03: col.ref03, ref04: col.ref04, ref05: col.ref05, callCenter: col.callCenter });
            } else if (col.editType == enumColumnTypes.check) {
                checkColumn.push({ obj: col.colObj, field: col.field });
            }
        });
        // 그리드 생성
        var $obj = new wijmo.grid.FlexGrid('#' + $params.id, {
            autoGenerateColumns: false, // 컬럼 자동생성 X
            showAlternatingRows: false,
            imeEnabled: true, // 한영전환관련
            allowSorting: $params.allowSorting,
            allowDragging: $params.allowDragging,
            allowMerging: 'ColumnHeaders',
            allowResizing: 'None',
            allowAddNew: $params.allowAddNew,
            allowDelete: $params.allowAddNew,
            newRowAtTop: $params.isTopAddNew,
            selectionMode: $params.selectMode,
            frozenColumns: $params.lockColumn,
            autoClipboard: $params.autoClipboard,
            keyActionTab: 'Cycle',
            keyActionEnter: 'None',
            columns: colList,
            itemsSourceChanged: function () {
                // 스타일 관련
                if ($obj._$initStyle == undefined) {
                    var state = {
                        columns: $obj.columnLayout,
                        //filterDefinition: $obj.flexFilter.filterDefinition,
                        sortDescriptions: $obj.collectionView.sortDescriptions.map(function (sortDesc) {
                            return { property: sortDesc.property, ascending: sortDesc.ascending };
                        })
                    }
                    $obj._$initStyle = JSON.stringify(state);
                }
                if ($obj._$customStyle != undefined) {
                    var ori_datamap = [];
                    $obj.columns.forEach(function (d) {
                        if (d.dataMap != undefined) {
                            ori_datamap.push({ binding: d.binding, dataMap: d.dataMap })
                        }
                    })
                    var json = $obj._$customStyle;
                    if (json) {
                        var state = JSON.parse(json);
                        $obj.columnLayout = state.columns.replace(/\n/gi, '\\n');
                        //$obj.flexFilter.filterDefinition = state.filterDefinition;
                        var view = $obj.collectionView;
                        view.deferUpdate(function () {
                            view.sortDescriptions.clear();
                            for (var i = 0; i < state.sortDescriptions.length; i++) {
                                var sortDesc = state.sortDescriptions[i];
                                view.sortDescriptions.push(
                                    new wijmo.collections.SortDescription(sortDesc.property, sortDesc.ascending)
                                );
                            }
                        });
                        if ($obj.bandText.length > 0) { // 밴드기능
                            var hr = new wijmo.grid.Row();
                            hr.allowMerging = true;
                            var ch = $obj.columnHeaders;
                            ch.rows.splice(0, 1);
                            ch.rows.splice(0, 0, hr);
                            for (var i = 0; i < $obj.bandText.length; i++) {
                                for (var j = 0; j < $obj.bandCol.length; j++) {
                                    if ($obj.bandText[i] == $obj.bandCol[j].text) {
                                        var $field = $obj.bandCol[j].field;
                                        var $column = $obj.getColumn($field);
                                        ch.setCellData(0, $column.index, $obj.bandText[i]);
                                    }
                                }
                            }
                            var $col = $obj.getColumn('isRowCheck');
                            $col.allowMerging = true;
                            ch.setCellData(0, $col.index, $col.header);
                            for (var i = 0; i < $obj.notBandCol.length; i++) {
                                var $col = $obj.getColumn($obj.notBandCol[i]);
                                if ($col != undefined) {
                                    $col.allowMerging = true;
                                    ch.setCellData(0, $col.index, $col.header);
                                }
                            }
                        }
                    }
                    ori_datamap.forEach(function (d) {
                        $obj.columns[ItsGrid.$colIndex($params.id, d.binding)].dataMap = d.dataMap;
                        $obj.columns[ItsGrid.$colIndex($params.id, d.binding)].dataMap._originData = d.dataMap.collectionView.items;
                    })
                }
                // select 이벤트 관련
                $obj._curRowIdx = undefined;
                var $index = 0;
                if ($obj.ItsSelectKey != undefined) {
                    var $key = Object.keys($obj.ItsSelectKey)[0];
                    $.each($obj.itemsSource, function (i, v) {
                        if (v[$key] == $obj.ItsSelectKey[$key]) {
                            $index = i;
                        }
                    });
                }
                $obj.ItsInitIndex = $index;
                $obj.initState = true;
                if ($params.selectFirstRowAtSetStore) {
                    $obj.initState = false;
                    ItsGrid.SelectRow(id, $obj.ItsInitIndex);
                } else {
                    ItsGrid.SelectRow(id, -1);
                }
                setTimeout(function () {
                    $obj.initState = false;
                    $obj.ItsSelectKey = undefined;
                    if (ItsGrid.Length($params.id) == 0) {
                        return;
                    }
                    if ($obj.ItsInitIndex == 0 && $params.selectFirstRowAtSetStore) {
                        if (ItsGrid.Event($params.id).onSelect != undefined) {
                            ItsGrid.Event($params.id).onSelect(0, $obj.columns[0].binding);
                        }
                    }
                }, 50);
            },
            selectionChanged: function (s, e) {
                try {
                    parent.wait_start();
                } catch (ex) { }
                $obj._ctxMenu.hide();
                if ($obj.initState == false) {
                    if ($obj.groupField != undefined) {
                        var row = s.itemsSource._idx;
                    } else {
                        var row = e.row;
                    }
                    if ($obj._curRowIdx != row && row > -1) {
                        if (ItsGrid.Event($params.id).onSelect != undefined) {
                            ItsGrid.Event($params.id).onSelect(row, $obj.columns[e.col].binding);
                        }
                    }
                    $obj._curRowIdx = row;
                }
                setTimeout(function () {
                    $('#' + $params.id).find('.itsgrid-seleted-row').removeClass('itsgrid-seleted-row');
                    $('#' + $params.id).find('.wj-state-active').siblings().addClass('itsgrid-seleted-row');
                    $('#' + $params.id).find('.wj-state-active').addClass('itsgrid-seleted-row');

                    try {
                        parent.wait_end();
                    } catch (ex) { }
                }, 1);
            },
            scrollPositionChanged: function () {
                setTimeout(function () {
                    $('#' + $params.id).find('.itsgrid-seleted-row').removeClass('itsgrid-seleted-row');
                    $('#' + $params.id).find('.wj-state-active').siblings().addClass('itsgrid-seleted-row');
                    $('#' + $params.id).find('.wj-state-active').addClass('itsgrid-seleted-row');
                }, 0);
            },
            cellEditEnded: function (sender, e) {
                var $oldValue = e._data;
                if ($oldValue == undefined) {
                    if ($obj.columns[e.col].format != undefined && $obj.columns[e.col].format.indexOf('d') > -1) { // dateColumn의경우
                        $oldValue = e.panel._activeCell.innerText;
                    } else {
                        $oldValue = ''; // 다른경우
                    }
                }
                if ($obj.groupField != undefined) {
                    var row = sender.itemsSource._idx;
                } else {
                    var row = e.row;
                }
                if (sender.getCellData(row, e.col) != $oldValue) {
                    if (e._p._cols[e.col]._binding._key != 'isRowCheck') {
                        //$obj.cells.setCellData(row, ItsGrid.$colIndex($params.id, 'isRowCheck'), true);
                        ItsGrid.CheckRow($params.id, row);
                    }
                    ItsGrid.Event($params.id).onChanged(row, e._p._cols[e.col]._binding._key, sender.getCellData(row, e.col), $oldValue, 'cellEditEnded');
                }
            },
            pastedCell: function (p, rng, data) {

                var $val = rng.data;
                var $format = p.columns[rng.col].format;
                if (p.columns[rng.col].format != undefined && p.columns[rng.col].format.indexOf('n') > -1) {
                    $val = parseFloat($val.replace(/[,]/gi, ''));
                }
                // 클립보드 oldvalue 사용불가..
                if ($obj.groupField != undefined) {
                    var row = p.itemsSource._idx;
                } else {
                    var row = rng.row;
                }

                //if ($val != p.getCellData(rng.row, rng.col)) {
                if (p._cols[rng.col]._binding._key != 'isRowCheck') {
                    ItsGrid.CheckRow($params.id, row);
                }
                ItsGrid.Event($params.id).onChanged(row, p.columns[rng.col].binding, $val, undefined, 'pastedCell');
                //}
            }
        });
        $obj.beginningEdit.addHandler(function (p, rng, data) {
            var $field = $obj.columns[rng.col].binding;
            ItsGrid.Event($params.id).onBeginningEdit(rng.row, $field, ItsGrid.GetValue($params.id, rng.row, $field));
        });
        // -----------------------------------------------------------------------------------------------------------------------
        for (var i = 0; i < $obj.columns.length; i++) {
            $obj.columns[i].customAllowMerging = $obj.columns[i].allowMerging;
        }
        $obj.bandText = bandText;
        $obj.bandCol = bandCol;
        $obj.notBandCol = notBandCol;

        if ($obj.bandText.length > 0) { // 밴드기능
            var hr = new wijmo.grid.Row();
            hr.allowMerging = true;
            var ch = $obj.columnHeaders;
            ch.rows.splice(0, 0, hr);
            for (var i = 0; i < $obj.bandText.length; i++) {
                for (var j = 0; j < $obj.bandCol.length; j++) {
                    if ($obj.bandText[i] == $obj.bandCol[j].text) {
                        var $field = $obj.bandCol[j].field;
                        var $column = $obj.getColumn($field);
                        ch.setCellData(0, $column.index, $obj.bandText[i]);
                    }
                }
            }
            var $col = $obj.getColumn('isRowCheck');
            $col.allowMerging = true;
            ch.setCellData(0, $col.index, $col.header);
            for (var i = 0; i < $obj.notBandCol.length; i++) {
                var $col = $obj.getColumn($obj.notBandCol[i]);
                $col.allowMerging = true;
                ch.setCellData(0, $col.index, $col.header);
            }
        }
        $obj.formatItem.addHandler(function (s, e) {
            if (e.panel == s.columnHeaders && e.range.rowSpan > 1) {
                var html = e.cell.innerHTML;
                e.cell.innerHTML = '<div class="v-center">' + html + '</div>';
            }
            if (e.panel == s.columnHeaders && e.range.columnSpan > 1) {
                var html = e.cell.innerHTML;
                e.cell.innerHTML = '<div class="h-center">' + html + '</div>';
            }
        });

        // -----------------------------------------------------------------------------------------------------------------------
        // 버튼컬럼 처리
        $obj.formatItem.addHandler(function (s, e) {
            try {
                btnColumn.forEach(function (col) {
                    if ($obj.columns[e.col]._binding != undefined) {
                        if (!$(e.cell).hasClass('wj-header') && !$(e.cell).hasClass('wj-group') && col.field == $obj.columns[e.col]._binding._key && e.panel != s.columnHeaders) {
                            e.cell.innerHTML = '<div class=\"' + col.buttonClass + ' ' + 'ItsGridButton' + '\" onClick=\"ItsGrid.Event(\'' + $params.id + '\').onButtonClick(ItsGrid.$GetRowIndex(\'' + params.id + '\'),\'' + col.field + '\')\"></div>';
                        }
                    }
                });
            } catch (e) { }
        });

        // 날짜 선택컬럼 처리
        dateColumn.forEach(function (col) {
            for (var i = 0; i < $obj.columns.length; i++) {
                if ($obj.columns[i]._binding != undefined) {
                    if (col.field == $obj.columns[i]._binding._key) {
                        new CustomGridEditor($obj, col.field, wijmo.input.InputDate, {
                            format: 'd'
                        });
                    }
                }
            }
        });
        // 콤보박스 컬럼
        comboColumn.forEach(function (col) {
            for (var i = 0; i < $obj.columns.length; i++) {
                if ($obj.columns[i]._binding != undefined) {
                    if (col.field == $obj.columns[i]._binding._key) {
                        var $data = ItsGrid.$getGpcdData(col.gpcd, col.ref01, col.ref02, col.ref03, col.ref04, col.ref05, col.callCenter);
                        try {
                            var $tag = Object.keys($data[0])[2];
                            if ($tag == undefined) {
                                $tag = Object.keys($data[0])[0];
                            }
                            var $dataMap = new wijmo.grid.DataMap($data, Object.keys($data[0])[1], $tag);
                            $obj.columns[i].dataMap = $dataMap;
                            $obj.columns[i].dataMap._originData = $data;
                        } catch (e) { }
                    }
                }
            }
        });
        $obj.$cellBackColorRanges = []; // 컬러 설정 관련
        $obj.$cellForeColorRanges = []; // 컬러 설정 관련
        // 필터 만들기 -----------------------------------------------------------------------------------------------------------------------
        //var filter = new wijmo.grid.filter.FlexGridFilter($obj);
        //$obj.flexFilter = filter;
        // 컬럼선택 목록 보기 -----------------------------------------------------------------------------------------------------------------------
        var theColumnPickerDiv = $('<div style="display:none"><div id="' + $params.id + 'theColumnPicker" class="column-picker"></div></div>');

        var theColumnPicker = new wijmo.input.ListBox(theColumnPickerDiv, {
            itemsSource: $obj.columns,
            checkedMemberPath: 'visible',
            displayMemberPath: 'header',
            lostFocus: function () {
                wijmo.hidePopup(theColumnPicker.hostElement);
            }
        });
        // 우클릭 컨텐츠 정의 -----------------------------------------------------------------------------------------------------------------------
        var localStorage = {};
        var ctxMenu = new wijmo.input.Menu(document.createElement('div'));
        var hitTest;
        ctxMenu.itemsSource = '전체선택,영역선택,컬럼목록,컬럼너비맞춤,셀계산,엑셀내보내기'.split(',');
        ctxMenu.selectedIndexChanged.addHandler(function (e) {

            if (ctxMenu.selectedIndex == 0) { // 전체선택
                var $curflag = $obj.checkFlag;
                try {
                    for (var i = 0; i <= $obj.rows.length; i++) {
                        if ($obj.rows[i]._data._gd == undefined) {
                            $obj.rows[i]._data.isRowCheck = !$curflag;
                        }
                    }
                } catch (e) { }
                $obj.refresh();
                $obj.checkFlag = !$curflag;
            } else if (ctxMenu.selectedIndex == 1) { // 영역선택
                try {
                    for (var i = $obj.selection.row2; i <= $obj.selection.row; i++) {
                        if ($obj.rows[i]._data._gd == undefined) {
                            $obj.rows[i]._data.isRowCheck = !$obj.rows[i]._data.isRowCheck;
                        }
                    }
                } catch (e) { }
                $obj.refresh();
            } else if (ctxMenu.selectedIndex == 2) { // 컬럼 목록 보기
                var $left = $('#_dropdown').css('left');
                var $top = $('#_dropdown').css('top');
                wijmo.showPopup(theColumnPicker.hostElement, $obj.hostElement.querySelector('.dropdown'), false, true, false);
                theColumnPicker.focus();
                theColumnPicker.hostElement.style.left = $left;
                theColumnPicker.hostElement.style.top = $top;

            }
            //else if (ctxMenu.selectedIndex == 3) { // 현재 스타일 저장
            //    var state = {
            //        columns: $obj.columnLayout,
            //        filterDefinition: $obj.flexFilter.filterDefinition,
            //        sortDescriptions: $obj.collectionView.sortDescriptions.map(function (sortDesc) {
            //            return { property: sortDesc.property, ascending: sortDesc.ascending };
            //        })
            //    }
            //    var maria = new ItsMaria('SYSGRID', 'SAVE_GRIDSTYLE');
            //    maria.AddSessionUserId();
            //    maria.AddParam('PRGCD', ItsPage.name);
            //    maria.AddParam('GRIDID', $params.id);
            //    maria.AddParam('STYLEINFO', JSON.stringify(state));
            //    maria.CallProcCenter();
            //    if (maria.isError) {
            //        maria.ShowErrMsg();
            //        return;
            //    }
            //    $obj._$customStyle = JSON.stringify(state);
            //} else if (ctxMenu.selectedIndex == 4) { // 그리드 스타일 초기화
            //    var json = $obj._$initStyle;
            //    if (json) {
            //        var state = JSON.parse(json);
            //        $obj.columnLayout = state.columns;
            //        $obj.flexFilter.filterDefinition = state.filterDefinition;
            //        var view = $obj.collectionView;
            //        view.deferUpdate(function () {
            //            view.sortDescriptions.clear();
            //            for (var i = 0; i < state.sortDescriptions.length; i++) {
            //                var sortDesc = state.sortDescriptions[i];
            //                view.sortDescriptions.push(
            //                new wijmo.collections.SortDescription(sortDesc.property, sortDesc.ascending)
            //                );
            //            }
            //        });
            //        if ($obj.bandText.length > 0) { // 밴드기능
            //            var hr = new wijmo.grid.Row();
            //            hr.allowMerging = true;
            //            var ch = $obj.columnHeaders;
            //            ch.rows.splice(0, 1);
            //            ch.rows.splice(0, 0, hr);
            //            for (var i = 0; i < $obj.bandText.length; i++) {
            //                for (var j = 0; j < $obj.bandCol.length; j++) {
            //                    if ($obj.bandText[i] == $obj.bandCol[j].text) {
            //                        var $field = $obj.bandCol[j].field;
            //                        var $column = $obj.getColumn($field);
            //                        ch.setCellData(0, $column.index, $obj.bandText[i]);
            //                    }
            //                }
            //            }
            //            var $col = $obj.getColumn('isRowCheck');
            //            $col.allowMerging = true;
            //            ch.setCellData(0, $col.index, $col.header);
            //            for (var i = 0; i < $obj.notBandCol.length; i++) {
            //                var $col = $obj.getColumn($obj.notBandCol[i]);
            //                $col.allowMerging = true;
            //                ch.setCellData(0, $col.index, $col.header);
            //            }
            //        }
            //    }
            //    var maria = new ItsMaria('SYSGRID', 'DEL_GRIDSTYLE');
            //    maria.AddSessionUserId();
            //    maria.AddParam('PRGCD', ItsPage.name);
            //    maria.AddParam('GRIDID', $params.id);
            //    maria.CallProcCenter();
            //    if (maria.isError) {
            //        maria.ShowErrMsg();
            //        return;
            //    }
            //    $obj._$customStyle = undefined;

            //    // 콤보박스 컬럼
            //    comboColumn.forEach(function (col) {
            //        for (var i = 0; i < $obj.columns.length; i++) {
            //            if ($obj.columns[i]._binding != undefined) {
            //                if (col.field == $obj.columns[i]._binding._key) {
            //                    var $data = ItsGrid.$getGpcdData(col.gpcd, col.ref01, col.ref02, col.ref03, col.ref04, col.ref05, col.callCenter);
            //                    try {
            //                        var $dataMap = new wijmo.grid.DataMap($data, Object.keys($data[0])[1], Object.keys($data[0])[2]);
            //                        $obj.columns[i].dataMap = $dataMap;
            //                        $obj.columns[i].dataMap._originData = $data;
            //                    } catch (e) { }
            //                }
            //            }
            //        }
            //    });

            //}
            else if (ctxMenu.selectedIndex == 3) { // 컬럼너비 맞춤
                $obj.autoSizeColumns();
            } else if (ctxMenu.selectedIndex == 4) { // 셀 계산
                ItsGrid.$calculate($params.id);
            } else if (ctxMenu.selectedIndex == 5) { // 엑셀 내보내기
                ItsGrid.$export($obj);
            } else if (ctxMenu.selectedIndex == 6) { // 그리드 출력
                ItsGrid.$print($params.id);
            }
        });

        // 우클릭 했을때의 동작 -----------------------------------------------------------------------------------------------------------------------
        if ($params.contextMenu) {
            $obj.addEventListener($obj.hostElement, 'contextmenu', function (e) {
                hitTest = $obj.hitTest(e);
                if (hitTest.panel == $obj.cells) {
                    e.preventDefault();
                    ctxMenu.selectedIndex = -1;
                    wijmo.showPopup(ctxMenu.dropDown, e);
                    ctxMenu.dropDown.focus();
                }
            });
        }
        // row 넘버 표시, 셀 색상 설정-----------------------------------------------------------------------------------------------------------------------
        $obj.itemFormatter = function (p, r, c, cell) {

            if ($params.rowNumber) {
                if (p.cellType == wijmo.grid.CellType.RowHeader) {
                    if ($params.allowAddNew && $params.isTopAddNew) {
                        if (r == 0) {
                            cell.textContent = '+';
                        } else {
                            cell.textContent = r.toString();
                        }
                    } else if ($params.allowAddNew && !$params.isTopAddNew) {
                        if (p._rows.length - 1 == r) {
                            cell.textContent = '+';
                        } else {
                            cell.textContent = (r + 1).toString();
                        }
                    } else {
                        cell.textContent = (r + 1).toString();
                    }
                }
            }
            if (wijmo.grid.CellType.Cell === p.cellType && $obj.rows[r]._data != undefined) { // 색상지정
                cell.style.backgroundColor = 'white';
                cell.style.color = 'black';
                // column
                columns.forEach(function (col) {
                    if (col.type == 'column') {
                        try {
                            if (col.field == $obj.columns[c]._binding._key) {
                                if ($obj.columns[c].backColor == undefined) {
                                    cell.style.backgroundColor = col.backColor;
                                } else {
                                    cell.style.backgroundColor = $obj.columns[c].backColor;
                                }
                                if ($obj.columns[c].foreColor == undefined) {
                                    cell.style.color = col.foreColor;
                                } else {
                                    cell.style.color = $obj.columns[c].foreColor;
                                }
                            }
                        } catch (e) { }
                    } else if (col.type == 'band') {
                        col.columns.forEach(function (col2) {
                            try {
                                if (col2.field == $obj.columns[c]._binding._key) {
                                    cell.style.backgroundColor = col2.backColor;
                                    cell.style.color = col2.foreColor;
                                }
                            } catch (e) { }
                        });
                    }
                });
                for (var i = 0; i < columns.length; i++) {
                    try {
                        if (columns[i].field == $obj.columns[c]._binding._key) {
                            cell.style.backgroundColor = columns[i].backColor;
                            cell.style.color = columns[i].foreColor;
                        }
                    } catch (e) { }
                }
                // row
                if ($obj.rows[r]._data['BACKGROUND'] != null && $obj.rows[r]._data['BACKGROUND'] != '' && $obj.rows[r]._data['BACKGROUND'] != undefined) {
                    cell.style.backgroundColor = $obj.rows[r]._data['BACKGROUND'];
                }
                if ($obj.rows[r]._data['FOREGROUND'] != null && $obj.rows[r]._data['FOREGROUND'] != '' && $obj.rows[r]._data['FOREGROUND'] != undefined) {
                    cell.style.color = $obj.rows[r]._data['FOREGROUND'];
                }
                // cell
                for (var i = 0; i < $obj.$cellBackColorRanges.length; i++) {
                    if ($obj.$cellBackColorRanges[i].row == r && $obj.$cellBackColorRanges[i].col == c) {
                        cell.style.backgroundColor = $obj.$cellBackColorRanges[i].color;
                    }
                }
                for (var i = 0; i < $obj.$cellForeColorRanges.length; i++) {
                    if ($obj.$cellForeColorRanges[i].row == r && $obj.$cellForeColorRanges[i].col == c) {
                        cell.style.color = $obj.$cellForeColorRanges[i].color;
                    }
                }
                var $format = $obj.columns[c].format;
                if ($format != undefined && $format.substring(0, 1) == 'n') {
                    try {
                        if (parseFloat($obj.cells.getCellData(r, c, true).toString().replace(/[^0-9.-]/gi, '')) < 0) {
                            cell.style.color = 'tomato';
                        };
                    } catch (e) { }
                }
            }
            wijmo.grid.MergeManager.prototype.getMergedRange = function (panel, r, c, clip) {

                if (panel.cellType == 2) { // 헤더부
                    var rg = new wijmo.grid.CellRange(r, c);
                    for (var i = rg.col; i < panel.columns.length - 1; i++) {
                        if (panel.getCellData(rg.row, i, true) != panel.getCellData(rg.row, i + 1, true))
                            break;
                        rg.col2 = i + 1;
                    }
                    for (var i = rg.col; i > 0; i--) {
                        if (panel.getCellData(rg.row, i, true) != panel.getCellData(rg.row, i - 1, true))
                            break;
                        rg.col = i - 1;
                    }
                    for (var i = rg.row; i < panel.rows.length - 1; i++) {
                        if (panel.getCellData(i, rg.col, true) != panel.getCellData(i + 1, rg.col, true))
                            break;
                        rg.row2 = i + 1;
                    }
                    for (var i = rg.row; i > 0; i--) {
                        if (panel.getCellData(i, rg.col, true) != panel.getCellData(i - 1, rg.col, true))
                            break;
                        rg.row = i - 1;
                    }
                    return rg;
                } else if (panel.cellType == 1) { // 일반 row
                    var $cAm = false;
                    try {
                        $cAm = $obj.columns[c].customAllowMerging;
                    } catch (e) { }
                    var $format = 'format';
                    try {
                        $format = $obj.columns[c].format == undefined ? $format : $obj.columns[c].format;
                    } catch (e) { }

                    var $fm = true;
                    if ($format.substring(0, 1) == 'n') {
                        $fm = false;
                    }
                    if ($cAm && $fm) {
                        // create basic cell range
                        if ($params.colMerging) {
                            var rg = new wijmo.grid.CellRange(r, c);
                            for (var i = rg.col; i < panel.columns.length - 1; i++) {
                                if (panel.getCellData(rg.row, i, true) != panel.getCellData(rg.row, i + 1, true))
                                    break;
                                rg.col2 = i + 1;
                            }
                            for (var i = rg.col; i > 0; i--) {
                                if (panel.getCellData(rg.row, i, true) != panel.getCellData(rg.row, i - 1, true))
                                    break;
                                rg.col = i - 1;
                            }
                        }
                        if ($params.rowMerging) {
                            var rg = new wijmo.grid.CellRange(r, c);
                            for (var i = rg.row; i < panel.rows.length - 1; i++) {
                                if (panel.getCellData(i, rg.col, true) != panel.getCellData(i + 1, rg.col, true))
                                    break;
                                rg.row2 = i + 1;
                            }
                            for (var i = rg.row; i > 0; i--) {
                                if (panel.getCellData(i, rg.col, true) != panel.getCellData(i - 1, rg.col, true))
                                    break;
                                rg.row = i - 1;
                            }
                        }
                        return rg;
                    }
                }

            };
        };
        // 정렬 관련
        $obj.formatItem.addHandler(function (s, e) {
            if (e.cell.children.length == 0) {
                if ($obj.columns[e.col].width < parseInt(e.cell.style.width.replace('px', ''))) {
                    e.cell.innerHTML = '<div>' + e.cell.innerHTML + '</div>';
                    wijmo.setCss(e.cell, {
                        display: 'table',
                        tableLayout: 'fixed'
                    });
                    wijmo.setCss(e.cell.children[0], {
                        display: 'table-cell',
                        textAlign: 'center',
                        verticalAlign: 'middle'
                    });
                }
                if ($obj.columns[e.col].height < parseInt(e.cell.style.height.replace('px', ''))) {
                    e.cell.innerHTML = '<div>' + e.cell.innerHTML + '</div>';
                    wijmo.setCss(e.cell, {
                        display: 'table',
                        tableLayout: 'fixed'
                    });
                    wijmo.setCss(e.cell.children[0], {
                        display: 'table-cell',
                        verticalAlign: 'middle'
                    });
                }

            }
        });
        $obj.formatItem.addHandler(function (s, e) {
            setTimeout(function () {
                // 서브토탈 그룹 텍스트
                var gw = 0;
                var subtotalIcon = $('#' + $params.id).find('.wj-btn.wj-btn-glyph.wj-elem-collapse').parent();
                var glength = $('#' + $params.id).find('.wj-btn.wj-btn-glyph.wj-elem-collapse').eq(0).parent().text().length * 11;
                gw = glength;
                subtotalIcon.css('width', gw);
                subtotalIcon.css('z-index', 5);
                subtotalIcon.css('border-right', '0px');
            }, 0);
        })
        if ($params.isSubTotalGrid) {
            $obj.columnFooters.rows.push(new wijmo.grid.GroupRow());
            $obj.bottomLeftCells.setCellData(0, 0, '총');
        }
        // ------------------------------------------------------------------------------------------------------------------------------------------------

        try {
            $obj.refresh();
            if (ItsPage.gridStyle.data.length > 0) {
                var styleData = ItsPage.gridStyle.data.filterObjects("GRIDID", $params.id);
                if (styleData.length == 1) {
                    $obj._$customStyle = styleData[0]['STYLEINFO'];
                }
            }
        } catch (e) { }


        // ------------------------------------------------------------------------------------------------------------------------------------------------
        $obj.colMergingList = [];
        $obj.rowMergingList = [];
        // ------------------------------------------------------------------------------------------------------------------------------------------------
        $obj._ctxMenu = ctxMenu;
        $obj.checkFlag = false;
        $obj.ItsSelectKey = undefined;
        $obj.isSubTotalGrid = $params.isSubTotalGrid;
        $obj.groupField = $params.groupField;
        $obj.groupASC = $params.groupASC;
        this.list.push($obj);
        return $obj;
    },
    /**************************************************
     * grid: 제어 함수
     * 2018-01-15: 문재원: addkey(), getkey(), setkey() 추가
     * 2018-01-18: isSelect() 추가
     * 2018-02-13: isChecked() 추가
     * 2018-03-13: 색상 관련 함수 추가
     **************************************************/
    Get: function (id) {
        try {
            for (var i = 0; i < ItsGrid.list.length; i++) {
                if (id == ItsGrid.list[i]._e.id) {
                    return ItsGrid.list[i];
                }
            }
        } catch (e) { return undefined; }

    },
    Length: function (id) {
        var $obj = ItsGrid.Get(id);
        try {
            if ($obj.groupField != undefined) {
                return $obj.itemsSource.itemCount;
            } else {
                return $obj.itemsSource.length;
            }
        } catch (e) {
            return 0;
        }
    },
    Clear: function (id) {
        ItsGrid.SetStore(id, new Store());
        //ItsGrid.Get(id).itemsSource = [];
    },
    FinishEditing: function (id) {
        ItsGrid.Get(id).finishEditing(true);
    },
    GetStore: function (id) {
        var $obj = ItsGrid.Get(id);
        try {
            if ($obj.groupField != undefined) {
                return $obj.itemsSource.items;
            } else {
                return $obj.itemsSource;
            }
        } catch (e) {
            return 0;
        }
    },
    SetStore: function (id, store) {
        var $obj = ItsGrid.Get(id);
        $obj.$cellBackColorRanges = [];
        $obj.$cellForeColorRanges = [];
        store.data.forEach(function (row) {
            ItsGrid.Get(id).columns.forEach(function (col) {
                if (col.format == 'check' && typeof (row[col.binding]) != typeof (true)) {
                    row[col.binding] = false;
                }
            })
            if (row.isRowCheck == undefined) {
                row.isRowCheck = false;
            }
        });
        $obj.checkFlag = false;
        if ($obj.isSubTotalGrid && $obj.groupField != undefined) {

            if (typeof ($obj.groupField) == 'string') {

                var cv = new wijmo.collections.CollectionView(store.data);

                var sd = new wijmo.collections.SortDescription($obj.groupField, $obj.groupASC);
                var gd = new wijmo.collections.PropertyGroupDescription($obj.groupField);
                cv.sortDescriptions.push(sd);
                cv.groupDescriptions.push(gd);

                $obj.itemsSource = cv;

            } else if (typeof ($obj.groupField) == 'object') {

                var cv = new wijmo.collections.CollectionView(store.data);

                var sd = new wijmo.collections.SortDescription($obj.groupField, $obj.groupASC);
                var gd = new wijmo.collections.PropertyGroupDescription($obj.groupField);
                cv.sortDescriptions.push(sd);
                cv.groupDescriptions.push(gd);

                $obj.itemsSource = cv;
            }

        } else {
            $obj.itemsSource = store.data;
        }
        $obj.autoSizeColumn(0, store.data.length, true);
    },
    IsSelect: function (id) {
        if (ItsGrid.Get(id).selectedRows.length > 0) {
            return true;
        } else {
            return false;
        }
    },
    IsChecked: function (id, index) {
        var $obj = ItsGrid.Get(id);
        var $return = false;
        try {
            var $res = ItsGrid.GetValue(id, index, 'isRowCheck');
            if ($res == 'true' || $res == true) $return = true
            else $return = false;
            return $return;
        } catch (e) {
            return false;
        }
        return $return;
    },
    CheckRow: function (id, rowIndex) {
        ItsGrid.SetValue(id, rowIndex, 'isRowCheck', true);
    },
    UnCheckRow: function (id, rowIndex) {
        ItsGrid.SetValue(id, rowIndex, 'isRowCheck', false);
    },
    CheckAll: function (id) {
        var $obj = ItsGrid.Get(id);
        for (var i = 0; i < $obj.rows.length; i++) {
            if ($obj.rows[i]._data._gd == undefined) {
                $obj.rows[i]._data.isRowCheck = true;
            }
        }
        $obj.checkFlag = true;
        $obj.refresh();
    },
    UnCheckAll: function (id) {
        var $obj = ItsGrid.Get(id);
        for (var i = 0; i < $obj.rows.length; i++) {
            if ($obj.rows[i]._data._gd == undefined) {
                $obj.rows[i]._data.isRowCheck = false;
            }
        }
        $obj.checkFlag = false;
        $obj.refresh();
    },
    SelectRow: function (id, rowIndex) {
        var $obj = ItsGrid.Get(id);
        //if (rowIndex < 0) {
        //    return;
        //}
        if (rowIndex > ItsGrid.Length(id) - 1) {
            return;
        }
        var $i = 0;
        for (var i = 0; i < $obj.columns.length; i++) {
            if ($obj.columns[i].isVisible) {
                $i = i;
                break;
            }
        }
        $obj.select(rowIndex, $i);
    },
    SelectCell: function (id, rowIndex, field) {
        var $obj = ItsGrid.Get(id);
        if (rowIndex < 0) {
            return;
        }
        if (rowIndex > ItsGrid.Length(id) - 1) {
            return;
        }
        var $col = ItsGrid.$colIndex(id, field);
        if ($col > $obj.columns.length - 1) {
            return;
        }
        setTimeout(function () {
            $obj.select(rowIndex, $col);
        }, 1);

    },
    GetRowCurrent: function (id) {
        try {
            if (ItsGrid.Get(id).rows.length <= 0) {
                return;
            }
            var data = jQuery.extend(true, {}, ItsGrid.Get(id).rows[ItsGrid.Get(id).selection._row]._data);
            return data;
        } catch (e) {
            return -1;
        }
    },
    GetCurrentIndex: function (id) {
        var $obj = ItsGrid.Get(id);
        try {
            if ($obj.rows.length <= 0) {
                return -1;
            }
            if ($obj.groupField != undefined) {
                return $obj.itemsSource._idx;
            } else {
                return ItsGrid.Get(id).selection._row;
            }
        } catch (e) {
            return -1;
        }
    },
    GetRowData: function (id, index) {
        try {
            if (ItsGrid.Get(id).groupField != undefined) {
                var data = jQuery.extend(true, {}, ItsGrid.Get(id).itemsSource.items[index]);
            } else {
                var data = jQuery.extend(true, {}, ItsGrid.Get(id).rows[index]._data);
            }
            return data;
        } catch (e) {
            return;
        }
    },
    SetRowData: function (id, index, data) {
        var $obj = ItsGrid.Get(id);
        var $keys = Object.keys(data);
        for (var i = 0; i < $keys.length; i++) {
            try {
                ItsGrid.SetValue(id, index, $keys[i], data[$keys[i]]);
            } catch (e) { }
        }
        $obj.refresh();
    },
    GetValue: function (id, index, field) {

        try {
            if (ItsGrid.Get(id).groupField != undefined) {
                var $value = ItsGrid.Get(id).itemsSource.items[index][field];
            } else {
                var $value = ItsGrid.Get(id).rows[index]._data[field];
            }
            try {
                var $format = ItsGrid.Get(id).columns[ItsGrid.$colIndex(id, field)].format;
                if ($format != undefined && $format.substring(0, 1) == 'n') {
                    try {
                        $value = parseFloat($value.toString().replace(/[^0-9.-]/gi, ''));
                    } catch (e) {
                        $value = '';
                    }
                    if (isNaN($value)) $value = 0;
                }
                var $mask = ItsGrid.Get(id).columns[ItsGrid.$colIndex(id, field)].mask;
                if ($mask != undefined) {
                    if ($value == $mask.replace(/0/gi, '_')) {
                        $value = '';
                    }
                }
            } catch (e) {

            }
            return $value;
        } catch (e) {
            return;
        }
    },
    GetRefValue: function (id, rowIndex, field, refName) {
        var $obj = ItsGrid.Get(id);
        if ($obj.columns[ItsGrid.$colIndex(id, field)].dataMap == undefined) {
            return "";
        }
        var $data = $obj.columns[ItsGrid.$colIndex(id, field)].dataMap._originData;
        var $value = ItsGrid.GetValue(id, rowIndex, field);
        var $refValue = "";
        $data.forEach(function (d) {
            if (d['Value'] == $value) {
                $refValue = d[refName];
            }
        })
        return $refValue;
    },
    GetValueByRefValue: function (id, field, refName, refValue) {
        var $obj = ItsGrid.Get(id);
        if ($obj.columns[ItsGrid.$colIndex(id, field)].dataMap == undefined) {
            return "";
        }
        var $data = $obj.columns[ItsGrid.$colIndex(id, field)].dataMap._originData;
        var $value = "";

        $data.forEach(function (d) {
            if (d[refName] == refValue) {
                $value = d['Value'];
            }
        })
        return $value;
    },
    SetValueByRefValue: function (id, rowIndex, field, refName, refValue) {
        var $obj = ItsGrid.Get(id);
        if ($obj.columns[ItsGrid.$colIndex(id, field)].dataMap == undefined) {
            return "";
        }
        var $data = $obj.columns[ItsGrid.$colIndex(id, field)].dataMap._originData;
        var $value = "";

        $data.forEach(function (d) {
            if (d[refName] == refValue) {
                $value = d['Value'];
            }
        })
        if ($value == "") return;

        ItsGrid.SetValue(id, rowIndex, field, $value);
    },
    SetValue: function (id, index, field, value) {
        var $obj = ItsGrid.Get(id);
        var $oldValue = ItsGrid.GetValue(id, index, field);
        try {
            if (ItsGrid.$colIndex(id, field) > -1) {
                var $format = ItsGrid.Get(id).columns[ItsGrid.$colIndex(id, field)].format;
                if ($format != undefined && $format.substring(0, 1) == 'n') {
                    if (isNaN(value)) value = 0;
                }
            }

            if (ItsGrid.Get(id).groupField != undefined) {
                $obj.itemsSource.items[index][field] = value;
                $obj.refresh();
            } else {
                $obj.rows[index].dataItem[field] = value;
                $obj.refresh();
                //$obj.cells.setCellData(index, ItsGrid.$colIndex(id, field), value);
            }

        } catch (e) { }
    },
    SetColumnName: function (id, index, text) {
        try {
            var $obj = ItsGrid.Get(id);
            $obj.columnHeaders.setCellData(0, index, text);
        } catch (e) { }
    },
    AddRow: function (id, startEdit, rowData) {
        var $obj = ItsGrid.Get(id);
        if (startEdit == undefined) {
            startEdit = ItsGrid.Length(id) + 1;
        }
        if (rowData == undefined) {
            rowData = { isRowCheck: false };
        }
        if (ItsGrid.Length(id) < 1) {
            ItsGrid.SetStore(id, { data: [rowData] });
            return;
        } else {
            var $new_store = new Store();
            $new_store.data = $obj.itemsSource;
            $new_store.data.splice(startEdit, 0, rowData);
            ItsGrid.Clear(id);
            ItsGrid.SetStore(id, $new_store);
        }
    },
    ClearRow: function (id, index) {
        ItsGrid.RemoveRow(id, index);
        ItsGrid.AddRow(id, index);
    },
    RemoveRow: function (id, index) {
        var $obj = ItsGrid.Get(id);
        var $new_store = new Store();
        $new_store.data = $obj.itemsSource;
        $new_store.data.splice(index, 1);
        ItsGrid.Clear(id);
        ItsGrid.SetStore(id, $new_store);
    },
    Addkey: function (id, key) {
        alert('addkey기능 삭제, setkey로 대체 합니다.');
    },
    Setkey: function (id, keyField, keyValue) {
        var $obj = ItsGrid.Get(id);
        $obj.ItsSelectKey = {};
        $obj.ItsSelectKey[keyField] = keyValue;
    },
    Getkey: function (id) {
        var $obj = ItsGrid.Get(id);
        return $obj.ItsSelectKey;
    },
    // 색상 관련
    SetCellBackColor: function (id, rowIdx, field, color) {
        var $obj = ItsGrid.Get(id);
        $obj.$cellBackColorRanges.push({ row: rowIdx, col: ItsGrid.$colIndex(id, field), color: color });
        $obj.refresh();
    },
    SetCellForeColor: function (id, rowIdx, field, color) {
        var $obj = ItsGrid.Get(id);
        $obj.$cellForeColorRanges.push({ row: rowIdx, col: ItsGrid.$colIndex(id, field), color: color });
        $obj.refresh();
    },
    SetColumnBackColor: function (id, field, color) {
        alert('함수 삭제 예정, 컬럼의 속성으로 사용하세요');
    },
    SetColumnForeColor: function (id, field, color) {
        alert('함수 삭제 예정, 컬럼의 속성으로 사용하세요');
    },
    SetColumnName: function (id, index, text) {
        ItsGrid.Get(id).columns[index].header = text;
    },
    SetRowBackColor: function (id, rowIdx, color) {
        var $obj = ItsGrid.Get(id);
        try {
            ItsGrid.SetValue(id, rowIdx, 'BACKGROUND', color);
            $obj.refresh();
        } catch (e) { }
    },
    SetRowForeColor: function (id, rowIdx, color) {
        var $obj = ItsGrid.Get(id);
        try {
            ItsGrid.SetValue(id, rowIdx, 'FOREGROUND', color);
            $obj.refresh();
        } catch (e) { }
    },
    Focus: function (id, rowIndex, colIndex) {
        var $obj = ItsGrid.Get(id);
        setTimeout(function () {
            if (rowIndex != undefined && colIndex != undefined) {
                $obj.select(rowIndex, colIndex);
            }
            $obj.hostElement.focus();
        }, 0);
    },
    // 우클릭시의 동작들
    Print: function (id) {
        ItsGrid.$print(id);
    },
    Export: function (id) {
        var $obj = ItsGrid.Get(id);
        ItsGrid.$export($obj);
    },
    /** 
    @returns {ItsGrid.Listener} 
    */
    Event: function (key) {
        if (ItsPage.EventList[key] == undefined) {
            ItsPage.EventList[key] = new ItsGrid.Listener();
        }
        return ItsPage.EventList[key];
    },
    Listener: function () {
        this.onChanged = function (rowIndex, field, newValue, oldValue, type) { };
        //this.onPastingCell = function (rowIndex, field, newValue, oldValue) { };
        this.onBeginningEdit = function (rowIndex, field, value) { };
        this.onSelect = function (rowIndex, field) { };
        this.onButtonClick = function (rowIndex, field) { };
        this.onDoubleClick = function (rowIndex, field) { };
        this.onKeydownEnter = function (rowIndex, field) { };
        this.onKeydown = function (rowIndex, field, keyCode, ctrlKey, shiftKey, altKey) { };
    }
};
/**************************************************
 * grid: 내부 함수
 * 2018-01-15: 문재원: $searchSelect() 추가 key로 해당 index 찾아서 선택하기
 **************************************************/
ItsGrid.$colIndex = function (id, fieldName) {
    var $obj = ItsGrid.Get(id);
    for (var i = 0; i < $obj.columns.length; i++) {
        if (fieldName == $obj.columns[i]._binding._key) {
            return i;
        }
    }
    return -1;
}
ItsGrid.$GetRowIndex = function (id) {
    var $obj = ItsGrid.Get(id);
    if ($obj.groupField != undefined) {
        return $obj.itemsSource._idx;
    } else {
        return ItsGrid.GetCurrentIndex(id);
    }
}

ItsGrid.$print = function (id) {
    var $obj = ItsGrid.Get(id);
    // *로 너비를 준 컬럼이 있을 시 오류 발생하므로 size로 대체 작업 해줌
    $obj.columns.forEach(function (col) {
        if (typeof (col.width) != typeof (1)) {
            col.width = col.size;
        }
    });

    var fontFile = {
        source: '../../fonts/malgun.ttf',
        name: "malgun",
        style: "normal",
        weight: "normal",
        sansSerif: true
    },
        font = new wijmo.pdf.PdfFont('malgun');
    wijmo.grid.pdf.FlexGridPdfConverter.export($obj, ItsHelper.GetDateFull().replace(/[^0-9.-]/gi, '') + '_' + ItsPage.name + '.pdf', {
        maxPages: 10,
        scaleMode: wijmo.grid.pdf.ScaleMode.PageWidth,
        documentOptions: {
            compress: false,
            header: { declarative: { text: ItsPage.name + ' ' + id + ' ' + ItsHelper.GetDateFull() } },
            footer: { declarative: { text: '\t&[Page] of &[Pages]' } },
            info: { author: 'C1', title: ItsPage.name }
        },
        styles: {
            cellStyle: { backgroundColor: '#ffffff', borderColor: '#c6c6c6', font: font },
            altCellStyle: { backgroundColor: '#f9f9f9', font: font },
            groupCellStyle: { backgroundColor: '#dddddd', font: font },
            headerCellStyle: { backgroundColor: '#eaeaea', font: font }
        },
        embeddedFonts: [fontFile]
    });
};
ItsGrid.$export = function (obj) {

    var book = wijmo.grid.xlsx.FlexGridXlsxConverter.save(obj, {
        includeColumnHeaders: true,
        includeRowHeaders: true
    });
    book.sheets[0].name = 'sheet1';

    book.save(ItsPage.name + '.xlsx');
};
ItsGrid.RenderTable = function (flex) {
    var tbl = '<table>';
    if (flex.headersVisibility & wijmo.grid.HeadersVisibility.Column) {
        tbl += '<thead>';
        for (var r = 0; r < flex.columnHeaders.rows.length; r++) {
            tbl += ItsGrid.RenderRow(flex.columnHeaders, r);
        }
        tbl += '</thead>';
    }
    tbl += '<tbody>';
    for (var r = 0; r < flex.rows.length; r++) {
        tbl += ItsGrid.RenderRow(flex.cells, r);
    }
    tbl += '</tbody>';
    tbl += '</table>';
    return tbl;
}
ItsGrid.RenderRow = function (panel, r) {
    var tr = '',
        row = panel.rows[r];
    if (row.renderSize > 0) {
        tr += '<tr>';
        for (var c = 0; c < panel.columns.length; c++) {
            var col = panel.columns[c];
            if (col.renderSize > 0) {

                // get cell style, content
                var style = 'width:' + col.renderSize + 'px;' +
                    'text-align:' + col.getAlignment() + ';' +
                    'padding-right: 6px';
                var content = panel.getCellData(r, c, true);
                if (!row.isContentHtml && !col.isContentHtml) {
                    content = wijmo.escapeHtml(content);
                }

                // add cell to row
                if (panel.cellType == wijmo.grid.CellType.ColumnHeader) {
                    tr += '<th style="' + style + '">' + content + '</th>';
                } else {

                    // show boolean values as checkboxes
                    var raw = panel.getCellData(r, c, false);
                    if (raw === true) {
                        content = '&#9745;';
                    } else if (raw === false) {
                        content = '&#9744;';
                    }

                    tr += '<td style="' + style + '">' + content + '</td>';
                }
            }
        }
        tr += '</tr>';
    }
    return tr;
}
ItsGrid.$calculate = function (id) {
    ItsPage.InitData('gridCalc');
    var $obj = ItsGrid.Get(id);
    var $selection = $obj.selection;
    var SELECTCELL = 0;
    var NUMBERCELL = 0;
    var SUM = 0;
    var AVG = 0;
    var MAX = 0;
    var MIN = 99999999999;
    for (var r = $selection.topRow; r < $selection.bottomRow + 1; r++) {
        for (var c = $selection.leftCol; c < $selection.rightCol + 1; c++) {
            if ($obj.columns[c].format != undefined && $obj.columns[c].format.substring(0, 1) == 'n') {
                NUMBERCELL = NUMBERCELL + 1;
                var $val = parseFloat($obj.cells.getCellData(r, c, true).replace(/[,]/gi, ''));
                SUM = SUM + $val;
                if (MAX < $val) MAX = $val;
                if (MIN > $val) MIN = $val;
            }
            SELECTCELL = SELECTCELL + 1;
        }
    }
    if (MIN == 99999999999) MIN = 0;
    AVG = SUM / NUMBERCELL;
    var regexp = /\B(?=(\d{3})+(?!\d))/g;
    var $data = {
        SELECTCELL: SELECTCELL.toString().replace(regexp, ','),
        NUMBERCELL: NUMBERCELL.toString().replace(regexp, ','),
        SUM: SUM.toString().replace(regexp, ','),
        AVG: AVG.toString().replace(regexp, ','),
        MAX: MAX.toString().replace(regexp, ','),
        MIN: MIN.toString().replace(regexp, ',')
    };
    ItsPage.SetStore('gridCalc', $data);
    ItsPop.Open('gridCalc');
};
ItsGrid.$getGpcdData = function (gpcd, ref01, ref02, ref03, ref04, ref05, callCenter) {
    if (gpcd.substring(0, 6).toUpperCase() == 'SELECT') {
        var maria = new ItsMaria();
        maria.AddQuery(gpcd);
        if (callCenter) {
            maria.QueryCenter();
        } else {
            maria.Query();
        }
        if (maria.isError) {
            alert(maria.errMessage);
            if (maria.errMessage.indexOf('session expired') > -1 || maria.errMessage.indexOf('ERROR:로그인 세션이 끊겼습니다.') > -1 || maria.errMessage.indexOf('Unable to connect to any of the specified MySQL hosts.') > -1) {
                parent.location.replace('/PAGECOM/LOGIN/login.html');
                return;
            }
        } else {
            return maria.store.data;
        };
    }
    else {
        var maria = new ItsMaria('DC_COMBO');
        maria.AddParam('GPCD', gpcd);
        maria.AddParam('REF01', ref01);
        maria.AddParam('REF02', ref02);
        maria.AddParam('REF03', ref03);
        maria.AddParam('REF04', ref04);
        maria.AddParam('REF05', ref05);
        maria.AddQuery("CALL DC_COMBO(\'" + gpcd + "\',\'" + ref01 + "\',\'" + ref02 + "\',\'" + ref03 + "\',\'" + ref04 + "\',\'" + ref05 + "\')");
        if (callCenter) {
            maria.CallProcCenter();
        } else {
            maria.CallProc();
        }
        if (maria.isError) {
            alert(maria.errMessage);
            if (maria.errMessage.indexOf('session expired') > -1 || maria.errMessage.indexOf('ERROR:로그인 세션이 끊겼습니다.') > -1 || maria.errMessage.indexOf('Unable to connect to any of the specified MySQL hosts.') > -1) {
                parent.location.replace('/PAGECOM/LOGIN/login.html');
                return;
            }
        } else {
            return maria.store.data;
        };
    }
}
/********************************************
 * >>>>> column: 그리드 컬럼 컨트롤 >>>>>
 * 2017-11-01: 문재원: 최초 작성
 *******************************************/
var column = {
    list: [],
    /**
     * @param {String} label
     * @param {String} field
     * @param {_columnParams} params
     */
    create: function (label, field, params) {

        var $params = new _columnParams();
        ItsHelper.CopyObj(params, $params);

        if ($params.columnType == enumColumnTypes.text) {
            if ($params.align == undefined) {
                $params.align = 'left';
            }

        } else if ($params.columnType == enumColumnTypes.number) {
            $params.format = 'n' + parseInt($params.decimalPrecision).toString();
            if ($params.align == undefined) {
                $params.align = 'right';
            }
        } else if ($params.columnType == enumColumnTypes.date) {
            $params.format = 'd';
            if ($params.align == undefined) {
                $params.align = 'left';
            }
        } else if ($params.columnType == enumColumnTypes.check) {
            $params.format = 'check';
            $params.align = 'center';
        } else if ($params.columnType == enumColumnTypes.button) {
            $params.align = 'center';
            $params.buttonClass = 'fa ' + $params.iconCls;
        } else if ($params.columnType == enumColumnTypes.combo) {
            if ($params.align == undefined) {
                $params.align = 'left';
            }
            if ($params.gpcd == '') {
                alert('combo column must have \'gpcd\' attribute.');
            }
        } else if ($params.columnType == enumColumnTypes.find) {
            if ($params.align == undefined) {
                $params.align = 'left';
            }
        }
        if (($params.backColor == 'white' && $params.readOnly == false) || $params.columnType == enumColumnTypes.find) {
            $params.backColor = '#f4fdff';
        }
        var $obj = {
            header: label,
            binding: field,
            width: $params.width,
            isReadOnly: $params.readOnly,
            allowMerging: $params.allowMerging,
            visible: !$params.hidden,
            format: $params.format,
            mask: $params.mask,
            align: $params.align,
            aggregate: $params.groupType,
            allowDragging: $params.allowDragging
        }
        this.list.push($obj);
        return {
            colObj: $obj,
            foreColor: $params.foreColor,
            backColor: $params.backColor,
            field: field, type: 'column',
            editType: $params.columnType,
            mask: $params.mask,
            buttonClass: $params.buttonClass,
            gpcd: $params.gpcd,
            ref01: $params.ref01,
            ref02: $params.ref02,
            ref03: $params.ref03,
            ref04: $params.ref04,
            ref05: $params.ref05,
            callCenter: $params.callCenter
        };
    },
    /**
     * @param {String} label
     * @param {_bandParams} params
     * @param {Object[]} columns
     */
    band: function (label, params, columns) {

        var $band = {
            text: label,
            columns: columns,
            type: 'band'
        };
        this.list.push($band);
        return $band;
    },
    split: function () {

        var $split = {
            width: '*',
            binding: '-',
            header: '-',
            isReadOnly: true
        };
        this.list.push($split);
        return {
            colObj: $split,
            field: '-', type: 'column',
        };
    }
};
/**************************************************
 * column: 내부 함수
 * 2017-12-18: 문재원: $setColumnCheck 추가 (그리드 체크박스 처리)
 **************************************************/
//column.$gpcd = function(gpcd, ref01, ref02, ref03, ref04, ref05, callCenter) {
//};
/**************************************************
 * grid: 커스텀에디터
 **************************************************/
var CustomGridEditor = /** @class */ (function () {
    /**
     * Initializes a new instance of a CustomGridEditor.
     */
    function CustomGridEditor(flex, binding, edtClass, options) {
        var _this = this;
        // save references
        this._grid = flex;
        this._col = flex.columns.getColumn(binding);
        // create editor
        this._ctl = new edtClass(document.createElement('div'), options);
        // connect grid events
        flex.beginningEdit.addHandler(this._beginningEdit, this);
        flex.sortingColumn.addHandler(function () {
            var ecv = _this._grid.editableCollectionView;
            if (ecv) {
                ecv.commitEdit();
            }
        });
        flex.scrollPositionChanged.addHandler(function () {
            if (_this._ctl.containsFocus()) {
                flex.focus();
            }
        });
        // connect editor events
        this._ctl.addEventListener(this._ctl.hostElement, 'keydown', function (e) {
            switch (e.keyCode) {
                case wijmo.Key.Tab:
                case wijmo.Key.Enter:
                    e.preventDefault(); // TFS 255685
                    _this._closeEditor(true);
                    _this._grid.focus();
                    // forward event to the grid so it will move the selection
                    var evt = document.createEvent('HTMLEvents');
                    evt.initEvent('keydown', true, true);
                    'altKey,metaKey,ctrlKey,shiftKey,keyCode'.split(',').forEach(function (prop) {
                        evt[prop] = e[prop];
                    });
                    _this._grid.hostElement.dispatchEvent(evt);
                    break;
                case wijmo.Key.Escape:
                    _this._closeEditor(false);
                    _this._grid.focus();
                    break;
            }
        });
        // close the editor when it loses focus
        this._ctl.lostFocus.addHandler(function () {
            setTimeout(function () {
                if (!_this._ctl.containsFocus()) {
                    _this._closeEditor(true); // apply edits and close editor
                    _this._grid.onLostFocus(); // commit item edits if the grid lost focus
                }
            });
        });
        // commit edits when grid loses focus
        this._grid.lostFocus.addHandler(function () {
            setTimeout(function () {
                if (!_this._grid.containsFocus() && !CustomGridEditor._isEditing) {
                    var ecv = _this._grid.editableCollectionView;
                    if (ecv) {
                        ecv.commitEdit();
                    }
                }
            });
        });
        // open drop-down on f4/alt-down
        this._grid.addEventListener(this._grid.hostElement, 'keydown', function (e) {
            // open drop-down on f4/alt-down
            _this._openDropDown = false;
            if (e.keyCode == wijmo.Key.F4 ||
                (e.altKey && (e.keyCode == wijmo.Key.Down || e.keyCode == wijmo.Key.Up))) {
                var colIndex = _this._grid.selection.col;
                if (colIndex > -1 && _this._grid.columns[colIndex] == _this._col) {
                    _this._openDropDown = true;
                    _this._grid.startEditing(true);
                    e.preventDefault();
                }
            }
            // commit edits on Enter (in case we're at the last row, TFS 268944)
            if (e.keyCode == wijmo.Key.Enter) {
                var ecv = _this._grid.editableCollectionView;
                if (ecv && ecv.currentEditItem) {
                    ecv.commitEdit();
                }
            }
        }, true);
        // close editor when user resizes the window
        // REVIEW: hides editor when soft keyboard pops up (TFS 326875)
        window.addEventListener('resize', function () {
            if (_this._ctl.containsFocus()) {
                _this._closeEditor(true);
                _this._grid.focus();
            }
        });
    }
    Object.defineProperty(CustomGridEditor.prototype, "control", {
        // gets an instance of the control being hosted by this grid editor
        get: function () {
            return this._ctl;
        },
        enumerable: true,
        configurable: true
    });
    // handle the grid's beginningEdit event by canceling the built-in editor,
    // initializing the custom editor and giving it the focus.
    CustomGridEditor.prototype._beginningEdit = function (grid, args) {
        var _this = this;
        // check that this is our column
        if (grid.columns[args.col] != this._col) {
            return;
        }
        // check that this is not the Delete key
        // (which is used to clear cells and should not be messed with)
        var evt = args.data;
        if (evt && evt.keyCode == wijmo.Key.Delete) {
            return;
        }
        // cancel built-in editor
        args.cancel = true;
        // save cell being edited
        this._rng = args.range;
        CustomGridEditor._isEditing = true;
        // initialize editor host
        var rcCell = grid.getCellBoundingRect(args.row, args.col), rcBody = document.body.getBoundingClientRect(), ptOffset = new wijmo.Point(-rcBody.left, -rcBody.top), zIndex = (args.row < grid.frozenRows || args.col < grid.frozenColumns) ? '3' : '';
        wijmo.setCss(this._ctl.hostElement, {
            position: 'absolute',
            left: rcCell.left - 1 + ptOffset.x,
            top: rcCell.top - 1 + ptOffset.y,
            width: rcCell.width + 1,
            height: grid.rows[args.row].renderHeight + 1,
            borderRadius: '0px',
            zIndex: zIndex,
        });
        // initialize editor content
        if (!wijmo.isUndefined(this._ctl['text'])) {
            this._ctl['text'] = grid.getCellData(this._rng.row, this._rng.col, true);
        }
        else {
            throw 'Can\'t set editor value/text...';
        }
        // start editing item
        var ecv = grid.editableCollectionView, item = grid.rows[args.row].dataItem;
        if (ecv && item) {
            setTimeout(function () {
                ecv.editItem(item);
            }, 50); // wait for the grid to commit edits after losing focus
        }
        // activate editor
        document.body.appendChild(this._ctl.hostElement);
        this._ctl.focus();
        setTimeout(function () {
            // get the key that triggered the editor
            var key = (evt && evt.charCode > 32)
                ? String.fromCharCode(evt.charCode)
                : null;
            // get input element in the control
            var input = _this._ctl.hostElement.querySelector('input');
            // send key to editor
            if (input) {
                if (key) {
                    input.value = key;
                    wijmo.setSelectionRange(input, key.length, key.length);
                    var evtInput = document.createEvent('HTMLEvents');
                    evtInput.initEvent('input', true, false);
                    input.dispatchEvent(evtInput);
                }
                else {
                    input.select();
                }
            }
            // give the control focus
            if (!input && !_this._openDropDown) {
                _this._ctl.focus();
            }
            // open drop-down on F4/alt-down
            if (_this._openDropDown && _this._ctl instanceof wijmo.input.DropDown) {
                _this._ctl.isDroppedDown = true;
                _this._ctl.dropDown.focus();
            }
        }, 50);
    };
    // close the custom editor, optionally saving the edits back to the grid
    CustomGridEditor.prototype._closeEditor = function (saveEdits) {
        if (this._rng) {
            var grid = this._grid, ctl = this._ctl, host = ctl.hostElement;
            // raise grid's cellEditEnding event
            var e = new wijmo.grid.CellEditEndingEventArgs(grid.cells, this._rng);
            grid.onCellEditEnding(e);
            // save editor value into grid
            if (saveEdits) {
                if (!wijmo.isUndefined(ctl['value'])) {
                    this._grid.setCellData(this._rng.row, this._rng.col, ctl['value']);
                }
                else if (!wijmo.isUndefined(ctl['text'])) {
                    this._grid.setCellData(this._rng.row, this._rng.col, ctl['text']);
                }
                else {
                    throw 'Can\'t get editor value/text...';
                }
                this._grid.invalidate();
            }
            // close editor and remove it from the DOM
            if (ctl instanceof wijmo.input.DropDown) {
                ctl.isDroppedDown = false;
            }
            host.parentElement.removeChild(host);
            this._rng = null;
            CustomGridEditor._isEditing = false;
            // raise grid's cellEditEnded event
            grid.onCellEditEnded(e);
        }
    };
    return CustomGridEditor;
}());