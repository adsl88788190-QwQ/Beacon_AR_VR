using UnityEngine;
using System.Collections;

public class updatepic : MonoBehaviour {

	//0812加入掃描媒體更新
	//------------------------------------------------------------------------------------
	// Android Activity
	private static AndroidJavaObject activity;
	//------------------------------------------------------------------------------------

	// Use this for initialization
	void Start () {

		// 使用Android Activity
		AndroidJavaClass jc = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
		activity = jc.GetStatic<AndroidJavaObject>("currentActivity");
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnClick() {

		string str = DataManger.new_pic_path;
		activity.Call("UpdatePic" , str);
		
	}
}
