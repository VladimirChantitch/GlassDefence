using System;
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

    float limitDistance = 0;

    public event Action onCloseEnought;

    private void Awake()
    {
        if (rb == null) rb = GetComponent<Rigidbody>(); 
    }

    public void Init(Transform target, float limitDistance)
    {
        this.target = target;
        this.limitDistance = limitDistance;
    }

    public void StartRunning(Transform target)
    {
        canRun = true;
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
        if (Vector3.Distance(transform.position, target.position) <= limitDistance)
        {
            onCloseEnought?.Invoke();
        }
    }
}
