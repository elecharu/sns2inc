/// <reference path="../../Script/reference.js" />

/* 페이지 로드 시 수행 */
ItsPage.Load = function () {
    /* 그리드 생성 */
    ItsGrid.Create('grid1', { isCheckBoxGrid: true, isSubTotalGrid: true, groupField: 'GRP' }, [
        column.create("패키지", "PKGTP", { width: 100, align: 'center', columnType: enumColumnTypes.combo, gpcd: 'PKGTP_E' }),        
        column.create("카테고리", "CATENM", { width: 100, align: 'center' }),
        column.create("프로그램코드", "PRGCD", { width: 100, align: 'center' }),
        column.create("화면명", "MENUNM", { width: 180, columnType: enumColumnTypes.find, readOnly: false }),
        column.create("작업상태", "PRGSTT", { width: 70, readOnly: false, columnType: enumColumnTypes.combo, gpcd: 'PRGSTT_E' }),
        column.create("순번", "SORTNO", { width: 50, readOnly: false, columnType: enumColumnTypes.number }),
        column.create("작업자", "DEV", { width: 70, readOnly: false, align: 'center' }),
        // 2026-11-16 현장프로그램(TML) 메뉴타일 색·아이콘. 비우면 현장프로그램이 화면명으로 자동 지정
        column.create("타일색", "TILECOLOR", { width: 80, readOnly: false, align: 'center', columnType: enumColumnTypes.combo, gpcd: 'TMLCOLOR' }),
        column.create("타일아이콘", "TILEICON", { width: 110, readOnly: false, align: 'center', columnType: enumColumnTypes.combo, gpcd: 'TMLICON' }),
        column.create("진행률(%)", "RATE", { width: 70, readOnly: false, columnType: enumColumnTypes.number, groupType: enumGrouping.avg }),
        column.create("작업시작일", "STRDT", { width: 90, readOnly: false, columnType: enumColumnTypes.date }),
        column.create("완료예정일", "ENDDT", { width: 90, readOnly: false, columnType: enumColumnTypes.date }),
        column.create("승인", "CONFIRMYN", { width: 50, readOnly: false, columnType: enumColumnTypes.check }),
        column.create("승인자", "CONFIRMEMPCD", { width: 70, columnType: enumColumnTypes.combo, gpcd: 'EMPCD' }),
        column.create("승인일", "CONFIRMDT", { width: 90 }),
        column.create("요청사항", "REQUEST", { width: 200, readOnly: false }),

        column.create("이동", "MOVEPRG", { width: 70, columnType: enumColumnTypes.button, iconCls: 'fa-external-link' }),
        column.create("비고", "SHOWREMARK", { width: 70, columnType: enumColumnTypes.button, iconCls: 'fa-search' }),
        column.create("비고-", "REMARK", { width: '*' }),
    ]);

    SetTileComboHtml('grid1');

    ItsButton.EventSearch();
};

/* 2026-11-16 타일색·타일아이콘 콤보 : 이름 앞에 실제 색 견본 / 아이콘을 같이 보여준다 (드롭다운·셀 모두)
   공통코드 REF01 = 색(#RRGGBB) / 아이콘(Segoe MDL2 Assets 글자코드 16진수). 조회 실패하면 기본 콤보(이름만) 그대로 */
