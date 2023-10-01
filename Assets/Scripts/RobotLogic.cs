using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RobotLogic : MonoBehaviour
{
    [SerializeField]
    private AnimController anim;
    private TextToSpeechTest test;

    public void SayHello()
    {
        StartCoroutine(Intro());
    }

    public void SayReply(string message)
    {
        StartCoroutine(Reply(message));
    }

    private IEnumerator Intro()
    {
        anim.SetTrueAnim("isHello");
        yield return new WaitForSeconds(7f);
        anim.SetFalseAnim("isHello");
        string ms = "Hola, Soy Guato! \nEs un gusto, para interactuar conmigo presiona el micrófono. Responderé cualquier pregunta.";
        test.StartTextToSpeech(ms);
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

    private IEnumerator Reply(string message)
    {
        yield return new WaitForSeconds(3.5f);
        anim.SetFalseAnim("isHello");
        anim.SetFalseAnim("isLooking");
        test.StartTextToSpeech(message);
    }


}
