using UnityEngine;
using System.Collections;

public class showpic : MonoBehaviour {
	
	//修改刪除線0709加入指定圖片分享
	//------------------------------------------------------------------------------------
	private static GameObject _momo;
	//------------------------------------------------------------------------------------
	
	private static string path;
	
	// Use this for initialization
	void Start () {

		path = DataManger.new_pic_path;
		
		_momo = GameObject.Find ("PicView");
		StartCoroutine (testUITexture ());
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnGUI() {


		if (DataManger.b) {		
			path = DataManger.new_pic_path;
			StartCoroutine (testUITexture ());
		}

		
	}
	
	//修改刪除線0709加入指定圖片分享
	//------------------------------------------------------------------------------------
	public static IEnumerator testUITexture()
	{
		//string str = Application.dataPath + "/ccc.png";

		//手機路徑
		//pic = new WWW ("file:///sdcard/ccc.png");
		WWW pic = new WWW (path);
		//pic = new WWW (path);
		//網路路徑
		//data0708 = new WWW ("http://img.barks.jp/image/review/1000073566/aaa1_s.jpg");
		//電腦路徑
		//data0708 = new WWW ("file:///C://Mita.jpg");
		yield return pic;

		//UITexture picview = _momo.GetComponent<UITexture> ();
		//picview.mainTexture = pic.texture;


		if(!DataManger.b){
			UITexture picview = _momo.GetComponent<UITexture> ();
			picview.mainTexture = pic.texture;
		}
		DataManger.b = false;

	}
	//------------------------------------------------------------------------------------
}
