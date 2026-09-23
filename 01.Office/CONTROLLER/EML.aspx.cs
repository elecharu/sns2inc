using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.IO;
using System.Net.Mail;
using ActiveUp.Net.Mail;
using System.Web.Script.Serialization;
using OpenPop.Pop3;


public partial class EML : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            var mailstate = Request["MAILSTATE"];
            var host = Request["HOST"];
            string fromid = Request["FROMID"];
            string frompw = Request["FROMPW"];

            if (mailstate == "SEND")                            // 메일 전송 SMTP
            {
                string toid = Request["TOID"];
                string cc = Request["CC"];
                string bcc = Request["BCC"];
                string title = Request["TITLE"];
                string body = Request["BODY"];
                string filepath = Request["filepath"];
                string filename = Request["filename"];
                string displaynm = Request["DISPLAYNM"];
                Response.Write(Send(fromid, frompw, host, 25, toid, cc, bcc, title, body, filepath, filename, displaynm));
            }
            else if (mailstate == "RECEIVE")                    // 메일 읽기 IMAP
            {
                string readtype = Request["READTYPE"];          // all 모두 보기, unseen 안읽은거 보기, seen 읽은거 보기
                string uid = Request["UID"];
                string subject = Request["SUBJECT"];
                string body = Request["BODY"];
                string from = Request["SENDFROM"];
                string sdate = Request["SDATE"];
                string edate = Request["EDATE"];

                Imap4Client imap = (Session["SESSION_IMAP"] as Imap4Client);
                if (imap == null || !imap.IsConnected)
                {
                    imap = new Imap4Client();

                    imap.Connect(host, 143);                      // 메일서버 접속
                    SetSession("SESSION_IMAP", imap);
                }
                DataSet ds = READ_IMAP(imap, fromid, frompw, readtype, uid, subject, body, from, sdate, edate);
                if (ds.Tables.Count == 0)
                    Response.Write("");
                else
                    Response.Write(DatasetToJson(ds));
            }
            else if (mailstate == "DELETE")                    // 메일 삭제 IMAP
            {
                int uid = Convert.ToInt32(Request["UID"]);
                Imap4Client imap = (Session["SESSION_IMAP"] as Imap4Client);
                if (imap == null || !imap.IsConnected)
                {
                    imap = new Imap4Client();

                    imap.Connect(host, 143);                      // 메일서버 접속
                    SetSession("SESSION_IMAP", imap);
                }
                Response.Write(Delete_IMAP(imap, fromid, frompw, uid));
            }
            else if (mailstate == "CHANGE")                    // 메일 읽음 상태로 변경 IMAP
            {
                int uid = Convert.ToInt32(Request["UID"]);
                Imap4Client imap = (Session["SESSION_IMAP"] as Imap4Client);
                if (imap == null || !imap.IsConnected)
                {
                    imap = new Imap4Client();

                    imap.Connect(host, 143);                      // 메일서버 접속
                    SetSession("SESSION_IMAP", imap);
                }
                Response.Write(ChangeSeen_IMAP(imap, fromid, frompw, uid));
            }
            else if (mailstate == "COUNT")                    // 메일 읽기 IMAP
            {
                string readtype = Request["READTYPE"];          // all 모두 보기, unseen 안읽은거 보기, seen 읽은거 보기
                string uid = Request["UID"];
                string subject = Request["SUBJECT"];
                string body = Request["BODY"];
                string from = Request["SENDFROM"];
                string sdate = Request["SDATE"];
                string edate = Request["EDATE"];

                Imap4Client imap = (Session["SESSION_IMAP"] as Imap4Client);
                if (imap == null || !imap.IsConnected)
                {
                    imap = new Imap4Client();

                    imap.Connect(host, 143);                      // 메일서버 접속
                    SetSession("SESSION_IMAP", imap);
                }

                Response.Write(IMAP_COUNT(imap, fromid, frompw, readtype, uid, subject, body, from, sdate, edate));
            }
            else if (mailstate == "KEYBOX")
            {
                string readtype = Request["READTYPE"];          // all 모두 보기, unseen 안읽은거 보기, seen 읽은거 보기
                string uid = Request["UID"];
                string subject = Request["SUBJECT"];
                string body = Request["BODY"];
                string from = Request["SENDFROM"];
                string sdate = Request["SDATE"];
                string edate = Request["EDATE"];

                Imap4Client imap = (Session["SESSION_IMAP"] as Imap4Client);
                if (imap == null || !imap.IsConnected)
                {
                    imap = new Imap4Client();

                    imap.Connect(host, 143);                      // 메일서버 접속
                    SetSession("SESSION_IMAP", imap);
                }
                List<int> keybox = IMAP_KEY(imap, fromid, frompw, readtype, uid, subject, body, from, sdate, edate);
                JavaScriptSerializer jsSerializer = new JavaScriptSerializer();
                Response.Write(jsSerializer.Serialize(keybox));
            }
            else if (mailstate == "MAILBOX")                    // 메일 읽기 IMAP
            {
                string hosttype = Request["HOSTTYPE"];          // 메일 호스트 종류 ITSCO: 자체메일, DAUM: 다음메일, UNSSL: SSL 인증 없음(port 필요), SSL: SSL 인증 있음(port 필요)
                string port = Request["PORT"];

                Imap4Client imap = new Imap4Client();
                if (hosttype == "ITSCO" || hosttype == "itsco")
                {
                    imap = (Session["SESSION_IMAP"] as Imap4Client);
                    if (imap == null || !imap.IsConnected)
                    {
                        imap = new Imap4Client();

                        imap.Connect(host, 143);                      // 메일서버 접속
                        SetSession("SESSION_IMAP", imap);
                    }
                }
                else if(hosttype == "DAUM" || hosttype == "daum")
                {
                    imap.ConnectSsl("imap.daum.net", 993);                      // 메일서버 접속
                    //imap = (Session["SESSION_IMAP_DAUM"] as Imap4Client);
                    //if (imap == null || !imap.IsConnected)
                    //{
                    //    imap = new Imap4Client();

                    //    imap.ConnectSsl("imap.daum.net", 993);                      // 메일서버 접속
                    //    SetSession("SESSION_IMAP_DAUM", imap);
                    //}
                }
                else if(hosttype == "UNSSL" || hosttype == "unssl")
                {
                    imap = new Imap4Client();

                    imap.Connect(host, Int32.Parse(port));                      // 메일서버 접속
                }
                else if (hosttype == "SSL" || hosttype == "ssl")
                {
                    imap = new Imap4Client();

                    imap.ConnectSsl(host, Int32.Parse(port));                      // 메일서버 접속
                }

                List<string> ds = MAILBOX(imap, fromid, frompw);
                if (hosttype != "ITSCO" && hosttype != "itsco")
                {
                    imap.Disconnect();
                }
                if (ds.Count == 0)
                    Response.Write("");
                else
                {
                    JavaScriptSerializer jsSerializer = new JavaScriptSerializer();
                    Response.Write(jsSerializer.Serialize(ds));
                }
            }

            else if (mailstate == "DAUMSEND")                            // 다음 메일 전송 SMTP
            {
                string toid = Request["TOID"];
                string cc = Request["CC"];
                string bcc = Request["BCC"];
                string title = Request["TITLE"];
                string body = Request["BODY"];
                string filepath = Request["filepath"];
                string filename = Request["filename"];
                string displaynm = Request["DISPLAYNM"];
                Response.Write(SendCDOSSL(fromid, frompw, host, 465, toid, cc, bcc, title, body, filepath, filename, displaynm));
            }
            else if (mailstate == "DAUMIMAP")                            // 다음 메일 전송 SMTP
            {
                string mailbox = Request["MAILBOX"];
                string page = Request["PAGE"];


                Imap4Client imap = new Imap4Client();

                imap.ConnectSsl("imap.daum.net", 993);                      // 메일서버 접속
                imap.Login(fromid, frompw);                                 // 메일서버에 로그인   
                //Imap4Client imap = (Session["SESSION_IMAP_DAUM"] as Imap4Client);
                //if (imap == null || !imap.IsConnected)
                //{
                //    imap = new Imap4Client();

                //    imap.ConnectSsl("imap.daum.net", 993);                      // 메일서버 접속
                //    imap.Login(fromid, frompw);                                 // 메일서버에 로그인   
                //    SetSession("SESSION_IMAP_DAUM", imap);
                //}

                DataSet ds = DAUM_IMAP(imap, mailbox, Int32.Parse(page));
                imap.Disconnect();

                if (ds.Tables.Count == 0)
                    Response.Write("");
                else
                    Response.Write(DatasetToJson(ds));
            }
            else if (mailstate == "DAUMPOP")                    // 다음 메일 읽기 POP3
            {
                string readtype = Request["READTYPE"];          // all 모두 보기, unseen 안읽은거 보기, seen 읽은거 보기
                string count = Request["COUNT"];
                string uid = Request["UID"];
                string subject = Request["SUBJECT"];
                string body = Request["BODY"];
                string from = Request["SENDFROM"];
                string sdate = Request["SDATE"];
                string edate = Request["EDATE"];

                try
                {
                    OpenPop.Pop3.Pop3Client pop3 = new OpenPop.Pop3.Pop3Client();
                    pop3.Connect("pop.daum.net", 995, true);
                    pop3.Authenticate(fromid, frompw, AuthenticationMethod.UsernameAndPassword);

                    SetSession("SESSION_POP3", pop3);

                    DataSet ds = POP(pop3, readtype, count, uid, subject, body, from, sdate, edate);
                    if (ds.Tables.Count == 0)
                        Response.Write("");
                    else
                        Response.Write(DatasetToJson(ds));
                }
                catch (Exception ex)
                {
                    Response.Write("Exception " + ex.Message);
                }

            }
            else if (mailstate == "DAUMREAD")
            {
                string mailbox = Request["MAILBOX"];
                string readtype = Request["READTYPE"];          // all 모두 보기, unseen 안읽은거 보기, seen 읽은거 보기
                string count = Request["COUNT"];
                string page = Request["PAGE"];
                string subject = Request["SUBJECT"];
                string body = Request["BODY"];
                string from = Request["SENDFROM"];
                string sdate = Request["SDATE"];
                string edate = Request["EDATE"];

                Imap4Client imap = new Imap4Client();
                //Imap4Client imap = (Session["SESSION_IMAP_DAUM"] as Imap4Client);
                try
                {
                    //if (imap == null || !imap.IsConnected)
                    //{
                    //    imap = new Imap4Client();

                    //    imap.ConnectSsl("imap.daum.net", 993);                      // 메일서버 접속
                    //    imap.Login(fromid, frompw);                                 // 메일서버에 로그인   
                    //    SetSession("SESSION_IMAP_DAUM", imap);
                    //}

                    imap.ConnectSsl("imap.daum.net", 993);                      // 메일서버 접속
                    imap.Login(fromid, frompw);                                 // 메일서버에 로그인   
                }
                catch(Imap4Exception iex)
                {
                    Response.Write("Imap4 Error : " + iex.Message);
                }
                catch(Exception ex)
                {
                    Response.Write("Exception : " + ex.Message);
                }
                OpenPop.Pop3.Pop3Client pop3 = (Session["SESSION_POP3_DAUM"] as OpenPop.Pop3.Pop3Client);
                try
                {
                    if (pop3 == null || !pop3.Connected)
                    {
                        pop3 = new OpenPop.Pop3.Pop3Client();

                        pop3.Connect("pop.daum.net", 995, true);                     // 메일서버 접속
                        SetSession("SESSION_POP3_DAUM", pop3);
                        pop3.Authenticate(fromid, frompw, AuthenticationMethod.UsernameAndPassword);

                        SetSession("SESSION_POP3_DAUM", pop3);
                    }
                }
                catch(Pop3Exception pex)
                {
                    Response.Write("Pop3 Error : " + pex.Message);
                }
                catch(Exception ex)
                {
                    Response.Write("Exception : " + ex.Message);
                }


                DataSet ds = Daum_READ(imap, pop3, mailbox, readtype, Int32.Parse(count), Int32.Parse(page), subject, body, from, sdate, edate);

                imap.Disconnect();
                if (ds.Tables.Count == 0)
                    Response.Write("");
                else
                    Response.Write(DatasetToJson(ds));

            }
            else if (mailstate == "DAUMUID")
            {
                string mailbox = Request["MAILBOX"];
                string readtype = Request["READTYPE"];          // all 모두 보기, unseen 안읽은거 보기, seen 읽은거 보기

                //Imap4Client imap = (Session["SESSION_IMAP_DAUM"] as Imap4Client);
                Imap4Client imap = new Imap4Client();
                try
                {
                    //if (imap == null || !imap.IsConnected)
                    //{
                    //    imap = new Imap4Client();

                    //    imap.ConnectSsl("imap.daum.net", 993);                      // 메일서버 접속
                    //    imap.Login(fromid, frompw);                                 // 메일서버에 로그인   
                    //    SetSession("SESSION_IMAP_DAUM", imap);
                    //}
                    imap.ConnectSsl("imap.daum.net", 993);                      // 메일서버 접속
                    imap.Login(fromid, frompw);                                 // 메일서버에 로그인   
                }
                catch (Imap4Exception iex)
                {
                    Response.Write("Imap4 Error : " + iex.Message);
                }
                catch (Exception ex)
                {
                    Response.Write("Exception : " + ex.Message);
                }

                DataSet ds = Daum_UID(imap, mailbox, readtype);

                imap.Disconnect();
                if (ds.Tables.Count == 0)
                    Response.Write("");
                else
                    Response.Write(DatasetToJson(ds));
            }
            else if (mailstate == "DAUMONE")                            // 다음 메일 전송 SMTP
            {
                string mailbox = Request["MAILBOX"];
                string uid = Request["UID"];

                Imap4Client imap = (Session["SESSION_IMAP_DAUM"] as Imap4Client);
                if (imap == null || !imap.IsConnected)
                {
                    imap = new Imap4Client();

                    imap.ConnectSsl("imap.daum.net", 993);                      // 메일서버 접속
                    imap.Login(fromid, frompw);                                 // 메일서버에 로그인   
                    SetSession("SESSION_IMAP_DAUM", imap);
                }

                DataSet ds = DAUM_ONE(imap, mailbox, uid);

                if (ds.Tables.Count == 0)
                    Response.Write("");
                else
                    Response.Write(DatasetToJson(ds));
            }

            else if (mailstate == "AGENT")
            {
                string empcd = Request["EMPCD"];
                int lastkey = Int32.Parse(Request["LASTKEY"]);
                Imap4Client imap = (Session["SESSION_IMAP"] as Imap4Client);
                if (imap == null || !imap.IsConnected)
                {
                    imap = new Imap4Client();

                    imap.Connect(host, 143);                      // 메일서버 접속
                    SetSession("SESSION_IMAP", imap);
                }
                DataSet ds = IMAP_Agent(imap, empcd, fromid, frompw, lastkey);
                if (ds.Tables.Count == 0)
                    Response.Write(false);
                else
                    Response.Write(true);
            }
            else if(mailstate == "ACCOUNTCREATE")
            {
                //Response.Write(AccountCreate("Administrator", "dudwls", "yeungjin.co.kr", "test2", "its1005"));
                Response.Write("NEED ACCOUNTCREATE");
            }
        }
        catch(Exception ex)
        {
            Response.Write(ex);
        }
        Response.End();
    }

    public string EmlToHTML(string emlFilePath)
    {
        CDO.Message msg = new CDO.MessageClass();
        ADODB.Stream stream = new ADODB.StreamClass();

        stream.Open(Type.Missing, ADODB.ConnectModeEnum.adModeUnknown, ADODB.StreamOpenOptionsEnum.adOpenStreamUnspecified, String.Empty, String.Empty);
        stream.LoadFromFile(emlFilePath);
        stream.Flush();
        msg.DataSource.OpenObject(stream, "_Stream");
        msg.DataSource.Save();

        return msg.HTMLBody;
    }

    /**************************************************** 메일 전송 *****************************************************************/

    //SSL 인증이 없는 메일 전송 - itsco 메일
    public bool Send(string fromid, string frompw, string host, int port, string toid, string cc, string bcc,
                           string title, string body, string filepath, string filename, string displayname)
    {
        MailMessage mail = new MailMessage();
        mail.From = new MailAddress(fromid, displayname);
        mail.To.Add(toid);
        if(cc!="" && cc!=null)
            mail.CC.Add(cc);
        if (bcc != "" && bcc != null)
            mail.Bcc.Add(bcc);
        mail.Subject = title;
        mail.Body = body;

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
                    mail.Attachments.Add(attachment);
                }
                
            }
            catch(Exception ex) {
                System.Net.Mail.Attachment attachment;
                attachment = new System.Net.Mail.Attachment(Server.MapPath(".") + "/../" + filepath);
                attachment.Name = filename;
                mail.Attachments.Add(attachment);
            }
        }
        mail.IsBodyHtml = true;

        System.Net.Mail.SmtpClient smtp = new System.Net.Mail.SmtpClient();
        smtp.Host = host;
        smtp.Port = port;
        smtp.Credentials = new System.Net.NetworkCredential(fromid, frompw);    //접속해서 인증

        try
        {
            smtp.Send(mail);
            return true;
        }
        catch (System.Net.Mail.SmtpException ex)
        {
            return false;
        }
    }

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
    private DataSet IMAP_Agent(Imap4Client imap, string empcd, string mailid, string mailpw, int lastkey)
    {
        lastkey++;
        if(lastkey <= 0)
        {
            lastkey = 1;
        }
        var mailAddress = mailid;
        var mailPassword = mailpw;
        DataSet ds = new DataSet();
        try
        {
            imap.Login(mailAddress, mailPassword);              // 메일서버에 로그인        
            
            ActiveUp.Net.Mail.Mailbox inbox = imap.SelectMailbox("inbox");
            
            int[] unseen = inbox.Search("UNSEEN UID " + lastkey + ":*");                        // 범위 안에서 안 읽은 메일 키값
            int[] allid = inbox.Search("ALL UNDELETED UID " + lastkey + ":*");                  // 범위 안의 모든 키값
            //ActiveUp.Net.Mail.MessageCollection messages = inbox.SearchParse("ALL UNDELETED UID " + lastkey + ":*"); // 범위 안의 데이터 가져오기

            
            ItsMaria maria = new ItsMaria("COMMAIL", "SETMAIL");
            foreach(var id in allid)
            {
                int uid = inbox.Fetch.Uid(id);
                Message message = inbox.Fetch.UidMessageObject(uid);

                maria.AddParam("EMPCD", empcd);

                maria.AddList("MAILID_LIST", uid);
                maria.AddList("SUBJECT_LIST", message.Subject.Replace("\'", "\'\'"));
                maria.AddList("FROMNM_LIST", message.From.Name);
                maria.AddList("FROMADDR_LIST", message.From.Email);
                string to = "";
                if (message.To.Count == 0)
                {
                    to = " ";
                }
                else
                {
                    for (int i = 0; i < message.To.Count; i++)
                    {
                        to += message.To[i].Merged + ",";
                    }
                }

                maria.AddList("TOADDR_LIST", to);
                string cc = "";
                if (message.Cc.Count == 0)
                {
                    cc = " ";
                }
                else
                {
                    for (int i = 0; i < message.Cc.Count; i++)
                    {
                        cc += message.Cc[i].Merged + ",";
                    }
                }

                maria.AddList("CCID_LIST", cc);
                string bcc = "";
                if (message.Bcc.Count == 0)
                {
                    bcc = " ";
                }
                else
                {
                    for (int i = 0; i < message.Bcc.Count; i++)
                    {
                        bcc += message.Bcc[i].Merged + ",";
                    }
                }
                maria.AddList("BCCID_LIST", bcc);
                DateTime date = new DateTime();
                if (message.DateString == null)
                {
                    date = DateTime.Parse("0001-01-01 12:00:00");
                }
                else
                {
                    date = DateTime.Parse(message.DateString.Replace("PDT", "").Replace("(", "").Replace(")", "").Replace("KST",""));
                }
                maria.AddList("DATE_LIST", date.ToString("yyyy-MM-dd hh:mm:ss"));
                maria.AddList("FILECOUNT_LIST", message.Attachments.Count);
                string filename = "";
                string fileBASE64 = "";
                if (message.Attachments.Count == 0)
                {
                    filename = " ";
                }
                else
                {
                    for (int i = 0; i < message.Attachments.Count - 1; i++)
                    {
                        filename += message.Attachments[i].Filename + ",";

                        fileBASE64 += message.Attachments[i].TextContent + ",";

                    }

                    filename += message.Attachments[message.Attachments.Count - 1].Filename;

                    fileBASE64 += message.Attachments[message.Attachments.Count - 1].TextContent;
                }
                maria.AddList("FILENM_LIST", filename);
                maria.AddList("BODY_LIST", message.BodyHtml.Text.Replace("\'", "\'\'"));
                string flag = "SEEN";
                for (int i = 0; i < unseen.Length; i++)
                {
                    if (unseen[i] == id)
                    {
                        flag = "UNSEEN";

                        //mark as unread
                        var flags = new FlagCollection();
                        flags.Add("Seen");
                        inbox.RemoveFlags(id, flags);
                    }
                }
                maria.AddList("FLAG_LIST", flag);
                maria.AddList("MAILSIZE_LIST", message.Size);
            }
            DataSet dbds = maria.CallProc(ConnStringCust, 120);
            if (maria.IsError)
            {
                return ds;
            }
            ds = dbds;

        }
        catch (Imap4Exception iex)
        {
            Response.Write("Imap4 Error: " + iex.Message + "<br />");
        }
        catch (Exception ex)
        {
            Response.Write("Exception: " + ex.Message + "<br />");
        }
        return ds;
    }

    private DataSet IMAP_Agent_HEAD()
    {
        Imap4Client imap = (Session["SESSION_IMAP"] as Imap4Client);
        if (imap == null || !imap.IsConnected)
        {
            imap = new Imap4Client();

            imap.Connect("mail.yeungjin.co.kr", 143);                      // 메일서버 접속
            SetSession("SESSION_IMAP", imap);
        }

        ItsMaria maria = new ItsMaria("COMMAIL", "GETMAILINFO");
        DataSet ds = maria.CallProc(ConnStringCust, 120);
        if (maria.IsError)
        {
            return ds;
        }

        DataSet rds = new DataSet();
        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            rds.Merge(IMAP_Agent(imap, ds.Tables[0].Rows[i]["EMPCD"].ToString(), ds.Tables[0].Rows[i]["MAILID"].ToString(), ds.Tables[0].Rows[i]["MAILPW"].ToString(), Int32.Parse(ds.Tables[0].Rows[i]["MAILKEY"].ToString())));
        }

        return rds;
    }

    //안읽은 메일 조회 (조회 시 읽음 표시로 변환되서 안읽음 표시로 다시 변경과정 포함)
    private DataSet UnSeen_IMAP(Imap4Client imap, string fromid, string frompw, string uid)
    {
        var mailAddress = fromid;
        var mailPassword = frompw;
        DataSet ds = new DataSet();

        try
        {
            imap.Login(mailAddress, mailPassword);

            imap.Command("capability");

            Mailbox inbox = imap.SelectMailbox("inbox");
            int[] ids = inbox.Search("UNSEEN");

            if(uid != "" && uid != null)
            {
                ids = inbox.Search("UNSEEN UID " + uid);
            }

            if (ids.Length > 0)
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
                dt.Columns.Add("FILESIZE");
                dt.Columns.Add("BODY");
                dt.Columns.Add("FLAG");
                dt.Columns.Add("MAILSIZE");

                ActiveUp.Net.Mail.Message msg = null;

                for (var i = 0; i < ids.Length; i++)
                {
                    msg = inbox.Fetch.MessageObject(ids[i]);                    

                    DataRow newRow = dt.NewRow();
                    newRow["ID"] = inbox.Fetch.Uid(ids[i]);
                    newRow["SUBJECT"] = msg.Subject;
                    newRow["FROMNM"] = msg.From.Name;
                    newRow["FROMADDR"] = msg.From.Email;

                    string to = "";
                    for (int j = 0; j < msg.To.Count; j++)
                    {
                        to += msg.To[j].Merged + "»";
                    }
                    newRow["TO"] = to;
                    string cc = "";
                    for (int j = 0; j < msg.Cc.Count; j++)
                    {
                        cc += msg.Cc[j].Merged + "»";
                    }
                    newRow["CC"] = cc;
                    newRow["CCCOUNT"] = msg.Cc.Count;
                    string bcc = "";
                    for (int j = 0; j < msg.Bcc.Count; j++)
                    {
                        bcc += msg.Bcc[j].Merged + "»";
                    }
                    newRow["BCC"] = bcc;
                    newRow["BCCCOUNT"] = msg.Bcc.Count;
                    DateTime date = new DateTime();
                    if (msg.DateString == null)
                    {
                        date = DateTime.Parse("0001-01-01 12:00:00");
                    }
                    else
                    {
                        date = DateTime.Parse(msg.DateString);
                    }
                    newRow["DATE"] = date.ToString("yyyy-MM-dd hh:mm:ss");
                    newRow["FILECOUNT"] = msg.Attachments.Count;
                    string filename = "";
                    string fileBASE64 = "";
                    string filesize = "";
                    for (int j = 0; j < msg.Attachments.Count; j++)
                    {
                        filename += msg.Attachments[j].Filename + "»";

                        fileBASE64 += msg.Attachments[j].TextContent + "»";
                        filesize += msg.Attachments[j].Size + "»";

                    }
                    newRow["FILENM"] = filename;
                    newRow["FILE"] = fileBASE64;
                    newRow["FILESIZE"] = filesize;
                    newRow["BODY"] = msg.BodyHtml.Text;
                    newRow["FLAG"] = "UNSEEN";
                    dt.Rows.Add(newRow);

                    //mark as unread
                    var flags = new FlagCollection();
                    flags.Add("Seen");
                    inbox.RemoveFlags(ids[i], flags);
                    newRow["MAILSIZE"] = msg.Size;

                }

                ds.Tables.Add(dt);

            }
        }
        catch (Imap4Exception iex)
        {
            Response.Write("Imap4 Error: " + iex.Message + "<br />");
        }
        catch (Exception ex)
        {
            Response.Write("Exception: " + ex.Message + "<br />");
        }
        return ds;

    }

    //읽은 메일 조회
    private DataSet Seen_IMAP(Imap4Client imap, string fromid, string frompw, string uid)
    {
        var mailAddress = fromid;
        var mailPassword = frompw;
        DataSet ds = new DataSet();

        try
        {
            imap.Login(mailAddress, mailPassword);

            imap.Command("capability");

            Mailbox inbox = imap.SelectMailbox("inbox");
            int[] ids = inbox.Search("SEEN");

            if (uid != "" && uid != null)
            {
                ids = inbox.Search("SEEN UID " + uid);
            }

            if (ids.Length > 0)
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
                dt.Columns.Add("FILESIZE");
                dt.Columns.Add("BODY");
                dt.Columns.Add("FLAG");
                dt.Columns.Add("MAILSIZE");

                ActiveUp.Net.Mail.Message msg = null;

                for (var i = 0; i < ids.Length; i++)
                {
                    msg = inbox.Fetch.MessageObject(ids[i]);
                    
                    DataRow newRow = dt.NewRow();
                    newRow["ID"] = inbox.Fetch.Uid(ids[i]);
                    newRow["SUBJECT"] = msg.Subject;
                    newRow["FROMNM"] = msg.From.Name;
                    newRow["FROMADDR"] = msg.From.Email;

                    string to = "";
                    for (int j = 0; j < msg.To.Count; j++)
                    {
                        to += msg.To[j].Merged + "»";
                    }
                    newRow["TO"] = to;
                    string cc = "";
                    for (int j = 0; j < msg.Cc.Count; j++)
                    {
                        cc += msg.Cc[j].Merged + "»";
                    }
                    newRow["CC"] = cc;
                    newRow["CCCOUNT"] = msg.Cc.Count;
                    string bcc = "";
                    for (int j = 0; j < msg.Bcc.Count; j++)
                    {
                        bcc += msg.Bcc[j].Merged + "»";
                    }
                    newRow["BCC"] = bcc;
                    newRow["BCCCOUNT"] = msg.Bcc.Count;
                    DateTime date = new DateTime();
                    if (msg.DateString == null)
                    {
                        date = DateTime.Parse("0001-01-01 12:00:00");
                    }
                    else
                    {
                        date = DateTime.Parse(msg.DateString);
                    }
                    newRow["DATE"] = date.ToString("yyyy-MM-dd hh:mm:ss");
                    newRow["FILECOUNT"] = msg.Attachments.Count;
                    string filename = "";
                    string fileBASE64 = "";
                    string filesize = "";
                    for (int j = 0; j < msg.Attachments.Count; j++)
                    {
                        filename += msg.Attachments[j].Filename + "»";

                        fileBASE64 += msg.Attachments[j].TextContent + "»";
                        filesize += msg.Attachments[j].Size + "»";

                    }
                    newRow["FILENM"] = filename;
                    newRow["FILE"] = fileBASE64;
                    newRow["FILESIZE"] = filesize;
                    newRow["BODY"] = msg.BodyHtml.Text;
                    newRow["FLAG"] = "SEEN";
                    newRow["MAILSIZE"] = msg.Size;

                    dt.Rows.Add(newRow);
                }

                ds.Tables.Add(dt);

            }
        }
        catch (Imap4Exception iex)
        {
            Response.Write("Imap4 Error: " + iex.Message + "<br />");
        }
        catch (Exception ex)
        {
            Response.Write("Exception: " + ex.Message + "<br />");
        }
        return ds;

    }

    //모든 메일 조회 (안읽은 메일은 안읽음 표시로 변경과정 포함)
    private DataSet ALL_IMAP(Imap4Client imap, string fromid, string frompw, string uid)
    {
        var mailAddress = fromid;
        var mailPassword = frompw;
        DataSet ds = new DataSet();

        try
        {
            imap.Login(mailAddress, mailPassword);              // 메일서버에 로그인        

            Mailbox inbox  = imap.SelectMailbox("inbox");
            
            int[] unseen = inbox.Search("UNSEEN");              // 안 읽은 메일 키값

            string AllQ = "ALL UNDELETED";
            if (uid != "" && uid != null)
            {
                unseen = inbox.Search("UNSEEN UID " + uid);
                AllQ = "ALL UNDELETED UID " + uid;
            }
            int[] allid = inbox.Search(AllQ);                  // 모든 키값
            MessageCollection messages = inbox.SearchParse(AllQ); // 모두 읽어오기 (한글 조회가 안돼서 코드적으로)
            
            if (messages.Count > 0)
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("ID");
                dt.Columns.Add("SUBJECT");
                dt.Columns.Add("FROMNM");
                dt.Columns.Add("FROMADDR");
                dt.Columns.Add("TO");
                dt.Columns.Add("TOCOUNT");
                dt.Columns.Add("CC");
                dt.Columns.Add("CCCOUNT");
                dt.Columns.Add("BCC");
                dt.Columns.Add("BCCCOUNT");
                dt.Columns.Add("DATE");
                dt.Columns.Add("FILECOUNT");
                dt.Columns.Add("FILENM");
                dt.Columns.Add("MIMETYPE");
                dt.Columns.Add("FILE");
                dt.Columns.Add("FILESIZE");
                dt.Columns.Add("BODY");
                dt.Columns.Add("FLAG");
                dt.Columns.Add("MAILSIZE");

                for (int n = 0; n < messages.Count; n++)
                {
                    //string return_M = "";
                    //return_M += "제목 : " + messages[n].Subject;
                    //return_M += "</br>보낸사람 : " + messages[n].From.Merged.Replace('<','[').Replace('>',']');
                    //return_M += "</br>참조 : ";
                    //for (int i=0; i < messages[n].Cc.Count; i++)
                    //{
                    //    return_M += " " + messages[n].Cc[i].Merged.Replace('<', '[').Replace('>', ']') + ";";
                    //}
                    //return_M += "</br>발송시간 : " + messages[n].Date;
                    //return_M += "</br>첨부파일 : ";
                    //return_M += "</br>내용 : " + messages[n].BodyHtml.Text;
                    //Response.Write(return_M + "</br></br>---------<a>--------------------------</br></br>");

                    DataRow newRow = dt.NewRow();
                    newRow["ID"] = inbox.Fetch.Uid(allid[n]);
                    newRow["SUBJECT"] = messages[n].Subject;
                    newRow["FROMNM"] = messages[n].From.Name;
                    newRow["FROMADDR"] = messages[n].From.Email;
                    string to = "";
                    for (int i = 0; i < messages[n].To.Count; i++)
                    {
                        to += messages[n].To[i].Merged + "»";
                    }
                    newRow["TO"] = to;
                    newRow["CCCOUNT"] = messages[n].To.Count;
                    string cc = "";
                    for (int i = 0; i < messages[n].Cc.Count; i++)
                    {
                        cc += messages[n].Cc[i].Merged + "»";
                    }
                    newRow["CC"] = cc;                    
                    newRow["CCCOUNT"] = messages[n].Cc.Count;
                    string bcc = "";
                    for (int i = 0; i < messages[n].Bcc.Count; i++)
                    {
                        bcc += messages[n].Bcc[i].Merged + "»";
                    }
                    newRow["BCC"] = bcc;
                    newRow["BCCCOUNT"] = messages[n].Bcc.Count;

                    DateTime date = new DateTime();
                    if (messages[n].DateString == null)
                    {
                        date = DateTime.Parse("0001-01-01 12:00:00");
                    }
                    else
                    {
                        date = DateTime.Parse(messages[n].DateString.Replace("PDT", "").Replace("(", "").Replace(")", "").Replace("KST", ""));
                    }
                    newRow["DATE"] = date.ToString("yyyy-MM-dd HH:mm:ss");
                    newRow["FILECOUNT"] = messages[n].Attachments.Count;
                    string filename = "";
                    string mimetype = "";
                    string fileBASE64 = "";
                    string filesize = "";
                    for(int i = 0; i < messages[n].Attachments.Count; i++)
                    {
                        filename += messages[n].Attachments[i].Filename + "»";
                        mimetype += messages[n].Attachments[i].MimeType + "»";
                        fileBASE64 += messages[n].Attachments[i].TextContent + "»";
                        filesize += messages[n].Attachments[i].Size + "»";

                    }
                    newRow["FILENM"] = filename;
                    newRow["MIMETYPE"] = mimetype;
                    newRow["FILE"] = fileBASE64;
                    newRow["FILESIZE"] = filesize;
                    newRow["BODY"] = messages[n].BodyHtml.Text;
                    newRow["FLAG"] = "";
                    for (int i = 0; i < unseen.Length; i++)
                    {
                        if(unseen[i] == allid[n])
                        {
                            newRow["FLAG"] = "UNSEEN";

                            //mark as unread
                            var flags = new FlagCollection();
                            flags.Add("Seen");
                            inbox.RemoveFlags(allid[n], flags);
                            break;
                        }
                    }

                    if(newRow["FLAG"].ToString() != "UNSEEN"){
                        newRow["FLAG"] = "SEEN";
                    }

                    newRow["MAILSIZE"] = messages[n].Size;

                    dt.Rows.Add(newRow);
                }

                ds.Tables.Add(dt);
            }
        }
        catch (Imap4Exception iex)
        {
            Response.Write("Imap4 Error: " + iex.Message + "<br />");
        }
        catch (Exception ex)
        {
            Response.Write("Exception: " + ex.Message + "<br />");
        }
        return ds;
    } 

    //조회한 메일을 병합하여 조회 조건에 맞게 최근 순으로 정렬
    public DataSet READ_IMAP(Imap4Client imap, string fromid, string frompw, string type, string uid, string subject, string body, string from, string sdate, string edate)
    {
        DataSet ds = new DataSet();
        if (type == "all" || type == "ALL") ds = ALL_IMAP(imap, fromid, frompw, uid);
        else if (type == "unseen" || type == "UNSEEN") ds = UnSeen_IMAP(imap, fromid, frompw, uid);
        else if (type == "seen" || type == "SEEN") ds = Seen_IMAP(imap, fromid, frompw, uid);

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

        for (int i = dt.Rows.Count - 1; i >= 0; i--)
        {
            DataRow dr = dt.Rows[i];
            if (subject != "" && subject != null)
            {
                string substr = dr["SUBJECT"].ToString();
                if (!substr.Contains(subject) || substr.Length < subject.Length)
                    continue;
            }
            if (body != "" && body != null)
            {
                string bodystr = dr["BODY"].ToString();
                if (!bodystr.Contains(body) || bodystr.Length < body.Length)
                    continue;
            }
            if (from != "" && from != null)
            {
                string fromnmstr = dr["FROMNM"].ToString();
                string fromstr = dr["FROMADDR"].ToString();
                if ((!fromnmstr.Contains(from) || fromnmstr.Length < from.Length) && (!fromstr.Contains(from) || fromstr.Length < from.Length))
                    continue;
            }
            if((sdate != "" && sdate != null)||(edate != "" && edate != null))
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

    //POP3방식 현재 다음에 맞게 수정됨
    private DataSet POP(OpenPop.Pop3.Pop3Client pop3, string type, string count, string uid, string subject, string body, string from, string sdate, string edate)
    {
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();
        dt.Columns.Add("ID");
        dt.Columns.Add("SUBJECT");
        dt.Columns.Add("FROMNM");
        dt.Columns.Add("FROMADDR");
        dt.Columns.Add("TO");
        dt.Columns.Add("TOCOUNT");
        dt.Columns.Add("CC");
        dt.Columns.Add("CCCOUNT");
        dt.Columns.Add("BCC");
        dt.Columns.Add("BCCCOUNT");
        dt.Columns.Add("DATE");
        dt.Columns.Add("FILECOUNT");
        dt.Columns.Add("FILENM");
        dt.Columns.Add("MIMETYPE");
        dt.Columns.Add("FILE");
        dt.Columns.Add("BODY");
        dt.Columns.Add("FLAG");
        dt.Columns.Add("MAILSIZE");

        int pageCount = 0;
        try
        {
            pageCount = Int32.Parse(count);
        }
        catch (Exception ex)
        {
            pageCount = 0;
        }
        int messageCount = pop3.GetMessageCount(); //받은메일의 메시지 개수
        if (messageCount < pageCount || pageCount == 0)
        {
            pageCount = messageCount;
        }

        List<OpenPop.Mime.Message> allMessages = new List<OpenPop.Mime.Message>(pageCount);
        int index = messageCount;
        if (uid != "" && uid != null && uid != "0")
            index = Int32.Parse(uid) - 1;
        for (var i = 1; i <= pageCount; i++)
        {
            DataRow dr = dt.NewRow();
            dr["ID"] = index;
            OpenPop.Mime.Message message;
            try
            {
                message = pop3.GetMessage(index);
            }
            catch (Exception ex)
            {
                index--;
                message = GetMessage(pop3, index, messageCount);
            }
            if (index < 1) break;
            dr["FROMNM"] = message.Headers.From.DisplayName;
            dr["FROMADDR"] = message.Headers.From.Address;
            dr["TOCOUNT"] = message.Headers.To.Count;
            dr["TO"] = "";
            for (int j = 0; j < message.Headers.To.Count; j++)
            {
                dr["TO"] += (message.Headers.To[j].Raw + ", ");
            }

            dr["CCCOUNT"] = message.Headers.Cc.Count;
            dr["CC"] = "";
            for (int j = 0; j < message.Headers.Cc.Count; j++)
            {
                dr["CC"] += (message.Headers.Cc[j].Raw + ", ");
            }
            dr["BCCCOUNT"] = message.Headers.Bcc.Count;
            dr["BCC"] = "";
            for (int j = 0; j < message.Headers.Bcc.Count; j++)
            {
                dr["BCC"] += (message.Headers.Bcc[j].Raw + ", ");
            }

            dr["SUBJECT"] = message.Headers.Subject;
            DateTime date = new DateTime();
            if (message.Headers.Date == null || message.Headers.Date == "")
            {
                date = DateTime.Parse("0001-01-01 12:00:00");
            }
            else
            {
                date = DateTime.Parse(message.Headers.Date.Replace("KST", "").Replace("(", "").Replace(")", "").Replace("KST",""));
            }
            dr["DATE"] = date.ToString("yyyy-MM-dd hh:mm:ss");

            var messageBody = String.Empty;

            var plainText = message.FindFirstPlainTextVersion();

            if (plainText == null)
            {
                var html = message.FindFirstHtmlVersion();
                messageBody = html.GetBodyAsText();
            }
            else
            {
                messageBody = plainText.GetBodyAsText();
            }
            dr["BODY"] = messageBody;

            var attachFile = message.FindAllAttachments();
            dr["FILECOUNT"] = attachFile.Count;
            dr["FILENM"] = "";
            dr["MIMETYPE"] = "";
            dr["FILE"] = "";

            foreach (var currentAttachFile in attachFile)
            {
                dr["FILENM"] += (currentAttachFile.FileName + ", ");
                dr["MIMETYPE"] += (currentAttachFile.ContentType.MediaType + ", ");
                string filepath = Server.MapPath(".").Substring(0, 27) + "\\" + currentAttachFile.FileName;
                dr["FILE"] += (filepath + ", ");
                //var attachFileInfo = new FileInfo(@"c:\yourpath\" + currentAttachFile.FileName);
                //currentAttachFile.Save(attachFileInfo);
            }

            dr["FLAG"] = "test";
            dr["MAILSIZE"] = pop3.GetMessageSize(index);
            dt.Rows.Add(dr);
            index--;
        }

        ds.Tables.Add(dt);

        return ds;
    }

    //다음 모든 메일 조회 (안읽은 메일은 안읽음 표시로 변경과정 포함)
    private DataSet DAUM_IMAP(Imap4Client imap, string mailbox, int page)
    {
        DataSet ds = new DataSet();

        try
        {
            Mailbox inbox = imap.SelectMailbox(UTF7Encode(mailbox));

            int[] unseen = inbox.Search("UNSEEN");              // 안 읽은 메일 키값

            string AllQ = "ALL UNDELETED";

            int[] allid = inbox.Search(AllQ);                  // 모든 키값
            int[] selectid;
            MessageCollection messages = new MessageCollection();
            if (page > 0)
            {
                int start = allid.Length - ((10 * page) - 1);
                int end = allid.Length - (10 * (page - 1));
                if (start < 1) start = 1;
                if (end < start) end = 1;

                selectid = inbox.Search(start + ":" + end);
                messages = inbox.SearchParse(start + ":" + end);
            }
            else
            {
                selectid = inbox.Search((allid.Length - 9) + ":" + allid.Length);
                messages = inbox.SearchParse((allid.Length - 9) + ":" + allid.Length);
            }

            if (messages.Count > 0)
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("ID");
                dt.Columns.Add("SUBJECT");
                dt.Columns.Add("FROMNM");
                dt.Columns.Add("FROMADDR");
                dt.Columns.Add("TO");
                dt.Columns.Add("TOCOUNT");
                dt.Columns.Add("CC");
                dt.Columns.Add("CCCOUNT");
                dt.Columns.Add("BCC");
                dt.Columns.Add("BCCCOUNT");
                dt.Columns.Add("DATE");
                dt.Columns.Add("FILECOUNT");
                dt.Columns.Add("FILENM");
                dt.Columns.Add("MIMETYPE");
                dt.Columns.Add("FILE");
                dt.Columns.Add("BODY");
                dt.Columns.Add("FLAG");
                dt.Columns.Add("MAILSIZE");

                for (int n = 0; n < messages.Count; n++)
                {
                    DataRow newRow = dt.NewRow();
                    newRow["ID"] = inbox.Fetch.Uid(selectid[n]);
                    newRow["SUBJECT"] = messages[n].Subject;
                    newRow["FROMNM"] = messages[n].From.Name;
                    newRow["FROMADDR"] = messages[n].From.Email;
                    string to = "";
                    for (int i = 0; i < messages[n].To.Count; i++)
                    {
                        to += messages[n].To[i].Merged + "»";
                    }
                    newRow["TO"] = to;
                    newRow["CCCOUNT"] = messages[n].To.Count;
                    string cc = "";
                    for (int i = 0; i < messages[n].Cc.Count; i++)
                    {
                        cc += messages[n].Cc[i].Merged + "»";
                    }
                    newRow["CC"] = cc;
                    newRow["CCCOUNT"] = messages[n].Cc.Count;
                    string bcc = "";
                    for (int i = 0; i < messages[n].Bcc.Count; i++)
                    {
                        bcc += messages[n].Bcc[i].Merged + "»";
                    }
                    newRow["BCC"] = bcc;
                    newRow["BCCCOUNT"] = messages[n].Bcc.Count;

                    DateTime date = new DateTime();
                    if (messages[n].DateString == null)
                    {
                        date = System.DateTime.Parse("0001-01-01 12:00:00");
                    }
                    else
                    {
                        date = System.DateTime.Parse(messages[n].DateString.Replace("PDT", "").Replace("(", "").Replace(")", "").Replace("KST",""));
                    }
                    newRow["DATE"] = date.ToString("yyyy-MM-dd HH:mm:ss");
                    newRow["FILECOUNT"] = messages[n].Attachments.Count;
                    string filename = "";
                    string mimetype = "";
                    string fileBASE64 = "";
                    for (int i = 0; i < messages[n].Attachments.Count; i++)
                    {
                        filename += messages[n].Attachments[i].Filename + "»";
                        mimetype += messages[n].Attachments[i].MimeType + "»";
                        fileBASE64 += messages[n].Attachments[i].TextContent + "»";

                    }
                    newRow["FILENM"] = filename;
                    newRow["MIMETYPE"] = mimetype;
                    newRow["FILE"] = fileBASE64;
                    newRow["BODY"] = messages[n].BodyHtml.Text;
                    newRow["FLAG"] = "";
                    for (int i = 0; i < unseen.Length; i++)
                    {
                        if (unseen[i] == selectid[n])
                        {
                            newRow["FLAG"] = "UNSEEN";

                            //mark as unread
                            var flags = new FlagCollection();
                            flags.Add("Seen");
                            inbox.RemoveFlags(selectid[n], flags);
                            break;
                        }
                    }

                    if (newRow["FLAG"].ToString() != "UNSEEN")
                    {
                        newRow["FLAG"] = "SEEN";
                    }

                    newRow["MAILSIZE"] = messages[n].Size;

                    dt.Rows.Add(newRow);
                }

                ds.Tables.Add(dt);
            }
        }
        catch (Imap4Exception iex)
        {
            Response.Write("Imap4 Error: " + iex.Message + "<br />");
        }
        catch (Exception ex)
        {
            Response.Write("Exception: " + ex.Message + "<br />");
        }
        return ds;
    }

    //다음 모든 메일 조회 (안읽은 메일은 안읽음 표시로 변경과정 포함)
    private DataSet DAUM_ONE(Imap4Client imap, string mailbox, string uid)
    {
        DataSet ds = new DataSet();

        try
        {
            Mailbox inbox = imap.SelectMailbox(UTF7Encode(mailbox));

            int[] unseen = inbox.Search("UNSEEN");              // 안 읽은 메일 키값

            string query = "ALL UNDELETED UID " + uid;

            int[] allid = inbox.Search(query);                  // 모든 키값
            MessageCollection messages = inbox.SearchParse(query);

            if (messages.Count > 0)
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("ID");
                dt.Columns.Add("SUBJECT");
                dt.Columns.Add("FROMNM");
                dt.Columns.Add("FROMADDR");
                dt.Columns.Add("TO");
                dt.Columns.Add("TOCOUNT");
                dt.Columns.Add("CC");
                dt.Columns.Add("CCCOUNT");
                dt.Columns.Add("BCC");
                dt.Columns.Add("BCCCOUNT");
                dt.Columns.Add("DATE");
                dt.Columns.Add("FILECOUNT");
                dt.Columns.Add("FILENM");
                dt.Columns.Add("MIMETYPE");
                dt.Columns.Add("FILE");
                dt.Columns.Add("BODY");
                dt.Columns.Add("FLAG");
                dt.Columns.Add("MAILSIZE");

                for (int n = 0; n < messages.Count; n++)
                {
                    DataRow newRow = dt.NewRow();
                    newRow["ID"] = inbox.Fetch.Uid(allid[n]);
                    newRow["SUBJECT"] = messages[n].Subject;
                    newRow["FROMNM"] = messages[n].From.Name;
                    newRow["FROMADDR"] = messages[n].From.Email;
                    string to = "";
                    for (int i = 0; i < messages[n].To.Count; i++)
                    {
                        to += messages[n].To[i].Merged + "»";
                    }
                    newRow["TO"] = to;
                    newRow["CCCOUNT"] = messages[n].To.Count;
                    string cc = "";
                    for (int i = 0; i < messages[n].Cc.Count; i++)
                    {
                        cc += messages[n].Cc[i].Merged + "»";
                    }
                    newRow["CC"] = cc;
                    newRow["CCCOUNT"] = messages[n].Cc.Count;
                    string bcc = "";
                    for (int i = 0; i < messages[n].Bcc.Count; i++)
                    {
                        bcc += messages[n].Bcc[i].Merged + "»";
                    }
                    newRow["BCC"] = bcc;
                    newRow["BCCCOUNT"] = messages[n].Bcc.Count;

                    DateTime date = new DateTime();
                    if (messages[n].DateString == null)
                    {
                        date = System.DateTime.Parse("0001-01-01 12:00:00");
                    }
                    else
                    {
                        date = System.DateTime.Parse(messages[n].DateString.Replace("PDT", "").Replace("(", "").Replace(")", "").Replace("KST", ""));
                    }
                    newRow["DATE"] = date.ToString("yyyy-MM-dd HH:mm:ss");
                    newRow["FILECOUNT"] = messages[n].Attachments.Count;
                    string filename = "";
                    string mimetype = "";
                    string fileBASE64 = "";
                    for (int i = 0; i < messages[n].Attachments.Count; i++)
                    {
                        filename += messages[n].Attachments[i].Filename + "»";
                        mimetype += messages[n].Attachments[i].MimeType + "»";
                        fileBASE64 += messages[n].Attachments[i].TextContent + "»";

                    }
                    newRow["FILENM"] = filename;
                    newRow["MIMETYPE"] = mimetype;
                    newRow["FILE"] = fileBASE64;
                    newRow["BODY"] = messages[n].BodyHtml.Text;
                    newRow["FLAG"] = "";
                    for (int i = 0; i < unseen.Length; i++)
                    {
                        if (unseen[i] == allid[n])
                        {
                            newRow["FLAG"] = "UNSEEN";

                            //mark as unread
                            var flags = new FlagCollection();
                            flags.Add("Seen");
                            inbox.RemoveFlags(allid[n], flags);
                            break;
                        }
                    }

                    if (newRow["FLAG"].ToString() != "UNSEEN")
                    {
                        newRow["FLAG"] = "SEEN";
                    }

                    newRow["MAILSIZE"] = messages[n].Size;

                    dt.Rows.Add(newRow);
                }

                ds.Tables.Add(dt);
            }
        }
        catch (Imap4Exception iex)
        {
            Response.Write("Imap4 Error: " + iex.Message + "<br />");
        }
        catch (Exception ex)
        {
            Response.Write("Exception: " + ex.Message + "<br />");
        }
        return ds;
    }

    //다음 모든 메일 조회(IMAP4와 POP3 연동하여 사용)
    private DataSet Daum_ALL(Imap4Client imap, OpenPop.Pop3.Pop3Client pop3, string mailbox, string type)
    {
        DataSet All_ds = new DataSet();
        DataTable All_dt = new DataTable();
        All_dt.Columns.Add("SEQ");
        All_dt.Columns.Add("ID");
        All_dt.Columns.Add("SUBJECT");
        All_dt.Columns.Add("FROMNM");
        All_dt.Columns.Add("FROMADDR");
        All_dt.Columns.Add("TO");
        All_dt.Columns.Add("TOCOUNT");
        All_dt.Columns.Add("CC");
        All_dt.Columns.Add("CCCOUNT");
        All_dt.Columns.Add("BCC");
        All_dt.Columns.Add("BCCCOUNT");
        All_dt.Columns.Add("DATE");
        All_dt.Columns.Add("FILECOUNT");
        All_dt.Columns.Add("FILENM");
        All_dt.Columns.Add("MIMETYPE");
        All_dt.Columns.Add("FILE");
        All_dt.Columns.Add("BODY");
        All_dt.Columns.Add("FLAG");
        All_dt.Columns.Add("MAILSIZE");

        DataSet UID_ds = Daum_UID(imap, mailbox, type);
        if (UID_ds.Tables.Count == 0)
        {
            return All_ds;
        }
        DataTable UID_dt = UID_ds.Tables[0];
        int messageCount = UID_dt.Rows.Count; //받은메일의 메시지 개수
        
        for (var i = 0; i < messageCount; i++)
        {
            DataRow UID_dr = UID_dt.Rows[i];
            DataRow dr = All_dt.NewRow();
            dr["SEQ"] = UID_dr["SEQ"];
            dr["ID"] = UID_dr["UID"];
            dr["FLAG"] = UID_dr["FLAG"];
            int index = Int32.Parse(UID_dr["SEQ"].ToString());
            OpenPop.Mime.Message message;
            try
            {
                message = pop3.GetMessage(index);
            }
            catch (Exception ex)
            {
                continue;
            }
            dr["FROMNM"] = message.Headers.From.DisplayName;
            dr["FROMADDR"] = message.Headers.From.Address;
            dr["TOCOUNT"] = message.Headers.To.Count;
            dr["TO"] = "";
            for (int j = 0; j < message.Headers.To.Count; j++)
            {
                dr["TO"] += (message.Headers.To[j].Raw + ", ");
            }

            dr["CCCOUNT"] = message.Headers.Cc.Count;
            dr["CC"] = "";
            for (int j = 0; j < message.Headers.Cc.Count; j++)
            {
                dr["CC"] += (message.Headers.Cc[j].Raw + ", ");
            }
            dr["BCCCOUNT"] = message.Headers.Bcc.Count;
            dr["BCC"] = "";
            for (int j = 0; j < message.Headers.Bcc.Count; j++)
            {
                dr["BCC"] += (message.Headers.Bcc[j].Raw + ", ");
            }

            dr["SUBJECT"] = message.Headers.Subject;
            DateTime date = new DateTime();
            if (message.Headers.Date == null || message.Headers.Date == "")
            {
                date = DateTime.Parse("0001-01-01 12:00:00");
            }
            else
            {
                date = DateTime.Parse(message.Headers.Date.Replace("KST", "").Replace("(", "").Replace(")", "").Replace("KST", ""));
            }
            dr["DATE"] = date.ToString("yyyy-MM-dd hh:mm:ss");

            var messageBody = String.Empty;

            var plainText = message.FindFirstPlainTextVersion();

            if (plainText == null)
            {
                var html = message.FindFirstHtmlVersion();
                messageBody = html.GetBodyAsText();
            }
            else
            {
                messageBody = plainText.GetBodyAsText();
            }
            dr["BODY"] = messageBody;

            var attachFile = message.FindAllAttachments();
            dr["FILECOUNT"] = attachFile.Count;
            dr["FILENM"] = "";
            dr["MIMETYPE"] = "";
            dr["FILE"] = "";

            foreach (var currentAttachFile in attachFile)
            {
                dr["FILENM"] += (currentAttachFile.FileName + ", ");
                dr["MIMETYPE"] += (currentAttachFile.ContentType.MediaType + ", ");
                string filepath = Server.MapPath(".").Substring(0, 27) + "\\" + currentAttachFile.FileName;
                dr["FILE"] += (filepath + ", ");
                //var attachFileInfo = new FileInfo(@"c:\yourpath\" + currentAttachFile.FileName);
                //currentAttachFile.Save(attachFileInfo);
            }

            dr["MAILSIZE"] = pop3.GetMessageSize(index);
            All_dt.Rows.Add(dr);
        }

        All_ds.Tables.Add(All_dt);

        return All_ds;
    }

    //다음 메일 조건 검색
    private DataSet Daum_READ(Imap4Client imap, OpenPop.Pop3.Pop3Client pop3, string mailbox, string type, int count, int page, string subject, string body, string from, string sdate, string edate)
    {
        DataSet ds = Daum_ALL(imap, pop3, mailbox, type);

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

        if (dt.Rows.Count < 1) return ds;

        int pagecount_s = count * (page - 1);
        if (pagecount_s > (dt.Rows.Count - 1)) pagecount_s = dt.Rows.Count - 1;
        int pagecount_e = count * page;
        if (pagecount_e > dt.Rows.Count) pagecount_e = dt.Rows.Count;

        for (int i = pagecount_s; i < pagecount_e; i++)
        {
            DataRow dr = dt.Rows[i];
            if (subject != "" && subject != null)
            {
                string substr = dr["SUBJECT"].ToString();
                if (!substr.Contains(subject) || substr.Length < subject.Length)
                    continue;
            }
            if (body != "" && body != null)
            {
                string bodystr = dr["BODY"].ToString();
                if (!bodystr.Contains(body) || bodystr.Length < body.Length)
                    continue;
            }
            if (from != "" && from != null)
            {
                string fromnmstr = dr["FROMNM"].ToString();
                string fromstr = dr["FROMADDR"].ToString();
                if ((!fromnmstr.Contains(from) || fromnmstr.Length < from.Length) && (!fromstr.Contains(from) || fromstr.Length < from.Length))
                    continue;
            }
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

    //다음 메일 메시지 가져오기
    private OpenPop.Mime.Message GetMessage(OpenPop.Pop3.Pop3Client pop3, int index, int max)
    {
        OpenPop.Mime.Message message = default(OpenPop.Mime.Message);

        if (index <= max)
        {
            try
            {
                message = pop3.GetMessage(index);
            }
            catch (Exception ex)
            {
                index++;
                message = GetMessage(pop3, index, max);
            }
        }

        return message;
    }


    /**************************************************** 부가 기능 *****************************************************************/
    //조회되는 메일 수
    public int IMAP_COUNT(Imap4Client imap, string fromid, string frompw, string type, string uid, string subject, string body, string from, string sdate, string edate)
    {
        int count = 0;
        var mailAddress = fromid;
        var mailPassword = frompw;
        DataSet ds = new DataSet();
        try
        {
            imap.Login(mailAddress, mailPassword);              // 메일서버에 로그인        

            Mailbox inbox = imap.SelectMailbox("inbox");

            string SearchType = "ALL UNDELETED ";
            if (type == "seen" || type == "SEEN")
                SearchType = "SEEN ";
            else if (type == "unseen" || type == "UNSEEN")
                SearchType = "UNSEEN ";
            
            if((subject == "" || subject == null) && (body == "" || body == null) && (from == "" || from == null) && (sdate == "" || sdate == null) && (edate == "" || edate == null))
            {
                int[] mail = inbox.Search(SearchType);
                if (uid != "" && uid != null)
                {
                    mail = inbox.Search(SearchType + "UID " + uid + ":*");
                }
                count = mail.Length;
            }
            else
            {
                MessageCollection messages = new MessageCollection();
                int[] unseen = inbox.Search("UNSEEN");              // 안 읽은 메일 키값
                int[] allid;
                if (uid != "" && uid != null)
                {
                    messages = inbox.SearchParse(SearchType + "UID " + uid + ":*");
                    allid = inbox.Search(SearchType + "UID " + uid + ":*");
                }
                else
                {
                    messages = inbox.SearchParse(SearchType);
                    allid = inbox.Search(SearchType);
                }
                if (sdate != "" && sdate != null)
                    sdate += " 00:00:00";
                if (edate != "" && edate != null)
                    edate += " 23:59:59";

                for (int i = 0; i < messages.Count; i++)
                {
                    for (int n = 0; n < unseen.Length; i++)
                    {
                        if (unseen[n] == allid[i])
                        {
                            //mark as unread
                            var flags = new FlagCollection();
                            flags.Add("Seen");
                            inbox.RemoveFlags(allid[i], flags);
                        }
                    }
                    if (subject != "" && subject != null)
                    {
                        string substr = messages[i].Subject;
                        if (!substr.Contains(subject) || substr.Length < subject.Length)
                            continue;
                    }
                    if (body != "" && body != null)
                    {
                        string bodystr = messages[i].BodyHtml.Text;
                        if (!bodystr.Contains(body) || bodystr.Length < body.Length)
                            continue;
                    }
                    if (from != "" && from != null)
                    {
                        string fromnmstr = messages[i].From.Name;
                        string fromstr = messages[i].From.Email;
                        if ((!fromnmstr.Contains(from) || fromnmstr.Length < from.Length) && (!fromstr.Contains(from) || fromstr.Length < from.Length))
                            continue;
                    }
                    if ((sdate != "" && sdate != null) || (edate != "" && edate != null))
                    {
                        DateTime date = new DateTime();
                        if (messages[i].DateString == null)
                        {
                            date = DateTime.Parse("0001-01-01 12:00:00");
                        }
                        else
                        {
                            date = DateTime.Parse(messages[i].DateString.Replace("PDT", "").Replace("(", "").Replace(")", "").Replace("KST", ""));
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
                    count++;
                }
            }
            
        }
        catch (Imap4Exception iex)
        {
            Response.Write("Imap4 Error: " + iex.Message + "<br />");
        }
        catch (Exception ex)
        {
            Response.Write("Exception: " + ex.Message + "<br />");
        }

        return count;
    }

    //조회 조건에 맞는 키 박스
    public List<int> IMAP_KEY(Imap4Client imap, string fromid, string frompw, string type, string uid, string subject, string body, string from, string sdate, string edate)
    {
        List<int> keybox = new List<int>();
        var mailAddress = fromid;
        var mailPassword = frompw;
        try
        {
            imap.Login(mailAddress, mailPassword);              // 메일서버에 로그인        

            Mailbox inbox = imap.SelectMailbox("inbox");

            string SearchType = "ALL UNDELETED ";
            if (type == "seen" || type == "SEEN")
                SearchType = "SEEN ";
            else if (type == "unseen" || type == "UNSEEN")
                SearchType = "UNSEEN ";

            
            MessageCollection messages = new MessageCollection();
            int[] unseen = inbox.Search("UNSEEN");              // 안 읽은 메일 키값
            int[] allid;
            if (uid != "" && uid != null)
            {
                messages = inbox.SearchParse(SearchType + "UID " + uid + ":*");
                allid = inbox.Search(SearchType + "UID " + uid + ":*");
            }
            else
            {
                messages = inbox.SearchParse(SearchType);
                allid = inbox.Search(SearchType);
            }
            if (sdate != "" && sdate != null)
                sdate += " 00:00:00";
            if (edate != "" && edate != null)
                edate += " 23:59:59";

            for (int i = 0; i < messages.Count; i++)
            {
                for (int n = 0; n < unseen.Length; n++)
                {
                    if (unseen[n] == allid[i])
                    {
                        //mark as unread
                        var flags = new FlagCollection();
                        flags.Add("Seen");
                        inbox.RemoveFlags(allid[i], flags);
                    }
                }
                if (subject != "" && subject != null)
                {
                    string substr = messages[i].Subject;
                    if (!substr.Contains(subject) || substr.Length < subject.Length)
                        continue;
                }
                if (body != "" && body != null)
                {
                    string bodystr = messages[i].BodyHtml.Text;
                    if (!bodystr.Contains(body) || bodystr.Length < body.Length)
                        continue;
                }
                if (from != "" && from != null)
                {
                    string fromnmstr = messages[i].From.Name;
                    string fromstr = messages[i].From.Email;
                    if ((!fromnmstr.Contains(from) || fromnmstr.Length < from.Length) && (!fromstr.Contains(from) || fromstr.Length < from.Length))
                        continue;
                }
                if ((sdate != "" && sdate != null) || (edate != "" && edate != null))
                {
                    DateTime date = new DateTime();
                    if (messages[i].DateString == null)
                    {
                        date = DateTime.Parse("0001-01-01 12:00:00");
                    }
                    else
                    {
                        date = DateTime.Parse(messages[i].DateString.Replace("PDT", "").Replace("(", "").Replace(")", "").Replace("KST", ""));
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
                keybox.Add(allid[i]);
            }

        }
        catch (Imap4Exception iex)
        {
            Response.Write("Imap4 Error: " + iex.Message + "<br />");
        }
        catch (Exception ex)
        {
            Response.Write("Exception: " + ex.Message + "<br />");
        }

        return keybox;
    }

    //모든 메일 박스 조회
    private List<string> MAILBOX(Imap4Client imap, string fromid, string frompw)
    {
        List<string> mailbox = new List<string>();
        var mailAddress = fromid;
        var mailPassword = frompw;
        DataSet ds = new DataSet();

        try
        {
            imap.Login(mailAddress, mailPassword);              // 메일서버에 로그인        

            for(int i = 0; i< imap.Mailboxes.Count; i++)
            {
                mailbox.Add(UTF7Decode(imap.Mailboxes[i].Name));
            }
        }
        catch (Imap4Exception iex)
        {
            Response.Write("Imap4 Error: " + iex.Message + "<br />");
        }
        catch (Exception ex)
        {
            Response.Write("Exception: " + ex.Message + "<br />");
        }
        return mailbox;
    }

    public Boolean Delete_IMAP(Imap4Client imap, string fromid, string frompw, int uid)
    {
        var mailAddress = fromid;
        var mailPassword = frompw;
        DataSet ds = new DataSet();

        try
        {
            imap.Login(mailAddress, mailPassword);              // 메일서버에 로그인

            Mailbox inbox = imap.SelectMailbox("inbox");

            inbox.UidDeleteMessage(uid, false);
            return true;
        }
        catch (Imap4Exception iex)
        {
            Response.Write("Imap4 Error: " + iex.Message + "<br />");
        }
        catch (Exception ex)
        {
            Response.Write("Exception: " + ex.Message + "<br />");
        }
        return false;
    }
    public Boolean ChangeSeen_IMAP(Imap4Client imap, string fromid, string frompw, int uid)
    {
        var mailAddress = fromid;
        var mailPassword = frompw;
        DataSet ds = new DataSet();

        try
        {
            imap.Login(mailAddress, mailPassword);              // 메일서버에 로그인

            Mailbox inbox = imap.SelectMailbox("inbox");


            var flags = new FlagCollection();
            flags.Add("Seen");
            inbox.UidAddFlags(uid, flags);
            return true;
        }
        catch (Imap4Exception iex)
        {
            Response.Write("Imap4 Error: " + iex.Message + "<br />");
        }
        catch (Exception ex)
        {
            Response.Write("Exception: " + ex.Message + "<br />");
        }
        return false;
    }

    private DataSet Daum_UID(Imap4Client imap, string mailbox, string type)
    {
        DataSet ds = new DataSet();

        try
        {     
            Mailbox inbox = imap.SelectMailbox(UTF7Encode(mailbox));

            string query = "ALL UNDELETED";
            if (type == "SEEN" || type == "seen")
            {
                query = "SEEN UNDELETED";
            }
            else if (type == "UNSEEN" || type == "unseen")
            {
                query = "UNSEEN UNDELETED";
            }
            int[] unseenid = inbox.Search("UNSEEN UNDELETED");
            int[] allid = inbox.Search(query);
            DataTable dt = new DataTable();
            dt.Columns.Add("SEQ");
            dt.Columns.Add("UID");
            dt.Columns.Add("FLAG");
            for (int i = allid.Length - 1; i >= 0; i--)
            {
                DataRow dr = dt.NewRow();
                dr["SEQ"] = allid[i];
                dr["UID"] = inbox.Fetch.Uid(allid[i]);
                if (Array.IndexOf(unseenid, allid[i]) >= 0)
                {
                    dr["FLAG"] = "UNSEEN";
                }
                else
                {
                    dr["FLAG"] = "SEEN";
                }
                dt.Rows.Add(dr);
            }
            ds.Tables.Add(dt);
        }
        catch (Imap4Exception iex)
        {
            Response.Write("Imap4 Error: " + iex.Message + "<br />");
        }
        catch (Exception ex)
        {
            Response.Write("Exception: " + ex.Message + "<br />");
        }

        return ds;
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
}