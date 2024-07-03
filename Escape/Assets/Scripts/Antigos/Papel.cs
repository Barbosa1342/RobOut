using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Papel : MonoBehaviour
{
    public GameObject numero_senha,folha;


    public void ativar()
    {
        folha.SetActive(true);
        numero_senha.SetActive(true);
    }
    
    public void desativar()
    {
        folha.SetActive(false);
        numero_senha.SetActive(false);
    }

    protected void OnTriggerExit2D(Collider2D colisor)
    {
        desativar();
    }

}
