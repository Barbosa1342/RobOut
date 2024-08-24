using System.Collections;
using System.Collections.Generic;
using Unity.Burst.Intrinsics;
using UnityEngine;

public class Bala : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D colisor) {
        LayerMask layerChao = LayerMask.NameToLayer("chao");
        
        if (colisor.CompareTag("Cientista") || colisor.CompareTag("Robo")){
            colisor.gameObject.GetComponent<Vida>().RecebeDano(1);
        }
        else if (colisor.gameObject.layer == layerChao){
            gameObject.SetActive(false);
        }
    }
}
