using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Botao1 : ObjInteragivel
{
    [SerializeField] GameObject porta;
    Porta scriptPorta;
    
    [SerializeField] AudioSource controladorSom;
    [SerializeField] AudioClip somPorta;

    bool podeInteragir;

    private void Update() {
        if (getPlayerPerto()){
            Acao();
        }
    }

    private void Start() {
        achaPersonagem("Cientista");
        moveScript = personagem.GetComponent<Movimentacao>();
        podeInteragir = true;
        scriptPorta = porta.GetComponent<Porta>();
    }

    override public void Acao(){
        if (Input.GetKeyDown(KeyCode.E)){
            if(moveScript.GetPodeAndar() && podeInteragir){
                StartCoroutine(InteragePorta());
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

    private IEnumerator InteragePorta(){
        podeInteragir = false;

        if (scriptPorta.GetAberta()){
            scriptPorta.AbrePorta(false);
        }else{
            scriptPorta.AbrePorta(true);
        }
        controladorSom.PlayOneShot(somPorta);

        yield return new WaitForSeconds(0.5f);

        podeInteragir = true;
    }
}