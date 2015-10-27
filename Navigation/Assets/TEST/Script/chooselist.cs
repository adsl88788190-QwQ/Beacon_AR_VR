using UnityEngine;
using System.Collections;

public class chooselist : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnGUI(){
		if (GUI.Button (new Rect (0, 0, 150, 150), "AR")) 
		{
			Application.LoadLevel(1);
		}
		if (GUI.Button (new Rect (0, 150, 150, 150), "VR")) 
		{

			Application.LoadLevel(2);
		}
		
		
		
		
	}
}
