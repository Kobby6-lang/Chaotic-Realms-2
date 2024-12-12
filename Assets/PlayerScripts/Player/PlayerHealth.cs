using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    private GameManager gameManager;

    private void Awake()
    {
        currentHealth = maxHealth;
    }

    void Start()
    {
        gameManager = GameManager.Instance;
        if (gameManager == null)
        {
            Debug.LogError("GameManager not found in the scene!");
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
        if (gameManager != null)
        {
            gameManager.ResetGame(); // Call the game reset method
        }
    }
}




