using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLaserBeamHandler : MonoBehaviour
{
    [SerializeField] float maxDistance;
    [SerializeField] float growSpeed;
    [SerializeField] float currentDistance;
    [SerializeField] bool isBeaming;

    internal void StartLaserBeam(Transform target, ResourcesManager.BeamDrawer beamDrawer)
    {
        isBeaming = true;
    }

    internal void StopLaserBeam()
    {
        isBeaming = false;
    }

    private void FixedUpdate()
    {
        if (isBeaming)
        {
            Grow();
        }
    }

    private void Grow()
    {
        if (Physics.Raycast(transform.position, transform.forward, currentDistance, 20))
        {
            Debug.Log($"'im hitting");
            Debug.DrawRay(transform.position, transform.forward);
        }
        else
        {
            currentDistance += growSpeed;
        }
    }
}
