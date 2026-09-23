using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

public static class ItsString
{
    public static bool IsAlphabet(string str)
    {
        str = str.Replace(" ", "");
        int strLength = str.Length;
        int byteLength = Encoding.UTF8.GetBytes(str).Length;
        if (strLength == byteLength)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public static bool IsDate(string date)
    {
        date = (date + "0101").Replace("-", "").Replace("/", "").Replace(".", "").Replace(" ", "").Replace(":", "");
        if (date.Length < 8)
        {
            date = "19000101";
        } else
        {
            date = date.Substring(0, 8);
            date = date.Substring(0, 4) + "-" + date.Substring(4, 2) + "-" + date.Substring(6);
        }

        try
        {
            DateTime checkDate = DateTime.Parse(date);
            return true;
        }
        catch
        {
            return false;
        }
    }
    public static bool IsTime(string time)
    {
        time = (time + "0000").Replace(":", "").Replace(" ", "");
        time = time.Substring(0, 2) + ":" + time.Substring(2, 2) + ":" + time.Substring(4);
        try
        {
            DateTime checkDate = DateTime.Parse("1900-01-01 " + time);
            return true;
        }
        catch
        {
            return false;
        }
    }
    public static bool IsNumber(string num)
    {
        try
        {
            decimal deNum = decimal.Parse(num);
            return true;
        }
        catch { return false; }
    }
    public static string FormatToString(string format, params object[] args)
    {
        try
        {
            return String.Format(format, args);
        }
        catch
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(format);
            foreach(object obj in args)
            {
                sb.Append("," + obj.ToString());
            }
            return sb.ToString();
        }
    }
    public static string FormatToAdd(string format, int number)
    {
        string newStr = format + number.ToString();
        if (number.ToString().Length > format.Length)
        {
            return format;
        }
        return newStr.Substring(newStr.Length - format.Length);
    }
    public static string FormatToMoney(decimal number)
    {
        string str = number.ToString("###,###,###,###,##0.###,###,###,###,###");
        return str;
    }
    public static string FormatToMoney(int number)
    {
        return number.ToString("###,###,###,###,##0");
    }
    public static string SerialString(string str, int count)
    {
        StringBuilder serialStr = new StringBuilder();
        for (int i = 0; i < count; i++)
        {
            serialStr.Append(str);
        }
        return serialStr.ToString();
    }
    public static Byte[] StringToByte(string str)
    {
        return (new UTF8Encoding()).GetBytes(str);
    }
    public static string StringToBase64(string str)
    {
        byte[] bt = (new UTF8Encoding()).GetBytes(str);
        return Convert.ToBase64String(bt);
    }
    public static int StringToInt(string number)
    {
        try
        {
            return int.Parse(number);
        }
        catch
        {
            return 0;
        }
    }
    public static decimal StringToDecimal(string number)
    {
        try
        {
            return Decimal.Parse(number);
        }
        catch
        {
            return 0.0m;
        }
    }
    public static string AnsiToBase64(string str)
    {
        byte[] bt = (new ASCIIEncoding()).GetBytes(str);
        return Convert.ToBase64String(bt);
    }
    public static string ByteToString(byte[] bt)
    {
        return (new UTF8Encoding()).GetString(bt, 0, bt.Length);
    }
    public static byte[] AnsiToByte(string str)
    {
        return (new ASCIIEncoding()).GetBytes(str);
    }
    public static string ByteToAnsi(byte[] bt)
    {
        return (new ASCIIEncoding()).GetString(bt, 0, bt.Length);
    }
    public static byte[] Base64ToByte(string str)
    {
        return Convert.FromBase64String(str);
    }
    public static string Base64ToString(string str)
    {
        byte[] bt = Convert.FromBase64String(str);
        return (new UTF8Encoding()).GetString(bt, 0, bt.Length);
    }
    public static string ByteToBase64(byte[] bt)
    {
        return Convert.ToBase64String(bt);
    }
    public static string DateToLot(DateTime date)
    {
        return DateToLot(date.ToString("yyyyMMdd"));
    }
    public static string DateToLot(string date)
    {
        string monthList = "123456789ABC";
        string dayList = "123456789ABCDEFGHIJKLMNOPQRSTUV";

        try
        {
            int month = int.Parse(date.Substring(4, 2));
            int day = int.Parse(date.Substring(6, 2));

            string lotStr = date.Substring(2, 2);
            lotStr += monthList.Substring(month - 1, 1);
            lotStr += dayList.Substring(day - 1, 1);

            return lotStr;
        }
        catch
        {
            return "";
        }
    }
    public static DateTime LotToDateTime(string lot)
    {
        string monthList = "123456789ABC";
        string dayList = "1234567890ABCDEFGHIJKLMNOPQRSTUV";

        try
        {
            int year = 2000 + int.Parse(lot.Substring(0, 2));
            int month = monthList.IndexOf(lot.Substring(1, 1)) + 1;
            int day = dayList.IndexOf(lot.Substring(2, 1)) + 1;

            DateTime date = new DateTime(year, month, day);
            return date;
        }
        catch
        {
            return new DateTime();
        }
    }
    public static string LotToDateStr(string lot)
    {
        return LotToDateTime(lot).ToString("yyyyMMdd");
    }

