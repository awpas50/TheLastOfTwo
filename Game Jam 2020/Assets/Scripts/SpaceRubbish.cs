using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceRubbish : MonoBehaviour
{
    //public GameObject explosion;
    public BoxCollider boxCol;
    //public ParticleSystem trail;

    void OnCollisionEnter(Collision col)
    {
        Quaternion rot = Quaternion.LookRotation(transform.position.normalized);
        rot *= Quaternion.Euler(90f, 0f, 0f);
        //Instantiate(explosion, col.contacts[0].point, rot);

        //boxCol.enabled = false;
        //trail.Stop(true, ParticleSystemStopBehavior.StopEmitting);

        this.enabled = false;
        //GetComponent<AudioSource>().Stop();

        Destroy(gameObject, 0.5f);
    }

    //private void OnTriggerEnter(Collider other)
    //{
    //    if(other.gameObject.tag == "SoundTriggerZone")
    //    {
    //        AudioManager.instance.Play(SoundList.RocketFallEffect);
    //    }
    //}
}
