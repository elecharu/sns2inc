using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Net;
using DevExpress.XtraPrinting;
using DevExpress.XtraReports.UI;
using ItsLibRpt;

namespace XtraRpt
{
    /// <summary>
    /// 2026-11-06 [년 설비고장율 현황] 웹 EQM1001_R06 설비 고장 TOP ISSUE 화면 출력 (A4 가로)
    /// 데이터 = EQM1001_R06 LIST_TOPISSUE (화면과 같은 조회, 그 달 상위 5개 설비 + 사진)
    /// 앞 페이지 = TOP ISSUE 표 (최대 5건 모두 1페이지), 뒤 페이지 = 세부내용 (페이지당 2건: 이슈 정보 / 원인 및 예방 / 사진)
    /// 2026-11-06 표를 페이지당 3건 → 5건 (화면에 조회되는 건이 표 1페이지에 모두 나오게)
    /// 고장유형·고장부위는 설비수리(EQMREP)에 항목이 없어 화면처럼 '-'
    /// </summary>
    public partial class R0602 : XtraReport
    {
        const float W = 1109F;            // 본문 폭 (1169 - 여백 30 x 2)
        const float PAGE_H = 765F;        // 본문 높이 (827 - 여백 30 x 2 - 2)
        const int TABLE_PER_PAGE = 5;     // 화면 TOP ISSUE(최대 5건)를 표 1페이지에 모두
        const int DETAIL_PER_PAGE = 2;

        static readonly Color HEAD_BACK = Color.FromArgb(0xef, 0xeb, 0xe0);   // 표 머리 (화면과 같은 색)
        static readonly Color TAG_BACK = Color.FromArgb(0xa3, 0x9a, 0x6b);    // 세부내용 머리표

        // 표 칸: 라인명, 설비명, 규격, 비가동시간, 고장횟수, 고장유형, 고장부위, 고장내용, 조치내역, 진행상태 (합 1109)
        static readonly float[] COL_W = { 90F, 100F, 110F, 90F, 60F, 65F, 65F, 225F, 225F, 79F };

        public R0602()
        {
            InitializeComponent();
        }

        public R0602(Dictionary<string, string> param) : this()
        {
            string year = param.ContainsKey("SYEAR") ? param["SYEAR"] : "";
            string month = param.ContainsKey("SMONTH") ? param["SMONTH"] : "";
            if (year == "" || month == "")
            {
                throw new InvalidOperationException("TOP ISSUE 를 출력할 년월을 선택하세요.");
            }

            ItsMaria maria = new ItsMaria("EQM1001_R06", "LIST_TOPISSUE");
            maria.AddParam("SYEAR", year);
            maria.AddParam("SMONTH", month);
            DataSet ds = maria.CallProc();
            if (maria.IsError)
            {
                throw new InvalidOperationException(maria.ErrMessage);
            }
            if (ds == null || ds.Tables.Count < 2 || ds.Tables[0].Rows.Count == 0)
            {
                throw new InvalidOperationException(month + "월 설비 수리 이력이 없습니다.");
            }

            DRAW(ds.Tables[0], ds.Tables[1], Convert.ToInt32(month) + "월");
        }

        // 표 페이지 → 세부내용 페이지 순으로 Detail 에 그리고 페이지마다 XRPageBreak
        private void DRAW(DataTable top, DataTable img, string monthText)
        {
            int rowCnt = top.Rows.Count;
            int tablePages = (rowCnt + TABLE_PER_PAGE - 1) / TABLE_PER_PAGE;
            int detailPages = (rowCnt + DETAIL_PER_PAGE - 1) / DETAIL_PER_PAGE;
            int page = 0;

            for (int p = 0; p < tablePages; p++, page++)
            {
                float y0 = NEW_PAGE(page, "■ 설비 고장 TOP ISSUE_" + monthText);
                for (int i = 0; i < TABLE_PER_PAGE; i++)
                {
                    int idx = p * TABLE_PER_PAGE + i;
                    if (idx >= rowCnt) break;
                    DRAW_TABLE(top.Rows[idx], y0 + 10F + i * 140F);
                }
            }

            for (int p = 0; p < detailPages; p++, page++)
            {
                float y0 = NEW_PAGE(page, "■ 설비 고장 TOP ISSUE 세부내용_" + monthText);
                for (int i = 0; i < DETAIL_PER_PAGE; i++)
                {
                    int idx = p * DETAIL_PER_PAGE + i;
                    if (idx >= rowCnt) break;
                    DRAW_DETAIL(top.Rows[idx], img, idx + 1, y0 + 14F + i * 350F);
                }
            }

            Detail.HeightF = page * PAGE_H;
        }

