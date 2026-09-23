using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Windows.Forms;
using System.IO;
using System.Data;
using System.Xml;
using System.Reflection;
using System.Runtime.InteropServices;

/// <summary>
/// RJSOFT: 컴퓨터 시스템 관련 정보 얻기
/// </summary>
public class ItsLocalInfo
{
    public static void _SetBDVCD(string BDVCD)
    {
        _BDVCD = BDVCD;
    }
    public static void _SetPrintSales1(string PRINT_SALES1)
    {
        _PRINT_SALES1 = PRINT_SALES1;
    }
    public static void _SetPrintSales2(string PRINT_SALES2)
    {
        _PRINT_SALES2 = PRINT_SALES2;
    }
    public static void _SetPrintDaesin(string PRINT_DAESIN)
    {
        _PRINT_DAESIN = PRINT_DAESIN;
    }
    public static void _SetPORTSCALE(string PORTSCALE)
    {
        _PORTSCALE = PORTSCALE;
    }
    public static void _SetPORTPLC(string PORTPLC)
    {
        _PORTPLC = PORTPLC;
    }
    public static void _SetPRINTTP(string PRINTTP)
    {
        _PRINTTP = PRINTTP;
    }
    private static string _BDVCD = "";
    public static string BDVCD
    {
        get
        {
            if (_BDVCD == "")
            {
                try
                {
                    _BDVCD = System.IO.File.ReadAllText("ConfigBdvcd.config", Encoding.UTF8);
                }
                catch { }
            }
            return _BDVCD;
        }
        set
        {
            if (_BDVCD == "")
            {
                _BDVCD = value;
            }
        }
    }

    private static string _PRINT_SALES1 = "";
    public static string PRINT_SALES1
    {
        get
        {
            if (_PRINT_SALES1 == "")
            {
                try
                {
                    _PRINT_SALES1 = System.IO.File.ReadAllText("ConfigPrintSales1.config", Encoding.UTF8);
                }
                catch { }
            }
            return _PRINT_SALES1;
        }
        set
        {
            if (_PRINT_SALES1 == "")
            {
                _PRINT_SALES1 = value;
            }
        }
    }

    private static string _PRINT_SALES2 = "";
    public static string PRINT_SALES2
    {
        get
        {
            if (_PRINT_SALES2 == "")
            {
                try
                {
                    _PRINT_SALES2 = System.IO.File.ReadAllText("ConfigPrintSales2.config", Encoding.UTF8);
                }
                catch { }
            }
            return _PRINT_SALES2;
        }
        set
        {
            if (_PRINT_SALES2 == "")
            {
                _PRINT_SALES2 = value;
            }
        }
    }
    private static string _PRINT_DAESIN = "";
    public static string PRINT_DAESIN
    {
        get
        {
            if (_PRINT_DAESIN == "")
            {
                try
                {
                    _PRINT_DAESIN = System.IO.File.ReadAllText("ConfigPrintDaesin.config", Encoding.UTF8);
                }
                catch { }
            }
            return _PRINT_DAESIN;
        }
        set
        {
            if (_PRINT_DAESIN == "")
            {
                _PRINT_DAESIN = value;
            }
        }
    }
    
    public static bool _TMLINFORELOAD = false;
    private static string _TMLCD = "";
    public static string TMLCD
    {
        get
        {
            if (_TMLCD == "" || _TMLINFORELOAD)
            {
                _TMLINFORELOAD = false;
                try
                {
                    _TMLCD = System.IO.File.ReadAllText("ConfigTmlcd.config", Encoding.UTF8);

                    StringBuilder query = new StringBuilder();
                    query.Append("SELECT WARECD FROM MSTTML WHERE TMLCD = '" + _TMLCD + "';");
                    _TMLWARE = ItsData.GetScalar(ItsMaria.Query(query.ToString()));
                }
                catch { }
            }
            return _TMLCD;
        }
        set
        {
            if (IsRunMode)
            {
                try
                {
                    _TMLCD = System.IO.File.ReadAllText("ConfigTmlcd.config", Encoding.UTF8);
                }
                catch { }
            }

            if (_TMLCD == "")
            {
                _TMLCD = value;

                StringBuilder query = new StringBuilder();
                query.Append("SELECT WARECD FROM MSTTML WHERE TMLCD = '" + TMLCD + "';");
                _TMLWARE = ItsData.GetScalar(ItsMaria.Query(query.ToString()));
            }
        }
    }

