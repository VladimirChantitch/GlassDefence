using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class PlayerAttackSlot
{
    [SerializeField] AttackType attackType;
    [SerializeField] float furyCost;
    [SerializeField] float damage;
    public AttackType AttackType { get => attackType; }
    public float FuryCost { get => furyCost; }
    public float Damage { get => damage; }
}
