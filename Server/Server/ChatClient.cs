using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Net;
using System.Net.Sockets;

namespace TestServer
{
    class ChatClient
    {
        //使用者列表
        public static Hashtable AllClients = new Hashtable();
        //使用者序號、IP列表
        public static Dictionary<int, string> people_number = new Dictionary<int, string>();
        //使用者序號、傳送給誰列表
        public static Dictionary<int, bool> people_sent = new Dictionary<int, bool>();

        //使用者IP
        public string ClientIP;
        //使用者實體
        private TcpClient _Client;
        //使用者姓名
        private string ClientName;
        //傳送資料
        private byte[] Data;
        //是否第一次進入聊天室
        private bool First = true;
        //test
        private Socket s;
        //本身序號
        private int my_number = 0;
        //切割字符
        private char split_str = '_';
        //切割字符
        private char split_strorpic = '*';

        public ChatClient(TcpClient C)
        {

            Program.totalpeople++;
            my_number = Program.totalpeople;

            //實體化?
            this._Client = C;
            this.ClientIP = C.Client.RemoteEndPoint.ToString();
            //將使用者加入列表
            AllClients.Add(this.ClientIP, this);
            people_number.Add(my_number, this.ClientIP);

            //建立緩衝區大小
            Data = new byte[this._Client.ReceiveBufferSize];
            //接收訊息
            C.GetStream().BeginRead(Data, 0, System.Convert.ToInt32(this._Client.ReceiveBufferSize), ReceiveMessage, null);
            //test
            s = _Client.Client;

        }

        //接收使用者訊息
        public void ReceiveMessage(IAsyncResult str)
        {

            int Bytes;

            try
            {

                //讀取傳入資料
                lock (this._Client.GetStream())
                {
                    Bytes = this._Client.GetStream().EndRead(str);
                    Console.Write("有收到");
                }

                //判斷是否離開
                if (Bytes < 1)
                {

                    AllClients.Remove(this.ClientIP);
                    people_number.Remove(my_number);
                    people_sent.Remove(my_number);

                    BroadCast(this.ClientName + "離開聊天室");
                    Console.Write("有離開");
                }
                else
                {

                    //----------------------------------------------------------------------------------------------
                    //接收訊息
                    string MessageReceived = System.Text.Encoding.UTF8.GetString(Data, 0, Bytes);
                    if (First)
                    {

                        //切割MessageReceived資料
                        string[] strorpic = MessageReceived.Split(split_strorpic);

                        //若第一次進入則把使用者輸入的訊息設為名子，並把First更改為false
                        this.ClientName = "(" + my_number + ")" + "%" + strorpic[1];
                        Console.Write("快要進入" + my_number);
                        people_sent.Add(my_number, true);
                        BroadCast(this.ClientName + "進入聊天室");
                        First = false;
                        Console.Write("有進入");
                    }
                    else
                    {

                        //切割接收的資料
                        string[] message = MessageReceived.Split(split_str);
                        //切割message位置0的資料
                        string[] strorpic = message[0].Split(split_strorpic);

                        //先將所有使用者預設為不勾選(否則使用者將永遠為勾選)
                        for (int i = 1; i <= 5; i++)
                        {

                            people_sent[i] = false;

                        }

                        //將有勾選之使用者設為true
                        for (int i = 2; i < message.Length; i++)
                        {

                            if (people_sent.ContainsKey(int.Parse(message[i])))
                                people_sent[int.Parse(message[i])] = true;

                            if (strorpic[0].Equals("string"))
                                Console.WriteLine(this.ClientName + " 將文字訊息 " + strorpic[1] + " 傳送給 " + int.Parse(message[i]) + " 使用者.");
                            else if (strorpic[0].Equals("picture"))
                                Console.WriteLine(this.ClientName + " 將圖片訊息 " + strorpic[2] + " 傳送給 " + int.Parse(message[i]) + " 使用者.");

                        }

                        /*
                        foreach (KeyValuePair<int, bool> x in people_sent)
                        {
                            Console.WriteLine(this.ClientName + " : " + " for test " + x.Key.ToString() + " " + x.Value.ToString());

                        } 
                        */
                        /*                           
                        for (int i = 0; i < message.Length; i++ )
                        {

                            BroadCast(this.ClientName + " : " + message[i]);

                        }
                        */

                        //把MessageReceived廣播出去
                        BroadCast(this.ClientName + " : " + message[0]);

                    }
                    //----------------------------------------------------------------------------------------------

                    lock (this._Client.GetStream())
                    {

                        this._Client.GetStream().BeginRead(Data, 0, System.Convert.ToInt32(this._Client.ReceiveBufferSize), ReceiveMessage, null);

                    }

                }

            }
            catch (Exception ex)
            {
                //印出錯誤訊息
                Console.WriteLine(ex);
                //將使用者踢下線
                AllClients.Remove(this.ClientIP);
                people_number.Remove(my_number);
                people_sent.Remove(my_number);

                BroadCast(this.ClientName + "離開聊天室");
                Console.Write("==========此為訊息輸出入 問題==========");

            }

        }

        //向使用者廣播訊息
        public void BroadCast(string message)
        {

            //顯示訊息
            Console.WriteLine(message);
            //傳送訊息

            //傳送給所有使用者Hashtable AllClients<String IP , Client物件 >
            foreach (DictionaryEntry c in AllClients)
            {

                //0626私人傳訊 修改刪除線
                //----------------------------------------------------------------------------------------------
                //第一次比對(確認序號0..1..2) Dictionary people_number<int 序號 , string IP>
                foreach (KeyValuePair<int, string> i in people_number)
                {
                    //序號確認，使用IP做為比對依據
                    if (i.Value.Equals(c.Key))
                    {

                        //比對小人是否勾選，使用---people_number---的key值進行尋找， Dictionary people_sent<int 序號 , bool 確認小人是否勾選>
                        foreach (KeyValuePair<int, bool> x in people_sent)
                        {

                            //當找到相同序號時
                            if (x.Key.Equals(i.Key))
                            {

                                //如果有勾選，送出訊息
                                if (x.Value)
                                    ((ChatClient)(c.Value)).SendMessage(message + Environment.NewLine);

                            }

                        }

                    }

                }
                //----------------------------------------------------------------------------------------------

                //((ChatClient)(c.Value)).SendMessage(message + "___" + c.Key + "___"  + c.Value+ Environment.NewLine);

            }

        }

        //向使用者發送訊息
        public void SendMessage(string message)
        {

            try
            {

                //網路串流
                System.Net.Sockets.NetworkStream NetStream;

                lock (this._Client.GetStream())
                {

                    NetStream = this._Client.GetStream();

                }

                //編碼訊息
                byte[] BytesToSend = System.Text.Encoding.UTF8.GetBytes(message);
                //寫入
                NetStream.Write(BytesToSend, 0, BytesToSend.Length);
                //傳送
                NetStream.Flush();

            }
            catch (Exception ex)
            {

                //印出錯誤訊息
                Console.WriteLine(ex);
                //將使用者踢下線
                AllClients.Remove(this.ClientIP);
                people_number.Remove(my_number);
                people_sent.Remove(my_number);

                BroadCast(this.ClientName + "離開聊天室");
                Console.Write("==========此為發送訊息 問題==========");

            }

        }

    }
}