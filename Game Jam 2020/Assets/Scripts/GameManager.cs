using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip rocketFallEffect;

    public TextMeshProUGUI timerText;
    public TextMeshProUGUI endGameText;
    public float roundTime;

    public GameObject player1;
    public GameObject player2;

    public MeteorSpawner meteorSpawner;

    public bool isBigRocketSpawned = false;
    public GameObject bigRocket;
    public GameObject mainCam;

    public GameObject endGameUI;

    private void Start()
    {
        StartCoroutine(CountdownToStart());
        endGameUI.SetActive(false);
        endGameText.text = "";
    }
    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.R))
        //{
        //    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        //}
        PlayRocketFallSoundFX();
        if(roundTime >= 180 && roundTime <= 240)
        {
            meteorSpawner.distance = 200;
        }
        if (roundTime >= 120 && roundTime <= 179)
        {
            meteorSpawner.distance = 130;
        }
        if (roundTime >= 60 && roundTime <= 119)
        {
            meteorSpawner.distance = 60;
        }
        if (roundTime >= 0 && roundTime <= 59)
        {
            meteorSpawner.distance = 20;
        }
        if(roundTime <= 8 && !isBigRocketSpawned)
        {
            Instantiate(bigRocket, mainCam.transform.position, Quaternion.identity);
            isBigRocketSpawned = true;
        }
        if (roundTime <= 0)
        {
            EndGame();
        }
    }

    void EndGame()
    {
        endGameUI.SetActive(true);
        if (player1.GetComponent<PlayerStat>().deathCounter < player2.GetComponent<PlayerStat>().deathCounter)
        {
            Debug.Log("Abby Wins!");
            endGameText.text = "Abby Wins!";
        }
        if (player1.GetComponent<PlayerStat>().deathCounter > player2.GetComponent<PlayerStat>().deathCounter)
        {
            Debug.Log("Ellie Wins!");
            endGameText.text = "Ellie Wins!";
        }
        if (player1.GetComponent<PlayerStat>().deathCounter == player2.GetComponent<PlayerStat>().deathCounter)
        {
            Debug.Log("Draw!");
            endGameText.text = "Draw!";
        }
    }
    IEnumerator CountdownToStart()
    {
        while(roundTime >= 0)
        {
            timerText.text = roundTime.ToString();
            yield return new WaitForSeconds(1f);
            roundTime--;
        }
    }
    void PlayRocketFallSoundFX()
    {
        if (!audioSource.isPlaying)
        {
            audioSource.PlayOneShot(rocketFallEffect);
        }
    }
}
