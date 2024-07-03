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
        }else{
            if(painel.activeSelf){
                painel.SetActive(false);
            }
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
}
