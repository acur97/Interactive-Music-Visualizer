using UnityEngine;
using System.Collections;

public class setupFilters : MonoBehaviour {

	SEF_Equalizer myEq;
	SEF_reverb myRev;
	SEF_delay myDelay;
	SEF_tremolo myTremolo;
	SEF_biquad myBiquad;
	SEF_highpass myHigh;
	SEF_lowpass myLow;

	static string[] stages = new string[] { "1 stage", "2 stages", "3 stages" };

	void OnGUI() {
		GUI.Box(new Rect(10, 10, 170, 300), "Equalizer");
		myEq.filterOn = GUI.Toggle(new Rect(15, 35, 170, 20), myEq.filterOn, "ON/OFF");
		myEq.lowFreq = GUI.VerticalSlider(new Rect(35, 70, 10, 200), myEq.lowFreq, 2.0F, 0.0F);
		myEq.midFreq = GUI.VerticalSlider(new Rect(85, 70, 10, 200), myEq.midFreq, 2.0F, 0.0F);
		myEq.highFreq = GUI.VerticalSlider(new Rect(135, 70, 10, 200), myEq.highFreq, 2.0F, 0.0F);
		GUI.Label(new Rect(25, 270, 100, 25), "Low");
		GUI.Label(new Rect(75, 270, 100, 25), "Mid");
		GUI.Label(new Rect(125, 270, 100, 25), "High");

		GUI.Box(new Rect(200, 10, 240, 150), "Reverb");
		myRev.filterOn = GUI.Toggle(new Rect(215, 35, 240, 20), myRev.filterOn, "ON/OFF");
		GUI.Label(new Rect(215, 60, 100, 25), "Delay");
		myRev.delaySeconds = GUI.HorizontalSlider(new Rect(260, 65, 170, 20), myRev.delaySeconds, 0F, 0.5F);
		GUI.Label(new Rect(215, 85, 100, 25), "Decay");
		myRev.decay = GUI.HorizontalSlider(new Rect(260, 90, 170, 20), myRev.decay, 0F, 1.0F);
		myRev.stages = GUI.SelectionGrid(new Rect(210, 120, 230, 20), myRev.stages-1, stages, stages.Length, GUI.skin.toggle) + 1;

		GUI.Box(new Rect(460, 10, 240, 150), "Delay");
		myDelay.filterOn = GUI.Toggle(new Rect(475, 35, 240, 20), myDelay.filterOn, "ON/OFF");
		GUI.Label(new Rect(475, 60, 100, 25), "Samples");
		myDelay.sampesInDelay = (int) GUI.HorizontalSlider(new Rect(535, 65, 150, 20), myDelay.sampesInDelay, 0F, 150F);
		GUI.Label(new Rect(475, 85, 100, 25), "Blend");
		myDelay.delayBlend = GUI.HorizontalSlider(new Rect(535, 90, 150, 20), myDelay.delayBlend, 0F, 2.0F);
		GUI.Label(new Rect(475, 110, 100, 25), "Delay vol");
		myDelay.delayVolume = GUI.HorizontalSlider(new Rect(535, 115, 150, 20), myDelay.delayVolume, 0F, 2.0F);
		GUI.Label(new Rect(475, 135, 100, 25), "Feedback");
		myDelay.feedbackVolume = GUI.HorizontalSlider(new Rect(535, 140, 150, 20), myDelay.feedbackVolume, 0F, 1.0F);

		GUI.Box(new Rect(200, 170, 240, 140), "Tremolo");
		myTremolo.filterOn = GUI.Toggle(new Rect(215, 160+35, 240, 20), myTremolo.filterOn, "ON/OFF");
		GUI.Label(new Rect(215, 160+60, 100, 25), "Depth");
		myTremolo.depth = GUI.HorizontalSlider(new Rect(260, 160+65, 170, 20), myTremolo.depth, 0F, 3F);
		GUI.Label(new Rect(215, 160+85, 100, 25), "Rate");
		myTremolo.effectRate = (int)GUI.HorizontalSlider(new Rect(260, 160+90, 170, 20), myTremolo.effectRate, 2000F, 8000F);

		GUI.Box(new Rect(460, 160+10, 240, 140), "Bi Quad");
		myBiquad.filterOn = GUI.Toggle(new Rect(475, 160+35, 240, 20), myBiquad.filterOn, "ON/OFF");
		GUI.Label(new Rect(475, 160+60, 100, 25), "Cutoff");
		myBiquad.cutoffFrequency = (int) GUI.HorizontalSlider(new Rect(535, 160+65, 150, 20), myBiquad.cutoffFrequency, 20F, 10000F);
		GUI.Label(new Rect(475, 160+85, 100, 25), "Reson.");
		myBiquad.resonance = GUI.HorizontalSlider(new Rect(535, 160+90, 150, 20), myBiquad.resonance, -25F, 25F);

		GUI.Box(new Rect(260+460, 10, 240, 150), "High Pass");
		myHigh.filterOn = GUI.Toggle(new Rect(260+475, 35, 240, 20), myHigh.filterOn, "ON/OFF");
		GUI.Label(new Rect(260+475, 60, 100, 25), "Cutoff");
		myHigh.cutoffFrequency = (int) GUI.HorizontalSlider(new Rect(260+535, 65, 150, 20), myHigh.cutoffFrequency, 5F, 1500F);
		GUI.Label(new Rect(260+475, 85, 100, 25), "Reson.");
		myHigh.resonance = GUI.HorizontalSlider(new Rect(260+535, 90, 150, 20), myHigh.resonance, 0.1f, 1.41421f);

		GUI.Box(new Rect(260+460, 160+10, 240, 140), "Low Pass");
		myLow.filterOn = GUI.Toggle(new Rect(260+475, 160+35, 240, 20), myLow.filterOn, "ON/OFF");
		GUI.Label(new Rect(260+475, 160+60, 100, 25), "Cutoff");
		myLow.cutoffFrequency = (int) GUI.HorizontalSlider(new Rect(260+535, 160+65, 150, 20), myLow.cutoffFrequency, 100f, 5000f);
		GUI.Label(new Rect(260+475, 160+85, 100, 25), "Reson.");
		myLow.resonance = GUI.HorizontalSlider(new Rect(260+535, 160+90, 150, 20), myLow.resonance, 0.1f, 1.41421f);
	}


	// Use this for initialization
	void Start () {
		myEq = gameObject.GetComponent<SEF_Equalizer> ();
		myEq.filterOn = true;

		myRev = gameObject.GetComponent<SEF_reverb> ();
		myRev.filterOn = false;

		myDelay = gameObject.GetComponent<SEF_delay> ();
		myDelay.filterOn = false;

		myTremolo = gameObject.GetComponent<SEF_tremolo> ();
		myTremolo.filterOn = false;

		myBiquad = gameObject.GetComponent<SEF_biquad> ();
		myBiquad.filterOn = false;

		myHigh = gameObject.GetComponent<SEF_highpass> ();
		myHigh.filterOn = false;

		myLow = gameObject.GetComponent<SEF_lowpass> ();
		myLow.filterOn = false;

		GetComponent<AudioSource>().Play ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
