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
        Console.WriteLine("청구서 마감 시작");
        ItsMaria maria = new ItsMaria();
        maria.AddQuery("CALL SAL3001_R04('" + System.DateTime.Now.ToString("yyyy-MM") + "','', 'ADD_PUBLICATION', '')");
        maria.Query();
        if (maria.IsError)
        {
            Console.WriteLine("청구서 마감 에러 발생");
            return;
        }
        Console.WriteLine("청구서 마감 종료");

        Console.WriteLine("재고 마감 시작");
        if ((System.DateTime.Now.ToString("yyyy-MM") + "-01") == System.DateTime.Now.ToString("yyyy-MM-dd"))
        {
            ItsMaria maria_before = new ItsMaria();
            maria_before.AddQuery("CALL STO5003_R02('', '" + System.DateTime.Now.AddDays(-1).ToString("yyyy-MM") + "','', 'ADD_PUBLICATION', '')");
            maria_before.Query();
            if (maria_before.IsError)
            {
                Console.WriteLine("재고 마감 에러 발생");
                return;
            }
        }

        ItsMaria maria2 = new ItsMaria("STO5003_R02", "ADD_PUBLICATION");
        maria2.AddQuery("CALL STO5003_R02('', '" + System.DateTime.Now.ToString("yyyy-MM") + "','', 'ADD_PUBLICATION', '')");
        maria2.Query();
        if (maria2.IsError)
        {
            Console.WriteLine("재고 마감 에러 발생");
            return;
        }
        Console.WriteLine("재고 마감 종료");

        // 안전재고 직접 관리
        //ItsMaria maria_safeqty = new ItsMaria("STO5003_R02", "CAL_SAFEQTY");
        //maria_safeqty.CallProc();
        //if (maria_safeqty.IsError)
        //{
        //    Console.WriteLine("안전재고계산 에러 발생");
        //    return;
        //}
        //Console.WriteLine("안전재고계산 종료");

        Thread.Sleep(2000);

        return;
    }
}