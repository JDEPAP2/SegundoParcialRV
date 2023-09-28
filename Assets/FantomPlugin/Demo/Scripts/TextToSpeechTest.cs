﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;
using FantomLib;

// Android Text To Speech Demo
// http://fantom1x.blog130.fc2.com/blog-entry-275.html
public class TextToSpeechTest : MonoBehaviour
{

    public string txt;
    public string language;
    public float speakPicthStep = 0.25f;    //Text reading pitch step
    public float speakSpeedStep = 0.25f;    //Text reading speed step



    // Use this for initialization
    private void Start()
    {
#if UNITY_EDITOR
        Debug.Log("InitSpeechRecognizer");
#elif UNITY_ANDROID
        AndroidPlugin.InitTextToSpeech(language, "OnStatus"); //Check the initialize status
#endif
    }

    // Update is called once per frame
    //private void Update () {

    //}



    //Reading text currently displayed (for button)
    public void PlayTextToSpeech()
    {
        if (txt != null && !string.IsNullOrEmpty(txt))
            StartTextToSpeech(txt);
    }


    //Start Text To Speech
    public void StartTextToSpeech(string message)
    {
#if UNITY_EDITOR
        Debug.Log("StartTextToSpeech : message = " + message);
        if (!string.IsNullOrEmpty(message))
            StartCoroutine(DebugSimulate());
#elif UNITY_ANDROID
        AndroidPlugin.StartTextToSpeech(message, language, "OnStatus", "OnStart", "OnDone", "OnStop");
#endif
    }


    //Text To Speech status callback handler
    private void OnStatus(string message)
    {
#if UNITY_EDITOR
        Debug.Log("OnStatus");
#endif

        if (txt != null)
        {
            if (message.StartsWith("SUCCESS_INIT"))
                txt += "\nText To Speech is available.";
            else if (message.StartsWith("ERROR_LOCALE_NOT_AVAILABLE"))
                txt += "\nFailed to initialize Text To Speech. It is a language that can not be used.";
            else if (message.StartsWith("ERROR_INIT"))
                txt += "\nFailed to initialize Text To Speech.";
        }
    }

    //Callback handler when start reading text
    private void OnStart(string message)
    {
#if UNITY_EDITOR
        Debug.Log("OnStart");
#endif
    }

    //Callback handler when finish reading text
    private void OnDone(string message)
    {
#if UNITY_EDITOR
        Debug.Log("OnDone");
#endif

    }

    //Callback handler when interrupted reading text
    private void OnStop(string message)
    {
#if UNITY_EDITOR
        Debug.Log("OnStop");
#endif

    }


    //Interrupted reading text
    public void StopTextToSpeech()
    {
#if UNITY_EDITOR
        Debug.Log("StopTextToSpeech called");
#elif UNITY_ANDROID
        AndroidPlugin.StopTextToSpeech();
#endif
    }


#if UNITY_EDITOR
    //For debug (Editor only)
    private IEnumerator DebugSimulate()
    {
        OnStart("onStart");
        yield return new WaitForSeconds(3f);

        OnDone("onDone");
    }
#endif


    //Increase utterance speed of Text To Speech
    public void SpeakSpeedUp()
    {
#if UNITY_EDITOR
        Debug.Log("SpeakSpeedUp called");
#elif UNITY_ANDROID
        SetSpeedText(AndroidPlugin.AddTextToSpeechSpeed(speakSpeedStep));
#endif
    }


    //Decrease utterance speed of Text To Speech
    public void SpeakSpeedDown()
    {
#if UNITY_EDITOR
        Debug.Log("SpeakSpeedDown called");
#elif UNITY_ANDROID
        SetSpeedText(AndroidPlugin.AddTextToSpeechSpeed(-speakSpeedStep));
#endif
    }


    //Reset utterance speed of Text To Speech (1.0f)
    public void SpeakSpeedReset()
    {
#if UNITY_EDITOR
        Debug.Log("SpeakSpeedReset called");
#elif UNITY_ANDROID
        SetSpeedText(AndroidPlugin.ResetTextToSpeechSpeed());
#endif
    }


    //Increase utterance pitch of Text To Speech
    public void SpeakPitchUp()
    {
#if UNITY_EDITOR
        Debug.Log("SpeakPitchUp called");
#elif UNITY_ANDROID
        SetPitchText(AndroidPlugin.AddTextToSpeechPitch(speakPicthStep));
#endif
    }


    //Decrease utterance pitch of Text To Speech
    public void SpeakPitchDown()
    {
#if UNITY_EDITOR
        Debug.Log("SpeakPitchDown called");
#elif UNITY_ANDROID
        SetPitchText(AndroidPlugin.AddTextToSpeechPitch(-speakPicthStep));
#endif
    }


    //Reset utterance pitch of Text To Speech (1.0f)
    public void SpeakPitchReset()
    {
#if UNITY_EDITOR
        Debug.Log("SpeakPitchReset called");
#elif UNITY_ANDROID
        SetPitchText(AndroidPlugin.ResetTextToSpeechPitch());
#endif
    }



    //Display utterance speed
    private void SetSpeedText(float speed)
    {

    }

    //Display utterance pitch
    private void SetPitchText(float pitch)
    {

    }



    //Call the text edit Dialog
    public void EditText()
    {
        if (txt != null)
        {
#if UNITY_EDITOR
            Debug.Log("EditText called");
#elif UNITY_ANDROID
            AndroidPlugin.ShowMultiLineTextDialog("Edit text", txt, 0, 9, txt, "OnEditText");
#endif
        }
    }

    //Callback handler in text edit Dialog
    private void OnEditText(string message)
    {
        if (txt != null)
            txt = message.Trim();
    }

}
