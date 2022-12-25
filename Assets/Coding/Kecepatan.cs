using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kecepatan : MonoBehaviour
{
    public float kecepatan;
    public GameObject objek;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("hilang", 4);
        TambahKecepatan();

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
        kecepatan += Random.Range(1, 4);
    }


}
