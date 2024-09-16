using UnityEngine;
using System.Collections.Generic;
using System;
using System.Collections;

public class Inimigo : MonoBehaviour
{
    // Variaveis para definir o alcance de visao do rato e fazer ele identificar o cientista
    [SerializeField] protected float raioVisao; // Raio para checar inimigos
    // [SerializeField] protected LayerMask layer_player; // Necessario para usar Overlapcircle
    [SerializeField] protected float velocidade; // Velocidade de Movimento
    

    protected Transform cientista;
    protected Transform robo;


    protected Rigidbody2D rbInimigo;

    //Variaveis para controle de animacao e giro da sprite
    protected Animator anim;
    protected SpriteRenderer sprite;


    protected bool patrulhando; // controle da corotina patrulha

    protected GameObject AchaPersonagem(string nomePersonagem){
        return GameObject.FindGameObjectWithTag(nomePersonagem);
    }

    virtual protected void Awake(){
        // Definindo rigidbody inimigo
        rbInimigo = GetComponent<Rigidbody2D>();
        // controlador de animacao
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
    }

    virtual protected void Start() {
        cientista = AchaPersonagem("Cientista").GetComponent<Transform>();
        robo = AchaPersonagem("Robo").GetComponent<Transform>();
        patrulhando = false;
    }

    virtual protected Vector2 DirecaoInimigoMaisProximo(){
        Vector3 inimigoPos = transform.position;
        Vector2 direcaoCientista = cientista.position - inimigoPos;
        Vector2 direcaoRobo = robo.position - inimigoPos;
        
        Vector2 direcao;
        if (direcaoCientista.x > direcaoRobo.x)
        {
            direcao = direcaoCientista;
        }
        else
        {
            direcao = direcaoRobo;
        }

        return direcao;
    }

    virtual protected void Andar(float velocidadeInimigo, Vector2 direcao){
        direcao = direcao.normalized;
        direcao.y = 0; // necessario pra ele nao flutuar
        rbInimigo.velocity = velocidade * direcao;

        if (rbInimigo.velocity.x >= 0.01f){
            sprite.flipX = false;
        }
        else if (rbInimigo.velocity.x <= -0.01f){
            sprite.flipX = true;
        }

        anim.SetBool("andando", true);
    }

    virtual protected void Parar(){
        rbInimigo.velocity = new Vector2(0, 0);
        anim.SetBool("andando", false);
    }

    virtual protected bool DetectaPlayer(Vector2 direcao){
        if (Math.Abs(direcao.x) < raioVisao){
            return true;
        }
        return false;
    }
    
    virtual protected IEnumerator Patrulha(){
        int escolha = UnityEngine.Random.Range(0, 2); // range entre 0 e 1

        Vector2 direcao;
        if (escolha == 0){
            direcao = Vector2.left;
            sprite.flipX = true;
        }
        else{
            direcao = Vector2.right;
            sprite.flipX = false;
        }

        rbInimigo.velocity = velocidade * direcao;
        anim.SetBool("andando", true);

        int tempo = UnityEngine.Random.Range(0, 2);
        
        yield return new WaitForSeconds(tempo);

        Parar();

        yield return new WaitForSeconds(tempo);

        patrulhando = false;
    }

    /*
    DetectaPlayer antigo
    virtual protected bool DetectaPlayer(){
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, raioVisao, layer_player);
        for (int i = 0; i < colliders.Length; i++)
        {
            // Ao inves de checar gameobject, valida se é cientista
            // Necessario pois cientista e robo tem a mesma layer
            if(colliders[i].CompareTag("Cientista") || colliders[i].CompareTag("Robo")){
                //rb_rato.gameObject.GetComponent<Ataque_Inimigo>().pode_atacar = true;
                return true;
            }
        }
        return false;
    }*/

}