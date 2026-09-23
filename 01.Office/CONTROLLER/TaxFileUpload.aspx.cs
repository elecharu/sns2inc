using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
using System.Text;
using System.Web.Script.Serialization;
using System.Drawing;

public partial class TaxFileUpload : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string FILEKEY = "";
        string BASEPATH = Server.MapPath(".") + "\\..";
        string FAXBASEPATH = Server.MapPath(".") + "\\..";
        BASEPATH = BASEPATH.Substring(0, 2);
        string centerYn = Request["centerYn"];
        string TYPE = Request["TYPE"];
        string WAITSTT = "N";

        if (TYPE == "Fax")
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


            
           
            FILEKEY = "USERFAXFILE";
            // 업로드 경로 설정
            string dbName = GetSession("SESSION_DBNAME");
            if (dbName == "")
            { // 세션이 없을경우
                Response.Write("ERROR: 세션 만료");
                return;
            }
            string uploadPath = FAXBASEPATH + "\\UploadFiles\\" + dbName;
            if (!System.IO.Directory.Exists(uploadPath))
            {
                System.IO.Directory.CreateDirectory(uploadPath);
            }
            string monthPath = uploadPath + "\\USERFAXFILE";
            if (!System.IO.Directory.Exists(monthPath))
            {
                System.IO.Directory.CreateDirectory(monthPath);
            }

            // 파일 데이터 읽기
            byte[] FILEBYTE = null;
            int FILESIZE = 0;
            // 파일 업로드
            string FILEPATH = "";
            string[] imgExtList = new string[] { ".png", ".jpg", ".jpeg", ".bmp" };
            string[] fileExtList = new string[] { ".tif", ".tiff", ".csv", ".htm", ".html", ".gul",
                                                      ".txt", ".jpg", ".jpeg", ".gif", ".pdf", ".bmp",
                                                      ".doc", ".docx", ".xls", ".xlsx", ".ppt", ".pptx", ".hwp" };
            if (fileExtList.Contains<string>(FILEEXT)) // IIS 다운로드 허용 파일 형식일 경우
            {
                FILEPATH = "/UploadFiles/" + dbName + "/USERFAXFILE/" + FILEKEY + FILEEXT;

                string localPath = monthPath + "\\" + FILEKEY + FILEEXT;
                try
                {
                    HttpPostedFile file = Request.Files[0];
                    FILEBYTE = new byte[file.ContentLength];
                    FILESIZE = FILEBYTE.Length;
                    file.InputStream.Read(FILEBYTE, 0, FILESIZE);
                    // 실제 파일 지우기
                    System.IO.File.Delete(localPath);
                    // 파일 업로드
                    System.IO.File.WriteAllBytes(localPath, FILEBYTE);

                    Response.Write("파일 업로드 성공. File:");

                }
                catch
                {
                    Response.Write("파일 업로드 실패. File:");
                }

                // 이미지 형식일 경우 사이즈 600 이상으로 조정
                if (imgExtList.Contains<string>(FILEEXT))
                {
                    System.Drawing.Image originalImage = System.Drawing.Image.FromFile(localPath);
                    if ((double)originalImage.Width < 600 || (double)originalImage.Height < 600)
                    {
                        double ratioX = 600 / (double)originalImage.Width;
                        double ratioY = 600 / (double)originalImage.Height;

                        double ratio = Math.Min(ratioX, ratioY);

                        int newWidth = (int)(originalImage.Width * ratio);
                        int newHeight = (int)(originalImage.Height * ratio);

                        Bitmap newImage = new Bitmap(newWidth, newHeight);
                        //Bitmap newImage = new Bitmap(600, 600);
                        using (Graphics g = Graphics.FromImage(newImage))
                        {
                            g.FillRectangle(Brushes.Transparent, 0, 0, newImage.Width, newImage.Height);
                            g.DrawImage(originalImage, 0, 0, newWidth, newHeight);
                            //g.DrawImage(originalImage, (600 - newWidth) / 2, (600 - newHeight) / 2, newWidth, newHeight);
                        }

                        originalImage.Dispose();
                        newImage.Save(localPath);
                        newImage.Dispose();
                    }
                }
            }
            else
            {
                Response.Write("ERROR: FAX 확장자가 아닙니다.");
                return;
            }

            // COMFILE 레코드 추가
            var maria = new ItsMaria("COMFILE", "ADD");
            maria.AddParam("FILEKEY", FILEKEY);
            maria.AddParam("FILENAME", FILEKEY + FILEEXT);
            maria.AddParam("FILEEXT", FILEEXT);
            maria.AddParam("FILESIZE", FILESIZE);
            maria.AddParam("FILEPATH", FILEPATH);
            maria.AddParam("WAITSTT", WAITSTT);

            DataSet dsUpload2 = null;
            if (centerYn == "Y")
            {
                dsUpload2 = maria.CallProc(maria.ConnString, 120);
            }
            else
            {
                dsUpload2 = maria.CallProc(this.ConnStringCust, 120);
            }

            if (dsUpload2.Tables[0].Rows[0][0].ToString() == "_ERR_")
            {
                Response.Write("ERROR: " + dsUpload2.Tables[0].Rows[0][1].ToString() + " query : " + maria.ToString());
                return;
            }
            //string[] fileExtList = new string[] { ".tif", ".tiff", ".csv", ".htm", ".html", ".gul",
            //                                      ".txt", ".jpg", ".jpeg", ".gif", ".pdf", ".bmp",
            //                                      ".doc", ".docx", ".xls", ".xlsx", ".ppt", ".pptx", ".hwp" };
            //if (fileExtList.Contains<string>(FILEEXT)) // LGU 팩스 발송 첨부 파일 확장자
            //{

            //}
            //else
            //{
            //    Response.Write("ERROR: FAX 확장자가 아닙니다.");
            //    return;
            //}

            //ItsMaria maria = new ItsMaria("COMFILE", "MAKE_FILENAME");

            //DataSet ds = maria.CallProc(ConnStringCust, 120);
            //if (maria.IsError)
            //{
            //    return;
            //}

            //string uploadPath = ds.Tables[0].Rows[0]["FAXPATH"].ToString();
            ////string uploadPath = "D:\\test";

            ////파일명 생성
            //string targetFile = ds.Tables[0].Rows[0]["FILE_NAME"].ToString() + FILEEXT;

            //string localPath = System.IO.Path.Combine(uploadPath, targetFile);

            //if (!System.IO.Directory.Exists(uploadPath))
            //{
            //    System.IO.Directory.CreateDirectory(uploadPath);
            //}

            //// 파일 데이터 읽기
            //byte[] FILEBYTE = null;
            //int FILESIZE = 0;
            //try
            //{
            //    HttpPostedFile file = Request.Files[0];
            //    FILEBYTE = new byte[file.ContentLength];
            //    FILESIZE = FILEBYTE.Length;
            //    file.InputStream.Read(FILEBYTE, 0, FILESIZE);
            //    // 실제 파일 지우기
            //    System.IO.File.Delete(localPath);
            //    // 파일 업로드
            //    System.IO.File.WriteAllBytes(localPath, FILEBYTE);

            //    Response.Write("파일 업로드 성공. File:");

            //}
            //catch {
            //    Response.Write("파일 업로드 실패. File:");
            //}




            Response.Write(FILEKEY + FILEEXT);
            Response.Write("File:");
            Response.Write(FILEPATH);
        }
        else
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


            if (TYPE == "Tax")
            {
                if (FILEEXT != ".key" && FILEEXT != ".der")
                {
                    Response.Write("ERROR: 인증서 확장자가 아닙니다.");
                    return;

                }
                else if (FILEEXT == ".key")
                {
                    FILEKEY = "signPri";
                }
                else if (FILEEXT == ".der")
                {
                    FILEKEY = "signCert";
                }
            }
            else if (TYPE == "Key")
            {
                if (FILEEXT == ".key")
                {
                    FILEKEY = "signPri";
                }
                else
                {
                    Response.Write("ERROR: 인증서 확장자가 아닙니다.");
                    return;
                }
            }
            else if (TYPE == "Der")
            {
                if (FILEEXT == ".der")
                {
                    FILEKEY = "signCert";
                }
                else
                {
                    Response.Write("ERROR: 인증서 확장자가 아닙니다.");
                    return;
                }
            }


            ItsMaria maria = new ItsMaria("COMFILE", "COMPREGNO");

            DataSet dsUpload = null;
            if (centerYn == "Y")
            {
                dsUpload = maria.CallProc(maria.ConnString, 120);
            }
            else
            {
                dsUpload = maria.CallProc(this.ConnStringCust, 120);
            }
            string compregno = dsUpload.Tables[0].Rows[0][0].ToString();

            if (compregno == "_ERR_")
            {
                Response.Write("ERROR: " + dsUpload.Tables[0].Rows[0][1].ToString() + " query : " + maria.ToString());
                return;
            }


            string uploadPath = BASEPATH + "\\WEBTAXAGENT\\NPKI\\" + compregno;
            if (!System.IO.Directory.Exists(uploadPath))
            {
                System.IO.Directory.CreateDirectory(uploadPath);
            }


            // 파일 데이터 읽기
            byte[] FILEBYTE = null;
            int FILESIZE = 0;
            try
            {
                HttpPostedFile file = Request.Files[0];
                FILEBYTE = new byte[file.ContentLength];
                FILESIZE = FILEBYTE.Length;
                file.InputStream.Read(FILEBYTE, 0, FILESIZE);
            }
            catch { }

            string localPath = uploadPath + "\\" + FILEKEY + FILEEXT;

            // 실제 파일 지우기
            System.IO.File.Delete(localPath);
            // 파일 업로드
            System.IO.File.WriteAllBytes(localPath, FILEBYTE);

            Response.Write("파일 업로드 성공. File:");
            Response.Write(FILEKEY);
        }
    }
}