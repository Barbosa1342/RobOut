using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cientista : Personagens
{
    private GameObject Robo;
    private BoxCollider2D colliderCientista, colliderRobo;
    private Collider2D colliderBloco,colliderPaper,colliderBotao,colliderPainel;

    private bool possivelIntPapel = false,possivelIntBotao=false,possivelIntPainel=false;

    public override void Start()
    {
        base.Start();
        Robo = GameObject.Find("Robo");
        colliderCientista = GetComponent<BoxCollider2D>();
        colliderRobo = Robo.GetComponent<BoxCollider2D>();
        Physics2D.IgnoreCollision(colliderCientista,colliderRobo,true);
    }

    public override void Update()
    {
        base.Update();

        if(possivelIntBotao || possivelIntBotao || possivelIntPapel)
            BotaoGuia.SetActive(true);
        else
            BotaoGuia.SetActive(false);

        if(Input.GetKeyDown(KeyCode.R))
        {
            Change();
        }
        if(Input.GetKeyDown(KeyCode.E))
        {
            if(possivelIntBotao)
                interacaoBotao(colliderBotao);
            else if(possivelIntPainel)
                interacaoPainel(colliderPainel);
            else if(possivelIntPapel)
                interacaoPapel(colliderPaper);
        }

    }

    protected override void MoverComTeclas()
    {
        Mover();
        Virar(MovimentoHoriz);
    }

    void interacaoPapel(Collider2D colisor)
    {
        colisor.GetComponent<Papel>().ativar();
    }

    void interacaoBotao(Collider2D colisor)
    {
        colisor.GetComponent<Botao>().interagirBotao();
    }

    void interacaoPainel(Collider2D colisor)
    {
        colisor.GetComponent<Painel>().interagirPainel();
    }

    public void Change()
    {
        rb.velocity = new Vector2(0f,0f);
        animacao.SetFloat("velocity",Mathf.Abs(rb.velocity.x));
        animacao.SetFloat("velocityY",rb.velocity.y);
        BotaoGuia.SetActive(false);
        Robo.GetComponent<Robo>().enabled = true;
        rb.GetComponent<Cientista>().enabled = false;
    
    }

    protected void OnTriggerEnter2D(Collider2D colisor)
    {
        if(colisor.gameObject.tag == "papel")
        {
            possivelIntPapel = true;
            colliderPaper = colisor;
        }

        if(colisor.gameObject.tag == "Botao")
        {
            possivelIntBotao = true;
            colliderBotao = colisor;
        }

        if(colisor.gameObject.tag == "Painel")
        {
            possivelIntPainel = true;
            colliderPainel = colisor;
        }
    }

    protected void OnTriggerExit2D(Collider2D colisor)
    {
        if(colisor.gameObject.tag == "papel")
        {
            possivelIntPapel = false;
        }
        if(colisor.gameObject.tag == "Botao")
        {
            possivelIntBotao = false;
        }
        if(colisor.gameObject.tag == "Painel")
        {
            possivelIntPainel = false;
        }
    }

    

    void OnDrawGizmos()
    {
        Gizmos.DrawSphere(TrChao.position, raioCh);
    }


}
