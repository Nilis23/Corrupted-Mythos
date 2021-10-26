using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class SetSliderValue : MonoBehaviour
{
    public Slider slider;
    // Start is called before the first frame update
    void Start()
    {
        Settings settings = FindObjectOfType<Settings>();
        slider.value = settings.vol;
    }
}
