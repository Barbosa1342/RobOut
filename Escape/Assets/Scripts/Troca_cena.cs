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

    // M�todo chamado quando um Collider2D entra na �rea de trigger da porta
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

        // Verifica se ambos os personagens est�o na porta
        if (TriggerCientista && TriggerRobo)
        {
            CarregarProximaFase();
        }
    }

    // M�todo chamado quando um Collider2D sai da �rea de trigger da porta
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

    // M�todo para carregar a pr�xima fase
    private void CarregarProximaFase()
    {
        SceneManager.LoadScene(fase);
    }
}