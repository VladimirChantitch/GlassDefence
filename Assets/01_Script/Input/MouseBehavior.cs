using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MouseBehavior : MonoBehaviour
{
    public event Action<Transform> CrossAirPositionChanged;
    Camera camera;

    public void Init(Camera camera)
    {
        this.camera = camera;
        Cursor.visible = false;
    }

    private void UpdateCrossAirPosition(Vector3 position, float distanceToPlayer)
    {
        position.z = distanceToPlayer;
        Vector3 objPos = camera.ScreenToWorldPoint(position);

        transform.position = objPos;
        CrossAirPositionChanged?.Invoke(transform);
    }

    internal void UpdateRealMousePosition(Vector2 position, float distanceToPlayer)
    {
        UpdateCrossAirPosition(position, distanceToPlayer);
    }
}
