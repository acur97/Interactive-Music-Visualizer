using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraShackeControl : MonoBehaviour {

    public CinemachineVirtualCamera cam;
    public float magnitudShake = 5;
    public float magnitudAmplitude = 1.5f;

    private CinemachineBasicMultiChannelPerlin noise;

    private void Awake()
    {
        noise = cam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
    }

    void FixedUpdate ()
    {
        noise.m_FrequencyGain = AudioSpectrum.amplitudeBuffer * magnitudShake;
        noise.m_AmplitudeGain = AudioSpectrum.amplitudeBuffer * magnitudAmplitude;
    }
}