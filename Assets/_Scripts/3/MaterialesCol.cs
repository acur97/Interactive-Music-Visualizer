using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialesCol : MonoBehaviour {

    public Material matColor;
    public Material matParticulas;
    public Material matAltos;
    public Material matColorEmision;
    public Material matColorEmision2X;

    private Color32 blanco = new Color32(255, 255, 255, 255);
    private Color blanco2 = new Color(2, 2, 2);
    private Color blanco3 = new Color(1, 1, 1);

    private Color32 azul = new Color32(0, 128, 255, 255);
    private Color azul2 = new Color(0, 1, 2);
    private Color azul3 = new Color(0, 0.5f, 1);

    private Color32 naranja = new Color32(255, 128, 0, 255);
    private Color naranja2 = new Color(2, 1, 0);
    private Color naranja3 = new Color(1, 0.5f, 0);

    private Color32 negro = new Color32(0, 0, 0, 255);
    private Color negro2 = new Color(0, 0, 0);

    void Update ()
    {
        //AudioSpectrum.amplitudeBuffer;
        //AudioSpectrum.bandBuffer[6]
        if (AudioSpectrum.amplitudeBuffer > 0 && AudioSpectrum.amplitudeBuffer < 0.3)
        {
            matColor.SetColor("_BaseColor", blanco);

            matParticulas.SetColor("_BaseColor", blanco);
            matParticulas.SetColor("_EmissionColor", blanco);

            matColorEmision.SetColor("_BaseColor", blanco);
            matColorEmision.SetColor("_EmissionColor", blanco3);

            matColorEmision2X.SetColor("_BaseColor", blanco);
            matColorEmision2X.SetColor("_EmissionColor", blanco2);
            
        }
        if (AudioSpectrum.amplitudeBuffer > 0.3 && AudioSpectrum.amplitudeBuffer < 0.7)
        {
            matColor.SetColor("_BaseColor", azul);

            matParticulas.SetColor("_BaseColor", azul);
            matParticulas.SetColor("_EmissionColor", azul);

            matColorEmision.SetColor("_BaseColor", azul);
            matColorEmision.SetColor("_EmissionColor", azul3);

            matColorEmision2X.SetColor("_BaseColor", azul);
            matColorEmision2X.SetColor("_EmissionColor", azul2);
            
        }
        if (AudioSpectrum.amplitudeBuffer > 0.7 && AudioSpectrum.amplitudeBuffer < 1)
        {
            matColor.SetColor("_BaseColor", naranja);

            matParticulas.SetColor("_BaseColor", naranja);
            matParticulas.SetColor("_EmissionColor", naranja);

            matColorEmision.SetColor("_BaseColor", naranja);
            matColorEmision.SetColor("_EmissionColor", naranja3);

            matColorEmision2X.SetColor("_BaseColor", naranja);
            matColorEmision2X.SetColor("_EmissionColor", naranja2);
            
        }

        if (AudioSpectrum.bandBuffer[6] > 0 && AudioSpectrum.bandBuffer[6] < 5.25)
        {
            matAltos.SetColor("_BaseColor", blanco);
            matAltos.SetColor("_EmissionColor", blanco3);

        }
        if (AudioSpectrum.bandBuffer[6] > 5.25 && AudioSpectrum.bandBuffer[6] < 10)
        {
            matAltos.SetColor("_BaseColor", negro);
            matAltos.SetColor("_EmissionColor", negro2);

        }
    }
}