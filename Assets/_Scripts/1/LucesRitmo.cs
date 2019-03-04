using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LucesRitmo : MonoBehaviour {

    public int band;
    public float scaleMultiplier;

    private Light luz;

    private void Awake()
    {
        luz = GetComponent<Light>();
    }

    void Update()
    {
        luz.intensity = (AudioSpectrum.bandBuffer[band] * scaleMultiplier);
    }
}
