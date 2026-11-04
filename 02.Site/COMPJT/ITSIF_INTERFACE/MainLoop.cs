using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;

namespace ITSIF_INTERFACE
{
    public class MainLoop
    {
        static MainLoop _this = new MainLoop();

        public static MainLoop This
        {
            get { return _this; }
        }

        // ERP 인터페이스 DB 접속정보·종류는 설정화면에서 저장한 IfConfig.txt 를 쓴다 (IfConfig.ErpQuery)

        // 루프 대기시간(ms)
        private const int LOOP_SLEEP = 1000;

        // IF_ERR_LOG 확인 주기(초)
        private const int ERRLOG_CYCLE = 30;

        // ItsMaria 는 static 공유 상태라 화면과 루프가 동시에 Set~Call 하지 않도록 잠근다
        public readonly object DbLock = new object();

        // 화면 처리이력 표시용 (구분, IF명, 내용)
        public event Action<string, string, string> LogAdded;

        // IF_ERR_LOG 확인 결과 (전체건수, 신규건수, 신규행)
        public event Action<int, int, DataTable> ErrLogChecked;

        private DateTime _lastErrLogCheck = DateTime.MinValue;
        private int _errLogCount = -1;

        // IF별 수집 상태 (IF명, 상태, 처리건수, 오류건수)
        public event Action<string, string, int, int> IFStatusChanged;

        // IF별 설명 (IF명, IFSTD.IFDESC) - RECEIVE 결과에 IFDESC 가 있을 때만
        public event Action<string, string> IFDescChanged;

        // 화면에 알린 설명 - 바뀐 것만 다시 알린다
        private Dictionary<string, string> _ifDesc = new Dictionary<string, string>();

        // IF별 마지막 확인시각 - 새 데이터가 없으면 IFSTD.LASTTIME 이 안 바뀌므로 주기는 여기서 지킨다
        private Dictionary<string, DateTime> _lastRunTime = new Dictionary<string, DateTime>();

        private bool _erpConfigWarned = false;

        private string _currentIF = "";
        private string _currentStatus = "";

        public string CurrentIF
        {
            get { return _currentIF; }
        }

        public string CurrentStatus
        {
            get { return _currentStatus; }
        }

        private bool _iftaskFlag = false;

        public bool IFTaskFlag
        {
            get { return _iftaskFlag; }
            set { _iftaskFlag = value; }
        }

        private DateTime _lastCheckTime = DateTime.MinValue;

        public DateTime LastCheckTime
        {
            get { return _lastCheckTime; }
        }

        public void IFTask()
        {
            while (true)
            {
                // 회차별로 예외를 잡아 한 번의 오류로 루프가 멈추지 않게 한다
                try
                {
                    if (IFTaskFlag)
                    {
                        IFReceive();
                        _lastCheckTime = DateTime.Now;
                    }
                }
                catch (Exception ex)
                {
                    err_log(ex.ToString());
                    AddLog("ERR", "", ex.Message);
                }

                // IF_ERR_LOG 는 IF 실행 여부와 관계없이 확인한다
                try
                {
                    if ((DateTime.Now - _lastErrLogCheck).TotalSeconds >= ERRLOG_CYCLE)
                    {
                        _lastErrLogCheck = DateTime.Now;
                        CheckErrLog();
                    }
                }
                catch (Exception ex)
                {
                    err_log(ex.ToString());
                    AddLog("ERR", "IF_ERR_LOG", ex.Message);
                }

                Thread.Sleep(LOOP_SLEEP);
            }
        }

        // IF_ERR_LOG 건수가 늘면 늘어난 만큼 최근 행을 화면에 알린다
        private void CheckErrLog()
        {
            DataSet ds;
            string errMsg = null;
            lock (DbLock)
            {
                ds = ItsMaria.Query("SELECT COUNT(*) FROM IF_ERR_LOG;");
                if (ItsMaria.IsError) errMsg = ItsMaria.ErrMessage;
            }
            if (errMsg != null)
            {
                AddLog("ERR", "IF_ERR_LOG", errMsg);
                return;
            }

            int count = Convert.ToInt32(ds.Tables[0].Rows[0][0]);

            // 첫 확인은 기존 건수만 알리고, 이후 늘어난 건만 신규로 본다
            int newCnt = _errLogCount < 0 ? 0 : count - _errLogCount;
            _errLogCount = count;

            DataTable newRows = null;
            if (newCnt > 0)
            {
                lock (DbLock)
                {
                    newRows = ItsMaria.Query("SELECT IFNAME, ERRMSG, READTIME FROM IF_ERR_LOG ORDER BY READTIME DESC LIMIT " + Math.Min(newCnt, 50) + ";").Tables[0];
                }
            }

            Action<int, int, DataTable> handler = ErrLogChecked;
            if (handler != null)
            {
                handler(count, newCnt, newRows);
            }
        }

