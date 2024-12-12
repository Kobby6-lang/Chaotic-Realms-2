using UnityEngine;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    private Vector3 playerInitialPosition;
    private int playerInitialHealth;
    private Vector3[] objectInitialPositions;
    private Quaternion[] objectInitialRotations;

    public PlayerHealth playerHealth;
    public Transform[] objectsToReset;

    private List<EnemyState> enemiesInitialStates = new List<EnemyState>();

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        // Save initial states of the player
        playerInitialPosition = playerHealth.transform.position;
        playerInitialHealth = playerHealth.maxHealth;

        // Save initial states of other objects
        objectInitialPositions = new Vector3[objectsToReset.Length];
        objectInitialRotations = new Quaternion[objectsToReset.Length];
        for (int i = 0; i < objectsToReset.Length; i++)
        {
            objectInitialPositions[i] = objectsToReset[i].position;
            objectInitialRotations[i] = objectsToReset[i].rotation;
        }

        // Save initial states of enemies
        Enemy[] enemies = FindObjectsOfType<Enemy>();
        foreach (Enemy enemy in enemies)
        {
            enemiesInitialStates.Add(new EnemyState
            {
                Position = enemy.transform.position,
                Rotation = enemy.transform.rotation,
                Health = enemy.currentHealth
            });
        }
    }

    public void ResetGame()
    {
        // Reset player position and health
        playerHealth.transform.position = playerInitialPosition;
        playerHealth.currentHealth = playerInitialHealth;

        // Reset positions and rotations of objects
        for (int i = 0; i < objectsToReset.Length; i++)
        {
            objectsToReset[i].position = objectInitialPositions[i];
            objectsToReset[i].rotation = objectInitialRotations[i];
        }

        // Reset enemies' positions, rotations, and health
        Enemy[] enemies = FindObjectsOfType<Enemy>();
        for (int i = 0; i < enemies.Length; i++)
        {
            enemies[i].transform.position = enemiesInitialStates[i].Position;
            enemies[i].transform.rotation = enemiesInitialStates[i].Rotation;
            enemies[i].currentHealth = enemiesInitialStates[i].Health;
            enemies[i].ResetEnemy(); // Optional: call a method to reset specific enemy state
        }

        Debug.Log("Game reset to initial state.");
    }
}

[System.Serializable]
public class EnemyState
{
    public Vector3 Position;
    public Quaternion Rotation;
    public int Health;
}

