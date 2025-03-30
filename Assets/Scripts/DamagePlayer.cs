using Unity.Cinemachine;
using UnityEngine;

public class DamagePlayer : MonoBehaviour
{

    public int damage = 20;
    private void OnTriggerEnter(Collider coll)
    {
        if (coll.tag == "Player" )
        {
            coll.GetComponent<PlayerHealth>().TakeDamage(damage);
        }
    }
    void Start()
    {
        
    }

   
    void Update()
    {
        
    }
}
