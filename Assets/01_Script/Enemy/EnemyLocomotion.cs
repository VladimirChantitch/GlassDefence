using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLocomotion : MonoBehaviour
{
    [SerializeField] Rigidbody rb;
    [SerializeField] float speed;
    [SerializeField] bool canRun;

    public void StartRunning()
    {
        canRun = true;
    }

    public void StopRunning()
    {
        canRun = false;
    }

    private void FixedUpdate()
    {
        
    }
}
