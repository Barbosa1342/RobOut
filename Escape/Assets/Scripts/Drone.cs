using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drone : MonoBehaviour
{
    private bool atirar = false, podeAtirar = true;
    
    public Transform BulletPos,Bullet; 

    void Update()
    {
        if(atirar)
        {
            if(podeAtirar)
                StartCoroutine(atirando());
        }
    }

    private IEnumerator atirando()
    {
        podeAtirar = false;
        Instantiate(Bullet,BulletPos.position, transform.rotation);
        yield return new WaitForSeconds(1f);
        podeAtirar = true;
    }

    public void morrer()
    {
        Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D colisor)
    {
        if(colisor.gameObject.tag == "Player")
            atirar = true;
    }

    void OnTriggerExit2D(Collider2D colisor)
    {
        if(colisor.gameObject.tag == "Player")
            atirar = true;
    }


}
