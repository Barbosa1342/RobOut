using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerInteracao : MonoBehaviour
{
    [SerializeField] GameObject guia;

    private void Awake() {
        guia = gameObject.transform.GetChild(0).gameObject;
        guia.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collider){
        if (collider.tag == "Interagivel"){
            setGuia(true);
            collider.GetComponent<ObjInteragivel>().setPlayerPerto(true);
            //collider.GetComponent<Botao1>().setPlayerPerto(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collider){
        if (collider.tag == "Interagivel"){
            setGuia(false);
            collider.GetComponent<ObjInteragivel>().setPlayerPerto(false);
            //collider.GetComponent<Botao1>().setPlayerPerto(false);
        }
    }

    private void setGuia(bool perto){
        if (guia.activeSelf != perto){
            guia.SetActive(perto);
        }
    }

}
