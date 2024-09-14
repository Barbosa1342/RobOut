using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GerenciadorCheckPoint : MonoBehaviour
{
    // Utilizando dicionarios pois a ordem dos indices
    // e aleatoria, e quebra o range da lista
    static Dictionary<int, Transform> checkPoints = new Dictionary<int, Transform>();
    static int indiceAtual;

    private void Awake() {
        indiceAtual = -1;
    }
    static public void RegistraCheckPoint(int indice, Transform checkPoint){
        checkPoints.Add(indice, checkPoint);
    }

    static public int GetIndiceAtual(){
        return indiceAtual;
    }

    static public void SetIndiceAtual(int indice){
        // A funcao so executa quando um indice maior
        // substitui um menor
        // Logo, tranquilo rodar a animacao aqui

        if (indiceAtual != -1){
            checkPoints[indiceAtual].gameObject.GetComponent<CheckPoint>().Animacao(false);
            indiceAtual = indice;
        }else{
            indiceAtual = indice;
        }
    }

    static public void Respawn(Transform trans){
        if(indiceAtual != -1){
            trans.position = checkPoints[indiceAtual].position;
            trans.gameObject.GetComponent<Vida>().RecuperaVida();
        }
    }
}
