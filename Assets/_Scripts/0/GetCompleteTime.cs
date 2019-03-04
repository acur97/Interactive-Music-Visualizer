using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetCompleteTime : MonoBehaviour {

    public AudioSource Source;
    public GameObject Cube;
    [Space]
    public float Multiplicador = 512;

    private GameObject cub;
    private float duracion = 0;

    void Start () {
        cub = Instantiate(Cube);
        cub.transform.parent = gameObject.transform;
        cub.transform.localPosition = new Vector3(0, 0, 0);
        cub.name = "Cube 0";
    }

    void Update ()
    {
        duracion = (Source.clip.length + Source.time - Source.clip.length) / Source.clip.length;
        cub.transform.localScale = new Vector3((duracion * Multiplicador), 1, 1);
        cub.transform.localPosition = new Vector3((duracion * Multiplicador) / 2, 0, 0);
    }
}