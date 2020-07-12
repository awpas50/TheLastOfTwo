using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public GameObject bullet;
    public GameObject fireLocation;
    public KeyCode shoot;

    private float nextFire;
    public float fireRate;

    void Update()
    {
        // Generate
        if (Input.GetKeyDown(shoot) && Time.time > nextFire)
        {
            Instantiate(bullet, fireLocation.transform.position, transform.rotation);
            int seed = Random.Range(0, 4);
            nextFire = Time.time + fireRate;
            if(seed == 0)
            {
                AudioManager.instance.Play(SoundList.PlayerShootEffect1);
            }
            if (seed == 1)
            {
                AudioManager.instance.Play(SoundList.PlayerShootEffect2);
            }
            if (seed == 2)
            {
                AudioManager.instance.Play(SoundList.PlayerShootEffect3);
            }
            if (seed == 3)
            {
                AudioManager.instance.Play(SoundList.PlayerShootEffect4);
            }
        }
    }
}
