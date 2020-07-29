using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject playerWhoShoot;
    private GameObject planet;
    public float damage;
    public GameObject particleEffect;
    public GameObject particleEffect2;
    public float moveSpeed;
    public float rotationSpeed;

    private float rotation;
    private Rigidbody rb;

    private float particleEffectTimer;
    public bool isSpawned = false;

    public float surviveTime;

    public void RecognizePlayer(PlayerShooting _playerShootingScript)
    {
        playerWhoShoot = _playerShootingScript.gameObject;
    }

    void Start()
    {
        particleEffectTimer = 0;
        planet = GameObject.FindGameObjectWithTag("Planet");
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
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
            GameObject particleEffectPrefab2 = Instantiate(particleEffect2, transform.position, Quaternion.identity);
            isSpawned = true;
        }
        Destroy(gameObject, surviveTime);
    }

    private void OnCollisionEnter(Collision col)
    {
        if(col.collider.gameObject == playerWhoShoot)
        {
            return;
        }
        else if (col.collider.gameObject.tag == "Player")
        {
            col.collider.gameObject.GetComponent<FauxGravityBody>().placeOnSurface = false;
            col.collider.gameObject.GetComponent<PlayerStat>().playerHealth -= damage;
            col.collider.gameObject.GetComponent<PlayerStat>().HealthBar.GetComponent<Healthbar>().health = col.collider.gameObject.GetComponent<PlayerStat>().playerHealth;
            col.collider.gameObject.GetComponent<Rigidbody>().velocity = new Vector3(0,0,0);

            Destroy(gameObject);
            GameObject particleEffectPrefab = Instantiate(particleEffect, transform.position, Quaternion.identity);
            GameObject particleEffectPrefab2 = Instantiate(particleEffect2, transform.position, Quaternion.identity);
        }
        if(col.collider.gameObject.tag == "Rock")
        {
            Destroy(gameObject);
            GameObject particleEffectPrefab = Instantiate(particleEffect, transform.position, Quaternion.identity);
            GameObject particleEffectPrefab2 = Instantiate(particleEffect2, transform.position, Quaternion.identity);
        }
    }
}
