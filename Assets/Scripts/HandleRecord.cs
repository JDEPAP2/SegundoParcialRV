using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Android;
using KKSpeech;
public class HandleRecord : MonoBehaviour
{
    private void Awake()
    {
        SpeechRecognizer.SetDetectionLanguage("ES-es");
        if (!Permission.HasUserAuthorizedPermission(Permission.Microphone))
        {
            Permission.RequestUserPermission(Permission.Microphone);
        }
    }

    public void StartRecordng()
    {
        SpeechRecognizer.StartRecording(true);
    }

    public void StopRecordng()
    {
        SpeechRecognizer.StopIfRecording();
    }

}
