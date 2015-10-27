using UnityEngine;
using System.Collections;

public class hit : MonoBehaviour {


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerStay(Collider other)
	{
		/*
		time += Time.deltaTime;
		if(time>1)
		{
			count++;
			time = 0;
		}//0.05  0.3  0.55  0.8
		if(count == 4)
		{
			MainScript.gameState = other.name;
			Debug.Log(MainScript.gameState);
			count = 0;
		}
		renderer.material.mainTextureOffset = new Vector2 (puctureOffset[count], 0);

	*/
	}
	// 離開碰撞 count = 0;
	void OnTriggerExit(Collider other)
	{

	}
}
