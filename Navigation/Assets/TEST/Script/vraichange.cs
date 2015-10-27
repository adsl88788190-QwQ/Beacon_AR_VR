using UnityEngine;
using System.Collections;

public class vraichange : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void enter_event () {
		Application.LoadLevel ("VR_scence");
	}
	public void back_event () {
		Application.LoadLevel ("start");
	}

}
