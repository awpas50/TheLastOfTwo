using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EZCameraShake;
using TMPro;

public class PlayerStat : MonoBehaviour
{
    public GameObject HealthBar;
    public float playerHealth;
    [HideInInspector] public float playerinitialHealth;
    public GameObject respawnLocation;
    public GameObject opponent;
    public int score;
    public TextMeshProUGUI scoreText;

    void Start()
    {
        HealthBar.GetComponent<Healthbar>().health = playerHealth;
        playerinitialHealth = playerHealth;
    }

    void Update()
    {
        HealthBar.GetComponent<Healthbar>().health = playerHealth;
        if (playerHealth <= 0)
        {
            AudioManager.instance.Play(SoundList.PlayerFallEffect);
            CameraShaker.Instance.ShakeOnce(8f, 4f, 0.1f, 1f);
            RestoreHealth();
            AddScore(opponent);
            Respawn(respawnLocation);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Player died
        if (collision.collider.gameObject.tag == "Rocket")
        {
            AudioManager.instance.Play(SoundList.PlayerFallEffect);
            CameraShaker.Instance.ShakeOnce(8f, 4f, 0.1f, 1f);
            RestoreHealth();
            AddScore(opponent);
            Respawn(respawnLocation);
            //Destroy rocket
            Destroy(collision.collider.gameObject);
        }
    }

    public void RestoreHealth()
    {
        playerHealth = playerinitialHealth;
    }
    public void Respawn(GameObject respawnLocation)
    {
        transform.position = respawnLocation.transform.position;
    }
    public void AddScore(GameObject opponent)
    {
        PlayerStat opponentStat = opponent.GetComponent<PlayerStat>();
        opponentStat.score += 1;
        opponentStat.scoreText.text = opponentStat.score.ToString();
    }
}
