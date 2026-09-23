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

public partial class FileUpload : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string FILEKEY = "";
        string BASEPATH = Server.MapPath(".") + "\\..";
        string centerYn = Request["centerYn"];
        string WAITSTT = "N";
        string SAVETYPE = "";
        string NEWNMYN = Request["NEWNMYN"];       // "F" : 키값으로 파일명, "Y" : 신규 파일명, "N" : 기존 파일명
        string NEWNM = "";
        string dbName = GetSession("SESSION_DBNAME");
        string FILEPATH = "/UploadFiles/" + dbName;

        if (NEWNMYN == "Y") NEWNM = Request["NEWNM"].ToString();

        try
        {
            WAITSTT = Request["WAITSTT"];
        } catch
        {
            WAITSTT = "N";
        }

        //저장 타입(위치) 2021-10-27 왕현준 ( "" : UploadFiles에 저장, "manual" : Manual 폴더에 저장 )
        try
        {
            SAVETYPE = Request["SAVETYPE"].ToString().ToLower();
        }
        catch
        {
            SAVETYPE = "";
        }

        // 처리 구분 UPLOAD 파일 업로드, DELETE 파일 삭제
        string CALLTYPE = "UPLOAD";
        try
        {
            CALLTYPE = Request["CALLTYPE"].ToString();
        }
        catch { }

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

            DataSet dsDelete = null;

            // COMFILE 테이블 파일 정보 지우기
            ItsMaria maria = new ItsMaria("COMFILE", "DELETE");
            maria.AddParam("FILEKEY", FILEKEY);
            if (centerYn == "Y")
            {
                dsDelete = maria.CallProc(maria.ConnString, 120);
            }
            else
            {
                dsDelete = maria.CallProc(this.ConnStringCust, 120);
            }

            // 실제 파일 지우기
            string localPath = BASEPATH + dsDelete.Tables[0].Rows[0][0].ToString().Replace("/", "\\");
            // Response.Write(localPath);
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
            DataSet dsUpload = null;
            ItsMaria maria = new ItsMaria("COMFILE", "NEWKEY");
            if (centerYn == "Y")
            {
                dsUpload = maria.CallProc(maria.ConnString, 120);
            }
            else
            {
                dsUpload = maria.CallProc(this.ConnStringCust, 120);
            }

            FILEKEY = dsUpload.Tables[0].Rows[0][0].ToString();
            if (FILEKEY == "_ERR_")
            {
                Response.Write("ERROR: " + dsUpload.Tables[0].Rows[0][1].ToString() + " query : " + maria.ToString());
                return;
            }
            else
            {
                // 업로드 경로 설정
                
                if (dbName == "")
                { // 세션이 없을경우
                    Response.Write("ERROR: 세션 만료");
                    return;
                }
                string uploadPath = BASEPATH + "\\UploadFiles\\" + dbName;
                //메뉴얼이면 위치 변경
                if (SAVETYPE == "manual")
                {
                    uploadPath = BASEPATH + "\\Manual";
                    FILEPATH = "/Manual";
                }

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
                int FILESIZE = 0;
                try
                {
                    HttpPostedFile file = Request.Files[0];
                    FILEBYTE = new byte[file.ContentLength];
                    FILESIZE = FILEBYTE.Length;
                    file.InputStream.Read(FILEBYTE, 0, FILESIZE);
                }
                catch { }
                // 파일 업로드
                string[] imgExtList = new string[] { ".png", ".jpg", ".jpeg", ".bmp" };

                string localPath = "";
                if (NEWNMYN == "Y")
                {
                    //메뉴얼이면 바로 저장
                    if (SAVETYPE == "manual")
                    {
                        FILEPATH = FILEPATH + "/" + NEWNM + FILEEXT;
                        localPath = uploadPath + "\\" + NEWNM + FILEEXT;
                    }
                    else
                    {
                        FILEPATH = FILEPATH + "/" + FILEKEY.Substring(0, 4) + "/" + NEWNM + FILEEXT;
                        localPath = monthPath + "\\" + NEWNM + FILEEXT;
                    }
                }
                else if (NEWNMYN == "N")
                {
                    FILEPATH = FILEPATH + "/" + FILEKEY.Substring(0, 4) + "/" + FILENAME;
                    localPath = monthPath + "\\" + FILENAME;
                }
                else
                {
                    FILEPATH = FILEPATH + "/" + FILEKEY.Substring(0, 4) + "/" + FILEKEY + FILEEXT;
                    localPath = monthPath + "\\" + FILEKEY + FILEEXT;
                }

                System.IO.File.WriteAllBytes(localPath, FILEBYTE);

                //string[] fileExtList = new string[] { ".png", ".jpg", ".jpeg", ".gif", ".pdf", ".bmp", ".doc", ".docx", ".xls", ".xlsx", ".ppt", ".pptx", ".hwp" };
                //if (fileExtList.Contains<string>(FILEEXT)) // IIS 다운로드 허용 파일 형식일 경우
                //{
                //    string localPath = "";
                //    if (NEWNMYN == "Y")
                //    {
                //        FILEPATH = "/UploadFiles/" + dbName + "/" + FILEKEY.Substring(0, 4) + "/" + NEWNM + FILEEXT;
                //        localPath = monthPath + "\\" + NEWNM + FILEEXT;
                //    }
                //    else if (NEWNMYN == "N")
                //    {
                //        FILEPATH = "/UploadFiles/" + dbName + "/" + FILEKEY.Substring(0, 4) + "/" + FILENAME;
                //        localPath = monthPath + "\\" + FILENAME;
                //    }
                //    else
                //    {
                //        FILEPATH = "/UploadFiles/" + dbName + "/" + FILEKEY.Substring(0, 4) + "/" + FILEKEY + FILEEXT;
                //        localPath = monthPath + "\\" + FILEKEY + FILEEXT;
                //    }

                //    System.IO.File.WriteAllBytes(localPath, FILEBYTE);

                //    // 이미지 형식일 경우 사이즈 600 이상으로 조정
                //    //if (imgExtList.Contains<string>(FILEEXT))
                //    //{
                //    //    System.Drawing.Image originalImage = System.Drawing.Image.FromFile(localPath);
                //    //    if ((double)originalImage.Width < 600 && (double)originalImage.Height < 600)
                //    //    {
                //    //        double ratioX = 600 / (double)originalImage.Width;
                //    //        double ratioY = 600 / (double)originalImage.Height;

                //    //        double ratio = Math.Min(ratioX, ratioY);

                //    //        int newWidth = (int)(originalImage.Width * ratio);
                //    //        int newHeight = (int)(originalImage.Height * ratio);

                //    //        Bitmap newImage = new Bitmap(newWidth, newHeight);
                //    //        //Bitmap newImage = new Bitmap(600, 600);
                //    //        using (Graphics g = Graphics.FromImage(newImage))
                //    //        {
                //    //            g.FillRectangle(Brushes.Transparent, 0, 0, newImage.Width, newImage.Height);
                //    //            g.DrawImage(originalImage, 0, 0, newWidth, newHeight);
                //    //            //g.DrawImage(originalImage, (600 - newWidth) / 2, (600 - newHeight) / 2, newWidth, newHeight);
                //    //        }

                //    //        originalImage.Dispose();
                //    //        newImage.Save(localPath);
                //    //        newImage.Dispose();
                //    //    }
                //    //}
                //}
                //else
                //{
                //    FILEPATH = "/UploadFiles/" + dbName + "/" + FILEKEY.Substring(0, 4) + "/" + FILEKEY + FILEEXT + ".zip";

                //    string localPath = monthPath + "\\" + FILEKEY + FILEEXT + ".zip";
                //    System.IO.File.WriteAllBytes(localPath, FILEBYTE);
                //}

                // COMFILE 레코드 추가
                maria = new ItsMaria("COMFILE", "ADD");
                maria.AddParam("FILEKEY", FILEKEY);
                if (NEWNMYN == "Y")
                {
                    maria.AddParam("FILENAME", NEWNM + FILEEXT);
                }
                else
                {
                    maria.AddParam("FILENAME", FILENAME);
                }
                maria.AddParam("FILEEXT", FILEEXT);
                maria.AddParam("FILESIZE", FILESIZE);
                maria.AddParam("FILEPATH", FILEPATH);
                maria.AddParam("LOCATION", "ERP");

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
            }
        }

        Response.Write(FILEKEY);
    }
}