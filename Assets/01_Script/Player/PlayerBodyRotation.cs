using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBodyRotation : MonoBehaviour
{
    public event Action onIsFacingLeft;
    public event Action onIsFacingRight;

    internal void RotateBody(Vector3 position, bool isFacingLeft)
    {
        Vector3 directionToCrossAir = position - transform.position;

        if (directionToCrossAir.x < 0)
        {
            if (!isFacingLeft)
            {
                transform.Rotate(new Vector3(0, 180, 0));
                onIsFacingLeft?.Invoke();
            }
        }
        else
        {
            if (isFacingLeft)
            {
                transform.Rotate(new Vector3(0, -180, 0));
                onIsFacingRight?.Invoke();
            }
        }
    }
}
