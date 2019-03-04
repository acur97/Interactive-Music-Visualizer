using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TamanoCubo : MonoBehaviour {

    [Range(0, 7)]
    public int Banda;

    private void Update()
    {
        transform.localScale = new Vector3(2, AudioSpectrum.bandBuffer[Banda], 2);
        transform.localPosition = new Vector3(transform.localPosition.x, AudioSpectrum.bandBuffer[Banda] / 2, transform.localPosition.z);
    }
}
