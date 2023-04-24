using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] PlayerLaserBeamHandler playerLaserBeamHandler;
    [SerializeField] bool isAttacking;
    [SerializeField] AttackType currentAttackType;

    public event Action onAttackReset;

    private void Awake()
    {
        if (playerLaserBeamHandler == null) playerLaserBeamHandler = GetComponent<PlayerLaserBeamHandler>();
        playerLaserBeamHandler.onVulnerabilityShot += (vulnerability) => vulnerability.DamageVulnerability(-0.5f, currentAttackType);
    }

    public void ChangeAttackType(AttackType newAttackType)
    {
        currentAttackType = newAttackType;
        if (isAttacking)
        {
            StopAttack();
            onAttackReset?.Invoke();
        }
    }

    internal void StartAttack(Transform target)
    {
        playerLaserBeamHandler.StartLaserBeam(target, ResourcesManager.Instance.GetAttack(currentAttackType));
    }

    internal void StopAttack()
    {
        playerLaserBeamHandler.StopLaserBeam();
    }
}
