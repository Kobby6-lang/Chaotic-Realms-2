using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    public float squashForce = 5f; // The force applied downwards to squash the enemy
    private CharacterController characterController;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        if (characterController == null)
        {
            Debug.LogError("CharacterController not found on player!");
        }
    }

    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Hit enemy: " + hit.gameObject.name);
            EnemyDetect enemy = hit.gameObject.GetComponent<EnemyDetect>();
            if (enemy != null && !enemy.isSquashed)
            {
                Vector3 hitNormal = hit.normal;
                Debug.Log("Hit normal: " + hitNormal);
                if (hitNormal.y < -0.5f) // Check if the player is hitting the top of the enemy
                {
                    Debug.Log("Squashing enemy");
                    enemy.Hit(transform); // Call the Hit method on the enemy
                    Vector3 bounce = Vector3.up * squashForce;
                    characterController.Move(bounce * Time.deltaTime); // Apply a bounce force to the player
                }
            }
        }
    }
}