        private void IFReceive()
        {
            string path = "./LOG/" + DateTime.Now.ToString("yyyy-MM-dd");
            if (Directory.Exists(path) == false)
            {
                Directory.CreateDirectory(path);
            }

            DataSet ds;
            string errMsg = null;
            lock (DbLock)
            {
                ItsMaria.Set("IF_INTERFACE", "RECEIVE");
                ds = ItsMaria.Call();
                if (ItsMaria.IsError) errMsg = ItsMaria.ErrMessage;
            }
            if (errMsg != null)
            {
                ItsDB_Error_log(path, "", "ItsMaria.Set(IF_INTERFACE, RECEIVE)", errMsg);
                AddLog("ERR", "", errMsg);
                return;
            }

            // RECEIVE 끝에 붙은 IFDESC(설명)를 화면에 넘긴다
            if (ds.Tables[0].Columns.Contains("IFDESC"))
            {
                Action<string, string> handler = IFDescChanged;
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    string name = row["IFNAME"].ToString();
                    string desc = row["IFDESC"].ToString();

                    string oldDesc;
                    if (_ifDesc.TryGetValue(name, out oldDesc) && oldDesc == desc) continue;

                    _ifDesc[name] = desc;
                    if (handler != null) handler(name, desc);
                }
            }

            // ERP 접속설정이 없으면 한 번만 알리고 대기
            if (IfConfig.ErpHost == "")
            {
                if (!_erpConfigWarned)
                {
                    _erpConfigWarned = true;
                    AddLog("ERR", "", "ERP 접속설정(IfConfig.txt)이 없습니다. [설정] 에서 저장하세요.");
                }
                return;
            }
            _erpConfigWarned = false;

            // RECEIVE 결과는 컬럼 이름으로 읽는다 (프로시저에서 컬럼 순서가 바뀌어도 안전하게)
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                string name = ds.Tables[0].Rows[i]["IFNAME"].ToString();

                // IF 하나가 실패해도 다음 IF 는 계속 처리한다
                try
                {
                    int cycle = Convert.ToInt32(ds.Tables[0].Rows[i]["CYCLE"].ToString());
                    string last = ds.Tables[0].Rows[i]["LASTTIME"].ToString();
                    string type = ds.Tables[0].Rows[i]["IFGB"].ToString();
                    string proc = ds.Tables[0].Rows[i]["PROCNAME"].ToString();

                    double diffSecond = (DateTime.Now - Convert.ToDateTime(last)).TotalSeconds;

                    DateTime lastRun;
                    bool cycleDone = !_lastRunTime.TryGetValue(name, out lastRun) || (DateTime.Now - lastRun).TotalSeconds >= cycle;

                    if (diffSecond > cycle && cycleDone && type == "ERP")
                    {
                        _lastRunTime[name] = DateTime.Now;
                        IFReceive_ERP(path, name, proc);
                    }
                }
                catch (Exception ex)
                {
                    ItsDB_Error_log(path, name, "IFReceive", ex.Message);
                    AddLog("ERR", name, ex.Message);
                    SetStatus(name, "오류", 0, 0);
                }
            }

