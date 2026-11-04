namespace ITSIF_INTERFACE
{
    partial class MainForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.timerClock = new System.Windows.Forms.Timer(this.components);
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblStatus = new System.Windows.Forms.Label();
            this.lblErrLog = new System.Windows.Forms.Label();
            this.btnSetting = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnRun = new System.Windows.Forms.Button();
            this.lblSubTitle = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.pnlStatusBar = new System.Windows.Forms.Panel();
            this.lblLastCheck = new System.Windows.Forms.Label();
            this.lblClock = new System.Windows.Forms.Label();
            this.pnlStatusLine = new System.Windows.Forms.Panel();
            this.pnlBody = new System.Windows.Forms.Panel();
            this.splitMain = new System.Windows.Forms.SplitContainer();
            this.pnlIfCard = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.IFNAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IFDESC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IFTYPE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CYCLE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.STATUS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CHECKTIME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OKCNT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NGCNT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblIfTitle = new System.Windows.Forms.Label();
            this.splitRight = new System.Windows.Forms.SplitContainer();
            this.pnlDataCard = new System.Windows.Forms.Panel();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.lblDataTitle = new System.Windows.Forms.Label();
            this.pnlLogCard = new System.Windows.Forms.Panel();
            this.dgvLog = new System.Windows.Forms.DataGridView();
            this.LOG_TIME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LOG_KIND = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LOG_NAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LOG_MSG = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblLogTitle = new System.Windows.Forms.Label();
            this.contextMenuStrip1.SuspendLayout();
            this.pnlHeader.SuspendLayout();
            this.pnlStatusBar.SuspendLayout();
            this.pnlBody.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitMain)).BeginInit();
            this.splitMain.Panel1.SuspendLayout();
            this.splitMain.Panel2.SuspendLayout();
            this.splitMain.SuspendLayout();
            this.pnlIfCard.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitRight)).BeginInit();
            this.splitRight.Panel1.SuspendLayout();
            this.splitRight.Panel2.SuspendLayout();
            this.splitRight.SuspendLayout();
            this.pnlDataCard.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.pnlLogCard.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLog)).BeginInit();
            this.SuspendLayout();
            //
            // contextMenuStrip1
            //
            this.contextMenuStrip1.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.toolStripSeparator1,
            this.closeToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(151, 54);
            //
            // openToolStripMenuItem
            //
            this.openToolStripMenuItem.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold);
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.openToolStripMenuItem.Text = "열기";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.notifyIcon1_DoubleClick);
            //
            // toolStripSeparator1
            //
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(147, 6);
            //
            // closeToolStripMenuItem
            //
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.closeToolStripMenuItem.Text = "프로그램종료";
            this.closeToolStripMenuItem.Click += new System.EventHandler(this.closeToolStripMenuItem_Click);
            //
            // notifyIcon1
            //
            this.notifyIcon1.ContextMenuStrip = this.contextMenuStrip1;
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "IF_MONITOR";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.DoubleClick += new System.EventHandler(this.notifyIcon1_DoubleClick);
            //
            // timerClock
            //
            this.timerClock.Enabled = true;
            this.timerClock.Interval = 1000;
            this.timerClock.Tick += new System.EventHandler(this.timerClock_Tick);
            //
            // pnlHeader
            //
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.pnlHeader.Controls.Add(this.lblErrLog);
            this.pnlHeader.Controls.Add(this.lblStatus);
            this.pnlHeader.Controls.Add(this.btnSetting);
            this.pnlHeader.Controls.Add(this.btnRefresh);
            this.pnlHeader.Controls.Add(this.btnRun);
            this.pnlHeader.Controls.Add(this.lblSubTitle);
            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(1440, 68);
            this.pnlHeader.TabIndex = 0;
            //
            // lblStatus
            //
            this.lblStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblStatus.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.lblStatus.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold);
            this.lblStatus.ForeColor = System.Drawing.Color.White;
            this.lblStatus.Location = new System.Drawing.Point(886, 21);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(130, 26);
            this.lblStatus.TabIndex = 2;
            this.lblStatus.Text = "●  중지됨";
            this.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //
            // lblErrLog
            //
            this.lblErrLog.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblErrLog.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.lblErrLog.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblErrLog.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold);
            this.lblErrLog.ForeColor = System.Drawing.Color.White;
            this.lblErrLog.Location = new System.Drawing.Point(744, 21);
            this.lblErrLog.Name = "lblErrLog";
            this.lblErrLog.Size = new System.Drawing.Size(130, 26);
            this.lblErrLog.TabIndex = 5;
            this.lblErrLog.Text = "에러 로그  -";
            this.lblErrLog.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblErrLog.Click += new System.EventHandler(this.lblErrLog_Click);
            //
            // btnSetting
            //
            this.btnSetting.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSetting.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(65)))), ((int)(((byte)(85)))));
            this.btnSetting.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSetting.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(65)))), ((int)(((byte)(85)))));
            this.btnSetting.FlatAppearance.BorderSize = 0;
            this.btnSetting.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.btnSetting.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSetting.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnSetting.ForeColor = System.Drawing.Color.White;
            this.btnSetting.Location = new System.Drawing.Point(1032, 16);
            this.btnSetting.Name = "btnSetting";
            this.btnSetting.Size = new System.Drawing.Size(120, 36);
            this.btnSetting.TabIndex = 6;
            this.btnSetting.Text = "설정";
            this.btnSetting.UseVisualStyleBackColor = false;
            this.btnSetting.Click += new System.EventHandler(this.btnSetting_Click);
            //
            // btnRefresh
            //
            this.btnRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRefresh.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(65)))), ((int)(((byte)(85)))));
            this.btnRefresh.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRefresh.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(65)))), ((int)(((byte)(85)))));
            this.btnRefresh.FlatAppearance.BorderSize = 0;
            this.btnRefresh.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefresh.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnRefresh.ForeColor = System.Drawing.Color.White;
            this.btnRefresh.Location = new System.Drawing.Point(1164, 16);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(120, 36);
            this.btnRefresh.TabIndex = 3;
            this.btnRefresh.Text = "새로고침";
            this.btnRefresh.UseVisualStyleBackColor = false;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            //
            // btnRun
            //
            this.btnRun.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRun.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(163)))), ((int)(((byte)(74)))));
            this.btnRun.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRun.FlatAppearance.BorderSize = 0;
            this.btnRun.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRun.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnRun.ForeColor = System.Drawing.Color.White;
            this.btnRun.Location = new System.Drawing.Point(1296, 16);
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(124, 36);
            this.btnRun.TabIndex = 4;
            this.btnRun.Text = "▶  실행";
            this.btnRun.UseVisualStyleBackColor = false;
            this.btnRun.Click += new System.EventHandler(this.btnRun_Click);
            //
            // lblSubTitle
            //
            this.lblSubTitle.AutoSize = true;
            this.lblSubTitle.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.lblSubTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(163)))), ((int)(((byte)(184)))));
            this.lblSubTitle.Location = new System.Drawing.Point(23, 42);
            this.lblSubTitle.Name = "lblSubTitle";
            this.lblSubTitle.Size = new System.Drawing.Size(150, 15);
            this.lblSubTitle.TabIndex = 1;
            this.lblSubTitle.Text = "ERP → MES 인터페이스";
            //
            // lblTitle
            //
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("맑은 고딕", 15.75F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(20, 10);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(136, 30);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "IF MONITOR";
            //
            // pnlStatusBar
            //
            this.pnlStatusBar.BackColor = System.Drawing.Color.White;
            this.pnlStatusBar.Controls.Add(this.lblLastCheck);
            this.pnlStatusBar.Controls.Add(this.lblClock);
            this.pnlStatusBar.Controls.Add(this.pnlStatusLine);
            this.pnlStatusBar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlStatusBar.Location = new System.Drawing.Point(0, 830);
            this.pnlStatusBar.Name = "pnlStatusBar";
            this.pnlStatusBar.Padding = new System.Windows.Forms.Padding(16, 0, 16, 0);
            this.pnlStatusBar.Size = new System.Drawing.Size(1440, 30);
            this.pnlStatusBar.TabIndex = 2;
            //
            // lblLastCheck
            //
            this.lblLastCheck.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblLastCheck.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblLastCheck.Location = new System.Drawing.Point(16, 1);
            this.lblLastCheck.Name = "lblLastCheck";
            this.lblLastCheck.Size = new System.Drawing.Size(1208, 29);
            this.lblLastCheck.TabIndex = 0;
            this.lblLastCheck.Text = "마지막 확인  -";
            this.lblLastCheck.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // lblClock
            //
            this.lblClock.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblClock.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblClock.Location = new System.Drawing.Point(1224, 1);
            this.lblClock.Name = "lblClock";
            this.lblClock.Size = new System.Drawing.Size(200, 29);
            this.lblClock.TabIndex = 1;
            this.lblClock.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            //
            // pnlStatusLine
            //
            this.pnlStatusLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.pnlStatusLine.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlStatusLine.Location = new System.Drawing.Point(16, 0);
            this.pnlStatusLine.Name = "pnlStatusLine";
            this.pnlStatusLine.Size = new System.Drawing.Size(1408, 1);
            this.pnlStatusLine.TabIndex = 2;
            //
            // pnlBody
            //
            this.pnlBody.Controls.Add(this.splitMain);
            this.pnlBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBody.Location = new System.Drawing.Point(0, 68);
            this.pnlBody.Name = "pnlBody";
            this.pnlBody.Padding = new System.Windows.Forms.Padding(16);
            this.pnlBody.Size = new System.Drawing.Size(1440, 762);
            this.pnlBody.TabIndex = 1;
            //
            // splitMain
            //
            this.splitMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitMain.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitMain.Location = new System.Drawing.Point(16, 16);
            this.splitMain.Name = "splitMain";
            //
            // splitMain.Panel1
            //
            this.splitMain.Panel1.Controls.Add(this.pnlIfCard);
            this.splitMain.Panel1MinSize = 240;
            //
            // splitMain.Panel2
            //
            this.splitMain.Panel2.Controls.Add(this.splitRight);
            this.splitMain.Size = new System.Drawing.Size(1408, 730);
            this.splitMain.SplitterDistance = 700;
            this.splitMain.SplitterWidth = 14;
            this.splitMain.TabIndex = 0;
            //
            // pnlIfCard
            //
            this.pnlIfCard.BackColor = System.Drawing.Color.White;
            this.pnlIfCard.Controls.Add(this.dataGridView1);
            this.pnlIfCard.Controls.Add(this.lblIfTitle);
            this.pnlIfCard.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlIfCard.Location = new System.Drawing.Point(0, 0);
            this.pnlIfCard.Name = "pnlIfCard";
            this.pnlIfCard.Padding = new System.Windows.Forms.Padding(14, 4, 14, 14);
            this.pnlIfCard.Size = new System.Drawing.Size(380, 730);
            this.pnlIfCard.TabIndex = 0;
            //
            // dataGridView1
            //
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IFNAME,
            this.IFDESC,
            this.IFTYPE,
            this.CYCLE,
            this.STATUS,
            this.CHECKTIME,
            this.OKCNT,
            this.NGCNT});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(14, 44);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(352, 672);
            this.dataGridView1.TabIndex = 1;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            this.dataGridView1.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataGridView1_CellFormatting);
            //
            // IFNAME
            //
            this.IFNAME.DataPropertyName = "IFNAME";
            this.IFNAME.FillWeight = 130F;
            this.IFNAME.HeaderText = "IF명";
            this.IFNAME.Name = "IFNAME";
            //
            // IFDESC
            //
            this.IFDESC.DataPropertyName = "IFDESC";
            this.IFDESC.FillWeight = 100F;
            this.IFDESC.HeaderText = "설명";
            this.IFDESC.Name = "IFDESC";
            //
            // IFTYPE
            //
            this.IFTYPE.DataPropertyName = "IFTYPE";
            this.IFTYPE.FillWeight = 70F;
            this.IFTYPE.HeaderText = "IF유형";
            this.IFTYPE.Name = "IFTYPE";
            this.IFTYPE.Visible = false;
            //
            // CYCLE
            //
            this.CYCLE.DataPropertyName = "CYCLE";
            this.CYCLE.FillWeight = 40F;
            this.CYCLE.HeaderText = "주기";
            this.CYCLE.Name = "CYCLE";
            //
            // STATUS
            //
            this.STATUS.DataPropertyName = "STATUS";
            this.STATUS.FillWeight = 70F;
            this.STATUS.HeaderText = "상태";
            this.STATUS.Name = "STATUS";
            //
            // CHECKTIME
            //
            this.CHECKTIME.DataPropertyName = "CHECKTIME";
            this.CHECKTIME.FillWeight = 55F;
            this.CHECKTIME.HeaderText = "확인시각";
            this.CHECKTIME.Name = "CHECKTIME";
            //
            // OKCNT
            //
            this.OKCNT.DataPropertyName = "OKCNT";
            this.OKCNT.FillWeight = 40F;
            this.OKCNT.HeaderText = "처리";
            this.OKCNT.Name = "OKCNT";
            //
            // NGCNT
            //
            this.NGCNT.DataPropertyName = "NGCNT";
            this.NGCNT.FillWeight = 40F;
            this.NGCNT.HeaderText = "오류";
            this.NGCNT.Name = "NGCNT";
            //
            // lblIfTitle
            //
            this.lblIfTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblIfTitle.Font = new System.Drawing.Font("맑은 고딕", 11.25F, System.Drawing.FontStyle.Bold);
            this.lblIfTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.lblIfTitle.Location = new System.Drawing.Point(14, 4);
            this.lblIfTitle.Name = "lblIfTitle";
            this.lblIfTitle.Size = new System.Drawing.Size(352, 40);
            this.lblIfTitle.TabIndex = 0;
            this.lblIfTitle.Text = "수집 현황";
            this.lblIfTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // splitRight
            //
            this.splitRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitRight.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitRight.Location = new System.Drawing.Point(0, 0);
            this.splitRight.Name = "splitRight";
            this.splitRight.Orientation = System.Windows.Forms.Orientation.Horizontal;
            //
            // splitRight.Panel1
            //
            this.splitRight.Panel1.Controls.Add(this.pnlDataCard);
            this.splitRight.Panel1MinSize = 160;
            //
            // splitRight.Panel2
            //
            this.splitRight.Panel2.Controls.Add(this.pnlLogCard);
            this.splitRight.Panel2MinSize = 120;
            this.splitRight.Size = new System.Drawing.Size(1014, 730);
            this.splitRight.SplitterDistance = 470;
            this.splitRight.SplitterWidth = 14;
            this.splitRight.TabIndex = 0;
            //
            // pnlDataCard
            //
            this.pnlDataCard.BackColor = System.Drawing.Color.White;
            this.pnlDataCard.Controls.Add(this.dataGridView2);
            this.pnlDataCard.Controls.Add(this.lblDataTitle);
            this.pnlDataCard.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlDataCard.Location = new System.Drawing.Point(0, 0);
            this.pnlDataCard.Name = "pnlDataCard";
            this.pnlDataCard.Padding = new System.Windows.Forms.Padding(14, 4, 14, 14);
            this.pnlDataCard.Size = new System.Drawing.Size(1014, 470);
            this.pnlDataCard.TabIndex = 0;
            //
            // dataGridView2
            //
            this.dataGridView2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView2.Location = new System.Drawing.Point(14, 44);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.Size = new System.Drawing.Size(986, 412);
            this.dataGridView2.TabIndex = 1;
            //
            // lblDataTitle
            //
            this.lblDataTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblDataTitle.Font = new System.Drawing.Font("맑은 고딕", 11.25F, System.Drawing.FontStyle.Bold);
            this.lblDataTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.lblDataTitle.Location = new System.Drawing.Point(14, 4);
            this.lblDataTitle.Name = "lblDataTitle";
            this.lblDataTitle.Size = new System.Drawing.Size(986, 40);
            this.lblDataTitle.TabIndex = 0;
            this.lblDataTitle.Text = "수신 데이터";
            this.lblDataTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // pnlLogCard
            //
            this.pnlLogCard.BackColor = System.Drawing.Color.White;
            this.pnlLogCard.Controls.Add(this.dgvLog);
            this.pnlLogCard.Controls.Add(this.lblLogTitle);
            this.pnlLogCard.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlLogCard.Location = new System.Drawing.Point(0, 0);
            this.pnlLogCard.Name = "pnlLogCard";
            this.pnlLogCard.Padding = new System.Windows.Forms.Padding(14, 4, 14, 14);
            this.pnlLogCard.Size = new System.Drawing.Size(1014, 246);
            this.pnlLogCard.TabIndex = 0;
            //
            // dgvLog
            //
            this.dgvLog.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.LOG_TIME,
            this.LOG_KIND,
            this.LOG_NAME,
            this.LOG_MSG});
            this.dgvLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvLog.Location = new System.Drawing.Point(14, 44);
            this.dgvLog.Name = "dgvLog";
            this.dgvLog.Size = new System.Drawing.Size(986, 188);
            this.dgvLog.TabIndex = 1;
            //
            // LOG_TIME
            //
            this.LOG_TIME.FillWeight = 16F;
            this.LOG_TIME.HeaderText = "시간";
            this.LOG_TIME.Name = "LOG_TIME";
            //
            // LOG_KIND
            //
            this.LOG_KIND.FillWeight = 10F;
            this.LOG_KIND.HeaderText = "구분";
            this.LOG_KIND.Name = "LOG_KIND";
            //
            // LOG_NAME
            //
            this.LOG_NAME.FillWeight = 20F;
            this.LOG_NAME.HeaderText = "IF명";
            this.LOG_NAME.Name = "LOG_NAME";
            //
            // LOG_MSG
            //
            this.LOG_MSG.FillWeight = 74F;
            this.LOG_MSG.HeaderText = "내용";
            this.LOG_MSG.Name = "LOG_MSG";
            //
            // lblLogTitle
            //
            this.lblLogTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblLogTitle.Font = new System.Drawing.Font("맑은 고딕", 11.25F, System.Drawing.FontStyle.Bold);
            this.lblLogTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.lblLogTitle.Location = new System.Drawing.Point(14, 4);
            this.lblLogTitle.Name = "lblLogTitle";
            this.lblLogTitle.Size = new System.Drawing.Size(986, 40);
            this.lblLogTitle.TabIndex = 0;
            this.lblLogTitle.Text = "최근 처리 이력";
            this.lblLogTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // MainForm
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            this.ClientSize = new System.Drawing.Size(1440, 860);
            this.Controls.Add(this.pnlBody);
            this.Controls.Add(this.pnlStatusBar);
            this.Controls.Add(this.pnlHeader);
            this.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(1000, 640);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "IF_MONITOR";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.contextMenuStrip1.ResumeLayout(false);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlStatusBar.ResumeLayout(false);
            this.pnlBody.ResumeLayout(false);
            this.splitMain.Panel1.ResumeLayout(false);
            this.splitMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitMain)).EndInit();
            this.splitMain.ResumeLayout(false);
            this.pnlIfCard.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.splitRight.Panel1.ResumeLayout(false);
            this.splitRight.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitRight)).EndInit();
            this.splitRight.ResumeLayout(false);
            this.pnlDataCard.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.pnlLogCard.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLog)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.Timer timerClock;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblSubTitle;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label lblErrLog;
        private System.Windows.Forms.Button btnSetting;
        private System.Windows.Forms.DataGridViewTextBoxColumn STATUS;
        private System.Windows.Forms.DataGridViewTextBoxColumn CHECKTIME;
        private System.Windows.Forms.DataGridViewTextBoxColumn OKCNT;
        private System.Windows.Forms.DataGridViewTextBoxColumn NGCNT;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnRun;
        private System.Windows.Forms.Panel pnlStatusBar;
        private System.Windows.Forms.Panel pnlStatusLine;
        private System.Windows.Forms.Label lblLastCheck;
        private System.Windows.Forms.Label lblClock;
        private System.Windows.Forms.Panel pnlBody;
        private System.Windows.Forms.SplitContainer splitMain;
        private System.Windows.Forms.Panel pnlIfCard;
        private System.Windows.Forms.Label lblIfTitle;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn IFNAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn IFDESC;
        private System.Windows.Forms.DataGridViewTextBoxColumn IFTYPE;
        private System.Windows.Forms.DataGridViewTextBoxColumn CYCLE;
        private System.Windows.Forms.SplitContainer splitRight;
        private System.Windows.Forms.Panel pnlDataCard;
        private System.Windows.Forms.Label lblDataTitle;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.Panel pnlLogCard;
        private System.Windows.Forms.Label lblLogTitle;
        private System.Windows.Forms.DataGridView dgvLog;
        private System.Windows.Forms.DataGridViewTextBoxColumn LOG_TIME;
        private System.Windows.Forms.DataGridViewTextBoxColumn LOG_KIND;
        private System.Windows.Forms.DataGridViewTextBoxColumn LOG_NAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn LOG_MSG;
    }
}

