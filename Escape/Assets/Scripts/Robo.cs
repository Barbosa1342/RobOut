using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Robo : Personagens
{
    private GameObject Cientista;
    private BoxCollider2D colliderCientista, colliderRobo;
    private Collider2D colliderBloco;
    
    private bool possivelIntBloco = false, possivelIntDrone = false;
    private bool movendoBloco = false;

    public Transform Bullet,BulletPos;

    public override void Start()
    {
        base.Start();
        Cientista = GameObject.Find("Player");
        colliderRobo = GetComponent<BoxCollider2D>();
        colliderCientista = Cientista.GetComponent<BoxCollider2D>();
        Physics2D.IgnoreCollision(colliderCientista,colliderRobo,true);
    }

    public override void Update()
    {
        base.Update();

        if(possivelIntBloco || possivelIntDrone)
            BotaoGuia.SetActive(true);
        else
            BotaoGuia.SetActive(false);
        
        if(Input.GetKeyDown(KeyCode.R))
        {
            if(movendoBloco)
            {
                interacaoBloco(colliderBloco);
            }
            Change();
        }
        if(Input.GetKeyDown(KeyCode.E))
        {
            if(possivelIntBloco)
                interacaoBloco(colliderBloco);
            if(possivelIntDrone)
                interacaoDrone();
        }

    }

    protected override void MoverComTeclas()
    {
        if(!movendoBloco)
        {
            Mover();
            Virar(MovimentoHoriz);
        }
        else
        {
            rb.velocity = new Vector2(colliderBloco.GetComponent<Rigidbody2D>().velocity.x,0f);
        }
        

    }

    public void Change()
    {
        rb.velocity = new Vector2(0f,0f);
        BotaoGuia.SetActive(false);
        animacao.SetFloat("velocity",Mathf.Abs(rb.velocity.x));
        animacao.SetFloat("velocityY",rb.velocity.y);
        BotaoGuia.SetActive(false);
        Cientista.GetComponent<Cientista>().enabled = true;
        rb.GetComponent<Robo>().enabled = false;
    }

    void interacaoBloco(Collider2D Bloco)
    {
        Bloco.GetComponent<Bloco>().mov();
        if(movendoBloco)
        {
            movendoBloco = !movendoBloco;
            animacao.SetBool("empurando",false);
        }
        else
        {
            movendoBloco = !movendoBloco;
            animacao.SetBool("empurando",true);
        };
    }

    void interacaoDrone()
    {
        animacao.SetTrigger("atk");
        Transform obj = Instantiate(Bullet,BulletPos.position, transform.rotation);
        if(direcaoRosto)
            obj.right = Vector2.right*-1;
    }

    protected void OnTriggerEnter2D(Collider2D colisor)
    {
        if(colisor.gameObject.tag == "Bloco")
        {
            colliderBloco = colisor;
            possivelIntBloco = true;
        }
        if(colisor.gameObject.tag == "drone")
        {
            possivelIntDrone = true;
        }
    }

    protected void OnTriggerExit2D(Collider2D colisor)
    {
        if(colisor.gameObject.tag == "Bloco")
        {
            possivelIntBloco = false;
            if(movendoBloco)
            {
                interacaoBloco(colliderBloco);
            }
        }
        if(colisor.gameObject.tag == "drone")
        {
            possivelIntDrone = false;
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.DrawSphere(TrChao.position, raioCh);
    }


}
