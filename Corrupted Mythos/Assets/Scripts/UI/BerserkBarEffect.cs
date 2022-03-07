using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BerserkBarEffect : MonoBehaviour
{
    private Image effect;

    void Start()
    {
        PlayerHealth.BerserkEffect += FlipActive;
        effect = GetComponent<Image>();
        effect.enabled = false;
    }

    public void FlipActive(bool flip)
    {
        Debug.Log("effect happening");
        if (flip == true)
        {
            effect.enabled = false;
        }
        else if (flip == false)
        {
            effect.enabled = true;
        }
        else
        {
            Debug.Log("cant flip this?");
        }
    }
}
