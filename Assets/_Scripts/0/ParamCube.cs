using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParamCube : MonoBehaviour {

    public int band;
    public float startScale, scaleMultiplier;
    public bool useBuffer;

	void Update ()
    {
        if (useBuffer)
        {
            transform.localScale = new Vector3(transform.localScale.x, (AudioSpectrum.bandBuffer[band] * scaleMultiplier) + startScale, transform.localScale.z);
        }
        else
        {
            transform.localScale = new Vector3(transform.localScale.x, (AudioSpectrum.freqBand[band] * scaleMultiplier) + startScale, transform.localScale.z);
        }
    }
}
