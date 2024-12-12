using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public Transform respawnPoint; // Reference to the respawn position
    private DeathAndRespawnManager respawnManager;

    private void Awake()
    {
        currentHealth = maxHealth;
    }

    void Start()
    {
        respawnManager = FindObjectOfType<DeathAndRespawnManager>(); // Find the DeathAndRespawnManager script in the scene
        if (respawnManager == null)
        {
            Debug.LogError("DeathAndRespawnManager not found in the scene!");
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        Debug.Log("Player health: " + currentHealth); // Debugging line to check health
        if (currentHealth <= 0)
        {
            currentHealth = 0;
            HandleDeath();
        }
    }

    void HandleDeath()
    {
        Debug.Log("HandleDeath called");
        if (respawnManager != null)
        {
            respawnManager.IncreaseDeaths(); // Notify DeathAndRespawnManager of the death
        }
        Respawn(); // Call respawn method
    }

    void Respawn()
    {
        Debug.Log("Respawn called");
        // Reset player's position to the respawn point
        if (respawnPoint != null)
        {
            transform.position = respawnPoint.position;
            currentHealth = maxHealth; // Reset health
            Debug.Log("Player respawned");
        }
        else
        {
            Debug.LogWarning("Respawn point not set!");
        }
    }
}




