using UnityEngine;
using System.Collections;

public class ARscence : MonoBehaviour {
	public string ArToLoad;
	public string VrToLoad;
	public UILabel loadlable;
	public GameObject screen;
	public UIProgressBar loadingbar;
	private int loadProgress=0;
	public GameObject ARbutton;
	public GameObject VRbutton;
	void Start () {
		screen.SetActive (false);
		ARbutton.SetActive (true);
		VRbutton.SetActive (true);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void aronclick(){
		StartCoroutine (ARLoadingscreen(ArToLoad));
		ARbutton.SetActive (false);
		VRbutton.SetActive (false);
	}

	public void vronclick(){
		StartCoroutine (VRLoadingscreen(VrToLoad));
		ARbutton.SetActive (false);
		VRbutton.SetActive (false);
	}

	IEnumerator ARLoadingscreen(string level){
		screen.SetActive (true);
		loadingbar.value = loadProgress;
		loadlable.text = "Loading..." + loadProgress + "%";
		AsyncOperation async = Application.LoadLevelAsync (level);
		while (!async.isDone) {
			Debug.Log ("LOAD" + (float)(async.progress - 0.4));
			loadProgress = (int)(async.progress * 100);
			loadlable.text = "Loading..." + loadProgress + "%";
			loadingbar.value = async.progress;
			yield return null;
		}
	}
		IEnumerator VRLoadingscreen(string level){
			screen.SetActive (true);
			loadingbar.value = loadProgress;
			loadlable.text="Loading..."+loadProgress+"%";
			AsyncOperation async = Application.LoadLevelAsync (level);
			while (!async.isDone) {
				Debug.Log("LOAD"+(float)(async.progress-0.4));
				loadProgress = (int)(async.progress*100);
				loadlable.text="Loading..."+loadProgress+"%";
				loadingbar.value = async.progress;
				yield return null;
			}
	}
}
