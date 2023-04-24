using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerHeadRotation : MonoBehaviour
{
    [SerializeField] Transform ShootTransform;

    public void RotateHeadTowardCrosAir(Vector3 crossAirPosition)
    {
        transform.LookAt(crossAirPosition);
    }
}
