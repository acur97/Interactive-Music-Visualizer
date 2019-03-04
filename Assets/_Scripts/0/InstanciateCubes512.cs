using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstanciateCubes512 : MonoBehaviour {

    public GameObject CubePrefa;
    private GameObject[] samples = new GameObject[512];
    public float maxScale;
    public float baseScale;

    private void Awake()
    {
        for (int i = 0; i < 512; i++)
        {
            GameObject instantiateCubes = (GameObject)Instantiate(CubePrefa);
            instantiateCubes.transform.position = transform.position;
            instantiateCubes.transform.parent = transform;
            instantiateCubes.name = "Cube " + i;
            transform.eulerAngles = new Vector3(0, -0.703125f * i, 0);
            instantiateCubes.transform.position = Vector3.forward * 100;
            samples[i] = instantiateCubes;
        }
    }

    void Update ()
    {
        for (int i = 0; i < 512; i++)
        {
            samples[i].transform.localScale = new Vector3(baseScale, (AudioSpectrum.sample[i] * maxScale) + 2, baseScale);
        }
	}
}
