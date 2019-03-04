using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraShackeControl : MonoBehaviour {

    public CinemachineVirtualCamera cam;
    public float magnitudShake = 10;

    private CinemachineBasicMultiChannelPerlin noise;

    private float amplitude;

    private void Awake()
    {
        noise = cam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
    }

    void Update ()
    {
        amplitude = AudioSpectrum.amplitudeBuffer * magnitudShake;
        noise.m_FrequencyGain = amplitude;
        noise.m_AmplitudeGain = AudioSpectrum.amplitudeBuffer;

    }
}
