using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextSliderValController : MonoBehaviour
{
    public Slider slider;
    public Text text;

    // Update is called once per frame
    void Start()
    {
        text.text = (Mathf.Round(slider.value * 100f)).ToString() + "%";
    }

    public void textChange(float value)
    {
        text.text = (Mathf.Round(value * 100f)).ToString() + "%";
    }
}
