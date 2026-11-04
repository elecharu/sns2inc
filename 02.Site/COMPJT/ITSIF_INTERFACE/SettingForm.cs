using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using Oracle.ManagedDataAccess.Client;

namespace ITSIF_INTERFACE
{
    // DB 접속 설정 - 수신 DB(MariaConfig.txt), 송신 DB·DB종류·자동실행(IfConfig.txt)
    public partial class SettingForm : Form
    {
        // 콤보 순서와 IfConfig 의 DB 종류 코드를 맞춘다
        private static readonly string[] MES_TYPES = { IfConfig.DB_MARIADB, IfConfig.DB_MYSQL };
        private static readonly string[] MES_TYPE_NAMES = { "MariaDB", "MySQL" };
        private static readonly string[] ERP_TYPES = { IfConfig.DB_MSSQL, IfConfig.DB_ORACLE, IfConfig.DB_MARIADB };
        private static readonly string[] ERP_TYPE_NAMES = { "MSSQL", "Oracle", "MariaDB / MySQL" };
        private static readonly string[] ERP_DEFAULT_PORTS = { "1433", "1521", "3306" };

        public SettingForm()
        {
            InitializeComponent();

            cboMesType.Items.AddRange(MES_TYPE_NAMES);
            cboErpType.Items.AddRange(ERP_TYPE_NAMES);
        }

        private void SettingForm_Load(object sender, EventArgs e)
        {
            // MariaConfig.txt : --host= / --port= / --user= / --password= / --dbname= 형식
            if (File.Exists(IfConfig.MARIA_FILE))
            {
                foreach (string line in File.ReadAllLines(IfConfig.MARIA_FILE))
                {
                    if (line.StartsWith("--host=")) txtMariaHost.Text = line.Substring(7).Trim();
                    else if (line.StartsWith("--port=")) txtMariaPort.Text = line.Substring(7).Trim();
                    else if (line.StartsWith("--user=")) txtMariaUser.Text = line.Substring(7).Trim();
                    else if (line.StartsWith("--password=")) txtMariaPass.Text = line.Substring(11).Trim();
                    else if (line.StartsWith("--dbname=")) txtMariaDb.Text = line.Substring(9).Trim();
                }
            }
            else
            {
                txtMariaPort.Text = "3306";
            }

            int mesIndex = Array.IndexOf(MES_TYPES, IfConfig.MesDbType);
            cboMesType.SelectedIndex = mesIndex < 0 ? 0 : mesIndex;

            // MYSQL 은 MARIADB 와 같은 접속 방식이라 ERP 콤보에서는 하나로 보여준다
            string erpType = IfConfig.ErpDbType == IfConfig.DB_MYSQL ? IfConfig.DB_MARIADB : IfConfig.ErpDbType;
            int erpIndex = Array.IndexOf(ERP_TYPES, erpType);
            cboErpType.SelectedIndex = erpIndex < 0 ? 0 : erpIndex;

            txtErpHost.Text = IfConfig.ErpHost;
            if (IfConfig.ErpPort != "") txtErpPort.Text = IfConfig.ErpPort;
            txtErpDb.Text = IfConfig.ErpDbName;
            txtErpUser.Text = IfConfig.ErpUser;
            txtErpPass.Text = IfConfig.ErpPass;

            chkAutoRun.Checked = IfConfig.AutoRun;
        }

        // ERP DB 종류를 바꾸면 기본 포트와 DB명 안내를 맞춘다
        private void cboErpType_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = cboErpType.SelectedIndex;
            if (index < 0) return;

            if (txtErpPort.Text.Trim() == "" || Array.IndexOf(ERP_DEFAULT_PORTS, txtErpPort.Text.Trim()) > -1)
            {
                txtErpPort.Text = ERP_DEFAULT_PORTS[index];
            }

            lblErpDb.Text = ERP_TYPES[index] == IfConfig.DB_ORACLE ? "서비스명" : "DB명";
        }

