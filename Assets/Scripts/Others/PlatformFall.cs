using System.Collections;
using UnityEngine;

public class PlatformFall : MonoBehaviour
{
    public float fallDelay = 2.0f; // Time in seconds before the platform falls
    private Rigidbody rb;
    private bool isPlayerOnPlatform = false;
    private Coroutine fallCoroutine;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.isKinematic = true; // Ensure it is kinematic initially
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player on the platform.");
            isPlayerOnPlatform = true;
            if (fallCoroutine == null)
            {
                fallCoroutine = StartCoroutine(FallAfterDelay());
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player exited the platform.");
            isPlayerOnPlatform = false;
            if (fallCoroutine != null)
            {
                StopCoroutine(fallCoroutine);
                fallCoroutine = null;
            }
        }
    }

    IEnumerator FallAfterDelay()
    {
        yield return new WaitForSeconds(fallDelay);
        if (isPlayerOnPlatform)
        {
            Debug.Log("Platform falling.");
            rb.isKinematic = false; // Enable physics
        }
    }
}




