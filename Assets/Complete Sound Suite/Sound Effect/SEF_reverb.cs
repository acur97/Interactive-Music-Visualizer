using UnityEngine;
using System.Collections;

public class SEF_reverb : MonoBehaviour {

	public bool filterOn = true;
		
	[Range(0,0.5f)]
	public float delaySeconds = 0.12f;

	[Range(0,1)]
	public float decay = 0.5f;

	[Range(1,3)]
	public int stages=3;

	private int delaySamples;
	private int delaySamples2;
	float [] delayBufferLeft;
	float [] delayBufferRight;
	float [] delayBufferLeft2;
	float [] delayBufferRight2;
	float [] delayBufferLeft3;
	float [] delayBufferRight3;
	int bufferIndex=0;


	void Start () {
		delayBufferLeft=new float[AudioSettings.outputSampleRate];
		delayBufferRight=new float[AudioSettings.outputSampleRate];
		delayBufferLeft2=new float[AudioSettings.outputSampleRate];
		delayBufferRight2=new float[AudioSettings.outputSampleRate];
		delayBufferLeft3=new float[AudioSettings.outputSampleRate];
		delayBufferRight3=new float[AudioSettings.outputSampleRate];
		for (int i=0; i<AudioSettings.outputSampleRate; i++) {
			delayBufferLeft[i]=0f;
			delayBufferRight[i]=0f;
			delayBufferLeft2[i]=0f;
			delayBufferRight2[i]=0f;
			delayBufferLeft3[i]=0f;
			delayBufferRight3[i]=0f;
		}
		delaySamples =  (int)(delaySeconds * (float)AudioSettings.outputSampleRate);
	}
	
	void Update () {
		delaySamples =  (int)(delaySeconds * (float)AudioSettings.outputSampleRate);
	}

	void OnAudioFilterRead (float[] data, int channels)  {
		if (!filterOn || delaySeconds == 0f || delaySamples==0)
			return;
		for(int i=0; i<data.Length; i++) {
			float aux1, aux2, aux3;
			if(IsOdd(i) || channels==1) {
				aux1=delayBufferLeft[bufferIndex];
				aux2=delayBufferLeft2[bufferIndex];
				aux3=delayBufferLeft3[bufferIndex];
				delayBufferLeft3[bufferIndex]=delayBufferLeft2[bufferIndex];
				delayBufferLeft2[bufferIndex]=delayBufferLeft[bufferIndex];
				delayBufferLeft[bufferIndex]=data[i];
			}
			else {
				aux1=delayBufferRight[bufferIndex];
				aux2=delayBufferRight2[bufferIndex];
				aux3=delayBufferRight3[bufferIndex];
				delayBufferRight3[bufferIndex]=delayBufferRight2[bufferIndex];
				delayBufferRight2[bufferIndex]=delayBufferRight[bufferIndex];
				delayBufferRight[bufferIndex]=data[i];
			}
			bufferIndex++;
			bufferIndex%=delaySamples;

			switch(stages) {
				case 1:
				data[i]=data[i]+aux1*decay;
				break;
				case 2:
				data[i]=data[i]+(aux1*decay)+(aux2*2f*decay/3f);
				break;
				case 3:
				data[i]=data[i]+(aux1*decay)+(aux2*2f*decay/3f)+(aux3*decay/3);
				break;
			}

		}
	}

	bool IsOdd(int value)
	{
		return value % 2 != 0;
	}
}
