using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriangulosGiratorios : MonoBehaviour {

    public float tiempoDeVidaMin;
    public float tiempoDeVidaMax;
    [Space]
    public float EscalaMaxima;
    public float saltosEscala;
    [Space]
    public float velocidadRotacion;
    public float velocidadTranslacion;

    private bool una = false;
    private float numeroEscala;
    private Vector3 escala;
    private Vector3 rotacion;
    private Vector3 translacion;
    private bool morir = false;

    private void OnEnable()
    {
        rotacion = new Vector3(Random.Range(0, 360), Random.Range(0, 360), Random.Range(0, 360));
        translacion = new Vector3(Random.Range(1, 2), Random.Range(1, 2), Random.Range(1, 2));
    }

    private void Update()
    {
        if (!una)
        {
            StartCoroutine(Fin());
            una = true;
        }

        if (!morir)
        {
            if (numeroEscala <= EscalaMaxima)
            {
                numeroEscala += saltosEscala;
            }
        }
        else
        {
            if (numeroEscala >= 0)
            {
                numeroEscala -= saltosEscala;
            }
            if (numeroEscala < 0.1)
            {
                Destroy(gameObject);
            }
        }

        escala = new Vector3(numeroEscala, numeroEscala, numeroEscala);
        transform.localScale = escala;
        
        transform.Rotate(rotacion * velocidadRotacion);
        transform.Translate(translacion * velocidadTranslacion, Space.World);
    }

    IEnumerator Fin()
    {
        yield return new WaitForSeconds(Random.Range(tiempoDeVidaMin, tiempoDeVidaMax));

        morir = true;
    }
}
