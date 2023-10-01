using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AjustarRot : MonoBehaviour
{
    public void Ajustar()
    {
        transform.rotation = Quaternion.Euler(0, Camera.current.transform.rotation.eulerAngles.y -180, 0);
    }
}
