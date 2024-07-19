using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjInteragivel : MonoBehaviour
{
    bool playerPerto;

    public void setPlayerPerto(bool perto){
        playerPerto = perto;
    }

    public bool getPlayerPerto(){
        return playerPerto;
    }

    virtual public void Acao(){
    }

    virtual public void OnTriggerEnter2D(Collider2D collider){
        if (collider.tag == "Cientista" || collider.tag == "Robo"){
            playerPerto = true;
        }
    }

    virtual public void OnTriggerExit2D(Collider2D collider){
        if (collider.tag == "Cientista" || collider.tag == "Robo"){
            playerPerto = false;
        }        
    }
}
