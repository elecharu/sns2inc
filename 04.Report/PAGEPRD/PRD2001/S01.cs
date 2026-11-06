// 2026-11-06 [생산일보] 생산실적조회(PRD2001_S01)에서 선택한 작업의 생산일·라인·품목 기준 생산일보 (가로 A4)
// 양식은 S01.Designer.cs (디자이너에서 보임). 여기서는 C_ 로 시작하는 칸에 이름으로 값만 넣는다.
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using DevExpress.XtraReports.UI;
using ItsLibRpt;

namespace XtraRpt
{
    public partial class S01 : XtraReport
    {
        private const int ShiftRowCount = 8;      // 주간·야간 표 줄 수 (양식 고정)
        private const int BadRowCount = 18;       // 불량현황 줄 수 (양식 고정)

        // 비가동 칸 N01~N13 에 들어갈 프로시저 컬럼 (N08 설비고장은 해당 비가동코드가 없어 빈 칸)
        private static readonly string[] NonFields = { "NON_TO", "NON_LINE", "NON_PLAN", "NON_EDU", "NON_3J5H", "NON_PREP", "NON_ST", "", "NON_TOOL", "NON_MODEL", "NON_MTR", "NON_MEAS", "NON_ETC" };

        public S01(Dictionary<string, string> param)
        {
            InitializeComponent();

            // 디자이너에서 칸을 새로 추가해도 출력 때 칸 크기가 바뀌지 않게 잠근다
            foreach (XRLabel label in AllControls<XRLabel>())
            {
                label.CanGrow = false;
                label.CanShrink = false;
            }

            LoadLogo();

            // 매개변수가 없으면 빈 양식만 출력 (레이아웃 확인용)
            if (param == null || !param.ContainsKey("PRDWORKKEY") || param["PRDWORKKEY"] == "")
            {
                return;
            }

            ItsMaria maria = new ItsMaria("PRD2001_S01", "PRINT_DAILY");
            maria.AddParam("PRDWORKKEY", param["PRDWORKKEY"]);
            DataSet ds = maria.CallProc();
            if (maria.IsError)
            {
                throw new InvalidOperationException(maria.ErrMessage);
            }

            if (ds == null || ds.Tables.Count < 4 || ds.Tables[0].Rows.Count == 0)
            {
                throw new InvalidOperationException("출력할 생산일보 데이터가 없습니다.");
            }

            FillReport(ds);
        }

        private void LoadLogo()
        {
            string baseDir = AppDomain.CurrentDomain.BaseDirectory;
            string[] logoPaths = new string[]
            {
                System.IO.Path.Combine(baseDir, "..", "images", "menu", "logo.png"),
                System.IO.Path.Combine(baseDir, "..", "..", "01.Office", "images", "menu", "logo.png")
            };
            foreach (string lp in logoPaths)
            {
                if (System.IO.File.Exists(lp))
                {
                    try
                    {
                        picLogo.Image = Image.FromFile(lp);
                        break;
                    }
                    catch { }
                }
            }
        }

        private void FillReport(DataSet ds)
        {
            DataRow head = ds.Tables[0].Rows[0];
            foreach (string field in new string[] { "PRDDATE", "DAYTIME", "NIGHTTIME", "DAYEMP", "NIGHTEMP", "EQMNM", "ITEMNM", "ITEMCD", "DAYISSUE", "NIGHTISSUE" })
            {
                SetCell("C_" + field, Value(head, field));
            }

            // 작업별 비가동 (작업의 첫 줄에만 찍는다)
            Dictionary<string, DataRow> nonByWork = new Dictionary<string, DataRow>();
            foreach (DataRow r in ds.Tables[2].Rows)
            {
                nonByWork[Value(r, "PRDWORKKEY")] = r;
            }

            decimal[] daySum = FillShift(ds.Tables[1], "DAY", nonByWork);
            decimal[] nightSum = FillShift(ds.Tables[1], "NIGHT", nonByWork);

            decimal[] total = new decimal[daySum.Length];
            for (int i = 0; i < total.Length; i++)
            {
                total[i] = daySum[i] + nightSum[i];
            }
            SetSumRow("C_TOTAL", total);

            FillBad(ds.Tables[3]);
        }

