using UnityEngine;
using UnityEngine.SceneManagement;

public class Configuracao : MonoBehaviour
{
    [SerializeField] GameObject fundo;
    [SerializeField] GameObject config;

    private void Start() {
        fundo.SetActive(false);
        config.SetActive(true);
        Time.timeScale = 1;
    }

    public void AbreConfig(){
        fundo.SetActive(true);
        config.SetActive(false);
        Time.timeScale = 0;
    }

    public void Reiniciar()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void AbreMenu()
    {
        SceneManager.LoadScene("Menu");
    }
    public void Voltar()
    {
        fundo.SetActive(false);
        config.SetActive(true);
        Time.timeScale = 1;
    }

    public void Sair()
    {
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #endif
        Application.Quit();
    }
}
