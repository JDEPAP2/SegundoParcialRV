using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AjustarRot : MonoBehaviour
{
    public void Ajustar()
    {
        transform.LookAt(Camera.main.transform);
    }
}
