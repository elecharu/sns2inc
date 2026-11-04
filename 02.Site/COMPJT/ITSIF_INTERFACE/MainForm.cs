using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace ITSIF_INTERFACE
{
    public partial class MainForm : Form
    {
        // 화면 색상
        private static readonly Color COLOR_RUN = Color.FromArgb(22, 163, 74);
        private static readonly Color COLOR_STOP = Color.FromArgb(220, 38, 38);
        private static readonly Color COLOR_IDLE = Color.FromArgb(71, 85, 105);
        private static readonly Color COLOR_WARN = Color.FromArgb(217, 119, 6);
        private static readonly Color COLOR_TEXT = Color.FromArgb(30, 41, 59);
        private static readonly Color COLOR_SUBTEXT = Color.FromArgb(100, 116, 139);
        private static readonly Font FONT_BOLD = new Font("맑은 고딕", 9F, FontStyle.Bold);

        // 처리이력 최대 표시 건수
        private const int LOG_MAX = 500;

        public MainForm()
        {
            InitializeComponent();

            //프로그램 버전 확인
            Version version = Assembly.GetEntryAssembly().GetName().Version;
            this.Text += " Ver." + version;
            lblSubTitle.Text += "   ·   Ver." + version;

            SetGridStyle(dataGridView1);
            SetGridStyle(dataGridView2);
            SetGridStyle(dgvLog);
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvLog.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            MainLoop.This.LogAdded += MainLoop_LogAdded;
            MainLoop.This.ErrLogChecked += MainLoop_ErrLogChecked;
            MainLoop.This.IFStatusChanged += MainLoop_IFStatusChanged;
            MainLoop.This.IFDescChanged += MainLoop_IFDescChanged;
        }

        // 그리드 공통 스타일
        private void SetGridStyle(DataGridView grid)
        {
            grid.BorderStyle = BorderStyle.None;
            grid.BackgroundColor = Color.White;
            grid.GridColor = Color.FromArgb(238, 241, 245);
            grid.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            grid.RowHeadersVisible = false;
            grid.AllowUserToAddRows = false;
            grid.AllowUserToDeleteRows = false;
            grid.AllowUserToResizeRows = false;
            grid.ReadOnly = true;
            grid.MultiSelect = false;
            grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            grid.RowTemplate.Height = 30;

            grid.EnableHeadersVisualStyles = false;
            grid.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            grid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            grid.ColumnHeadersHeight = 34;
            grid.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(248, 250, 252);
            grid.ColumnHeadersDefaultCellStyle.ForeColor = COLOR_SUBTEXT;
            grid.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.FromArgb(248, 250, 252);
            grid.ColumnHeadersDefaultCellStyle.Font = FONT_BOLD;
            grid.ColumnHeadersDefaultCellStyle.Padding = new Padding(6, 0, 0, 0);
            grid.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.False;

            grid.DefaultCellStyle.ForeColor = COLOR_TEXT;
            grid.DefaultCellStyle.SelectionBackColor = Color.FromArgb(219, 234, 254);
            grid.DefaultCellStyle.SelectionForeColor = COLOR_TEXT;
            grid.DefaultCellStyle.Padding = new Padding(6, 0, 0, 0);
            grid.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(250, 251, 253);
        }

        private void ShowErrMsg(string errmsg)
        {
            AddLogRow("ERR", "", errmsg);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            // 접속설정이 없을 때만 설정화면을 띄운다 (저장해 두면 다음부터는 바로 시작)
            if (!IfConfig.IsConfigured())
            {
                using (SettingForm f = new SettingForm())
                {
                    f.ShowDialog(this);
                }
            }

            LoadIFList();

            // 설정돼 있고 자동실행이면 바로 수집 시작
            bool autoRun = IfConfig.IsConfigured() && IfConfig.AutoRun;
            SetRunState(autoRun);
            if (autoRun)
            {
                AddLogRow("OK", "", "자동 실행 - 수집을 시작합니다. (ERP: " + IfConfig.ErpDbType + " " + IfConfig.ErpHost + ")");
            }

            Workspace.This.MainStart();
        }

        // 수집현황 표 (IF_INTERFACE LIST 결과 + 화면에서 채우는 상태 컬럼)
        private DataTable dtStatus = null;

        // IF목록 조회
        private void LoadIFList()
        {
            DataTable dt;
            string errMsg = null;
            try
            {
                lock (MainLoop.This.DbLock)
                {
                    ItsMaria.Set("IF_INTERFACE", "LIST");
                    dt = ItsMaria.Call().Tables[0];
                    if (ItsMaria.IsError) errMsg = ItsMaria.ErrMessage;
                }
            }
            catch (Exception ex)
            {
                // MariaConfig.txt 가 없을 때 등
                ShowErrMsg(ex.Message);
                return;
            }
            if (errMsg != null)
            {
                ShowErrMsg(errMsg);
                return;
            }

            dt.Columns.Add("STATUS", typeof(string));
            dt.Columns.Add("IFDESC", typeof(string));
            dt.Columns.Add("CHECKTIME", typeof(string));
            dt.Columns.Add("OKCNT", typeof(int));
            dt.Columns.Add("NGCNT", typeof(int));

            // 새로고침해도 지금까지의 수집현황은 이어서 보여준다
            foreach (DataRow row in dt.Rows)
            {
                DataRow old = FindStatusRow(dtStatus, row["IFNAME"].ToString());
                row["STATUS"] = old != null ? old["STATUS"] : "";
                row["IFDESC"] = old != null ? old["IFDESC"] : "";
                row["CHECKTIME"] = old != null ? old["CHECKTIME"] : "";
                row["OKCNT"] = old != null ? old["OKCNT"] : 0;
                row["NGCNT"] = old != null ? old["NGCNT"] : 0;
            }

            dtStatus = dt;
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = dtStatus;
            lblIfTitle.Text = "수집 현황  (" + dt.Rows.Count + ")";
        }

        private DataRow FindStatusRow(DataTable dt, string name)
        {
            if (dt == null) return null;

            foreach (DataRow row in dt.Rows)
            {
                if (row["IFNAME"].ToString() == name) return row;
            }
            return null;
        }

        // 루프 스레드에서 올라오므로 화면 스레드로 넘긴다
        private void MainLoop_IFStatusChanged(string name, string status, int okCnt, int ngCnt)
        {
            if (!this.IsHandleCreated || this.IsDisposed) return;

            this.BeginInvoke(new Action(() => ShowIFStatus(name, status, okCnt, ngCnt)));
        }

        private void ShowIFStatus(string name, string status, int okCnt, int ngCnt)
        {
            if (dtStatus == null) return;

            DataRow row = FindStatusRow(dtStatus, name);
            if (row == null)
            {
                // LIST 에 없는 IF 가 수집되면 줄을 추가한다
                row = dtStatus.NewRow();
                row["IFNAME"] = name;
                row["OKCNT"] = 0;
                row["NGCNT"] = 0;
                dtStatus.Rows.Add(row);
            }

            row["STATUS"] = status;
            row["CHECKTIME"] = DateTime.Now.ToString("HH:mm:ss");
            row["OKCNT"] = Convert.ToInt32(row["OKCNT"]) + okCnt;
            row["NGCNT"] = Convert.ToInt32(row["NGCNT"]) + ngCnt;
        }

        // RECEIVE 로 받은 IF 설명 - 루프 스레드에서 올라오므로 화면 스레드로 넘긴다
        private void MainLoop_IFDescChanged(string name, string desc)
        {
            if (!this.IsHandleCreated || this.IsDisposed) return;

            this.BeginInvoke(new Action(() =>
            {
                DataRow row = FindStatusRow(dtStatus, name);
                if (row != null) row["IFDESC"] = desc;
            }));
        }

        // 상태별 글자색
        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0 || dataGridView1.Columns[e.ColumnIndex].Name != "STATUS" || e.Value == null) return;

            string status = e.Value.ToString();
            if (status == "완료") e.CellStyle.ForeColor = COLOR_RUN;
            else if (status == "오류") e.CellStyle.ForeColor = COLOR_STOP;
            else if (status == "일부 오류") e.CellStyle.ForeColor = COLOR_WARN;
            else if (status == "ERP 조회중" || status == "MES 반영중") e.CellStyle.ForeColor = Color.FromArgb(37, 99, 235);
            else e.CellStyle.ForeColor = COLOR_SUBTEXT;

            e.CellStyle.SelectionForeColor = e.CellStyle.ForeColor;
            e.CellStyle.Font = FONT_BOLD;
        }

        // DB 접속 설정
        private void btnSetting_Click(object sender, EventArgs e)
        {
            using (SettingForm f = new SettingForm())
            {
                if (f.ShowDialog(this) == DialogResult.OK)
                {
                    AddLogRow("OK", "", "DB 접속설정을 저장했습니다.");
                    LoadIFList();
                }
            }
        }

        private bool IsClose = false;
        private bool IsTrayNoticeShown = false;
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (IsClose == true) return;

            e.Cancel = true;
            this.Visible = false;

            // 처음 숨길 때만 트레이에서 계속 실행중임을 알린다
            if (!IsTrayNoticeShown)
            {
                IsTrayNoticeShown = true;
                notifyIcon1.ShowBalloonTip(3000, "IF_MONITOR", "트레이에서 계속 실행중입니다.", ToolTipIcon.Info);
            }
        }

        private void notifyIcon1_DoubleClick(object sender, EventArgs e)
        {
            this.Visible = true;
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.WindowState = FormWindowState.Normal;
            }
            this.Activate();
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MainLoop.This.IFTaskFlag)
            {
                if (MessageBox.Show("인터페이스가 실행중입니다.\n\n프로그램을 종료할까요?", "IF_MONITOR", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes)
                {
                    return;
                }
            }

            this.IsClose = true;
            notifyIcon1.Visible = false;
            this.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // 헤더 클릭은 무시
            if (e.RowIndex < 0) return;

            object ifName = dataGridView1.Rows[e.RowIndex].Cells["IFNAME"].Value;
            if (ifName == null || ifName.ToString() == "") return;

            DataTable dt;
            string errMsg = null;
            try
            {
                lock (MainLoop.This.DbLock)
                {
                    ItsMaria.Set("IF_INTERFACE", "VIEW_DATA");
                    ItsMaria.AddOne("IFNAME", ifName.ToString());
                    dt = ItsMaria.Call().Tables[0];
                    if (ItsMaria.IsError) errMsg = ItsMaria.ErrMessage;
                }
            }
            catch (Exception ex)
            {
                ShowErrMsg(ex.Message);
                return;
            }
            if (errMsg != null)
            {
                ShowErrMsg(errMsg);
                return;
            }

            dataGridView2.Columns.Clear();
            dataGridView2.DataSource = dt;
            dataGridView2.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.DisplayedCells);

            lblDataTitle.Text = "수신 데이터  ·  " + ifName + "  (" + dt.Rows.Count + ")";
        }

        // IF목록 갱신
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadIFList();
        }

        // IF실행 버튼
        private void btnRun_Click(object sender, EventArgs e)
        {
            SetRunState(!MainLoop.This.IFTaskFlag);
        }

        private void SetRunState(bool run)
        {
            MainLoop.This.IFTaskFlag = run;

            if (run)
            {
                btnRun.Text = "■  중지";
                btnRun.BackColor = COLOR_STOP;
                btnRun.FlatAppearance.BorderColor = COLOR_STOP;
                lblStatus.Text = "●  실행중";
                lblStatus.BackColor = COLOR_RUN;
                notifyIcon1.Text = "IF_MONITOR - 실행중";
            }
            else
            {
                btnRun.Text = "▶  실행";
                btnRun.BackColor = COLOR_RUN;
                btnRun.FlatAppearance.BorderColor = COLOR_RUN;
                lblStatus.Text = "●  중지됨";
                lblStatus.BackColor = COLOR_IDLE;
                notifyIcon1.Text = "IF_MONITOR - 중지됨";
            }
        }

        // 루프 스레드에서 올라오므로 화면 스레드로 넘긴다
        private void MainLoop_LogAdded(string kind, string name, string message)
        {
            if (!this.IsHandleCreated || this.IsDisposed) return;

            this.BeginInvoke(new Action(() => AddLogRow(kind, name, message)));
        }

        private void AddLogRow(string kind, string name, string message)
        {
            dgvLog.Rows.Insert(0, DateTime.Now.ToString("HH:mm:ss"), kind, name, message);

            DataGridViewCell kindCell = dgvLog.Rows[0].Cells["LOG_KIND"];
            kindCell.Style.Font = FONT_BOLD;
            if (kind == "OK") kindCell.Style.ForeColor = COLOR_RUN;
            else if (kind == "NG") kindCell.Style.ForeColor = COLOR_WARN;
            else kindCell.Style.ForeColor = COLOR_STOP;
            kindCell.Style.SelectionForeColor = kindCell.Style.ForeColor;
            dgvLog.ClearSelection();

            while (dgvLog.Rows.Count > LOG_MAX)
            {
                dgvLog.Rows.RemoveAt(dgvLog.Rows.Count - 1);
            }
        }

        // 루프 스레드에서 올라오므로 화면 스레드로 넘긴다
        private void MainLoop_ErrLogChecked(int count, int newCnt, DataTable newRows)
        {
            if (!this.IsHandleCreated || this.IsDisposed) return;

            this.BeginInvoke(new Action(() => ShowErrLogState(count, newCnt, newRows)));
        }

        private bool IsErrLogChecked = false;
        private void ShowErrLogState(int count, int newCnt, DataTable newRows)
        {
            lblErrLog.Text = "에러 로그  " + count + "건";
            lblErrLog.BackColor = count > 0 ? COLOR_STOP : COLOR_IDLE;

            if (newRows != null)
            {
                // 오래된 것부터 넣어 최신이 위로 오게 한다
                for (int i = newRows.Rows.Count - 1; i >= 0; i--)
                {
                    AddLogRow("ERR", newRows.Rows[i]["IFNAME"].ToString(), "[IF_ERR_LOG] " + newRows.Rows[i]["ERRMSG"]);
                }
                notifyIcon1.ShowBalloonTip(5000, "IF_MONITOR", "IF 에러 로그가 " + newCnt + "건 새로 쌓였습니다.", ToolTipIcon.Error);
            }
            else if (!IsErrLogChecked && count > 0)
            {
                // 프로그램 시작 시 이미 쌓여 있던 에러 로그
                notifyIcon1.ShowBalloonTip(5000, "IF_MONITOR", "IF 에러 로그가 " + count + "건 있습니다.", ToolTipIcon.Warning);
            }
            IsErrLogChecked = true;
        }

        // 에러 로그 배지 클릭 시 IF_ERR_LOG 내용을 데이터 영역에 보여준다
        private void lblErrLog_Click(object sender, EventArgs e)
        {
            DataTable dt;
            string errMsg = null;
            try
            {
                lock (MainLoop.This.DbLock)
                {
                    dt = ItsMaria.Query("SELECT * FROM IF_ERR_LOG ORDER BY READTIME DESC LIMIT 500;").Tables[0];
                    if (ItsMaria.IsError) errMsg = ItsMaria.ErrMessage;
                }
            }
            catch (Exception ex)
            {
                ShowErrMsg(ex.Message);
                return;
            }
            if (errMsg != null)
            {
                ShowErrMsg(errMsg);
                return;
            }

            dataGridView1.ClearSelection();
            dataGridView2.Columns.Clear();
            dataGridView2.DataSource = dt;
            dataGridView2.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.DisplayedCells);

            lblDataTitle.Text = "에러 로그  ·  IF_ERR_LOG  (" + dt.Rows.Count + ")";
        }

        private void timerClock_Tick(object sender, EventArgs e)
        {
            lblClock.Text = DateTime.Now.ToString("yyyy-MM-dd  HH:mm:ss");

            DateTime last = MainLoop.This.LastCheckTime;
            string current = MainLoop.This.CurrentIF == "" ? "-" : MainLoop.This.CurrentIF + "  ·  " + MainLoop.This.CurrentStatus;
            lblLastCheck.Text = "마지막 확인  " + (last == DateTime.MinValue ? "-" : last.ToString("HH:mm:ss")) + "        현재 수집  " + current;
        }
    }
}
