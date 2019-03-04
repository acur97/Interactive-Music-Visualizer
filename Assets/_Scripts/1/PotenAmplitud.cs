using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotenAmplitud : MonoBehaviour {

    public float scaleMultiplier;
    public float desface;

    private readonly int emission = Shader.PropertyToID("_EmissionColor");

    private Material mat;
    private Color col;
    private float buffer;

    private void Start()
    {
        mat = GetComponentInChildren<MeshRenderer>().material;
    }

    void Update()
    {
        transform.localEulerAngles = new Vector3(0, (AudioSpectrum.amplitudeBuffer * scaleMultiplier) - desface, 0);
        buffer = Mathf.Clamp01(AudioSpectrum.amplitudeBuffer);
        col = new Color(buffer, buffer, buffer);
        mat.SetColor(emission, col);
    }
}
