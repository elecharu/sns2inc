using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.IO;
using System.Net;
using System.Collections.Specialized;
using System.Security.Cryptography;
using System.Threading;

public class Program
{
    public static void Main(string[] args)
    {
        try
        {   
            ItsMaria maria = new ItsMaria("HRM2001_R01", "UP_POSTPONED");
            maria.CallProc();
            if (maria.IsError)
            {
                return;
            }
        }
        catch
        {

        }
        return;
    }
}