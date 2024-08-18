using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drone1 : MonoBehaviour
{
    [SerializeField] float distanciaLaser = 3.0f;
    [SerializeField] LayerMask layer_player;

    SpriteRenderer sprite;
    bool virado;
    float yInicial;


    bool podeAtirar = true;
    public Transform posicaoSpawn;
    public Transform objeto; 

    private void Awake() {
        sprite = GetComponent<SpriteRenderer>();
    }

    void Start()
    {
        podeAtirar = true;

        virado = sprite.flipX;
        yInicial = transform.position.y;
    }

    private void FixedUpdate() {
        Flutuar();

        Vector2 direcao;

        // A direcao da sprite aponta para esquerda
        // caso esteja virado, deve apontar para direita
        if (!virado){
            direcao = Vector2.left;
        }else{
            direcao = Vector2.right;
        }

        // dispara um raio e retorna o colisor de um player
        RaycastHit2D acerto = Physics2D.Raycast(transform.position, direcao, distanciaLaser, layer_player);
        
        // Caso queira visualizar o raio (Ativar Gizmo na Scene):
        //Debug.DrawRay(transform.position, direcao * distanciaLaser, Color.black);

        if (acerto.collider != null){
            Debug.Log("Acertando: " + acerto.collider.tag);

            if (podeAtirar){
                StartCoroutine(Tiro());
            }
        }
    }

    private IEnumerator Tiro()
    {
        podeAtirar = false;
        Vector2 direcao;

        if (!virado){
            direcao = Vector2.left;
        }else{
            direcao = Vector2.right;
        }

        Transform bala = Instantiate(objeto, posicaoSpawn.position, transform.rotation);
        bala.GetComponent<Rigidbody2D>().AddForce(direcao, ForceMode2D.Impulse);

        yield return new WaitForSeconds(1f);

        podeAtirar = true;
    }

    void Flutuar(){
        Vector2 dest = new(transform.position.x, yInicial + (Mathf.Cos(Time.fixedTime * Mathf.PI) * 0.2f));
        transform.position = dest;
    }

}
