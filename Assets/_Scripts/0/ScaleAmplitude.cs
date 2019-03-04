using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleAmplitude : MonoBehaviour {

    public float startScale, scaleMultiplier;
    
    void Update()
    {
        transform.localScale = new Vector3(transform.localScale.x, (AudioSpectrum.amplitudeBuffer * scaleMultiplier) + startScale, transform.localScale.z);
    }
}
