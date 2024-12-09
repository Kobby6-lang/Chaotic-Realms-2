using UnityEngine;

public class RotateClockwise : MonoBehaviour
{
    public float rotationSpeed = 30f; // Speed of rotation

    void Update()
    {
        // Rotate the object clockwise around the local y-axis
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime, Space.Self);
    }
}

