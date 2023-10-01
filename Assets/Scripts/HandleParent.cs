using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleParent : MonoBehaviour
{
    public GameObject obj;
    public bool s;
    public void setParent() { obj.SetActive(s); }
}
