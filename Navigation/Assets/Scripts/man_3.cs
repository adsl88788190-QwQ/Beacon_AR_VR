using UnityEngine;
using System.Collections;

public class man_3 : MonoBehaviour {

	public static bool man3 = true;
	
	// Use this for initialization
	void Start () {
		/*
		if (Chat_0321.change_man_color [2]) {
			
			UISprite sprite = gameObject.GetComponent<UISprite>();
			sprite.spriteName = "red";
			Debug.Log("222");
			
		}
		*/
	}
	
	// Update is called once per frame
	void Update () {

		if (Chat_0321.change_man_color [2]) {
			
			UISprite sprite = gameObject.GetComponent<UISprite>();
			sprite.spriteName = "red";
			//Debug.Log("222");
			
		}

	}
	
	void OnClick() {

		man3 = !man3;
		Debug.Log (man3.ToString());
		
	}

}
