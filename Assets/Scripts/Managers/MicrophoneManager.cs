using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows.Speech;

public class MicrophoneManager : MonoBehaviour {

    private int frequency = 48000;
    private AudioSource audioSource;        //AudioSource component, provides access to mic
    private DictationRecognizer dictationRecognizer;  //Component converting speech to text
    private string lastDictationCaptured = null;
    private bool capturing;

    void Start()
    {
        if (Microphone.devices.Length > 0)
        {
            audioSource = GetComponent<AudioSource>();
        }
    }
    /// <summary>
    /// Return if mic audio source it's ok,
    /// </summary>
    public bool IsMicAudioSourceAsigned()
    {
        if (audioSource != null)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    /// <summary>
    /// Return last Dictation Result
    /// </summary>
    public string GetLastDictation()
    {
        return lastDictationCaptured;
    }
    /// <summary>
    /// Return frecuency of mic
    /// </summary>
    public int GetFrequency()
    {
        return frequency;
    }
    /// <summary>
    /// Start microphone capture, by providing the microphone as a continual audio source (looping),
    /// then initialise the DictationRecognizer, which will capture spoken words
    /// </summary>
    public void StartCapturingAudio()
    {
        if (!capturing) {
            capturing = true;

            dictationRecognizer = new DictationRecognizer();
            dictationRecognizer.InitialSilenceTimeoutSeconds = 10;

            dictationRecognizer.DictationResult += (text, confidence) =>
            {
                Debug.LogFormat("Dictation result: {0}", text);
                lastDictationCaptured = text;
                MyRobotMgr.instance.dialogMgr.DictationProcess(text);

            };

            dictationRecognizer.DictationHypothesis += (text) =>
            {
                Debug.LogFormat("Dictation hypothesis: {0}", text);
            };

            dictationRecognizer.DictationComplete += (completionCause) =>
            {
                if (completionCause != DictationCompletionCause.Complete && completionCause != DictationCompletionCause.TimeoutExceeded)

                    if (completionCause == DictationCompletionCause.TimeoutExceeded)
                    {
                        Debug.LogWarning("time out");
                        StopCapturinAudio();
                        MyRobotMgr.instance.dialogMgr.DictationProcess("xxxxx");
                    }
            };

            dictationRecognizer.DictationError += (error, hresult) =>
            {
                Debug.LogErrorFormat("Dictation error: {0}; HResult = {1}.", error, hresult);
            };
            dictationRecognizer.Start();
        }
       
    }

    public void StopCapturinAudio()
    {
        capturing = false;
    }
}
