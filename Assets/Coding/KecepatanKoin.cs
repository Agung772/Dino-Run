using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KecepatanKoin : MonoBehaviour
{
    public float kecepatanKoin;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("KoinLewat", 10);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.left * kecepatanKoin * Time.deltaTime);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("player"))
        {
            
            Destroy(gameObject);
        }
    }


    void KoinLewat()
    {
        Destroy(gameObject);
    }
}
