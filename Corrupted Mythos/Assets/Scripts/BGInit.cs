using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGInit : MonoBehaviour
{
    [SerializeField]
    GameObject cam;
    // Start is called before the first frame update
    void Start()
    {
        this.transform.position = cam.transform.position;
    }
}
