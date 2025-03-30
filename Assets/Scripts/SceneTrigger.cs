using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

public class SceneTrigger : MonoBehaviour
{

    public Object sceneToLoad;
    public string enemyTag = "Enemy"; 
    BoxCollider triggerToActivate;
    [SerializeField] int enemiesKill = 1;

    private bool triggerActivated = false;

    public string escena;

    private void Start()
    {
        triggerToActivate = GetComponent<BoxCollider>();
    }

    void Update()
    {
       
        //if (AreAllEnemiesDefeated() && !triggerActivated)
        //{
            
        //    if (triggerToActivate != null)
        //    {
        //        triggerToActivate.enabled = true; 
        //        triggerActivated = true; 
        //    }
        //}
    }

  
    public void KillEnemy()
    {
        enemiesKill--;
    }

   
    private void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag("Player"))
        {
            if(enemiesKill == 0)
            {
                LoadScene(escena);
            }
           
            
        }
    }

    
    void LoadScene(string scene)
    {
        if (sceneToLoad != null)
        {

            SceneManagere.Singleton.LoadLevel(sceneToLoad.name);
        }
    }
}

