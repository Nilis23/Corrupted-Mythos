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
    GameObject options;
    [SerializeField]
    GameObject playingUI;

    // Update is called once per frame
    void Update()
    {
        if(Pause.activeSelf || death.activeSelf || options.activeSelf)
        {
            playingUI.gameObject.SetActive(false);
        }
        else
        {
            playingUI.SetActive(true);
        }
    }
}
