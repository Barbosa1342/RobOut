using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoboAnim : MonoBehaviour
{  
    Rigidbody2D rg;
    [SerializeField] Animator anim;
    Movimentacao movimentacaoScript;

    bool empurrando;
    bool atirando;
    private SpriteRenderer sprite;
   

    public void setEmpurrando(bool estaEmpurrando){
        empurrando = estaEmpurrando;
    }

    public void setAtirando(bool estaAtirando){
        atirando = estaAtirando;
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
            anim.SetBool("atirando", atirando);
            
            if(!atirando){
                if (movimentacaoScript.GetAndando()){
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
            }            
        }else{
            anim.SetBool("andando", false);
        }

        anim.SetBool("empurrando", empurrando);
    }
}