            SetStatus("", "", 0, 0);
        }

        private void IFReceive_ERP(string path, string name, string proc)
        {
            SetStatus(name, "ERP 조회중", 0, 0);

            string query = "SELECT * FROM " + name + " WHERE IF_YN = 'N' OR IF_YN = 'E';";

            string erpErr;
            DataSet list_IF = IfConfig.ErpQuery(query, out erpErr);
            if (erpErr != null)
            {
                ItsDB_Error_log(path, name, "ERP_Sel", erpErr);
                AddLog("ERR", name, erpErr);
                SetStatus(name, "오류", 0, 0);
                return;
            }

            // 조회결과가 없으면 종료
            if (list_IF.Tables[0].Rows.Count == 0)
            {
                SetStatus(name, "대기", 0, 0);
                return;
            }

            int rowCnt = list_IF.Tables[0].Rows.Count;
            if (rowCnt > 1000)
            {
                rowCnt = 1000;
            }

            SetStatus(name, "MES 반영중", 0, 0);

            DataSet listErr;
            string errMsg = null;
            lock (DbLock)
            {
                ItsMaria.Set(proc, "");
                for (int j = 0; j < rowCnt; j++)
                {
                    for (int l = 0; l < list_IF.Tables[0].Columns.Count; l++)
                    {
                        ItsMaria.AddList(list_IF.Tables[0].Columns[l].ColumnName + "_LIST", list_IF.Tables[0].Rows[j][l].ToString().Replace("'", "''''"));
                    }
                }

                listErr = ItsMaria.Call();
                if (ItsMaria.IsError) errMsg = ItsMaria.ErrMessage;
            }

            // MES 반영 실패 시 IF_YN 을 바꾸지 않고 다음 주기에 다시 받는다
            if (errMsg != null)
            {
                ItsDB_Error_log(path, name, "ItsMaria_Proc", errMsg);
                AddLog("ERR", name, errMsg);
                SetStatus(name, "오류", 0, 0);
                return;
            }

            string list = "";
            for (int k = 0; k < rowCnt; k++)
            {
                if (k == rowCnt - 1)
                    list += "'" + list_IF.Tables[0].Rows[k][0] + "') ";
                else
                    list += "'" + list_IF.Tables[0].Rows[k][0] + "', ";
            }

            string err_list = "";
            int errCnt = listErr.Tables.Count > 0 ? listErr.Tables[0].Rows.Count : 0;
            for (int k = 0; k < errCnt; k++)
            {
                if (k == errCnt - 1)
                    err_list += "'" + listErr.Tables[0].Rows[k][0] + "') ";
                else
                    err_list += "'" + listErr.Tables[0].Rows[k][0] + "', ";
            }

            string file = path + "/" + name + ".txt";
            string now = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

            // 처리대상 전체를 Y 로 바꾼 뒤 오류건만 E 로 되돌린다
            File.AppendAllText(file, "\r\n" + "[" + DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss") + "] OK\t" + list);

            query = "UPDATE " + name + " SET IF_YN = 'Y', IF_READTIME = '" + now + "' WHERE IF_KEY IN (" + list + " ";
            IfConfig.ErpQuery(query, out erpErr);
            if (erpErr != null)
            {
                ItsDB_Error_log(path, name, "ERP_Update", erpErr);
                AddLog("ERR", name, erpErr);
                SetStatus(name, "오류", 0, 0);
                return;
            }
            else
            {
                AddLog("OK", name, (rowCnt - errCnt) + "건 처리");
            }

            if (err_list != "")
            {
                File.AppendAllText(file, "\r\n" + "[" + DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss") + "] NG\t" + err_list);

                query = "UPDATE " + name + " SET IF_YN = 'E', IF_READTIME = '" + now + "' WHERE IF_KEY IN (" + err_list + " ";
                IfConfig.ErpQuery(query, out erpErr);
                if (erpErr != null)
                {
                    ItsDB_Error_log(path, name, "ERP_Update", erpErr);
                    AddLog("ERR", name, erpErr);
                }
                else
                {
                    AddLog("NG", name, errCnt + "건 오류");
                }
            }

            SetStatus(name, errCnt > 0 ? "일부 오류" : "완료", rowCnt - errCnt, errCnt);
        }

        // 현재 수집중인 IF 를 기억하고 화면에 알린다 (name 이 빈값이면 한 바퀴 종료)
        private void SetStatus(string name, string status, int okCnt, int ngCnt)
        {
            _currentIF = name;
            _currentStatus = status;

            if (name == "") return;

            Action<string, string, int, int> handler = IFStatusChanged;
            if (handler != null)
            {
                handler(name, status, okCnt, ngCnt);
            }
        }

        private void AddLog(string kind, string name, string message)
        {
            Action<string, string, string> handler = LogAdded;
            if (handler != null)
            {
                handler(kind, name, message);
            }
        }

        private void err_log(string text)
        {
            File.AppendAllText("log.txt", "\r\n" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "\t" + text, Encoding.UTF8);
        }

        private void ItsDB_Error_log(string path, string name, string errfountion, string errormessage)
        {
            string file = path + "/" + name + ".txt";
            File.AppendAllText(file, "\r\n" + "[" + DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss") + "] " + errfountion + "ERR\t" + name + " " + errormessage);
        }
    }
}
