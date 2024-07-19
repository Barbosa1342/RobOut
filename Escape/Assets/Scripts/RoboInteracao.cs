using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoboInteracao : MonoBehaviour
{
    private GameObject guia;

    private void Awake() {
        guia = gameObject.transform.GetChild(0).gameObject;
        guia.SetActive(false);
    }

    /*
    private void OnTriggerEnter2D(Collider2D collider){
        if (collider.tag == "InteragivelRobo"){
            setGuia(true);
            collider.GetComponent<ObjInteragivel>().setPlayerPerto(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collider){
        if (collider.tag == "InteragivelRobo"){
            setGuia(false);
            collider.GetComponent<ObjInteragivel>().setPlayerPerto(false);
        }
    }
    */

    public void setGuia(bool perto){
        if (guia.activeSelf != perto){
            guia.SetActive(perto);
        }
    }
}
