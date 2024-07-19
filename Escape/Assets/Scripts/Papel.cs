using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Papel1 : ObjInteragivel
{
    [SerializeField] GameObject folhaSenha;
    [SerializeField] GameObject gerenciador;
    private GerenciadorSenha scriptGerenciador;
    private int posicaoSenha;
    
    void Start(){
        scriptGerenciador = gerenciador.GetComponent<GerenciadorSenha>();
    }


    public void setPosicaoSenha(int posicao){
        posicaoSenha = posicao;
    }

    public int getPosicaoSenha(){
        return posicaoSenha;
    }

    private void Update() {
        if (getPlayerPerto()){
            Acao();
        }
    }

    override public void Acao(){
        if (Input.GetKeyDown(KeyCode.E)){
            if (folhaSenha.activeSelf){
                folhaSenha.SetActive(false);
                scriptGerenciador.desativar(getPosicaoSenha());
            }else{
                folhaSenha.SetActive(true);
                scriptGerenciador.ativar(getPosicaoSenha());
            }
        }
    }

    public void Desativar(){
        if(folhaSenha.activeSelf){
            folhaSenha.SetActive(false);
            scriptGerenciador.desativar(getPosicaoSenha());
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
            Desativar();
        }        
    }
}
