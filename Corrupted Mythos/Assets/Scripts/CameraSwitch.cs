using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitch : MonoBehaviour
{
    public GameObject C_Player;
    public GameObject C_Fixed;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.GetComponent<PlayerHealth>().Pcamera = C_Player;
            collision.GetComponent<PlayerHealth>().Fcamera = C_Fixed;


            C_Player.SetActive(false);
            C_Fixed.SetActive(true);
        }
    }
}
