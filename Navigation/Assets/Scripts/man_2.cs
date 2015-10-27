using UnityEngine;
using System.Collections;

public class man_2 : MonoBehaviour {

	public static bool man2 = true;
	
	// Use this for initialization
	void Start () {
		/*
		if (Chat_0321.change_man_color [1]) {
			
			UISprite sprite = gameObject.GetComponent<UISprite>();
			sprite.spriteName = "red";
			Debug.Log("111");
		}
		*/
	}
	
	// Update is called once per frame
	void Update () {

		if (Chat_0321.change_man_color [1]) {
			
			UISprite sprite = gameObject.GetComponent<UISprite>();
			sprite.spriteName = "red";
		//	Debug.Log("111");
		}

	}
	
	void OnClick() {
		
		man2 = !man2;
		Debug.Log (man2.ToString());

	}

}
