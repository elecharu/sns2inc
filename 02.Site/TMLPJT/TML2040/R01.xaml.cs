using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ITSLIB;
using System.Globalization;

namespace TML2040
{
    /// <summary>
    /// R02.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class R01 : ItsPageTml
    {
        // 2026-11-27 안 쓰는 코드 정리: 예전 시작·종료 팝업(PANEL_A3·타이머), 금형교체(CHANGE_TOOL), 예전 추가(ADD·POP_NONTPLIST) 제거
        ItsModelPanel MODEL_A1 = new ItsModelPanel(); //비가동 수정 팝업
        ItsModelPanel MODEL_A5 = new ItsModelPanel(); //진행 중 비가동 종료 팝업 (2026-11-27)
        private string _endNonKey = "";               //종료할 비가동키
        ItsModelPanel MODEL_A6 = new ItsModelPanel(); //비가동 분할 팝업 (2026-11-27)
        private string _splKey = "", _splStart = "", _splEnd = "";   //분할할 비가동키·원래 시작·종료

        ItsModelPanel MODEL_B1 = new ItsModelPanel(); //컨트롤패널
        ItsModelPanel MODEL_B2 = new ItsModelPanel(); //조회기간 (비가동 이력)
        ItsModelPanel MODEL_B3 = new ItsModelPanel(); //라인 조회조건 (작업장·공정) 2026-11-27

        ItsModelGrid MODEL_G1 = new ItsModelGrid();   //비가동이력그리드

        public R01()
        {
            InitializeComponent();

            MODEL_A1.Binding(PANEL_A1);
            MODEL_A1.InitData();
            
            MODEL_A5.Binding(PANEL_A5);
            MODEL_A5.InitData();
            MODEL_A6.Binding(PANEL_A6);
            MODEL_A6.InitData();
            MODEL_A6.EventValueChanged += (fieldName) => ShowSplitRange();   // 분할 시각을 바꾸면 앞쪽·뒤쪽 시간 다시 표시

            MODEL_B1.Binding(PANEL_B1);
            MODEL_B1.InitData();
            MODEL_B2.Binding(PANEL_B2);
            MODEL_B2.InitData();
            MODEL_B2.SetValue("SDATE", DateTime.Now.ToString("yyyy-MM-dd"));   // 조회기간 기본값: 오늘~오늘
            MODEL_B2.SetValue("EDATE", DateTime.Now.ToString("yyyy-MM-dd"));
            MODEL_B2.EventValueChanged += MODEL_B2_EventValueChanged;
            MODEL_B3.Binding(PANEL_B3);
            MODEL_B3.InitData();
            MODEL_B3.EventValueChanged += MODEL_B3_EventValueChanged;

            MODEL_G1.Binding(GRID_G1);
            MODEL_G1.AddKey("PRDNONKEY");
        }

        // 조회기간을 바꾸면 선택한 라인의 비가동 이력을 다시 조회
        private void MODEL_B2_EventValueChanged(string fieldName)
        {
            EventCommand("EQM_LIST");
        }

        // 2026-11-27 작업장·공정을 바꿀 때마다 라인 버튼 목록을 다시 조회 (작업장을 바꾸면 공정 콤보도 그 작업장 공정으로)
        private void MODEL_B3_EventValueChanged(string fieldName)
        {
            if (fieldName == "LINECD")
            {
                MODEL_B3.SetRef01("PRCCD", MODEL_B3.GetText("LINECD"));
                LoadLineList();
            }
            else if (fieldName == "PRCCD")
            {
                LoadLineList();
            }
        }

        //===== 생산라인 목록 (2026-11-27 화면 B안: 왼쪽 세로 목록) =====
        // 줄마다 라인명(굵게)·공정명, 진행 중 비가동이 있으면 빨간 점. 고른 줄은 파란 바탕
        private string _lineValue = "";
        private readonly Dictionary<string, Border> _lineItems = new Dictionary<string, Border>();
        private readonly Dictionary<string, string> _lineNames = new Dictionary<string, string>();
        private readonly Dictionary<string, string> _lineRunKey = new Dictionary<string, string>();   // 라인별 진행 중 비가동키 (2026-11-27)
        private string _returnMenu = "";   // 생산실적등록(TML2010)에서 넘어왔으면 돌아갈 화면 (2026-11-27)
        private static readonly Brush LINE_ON_BACK = new SolidColorBrush(Color.FromRgb(0x44, 0x72, 0xC4));   // 현장프로그램 기본 버튼 파랑 #4472C4
        private static readonly Brush LINE_OFF_BACK = Brushes.White;   // 회색 카드 위 흰 줄 (2026-11-27)
        private static readonly Brush LINE_BORDER = new SolidColorBrush(Color.FromRgb(0xC8, 0xC8, 0xC8));
        private static readonly Brush TEXT_DARK = new SolidColorBrush(Color.FromRgb(0x26, 0x29, 0x38));   // 현장프로그램 제목줄 남색
        private static readonly Brush TEXT_GRAY = new SolidColorBrush(Color.FromRgb(0x55, 0x55, 0x55));

        // 고른 라인 (EQMCD). 바꾸면 목록 색을 바꾸고 비가동 이력을 다시 조회
        private string LineValue
        {
            get { return _lineValue; }
            set
            {
                _lineValue = value ?? "";
                foreach (KeyValuePair<string, Border> kv in _lineItems)
                {
                    bool on = kv.Key == _lineValue;
                    kv.Value.Background = on ? LINE_ON_BACK : LINE_OFF_BACK;
                    foreach (TextBlock tb in ItsElement.FindChild<TextBlock>(kv.Value))
                    {
                        tb.Foreground = on ? Brushes.White : (tb.Tag as string == "SUB" ? TEXT_GRAY : TEXT_DARK);
                    }
                }
                TXT_LINENM.Text = _lineNames.ContainsKey(_lineValue) ? _lineNames[_lineValue] : "라인을 선택하세요";
                EventCommand("EQM_LIST");
            }
        }

        // 2026-11-27 생산라인 목록 (작업장 필수, 공정은 비우면 그 작업장 전체). 첫 라인을 골라 비가동 이력 조회
        private void LoadLineList()
        {
            MODEL_G1.InitData();
            LINE_LIST.Children.Clear();
            _lineItems.Clear();
            _lineNames.Clear();
            _lineRunKey.Clear();
            _lineValue = "";
            TXT_LINECNT.Text = "";
            TXT_LINENM.Text = "라인을 선택하세요";
            TXT_NONSUM.Text = "";
            if (MODEL_B3.GetText("LINECD") == "")
            {
                TXT_LINENM.Text = "작업장을 선택하세요";
                return;   // 작업장을 골라야 라인 조회
            }

            ItsMaria.Set("TML2040_R01", "LIST_LINE");
            ItsMaria.AddOne("LINECD", MODEL_B3.GetText("LINECD"));
            ItsMaria.AddOne("PRCCD", MODEL_B3.GetText("PRCCD"));
            ItsMaria.AddOne("EQMCD", "");
            DataSet ds = ItsMaria.Call();
            if (ItsMaria.IsError)
            {
                ShowMessageBox("", ItsMaria.ErrMessage);
                return;
            }

            DataTable dt = ds.Tables[0];
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string eqmcd = ItsData.GetText(dt, i, "EQMCD");
                string eqmnm = ItsData.GetText(dt, i, "EQMNM");
                bool running = dt.Columns.Contains("RUNYN") && ItsData.GetText(dt, i, "RUNYN") == "Y";
                AddLineItem(eqmcd, eqmnm, ItsData.GetText(dt, i, "PRCNM"), running);
                _lineRunKey[eqmcd] = dt.Columns.Contains("RUNKEY") ? ItsData.GetText(dt, i, "RUNKEY") : "";
            }
            TXT_LINECNT.Text = dt.Rows.Count + "개";

            if (dt.Rows.Count > 0)
            {
                LineValue = ItsData.GetText(dt, 0, "EQMCD");
            }
        }