/* 글꼴에 없는 아이콘 : 공통코드 TMLICON 의 REF01 이 이 이름이면 직접 그린다 (현장프로그램 TMLMAIN 의 TileShapes 와 같은 모양) */
/* vb = 그림 영역(viewBox), fill = 면(짝홀 규칙), stroke = 선(둥근 끝), sw = 선 굵기, rot = 회전 '각도 중심x 중심y' */
var TILE_SHAPES = {
    // 트럭에 상자가 쌓인 모양 (짐칸 상자 5개 + 운전석 + 바퀴 2개)
    TRUCK: {
        vb: '0 0 31 24.2',
        fill: 'M3,0 h6 v6 h-6 Z M10,0 h6 v6 h-6 Z M0,7 h6 v6 h-6 Z M7,7 h6 v6 h-6 Z M14,7 h6 v6 h-6 Z'
         + ' M0,14 h20 v4 h-20 Z M21,7 h6 l4,5 v6 h-10 Z M22.5,8.5 h3.8 l2.7,3.5 h-6.5 Z'
         + ' M3.5,21 a3.2,3.2 0 1 0 6.4,0 a3.2,3.2 0 1 0 -6.4,0 Z M5.4,21 a1.3,1.3 0 1 0 2.6,0 a1.3,1.3 0 1 0 -2.6,0 Z'
         + ' M21.5,21 a3.2,3.2 0 1 0 6.4,0 a3.2,3.2 0 1 0 -6.4,0 Z M23.4,21 a1.3,1.3 0 1 0 2.6,0 a1.3,1.3 0 1 0 -2.6,0 Z'
    },
    // 손수레에 상자 2개 (상자 2개 + 바퀴는 면, 손잡이·기둥·바닥판은 선). 뒤로 14도 기울임
    HANDTRUCK: {
        vb: '-3.6 -1.3 33.8 35.2',
        fill: 'M10.2,11 H23.8 A1.2,1.2 0 0 1 25,12.2 V21.5 A1.2,1.2 0 0 1 23.8,22.7 H10.2 A1.2,1.2 0 0 1 9,21.5 V12.2 A1.2,1.2 0 0 1 10.2,11 Z'
         + ' M14.2,14 H19.8 A1.2,1.2 0 0 1 21,15.2 A1.2,1.2 0 0 1 19.8,16.4 H14.2 A1.2,1.2 0 0 1 13,15.2 A1.2,1.2 0 0 1 14.2,14 Z'
         + ' M11.2,0.5 H22.8 A1.2,1.2 0 0 1 24,1.7 V8.6 A1.2,1.2 0 0 1 22.8,9.8 H11.2 A1.2,1.2 0 0 1 10,8.6 V1.7 A1.2,1.2 0 0 1 11.2,0.5 Z'
         + ' M14.2,3.2 H19.8 A1.2,1.2 0 0 1 21,4.4 A1.2,1.2 0 0 1 19.8,5.6 H14.2 A1.2,1.2 0 0 1 13,4.4 A1.2,1.2 0 0 1 14.2,3.2 Z'
         + ' M1.6,28.6 A3.4,3.4 0 1 0 8.4,28.6 A3.4,3.4 0 1 0 1.6,28.6 Z M3.7,28.6 A1.3,1.3 0 1 0 6.3,28.6 A1.3,1.3 0 1 0 3.7,28.6 Z',
        stroke: 'M1,1.4 H4.6 Q6.2,1.4 6.2,3 V22 Q6.2,24.6 8.8,24.6 H27',
        sw: 2.8,
        rot: '-14 14 16'
    },
    // 상자 1개 (입체 : 윗면 + 왼쪽면 + 오른쪽면, 윗면에 U자 테이프 홈)
    BOX: {
        vb: '2 0 28 31',
        fill: 'M16,0 L30,7 L16,14 L2,7 Z M4.8,8.4 L10.68,11.34 L19.68,6.84 L13.8,3.9 Z M6.06,9.03 L9.42,10.71 L17.12,6.86 L13.76,5.18 Z'
         + ' M2,8.8 L15.2,15.4 V31 L2,24.4 Z M16.8,15.4 L30,8.8 V24.4 L16.8,31 Z'
    },
    // 상자 3개 쌓은 모양 (위 1개 + 아래 2개, 뚜껑·테이프 자국)
    BOXES: {
        vb: '0 0 30 26',
        fill: 'M8,0 h5 v2.5 h4 v-2.5 h5 v4 h-14 Z M8,5 h14 v7 h-14 Z'
         + ' M0,14 h5 v2.5 h4 v-2.5 h5 v4 h-14 Z M0,19 h14 v7 h-14 Z'
         + ' M16,14 h5 v2.5 h4 v-2.5 h5 v4 h-14 Z M16,19 h14 v7 h-14 Z'
    }
};

/* TILE_SHAPES 의 모양 하나를 svg 로 */
function TileShapeSvg(key) {
    var s = TILE_SHAPES[key];
    var inner = '<path fill="currentColor" fill-rule="evenodd" d="' + s.fill + '"/>';
    if (s.stroke) {
        inner += '<path fill="none" stroke="currentColor" stroke-width="' + s.sw + '" stroke-linecap="round" stroke-linejoin="round" d="' + s.stroke + '"/>';
    }
    if (s.rot) {
        inner = '<g transform="rotate(' + s.rot + ')">' + inner + '</g>';
    }
    return '<svg viewBox="' + s.vb + '" style="width:18px; height:16px; margin-right:4px; vertical-align:middle">' + inner + '</svg>';
}

