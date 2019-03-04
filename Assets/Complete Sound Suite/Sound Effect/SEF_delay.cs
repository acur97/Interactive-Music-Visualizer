using UnityEngine;
using System.Collections;

public class SEF_delay : MonoBehaviour {

	public bool filterOn = true;

	[Range(0,150)]
	public int sampesInDelay=70;			

	[Range(0,2)]
	public float delayBlend=0.7f;   

	[Range(0,2)]
	public float delayVolume=0.7f;   

	[Range(0,1)]
	public float feedbackVolume=0.5f;  
	
	private int delayReader;	 
	private int delayWriter;   
	static int bufferSize=64000;
	float[] dataBuffer = new float[bufferSize];

	
	void Start() {
		delayWriter = bufferSize - 1;
	}

	void OnAudioFilterRead (float[] data, int channels)  {
		if (!filterOn || sampesInDelay==0)
			return;
		for (int i = 0; i < data.Length; i++)
			data[i]=performDelay(data[i]);
	}

	float performDelay(float dataIn) {
		float dataOut;
		int indexPrevious; 
		int indexCurrent;
		float dataFinal;
		float dataCurrent;

		delayReader = delayWriter - sampesInDelay;

		if (delayReader < 0) {
			delayReader += bufferSize-1;
		}

		indexCurrent = delayReader;
		indexPrevious = delayReader - 1;
		if (indexPrevious < 0) {
			indexPrevious += bufferSize-1;
		}

		dataCurrent = dataBuffer[indexCurrent];
		dataFinal = dataIn + dataCurrent*feedbackVolume;

		dataBuffer[delayWriter] = dataFinal;
		dataOut = dataFinal*delayBlend + dataCurrent*delayVolume;

		delayWriter++;
		if(delayWriter>bufferSize-1)
		   delayWriter=0;

		return dataOut;
	}
}
