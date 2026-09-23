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

public class Program
{
    static string mydoc = System.Environment.CurrentDirectory;
    //static string mydoc2 = AppDomain.CurrentDomain.BaseDirectory;

    static string logpath = mydoc + @"\Log\AgentLog.txt";
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
    public static void Main(string[] args)
    {
        DirectoryInfo folder = new DirectoryInfo(mydoc + @"\Log");
        if (folder.Exists == false) folder.Create();
        Console.Write("MAIL Agent Start ");
        for (int i = 0; i < args.Length; i++)
        {
            Console.Write(args[i].ToString()+" ");
        }
        Console.WriteLine();

        try
        {
            if (args.Length > 1)
            {
                string ID = args[0].ToString();
                string Domain = args[1].ToString();
                try
                {
                    ItsMaria maria = new ItsMaria("COMMAILAGENT", "ADDRINFO");
                    maria.AddParam("MAILADDR", ID + "@" + Domain);
                    DataSet ds = maria.CallProc();
                    if (maria.IsError)
                    {
                        logtext = "0. Time : " + DateTime.Now + " id : " + ID + "@" + Domain + " Error : maria error(ADDRINFO)\n\n mess : " + maria.ErrMessage + "\n\n";
                        System.IO.File.AppendAllText(logpath, logtext + Environment.NewLine, Encoding.Default);
                        return;
                    }

                    DataSet rds = new DataSet();
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        rds.Merge(IMAP_Agent(ds.Tables[0].Rows[i]["EMPCD"].ToString(), ds.Tables[0].Rows[i]["MAILID"].ToString(), ds.Tables[0].Rows[i]["MAILPW"].ToString()));
                    }
                }
                catch (Exception ex)
                {
                    logtext = "2. Time : " + DateTime.Now + " id : " + ID + "@" + Domain + " Error : Mail Server Connect Fail\n\n";
                    System.IO.File.AppendAllText(logpath, logtext + Environment.NewLine, Encoding.Default);
                    return;
                }
                logtext = "2. Time : " + DateTime.Now + " id : " + ID + "@" + Domain + " Success\n\n";
                System.IO.File.AppendAllText(logpath, logtext + Environment.NewLine, Encoding.Default);
            }
            else
            {
                logtext = "2. Time : " + DateTime.Now + " Error : Not Mail File\n\n";
                System.IO.File.AppendAllText(logpath, logtext + Environment.NewLine, Encoding.Default);
            }
        }
        catch(Exception ex)
        {
            Console.WriteLine("ERROR : "+ex.Message);
        }

