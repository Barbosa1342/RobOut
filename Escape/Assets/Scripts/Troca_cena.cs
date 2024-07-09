using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Troca_cena : MonoBehaviour
{
    private bool TriggerCientista = false;
    private bool TriggerRobo = false;
    public string fase;

    // Método chamado quando um Collider2D entra na área de trigger da porta
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Cientista"))
        {
            TriggerCientista = true;
        }
        else if (other.CompareTag("Robo"))
        {
            TriggerRobo = true;
        }

        // Verifica se ambos os personagens estão na porta
        if (TriggerCientista && TriggerRobo)
        {
            CarregarProximaFase();
        }
    }

    // Método chamado quando um Collider2D sai da área de trigger da porta
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Cientista"))
        {
            TriggerCientista = false;
        }
        else if (other.CompareTag("Robo"))
        {
            TriggerRobo = false;
        }
    }

    // Método para carregar a próxima fase
    private void CarregarProximaFase()
    {
        SceneManager.LoadScene(fase);
    }
}