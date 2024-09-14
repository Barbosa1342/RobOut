using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    // Preencher a ordem de cada checkpoint
    // conforme a ordem no jogo
    [SerializeField] int indice;
    Animator anim;

    private void Awake() {
        anim = GetComponent<Animator>();
    }

    private void Start(){
        GerenciadorCheckPoint.RegistraCheckPoint(indice, transform);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Cientista") || other.CompareTag("Robo")){
            if(indice > GerenciadorCheckPoint.GetIndiceAtual()){
                GerenciadorCheckPoint.SetIndiceAtual(indice);
                Animacao(true);
            }
        }
    }

    public void Animacao(bool ativando){
        Debug.Log("AAA");
        if (ativando){
            anim.Play("CheckPoint");    
        }else{
            anim.Play("CheckPointDesativando");
        }
        
    }
}
