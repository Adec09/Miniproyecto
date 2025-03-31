using UnityEngine;

public class MouseLocker : MonoBehaviour
{
    
    void Start()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    
   
}