    public static string ParseYN(object value)
    {
        string boolStr = value.ToString();
        if (boolStr.ToLower() == "true") return "Y";
        if (boolStr.ToLower() == "y") return "Y";
        else return "N";
    }
    public static bool ParseBool(object value)
    {
        string boolStr = value.ToString();
        if (boolStr == "1") return true; // 1일 경우만 true
        if (boolStr.ToLower() == "true") return true;
        if (boolStr.ToLower() == "y") return true;
        else return false;
    }
    public static int ParseInt(object value)
    {
        return (int)(ParseDecimal(value));
    }
    public static decimal ParseDecimal(object value)
    {
        string str = value.ToString();
        string result = "";
        string checkNum = "1234567890.";
        foreach (char ch in str)
        {
            if (checkNum.IndexOf(ch) > -1)
            {
                result += ch.ToString();
            }
        }
        int firstDot = result.IndexOf('.');
        if (firstDot >= 0)
        {
            result = result.Replace(".", "");
            if (firstDot == 0)
            {
                result = "0." + result;
            }
            else
            {
                result = result.Substring(0, firstDot) + "." + result.Substring(firstDot);
            }
        }

        try
        {
            return decimal.Parse(result);
        }
        catch
        {
            return 0m;
        }
    }
    public static string ParseString(object value)
    {
        string str = "";
        try
        {
            str = value.ToString();
        }
        catch { }
        return str;
    }
    public static DateTime ParseDateTime(object value)
    {
        string date = (value.ToString()).Replace("-", "").Replace("/", "").Replace(".", "").Replace(" ", "").Replace(":", "");
        string time = "";
        if (date.Length < 4) date = "1900";
        if (date.Length < 8)
        {
            date = (date + "0101").Substring(0, 8);
            time = "000000";
        }
        else
        {
            date = date.Substring(0, 8);
            time = (date.Substring(8) + "000000").Substring(0, 6);
        }

        string dateStr = date.Substring(0, 4) + "-" + date.Substring(4, 2) + "-" + date.Substring(6);
        dateStr = dateStr + " " + time.Substring(0, 2) + ":" + time.Substring(2, 2) + ":" + time.Substring(4);

        try
        {
            return DateTime.Parse(dateStr);
        }
        catch
        {
            return new DateTime(1900, 1, 1);
        }
    }
    public static DateTime GetWeekFirst(int year, int week)
    {
        return GetWeekFirst(year, week, true);
    }
    public static DateTime GetWeekFirst(int year, int week, bool IsMondayStart)
    {
        DateTime date = new DateTime(year, 1, 1);
        int addDay = 0; if (!IsMondayStart) addDay = -1;
        switch (date.DayOfWeek)
        {
            case DayOfWeek.Tuesday:
                addDay -= 1;
                break;
            case DayOfWeek.Wednesday:
                addDay -= 2;
                break;
            case DayOfWeek.Thursday:
                addDay -= 3;
                break;
            case DayOfWeek.Friday:
                addDay -= 4;
                break;
            case DayOfWeek.Saturday:
                addDay -= 5;
                break;
            case DayOfWeek.Sunday:
                if (IsMondayStart) addDay -= 6; else addDay = 0;
                break;
        }
        return date.AddDays((week - 1) * 7 + addDay);
    }
    public static DateTime GetWeekFirst(int year, int month, int week)
    {
        return GetWeekFirst(year, month, week, true);
    }
    public static DateTime GetWeekFirst(int year, int month, int week, bool IsMondayStart)
    {
        DateTime date = new DateTime(year, month, 1);
        int addDay = 0; if (!IsMondayStart) addDay = -1;
        switch (date.DayOfWeek)
        {
            case DayOfWeek.Tuesday:
                addDay -= 1;
                break;
            case DayOfWeek.Wednesday:
                addDay -= 2;
                break;
            case DayOfWeek.Thursday:
                addDay -= 3;
                break;
            case DayOfWeek.Friday:
                addDay -= 4;
                break;
            case DayOfWeek.Saturday:
                addDay -= 5;
                break;
            case DayOfWeek.Sunday:
                if (IsMondayStart) addDay -= 6; else addDay = 0;
                break;
        }
        return date.AddDays((week - 1) * 7 + addDay);
    }
    public static string GetUid()
    {
        long i = 1;
        foreach (byte b in Guid.NewGuid().ToByteArray())
        {
            i *= ((int)b + 1);
        }
        return string.Format("{0:x}", i - DateTime.Now.Ticks);
    }
    public static void Append(ref StringBuilder sb, string str)
    {
        sb.Append("┃" + str);
    }
    public static void Append(ref StringBuilder sb, int num)
    {
        sb.Append("┃" + num.ToString());
    }
    public static void Append(ref StringBuilder sb, decimal num)
    {
        sb.Append("┃" + num.ToString());
    }
}
