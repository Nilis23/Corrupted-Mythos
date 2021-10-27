using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class signCntrl : MonoBehaviour
{
    [SerializeField]
    bool isImage;

    Transform mytext;
    Transform myImage;

    void Start()
    {
        mytext = transform.GetChild(0);
        myImage = transform.GetChild(1);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isImage)
        {
            myImage.gameObject.SetActive(true);
        }
        else
        {
            mytext.gameObject.SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (isImage)
        {
            myImage.gameObject.SetActive(false);
        }
        else
        {
            mytext.gameObject.SetActive(false);
        }
    }
}
