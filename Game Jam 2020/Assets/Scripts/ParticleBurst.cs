using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleBurst : MonoBehaviour
{
    void Update()
    {
        Destroy(gameObject, 3f);
    }
}
