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
        // Add squash animation or effect here
        Destroy(gameObject, 0.5f); // Destroy the enemy after 0.5 seconds
    }

    private void Fall()
    {
        GetComponent<Collider>().enabled = false;
        GetComponent<Rigidbody>().isKinematic = false;
        GetComponent<NavMeshAgent>().enabled = false;
    }
}

