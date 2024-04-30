using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bloco : MonoBehaviour
{   
    protected Rigidbody2D rb;
    protected Transform Tr;

    protected float MovimentoHoriz;
    private GameObject Robo;
    private float ax;
    private bool movendo = false;
    public float velocidade = 1.5f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Tr = GetComponent<Transform>();      
        Robo = GameObject.Find("Robo");
    }

    void Update()
    {
        if(movendo)
        {
            MovimentoHoriz = Input.GetAxis("Horizontal");
            rb.velocity = new Vector2(MovimentoHoriz*velocidade,0);
        }
        
    }

    public void mov()
    {
        if(!movendo){
            rb.constraints = RigidbodyConstraints2D.None;
            rb.constraints = RigidbodyConstraints2D.FreezePositionY;
            rb.constraints = RigidbodyConstraints2D.FreezeRotation;
            movendo = !movendo;
        }
        else
        {
            rb.constraints = RigidbodyConstraints2D.FreezeAll;
            movendo = !movendo;
        }
    }
}
