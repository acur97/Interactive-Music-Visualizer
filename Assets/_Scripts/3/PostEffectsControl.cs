using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class PostEffectsControl : MonoBehaviour {

    public PostProcessVolume post;

    ChromaticAberration chromatic;

    private float valor;
    private float mejorValor;

    private void Awake()
    {
        post.profile.TryGetSettings(out chromatic);
    }

    void Update ()
    {
        valor = (AudioSpectrum.bandBuffer[3] / 11);
        mejorValor = Mathf.Clamp(valor, 0.2f, 1);

        chromatic.intensity.value = mejorValor;
    }
}
