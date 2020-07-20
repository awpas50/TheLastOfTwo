using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public float roundTime;
    [Header("SFX")]
    public AudioSource audioSource;
    [Header("VFX")]
    public AudioClip rocketFallEffect;
    [Header("UI")]
    public TextMeshProUGUI timerText;
    public TextMeshProUGUI endGameText;
    public GameObject endGameUI;
    public GameObject FadeScreen;
    [Header("Ref")]
    public GameObject player1;
    public GameObject player2;
    public GameObject mainCam;
    public CameraRotation cameraRotation;
    private MeteorSpawner meteorSpawner;
    public GameObject bigRocket;
    public bool isBigRocketSpawned = false;

    float t1 = 0;
    float t2 = 0;
    float t3 = 0;

    private void Start()
    {
        meteorSpawner = gameObject.GetComponent<MeteorSpawner>();
        StartCoroutine(CountdownToStart());
        endGameUI.SetActive(false);
        endGameText.text = "";

        EnablePlayerControl();
    }
    void Update()
    {
        //SFX
        PlayRocketFallSoundFX();

        //DEBUG
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        if (Input.GetKeyDown(KeyCode.T))
        {
            roundTime = 7;
        }

        //Timer
        if (roundTime >= 60)
        {
            t1 += Time.deltaTime;
            cameraRotation.speed = Mathf.Lerp(cameraRotation.initialSpeed * 1f, cameraRotation.initialSpeed * 25f, t1 / 180);
        }
        if (roundTime >= 10 && roundTime <= 59)
        {
            t2 += Time.deltaTime;
            cameraRotation.speed = Mathf.Lerp(cameraRotation.initialSpeed * 25f, cameraRotation.initialSpeed * 12f, t2 / 50);
        }
        if (roundTime <= 6f)
        {
            t3 += Time.deltaTime;
            cameraRotation.speed = Mathf.Lerp(cameraRotation.initialSpeed * 12f, cameraRotation.initialSpeed * 4f, t3 / 6);
            mainCam.GetComponent<Camera>().fieldOfView = Mathf.Lerp(60, 75, t3 / 1);
            if (!isBigRocketSpawned)
            {
                Instantiate(bigRocket, mainCam.transform.position, Quaternion.identity);
                isBigRocketSpawned = true;
            }
        }
        if (roundTime == 0)
        {
            EndGame();
            DisablePlayerControl();
        }

        //if(roundTime >= 187)
        //{
        //    meteorSpawner.distance = 200;
        //}
        //if (roundTime >= 120 && roundTime <= 186)
        //{
        //    meteorSpawner.distance = 150;
        //    cameraRotation.speed = Mathf.Lerp(cameraRotation.initialSpeed * 1f, cameraRotation.initialSpeed * 3f, 5);
        //}
        //if (roundTime >= 60 && roundTime <= 119)
        //{
        //    meteorSpawner.distance = 90;
        //    cameraRotation.speed = Mathf.Lerp(cameraRotation.initialSpeed * 3f, cameraRotation.initialSpeed * 6f, 5);
        //}
        //if (roundTime >= 10 && roundTime <= 59)
        //{
        //    meteorSpawner.distance = 60;
        //    cameraRotation.speed = Mathf.Lerp(cameraRotation.initialSpeed * 6f, cameraRotation.initialSpeed * 15f, 5);
        //}
        //if (roundTime <= 5.5f)
        //{
        //    meteorSpawner.distance = 20;
        //    cameraRotation.speed = Mathf.Lerp(cameraRotation.initialSpeed * 15f, cameraRotation.initialSpeed * 2f, 2);
        //}

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

    //SFX
    void PlayRocketFallSoundFX()
    {
        if (!audioSource.isPlaying)
        {
            audioSource.PlayOneShot(rocketFallEffect);
        }
    }

    void EnablePlayerControl()
    {
        player1.GetComponent<PlayerMovement>().enabled = true;
        player1.GetComponent<PlayerShooting>().enabled = true;
        player1.GetComponent<PlayerStat>().enabled = true;
        player2.GetComponent<PlayerMovement>().enabled = true;
        player2.GetComponent<PlayerShooting>().enabled = true;
        player2.GetComponent<PlayerStat>().enabled = true;
    }

    void DisablePlayerControl()
    {
        player1.GetComponent<PlayerMovement>().enabled = false;
        player1.GetComponent<PlayerShooting>().enabled = false;
        player1.GetComponent<PlayerStat>().enabled = false;
        player2.GetComponent<PlayerMovement>().enabled = false;
        player2.GetComponent<PlayerShooting>().enabled = false;
        player2.GetComponent<PlayerStat>().enabled = false;
    }
}
