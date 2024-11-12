using UnityEngine;

public class ToggleVisibility : MonoBehaviour
{
    public Transform player;
    public float detectionRadius = 5f; // Distance within which the object should be visible
    private MeshRenderer meshRenderer;
    private Collider objectCollider;

    void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        objectCollider = GetComponent<Collider>();
    }

    void Update()
    {
        float distance = Vector3.Distance(player.position, transform.position);
        if (distance <= detectionRadius)
        {
            ShowObject();
        }
        else
        {
            HideObject();
        }
    }

    void ShowObject()
    {
        meshRenderer.enabled = true;
        objectCollider.enabled = true;
    }

    void HideObject()
    {
        meshRenderer.enabled = false;
        objectCollider.enabled = false;
    }
}


