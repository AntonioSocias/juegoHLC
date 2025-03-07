using UnityEngine;
using UnityEngine.SceneManagement;

public class NewEmptyCSharpScripts : MonoBehaviour
{

    public void LoadGameScene() // Ahora es public
    {
        SceneManager.LoadScene("NivelPrincipal"); //Carga la escena llamada "NivelPrincipal"
    }

    /**
     * 
    public void LoadMainMenuScene()
    {
        SceneManager.LoadScene("MainMenu"); //Carga la escena llamada "MainMenu"
    }

    public void ExitGame()
    {
        Application.Quit(); //Cierra la aplicación (no funciona en el Editor de Unity)
    }
    */
}