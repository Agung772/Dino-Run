using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Summon : MonoBehaviour
{
    public GameObject kaktus;
    public float waktu;
    public float xMax, xMin;
    public GameObject kecepatanWaktu;
    public float acak;


    // Start is called before the first frame update
    void Start()
    {
        acak = Random.Range((float) 1, 3);
        StartCoroutine(SummonKaktusCoroutine());
    }

    IEnumerator SummonKaktusCoroutine()
    {
        yield return new WaitForSeconds(acak);
        Instantiate(kaktus, transform.position + Vector3.right * Random.Range(xMax, xMin), Quaternion.identity);
        StartCoroutine(SummonKaktusCoroutine());
    }

}
