using UnityEngine;
using System.Collections;

public class _map : MonoBehaviour {
	private GameObject m1;
	private GameObject m2;
	private GameObject m3;
	private GameObject m4;
	private GameObject m5;
	private GameObject m6;
	private GameObject m7;
	private GameObject m8;
	private int temp = -1;

	private Vector3 vector_Up = new Vector3(0, 10, 0);
	private Vector3 vector_Down = new Vector3(0, -10, 0);

	//Server IP & Port
	//const String IP = "140.131.152.108";
	//const int Port_Map = 1225;
	//TCP 連線
	//private TcpClient Client_String;

	// Use this for initialization
	void Awake(){ 
		
		m1 = GameObject.Find("location01");
		m2 = GameObject.Find("location02");
		m3 = GameObject.Find("location03");
		m4 = GameObject.Find("location04");
		m5 = GameObject.Find("location05");
		m6 = GameObject.Find("location06");
		m7 = GameObject.Find("location07");
		m8 = GameObject.Find("location08");
		
	}
	void Start () {


	}
	
	// Update is called once per frame
	void Update () {
		if(temp!= _arHandler.index) {
			_setMap(temp, vector_Down);
			temp = _arHandler.index;
			_setMap(temp, vector_Up);
		}
	}

	public void _setMap(int i, Vector3 vector) {
		
		switch(i) {	
			case 1:
				m1.transform.Translate(vector);
				break;

			case 2:
				m2.transform.Translate(vector);
				break;

			case 3:
				m3.transform.Translate(vector);
				break;

			case 4:
				m4.transform.Translate(vector);
				break;		

			case 5:
				m5.transform.Translate(vector);
				break;
				
			case 6:
				m6.transform.Translate(vector);
				break;
				
			case 7:
				m7.transform.Translate(vector);
				break;
				
			case 8:
				m8.transform.Translate(vector);
				break;
		}
	}

	/*
	public void ReceiveMessage(IAsyncResult ar) {
		try {
			int bytesRead;
			
			bytesRead = this.Client_String.GetStream().EndRead(ar);
			
			if (bytesRead < 1) {
				return;
			}
			else {
				Debug.Log(System.Text.Encoding.UTF8.GetString(data, 0, bytesRead));
				message += System.Text.Encoding.UTF8.GetString(data, 0, bytesRead);
				//string[] allmap = message.Split

			}
			this.Client_String.GetStream().BeginRead(data, 0, System.Convert.ToInt32(this.Client_String.ReceiveBufferSize), ReceiveMessage, null);
			
		}
		catch (Exception ex){
			Debug.Log(ex);
		} 
		
	}
	*/


}

