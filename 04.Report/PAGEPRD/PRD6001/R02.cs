using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using DevExpress.XtraReports.UI;
using ItsLibRpt;

namespace XtraRpt
{
    /// <summary>
    /// 2026-11-26 [설비 일상점검 계획등록 PRD6001_R02] 설비 일상점검표 (A4 가로, 1~31일 칸은 빈 양식)
    /// 프로시저 PRD6001_R02 PRINT_CHKSHEET
    ///   Tables[0] 머리글 (FANO, EQMNM, LINENM, ITEMNM_LIST '|' 구분, FIRSTDATE, REVDATE, REVNUM)
    ///   Tables[1] 점검항목 (SEQ, CHKLOCNM, CHKKNDNM, CHKSTD, CHKCYCLENM)
    ///   Tables[2] 위치사진 (SEQ = 항목 순번, FILEPATH = 웹 루트 기준 /UploadFiles/...)
    /// 양식은 R02.Designer.cs. 여기는 값 채우기만
    /// </summary>
    public partial class R02 : XtraReport
    {
        const int MIN_ROWS = 10;   // 항목이 적어도 양식처럼 10줄은 그림

        // Visual Studio 디자이너용 기본 생성자
        public R02()
        {
            InitializeComponent();
            FixCells();
        }

        public R02(Dictionary<string, string> param) : this()
        {
            string planCode = param != null && param.ContainsKey("PLANCD") ? param["PLANCD"] : "";
            if (string.IsNullOrEmpty(planCode))
            {
                throw new InvalidOperationException("설비를 선택해주세요.");
            }

            ItsMaria maria = new ItsMaria("PRD6001_R02", "PRINT_CHKSHEET");
            maria.AddParam("PLANTP", param.ContainsKey("PLANTP") ? param["PLANTP"] : "E");
            maria.AddParam("PLANCD", planCode);
            maria.AddParam("REVNUM", param.ContainsKey("REVNUM") ? param["REVNUM"] : "");
            DataSet ds = maria.CallProc();
            if (maria.IsError)
            {
                throw new InvalidOperationException(maria.ErrMessage);
            }
            if (ds == null || ds.Tables.Count < 3 || ds.Tables[0].Rows.Count == 0)
            {
                throw new InvalidOperationException("출력할 일상점검 항목이 없습니다.");
            }

            FillSheet(ds.Tables[0].Rows[0], ds.Tables[1], ds.Tables[2], "", false);
        }

        // 2026-11-26 점검표 한 장 채우기 (PRD6001_S01 점검표 출력도 이 양식·이 함수를 씀)
        //   head = 머리글 1행, items = 점검항목(SEQ, CHKLOCNM, CHKKNDNM, CHKSTD, CHKCYCLENM [, D01~D31, N01~N31]), photos = 위치사진(SEQ, FILEPATH)
        //   month = 제목 '( 11 )월' 에 넣을 월 (빈값이면 빈칸), fillDays = 1~31일 칸에 결과(Dnn) 채움, Nnn = 'Y' 면 빨간 글씨
        internal void FillSheet(DataRow head, DataTable itemSource, DataTable photos, string month, bool fillDays)
        {
            cell_H_FANO.Text = Value(head, "FANO");
            cell_H_EQMNM.Text = Value(head, "EQMNM");
            cell_H_LINENM.Text = Value(head, "LINENM");
            cell_H_ITEMNM.Text = ItemText(Value(head, "ITEMNM_LIST"));
            cell_T_Date.Text = "제정일자 : " + DateText(Value(head, "FIRSTDATE"))
                + "\r\n개정일자(개정번호) : " + DateText(Value(head, "REVDATE")) + " (REV." + Value(head, "REVNUM") + ")";
            if (!string.IsNullOrEmpty(month))
            {
                cell_T_Title.Text = "(  " + month + "  )월 점검표";
            }

            // 점검항목 : 순번은 동그라미 숫자 (위치사진 번호와 같음), 모자라면 빈 줄
            DataTable items = itemSource.Copy();
            items.Columns.Add("SEQTXT", typeof(string));
            foreach (DataRow r in items.Rows)
            {
                r["SEQTXT"] = Circle(Value(r, "SEQ"));
                if (fillDays)
                {
                    for (int d = 1; d <= 31; d++)
                    {
                        string col = "D" + d.ToString("00");
                        if (items.Columns.Contains(col))
                        {
                            r[col] = Value(r, col).Replace("/", "\n");   // 같은 날 여러 번은 위아래로
                        }
                    }
                }
            }
            while (items.Rows.Count < MIN_ROWS)
            {
                items.Rows.Add(items.NewRow());
            }
            this.DataSource = items;

            if (fillDays)
            {
                BindDays();
            }

            BindPhotos(photos);
        }

