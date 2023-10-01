using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.ComponentModel;

public class AnimController : MonoBehaviour
{
    [SerializeField]
    private Animator anim;

    public void SetFalseAnim(String param)
    {
        anim.SetBool(param, false);
    }

    public void SetFalseAnimWithTime(String param)
    {
        StartCoroutine(Wait(param));
    }

    public void SetTrueAnim(String param)
    {
        anim.SetBool(param, true);
    }

    private IEnumerator Wait(string param)
    {
        yield return new WaitForSeconds(2f);
        anim.SetBool(param, false);
    }

}
