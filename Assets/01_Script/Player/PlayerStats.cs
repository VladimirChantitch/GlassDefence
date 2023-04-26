using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    [SerializeField] float health;
    [SerializeField] float maxHealth;
    [SerializeField] float fury;
    [SerializeField] float maxFury;
    [SerializeField] float furyDecaySpeed;

    Coroutine coroutine;

    public event Action onPlayerDied;
    public event Action onFuryDecayFinished;

    public void GenerateFury(float amount)
    {
        fury += amount;
        if (fury > maxFury)
        {
            fury = maxFury;
        }
    }

    public bool TryConsumeFury(float amount)
    {
        if (fury < amount)
        {
            return false;
        }
        else
        {
            fury -= amount;
            return true;
        }
    }

    public void RecoverHealth(float amount)
    {
        health += amount;
        if (health > maxHealth)
        {
            health = maxHealth;
        }
    }

    public void LoseHealth(float amount)
    {
        health -= amount;
        if (health <= 0)
        {
            health = 0;
            onPlayerDied?.Invoke();
        }
    }

    public bool IsFuryMaxed()
    {
        if (fury >= maxFury)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void StartDecayFury(float decayRate)
    {
        coroutine = StartCoroutine(DecayFuryOverTime(decayRate));
    }

    IEnumerator DecayFuryOverTime(float decayRate)
    {
        while (TryConsumeFury(decayRate))
        {
            yield return new WaitForSeconds(furyDecaySpeed);
        }
        onFuryDecayFinished?.Invoke();
    }
}
