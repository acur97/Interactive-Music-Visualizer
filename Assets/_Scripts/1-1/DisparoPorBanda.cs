using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisparoPorBanda : MonoBehaviour {

    [Range(0, 7)]
    public int Banda;
    [Range(0,5)]
    public float limite = 3;
    public GameObject bala;
    public Transform lugarDisparo;
    [Space]
    public float tiempoEntreDisparos;

    private Renderer mat;
    private float tiempoAnterior;
    private bool puedeDisparar;

    private void Awake()
    {
        mat = GetComponent<Renderer>();
        tiempoAnterior = tiempoEntreDisparos;
    }

    private void Update()
    {
        if (AudioSpectrum.bandBuffer[Banda] > limite)
        {
            mat.material.SetColor("_Color", Color.red);
            if (puedeDisparar)
            {
                Disparar();
            }
        }
        else
        {
            mat.material.SetColor("_Color", Color.black);
        }

        if (tiempoEntreDisparos > 0)
        {
            tiempoEntreDisparos = tiempoEntreDisparos - Time.deltaTime;
            puedeDisparar = false;
        }
        if (tiempoEntreDisparos <= 0)
        {
            tiempoEntreDisparos = tiempoAnterior;
            puedeDisparar = true;
        }
    }

    private void Disparar()
    {
        Instantiate(bala, lugarDisparo);
    }
}
