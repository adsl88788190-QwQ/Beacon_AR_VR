using UnityEngine;
using System.Collections;

public class man_1 : MonoBehaviour {

	public static bool man1 = true;

	// Use this for initialization
	void Start () {
		/*
		if (Chat_0321.change_man_color [0]) {
			
			UISprite sprite = gameObject.GetComponent<UISprite>();
			sprite.spriteName = "red";
			Debug.Log("000");
		}
		*/
	}
	
	// Update is called once per frame
	void Update () {

		if (Chat_0321.change_man_color [0]) {
			
			UISprite sprite = gameObject.GetComponent<UISprite>();
			sprite.spriteName = "red";
			//Debug.Log("000");
		}

	}

	void OnClick() {
		
		man1 = !man1;
		Debug.Log (man1.ToString());
				
	}

}
