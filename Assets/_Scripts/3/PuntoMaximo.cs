using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuntoMaximo : MonoBehaviour {

	void Update ()
    {
		if (AudioSpectrum.amplitudeBuffer > 0.7 && AudioSpectrum.bandBuffer[6] > 5.25 && AudioSpectrum.bandBuffer[0] > 4.75)
        {
            Debug.Log("Desvergue");
        }
	}
}
