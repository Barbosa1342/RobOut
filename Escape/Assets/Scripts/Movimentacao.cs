using UnityEngine;

public class Jogador : MonoBehaviour
{
    private Rigidbody2D rb;

    private bool estaNoChao;
    [SerializeField] float velocidade = 2.5f;
    [SerializeField] float forcaPulo = 15; //Deixei a gravity Scale do Jogador lá no rigidbody2D em 5
    public bool pode_andar;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        Debug.Log(estaNoChao);
        pode_andar = gameObject.GetComponent<Troca>().pode_andar;
        if (Input.GetKey(KeyCode.W) && estaNoChao && pode_andar)
        {
            Pular(forcaPulo);
        }
        if (Input.GetKey(KeyCode.D) && pode_andar)
        {
            Andar(velocidade);
        }
        if (Input.GetKey(KeyCode.A) && pode_andar)
        {
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

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "chao")
        {
            estaNoChao = true;
        }
    }


    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "chao")
        {
            estaNoChao = false;
        }
    }
}