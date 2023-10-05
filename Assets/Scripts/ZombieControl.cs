using UnityEngine;
using UnityEngine.AI;
using System.Collections;

public class ZombieControl : MonoBehaviour
{
    private UnityEngine.AI.NavMeshAgent agent;
    public Transform target;
    public GameObject damageRange;
    public int damage = 10; // Adjust the damage value as needed.
    public float attackRate = 1.0f; // Adjust the attack rate in seconds.

    private bool canAttack = true;

    void Start()
    {
        damageRange.SetActive(false);
        target = GameObject.FindWithTag("Player").GetComponent<Transform>();
    }

    void Awake()
    {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
    }

    void Update()
    {
        agent.SetDestination(target.position);

        // Check if the zombie can attack again based on the attack rate.
        if (!canAttack)
        {
            // Check if enough time has passed since the last attack.
            if (Time.time >= (Time.time + attackRate))
            {
                canAttack = true;
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && canAttack)
        {
            damageRange.SetActive(true);
            Attack(other.gameObject);
        }
    }

    private void Attack(GameObject player)
    {
        // Check if the object has a script/component to take damage
        Health healthController = player.GetComponent<Health>();

        if (healthController != null)
        {
            StartCoroutine(AttackCoroutine(healthController));
        }
    }

    IEnumerator AttackCoroutine(Health healthController)
    {
        canAttack = false; // Prevent further attacks until the cooldown is over.

        // Apply damage to the player object
        healthController.TakeDamage(damage);
        
        damageRange.SetActive(false); // Deactivate the damage range.

        yield return new WaitForSeconds(attackRate);
    }
}
