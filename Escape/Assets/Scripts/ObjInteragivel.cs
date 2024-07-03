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
}
