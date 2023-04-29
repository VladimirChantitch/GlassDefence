using enemies;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using utils.colliders;

public class PlayerDashCollider : OpenableColliders
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 21)
        {
            other.gameObject.GetComponent<EnemyVulnerability>().DamageVulnerability(-5000, AttackType.Special);
        }
    }
}
