using UnityEngine;
using UnityEngine.AI;


public class ZombieControl : MonoBehaviour
{
    private UnityEngine.AI.NavMeshAgent agent;
    public Transform target;
    public int damage = 10; // Adjust the damage value as needed.

    void Awake()
    {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
    }

    void Update()
    {
        agent.SetDestination(target.position);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Attack(other.gameObject);
        }
    }

    private void Attack(GameObject player)
    {
        // Check if the object has a script/component to take damage
        Health healthController = player.GetComponent<Health>();
        
        if (healthController != null)
        {
            // Apply damage to the player object
            healthController.TakeDamage(damage);
        }
    }
}
