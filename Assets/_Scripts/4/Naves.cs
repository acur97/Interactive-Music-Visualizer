using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Naves : MonoBehaviour {

    public enum tipoDeNave {Altos, Medios, Bajos};
    public tipoDeNave TipoDeNave;
    public Transform cubo1;
    public Transform cubo2;
    public Transform cubo3;
    public Transform cubo4;
    [Space]
    public float multiplicador;
    public float escalaBase;
    [Space]
    public bool TresDe;
    [Space]
    public Slider Disparo;
    public Slider Velocidad;

    void Update ()
    {
		if (TipoDeNave == tipoDeNave.Altos)
        {
            Disparo.value = AudioSpectrum.bandBuffer[7];
            Velocidad.value = AudioSpectrum.bandBuffer[4];
            if (TresDe)
            {
                cubo1.localScale = new Vector3(escalaBase + (AudioSpectrum.bandBuffer[7] * multiplicador), escalaBase + (AudioSpectrum.bandBuffer[7] * multiplicador), 1);
                cubo2.localScale = new Vector3(escalaBase + (AudioSpectrum.bandBuffer[6] * multiplicador), escalaBase + (AudioSpectrum.bandBuffer[6] * multiplicador), 1);
                cubo3.localScale = new Vector3(escalaBase + (AudioSpectrum.bandBuffer[5] * multiplicador), escalaBase + (AudioSpectrum.bandBuffer[5] * multiplicador), 1);
                cubo4.localScale = new Vector3(escalaBase + (AudioSpectrum.bandBuffer[4] * multiplicador), escalaBase + (AudioSpectrum.bandBuffer[4] * multiplicador), 1);
            }
            else
            {
                cubo1.localScale = new Vector3(escalaBase + (AudioSpectrum.bandBuffer[7] * multiplicador), escalaBase, 1);
                cubo2.localScale = new Vector3(escalaBase + (AudioSpectrum.bandBuffer[6] * multiplicador), escalaBase, 1);
                cubo3.localScale = new Vector3(escalaBase + (AudioSpectrum.bandBuffer[5] * multiplicador), escalaBase, 1);
                cubo4.localScale = new Vector3(escalaBase + (AudioSpectrum.bandBuffer[4] * multiplicador), escalaBase, 1);
            }
        }
        if (TipoDeNave == tipoDeNave.Medios)
        {
            Disparo.value = AudioSpectrum.bandBuffer[5];
            Velocidad.value = AudioSpectrum.bandBuffer[2];
            if (TresDe)
            {
                cubo1.localScale = new Vector3(escalaBase + (AudioSpectrum.bandBuffer[5] * multiplicador), escalaBase + (AudioSpectrum.bandBuffer[5] * multiplicador), 1);
                cubo2.localScale = new Vector3(escalaBase + (AudioSpectrum.bandBuffer[4] * multiplicador), escalaBase + (AudioSpectrum.bandBuffer[4] * multiplicador), 1);
                cubo3.localScale = new Vector3(escalaBase + (AudioSpectrum.bandBuffer[3] * multiplicador), escalaBase + (AudioSpectrum.bandBuffer[3] * multiplicador), 1);
                cubo4.localScale = new Vector3(escalaBase + (AudioSpectrum.bandBuffer[2] * multiplicador), escalaBase + (AudioSpectrum.bandBuffer[2] * multiplicador), 1);
            }
            else
            {
                cubo1.localScale = new Vector3(escalaBase + (AudioSpectrum.bandBuffer[5] * multiplicador), escalaBase, 1);
                cubo2.localScale = new Vector3(escalaBase + (AudioSpectrum.bandBuffer[4] * multiplicador), escalaBase, 1);
                cubo3.localScale = new Vector3(escalaBase + (AudioSpectrum.bandBuffer[3] * multiplicador), escalaBase, 1);
                cubo4.localScale = new Vector3(escalaBase + (AudioSpectrum.bandBuffer[2] * multiplicador), escalaBase, 1);
            }
        }
        if (TipoDeNave == tipoDeNave.Bajos)
        {
            Disparo.value = AudioSpectrum.bandBuffer[3];
            Velocidad.value = AudioSpectrum.bandBuffer[0];
            if (TresDe)
            {
                cubo1.localScale = new Vector3(escalaBase + (AudioSpectrum.bandBuffer[3] * multiplicador), escalaBase + (AudioSpectrum.bandBuffer[3] * multiplicador), 1);
                cubo2.localScale = new Vector3(escalaBase + (AudioSpectrum.bandBuffer[2] * multiplicador), escalaBase + (AudioSpectrum.bandBuffer[2] * multiplicador), 1);
                cubo3.localScale = new Vector3(escalaBase + (AudioSpectrum.bandBuffer[1] * multiplicador), escalaBase + (AudioSpectrum.bandBuffer[1] * multiplicador), 1);
                cubo4.localScale = new Vector3(escalaBase + (AudioSpectrum.bandBuffer[0] * multiplicador), escalaBase + (AudioSpectrum.bandBuffer[0] * multiplicador), 1);
            }
            else
            {
                cubo1.localScale = new Vector3(escalaBase + (AudioSpectrum.bandBuffer[3] * multiplicador), escalaBase, 1);
                cubo2.localScale = new Vector3(escalaBase + (AudioSpectrum.bandBuffer[2] * multiplicador), escalaBase, 1);
                cubo3.localScale = new Vector3(escalaBase + (AudioSpectrum.bandBuffer[1] * multiplicador), escalaBase, 1);
                cubo4.localScale = new Vector3(escalaBase + (AudioSpectrum.bandBuffer[0] * multiplicador), escalaBase, 1);
            }
        }
    }
}
