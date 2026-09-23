using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Data;
using System.Net;
using System.Net.Sockets;
using MySql.Data.MySqlClient;
using System.Reflection;
using ITSLIB;

public static class ItsEqm
{
    public static string ResetCnt(string mechcd)
    {
        try
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("SELECT SYSEQMH.EQMIP, SYSEQMH.EQMPORT, SYSEQMH.FRAMETP, CONCAT(SUBSTRING(SYSEQMDATA.EQMADDR, 1, 4), 2),'1' ");
            sb.AppendLine("FROM SYSEQMD ");
            sb.AppendLine("LEFT JOIN SYSEQMH ");
            sb.AppendLine("ON SYSEQMD.EQMKEY = SYSEQMH.EQMKEY ");
            sb.AppendLine("LEFT JOIN SYSEQMDATA ");
            sb.AppendLine("ON SYSEQMD.EQMCD = SYSEQMDATA.EQMCD ");
            sb.AppendLine("WHERE SYSEQMD.EQMCD = 'MC01'; ");
            DataSet ds = ItsMaria.Query(sb.ToString());

            string ip = ds.Tables[0].Rows[0][0].ToString();
            int port = int.Parse(ds.Tables[0].Rows[0][1].ToString());
            string frameType = ds.Tables[0].Rows[0][2].ToString();
            string address = ds.Tables[0].Rows[0][3].ToString();
            string data = ds.Tables[0].Rows[0][4].ToString();
            #region XGT 프레임
            if (frameType.IndexOf("XG") > -1)
            {
                Socket client;
                IPAddress IPAddress;
                int Port;
                IPEndPoint IPEndPoint;

                if (frameType.IndexOf("UDP") > -1)
                {
                    client = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
                }
                else
                {
                    client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                }

                IPAddress = IPAddress.Parse(ip);
                Port = port;
                IPEndPoint = new IPEndPoint(IPAddress, Port);
                try
                {
                    client.Connect(ip, port);
                }
                catch { return "C"; }

                byte[] appHeader = new byte[20]; //헤더
                byte[] appInstruction = new byte[21];  //프레임 

                //헤더>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                appHeader[0] = 0x4c;  //LSIS-XGT
                appHeader[1] = 0x53;
                appHeader[2] = 0x49;
                appHeader[3] = 0x53;
                appHeader[4] = 0x2d;
                appHeader[5] = 0x58;
                appHeader[6] = 0x47;
                appHeader[7] = 0x54;
                appHeader[8] = 0x00;  //예약영역
                appHeader[9] = 0x00;
                appHeader[10] = 0x00; //PLC INFO (클라이언트에서 -> PLC로 요청할 경우 역할 없음)
                appHeader[11] = 0x00;
                appHeader[12] = 0x00; //CPU INFO (Reserved 영역을 통해 XGK/XGI 시리즈임을 판단)
                appHeader[13] = 0x33; //SOURCE OF FRAME (클라이언트->서버 0x33, 서버->클라이언트 0x11)
                appHeader[14] = 0x00; //Invork ID (프레임순번구별, 응답프레임에 해당순번 보내줌)
                appHeader[15] = 0x00;
                appHeader[16] = 0x15; //Application Instruction 의 바이트 크기
                appHeader[17] = 0x00;
                appHeader[18] = 0x00; //FEnet Position
                for (int i = 0; i < 19; i++)  //Application Header 의 Byte Sum
                {
                    if (i == 0)
                    {
                        appHeader[19] = appHeader[i];
                    }
                    else
                    {
                        appHeader[19] += (byte)appHeader[i];
                    }
                }

                //프레임>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                appInstruction[0] = 0x58; //명령어(쓰기)
                appInstruction[1] = 0x00;
                appInstruction[2] = 0x02; //데이터 타입
                appInstruction[3] = 0x00;
                appInstruction[4] = 0x00; //예약영역
                appInstruction[5] = 0x00;
                appInstruction[6] = 0x01; //블럭수
                appInstruction[7] = 0x00;
                appInstruction[8] = 0x07; //변수명 길이
                appInstruction[9] = 0x00;
                appInstruction[10] = Encoding.ASCII.GetBytes("%DW" + address.Replace("D", "").ToString())[0]; //변수(선두 메모리 번지)
                appInstruction[11] = Encoding.ASCII.GetBytes("%DW" + address.Replace("D", "").ToString())[1];
                appInstruction[12] = Encoding.ASCII.GetBytes("%DW" + address.Replace("D", "").ToString())[2];
                appInstruction[13] = Encoding.ASCII.GetBytes("%DW" + address.Replace("D", "").ToString())[3];
                appInstruction[14] = Encoding.ASCII.GetBytes("%DW" + address.Replace("D", "").ToString())[4];
                appInstruction[15] = Encoding.ASCII.GetBytes("%DW" + address.Replace("D", "").ToString())[5];
                appInstruction[16] = Encoding.ASCII.GetBytes("%DW" + address.Replace("D", "").ToString())[6];
                appInstruction[17] = 0x02; //Data 의 Byte Size
                appInstruction[18] = 0x00;
                appInstruction[19] = (byte)(int.Parse(data));
                appInstruction[20] = (byte)(int.Parse(data) >> 8);

                byte[] SendBuffer = new byte[41];       //전송 버퍼
                appHeader.CopyTo(SendBuffer, 0);        //전송버퍼에 헤더탑재
                appInstruction.CopyTo(SendBuffer, 20);  //전송버퍼에 프레임탑재

                try //버퍼 데이터 전송
                {
                    if (client.Connected == false)
                    {
                        client.Connect(ip, port);
                    }
                    client.Send(SendBuffer, 0, 41, 0);
                }
                catch { return "F"; }

                client.Close();

                return "T";
            }
            #endregion

            else
            {
                return "FrameType error!";
            }
        }
        catch { return "ERR"; }
    }
}