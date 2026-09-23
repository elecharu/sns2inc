using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Windows.Forms;
using System.IO;
using System.Xml;
using System.Runtime.InteropServices;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using System.Diagnostics;
using System.Data;
using System.Data.OleDb;


/// <summary>
/// RJSOFT: 文件处理关联 Class
/// </summary>
public class ItsFileSystem
{
    #region // ######################################################## 文件夹 生成/复制/删除
    /// <summary>
    /// RJSOFT: 成成文件夹
    /// </summary>
    public static bool CreateDirectory(string directory)
    {
        try
        {
            System.IO.Directory.CreateDirectory(directory);
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }
    /// <summary>
    /// RJSOFT: 复制整个文件夹 ( 包含所有子目录和子目录里的文件 )
    /// </summary>
    public static bool CopyDirectory(string srcPath, string desPath, bool overwrite)
    {
        // 保修路径末尾字段, 末尾如无"\\"字段时添加
        if (srcPath.Substring(srcPath.Length - 1) == "\\") srcPath = srcPath.Substring(0, srcPath.Length - 1);
        if (desPath.Substring(desPath.Length - 1) == "\\") desPath = desPath.Substring(0, desPath.Length - 1);
        try
        {
            if (Directory.Exists(srcPath))
            {
                if (!Directory.Exists(desPath))
                {
                    Directory.CreateDirectory(desPath);
                }

                foreach (string item in Directory.GetFiles(srcPath))
                {
                    File.Copy(item, desPath + "\\" + Path.GetFileName(item), overwrite);
                }
                foreach (string item in Directory.GetDirectories(srcPath))
                {
                    CopyDirectory(item, desPath + "\\" + item.Substring(item.LastIndexOf("\\") + 1), overwrite);
                }
            }
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }
    /// <summary>
    /// RJSOFT: 删除整个文件夹 ( 同时删除所有子目录和子目录里的文件 )
    /// </summary>
    public static bool DeleteDirectory(string desPath)
    {
        try
        {
            Directory.Delete(desPath, true);
            return true;
        }
        catch
        {
            return false;
        }
    }
    #endregion

    #region // ######################################################## 文件 生成/复制/删除
    /// <summary>
    /// RJSOFT: 指定路径里生成UTF-8格式的文本文件
    /// </summary>
    public static bool WriteTextFile(string filePath, string text)
    {
        try
        {
            File.WriteAllText(filePath, text, Encoding.UTF8);
            return true;
        }
        catch
        {
            return false;
        }
    }
    /// <summary>
    /// RJSOFT: 指定文件写入二进制文件
    /// </summary>
    public static bool WriteByteFile(string filePath, byte[] bytes)
    {
        try
        {
            File.WriteAllBytes(filePath, bytes);
            return true;
        }
        catch
        {
            return false;
        }
    }
    /// <summary>
    /// RJSOFT: 文件复制
    /// </summary>
    public static bool CopyFile(string sourceFile, string destFile, bool overwrite)
    {
        try
        {
            File.Copy(sourceFile, destFile, overwrite);
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }
    /// <summary>
    /// RJSOFT: 文件删除
    /// </summary>
    public static bool DeleteFile(string sourceFile)
    {
        try
        {
            File.Delete(sourceFile);
            return true;
        }
        catch
        {
            return false;
        }
    }
    /// <summary>
    /// RJSOFT: 读取二进制文件
    /// </summary>
    public static byte[] ReadByteFile(string filePath)
    {
        try
        {
            return File.ReadAllBytes(filePath);
        }
        catch
        {
            return null;
        }
    }
    /// <summary>
    /// RJSOFT: 读取Excel文件
    /// </summary>
    public static DataSet ReadExcelFile(string excelPath)
    {
        string connectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + excelPath + ";Extended Properties=\"Excel 8.0;HDR=NO;IMEX=1\"";
        if (excelPath.IndexOf(".xlsx") > 0)
        {
            connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + excelPath + ";Extended Properties=\"Excel 12.0;HDR=NO;IMEX=1\"";
        }

        OleDbConnection conn = new OleDbConnection(connectionString);
        OleDbCommand comm = new OleDbCommand();
        OleDbDataAdapter adap = new OleDbDataAdapter();

        comm.Connection = conn;
        comm.CommandType = CommandType.Text;
        adap.SelectCommand = comm;
        conn.Open();

        DataSet ds = new DataSet();
        DataTable sheetTable = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);

        if (sheetTable.Rows.Count > 0)
        {
            foreach (DataRow sheetRow in sheetTable.Rows)
            {
                comm.CommandText = "select * from [" + sheetRow[2].ToString() + "]";
                DataTable dt = new DataTable();
                adap.Fill(dt);
                ds.Tables.Add(dt);
            }
        }
        else
        {
            comm.CommandText = "select * from [Sheet1$]";
            DataTable dt = new DataTable();
            adap.Fill(dt);
            ds.Tables.Add(dt);
        }

        conn.Close();
        conn.Dispose();

        return ds;
    }
    /// <summary>
    /// RJSOFT: 读取Text文件(行单位)
    /// </summary>
    public static string[] ReadTextFile(string filePath)
    {
        string[] lineString = System.IO.File.ReadAllLines(filePath, Encoding.Default);
        return lineString;
    }
    /// <summary>
    /// RJSOFT: 读取Text文件(行单位读取,然后以隔离符再隔离)
    /// </summary>
    public static List<string[]> ReadTextFile(string filePath, string separator)
    {
        string[] lineString = System.IO.File.ReadAllLines(filePath, Encoding.Default);
        List<string[]> allString = new List<string[]>();
        foreach (string str in lineString)
        {
            allString.Add(str.Split(new string[] { separator }, StringSplitOptions.None));
        }
        return allString;
    }
    /// <summary>
    /// RJSOFT: 读取Image文件
    /// </summary>
    public static Image ReadImageFile(string filePath)
    {
        byte[] bt = ReadByteFile(filePath);
        MemoryStream ms = new MemoryStream(bt);
        Image img = Image.FromStream(ms, true);
        return img;
    }
    #endregion

    #region // ######################################################## Image <=> byte[] <=> Base64 <=> Bitmap
    /// <summary>
    /// RJSOFT: Base64 转换成 Image
    /// </summary>
    public static Image Base64ToImage(string base64Str)
    {
        if (base64Str.Trim() == "")
        {
            return null;
        }
        byte[] bt = Convert.FromBase64String(base64Str);
        MemoryStream ms = new MemoryStream(bt);
        Image img = Image.FromStream(ms);
        return img;
    }
    /// <summary>
    /// RJSOFT: Byte[] 转换成 Image
    /// </summary>
    public static Image ByteToImage(byte[] bt)
    {
        MemoryStream ms = new MemoryStream(bt);
        Image img = Image.FromStream(ms);
        return img;
    }
    /// <summary>
    /// RJSOFT: Image 转换成 Byte[] 
    /// </summary>
    public static byte[] ImageToByte(Image img)
    {
        if (img == null) return null;

        ImageConverter converter = new ImageConverter();
        return (byte[])converter.ConvertTo(img, typeof(byte[]));
    }
    /// <summary>
    /// RJSOFT: Image 转换成 Base64 
    /// </summary>
    public static string ImageToBase64(Image img)
    {
        if (img == null) return "";

        ImageConverter converter = new ImageConverter();
        byte[] bt = (byte[])converter.ConvertTo(img, typeof(byte[]));
        string base64 = Convert.ToBase64String(bt);
        return base64;
    }
    /// <summary>
    /// RJSOFT: Byte[] 转换成 Base64 
    /// </summary>
    public static string ByteToBase64(byte[] bt)
    {
        if (bt == null) return "";

        string base64 = Convert.ToBase64String(bt);
        return base64;
    }
    /// <summary>
    /// RJSOFT: Base64 转换成 Byte[]
    /// </summary>
    public static byte[] Base64ToByte(string base64Str)
    {
        if (base64Str.Trim() == "") return null;

        byte[] bt = Convert.FromBase64String(base64Str);
        return bt;
    }
    /// <summary>
    /// RJSOFT: Image 转换成 Bitmap
    /// </summary>
    public static Bitmap ImageToBitmap(Image image)
    {
        Bitmap bitmap = new Bitmap(image);
        return bitmap;
    }
    /// <summary>
    /// RJSOFT: Bitmap 转换成 Image
    /// </summary>
    public static Image BitmapToImage(Bitmap bitmap)
    {
        Image image = bitmap;
        return image;
    }
    #endregion


    #region // ######################################################## ini 文件读写
    [DllImport("kernel32.dll")]
    private static extern int GetPrivateProfileString(    // ini Read 函数
        string section,
        string key,
        string def,
        StringBuilder retVal,
        int size,
        string filePath);

    [DllImport("kernel32.dll")]
    private static extern long WritePrivateProfileString(  // ini Write 函数
        string section,
        string key,
        string val,
        string filePath);
    #endregion

    #region // ######################################################## 其他 文件路径转换
    /// <summary>
    /// RJSOFT: 相对路径转换成绝对路径
    /// </summary>
    public static string ConvertPathToLong(string path)
    {
        if (path.IndexOf(":\\") > -1) return path;

        path = ItsLocalInfo.AssemblyPath + "\\" + path;
        return path;
    }
    /// <summary>
    /// RJSOFT: 绝对路径转换成相对路径
    /// </summary>
    public static string ConvertPathToShort(string path)
    {
        if (path.IndexOf(":\\") == -1) return path;

        path = path.Replace(ItsLocalInfo.AssemblyPath, "");
        return path;
    }
    #endregion

    #region // ######################################################## 图片处理
    /// <summary>
    /// RJSOFT: 按比例调整大小
    /// </summary>
    public static Image ZoomImage(Image image, int width, int height)
    {
        if (image.Width > width || image.Height > height)
        {
            decimal rate1 = ((decimal)(image.Width)) / ((decimal)width);
            decimal rate2 = ((decimal)(image.Height)) / ((decimal)height);

            if (rate1 > rate2)
            {
                return ResizeImage(image, width, 0);
            }
            else
            {
                return ResizeImage(image, 0, height);
            }
        }
        return (Image)image.Clone();
    }
    /// <summary>
    /// RJSOFT: 调整图片大小
    /// </summary>
    public static Image ResizeImage(Image image, int width, int height)
    {
        Bitmap bitmap = new Bitmap(image);
        Bitmap newBitmap = ResizeBitmap(bitmap, width, height);

        image = newBitmap;
        return image;
    }
    /// <summary>
    /// RJSOFT: 调整图片大小
    /// </summary>
    public static Bitmap ResizeBitmap(Bitmap bitmap, int width, int height)
    {
        int newWidth = 0;
        int newHeight = 0;

        // 调整大小
        if (width != 0 && height == 0)
        {
            newWidth = width;
            newHeight = (int)(((decimal)width * (decimal)(bitmap.Height)) / ((decimal)(bitmap.Width)));
        }
        else if (width == 0 && height != 0)
        {
            newHeight = height;
            newWidth = (int)(((decimal)height * (decimal)(bitmap.Width)) / ((decimal)(bitmap.Height)));
        }
        else if (width == 0 && height == 0)
        {
            newWidth = bitmap.Width;
            newHeight = bitmap.Height;
        }

        if ((width > 0 && newWidth > width) || (height > 0 && newHeight > height))
        {
            ItsMsgBox.Show("bitmap.Width:" + bitmap.Width + ", bitmap.Height:" + bitmap.Height + ", Width:" + width + ", Heigth:" + height + ", newWidth:" + newWidth + ", newHeight:" + newHeight);
            ItsMsgBox.Show("调整图片大小时发生错误{\n\nRjFileSystem -> ResizeBitmap(image, " + bitmap.Width + ", " + bitmap.Height + ")}");
        }

        Bitmap scaledBitmap = new Bitmap(newWidth, newHeight, PixelFormat.Format24bppRgb);
        Graphics g = Graphics.FromImage(scaledBitmap);
        Rectangle destRect = new Rectangle(0, 0, newWidth, newHeight);
        g.InterpolationMode = InterpolationMode.HighQualityBicubic;
        g.SmoothingMode = SmoothingMode.AntiAlias;
        g.DrawImage(bitmap, destRect);

        return scaledBitmap;
    }
    #endregion

    public static bool Delete(string fileKey)
    {
        HttpWebRequest request = WebRequest.Create(ItsServerInfo.ServerUrl + "FileUpload.aspx") as HttpWebRequest;
        request.Method = "POST";
        request.ContentType = "application/x-www-form-urlencoded";

        string param = "CALLTYPE=DELETE&FILEKEY=" + fileKey;
        byte[] paramByte = Encoding.UTF8.GetBytes(param);

        Stream requestStream = request.GetRequestStream();
        requestStream.Write(paramByte, 0, paramByte.Length);
        requestStream.Close();

        HttpWebResponse response = (HttpWebResponse)request.GetResponse();
        Stream responseStrem = response.GetResponseStream();
        StreamReader responseStremReader = new StreamReader(responseStrem, Encoding.UTF8);

        string result = responseStremReader.ReadToEnd();
        if (result.Substring(0, 6) == "ERROR:")
        {
            // ItsMsgBox.ShowErr(result.Substring(6));
            return false;
        }
        else
        {
            return true;
        }
    }

    public static void Download(string fileKey, string fileName)
    {
        if (fileKey != "")
        {
            try
            {
                fileName = fileName.Split(new char[] { '|' })[0].Trim();
            }
            catch { }

            try
            {
                System.Windows.Forms.SaveFileDialog saveFile = new System.Windows.Forms.SaveFileDialog();
                saveFile.FileName = fileName;
                saveFile.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
                saveFile.Filter = "All Files (*.*)|*.*";
                saveFile.ShowDialog();

                if (saveFile.FileName.IndexOf(":\\") > -1)
                {
                    WebClient webClient = new WebClient();
                    StringBuilder query = new StringBuilder("SELECT FILEURL('" + fileKey + "')");
                    string fileUrl = ItsData.GetScalar(ItsMaria.Query(query.ToString()));
                    byte[] fileData = webClient.DownloadData(fileUrl);

                    System.IO.File.WriteAllBytes(saveFile.FileName, fileData);

                    Process.Start("explorer.exe", saveFile.FileName);
                }
                else
                {
                    ItsMsgBox.ShowErr("경로가 유효하지 않습니다.");
                }
            }
            catch (Exception ex)
            {
                ItsMsgBox.ShowErr(ex.ToString());
            }
        }
        else
        {
            ItsMsgBox.ShowErr("FileKey가 비어 있습니다.");
        }
    }

    public static string Upload(string filePath)
    {
        if (filePath.Substring(0, 4).ToLower() == "file")
        {
            filePath = filePath.Replace("file:///", "").Replace("/", "\\");
        }

        try
        {
            filePath = filePath.Split(new string[] { ": " }, StringSplitOptions.None)[1];
        }
        catch { }

        FileInfo fInfo = new FileInfo(filePath);

        string fileName = fInfo.Name.Replace("'", "");
        byte[] fileData = System.IO.File.ReadAllBytes(filePath);
        string fileBase64 = ItsString.ByteToBase64(fileData);

        StringBuilder sb = new StringBuilder();
        byte[] byStr = Encoding.UTF8.GetBytes(fileBase64);
        for (int i = 0; i < byStr.Length; i++)
        {
            sb.Append(@"%" + Convert.ToString(byStr[i], 16));
        }
        fileBase64 = sb.ToString();

        HttpWebRequest request = WebRequest.Create(ItsServerInfo.ServerUrl + "FileUpload.aspx") as HttpWebRequest;
        request.Method = "POST";
        request.ContentType = "application/x-www-form-urlencoded";

        string param = "FILENAME=" + fileName + "&FILEDATA=" + fileBase64;
        byte[] paramByte = Encoding.UTF8.GetBytes(param);

        Stream requestStream = request.GetRequestStream();
        requestStream.Write(paramByte, 0, paramByte.Length);
        requestStream.Close();

        HttpWebResponse response = (HttpWebResponse)request.GetResponse();
        Stream responseStrem = response.GetResponseStream();
        StreamReader responseStremReader = new StreamReader(responseStrem, Encoding.UTF8);

        string fileKey = responseStremReader.ReadToEnd();
        if (fileKey.Substring(0, 6) == "ERROR:")
        {
            ItsMsgBox.ShowErr(fileKey.Substring(6));
            return "";
        }
        else
        {
            return fileKey;
        }
    }
}
