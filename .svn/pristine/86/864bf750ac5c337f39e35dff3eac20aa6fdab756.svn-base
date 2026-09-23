<%@ Page Language="C#" %>
<%
    string FILEKEY = "";
    string BASEPATH = Server.MapPath(".");

    // 처리 구분 UPLOAD 파일 업로드, DELETE 파일 삭제
    string CALLTYPE = "UPLOAD";
    try
    {
        CALLTYPE = Request["CALLTYPE"].ToString();
    }
    catch { }

    // 데이터베이스 접속
    try
    {
        byte[] addr = new byte[0];
        byte[] port = new byte[0];
        byte[] user = new byte[0];
        byte[] pass = new byte[0];
        byte[] dbname = new byte[0];

        string[] mariaConnStr = System.IO.File.ReadAllLines(BASEPATH + "\\ITS_CONFIG_MARIA.xml", Encoding.UTF8);
        foreach (string str in mariaConnStr)
        {
            if (str.IndexOf("--addr:") > -1) addr = Convert.FromBase64String(str.Replace("--addr:", "").Trim());
            else if (str.IndexOf("--port:") > -1) port = Convert.FromBase64String(str.Replace("--port:", "").Trim());
            else if (str.IndexOf("--user:") > -1) user = Convert.FromBase64String(str.Replace("--user:", "").Trim());
            else if (str.IndexOf("--password:") > -1) pass = Convert.FromBase64String(str.Replace("--password:", "").Trim());
            else if (str.IndexOf("--dbname:") > -1) dbname = Convert.FromBase64String(str.Replace("--dbname:", "").Trim());
        }

        byte[] keyByte = (new UTF8Encoding()).GetBytes(">ITS1005");
        System.Security.Cryptography.DESCryptoServiceProvider des = new System.Security.Cryptography.DESCryptoServiceProvider();
        des.Key = keyByte;
        des.IV = keyByte;
        System.Security.Cryptography.ICryptoTransform desdecrypt = des.CreateDecryptor();

        System.IO.MemoryStream ms;
        System.Security.Cryptography.CryptoStream cs;

        // 주소
        ms = new System.IO.MemoryStream();
        cs = new System.Security.Cryptography.CryptoStream(ms, desdecrypt, System.Security.Cryptography.CryptoStreamMode.Write);
        cs.Write(addr, 0, addr.Length);
        cs.FlushFinalBlock();
        addr = ms.ToArray();
        string addrStr = (new UTF8Encoding()).GetString(addr, 0, addr.Length);

        // 포트
        ms = new System.IO.MemoryStream();
        cs = new System.Security.Cryptography.CryptoStream(ms, desdecrypt, System.Security.Cryptography.CryptoStreamMode.Write);
        cs.Write(port, 0, port.Length);
        cs.FlushFinalBlock();
        port = ms.ToArray();
        string portStr = (new UTF8Encoding()).GetString(port, 0, port.Length);

        // 사용자
        ms = new System.IO.MemoryStream();
        cs = new System.Security.Cryptography.CryptoStream(ms, desdecrypt, System.Security.Cryptography.CryptoStreamMode.Write);
        cs.Write(user, 0, user.Length);
        cs.FlushFinalBlock();
        user = ms.ToArray();
        string userStr = (new UTF8Encoding()).GetString(user, 0, user.Length);

        // 비밀번호
        ms = new System.IO.MemoryStream();
        cs = new System.Security.Cryptography.CryptoStream(ms, desdecrypt, System.Security.Cryptography.CryptoStreamMode.Write);
        cs.Write(pass, 0, pass.Length);
        cs.FlushFinalBlock();
        pass = ms.ToArray();
        string passStr = (new UTF8Encoding()).GetString(pass, 0, pass.Length);

        // 데이터베이스명
        ms = new System.IO.MemoryStream();
        cs = new System.Security.Cryptography.CryptoStream(ms, desdecrypt, System.Security.Cryptography.CryptoStreamMode.Write);
        cs.Write(dbname, 0, dbname.Length);
        cs.FlushFinalBlock();
        dbname = ms.ToArray();
        string dbnameStr = (new UTF8Encoding()).GetString(dbname, 0, dbname.Length);

        // 연결정보
        string ConnString = String.Format("server={0};port={1};uid={2};pwd={3};database={4}", addrStr, portStr, userStr, passStr, dbnameStr);
        System.Reflection.Assembly assembly = System.Reflection.Assembly.LoadFrom(BASEPATH + "\\MySql.Data.dll");

        Type tpConn = assembly.GetType("MySql.Data.MySqlClient.MySqlConnection");
        Type tpCommand = assembly.GetType("MySql.Data.MySqlClient.MySqlCommand");
        Type tpAdapter = assembly.GetType("MySql.Data.MySqlClient.MySqlDataAdapter");

        System.Reflection.MethodInfo miConn = tpConn.GetMethod("Open");
        System.Reflection.MethodInfo miFill = tpAdapter.GetMethod("Fill", new Type[] { typeof(System.Data.DataSet) });

        string query = "";
        System.Data.DataSet ds = null;
        object objConn = null;
        object objCmd = null;
        object objAdapter = null;

        objConn = Activator.CreateInstance(tpConn, ConnString);
        miConn.Invoke(objConn, null);

        if (CALLTYPE.ToUpper() == "DELETE")
        {
            try
            {
                FILEKEY = Request["FILEKEY"].ToString();
            }
            catch
            {
                Response.Write("ERROR: FILEKEY가 비어 있습니다.");
                return;
            }

            // COMFILE 테이블 파일 정보 지우기
            StringBuilder sb = new StringBuilder();
            sb.Append("CALL COMCALLC('COMFILE', 'DELETE', 'Y', '");
            sb.Append("┃FILEKEY»" + FILEKEY);
            sb.Append("┃');");
            objCmd = Activator.CreateInstance(tpCommand, new object[] { sb.ToString(), objConn });
            objAdapter = Activator.CreateInstance(tpAdapter, objCmd);
            ds = new System.Data.DataSet();
            miFill.Invoke(objAdapter, new object[] { ds });

            // 실제 파일 지우기
            string localPath =  BASEPATH + ds.Tables[0].Rows[0][0].ToString();
            System.IO.File.Delete(localPath);
            
        }
        else if (CALLTYPE == "UPLOAD")
        {
            // 파일명
            string FILENAME = "";
            try
            {
                FILENAME = Request["FILENAME"].ToString();
            }
            catch
            {
                Response.Write("ERROR: 파일명이 비어있습니다.");
                return;
            }

            // 파일명에서 파일 확장자 얻기
            string FILEEXT = "";
            string[] fileList = FILENAME.Split(new char[] { '.' });
            if (fileList.Length == 1)
            {
                Response.Write("ERROR: 확장자를 인식할 수 없습니다.");
                return;
            }
            else
            {
                FILEEXT = ("." + fileList[fileList.Length - 1]).ToLower();
            }

            // 파일 키 생성
            query = "CALL COMCALLC('COMFILE', 'NEWKEY', 'Y', '');";
            objCmd = Activator.CreateInstance(tpCommand, new object[] { query, objConn });
            objAdapter = Activator.CreateInstance(tpAdapter, objCmd);
            ds = new System.Data.DataSet();
            miFill.Invoke(objAdapter, new object[] { ds });

            FILEKEY = ds.Tables[0].Rows[0][0].ToString();
            if (FILEKEY == "_ERR_")
            {
                Response.Write("ERROR: " + ds.Tables[0].Rows[0][1].ToString());
                return;
            }
            else
            {
                // 업로드 경로 설정
                string uploadPath = BASEPATH + "\\UploadFiles";
                if (!System.IO.Directory.Exists(uploadPath))
                {
                    System.IO.Directory.CreateDirectory(uploadPath);
                }
                string monthPath = uploadPath + "\\" + FILEKEY.Substring(0, 4);
                if (!System.IO.Directory.Exists(monthPath))
                {
                    System.IO.Directory.CreateDirectory(monthPath);
                }

                // 파일 데이터 읽기
                byte[] FILEBYTE = null;
                decimal FILESIZE = 0m;
                try
                {
                    string FILEDATA = Request["FILEDATA"].ToString();
                    FILEBYTE = Convert.FromBase64String(FILEDATA);
                    FILESIZE = FILEBYTE.Length;
                }
                catch { }

                // 파일 업로드
                string FILEPATH = "";
                string[] fileExtList = new string[] { ".png", ".jpg", ".gif", ".pdf", ".bmp", ".doc", ".docx", ".xls", ".xlsx", ".ppt", ".pptx", ".hwp" };
                if (fileExtList.Contains<string>(FILEEXT)) // IIS 다운로드 허용 파일 형식일 경우
                {
                    FILEPATH = "/UploadFiles/" + FILEKEY.Substring(0, 4) + "/" + FILEKEY + FILEEXT;

                    string localPath = monthPath + "\\" + FILEKEY + FILEEXT;
                    System.IO.File.WriteAllBytes(localPath, FILEBYTE);
                }
                else
                {
                    FILEPATH = "/UploadFiles/" + FILEKEY.Substring(0, 4) + "/" + FILEKEY + FILEEXT + ".zip";

                    string localPath = monthPath + "\\" + FILEKEY + FILEEXT + ".zip";
                    System.IO.File.WriteAllBytes(localPath, FILEBYTE);
                }

                // COMFILE 레코드 추가
                StringBuilder sb = new StringBuilder();
                sb.Append("CALL COMCALLC('COMFILE', 'ADD', 'Y', '");
                sb.Append("┃FILEKEY»" + FILEKEY);
                sb.Append("┃FILENAME»" + FILENAME);
                sb.Append("┃FILEEXT»" + FILEEXT);
                sb.Append("┃FILESIZE»" + FILESIZE);
                sb.Append("┃FILEPATH»" + FILEPATH);
                sb.Append("┃');");
                objCmd = Activator.CreateInstance(tpCommand, new object[] { sb.ToString(), objConn });
                objAdapter = Activator.CreateInstance(tpAdapter, objCmd);
                ds = new System.Data.DataSet();
                miFill.Invoke(objAdapter, new object[] { ds });

                if (ds.Tables[0].Rows[0][0].ToString() == "_ERR_")
                {
                    Response.Write("ERROR: " + ds.Tables[0].Rows[0][1].ToString());
                    return;
                }
            }
        }

    }
    catch (Exception ex)
    {
        Response.Write("ERROR: " + ex.Message);
        return;
    }

    Response.Write(FILEKEY);
%>