using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using FantomLib;

public class RobotLogic : MonoBehaviour
{

    [SerializeField] private AnimController anim;
    [SerializeField] private TextToSpeechController test;

    public void SayHello()
    {
        StartCoroutine(Intro());
    }


    private IEnumerator Intro()
    {
        anim.SetTrueAnim("isHello");
        yield return new WaitForSeconds(7f);
        anim.SetFalseAnim("isHello");
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
    }


}
