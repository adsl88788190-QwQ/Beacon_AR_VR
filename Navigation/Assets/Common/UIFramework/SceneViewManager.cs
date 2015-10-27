/*============================================================================== 
 * Copyright (c) 2012-2014 Qualcomm Connected Experiences, Inc. All Rights Reserved. 
 * ==============================================================================*/

/// <summary>
/// All Initializations, Draw Calls and Update Calls go through here.
/// </summary>
using UnityEngine;
using System.Collections;
using Vuforia;

[RequireComponent(typeof( SampleInitErrorHandler ))]
public class SceneViewManager : MonoBehaviour {

	//public AppManager mAppManager 全數註解，解決起始畫面以及結束畫面，連帶解決畫面反轉問題
    
    //public AppManager mAppManager;
    //private SampleInitErrorHandler mPopUpMsg;

    private bool mErrorOccurred;

    void Awake()
    {
		/*
        mPopUpMsg = GetComponent<SampleInitErrorHandler>();
        if(!mPopUpMsg)
        {
            mPopUpMsg = gameObject.AddComponent<SampleInitErrorHandler>();
        }
        */

        // Check for an initialization error on start.
        VuforiaAbstractBehaviour vuforiaBehaviour = (VuforiaAbstractBehaviour)FindObjectOfType(typeof(VuforiaAbstractBehaviour));
        if (vuforiaBehaviour)
        {
            vuforiaBehaviour.RegisterVuforiaInitErrorCallback(OnVuforiaInitializationError);
        }
    }

    void Start () 
    {
        //mPopUpMsg.InitPopUp(); //註解以解決初始畫面顯示
        //mAppManager.InitManager();
    }
    
    void Update()
    {
        if (mErrorOccurred)
            return;

        InputController.UpdateInput();  
        //mAppManager.UpdateManager();
    }


    void OnDestroy()
    {
        VuforiaAbstractBehaviour vuforiaBehaviour = (VuforiaAbstractBehaviour)FindObjectOfType(typeof(VuforiaAbstractBehaviour));
        if (vuforiaBehaviour)
        {
            vuforiaBehaviour.UnregisterVuforiaInitErrorCallback(OnVuforiaInitializationError);
        }

		//mAppManager.DeInitManager(); 
    }

    
    void OnGUI () 
    {

        if (mErrorOccurred)
        {
            //mPopUpMsg.Draw();
        }
        else
        {
            //mAppManager.Draw();
        }
    }

    public void OnVuforiaInitializationError(VuforiaUnity.InitError initError)
    {
        if (initError != VuforiaUnity.InitError.INIT_SUCCESS)
        {
            mErrorOccurred = true;
            //mPopUpMsg.SetErrorCode(initError);
        }
    }
}
