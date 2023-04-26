using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] PlayerLaserBeamHandler playerLaserBeamHandler;
    [SerializeField] PlayerDashCollider playerDashCollider;
    [SerializeField] bool isAttacking;
    [SerializeField] bool isDashing;
    [SerializeField] bool isSpecialAttack;
    [SerializeField] AttackType currentAttackType;

    PlayerAttackSlot playerAttackSlot;

    public event Action onAttackReset;
    public event Action<float> onSpecialAttackStarted;
    public event Action onVulnerabilityDestroyed;

    private void Awake()
    {
        if (playerLaserBeamHandler == null) playerLaserBeamHandler = GetComponent<PlayerLaserBeamHandler>();
        playerLaserBeamHandler.onVulnerabilityShot += (vulnerability) => HandleVulnerabilityShot(vulnerability); 
    }

    public void ChangeAttackType(AttackType newAttackType)
    {
        currentAttackType = newAttackType;
        if (isAttacking && !isSpecialAttack)
        {
            StopAttack();
            onAttackReset?.Invoke();
            return;
        }
    }

    public void StartAttack(Transform target)
    {
        if (!isDashing && !isSpecialAttack)
        {
            isAttacking = true;
            playerAttackSlot = ResourcesManager.Instance.GetAttack(currentAttackType);
            playerLaserBeamHandler.StartLaserBeam(target, playerAttackSlot);
            if (currentAttackType == AttackType.Special)
            {
                isSpecialAttack = true;
                onSpecialAttackStarted?.Invoke(playerAttackSlot.FuryCost);
            }
        }
    }

    public void StopAttack()
    {
        if (!isSpecialAttack)
        {
            isAttacking = false;
            playerLaserBeamHandler.StopLaserBeam();
        }
    }

    public void StopSpecialAttack()
    {
        isAttacking = false;
        isSpecialAttack = false;
        playerLaserBeamHandler.StopLaserBeam();
    }

    public void StartDashAttack()
    {
        isDashing = true;
        playerDashCollider.OpenCollider();
        StopAttack();
    }

    public void StopDashAttack()
    {
        isDashing = false;
        playerDashCollider.CloseCollider();
    }

    private AttackType GetCurrentAttackType()
    {
        if (isSpecialAttack)
        {
            return AttackType.Special;
        }
        else
        {
            return currentAttackType;
        }
    }

    EnemyVulnerability currentVulnerability;

    private void HandleVulnerabilityShot(EnemyVulnerability vulnerability)
    {
        if (currentVulnerability == null)
        {
            currentVulnerability = vulnerability;
            vulnerability.onVulnerabilityDestroyed += () => HandleVulnerabilityDestroyed();
        }
        else if (currentVulnerability != vulnerability)
        {
            currentVulnerability.onVulnerabilityDestroyed -= () => HandleVulnerabilityDestroyed();
            currentVulnerability = vulnerability;
            vulnerability.onVulnerabilityDestroyed += () => HandleVulnerabilityDestroyed();
        }
        vulnerability.DamageVulnerability(playerAttackSlot.Damage, GetCurrentAttackType());
    }

    private void HandleVulnerabilityDestroyed()
    {
        onVulnerabilityDestroyed?.Invoke();
    }
}
