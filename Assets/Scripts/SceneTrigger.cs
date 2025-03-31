using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTrigger : MonoBehaviour
{
    public string sceneToLoad; // Almacena el nombre de la escena como string
    public string enemyTag = "Enemy";
    private BoxCollider triggerToActivate;
    [SerializeField] private int enemiesKill = 1;
    private bool triggerActivated = false;

    private void Start()
    {
        triggerToActivate = GetComponent<BoxCollider>();
    }

    public void KillEnemy()
    {
        enemiesKill--;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && enemiesKill <= 0)
        {
            LoadScene();
        }
    }

    void LoadScene()
    {
        if (!string.IsNullOrEmpty(sceneToLoad))
        {
            SceneManager.LoadScene(sceneToLoad);
        }
        else
        {
            Debug.LogError("No se ha asignado una escena en el Inspector.");
        }
    }
}


