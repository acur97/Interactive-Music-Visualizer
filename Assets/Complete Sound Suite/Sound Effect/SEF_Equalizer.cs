using UnityEngine;
using System.Collections;

public class SEF_Equalizer : MonoBehaviour {

    public bool filterOn = true;

    [Range(0, 2)]
    public float lowFreq = 2.0f;

    [Range(0, 2)]
    public float midFreq = 2.0f;

    [Range(0, 2)]
    public float highFreq = 2.0f;

    public struct EQSTATE
    {
        public float lf;
        public float f1p0;
        public float f1p1;
        public float f1p2;
        public float f1p3;

        public float hf;
        public float f2p0;
        public float f2p1;
        public float f2p2;
        public float f2p3;

        public float sdm1;
        public float sdm2;
        public float sdm3;

        public float lg;
        public float mg;
        public float hg;

    };

    static float vsa = (1.0f / 4294967295.0f);

    EQSTATE eq = new EQSTATE();

#if UNITY_EDITOR

    private void Reset()
    {
        GetComponent<AudioSource>().volume = 0.5f;
        Debug.Log("Volumen puesto a 0.5 por ser hasta 2 el equalizador.");
    }

#endif

    void Start () {
		init_3band_state(ref eq,880,5000,44100);
		eq.lg = 1f;
		eq.mg = 1f;
		eq.hg = 1f;
	}
	
	void Update () {
		eq.lg = lowFreq;
		eq.mg = midFreq;
		eq.hg = highFreq;
	}

	void OnAudioFilterRead (float[] data, int channels)  {
		if (!filterOn)
			return;
		for (int i = 0; i < data.Length; i++) {
			data [i] = do_3band (ref eq, data [i]);
		}
	}

	void init_3band_state(ref EQSTATE es, int lowfreq, int highfreq, int mixfreq) {
		es.lg = 1.0f; es.mg = 1.0f; es.hg = 1.0f;
		es.lf = 2f * Mathf.Sin(Mathf.PI * ((float)lowfreq / (float)mixfreq)); 
		es.hf = 2f * Mathf.Sin(Mathf.PI * ((float)highfreq / (float)mixfreq));
	}

	float do_3band(ref EQSTATE es, float sample) {
		float  l,m,h; 
		es.f1p0  += (es.lf * (sample   - es.f1p0)) + vsa;
		es.f1p1  += (es.lf * (es.f1p0 - es.f1p1));
		es.f1p2  += (es.lf * (es.f1p1 - es.f1p2));
		es.f1p3  += (es.lf * (es.f1p2 - es.f1p3));
		l          = es.f1p3;		
		es.f2p0  += (es.hf * (sample   - es.f2p0)) + vsa;
		es.f2p1  += (es.hf * (es.f2p0 - es.f2p1));
		es.f2p2  += (es.hf * (es.f2p1 - es.f2p2));
		es.f2p3  += (es.hf * (es.f2p2 - es.f2p3));
		h         = es.sdm3 - es.f2p3;
		m         = es.sdm3 - (h + l);
		l        *= es.lg;
		m        *= es.mg;
		h        *= es.hg;
		es.sdm3   = es.sdm2;
		es.sdm2   = es.sdm1;
		es.sdm1   = sample;                
		return(l + m + h);
	}
}
