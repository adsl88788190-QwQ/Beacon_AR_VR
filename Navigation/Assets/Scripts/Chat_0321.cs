using UnityEngine;
using System.Collections;
using System.IO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using System.Text;
using System.Net.Sockets;
using System.Net;
using System.Threading;

//可單人傳訊

public class Chat_0321 : MonoBehaviour
{
	const int Port_String = 2015;
	const int Port_Picture = 2016;
	const String IP = "192.168.10.102";
	public bool fillWithDummyData = false;
	public UITextList textList;
	UIInput mInput;
	public string me;
	private TcpClient Client_String;
	private TcpClient TcpClient_Picture;  
	byte[] data;
	
	public string pic_name;
	//使用者名子
	public string nickName;
	public string message;
	public string sendMsg;
	//public string Path = "\\目錄\\sdcard\\Android\\data\\com.qualcomm.QCARUnityPlayer\\files\\";
	Boolean isConnect;
	public int total = 0;
	
	private GameObject _cube;
	private bool serverIsRun = true;
	private string path = "/sdcard/Android/data/com.aaa.bbb/files/";
	//private string path = "/sdcard/aaa.png";
	
	private Socket s;
	private FtpWebRequest ftpRequest = null;
	private Stream ftpStream = null;
	private int bufferSize = 2048;
	
	//切割字符
	private char split_data = '%';
	//切割字符
	private char split_str = '*';
	//送出訊息計算數量
	private int count = 0;
	//藍色小人點擊確認
	private string howpeople = "";
	//啥?
	private bool sent = false;
	//傳送圖片訊息
	private string sentpic = "picture";
	//傳送文字訊息
	private string sentstr = "string";
	//傳送照片次數
	private int piccount = 1;
	//傳送照片的使用者名稱
	private string whosentpic = "";
	//實作quene
	private List<string> usernameandpic = new List<string>();
	//第一次傳送文字訊息
	private bool firstsent = true;
	//傳送登入訊息
	private string name = "name";
	//第一次進入
	private bool firstin = true;
	//更改小人顏色
	public static bool[] change_man_color = new bool[5];
	
	//修改刪除線0709加入指定圖片分享 可刪除
	//------------------------------------------------------------------------------------
	private WWW data0708;
	private GameObject _momo;
	private UITexture test0708;
	//------------------------------------------------------------------------------------
	
	public static string img_path_prefix = "file://";
	public static string img_path = "";
	
	//0812加入掃描媒體更新
	//------------------------------------------------------------------------------------
	// Android Activity
	//123private static AndroidJavaObject activity;
	//------------------------------------------------------------------------------------

	public GameObject GO;
	public bool b = false;
	
	// Use this for initialization
	void Start () {
		nickName = "";
		message = "";
		sendMsg = "";
		isConnect = false;	
		mInput = GetComponent<UIInput>();
		mInput.label.maxLineCount = 1;

		
	}
	
	//修改刪除線0709加入指定圖片分享
	//------------------------------------------------------------------------------------
	/*
	IEnumerator testUITexture()
	{

		data0708 = new WWW (@"/sdcard/ccc.png");
		yield return data0708;
	
		UITexture texture = _momo.GetComponent<UITexture> ();
		texture.mainTexture = data0708.texture;

	}
	*/
	//------------------------------------------------------------------------------------
	
	// Update is called once per frame
	void Update () {
		
		if (fillWithDummyData == true)
		{
			textList.Add (me);
			fillWithDummyData=false;
		}
	}
	
	
	void OnGUI() {
		
		GUI.color = Color.black;
		try {
			if( isConnect == false && serverIsRun) 
			{			
				//連接傳送文字Port
				this.Client_String = new TcpClient();
				this.Client_String.Connect(IP, Port_String);
				//連接傳送圖片Port
				this.TcpClient_Picture = new TcpClient();
				this.TcpClient_Picture.Connect(IP, Port_Picture);
				
				s = TcpClient_Picture.Client;
				
				data = new byte[this.Client_String.ReceiveBufferSize];
				SendMessage(nickName);
				this.Client_String.GetStream().BeginRead(data, 0, System.Convert.ToInt32(this.Client_String.ReceiveBufferSize), ReceiveMessage, null);
				
				isConnect = true;
			}
		}
		catch(Exception e) 
		{
			serverIsRun = false;
			Debug.Log("Server is not run");
		}


		//是否開啟接收按鈕
		if(sent == true){
			GO.SetActive(true);
			sent = false;
		}

	}
	
