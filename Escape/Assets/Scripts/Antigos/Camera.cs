using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera2 : MonoBehaviour
{      
    Transform tr;
    Transform Cientista,Robo;
    Vector2 D;
    // Start is called before the first frame update
    void Start()
    {
        tr = GetComponent<Transform>();
        Cientista = GameObject.Find("Player").GetComponent<Transform>();
        Robo = GameObject.Find("Robo").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        D = Cientista.position -((Cientista.position-Robo.position)/2);
        tr.position = D;
    }
}
