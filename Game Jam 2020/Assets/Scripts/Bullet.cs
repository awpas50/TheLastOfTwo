using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private GameObject planet;
    public float damage;
    public GameObject particleEffect;
    public float moveSpeed;
    public float rotationSpeed;

    private float rotation;
    private Rigidbody rb;

    private float particleEffectTimer;
    public bool isSpawned = false;

    public float surviveTime;
    void Start()
    {
        particleEffectTimer = 0;
        planet = GameObject.FindGameObjectWithTag("Planet");
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        particleEffectTimer += Time.deltaTime;
        rb.MovePosition(rb.position + transform.forward * moveSpeed * Time.fixedDeltaTime);
        Vector3 yRotation = Vector3.up * rotation * rotationSpeed * Time.fixedDeltaTime;
        Quaternion deltaRotation = Quaternion.Euler(yRotation);
        Quaternion targetRotation = rb.rotation * deltaRotation;
        rb.MoveRotation(Quaternion.Slerp(rb.rotation, targetRotation, 50f * Time.deltaTime));

        if(particleEffectTimer >= surviveTime && !isSpawned)
        {
            
            GameObject particleEffectPrefab = Instantiate(particleEffect, transform.position, Quaternion.identity);
            isSpawned = true;
            Vector3 dir = planet.transform.position - transform.position;
            Quaternion rotation = Quaternion.Euler(dir.x, dir.y, dir.z);
            particleEffectPrefab.transform.rotation = rotation;

            
        }
        Destroy(gameObject, surviveTime);
    }

    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.gameObject.tag == "Player")
    //    {
    //        other.gameObject.GetComponent<FauxGravityBody>().placeOnSurface = false;
    //        other.gameObject.GetComponent<PlayerStat>().playerHealth -= damage;
    //        Destroy(gameObject);
    //    }
    //}

    private void OnCollisionEnter(Collision col)
    {
        if (col.collider.gameObject.tag == "Player")
        {
            col.collider.gameObject.GetComponent<FauxGravityBody>().placeOnSurface = false;
            col.collider.gameObject.GetComponent<PlayerStat>().playerHealth -= damage;
            col.collider.gameObject.GetComponent<PlayerStat>().HealthBar.GetComponent<Healthbar>().health = col.collider.gameObject.GetComponent<PlayerStat>().playerHealth;
            col.collider.gameObject.GetComponent<Rigidbody>().velocity = new Vector3(0,0,0);

            Destroy(gameObject);
            GameObject particleEffectPrefab = Instantiate(particleEffect, transform.position, Quaternion.identity);
            Vector3 dir = planet.transform.position - transform.position;
            Quaternion rotation = Quaternion.Euler(-dir.x, -dir.y, -dir.z);
            particleEffectPrefab.transform.rotation = rotation;
        }
    }
}