    private static string _TMLEMP = "";
    public static string TMLEMP
    {
        get
        {
            if (_TMLEMP == "")
            {
                try
                {
                    _TMLEMP = System.IO.File.ReadAllText("ConfigEmpcd.config", Encoding.UTF8);
                }
                catch { }
            }
            return _TMLEMP;
        }
        set
        {
            if (_TMLEMP == "")
            {
                _TMLEMP = value;
            }
        }
    }

    private static string _TMLWARE = "";
    public static string TMLWARE
    {
        get
        {
            if (_TMLWARE == "")
            {
                StringBuilder query = new StringBuilder();
                query.Append("SELECT WARECD FROM MSTTML WHERE TMLCD = '" + TMLCD + "';");
                _TMLWARE = ItsData.GetScalar(ItsMaria.Query(query.ToString()));
            }

            return _TMLWARE;
        }
    }

    private static string _TMLUID = "";
    public static string TMLUID
    {
        get
        {
            if (_TMLUID == "")
            {
                try
                {
                    _TMLUID = System.IO.File.ReadAllText("ConfigTmluid.config", Encoding.UTF8);
                }
                catch
                {
                    _TMLUID = Guid.NewGuid().ToString().Replace("-", "").ToUpper();
                    System.IO.File.WriteAllText("ConfigTmluid.config", _TMLUID, Encoding.UTF8);
                }
            }
            return _TMLUID;
        }
        set
        {
            if (_TMLUID == "")
            {
                _TMLUID = value;
            }
        }
    }

    public static System.IO.Ports.SerialPort SerialScale = new System.IO.Ports.SerialPort();
    private static string _PORTSCALE = "";
    public static string PORTSCALE
    {
        get
        {
            if (_PORTSCALE == "")
            {
                try
                {
                    _PORTSCALE = System.IO.File.ReadAllText("ConfigPortScale.config", Encoding.UTF8);
                }
                catch { }
            }
            return _PORTSCALE;
        }
        set
        {
            if (_PORTSCALE == "")
            {
                _PORTSCALE = value;
            }
        }
    }

    public static System.IO.Ports.SerialPort SerialPlc = new System.IO.Ports.SerialPort();
    private static string _PORTPLC = "";
    public static string PORTPLC
    {
        get
        {
            if (_PORTPLC == "")
            {
                try
                {
                    _PORTPLC = System.IO.File.ReadAllText("ConfigPortPlc.config", Encoding.UTF8);
                }
                catch { }
            }
            return _PORTPLC;
        }
        set
        {
            if (_PORTPLC == "")
            {
                _PORTPLC = value;
            }
        }
    }


    public static System.IO.Ports.SerialPort SerialPrinttp = new System.IO.Ports.SerialPort();
    private static string _PRINTTP = "";
    public static string PRINTTP
    {
        get
        {
            if (_PRINTTP == "")
            {
                try
                {
                    _PRINTTP = System.IO.File.ReadAllText("ConfigPrinttp.config", Encoding.UTF8);
                }
                catch { }
            }
            return _PRINTTP;
        }
        set
        {
            if (_PRINTTP == "")
            {
                _PRINTTP = value;
            }
        }
    }

