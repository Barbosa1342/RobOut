using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoboAnim : MonoBehaviour
{  
    Rigidbody2D rg;
    [SerializeField] Animator anim;
    Movimentacao movimentacaoScript;

    bool empurrando;
    private SpriteRenderer sprite;
   

    public void setEmpurrando(bool estaEmpurrando){
        empurrando = estaEmpurrando;
    }

    void Awake()
    {
        rg = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        movimentacaoScript = GetComponent<Movimentacao>();
    }

    // Update is called once per frame
    void Update()
    {
        if (movimentacaoScript.GetPodeAndar()){
            if (Mathf.Abs(rg.velocity.x) > 0.01f){
                anim.SetBool("andando", true);
            }else{
                anim.SetBool("andando", false);
            }

            if (!empurrando){
                if (Input.GetAxisRaw("Horizontal") > 0.1f){
                    sprite.flipX = false;
                }else if(Input.GetAxisRaw("Horizontal") < -0.1f){
                    sprite.flipX = true;
                }
            }

        }else{
            anim.SetBool("andando", false);
        }

        anim.SetBool("empurrando", empurrando);
    }
}