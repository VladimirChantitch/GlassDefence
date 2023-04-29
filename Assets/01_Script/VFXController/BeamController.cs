using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class BeamController : MonoBehaviour
{
    [SerializeField] VisualEffect beamEffect;

    private void Awake()
    {
        if (beamEffect == null) beamEffect = GetComponentInChildren<VisualEffect>();
    }
}
