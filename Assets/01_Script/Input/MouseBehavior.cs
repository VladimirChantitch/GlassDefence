using Cinemachine;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MouseBehavior : MonoBehaviour
{
    public event Action<Transform> CrossAirPositionChanged;
    Camera camera;
    [SerializeField] float plane;

    public void Init(Camera camera)
    {
        this.camera = camera;
        Cursor.visible = false;
    }

    [SerializeField] Vector2 lastPos;
    [SerializeField] float lastDist;

    private void UpdateCrossAirPosition(Vector3 position, float distanceToPlayer)
    {
        position.z = distanceToPlayer;
        Vector3 objPos = camera.ScreenToWorldPoint(position);

        transform.position = objPos;
        CrossAirPositionChanged?.Invoke(transform);
    }

    public void UpdateRealMousePosition(Vector2 position)
    {
        lastPos = position;
        lastDist = CalculateDistanceToPlayer();
        UpdateCrossAirPosition(lastPos, lastDist);
    }

    private float CalculateDistanceToPlayer()
    {
        return plane;
    }

    private void FixedUpdate()
    {
        UpdateCrossAirPosition(lastPos, lastDist);
    }
}
