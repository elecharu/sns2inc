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
using System.Windows.Threading;
using ITSLIB;

namespace TML2050
{
    /// <summary>
    /// R01.xaml에 대한 상호 작용 논리
    /// 생산기술팀 호출 - 현황판 (진행 중 호출 카드 + 하단 버튼 + 3단계 호출 팝업)
    /// </summary>
    public partial class R01 : ItsPageTml
    {
        ItsModelPanel MODEL_S1 = new ItsModelPanel(); //작업장
        ItsModelPanel MODEL_A1 = new ItsModelPanel(); //호출등록팝업
        ItsModelPanel MODEL_A6S = new ItsModelPanel(); //이력조회 기간
        ItsModelGrid MODEL_H1 = new ItsModelGrid();    //이력조회 그리드

        private static readonly FontFamily UI_FONT = new FontFamily("Malgun Gothic"); //ITSLIB 기본 Roboto 대신 맑은 고딕

        //상태 색
        private const string COLOR_CALL = "#E53935";   //호출
        private const string COLOR_ARRIVE = "#FB8C00"; //도착
        private const string COLOR_REPAIR = "#1E88E5"; //수리중
        private const string COLOR_DONE = "#43A047";   //완료
        private const string COLOR_DARK = "#263238";
        private const string COLOR_OFF = "#CFD8DC";    //꺼진 버튼

        //팝업 버튼 색
        private const string COLOR_FILTER = "#90A4AE";        //설비구분/라인 기본
        private const string COLOR_FILTER_SELECT = "#263238"; //설비구분/라인 선택
        private const string COLOR_EQM = "#607D8B";           //설비 기본
        private const string COLOR_EQM_SELECT = "#1E88E5";    //선택한 설비

        //호출이유: 공통코드 생기팀 호출사유(EQMCALLRSN) + 직접 입력
        private const string REASON_ETC = "ETC";
        private Dictionary<string, string> reasonNmDic = new Dictionary<string, string>(); //사유코드 → 사유명
        private Dictionary<string, string> lineNmDic = new Dictionary<string, string>();   //작업장코드 → 작업장명

        //도착 팝업
        private string arrvCallKey = "";
        private List<string> arrvEmpKeys = new List<string>();                              //도착자 후보 (버튼 순서)
        private List<string> arrvEmpSel = new List<string>();                               //선택한 도착자 (여러 명)
        private Dictionary<string, string> arrvEmpNmDic = new Dictionary<string, string>(); //사원코드 → 이름

        //수리시작 팝업
        private string repCallKey = "";                                                     //호출키 ('' = 직접 수리)
        private string repLineKey = "";                                                     //라인 호출이면 호출키 (설비 선택 필요)
        private string repEqmcd = "";                                                       //수리할 설비
        private List<string> repEqmKeys = new List<string>();
        private HashSet<string> repBusyEqm = new HashSet<string>();                         //이미 수리 중인 설비
        private Dictionary<string, string> repEqmNmDic = new Dictionary<string, string>();
        private List<string> repEmpKeys = new List<string>();
        private List<string> repEmpSel = new List<string>();                                //선택한 수리자 (순서 = 선택 순, 첫 번째가 대표)
        private Dictionary<string, string> repEmpNmDic = new Dictionary<string, string>();

        //수리종료 팝업
        private string endRepKey = "";
        private string endEqmNm = "";

        //이력조회
        private bool hisReady = false; //팝업 여는 중에는 조건 변경으로 조회하지 않음

        //현황판
        private DataTable callTable = new DataTable();
        private string selCardKey = ""; //선택한 카드 (호출키|설비코드)

        //호출 팝업
        private int callStep = 1;
        private bool isPopupOpen = false;
        private List<string> selEqmList = new List<string>();                           //선택한 설비코드 (여러 개)
        private HashSet<string> callEqmSet = new HashSet<string>();                     //진행 중인 호출이 있는 설비코드
        private Dictionary<string, string> eqmNmDic = new Dictionary<string, string>(); //설비코드 → 설비명
        private Dictionary<string, string> eqmtpNmDic = new Dictionary<string, string>();
        private Dictionary<string, string> eqmgroup1NmDic = new Dictionary<string, string>();

        private DispatcherTimer timer;
        private int tickCount = 0;

