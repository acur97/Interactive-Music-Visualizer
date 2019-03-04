using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleEmiter : MonoBehaviour {

    public int banda;
    public float limite;
    public GameObject particle;

    private void Update()
    {
        if (AudioSpectrum.freqBand[banda] > limite)
        {
            Instantiate(particle, transform.localPosition, transform.localRotation, transform);
        }
    }
}
