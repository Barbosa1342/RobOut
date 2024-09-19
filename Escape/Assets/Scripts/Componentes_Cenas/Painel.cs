using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Painel1 : ObjInteragivel
{
    [SerializeField] GameObject painel;
    [SerializeField] GameObject porta;
    Porta scriptPorta;

    [SerializeField] AudioSource controladorSom;
    [SerializeField] AudioClip somPorta;
    
    private void Update() {
        if (getPlayerPerto()){
            if (moveScript.GetPodeAndar()){
                Acao();
            }else{
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
        if (!scriptPorta.GetAberta()){
            if (painel.activeSelf){
                painel.SetActive(false);
            }
            scriptPorta.AbrePorta(true);
            controladorSom.PlayOneShot(somPorta);
        }
    }

    private void Start() {
        achaPersonagem("Cientista");
        moveScript = personagem.GetComponent<Movimentacao>();
        scriptPorta = porta.GetComponent<Porta>();
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
