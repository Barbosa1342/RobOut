using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Troca : MonoBehaviour
{
    GameObject outro_personagem; //GameObject que sera localizado usando a variavel "tagParaTrocaDePersonagem" para trocar a movimentacao
    public bool pode_andar; //Define se o personagem pode ou nao se mover
    public bool personagem_inicio; //Define qual dos personagens ira começar se movimentando (Assinale apenas em um personagem)
    public string tag_troca; //Informa a variavel "" qual será a tag que sera utilizada

    void Start()
    {
        outro_personagem = GameObject.FindWithTag(tag_troca);//Procura na Hierarquia dos Game Object presentes no mundo um Game Object com a tag igual ao valor de "tagParaTrocaDePersonagem" afim de identificar qual sera o outro personagem que podera ser trocado
        pode_andar = false;

//Verifica se a variavel "IniciarComEssePersonagem" esta true e entao habilita a movimentacao no inicio do jogo
        if (personagem_inicio)
        {
            pode_andar = true;
        }
    }

    void Update()
    {
//Verifica se a tecla "R" foi pressionado e se a variavel "personagemPodeAndar" esta true
        if (Input.GetKeyUp(KeyCode.R) && pode_andar)
        {
            StartCoroutine(TrocarDePersonagem());
        }
    }

//Realiza a troca dos personagens utilizando uma corrotina para que possa se esperar 0.1 segundos e o pressionar do R funcione corretamente
    IEnumerator TrocarDePersonagem()
    {
        pode_andar = false;
        yield return new WaitForSeconds(0.01f);
        outro_personagem.GetComponent<Troca>().pode_andar = true;
    }
}
