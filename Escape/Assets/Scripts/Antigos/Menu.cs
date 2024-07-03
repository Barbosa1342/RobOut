using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public string proximaCena;
   
    public void GoTo()
    {
        SceneManager.LoadScene(proximaCena);
    }

    public void Quit()
    {
        Debug.Log("saiu do jogo");
        Application.Quit();
    }

}
