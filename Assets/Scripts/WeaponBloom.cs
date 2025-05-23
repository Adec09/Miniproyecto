using UnityEngine;

public class WeaponBloom : MonoBehaviour
{
    [SerializeField] float defaultBloomAngle = 3;
    [SerializeField] float walkBloomMultiplier = 1.5f;
    [SerializeField] float crouchBloomMultiplier = 0.5f;
    [SerializeField] float sprintBloomMultiplier = 2f;
    [SerializeField] float adsBloomMultiplier = 0.5f;

    MovimientoPersonaje movement;
    AimStateManager aiming;

    float currentBloom;
    void Start()
    {
        movement = GetComponentInParent<MovimientoPersonaje>();
        aiming = GetComponentInParent<AimStateManager>();

    }

    public Vector3 BloomAngle(Transform barrelPos)
    {
        if(movement.currentState == movement.Idle) currentBloom = defaultBloomAngle;
        else if (movement.currentState == movement.Walk) currentBloom = defaultBloomAngle * walkBloomMultiplier;
        else if (movement.currentState == movement.Run) currentBloom = defaultBloomAngle * sprintBloomMultiplier;
        else if (movement.currentState == movement.Crouch)
        {
            if (movement.dir.magnitude == 0) currentBloom = defaultBloomAngle * crouchBloomMultiplier;
            else currentBloom = defaultBloomAngle * crouchBloomMultiplier * walkBloomMultiplier;
        }

        if (aiming.currentState == aiming.Aim) currentBloom *= adsBloomMultiplier;

        float randX = Random.Range(-currentBloom, currentBloom);
        float randY = Random.Range(-currentBloom, currentBloom);
        float randZ = Random.Range(-currentBloom, currentBloom);

        Vector3 randomRotation = new Vector3(randX, randY, randZ);
        return barrelPos.localEulerAngles + randomRotation; 
    }
}
