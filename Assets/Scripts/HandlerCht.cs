using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System.Text;
using FantomLib;
using TMPro;

public class HandlerCht : MonoBehaviour
{
    [SerializeField] private string apiKey;
    public TextMeshProUGUI txt;
    private string openAIEndpoint;

    private void Awake()
    {
        openAIEndpoint = "https://generativelanguage.googleapis.com/v1beta2/models/text-bison-001:generateText?key=" + apiKey;
    }
    public TextToSpeechController controller;

    public void EnviarSolicitudAOpenAI(string inputText)
    {
        StartCoroutine(EnviarSolicitud(inputText));
    }

    IEnumerator EnviarSolicitud(string inputText)
    {
        string jsonData = "{\"prompt\":{\"text\":" + "\"Eres un asistente de voz, te llamas Guato, de un centro comercial llamado UAO Mall, tu misión es ayudar al usuario y guiarlo a que pregunte cosas como los locales o las promociones, ya hay un código que responde esas preguntas. Responde con poco texto y sin saltos de linea. \n El usuario hizo la siguiente prompt: " + inputText + "\"}}";

        int intent = 0;
        while (intent < 5 )
        {
            UnityWebRequest request = UnityWebRequest.PostWwwForm(openAIEndpoint, jsonData);
            request.SetRequestHeader("Content-Type", "application/json");
            request.uploadHandler = new UploadHandlerRaw(Encoding.UTF8.GetBytes(jsonData));
            request.downloadHandler = new DownloadHandlerBuffer();
            yield return request.SendWebRequest();

            if (request.result == UnityWebRequest.Result.Success)
            {
                string responseJson = request.downloadHandler.text;
                
                if (responseJson.Contains("output"))
                {
                    int indx = responseJson.IndexOf("output");
                    string res = "";
                    for (int i = indx + 10; i <= responseJson.Length; i++)
                    {
                        if (responseJson[i].ToString() == "\"")
                        { break; }
                        Debug.Log(responseJson[i].ToString());
                        res += responseJson[i].ToString();
                    }
                    controller.StartSpeech(res);
                    txt.text = res;
                    break;
                }
                intent++;
            }
            else
            {
                Debug.Log(request.error);
                controller.StartSpeech("Intentalo de nuevo, deberias preguntar cosas relacionadas :)");
                txt.text = "Intentalo de nuevo, deberias preguntar cosas relacionadas :)";
                break;
            }
        }
        
        if(intent >= 5)
        {
            controller.StartSpeech("No te entendí");
            txt.text = "No te entendí";
        }
   
    }
}
