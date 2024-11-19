using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyDetect : MonoBehaviour
{
    private bool inContact = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 size = GetComponent<Collider>().bounds.size;
        Vector3 center = GetComponent<Collider>().bounds.center;
        Vector3 direction = GetComponent<Collider>().transform.up;
        if (Physics.BoxCast(center, size, direction) && inContact)
        {
            Fall();
        }
    }

    public void Hit(Transform player)
    {
        if ((player.position.y > transform.position.y))
        {
            Debug.Log("Enemy hit");
            inContact = true;

        }

    }

    private void Fall()
    {
        GetComponent<Collider>().enabled = false;
        GetComponent<Rigidbody>().isKinematic = false;
        GetComponent<NavMeshAgent>().enabled = false;
    }
}