        public R01()
        {
            InitializeComponent();

            MODEL_S1.Binding(PANEL_S1);
            MODEL_S1.InitData();
            MODEL_S1.EventValueChanged += MODEL_S1_EventValueChanged;

            MODEL_A1.Binding(PANEL_A1);
            MODEL_A1.InitData();

            MODEL_A6S.Binding(PANEL_A6S);
            MODEL_A6S.InitData();
            MODEL_A6S.EventValueChanged += MODEL_A6S_EventValueChanged;

            MODEL_H1.Binding(GRID_H1);

            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private void MODEL_S1_EventValueChanged(string fieldName)
        {
            if (fieldName == "LINECD")
            {
                selCardKey = "";
                UpdateLineButton();
                EventCommand("LIST_CALL");
            }
        }

        //현황판 10초마다 새로고침
        private void Timer_Tick(object sender, EventArgs e)
        {
            tickCount++;
            if (tickCount >= 10)
            {
                tickCount = 0;
                if (!isPopupOpen && MODEL_S1.GetText("LINECD") != "")
                {
                    LoadCalls(false);
                }
            }
        }

        public override void EventPageLoaded()
        {
            base.EventPageLoaded();

            PANEL_A1.Close();
            PANEL_A2.Close();
            PANEL_A3.Close();
            PANEL_A4.Close();
            PANEL_A5.Close();
            PANEL_A6.Close();
            isPopupOpen = false;

            UpdateLineButton();
            RenderCalls();

            Dispatcher.BeginInvoke(new Action(() =>
            {
                ApplyFont(this);
                if (MODEL_S1.GetText("LINECD") == "") OpenLinePop(); //작업장 필수 → 처음에 바로 선택
            }), DispatcherPriority.Loaded);
        }

        public override void EventPopClose(string panelName)
        {
            base.EventPopClose(panelName);

            if (panelName.StartsWith("PANEL_A"))
            {
                isPopupOpen = false;
            }
        }

        public override void EventCommand(string commandName)
        {
            base.EventCommand(commandName);

            // ---------------------------------------------------------------- 현황판
            if (commandName == "LIST_CALL")
            {
                if (MODEL_S1.GetText("LINECD") == "")
                {
                    OpenLinePop();
                    return;
                }
                LoadCalls(true);
            }
            else if (commandName == "SELECT_LINE") //작업장 선택 팝업
            {
                OpenLinePop();
            }
            else if (commandName == "LINE_LIST") //작업장 선택
            {
                PANEL_A2.Close();
                isPopupOpen = false;
                MODEL_S1.SetValue("LINECD", LINE_LIST.Value); //→ EventValueChanged 에서 현황판 조회
            }
            else if (commandName == "CLOSE_LINE")
            {
                PANEL_A2.Close();
                isPopupOpen = false;
            }
            else if (commandName == "CALL") //호출
            {
                if (MODEL_S1.GetText("LINECD") == "")
                {
                    ShowMessageBox("", "작업장을 선택하세요.");
                    return;
                }
                OpenCallPop();
            }
            else if (commandName == "CALL_CANCEL") //호출취소 (호출이력 삭제)
            {
                if (!CheckSelCall("CALL")) return;

                int i = GetSelRow();
                string target = ItsData.GetText(callTable, i, "EQMCD") == ""
                    ? ItsData.GetText(callTable, i, "EQMGROUP1NM") + " 라인"
                    : ItsData.GetText(callTable, i, "EQMNM");

                //메시지 창은 3줄 이상이면 제목과 겹치므로 2줄 이하로
                ShowMessageBox("DEL_CALL", "호출을 취소(삭제)할까요?\n" + target);
                return;
            }
            else if (commandName == "ARRIVE") //도착
            {
                if (!CheckSelCall("CALL")) return;
                OpenArrivePop();
            }
            else if (commandName == "ARRVEMP_LIST") //도착자 선택 (누르면 선택, 다시 누르면 해제)
            {
                string empcd = ARRVEMP_LIST.Value;
                if (arrvEmpSel.Contains(empcd)) arrvEmpSel.Remove(empcd);
                else arrvEmpSel.Add(empcd);
                PaintMulti(ARRVEMP_LIST, arrvEmpKeys, arrvEmpSel, COLOR_FILTER, COLOR_FILTER_SELECT);
            }
            else if (commandName == "ADD_ARRIVE") //도착 등록
            {
                if (arrvEmpSel.Count == 0)
                {
                    ShowMessageBox("", "도착자를 선택하세요.");
                    return;
                }
                ShowMessageBox("ADD_ARRIVE", "도착 등록할까요?\n도착자: " + EmpSummary(arrvEmpSel, arrvEmpNmDic));
                return;
            }
            else if (commandName == "CLOSE_ARRIVE")
            {
                PANEL_A3.Close();
                isPopupOpen = false;
            }
            else if (commandName == "REPAIR_START") //수리시작: 카드 선택 → 호출 기준, 선택 없음 → 직접 수리
            {
                if (MODEL_S1.GetText("LINECD") == "")
                {
                    ShowMessageBox("", "작업장을 선택하세요.");
                    return;
                }

                int sel = GetSelRow();
                if (sel >= 0 && ItsData.GetText(callTable, sel, "CALLSTAT") == "REPAIR")
                {
                    ShowMessageBox("", "이미 수리 중인 설비입니다.");
                    return;
                }
                OpenRepairPop(sel);
            }
            else if (commandName == "R_EQMTP_LIST") //직접 수리: 설비구분 선택
            {
                LoadRepGroup1();
            }
            else if (commandName == "R_GROUP1_LIST") //직접 수리: 라인 선택
            {
                LoadRepEqm(R_EQMTP_LIST.Value, R_GROUP1_LIST.Value);
            }
            else if (commandName == "R_EQM_LIST") //수리할 설비 선택 (수리 중인 설비는 선택 불가)
            {
                string eqmcd = R_EQM_LIST.Value;
                if (repBusyEqm.Contains(eqmcd))
                {
                    PaintSingle(R_EQM_LIST, repEqmKeys, repEqmcd, repBusyEqm);
                    ShowMessageBox("", "이미 수리 중인 설비입니다.");
                    return;
                }
                repEqmcd = eqmcd;
                PaintSingle(R_EQM_LIST, repEqmKeys, repEqmcd, repBusyEqm);
                LoadRepEmp();
            }
            else if (commandName == "REPEMP_LIST") //수리자 선택 (누르면 선택, 다시 누르면 해제)
            {
                string empcd = REPEMP_LIST.Value;
                if (repEmpSel.Contains(empcd)) repEmpSel.Remove(empcd);
                else repEmpSel.Add(empcd);
                PaintMulti(REPEMP_LIST, repEmpKeys, repEmpSel, COLOR_FILTER, COLOR_FILTER_SELECT);
            }
            else if (commandName == "ADD_REPAIR") //수리시작 등록
            {
                if (repEqmcd == "")
                {
                    ShowMessageBox("", "수리할 설비를 선택하세요.");
                    return;
                }
                if (repEmpSel.Count == 0)
                {
                    ShowMessageBox("", "수리자를 선택하세요.");
                    return;
                }
                ShowMessageBox("ADD_REPAIR", "수리를 시작할까요?\n" + GetDicText(repEqmNmDic, repEqmcd));
                return;
            }
            else if (commandName == "CLOSE_REPAIR")
            {
                PANEL_A4.Close();
                isPopupOpen = false;
            }
            else if (commandName == "REPAIR_END") //수리종료
            {
                if (!CheckSelCall("REPAIR")) return;
                OpenEndPop(GetSelRow());
            }
            else if (commandName == "END_REPAIR") //수리종료 등록 (종료시각만 기록)
            {
                ShowMessageBox("END_REPAIR", "수리를 종료할까요?\n" + endEqmNm);
                return;
            }
            else if (commandName == "CLOSE_END")
            {
                PANEL_A5.Close();
                isPopupOpen = false;
            }
            else if (commandName == "HISTORY") //이력조회
            {
                if (MODEL_S1.GetText("LINECD") == "")
                {
                    ShowMessageBox("", "작업장을 선택하세요.");
                    return;
                }
                hisReady = false;
                SetHistoryDate(0, 0);
                LoadHisEqm(); //설비 콤보 (전체 + 작업장 설비)
                MODEL_A6S.SetValue("EQMCD", "");
                hisReady = true;

                PANEL_A6.Show();
                isPopupOpen = true;
                LoadHistory();
            }
            else if (commandName == "HIS_SEARCH")
            {
                LoadHistory();
            }
            else if (commandName == "CLOSE_HISTORY")
            {
                PANEL_A6.Close();
                isPopupOpen = false;
            }

            // ---------------------------------------------------------------- 호출 팝업 ① 설비
            else if (commandName == "LIST_EQMTP") //설비구분 조회
            {
                EQMTP_LIST.Clear();
                EQMGROUP1_LIST.Clear();
                ClearEqmList();

                ItsMaria.Set("TML2050_R01", "LIST_EQMTP");
                ItsMaria.AddOne("LINECD", MODEL_S1.GetValue("LINECD"));
                DataTable dt = ItsMaria.Call().Tables[0];
                if (ItsMaria.IsError)
                {
                    ShowMessageBox("", ItsMaria.ErrMessage);
                    return;
                }

                EQMTP_LIST.ButtonWidth = "140";
                EQMTP_LIST.ButtonHeight = "46";
                EQMTP_LIST.ButtonBackColor = COLOR_FILTER;
                EQMTP_LIST.ButtonSelectBackColor = COLOR_FILTER_SELECT;
                eqmtpNmDic.Clear();

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    eqmtpNmDic[ItsData.GetText(dt, i, "EQMTP")] = ItsData.GetText(dt, i, "EQMTPNM");
                    EQMTP_LIST.AddButton(ItsData.GetText(dt, i, "EQMTPNM"), ItsData.GetText(dt, i, "EQMTP"));
                }
                StyleButtonList(EQMTP_LIST, 18);

                if (dt.Rows.Count == 1)
                {
                    EQMTP_LIST.Value = ItsData.GetText(dt, 0, "EQMTP");
                }
            }
            else if (commandName == "EQMTP_LIST") //설비구분 선택
            {
                EventCommand("LIST_EQMGROUP1");
            }
            else if (commandName == "LIST_EQMGROUP1") //라인 조회
            {
                EQMGROUP1_LIST.Clear();
                ClearEqmList();

                ItsMaria.Set("TML2050_R01", "LIST_EQMGROUP1");
                ItsMaria.AddOne("LINECD", MODEL_S1.GetValue("LINECD"));
                ItsMaria.AddOne("EQMTP", EQMTP_LIST.Value);
                DataTable dt = ItsMaria.Call().Tables[0];
                if (ItsMaria.IsError)
                {
                    ShowMessageBox("", ItsMaria.ErrMessage);
                    return;
                }

                EQMGROUP1_LIST.ButtonWidth = "140";
                EQMGROUP1_LIST.ButtonHeight = "46";
                EQMGROUP1_LIST.ButtonBackColor = COLOR_FILTER;
                EQMGROUP1_LIST.ButtonSelectBackColor = COLOR_FILTER_SELECT;
                eqmgroup1NmDic.Clear();

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    eqmgroup1NmDic[ItsData.GetText(dt, i, "EQMGROUP1")] = ItsData.GetText(dt, i, "EQMGROUP1NM");
                    EQMGROUP1_LIST.AddButton(ItsData.GetText(dt, i, "EQMGROUP1NM"), ItsData.GetText(dt, i, "EQMGROUP1"));
                }
                StyleButtonList(EQMGROUP1_LIST, 18);

                if (dt.Rows.Count == 1)
                {
                    EQMGROUP1_LIST.Value = ItsData.GetText(dt, 0, "EQMGROUP1");
                }
            }
            else if (commandName == "EQMGROUP1_LIST") //라인 선택
            {
                EventCommand("LIST_EQM");
            }
            else if (commandName == "LIST_EQM") //설비 조회
            {
                ClearEqmList();

                if (EQMGROUP1_LIST.Value == "")
                {
                    return;
                }

                ItsMaria.Set("TML2050_R01", "LIST_EQM");
                ItsMaria.AddOne("LINECD", MODEL_S1.GetValue("LINECD"));
                ItsMaria.AddOne("EQMTP", EQMTP_LIST.Value);
                ItsMaria.AddOne("EQMGROUP1", EQMGROUP1_LIST.Value);
                DataTable dt = ItsMaria.Call().Tables[0];
                if (ItsMaria.IsError)
                {
                    ShowMessageBox("", ItsMaria.ErrMessage);
                    return;
                }

                EQM_LIST.ButtonWidth = "190";
                EQM_LIST.ButtonHeight = "58";
                EQM_LIST.ButtonBackColor = COLOR_EQM;
                EQM_LIST.ButtonSelectBackColor = COLOR_EQM_SELECT;

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    string eqmcd = ItsData.GetText(dt, i, "EQMCD");
                    eqmNmDic[eqmcd] = ItsData.GetText(dt, i, "EQMNM");

                    //작업자에게는 설비명만 표시 (설비번호 코드 X), 호출 중은 빨간색으로 구분
                    if (ItsData.GetText(dt, i, "CALLYN") == "Y")
                    {
                        callEqmSet.Add(eqmcd);
                        EQM_LIST.SelectColor(eqmcd, COLOR_CALL);
                    }
                    EQM_LIST.AddButton(ItsData.GetText(dt, i, "EQMNM"), eqmcd);
                }
                StyleButtonList(EQM_LIST, 18);
            }
            else if (commandName == "EQM_LIST") //설비 선택 (누르면 선택, 다시 누르면 해제)
            {
                string eqmcd = EQM_LIST.Value;

                if (callEqmSet.Contains(eqmcd))
                {
                    PaintEqmList();
                    ShowMessageBox("", "이미 호출된 설비입니다.");
                    return;
                }

                if (selEqmList.Contains(eqmcd))
                {
                    selEqmList.Remove(eqmcd);
                }
                else
                {
                    selEqmList.Add(eqmcd);
                }
                PaintEqmList();
            }

