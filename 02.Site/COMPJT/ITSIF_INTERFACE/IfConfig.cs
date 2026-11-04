using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Text;

namespace ITSIF_INTERFACE
{
    // 프로그램 설정 - IfConfig.txt (ERP 접속정보, DB 종류, 자동실행)
    // MES 접속정보는 ItsMaria 가 직접 읽는 MariaConfig.txt 에 둔다
    public static class IfConfig
    {
        public const string FILE = "IfConfig.txt";
        public const string MARIA_FILE = "MariaConfig.txt";

        // DB 종류
        public const string DB_MARIADB = "MARIADB";
        public const string DB_MYSQL = "MYSQL";
        public const string DB_MSSQL = "MSSQL";
        public const string DB_ORACLE = "ORACLE";

        public static string MesDbType = DB_MARIADB;

        public static string ErpDbType = DB_MSSQL;
        public static string ErpHost = "";
        public static string ErpPort = "";
        public static string ErpDbName = "";
        public static string ErpUser = "";
        public static string ErpPass = "";

        // 프로그램 시작 시 바로 수집 시작
        public static bool AutoRun = true;

        // 설정 파일이 둘 다 있으면 설정화면 없이 시작한다
        public static bool IsConfigured()
        {
            return File.Exists(FILE) && File.Exists(MARIA_FILE);
        }

        public static void Load()
        {
            if (!File.Exists(FILE)) return;

            foreach (string line in File.ReadAllLines(FILE, Encoding.UTF8))
            {
                int point = line.IndexOf('=');
                if (!line.StartsWith("--") || point < 0) continue;

                string key = line.Substring(2, point - 2).Trim().ToLower();
                string value = line.Substring(point + 1).Trim();

                switch (key)
                {
                    case "mes_dbtype": MesDbType = value.ToUpper(); break;
                    case "erp_dbtype": ErpDbType = value.ToUpper(); break;
                    case "erp_host": ErpHost = value; break;
                    case "erp_port": ErpPort = value; break;
                    case "erp_dbname": ErpDbName = value; break;
                    case "erp_user": ErpUser = value; break;
                    case "erp_password": ErpPass = value; break;
                    case "autorun": AutoRun = value.ToUpper() == "Y"; break;
                }
            }
        }

        public static void Save()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("--mes_dbtype=" + MesDbType);
            sb.AppendLine("--erp_dbtype=" + ErpDbType);
            sb.AppendLine("--erp_host=" + ErpHost);
            sb.AppendLine("--erp_port=" + ErpPort);
            sb.AppendLine("--erp_dbname=" + ErpDbName);
            sb.AppendLine("--erp_user=" + ErpUser);
            sb.AppendLine("--erp_password=" + ErpPass);
            sb.AppendLine("--autorun=" + (AutoRun ? "Y" : "N"));

            File.WriteAllText(FILE, sb.ToString(), new UTF8Encoding(false));
        }

        // ERP 조회/갱신 - 설정한 DB 종류의 라이브러리로 접속한다
        public static DataSet ErpQuery(string query, out string errMsg)
        {
            // Oracle 은 문장 끝 ; 가 있으면 오류라 뺀다 (다른 DB 는 없어도 된다)
            query = query.Trim().TrimEnd(';');
            errMsg = null;

            DataSet ds;
            if (ErpDbType == DB_ORACLE)
            {
                ds = ItsOracle.Query(ErpHost, ErpPort, ErpUser, ErpPass, ErpDbName, query);
                if (ItsOracle.IsError) errMsg = ItsOracle.ErrMessage;
            }
            else if (ErpDbType == DB_MARIADB || ErpDbType == DB_MYSQL)
            {
                // ItsMaria 는 MES 호출과 같은 static 상태를 쓰므로 잠근다
                lock (MainLoop.This.DbLock)
                {
                    ds = ItsMaria.Query(query, ErpHost, ErpPort, ErpUser, ErpPass, ErpDbName, 300);
                    if (ItsMaria.IsError) errMsg = ItsMaria.ErrMessage;
                }
            }
            else
            {
                ds = ItsMssql.Query(ErpHost, ErpPort, ErpUser, ErpPass, ErpDbName, query);
                if (ItsMssql.IsError) errMsg = ItsMssql.ErrMessage;
            }

            if (ds.Tables.Count == 0) ds.Tables.Add(new DataTable());
            return ds;
        }
    }
}
