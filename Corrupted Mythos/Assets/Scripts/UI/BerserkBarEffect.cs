using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BerserkBarEffect : MonoBehaviour
{

    void Start()
    {
        this.gameObject.SetActive(false);
        PlayerHealth.BerserkEffect += FlipActive;
    }

    private void OnEnable(){    }

    private void OnDisable()
    {
        //PlayerHealth.BerserkEffect -= FlipActive;
    }

    public void FlipActive(bool flip)
    {
        Debug.Log("effect happening");
        if (flip == true)
        {
            this.gameObject.SetActive(false);
        }
        else if (flip == false)
        {
            this.gameObject.SetActive(true);
        }
        else
        {
            Debug.Log("cant flip this?");
        }
    }
}
