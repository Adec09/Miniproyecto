using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.AI;

public class EnemyIA : MonoBehaviour
{
    public Transform player;
    public float chaseRange = 10f;
    public float attackRange = 2f;
    public float attackCooldown = 1.5f;
    private float lastAttackTime;
    public NavMeshAgent agent;
    Animator anim;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        player = FindObjectOfType<MovimientoPersonaje>().transform;
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        if (distanceToPlayer <= attackRange)
        {
            AttackPlayer();
        }
        else if (distanceToPlayer <= chaseRange) 
        {
            ChasePlayer();
        }
        else if (agent.velocity == Vector3.zero)
        {
            anim.SetBool("Running", false);
        }
        else
        {
            agent.SetDestination(transform.position); 
        }
    }

    void ChasePlayer()
    {
        agent.SetDestination(player.position);
        anim.SetBool("Running", true);
        
    }

    void AttackPlayer()
    {
        if (Time.time >= lastAttackTime + attackCooldown)
        {
            lastAttackTime = Time.time;
            anim.SetTrigger("Attack");
            
        }
    }
}

