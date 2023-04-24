using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerLocomotion : MonoBehaviour
{
    [SerializeField] Rigidbody rb = null;
    [SerializeField] float speed = 2;
    [SerializeField] float gravityIntensity = 1;

    private void Awake()
    {
        if (rb == null) rb = GetComponent<Rigidbody>();
    }

    internal void Move(Vector2 motion)
    {
        Vector3 direction = motion * speed;
        direction.y = gravityIntensity + rb.velocity.y;

        rb.velocity = direction;
    }
}
