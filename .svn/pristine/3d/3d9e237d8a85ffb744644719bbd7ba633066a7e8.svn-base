using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Windows.Forms;
using System.IO;
using System.Xml;
using System.Runtime.InteropServices;
using Microsoft.Win32;
using System.Drawing;
using System.Data;

/// <summary>
/// RJSOFT: 파일 시스템 관련 Class
/// </summary>
public class ItsFileDialog
{
    /// <summary>
    /// RJSOFT: 파일 정보 클래스
    /// </summary>
    public class FileInfo
    {
        public string FileName = "";
        public string FileExt = "";
        public string FilePath = "";
        public decimal FileSize = 0;
    }
    /// <summary>
    /// RJSOFT: 파일 열기 확장자 지정
    /// </summary>
    public static FileInfo OpenFile()
    {
        return OpenFile("");
    }
    public static FileInfo OpenFile(string dirPath, params string[] extentions)
    {
        return OpenFile(dirPath, -1, extentions);
    }
    public static FileInfo OpenFile(int limitSize, params string[] extentions)
    {
        return OpenFile("", limitSize, extentions);
    }
    public static FileInfo OpenFile(string dirPath, int limitSize, params string[] extentions)
    {
        System.Windows.Forms.OpenFileDialog oDialog = new System.Windows.Forms.OpenFileDialog();
        if (dirPath.IndexOf(":\\") > 0)
        {
            oDialog.InitialDirectory = dirPath;
        }
        if (extentions.Length > 0)
        {
            oDialog.Filter = ItsFileDialog.ConvertExtention(extentions[0]);
            for (int i = 1; i < extentions.Length; i++)
            {
                oDialog.Filter += "|" + ItsFileDialog.ConvertExtention(extentions[i]);
            }
        }
        else
        {
            oDialog.Filter = "All Files (*.*)|*.*";
        }

        if (limitSize <= 0)
        {
            limitSize = 9999998;
        }

        decimal fileSize = 9999999;
        while (true)
        {
            DialogResult result = oDialog.ShowDialog();

            // 취소를 했을 경우
            if (result == DialogResult.Cancel || oDialog.FileName.IndexOf(":\\") == -1)
            {
                return new ItsFileDialog.FileInfo();
            }

            // 파일 용량 체크
            System.IO.FileInfo fInfo = new System.IO.FileInfo(oDialog.FileName);
            fileSize = Math.Round((decimal)fInfo.Length / 1024 / 1024, 2);
            if (fileSize > (decimal)limitSize)
            {
                string msg = String.Format("파일 크기는 {0}M를 초과할 수 없습니다.", limitSize);
                ItsMsgBox.Show(msg);
            }
            else
            {

                ItsFileDialog.FileInfo cmFileInfo = new ItsFileDialog.FileInfo();

                cmFileInfo.FileName = fInfo.Name;
                cmFileInfo.FileExt = fInfo.Extension;
                cmFileInfo.FilePath = fInfo.FullName;
                cmFileInfo.FileSize = Math.Round((decimal)fInfo.Length / 1024 / 1024, 2);

                return cmFileInfo;
            }
        }
    }
    /// <summary>
    /// RJSOFT: 파일 저장
    /// </summary>
    public static bool SaveFile(string fileName, byte[] bytes)
    {
        return SaveFile(fileName, "C:\\", bytes);
    }
    public static bool SaveFile(string fileName, string base64)
    {
        return SaveFile(fileName, "C:\\", base64);
    }
    public static bool SaveFile(string fileName, string dirPath, string base64)
    {
        return SaveFile(fileName, "C:\\", ItsFileSystem.Base64ToByte(base64));
    }
    public static bool SaveFile(string fileName, string dirPath, byte[] bytes)
    {
        System.Windows.Forms.SaveFileDialog saveFile = new System.Windows.Forms.SaveFileDialog();
        saveFile.FileName = fileName;
        saveFile.InitialDirectory = dirPath;
        saveFile.RestoreDirectory = true;

        saveFile.Filter = "All Files (*.*)|*.*";

        saveFile.ShowDialog();
        if (saveFile.FileName.IndexOf(":\\") > -1)
        {
            System.IO.File.WriteAllBytes(saveFile.FileName, bytes);
            return true;
        }
        else
        {
            return false;
        }
    }
    private static string ConvertExtention(string extention)
    {
        //extention: *.JPG 형태로 넘길것
        extention = extention.ToLower();
        if (extention == "*.*")
        {
            return "All Files (*.*)|*.*";
        }
        else if (extention == "*.xls")
        {
            return "Excel Files (*.xls)|*.xls";
        }
        else if (extention == "*.xlsx")
        {
            return "Excel Files (*.xlsx)|*.xlsx";
        }
        else if (extention == "*.doc")
        {
            return "Word Files (*.doc)|*.doc";
        }
        else if (extention == "*.docx")
        {
            return "Word Files (*.docx)|*.docx";
        }
        else if (extention == "*.ppt")
        {
            return "PowerPoint Files (*.ppt)|*.ppt";
        }
        else if (extention == "*.pptx")
        {
            return "PowerPoint Files (*.pptx)|*.pptx";
        }
        else
        {
            string str = extention.Substring(2, 1).ToLower() + extention.Substring(3);
            return str + " Files (" + extention + ")|" + extention;
        }
    }

}
