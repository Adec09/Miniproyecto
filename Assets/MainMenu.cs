using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneNavigation : MonoBehaviour
{
    public Object sceneToLoad;

    private void Start()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

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

