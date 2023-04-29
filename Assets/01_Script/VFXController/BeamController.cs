using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class BeamController : MonoBehaviour
{
    [SerializeField] VisualEffect beamEffect;
    [SerializeField] bool isShooting;
    [SerializeField, Tooltip("divides the actual distance")] float sizeConvertion = 6;

    [SerializeField] float offset = 0.25f;

    [SerializeField] Vector3 primaryScaleControl;
    [SerializeField] Vector3 secondaryScaleControl;
    [SerializeField] Light spotLight;
    [SerializeField] Light secondaryLight;

    private void Awake()
    {
        if (beamEffect == null) beamEffect = GetComponentInChildren<VisualEffect>();
    }

    public void StartBeam()
    {
        beamEffect.enabled = 
            isShooting = 
            spotLight.enabled = 
            secondaryLight.enabled = 
            true;
        UpdateSize(0.01f);
    }

    public void StopBeam()
    {
        beamEffect.enabled =
            isShooting = 
            spotLight.enabled = 
            secondaryLight.enabled = 
            false;
        UpdateSize(0.01f);
    }

    public void UpdateSize(float size)
    {
        if (isShooting)
        {
            float actualSize = size / 6 + offset;
            beamEffect.SetFloat("sSize", actualSize);
        }
    }
}