            // ---------------------------------------------------------------- 호출 팝업 ② 호출이유
            else if (commandName == "REASON_LIST")
            {
                PANEL_REASON_ETC.Visibility = REASON_LIST.Value == REASON_ETC ? Visibility.Visible : Visibility.Collapsed;
            }

            // ---------------------------------------------------------------- 호출 팝업 단계 이동
            else if (commandName == "CALL_PREV")
            {
                if (callStep > 1) ShowStep(callStep - 1);
            }
            else if (commandName == "CALL_NEXT")
            {
                if (callStep == 1)
                {
                    if (EQMTP_LIST.Value == "" || EQMGROUP1_LIST.Value == "")
                    {
                        ShowMessageBox("", "설비구분과 라인을 선택하세요.");
                        return;
                    }
                    if (selEqmList.Count == 0)
                    {
                        //설비를 모를 때: 라인 전체로 호출
                        ShowMessageBox("CALL_LINE", "설비를 선택하지 않았습니다.\n라인 전체로 호출하시겠습니까?");
                        return;
                    }
                    ShowStep(2);
                }
                else if (callStep == 2)
                {
                    if (REASON_LIST.Value == "")
                    {
                        ShowMessageBox("", "호출이유를 선택하세요.");
                        return;
                    }
                    if (REASON_LIST.Value == REASON_ETC && MODEL_A1.GetText("REASON_ETC").Trim() == "")
                    {
                        ShowMessageBox("", "호출이유를 입력하세요.");
                        return;
                    }
                    ShowStep(3);
                }
                else
                {
                    if (CALLEMP_LIST.Count == 0)
                    {
                        ShowMessageBox("", "등록된 호출자가 없습니다.\n기준정보에서 먼저 등록하세요.");
                        return;
                    }
                    if (CALLEMP_LIST.Value == "")
                    {
                        ShowMessageBox("", "호출자를 선택하세요.");
                        return;
                    }
                    ShowMessageBox("ADD_CALL", "호출하시겠습니까?");
                    return;
                }
            }
            else if (commandName == "CLOSE_CALL")
            {
                PANEL_A1.Close();
                isPopupOpen = false;
            }
        }

        public override void EventMessageResult(string commandName)
        {
            base.EventMessageResult(commandName);

            if (commandName == "CALL_LINE")
            {
                ShowStep(2);
            }
            else if (commandName == "END_REPAIR")
            {
                ItsMaria.Set("TML2050_R01", "END_REPAIR");
                ItsMaria.AddOne("EQMREPKEY", endRepKey);
                ItsMaria.Call();
                if (ItsMaria.IsError)
                {
                    ShowMessageBox("", ItsMaria.ErrMessage);
                    return;
                }

                PANEL_A5.Close();
                isPopupOpen = false;
                selCardKey = "";
                LoadCalls(true);
                ShowMessageBox("", "수리를 종료했습니다.");
            }
            else if (commandName == "ADD_REPAIR")
            {
                ItsMaria.Set("TML2050_R01", "ADD_REPAIR");
                ItsMaria.AddOne("EQMCALLKEY", repCallKey);
                ItsMaria.AddOne("EQMCD", repEqmcd);
                foreach (string empcd in repEmpSel) //첫 번째가 대표 수리자
                {
                    ItsMaria.AddList("EMPCD_LIST", empcd);
                }
                ItsMaria.Call();
                if (ItsMaria.IsError)
                {
                    ShowMessageBox("", ItsMaria.ErrMessage);
                    return;
                }

                PANEL_A4.Close();
                isPopupOpen = false;
                selCardKey = repCallKey + "|" + repEqmcd; //수리 시작한 카드 선택
                LoadCalls(true);
                ShowMessageBox("", "수리를 시작했습니다.");
            }
            else if (commandName == "ADD_ARRIVE")
            {
                ItsMaria.Set("TML2050_R01", "ADD_ARRIVE");
                ItsMaria.AddOne("EQMCALLKEY", arrvCallKey);
                foreach (string empcd in arrvEmpSel)
                {
                    ItsMaria.AddList("EMPCD_LIST", empcd);
                }
                ItsMaria.Call();
                if (ItsMaria.IsError)
                {
                    ShowMessageBox("", ItsMaria.ErrMessage);
                    return;
                }

                PANEL_A3.Close();
                isPopupOpen = false;
                LoadCalls(true);
                ShowMessageBox("", "도착 등록되었습니다.");
            }
            else if (commandName == "DEL_CALL")
            {
                int i = GetSelRow();
                if (i < 0) return;

                ItsMaria.Set("TML2050_R01", "DEL_CALL");
                ItsMaria.AddOne("EQMCALLKEY", ItsData.GetText(callTable, i, "EQMCALLKEY"));
                ItsMaria.AddOne("EQMCD", ItsData.GetText(callTable, i, "EQMCD"));
                ItsMaria.Call();
                if (ItsMaria.IsError)
                {
                    ShowMessageBox("", ItsMaria.ErrMessage);
                    LoadCalls(false);
                    return;
                }

                selCardKey = "";
                LoadCalls(true);
                ShowMessageBox("", "호출이 취소되었습니다.");
            }
            else if (commandName == "ADD_CALL")
            {
                ItsMaria.Set("TML2050_R01", "ADD_CALL");
                ItsMaria.AddOne("LINECD", MODEL_S1.GetValue("LINECD"));
                ItsMaria.AddOne("EQMTP", EQMTP_LIST.Value);
                ItsMaria.AddOne("EQMGROUP1", EQMGROUP1_LIST.Value);
                ItsMaria.AddOne("EMPCD_CALL", CALLEMP_LIST.Value);
                ItsMaria.AddOne("REMARK", GetReasonText());
                if (selEqmList.Count == 0)
                {
                    ItsMaria.AddOne("EQMCD_LIST", "");
                }
                foreach (string eqmcd in selEqmList)
                {
                    ItsMaria.AddList("EQMCD_LIST", eqmcd);
                }
                DataSet ds = ItsMaria.Call();
                if (ItsMaria.IsError)
                {
                    ShowMessageBox("", ItsMaria.ErrMessage);
                    return;
                }

                string eqmcallkey = ItsData.GetText(ds.Tables[0], 0, "EQMCALLKEY");
                SendCallNotice(eqmcallkey);

                PANEL_A1.Close();
                isPopupOpen = false;
                selCardKey = eqmcallkey + "|" + (selEqmList.Count > 0 ? selEqmList[0] : ""); //새 호출의 첫 설비 카드 선택
                LoadCalls(true);
                ShowMessageBox("", "호출되었습니다.");
            }
        }

        // ==================================================================== 현황판

        private void LoadCalls(bool showError)
        {
            if (MODEL_S1.GetText("LINECD") == "")
            {
                callTable = new DataTable();
                RenderCalls();
                return;
            }

            ItsMaria.Set("TML2050_R01", "LIST_CALL");
            ItsMaria.AddOne("LINECD", MODEL_S1.GetValue("LINECD"));
            DataTable dt = ItsMaria.Call().Tables[0];
            if (ItsMaria.IsError)
            {
                if (showError) ShowMessageBox("", ItsMaria.ErrMessage);
                return;
            }

            callTable = dt;
            RenderCalls();
        }

        //작업장 선택 팝업 (숨긴 작업장 콤보의 목록을 버튼으로)
        private void OpenLinePop()
        {
            string linecd = MODEL_S1.GetText("LINECD");

            //작업장 목록: 외주 작업장(MSTLINE.OSCCUSTCD 있음) 제외
            ItsMaria.Set("TML2050_R01", "LIST_LINE");
            ItsMaria.AddOne("FACTORYCD", cb_LINECD.REF01);
            DataTable dt = ItsMaria.Call().Tables[0];
            if (ItsMaria.IsError)
            {
                ShowMessageBox("", ItsMaria.ErrMessage);
                return;
            }

            LINE_LIST.Clear();
            LINE_LIST.ButtonWidth = "150";
            LINE_LIST.ButtonHeight = "54";
            LINE_LIST.ButtonBackColor = COLOR_FILTER;
            LINE_LIST.ButtonSelectBackColor = COLOR_FILTER_SELECT;
            if (linecd != "") LINE_LIST.SelectColor(linecd, COLOR_FILTER_SELECT); //지금 작업장 표시

            lineNmDic.Clear();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                lineNmDic[ItsData.GetText(dt, i, "LINECD")] = ItsData.GetText(dt, i, "LINENM");
                LINE_LIST.AddButton(ItsData.GetText(dt, i, "LINENM"), ItsData.GetText(dt, i, "LINECD"));
            }
            StyleButtonList(LINE_LIST, 19);

            PANEL_A2.Show();
            isPopupOpen = true;

            Dispatcher.BeginInvoke(new Action(() => ApplyFont(PANEL_A2)), DispatcherPriority.Loaded);
        }

        // ==================================================================== 도착 팝업

        //선택한 카드의 호출로 도착 등록 팝업 열기 (도착은 호출 단위 → 같이 호출된 설비 모두 도착)
        private void OpenArrivePop()
        {
            int sel = GetSelRow();
            if (sel < 0) return;

            arrvCallKey = ItsData.GetText(callTable, sel, "EQMCALLKEY");

            //같이 호출된 설비 이름
            List<string> eqmNames = new List<string>();
            for (int i = 0; i < callTable.Rows.Count; i++)
            {
                if (ItsData.GetText(callTable, i, "EQMCALLKEY") != arrvCallKey) continue;
                eqmNames.Add(ItsData.GetText(callTable, i, "EQMCD") == ""
                    ? ItsData.GetText(callTable, i, "EQMGROUP1NM") + " (설비 모름)"
                    : ItsData.GetText(callTable, i, "EQMNM"));
            }

            int eqmCnt = 0;
            int.TryParse(ItsData.GetText(callTable, sel, "EQMCNT"), out eqmCnt);
            txt_ARRV_NOTE.Text = eqmCnt > 1 ? "같이 호출된 설비 " + eqmCnt + "대가 모두 도착 처리됩니다" : "";

            string callTime = ItsData.GetText(callTable, sel, "CALLTIME");
            txt_ARRV_EQM.Text = string.Join(", ", eqmNames.ToArray());
            txt_ARRV_REASON.Text = ItsData.GetText(callTable, sel, "REMARK");
            txt_ARRV_CALL.Text = ItsData.GetText(callTable, sel, "EMPNM_CALL") + "  " + (callTime.Length >= 16 ? callTime.Substring(11, 5) : callTime);
            txt_ARRV_WAIT.Text = ItsData.GetText(callTable, sel, "ELAPSEMIN") + "분";

            //도착자 후보: 설비별 생기팀 호출사원(MSTEQM_CALLEMP)
            ARRVEMP_LIST.Clear();
            arrvEmpKeys.Clear();
            arrvEmpSel.Clear();
            arrvEmpNmDic.Clear();

            ItsMaria.Set("TML2050_R01", "LIST_ARRVEMP");
            ItsMaria.AddOne("EQMCALLKEY", arrvCallKey);
            DataTable dt = ItsMaria.Call().Tables[0];
            if (ItsMaria.IsError)
            {
                ShowMessageBox("", ItsMaria.ErrMessage);
                return;
            }

            ARRVEMP_LIST.ButtonWidth = "200";
            ARRVEMP_LIST.ButtonHeight = "56";
            ARRVEMP_LIST.ButtonBackColor = COLOR_FILTER;
            ARRVEMP_LIST.ButtonSelectBackColor = COLOR_FILTER_SELECT;

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string empcd = ItsData.GetText(dt, i, "EMPCD");
                arrvEmpKeys.Add(empcd);
                arrvEmpNmDic[empcd] = ItsData.GetText(dt, i, "EMPNM");
                ARRVEMP_LIST.AddButton(ItsData.GetText(dt, i, "EMPNM"), empcd);
            }
            StyleButtonList(ARRVEMP_LIST, 20);

            //1명뿐이면 자동 선택, 로그인 작업자가 후보에 있으면 기본 선택
            if (dt.Rows.Count == 1) arrvEmpSel.Add(arrvEmpKeys[0]);
            else if (arrvEmpKeys.Contains(ItsLocalInfo.TMLEMP)) arrvEmpSel.Add(ItsLocalInfo.TMLEMP);
            PaintMulti(ARRVEMP_LIST, arrvEmpKeys, arrvEmpSel, COLOR_FILTER, COLOR_FILTER_SELECT);

            txt_ARRVEMP_EMPTY.Visibility = dt.Rows.Count == 0 ? Visibility.Visible : Visibility.Collapsed;

            PANEL_A3.Show();
            isPopupOpen = true;

            Dispatcher.BeginInvoke(new Action(() => ApplyFont(PANEL_A3)), DispatcherPriority.Loaded);
        }

        // ==================================================================== 수리시작 팝업

        //sel >= 0: 선택한 호출 카드 기준, sel < 0: 직접 수리 (작업장 설비 선택)
        private void OpenRepairPop(int sel)
        {
            repCallKey = "";
            repLineKey = "";
            repEqmcd = "";
            R_EQMTP_LIST.Clear();
            R_GROUP1_LIST.Clear();
            ClearRepEqm();
            ClearRepEmp("설비를 먼저 선택하세요.");
            txt_REP_NOTE.Text = "";

            if (sel >= 0)
            {
                //호출 기준
                repCallKey = ItsData.GetText(callTable, sel, "EQMCALLKEY");
                string eqmcd = ItsData.GetText(callTable, sel, "EQMCD");
                string stat = ItsData.GetText(callTable, sel, "CALLSTAT");
                string callTime = ItsData.GetText(callTable, sel, "CALLTIME");
                string arrvTime = ItsData.GetText(callTable, sel, "ARRVTIME");

                txt_REP_TITLE.Text = "수리시작 - 호출";
                txt_REP_EQM.Text = eqmcd == ""
                    ? ItsData.GetText(callTable, sel, "EQMGROUP1NM") + " (설비 모름 → 아래에서 설비 선택)"
                    : ItsData.GetText(callTable, sel, "EQMNM");
                txt_REP_REASON.Text = ItsData.GetText(callTable, sel, "REMARK");
                txt_REP_CALL.Text = ItsData.GetText(callTable, sel, "EMPNM_CALL") + "  " + (callTime.Length >= 16 ? callTime.Substring(11, 5) : callTime);
                txt_REP_ARRV.Text = arrvTime == "" ? "도착 전" : ItsData.GetText(callTable, sel, "ARRVEMPNM") + "  " + (arrvTime.Length >= 16 ? arrvTime.Substring(11, 5) : arrvTime);
                if (stat == "CALL") txt_REP_NOTE.Text = "도착 전 호출입니다. 수리시작과 함께 도착도 등록됩니다";

                REP_SUMMARY.Visibility = Visibility.Visible;
                REP_FILTER.Visibility = Visibility.Collapsed;

                if (eqmcd == "")
                {
                    //라인 호출: 그 라인 설비 중에서 수리할 설비 선택
                    repLineKey = repCallKey;
                    REP_EQM.Visibility = Visibility.Visible;
                    LoadRepEqm(ItsData.GetText(callTable, sel, "EQMTP"), ItsData.GetText(callTable, sel, "EQMGROUP1"));
                }
                else
                {
                    REP_EQM.Visibility = Visibility.Collapsed;
                    repEqmcd = eqmcd;
                    repEqmNmDic[eqmcd] = ItsData.GetText(callTable, sel, "EQMNM");
                    LoadRepEmp();
                }
            }
            else
            {
                //직접 수리: 설비구분 → 라인 → 설비
                txt_REP_TITLE.Text = "수리시작 - 직접 수리";
                txt_REP_NOTE.Text = "호출 없이 수리를 시작합니다";
                REP_SUMMARY.Visibility = Visibility.Collapsed;
                REP_FILTER.Visibility = Visibility.Visible;
                REP_EQM.Visibility = Visibility.Visible;

                ItsMaria.Set("TML2050_R01", "LIST_EQMTP");
                ItsMaria.AddOne("LINECD", MODEL_S1.GetValue("LINECD"));
                DataTable dt = ItsMaria.Call().Tables[0];
                if (ItsMaria.IsError)
                {
                    ShowMessageBox("", ItsMaria.ErrMessage);
                    return;
                }

                R_EQMTP_LIST.ButtonWidth = "140";
                R_EQMTP_LIST.ButtonHeight = "44";
                R_EQMTP_LIST.ButtonBackColor = COLOR_FILTER;
                R_EQMTP_LIST.ButtonSelectBackColor = COLOR_FILTER_SELECT;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    R_EQMTP_LIST.AddButton(ItsData.GetText(dt, i, "EQMTPNM"), ItsData.GetText(dt, i, "EQMTP"));
                }
                StyleButtonList(R_EQMTP_LIST, 18);
                if (dt.Rows.Count == 1) R_EQMTP_LIST.Value = ItsData.GetText(dt, 0, "EQMTP");
            }

            PANEL_A4.Show();
            isPopupOpen = true;

            Dispatcher.BeginInvoke(new Action(() => ApplyFont(PANEL_A4)), DispatcherPriority.Loaded);
        }

        //직접 수리: 라인 목록
        private void LoadRepGroup1()
        {
            R_GROUP1_LIST.Clear();
            ClearRepEqm();
            ClearRepEmp("설비를 먼저 선택하세요.");

            ItsMaria.Set("TML2050_R01", "LIST_EQMGROUP1");
            ItsMaria.AddOne("LINECD", MODEL_S1.GetValue("LINECD"));
            ItsMaria.AddOne("EQMTP", R_EQMTP_LIST.Value);
            DataTable dt = ItsMaria.Call().Tables[0];
            if (ItsMaria.IsError)
            {
                ShowMessageBox("", ItsMaria.ErrMessage);
                return;
            }

            R_GROUP1_LIST.ButtonWidth = "140";
            R_GROUP1_LIST.ButtonHeight = "44";
            R_GROUP1_LIST.ButtonBackColor = COLOR_FILTER;
            R_GROUP1_LIST.ButtonSelectBackColor = COLOR_FILTER_SELECT;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                R_GROUP1_LIST.AddButton(ItsData.GetText(dt, i, "EQMGROUP1NM"), ItsData.GetText(dt, i, "EQMGROUP1"));
            }
            StyleButtonList(R_GROUP1_LIST, 18);
            if (dt.Rows.Count == 1) R_GROUP1_LIST.Value = ItsData.GetText(dt, 0, "EQMGROUP1");
        }

        //수리할 설비 목록 (수리 중인 설비는 빨간색, 선택 불가)
        private void LoadRepEqm(string eqmtp, string eqmgroup1)
        {
            ClearRepEqm();
            ClearRepEmp("설비를 먼저 선택하세요.");
            if (eqmgroup1 == "") return;

            ItsMaria.Set("TML2050_R01", "LIST_EQM");
            ItsMaria.AddOne("LINECD", MODEL_S1.GetValue("LINECD"));
            ItsMaria.AddOne("EQMTP", eqmtp);
            ItsMaria.AddOne("EQMGROUP1", eqmgroup1);
            DataTable dt = ItsMaria.Call().Tables[0];
            if (ItsMaria.IsError)
            {
                ShowMessageBox("", ItsMaria.ErrMessage);
                return;
            }

            R_EQM_LIST.ButtonWidth = "190";
            R_EQM_LIST.ButtonHeight = "60";
            R_EQM_LIST.ButtonBackColor = COLOR_EQM;
            R_EQM_LIST.ButtonSelectBackColor = COLOR_EQM_SELECT;

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string eqmcd = ItsData.GetText(dt, i, "EQMCD");
                repEqmKeys.Add(eqmcd);
                repEqmNmDic[eqmcd] = ItsData.GetText(dt, i, "EQMNM");

                //설비명만 표시, 수리 중은 빨간색으로 구분
                if (ItsData.GetText(dt, i, "REPYN") == "Y")
                {
                    repBusyEqm.Add(eqmcd);
                    R_EQM_LIST.SelectColor(eqmcd, COLOR_CALL);
                }
                R_EQM_LIST.AddButton(ItsData.GetText(dt, i, "EQMNM"), eqmcd);
            }
            StyleButtonList(R_EQM_LIST, 17);
        }

        //수리자 후보: 설비별 생기팀 호출사원(MSTEQM_CALLEMP). 이 호출의 도착자는 기본 선택
        private void LoadRepEmp()
        {
            ClearRepEmp("");

            ItsMaria.Set("TML2050_R01", "LIST_REPEMP");
            ItsMaria.AddOne("EQMCALLKEY", repCallKey);
            ItsMaria.AddOne("EQMCD", repEqmcd);
            DataTable dt = ItsMaria.Call().Tables[0];
            if (ItsMaria.IsError)
            {
                ShowMessageBox("", ItsMaria.ErrMessage);
                return;
            }

            REPEMP_LIST.ButtonWidth = "180";
            REPEMP_LIST.ButtonHeight = "58";
            REPEMP_LIST.ButtonBackColor = COLOR_FILTER;
            REPEMP_LIST.ButtonSelectBackColor = COLOR_FILTER_SELECT;

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string empcd = ItsData.GetText(dt, i, "EMPCD");
                repEmpKeys.Add(empcd);
                repEmpNmDic[empcd] = ItsData.GetText(dt, i, "EMPNM");
                REPEMP_LIST.AddButton(ItsData.GetText(dt, i, "EMPNM"), empcd);
                if (ItsData.GetText(dt, i, "ARRVYN") == "Y") repEmpSel.Add(empcd);
            }
            StyleButtonList(REPEMP_LIST, 20);

            //도착자가 없으면: 1명뿐이면 자동 선택, 로그인 작업자가 후보에 있으면 기본 선택
            if (repEmpSel.Count == 0)
            {
                if (dt.Rows.Count == 1) repEmpSel.Add(repEmpKeys[0]);
                else if (repEmpKeys.Contains(ItsLocalInfo.TMLEMP)) repEmpSel.Add(ItsLocalInfo.TMLEMP);
            }
            PaintMulti(REPEMP_LIST, repEmpKeys, repEmpSel, COLOR_FILTER, COLOR_FILTER_SELECT);

            if (dt.Rows.Count == 0)
            {
                txt_REPEMP_EMPTY.Text = "이 설비에 등록된 생기팀 사원이 없습니다. 기준정보(설비별 생기팀 호출사원)에서 먼저 등록하세요.";
                txt_REPEMP_EMPTY.Visibility = Visibility.Visible;
            }
        }

        private void ClearRepEqm()
        {
            R_EQM_LIST.Clear();
            repEqmKeys.Clear();
            repBusyEqm.Clear();
            repEqmNmDic.Clear();
            if (repLineKey != "" || repCallKey == "") repEqmcd = ""; //고정된 호출 설비는 유지
        }

        private void ClearRepEmp(string emptyText)
        {
            REPEMP_LIST.Clear();
            repEmpKeys.Clear();
            repEmpSel.Clear();
            repEmpNmDic.Clear();
            txt_REPEMP_EMPTY.Text = emptyText;
            txt_REPEMP_EMPTY.Visibility = emptyText == "" ? Visibility.Collapsed : Visibility.Visible;
        }

        // ==================================================================== 수리종료 팝업

        private void OpenEndPop(int sel)
        {
            if (sel < 0) return;

            endRepKey = ItsData.GetText(callTable, sel, "EQMREPKEY");
            endEqmNm = ItsData.GetText(callTable, sel, "EQMNM");
            bool isDirect = ItsData.GetText(callTable, sel, "EQMCALLKEY") == "";
            string repStart = ItsData.GetText(callTable, sel, "REPSTIME");
            int repCnt = 0;
            int.TryParse(ItsData.GetText(callTable, sel, "REPCNT"), out repCnt);

            txt_END_EQM.Text = ItsData.GetText(callTable, sel, "EQMNM");
            txt_END_EMP.Text = ItsData.GetText(callTable, sel, "REPEMPNM") + (repCnt > 1 ? " 외 " + (repCnt - 1) + "명" : "");
            txt_END_GUBUN.Text = isDirect ? "직접 수리" : "호출 (" + ItsData.GetText(callTable, sel, "REMARK") + ")";
            txt_END_START.Text = repStart.Length >= 16 ? repStart.Substring(11, 5) : repStart;
            txt_END_ELAPSE.Text = ItsData.GetText(callTable, sel, "ELAPSEMIN") + "분";

            PANEL_A5.Show();
            isPopupOpen = true;

            Dispatcher.BeginInvoke(new Action(() => ApplyFont(PANEL_A5)), DispatcherPriority.Loaded);
        }

        // ==================================================================== 이력조회 화면

        //조회 기준 설비 콤보 (맨 앞 "전체" = 작업장 전체)
        private void LoadHisEqm()
        {
            ItsMaria.Set("TML2050_R01", "LIST_HIS_EQM");
            ItsMaria.AddOne("LINECD", MODEL_S1.GetValue("LINECD"));
            DataTable dt = ItsMaria.Call().Tables[0];
            if (ItsMaria.IsError)
            {
                ShowMessageBox("", ItsMaria.ErrMessage);
                return;
            }

            //콤보는 (Label, Value) 순서
            DataTable items = new DataTable();
            items.Columns.Add("Label");
            items.Columns.Add("Value");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                items.Rows.Add(ItsData.GetText(dt, i, "EQMNM"), ItsData.GetText(dt, i, "EQMCD")); //설비명만 표시
            }

            cb_HIS_EQMCD.ItemClear();
            cb_HIS_EQMCD.AddItem(items, "전체");
        }

        //이력조회 조건(일자, 설비)을 바꾸면 바로 조회
        private void MODEL_A6S_EventValueChanged(string fieldName)
        {
            if (hisReady) LoadHistory();
        }

        //기간 설정 (오늘 기준 일수)
        private void SetHistoryDate(int fromDays, int toDays)
        {
            MODEL_A6S.SetValue("SDATE", DateTime.Today.AddDays(fromDays).ToString("yyyy-MM-dd"));
            MODEL_A6S.SetValue("EDATE", DateTime.Today.AddDays(toDays).ToString("yyyy-MM-dd"));
        }

        private void LoadHistory()
        {
            string sdate = MODEL_A6S.GetText("SDATE");
            string edate = MODEL_A6S.GetText("EDATE");
            if (sdate == "" || edate == "")
            {
                ShowMessageBox("", "조회 기간을 입력하세요.");
                return;
            }

            ItsMaria.Set("TML2050_R01", "LIST_HISTORY");
            ItsMaria.AddOne("LINECD", MODEL_S1.GetValue("LINECD"));
            ItsMaria.AddOne("SDATE", sdate);
            ItsMaria.AddOne("EDATE", edate);
            ItsMaria.AddOne("EQMCD", MODEL_A6S.GetValue("EQMCD")); //설비 기준 ('' = 전체)
            DataTable dt = ItsMaria.Call().Tables[0];
            if (ItsMaria.IsError)
            {
                ShowMessageBox("", ItsMaria.ErrMessage);
                return;
            }

            //시각은 "MM-dd HH:mm" 으로 짧게 표시
            dt.Columns.Add("CALLTIME_V");
            dt.Columns.Add("ARRVTIME_V");
            dt.Columns.Add("REPSTIME_V");
            dt.Columns.Add("REPETIME_V");
            foreach (DataRow r in dt.Rows)
            {
                r["CALLTIME_V"] = ShortTime(r["CALLTIME"].ToString());
                r["ARRVTIME_V"] = ShortTime(r["ARRVTIME"].ToString());
                r["REPSTIME_V"] = ShortTime(r["REPSTIME"].ToString());
                r["REPETIME_V"] = ShortTime(r["REPETIME"].ToString());
            }

            MODEL_H1.SetData(dt);
        }

        //확인 메시지용 사람 요약: "김다정" / "김다정 외 2명" (메시지 한 줄이 길어지지 않게)
        private string EmpSummary(List<string> sel, Dictionary<string, string> nmDic)
        {
            if (sel.Count == 0) return "";
            string first = GetDicText(nmDic, sel[0]);
            return sel.Count == 1 ? first : first + " 외 " + (sel.Count - 1) + "명";
        }

        private string ShortTime(string t)
        {
            return t.Length >= 16 ? t.Substring(5, 11) : t; //yyyy-MM-dd HH:mm → MM-dd HH:mm
        }

        //하나만 선택하는 ButtonList 색 (선택 불가 항목은 빨간색 유지)
        private void PaintSingle(ButtonList list, List<string> keys, string selKey, HashSet<string> busy)
        {
            foreach (string key in keys)
            {
                string color = busy.Contains(key) ? COLOR_CALL : (key == selKey ? COLOR_EQM_SELECT : COLOR_EQM);
                list.SetBackColor(key, color, false);
            }
        }

        //여러 개 선택 ButtonList 색 칠하기 (ButtonList 는 하나만 선택되므로 선택 목록 기준으로 색 지정)
        private void PaintMulti(ButtonList list, List<string> keys, List<string> sel, string baseColor, string selColor)
        {
            foreach (string key in keys)
            {
                list.SetBackColor(key, sel.Contains(key) ? selColor : baseColor, false);
            }
        }

        //상단 작업장 버튼: 선택한 작업장 이름 표시
        private void UpdateLineButton()
        {
            string linecd = MODEL_S1.GetText("LINECD");
            btn_LINE.Label = (linecd == "" ? "작업장 선택" : GetLineNm(linecd)) + "  ▼";
            btn_LINE.BackColor = linecd == "" ? "#78909C" : COLOR_DARK;
        }

        //카드 키 = 호출키|설비코드 (라인 호출은 설비코드 없음)
        private string GetCardKey(int i)
        {
            return ItsData.GetText(callTable, i, "EQMCALLKEY") + "|" + ItsData.GetText(callTable, i, "EQMCD");
        }

        //진행 중 호출 카드 그리기 (카드 1장 = 호출설비 1대)
        private void RenderCalls()
        {
            PANEL_CARDS.Children.Clear();

            int cntCall = 0, cntArrive = 0, cntRepair = 0;
            bool hasSel = false;
            for (int i = 0; i < callTable.Rows.Count; i++)
            {
                if (GetCardKey(i) == selCardKey) hasSel = true;
            }
            if (!hasSel) selCardKey = "";
            string selCallKey = selCardKey.Split('|')[0];

            for (int i = 0; i < callTable.Rows.Count; i++)
            {
                string stat = ItsData.GetText(callTable, i, "CALLSTAT");
                if (stat == "CALL") cntCall++;
                else if (stat == "ARRIVE") cntArrive++;
                else if (stat == "REPAIR") cntRepair++;

                PANEL_CARDS.Children.Add(MakeCard(i, selCallKey));
            }

            if (MODEL_S1.GetText("LINECD") == "")
            {
                txt_SUMMARY.Text = "진행 중 호출";
                txt_EMPTY.Text = "작업장을 선택하세요.";
            }
            else
            {
                txt_SUMMARY.Text = string.Format("진행 중 호출 설비 {0}대   (호출 {1} · 도착 {2} · 수리중 {3})",
                                                 callTable.Rows.Count, cntCall, cntArrive, cntRepair);
                txt_EMPTY.Text = callTable.Rows.Count == 0 ? "진행 중인 호출이 없습니다.\n[호출] 버튼으로 생산기술팀을 부를 수 있습니다." : "";
            }
            txt_EMPTY.Visibility = txt_EMPTY.Text == "" ? Visibility.Collapsed : Visibility.Visible;

            UpdateActionButtons();
        }

        private Border MakeCard(int i, string selCallKey)
        {
            string key = GetCardKey(i);
            string eqmcd = ItsData.GetText(callTable, i, "EQMCD");
            string stat = ItsData.GetText(callTable, i, "CALLSTAT");
            bool isSel = key == selCardKey;
            bool isSameCall = !isSel && selCallKey != "" && ItsData.GetText(callTable, i, "EQMCALLKEY") == selCallKey; //같이 호출된 설비

            //제목: 설비명 / 설비를 모르는 라인 호출 → 라인 (설비 모름)
            string title = eqmcd == ""
                ? ItsData.GetText(callTable, i, "EQMGROUP1NM") + " (설비 모름)"
                : ItsData.GetText(callTable, i, "EQMNM");

            Border card = new Border();
            card.Width = 226;
            card.Height = 140;
            card.Margin = new Thickness(5);
            card.Padding = new Thickness(12, 10, 12, 10);
            card.CornerRadius = new CornerRadius(10);
            card.Background = ToBrush("#FFFFFF");
            card.BorderBrush = ToBrush(isSel ? COLOR_DARK : (isSameCall ? "#78909C" : "#CFD8DC"));
            card.BorderThickness = new Thickness(isSel ? 4 : (isSameCall ? 2 : 1));
            card.Cursor = Cursors.Hand;
            card.Tag = key;
            card.MouseLeftButtonUp += Card_MouseLeftButtonUp;

            StackPanel sp = new StackPanel();

            //상태 배지 + 라인명 (설비번호 같은 코드는 작업자에게 표시하지 않음)
            DockPanel top = new DockPanel();
            TextBlock tbLine = MakeText(ItsData.GetText(callTable, i, "EQMGROUP1NM"), 16, false, "#78909C");
            DockPanel.SetDock(tbLine, Dock.Right);
            top.Children.Add(tbLine);

            Border pill = new Border();
            pill.Background = ToBrush(StatColor(stat));
            pill.CornerRadius = new CornerRadius(11);
            pill.Padding = new Thickness(12, 1, 12, 1);
            pill.HorizontalAlignment = HorizontalAlignment.Left;
            pill.Child = MakeText(StatName(stat), 16, true, stat == "ARRIVE" ? COLOR_DARK : "#FFFFFF");
            top.Children.Add(pill);
            sp.Children.Add(top);

            TextBlock tbTitle = MakeText(title, 19, true, COLOR_DARK);
            tbTitle.Margin = new Thickness(0, 6, 0, 0);
            sp.Children.Add(tbTitle);

            TextBlock tbReason = MakeText(ItsData.GetText(callTable, i, "REMARK"), 16, false, "#455A64");
            sp.Children.Add(tbReason);

            DockPanel dp = new DockPanel();
            dp.Margin = new Thickness(0, 4, 0, 0);
            TextBlock tbElapsed = MakeText(ItsData.GetText(callTable, i, "ELAPSEMIN") + "분", 18, true, stat == "CALL" ? COLOR_CALL : "#546E7A");
            tbElapsed.FontFamily = new FontFamily("Consolas");
            DockPanel.SetDock(tbElapsed, Dock.Right);
            dp.Children.Add(tbElapsed);
            //호출 상태는 호출자, 도착은 도착자, 수리중은 수리자 (첫 사람 외 N명)
            string who = "호출 " + ItsData.GetText(callTable, i, "EMPNM_CALL");
            if (stat == "REPAIR" && ItsData.GetText(callTable, i, "REPEMPNM") != "")
            {
                int repCnt = 0;
                int.TryParse(ItsData.GetText(callTable, i, "REPCNT"), out repCnt);
                who = "수리 " + ItsData.GetText(callTable, i, "REPEMPNM") + (repCnt > 1 ? " 외 " + (repCnt - 1) : "");
            }
            else if (stat == "ARRIVE" && ItsData.GetText(callTable, i, "ARRVEMPNM") != "")
            {
                int arrvCnt = 0;
                int.TryParse(ItsData.GetText(callTable, i, "ARRVCNT"), out arrvCnt);
                who = "도착 " + ItsData.GetText(callTable, i, "ARRVEMPNM") + (arrvCnt > 1 ? " 외 " + (arrvCnt - 1) : "");
            }
            dp.Children.Add(MakeText(who, 16, false, "#607D8B"));
            sp.Children.Add(dp);

            card.Child = sp;
            return card;
        }

        private void Card_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            string key = (sender as Border).Tag.ToString();
            selCardKey = selCardKey == key ? "" : key; //다시 누르면 선택 해제
            RenderCalls();
        }

        //선택한 카드 상태에 맞는 버튼만 켬 (호출/이력조회는 항상 켜짐)
        private void UpdateActionButtons()
        {
            string stat = GetSelCallStat();
            SetActionButton(btn_CALL_CANCEL, stat == "CALL", "#6D4C41");
            SetActionButton(btn_ARRIVE, stat == "CALL", COLOR_ARRIVE);
            SetActionButton(btn_REPAIR_START, stat == "" || stat == "CALL" || stat == "ARRIVE", COLOR_REPAIR); //선택 없음 = 직접 수리
            SetActionButton(btn_REPAIR_END, stat == "REPAIR", COLOR_DONE);
        }

        private void SetActionButton(ITSLIB.Button btn, bool on, string color)
        {
            btn.ForeColor = on ? "#FFFFFF" : "#90A4AE";
            btn.BackColor = on ? color : COLOR_OFF;
        }

        private int GetSelRow()
        {
            for (int i = 0; i < callTable.Rows.Count; i++)
            {
                if (GetCardKey(i) == selCardKey) return i;
            }
            return -1;
        }

        private string GetSelCallStat()
        {
            int i = GetSelRow();
            return i < 0 ? "" : ItsData.GetText(callTable, i, "CALLSTAT");
        }

        //하단 버튼 누를 때 선택한 호출 상태 확인
        private bool CheckSelCall(string needStat)
        {
            string stat = GetSelCallStat();
            if (stat == "")
            {
                ShowMessageBox("", "호출 카드를 먼저 선택하세요.");
                return false;
            }
            if (stat != needStat)
            {
                ShowMessageBox("", "선택한 호출은 '" + StatName(stat) + "' 상태입니다.");
                return false;
            }
            return true;
        }

        private string StatName(string stat)
        {
            if (stat == "CALL") return "호출";
            if (stat == "ARRIVE") return "도착";
            if (stat == "REPAIR") return "수리중";
            return "완료";
        }

        private string StatColor(string stat)
        {
            if (stat == "CALL") return COLOR_CALL;
            if (stat == "ARRIVE") return COLOR_ARRIVE;
            if (stat == "REPAIR") return COLOR_REPAIR;
            return COLOR_DONE;
        }

        // ==================================================================== 호출 팝업

        private void OpenCallPop()
        {
            MODEL_A1.InitData();
            CALLEMP_LIST.Clear();

            LoadReasons();

            ShowStep(1);
            PANEL_A1.Show();
            isPopupOpen = true;

            EventCommand("LIST_EQMTP");

            Dispatcher.BeginInvoke(new Action(() => ApplyFont(PANEL_A1)), DispatcherPriority.Loaded);
        }

        private void ShowStep(int step)
        {
            callStep = step;

            STEP1.Visibility = step == 1 ? Visibility.Visible : Visibility.Collapsed;
            STEP2.Visibility = step == 2 ? Visibility.Visible : Visibility.Collapsed;
            STEP3.Visibility = step == 3 ? Visibility.Visible : Visibility.Collapsed;

            SetStepText(txt_STEP1, step, 1);
            SetStepText(txt_STEP2, step, 2);
            SetStepText(txt_STEP3, step, 3);

            btn_PREV.Visibility = step == 1 ? Visibility.Hidden : Visibility.Visible;
            btn_NEXT.Label = step == 3 ? "호출하기" : "다음 ▶";

            if (step == 2)
            {
                txt_STEP2_TARGET.Text = GetDicText(eqmgroup1NmDic, EQMGROUP1_LIST.Value) + "  ·  " + GetEqmText();
            }
            else if (step == 3)
            {
                txt_INFO_LINE.Text = GetLineNm(MODEL_S1.GetText("LINECD"));
                txt_INFO_PRC.Text = GetDicText(eqmtpNmDic, EQMTP_LIST.Value) + " / " + GetDicText(eqmgroup1NmDic, EQMGROUP1_LIST.Value);
                txt_INFO_EQM.Text = GetEqmText();
                txt_INFO_REASON.Text = GetReasonText();
                LoadCallEmp();
            }
        }

        //호출자 목록: MSTEQM_CALLEMP 에 등록된 사원만 (설비를 고르면 그 설비, 라인 호출이면 라인 전체 설비 기준)
        private void LoadCallEmp()
        {
            CALLEMP_LIST.Clear();
            txt_CALLEMP_EMPTY.Visibility = Visibility.Collapsed;

            ItsMaria.Set("TML2050_R01", "LIST_CALLEMP");
            ItsMaria.AddOne("LINECD", MODEL_S1.GetValue("LINECD"));
            ItsMaria.AddOne("EQMTP", EQMTP_LIST.Value);
            ItsMaria.AddOne("EQMGROUP1", EQMGROUP1_LIST.Value);
            if (selEqmList.Count == 0)
            {
                ItsMaria.AddOne("EQMCD_LIST", "");
            }
            foreach (string eqmcd in selEqmList)
            {
                ItsMaria.AddList("EQMCD_LIST", eqmcd);
            }
            DataTable dt = ItsMaria.Call().Tables[0];
            if (ItsMaria.IsError)
            {
                ShowMessageBox("", ItsMaria.ErrMessage);
                return;
            }

            CALLEMP_LIST.ButtonWidth = "200";
            CALLEMP_LIST.ButtonHeight = "56";
            CALLEMP_LIST.ButtonBackColor = COLOR_FILTER;
            CALLEMP_LIST.ButtonSelectBackColor = COLOR_FILTER_SELECT;

            bool hasTmlEmp = false;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string empcd = ItsData.GetText(dt, i, "EMPCD");
                if (empcd == ItsLocalInfo.TMLEMP) hasTmlEmp = true;
                CALLEMP_LIST.AddButton(ItsData.GetText(dt, i, "EMPNM"), empcd);
            }
            StyleButtonList(CALLEMP_LIST, 20);

            //1명뿐이면 자동 선택, 로그인 작업자가 목록에 있으면 그 사람을 기본 선택
            if (dt.Rows.Count == 1)
            {
                CALLEMP_LIST.Value = ItsData.GetText(dt, 0, "EMPCD");
            }
            else if (hasTmlEmp)
            {
                CALLEMP_LIST.Value = ItsLocalInfo.TMLEMP;
            }

            txt_CALLEMP_EMPTY.Visibility = dt.Rows.Count == 0 ? Visibility.Visible : Visibility.Collapsed;
        }

        //지난 단계는 회색 ✔, 지금 단계는 빨강 굵게, 남은 단계는 회색
        private void SetStepText(TextBlock tb, int nowStep, int myStep)
        {
            string[] names = { "", "설비", "호출이유", "호출자" };
            string[] nums = { "", "①", "②", "③" };

            tb.Text = (myStep < nowStep ? "✔ " : nums[myStep] + " ") + names[myStep];
            tb.FontWeight = myStep == nowStep ? FontWeights.Bold : FontWeights.Normal;
            tb.Foreground = ToBrush(myStep == nowStep ? COLOR_CALL : "#78909C");
        }

        private string GetEqmText()
        {
            if (selEqmList.Count == 0) return "라인 전체 (설비 모름)";
            return string.Join(", ", selEqmList.Select(x => GetDicText(eqmNmDic, x)).ToArray());
        }

        private string GetReasonText()
        {
            if (REASON_LIST.Value == REASON_ETC) return MODEL_A1.GetText("REASON_ETC").Trim();
            return GetDicText(reasonNmDic, REASON_LIST.Value); //호출이력 REMARK 에는 사유명 저장
        }

        //호출이유 목록: 공통코드 생기팀 호출사유(EQMCALLRSN) + 마지막에 [직접 입력]
        private void LoadReasons()
        {
            REASON_LIST.Clear();
            reasonNmDic.Clear();
            PANEL_REASON_ETC.Visibility = Visibility.Collapsed;

            ItsMaria.Set("TML2050_R01", "LIST_REASON");
            ItsMaria.AddOne("LINECD", MODEL_S1.GetValue("LINECD"));
            DataTable dt = ItsMaria.Call().Tables[0];
            if (ItsMaria.IsError)
            {
                ShowMessageBox("", ItsMaria.ErrMessage);
                dt = new DataTable();
            }

            REASON_LIST.ButtonWidth = "150";
            REASON_LIST.ButtonHeight = "50";
            REASON_LIST.ButtonBackColor = COLOR_FILTER;
            REASON_LIST.ButtonSelectBackColor = COLOR_FILTER_SELECT;

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                reasonNmDic[ItsData.GetText(dt, i, "RSNCD")] = ItsData.GetText(dt, i, "RSNNM");
                REASON_LIST.AddButton(ItsData.GetText(dt, i, "RSNNM"), ItsData.GetText(dt, i, "RSNCD"));
            }
            REASON_LIST.SelectColor(REASON_ETC, "#607D8B");
            REASON_LIST.AddButton("직접 입력", REASON_ETC);
            StyleButtonList(REASON_LIST, 18);

            txt_REASON_EMPTY.Visibility = dt.Rows.Count == 0 ? Visibility.Visible : Visibility.Collapsed;
        }

        //두레이 문자 전송 (추후 연결)
        private void SendCallNotice(string eqmcallkey)
        {
        }

        private void ClearEqmList()
        {
            EQM_LIST.Clear();
            selEqmList.Clear();
            callEqmSet.Clear();
            eqmNmDic.Clear();
        }

        //설비 버튼 색 다시 칠하기 (ButtonList는 하나만 선택되므로 선택 목록 기준으로 색 지정)
        private void PaintEqmList()
        {
            foreach (string eqmcd in eqmNmDic.Keys)
            {
                string color = COLOR_EQM;
                if (callEqmSet.Contains(eqmcd))
                {
                    color = COLOR_CALL;
                }
                else if (selEqmList.Contains(eqmcd))
                {
                    color = COLOR_EQM_SELECT;
                }
                EQM_LIST.SetBackColor(eqmcd, color, false);
            }
        }

        // ==================================================================== 공통

        private TextBlock MakeText(string text, double size, bool bold, string color)
        {
            TextBlock tb = new TextBlock();
            tb.Text = text;
            tb.FontFamily = UI_FONT;
            tb.FontSize = size;
            tb.FontWeight = bold ? FontWeights.Bold : FontWeights.Normal;
            tb.Foreground = ToBrush(color);
            tb.TextTrimming = TextTrimming.CharacterEllipsis;
            return tb;
        }

        private Brush ToBrush(string color)
        {
            return new SolidColorBrush((Color)ColorConverter.ConvertFromString(color));
        }

        //화면 안 글자를 맑은 고딕으로 (ITSLIB 컨트롤은 내부에 Roboto 가 고정되어 있음)
        private void ApplyFont(DependencyObject parent)
        {
            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(parent); i++)
            {
                DependencyObject child = VisualTreeHelper.GetChild(parent, i);
                if (child == HIS_LAYER) continue; //이력조회는 다른 현장 이력 메뉴와 같은 기본 글꼴 유지
                if (child is TextBlock)
                {
                    (child as TextBlock).FontFamily = UI_FONT;
                    if (VisualTreeHelper.GetParent(VisualTreeHelper.GetParent(child)) is Border
                        && ItsElement.FindParent<ITSLIB.Button>(child) != null)
                    {
                        (child as TextBlock).FontWeight = FontWeights.Bold; //버튼 글자는 굵게
                    }
                }
                else if (child is Control)
                {
                    (child as Control).FontFamily = UI_FONT;
                }
                ApplyFont(child);
            }
        }

        //ButtonList 안 버튼 글자 크기/글꼴 (AddButton 으로 만든 버튼은 10pt Roboto 로 고정)
        private void StyleButtonList(ButtonList list, double fontSize)
        {
            WrapPanel panel = list.FindName("PANEL_BTNLIST") as WrapPanel;
            if (panel == null) return;

            foreach (object child in panel.Children)
            {
                ITSLIB.Button btn = child as ITSLIB.Button;
                if (btn == null) continue;

                btn.SetFontSize = fontSize;
                TextBlock tb = btn.FindName("textBlock") as TextBlock;
                if (tb != null)
                {
                    tb.FontFamily = UI_FONT;
                    tb.FontWeight = FontWeights.Bold;
                }
            }
        }

        private string GetLineNm(string linecd)
        {
            if (lineNmDic.ContainsKey(linecd)) return lineNmDic[linecd];
            foreach (DataRow r in cb_LINECD.ModelCombo.Rows)
            {
                if (r["Value"].ToString() == linecd)
                {
                    return r["Label"].ToString();
                }
            }
            return linecd;
        }

        private string GetDicText(Dictionary<string, string> dic, string key)
        {
            return dic.ContainsKey(key) ? dic[key] : key;
        }
    }
}
