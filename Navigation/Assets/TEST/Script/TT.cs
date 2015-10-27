using UnityEngine;
using System.Collections;

public class TT : MonoBehaviour {

	public Material sk5build ;
	public Material skground ;
//	public GameObject mCamera;
	//private GameObject clui;
	//private GameObject crui;
	//private GameObject cui;
	public  GameObject mc;
	// Use this for initialization
	void Start () {
		RenderSettings.skybox = skground;
		//cui = GameObject.Find ("ctrl");


	}
	
	// Update is called once per frame
	void Update () {

	
}
	public void changesk5b(){
		RenderSettings.skybox = sk5build;	
	}
	public void changesground(){
		RenderSettings.skybox = skground;	
	}
	public void movemcamera(){
		//cui.transform.position = new Vector3(-100,0,0);

	}
	public void REmovemcamera(){
		//cui.transform.position = new Vector3(0,0,0);

	}

	public void mcmovemcamera(){
		mc.transform.position = new Vector3(500,0,0);
		
	}
	public void mcremovemcamera(){

		mc.transform.position = new Vector3(0,0,0);
		
	}
	void OnTriggerStay(Collider other)
	{
		Debug.Log("123123");
		mc.transform.position = new Vector3(500,0,0);
	}
	void OnTriggerEnter(Collider other) 
	{
		Debug.Log ("123");
	}





}