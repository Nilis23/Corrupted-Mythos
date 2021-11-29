using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnCameraSwitch : MonoBehaviour
{
    public GameObject C_Player;
    public GameObject C_Fixed;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            C_Fixed.SetActive(false);
            C_Player.SetActive(true);
        }
    }
}
