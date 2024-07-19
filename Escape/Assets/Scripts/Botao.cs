using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Botao1 : ObjInteragivel
{
    [SerializeField] GameObject porta;
    
    private void Update() {
        if (getPlayerPerto()){
            Acao();
        }
    }

    override public void Acao(){
        if (Input.GetKeyDown(KeyCode.E)){
            if (porta.activeSelf){
                porta.SetActive(false);
            }else{
                porta.SetActive(true);
            }
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
        }        
    }
}