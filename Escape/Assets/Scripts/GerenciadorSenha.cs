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
        string senha = "";
        for (int i = 0; i < 6; i++)
        {
            codigo[i] = Random.Range(0, 10);
            LimpaSenha();

            senha += codigo[i].ToString();
        }
        Debug.Log(senha);
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
