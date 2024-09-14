using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vida : MonoBehaviour
{
    [SerializeField] float vidaMax;
    public bool invencivel = false;
    public float vidaAtual;

    public float getVidaAtual(){
        return vidaAtual;
    }

    public float RecebeDano(float quantidade){
        vidaAtual -= quantidade;
        vidaAtual = Mathf.Clamp(vidaAtual, 0, vidaMax);
        StartCoroutine(Invencibilidade());
        return vidaAtual;
    }

    private void OnEnable() {
        vidaAtual = vidaMax;
    }
    
    void Update()
    {
        if (vidaAtual <= 0){
            if(this.CompareTag("Cientista") || this.CompareTag("Robo")){
                GerenciadorCheckPoint.Respawn(transform);
            }else{
                gameObject.SetActive(false);
            }
        }
    }

    public void RecuperaVida(){
        vidaAtual = vidaMax;
    }

    public IEnumerator Invencibilidade()
    {
        invencivel = true;
        yield return new WaitForSeconds(1.5f);
        invencivel = false;
    }
}
