using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int maxHealth = 50;
    public int currentHealth;

    private void Awake()
    {
        currentHealth = maxHealth;
    }

    public void ResetEnemy()
    {
        // Reset any additional enemy state if needed
        Debug.Log("Enemy reset");
    }
}

