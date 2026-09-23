using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.IO;
using System.Net;
using System.Collections.Specialized;
using System.Security.Cryptography;
using System.Threading;
using ActiveUp.Net.Mail;
using System.Net.Mail;

public class Program
{
    static string mydoc = System.Environment.CurrentDirectory;
    //static string mydoc2 = AppDomain.CurrentDomain.BaseDirectory;

    static string logpath = mydoc + @"\Log\AgentLog_Hour.txt";
    static string logtext = "";
    static string[] info
    {
        get
        {
            string[] val;
            try
            {
                val = File.ReadAllLines(mydoc + @"\bin\MailServiceInfo.txt");
            }
            catch (Exception ex)
            {
                try
                {
                    val = File.ReadAllLines(mydoc + @"\..\bin\MailServiceInfo.txt");
                }
                catch (Exception ex2)
                {
                    val = new string[] { "HOST: \"mail.yeungjin.co.kr\"", "SMTP: \"25\"", "IMAP: \"143\"" };
                }
            }
            return val;
        }
    }
    public static string HOST
    {
        get
        {
            string val = "";
            foreach (string infostr in info)
            {
                if (infostr.IndexOf("HOST:") > -1)
                {
                    val = infostr.Split('"')[1];
                    continue;
                }
            }
            return val;
        }
    }
    public static string SMTP
    {
        get
        {
            string val = "";
            foreach (string infostr in info)
            {
                if (infostr.IndexOf("SMTP:") > -1)
                {
                    val = infostr.Split('"')[1];
                    continue;
                }
            }
            return val;
        }
    }
    public static string IMAP
    {
        get
        {
            string val = "";
            foreach (string infostr in info)
            {
                if (infostr.IndexOf("IMAP:") > -1)
                {
                    val = infostr.Split('"')[1];
                    continue;
                }
            }
            return val;
        }
    }
    public static string FilePath
    {
        get
        {
            string val = "";
            foreach (string infostr in info)
            {
                if (infostr.IndexOf("FilePath:") > -1)
                {
                    val = infostr.Split('"')[1];
                    continue;
                }
            }
            return val;
        }
    }

