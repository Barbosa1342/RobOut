using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CientistaAnim : MonoBehaviour
{
    Rigidbody2D rg;
    [SerializeField] Animator anim;
    Movimentacao movimentacaoScript;
    private SpriteRenderer sprite;
    void Awake()
    {
        rg = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        movimentacaoScript = GetComponent<Movimentacao>();
    }

    void Update()
    {
        // Apenas altera as animacoes quando o personagem esta ativo
        // Do contrario, fica na animacao de Idle (parado)
        if (movimentacaoScript.GetPodeAndar()){
            if (movimentacaoScript.GetAndando()){
                anim.SetBool("andando", true);
            }else{
                anim.SetBool("andando", false);
            }
            
            if (Input.GetAxisRaw("Horizontal") > 0.1f){
                    sprite.flipX = false;
                }else if(Input.GetAxisRaw("Horizontal") < -0.1f){
                    sprite.flipX = true;
            }

            // Você pode apertar mesmo fora de um botao
            if (Input.GetKeyDown(KeyCode.E)){
                anim.SetBool("apertando", true);
            }
        }else{
            anim.SetBool("andando", false);
            anim.SetBool("apertando", false);
        }
    }

    // funcao esta sendo usada no Event da animacao
    // dentro do Inspect da animacao
    public void Apertando(int fim){
        if (fim == 1){
            anim.SetBool("apertando", false);
        }
    }
}