	public void UIButton_Download(){

		ftp ftpClient = new ftp(@"ftp://140.131.152.3:7223/FTP/momoya", "momo6699", "123");
		//ftp ftpClient = new ftp(@"ftp://140.131.152.5:7223/Volume_1/momoya/", "momo6699", "123456");
		// 參數：  （ftp端 要存的檔案名稱,  本地端的路徑  note: 副檔名非常重要  jpg jpeg png 要分清楚）
		
		
		string str1 = usernameandpic[0] + ".png";
		string str2 = "/sdcard/" + usernameandpic[0] + ".png";
		
		//ftpClient.download(@"AR_test.jpg" , @str2);
		ftpClient.download(@str1 , @str2);
		
		DataManger.new_pic_path = img_path_prefix + str2;
		DataManger.b = true;
		
		checksent();
	}
	
	public void UIButton_Close(){

		checksent();
		
	}

	private void checksent(){
		
		//修改刪除線0627加入指定圖片分享
		//------------------------------------------------------------------------------------
		GO.SetActive(false);
		usernameandpic.RemoveAt(0);
		//usernameandpic.RemoveAt(1);
		
		if(usernameandpic[0] == null)
			sent = false;

		//------------------------------------------------------------------------------------
		
	}
	
	public void PiconClick(){
		
		//取得目前時間
		pic_name = DateTime.Now.ToShortTimeString();
		//螢幕擷取
		Application.CaptureScreenshot(pic_name+".png");							
		
		String pic_path = path + pic_name + ".png";
		
		try{
			
			//此為暫存器，儲存上傳次數+使用者姓名
			string str = piccount + nickName ;
			
			ftp ftpClient = new ftp(@"ftp://140.131.152.3:7223/FTP/momoya", "momo6699", "123");
			//ftp ftpClient = new ftp(@"ftp://140.131.152.5:7223/Volume_1/momoya/", "momo6699", "123456");
			// 參數：  （ftp端 要存的檔案名稱,  本地端的路徑  note: 副檔名非常重要  jpg jpeg png 要分清楚）
			ftpClient.upload( str + ".png" , @pic_path);
			
			//修改刪除線0627加入指定圖片分享
			//------------------------------------------------------------------------------------
			
			//檢查藍色小人是否被點選
			CheckMan();
			//傳送圖片訊息*使用者姓名*上傳的檔名
			SendMessage(sentpic + "*" + nickName + "*" + str);
			//傳送次數+1，藉此變更傳送圖片
			piccount++;
			
			//------------------------------------------------------------------------------------
			
		}catch(Exception e){
			
			SendMessage("Client " + e.ToString());
			
		}
		
	}
	
	public void StrOnclick ()
	{
		
		//if (textList != null)
		//{
		// It's a good idea to strip out all symbols as we don't want user input to alter colors, add new lines, etc
		string text = NGUIText.StripSymbols(mInput.value);
		
		//檢查藍色小人是否被點選
		CheckMan();
		
		
		if (firstsent) {
			
			//傳送使用者輸入的文字訊息
			//SendMessage (sentstr + "*" + name + ":" +  text);
			
			nickName = text;
			
			//傳送使用者輸入的文字訊息
			SendMessage (sentstr + "*" + name + "%" +  text);
			firstsent = false;
			
		} else {
			
			//傳送使用者輸入的文字訊息
			SendMessage (sentstr + "*" + text);
			
		}
		
		//textList.Add(text);
		mInput.value = "";
		mInput.isSelected = false;
		
	}

	//檢查藍色小人是否被點選
	private void CheckMan(){
		
		if (count > 1) {
			
			bool sendman_1 = man_1.man1;
			bool sendman_2 = man_2.man2;
			bool sendman_3 = man_3.man3;
			bool sendman_4 = man_4.man4;
			bool sendman_5 = man_5.man5;
			
			howpeople = howpeople + "_@@@@@@@@"; //共有八個@確認
			
			if(sendman_1)
				howpeople = howpeople + "_1";
			if(sendman_2)
				howpeople = howpeople + "_2";
			if(sendman_3)
				howpeople = howpeople + "_3";
			if(sendman_4)
				howpeople = howpeople + "_4";
			if(sendman_5)
				howpeople = howpeople + "_5";
			
		}
		
	}
	
	//傳送文字或接收圖片訊息
	public void SendMessage(string Msg) {
		
		try {
			count++;
			
			NetworkStream ns = this.Client_String.GetStream();
			
			Msg = Msg + howpeople;
			
			byte[] data = System.Text.Encoding.UTF8.GetBytes(Msg);
			
			howpeople = "";
			
			ns.Write(data, 0, data.Length);
			ns.Flush();
		}
		catch (Exception ex){
			Debug.Log(ex);
		}   
	}
	