        // 페이지 시작 (2페이지부터 앞에 페이지 나누기) + 제목·밑줄, 제목 아래 y 반환
        private float NEW_PAGE(int page, string title)
        {
            float top = page * PAGE_H;
            if (page > 0)
            {
                XRPageBreak br = new XRPageBreak();
                br.LocationFloat = new DevExpress.Utils.PointFloat(0F, top);
                Detail.Controls.Add(br);
            }

            XRLabel lbl = LABEL(title, 0F, top, W, 36F, 18F, true);
            lbl.TextAlignment = TextAlignment.MiddleLeft;

            XRLine line = new XRLine();
            line.LocationFloat = new DevExpress.Utils.PointFloat(0F, top + 38F);
            line.SizeF = new SizeF(W, 4F);
            line.LineWidth = 2;
            Detail.Controls.Add(line);

            return top + 44F;
        }

        // TOP ISSUE 표 1건 (머리 2줄 + 값 1줄)
        private void DRAW_TABLE(DataRow r, float y)
        {
            const float H1 = 24F, H2 = 24F, HV = 76F;   // 5건 x 140 이 한 페이지에 들어가게
            string[] heads = { "라인명", "설비명", "규격", "비가동\r\n시간(분)", "고장\r\n횟수", "고장\r\n유형", "고장\r\n부위", "", "", "진행\r\n상태" };

            int nonMin = INT(r["NONMIN"]);
            string[] vals = {
                TEXT(r, "LINENM"),
                TEXT(r, "EQMNM"),
                TEXT(r, "EQMSPEC"),
                nonMin + "(분)\r\n(약 " + Math.Round(nonMin / 60D) + "HR)",
                TEXT(r, "FAILCNT") + "회",
                "-",
                "-",
                "- " + TEXT(r, "MALFUNCTION"),
                "- " + TEXT(r, "HANDLE"),
                TEXT(r, "STATNM")
            };

            float x = 0F;
            for (int c = 0; c < COL_W.Length; c++)
            {
                if (c == 7)
                {
                    // 고장 및 조치 (2칸 묶음) / 고장내용 · 조치내역
                    CELL("고장 및 조치", x, y, COL_W[7] + COL_W[8], H1, true, TextAlignment.MiddleCenter);
                    CELL("고장내용", x, y + H1, COL_W[7], H2, true, TextAlignment.MiddleCenter);
                    CELL("조치내역", x + COL_W[7], y + H1, COL_W[8], H2, true, TextAlignment.MiddleCenter);
                }
                else if (c != 8)
                {
                    CELL(heads[c], x, y, COL_W[c], H1 + H2, true, TextAlignment.MiddleCenter);
                }

                bool isText = (c == 7 || c == 8);
                CELL(vals[c], x, y + H1 + H2, COL_W[c], HV, false, isText ? TextAlignment.MiddleLeft : TextAlignment.MiddleCenter);
                x += COL_W[c];
            }
        }

        // 세부내용 1건: 이슈 정보 / 원인 및 예방 / 사진
        private void DRAW_DETAIL(DataRow r, DataTable img, int no, float y)
        {
            const float TAG_H = 28F, BOX_Y = 34F, BOX_H = 296F;
            float infoX = 0F, infoW = 255F;
            float causeX = 270F, causeW = 520F;
            float photoX = 805F, photoW = W - 805F;

            // 이슈 정보
            TAG("TOP ISSUE-" + no, infoX + 10F, y, 170F);
            string repDate = TEXT(r, "REPSTIME");
            if (repDate.Length >= 10) repDate = repDate.Substring(2, 8).Replace("-", ".");
            XRLabel info = BOX("✓ 라인명 : " + TEXT(r, "LINENM")
                + "\r\n\r\n✓ 설비명 : " + TEXT(r, "EQMNM")
                + "\r\n\r\n✓ 발생일 : " + repDate
                + "\r\n\r\n✓ 문제내용 : " + TEXT(r, "MALFUNCTION"),
                infoX, y + BOX_Y, infoW, BOX_H);
            info.Font = new Font("맑은 고딕", 11F);

            // 원인 및 예방 (이 화면에서 등록한 값, 없으면 '-')
            TAG("원인 및 예방", causeX + (causeW - 170F) / 2F, y, 170F);
            BOX("[원인]\r\n" + INDENT(TEXT(r, "CAUSE")) + "\r\n[예방]\r\n" + INDENT(TEXT(r, "PREVENT")),
                causeX, y + BOX_Y, causeW, BOX_H);

            // 사진 (최대 4장, 2장까지는 나란히 크게)
            TAG("사진", photoX + (photoW - 170F) / 2F, y, 170F);
            XRLabel photoBox = BOX("", photoX, y + BOX_Y, photoW, BOX_H);
            List<Image> photos = new List<Image>();
            string eqmCd = TEXT(r, "EQMCD");
            foreach (DataRow p in img.Rows)
            {
                if (photos.Count >= 4) break;
                if (TEXT(p, "EQMCD") != eqmCd) continue;
                Image image = LOAD_IMAGE(TEXT(p, "FILEURL"));
                if (image != null) photos.Add(image);
            }
            if (photos.Count == 0)
            {
                photoBox.Text = "사진 없음";
                photoBox.ForeColor = Color.Gray;
                photoBox.TextAlignment = TextAlignment.MiddleCenter;
                return;
            }

            int cols = 2, rows = photos.Count <= 2 ? 1 : 2;
            float gap = 6F;
            float pw = (photoW - gap * 3) / cols;
            float ph = (BOX_H - gap * (rows + 1)) / rows;
            for (int i = 0; i < photos.Count; i++)
            {
                XRPictureBox pic = new XRPictureBox();
                pic.Image = photos[i];
                pic.Sizing = ImageSizeMode.ZoomImage;
                pic.LocationFloat = new DevExpress.Utils.PointFloat(photoX + gap + (i % cols) * (pw + gap), y + BOX_Y + gap + (i / cols) * (ph + gap));
                pic.SizeF = new SizeF(pw, ph);
                Detail.Controls.Add(pic);
            }
        }