    public static void Main(string[] args)
    {
        DirectoryInfo folder = new DirectoryInfo(mydoc + @"\Log");
        if (folder.Exists == false) folder.Create();
        Console.WriteLine("MAIL Agent Start " + DateTime.Now);
        Console.WriteLine();
        try
        {
            Imap4Client imap = new Imap4Client();
            imap.Connect(HOST, Int32.Parse(IMAP));

            ItsMaria maria = new ItsMaria("COMMAILAGENT", "RESERVATION");
            DataSet ds = maria.CallProc();
            if (maria.IsError)
            {
                logtext = "Time : " + DateTime.Now + " Error : maria error(RESERVATION) / mess : " + maria.ErrMessage;
                System.IO.File.AppendAllText(logpath, logtext + Environment.NewLine, Encoding.Default);
                return;
            }
            int delsucc = 0;
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                string mailid = ds.Tables[0].Rows[i]["MAILID"].ToString();
                string mailpw = ds.Tables[0].Rows[i]["MAILPW"].ToString();
                int uid = Int32.Parse(ds.Tables[0].Rows[i]["UID"].ToString());
                string mailtp = ds.Tables[0].Rows[i]["MAILTP"].ToString();

                if (mailtp == "R01" || mailtp == "S01")
                {
                    if (Delete(imap, mailid, mailpw, uid, mailtp))
                    {
                        delsucc++;
                    }
                }
                else
                {
                    ItsMaria maria2 = new ItsMaria("COMMAILAGENT", "MAILDELETE");
                    maria2.AddParam("MAILADDR", mailid);
                    maria2.AddParam("MAILID", uid);
                    maria2.AddParam("MAILTP", mailtp);
                    DataSet ds2 = maria2.CallProc();
                    if (maria.IsError)
                    {
                        logtext = "Time : " + DateTime.Now + " Id : " + mailid + " UID : " + uid + " MAILTP : "+ mailtp +" Error : maria error(MAILDELETE), IMAP4 OK / mess : " + maria2.ErrMessage + "\n\n";
                        System.IO.File.AppendAllText(logpath, logtext + Environment.NewLine, Encoding.Default);
                    }
                    else
                    {
                        delsucc++;
                    }
                }
                               
            }
            if(delsucc != ds.Tables[0].Rows.Count)
            {
                logtext = "Time : " + DateTime.Now + " MISSING DELETE " + (ds.Tables[0].Rows.Count - delsucc);
                System.IO.File.AppendAllText(logpath, logtext + Environment.NewLine, Encoding.Default);
            }

            int sendsucc = 0;
            for(int i = 0; i < ds.Tables[1].Rows.Count; i++)
            {
                string EMPCD = ds.Tables[1].Rows[i]["EMPCD"].ToString();
                string MAILKEY = ds.Tables[1].Rows[i]["MAILKEY"].ToString();
                string MAILTP = ds.Tables[1].Rows[i]["MAILTP"].ToString();
                string fromid = ds.Tables[1].Rows[i]["MAILID"].ToString();
                string frompw = ds.Tables[1].Rows[i]["MAILPW"].ToString();
                string host = HOST;
                int port = Int32.Parse(IMAP);
                string toid = ds.Tables[1].Rows[i]["TOID"].ToString();
                string cc = ds.Tables[1].Rows[i]["CCID"].ToString();
                string bcc = ds.Tables[1].Rows[i]["BCCID"].ToString();
                string title = ds.Tables[1].Rows[i]["SUBJECT"].ToString();
                string body = ds.Tables[1].Rows[i]["BODY"].ToString();
                string displayname = ds.Tables[1].Rows[i]["FROMNM"].ToString();
                int filecount = Int32.Parse(ds.Tables[1].Rows[i]["FILECOUNT"].ToString());
                string filepath = "";
                string filename = "";
                if(filecount > 0)
                {
                    filepath = ds.Tables[1].Rows[i]["FILEPATH"].ToString();
                    string[] filenameArr = filename.Split('»');
                    foreach(string fnarr in filenameArr)
                    {
                        string[] fnarrsplit = fnarr.Split('/');
                        filename += (fnarrsplit[fnarrsplit.Length - 1] + "»");
                    }
                    filename = filename.Substring(0, filename.Length - 2);
                }

                if (Send(fromid, frompw, host, port, toid, cc, bcc, title, body, filepath, filename, displayname))
                {
                    ItsMaria maria2 = new ItsMaria("COMMAILAGENT", "SENDSUCC");
                    maria2.AddParam("EMPCD", EMPCD);
                    maria2.AddParam("MAILID", MAILKEY);
                    maria2.AddParam("MAILTP", MAILTP);
                    DataSet ds2 = maria2.CallProc();
                    if (maria2.IsError)
                    {
                        logtext = "Time : " + DateTime.Now + " Error : maria error(SENDSUCC) / mess : " + maria2.ErrMessage;
                        System.IO.File.AppendAllText(logpath, logtext + Environment.NewLine, Encoding.Default);
                        continue;
                    }
                    sendsucc++;
                }
            }
            if (sendsucc != ds.Tables[1].Rows.Count)
            {
                logtext = "Time : " + DateTime.Now + " MISSING SEND " + (ds.Tables[1].Rows.Count - sendsucc);
                System.IO.File.AppendAllText(logpath, logtext + Environment.NewLine, Encoding.Default);
            }


        }
        catch
        {
            logtext = "Time : " + DateTime.Now + " Error : Mail Server Connect Fail\n\n";
            System.IO.File.AppendAllText(logpath, logtext + Environment.NewLine, Encoding.Default);
            return;
        }
        logtext = "Time : " + DateTime.Now + " Success\n\n";
        System.IO.File.AppendAllText(logpath, logtext + Environment.NewLine, Encoding.Default);
        return;
    }
    public static Boolean Delete(Imap4Client imap, string mailid, string mailpw, int uid, string mailtp)
    {
        var mailAddress = mailid;
        var mailPassword = mailpw;

        try
        {
            imap.Login(mailAddress, mailPassword);              // 메일서버에 로그인

            string mailbox = "inbox";
            if (mailtp == "S01") mailbox = "sent";
            Mailbox inbox = imap.SelectMailbox(mailbox);

            inbox.UidDeleteMessage(uid, false);

            ItsMaria maria = new ItsMaria("COMMAILAGENT", "MAILDELETE");
            maria.AddParam("MAILADDR", mailid);
            maria.AddParam("MAILID", uid);
            maria.AddParam("MAILTP", mailtp);
            DataSet ds = maria.CallProc();
            if (maria.IsError)
            {
                logtext = "Time : " + DateTime.Now + " Id : " + mailid + " UID : " + uid + " MAILTP : " + mailtp + " Error : maria error(MAILDELETE), IMAP4 OK / mess : " + maria.ErrMessage + "\n\n";
                System.IO.File.AppendAllText(logpath, logtext + Environment.NewLine, Encoding.Default);
            }

            return true;
        }
        catch (Imap4Exception iex)
        {
            logtext = "Time : " + DateTime.Now + " Id : " + mailid + " Imap4Exception : " + iex.Message + "\n\n";
            System.IO.File.AppendAllText(logpath, logtext + Environment.NewLine, Encoding.Default);
            return false;
        }
        catch (Exception ex)
        {
            logtext = "Time : " + DateTime.Now + " Id : " + mailid + " Error : " + ex.Message + "\n\n";
            System.IO.File.AppendAllText(logpath, logtext + Environment.NewLine, Encoding.Default);
            return false;
        }
    }
    public static bool Send(string fromid, string frompw, string host, int port, string toid, string cc, string bcc,
                           string title, string body, string filepath, string filename, string displayname)
    {
        MailMessage mail = new MailMessage();
        mail.From = new MailAddress(fromid, displayname);
        mail.To.Add(toid);
        if (cc != "" && cc != null)
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
                    attachment = new System.Net.Mail.Attachment(FilePath.Replace("\\","/") + filepathArr[i]);
                    attachment.Name = filenameArr[i];
                    mail.Attachments.Add(attachment);
                }

            }
            catch (Exception ex)
            {
                System.Net.Mail.Attachment attachment;
                attachment = new System.Net.Mail.Attachment(FilePath.Replace("\\", "/") + filepath);
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
            mail.Dispose();
            return true;
        }
        catch (System.Net.Mail.SmtpException ex)
        {
            return false;
        }
    }

}