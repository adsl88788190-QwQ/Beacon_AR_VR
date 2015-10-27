using UnityEngine;
using System.Collections;

public class man_4 : MonoBehaviour {

	public static bool man4 = true;
	
	// Use this for initialization
	void Start () {
		/*
		if (Chat_0321.change_man_color [3]) {
			
			UISprite sprite = gameObject.GetComponent<UISprite>();
			sprite.spriteName = "red";
			Debug.Log("333");
			
		}
		*/
	}
	
	// Update is called once per frame
	void Update () {

		if (Chat_0321.change_man_color [3]) {
			
			UISprite sprite = gameObject.GetComponent<UISprite>();
			sprite.spriteName = "red";
			//Debug.Log("333");
			
		}

	}
	
	void OnClick() {
		
		man4 = !man4;
		Debug.Log (man4.ToString());

	}

}
