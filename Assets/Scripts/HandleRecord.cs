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
        SetPermission();
    }

    public void StartRecordng()
    {
        if(!SpeechRecognizer.IsRecording())
            SpeechRecognizer.StartRecording(true);
    }

    public void StopRecordng()
    {
        SpeechRecognizer.StopIfRecording();
    }

    public void SetPermission()
    {
        if (!Permission.HasUserAuthorizedPermission(Permission.Microphone))
        {
            Permission.RequestUserPermission(Permission.Microphone);
        }
    }

}
