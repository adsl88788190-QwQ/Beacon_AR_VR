using System;
using System.IO;
using System.Net.Sockets;
using System.Text;

namespace TestServer
{

    class ChatPic
    {

        public static string receivedPath = "D://0419.png";

        //P為主類別傳入的TcpListener
        public ChatPic(TcpClient P)
        {

            try
            {
                
                Socket s = P.Client;
                byte[] data = new byte[117912]; 
                s.Receive(data , SocketFlags.None);

                File.WriteAllBytes("D://0419.png", data);

                Console.WriteLine("OK");
                
            }
            catch(Exception e){

                Console.WriteLine(e);
                Console.Write("==========此為圖片server 問題==========");
            }
        }

    }
}