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
    [SerializeField] bool isSpecial;

    [SerializeField] PlayerAttackSlot currentBeamDrawer;
    [SerializeField] PlayerAttackSlot specialBeamDrawer;

    public event Action<EnemyVulnerability> onVulnerabilityShot;

    internal void StartLaserBeam(Transform target, PlayerAttackSlot playerAttackSlot)
    {
        isBeaming = true;
        if (playerAttackSlot.AttackType == AttackType.Special)
        {
            isSpecial = true;
            specialBeamDrawer = playerAttackSlot;
        }
        else
        {
            this.currentBeamDrawer = playerAttackSlot;
        }
    }

    internal void StopLaserBeam()
    {
        isBeaming = false;
        isSpecial = false;
        currentDistance = 0;
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
        Debug.DrawRay(transform.position, transform.forward * currentDistance);
        RaycastHit[] hits = Physics.RaycastAll(transform.position, transform.forward, currentDistance);

        if (hits.Length <= 0)
        {
            if (currentDistance > maxDistance) return;
            currentDistance += growSpeed;
        }
        else
        {
            foreach (RaycastHit hit in hits)
            {
                currentDistance = Vector3.Distance(transform.position, hit.point);

                if (hit.collider.gameObject.layer == 21)
                {
                    onVulnerabilityShot?.Invoke(hit.collider.gameObject.GetComponent<EnemyVulnerability>());
                }
            }
        }
    }
}
