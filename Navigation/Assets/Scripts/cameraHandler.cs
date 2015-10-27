using UnityEngine;
using System.Collections;

public class cameraHandler : MonoBehaviour {
	private GameObject Camera01;
	private GameObject Camera02;
	private GameObject Camera03;
	private bool temp;
	//private bool isRun;
	public static bool chatIsRun;
	public static bool infoIsRun;
	public static bool mapIsRun;
	public static bool reMap;
	public static bool ishide;


	// Use this for initialization
	void Awake(){
		chatIsRun = true;
		infoIsRun = true;
		mapIsRun = true;
		reMap = false;

		temp = false;
		ishide = false;
		//isRun = true;
		Camera01 = GameObject.Find("Camera_Chat");
		Camera02 = GameObject.Find("Camera_Infomation");
		Camera03 = GameObject.Find("Camera_Map");


	}
	void Start () {


	}
	
	// Update is called once per frame
	void Update () {

		if (temp != ishide) {
			if(!ishide) 
				openCamera();
			else
				closeCamera();

			temp = ishide;
		}

		
	}
	void OnGUI() {

		//if (GUI.Button (new Rect (1155, 10, 80, 20), "隱藏")) {
		/*if (GUI.Button (new Rect (1800, 10, 100, 40), "隱藏")) {
			if (ishide) {
				ishide = false;
			} 
			else {
				ishide = true;
			}
		}*/
		if (reMap == true) 
		{
			reCamera ();
			reMap = false;
		}
	}

	void reCamera () {
		if(chatIsRun == true) 
			Camera01.SetActive(true);
		else if(chatIsRun == false) 
			Camera01.SetActive(false);

		if(infoIsRun == true)
			Camera02.SetActive(true);
		else if(infoIsRun == false)
			Camera02.SetActive(false);

		if(mapIsRun == true)
			Camera03.SetActive(true);
		else if(mapIsRun == false)
			Camera03.SetActive(false);
	}

	void openCamera() {
		if(chatIsRun == true) 
			Camera01.SetActive(true);

		if(infoIsRun == true)
			Camera02.SetActive(true);

		if(mapIsRun == true)
			Camera03.SetActive(true);
	}

	void closeCamera() {
		if(chatIsRun == true) 
			Camera01.SetActive(false);

		if(infoIsRun == true)
			Camera02.SetActive(false);

		if(mapIsRun == true)
			Camera03.SetActive(false);
	}
}
