using UnityEngine;
using System.Collections;

public class vrback : MonoBehaviour {

	// Use this for initialization
	private float time = 0; 
	private int count = 0;
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerStay(Collider other)
	{
		Debug.Log ("SK Stay");
		time += Time.deltaTime;
		if(time>1)
		{
			
			count++;
			time = 0;
		}//0.05  0.3  0.55  0.8*/
		if(count == 4)
		{
			Debug.Log ("changesk");
			count = 0;
			Application.LoadLevel (2);

		}
		
	}

	void OnTriggerExit (Collider other) 
	{
		Debug.Log ("SK Exit");
		
	}
	
}
