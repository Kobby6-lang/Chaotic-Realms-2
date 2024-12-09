using UnityEngine;

public class CubeAnimationController : MonoBehaviour
{
    private Animator animator;

    void Start()
    {
        // Get the Animator component
        animator = GetComponent<Animator>();

        // Start the animation
        animator.Play("CubeRotate");
    }
}
