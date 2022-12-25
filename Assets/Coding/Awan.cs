using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Awan : MonoBehaviour
{
    public float kecepatanAwan;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("hilang", 13);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.left * kecepatanAwan * Time.deltaTime);
    }
    void hilang()
    {
        Destroy(gameObject);
    }
}
