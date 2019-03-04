using UnityEngine;
using System.Collections;

public class SEF_biquad : MonoBehaviour {

	public bool filterOn = true;
	
	[Range(20f, 10000f)]
	public float cutoffFrequency=1000f;
	
	[Range(-25f, 25f)]
	public float resonance=0f;

	//init
	float mX1 = 0f;
	float mX2 = 0f;
	float mY1 = 0f;
	float mY2 = 0f;
	float pi = 22f/7f;

	float cutoff=20f;
	float res=0f;

	float mA0, mA1, mA2, mB1, mB2;

	// Use this for initialization
	void Start () {
		cutoff = cutoffFrequency;
		res = resonance;
		biquad ();
	}
	
	// Update is called once per frame
	void Update () {
		cutoff = cutoffFrequency;
		res = resonance;
		biquad ();
	}

	void OnAudioFilterRead (float[] data, int channels)  {
		if (!filterOn)
			return;
		for (int i = 0; i < data.Length; i++) {
			float aux=data[i];

			data[i] = mA0*data[i] + mA1*mX1 + mA2*mX2 - mB1*mY1 - mB2*mY2;
			mX2 = mX1;
			mX1 = aux;
			mY2 = mY1;
			mY1 = data[i];
		}
	}

	void biquad() {
		cutoff = 2f * cutoffFrequency / AudioSettings.outputSampleRate;
		res = Mathf.Pow(10f, 0.05f * -resonance);
		float k = 0.5f * res * Mathf.Sin(pi * cutoff);
		float c1 = 0.5f * (1f - k) / (1f + k);
		float c2 = (0.5f + c1) * Mathf.Cos(pi * cutoff);
		float c3 = (0.5f + c1 - c2) * 0.25f;
		
		mA0 = 2f * c3;
		mA1 = 2f * 2f * c3;
		mA2 = 2f * c3;
		mB1 = 2f * -c2;
		mB2 = 2f * c1;
	}
}
