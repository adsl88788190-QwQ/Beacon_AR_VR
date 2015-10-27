using UnityEngine;
using System.Collections;


public class SkyboxObj : MonoBehaviour {
	//public GameObject ob;
	public Material sk5build ;
	public Material skneigen ;
	private float time = 0; 
	private int count = 0;
	private int changesk=0;
	public GameObject go;
	public GameObject au5;
	// Use this for initialization
	void Start () {
		//ob.renderer.enabled = false;
		RenderSettings.skybox = skneigen;
		go.transform.position = new Vector3 (0,0,0); 
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
			Debug.Log (changesk);
			if(changesk==0){
				RenderSettings.skybox = sk5build;
				au5.transform.position= new Vector3(0,0,0);
				go.transform.position = new Vector3 (2000,0,0); 
				changesk=1;
				count = 0;
			}
			else{
				RenderSettings.skybox = skneigen;
				go.transform.position = new Vector3 (0,0,0); 
				au5.transform.position = new Vector3 (2000,0,0); 
				changesk=0;
				count = 0;
			}


		
		}
		
	}
	void OnTriggerExit (Collider other) 
	{
		Debug.Log ("SK Exit");
		
	}
	
}
