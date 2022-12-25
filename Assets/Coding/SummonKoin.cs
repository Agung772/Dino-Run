using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SummonKoin : MonoBehaviour
{
    public GameObject koin;
    public float waktu;
    public float yMax, yMin;
    float random;


    // Start is called before the first frame update
    void Start()
    {
        random = Random.Range(1f, 3f);
        StartCoroutine(KoinCoroutine());
    }

    IEnumerator KoinCoroutine()
    {
        yield return new WaitForSeconds(waktu);
        Instantiate(koin, transform.position + Vector3.up * Random.Range(yMax, yMin), Quaternion.identity);
        StartCoroutine(KoinCoroutine());
    }

    // Update is called once per frame
    void Update()
    {

    }

}
