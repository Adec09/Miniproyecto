using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

public class SceneTrigger : MonoBehaviour
{

    public Object sceneToLoad;
    public string enemyTag = "Enemy"; 
    BoxCollider triggerToActivate; 

    private bool triggerActivated = false;

    private void Start()
    {
        triggerToActivate = GetComponent<BoxCollider>();
    }

    void Update()
    {
       
        if (AreAllEnemiesDefeated() && !triggerActivated)
        {
            
            if (triggerToActivate != null)
            {
                triggerToActivate.enabled = true; 
                triggerActivated = true; 
            }
        }
    }

  
    bool AreAllEnemiesDefeated()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag); 
        return enemies.Length == 0; 
    }

   
    private void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag("Player"))
        {
           
            LoadScene();
        }
    }

    
    void LoadScene()
    {
        if (sceneToLoad != null)
        {
            
            SceneManager.LoadScene(sceneToLoad.name);
        }
    }
}

