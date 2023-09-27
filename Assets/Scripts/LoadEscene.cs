using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LoadEscene : MonoBehaviour
{
    public void LoadByName(string name)
    {
        SceneManager.LoadScene(name);
    }
}
