using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using System.Net;
using System.IO;
using System.Text;
using Newtonsoft.Json.Linq;
using com.baroservice.ws;

public partial class AttachFileByFTP : BasePage
{
    /* Request
     * - CUST : 업체간략 (예 ERP_JY )
     * - PATH : FTP 올릴 로컬 주소
     * - CorpNum : 바로빌 회원 사업자번호 ('-' 제외, 10자리)
     * - MgtKey : 연동사부여 문서키
     * - DisplayFileName : 다운로드시 보여질 파일명
     */
    protected void Page_Load(object sender, EventArgs e)
    {
        //BaroBill FTP에 파일 등록 및 연결
        string CUST = Request["CUST"].ToString();
        string DirectoryPath = "ftp://testftp.barobill.co.kr:9031/"+ CUST;
        string userID = "itscomipl";
        string password = "its1005!";

        if (!IsExistDirectory(DirectoryPath, userID, password))
        {
            if(!MakeDirectory(DirectoryPath, userID, password))
            {
                Response.Write("ERROR: FTP 접속 실패");
                Response.End();
                return;
            }
        }

        string fileNM = Request["CUST"].ToString();
        string targetFileURI = Request["PATH"].ToString().Replace('/','\\');
        string sourceFilePath = DirectoryPath + "/" + fileNM;
        string responseStr = "";

        if (UploadFTPFile(sourceFilePath, targetFileURI, userID, password))
        {
            BaroService_TI BS_TI = new BaroService_TI();

            string CERTKEY = GetSession("SESSION_BILLCERTKEY");        //인증키
            string CorpNum = Request["CorpNum"].ToString();                 //바로빌 회원 사업자번호 ('-' 제외, 10자리)
            string MgtKey = Request["MgtKey"].ToString();                   //연동사부여 문서키
            string FileName = CUST + "/" + fileNM;                          //첨부할 파일명
            string DisplayFileName = Request["DisplayFileName"].ToString(); //다운로드시 보여질 파일명

            int Result = BS_TI.AttachFileByFTP(CERTKEY, CorpNum, MgtKey, FileName, DisplayFileName);

            if (Result == 1)
            {
                responseStr = "정상 처리되었습니다.";
            }
            else
            {
                responseStr = "ERROR: " + BS_TI.GetErrString(CERTKEY, Result);
            }
        }
        else
        {
            responseStr = "ERROR: 파일 등록 실패";
        }
        

        Response.Write(responseStr);
        Response.End();
    }

    private bool UploadFTPFile(string sourceFilePath, string targetFileURI, string userID, string password)
    {
        try
        {
            Uri targetFileUri = new Uri(targetFileURI);
            FtpWebRequest ftpWebRequest = WebRequest.Create(targetFileUri) as FtpWebRequest;
            ftpWebRequest.Credentials = new NetworkCredential(userID, password);
            ftpWebRequest.Method = WebRequestMethods.Ftp.UploadFile;
            FileStream sourceFileStream = new FileStream(sourceFilePath, FileMode.Open, FileAccess.Read);
            Stream targetStream = ftpWebRequest.GetRequestStream();

            byte[] bufferByteArray = new byte[1024];

            while (true)
            {
                int byteCount = sourceFileStream.Read(bufferByteArray, 0, bufferByteArray.Length);

                if (byteCount == 0)
                {
                    break;
                }
                targetStream.Write(bufferByteArray, 0, byteCount);
            }
            targetStream.Close();
            sourceFileStream.Close();
        }
        catch
        {
            return false;
        }
        return true;
    }

    private bool IsExistDirectory(string DirectoryPath, string userID, string password)
    {
        try
        {
            var request = (FtpWebRequest)WebRequest.Create(DirectoryPath);
            request.Method = WebRequestMethods.Ftp.ListDirectory;
            request.Credentials = new NetworkCredential(userID, password); 
         using (request.GetResponse())
            {
                return true;
            }
        }
        catch (WebException)
        {
            return false;
        }
    }

    private bool MakeDirectory(string DirectoryPath, string userID, string password)
    {
        string URI = DirectoryPath;
        System.Net.FtpWebRequest ftp = WebRequest.Create(new Uri(URI)) as FtpWebRequest;
        ftp.Credentials = new NetworkCredential(userID, password);
        ftp.UseBinary = true;
        ftp.UsePassive = true;
        ftp.Timeout = 10000;
        ftp.Method = System.Net.WebRequestMethods.Ftp.MakeDirectory;             
        
       try
        {
            string str = GetStringResponse(ftp);
        }
        catch
        {
            return false;
        }
        return true;
    }

    private string GetStringResponse(FtpWebRequest ftp)
    {
        string result = "";
        using (FtpWebResponse response = (FtpWebResponse)ftp.GetResponse())
        {
            long size = response.ContentLength;
            using (Stream datastream = response.GetResponseStream())
            {
                if (datastream != null)
                {
                    using (StreamReader sr = new StreamReader(datastream))
                    {
                        result = sr.ReadToEnd();
                        sr.Close();
                    }
                    datastream.Close();
                }
            }
            response.Close();
        }
        return result;
    }

}