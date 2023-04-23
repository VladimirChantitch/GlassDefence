using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace enemies
{
    public class EnemyManager : MonoBehaviour
    {
        [SerializeField] Transform playerTransform = null;
        [SerializeField] EnemyLocomotion locomotion = null;

        private void Awake()
        {
            if (locomotion == null) locomotion = GetComponent<EnemyLocomotion>();
        }

        private void Start()
        {
            if (playerTransform == null)
            {
                playerTransform = ResourcesManager.Instance.PlayerTransform;
            }
            locomotion.onCloseEnought += () =>
            {
                locomotion.StopRunning();
            };
            locomotion.StartRunning(playerTransform);
        }
    }
}

