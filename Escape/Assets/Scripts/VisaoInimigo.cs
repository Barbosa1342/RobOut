using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using UnityEngine.UIElements;

public class VisaoInimigo : MonoBehaviour
{
    [SerializeField] float raio_visao;
    [SerializeField] Transform campo_visao;
    [SerializeField] LayerMask layer_player;
    [SerializeField] private Rigidbody2D rb_rato;
    [SerializeField] private float velocidade_player;

    // Start is called before the first frame update
    void Start()
    {
        rb_rato = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        velocidade_player = GetComponent<Movimentacao>().velocidade;
        if (DetectaPlayer())
        {
            Andar_teste(velocidade_player);
        }
        if (!DetectaPlayer()){
            Parar();
        }
    }

    void Andar_teste(float velocidade_player)
    {
        rb_rato.velocity = new Vector2(velocidade_player,rb_rato.velocity.y);
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ((collision.gameObject.tag == "Player" | collision.gameObject.tag == "Robo") && DetectaPlayer())
        {
            Andar_teste(-velocidade_player);
        }
    }
}