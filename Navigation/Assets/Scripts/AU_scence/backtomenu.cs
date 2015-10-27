using UnityEngine;
using System.Collections;

public class backtomenu : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void back_event () {
		Application.LoadLevel ("start");
	}
}
