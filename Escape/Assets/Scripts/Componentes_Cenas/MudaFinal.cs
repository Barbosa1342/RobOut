using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MudaFinal : MonoBehaviour
{
    [SerializeField] string cena;
    [SerializeField] GameObject imagem;

    private bool finalizando = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!finalizando){
            StartCoroutine(Final());
        }
    }

    IEnumerator Final(){
        finalizando = true;

        for (byte color = 0; color <= 254; color += 1)
        {
            // Se color chegar até 255+1, ele estoura e volta a zero
            // fazendo um loop infinito
            imagem.GetComponent<Image>().color = new Color32(0, 0, 0, color);
            yield return new WaitForSeconds(0.005f);
        }
        SceneManager.LoadScene(cena);
    }
}
