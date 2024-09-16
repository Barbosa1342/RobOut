using UnityEngine;

public class Rato : Inimigo
{
    [SerializeField] float dano = 1;
    
    void Update()
    {
        Vector2 direcao = DirecaoInimigoMaisProximo();
        // se detectaplayer for verdadeiro e a tag for cientista
        if (DetectaPlayer(direcao))
        {
            if(patrulhando){
                StopCoroutine(Patrulha());
                patrulhando = false;
            }
            Andar(velocidade, direcao);
        }else{
            if (!patrulhando){
                StartCoroutine(Patrulha());
                patrulhando = true;
            }
        }
    }

    protected override Vector2 DirecaoInimigoMaisProximo()
    {
        // Rato persegue apenas Cientista, logo, ele sempre e o mais proximo
        Vector3 inimigoPos = transform.position;
        Vector2 direcaoCientista = cientista.position - inimigoPos;

        return direcaoCientista;
    }

    private void OnCollisionEnter2D(Collision2D collider)
    {
        if (collider.collider.CompareTag("Cientista"))
        {
            bool invencivel = collider.gameObject.GetComponent<Vida>().invencivel;
            float vidaInimigo = collider.gameObject.GetComponent<Vida>().vidaAtual;
            if (invencivel == false)
            {
                collider.gameObject.GetComponent<Vida>().RecebeDano(dano);
                Debug.Log(vidaInimigo);
            }
        }
    }

    /*
    private void OnCollisionExit2D(Collision2D colisor)
    {
        colisor.gameObject.GetComponent<Movimentacao>().Parar();
    }
    */
}