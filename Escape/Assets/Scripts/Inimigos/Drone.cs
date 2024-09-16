using System.Collections;
using System;
using UnityEngine;

public class Drone1 : Inimigo
{
    // Variaveis usadas pelo RayCast
    //[SerializeField] float distanciaLaser = 3.0f; 
    //[SerializeField] LayerMask layer_player;
    //bool virado;

    // distancia maxima que o drone chega perto do player
    [SerializeField] float distanciaSegura = 1.0f; 
    [SerializeField] float velocidadeBala = 2.0f; 
    
    float yInicial; // y usado para flutuar
    bool podeAtirar; // controle do tiro
    public Transform posicaoSpawn; // filho pra usar de local de spawn
    public Transform balaPrefab; // objeto a ser instanciado

    override protected void Start()
    {
        cientista = AchaPersonagem("Cientista").GetComponent<Transform>();
        robo = AchaPersonagem("Robo").GetComponent<Transform>();

        podeAtirar = true;
        patrulhando = false;
        yInicial = transform.position.y;
    }

    private void Update() {
        Vector2 direcao = DirecaoInimigoMaisProximo();
        if (DetectaPlayer(direcao))
        {
            if(patrulhando){
                StopCoroutine(Patrulha());
                patrulhando = false;
            }

            if(podeAtirar){
                StartCoroutine(Tiro(direcao));
            }
        
            if(distanciaSegura < Math.Abs(direcao.x)){
                Andar(velocidade, direcao);
            }
        }else{ 
            if (!patrulhando){
                StartCoroutine(Patrulha());
                patrulhando = true;
            }
        }
        Flutuar();
    }

    void Flutuar(){
        Vector2 dest = new(transform.position.x, yInicial + (Mathf.Cos(Time.fixedTime * Mathf.PI) * 0.2f));
        transform.position = dest;
    }

    override protected void Andar(float velocidadeInimigo, Vector2 direcao){
        direcao = direcao.normalized;
        direcao.y = 0; // necessario pra ele nao flutuar
        rbInimigo.velocity = velocidade * direcao;

        if (rbInimigo.velocity.x >= 0.01f){
            sprite.flipX = false;
        }
        else if (rbInimigo.velocity.x <= -0.01f){
            sprite.flipX = true;
        }
    }

    override protected void Parar(){
        rbInimigo.velocity = new Vector2(0, 0);
    }

    override protected IEnumerator Patrulha(){
        int escolha = UnityEngine.Random.Range(1, 3); // range entre 0 e 1

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

        int tempo = UnityEngine.Random.Range(1, 3);
        
        yield return new WaitForSeconds(tempo);

        Parar();

        yield return new WaitForSeconds(tempo);

        patrulhando = false;
    }
    protected override bool DetectaPlayer(Vector2 direcao)
    {
        if (Math.Abs(direcao.x) < raioVisao && Math.Abs(direcao.y) < raioVisao){
            return true;
        }
        return false;
    }

    /*
    private void FixedUpdate() {
        Flutuar();

        Vector2 direcao;

        // A direcao da sprite aponta para esquerda
        // caso esteja virado, deve apontar para direita
        if (!virado){
            direcao = Vector2.left;
        }else{
            direcao = Vector2.right;
        }

        // dispara um raio e retorna o colisor de um player
        RaycastHit2D acerto = Physics2D.Raycast(transform.position, direcao, distanciaLaser, layer_player);
        
        // Caso queira visualizar o raio (Ativar Gizmo na Scene):
        //Debug.DrawRay(transform.position, direcao * distanciaLaser, Color.black);

        if (acerto.collider != null){
            Debug.Log("Acertando: " + acerto.collider.tag);

            if (podeAtirar){
                
            }
        }
    }*/

    private IEnumerator Tiro(Vector2 direcao)
    {
        podeAtirar = false;
        anim.SetBool("atirando", true);

        direcao.y = 0;
        direcao = direcao.normalized;

        Transform bala = Instantiate(balaPrefab, posicaoSpawn.position, transform.rotation);
        bala.GetComponent<Rigidbody2D>().AddForce(direcao*velocidadeBala, ForceMode2D.Impulse);

        yield return new WaitForSeconds(1f);

        podeAtirar = true;
        anim.SetBool("atirando", false);
    }
}
