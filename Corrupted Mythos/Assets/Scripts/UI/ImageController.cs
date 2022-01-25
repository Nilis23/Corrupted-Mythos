using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageController : MonoBehaviour
{
    [SerializeField]
    Color active;
    [SerializeField]
    Color deactive;
    public void ActivateImage()
    {
       gameObject.GetComponent<Image>().color = active;
    }
    public void DeactivateImage()
    {
        gameObject.GetComponent<Image>().color = deactive;
    }
}
