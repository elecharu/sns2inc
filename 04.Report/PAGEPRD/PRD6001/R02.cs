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

            DataRow head = ds.Tables[0].Rows[0];
            cell_H_FANO.Text = Value(head, "FANO");
            cell_H_EQMNM.Text = Value(head, "EQMNM");
            cell_H_LINENM.Text = Value(head, "LINENM");
            cell_H_ITEMNM.Text = ItemText(Value(head, "ITEMNM_LIST"));
            cell_T_Date.Text = "제정일자 : " + DateText(Value(head, "FIRSTDATE"))
                + "\r\n개정일자(개정번호) : " + DateText(Value(head, "REVDATE")) + " (REV." + Value(head, "REVNUM") + ")";

            // 점검항목 : 순번은 동그라미 숫자 (위치사진 번호와 같음), 모자라면 빈 줄
            DataTable items = ds.Tables[1].Copy();
            items.Columns.Add("SEQTXT", typeof(string));
            foreach (DataRow r in items.Rows)
            {
                r["SEQTXT"] = Circle(Value(r, "SEQ"));
            }
            while (items.Rows.Count < MIN_ROWS)
            {
                items.Rows.Add(items.NewRow());
            }
            this.DataSource = items;

            BindPhotos(ds.Tables[2]);
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
