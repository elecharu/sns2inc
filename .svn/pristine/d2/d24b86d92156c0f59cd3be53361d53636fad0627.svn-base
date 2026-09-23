using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.IO;
using System.Net;
using Newtonsoft.Json;


public class Program
{
    public static void Main(string[] args)
    {
        //string currency = "FRX.KRWAUD,FRX.KRWBRL,FRX.KRWCAD,FRX.KRWCHF,FRX.KRWCNY,FRX.KRWEUR,FRX.KRWGBP,FRX.KRWHKD,FRX.KRWINR,FRX.KRWJPY,FRX.KRWMXN,FRX.KRWRUB,FRX.KRWTHB,FRX.KRWTWD,FRX.KRWUSD,FRX.KRWVND";
        string currency = "FRX.KRWCNY,FRX.KRWEUR,FRX.KRWJPY,FRX.KRWUSD";
        WebRequest request = WebRequest.Create("http://quotation-api-cdn.dunamu.com/v1/forex/recent?codes=" + currency); // 호출할 url
        request.Method = "GET";

        WebResponse response = request.GetResponse();
        Stream dataStream = response.GetResponseStream();
        StreamReader reader = new StreamReader(dataStream);

        string responseFromServer = reader.ReadToEnd();
        dynamic responseData = JsonConvert.DeserializeObject(responseFromServer);

        ItsMaria maria = new ItsMaria("COMEXCHANGE", "ADD_COMEXRATE");
        for (int i = 0; i < responseData.Count; i++)
        {
            dynamic exchangeData = responseData[i];
            maria.AddList("EXMONYTP_LIST", exchangeData.currencyCode.Value);
            maria.AddList("EXBASERT_LIST", exchangeData.basePrice.Value);
            maria.AddList("EXCASHBUY_LIST", exchangeData.cashBuyingPrice.Value);
            maria.AddList("EXCASHSALE_LIST", exchangeData.cashSellingPrice.Value);
            maria.AddList("EXCTTBUY_LIST", exchangeData.ttBuyingPrice.Value);
            maria.AddList("EXCTTSALE_LIST", exchangeData.ttSellingPrice.Value);
            maria.AddList("EXCHRT_LIST", exchangeData.changeRate.Value);
            maria.AddList("EXUSRT_LIST", exchangeData.usDollarRate.Value);
        }
        DataSet ds = maria.CallProc();
        if (maria.IsError)
        {
            return;
        }

        reader.Close();
        dataStream.Close();
        response.Close();        
        
    }
    
}