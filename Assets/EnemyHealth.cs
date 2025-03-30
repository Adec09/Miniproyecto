using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] public float health;
    Animator anim;
    EnemyIA enemyai;
    RagdollManager ragdollManager;
    [HideInInspector] public bool isDead;
    SceneTrigger sceneTrigger;

    private void Start()
    {
        ragdollManager = GetComponent<RagdollManager>();
        enemyai = GetComponent<EnemyIA>();   
        anim = GetComponent<Animator>();
        sceneTrigger = FindAnyObjectByType<SceneTrigger>();
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
        anim.enabled = false;
        enemyai.agent.isStopped = true;
        sceneTrigger.KillEnemy();
        enemyai.enabled = false;
        ragdollManager.TriggerRagdoll();
        Debug.Log("Death");
    }
}
