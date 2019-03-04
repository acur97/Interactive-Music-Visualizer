using UnityEngine;
using System.Collections;

public class SEF_tremolo : MonoBehaviour {

	public bool filterOn = true;

	[Range(0,3)]
	public float depth=1f;

	[Range(2000,8000)]
	public int effectRate=4000;

	static int counter;
	static int tester;
	static float offset;
	
	void Start() {
		counter = 1;
		tester     = 0;
		offset  = 1 - depth;
	}

	void OnAudioFilterRead (float[] data, int channels)  {
		if (!filterOn)
			return;
		for (int i = 0; i < data.Length; i++) {
			data [i] = performTremolo (data [i]);
			tremoloShift();
		}
	}

	float performTremolo(float xin) {
		float dataOut;
		float aux;
		
		aux = (float)tester*depth/effectRate;
		dataOut = (aux + offset)*xin;
		return dataOut;
	}
	
	void tremoloShift() {
		
		tester += counter;
		if (tester > effectRate) {
			counter = -1;
		} 
		else if(tester==0) {
			counter = 1;
		}
	}

}
