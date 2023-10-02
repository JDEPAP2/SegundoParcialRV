using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System;
using TMPro;
using FantomLib;

public class HandleResponse : MonoBehaviour
{
    [SerializeField] private HandlerCht assitent;
    [SerializeField] private TextMeshProUGUI txt;
    [SerializeField] private TextToSpeechController controller;

    [Serializable]
    public struct VoiceCommand
    {
        public string keyword;
        public UnityEvent response;
    }

    public VoiceCommand[] voiceCommand;

    private Dictionary<string, UnityEvent> commands = new Dictionary<string, UnityEvent>();
 

    private void Awake()
    {

        foreach (var command in voiceCommand)
        {
            commands.Add(command.keyword.ToLower(), command.response);
        }
    }


    public void OnFinalSpeechResult(string resultado)
    {
        resultado = resultado.ToLower();
        if (resultado != null)
        {
            foreach(var res in resultado.Split(","))
            {
                UnityEvent respuesta = getResult(res);
                if (respuesta != null)
                {
                    respuesta?.Invoke();
                    break;
                }
                else if (resultado != "")
                {
                    assitent.EnviarSolicitudAOpenAI(resultado);
                    break;
                }
            }
        }
    }

    public UnityEvent getResult(string resultado)
    {
        UnityEvent respuesta = null;
        foreach (string key in commands.Keys)
        {
            if (key.Contains(resultado) || resultado.Contains(key))
            {
                respuesta = commands[key];
            }
        }
        return respuesta;
    }

    public void SpeechResult(string mess)
    {
        controller.StartSpeech(mess);
        txt.text = mess;
    }
}
