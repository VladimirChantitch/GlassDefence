using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace enemies
{
    public class EnemyManager : MonoBehaviour
    {
        [SerializeField] Transform playerTransform = null;
        [SerializeField] EnemyLocomotion locomotion = null;
        [SerializeField] List<EnemyVulnerability> vulnerabilities = new List<EnemyVulnerability>();

        [SerializeField] int totalVulnerabilitiesLeft;

        public event Action onEnemyKilled;

        private void Awake()
        {
            if (locomotion == null) locomotion = GetComponent<EnemyLocomotion>();
        }

        private void Start()
        {
            if (playerTransform == null) playerTransform = ResourcesManager.Instance.PlayerTransform;

            SubscribeToLocomotion();
            SubscribeToVulnerabilities();

        }

        private void SubscribeToLocomotion()
        {
            locomotion.onCloseEnought += () =>
            {
                locomotion.StopRunning();
            };

            locomotion.onFarEnought += () =>
            {
                locomotion.StartRunning();
            };

            locomotion.Init(playerTransform, 3f);
            locomotion.StartRunning();
        }

        private void SubscribeToVulnerabilities()
        {
            totalVulnerabilitiesLeft = vulnerabilities.Count;
            foreach(EnemyVulnerability vulnerability in vulnerabilities)
            {
                vulnerability.onVulnerabilityDestroyed += (vuln) =>
                {
                    HandleDesactivationOfVulnerability(vulnerability);
                };
            }
        }

        private void HandleDesactivationOfVulnerability(EnemyVulnerability vulnerability)
        {
            Debug.Log("Vulnérability destroyed");
            vulnerability.gameObject.SetActive(false);
            totalVulnerabilitiesLeft -= 1;
            if (totalVulnerabilitiesLeft <= 0)
            {
                HandleDeath();
            }
        }

        private void HandleDeath()
        {
            Debug.Log("Enemy Killed");
            Destroy(gameObject);
            onEnemyKilled?.Invoke();
        }
    }
}

