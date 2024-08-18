using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vida : MonoBehaviour
{
    [SerializeField] float vidaMax;
    float vidaAtual;

    public float getVidaAtual(){
        return vidaAtual;
    }

    public float alteraVidaAtual(float quantidade){
        vidaAtual += quantidade;
        vidaAtual = Mathf.Clamp(vidaAtual, 0, vidaMax);
        
        return vidaAtual;
    }

    private void OnEnable() {
        vidaAtual = vidaMax;
    }
    
    void Update()
    {
        if (vidaAtual <= 0){
            gameObject.SetActive(false);
        }
    }
}
