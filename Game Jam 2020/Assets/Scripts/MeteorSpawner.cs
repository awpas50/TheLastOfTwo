using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorSpawner : MonoBehaviour
{
    public GameObject spaceRubbish1;
    public GameObject spaceRubbish2;
    public GameObject spaceRubbish3;
    public GameObject spaceRubbish4;
    public float distance = 20f;
    public float interval;

    public GameObject[] rocketArray;
    public int maxRocketNum;
    public bool canSpawn;

    private float spawnTimer;
    public float spawnRate; // 1

    public int seed;

    private void Start()
    {
        canSpawn = true;
        spawnRate = Random.Range(0.2f, 1.8f);
    }
    private void Update()
    {
        spawnRate = Random.Range(0.2f, 1.8f);
        seed = Random.Range(0, 4); // 0,1,2,3
        rocketArray = GameObject.FindGameObjectsWithTag("Rocket");
        if(rocketArray.Length < maxRocketNum) // 0,1,2,3,4
        {
            canSpawn = true;
        }
        if (rocketArray.Length >= maxRocketNum) //5, 6, ......
        {
            canSpawn = false;
        }

        //Spawn rocket
        if (canSpawn && Time.time > spawnTimer)
        {
            Debug.Log(spawnTimer + " " + canSpawn);
            spawnTimer = Time.time + spawnRate;
            Vector3 pos = Random.onUnitSphere * distance;
            if(seed == 0)
            {
                Instantiate(spaceRubbish2, pos, Quaternion.Euler(Random.Range(0f, 360f), Random.Range(0f, 360f), Random.Range(0f, 360f)));
            }
            if (seed == 1)
            {
                Instantiate(spaceRubbish2, pos, Quaternion.Euler(Random.Range(0f, 360f), Random.Range(0f, 360f), Random.Range(0f, 360f)));
            }
            if (seed == 2)
            {
                Instantiate(spaceRubbish3, pos, Quaternion.Euler(Random.Range(0f, 360f), Random.Range(0f, 360f), Random.Range(0f, 360f)));
            }
            if (seed == 3)
            {
                Instantiate(spaceRubbish4, pos, Quaternion.Euler(Random.Range(0f, 360f), Random.Range(0f, 360f), Random.Range(0f, 360f)));
            }
            
        }
    }
}
