using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System.Text;
using FantomLib;

public class HandlerChtGpt : MonoBehaviour
{
    private string apiKey = "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";
    private string openAIEndpoint = "https://api.openai.com/v1/chat/completions"; // El endpoint de la API de OpenAI
    public TextToSpeechController controller;

    public void EnviarSolicitudAOpenAI(string inputText)
    {
        StartCoroutine(EnviarSolicitud(inputText));
    }

    IEnumerator EnviarSolicitud(string inputText)
    {
        string jsonData = "{\"model\":\"gpt-3.5-turbo\", \"messages\":[" +
            "{\"role\":\"system\", \"content\":\"" + "Eres un asistente de voz, te llamas Guato, de un centro comercial llamado UAO Mall, tu mision es ayudar al usuario y guiarlo a que pregunte cosas como los locales o las promociones, ya hay un codigo que responde esas preguntas. No respondas con mucho texto, maximo un parrafo" + "\"}," +
            "{\"role\":\"user\", \"content\":\"" + inputText + "\"}" +
            "]}";

        UnityWebRequest request = UnityWebRequest.PostWwwForm(openAIEndpoint, jsonData);
        request.SetRequestHeader("Authorization", "Bearer " + apiKey);
        request.uploadHandler = new UploadHandlerRaw(Encoding.UTF8.GetBytes(jsonData));
        request.downloadHandler = new DownloadHandlerBuffer();

        yield return request.SendWebRequest();

        if (request.result == UnityWebRequest.Result.Success)
        {
            string responseJson = request.downloadHandler.text;
            controller.StartSpeech(responseJson);
        }
        else
        {
            Debug.LogError("Error al enviar la solicitud a OpenAI: " + request.error);
            controller.StartSpeech(request.error);
        }
    }
}
