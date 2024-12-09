using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeTrap : MonoBehaviour
{
    public float spikeSpeed = 2.0f; // Speed of the spike's up and down movement
    public int damageAmount = 10; // Amount of damage to the player
    public float delayTime = 1.0f; // Time delay before spikes move up again
    private Vector3 startPos; // Initial position of the spikes

    void Start()
    {
        // Record the starting position
        startPos = transform.position;
        StartCoroutine(ActivateTrap());
    }

    IEnumerator ActivateTrap()
    {
        while (true)
        {
            // Move spikes up
            yield return StartCoroutine(MoveSpike(startPos.y + 1.0f));

            // Wait before moving spikes down
            yield return new WaitForSeconds(delayTime);

            // Move spikes down
            yield return StartCoroutine(MoveSpike(startPos.y));

            // Wait before repeating the cycle
            yield return new WaitForSeconds(delayTime);
        }
    }

    IEnumerator MoveSpike(float targetY)
    {
        Vector3 targetPosition = new Vector3(startPos.x, targetY, startPos.z);
        while (Mathf.Abs(transform.position.y - targetY) > 0.01f)
        {
            transform.position = Vector3.Lerp(transform.position, targetPosition, spikeSpeed * Time.deltaTime);
            yield return null;
        }
        transform.position = targetPosition;
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Triggered by: " + other.name); // Debugging line to check trigger
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




