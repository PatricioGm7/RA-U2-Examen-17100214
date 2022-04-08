/*==============================================================================
Copyright (c) 2021 PTC Inc. All Rights Reserved.

Confidential and Proprietary - Protected under copyright and other laws.
Vuforia is a trademark of PTC Inc., registered in the United States and other 
countries.
==============================================================================*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Vuforia;


/// <summary>
/// A custom handler that implements the ITrackableEventHandler interface.
///
/// Changes made to this file could be overwritten when upgrading the Vuforia version.
/// When implementing custom event handler behavior, consider inheriting from this class instead.
/// </summary>
public class CustomObserverEventHandler : DefaultObserverEventHandler
{

    public UnityEngine.UI.Image detectionImage;
    [Space]
    public Color colorFound;
    public Color colorLost;

    protected override void Start()
    {
        base.Start();
        //VuforiaApplication.Instance.OnVuforiaStarted += OnvuforiaStarted;
        VuforiaApplication.Instance.OnVuforiaPaused += OnPaused;
    }

    // Start is called before the first frame update
    public void OnVuforiaStarted()
    {
        VuforiaBehaviour.Instance.CameraDevice.SetFocusMode(
        FocusMode.FOCUS_MODE_CONTINUOUSAUTO);
        VuforiaBehaviour.Instance.CameraDevice.SetCameraMode(Vuforia.CameraMode.MODE_DEFAULT);
    }



    public void OnPaused(bool paused)
    {
        if (!paused) // Resumed
        {
            //Set again autofocus mode when app is resumed
            VuforiaBehaviour.Instance.CameraDevice.SetFocusMode(
            FocusMode.FOCUS_MODE_CONTINUOUSAUTO);
        }
    }

    protected override void OnTrackingFound()
    {
        base.OnTrackingFound();
        Debug.Log("<color=green><b>FOUND</b></color>");
        detectionImage.color = colorFound;
    }

    protected override void OnTrackingLost()
    {
       base.OnTrackingLost();
        Debug.Log("<color=red><b>LOST</b></color>");
        detectionImage.color = colorLost;
    }
    
}