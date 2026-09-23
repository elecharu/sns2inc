using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class FaxFileCopy : BasePage
{
    public string PATH = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        string filePath = Server.MapPath(".").Substring(0,27) + "\\" + Request["FilePath"];
        Copy_PDF(filePath);

    }

    public void Copy_PDF(string oldPath) 
    {
        var type = oldPath.Split('.');
        var FILETYPE = type[type.Length - 1];        

        string[] fileExtList = new string[] { "tif", "tiff", "csv", "htm", "html", "gul",
                                                      "txt", "jpg", "jpeg", "gif", "pdf", "bmp",
                                                      "doc", "docx", "xls", "xlsx", "ppt", "pptx", "hwp" };

        if (fileExtList.Contains<string>(FILETYPE))
        {
            string sourceFile = System.IO.Path.Combine(oldPath);

            ItsMaria maria = new ItsMaria("COMFILE", "MAKE_FILENAME");

            DataSet ds = maria.CallProc(ConnStringCust, 120);
            if (maria.IsError)
            {
                return;
            }

            string newPath = ds.Tables[0].Rows[0]["FAXPATH"].ToString();
            //string newPath = "D:\\test";

            //파일명 생성
            string targetFile = ds.Tables[0].Rows[0]["FILE_NAME"].ToString() + "." + FILETYPE;

            string destFile = System.IO.Path.Combine(newPath, targetFile);

            if (!System.IO.Directory.Exists(newPath))
            {
                System.IO.Directory.CreateDirectory(newPath);
            }
            System.IO.File.Copy(sourceFile, destFile, true);
            PATH = destFile;
        }

        //다중 복사
        //if (System.IO.Directory.Exists(sourceFile))
        //{
        //    string[] files = System.IO.Directory.GetFiles(sourceFile);

        //    foreach(string s in files)
        //    {
        //        destFile = System.IO.Path.Combine(destFile, targetFile);
        //        System.IO.File.Copy(s, destFile, true);
        //    }
        //}
        //else
        //{
        //    Console.WriteLine("Source path does not exist!");
        //}


    }
}