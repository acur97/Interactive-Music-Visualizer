using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bala : MonoBehaviour {

    public float Velocidad;
    public float puntoMuerte;

    private Vector3 movimiento;

    private void Update()
    {
        movimiento = new Vector3(0, -(AudioSpectrum.amplitudeBuffer * Velocidad), 0);
        transform.Translate(movimiento);

        if (transform.localPosition.y < puntoMuerte)
        {
            Destroy(gameObject);
        }
    }
}
