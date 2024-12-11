using UnityEngine;

public class SmoothRotate : MonoBehaviour
{
    public float rotationSpeed = 10f; // Speed of rotation

    void Update()
    {
        // Calculate rotation step
        float step = rotationSpeed * Time.deltaTime;

        // Apply smooth rotation
        transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0, transform.eulerAngles.y + step, 0), step);
    }
}
