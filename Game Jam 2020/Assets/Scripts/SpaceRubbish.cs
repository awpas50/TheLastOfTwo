using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceRubbish : MonoBehaviour
{
    public GameObject explosion;
    public BoxCollider boxCol;
    GameObject planet;
    //public ParticleSystem trail;

    private void Start()
    {
        planet = GameObject.FindGameObjectWithTag("Planet");
    }

    void OnCollisionEnter(Collision col)
    {
        GameObject explosionPrefab = Instantiate(explosion, col.contacts[0].point + new Vector3(0,0,-2), Quaternion.identity);

        AudioManager.instance.Play(SoundList.ExplosionEffect1);
        // VFX rotation
        //Vector3 dir = planet.transform.position - transform.position;
        //Quaternion rotation = Quaternion.Euler(-dir.x, -dir.y, -dir.z);
        //explosionPrefab.transform.rotation = rotation;

        Destroy(gameObject, 0.2f);
        Destroy(explosionPrefab, 3f);
        
    }

    //private void OnTriggerEnter(Collider other)
    //{
    //    if(other.gameObject.tag == "SoundTriggerZone")
    //    {
    //        AudioManager.instance.Play(SoundList.RocketFallEffect);
    //    }
    //}
}
