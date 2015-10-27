using UnityEngine;
using System.Collections;

public class AU5HIT : MonoBehaviour {

	public GameObject ob;
	private float time = 0; 
	private int count = 0;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
		
	}
	void OnTriggerStay(Collider other)
	{ 
		Debug.Log ("AU Stay");
		time += Time.deltaTime;
		if(time>1)
		{
			
			count++;
			time = 0;
		}//0.05  0.3  0.55  0.8*/
		if(count == 4)
		{
			
			ob.transform.position = new Vector3 (0, 0, 0); 
			count = 0;
			time=0;
		}
		
	}
	void OnTriggerExit (Collider other) 
	{
		Debug.Log ("AU Exit");
		//btnopen = 1;
		
		
		ob.transform.position = new Vector3 (2000, 0, 0); 
		
		
		
		
	}
	
}