        Console.Write("MAIL Agent END ");
        for (int i = 0; i < args.Length; i++)
        {
            Console.Write(args[i].ToString() + " ");
        }
        Console.WriteLine();
        return;
    }
    private static DataSet IMAP_Agent(string empcd, string mailid, string mailpw)
    {
        DataSet ds = new DataSet();
        try
        {
            Imap4Client imap = new Imap4Client();
            imap.Connect(HOST, Int32.Parse(IMAP));                      // 메일서버 접속 (호스트 수정시 여기)
            imap.Login(mailid, mailpw);                                 // 메일서버에 로그인        

            Mailbox inbox = imap.SelectMailbox("inbox");
            
            int[] unseen = inbox.Search("UNSEEN");                        // 안 읽은 메일 키값
            int[] allid = inbox.Search("ALL UNDELETED");                  // 모든 키값

            if (allid.Length > 0)
            {
                ItsMaria maria = new ItsMaria("COMMAILAGENT", "SETMAIL");
                maria.AddParam("EMPCD", empcd);

                foreach(var id in allid.Reverse())
                {
                    int uid = inbox.Fetch.Uid(id);
                    Message message = inbox.Fetch.UidMessageObject(uid);

                    if (message.Subject == null && (message.BodyHtml.Text == "" || message.BodyText.Text == ""))
                        continue;

                    maria.AddList("MAILID_LIST", uid);
                    maria.AddList("SUBJECT_LIST", message.Subject.Replace("\'", "\'\'"));
                    if (message.From.Email.Contains("@") && message.From.Email.Contains("."))
                    {
                        maria.AddList("FROMADDR_LIST", message.From.Email);
                        maria.AddList("FROMNM_LIST", message.From.Name);
                    }
                    else
                    {
                        maria.AddList("FROMADDR_LIST", message.HeaderFields[0]);
                        maria.AddList("FROMNM_LIST", message.From.Email);
                    }
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
                    if(message.BodyHtml.Text.Replace("\'", "\'\'").Length > 0)
                    {
                        maria.AddList("BODY_LIST", message.BodyHtml.Text.Replace("\'", "\'\'"));
                    }
                    else
                    {
                        maria.AddList("BODY_LIST", message.BodyText.Text.Replace("\'", "\'\'"));
                    }
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
                DataSet dbds = maria.CallProc(maria.ConnString, 300);
                if (maria.IsError)
                {
                    logtext = "1. Time : " + DateTime.Now + " id : " + mailid + " Error : maria error(SETMAIL)\n\n call : " + maria.ErrMessage + "\n\n";
                    System.IO.File.AppendAllText(logpath, logtext + Environment.NewLine, Encoding.Default);
                    return ds;
                }
                else
                {
                    logtext = "1. DB Update success  id : " + mailid + " Total Count : " + allid.Length + "\n\n";
                    System.IO.File.AppendAllText(logpath, logtext + Environment.NewLine, Encoding.Default);
                }
                ds = dbds;
            }

        }
        catch (Imap4Exception iex)
        {
            logtext = "1. Time : " + DateTime.Now + " id : " + mailid + "Imap4 Error: " + iex.Message + "\n";
            System.IO.File.AppendAllText(logpath, logtext + Environment.NewLine, Encoding.Default);
        }
        catch (Exception ex)
        {
            logtext = "1. Time : " + DateTime.Now + " id : " + mailid + "Exception: " + ex.Message + "\n";
            System.IO.File.AppendAllText(logpath, logtext + Environment.NewLine, Encoding.Default);
        }
        return ds;
    }

    private static DataSet IMAPX_Agent(string empcd, string mailid, string mailpw)  //현재 이거 사용
    {
        ImapX.ImapClient imap = new ImapX.ImapClient();
        DataSet ds = new DataSet();

        try
        {
            imap.Connect(HOST, Int32.Parse(IMAP), false); // 메일서버 접속
            imap.Login(mailid, mailpw);               // 메일서버에 로그인   
        }
        catch (Exception ex)
        {
            logtext = "Time : " + DateTime.Now + " id : " + mailid + " Error : ImapX Error\n\n Message : " + ex.Message + "\n\n";
            System.IO.File.AppendAllText(logpath, logtext + Environment.NewLine, Encoding.Default);
            return ds;
        }
        try
        {
            ImapX.Message[] messages = imap.Folders.Inbox.Search("ALL UNDELETED");

            if (messages.Length > 0)
            {
                ItsMaria maria = new ItsMaria("COMMAILAGENT", "SETMAIL");
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
                    if (messages[n].Attachments.Length == 0)
                    {
                        filename = " ";
                    }
                    else
                    {
                        for (int i = 0; i < messages[n].Attachments.Length - 1; i++)
                        {
                            filename += messages[n].Attachments[i].FileName + ",";

                        }

                        filename += messages[n].Attachments[messages[n].Attachments.Length - 1].FileName;
                    }
                    maria.AddList("FILENM_LIST", filename);
                    string body = "";
                    if (messages[n].Body.HasHtml)
                    {
                        try
                        {
                            body = messages[n].Body.Html;
                        }
                        catch (Exception ex)
                        {
                            body = "";
                        }
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
                DataSet dbds = maria.CallProc(maria.ConnString, 300);
                if (maria.IsError)
                {
                    logtext = "Time : " + DateTime.Now + " id : " + mailid + " Error : Maria Error(SETMAIL)\n\n call : " + maria.ErrMessage + "\n\n";
                    System.IO.File.AppendAllText(logpath, logtext + Environment.NewLine, Encoding.Default);
                    return ds;
                }
                ds = dbds;
            }

        }
        catch (Exception ex)
        {
            logtext = "Time : " + DateTime.Now + " id : " + mailid + " Error : ImapX Error\n\n Message : " + ex.Message + "\n\n";
            System.IO.File.AppendAllText(logpath, logtext + Environment.NewLine, Encoding.Default);
            return ds;
        }

        imap.Disconnect();
        return ds;
    }

}