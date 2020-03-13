using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuntoMaximo : MonoBehaviour {

    public float limite1 = 0.7f;
    public float limite2 = 5.25f;
    public float limite3 = 4.75f;

    public ControlParticulas cParticulas;

	void Update ()
    {
		if (AudioSpectrum.amplitudeBuffer > limite1 && AudioSpectrum.bandBuffer[6] > limite2 && AudioSpectrum.bandBuffer[0] > limite3)
        {
            Debug.Log("Desvergue");
            cParticulas.speed = 2;
        }
        else
        {
            cParticulas.speed = 1;
        }
	}
}