using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SummonAwan : MonoBehaviour
{
    public float yMax, yMin;
    public float waktu;
    public GameObject awan;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SummonKaktusCoroutine());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator SummonKaktusCoroutine()
    {
        yield return new WaitForSeconds(waktu);
        Instantiate(awan, transform.position + Vector3.up * Random.Range(yMax, yMin), Quaternion.identity);
        StartCoroutine(SummonKaktusCoroutine());
    }
}