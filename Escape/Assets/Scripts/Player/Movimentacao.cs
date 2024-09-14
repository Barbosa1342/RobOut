using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimentacao : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] float velocidade = 2.5f;
    [SerializeField] float forcaPulo = 15; //Deixei a gravity Scale do Jogador l� no rigidbody2D em 5
    public bool pode_andar; //nao precisa ser publica
    [SerializeField] Transform detecta_chao;
    [SerializeField] LayerMask layer_chao;
    [SerializeField] LayerMask layer_player;

    bool andando;

    public bool GetAndando(){
        return andando;
    }

    public bool GetPodeAndar(){
        return pode_andar;
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        pode_andar = gameObject.GetComponent<Troca>().GetPodeAndar();
        if (Input.GetKey(KeyCode.W) && estaNoChao() && pode_andar)
        {
            Pular(forcaPulo);
        }
        if (Input.GetKey(KeyCode.D) && pode_andar)
        {
            Andar(velocidade);
            andando = true;
        }
        if (Input.GetKey(KeyCode.A) && pode_andar)
        {
            Andar(-velocidade);
            andando = true;
        }
        if ((Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.A)) || !pode_andar)
        {
            Parar();
            andando = false;
        }

    }


    void Andar(float velocidade)
    {
        rb.velocity = new Vector2(velocidade, rb.velocity.y);
    }


    void Pular(float forcaPulo)
    {
        rb.velocity = new Vector2(rb.velocity.x, forcaPulo);
    }


    public void Parar()
    {
        rb.velocity = new Vector2(0, rb.velocity.y);
    }

    public bool estaNoChao()
    {
        // evita pulo duplo
        // checar numeros <= 0 pode resultar em erros de imprecisao (ex: velocity.y = 1E-7)
        if (!(rb.velocity.y >= 0.01f))
        {
            //"cria" um circulo no objeto esta no chao criado
            Collider2D[] colliders = Physics2D.OverlapCircleAll(detecta_chao.position, 0.1f, layer_chao | layer_player);

            //Verifica o raio desse circulo
            for (int i = 0; i < colliders.Length; i++)
            {
                //Confere para ver se o objeto e o player, pois se for nao vai retornar que e o chao
                if (colliders[i].gameObject != gameObject)
                {
                    //Se o objeto nao for o proprio player retorna verdadeiro para esta no chao
                    return true;
                }
            }
        }
        //Caso as verificacoes nao sejam atendidas retorna falso, ou seja, player nao esta no chao
        return false;
    }
}

