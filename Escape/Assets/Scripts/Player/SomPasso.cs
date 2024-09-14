using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SomPasso : MonoBehaviour
{
    [SerializeField] AudioSource controladorSom;
    [SerializeField] AudioClip[] listaSomPassos;
    [SerializeField] AudioClip puloSom;
    [SerializeField] AudioClip aterrisagemSom;

    public float tempoEntre = 0.1f; // tempo entre cada passo
    float timer; // mede o tempo que passou

    // necessario para saber se ele esta andando
    private Movimentacao movimentacaoScript;
    Rigidbody2D rg;

    bool ultimoChao;

    // Start is called before the first frame update
    void Start()
    {
        rg = GetComponent<Rigidbody2D>();
        movimentacaoScript = GetComponent<Movimentacao>();
        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (movimentacaoScript.GetPodeAndar()){
            if(movimentacaoScript.estaNoChao()){
                // nao precisa de som de passo no ar .-.

                if (ultimoChao == false){
                    // se ultimoChao for false e ele voltou ao chao
                    // indica que ele aterrisou
                    controladorSom.PlayOneShot(aterrisagemSom);
                }

                if (movimentacaoScript.GetAndando()){
                    // Indica que esta andando
                    // Abs = absoluto, para considerar positivo e negativo

                    if (timer > tempoEntre){
                        controladorSom.PlayOneShot(somAleatorio());
                        timer = 0;
                    }
                }
            }else if(ultimoChao == true){
                // se ultimoChao for verdadeiro e ele nao esta mais no chao
                // indica que ele pulou
                controladorSom.PlayOneShot(puloSom);
            }
            // guarda se ele esta no chao, para considerar depois
            ultimoChao = movimentacaoScript.estaNoChao();
        }
    }

    AudioClip somAleatorio(){
        // Retorna um clip de audio aleatorio
        // dentre os disponiveis na lista

        int aleatorio = Random.Range(0, listaSomPassos.Length-1);
        return listaSomPassos[aleatorio];
    }
}
