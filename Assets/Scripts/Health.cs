using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Health : MonoBehaviour
{
    public float maxHealth = 100;
    public TextMeshProUGUI healthCount;
    private float currentHealth;
    public GameObject gameObject;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        UpdateHealthUI();
    }

    private void UpdateHealthUI()
    {
        if (healthCount != null)
        {
            healthCount.text = "Health: " + currentHealth.ToString("0") + "/" + maxHealth.ToString("0");
        }
    }

    public void TakeDamage(float damageAmount)
    {
        currentHealth -= damageAmount;
        currentHealth = Mathf.Max(currentHealth, 0); // Ensure health doesn't go below zero
        UpdateHealthUI();

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public void Heal(float healAmount)
    {
        currentHealth += healAmount;
        currentHealth = Mathf.Min(currentHealth, maxHealth); // Ensure health doesn't exceed maximum
        UpdateHealthUI();
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}
