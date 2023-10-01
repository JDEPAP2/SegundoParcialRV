using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System;
using TMPro;

public class HandleResponse : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI txtUI;

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

        if (resultado != null)
        {
            UnityEvent respuesta = null;
            foreach(string key in commands.Keys) {
                if (key.Contains(resultado.ToLower()) || resultado.ToLower().Contains(key))
                {
                    respuesta = commands[key];
                }
            }
            
            if (respuesta != null)
            {
                respuesta?.Invoke();
            }
            txtUI.text = resultado;
        }
    }
}