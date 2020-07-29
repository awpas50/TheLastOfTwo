using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public bool isPaused = false;
    private GameManager gameManager;
    public void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
    }
    public void Update()
    {
        if(isPaused)
        {
            Time.timeScale = 0;
        } else
        {
            
            Time.timeScale = 1;
        }
    }
    public void Pause()
    {
        isPaused = true;
        gameManager.PauseAllAudio();
        gameManager.DisablePlayerControl();
        gameManager.AllUI.enabled = false;
        gameManager.PauseUI.enabled = true;
    }

    public void Resume()
    {
        isPaused = false;
        gameManager.ResumeAllAudio();
        gameManager.EnablePlayerControl();
        gameManager.AllUI.enabled = true;
        gameManager.PauseUI.enabled = false;
    }
}
