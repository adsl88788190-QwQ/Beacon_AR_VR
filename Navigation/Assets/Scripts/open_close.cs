using UnityEngine;
using System.Collections;

public class open_close : MonoBehaviour {
	public GameObject picview;
	public GameObject map;
	public GameObject map_check;
	public GameObject chat;
	public GameObject chat_check;
	public GameObject info;
	public GameObject info_check;
	public GameObject table_setting;


	void Start(){
		//確保執行時各物件狀態正常
		map.SetActive (true);
		chat.SetActive (true);
		info.SetActive (true);
		picview.SetActive (false);
		table_setting.SetActive (false);
	}

	//table_setting
	public void table_setting_event(){
		if (table_setting.activeSelf == true)
			table_setting.SetActive (false);
		else
			table_setting.SetActive (true);
	}
	//map
	public void map_event(){
		if (map.activeSelf == true) {
			map.SetActive (false);
			map_check.SetActive (false);
		} 
		else {
			map.SetActive (true);
			map_check.SetActive (true);
		}
	}
	//chat
	public void chat_event(){
		if (chat.activeSelf == true) {
			chat.SetActive (false);
			chat_check.SetActive (false);
		} 
		else {
			chat.SetActive (true);
			chat_check.SetActive (true);
		}
	}
	//info
	public void info_event(){
		if (info.activeSelf == true) {
			info.SetActive (false);
			info_check.SetActive (false);
		} 
		else {
			info.SetActive (true);
			info_check.SetActive (true);
		}
	}
	//picview
	public void picview_event(){
		if(picview.activeSelf==true){
			picview.SetActive (false);
		}
		else{
		picview.SetActive (true);
		}
	}

}
