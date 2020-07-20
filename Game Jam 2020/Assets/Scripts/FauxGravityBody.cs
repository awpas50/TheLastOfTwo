using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class FauxGravityBody : MonoBehaviour
{
    public GameManager gameManager;
    public SpaceRubbish spaceRubbish;
    public FauxGravityAttracter attractor;
    public Rigidbody rb;

    [HideInInspector] public float initGravity;
    public float gravity;
    public bool placeOnSurface = false;

    void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
        spaceRubbish = transform.GetComponent<SpaceRubbish>();
        initGravity = gravity;
        rb = GetComponent<Rigidbody>();
        attractor = FauxGravityAttracter.instance;
    }

    private void Update()
    {
        if(spaceRubbish == null)
        {
            return;
        }
        if (spaceRubbish.RocketID == 5)
        {
            gravity = initGravity;
        }
        else if (spaceRubbish.RocketID != 5)
        {
            if (gameManager.roundTime >= 186 && gameManager.roundTime <= 240)
            {
                gravity = initGravity;
            }
            if (gameManager.roundTime >= 120 && gameManager.roundTime <= 185)
            {
                gravity = initGravity - 2f;
            }
            if (gameManager.roundTime >= 60 && gameManager.roundTime <= 119)
            {
                gravity = initGravity - 2f;
            }
            if (gameManager.roundTime <= 59)
            {
                gravity = initGravity - 3f;
            }
        }
        
    }

    void FixedUpdate()
    {
        if (placeOnSurface)
            attractor.PlaceOnSurface(rb);
        else
            attractor.Attract(rb, gravity);
    }
}
