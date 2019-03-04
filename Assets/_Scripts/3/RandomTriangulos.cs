using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomTriangulos : MonoBehaviour {

    public float TiempoEntreTriangulos;
    public bool delay;
    [Space]
    public GameObject TrianguloPrefab;
    public Transform Posicion;
    public float randomPosMin;
    public float randomPosMax;
    public Transform Padre;

    private Vector3 localpos1;
    private Vector3 localpos2;
    private Vector3 localpos3;
    private Vector3 localpos4;
    private Vector3 localpos5;
    private Quaternion quat = new Quaternion(0, 0, 0, 0);
    private bool una = false;

	void Update()
    {
        if (!una)
        {
            StartCoroutine(CrearTriangulos());
            una = true;
        }
	}

    IEnumerator CrearTriangulos()
    {
        if (delay)
        {
            yield return new WaitForSeconds(Random.Range(1, 5));
        }
        localpos1 = new Vector3(Posicion.localPosition.x + Random.Range(randomPosMin, randomPosMax), Posicion.localPosition.y + Random.Range(randomPosMin * 2, randomPosMax * 2), Posicion.localPosition.z + Random.Range(randomPosMin, randomPosMax * 4));
        Instantiate(TrianguloPrefab, localpos1, quat, Padre);

        yield return new WaitForSeconds(TiempoEntreTriangulos);

        localpos2 = new Vector3(Posicion.localPosition.x + Random.Range(randomPosMin, randomPosMax), Posicion.localPosition.y + Random.Range(randomPosMin * 2, randomPosMax * 2), Posicion.localPosition.z + Random.Range(randomPosMin, randomPosMax * 4));
        Instantiate(TrianguloPrefab, localpos2, quat, Padre);

        yield return new WaitForSeconds(TiempoEntreTriangulos);

        localpos3 = new Vector3(Posicion.localPosition.x + Random.Range(randomPosMin, randomPosMax), Posicion.localPosition.y + Random.Range(randomPosMin * 2, randomPosMax * 2), Posicion.localPosition.z + Random.Range(randomPosMin, randomPosMax * 4));
        Instantiate(TrianguloPrefab, localpos3, quat, Padre);

        yield return new WaitForSeconds(TiempoEntreTriangulos);

        localpos4 = new Vector3(Posicion.localPosition.x + Random.Range(randomPosMin, randomPosMax), Posicion.localPosition.y + Random.Range(randomPosMin * 2, randomPosMax * 2), Posicion.localPosition.z + Random.Range(randomPosMin, randomPosMax * 4));
        Instantiate(TrianguloPrefab, localpos4, quat, Padre);

        yield return new WaitForSeconds(TiempoEntreTriangulos);

        localpos5 = new Vector3(Posicion.localPosition.x + Random.Range(randomPosMin, randomPosMax), Posicion.localPosition.y + Random.Range(randomPosMin * 2, randomPosMax * 2), Posicion.localPosition.z + Random.Range(randomPosMin, randomPosMax * 4));
        Instantiate(TrianguloPrefab, localpos5, quat, Padre);

        yield return new WaitForSeconds(TiempoEntreTriangulos);

        StartCoroutine(CrearTriangulos());
    }
}
