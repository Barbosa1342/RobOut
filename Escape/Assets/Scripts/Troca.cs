using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Troca : MonoBehaviour
{
    GameObject outro_personagem; //GameObject que sera localizado usando a variavel "tagParaTrocaDePersonagem" para trocar a movimentacao
    [SerializeField] bool pode_andar; //Define se o personagem pode ou nao se mover
    [SerializeField] bool personagem_inicio; //Define qual dos personagens ira come�ar se movimentando (Assinale apenas em um personagem)
    [SerializeField] string tag_troca; //Informa a variavel "" qual ser� a tag que sera utilizada

    float tempoEspera;
    float tempo;
    bool podeTrocar;

    public bool GetPodeAndar(){
        return pode_andar;
    }


    void Start()
    {
        outro_personagem = GameObject.FindWithTag(tag_troca);//Procura na Hierarquia dos Game Object presentes no mundo um Game Object com a tag igual ao valor de "tagParaTrocaDePersonagem" afim de identificar qual sera o outro personagem que podera ser trocado
        pode_andar = false;

//Verifica se a variavel "IniciarComEssePersonagem" esta true e entao habilita a movimentacao no inicio do jogo
        if (personagem_inicio)
        {
            pode_andar = true;
        }

        tempoEspera = 0.5f;
        podeTrocar = false;
        tempo = 0.0f;
    }

    void Update()
    {
        //Verifica se a tecla "R" foi pressionado e se a variavel "personagemPodeAndar" esta true
        if (podeTrocar){
            if (Input.GetKeyUp(KeyCode.R) && pode_andar)
            {
                StartCoroutine(TrocarDePersonagem());
            }
        }else{
            tempo += Time.deltaTime;
        }
        
        if (tempo >= tempoEspera){
            podeTrocar = true;
        }
    }

    public void Trocando(){
        pode_andar = true;
        podeTrocar = false;
        tempo = 0.0f;
    }

    //Realiza a troca dos personagens utilizando uma corrotina para que possa se esperar 0.1 segundos e o pressionar do R funcione corretamente
    IEnumerator TrocarDePersonagem()
    {
        pode_andar = false;
        yield return new WaitForSeconds(0.01f);
        outro_personagem.GetComponent<Troca>().Trocando();
    }
}
