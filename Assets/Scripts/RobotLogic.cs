using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using FantomLib;

public class RobotLogic : MonoBehaviour
{

    [SerializeField] private AnimController anim;
    [SerializeField] private TextToSpeechController test;
    private bool first = true;

    public void SayHello()
    {
        if (first)
        {
            StartCoroutine(Intro());
            first = false;
        }
    }


    private IEnumerator Intro()
    {
        anim.SetTrueAnim("isHello");
        string ms = "Hola, Soy Guato! \nEs un gusto, para interactuar conmigo presiona el micrófono. Responderé cualquier pregunta.";
        test.StartSpeech(ms);
        var txt = GameObject.Find("MensajePanel");
        if(txt != null)
        {
            var tm = txt.GetComponent<TextMeshProUGUI>();
            if( tm != null)
            {
                tm.text = ms;
            }
        }
        yield return new WaitForSeconds(8f);
        anim.SetFalseAnim("isHello");
    }


}
