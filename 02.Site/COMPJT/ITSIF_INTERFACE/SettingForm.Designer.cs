namespace ITSIF_INTERFACE
{
    partial class SettingForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblDesc = new System.Windows.Forms.Label();
            this.lblMariaTitle = new System.Windows.Forms.Label();
            this.btnMariaTest = new System.Windows.Forms.Button();
            this.lblMesType = new System.Windows.Forms.Label();
            this.cboMesType = new System.Windows.Forms.ComboBox();
            this.lblMariaHost = new System.Windows.Forms.Label();
            this.txtMariaHost = new System.Windows.Forms.TextBox();
            this.lblMariaPort = new System.Windows.Forms.Label();
            this.txtMariaPort = new System.Windows.Forms.TextBox();
            this.lblMariaDb = new System.Windows.Forms.Label();
            this.txtMariaDb = new System.Windows.Forms.TextBox();
            this.lblMariaUser = new System.Windows.Forms.Label();
            this.txtMariaUser = new System.Windows.Forms.TextBox();
            this.lblMariaPass = new System.Windows.Forms.Label();
            this.txtMariaPass = new System.Windows.Forms.TextBox();
            this.lblErpTitle = new System.Windows.Forms.Label();
            this.btnErpTest = new System.Windows.Forms.Button();
            this.lblErpType = new System.Windows.Forms.Label();
            this.cboErpType = new System.Windows.Forms.ComboBox();
            this.lblErpHost = new System.Windows.Forms.Label();
            this.txtErpHost = new System.Windows.Forms.TextBox();
            this.lblErpPort = new System.Windows.Forms.Label();
            this.txtErpPort = new System.Windows.Forms.TextBox();
            this.lblErpDb = new System.Windows.Forms.Label();
            this.txtErpDb = new System.Windows.Forms.TextBox();
            this.lblErpUser = new System.Windows.Forms.Label();
            this.txtErpUser = new System.Windows.Forms.TextBox();
            this.lblErpPass = new System.Windows.Forms.Label();
            this.txtErpPass = new System.Windows.Forms.TextBox();
            this.chkAutoRun = new System.Windows.Forms.CheckBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            //
            // lblTitle
            //
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("맑은 고딕", 14.25F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.lblTitle.Location = new System.Drawing.Point(22, 16);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(126, 25);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "DB 접속 설정";
            //
            // lblDesc
            //
            this.lblDesc.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblDesc.Location = new System.Drawing.Point(24, 44);
            this.lblDesc.Name = "lblDesc";
            this.lblDesc.Size = new System.Drawing.Size(452, 34);
            this.lblDesc.TabIndex = 1;
            this.lblDesc.Text = "송신 DB 에서 데이터를 읽어 수신 DB 로 넘깁니다.\r\n저장한 설정은 실행 파일 폴더에 남아 다음 실행에도 그대로 쓰입니다.";
            //
            // lblMariaTitle
            //
            this.lblMariaTitle.AutoSize = true;
            this.lblMariaTitle.Font = new System.Drawing.Font("맑은 고딕", 10.5F, System.Drawing.FontStyle.Bold);
            this.lblMariaTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(99)))), ((int)(((byte)(235)))));
            this.lblMariaTitle.Location = new System.Drawing.Point(22, 350);
            this.lblMariaTitle.Name = "lblMariaTitle";
            this.lblMariaTitle.Size = new System.Drawing.Size(130, 19);
            this.lblMariaTitle.TabIndex = 10;
            this.lblMariaTitle.Text = "수신 DB  ·  데이터를 받는 쪽";
            //
            // btnMariaTest
            //
            this.btnMariaTest.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            this.btnMariaTest.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMariaTest.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(213)))), ((int)(((byte)(225)))));
            this.btnMariaTest.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMariaTest.Location = new System.Drawing.Point(366, 345);
            this.btnMariaTest.Name = "btnMariaTest";
            this.btnMariaTest.Size = new System.Drawing.Size(110, 28);
            this.btnMariaTest.TabIndex = 17;
            this.btnMariaTest.Text = "연결 테스트";
            this.btnMariaTest.UseVisualStyleBackColor = false;
            this.btnMariaTest.Click += new System.EventHandler(this.btnMariaTest_Click);
            //
            // lblMesType
            //
            this.lblMesType.Location = new System.Drawing.Point(24, 386);
            this.lblMesType.Name = "lblMesType";
            this.lblMesType.Size = new System.Drawing.Size(90, 25);
            this.lblMesType.TabIndex = 0;
            this.lblMesType.Text = "DB 종류";
            this.lblMesType.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // cboMesType
            //
            this.cboMesType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMesType.Location = new System.Drawing.Point(120, 386);
            this.cboMesType.Name = "cboMesType";
            this.cboMesType.Size = new System.Drawing.Size(200, 23);
            this.cboMesType.TabIndex = 11;
            //
            // lblMariaHost
            //
            this.lblMariaHost.Location = new System.Drawing.Point(24, 418);
            this.lblMariaHost.Name = "lblMariaHost";
            this.lblMariaHost.Size = new System.Drawing.Size(90, 25);
            this.lblMariaHost.TabIndex = 0;
            this.lblMariaHost.Text = "주소";
            this.lblMariaHost.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // txtMariaHost
            //
            this.txtMariaHost.Location = new System.Drawing.Point(120, 418);
            this.txtMariaHost.Name = "txtMariaHost";
            this.txtMariaHost.Size = new System.Drawing.Size(356, 23);
            this.txtMariaHost.TabIndex = 12;
            //
            // lblMariaPort
            //
            this.lblMariaPort.Location = new System.Drawing.Point(24, 450);
            this.lblMariaPort.Name = "lblMariaPort";
            this.lblMariaPort.Size = new System.Drawing.Size(90, 25);
            this.lblMariaPort.TabIndex = 0;
            this.lblMariaPort.Text = "포트";
            this.lblMariaPort.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // txtMariaPort
            //
            this.txtMariaPort.Location = new System.Drawing.Point(120, 450);
            this.txtMariaPort.Name = "txtMariaPort";
            this.txtMariaPort.Size = new System.Drawing.Size(100, 23);
            this.txtMariaPort.TabIndex = 13;
            //
            // lblMariaDb
            //
            this.lblMariaDb.Location = new System.Drawing.Point(24, 482);
            this.lblMariaDb.Name = "lblMariaDb";
            this.lblMariaDb.Size = new System.Drawing.Size(90, 25);
            this.lblMariaDb.TabIndex = 0;
            this.lblMariaDb.Text = "DB명";
            this.lblMariaDb.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // txtMariaDb
            //
            this.txtMariaDb.Location = new System.Drawing.Point(120, 482);
            this.txtMariaDb.Name = "txtMariaDb";
            this.txtMariaDb.Size = new System.Drawing.Size(356, 23);
            this.txtMariaDb.TabIndex = 14;
            //
            // lblMariaUser
            //
            this.lblMariaUser.Location = new System.Drawing.Point(24, 514);
            this.lblMariaUser.Name = "lblMariaUser";
            this.lblMariaUser.Size = new System.Drawing.Size(90, 25);
            this.lblMariaUser.TabIndex = 0;
            this.lblMariaUser.Text = "계정";
            this.lblMariaUser.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // txtMariaUser
            //
            this.txtMariaUser.Location = new System.Drawing.Point(120, 514);
            this.txtMariaUser.Name = "txtMariaUser";
            this.txtMariaUser.Size = new System.Drawing.Size(200, 23);
            this.txtMariaUser.TabIndex = 15;
            //
            // lblMariaPass
            //
            this.lblMariaPass.Location = new System.Drawing.Point(24, 546);
            this.lblMariaPass.Name = "lblMariaPass";
            this.lblMariaPass.Size = new System.Drawing.Size(90, 25);
            this.lblMariaPass.TabIndex = 0;
            this.lblMariaPass.Text = "비밀번호";
            this.lblMariaPass.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // txtMariaPass
            //
            this.txtMariaPass.Location = new System.Drawing.Point(120, 546);
            this.txtMariaPass.Name = "txtMariaPass";
            this.txtMariaPass.Size = new System.Drawing.Size(200, 23);
            this.txtMariaPass.TabIndex = 16;
            this.txtMariaPass.UseSystemPasswordChar = true;
            //
            // lblErpTitle
            //
            this.lblErpTitle.AutoSize = true;
            this.lblErpTitle.Font = new System.Drawing.Font("맑은 고딕", 10.5F, System.Drawing.FontStyle.Bold);
            this.lblErpTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(99)))), ((int)(((byte)(235)))));
            this.lblErpTitle.Location = new System.Drawing.Point(22, 100);
            this.lblErpTitle.Name = "lblErpTitle";
            this.lblErpTitle.Size = new System.Drawing.Size(124, 19);
            this.lblErpTitle.TabIndex = 3;
            this.lblErpTitle.Text = "송신 DB  ·  데이터를 보내는 쪽";
            //
            // btnErpTest
            //
            this.btnErpTest.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            this.btnErpTest.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnErpTest.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(213)))), ((int)(((byte)(225)))));
            this.btnErpTest.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnErpTest.Location = new System.Drawing.Point(366, 95);
            this.btnErpTest.Name = "btnErpTest";
            this.btnErpTest.Size = new System.Drawing.Size(110, 28);
            this.btnErpTest.TabIndex = 10;
            this.btnErpTest.Text = "연결 테스트";
            this.btnErpTest.UseVisualStyleBackColor = false;
            this.btnErpTest.Click += new System.EventHandler(this.btnErpTest_Click);
            //
            // lblErpType
            //
            this.lblErpType.Location = new System.Drawing.Point(24, 136);
            this.lblErpType.Name = "lblErpType";
            this.lblErpType.Size = new System.Drawing.Size(90, 25);
            this.lblErpType.TabIndex = 0;
            this.lblErpType.Text = "DB 종류";
            this.lblErpType.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // cboErpType
            //
            this.cboErpType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboErpType.Location = new System.Drawing.Point(120, 136);
            this.cboErpType.Name = "cboErpType";
            this.cboErpType.Size = new System.Drawing.Size(200, 23);
            this.cboErpType.TabIndex = 4;
            this.cboErpType.SelectedIndexChanged += new System.EventHandler(this.cboErpType_SelectedIndexChanged);
            //
            // lblErpHost
            //
            this.lblErpHost.Location = new System.Drawing.Point(24, 168);
            this.lblErpHost.Name = "lblErpHost";
            this.lblErpHost.Size = new System.Drawing.Size(90, 25);
            this.lblErpHost.TabIndex = 0;
            this.lblErpHost.Text = "주소";
            this.lblErpHost.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // txtErpHost
            //
            this.txtErpHost.Location = new System.Drawing.Point(120, 168);
            this.txtErpHost.Name = "txtErpHost";
            this.txtErpHost.Size = new System.Drawing.Size(356, 23);
            this.txtErpHost.TabIndex = 5;
            //
            // lblErpPort
            //
            this.lblErpPort.Location = new System.Drawing.Point(24, 200);
            this.lblErpPort.Name = "lblErpPort";
            this.lblErpPort.Size = new System.Drawing.Size(90, 25);
            this.lblErpPort.TabIndex = 0;
            this.lblErpPort.Text = "포트";
            this.lblErpPort.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // txtErpPort
            //
            this.txtErpPort.Location = new System.Drawing.Point(120, 200);
            this.txtErpPort.Name = "txtErpPort";
            this.txtErpPort.Size = new System.Drawing.Size(100, 23);
            this.txtErpPort.TabIndex = 6;
            //
            // lblErpDb
            //
            this.lblErpDb.Location = new System.Drawing.Point(24, 232);
            this.lblErpDb.Name = "lblErpDb";
            this.lblErpDb.Size = new System.Drawing.Size(90, 25);
            this.lblErpDb.TabIndex = 0;
            this.lblErpDb.Text = "DB명";
            this.lblErpDb.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // txtErpDb
            //
            this.txtErpDb.Location = new System.Drawing.Point(120, 232);
            this.txtErpDb.Name = "txtErpDb";
            this.txtErpDb.Size = new System.Drawing.Size(356, 23);
            this.txtErpDb.TabIndex = 7;
            //
            // lblErpUser
            //
            this.lblErpUser.Location = new System.Drawing.Point(24, 264);
            this.lblErpUser.Name = "lblErpUser";
            this.lblErpUser.Size = new System.Drawing.Size(90, 25);
            this.lblErpUser.TabIndex = 0;
            this.lblErpUser.Text = "계정";
            this.lblErpUser.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // txtErpUser
            //
            this.txtErpUser.Location = new System.Drawing.Point(120, 264);
            this.txtErpUser.Name = "txtErpUser";
            this.txtErpUser.Size = new System.Drawing.Size(200, 23);
            this.txtErpUser.TabIndex = 8;
            //
            // lblErpPass
            //
            this.lblErpPass.Location = new System.Drawing.Point(24, 296);
            this.lblErpPass.Name = "lblErpPass";
            this.lblErpPass.Size = new System.Drawing.Size(90, 25);
            this.lblErpPass.TabIndex = 0;
            this.lblErpPass.Text = "비밀번호";
            this.lblErpPass.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // txtErpPass
            //
            this.txtErpPass.Location = new System.Drawing.Point(120, 296);
            this.txtErpPass.Name = "txtErpPass";
            this.txtErpPass.Size = new System.Drawing.Size(200, 23);
            this.txtErpPass.TabIndex = 9;
            this.txtErpPass.UseSystemPasswordChar = true;
            //
            // chkAutoRun
            //
            this.chkAutoRun.AutoSize = true;
            this.chkAutoRun.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold);
            this.chkAutoRun.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.chkAutoRun.Location = new System.Drawing.Point(26, 596);
            this.chkAutoRun.Name = "chkAutoRun";
            this.chkAutoRun.Size = new System.Drawing.Size(250, 19);
            this.chkAutoRun.TabIndex = 18;
            this.chkAutoRun.Text = "프로그램 시작 시 바로 수집 실행";
            this.chkAutoRun.UseVisualStyleBackColor = true;
            //
            // btnSave
            //
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(99)))), ((int)(((byte)(235)))));
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSave.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(99)))), ((int)(((byte)(235)))));
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(262, 638);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(104, 36);
            this.btnSave.TabIndex = 19;
            this.btnSave.Text = "저장";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            //
            // btnCancel
            //
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(213)))), ((int)(((byte)(225)))));
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("맑은 고딕", 9.75F);
            this.btnCancel.Location = new System.Drawing.Point(372, 638);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(104, 36);
            this.btnCancel.TabIndex = 20;
            this.btnCancel.Text = "취소";
            this.btnCancel.UseVisualStyleBackColor = false;
            //
            // SettingForm
            //
            this.AcceptButton = this.btnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(500, 694);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblDesc);
            this.Controls.Add(this.lblMariaTitle);
            this.Controls.Add(this.btnMariaTest);
            this.Controls.Add(this.lblMesType);
            this.Controls.Add(this.cboMesType);
            this.Controls.Add(this.lblMariaHost);
            this.Controls.Add(this.txtMariaHost);
            this.Controls.Add(this.lblMariaPort);
            this.Controls.Add(this.txtMariaPort);
            this.Controls.Add(this.lblMariaDb);
            this.Controls.Add(this.txtMariaDb);
            this.Controls.Add(this.lblMariaUser);
            this.Controls.Add(this.txtMariaUser);
            this.Controls.Add(this.lblMariaPass);
            this.Controls.Add(this.txtMariaPass);
            this.Controls.Add(this.lblErpTitle);
            this.Controls.Add(this.btnErpTest);
            this.Controls.Add(this.lblErpType);
            this.Controls.Add(this.cboErpType);
            this.Controls.Add(this.lblErpHost);
            this.Controls.Add(this.txtErpHost);
            this.Controls.Add(this.lblErpPort);
            this.Controls.Add(this.txtErpPort);
            this.Controls.Add(this.lblErpDb);
            this.Controls.Add(this.txtErpDb);
            this.Controls.Add(this.lblErpUser);
            this.Controls.Add(this.txtErpUser);
            this.Controls.Add(this.lblErpPass);
            this.Controls.Add(this.txtErpPass);
            this.Controls.Add(this.chkAutoRun);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnCancel);
            this.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SettingForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "설정";
            this.Load += new System.EventHandler(this.SettingForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblDesc;
        private System.Windows.Forms.Label lblMariaTitle;
        private System.Windows.Forms.Button btnMariaTest;
        private System.Windows.Forms.Label lblMesType;
        private System.Windows.Forms.ComboBox cboMesType;
        private System.Windows.Forms.Label lblMariaHost;
        private System.Windows.Forms.TextBox txtMariaHost;
        private System.Windows.Forms.Label lblMariaPort;
        private System.Windows.Forms.TextBox txtMariaPort;
        private System.Windows.Forms.Label lblMariaDb;
        private System.Windows.Forms.TextBox txtMariaDb;
        private System.Windows.Forms.Label lblMariaUser;
        private System.Windows.Forms.TextBox txtMariaUser;
        private System.Windows.Forms.Label lblMariaPass;
        private System.Windows.Forms.TextBox txtMariaPass;
        private System.Windows.Forms.Label lblErpTitle;
        private System.Windows.Forms.Button btnErpTest;
        private System.Windows.Forms.Label lblErpType;
        private System.Windows.Forms.ComboBox cboErpType;
        private System.Windows.Forms.Label lblErpHost;
        private System.Windows.Forms.TextBox txtErpHost;
        private System.Windows.Forms.Label lblErpPort;
        private System.Windows.Forms.TextBox txtErpPort;
        private System.Windows.Forms.Label lblErpDb;
        private System.Windows.Forms.TextBox txtErpDb;
        private System.Windows.Forms.Label lblErpUser;
        private System.Windows.Forms.TextBox txtErpUser;
        private System.Windows.Forms.Label lblErpPass;
        private System.Windows.Forms.TextBox txtErpPass;
        private System.Windows.Forms.CheckBox chkAutoRun;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
    }
}
