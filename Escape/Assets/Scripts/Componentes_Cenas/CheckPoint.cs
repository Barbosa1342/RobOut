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

    private void OnEnable() {
        GerenciadorCheckPoint.RegistraCheckPoint(indice, transform);
    }

    private void OnDisable() {
        GerenciadorCheckPoint.RemoveCheckPoint(indice);
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
        if (ativando){
            anim.Play("CheckPoint");    
        }else{
            anim.Play("CheckPointDesativando");
        }
        
    }
}
