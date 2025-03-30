using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] public float health;
    RagdollManager ragdollManager;
    [HideInInspector] public bool isDead;

    private void Start()
    {
        ragdollManager = GetComponent<RagdollManager>();
    }

    public void TakeDamage(float damage)
    {
        if (health > 0)
        {
            health -= damage;
            if (health <= 0) EnemyDeath();
            Debug.Log("Hit");
        }
        
    }

   public void EnemyDeath()
    {
        ragdollManager.TriggerRagdoll();
        Debug.Log("Death");
    }
}
