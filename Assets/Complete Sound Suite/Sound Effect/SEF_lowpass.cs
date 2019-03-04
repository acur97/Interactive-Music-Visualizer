using UnityEngine;
using System.Collections;

public class SEF_lowpass : MonoBehaviour {

	public bool filterOn = true;

	[Range(100f, 5000)]
	public int cutoffFrequency=1000;

	[Range(0.1f, 1.41421f)]
	public float resonance=0.2f;

	float a1,a2,a3,b1,b2;

	float in_1=0f, in_2=0f, out_1=0f, out_2=0f;

	void Start() {
		lowPass();
	}

	void Update() {
		lowPass();
	}

	void OnAudioFilterRead (float[] data, int channels)  {
		if (!filterOn)
			return;
		for (int i = 0; i < data.Length; i++) {
			float aux=data[i];
			data [i] = a1 * data [i] + a2 * in_1 + a3 * in_2 - b1*out_1 - b2*out_2;
			in_2=in_1;
			in_1=aux;
			out_2=out_1;
			out_1=data[i];
		}
	}

	void lowPass() {
		float c=1.0f / Mathf.Tan(Mathf.PI * cutoffFrequency / AudioSettings.outputSampleRate);
		a1 = 1.0f / ( 1.0f + resonance * c + c * c);
		a2 = 2f* a1;
		a3 = a1;
		b1 = 2.0f * ( 1.0f - c*c) * a1;
		b2 = ( 1.0f - resonance * c + c * c) * a1;
	}
}
