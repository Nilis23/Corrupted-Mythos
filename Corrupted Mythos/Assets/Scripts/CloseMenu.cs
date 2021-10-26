using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        this.gameObject.GetComponent<MenuSetActive>().enabled = false;
        this.gameObject.SetActive(false);
    }
}
