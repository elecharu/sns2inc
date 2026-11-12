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

namespace TML3001
{
    /// <summary>
    /// // 2026-11-11 [불량 양품전환] 부적합 판정이 재작업(REWORK)인 불량재고를 사내 재작업 후 양품창고로 재고이동
    /// 출고창고 = 재공불량(04S130_N)·제품불량(04S230_N), 입고창고 = 재공품(04S131_N)·제품(04S200_N) (짝은 자유 선택)
    /// LOT 바코드 스캔 (후처리 안 된 재작업 판정이 있는 재고만) → 이동량 = 재작업 판정수량 합 (고칠 수 없음) → [등록]
    /// 등록하면 재고이동(IO_MOVELOT_WARE, 입출고구분 02) 후 그 재작업 판정을 후처리 완료로 바꾼다 (프로시저 TML3001_R01)
    /// 재작업 이력은 남기지 않고 ERP 로도 보내지 않는다.
    /// </summary>
    public partial class R01 : ITSLIB.ItsPageTml
    {
        ItsModelPanel MODEL_S1 = new ItsModelPanel();
        ItsModelGrid MODEL_G1 = new ItsModelGrid();

        public R01()
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
            MODEL_S1.SetValue("OUTWARE", "04S130_N");   // 기본 출고창고 : 재공불량창고
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
                    totQty += MODEL_G1.GetDecimal(i, "MOVEQTY");
                }

                ShowMessageBox(commandName, MODEL_S1.GetText("MOVEDATE") + " 일자로 LOT " + MODEL_G1.Rows.Count + "개, 총 " + totQty.ToString("#,0") + " 을(를) 양품전환 하시겠습니까?");
            }
        }

        public override void EventMessageResult(string commandName)
        {
            base.EventMessageResult(commandName);

            if (commandName == "ADD_MOVE")
            {
                // 이동량은 프로시저가 재작업 판정수량으로 다시 구하므로 LOT 만 보낸다
                ItsMaria.Set("TML3001_R01", "ADD_MOVE");
                ItsMaria.AddModel(MODEL_S1);
                for (int i = 0; i < MODEL_G1.Rows.Count; i++)
                {
                    ItsMaria.AddList("LOTKEY_LIST", MODEL_G1.GetText(i, "LOTKEY"));
                }
                DataSet ds = ItsMaria.Call();
                if (ItsMaria.IsError)
                {
                    ShowMessageBox("", ItsMaria.ErrMessage);
                    return;
                }

                MODEL_G1.Clear();
                MODEL_S1.SetValue("SCANLOT", "");
                ShowMessageBox("", "양품전환 되었습니다. (LOT " + ItsData.GetText(ds.Tables[0], 0, "LOTCNT") + "개)");
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

            ItsMaria.Set("TML3001_R01", "SCAN_LOT");
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