        // 1~31일 칸에 결과 연결 (작은 글씨, NG 는 빨간색)
        private void BindDays()
        {
            for (int d = 1; d <= 31; d++)
            {
                XRTableCell cell = FindControl("cell_D_D" + d.ToString("00"), true) as XRTableCell;
                if (cell == null) continue;
                string dayCol = "D" + d.ToString("00");
                string ngCol = "N" + d.ToString("00");
                cell.DataBindings.Add(new XRBinding("Text", null, dayCol));
                cell.Font = new Font("맑은 고딕", 5.5F);
                cell.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
                cell.BeforePrint += (s, e) =>
                {
                    XRTableCell c = (XRTableCell)s;
                    c.ForeColor = Convert.ToString(GetCurrentColumnValue(ngCol)) == "Y" ? Color.Red : Color.Black;
                };
            }
        }

        // 위치사진 8칸에 순서대로 (사진마다 그 항목 번호), 남는 칸은 빈 틀
        private void BindPhotos(DataTable photos)
        {
            XRPictureBox[] pics = { pic_Photo0, pic_Photo1, pic_Photo2, pic_Photo3, pic_Photo4, pic_Photo5, pic_Photo6, pic_Photo7 };
            XRLabel[] labels = { lbl_Photo0, lbl_Photo1, lbl_Photo2, lbl_Photo3, lbl_Photo4, lbl_Photo5, lbl_Photo6, lbl_Photo7 };

            int slot = 0;
            foreach (DataRow r in photos.Rows)
            {
                if (slot >= pics.Length) break;
                Image img = LoadImage(Value(r, "FILEPATH"));
                if (img == null) continue;
                pics[slot].Image = img;
                labels[slot].Text = Circle(Value(r, "SEQ"));
                slot++;
            }
            for (int i = slot; i < labels.Length; i++)
            {
                labels[i].Visible = false;
            }
        }

        // 웹 루트(이 exe 가 있는 Reports 폴더의 위) + /UploadFiles/... 파일을 읽음. 없으면 null
        private static Image LoadImage(string filePath)
        {
            try
            {
                if (string.IsNullOrEmpty(filePath)) return null;
                string root = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, ".."));
                string full = Path.Combine(root, filePath.TrimStart('/', '\\').Replace('/', '\\'));
                if (!File.Exists(full)) return null;
                using (MemoryStream ms = new MemoryStream(File.ReadAllBytes(full)))
                using (Image src = Image.FromStream(ms))
                {
                    return new Bitmap(src);   // 스트림을 닫아도 되게 복사
                }
            }
            catch
            {
                return null;
            }
        }

        // 생산품목 : 품명 앞에서부터 한 줄에 들어갈 만큼(최대 3개) + '외 N건'
        private static string ItemText(string list)
        {
            if (string.IsNullOrEmpty(list)) return "";
            string[] names = list.Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);
            if (names.Length == 0) return "";

            string text = names[0];
            int used = 1;
            while (used < names.Length && used < 3 && (text + ", " + names[used]).Length <= 46)
            {
                text += ", " + names[used];
                used++;
            }
            if (used < names.Length)
            {
                text += " 외 " + (names.Length - used) + "건";
            }
            return text;
        }

        // 2026-01-19 → 2026년 1월 19일
        private static string DateText(string ymd)
        {
            DateTime d;
            if (!DateTime.TryParse(ymd, out d)) return ymd;
            return d.Year + "년 " + d.Month + "월 " + d.Day + "일";
        }

        // 1 → ①  (20 넘으면 숫자 그대로)
        private static string Circle(string seq)
        {
            int n;
            if (!int.TryParse(seq, out n) || n <= 0) return "";
            return n <= 20 ? ((char)(0x2460 + n - 1)).ToString() : n.ToString();
        }

        // 칸이 글자 길이에 따라 늘었다 줄었다 하지 않게 (디자이너에서 새로 넣은 칸도)
        private void FixCells()
        {
            foreach (XRTableCell c in this.AllControls<XRTableCell>())
            {
                c.CanGrow = false;
                c.CanShrink = false;
            }
            foreach (XRLabel l in this.AllControls<XRLabel>())
            {
                l.CanGrow = false;
                l.CanShrink = false;
            }
        }

        private static string Value(DataRow row, string col)
        {
            return row.Table.Columns.Contains(col) && !row.IsNull(col) ? row[col].ToString() : "";
        }
    }
}
