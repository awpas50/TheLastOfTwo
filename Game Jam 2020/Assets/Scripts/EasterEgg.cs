using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EasterEgg : MonoBehaviour
{
    public int counter = 0;
    public GameObject easterEggScene;
    public Text option;

    public void Start()
    {
        easterEggScene.SetActive(false);
    }
    public void ButtonClick()
    {
        counter++;
    }
    // Update is called once per frame
    void Update()
    {
        if(counter >= 3 && counter <= 5)
        {
            option.text = "No Option Avaliable";
        }
        if (counter >= 6 && counter <= 7)
        {
            option.text = "Don't Click me!";
        }
        if (counter >= 8 && counter <= 9)
        {
            option.text = "NO!!!!!!!";
        }
        if (counter >= 10)
        {
            option.text = ".......";
            easterEggScene.SetActive(true);
        }
    }
}
