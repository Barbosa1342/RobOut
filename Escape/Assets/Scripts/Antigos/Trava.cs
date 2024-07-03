using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trava : MonoBehaviour
{
    GameObject Cientista,Robo;
    BoxCollider2D collider;

    void Start()
    {
        Cientista = GameObject.Find("Player");
        Robo = GameObject.Find("Robo");
        collider = GetComponent<BoxCollider2D>();
        Physics2D.IgnoreCollision(collider,Robo.GetComponent<BoxCollider2D>(),true);
        Physics2D.IgnoreCollision(collider,Cientista.GetComponent<BoxCollider2D>(),true);
    }
}
