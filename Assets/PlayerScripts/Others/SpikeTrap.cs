using UnityEngine;

public class SpikeTrap : MonoBehaviour
{
    public int damageAmount = 10; // Amount of damage to the player

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(damageAmount);
                Debug.Log("Player took damage: " + damageAmount); // Debugging line to confirm damage
            }
        }
    }
}




