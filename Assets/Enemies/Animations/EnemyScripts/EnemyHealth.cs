using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth = 1;
    public int currentHealth;

    void Awake()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("Enemy died");
        // Add death logic here (e.g., play animation, disable enemy, etc.)
        Destroy(gameObject);
    }

    void OnCollisionEnter(Collision collision)
    {
        // Example to handle specific collision logic
        if (collision.gameObject.CompareTag("Player"))
        {
            // Handle player collision here (if necessary)
        }
    }

}
