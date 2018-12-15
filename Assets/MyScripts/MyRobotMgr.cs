
using UnityEngine;

public class MyRobotMgr : MonoBehaviour
{

    public MyDialogMgr dialogMgr;
    public SpeechManager speechManager;
    public MicrophoneManager microphoneManager;
    public static MyRobotMgr instance;
    public bool speeching;

    private void Awake()
    {
        dialogMgr = GetComponent<MyDialogMgr>();
        speechManager = GetComponent<SpeechManager>();
        microphoneManager = GetComponent<MicrophoneManager>();
        instance = this;
    }
}
