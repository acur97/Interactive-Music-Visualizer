using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleCentro : MonoBehaviour {

    public float startScale, scaleMultiplier;

    void Update()
    {
        transform.localScale = new Vector3((AudioSpectrum.amplitudeBuffer * scaleMultiplier) + startScale, transform.localScale.y, (AudioSpectrum.amplitudeBuffer * scaleMultiplier) + startScale);

    }
}