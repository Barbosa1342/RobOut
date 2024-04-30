using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitch : MonoBehaviour
{
    public string fase;

    void OnTriggerEnter2D()
    {
        SceneManager.LoadScene(fase);
    }
}
