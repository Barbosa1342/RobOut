using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoboInteracao : MonoBehaviour
{
    private GameObject guia;
    [SerializeField] RoboAnim scriptAnim;

    public Transform posicaoSpawn;
    public Transform objeto; 

    SpriteRenderer sprite;
    bool virado;
    bool podeAtirar;

    private void Awake() {
        guia = gameObject.transform.GetChild(0).gameObject;
        guia.SetActive(false);

        scriptAnim = GetComponent<RoboAnim>();
        sprite = GetComponent<SpriteRenderer>();
        podeAtirar = true;
    }

    private void Update() {
        virado = sprite.flipX;

        if (!guia.activeSelf){
            if (Input.GetKeyDown(KeyCode.E) && podeAtirar){
                StartCoroutine(Tiro());
            }
        }
    }

    public void setGuia(bool perto){
        if (guia.activeSelf != perto){
            guia.SetActive(perto);
        }
    }

    private IEnumerator Tiro()
    {
        podeAtirar = false;
        scriptAnim.setAtirando(true);

        Vector2 direcao;
        Transform bala;
        Vector3 pos;

        if (virado){
            direcao = Vector2.left;

            // usando localPosition para inverter em relacao ao robo
            // necessario inverter o local de spawn na horizontal
            // para o tiro spawnar no lugar certo
            pos = new Vector3(-posicaoSpawn.localPosition.x, posicaoSpawn.localPosition.y, posicaoSpawn.localPosition.z);
        }else{
            direcao = Vector2.right;

            pos = posicaoSpawn.localPosition;
        }

        // instancia e guarda a referencia
        bala = Instantiate(objeto, this.transform, false);
        // posiciona conforme a orientacao do robo
        bala.localPosition = pos;
        // adiciona velocidade de uma so vez
        bala.GetComponent<Rigidbody2D>().AddForce(direcao, ForceMode2D.Impulse);

        yield return new WaitForSeconds(1f);

        podeAtirar = true;
        scriptAnim.setAtirando(false);
    }
}
