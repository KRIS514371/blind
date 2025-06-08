using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class VolumeHelper : MonoBehaviour
{
    public float exposure;
    public float bloomIntensity;
    
    Volume _volume;
    Bloom  _bloom;
    ColorAdjustments _colorAdjustments;
    void Start()
    {
        _volume = GetComponent<Volume>();
        _volume.profile.TryGet<Bloom>(out _bloom);
        _volume.profile.TryGet<ColorAdjustments>(out _colorAdjustments);
        
    }
   
    void Update()
    {
        _bloom.intensity.value = bloomIntensity;
        _colorAdjustments.postExposure.value = exposure;
    }
}
