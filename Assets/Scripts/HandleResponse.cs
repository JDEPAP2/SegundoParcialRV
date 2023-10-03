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
        public List<string> alternatives;
        public UnityEvent response;
    }

    public VoiceCommand[] voiceCommand;

    private Dictionary<string, UnityEvent> commands = new();
    private Dictionary<string, List<string>> alternatives = new();


    private void Awake()
    {

        foreach (var command in voiceCommand)
        {
            commands.Add(command.keyword.ToLower(), command.response);
            alternatives.Add(command.keyword.ToLower(), command.alternatives);
        }

    }


    public void OnFinalSpeechResult(string resultado)
    {
        resultado = resultado.ToLower();
        if (resultado != null)
        {
            UnityEvent respuesta = getResult(resultado);
            if (respuesta != null)
            {
                respuesta?.Invoke();
            }
            else if (resultado != "")
            {
                assitent.EnviarSolicitudAOpenAI(resultado);
            }
        }
    }

    public UnityEvent getResult(string resultado)
    {
        foreach(string key in alternatives.Keys)
        {
            foreach(string alter in alternatives[key])
            {
                if (resultado.Contains(alter))
                {
                    return commands[key];
                }
            }
        }
        return null;
    }

    public void SpeechResult(string mess)
    {
        controller.StartSpeech(mess);
        txt.text = mess;
    }
}
