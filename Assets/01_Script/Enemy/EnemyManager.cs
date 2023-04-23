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
            if (playerTransform == null)
            {
                playerTransform = ResourcesManager.Instance.PlayerTransform;
            }
        }


    }
}

