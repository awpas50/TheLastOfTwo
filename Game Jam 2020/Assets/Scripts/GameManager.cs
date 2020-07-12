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
    public float roundTime;

    public GameObject player1;
    public GameObject player2;

    private void Start()
    {
        StartCoroutine(CountdownToStart());
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        PlayRocketFallSoundFX();

        if(roundTime <= 0)
        {
            EndGame();
        }
    }

    void EndGame()
    {
        if(player1.GetComponent<PlayerStat>().deathCounter < player2.GetComponent<PlayerStat>().deathCounter)
        {
            Debug.Log("Abby Wins!");
        }
        if (player1.GetComponent<PlayerStat>().deathCounter > player2.GetComponent<PlayerStat>().deathCounter)
        {
            Debug.Log("Ellie Wins!");
        }
        if (player1.GetComponent<PlayerStat>().deathCounter == player2.GetComponent<PlayerStat>().deathCounter)
        {
            Debug.Log("Draw!");
        }
    }
    IEnumerator CountdownToStart()
    {
        while(roundTime > 0)
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
