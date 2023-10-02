using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleParent : MonoBehaviour
{
    public bool s;
    public GameObject objP, objS;
    public void setParent() { objP.SetActive(s); }
    public void setChild() { objS.SetActive(s); }
}
