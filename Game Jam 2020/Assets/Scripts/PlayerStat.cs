using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EZCameraShake;
using TMPro;

public class PlayerStat : MonoBehaviour
{
    public GameObject HealthBar;
    public float playerHealth;
    private float playerinitialHealth;
    public GameObject respawnLocation;

    public int deathCounter;
    public TextMeshProUGUI deathCounterText;
    // Start is called before the first frame update
    void Start()
    {
        HealthBar.GetComponent<Healthbar>().health = playerHealth;
        playerinitialHealth = playerHealth;
    }

    // Update is called once per frame
    void Update()
    {
        HealthBar.GetComponent<Healthbar>().health = playerHealth;
        if (playerHealth <= 0)
        {
            // player respawn sound
            AudioManager.instance.PlayOnce(SoundList.PlayerFallEffect);
            CameraShaker.Instance.ShakeOnce(8f, 4f, 0.1f, 1f);
            transform.position = respawnLocation.transform.position;
            deathCounter += 1;
            deathCounterText.text = deathCounter.ToString();

            playerHealth = playerinitialHealth;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.gameObject.tag == "Rocket")
        {
            AudioManager.instance.Play(SoundList.PlayerFallEffect);
            CameraShaker.Instance.ShakeOnce(8f, 4f, 0.1f, 1f);
            transform.position = respawnLocation.transform.position;
            deathCounter += 1;
            deathCounterText.text = deathCounter.ToString();
            playerHealth = playerinitialHealth;

            Destroy(collision.collider.gameObject.gameObject);
        }
    }
}
