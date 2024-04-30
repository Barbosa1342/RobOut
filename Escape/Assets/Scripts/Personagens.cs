using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Rigidbody2D))]

public abstract class Personagens : MonoBehaviour
{
    public GameObject BotaoGuia;

    public bool direcaoRosto = false;
    protected float velocidade = 2.5f;
    protected float MovimentoHoriz;

    protected Rigidbody2D rb;
    protected Animator animacao;

    private LayerMask LMChao;
    public Transform TrChao;
    public float raioCh;
    public bool noChao;

    public float intervaloDePulo;
    private float contadorPulo = 1;
    private bool parouDePular; 
    public float forcaPulo;  


    public virtual void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animacao = GetComponent<Animator>();

        LMChao = LayerMask.GetMask("chao");

    }

    public virtual void Update()
    {
        MovimentoHoriz=Input.GetAxis("Horizontal");
        noChao = Physics2D.OverlapCircle(TrChao.position,raioCh,LMChao);

        contadorPulo = intervaloDePulo;
        if(noChao){
            if(Input.GetButtonDown("Jump") && rb.velocity.y <= 0.2f)
            {
                rb.velocity = new Vector2(rb.velocity.x,forcaPulo);
                parouDePular = false;
            }

            if(Input.GetButton("Jump") && !parouDePular && (contadorPulo > 0) && rb.velocity.y <= 0.2f)
            {
                rb.velocity = new Vector2(rb.velocity.x,forcaPulo);
                contadorPulo -= Time.fixedDeltaTime;
            }

            if(Input.GetButtonUp("Jump") && !parouDePular)
            {
                contadorPulo = 0;
                parouDePular = true;
            }
        }
    }

    public virtual void FixedUpdate()
    {
        MoverComTeclas();
        animacao.SetFloat("velocity",Mathf.Abs(rb.velocity.x));
        animacao.SetFloat("velocityY",rb.velocity.y);
        if(!noChao)
            animacao.SetLayerWeight(1,1);
        else
            animacao.SetLayerWeight(1,0);

    }


    protected void Mover()
    {
        rb.velocity = new Vector2(MovimentoHoriz*velocidade,rb.velocity.y);
    }

    protected virtual void MoverComTeclas()
    {
        Mover();
    }

    protected void Virar(float MovimentoHoriz)
    {
        if((MovimentoHoriz<0 && !direcaoRosto) || (MovimentoHoriz > 0 && direcaoRosto))
        {
            direcaoRosto = !direcaoRosto;
            transform.localScale = new Vector2(transform.localScale.x*-1,transform.localScale.y);
            if(direcaoRosto)
                BotaoGuia.GetComponent<SpriteRenderer>().flipX = true;
            else
                BotaoGuia.GetComponent<SpriteRenderer>().flipX = false;
        }
    }

    public void mudaVelocidade(float x)
    {
        velocidade += x;
    }
}