        // 사진: 서버면 웹 폴더(Reports\..\UploadFiles)에서 바로, 없으면 주소로 받아옴
        private static Image LOAD_IMAGE(string url)
        {
            if (url == "") return null;
            try
            {
                int at = url.IndexOf("/UploadFiles/", StringComparison.OrdinalIgnoreCase);
                if (at >= 0)
                {
                    string local = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", url.Substring(at + 1).Replace('/', '\\'));
                    if (File.Exists(local))
                    {
                        return Image.FromStream(new MemoryStream(File.ReadAllBytes(local)));
                    }
                }

                HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
                req.Timeout = 10000;
                using (WebResponse res = req.GetResponse())
                using (Stream st = res.GetResponseStream())
                {
                    MemoryStream ms = new MemoryStream();
                    st.CopyTo(ms);
                    ms.Position = 0;
                    return Image.FromStream(ms);
                }
            }
            catch
            {
                return null;   // 사진 하나 못 읽어도 출력은 계속
            }
        }

        private XRLabel CELL(string text, float x, float y, float w, float h, bool head, TextAlignment align)
        {
            XRLabel lbl = LABEL(text, x, y, w, h, 9F, false);
            lbl.Borders = BorderSide.All;
            lbl.BorderColor = Color.FromArgb(0xbb, 0xbb, 0xbb);
            lbl.TextAlignment = align;
            lbl.Padding = new PaddingInfo(4, 4, 2, 2);
            if (head) lbl.BackColor = HEAD_BACK;
            return lbl;
        }

        private void TAG(string text, float x, float y, float w)
        {
            XRLabel lbl = LABEL(text, x, y, w, 28F, 11F, true);
            lbl.BackColor = TAG_BACK;
            lbl.ForeColor = Color.White;
            lbl.TextAlignment = TextAlignment.MiddleCenter;
        }

        private XRLabel BOX(string text, float x, float y, float w, float h)
        {
            XRLabel lbl = LABEL(text, x, y, w, h, 9.5F, false);
            lbl.Borders = BorderSide.All;
            lbl.BorderColor = Color.FromArgb(0xcc, 0xcc, 0xcc);
            lbl.TextAlignment = TextAlignment.TopLeft;
            lbl.Padding = new PaddingInfo(10, 10, 8, 8);
            return lbl;
        }

        // 칸 크기 고정 (긴 글은 칸 안에서 줄바꿈, 넘치면 잘림)
        private XRLabel LABEL(string text, float x, float y, float w, float h, float fontSize, bool bold)
        {
            XRLabel lbl = new XRLabel();
            lbl.Text = text;
            lbl.LocationFloat = new DevExpress.Utils.PointFloat(x, y);
            lbl.SizeF = new SizeF(w, h);
            lbl.Font = new Font("맑은 고딕", fontSize, bold ? FontStyle.Bold : FontStyle.Regular);
            lbl.Multiline = true;
            lbl.WordWrap = true;
            lbl.CanGrow = false;
            lbl.CanShrink = false;
            Detail.Controls.Add(lbl);
            return lbl;
        }

        private static string INDENT(string text)
        {
            if (text.Trim() == "") return "    -";
            return "    " + text.Replace("\r\n", "\n").Replace("\n", "\r\n    ");
        }

        private static string TEXT(DataRow r, string col)
        {
            return r.Table.Columns.Contains(col) && r[col] != DBNull.Value ? r[col].ToString() : "";
        }

        private static int INT(object value)
        {
            decimal d;
            return value != null && decimal.TryParse(value.ToString(), out d) ? (int)Math.Round(d) : 0;
        }
    }
}
