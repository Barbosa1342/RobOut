using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu1 : MonoBehaviour
{
    [SerializeField] string nomeFase;
    [SerializeField] string creditos;
    public void Jogar()
    {
        SceneManager.LoadScene(nomeFase);
    }

    public void Creditos()
    {
        SceneManager.LoadScene(creditos);
    }

    public void Sair()
    {
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #endif
        Application.Quit();
    }   
}
