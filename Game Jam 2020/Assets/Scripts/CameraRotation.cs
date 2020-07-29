using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotation : MonoBehaviour
{
    [HideInInspector] public float initialSpeed;
    public float speed;
    private int seed = 0;

    private void Start()
    {
        initialSpeed = speed;
        seed = Random.Range(0, 2); // 0 ~ 1
    }
    void Update()
    {
        float rndX = Random.Range(0.2f, 1f);
        float rndY = Random.Range(0.2f, 1f);
        if (seed == 0)
        {
            transform.Rotate(speed * rndX * Time.deltaTime, speed * rndY * Time.deltaTime, 0);
        }
        else if (seed == 1)
        {
            transform.Rotate(-speed * rndX * Time.deltaTime, -speed * rndY * Time.deltaTime, 0);
        }
    }
}
