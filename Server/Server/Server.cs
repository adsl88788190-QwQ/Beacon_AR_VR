using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;
using TestServer;

namespace TestServer
{
    class Program
    {
        //建立IP、PORT
        const string ServerIP = "192.168.10.102";
        public const int Port_String = 2015;
        public const int Port_Picture = 2016;
        public static int totalpeople = 0;

        static void Main(string[] args)
        {

            //ChatClient.AllClients

            //初始化IP
            System.Net.IPAddress IP = System.Net.IPAddress.Parse(ServerIP);
            //TCP偵聽器
            TcpListener listener_String = new TcpListener(IP, Port_String);
            TcpListener listener_Picture = new TcpListener(IP, Port_Picture);
            listener_String.Start();
            listener_Picture.Start();
            //印出Server相關資訊
            Console.WriteLine("Server IP : " + ServerIP + " Port_Str : " + Port_String + " Port_Pic : " + Port_Picture);
            Console.WriteLine("Server Start");

            while (true)
            {

                //進入聊天圖片處理
                ChatClient CSP = new ChatClient(listener_String.AcceptTcpClient());
                Console.WriteLine("\n" + CSP.ClientIP + "加入");
                //ChatPic CP = new ChatPic(listener_Picture.AcceptTcpClient());
                //Console.WriteLine("test");

            }

        }
    }
}