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
        achaPersonagem("Cientista");
        moveScript = personagem.GetComponent<Movimentacao>();
    }


    public void setPosicaoSenha(int posicao){
        posicaoSenha = posicao;
    }

    public int getPosicaoSenha(){
        return posicaoSenha;
    }

    private void Update() {
        if (getPlayerPerto()){
            if (moveScript.GetPodeAndar()){
                Acao();
            }else{
                Ativar(false);
            }
        }
    }

    override public void Acao(){
        if (Input.GetKeyDown(KeyCode.E)){
            if (folhaSenha.activeSelf){
                Ativar(false);
            }else{
                Ativar(true);
            }
        }
    }

    public void Ativar(bool ativo){
        if (ativo){
            folhaSenha.SetActive(true);
            scriptGerenciador.ativar(getPosicaoSenha());
        }else{
            folhaSenha.SetActive(false);
            scriptGerenciador.desativar(getPosicaoSenha());
        }
    }

    override public void OnTriggerEnter2D(Collider2D collider){
        if (collider.CompareTag("Cientista"))
        {
            setPlayerPerto(true);
            collider.GetComponent<CientistaInteracao>().setGuia(true);
        }
    }

    override public void OnTriggerExit2D(Collider2D collider){
        if (collider.CompareTag("Cientista"))
        {
            setPlayerPerto(false);
            collider.GetComponent<CientistaInteracao>().setGuia(false);
            Ativar(false);
        }        
    }
}
