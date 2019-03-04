using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof (AudioSource))]
public class AudioSpectrum : MonoBehaviour {

    AudioSource source;
    public static float[] sample = new float[512];
    public static float[] freqBand = new float[8];
    public static float[] bandBuffer = new float[8];
    private float[] bufferDecrease = new float[8];
    public float[] test;

    public static float amplitude, amplitudeBuffer;
    public float amplitudeHighest;

    private void Awake()
    {
        source = GetComponent<AudioSource>();
    }

    void Update ()
    {
        GetSpectrum();
        MakeFrequencyBands();
        BandBuffer();
        GetAmplitude();
        test = sample;
	}

    void GetSpectrum()
    {
        source.GetSpectrumData(sample, 0, FFTWindow.Blackman);
    }

    void BandBuffer()
    {
        for (int i = 0; i < 8; i++)
        {
            if (freqBand[i] > bandBuffer[i])
            {
                bandBuffer[i] = freqBand[i];
                bufferDecrease[i] = 0.005f;
            }
            if (freqBand[i] < bandBuffer[i])
            {
                bufferDecrease[i] = (bandBuffer[i] - freqBand[i]) / 8;
                bandBuffer[i] -= bufferDecrease[i];
            }
        }
    }

    void GetAmplitude()
    {
        float currentAmplitude = 0;
        float currentAmplitudeBuffer = 0;

        for (int i = 0; i < 8; i++)
        {
            currentAmplitude += freqBand[i];
            currentAmplitudeBuffer += bandBuffer[i];
        }

        if (currentAmplitude > amplitudeHighest)
        {
            amplitudeHighest = currentAmplitude;
        }

        amplitude = currentAmplitude / amplitudeHighest;
        amplitudeBuffer = currentAmplitudeBuffer / amplitudeHighest;
    }

    void MakeFrequencyBands()
    {
        int count = 0;

        for (int i = 0; i < 8; i++)
        {
            float average = 0;
            int sampleCount = (int)Mathf.Pow(2, i) * 2;

            if (i == 7)
            {
                sampleCount += 2;
            }

            for (int j = 0; j < sampleCount; j++)
            {
                average += sample[count] * (count + 1);
                count++;
            }

            average /= count;

            freqBand[i] = average * 10;
        }
    }
}
