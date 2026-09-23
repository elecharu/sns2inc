using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public static class ItsEqmConn
{
    private static string _CRLF = Convert.ToChar(13).ToString() + Convert.ToChar(10).ToString();
    private static string _ENQ = Convert.ToChar(5).ToString();
    private static string _ACK = Convert.ToChar(6).ToString();
    private static string _STX = Convert.ToChar(2).ToString();
    private static string _EOT = Convert.ToChar(4).ToString();
    private static string _ETX = Convert.ToChar(3).ToString();
    private static string _NAK = Convert.ToChar(21).ToString();

    public static string SerialReadWord(SerialPort Serial, string var1, int var2)
    {
        //if (!Serial.IsOpen)
        //{
        //    Serial.PortName = File.ReadAllText("Cfg_PLCPORT.txt");
        //    Serial.Open();
        //}

        int PLC_Loop = 0, ilen = 0;

        string[] sARR = new string[20];
        string sADD = "";
        string sRcv = "";
        string sRCV1 = "";

        string sHEX = "";
        string sRESULT = "";

        int i = 0;

        if (var2 > 20)
        {
            var2 = 20;
        }

        for (i = 0; i < var2; i++)
        {
            sARR[i] = var1.Substring(i * 6, 6);
        }

        for (i = 0; i < var2; i++)
        {
            sADD = sADD + "07%" + sARR[i];
        }

        ilen = var2 * 6 + 9;   //9 : Ack + 국번(00) + "RSB" + 갯수(00) + ... + ETX

        sHEX = "0" + String.Format("{0:X}", Convert.ToInt32(var2));

        sHEX = sHEX.Substring(sHEX.Length - 2, 2);


    //' 프로토콜 시작
    Start:

        PLC_Loop = PLC_Loop + 1;
        if (PLC_Loop > 10)
        {
            return "";
        }

        sRcv = Serial.ReadExisting();

        Serial.Write(_ENQ + "00RSS" + sHEX + sADD + _EOT);

        delay(200);

        sRcv = Serial.ReadExisting();

        if (sRcv == "") goto Start;

        if (sRcv.Length < ilen)
        {
            goto Start;
        }

        if (sRcv.Substring(6, 2) != sHEX) goto Start;

        if (sRcv.Substring(0, 1) == _ACK && sRcv.Substring(ilen - 1, 1) == _ETX)
        {
            sRCV1 = sRcv.Substring(8, var2 * 6);

            for (i = 0; i < sRCV1.Length; i = i + 6)
            {
                sRESULT = sRESULT + sRCV1.Substring(i + 2, 4);
            }
        }
        else
        {
            goto Start;

        }

        return sRESULT;
    }

    public static string SerialWriteWord(SerialPort SERIAL, string var1, string var2)
    {
        if (!SERIAL.IsOpen)
        {
            try
            {
                SERIAL.PortName = File.ReadAllText("Cfg_PLCPORT.txt");
                SERIAL.Open();
            }
            catch { }
        }

        string sRcv = "";
        string sRESULT = "";

        string sDATA = "";
        string sCNTHEX = "";

        int iCNT = 0;

        int PLC_Loop = 0;

    Start:

        PLC_Loop = PLC_Loop + 1;
        if (PLC_Loop > 10)
        {
            return "";
        }

        sRcv = SERIAL.ReadExisting();

        iCNT = var1.Length / 4;

        sCNTHEX = "00" + String.Format("{0:X}", iCNT);

        sCNTHEX = sCNTHEX.Substring(sCNTHEX.Length - 2, 2);



        for (int i = 0; i < var1.Length; i = i + 4)
        {
            sDATA = sDATA + "07%DW" + var1.Substring(i, 4) + var2.Substring(i, 4);
        }

        SERIAL.Write(_ENQ + "00WSS" + sCNTHEX + sDATA + _EOT);       //자료 입력할 주소 보냄   ===> Step 1.

        delay(200);

        sRcv = SERIAL.ReadExisting();

        if (sRcv == "") goto Start;

        if (sRcv.Substring(0, 1) != _ACK) goto Start;

        sRESULT = "T";

        return sRESULT;
    }

    public static void delay(long Millisecond)
    {
        double iDiff = 0;
        DateTime sETIME;

        DateTime sSTIME = DateTime.Now;
        int iDELCNT = 0;

        while (iDELCNT == 0)
        {

            sETIME = DateTime.Now;


            iDiff = DateDiff(sSTIME, sETIME);


            if (iDiff > Millisecond) break;


            // Application.DoEvents();
        }

    }

    public static double DateDiff(DateTime Date1, DateTime Date2)
    {
        string sSDATE = "";
        string sEDATE = "";


        double iDELS = 0;
        double iDELE = 0;

        sSDATE = Date1.Year.ToString() + Date1.Month.ToString("00") + Date1.Day.ToString("00") + Date1.Hour.ToString("00") + Date1.Minute.ToString("00") + Date1.Second.ToString("00") + Date1.Millisecond.ToString("000");
        sEDATE = Date2.Year.ToString() + Date2.Month.ToString("00") + Date2.Day.ToString("00") + Date2.Hour.ToString("00") + Date2.Minute.ToString("00") + Date2.Second.ToString("00") + Date2.Millisecond.ToString("000");

        iDELS = double.Parse(sSDATE);
        iDELE = double.Parse(sEDATE);

        double diff = iDELE - iDELS;

        return diff;
    }
}