	public void ReceiveMessage(IAsyncResult ar) {
		try {
			int bytesRead;
			
			bytesRead = this.Client_String.GetStream().EndRead(ar);
			
			if (bytesRead < 1) {
				return;
			}
			else {
				
				//接收訊息
				string receivevalue = System.Text.Encoding.UTF8.GetString(data, 0, bytesRead);
				
				
				//修改刪除線0627加入指定圖片分享
				//------------------------------------------------------------------------------------
				
				
				//將訊息切割使用%
				string[] messagedata = new string[3];
				messagedata = receivevalue.Split(split_data);
				
				//如果是登入訊息
				if(messagedata[1].Equals(name)){
					
					string[] message_first_in = messagedata[2].Split(':');
					
					if(message_first_in.Length.Equals(1)){
						
						Debug.Log(messagedata[0] + messagedata[2]);
						message += messagedata[0] + messagedata[2];
						me = messagedata[0] + messagedata[2];
						me = me.TrimEnd((char[])("\n\r".ToCharArray()));
						fillWithDummyData=true;
						
						//修改刪除線0627加入指定圖片分享
						//------------------------------------------------------------------------------------
						if(firstin){
							
							change_color(messagedata[0]);
							
						}
						//------------------------------------------------------------------------------------
						
					}else{
						
						//將訊息切割使用*
						string[] message_str_or_pic = message_first_in[1].Split(split_str);
						
						/*檢查代碼
					 * 
					 *EX：string hello
					 *string開頭為傳送文字訊息
					 * 後面接著文字訊息
					 * 
					 *EX：picture aaa.png
					 *picture開頭為圖片訊息
					 * 後面接著檔名
					 */
						
						if(message_str_or_pic[0].Equals(" string")){
							
							Debug.Log(messagedata[0] + message_first_in[0] + ":" + message_str_or_pic[1]);
							message += messagedata[0] + message_first_in[0] + ":" + message_str_or_pic[1];
							me = messagedata[0] + message_first_in[0] + ":" + message_str_or_pic[1];
							me = me.TrimEnd((char[])("\n\r".ToCharArray()));
							fillWithDummyData=true;
							
						}else if(message_str_or_pic[0].Equals(" picture")){
							
							
							//------------------------------------------------------------------------------------
							Debug.Log(message_str_or_pic[1] + "傳送了一張圖片");
							message += message_str_or_pic[1] + "傳送了一張圖片";
							me = message_str_or_pic[1] + "傳送了一張圖片";
							
							sent = true;
							
							me = me.TrimEnd((char[])("\n\r".ToCharArray()));
							fillWithDummyData=true;
							//------------------------------------------------------------------------------------
							
							//usernameandpic.Add(message_str_or_pic[1]);
							
							//0715修改
							//usernameandpic.Add(message_str_or_pic[2]);
							
							//0715修改 刪除結尾空白字元
							string[] test = message_str_or_pic[2].Split();
							usernameandpic.Add(test[0]);
							
						}
						
					}
					/*
					Debug.Log(messagedata[0] + messagedata[2]);
					message += messagedata[0] + messagedata[2];
					me = messagedata[0] + messagedata[2];
					me = me.TrimEnd((char[])("\n\r".ToCharArray()));
					fillWithDummyData=true;
					*/
					
				}
				//------------------------------------------------------------------------------------
				
				/*
				Debug.Log(receivevalue);
				message += receivevalue;
				me = receivevalue;
				me = me.TrimEnd((char[])("\n\r".ToCharArray()));
				fillWithDummyData=true;
				*/
				
			}
			
			//繼續接收資料
			this.Client_String.GetStream().BeginRead(data, 0, System.Convert.ToInt32(this.Client_String.ReceiveBufferSize), ReceiveMessage, null);
			
		}
		catch (Exception ex){
			Debug.Log(ex);
		} 
		
	}
	
	private void change_color(string str){
		
		if (str.Equals ("(1)")) {
			change_man_color[0] = true;
		}
		if (str.Equals ("(2)")) {
			change_man_color[1] = true;
		}
		if (str.Equals ("(3)")) {
			change_man_color[2] = true;
		}
		if (str.Equals ("(4)")) {
			change_man_color[3] = true;
		}
		if (str.Equals ("(5)")) {
			change_man_color[4] = true;
		}
		
		firstin = false;
		//UIInput.label = "Label_Pic";
	}
	
}
