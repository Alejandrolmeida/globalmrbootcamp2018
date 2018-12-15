using HoloToolkit.Unity.InputModule;
using UnityEngine;
using UnityEngine.XR.WSA;

public class MyRobotInput : MonoBehaviour, IInputClickHandler
{

    public void OnInputClicked(InputClickedEventData eventData)
    {
        if (HolographicSettings.IsDisplayOpaque)
        {
            MyRobotMgr.instance.dialogMgr.activo = true;
            MyRobotMgr.instance.dialogMgr.DictationProcess("Hola machote");
        }
        eventData.Use(); // Mark the event as used, so it doesn't fall through to other handlers.
    }
}