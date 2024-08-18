using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjInteragivel : MonoBehaviour
{
    private bool playerPerto;
    protected GameObject personagem;
    protected Movimentacao moveScript;

    // definir o personagem por script facilita a reutilizacao do objeto
    // pelo Inspetor seria muito repetitivo
    protected void achaPersonagem(string nomePersonagem){
        personagem = GameObject.FindGameObjectWithTag(nomePersonagem);
    }

    public void setPlayerPerto(bool perto){
        playerPerto = perto;
    }

    public bool getPlayerPerto(){
        return playerPerto;
    }

    virtual public void Acao(){
    }

    virtual public void OnTriggerEnter2D(Collider2D collider){
        if (collider.CompareTag("Cientista") || collider.CompareTag("Robo"))
        {
            playerPerto = true;
        }
    }

    virtual public void OnTriggerExit2D(Collider2D collider){
        if (collider.CompareTag("Cientista") || collider.CompareTag("Robo"))
        {
            playerPerto = false;
        }        
    }
}
