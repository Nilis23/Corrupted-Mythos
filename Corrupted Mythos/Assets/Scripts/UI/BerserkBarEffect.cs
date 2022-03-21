using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BerserkBarEffect : MonoBehaviour
{
    private Image effect;

    void Awake()
    {
        PlayerHealth.BerserkEffect += FlipActive;
        effect = GetComponent<Image>();
        effect.enabled = false;
    }
    private void OnDisable()
    {
        PlayerHealth.BerserkEffect -= FlipActive;
    }
    public void FlipActive(bool flip)
    {
        Debug.Log("effect");
        if (flip)
        {
            Debug.Log("off");
            effect.enabled = false;
        }
        else if (!flip)
        {
            effect.enabled = true;
        }
        else
        {
            Debug.Log("cant flip this?");
        }
    }
}
