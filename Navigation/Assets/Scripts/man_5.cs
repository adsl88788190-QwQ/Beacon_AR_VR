using UnityEngine;
using System.Collections;

public class man_5 : MonoBehaviour {

	public static bool man5 = true;
	
	// Use this for initialization
	void Start () {
		/*
		if (Chat_0321.change_man_color [4]) {
			
			UISprite sprite = gameObject.GetComponent<UISprite>();
			sprite.spriteName = "red";
			Debug.Log("444");
			
		}
		*/
	}
	
	// Update is called once per frame
	void Update () {

		if (Chat_0321.change_man_color [4]) {
			
			UISprite sprite = gameObject.GetComponent<UISprite>();
			sprite.spriteName = "red";
			//Debug.Log("444");
			
		}

	}
	
	void OnClick() {
		
		man5 = !man5;
		Debug.Log (man5.ToString());

	}

}
