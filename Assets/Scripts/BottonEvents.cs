using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class BottonEvents : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{

    public UnityEvent OnHold;
    public UnityEvent OnUp;

    public void OnPointerDown(PointerEventData eventData)
    {
        OnHold?.Invoke();    }

    public void OnPointerUp(PointerEventData eventData)
    {
        OnUp?.Invoke();
    }

}
