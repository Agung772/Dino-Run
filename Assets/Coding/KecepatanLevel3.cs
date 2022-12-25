using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KecepatanLevel3 : MonoBehaviour
{
    public float kecepatan;
    public GameObject objek;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("hilang", 4);
        Invoke("TambahKecepatan", (float)0.6);
        Invoke("KurangKecepatan", (float)0.7);
        Invoke("TambahKecepatan", (float)0.8);

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
        kecepatan += Random.Range(10, 30);
    }
    void KurangKecepatan()
    {
        kecepatan -= Random.Range(38, 40);
    }


}
