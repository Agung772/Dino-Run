using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SensorLevel : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("Hapus", 85);
        
    }

    // Update is called once per frame
    void Update()
    {
        Invoke("SensorNextLevelCoding", 60);

    }
    void SensorNextLevelCoding()
    {
        transform.Translate(Vector2.left * 1 * Time.deltaTime);
    }

    void Hapus()
    {
        Destroy(gameObject);
    }

}
