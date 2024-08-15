using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using UnityEngine.UIElements;

public class VisaoInimigo : MonoBehaviour
{
    //Variaveis para definir o alcance de visao do rato e fazer ele identificar o cientista
    [SerializeField] float raio_visao;
    [SerializeField] Transform campo_visao;
    [SerializeField] LayerMask layer_player;

    //Variaveis para calcular a velocidade do rato e a posicao do player
    [SerializeField] private Rigidbody2D rb_rato;
    [SerializeField] Transform alvo;
    [SerializeField] private float velocidade;

    void Start()
    {
        //Definindo rigidbody rato
        rb_rato = GetComponent<Rigidbody2D>();
    }


    void Update()
    {

        //se detectaplayer for verdadeiro e a tag for diferente do robo, rato segue cientista
        if (DetectaPlayer())
        {
            Andar(velocidade);
        }

        //se detecta player for falso e a tag for igual a do rovo, rato fica parado 
        if (!DetectaPlayer()){
            Parar();
        }
    }

    void Andar(float velocidade_player)
    {
        Vector2 posicao_alvo = this.alvo.position;
        Vector2 posicao_rato = this.transform.position;
        Vector2 direcao = posicao_alvo - posicao_rato;
        direcao = direcao.normalized;
        this.rb_rato.velocity = (this.velocidade * direcao);
    }

    void Parar()
    {
        rb_rato.velocity = new Vector2(0,0);
    }
    private bool DetectaPlayer()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(campo_visao.position, raio_visao, layer_player);
        for (int i = 0; i < colliders.Length; i++)
            {
                if (colliders[i].gameObject != gameObject)
                {
                return true;
                }
        }
        //Caso as verifica��es n�o sejam atendidas retorna falso, ou seja, player n�o esta no ch�o
        return false;
    }
}