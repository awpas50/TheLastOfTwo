using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotation : MonoBehaviour
{
    public float speed;
    public int seed = 0;

    private void Start()
    {
        seed = Random.Range(0, 2); // 0 ~ 1
    }
    void Update()
    {
        if(seed == 0)
        {
            transform.Rotate(speed * Random.Range(0.5f, 0.8f) * Time.deltaTime, speed * Random.Range(0.6f, 1.2f) * Time.deltaTime, 0);
        }
        else if (seed == 1)
        {
            transform.Rotate(-speed * Random.Range(0.5f, 0.8f) * Time.deltaTime, -speed * Random.Range(0.6f, 1.2f) * Time.deltaTime, 0);
        }
    }
}
