using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitch : MonoBehaviour
{
    public GameObject C_Player;
    public GameObject C_Fixed;
    private bool switched;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.GetComponent<PlayerHealth>().Pcamera = C_Player;
            collision.GetComponent<PlayerHealth>().Fcamera = C_Fixed;
            collision.GetComponent<PlayerMovement>().beserkLocator = C_Fixed.transform.GetChild(0).gameObject;

            C_Player.SetActive(false);
            C_Fixed.SetActive(true);
            switched = true;
        }
    }

    public void CameraSwap()
    {
        if (switched)
        {
            C_Fixed.SetActive(false);
            C_Player.SetActive(true);
            switched = false;
        }
    }
}
