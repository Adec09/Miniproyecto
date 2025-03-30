using UnityEngine;

public class DetectionStateManager : MonoBehaviour
{
    [SerializeField] float lookDistance = 30, fov = 120;
    [SerializeField] Transform enemyEyes;
    Transform playerHead;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool PlayerSeen()
    {
        return false;
    }
}
