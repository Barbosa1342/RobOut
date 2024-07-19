using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GerenciadorSenha : MonoBehaviour
{
    [SerializeField] TMP_Text[] numeros = new TMP_Text[6];
    [SerializeField] GameObject[] listaPapel = new GameObject[6];
    [SerializeField] TMP_Text senhaDigitada;
    
    int[] codigo = new int[6];
    List<int> tentativa = new List<int>();
    
    [SerializeField] GameObject painel;

    private void Awake()
    {
        LimpaSenha();
        for (int i = 0; i < 6; i++)
        {
            codigo[i] = Random.Range(0, 10);
        }
    }
    
    private void Start() {
        geraPosicao();
    }

    private void geraPosicao(){
        List<int> numerosPos = new List<int>() {0, 1, 2, 3, 4, 5};
        int indice;

        for (int i = 0; i < 6; i++){
            indice = Random.Range(0, numerosPos.Count);

            int numero = numerosPos[indice];
            listaPapel[i].GetComponent<Papel1>().setPosicaoSenha(numero);
            numerosPos.Remove(numero);
        }
    }

    public void ativar(int posicao){
        numeros[posicao].text = codigo[posicao].ToString();
    }

    public void desativar(int posicao){
        numeros[posicao].text = "_";
    }



    /*
    Testes Gerenciamento de Senha aleatoria em papeis aleatorios
    public void Ativar(int pos){
        int numeroAtual = codigo[pos];

        numeros[pos].text = numeroAtual.ToString();
    }

    void codigoPainel(){
        string temp = "";

        for (int i = 0; i < 6; i++)
        {
            temp += codigo[i].ToString();
        }

        painel.setSenha(temp);
    }*/

    public void AdicionaNumero(int num){
        if (tentativa.Count < 10){
            tentativa.Add(num);
            senhaDigitada.text += num.ToString();
        }
    }

    public void ConfirmaSenha(){
        string teste = "";
        string senha = "";

        for (int i = 0; i < tentativa.Count; i++){
            teste += tentativa[i].ToString();
        }

        for (int i = 0; i < codigo.Length; i++){
            senha += codigo[i].ToString();
        }

        if (teste == senha){
            painel.GetComponent<Painel1>().AbrirPorta();
        }else{
            LimpaSenha();
        }
    }

    public void LimpaSenha(){
        tentativa.Clear();
        senhaDigitada.text = "";
    }
}
