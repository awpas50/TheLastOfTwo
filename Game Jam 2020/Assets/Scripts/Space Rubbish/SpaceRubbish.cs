using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceRubbish : MonoBehaviour
{
    public int RocketID; 
    [Header("VFX")]
    public GameObject explosion1;
    public GameObject explosion2;
    public GameObject explosion3;
    public GameObject explosion4;

    public BoxCollider boxCol;
    private int seed;

    private void Update()
    {
        seed = Random.Range(0, 4); // 0,1,2,3
    }
    void OnCollisionEnter(Collision col)
    {
        switch (seed)
        {
            case 0:
                VFX(explosion1, col);
                SFX(SoundList.ExplosionEffect1);
                break;
            case 1:
                VFX(explosion2, col);
                SFX(SoundList.ExplosionEffect1);
                break;
            case 2:
                VFX(explosion3, col);
                SFX(SoundList.ExplosionEffect2);
                break;
            case 3:
                VFX(explosion4, col);
                SFX(SoundList.ExplosionEffect2);
                break;
        }
        boxCol.enabled = false;
        Destroy(gameObject, 1f);
    }

    void VFX(GameObject visualEffect, Collision col)
    {
        GameObject VFXPrefab = Instantiate(visualEffect, col.contacts[0].point + new Vector3(0, 0, -2), Quaternion.identity);
        Destroy(VFXPrefab, 3f);
    }

    void SFX(SoundList soundToPlay)
    {
        AudioManager.instance.Play(soundToPlay);
    }
}
