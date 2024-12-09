using System.Collections;
using UnityEngine;

public class PlayerPowerUp : MonoBehaviour
{
    public float speedBoostMultiplier = 7.5f; // Adjusted multiplier for the speed boost
    public float speedBoostDuration = 7f; // Duration of the speed boost
    public float maxSpeed = 15f; // Maximum speed limit

    private PlayerStateMachine playerStateMachine;
    private float originalSpeed;

    void Start()
    {
        playerStateMachine = GetComponent<PlayerStateMachine>();
        if (playerStateMachine == null)
        {
            Debug.LogError("PlayerStateMachine script not found on the player!");
        }
        originalSpeed = playerStateMachine.RunMultiplier; // Store the original run speed
    }

    public void ActivatePowerUp()
    {
        StartCoroutine(SpeedBoost());
    }

    private IEnumerator SpeedBoost()
    {
        Debug.Log("Speed boost activated!");
        playerStateMachine._runMultiplier *= speedBoostMultiplier;

        // Ensure the player's speed does not exceed the maximum speed
        if (playerStateMachine.RunMultiplier > maxSpeed)
        {
            playerStateMachine._runMultiplier = maxSpeed;
        }

        yield return new WaitForSeconds(speedBoostDuration);

        playerStateMachine._runMultiplier = originalSpeed; // Reset the player's speed
        Debug.Log("Speed boost ended.");
    }
}



