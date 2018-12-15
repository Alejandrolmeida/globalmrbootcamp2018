using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotMgr : MonoBehaviour {

    public DialogMgr dialogMgr;
    public SpeechManager speechManager;
    public MicrophoneManager microphoneManager;
    public static RobotMgr instance;
    public bool speeching;

    private void Awake()
    {
        dialogMgr = GetComponent<DialogMgr>();
        speechManager = GetComponent<SpeechManager>();
        microphoneManager = GetComponent<MicrophoneManager>();
        instance = this;
    }

}
