using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security;
using System.Security.Cryptography;
using System.IO;
using System.Xml;

public static class ItsSecurity
{
    public static string EncDES(string str)
    {
        return EncDES(str, ">ITS1005");
    }

    public static string EncDES(string str, string key)
    {
        byte[] keyByte = (new UTF8Encoding()).GetBytes(key);
        if (keyByte.Length != 8)
        {
            return "Key length must be 8 byte";
        }

        byte[] strByte = (new UTF8Encoding()).GetBytes(str);
        DESCryptoServiceProvider des = new DESCryptoServiceProvider();
        des.Key = keyByte;
        des.IV = keyByte;
        ICryptoTransform desencrypt = des.CreateEncryptor();
        MemoryStream ms = new MemoryStream();
        CryptoStream cs = new CryptoStream(ms, desencrypt,
            CryptoStreamMode.Write);
        cs.Write(strByte, 0, strByte.Length);
        cs.FlushFinalBlock();

        byte[] encByte = ms.ToArray();
        return Convert.ToBase64String(encByte);
    }

    public static string DecDES(string str)
    {
        return DecDES(str, ">ITS1005");
    }

    public static string DecDES(string str, string key)
    {
        byte[] keyByte = (new UTF8Encoding()).GetBytes(key);
        if (keyByte.Length != 8)
        {
            return "Key length must be 8 byte.";
        }

        if (str.Trim().Length < 12) return "";
        byte[] encData = Convert.FromBase64String(str);
        DESCryptoServiceProvider des = new DESCryptoServiceProvider();
        des.Key = keyByte;
        des.IV = keyByte;
        ICryptoTransform desdecrypt = des.CreateDecryptor();
        MemoryStream ms = new MemoryStream();
        CryptoStream cs = new CryptoStream(ms, desdecrypt,
            CryptoStreamMode.Write);
        cs.Write(encData, 0, encData.Length);
        cs.FlushFinalBlock();

        byte[] strByte = ms.ToArray();
        return (new UTF8Encoding()).GetString(strByte, 0, strByte.Length);
    }

    public static string EncMD5(string str)
    {
        byte[] data = (new UTF8Encoding()).GetBytes(str);
        MD5 md5 = new MD5CryptoServiceProvider();
        byte[] decByte = md5.ComputeHash(data);

        return Convert.ToBase64String(decByte);
    }
}