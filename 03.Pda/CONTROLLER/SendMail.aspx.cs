using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Text;
using System.Net;
using System.Net.Mail;

public partial class SendMail : BasePage
{
    public string SENDSTAT = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        string fromid = Request["fromaddr"];
        string frompw = Request["frompw"];
        string host = Request["host"];
        int port = Convert.ToInt32(Request["port"]);
        string toid = Request["toid"];
        string title = Request["title"];
        string body = Request["body"];
        string filepath = Server.MapPath(".") + "/../" + Request["filepath"];
        string filename = Request["filename"];
        string displayname = "미플 메일 서비스";
        if (Request["displayname"] != "" || Request["displayname"] != null)
        {
            displayname = Request["displayname"];
        }

        Mail_Send(fromid, frompw, host, port, toid, title, body, filepath, filename, displayname);
        //Mail_Send2();
        //Mail_Send3(fromid, frompw, host, port, toid, title, body, filepath, filename, displayname);
    }

    public void Mail_Send(string fromid, string frompw, string host, int port, string toid,
                           string title, string body, string filepath, string filename, string displayname)
    {
        MailMessage mail = new MailMessage();
        mail.From = new MailAddress(fromid, displayname);
        mail.To.Add(toid);
        mail.Subject = title;
        mail.Body = body;

        
        if (filename != "" && filename != null)
        {
            System.Net.Mail.Attachment attachment;
            attachment = new System.Net.Mail.Attachment(filepath);
            attachment.Name = filename;
            mail.Attachments.Add(attachment);
        }
        mail.IsBodyHtml = true;

        SmtpClient smtp = new SmtpClient();
        smtp.Host = host;
        smtp.Port = port;

        try
        {
            smtp.Send(mail);
            SENDSTAT = "TITLE:" + title + "»TOID:" + toid + "»SENDYN:Y";
        }
        catch (SmtpException ex)
        {
            SENDSTAT = "TITLE:" + title + "»TOID:" + toid + "»SENDYN:N";
        }
    }
    //네이버
    public void Mail_Send2()
    {
        const string SMTP_SERVER = "smtp.naver.com"; // SMTP 서버 주소
        const int SMTP_PORT = 587; // SMTP 포트

        const string MAIL_ID = "zzip2595@naver.com"; // 보내는 사람의 이메일
        const string MAIL_ID_NAME = "test"; // 보내는사람 계정 ( 네이버 로그인 아이디 ) 
        const string MAIL_PW = "sniper14!";  // 보내는사람 패스워드 ( 네이버 로그인 패스워드 )
        const string TO_ID = "zzip2595@gmail.com";


        try
        {
            MailAddress mailFrom = new MailAddress(MAIL_ID, MAIL_ID_NAME, Encoding.UTF8); // 보내는사람의 정보를 생성
            MailAddress mailTo = new MailAddress(TO_ID); // 받는사람의 정보를 생성
            SmtpClient client = new SmtpClient(SMTP_SERVER, SMTP_PORT); // smtp 서버 정보를 생성
            MailMessage message = new MailMessage(mailFrom, mailTo);

            message.Subject = "CSDP000 테스트"; // 메일 제목 프로퍼티
            message.Body = "반갑습니다"; // 메일의 몸체 메세지 프로퍼티
            message.BodyEncoding = Encoding.UTF8; // 메세지 인코딩 형식
            message.SubjectEncoding = Encoding.UTF8; // 제목 인코딩 형식

            client.EnableSsl = true; // SSL 사용 유무 (네이버는 SSL을 사용합니다. )
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.Credentials = new System.Net.NetworkCredential(MAIL_ID, MAIL_PW); // 보안인증 ( 로그인 )
            client.Send(message);  //메일 전송 

        }

        catch (Exception ex)
        {

        }
    }
    //google
    public void Mail_Send3(string fromid, string frompw, string host, int port, string toid,
                           string title, string body, string filepath, string filename, string displayname)
    {
        const string SMTP_SERVER = "smtp.gmail.com"; // SMTP 서버 주소
        const int SMTP_PORT = 587; // SMTP 포트

        SmtpClient client = new SmtpClient(host, port);
        // 먼저 stmpclient 클래스를 이용하여 객체를 하나 만든다.
        // 객체를 만들때에는 자신의 원하는 메일의 host 주소와 포트번호가 필요하다

        client.UseDefaultCredentials = false;
        // 시스템에 설정된 인증 정보를 사용하지 않는다.
        client.EnableSsl = true;
        // SSL을 사용한다.
        client.DeliveryMethod = SmtpDeliveryMethod.Network;
        // 이걸 하지 않으면 Gmail에 인증을 받지 못한다.
        client.Credentials = new System.Net.NetworkCredential(fromid, frompw);
        // gmail 계정주소와 비밀번호를 입력하여 보낸 사람의 인증 설정을 한다.

        MailAddress from = new MailAddress(fromid, displayname, System.Text.Encoding.UTF8);
        // 보낸 사용자의 gmail 계정주소와 이름을 넣고 MailAddress 객체를 생성한다.
        MailAddress to = new MailAddress(toid);
        // 받는 사용자의 gmail 계정주소를 넣고 MailAddress 객체를 생성한다.

        MailMessage message = new MailMessage(from, to);
        // 메일을 생성한다.
        message.Subject = title;
        message.Body = body;
        message.SubjectEncoding = System.Text.Encoding.UTF8;
        message.BodyEncoding = System.Text.Encoding.UTF8;
        // 제목과 내용을 모두 UTF8로 인코딩 설정을 한다.

        try
        {
            // 동기로 메일을 보낸다.
            client.Send(message);
            // Clean up.
            message.Dispose();
        }
        catch (Exception ex)
        {

        }
        
    }
}