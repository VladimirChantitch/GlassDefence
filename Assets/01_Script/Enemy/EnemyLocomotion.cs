using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class EnemyLocomotion : MonoBehaviour
{
    [SerializeField] Rigidbody rb;
    [SerializeField] float speed;
    [SerializeField] bool canRun;
    Transform target;

    private void Awake()
    {
        if (rb == null) rb = GetComponent<Rigidbody>(); 
    }

    public void StartRunning(Transform target)
    {
        canRun = true;
        this.target = target;
    }

    public void StopRunning()
    {
        canRun = false;
    }

    private void FixedUpdate()
    {
        if (canRun)
        {
            Move();
        }
    }

    private void Move()
    {
        Vector3 direction = transform.right;
        rb.velocity = direction.normalized * speed;
    }
}
