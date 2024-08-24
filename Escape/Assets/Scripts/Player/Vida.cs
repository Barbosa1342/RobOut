using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vida : MonoBehaviour
{
    [SerializeField] float vidaMax;
    [SerializeField] GameObject player, inimigo;
    public bool invencivel = false;
    public float vidaAtual;

    private void Start()
    {
    }

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
            gameObject.SetActive(false);
        }
    }

    public IEnumerator Invencibilidade()
    {
        invencivel = true;
        yield return new WaitForSeconds(1.5f);
        invencivel = false;
    }
}
