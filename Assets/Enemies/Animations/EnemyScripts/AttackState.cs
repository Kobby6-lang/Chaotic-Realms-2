using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AttackState : StateMachineBehaviour
{
    Transform player;
    PlayerHealth playerHealth;
    float attackRange = 1.5f;
    float attackCooldown = 1f; // Time in seconds between attacks
    float lastAttackTime;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = GameObject.FindGameObjectWithTag("Player")?.transform;
        playerHealth = player.GetComponent<PlayerHealth>();

        if (player == null || playerHealth == null)
        {
            Debug.LogWarning("Player or PlayerHealth script not found!");
            return;
        }

        lastAttackTime = Time.time; // Initialize the last attack time
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (player == null || playerHealth == null) return;

        // Smoothly rotate towards the player
        Vector3 direction = (player.position - animator.transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        animator.transform.rotation = Quaternion.Slerp(animator.transform.rotation, lookRotation, Time.deltaTime * 5);

        float distance = Vector3.Distance(player.position, animator.transform.position);
        if (distance > attackRange)
        {
            animator.SetBool("isAttacking", false);
        }

        // Perform the attack if cooldown has passed
        if (Time.time >= lastAttackTime + attackCooldown)
        {
            AttackPlayer();
            lastAttackTime = Time.time; // Reset the attack time
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // No specific action needed on exit
    }

    private void AttackPlayer()
    {
        if (playerHealth != null)
        {
            playerHealth.TakeDamage(15); // Example damage value
        }
    }
}


