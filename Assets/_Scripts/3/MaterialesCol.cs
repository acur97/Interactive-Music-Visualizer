using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialesCol : MonoBehaviour {

    public Material matColor;
    public Material matParticulas;
    public Material matAltos;
    public Material matColorEmision;
    public Material matColorEmision2X;

    private readonly Color32 blanco = new Color32(255, 255, 255, 255);
    private readonly Color blanco2 = new Color(2, 2, 2);
    private readonly Color blanco3 = new Color(1, 1, 1);

    private readonly Color32 azul = new Color32(0, 128, 255, 255);
    private readonly Color azul2 = new Color(0, 1, 2);
    private readonly Color azul3 = new Color(0, 0.5f, 1);

    private readonly Color32 naranja = new Color32(255, 128, 0, 255);
    private readonly Color naranja2 = new Color(2, 1, 0);
    private readonly Color naranja3 = new Color(1, 0.5f, 0);

    private Color32 negro = new Color32(0, 0, 0, 255);
    private Color negro2 = new Color(0, 0, 0);

    private readonly int baseColor = Shader.PropertyToID("_BaseColor");
    private readonly int emissionColor = Shader.PropertyToID("_EmissionColor");

    void Update ()
    {
        if (AudioSpectrum.amplitudeBuffer > 0 && AudioSpectrum.amplitudeBuffer < 0.3)
        {
            matColor.SetColor(baseColor, blanco);

            matParticulas.SetColor(baseColor, blanco);
            matParticulas.SetColor(emissionColor, blanco);

            matColorEmision.SetColor(baseColor, blanco);
            matColorEmision.SetColor(emissionColor, blanco3);

            matColorEmision2X.SetColor(baseColor, blanco);
            matColorEmision2X.SetColor(emissionColor, blanco2);
        }
        if (AudioSpectrum.amplitudeBuffer > 0.3 && AudioSpectrum.amplitudeBuffer < 0.7)
        {
            matColor.SetColor(baseColor, azul);

            matParticulas.SetColor(baseColor, azul);
            matParticulas.SetColor(emissionColor, azul);

            matColorEmision.SetColor(baseColor, azul);
            matColorEmision.SetColor(emissionColor, azul3);

            matColorEmision2X.SetColor(baseColor, azul);
            matColorEmision2X.SetColor(emissionColor, azul2);
        }
        if (AudioSpectrum.amplitudeBuffer > 0.7 && AudioSpectrum.amplitudeBuffer < 1)
        {
            matColor.SetColor(baseColor, naranja);

            matParticulas.SetColor(baseColor, naranja);
            matParticulas.SetColor(emissionColor, naranja);

            matColorEmision.SetColor(baseColor, naranja);
            matColorEmision.SetColor(emissionColor, naranja3);

            matColorEmision2X.SetColor(baseColor, naranja);
            matColorEmision2X.SetColor(emissionColor, naranja2);
        }

        if (AudioSpectrum.bandBuffer[6] > 0 && AudioSpectrum.bandBuffer[6] < 5.25)
        {
            matAltos.SetColor(baseColor, blanco);
            matAltos.SetColor(emissionColor, blanco3);

        }
        if (AudioSpectrum.bandBuffer[6] > 5.25 && AudioSpectrum.bandBuffer[6] < 10)
        {
            matAltos.SetColor(baseColor, negro);
            matAltos.SetColor(emissionColor, negro2);
        }
    }
}