        private string MariaConnString(string host, string port, string user, string pass, string db)
        {
            return String.Format("server={0};port={1};uid={2};pwd={3};database={4};Connection Timeout=5", host, port, user, pass, db);
        }

        private void btnMariaTest_Click(object sender, EventArgs e)
        {
            TestConnection("수신 DB", () =>
            {
                using (MySqlConnection conn = new MySqlConnection(MariaConnString(txtMariaHost.Text.Trim(), txtMariaPort.Text.Trim(), txtMariaUser.Text.Trim(), txtMariaPass.Text, txtMariaDb.Text.Trim())))
                {
                    conn.Open();
                }
            });
        }

        private void btnErpTest_Click(object sender, EventArgs e)
        {
            string host = txtErpHost.Text.Trim();
            string port = txtErpPort.Text.Trim();
            string db = txtErpDb.Text.Trim();
            string user = txtErpUser.Text.Trim();
            string pass = txtErpPass.Text;
            string type = ERP_TYPES[cboErpType.SelectedIndex];

            TestConnection("송신 DB", () =>
            {
                if (type == IfConfig.DB_ORACLE)
                {
                    string connString = String.Format("Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST={0})(PORT={1})))(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME={2})));User ID={3};Password={4};Connection Timeout=5;", host, port, db, user, pass);
                    using (OracleConnection conn = new OracleConnection(connString))
                    {
                        conn.Open();
                    }
                }
                else if (type == IfConfig.DB_MARIADB)
                {
                    using (MySqlConnection conn = new MySqlConnection(MariaConnString(host, port, user, pass, db)))
                    {
                        conn.Open();
                    }
                }
                else
                {
                    string connString = String.Format("Data Source={0},{1};Initial Catalog={2};User ID={3};Password={4};Connect Timeout=5;", host, port, db, user, pass);
                    using (SqlConnection conn = new SqlConnection(connString))
                    {
                        conn.Open();
                    }
                }
            });
        }

        private void TestConnection(string title, Action open)
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                open();
                MessageBox.Show(title + " 연결 성공", "연결 테스트", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(title + " 연결 실패\n\n" + ex.Message, "연결 테스트", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtMariaHost.Text.Trim() == "" || txtMariaPort.Text.Trim() == "" || txtMariaDb.Text.Trim() == "" || txtMariaUser.Text.Trim() == ""
                || txtErpHost.Text.Trim() == "" || txtErpPort.Text.Trim() == "" || txtErpDb.Text.Trim() == "" || txtErpUser.Text.Trim() == "")
            {
                MessageBox.Show("송신 DB 와 수신 DB 의 주소, 포트, DB명, 계정을 모두 입력하세요.", "설정", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            StringBuilder maria = new StringBuilder();
            maria.AppendLine("--host=" + txtMariaHost.Text.Trim());
            maria.AppendLine("--port=" + txtMariaPort.Text.Trim());
            maria.AppendLine("--user=" + txtMariaUser.Text.Trim());
            maria.AppendLine("--password=" + txtMariaPass.Text);
            maria.AppendLine("--dbname=" + txtMariaDb.Text.Trim());

            // 수집 루프가 읽는 중에 바뀌지 않도록 잠그고 기록한다
            lock (MainLoop.This.DbLock)
            {
                File.WriteAllText(IfConfig.MARIA_FILE, maria.ToString(), new UTF8Encoding(false));

                IfConfig.MesDbType = MES_TYPES[cboMesType.SelectedIndex];
                IfConfig.ErpDbType = ERP_TYPES[cboErpType.SelectedIndex];
                IfConfig.ErpHost = txtErpHost.Text.Trim();
                IfConfig.ErpPort = txtErpPort.Text.Trim();
                IfConfig.ErpDbName = txtErpDb.Text.Trim();
                IfConfig.ErpUser = txtErpUser.Text.Trim();
                IfConfig.ErpPass = txtErpPass.Text;
                IfConfig.AutoRun = chkAutoRun.Checked;
                IfConfig.Save();
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