        // 라인 목록 한 줄 (터치·마우스로 누르면 그 라인 선택)
        private void AddLineItem(string eqmcd, string eqmnm, string prcnm, bool running)
        {
            System.Windows.Controls.Grid g = new System.Windows.Controls.Grid();
            g.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
            g.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Auto });

            StackPanel sp = new StackPanel();
            // 라인명에 공정이 들어 있어서 (예: (M3열전)T1) 공정명은 따로 안 보임 (2026-11-27)
            sp.Children.Add(new TextBlock { Text = eqmnm, FontSize = 18, FontWeight = FontWeights.Bold, Foreground = TEXT_DARK });
            g.Children.Add(sp);

            if (running)
            {   // 진행 중(종료 안 된) 비가동이 있는 라인
                System.Windows.Shapes.Ellipse dot = new System.Windows.Shapes.Ellipse
                {
                    Width = 12, Height = 12, VerticalAlignment = VerticalAlignment.Center,
                    Fill = Brushes.Red, Stroke = Brushes.White, StrokeThickness = 1.5
                };
                System.Windows.Controls.Grid.SetColumn(dot, 1);
                g.Children.Add(dot);
            }

            Border item = new Border
            {
                Child = g, CornerRadius = new CornerRadius(6), Padding = new Thickness(12, 13, 10, 13),
                Margin = new Thickness(0, 0, 0, 5), Background = LINE_OFF_BACK,
                BorderBrush = LINE_BORDER, BorderThickness = new Thickness(1), Cursor = Cursors.Hand, Tag = eqmcd
            };
            item.MouseLeftButtonUp += (s, e) => { LineValue = (s as Border).Tag.ToString(); };

            LINE_LIST.Children.Add(item);
            _lineItems[eqmcd] = item;
            _lineNames[eqmcd] = eqmnm;   // 오른쪽 위 제목도 라인명만
        }

        // 라인 목록을 다시 불러오되 (진행 중 빨간 점 갱신) 보던 라인은 그대로
        private void RefreshLineKeep()
        {
            string curLine = LineValue;
            LoadLineList();
            if (curLine != "" && _lineItems.ContainsKey(curLine) && LineValue != curLine) LineValue = curLine;
        }

        //===== 생산실적등록(TML2010) 연동 (2026-11-27) =====
        // TML2010 [비가동 등록] → 이 화면으로 넘어옴 (LINECD·PRCCD·EQMCD·RETURN·AUTO)
        // → 그 라인을 골라 두고, 진행 중 비가동이 있으면 종료 팝업, 없으면 시작 팝업
        // → 저장하면(또는 [◀ 생산실적등록으로]) TML2010 으로 돌아가 비가동 탭 다시 조회
        public override void EventMenuParam(Dictionary<string, string> param)
        {
            base.EventMenuParam(param);
            if (param == null || !param.ContainsKey("EQMCD")) return;
            Dictionary<string, string> p = new Dictionary<string, string>(param);
            // 처음 열리는 화면이면 EventPageLoaded(라인 목록 조회)가 끝난 뒤에 처리
            Dispatcher.BeginInvoke(new Action(() => ApplyMenuParam(p)), System.Windows.Threading.DispatcherPriority.ContextIdle);
        }

        private void ApplyMenuParam(Dictionary<string, string> p)
        {
            Func<string, string> get = k => p.ContainsKey(k) && p[k] != null ? p[k] : "";
            string eqmcd = get("EQMCD");

            // 열려 있던 팝업은 닫음
            PANEL_A1.Close();
            PANEL_A4.Close();
            PANEL_A5.Close();
            PANEL_A6.Close();

            _returnMenu = get("RETURN");
            PANEL_BACK.Visibility = _returnMenu != "" ? Visibility.Visible : Visibility.Collapsed;
            if (_returnMenu != "") BoldButtonText(PANEL_BACK);

            MODEL_B3.SetValue("LINECD", get("LINECD"));
            MODEL_B3.SetRef01("PRCCD", get("LINECD"));
            MODEL_B3.SetValue("PRCCD", get("PRCCD"));
            LoadLineList();
            if (!_lineItems.ContainsKey(eqmcd) && MODEL_B3.GetText("PRCCD") != "")
            {   // 공정 조건에 안 걸리면 작업장 전체로 다시
                MODEL_B3.SetValue("PRCCD", "");
                LoadLineList();
            }
            if (!_lineItems.ContainsKey(eqmcd))
            {
                ShowMessageBox("", "비가동관리 라인 목록에 이 생산라인이 없습니다.");
                return;
            }
            if (LineValue != eqmcd) LineValue = eqmcd;
            _lineItems[eqmcd].BringIntoView();

            if (get("AUTO") == "Y")
            {
                string runKey = _lineRunKey.ContainsKey(eqmcd) ? _lineRunKey[eqmcd] : "";
                if (runKey != "") OpenEndPopup(runKey);
                else EventCommand("START_POP");
            }
        }

        // 넘어온 화면으로 돌아감 (msg 는 돌아간 화면에서 띄움)
        private void GoBack(string msg)
        {
            string menu = _returnMenu;
            _returnMenu = "";
            PANEL_BACK.Visibility = Visibility.Collapsed;
            if (menu == "") return;

            Dictionary<string, string> p = new Dictionary<string, string>();
            p["REFRESH"] = "NON";
            p["MSG"] = msg;
            // Application.Current.MainWindow 는 로그인 창이다 (로그인 창이 TMLMAIN 을 ShowDialog 로 띄움) → 열린 창 중 LoadMenu 가 있는 창을 찾는다
            foreach (Window w in Application.Current.Windows)
            {
                System.Reflection.MethodInfo m = w.GetType().GetMethod("LoadMenu", new Type[] { typeof(string), typeof(Dictionary<string, string>) });
                if (m == null) continue;
                m.Invoke(w, new object[] { menu, p });
                break;
            }
            if (ItsElement.ActiveTml != menu && msg != "") ShowMessageBox("", msg);   // 돌아가지 못했으면 여기서 알림
        }

        // 진행 중 비가동 종료 팝업 (그리드에서 고른 줄 또는 생산실적등록에서 넘어온 라인의 진행 중 비가동)
        private void OpenEndPopup(string prdnonkey)
        {
            _endNonKey = prdnonkey;
            ItsMaria.Set("TML2040_R01", "INFO_PRDRSTNON");
            ItsMaria.AddOne("PRDNONKEY", _endNonKey);
            ItsMaria.AddOne("EQMCD", LineValue);
            DataSet ds = ItsMaria.Call();
            if (ItsMaria.IsError)
            {
                ShowMessageBox("", ItsMaria.ErrMessage);
                return;
            }
            string nontp = ItsData.GetText(ds.Tables[0], 0, "NONTP");
            string noncd = ItsData.GetText(ds.Tables[0], 0, "NONCD");
            string nonstime = ItsData.GetText(ds.Tables[0], 0, "NONSTIME");

            // 비고는 그리드 줄에서 (같은 비가동키 줄)
            string remark = "";
            if (MODEL_G1.Columns.Contains("REMARK"))
            {
                for (int i = 0; i < MODEL_G1.Rows.Count; i++)
                {
                    if (MODEL_G1.GetText(i, "PRDNONKEY") == prdnonkey) { remark = MODEL_G1.GetText(i, "REMARK"); break; }
                }
            }

            // 생산실적등록(TML2010) 비가동 팝업과 같음: 진행 중 → 시작 정보 표시, 종료시간은 지금, [종료]만
            MODEL_A5.InitData();
            if (nonstime.Length >= 19)
            {
                MODEL_A5.SetValue("NONSDAY", nonstime.Substring(0, 10));
                MODEL_A5.SetValue("NONSTIME", nonstime.Substring(11, 8));
            }
            MODEL_A5.SetValue("NONEDAY", DateTime.Now.ToString("yyyy-MM-dd"));
            MODEL_A5.SetValue("NONETIME", DateTime.Now.ToString("HH:mm:ss"));
            MODEL_A5.SetValue("REMARK", remark);

            LoadNonTpList();
            END_NONCD_LIST.Clear();
            if (nontp != "") END_NONTP_LIST.Value = nontp;   // 지금 유형 → END_NONTP_LIST 명령이 코드 목록을 채움
            if (noncd != "") END_NONCD_LIST.Value = noncd;   // 지금 코드 (바꿀 수 있음)
            // 종료 모드: 시작 → 종료(기본 지금)·경과, 아래 [종료]
            DateTime st;
            if (DateTime.TryParse(nonstime, out st))
            {
                TimeSpan el = DateTime.Now - st;
                TXT_ELAPSED.Text = (el.Days > 0 ? el.Days + "일 " : "") + el.Hours + "시간 " + el.Minutes + "분";
            }
            else TXT_ELAPSED.Text = "";
            TXT_ARROW.Visibility = Visibility.Visible;
            END_TIME_BOX.Visibility = Visibility.Visible;
            ELAPSED_BOX.Visibility = Visibility.Visible;
            TXT_CODENOTE.Visibility = Visibility.Collapsed;
            BTN_NONSTART.Visibility = Visibility.Collapsed;
            BTN_NONEND.Visibility = Visibility.Visible;
            SetTMLPOPTitle(POPUP_A5, "비가동 종료 - " + TXT_LINENM.Text);
            PANEL_A5.Show();
        }

        // 분할 시각 (yyyy-MM-dd HH:mm:ss)
        private string SplitTimeText()
        {
            string t = MODEL_A6.GetText("SPLTIME");
            if (t.Length == 5) t += ":00";
            return MODEL_A6.GetText("SPLDAY") + " " + t;
        }

        // 분할 팝업 앞쪽·뒤쪽 제목에 시간 범위
        private void ShowSplitRange()
        {
            DateTime s, e, m;
            if (!DateTime.TryParse(_splStart, out s) || !DateTime.TryParse(_splEnd, out e) || !DateTime.TryParse(SplitTimeText(), out m))
            {
                TXT_SPL1.Text = "앞쪽";
                TXT_SPL2.Text = "뒤쪽";
                return;
            }
            bool ok = m > s && m < e;
            TXT_SPL1.Text = "앞쪽  " + s.ToString("HH:mm") + " ~ " + m.ToString("HH:mm") + (ok ? "  (" + (int)(m - s).TotalMinutes + "분)" : "");
            TXT_SPL2.Text = "뒤쪽  " + m.ToString("HH:mm") + " ~ " + e.ToString("HH:mm") + (ok ? "  (" + (int)(e - m).TotalMinutes + "분)" : "");
            Brush c = ok ? (Brush)new SolidColorBrush(Color.FromRgb(0x26, 0x29, 0x38)) : Brushes.IndianRed;   // 범위 밖이면 빨간 글자
            TXT_SPL1.Foreground = c;
            TXT_SPL2.Foreground = c;
        }

        // 비가동 유형 버튼을 지정한 목록에 (미리 고르지 않음)
        private void LoadNonTpInto(ITSLIB.ButtonList list)
        {
            list.Clear();
            ItsMaria.Set("TML2040_R01", "LIST_NONTP");
            ItsMaria.AddOne("EQMCD", LineValue);
            DataSet ds = ItsMaria.Call();
            if (ItsMaria.IsError)
            {
                ShowMessageBox("", ItsMaria.ErrMessage);
                return;
            }
            list.ButtonWidth = "80";
            list.ButtonHeight = "50";
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                list.AddButton(ItsData.GetText(ds.Tables[0], i, "TPNM"), ItsData.GetText(ds.Tables[0], i, "NONTP"));
            }
        }

        // 고른 유형의 비가동 코드 버튼을 지정한 목록에
        private void LoadNonCdInto(ITSLIB.ButtonList tp, ITSLIB.ButtonList cd)
        {
            cd.Clear();
            ItsMaria.Set("TML2040_R01", "LIST_MSTNON");
            ItsMaria.AddOne("NONTP", tp.Value);
            ItsMaria.AddOne("EQMCD", LineValue);
            DataSet ds = ItsMaria.Call();
            if (ItsMaria.IsError)
            {
                ShowMessageBox("", ItsMaria.ErrMessage);
                return;
            }
            cd.ButtonWidth = "80";
            cd.ButtonHeight = "50";
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                cd.AddButton(ItsData.GetText(ds.Tables[0], i, "NONNM"), ItsData.GetText(ds.Tables[0], i, "NONCD"));
            }
        }

        // 2026-11-27 비가동 유형 버튼 (생산실적등록 TML2010 과 같음: 미리 고르지 않음)
        private void LoadNonTpList()
        {
            END_NONTP_LIST.Clear();
            ItsMaria.Set("TML2040_R01", "LIST_NONTP");
            ItsMaria.AddOne("EQMCD", LineValue);
            DataSet ds = ItsMaria.Call();
            if (ItsMaria.IsError)
            {
                ShowMessageBox("", ItsMaria.ErrMessage);
                return;
            }
            END_NONTP_LIST.ButtonWidth = "80";
            END_NONTP_LIST.ButtonHeight = "50";
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                END_NONTP_LIST.AddButton(ItsData.GetText(ds.Tables[0], i, "TPNM"), ItsData.GetText(ds.Tables[0], i, "NONTP"));
            }
        }

        // 비가동 코드 버튼 (고른 유형 기준)
        private void LoadNonCdList()
        {
            END_NONCD_LIST.Clear();
            ItsMaria.Set("TML2040_R01", "LIST_MSTNON");
            ItsMaria.AddOne("NONTP", END_NONTP_LIST.Value);
            ItsMaria.AddOne("EQMCD", LineValue);
            DataSet ds = ItsMaria.Call();
            if (ItsMaria.IsError)
            {
                ShowMessageBox("", ItsMaria.ErrMessage);
                return;
            }
            END_NONCD_LIST.ButtonWidth = "80";
            END_NONCD_LIST.ButtonHeight = "50";
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                END_NONCD_LIST.AddButton(ItsData.GetText(ds.Tables[0], i, "NONNM"), ItsData.GetText(ds.Tables[0], i, "NONCD"));
            }
        }

        // 고른 라인의 조회기간 비가동 요약 (건수·합계 시간·진행 중)
        private void ShowNonSummary()
        {
            int cnt = MODEL_G1.Rows.Count, minutes = 0, running = 0;
            for (int i = 0; i < cnt; i++)
            {
                string t = new string(MODEL_G1.GetText(i, "NONTIME").Where(char.IsDigit).ToArray());
                int m;
                if (int.TryParse(t, out m)) minutes += m;
                if (MODEL_G1.GetText(i, "NONETIME").Trim() == "")
                {
                    running++;
                    MODEL_G1.SetForeColor(i, Colors.Red);   // 진행 중 비가동은 빨간 글자
                }
            }
            TXT_NONSUM.Text = _lineValue == "" ? "" :
                "조회기간 비가동 " + cnt + "건 · 합계 " + minutes + "분" + (running > 0 ? " · 진행 중 " + running + "건" : "");
        }

        //버튼 글자 굵게: ITSLIB.Button 안 TextBlock 에 직접 넣어야 함 (버튼에 FontWeight 를 줘도 공통 글자 스타일이 덮어써서 안 굵어짐)
        private void BoldButtonText(FrameworkElement area)
        {
            area.UpdateLayout();
            foreach (ITSLIB.Button btn in ItsElement.FindChild<ITSLIB.Button>(area))
            {
                foreach (TextBlock tb in ItsElement.FindChild<TextBlock>(btn))
                {
                    tb.FontWeight = FontWeights.Bold;
                }
            }
        }

        public override void EventPageLoaded()
        {
            base.EventPageLoaded();

            PANEL_A1.Close();
            PANEL_A4.Close();
            PANEL_A5.Close();
            PANEL_A6.Close();

            LoadLineList();   // 2026-11-27 생산라인 버튼 목록 (예전: LIST_EQM 비가동 이력이 있는 라인만)
            BoldButtonText(PANEL_B1);   // 비가동조회·수정·삭제·문제점/조치사항 버튼 글자 굵게
        }

        private void NoncdButton(ButtonList button, ButtonList mbutton)
        {
            ItsMaria.Set("TML2040_R01", "LIST_MSTNON");
            ItsMaria.AddOne("NONTP", mbutton.Value);
            ItsMaria.AddOne("EQMCD", LineValue);
            DataSet ds = ItsMaria.Call();
            if (ItsMaria.IsError)
            {
                ShowMessageBox("", ItsMaria.ErrMessage);
                return;
            }
            button.Clear();
            button.ButtonWidth = "80";
            button.ButtonHeight = "50";
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                button.AddButton(ItsData.GetText(ds.Tables[0], i, "NONNM"), ItsData.GetText(ds.Tables[0], i, "NONCD"));
            }
            if (ItsData.GetText(ds.Tables[0], 0, "NONCD") != null)
            {
                button.Value = ItsData.GetText(ds.Tables[0], 0, "NONCD");
            }
        }

        private void NontpButton(ButtonList button, string eqmcd)
        {
            ItsMaria.Set("TML2040_R01", "LIST_NONTP");
            ItsMaria.AddOne("EQMCD", LineValue);
            DataSet ds = ItsMaria.Call();
            if (ItsMaria.IsError)
            {
                ShowMessageBox("", ItsMaria.ErrMessage);
                return;
            }
            button.Clear();
            button.ButtonWidth = "80";
            button.ButtonHeight = "50";
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                button.AddButton(ItsData.GetText(ds.Tables[0], i, "TPNM"), ItsData.GetText(ds.Tables[0], i, "NONTP"));
            }
            button.Value = ItsData.GetText(ds.Tables[0], 0, "NONTP");
        }

        public override void EventCommand(string commandName)
        {
            base.EventCommand(commandName);

            if (commandName == "EQM_LIST")
            {
                ItsMaria.Set("TML2040_R01", "LIST_PRDRSTNON");
                MODEL_G1.InitData();
                if (LineValue == "")
                {
                    ShowNonSummary();
                    return;
                }
                ItsMaria.AddOne("EQMCD", LineValue);
                ItsMaria.AddOne("SDATE", MODEL_B2.GetText("SDATE"));   // 2026-11-27 조회기간 (예전: 조회일자 DATE 하루)
                ItsMaria.AddOne("EDATE", MODEL_B2.GetText("EDATE"));
                DataSet ds = ItsMaria.Call();
                if (ItsMaria.IsError)
                {
                    ShowMessageBox("", ItsMaria.ErrMessage);
                    return;
                }

                MODEL_G1.SetData(ds.Tables[0]);
                ShowNonSummary();   // 2026-11-27 위 요약(건수·합계·진행 중), 진행 중 줄 빨간 글자
            }
            else if (commandName == "ERR")
            {
                if (MODEL_G1.GetText(MODEL_G1.CurrentIndex, "PRDNONKEY") == "")
                {
                    ShowMessageBox("", "비가동 정보를 선택해주세요.");
                }
                else
                {
                    ItsMaria.Set("TML2040_R01", "SEL_PRDRSTNON_PROBLEM");
                    ItsMaria.AddOne("PRDNONKEY", MODEL_G1.GetText(MODEL_G1.CurrentIndex, "PRDNONKEY"));
                    DataSet ds = ItsMaria.Call();
                    if (ItsMaria.IsError)
                    {
                        ShowMessageBox("", ItsMaria.ErrMessage);
                        return;
                    }

                    PROB.Text = ds.Tables[0].Rows[0]["PROBLEM"].ToString();
                    SOL.Text = ds.Tables[0].Rows[0]["SOLUTION"].ToString();

                    // 2026-11-27 맨 위에 어떤 비가동인지 (비가동명 · 시작~종료 · 시간)
                    int r = MODEL_G1.CurrentIndex;
                    string etime = MODEL_G1.GetText(r, "NONETIME");
                    TXT_ERRINFO.Text = "비가동  " + MODEL_G1.GetText(r, "NONNM") + "      시간  " + MODEL_G1.GetText(r, "NONSTIME")
                                     + " ~ " + (etime == "" ? "진행 중" : etime) + (MODEL_G1.GetText(r, "NONTIME") != "" ? "  (" + MODEL_G1.GetText(r, "NONTIME") + ")" : "");
                    SetTMLPOPTitle(POPUP_A4, "문제점 · 조치사항 - " + TXT_LINENM.Text);
                    PANEL_A4.Show();
                }       
            }

            else if (commandName == "SAVE_ERR")
            {
                ItsMaria.Set("TML2040_R01", "UP_PRDRSTNON_PROBLEM");
                ItsMaria.AddOne("PROBLEM", PROB.Text);
                ItsMaria.AddOne("SOLUTION", SOL.Text);
                ItsMaria.AddOne("PRDNONKEY", MODEL_G1.GetText(MODEL_G1.CurrentIndex, "PRDNONKEY"));
                ItsMaria.Call();
                if (ItsMaria.IsError)
                {
                    ShowMessageBox("", ItsMaria.ErrMessage);
                    return;
                }

                PROB.Text = string.Empty;
                SOL.Text = string.Empty;

                PANEL_A4.Close();

                EventCommand("EQM_LIST");
            }

            else if (commandName == "UPDATE")
            {
                string prdnonkey = string.Empty;

                if (MODEL_G1.GetText(MODEL_G1.CurrentIndex, "PRDNONKEY") == "")
                {
                    ShowMessageBox("", "비가동 정보를 선택해주세요.");
                    return;
                }

                prdnonkey = MODEL_G1.GetText(MODEL_G1.CurrentIndex, "PRDNONKEY");

                ItsMaria.Set("TML2040_R01", "SHOW_PRDRSTNON_UP");
                ItsMaria.AddOne("PRDNONKEY", prdnonkey);

                DataSet ds = ItsMaria.Call();
                if (ItsMaria.IsError)
                {
                    ShowMessageBox("", ItsMaria.ErrMessage);
                    return;
                }

                MODEL_A1.InitData();
                NONCD_LIST.Clear();
                NontpButton(NONTP_LIST, LineValue);
                MODEL_A1.SetData(ds.Tables[0]);

                // 2026-11-27 비가동시간 표시 (시작~종료 분)
                DateTime s1, e1;
                bool okS = DateTime.TryParse(MODEL_A1.GetText("NONSDAY") + " " + MODEL_A1.GetText("NONSTIME"), out s1);
                bool okE = DateTime.TryParse(MODEL_A1.GetText("NONEDAY") + " " + MODEL_A1.GetText("NONETIME"), out e1);
                TXT_A1MIN.Text = okS && okE ? ((int)(e1 - s1).TotalMinutes) + "분" : "";

                btnPOP.Label = "수정 저장";
                SetTMLPOPTitle(POPUP_A1, "비가동 수정 - " + TXT_LINENM.Text);
                PANEL_A1.Show();
            }
            else if (commandName == "CLOSE_A1") { PANEL_A1.Close(); }   // 2026-11-27 팝업 [닫기]
            else if (commandName == "CLOSE_A4") { PANEL_A4.Close(); }
            else if (commandName == "CLOSE_A5") { PANEL_A5.Close(); }
            else if (commandName == "CLOSE_A6") { PANEL_A6.Close(); }
            else if (commandName == "SPLIT_POP")
            {   // 2026-11-27 종료된 비가동 분할 팝업 (분할 시각 기본값 = 시작·종료의 가운데, 앞쪽·뒤쪽 유형·코드는 원래 값이 미리 골라짐)
                int row = MODEL_G1.CurrentIndex;
                if (row < 0 || MODEL_G1.GetText(row, "PRDNONKEY") == "")
                {
                    ShowMessageBox("", "분할할 비가동을 선택하세요.");
                    return;
                }
                if (MODEL_G1.GetText(row, "NONETIME").Trim() == "")
                {
                    ShowMessageBox("", "종료된 비가동만 분할할 수 있습니다.\n진행 중인 비가동은 먼저 종료하세요.");
                    return;
                }

                _splKey = MODEL_G1.GetText(row, "PRDNONKEY");
                ItsMaria.Set("TML2040_R01", "INFO_PRDRSTNON");
                ItsMaria.AddOne("PRDNONKEY", _splKey);
                ItsMaria.AddOne("EQMCD", LineValue);
                DataSet ds = ItsMaria.Call();
                if (ItsMaria.IsError)
                {
                    ShowMessageBox("", ItsMaria.ErrMessage);
                    return;
                }
                _splStart = ItsData.GetText(ds.Tables[0], 0, "NONSTIME");
                _splEnd = ItsData.GetText(ds.Tables[0], 0, "NONETIME");
                string nontp = ItsData.GetText(ds.Tables[0], 0, "NONTP");
                string noncd = ItsData.GetText(ds.Tables[0], 0, "NONCD");

                DateTime ds1, de1;
                if (!DateTime.TryParse(_splStart, out ds1) || !DateTime.TryParse(_splEnd, out de1))
                {
                    ShowMessageBox("", "비가동 시작·종료시간을 읽을 수 없습니다.");
                    return;
                }
                DateTime mid = ds1.AddTicks((de1 - ds1).Ticks / 2);
                mid = new DateTime(mid.Year, mid.Month, mid.Day, mid.Hour, mid.Minute, 0);
                if (mid <= ds1) mid = ds1.AddMinutes(1);

                TXT_SPLINFO.Text = MODEL_G1.GetText(row, "NONNM") + "   " + ds1.ToString("MM-dd HH:mm") + " ~ " + de1.ToString("MM-dd HH:mm")
                                 + "  (" + (int)(de1 - ds1).TotalMinutes + "분)";
                MODEL_A6.InitData();
                MODEL_A6.SetValue("SPLDAY", mid.ToString("yyyy-MM-dd"));
                MODEL_A6.SetValue("SPLTIME", mid.ToString("HH:mm:ss"));

                foreach (ITSLIB.ButtonList tp in new[] { SPL_TP1, SPL_TP2 }) LoadNonTpInto(tp);
                SPL_CD1.Clear();
                SPL_CD2.Clear();
                if (nontp != "") { SPL_TP1.Value = nontp; SPL_TP2.Value = nontp; }   // 유형 → 코드 목록
                if (noncd != "") { SPL_CD1.Value = noncd; SPL_CD2.Value = noncd; }
                ShowSplitRange();
                SetTMLPOPTitle(POPUP_A6, "비가동 분할 - " + TXT_LINENM.Text);
                PANEL_A6.Show();
            }
            else if (commandName == "SPL_TP1") { LoadNonCdInto(SPL_TP1, SPL_CD1); }
            else if (commandName == "SPL_TP2") { LoadNonCdInto(SPL_TP2, SPL_CD2); }
            else if (commandName == "SPLIT_SAVE")
            {
                if (SPL_CD1.Value == "" || SPL_CD2.Value == "")
                {
                    ShowMessageBox("", "앞쪽·뒤쪽 비가동코드를 모두 선택하세요.");
                    return;
                }
                ShowMessageBox(commandName, "비가동을 분할하시겠습니까?");
                return;
            }

            else if (commandName == "DELETE")
            {
                if (MODEL_G1.GetText(MODEL_G1.CurrentIndex, "PRDNONKEY") == "")
                {
                    ShowMessageBox("", "비가동 정보를 선택해주세요.");
                    return;
                }
                ShowMessageBox(commandName, "삭제하시겠습니까?");
                return;
            }

            else if (commandName == "ADD_NON")
            {   // 수정 팝업 [수정 저장] (예전 [등록] 은 안 씀)
                ShowMessageBox("UP_NON", "수정하시겠습니까?");
                return;
            }
            else if (commandName == "END_SEL")
            {   // 2026-11-27 고른 진행 중 비가동 종료 팝업 (지금 비가동유형·코드가 미리 골라짐, 바꿀 수 있음)
                int row = MODEL_G1.CurrentIndex;
                if (row < 0 || MODEL_G1.GetText(row, "PRDNONKEY") == "")
                {
                    ShowMessageBox("", "종료할 비가동을 선택하세요.");
                    return;
                }
                if (MODEL_G1.GetText(row, "NONETIME").Trim() != "")
                {
                    ShowMessageBox("", "진행 중인 비가동만 종료할 수 있습니다.\n(종료시간이 빈 줄을 선택하세요)");
                    return;
                }

                OpenEndPopup(MODEL_G1.GetText(row, "PRDNONKEY"));
            }
            else if (commandName == "GO_BACK")
            {   // 2026-11-27 [◀ 생산실적등록으로]
                GoBack("");
            }
            else if (commandName == "START_POP")
            {   // 2026-11-27 비가동 시작 팝업 (생산실적등록 TML2010 비가동 팝업과 같음: 시작시간 지금, 유형·코드 선택, 코드는 종료 때 골라도 됨)
                if (LineValue == "")
                {
                    ShowMessageBox("", "생산라인을 선택하세요.");
                    return;
                }
                _endNonKey = "";
                MODEL_A5.InitData();
                MODEL_A5.SetValue("NONSDAY", DateTime.Now.ToString("yyyy-MM-dd"));
                MODEL_A5.SetValue("NONSTIME", DateTime.Now.ToString("HH:mm:ss"));
                LoadNonTpList();
                END_NONCD_LIST.Clear();
                // 시작 모드: 시작시간 하나만 (기본 지금), 아래 [시작]
                TXT_ARROW.Visibility = Visibility.Collapsed;
                END_TIME_BOX.Visibility = Visibility.Collapsed;
                ELAPSED_BOX.Visibility = Visibility.Collapsed;
                TXT_CODENOTE.Visibility = Visibility.Visible;
                BTN_NONSTART.Visibility = Visibility.Visible;
                BTN_NONEND.Visibility = Visibility.Collapsed;
                SetTMLPOPTitle(POPUP_A5, "비가동 시작 - " + TXT_LINENM.Text);
                PANEL_A5.Show();
            }
            else if (commandName == "START_SAVE")
            {   // 비가동 시작 (라인 단위)
                ItsMaria.Set("TML2040_R01", "START_NON_LINE");
                ItsMaria.AddOne("EQMCD", LineValue);
                ItsMaria.AddOne("NONSTIME", MODEL_A5.GetText("NONSDAY") + " " + MODEL_A5.GetText("NONSTIME"));
                ItsMaria.AddOne("NONCD", END_NONCD_LIST.Value);
                ItsMaria.AddOne("REMARK", MODEL_A5.GetText("REMARK"));
                ItsMaria.Call();
                if (ItsMaria.IsError)
                {
                    ShowMessageBox("", ItsMaria.ErrMessage);
                    return;
                }

                PANEL_A5.Close();
                RefreshLineKeep();
                if (_returnMenu != "") { GoBack("비가동이 시작되었습니다."); return; }   // 생산실적등록에서 왔으면 돌아감
                ShowMessageBox("", "비가동이 시작되었습니다.");
            }
            else if (commandName == "END_NONTP_LIST")
            {   // 비가동 유형 선택 → 코드 목록
                LoadNonCdList();
            }
            else if (commandName == "END_SEL_SAVE")
            {
                ShowMessageBox(commandName, "비가동을 종료하시겠습니까?");
                return;
            }
            else if (commandName == "NONTP_LIST")
            {
                NoncdButton(NONCD_LIST, NONTP_LIST);
            }
        }

        public override void EventMessageResult(string commandName)
        {
            base.EventMessageResult(commandName);

            if (commandName == "SPLIT_SAVE")
            {   // 2026-11-27 비가동 분할 저장
                ItsMaria.Set("TML2040_R01", "SPLIT_NON");
                ItsMaria.AddOne("PRDNONKEY", _splKey);
                ItsMaria.AddOne("SPLITTIME", SplitTimeText());
                ItsMaria.AddOne("NONCD", SPL_CD1.Value);
                ItsMaria.AddOne("NONCD2", SPL_CD2.Value);
                ItsMaria.Call();
                if (ItsMaria.IsError)
                {
                    ShowMessageBox("", ItsMaria.ErrMessage);
                    return;
                }
                PANEL_A6.Close();
                _splKey = "";
                EventCommand("EQM_LIST");
                ShowMessageBox("", "비가동을 분할했습니다.");
                return;
            }

            if (commandName == "END_SEL_SAVE")
            {   // 2026-11-27 고른 진행 중 비가동 종료 (비가동키로)
                string etime = MODEL_A5.GetText("NONETIME");
                if (etime.Length == 5) etime += ":00";   // HH:mm → HH:mm:ss
                ItsMaria.Set("TML2040_R01", "END_NON_KEY");
                ItsMaria.AddOne("PRDNONKEY", _endNonKey);
                ItsMaria.AddOne("NONETIME", MODEL_A5.GetText("NONEDAY") + " " + etime);
                ItsMaria.AddOne("NONCD", END_NONCD_LIST.Value);
                ItsMaria.AddOne("REMARK", MODEL_A5.GetText("REMARK"));
                ItsMaria.Call();
                if (ItsMaria.IsError)
                {
                    ShowMessageBox("", ItsMaria.ErrMessage);
                    return;
                }

                PANEL_A5.Close();
                _endNonKey = "";
                RefreshLineKeep();
                if (_returnMenu != "") { GoBack("비가동이 종료되었습니다."); return; }   // 생산실적등록에서 왔으면 돌아감
                ShowMessageBox("", "비가동이 종료되었습니다.");
                return;
            }

            if (commandName == "UP_NON")
            {
                ItsMaria.Set("TML2040_R01", "UP_PRDRSTNON");
                ItsMaria.AddOne("PRDNONKEY", MODEL_A1.GetText("PRDNONKEY"));
                ItsMaria.AddOne("NONSTIME", MODEL_A1.GetText("NONSDAY") + " " + MODEL_A1.GetText("NONSTIME"));
                ItsMaria.AddOne("NONETIME", MODEL_A1.GetText("NONEDAY") + " " + MODEL_A1.GetText("NONETIME"));
                ItsMaria.AddOne("FANO", "");   // 2026-11-27 상세설비 선택 뺌
                ItsMaria.AddOne("NONTP", NONTP_LIST.Value);
                ItsMaria.AddOne("NONCD", NONCD_LIST.Value);
                ItsMaria.Call();

                if (ItsMaria.IsError)
                {
                    ShowMessageBox("", ItsMaria.ErrMessage);
                    return;
                }

                MODEL_A1.InitData();
                PANEL_A1.Close();
                EventCommand("EQM_LIST");
            }

            else if (commandName == "DELETE")
            { 
                ItsMaria.Set("TML2040_R01", "DEL_PRDRSTNON");
                ItsMaria.AddOne("EQMCD", LineValue);
                ItsMaria.AddModel(MODEL_G1, MODEL_G1.CurrentIndex);
                ItsMaria.Call();
                if (ItsMaria.IsError)
                {
                    ShowMessageBox("", ItsMaria.ErrMessage);
                    return;
                }

                EventCommand("EQM_LIST");
            }
        }
    }
}
