using UnityEngine;
using System.Collections;

public class outc : MonoBehaviour {

	// Use this for initialization
	void Start () {

	}
	int escapeTimes=0;
	// Update is called once per frame
	void Update()
	{

		if(Input.GetKey(KeyCode.Escape))
		{	
			escapeTimes++;	
			StartCoroutine("resetTimes");
			if(escapeTimes > 2)
			{
				Application.Quit();
			}
			
		}
		
	}
	IEnumerator resetTimes()
	{
		yield return new WaitForSeconds(1);
		escapeTimes =0;
	}
}
