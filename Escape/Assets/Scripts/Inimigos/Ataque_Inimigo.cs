using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ataque_Inimigo : MonoBehaviour
{
    //Variaveis de ataque
    [SerializeField] private GameObject inimigo;
    [SerializeField] private bool toma_dano;
    [SerializeField] private float dano;
    [SerializeField] public bool pode_atacar;
    [SerializeField] private string tag_alvo;
    public bool inimigo_anda;
    private float vida_inimigo;

    // Start is called before the first frame update
    void Start()
    {
        inimigo = GameObject.FindWithTag(tag_alvo);
    }

    // Update is called once per frame
    void Update()
    {
        toma_dano = inimigo.gameObject.GetComponent<Vida>().invencivel;
        vida_inimigo = inimigo.GetComponent<Vida>().vidaAtual;
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == tag_alvo)
        {
            if (toma_dano == false && pode_atacar)
            {
                inimigo.GetComponent<Vida>().RecebeDano(dano);
                Debug.Log(vida_inimigo);
            }
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        collision.gameObject.GetComponent<Movimentacao>().Parar();
    }
}
