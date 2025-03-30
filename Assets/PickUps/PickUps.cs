using UnityEngine;

public class HealthPickup : MonoBehaviour
{
    public int healAmount = 20;
    

    private void OnTriggerEnter(Collider other)
    {
       if (other.tag == "Player")
        {
            other.GetComponent<PlayerHealth>().Heal(healAmount); Destroy(gameObject);
        }

    }
}


