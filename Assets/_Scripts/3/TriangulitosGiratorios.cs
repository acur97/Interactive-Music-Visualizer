using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriangulitosGiratorios : MonoBehaviour {
    
    public float rotMultiplier;
    [Space]
    public float scaleMultiplier;
    public float startScale;

    private void FixedUpdate()
    {
        transform.Rotate((AudioSpectrum.amplitudeBuffer * rotMultiplier), (AudioSpectrum.amplitudeBuffer * rotMultiplier), (AudioSpectrum.amplitudeBuffer * rotMultiplier));
    }

    private void Update()
    {
        transform.localScale = new Vector3((AudioSpectrum.amplitudeBuffer * scaleMultiplier) + startScale, (AudioSpectrum.amplitudeBuffer * scaleMultiplier) + startScale, (AudioSpectrum.amplitudeBuffer * scaleMultiplier) + startScale);
    }
}