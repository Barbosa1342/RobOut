using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bloco1 : ObjInteragivel
{
    bool movendo = false;
    bool ultimoMove = false;
    [SerializeField] float velocidade;
    Rigidbody2D rg;
    private RoboAnim roboAnimator;

    private void Awake() {
        rg = GetComponent<Rigidbody2D>();
    }

    private void Start() {
        achaPersonagem("Robo");
        moveScript = personagem.GetComponent<Movimentacao>();
        roboAnimator = personagem.GetComponent<RoboAnim>();
    }

    private void Update() {
        if (getPlayerPerto()){
            if (moveScript.GetPodeAndar()){
                Acao();
            }else{
                movendo = false;
            }
        }else{
            movendo = false;
        }


        
        if (movendo){

            // mais correto fazer um mecanismo de puxar
            // mas assim funciona legal
            rg.constraints = RigidbodyConstraints2D.FreezeRotation;
            float movimentoHoriz = Input.GetAxisRaw("Horizontal");
            rg.velocity = new Vector2(movimentoHoriz * velocidade, rg.velocity.y);

            roboAnimator.setEmpurrando(movendo);
            ultimoMove = true;
        }else{
            rg.constraints = RigidbodyConstraints2D.FreezePositionX;
            rg.freezeRotation = true;

            // utilizando a variavel ultimoMove
            // apenas o bloco movimentado afeta "empurrando"
            if(ultimoMove == true){
                roboAnimator.setEmpurrando(movendo);
                ultimoMove = false;
            }
        }

        
    }

    override public void Acao(){
        if (Input.GetKeyDown(KeyCode.E)){
            movendo = !movendo;
        }
    }

    override public void OnTriggerEnter2D(Collider2D collider){
        if (collider.tag == "Robo"){
            setPlayerPerto(true);
            collider.GetComponent<RoboInteracao>().setGuia(true);
        }
    }

    override public void OnTriggerExit2D(Collider2D collider){
        if (collider.tag == "Robo"){
            setPlayerPerto(false);
            collider.GetComponent<RoboInteracao>().setGuia(false);
        }        
    }
}
