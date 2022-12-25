using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KecepatanLevel2 : MonoBehaviour
{
    public float kecepatan;
    public GameObject objek;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("hilang", 4);
        Invoke("TambahKecepatan", Random.Range((float)0.7, (float)1.1));

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.left * kecepatan * Time.deltaTime);
    }
    void hilang()
    {
        Destroy(gameObject);
    }

    void TambahKecepatan()
    {
        kecepatan += Random.Range(8, 14);
    }


}
