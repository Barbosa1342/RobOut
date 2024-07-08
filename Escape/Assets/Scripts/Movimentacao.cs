using UnityEngine;

public class Jogador : MonoBehaviour
{
    private Rigidbody2D rb;
    private SpriteRenderer virar;

    [SerializeField] float velocidade = 2.5f;
    [SerializeField] float forcaPulo = 15; //Deixei a gravity Scale do Jogador lá no rigidbody2D em 5
    public bool pode_andar;
    public Transform detecta_chao;
    public LayerMask layer_chao;
    public LayerMask layer_player;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        virar = GetComponent<SpriteRenderer>();
    }


    void Update()
    {
        pode_andar = gameObject.GetComponent<Troca>().pode_andar;
        
        if (Input.GetKey(KeyCode.W) && estaNoChao() && pode_andar)
        {
            Pular(forcaPulo);
        }
        if (Input.GetKey(KeyCode.D) && pode_andar)
        {
            virar.flipX = false;
            Andar(velocidade);
        }
        if (Input.GetKey(KeyCode.A) && pode_andar)
        {
            virar.flipX = true;
            Andar(-velocidade);
        }
        if ((Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.A)) || !pode_andar)
        {
            Parar();
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


    void Parar()
    {
        rb.velocity = new Vector2(0, rb.velocity.y);
    }

    private bool estaNoChao()
    {
        if (rb.velocity.y <= 0)
        {
            //"cria" um circulo no objeto esta no chão criado
            Collider2D[] colliders = Physics2D.OverlapCircleAll(detecta_chao.position, 0.1f, layer_chao | layer_player);

            //Verifica o raio desse circulo
            for (int i = 0; i < colliders.Length; i++)
            {
                //Confere para ver se o objeto é o player, pois se for não vai retornar que é o chão
                if (colliders[i].gameObject != gameObject)
                {
                    //Se o objeto não for o próprio player retorna verdadeiro para esta no chão
                    return true;
                }
            }
        }
        //Caso as verificações não sejam atendidas retorna falso, ou seja, player não esta no chão
        return false;
    }
}
