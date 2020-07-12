using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereColor : MonoBehaviour
{
    public float colorSwitchSpeed = 1f;
    public List<Color> ColorList;
    public Color startColor;
    public Color endColor;

    public float fadeStart;
    public float fadeTime;

    private void Start()
    {
        
    }
    private void Update()
    {
        ColourChanging();
    }

    void ColourChanging()
    {
        gameObject.GetComponent<Renderer>().material.color = Color.Lerp(startColor, endColor, fadeStart);
        //gameObject.GetComponent<Renderer>().material.color = Color.Lerp(ColorList[Random.Range(0, ColorList.Count)], ColorList[Random.Range(0, ColorList.Count)], fadeStart);
        if (fadeStart < 1)
        {
            fadeStart += Time.deltaTime / fadeTime;
        }
    }
}