        // 한 근무조(주간/야간) 8줄 + 합계. 합계는 8줄을 넘친 줄까지 모두 더한다.
        // 줄 = 투입로트 1개. 가공완료 로트·수량은 실적의 첫 줄, 비가동은 작업의 첫 줄에만 찍는다.
        // 반환: [0]양품 [1]불량 [2]합계 [3~15]비가동 N01~N13
        private decimal[] FillShift(DataTable lines, string shift, Dictionary<string, DataRow> nonByWork)
        {
            decimal[] sum = new decimal[3 + NonFields.Length];
            string prevRst = null;
            string prevWork = null;
            int line = 0;

            foreach (DataRow r in lines.Rows)
            {
                if (Value(r, "SHIFT") != shift) continue;

                line++;
                bool print = line <= ShiftRowCount;
                string prefix = "C_" + shift + "_" + line + "_";

                if (print)
                {
                    SetCell(prefix + "IN", Value(r, "USELOTKEY"));
                }

                string rstKey = Value(r, "PRDRSTKEY");
                if (rstKey != prevRst)
                {
                    decimal good = ToDecimal(r["GOODQTY"]);
                    decimal bad = ToDecimal(r["BADQTY"]);
                    decimal prod = ToDecimal(r["PRODQTY"]);
                    if (print)
                    {
                        SetCell(prefix + "OUT", Value(r, "LOTKEY"));
                        SetCell(prefix + "GOOD", Num(good));
                        SetCell(prefix + "BAD", Num(bad));
                        SetCell(prefix + "SUM", Num(prod));
                    }
                    sum[0] += good;
                    sum[1] += bad;
                    sum[2] += prod;
                    prevRst = rstKey;
                }

                string workKey = Value(r, "PRDWORKKEY");
                if (workKey != prevWork)
                {
                    DataRow non;
                    if (nonByWork.TryGetValue(workKey, out non))
                    {
                        for (int c = 0; c < NonFields.Length; c++)
                        {
                            if (NonFields[c] == "") continue;
                            decimal m = ToDecimal(non[NonFields[c]]);
                            if (print)
                            {
                                SetCell(prefix + "N" + (c + 1).ToString("00"), Num(m));
                            }
                            sum[3 + c] += m;
                        }
                    }
                    prevWork = workKey;
                }
            }

            SetSumRow("C_" + shift + "_SUM", sum);
            return sum;
        }

        // 합계 줄: {prefix}_GOOD / _BAD / _SUM / _N01~N13
        private void SetSumRow(string prefix, decimal[] sum)
        {
            SetCell(prefix + "_GOOD", Num(sum[0]));
            SetCell(prefix + "_BAD", Num(sum[1]));
            SetCell(prefix + "_SUM", Num(sum[2]));
            for (int c = 0; c < NonFields.Length; c++)
            {
                SetCell(prefix + "_N" + (c + 1).ToString("00"), Num(sum[3 + c]));
            }
        }

        // 불량현황 18줄 + 합계 (합계는 18줄을 넘친 줄까지 포함)
        private void FillBad(DataTable bads)
        {
            decimal sum = 0;
            for (int i = 0; i < bads.Rows.Count; i++)
            {
                DataRow r = bads.Rows[i];
                decimal qty = ToDecimal(r["BADQTY"]);
                sum += qty;
                if (i >= BadRowCount) continue;

                string prefix = "C_BAD_" + (i + 1) + "_";
                SetCell(prefix + "TP", Value(r, "BADTP2NM"));
                SetCell(prefix + "NM", Value(r, "BADNM"));
                SetCell(prefix + "QTY", Num(qty));
            }
            SetCell("C_BAD_SUM_QTY", Num(sum));
        }

        // 이름으로 칸을 찾아 값을 넣는다. 양식에 그 칸이 없으면 조용히 넘어간다.
        private void SetCell(string name, string text)
        {
            XRLabel label = FindControl(name, true) as XRLabel;
            if (label == null) return;
            label.Text = text;
        }

        private static string Value(DataRow row, string columnName)
        {
            if (row == null || !row.Table.Columns.Contains(columnName) || row.IsNull(columnName))
            {
                return "";
            }
            return row[columnName].ToString().Trim();
        }

        private static decimal ToDecimal(object obj)
        {
            if (obj == null || obj == DBNull.Value) return 0;
            decimal d;
            if (decimal.TryParse(obj.ToString(), out d)) return d;
            return 0;
        }

        // 수량·분: 0 은 빈칸
        private static string Num(decimal d)
        {
            return d == 0 ? "" : d.ToString("#,##0");
        }
    }
}
