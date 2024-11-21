using System.Collections;
using UnityEngine;

public class SoundState : MonoBehaviour
{
    public AudioSource footstepSource;
    public AudioSource jumpSource;
    public AudioSource yawnSource;
    public AudioSource landingSource;

    public AudioClip[] footstepSounds;
    public AudioClip jumpSound;
    public AudioClip yawnSound;
    public AudioClip landingSound;

    public float footstepVolume = 0.5f;
    public float jumpVolume = 0.7f;
    public float yawnVolume = 0.6f;
    public float landingVolume = 0.8f;

    private CharacterController characterController;

    void Start()
    {
        characterController = GetComponent<CharacterController>();

        footstepSource.volume = footstepVolume;
        jumpSource.volume = jumpVolume;
        yawnSource.volume = yawnVolume;
        landingSource.volume = landingVolume;

        footstepSource.loop = true; // Loop footstep sound if needed
    }

    void Update()
    {
        HandleFootsteps();
        HandleJump();
        HandleYawn();
    }

    void HandleFootsteps()
    {
        // Play footstep sound when character is moving and grounded
        if (characterController.isGrounded && characterController.velocity.magnitude > 2f && !footstepSource.isPlaying)
        {
            footstepSource.clip = footstepSounds[Random.Range(0, footstepSounds.Length)];
            footstepSource.Play();
        }
        else if (!characterController.isGrounded || characterController.velocity.magnitude <= 2f)
        {
            footstepSource.Stop();
        }
    }

    void HandleJump()
    {
        if (Input.GetButtonDown("Jump") && characterController.isGrounded)
        {
            jumpSource.PlayOneShot(jumpSound, jumpVolume);
        }
    }

    void HandleYawn()
    {
        // Example: Trigger yawning sound with a key press (e.g., "Y" key)
        if (Input.GetKeyDown(KeyCode.Y))
        {
            yawnSource.PlayOneShot(yawnSound, yawnVolume);
        }
    }

    void HandleLanding() 
    {
        
        landingSource.PlayOneShot(landingSound, landingVolume);
    }
}
