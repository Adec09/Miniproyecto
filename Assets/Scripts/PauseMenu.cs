using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenuUI; 

    private bool isPaused = false;
    AimStateManager aim;

    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                Resume(); 
            }
            else
            {
                Pause(); 
            }
        }
    }

    void Pause()
    {
        aim.enabled = false;
        pauseMenuUI.SetActive(true); 
        Time.timeScale = 0f; 
        isPaused = true; 
    }

    void Resume()
    {
        aim.enabled = true;
        pauseMenuUI.SetActive(false); 
        Time.timeScale = 1f; 
        isPaused = false; 
    }

    void Start()
    {
        aim = FindFirstObjectByType<AimStateManager>(); 
    }


   
}

