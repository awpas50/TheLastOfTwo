using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockSpawner : MonoBehaviour
{
    public GameObject planet;
    
    public int rockNumber;
    public GameObject[] rockList;
    public int plantNumber;
    public GameObject[] plantList;

    void Start()
    {
        planet = GameObject.FindGameObjectWithTag("Planet");
        for (int i = 0; i < rockNumber + plantNumber; i++)
        {
            Vector3 pos = Random.onUnitSphere * 10;
            if (i < rockNumber)
            {
                //create the rotation we need to be in to look at the target
                //rotate us over time according to speed until we are in the required rotation
                GameObject rockPrefab = Instantiate(rockList[Random.Range(0, rockList.Length)], pos, Quaternion.identity);
                Vector3 dir1 = (rockPrefab.transform.position - planet.transform.position).normalized;
                rockPrefab.transform.rotation = Quaternion.LookRotation(dir1);
            }
            if(i >= rockNumber)
            {
                GameObject cactusPrefab = Instantiate(plantList[Random.Range(0, plantList.Length)], pos, Quaternion.identity);
                Vector3 dir2 = (cactusPrefab.transform.position - planet.transform.position).normalized;
                cactusPrefab.transform.rotation = Quaternion.LookRotation(dir2);
            }
        }
    }
}
