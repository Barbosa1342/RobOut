using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimentacao : MonoBehaviour
{
    private Rigidbody2D Rb;
    private bool chao;
    SpriteRenderer sprite;

    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        Rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Rb.velocity = Vector3.zero;

        if (Input.GetKey(KeyCode.A))
        {
            Rb.velocity = new Vector2(-2.5f,0f);

            // inverte a sprite
            // provisorio
            sprite.flipX = true; 
        }
        if (Input.GetKey(KeyCode.D))
        {
            Rb.velocity = new Vector2(2.5f, 0f);
            
            // inverte a sprite
            // provisorio
            sprite.flipX = false;
        }
    }

    /*
    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "chao")
        {
            chao = true;
            {
                if (Input.GetKeyDown(KeyCode.W) && chao == true)
                {
                    Rb.velocity = new Vector2(Rb.velocity.x, Rb.velocity.y * 3);
                }
            }
        }
    }
    */
}
