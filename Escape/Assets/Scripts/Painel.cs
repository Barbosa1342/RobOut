using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Painel1 : ObjInteragivel
{
    [SerializeField] GameObject painel;
    [SerializeField] GameObject porta;
    
    private void Update() {
        if (getPlayerPerto()){
            Acao();
        }
    }

    override public void Acao(){
        if (Input.GetKeyDown(KeyCode.E)){
            if (painel.activeSelf){
                painel.SetActive(false);
            }else{
                painel.SetActive(true);
            }
        }
    }

    public void AbrirPorta(){
        if (porta.activeSelf){
            if (painel.activeSelf){
                painel.SetActive(false);
            }
            porta.SetActive(false);
        }
    }

    override public void OnTriggerEnter2D(Collider2D collider){
        if (collider.tag == "Cientista"){
            setPlayerPerto(true);
            collider.GetComponent<CientistaInteracao>().setGuia(true);
        }
    }

    override public void OnTriggerExit2D(Collider2D collider){
        if (collider.tag == "Cientista"){
            setPlayerPerto(false);
            collider.GetComponent<CientistaInteracao>().setGuia(false);

            if(painel.activeSelf){
                painel.SetActive(false);
            }
        }        
    }
}
