using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SomFase : MonoBehaviour
{
    AudioSource controladorSom;
    [SerializeField] AudioClip loopSom;

    private void Awake() {
        controladorSom = GetComponent<AudioSource>();
    }

    private void Start(){
        controladorSom.clip = loopSom;
        controladorSom.loop = true;
        controladorSom.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
