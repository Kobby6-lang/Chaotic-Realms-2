using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyDetect : MonoBehaviour
{
    private bool inContact = false;
    public int maxHealth = 10;
    public int currentHealth;
    public bool isSquashed = false;
    public float fallDelay = 1.0f; // Delay before falling through the floor
    public float squashDelay = 0.5f; // Delay before starting the squash effect

    void Awake()
    {
        currentHealth = maxHealth;
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 size = GetComponent<Collider>().bounds.size;
        Vector3 center = GetComponent<Collider>().bounds.center;
        Vector3 direction = GetComponent<Collider>().transform.up;
        if (Physics.BoxCast(center, size, direction) && inContact)
        {
            Fall();
        }
    }

    public void Hit(Transform player)
    {
        if (player.position.y > transform.position.y)
        {
            Debug.Log("Enemy hit");
            inContact = true;
            TakeDamage(maxHealth); // Take full damage to squash the enemy
            GrantPowerUp(player); // Grant the player a power-up
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        Debug.Log("Enemy health: " + currentHealth);
        if (currentHealth <= 0 && !isSquashed)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("Enemy squashed!");
        isSquashed = true;
        StartCoroutine(SquashEffect());
    }

    private IEnumerator SquashEffect()
    {
        // Wait for the squash delay before starting the squash effect
        yield return new WaitForSeconds(squashDelay);

        // Perform squash effect
        Vector3 originalScale = transform.localScale;
        Vector3 squashedScale = new Vector3(originalScale.x, originalScale.y * 0.5f, originalScale.z);

        float squashDuration = 0.2f;
        float elapsedTime = 0f;

        while (elapsedTime < squashDuration)
        {
            transform.localScale = Vector3.Lerp(originalScale, squashedScale, elapsedTime / squashDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.localScale = squashedScale;

        // Wait for a moment before falling through the floor
        yield return new WaitForSeconds(fallDelay);

        Fall();
        Destroy(gameObject, 0.5f); // Destroy the enemy after falling
    }

    private void Fall()
    {
        GetComponent<Collider>().enabled = false;
        GetComponent<Rigidbody>().isKinematic = false;
        GetComponent<NavMeshAgent>().enabled = false;
    }

    private void GrantPowerUp(Transform player)
    {
        // Grant the player a speed power-up
        Debug.Log("Power-up granted to player!");
        PlayerPowerUp powerUp = player.GetComponent<PlayerPowerUp>();
        if (powerUp != null)
        {
            powerUp.ActivatePowerUp();
        }
    }
}

