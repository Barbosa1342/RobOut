using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Papel1 : ObjInteragivel
{
    [SerializeField] GameObject folhaSenha;
    
    private void Update() {
        if (getPlayerPerto()){
            Acao();
        }else{
            Desativar();
        }
    }

    override public void Acao(){
        if (Input.GetKeyDown(KeyCode.E)){
            if (folhaSenha.activeSelf){
                folhaSenha.SetActive(false);
            }else{
                folhaSenha.SetActive(true);
            }
        }
    }

    public void Desativar(){
        if(folhaSenha.activeSelf){
            folhaSenha.SetActive(false);
        }
    }
}
