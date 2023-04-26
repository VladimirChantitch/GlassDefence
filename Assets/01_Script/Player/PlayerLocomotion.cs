using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerLocomotion : MonoBehaviour
{
    [SerializeField] Rigidbody rb = null;
    [SerializeField] float speed = 2;
    [SerializeField] float gravityIntensity = -1;
    [SerializeField] float DashDuration = 0.5f;
    [SerializeField] float DashPower = 25f;
    [SerializeField] bool isDashing;
    [SerializeField] bool isKnockedBack;
    [SerializeField] float specialKnocBackIntensity = 10f;

    public event Action onDashStarted;
    public event Action onDashStopped;

    private void Awake()
    {
        if (rb == null) rb = GetComponent<Rigidbody>();
    }

    Vector2 currentDirection;
    Vector2 currentKnocBack;

    public void Move(Vector2 motion)
    {
        if (!isDashing)
        {
            currentDirection = motion;
            if (motion.x == 0 && motion.y == 0)
            {
                return;
            }
            if (!isKnockedBack)
            {
                Vector3 direction = motion * speed;
                rb.velocity = HandleGravityScalling(direction);
            }
        }
    }

    public void StartDash()
    {
        if (!isDashing)
        {
            isDashing = true;
            onDashStarted?.Invoke();

            Vector3 direction = currentDirection * DashPower;
            rb.velocity = HandleGravityScalling(direction);
            StartCoroutine(Dash());
        }
    }

    public void UpdateKnocBack(Vector2 lookDirection)
    {
        currentKnocBack = -lookDirection * specialKnocBackIntensity + currentDirection * speed;
        currentKnocBack.y = 0;
        rb.velocity = HandleGravityScalling(currentKnocBack);
    }

    public void StartKnocBack()
    {
        isKnockedBack = true;
    }

    public void StopKnocBack()
    {
        isKnockedBack = false;
    }

    private Vector3 HandleGravityScalling(Vector3 direction)
    {
        if (isDashing)
        {
            direction.y = gravityIntensity * 5 + rb.velocity.y;
        }
        else
        {
            direction.y = gravityIntensity + rb.velocity.y;
        }

        return direction;
    }

    IEnumerator Dash()
    {
        yield return new WaitForSeconds(DashDuration);
        isDashing = false;
        currentDirection = Vector3.zero;
        rb.velocity = Vector3.zero;
        onDashStopped?.Invoke();
    }
}
