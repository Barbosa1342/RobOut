using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Botao : MonoBehaviour
{
    public GameObject Porta;

    public void interagirBotao()
    {
        GetComponent<Animator>().SetTrigger("pressionado");
        Porta.SetActive(false);
    }
}
