using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrasAltura : MonoBehaviour {

    public int band;
    public float startScale, scaleMultiplier;
    public bool rojo;

    private readonly int emission = Shader.PropertyToID("_EmissionColor");

    private Material mat;
    private Color col;
    private float buffer;

    private void Start()
    {
        mat = GetComponent<MeshRenderer>().material;
    }

    void Update()
    {
        transform.localScale = new Vector3(transform.localScale.x, (AudioSpectrum.bandBuffer[band] * scaleMultiplier) + startScale, transform.localScale.z);
        transform.localPosition = new Vector3(transform.localPosition.x, ((AudioSpectrum.bandBuffer[band] * scaleMultiplier) + startScale) / 2, transform.localPosition.z);
        buffer = Mathf.Clamp01(AudioSpectrum.bandBuffer[band]);
        if (rojo)
        {
            col = new Color(buffer, 0, 0);
        }
        else
        {
            col = new Color(0, 0, buffer);
        }
        mat.SetColor(emission, col);
    }
}
