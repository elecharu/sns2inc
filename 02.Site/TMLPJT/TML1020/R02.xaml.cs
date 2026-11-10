using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Data;
using ITSLIB;
using DevExpress.Xpf.Grid;

namespace TML1020
{
    /// <summary>
    /// // 2026-11-10 [외주반출] SNS 2공장 사내 양품창고 → 외주처 창고 재고이동
    /// 이동할 LOT 바코드 스캔 → 그리드에 추가 (이동량 기본 = 현재고, 수정 가능) → [등록]
    /// 같은 LOT 번호로 창고별 재고 관리 (프로시저 TML1020_R02 → IO_MOVELOT_WARE, 입출고구분 02 창고이동)
    /// </summary>
    public partial class R02 : ITSLIB.ItsPageTml
    {
        ItsModelPanel MODEL_S1 = new ItsModelPanel();
        ItsModelGrid MODEL_G1 = new ItsModelGrid();

        public R02()
        {
            InitializeComponent();

            MODEL_S1.Binding(PANEL_S1);
            MODEL_S1.InitData();
            MODEL_S1.EventValueChanged += MODEL_S1_EventValueChanged;

            MODEL_G1.Binding(GRID_G1);
            MODEL_G1.InitData();
        }

        public override void EventPageLoaded()
        {
            base.EventPageLoaded();

            MODEL_S1.SetValue("MOVEDATE", DateTime.Now.ToString("yyyy-MM-dd"));
            MODEL_S1.SetValue("OUTWARE", "04S111_N");   // 기본 출고창고 : 자재투입창고
            MODEL_S1.SetValue("SCANLOT", "");
            txt_BARCODE.Focus();
        }

        // 출고창고를 바꾸면 스캔한 LOT 는 다른 창고 것이므로 비움
        private void MODEL_S1_EventValueChanged(string fieldName)
        {
            if (fieldName == "OUTWARE" && MODEL_G1.Rows.Count > 0)
            {
                MODEL_G1.Clear();
            }
        }

        public override void EventCommand(string commandName)
        {
            base.EventCommand(commandName);

            // 행 삭제
            if (commandName == "DEL_ROW")
            {
                MODEL_G1.DeleteCurrentModel();
                txt_BARCODE.Focus();
            }
            // 스캔 목록 비우기
            else if (commandName == "CLEAR_SCAN")
            {
                MODEL_G1.Clear();
                MODEL_S1.SetValue("SCANLOT", "");
                txt_BARCODE.Focus();
            }
            // 등록
            else if (commandName == "ADD_MOVE")
            {
                if (MODEL_S1.GetText("MOVEDATE") == "")
                {
                    ShowMessageBox("", "이동일자를 선택하세요.");
                    return;
                }
                if (MODEL_S1.GetText("OUTWARE") == "")
                {
                    ShowMessageBox("", "출고창고를 선택하세요.");
                    return;
                }
                if (MODEL_S1.GetText("INWARE") == "")
                {
                    ShowMessageBox("", "입고창고를 선택하세요.");
                    return;
                }
                if (MODEL_G1.Rows.Count == 0)
                {
                    ShowMessageBox("", "이동할 LOT 바코드를 스캔하세요.");
                    return;
                }

                decimal totQty = 0;
                for (int i = 0; i < MODEL_G1.Rows.Count; i++)
                {
                    decimal moveQty = MODEL_G1.GetDecimal(i, "MOVEQTY");
                    if (moveQty <= 0)
                    {
                        ShowMessageBox("", "이동량을 입력하세요. (" + MODEL_G1.GetText(i, "LOTKEY") + ")");
                        return;
                    }
                    if (moveQty > MODEL_G1.GetDecimal(i, "LOTQTY"))
                    {
                        ShowMessageBox("", "이동량이 잔여재고량보다 많습니다. (" + MODEL_G1.GetText(i, "LOTKEY") + ")");
                        return;
                    }
                    totQty += moveQty;
                }

                ShowMessageBox(commandName, MODEL_S1.GetText("MOVEDATE") + " 일자로 LOT " + MODEL_G1.Rows.Count + "개, 총 " + totQty.ToString("#,0") + " 을(를) 외주반출 하시겠습니까?");
            }
        }

        public override void EventMessageResult(string commandName)
        {
            base.EventMessageResult(commandName);

            if (commandName == "ADD_MOVE")
            {
                ItsMaria.Set("TML1020_R02", "ADD_MOVE");
                ItsMaria.AddModel(MODEL_S1);
                for (int i = 0; i < MODEL_G1.Rows.Count; i++)
                {
                    ItsMaria.AddList("LOTKEY_LIST", MODEL_G1.GetText(i, "LOTKEY"));
                    ItsMaria.AddList("MOVEQTY_LIST", MODEL_G1.GetDecimal(i, "MOVEQTY"));
                }
                DataSet ds = ItsMaria.Call();
                if (ItsMaria.IsError)
                {
                    ShowMessageBox("", ItsMaria.ErrMessage);
                    return;
                }

                MODEL_G1.Clear();
                MODEL_S1.SetValue("SCANLOT", "");
                ShowMessageBox("", "외주반출 되었습니다. (LOT " + ItsData.GetText(ds.Tables[0], 0, "LOTCNT") + "개)");
                txt_BARCODE.Focus();
            }
        }

        // 바코드 스캔 (스캐너가 Enter 를 붙여 보냄)
        private void Text_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key != Key.Enter) return;

            string lotKey = MODEL_S1.GetText("SCANLOT").Trim();
            MODEL_S1.SetValue("SCANLOT", "");
            if (lotKey == "") return;

            for (int i = 0; i < MODEL_G1.Rows.Count; i++)
            {
                if (MODEL_G1.GetText(i, "LOTKEY") == lotKey)
                {
                    ShowMessageBox("", "이미 스캔한 LOT 입니다. (" + lotKey + ")");
                    return;
                }
            }

            ItsMaria.Set("TML1020_R02", "SCAN_LOT");
            ItsMaria.AddOne("OUTWARE", MODEL_S1.GetText("OUTWARE"));
            ItsMaria.AddOne("SCANLOT", lotKey);
            DataSet ds = ItsMaria.Call();
            if (ItsMaria.IsError)
            {
                ShowMessageBox("", ItsMaria.ErrMessage);
                return;
            }
            if (ds.Tables[0].Rows.Count == 0) return;

            if (MODEL_G1.Rows.Count == 0)
            {
                MODEL_G1.SetData(ds.Tables[0]);
            }
            else
            {
                MODEL_G1.AddRow(ds.Tables[0]);
            }

            txt_BARCODE.Focus();
        }
    }
}
