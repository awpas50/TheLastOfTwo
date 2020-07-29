using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Tutorial : MonoBehaviour
{
    public GameObject easterEggScreen;
    public GameObject tutorialScreen;
    public GameObject mainMenu;

    public void StartTutorial()
    {
        easterEggScreen.SetActive(false);
        tutorialScreen.SetActive(true);
        mainMenu.SetActive(false);
    }

    public void Update()
    {
        WaitForButtonPress();
    }

    public void WaitForButtonPress()
    {
        if (Input.anyKeyDown && tutorialScreen.activeSelf)
        {
            SceneManager.LoadScene(1);
        }
    }
}
