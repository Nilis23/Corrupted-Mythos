using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayingUICntrl : MonoBehaviour
{
    [SerializeField]
    GameObject Pause;
    [SerializeField]
    GameObject death;
    [SerializeField]
    GameObject deathReload;
    [SerializeField]
    GameObject options;
    [SerializeField]
    GameObject playingUI;
    

    // Update is called once per frame
    void Update()
    {
        if(Pause.activeSelf || death.activeSelf || options.activeSelf || deathReload.activeSelf)
        {
            playingUI.gameObject.SetActive(false);
        }
        else
        {
            playingUI.SetActive(true);
        }
    }

    public void ShowPause()
    {
        Pause.SetActive(true);
    }
    public void ShowDeath()
    {
        death.SetActive(true);
    }
    public void HideDeath()
    {
        death.SetActive(false);
    }
    public void ShowDeathReload()
    {
        deathReload.SetActive(true);
    }
    public void ShowOptions()
    {
        options.SetActive(true);
    }
}
