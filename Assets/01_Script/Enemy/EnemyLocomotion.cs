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
    [SerializeField] Transform target;
    [SerializeField] float gravityIntensity = 150;

    float limitDistance = 0;

    public event Action onCloseEnought;
    public event Action onFarEnought;

    private void Awake()
    {
        if (rb == null) rb = GetComponent<Rigidbody>(); 
    }

    public void Init(Transform target, float limitDistance)
    {
        this.target = target;
        this.limitDistance = limitDistance;
    }

    public void StartRunning()
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
        else
        {
            if (Vector3.Distance(transform.position, target.position) > limitDistance)
            {
                onFarEnought?.Invoke();
            }
        }
    }

    private void Move()
    {
        if (target != null)
        {
            Vector3 direction = transform.right * speed;
            direction.y = rb.velocity.y + gravityIntensity;
            rb.velocity = direction;
            if (Vector3.Distance(transform.position, target.position) <= limitDistance)
            {
                onCloseEnought?.Invoke();
            }
        }
    }
}
