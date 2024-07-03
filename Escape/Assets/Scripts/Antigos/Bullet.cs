using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bullet : MonoBehaviour
{
    public string cena;

    void Start()
    {
        GetComponent<Rigidbody2D>().AddForce(transform.right * 250);
    }

    void OnTriggerEnter2D(Collider2D colisor)
    {
        if(colisor.gameObject.tag == "Player")
        {
            SceneManager.LoadScene(cena);
            Destroy(gameObject);
        }
        if(colisor.gameObject.tag == "drone")
        {
            colisor.GetComponent<Drone>().morrer();
            Destroy(gameObject);
        }
        if(colisor.gameObject.tag == "chao")
            Destroy(gameObject);
        
    }
}