function SetTileComboHtml(gridId) {
    var maria = new ItsMaria();
    maria.AddQuery("SELECT GPCD, TPCD, TPNM, REF01 FROM COMTYPE WHERE GPCD IN ('TMLCOLOR', 'TMLICON') AND USEYN = 'Y' ORDER BY GPCD, SORTNO;");
    maria.Query();
    if (maria.isError) return;

    var colorItems = [];
    var iconItems = [];
    maria.stores[0].data.forEach(function (d) {
        var name = wijmo.escapeHtml(d.TPNM);
        if (d.GPCD == 'TMLCOLOR') {
            colorItems.push({
                Value: d.TPCD,
                Label: '<span style="display:inline-block; width:14px; height:14px; margin-right:6px; vertical-align:middle; border:1px solid #888; background:' + d.REF01 + '"></span>' + name
            });
        } else if (TILE_SHAPES[d.REF01]) {
            // 글꼴에 없는 아이콘(트럭 등)은 직접 그린 모양
            iconItems.push({
                Value: d.TPCD,
                Label: TileShapeSvg(d.REF01) + name
            });
        } else {
            iconItems.push({
                Value: d.TPCD,
                Label: '<span style="display:inline-block; width:18px; margin-right:4px; vertical-align:middle; font-family:\'Segoe MDL2 Assets\'; font-size:15px">&#x' + d.REF01 + ';</span>' + name
            });
        }
    });
    // 2026-11-20 타일아이콘은 빈칸(아이콘 없음 → 현장 타일에 이름만)으로도 되돌릴 수 있게 맨 위에 빈 항목
    //   Label 을 '' 로 두면 드롭다운 줄 높이가 없어져 고를 수 없으므로 &nbsp;
    if (iconItems.length > 0) {
        iconItems.unshift({ Value: '', Label: '&nbsp;' });
    }

    [['TILECOLOR', colorItems], ['TILEICON', iconItems]].forEach(function (c) {
        if (c[1].length == 0) return;
        var col = ItsGrid.Get(gridId).columns[ItsGrid.$colIndex(gridId, c[0])];
        col.isContentHtml = true;
        col.dataMap = new wijmo.grid.DataMap(c[1], 'Value', 'Label');
        col.dataMap._originData = c[1];
    });
}

/* 조회 */
ItsButton.EventSearch = function () {
    var maria = new ItsMaria('SYS0001_R03', 'LIST_WEBPKG');
    maria.AddPanel('sdiv1');
    maria.CallProc();
    if (maria.isError) {
        maria.ShowErrMsg();
        return;
    }

    ItsGrid.SetStore('grid1', maria.store);
};
/* 추가 */
ItsButton.EventAdd = function () {
    ItsPop.Open('pop2');
};
ItsCombo.Event('pop2_PKGTP').onChanged = function (value, oldValue) {
    ItsCombo.SetRef01('pop2_CATECD', value);
    ItsCombo.SetValueByIndex('pop2_CATECD', 0);
}

ItsPop.Event('pop2').onAddBtnClick = function () {
    var maria = new ItsMaria('SYS0001_R03', 'ADD_WEBPRG');
    maria.AddPanel('pop2');
    maria.CallProc();
    if (maria.isError) {
        maria.ShowErrMsg();
        return;
    }
    ItsPop.Close('pop2');
    ItsMsg.Toast(ItsMsg.CommonMsg.AddComplete);
    ItsButton.EventSearch();
};
ItsPop.Event('pop2').onCancelBtnClick = function () {
    ItsPage.InitData('pop2');
    ItsPop.Close('pop2');
};

/* 저장 */
ItsButton.EventSave = function () {
    for (var i = 0; i < ItsGrid.Length('grid1'); i++) {
        if (ItsGrid.IsChecked('grid1', i)) {
            var maria = new ItsMaria('SYS0001_R03', 'SAVE_WEBPRG');
            maria.AddRecord('grid1', i);
            maria.CallProc();
            if (maria.isError) {
                maria.ShowErrMsg();
                return;
            }
        }
    }
    ItsMsg.Toast('저장되었습니다.');
    ItsButton.EventSearch();
};

// 삭제
ItsButton.EventDelete = function () {
    ItsMsg.Confirm('선택한 화면의 모든 정보를 삭제합니다.', function () {
        for (var i = 0; i < ItsGrid.Length('grid1'); i++) {
            if (ItsGrid.IsChecked('grid1', i)) {
                var maria = new ItsMaria('SYS0001_R03', 'DEL_WEBPRG');
                maria.AddRecord('grid1', i);
                maria.CallProc();
                if (maria.isError) {
                    maria.ShowErrMsg();
                    return;
                }
            }
        }

        ItsButton.EventSearch();
    })
};

ItsButton.Event('SAVE_REMARK').onClick = function () {
    var maria = new ItsMaria('SYS0001_R03', 'SAVE_REMARK');
    maria.AddParam('PRGCD', ItsGrid.GetValue('grid1', ItsGrid.GetCurrentIndex('grid1'), 'PRGCD'));
    maria.AddParam('REMARK', ItsTextArea.GetValue('ta_REMARK'));
    maria.CallProc();
    if (maria.isError) {
        maria.ShowErrMsg();
        return;
    }
    ItsMsg.Toast('저장되었습니다.');
    ItsButton.EventSearch();
};


ItsGrid.Event('grid1').onButtonClick = function (row, field) {
    if (field == 'SHOWREMARK') {
        ItsPop.Open('pop1');
        ItsTextArea.SetValue('ta_REMARK', ItsGrid.GetValue('grid1', row, 'REMARK'));
    } else if (field == 'MOVEPRG') {
        ItsPage.Jump(ItsGrid.GetValue('grid1', row, 'PRGCD'));
    }
};

