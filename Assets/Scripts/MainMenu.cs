using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class SceneNavigation : MonoBehaviour
{
    public Object sceneToLoad;

    public void LoadSelectedScene()
    {
        if (sceneToLoad != null)
        {
            string sceneName = sceneToLoad.name;
            SceneManager.LoadScene(sceneName);
        }
        else
        {
            Debug.Log("No se ha asignado una escena en el Inspector.");
        }
    }

    public void QuitGame()
    {
        Debug.Log("Saliendo del juego...");
        Application.Quit();
    }
}


