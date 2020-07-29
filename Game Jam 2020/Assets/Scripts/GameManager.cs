using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public float roundTime;
    [Header("SFX")]
    public AudioSource mainMusic;
    private AudioSource[] allAudioSources;
    [Header("UI")]
    public Canvas PauseUI;
    public Canvas AllUI;
    public TextMeshProUGUI timerText;
    public TextMeshProUGUI endGameText;
    public GameObject endGameUI;
    public TextMeshProUGUI tipsText1;
    public TextMeshProUGUI tipsText2;
    public GameObject playerTag1;
    public GameObject playerTag2;
    [Header("Ref")]
    public GameObject player1;
    public GameObject player2;
    public GameObject mainMenuController;
    public GameObject mainCam;
    public CameraRotation cameraRotation;
    private MeteorSpawner meteorSpawner;
    public GameObject bigRocket;
    public bool isBigRocketSpawned = false;

    float t1 = 0;
    float t2 = 0;
    float t3 = 0;

    [HideInInspector] public bool buttonTstate = true;
    [HideInInspector] public bool buttonYstate = true;
    [HideInInspector] public bool buttonUstate = true;
    private void Start()
    {
        meteorSpawner = gameObject.GetComponent<MeteorSpawner>();
        StartCoroutine(CountdownToStart());
        endGameUI.SetActive(false);
        endGameText.text = "";
        EnablePlayerControl();

        StartCoroutine(PlayRocketFallSoundFX(5));
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            buttonTstate = !buttonTstate;
        }
        if (Input.GetKeyDown(KeyCode.Y))
        {
            buttonYstate = !buttonYstate;
        }
        if (Input.GetKeyDown(KeyCode.U))
        {
            buttonUstate = !buttonUstate;
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!mainMenuController.GetComponent<PauseMenu>().isPaused)
            {
                mainMenuController.GetComponent<PauseMenu>().isPaused = true;
                mainMenuController.GetComponent<PauseMenu>().Pause();
            }
            else
            {
                mainMenuController.GetComponent<PauseMenu>().isPaused = false;
                mainMenuController.GetComponent<PauseMenu>().Resume();
            }
        }
        //if (!buttonTstate) {
        //    tipsText1.text = "[T] Tips OFF";
        //    playerText1.enabled = false;
        //    playerText2.enabled = false;
        //} else {
        //    tipsText1.text = "[T] Tips ON";
        //    playerText1.enabled = true;
        //    playerText2.enabled = true;
        //}
        //if (!buttonYstate) {
        //    tipsText2.text = "[Y] Indicator OFF";
        //    playerTag1.SetActive(false);
        //    playerTag2.SetActive(false);
        //} else {
        //    tipsText2.text = "[Y] Indicator ON";
        //    playerTag1.SetActive(true);
        //    playerTag2.SetActive(true);
        //}
        //if (!buttonUstate) {
        //    AllUI.enabled = false;
        //}
        //else {
        //    AllUI.enabled = true;
        //}

        //Timer
        if (roundTime >= 30)
        {
            t1 += Time.deltaTime;
            cameraRotation.speed = Mathf.Lerp(cameraRotation.initialSpeed * 1f, cameraRotation.initialSpeed * 30f, t1 / 180);
        }
        if (roundTime >= 10 && roundTime <= 29)
        {
            t2 += Time.deltaTime;
            cameraRotation.speed = Mathf.Lerp(cameraRotation.initialSpeed * 30f, cameraRotation.initialSpeed * 12f, t2 / 20);
        }
        if(roundTime < 6.5f)
        {
            mainCam.GetComponent<Camera>().fieldOfView = Mathf.Lerp(60, 75, t3 / 1);
        }
        if (roundTime <= 5.5f)
        {
            t3 += Time.deltaTime;
            cameraRotation.speed = Mathf.Lerp(cameraRotation.initialSpeed * 12f, cameraRotation.initialSpeed * 4f, t3 / 2.5f);
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
    }

    void EndGame()
    {
        endGameUI.SetActive(true);
        if (player1.GetComponent<PlayerStat>().score < player2.GetComponent<PlayerStat>().score)
        {
            endGameText.text = "Ellie Wins!";
        }
        if (player1.GetComponent<PlayerStat>().score > player2.GetComponent<PlayerStat>().score)
        {
            endGameText.text = "Abby Wins!";
        }
        if (player1.GetComponent<PlayerStat>().score == player2.GetComponent<PlayerStat>().score)
        {
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
    IEnumerator PlayRocketFallSoundFX(float interval)
    {
        if (!mainMenuController.GetComponent<PauseMenu>().isPaused)
        {
            yield return new WaitForSeconds(interval);
            AudioManager.instance.Play(SoundList.RocketFallEffect);
        }
        else
        {
            yield return null;
        }
    }

    public void EnablePlayerControl()
    {
        player1.GetComponent<PlayerMovement>().enabled = true;
        player1.GetComponent<PlayerShooting>().enabled = true;
        player1.GetComponent<PlayerStat>().enabled = true;
        player2.GetComponent<PlayerMovement>().enabled = true;
        player2.GetComponent<PlayerShooting>().enabled = true;
        player2.GetComponent<PlayerStat>().enabled = true;
    }

    public void DisablePlayerControl()
    {
        player1.GetComponent<PlayerMovement>().enabled = false;
        player1.GetComponent<PlayerShooting>().enabled = false;
        player1.GetComponent<PlayerStat>().enabled = false;
        player2.GetComponent<PlayerMovement>().enabled = false;
        player2.GetComponent<PlayerShooting>().enabled = false;
        player2.GetComponent<PlayerStat>().enabled = false;
    }
    public void PauseAllAudio()
    {
        allAudioSources = FindObjectsOfType(typeof(AudioSource)) as AudioSource[];
        foreach (AudioSource audioS in allAudioSources)
        {
            audioS.Pause();
        }
    }
    public void ResumeAllAudio()
    {
        allAudioSources = FindObjectsOfType(typeof(AudioSource)) as AudioSource[];
        foreach (AudioSource audioS in allAudioSources)
        {
            audioS.UnPause();
        }
    }
}
