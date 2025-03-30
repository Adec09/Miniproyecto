using UnityEngine;

public class AmmoPickup : MonoBehaviour
{
    public int ammoAmount = 30;
    

    


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            other.GetComponentInChildren<WeaponAmmo>().Ammo(ammoAmount); Destroy(gameObject);
        }

    }
}

