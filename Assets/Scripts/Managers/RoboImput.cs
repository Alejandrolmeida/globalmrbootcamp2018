using HoloToolkit.Unity.InputModule;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.WSA;

public class RoboImput : MonoBehaviour, IInputClickHandler
{
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void OnInputClicked(InputClickedEventData eventData)
    {
        if (HolographicSettings.IsDisplayOpaque)
        {
            RobotMgr.instance.dialogMgr.activo = true;
            RobotMgr.instance.dialogMgr.DictationProcess("Hola machote");
        }
        eventData.Use(); // Mark the event as used, so it doesn't fall through to other handlers.
    }
}
