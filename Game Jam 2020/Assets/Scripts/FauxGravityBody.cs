using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class FauxGravityBody : MonoBehaviour
{
    private FauxGravityAttracter attractor;
    private Rigidbody rb;

    public float gravity = -10f;

    public bool placeOnSurface = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        attractor = FauxGravityAttracter.instance;
    }

    void FixedUpdate()
    {
        if (placeOnSurface)
            attractor.PlaceOnSurface(rb);
        else
            attractor.Attract(rb, gravity);
    }
}
