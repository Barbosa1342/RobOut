using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GerenciadorSenha : MonoBehaviour
{
    [SerializeField] List<TMP_Text> numeros = new();
    [SerializeField] List<GameObject> listaPapel = new();
    [SerializeField] TMP_Text senhaDigitada;
    private List<int> codigo = new();
    List<int> tentativa = new List<int>();
    [SerializeField] GameObject painel;

    int quantidade;

    private void Awake()
    {
        LimpaSenha();
    }
    
    private void Start() {
        quantidade = numeros.Count;
        for (int i = 0; i < quantidade; i++)
        {
            codigo.Add(Random.Range(0, 10));
        }

        geraPosicao();
    }

    private void geraPosicao(){
        List<int> numerosPos = new List<int>();
        for (int i = 0; i < quantidade; i++)
        {
            numerosPos.Add(i);
        }

        int indice;

        for (int i = 0; i < quantidade; i++){
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

        for (int i = 0; i < codigo.Count; i++){
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
