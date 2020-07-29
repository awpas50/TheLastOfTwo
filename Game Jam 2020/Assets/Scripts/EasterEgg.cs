using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EasterEgg : MonoBehaviour
{
    public int counter = 0;
    public GameObject[] easterEggPicList;

    public Text option;
    
    public void ButtonClick()
    {
        counter++;
    }
    // Update is called once per frame
    void Update()
    {
        switch(counter)
        {
            case 3:
            case 4:
            case 5:
                {
                    option.text = "No Option Avaliable";
                    break;
                }
            case 6:
            case 7:
                {
                    option.text = "Do not touch me";
                    break;
                }
            case 8:
            case 9:
                {
                    option.text = "Don't Click me!";
                    break;
                }
            case 10:
                {
                    option.text = "NO!!!!!!!";
                    easterEggPicList[0].SetActive(true);
                    break;
                }
            case 11:
                {
                    option.text = "I will be";
                    easterEggPicList[1].SetActive(true);
                    break;
                }
            case 12:
                {
                    option.text = "banned by";
                    easterEggPicList[2].SetActive(true);
                    break;
                }
            case 13:
                {
                    option.text = "Naughty Dog";
                    easterEggPicList[3].SetActive(true);
                    break;
                }
            case 14:
                {
                    option.text = "You won't";
                    easterEggPicList[4].SetActive(true);
                    break;
                }
            case 15:
                {
                    option.text = "see me";
                    easterEggPicList[5].SetActive(true);
                    break;
                }
            case 16:
                {
                    option.text = "again";
                    easterEggPicList[6].SetActive(true);
                    break;
                }
        }
    }
}
