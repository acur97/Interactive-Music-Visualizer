using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlParticulas : MonoBehaviour {

    public ParticleSystem ps;
    public float multiplicador;
    public float speed = 1;

    private float velocidad;
    private ParticleSystem.MainModule main;

    private void Awake()
    {
        main = ps.main;
    }

    void Update ()
    {
        velocidad = AudioSpectrum.bandBuffer[0] * multiplicador;

        main.simulationSpeed = velocidad;
        main.startSpeed = speed;
    }
}