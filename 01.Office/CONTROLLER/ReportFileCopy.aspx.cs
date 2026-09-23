using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ReportFileCopy : BasePage
{
    public string PATH = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        string[] splitName;
        splitName = Request["FILENAME"].Split('.');
        string fileName = splitName[0];
        string fileType = "." + splitName[splitName.Length - 1];
        string filePath = Server.MapPath(".") + "\\..\\Reports\\tempFiles\\" + fileName + fileType;
        Copy_PDF(filePath, fileName, fileType);
    }

    public void Copy_PDF(string oldPath, string fileName, string fileType) 
    {
        string sourceFile = System.IO.Path.Combine(oldPath);

        string newPath = Server.MapPath(".") + "\\..\\Reports\\saveFiles\\" + DateTime.Now.ToString("yyyy.MM.dd");
        //string newPath = "D:\\test";

        //파일명 생성
        string targetFile = fileName + fileType;

        string destFile = System.IO.Path.Combine(newPath, targetFile);

        if (!System.IO.Directory.Exists(newPath))
        {
            System.IO.Directory.CreateDirectory(newPath);
        }
        System.IO.File.Copy(sourceFile, destFile, true);
        PATH = DateTime.Now.ToString("yyyy.MM.dd")+"/"+ targetFile;

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