using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Effect_Letter : MonoBehaviour
{ 
    private Text dialogo;
    private string frase;
    public bool skip = false;


    private void Awake()
    {
        dialogo = transform.GetComponent<Text>();
        frase = dialogo.text;
        dialogo.text = "";
    }

    private void OnEnable()
    {
        StartCoroutine(Reloj());
    }

    public void Iniciar(string f)
    {
        frase = f;
        StartCoroutine(Reloj());
    }

    public void Skipped()
    {
        skip = true;
    }

    IEnumerator Reloj()
    {
        
        foreach (char caracter in frase)
        {
            if (skip)
                break;

            dialogo.text = dialogo.text + caracter;

            yield return new WaitForSeconds(0.06f);
            
        }
        dialogo.text = frase;
    }
}