    /// <summary>
    /// RJSOFT: 컴퓨터 이름 얻기
    /// </summary>
    public static string HostName
    {
        get
        {
            try
            {
                return Dns.GetHostName().Trim();
            } catch
            {
                return "HostName";
            }
        }
    }
    /// <summary>
    /// RJSOFT: 클라이언트 로컬 IP 주소 얻기
    /// </summary>
    private static string _IPAddressLan = "";
    public static string IPAddressLan
    {
        get
        {
            if (_IPAddressLan == "")
            {
                try
                {
                    IPHostEntry entry = Dns.GetHostEntry(Dns.GetHostName());
                    for (int i = 0; i < entry.AddressList.Length; i++)
                    {
                        if (entry.AddressList[i].AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                        {
                            string ip4Address = entry.AddressList[i].ToString().Trim();
                            _IPAddressLan = ip4Address;
                            break;
                        }
                    }
                    if (_IPAddressLan == "") _IPAddressLan = "0.0.0.0";
                }
                catch
                {
                    _IPAddressLan = "0.0.0.0";
                };
            }
            return _IPAddressLan;
        }
    }
    /// <summary>
    /// RJSOFT: 클라이언트 외부 IP 주소 얻기
    /// </summary>
    private static string _IPAddressWan = "";
    public static string IPAddressWan
    {
        get
        {
            if (_IPAddressWan == "")
            {
                WebClient wClient = new WebClient();
                try
                {
                    _IPAddressWan = wClient.DownloadString("http://home.rjsoft.co.kr/rjservice/client_ip_address.aspx").Trim();
                }
                catch
                {
                    _IPAddressWan = "0.0.0.0";
                }
            }
            return _IPAddressWan;
        }
    }

    private static string _MacAddress = "";
    public static string MacAddress
    {
        get
        {
            if (_MacAddress == "")
            {
                try
                {
                    _MacAddress = System.Net.NetworkInformation.NetworkInterface.GetAllNetworkInterfaces()[0].GetPhysicalAddress().ToString();
                }
                catch
                {
                    _MacAddress = "0000";
                }
            }
            return _MacAddress;
        }
    }

    /// <summary>
    /// RJSOFT: 어샘블리 경로
    /// </summary>
    public static string AssemblyPath
    {
        get
        {
            if (_AssemblyPath == "")
            {
                DirectoryInfo dInfo = new DirectoryInfo(Directory.GetCurrentDirectory());
                _AssemblyPath = dInfo.FullName;
            }
            return _AssemblyPath;
        }
    }
    private static string _AssemblyPath = "";
    /// <summary>
    /// RJSOFT: 실행 모드 여부
    /// </summary>
    public static bool IsRunMode
    {
        get
        {
            if (Directory.Exists("..\\AAALIB"))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
    /// <summary>
    /// RJSOFT: 디자인 모드
    /// </summary>
    public static bool IsDesignMode
    {
        get
        {
            if (_IsDesignMode == "")
            {
                if (System.ComponentModel.LicenseManager.UsageMode == System.ComponentModel.LicenseUsageMode.Designtime)
                {
                    _IsDesignMode = "Y";
                }
                else if (System.Diagnostics.Process.GetCurrentProcess().ProcessName.ToUpper().Equals("DEVENV"))
                {
                    _IsDesignMode = "Y";
                }
                else
                {
                    _IsDesignMode = "N";
                }
            }
            if (_IsDesignMode == "Y")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
    private static string _IsDesignMode = "";

    /// <summary>
    /// RJSOFT: 환경설정파일 경로
    /// </summary>
    public static string ConfigFilePath
    {
        get
        {
            if (_ConfigFilePath == "")
            {
                _ConfigFilePath = AssemblyPath + "\\RjConfig.xml";
            }
            return _ConfigFilePath;
        }
        set
        {
            _ConfigFilePath = value.ToString().Trim();
        }
    }
    private static string _ConfigFilePath = "";
    /// <summary>
    /// RJSOFT: 환경설정파일 경로
    /// </summary>
    public static string UpdateVer
    {
        get
        {
            if (_UpdateVer == "")
            {
                if (System.IO.File.Exists("RjConfig.UpdateVer.rjc"))
                {
                    _UpdateVer = System.IO.File.ReadAllText("RjConfig.UpdateVer.rjc");
                }
                else
                {
                    _UpdateVer = "";
                }
            }
            return _UpdateVer;
        }
    }
    private static string _UpdateVer = "";
    /// <summary>
    /// RJSOFT: 사용자 정보 환경 설정 파일 경로
    /// </summary>
    public static string UserInfoFilePath
    {
        get
        {
            string filePath = AssemblyPath + "\\XmlData\\UserInfo\\" + ItsMemberShip.USERID + ".xml";
            // 로컬에 사용자 XML 정보 존재 여부 확인, 없다면 생성
            if (!System.IO.File.Exists(filePath))
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("<?xml version=\"1.0\" encoding=\"utf-8\" ?>\r\n");
                sb.Append("<UserInfo>\r\n");

                sb.Append("\t<PrinterInfo>\r\n");
                sb.Append("\t\t<BarcodePrinter></BarcodePrinter>\r\n");
                sb.Append("\t\t<GeneralPrinter></GeneralPrinter>\r\n");
                sb.Append("\t</PrinterInfo>\r\n");

                sb.Append("</UserInfo>");

                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.LoadXml(sb.ToString());

                string dirPath = filePath.Replace(ItsMemberShip.USERID + ".xml", "");
                ItsFileSystem.CreateDirectory(dirPath);
                xmlDoc.Save(filePath);
            }
            return filePath;
        }
    }
    /// <summary>
    /// RJSOFT: 프로그램 Title 정보
    /// </summary>
    public static string ProgramTitle
    {
        get
        {
            if (_ProgramTile == "RJSOFT" && File.Exists("RjConfig.ProgramTitle.rjc"))
            {
                _ProgramTile = System.IO.File.ReadAllText("RjConfig.ProgramTitle.rjc", Encoding.UTF8).Trim();
            }
            return _ProgramTile;
        }
        set
        {
            _ProgramTile = value;
        }
    }
    private static string _ProgramTile = "RJSOFT";
    /// <summary>
    /// RJSOFT: 메시지 박스 Title 정보
    /// </summary>
    public static string MessageBoxCaption
    {
        get
        {
            if (_MessageBoxCaption == "RJSOFT" && File.Exists("RjConfig.MessageBoxCaption.rjc"))
            {
                _MessageBoxCaption = System.IO.File.ReadAllText("RjConfig.MessageBoxCaption.rjc", Encoding.UTF8).Trim();
            }
            return _MessageBoxCaption;
        }
        set
        {
            _MessageBoxCaption = value;
        }
    }
    private static string _MessageBoxCaption = "RJSOFT";
    /// <summary>
    /// RJSOFT: 바코드 전용 프린트 이름 ( 설정되어 있지 않을 경우 기본 프린터 )
    /// </summary>
    public static string BarcodePrintName
    {
        get
        {
            if (_BarcodePrintName == "")
            {
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(ItsLocalInfo.UserInfoFilePath);
                string barcodePrinter = xmlDoc.SelectSingleNode("/UserInfo/PrinterInfo/BarcodePrinter").InnerText;
                if (barcodePrinter.Trim() != "")
                {
                    _BarcodePrintName = barcodePrinter;
                }
                else
                {

                    System.Drawing.Printing.PrintDocument printDoc = new System.Drawing.Printing.PrintDocument();
                    _BarcodePrintName = printDoc.PrinterSettings.PrinterName;
                }
            }
            return _BarcodePrintName;
        }
        set
        {
            _BarcodePrintName = value.Trim();
        }
    }
    private static string _BarcodePrintName = "";
    /// <summary>
    /// RJSOFT: 일반 프린터 이름 ( 설정되어 있지 않을 경우 기본 프린터 )
    /// </summary>
    public static string GeneralPrintName
    {
        get
        {
            if (_GeneralPrintName == "")
            {
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(ItsLocalInfo.UserInfoFilePath);
                string generalPrinter = xmlDoc.SelectSingleNode("/UserInfo/PrinterInfo/GeneralPrinter").InnerText;
                if (generalPrinter.Trim() != "")
                {
                    _GeneralPrintName = generalPrinter;
                }
                else
                {
                    System.Drawing.Printing.PrintDocument printDoc = new System.Drawing.Printing.PrintDocument();
                    _GeneralPrintName = printDoc.PrinterSettings.PrinterName;
                }
            }
            return _GeneralPrintName;
        }
        set
        {
            _GeneralPrintName = value.Trim();
        }
    }
    private static string _GeneralPrintName = "";
    /// <summary>
    /// RJSOFT: 기본 프린터 이름
    /// </summary>
    public static string DefaultPrintName
    {
        get
        {
            System.Drawing.Printing.PrintDocument printDoc = new System.Drawing.Printing.PrintDocument();
            return printDoc.PrinterSettings.PrinterName;
        }
    }
    /// <summary>
    /// RJSOFT: 기본 프린터 변경
    /// </summary>
    [DllImport("winspool.drv")]
    private static extern bool SetDefaultPrinter(string printerName);
    /// <summary>
    /// RJSOFT: 기본 프린터 임시 저장용
    /// </summary>
    private static string _defaultPrintName = "";
    /// <summary>
    /// RJSOFT: 기본 프린터 변경
    /// </summary>
    public static void ChangeDefaultPrinter(string printerName)
    {
        _defaultPrintName = ItsLocalInfo.DefaultPrintName;
        SetDefaultPrinter(printerName);
    }
    /// <summary>
    /// RJSOFT: 변경전 기본 프린터로 되돌림
    /// </summary>
    public static void ResetDefaultPrinter()
    {
        if (_defaultPrintName.Trim() != "")
        {
            SetDefaultPrinter(_defaultPrintName);
        }
    }
}
