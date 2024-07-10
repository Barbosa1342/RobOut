using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bloco1 : ObjInteragivel
{
    bool movendo = false;
    Rigidbody2D rg;
    private void Awake() {
        rg = GetComponent<Rigidbody2D>();
    }
    private void Update() {
        if (getPlayerPerto()){
            Acao();
        }else{
            movendo = false;
        }
        
        if (movendo){
            rg.constraints = RigidbodyConstraints2D.None;
            rg.constraints = RigidbodyConstraints2D.FreezeRotation;
        }else{
            rg.constraints = RigidbodyConstraints2D.FreezeAll;
        }
        
    }

    override public void Acao(){
        if (Input.GetKeyDown(KeyCode.E)){
            movendo = !movendo;
        }
    }
}
