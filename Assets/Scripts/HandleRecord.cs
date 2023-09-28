using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Android;
using KKSpeech;
public class HandleRecord : MonoBehaviour
{
    private void Awake()
    {
        GetPermissn();
    }

    public void StartRecordng()
    {
        GetPermissn();
        SpeechRecognizer.StartRecording(true);
    }

    public void StopRecordng()
    {
        SpeechRecognizer.StopIfRecording();
    }

    public void GetPermissn()
    {
        SpeechRecognizer.SetDetectionLanguage("ES-es");
        if (!Permission.HasUserAuthorizedPermission(Permission.Microphone))
        {
            Permission.RequestUserPermission(Permission.Microphone);
        }
    }

}
