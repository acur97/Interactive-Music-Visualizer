using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiraAmplitud : MonoBehaviour {

    public float scaleMultiplier;

    void Update()
    {
        transform.Rotate((AudioSpectrum.amplitudeBuffer * scaleMultiplier), (AudioSpectrum.amplitudeBuffer * scaleMultiplier), (AudioSpectrum.amplitudeBuffer * scaleMultiplier));
    }
}
