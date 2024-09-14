using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Porta : MonoBehaviour
{
    private Animator anim;
    private bool aberta;
    
    private void Awake() {
        anim = GetComponent<Animator>();
        aberta = false;
    }

    public bool GetAberta(){
        return aberta;
    }

    public void AbrePorta(bool taAbrindo){
        //false = fechando
        //true = abrindo

        if (taAbrindo){
            anim.Play("portaAbrindo");
            aberta = true;
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
        }
        else{
            anim.Play("portaFechando");
            aberta = false;
            gameObject.GetComponent<BoxCollider2D>().enabled = true;
        }
    }
}