using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Painel : MonoBehaviour
{
    public GameObject PainelCanvas, Porta;
    public Text numeros;
    public string senha;

    private bool habilitado = false;

    void Update()
    {
        if(habilitado)
        {
            digitar();
            if(numeros.text.Length>=5)
            {
                if(numeros.text == senha)
                {
                    numeros.text = "Success!!";
                    StartCoroutine(success(1f));
                }
                else
                {   
                    numeros.text = "Error!!";
                    StartCoroutine(senhaErrada(1f));
                }
            }
        }
    }

    public void interagirPainel()
    {
        PainelCanvas.SetActive(true);
        habilitado = true;
    }
    
    public void desativar()
    {
        numeros.text = "";
        PainelCanvas.SetActive(false);
    }

    void digitar()
    {
        if(Input.GetKeyDown(KeyCode.Keypad0))
        {
            numeros.text = numeros.text + 0;
        }
        if(Input.GetKeyDown(KeyCode.Keypad1))
        {
            numeros.text = numeros.text + 1;
        }
        if(Input.GetKeyDown(KeyCode.Keypad2))
        {
            numeros.text = numeros.text + 2;
        }
        if(Input.GetKeyDown(KeyCode.Keypad3))
        {
            numeros.text = numeros.text + 3;
        }
        if(Input.GetKeyDown(KeyCode.Keypad4))
        {
            numeros.text = numeros.text + 4;
        }
        if(Input.GetKeyDown(KeyCode.Keypad5))
        {
            numeros.text = numeros.text + 5;
        }
        if(Input.GetKeyDown(KeyCode.Keypad6))
        {
            numeros.text = numeros.text + 6;
        }
        if(Input.GetKeyDown(KeyCode.Keypad7))
        {
            numeros.text = numeros.text + 7;
        }
        if(Input.GetKeyDown(KeyCode.Keypad8))
        {
            numeros.text = numeros.text + 8;
        }
        if(Input.GetKeyDown(KeyCode.Keypad9))
        {
            numeros.text = numeros.text + 9;
        }
        if(Input.GetKeyDown(KeyCode.Backspace))
        {
            numeros.text = "";
        }
    }

    private IEnumerator success(float s)
    {
        habilitado = false;
        yield return new WaitForSeconds(s);
        Porta.SetActive(false);
        desativar();
    }

    private IEnumerator senhaErrada(float s)
    {
        habilitado = false;
        yield return new WaitForSeconds(s);
        numeros.text = "";
        habilitado = true;
    }

    protected void OnTriggerExit2D(Collider2D colisor)
    {
        desativar();
    }

}
