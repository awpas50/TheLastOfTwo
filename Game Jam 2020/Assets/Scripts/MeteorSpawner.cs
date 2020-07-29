using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorSpawner : MonoBehaviour
{
    GameManager gameManager;

    public GameObject spaceRubbish1;
    public GameObject spaceRubbish2;
    public GameObject spaceRubbish3;
    public GameObject spaceRubbish4;

    [Header("Space Rubbish Data")]
    public float distance = 20f;
    private float spawnTimer;
    [HideInInspector] public float spawnRate;
    public float spawnRateMin;
    public float spawnRateMax;
    public int maxRocketNum;
    public GameObject[] rocketArray;

    private bool canSpawn = true;
    private int seed;

    private void Start()
    {
        gameManager = gameObject.GetComponent<GameManager>();
    }
    private void Update()
    {
        spawnRate = Random.Range(spawnRateMin, spawnRateMax);
        
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
        if (canSpawn && Time.time > spawnTimer && gameManager.roundTime >= 10)
        {
            seed = Random.Range(0, 3); // 0,1,2
            spawnTimer = Time.time + spawnRate;
            Vector3 pos = Random.onUnitSphere * distance;
            if(seed == 0)
            {
                Instantiate(spaceRubbish2, pos, Quaternion.Euler(Random.Range(0f, 360f), Random.Range(0f, 360f), Random.Range(0f, 360f)));
            }
            if (seed == 1)
            {
                Instantiate(spaceRubbish3, pos, Quaternion.Euler(Random.Range(0f, 360f), Random.Range(0f, 360f), Random.Range(0f, 360f)));
            }
            if (seed == 2)
            {
                Instantiate(spaceRubbish4, pos, Quaternion.Euler(Random.Range(0f, 360f), Random.Range(0f, 360f), Random.Range(0f, 360f)));
            }
        }
    }
}
