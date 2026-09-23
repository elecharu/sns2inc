using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.IO;
using System.Web.Script.Serialization;

public partial class DAUMEML : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            var mailstate = Request["MAILSTATE"];
            string fromid = "yeungjin01@hanmail.net";
            string frompw = ItsSecurity.DecDES("CVaDlqpEuTiRAQcb2qcF9A==");
            //string fromid = "zzip2595@hanmail.net";
            //string frompw = "siyan8003!";

            if (mailstate == "DAUMSEND")                            // 다음 메일 전송 SMTP
            {
                string toid = Request["TOID"];
                string cc = Request["CC"];
                string bcc = Request["BCC"];
                string title = Request["TITLE"];
                string body = Request["BODY"];
                string filepath = Request["filepath"];
                string filename = Request["filename"];
                string displaynm = Request["DISPLAYNM"];
                Response.Write(SendCDOSSL(fromid, frompw, "smtp.daum.net", 465, toid, cc, bcc, title, body, filepath, filename, displaynm));
            }
            else if (mailstate == "DAUMIMAP")                            // 다음 메일 받기 IMAP
            {
                string mailbox = Request["MAILBOX"];
                string readtype = Request["READTYPE"];          // all 모두 보기, unseen 안읽은거 보기, seen 읽은거 보기
                string uid = Request["UID"];
                string subject = Request["SUBJECT"];
                string body = Request["BODY"];
                string from = Request["SENDFROM"];
                string sdate = Request["SDATE"];
                string edate = Request["EDATE"];
                ImapX.ImapClient imap = new ImapX.ImapClient();

                try
                {
                    imap.Connect("imap.daum.net", 993, true); // 메일서버 접속
                    imap.Login(fromid, frompw);               // 메일서버에 로그인   
                }
                catch (Exception ex)
                {
                    Response.Write("Exception: " + ex.Message + "<br />");
                }
                
                DataSet ds = DAUM_READ(imap, mailbox, readtype, uid, subject, body, from, sdate, edate);
                imap.Disconnect();

                if (ds.Tables.Count == 0)
                    Response.Write("");
                else
                    Response.Write(DatasetToJson(ds));
            }
            else if (mailstate == "DAUMIMAPPAGE")                            // 다음 메일 받기 IMAP
            {
                string mailbox = Request["MAILBOX"];
                string totalcount = Request["TOTALCOUNT"];
                string page = Request["PAGE"];
                string count = Request["COUNT"];
                ImapX.ImapClient imap = new ImapX.ImapClient();
                DataSet ds = new DataSet();
                try
                {
                    imap.Connect("imap.daum.net", 993, true); // 메일서버 접속
                    imap.Login(fromid, frompw);               // 메일서버에 로그인   

                    ds = DAUM_PAGE(imap, mailbox, Int32.Parse(totalcount), Int32.Parse(page), Int32.Parse(count));
                }
                catch (Exception ex)
                {
                    Response.Write("Exception: " + ex.Message + "<br />");
                }
                imap.Disconnect();

                if (ds.Tables.Count == 0)
                    Response.Write("");
                else
                    Response.Write(DatasetToJson(ds));
            }
            else if (mailstate == "DAUMKEYBOX")                            // 다음 키 박스
            {
                string mailbox = Request["MAILBOX"];
                string readtype = Request["READTYPE"];          // all 모두 보기, unseen 안읽은거 보기, seen 읽은거 보기
                string subject = Request["SUBJECT"];
                string body = Request["BODY"];
                string from = Request["SENDFROM"];
                string sdate = Request["SDATE"];
                string edate = Request["EDATE"];
                ImapX.ImapClient imap = new ImapX.ImapClient();

                try
                {
                    imap.Connect("imap.daum.net", 993, true); // 메일서버 접속
                    imap.Login(fromid, frompw);               // 메일서버에 로그인   
                }
                catch (Exception ex)
                {
                    Response.Write("Exception: " + ex.Message + "<br />");
                }

                List<int> keybox = DAUM_UID(imap, mailbox, readtype, subject, body, from, sdate, edate);
                imap.Disconnect();

                JavaScriptSerializer jsSerializer = new JavaScriptSerializer();
                Response.Write(jsSerializer.Serialize(keybox));
            }
            else if (mailstate == "DAUMMAILBOX")                            // 다음 메일 박스
            {
                ImapX.ImapClient imap = new ImapX.ImapClient();

                try
                {
                    imap.Connect("imap.daum.net", 993, true); // 메일서버 접속
                    imap.Login(fromid, frompw);               // 메일서버에 로그인   
                }
                catch (Exception ex)
                {
                    Response.Write("Exception: " + ex.Message + "<br />");
                }
                
                List<string> keybox = DAUM_MAILBOX(imap);
                imap.Disconnect();

                JavaScriptSerializer jsSerializer = new JavaScriptSerializer();
                Response.Write(jsSerializer.Serialize(keybox));
            }
            else if (mailstate == "DAUMDEL")                            // 다음 uid 삭제
            {
                string mailbox = Request["MAILBOX"];
                string uid = Request["UID"];
                ImapX.ImapClient imap = new ImapX.ImapClient();

                try
                {
                    imap.Connect("imap.daum.net", 993, true); // 메일서버 접속
                    imap.Login(fromid, frompw);               // 메일서버에 로그인   
                }
                catch (Exception ex)
                {
                    Response.Write("Exception: " + ex.Message + "<br />");
                }
                bool delyn = DAUM_Delete(imap, mailbox, uid);

                imap.Disconnect();

                Response.Write(delyn);
            }
            else if (mailstate == "DAUMSEEN")                            // 다음 읽음 표시
            {
                string mailbox = Request["MAILBOX"];
                string uid = Request["UID"];
                ImapX.ImapClient imap = new ImapX.ImapClient();

                try
                {
                    imap.Connect("imap.daum.net", 993, true); // 메일서버 접속
                    imap.Login(fromid, frompw);               // 메일서버에 로그인   
                }
                catch (Exception ex)
                {
                    Response.Write("Exception: " + ex.Message + "<br />");
                }
                bool seenyn = DAUM_ChangeSeen(imap, mailbox, uid);

                imap.Disconnect();

                Response.Write(seenyn);
            }
            else if (mailstate == "DAUMCOUNT")                            // 다음 키 박스
            {
                string mailbox = Request["MAILBOX"];

                ActiveUp.Net.Mail.Imap4Client imap = new ActiveUp.Net.Mail.Imap4Client();

                imap.ConnectSsl("imap.daum.net", 993);                      // 메일서버 접속

                int count = DAUMCOUNT(imap, fromid, frompw, UTF7Encode(mailbox));
                imap.Disconnect();
                Response.Write(count);
            }
            else if(mailstate == "AGENT")
            {
                string empcd = Request["EMPCD"];
                int lastkey = Int32.Parse(Request["LASTKEY"]);
                string id = Request["FROMID"];
                string pw = Request["FROMPW"];

                ImapX.ImapClient imap = new ImapX.ImapClient();

                try
                {
                    imap.Connect("mail.yeungjin.co.kr", 143, false);
                    //imap.Connect("mail.optisco.com", 143, false); // 메일서버 접속
                    imap.Login(id, pw);               // 메일서버에 로그인   
                }
                catch (Exception ex)
                {
                    Response.Write("Exception: " + ex.Message + "<br />");
                }
                DataSet ds = IMAP_Agent(imap, empcd, lastkey);
                imap.Disconnect();

                if (ds.Tables.Count == 0)
                    Response.Write(false);
                else
                    Response.Write(true);
                
            }
        }
        catch (Exception ex)
        {
            Response.Write(ex);
        }
        Response.End();
    }

    /**************************************************** 메일 전송 *****************************************************************/

    //SSL 방식이 적용된 메일 전송(구형) - 다음은 구형만 가능하기 때문에 다음으로 고정, 이 방식은 속도가 느림
    public bool SendCDOSSL(string fromid, string frompw, string host, int port, string toid, string cc, string bcc,
                           string title, string body, string filepath, string filename, string displayname)
    {
        try
        {
            CDO.Message mail = new CDO.Message();
            CDO.IConfiguration configuration = mail.Configuration;
            ADODB.Fields fields = configuration.Fields;

            if (displayname != "" && displayname != null)
                mail.From = displayname + "(" + fromid + ")";
            else
                mail.From = fromid;
            mail.To = toid;
            if (cc != "" && cc != null)
                mail.CC = cc;
            if (bcc != "" && bcc != null)
                mail.BCC = bcc;
            mail.Subject = title;
            mail.HTMLBody = body;

            if (filename != "" && filename != null)
            {
                try
                {
                    string[] filenameArr = filename.Split('»');
                    string[] filepathArr = filepath.Split('»');
                    System.Net.Mail.Attachment attachment;
                    for (int i = 0; i < (filenameArr.Length - 1); i++)
                    {
                        attachment = new System.Net.Mail.Attachment(Server.MapPath(".") + "/../" + filepathArr[i]);
                        attachment.Name = filenameArr[i];
                        mail.AddAttachment(Server.MapPath(".") + "/../" + filepathArr[i]);
                    }

                }
                catch (Exception ex)
                {
                    System.Net.Mail.Attachment attachment;
                    attachment = new System.Net.Mail.Attachment(Server.MapPath(".") + "/../" + filepath);
                    attachment.Name = filename;
                    mail.AddAttachment(Server.MapPath(".") + "/../" + filepath);
                }
            }

            //CDO 설정

            ADODB.Field field = fields["http://schemas.microsoft.com/cdo/configuration/smtpserver"];
            field.Value = host;

            field = fields["http://schemas.microsoft.com/cdo/configuration/smtpserverport"];
            field.Value = port;

            field = fields["http://schemas.microsoft.com/cdo/configuration/sendusing"];
            field.Value = CDO.CdoSendUsing.cdoSendUsingPort;

            field = fields["http://schemas.microsoft.com/cdo/configuration/smtpauthenticate"];
            field.Value = CDO.CdoProtocolsAuthentication.cdoBasic;

            field = fields["http://schemas.microsoft.com/cdo/configuration/sendusername"];
            field.Value = fromid;

            field = fields["http://schemas.microsoft.com/cdo/configuration/sendpassword"];
            field.Value = frompw;

            field = fields["http://schemas.microsoft.com/cdo/configuration/smtpusessl"];
            field.Value = "true";

            fields.Update();

            //전송
            mail.Send();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return false;
        }
        return true;
    }


    /**************************************************** 메일 읽기 *****************************************************************/

    //다음 모든 메일 조회
    private DataSet DAUM_IMAP(ImapX.ImapClient imap, string mailbox, string type, string uid)
    {
        DataSet ds = new DataSet();

        try
        {
            string query = "ALL";
            if(type == "seen" || type == "SEEN")
                query = "SEEN";
            else if(type == "unseen" || type == "UNSEEN")
                query = "UNSEEN";
            

            if (uid != "" && uid != null)
                query += (" UID " + uid);

            ImapX.Message[] messages = imap.Folders[mailbox].Search(query);

            if (messages.Length > 0)
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("ID");
                dt.Columns.Add("SUBJECT");
                dt.Columns.Add("FROMNM");
                dt.Columns.Add("FROMADDR");
                dt.Columns.Add("TO");
                dt.Columns.Add("CC");
                dt.Columns.Add("CCCOUNT");
                dt.Columns.Add("BCC");
                dt.Columns.Add("BCCCOUNT");
                dt.Columns.Add("DATE");
                dt.Columns.Add("FILECOUNT");
                dt.Columns.Add("FILENM");
                dt.Columns.Add("FILE");
                dt.Columns.Add("BODY");
                dt.Columns.Add("FLAG");
                dt.Columns.Add("MAILSIZE");

                ImapX.Message msg = null;

                for (var i = 0; i < messages.Length; i++)
                {
                    msg = messages[i];

                    DataRow newRow = dt.NewRow();
                    newRow["ID"] = msg.UId;
                    newRow["SUBJECT"] = msg.Subject;
                    newRow["FROMNM"] = msg.From.DisplayName;
                    newRow["FROMADDR"] = msg.From.Address;

                    string to = "";
                    for (int j = 0; j < msg.To.Count; j++)
                    {
                        to += "\"" + msg.To[j].DisplayName + "\"<" + msg.To[j].Address + ">" + "»";
                    }
                    newRow["TO"] = to;
                    string cc = "";
                    for (int j = 0; j < msg.Cc.Count; j++)
                    {
                        cc += "\"" + msg.Cc[j].DisplayName + "\"<" + msg.Cc[j].Address + ">" + "»";
                    }
                    newRow["CC"] = cc;
                    newRow["CCCOUNT"] = msg.Cc.Count;
                    string bcc = "";
                    for (int j = 0; j < msg.Bcc.Count; j++)
                    {
                        bcc += "\"" + msg.Bcc[j].DisplayName + "\"<" + msg.Bcc[j].Address + ">" + "»";
                    }
                    newRow["BCC"] = bcc;
                    newRow["BCCCOUNT"] = msg.Bcc.Count;
                    DateTime date = new DateTime();
                    if (msg.Date == null)
                    {
                        date = DateTime.Parse("0001-01-01 12:00:00");
                    }
                    else
                    {
                        date = DateTime.Parse(msg.Date.ToString());
                    }
                    newRow["DATE"] = date.ToString("yyyy-MM-dd HH:mm:ss");
                    newRow["FILECOUNT"] = msg.Attachments.Length;
                    string filename = "";
                    string fileBASE64 = "";
                    for (int j = 0; j < msg.Attachments.Length; j++)
                    {
                        filename += msg.Attachments[j].FileName + "»";

                        fileBASE64 += msg.Attachments[j].GetTextData() + "»";

                    }
                    newRow["FILENM"] = filename;
                    newRow["FILE"] = fileBASE64;
                    if (msg.Body.HasHtml) {
                        try
                        {
                            newRow["BODY"] = msg.Body.Html;
                        }
                        catch (Exception ex)
                        {
                            newRow["BODY"] = "";
                        }
                    }
                    else if(msg.Body.HasText)
                    {
                        try
                        {
                            newRow["BODY"] = msg.Body.Text;
                        }
                        catch(Exception ex)
                        {
                            newRow["BODY"] = "";
                        }
                    }
                    else
                    {
                        newRow["BODY"] = "";
                    }
                    string flag = "UNSEEN";
                    if (msg.Seen)
                    {
                        flag = "SEEN";
                    }
                    newRow["FLAG"] = flag;
                    newRow["MAILSIZE"] = msg.Size;

                    dt.Rows.Add(newRow);
                }

                ds.Tables.Add(dt);

            }
        }
        catch (Exception ex)
        {
            Response.Write("Exception: " + ex.Message + "<br />");
        }
        return ds;
    }

    //조회한 메일을 병합하여 조회 조건에 맞게 최근 순으로 정렬
    public DataSet DAUM_READ(ImapX.ImapClient imap, string mailbox, string type, string uid, string subject, string body, string from, string sdate, string edate)
    {
        DataSet ds = DAUM_IMAP(imap, mailbox, type, uid);

        if (ds.Tables.Count == 0)
        {
            return ds;
        }
        DataTable dt = ds.Tables[0];
        DataTable output = new DataTable();
        output = dt.Clone();

        if (sdate != "" && sdate != null)
            sdate += " 00:00:00";
        if (edate != "" && edate != null)
            edate += " 23:59:59";

        for (int i = 0; i < dt.Rows.Count; i++)
        {
            DataRow dr = dt.Rows[i];
            int subcheck = 0;
            if (subject != "" && subject != null)
            {
                string substr = dr["SUBJECT"].ToString();
                if (!substr.Contains(subject) || substr.Length < subject.Length)
                    subcheck = 2;
                else
                    subcheck = 1;
            }
            int bodycheck = 0;
            if (body != "" && body != null)
            {
                string bodystr = dr["BODY"].ToString();
                if (!bodystr.Contains(body) || bodystr.Length < body.Length)
                    bodycheck = 2;
                else
                    bodycheck = 1;
            }
            int fromcheck = 0;
            if (from != "" && from != null)
            {
                string fromnmstr = dr["FROMNM"].ToString();
                string fromstr = dr["FROMADDR"].ToString();
                if ((!fromnmstr.Contains(from) || fromnmstr.Length < from.Length) && (!fromstr.Contains(from) || fromstr.Length < from.Length))
                    fromcheck = 2;
                else
                    fromcheck = 1;
            }

            //check => 0: 조건 없음 1: true 2: false
            bool totalcheck = false;
            if (subcheck == 0 && bodycheck == 0 && fromcheck == 0)
                totalcheck = true;
            else if (subcheck == 1 || bodycheck == 1 || fromcheck == 1)
                totalcheck = true;

            if (!totalcheck)
                continue;

            if ((sdate != "" && sdate != null) || (edate != "" && edate != null))
            {
                string date = dr["DATE"].ToString();
                if (sdate == "" || sdate == null)
                    sdate = "1900-01-01 00:00:00";
                if (edate == "" || edate == null)
                    edate = "2900-01-01 00:00:00";

                DateTime sdate_dt = DateTime.Parse(sdate);
                DateTime edate_dt = DateTime.Parse(edate);
                DateTime date_dt = DateTime.Parse(date);

                if (sdate_dt > date_dt || date_dt > edate_dt)
                    continue;
            }

            output.ImportRow(dr);
        }

        DataSet output_set = new DataSet();
        output_set.Tables.Add(output);
        return output_set;

    }

    //다음 모든 메일 조회
    private DataSet DAUM_PAGE(ImapX.ImapClient imap, string mailbox, int totalcount, int page, int count)
    {
        DataSet ds = new DataSet();

        try
        {
            string query = "ALL";
            int start = totalcount - (page * count) + 1;
            int end = totalcount - ((page - 1) * count);
            query += (" " + start + ":" + end);

            ImapX.Message[] messages = imap.Folders[mailbox].Search(query);

            if (messages.Length > 0)
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("ID");
                dt.Columns.Add("SUBJECT");
                dt.Columns.Add("FROMNM");
                dt.Columns.Add("FROMADDR");
                dt.Columns.Add("TO");
                dt.Columns.Add("CC");
                dt.Columns.Add("CCCOUNT");
                dt.Columns.Add("BCC");
                dt.Columns.Add("BCCCOUNT");
                dt.Columns.Add("DATE");
                dt.Columns.Add("FILECOUNT");
                dt.Columns.Add("FILENM");
                dt.Columns.Add("FILE");
                dt.Columns.Add("BODY");
                dt.Columns.Add("FLAG");
                dt.Columns.Add("MAILSIZE");

                ImapX.Message msg = null;

                for (var i = 0; i < messages.Length; i++)
                {
                    msg = messages[i];

                    DataRow newRow = dt.NewRow();
                    newRow["ID"] = msg.UId;
                    newRow["SUBJECT"] = msg.Subject;
                    newRow["FROMNM"] = msg.From.DisplayName;
                    newRow["FROMADDR"] = msg.From.Address;

                    string to = "";
                    for (int j = 0; j < msg.To.Count; j++)
                    {
                        to += "\"" + msg.To[j].DisplayName + "\"<" + msg.To[j].Address + ">" + "»";
                    }
                    newRow["TO"] = to;
                    string cc = "";
                    for (int j = 0; j < msg.Cc.Count; j++)
                    {
                        cc += "\"" + msg.Cc[j].DisplayName + "\"<" + msg.Cc[j].Address + ">" + "»";
                    }
                    newRow["CC"] = cc;
                    newRow["CCCOUNT"] = msg.Cc.Count;
                    string bcc = "";
                    for (int j = 0; j < msg.Bcc.Count; j++)
                    {
                        bcc += "\"" + msg.Bcc[j].DisplayName + "\"<" + msg.Bcc[j].Address + ">" + "»";
                    }
                    newRow["BCC"] = bcc;
                    newRow["BCCCOUNT"] = msg.Bcc.Count;
                    DateTime date = new DateTime();
                    if (msg.Date == null)
                    {
                        date = DateTime.Parse("0001-01-01 12:00:00");
                    }
                    else
                    {
                        date = DateTime.Parse(msg.Date.ToString());
                    }
                    newRow["DATE"] = date.ToString("yyyy-MM-dd HH:mm:ss");
                    newRow["FILECOUNT"] = msg.Attachments.Length;
                    string filename = "";
                    string fileBASE64 = "";
                    for (int j = 0; j < msg.Attachments.Length; j++)
                    {
                        filename += msg.Attachments[j].FileName + "»";

                        fileBASE64 += msg.Attachments[j].GetTextData() + "»";

                    }
                    newRow["FILENM"] = filename;
                    newRow["FILE"] = fileBASE64;
                    if (msg.Body.HasHtml)
                    {
                        try
                        {
                            newRow["BODY"] = msg.Body.Html;
                        }
                        catch (Exception ex)
                        {
                            newRow["BODY"] = "";
                        }
                    }
                    else if (msg.Body.HasText)
                    {
                        try
                        {
                            newRow["BODY"] = msg.Body.Text;
                        }
                        catch (Exception ex)
                        {
                            newRow["BODY"] = "";
                        }
                    }
                    else
                    {
                        newRow["BODY"] = "";
                    }
                    string flag = "UNSEEN";
                    if (msg.Seen)
                    {
                        flag = "SEEN";
                    }
                    newRow["FLAG"] = flag;
                    newRow["MAILSIZE"] = msg.Size;

                    dt.Rows.Add(newRow);
                }

                ds.Tables.Add(dt);

            }
        }
        catch (Exception ex)
        {
            Response.Write("Exception: " + ex.Message + "<br />");
        }
        return ds;
    }
    /**************************************************** 부가 기능 *****************************************************************/

    //조회 조건에 맞는 키 박스
    public List<int> DAUM_UID(ImapX.ImapClient imap, string mailbox, string type, string subject, string body, string from, string sdate, string edate)
    {
        List<int> keybox = new List<int>();
        try
        {
            string query = "ALL";
            if (type == "seen" || type == "SEEN")
                query = "SEEN";
            else if (type == "unseen" || type == "UNSEEN")
                query = "UNSEEN";
            
            ImapX.Message[] messages = imap.Folders[mailbox].Search(query);

            if (sdate != "" && sdate != null)
                sdate += " 00:00:00";
            if (edate != "" && edate != null)
                edate += " 23:59:59";

            for (int i = 0; i < messages.Length; i++)
            {
                int subcheck = 0;
                if (subject != "" && subject != null)
                {
                    string substr = messages[i].Subject;
                    if (!substr.Contains(subject) || substr.Length < subject.Length)
                        subcheck = 2;
                    else
                        subcheck = 1;
                }
                int bodycheck = 0;
                if (body != "" && body != null)
                {
                    string bodystr = "";
                    if (messages[i].Body.HasHtml)
                    {
                        bodystr = messages[i].Body.Html;
                    }
                    else if (messages[i].Body.HasText)
                    {
                        try
                        {
                            bodystr = messages[i].Body.Text;
                        }
                        catch (Exception ex)
                        {
                            bodystr = "";
                        }
                    }
                    else
                    {
                        bodystr = "";
                    }
                    if (!bodystr.Contains(body) || bodystr.Length < body.Length)
                        bodycheck = 2;
                    else
                        bodycheck = 1;
                }
                int fromcheck = 0;
                if (from != "" && from != null)
                {
                    string fromnmstr = messages[i].From.DisplayName;
                    string fromstr = messages[i].From.Address;
                    if ((!fromnmstr.Contains(from) || fromnmstr.Length < from.Length) && (!fromstr.Contains(from) || fromstr.Length < from.Length))
                        fromcheck = 2;
                    else
                        fromcheck = 1;
                }
                
                //check => 0: 조건 없음 1: true 2: false
                bool totalcheck = false;
                if (subcheck == 0 && bodycheck == 0 && fromcheck == 0)
                    totalcheck = true;
                else if (subcheck == 1 || bodycheck == 1 || fromcheck == 1)
                    totalcheck = true;

                if (!totalcheck)
                    continue;

                if ((sdate != "" && sdate != null) || (edate != "" && edate != null))
                {
                    DateTime date = new DateTime();
                    if (messages[i].Date == null)
                    {
                        date = DateTime.Parse("0001-01-01 12:00:00");
                    }
                    else
                    {
                        date = DateTime.Parse(messages[i].Date.ToString());
                    }

                    string datestr = date.ToString("yyyy-MM-dd hh:mm:ss");
                    if (sdate == "" || sdate == null)
                        sdate = "1900-01-01 00:00:00";
                    if (edate == "" || edate == null)
                        edate = "2900-01-01 00:00:00";

                    DateTime sdate_dt = DateTime.Parse(sdate);
                    DateTime edate_dt = DateTime.Parse(edate);
                    DateTime date_dt = DateTime.Parse(datestr);

                    if (sdate_dt > date_dt || date_dt > edate_dt)
                        continue;
                }
                keybox.Add(Int32.Parse(messages[i].UId.ToString()));
            }

        }
        catch (Exception ex)
        {
            Response.Write("Exception: " + ex.Message + "<br />");
        }

        return keybox;
    }

    //조회 조건에 맞는 키 박스
    private List<string> DAUM_MAILBOX(ImapX.ImapClient imap)
    {
        List<string> mailbox = new List<string>();
        try
        {
            var test = imap.Folders;
            foreach (var item in test)
            {
                mailbox.Add(item.Name);
            }
            //for (int i = 0; i < test.List.Count; i++)
            //{
            //    mailbox.Add(imap.Folders[i].Name);
            //}

        }
        catch (Exception ex)
        {
            Response.Write("Exception: " + ex.Message + "<br />");
        }

        return mailbox;
    }

    private int DAUMCOUNT(ActiveUp.Net.Mail.Imap4Client imap, string fromid, string frompw, string mailbox)
    {
        int count = 0;
        var mailAddress = fromid;
        var mailPassword = frompw;
        try
        {
            imap.Login(mailAddress, mailPassword);              // 메일서버에 로그인        

            ActiveUp.Net.Mail.Mailbox box = imap.SelectMailbox(mailbox);

            count = box.MessageCount;
        }
        catch (ActiveUp.Net.Mail.Imap4Exception iex)
        {
            Response.Write("Imap4 Error: " + iex.Message + "<br />");
        }
        catch (Exception ex)
        {
            Response.Write("Exception: " + ex.Message + "<br />");
        }

        return count;
    }

    public Boolean DAUM_Delete(ImapX.ImapClient imap, string mailbox, string uid)
    {
        DataSet ds = new DataSet();

        try
        {
            var messages = imap.Folders[mailbox].Search("UID "+uid);
            foreach(var mess in messages)
            {
                mess.Remove();
            }
            return true;
        }
        catch (Exception ex)
        {
            Response.Write("Exception: " + ex.Message + "<br />");
        }
        return false;
    }
    public Boolean DAUM_ChangeSeen(ImapX.ImapClient imap, string mailbox, string uid)
    {
        DataSet ds = new DataSet();

        try
        {
            ImapX.Message[] messages = imap.Folders[mailbox].Search("UID "+uid);
            foreach (var mess in messages)
            {
                mess.Seen = true;
            }
            return true;
        }
        catch (Exception ex)
        {
            Response.Write("Exception: " + ex.Message + "<br />");
        }
        return false;
    }

    //IMAP에서 한글을 UTF7로 변경하기 때문에 해당 기능 필요(파일은 BASE64)
    internal static string UTF7Decode(string s)
    {
        StringReader reader = new StringReader(s);
        StringBuilder builder = new StringBuilder();
        while (reader.Peek() != -1)
        {
            char c = (char)reader.Read();
            if (c == '&' && reader.Peek() != '-')
            {
                // The character sequence needs to be decoded.
                StringBuilder sequence = new StringBuilder();
                while (reader.Peek() != -1)
                {
                    if ((c = (char)reader.Read()) == '-')
                        break;
                    sequence.Append(c);
                }
                string encoded = sequence.ToString().Replace(',', '/');
                int pad = encoded.Length % 4;
                if (pad > 0)
                    encoded = encoded.PadRight(encoded.Length + (4 - pad), '=');
                try
                {
                    byte[] buffer = Convert.FromBase64String(encoded);
                    builder.Append(Encoding.BigEndianUnicode.GetString(buffer));
                }
                catch (Exception e)
                {
                    throw new FormatException(
                        "The input string is not in the correct Format.", e);
                }
            }
            else
            {
                if (c == '&' && reader.Peek() == '-')
                    reader.Read();
                builder.Append(c);
            }
        }
        return builder.ToString();
    }
    internal static string UTF7Encode(string s)
    {
        StringReader reader = new StringReader(s);
        StringBuilder builder = new StringBuilder();
        while (reader.Peek() != -1)
        {
            char c = (char)reader.Read();
            int codepoint = Convert.ToInt32(c);
            // It's a printable ASCII character.
            if (codepoint > 0x1F && codepoint < 0x7F)
            {
                builder.Append(c == '&' ? "&-" : c.ToString());
            }
            else
            {
                // The character sequence needs to be encoded.
                StringBuilder sequence = new StringBuilder(c.ToString());
                while (reader.Peek() != -1)
                {
                    codepoint = Convert.ToInt32((char)reader.Peek());
                    if (codepoint > 0x1F && codepoint < 0x7F)
                        break;
                    sequence.Append((char)reader.Read());
                }
                byte[] buffer = Encoding.BigEndianUnicode.GetBytes(
                    sequence.ToString());
                string encoded = Convert.ToBase64String(buffer).Replace('/', ',').
                    TrimEnd('=');
                builder.Append("&" + encoded + "-");
            }
        }
        return builder.ToString();
    }

    private DataSet IMAP_Agent(ImapX.ImapClient imap, string empcd, int lastkey)
    {
        lastkey++;
        if (lastkey <= 0)
        {
            lastkey = 1;
        }
        DataSet ds = new DataSet();
        try
        {     
            ImapX.Message[] messages = imap.Folders.Inbox.Search("ALL UNDELETED UID " + lastkey + ":*");

            if (messages.Length > 0)
            {
                ItsMaria maria = new ItsMaria("COMMAIL", "SETMAIL");
                maria.AddParam("EMPCD", empcd);

                for (int n = 0; n < messages.Length; n++)
                {
                    maria.AddList("MAILID_LIST", messages[n].UId);
                    maria.AddList("SUBJECT_LIST", messages[n].Subject.Replace("\'", "\'\'"));
                    maria.AddList("FROMNM_LIST", messages[n].From.DisplayName);
                    maria.AddList("FROMADDR_LIST", messages[n].From.Address);

                    string to = "";
                    if (messages[n].To.Count == 0)
                    {
                        to = " ";
                    }
                    else
                    {
                        for (int j = 0; j < messages[n].To.Count; j++)
                        {
                            to += "\"" + messages[n].To[j].DisplayName + "\"<" + messages[n].To[j].Address + ">" + ",";
                        }
                    }

                    maria.AddList("TOADDR_LIST", to);
                    string cc = "";
                    if (messages[n].Cc.Count == 0)
                    {
                        cc = " ";
                    }
                    else
                    {
                        for (int j = 0; j < messages[n].Cc.Count; j++)
                        {
                            cc += "\"" + messages[n].Cc[j].DisplayName + "\"<" + messages[n].Cc[j].Address + ">" + ",";
                        }
                    }

                    maria.AddList("CCID_LIST", cc);
                    string bcc = "";
                    if (messages[n].Bcc.Count == 0)
                    {
                        bcc = " ";
                    }
                    else
                    {
                        for (int j = 0; j < messages[n].Bcc.Count; j++)
                        {
                            bcc += "\"" + messages[n].Bcc[j].DisplayName + "\"<" + messages[n].Bcc[j].Address + ">" + ",";
                        }
                    }
                    maria.AddList("BCCID_LIST", bcc);
                    DateTime date = new DateTime();
                    if (messages[n].Date == null)
                    {
                        date = DateTime.Parse("0001-01-01 12:00:00");
                    }
                    else
                    {
                        date = DateTime.Parse(messages[n].Date.ToString().Replace("PDT", "").Replace("(", "").Replace(")", ""));
                    }
                    maria.AddList("DATE_LIST", date.ToString("yyyy-MM-dd hh:mm:ss"));
                    maria.AddList("FILECOUNT_LIST", messages[n].Attachments.Length);
                    string filename = "";
                    string fileBASE64 = "";
                    if (messages[n].Attachments.Length == 0)
                    {
                        filename = " ";
                    }
                    else
                    {
                        for (int i = 0; i < messages[n].Attachments.Length - 1; i++)
                        {
                            filename += messages[n].Attachments[i].FileName + ",";

                            fileBASE64 = Convert.ToBase64String(messages[n].Attachments[i].FileData) + ",";

                        }

                        filename += messages[n].Attachments[messages[n].Attachments.Length - 1].FileName;

                        fileBASE64 += Convert.ToBase64String(messages[n].Attachments[messages[n].Attachments.Length - 1].FileData);
                    }
                    maria.AddList("FILENM_LIST", filename);
                    string body = "";
                    if (messages[n].Body.HasHtml)
                    {
                        body = messages[n].Body.Html;
                    }
                    else if (messages[n].Body.HasText)
                    {
                        try
                        {
                            body = messages[n].Body.Text;
                        }
                        catch (Exception ex)
                        {
                            body = "";
                        }
                    }
                    else
                    {
                        body = "";
                    }
                    maria.AddList("BODY_LIST", body.Replace("\'", "\'\'"));
                    string flag = "UNSEEN";
                    if (messages[n].Seen)
                    {
                        flag = "SEEN";
                    }
                    maria.AddList("FLAG_LIST", flag);
                    maria.AddList("MAILSIZE_LIST", messages[n].Size);
                }
                DataSet dbds = maria.CallProc(ConnStringCust, 120);
                if (maria.IsError)
                {
                    return ds;
                }
                ds = dbds;
            }

        }
        catch (Exception ex)
        {
            Response.Write("Exception: " + ex.Message + "<br />");
        }
        return ds;
    }

}