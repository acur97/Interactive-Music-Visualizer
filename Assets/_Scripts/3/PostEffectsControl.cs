using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.Rendering;

public class PostEffectsControl : MonoBehaviour {

    public VolumeProfile postV;

    private ChromaticAberration chromatic;

    private float valor;
    private float mejorValor;

    private void Awake()
    {
        postV.TryGet(out chromatic);
    }

    void Update ()
    {
        valor = (AudioSpectrum.bandBuffer[3] / 11);
        mejorValor = Mathf.Clamp(valor, 0.2f, 1);

        chromatic.intensity.value = mejorValor;
    }
}