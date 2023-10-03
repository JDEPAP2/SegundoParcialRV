using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class HandleIntro : MonoBehaviour
{
    public float time;
    public UnityEvent onInit;
    
    void Start()
    {
        StartCoroutine(str());
    }

    IEnumerator str()
    {
        yield return new WaitForSeconds(time);
        onInit?.Invoke();
    }
}
